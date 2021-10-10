using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MediaPlayer
{

    public partial class Form1 : Form
    {
        List<MusicFolder> MFolders = new List<MusicFolder>();
        List<MusicFile> MFiles = new List<MusicFile>();
        List<string> playlist = new List<string> { };
        string currentFolder;
        string FirstItem;
        bool LastItemPlaying;
        double currentPosition;

        public Form1()
        {
            InitializeComponent();

            this.checkedListBox1.HorizontalScrollbar = true;
            this.listBox1.HorizontalScrollbar = true;
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            int selectedItem = this.listBox1.SelectedIndex;
            if (selectedItem < 0)
                selectedItem = 0;

            // Ensure that the previous media item is stopped.
            this.axWindowsMediaPlayer1.Ctlcontrols.stop();

            // Set the current item to the item selected from the list box.
            this.axWindowsMediaPlayer1.Ctlcontrols.currentItem = this.axWindowsMediaPlayer1.currentPlaylist.get_Item(selectedItem);

            // Play the current item.
            if (this.axWindowsMediaPlayer1.Ctlcontrols.get_isAvailable("play"))
            {
                try
                {
                    this.axWindowsMediaPlayer1.Ctlcontrols.play();
                    this.axWindowsMediaPlayer1.Ctlcontrols.currentPosition = this.currentPosition;
                }
                catch
                {
                }
            }
            nowTitle = "";
            search = null;
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            //再生しているオーディオを停止する Stop playing audio
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void cmdFolder_Click(object sender, EventArgs e)
        {
            IEnumerable<string> Folders;
            string selectedPath = "";

            Folders = null;
            string Path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            //Console.WriteLine(Path);
            //フォルダを列挙する
            string[] subFolders = System.IO.Directory.GetDirectories(Path, "*", System.IO.SearchOption.TopDirectoryOnly);
            foreach (string FName in subFolders)
            {
                selectedPath = FName;
                break;
            }

            //FolderBrowserDialogクラスのインスタンスを作成 Create an instance of the class
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する Specify the descriptive text to display at the top
            fbd.Description = "Please specify a music folder."; //音楽のフォルダを指定してください。";
            //ルートフォルダを指定する Specify the root folder
            //デフォルトでDesktop  Desktop by default
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //fbd.RootFolder = Environment.SpecialFolder.MyMusic;
            //fbd.RootFolder = Environment.SpecialFolder.Personal;
            //fbd.RootFolder = Path;
            //最初に選択するフォルダを指定する  Specify the folder to select first
            //RootFolder以下にあるフォルダである必要がある  Must be a folder under RootFolder
            fbd.SelectedPath = selectedPath;
            //ユーザーが新しいフォルダを作成できるようにする  Allow users to create new folders
            //デフォルトでTrue  True by default
            fbd.ShowNewFolderButton = false;

            MFolders.Clear();
            //ダイアログを表示する  Display a dialog
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                this.currentFolder = fbd.SelectedPath;
                string Parent = System.IO.Directory.GetParent(fbd.SelectedPath).ToString();
                this.currentFolder = this.currentFolder.Replace(Parent, "");
                this.currentFolder = this.currentFolder.Replace(@"\", "");
                this.lblCurrentFolder.Text = this.currentFolder;

                this.checkedListBox1.Items.Clear();

                //トップフォルダを取得する  Get the top folder
                Folders = System.IO.Directory.EnumerateDirectories(fbd.SelectedPath, "*", System.IO.SearchOption.TopDirectoryOnly);

                this.MFolders.Clear();
                //フォルダを列挙する  List folders
                foreach (string subFolder in Folders)
                {
                    string FolderName = System.IO.Path.GetDirectoryName(subFolder);
                    FolderName = subFolder.Replace(FolderName, "");
                    FolderName = FolderName.Replace(@"\", "");

                    this.checkedListBox1.Items.Add(FolderName);

                    MusicFolder MF = new MusicFolder();
                    MF.Name = FolderName;
                    MF.Path = subFolder;
                    MF.Checked = false;
                    MF.ID = System.Guid.NewGuid();
                    MF.SubFolder = false;
                    MFolders.Add(MF);
                }
            }
        }

        private void cmdSet_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you want to rebuild the file？", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            //DialogResult result = MessageBox.Show("ファイルを再構築しますか？","質問", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.No)
            {
                return;
            }

            this.playlist.Clear();
            this.listBox1.Items.Clear();
            this.axWindowsMediaPlayer1.currentPlaylist.clear();
            this.FirstItem = "";
            this.MFiles.Clear();

            foreach (MusicFolder MF in this.MFolders)
            {
                MF.Checked = false;
            }

            foreach (string str in this.checkedListBox1.CheckedItems)
            {
                MusicFolder MF = MFolders.Find(ee => ee.Name == str);

                MF.Checked = true;
                MF.ID = System.Guid.NewGuid();
            }

            List<MusicFolder> CheckedMF = MFolders.FindAll(ee => ee.Checked == true);

            foreach (MusicFolder MF in CheckedMF)
            {
                //Console.WriteLine(MF.Name);
                //Console.WriteLine(MF.Path);
                //全てのサブフォルダを取得する  Get all subfolders
                IEnumerable<string> subFolders = System.IO.Directory.EnumerateDirectories(MF.Path, "*", System.IO.SearchOption.AllDirectories);
                foreach (string folder in subFolders)
                {
                    string FolderName = System.IO.Path.GetDirectoryName(folder);
                    FolderName = folder.Replace(FolderName, "");
                    FolderName = FolderName.Replace(@"\", "");
                    MusicFolder subMF = new MusicFolder();
                    subMF.Name = FolderName;
                    subMF.Path = folder;
                    subMF.Checked = false;
                    subMF.ID = System.Guid.NewGuid();
                    subMF.SubFolder = true;
                    this.MFolders.Add(subMF);

                    string[] files = System.IO.Directory.GetFiles(folder, "*");
                    foreach (string path in files)
                    {
                        //Console.WriteLine(path);
                        string extension = System.IO.Path.GetExtension(path);
                        if (extension.IndexOf("m4a") > 0 || extension.IndexOf("wav") > 0 || extension.IndexOf("avi") > 0 || extension.IndexOf("aac") > 0 || extension.IndexOf("adt") > 0 || extension.IndexOf("adts") > 0)
                        {
                            string Parent;
                            FolderName = myGetDirectoryName(path, out Parent);
                            string FileName = myGetFileName(path, Parent, FolderName);

                            MusicFile MFI = new MusicFile();
                            MFI.ID = System.Guid.NewGuid();
                            MFI.FolderID = subMF.ID;
                            MFI.Path = path;
                            MFI.ListName = FolderName + " : " + FileName;
                            MFI.FolderName = subMF.Name;
                            MFI.Title = System.IO.Path.GetFileNameWithoutExtension(path);
                            this.MFiles.Add(MFI);
                        }
                    }
                }
            }

            IEnumerable<MusicFile>  filelist;
            if (this.rabNo.Checked == true)
            {
                filelist = from file in MFiles
                            select file;
            }
            else if (this.rabFolder.Checked == true)
            {
                filelist = from file in MFiles
                            orderby file.FolderID
                            select file;
            }
            else //if (this.rabFile.Checked == true)
            {
                filelist = from file in MFiles
                            orderby file.ID
                            select file;
            }

            foreach (var file in filelist)
            {
                this.playlist.Add(file.Path);
                this.listBox1.Items.Add(file.ListName);
                if (this.FirstItem == "")
                {
                    this.FirstItem = file.ListName;
                }
            }
            this.listBox1.ClearSelected();
            this.listBox1.Text = this.FirstItem;

            foreach (string song in this.playlist)
            {
                WMPLib.IWMPMedia songs = this.axWindowsMediaPlayer1.newMedia(song);
                this.axWindowsMediaPlayer1.currentPlaylist.appendItem(songs);
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.axWindowsMediaPlayer1.Ctlcontrols.get_isAvailable("currentPosition"))
            {
                Console.WriteLine(this.axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
                this.currentPosition = this.axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            }

            string appPath = Application.StartupPath;// System.Reflection.Assembly.GetExecutingAssembly().Location;
            appPath += @"\FoldersAndFiles.txt";
            Console.WriteLine(appPath);

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    appPath,
                    false,
                    System.Text.Encoding.GetEncoding("utf-8"))) // shift_jis")))
            {
                try
                {
                    //ファイルを上書きし、Shift JISで書き込む
                    //System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    //    appPath,
                    //    false,
                    //    System.Text.Encoding.GetEncoding("shift_jis"));

                    string line;

                    line = '"' + this.currentFolder + '"';
                    sw.WriteLine(line);

                    List<MusicFolder> notSubMF = MFolders.FindAll(ee => ee.SubFolder == false);
                    foreach (MusicFolder MF in notSubMF)
                    {
                        line = '"' + MF.Name + '"' + "," + '"' + MF.Path + '"' + "," + '"' + MF.Checked + '"';
                        sw.WriteLine(line);
                    }
                    foreach (string song in this.playlist)
                    {
                        sw.WriteLine('"' + song + '"');
                    }

                    sw.WriteLine('"' + "SELECT" + '"' + "," + '"' + this.listBox1.Text + '"' + "," + '"' + this.currentPosition + '"' + "," + this.axWindowsMediaPlayer1.settings.volume);

                    sw.Close();
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    sw.Close();
                }
            }
            Properties.Settings.Default.Save( );
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            this.MFolders.Clear();
            this.playlist.Clear();
            this.checkedListBox1.Items.Clear();
            this.listBox1.Items.Clear();
            this.FirstItem = "";
            this.chbRepeat.Checked = Properties.Settings.Default.Repeat;
            this.LastItemPlaying = false;
            this.currentPosition = 0;

            this.Form1_Resize(this, EventArgs.Empty);
    
            string appPath = Application.StartupPath;// System.Reflection.Assembly.GetExecutingAssembly().Location;
            appPath += @"\FoldersAndFiles.txt";
            //Console.WriteLine(appPath);

            if (System.IO.File.Exists(appPath) == false)
            {
                using (System.IO.FileStream fs = System.IO.File.Create(appPath))
                {
                    fs.Close();
                }
            }

            using (System.IO.StreamReader sr = new System.IO.StreamReader(
                    appPath,
                    System.Text.Encoding.GetEncoding("utf-8"))) // shift_jis")))
            {
                try
                {
                    while (sr.Peek() > -1)
                    {
                        this.currentFolder = sr.ReadLine();
                        this.currentFolder = this.currentFolder.Replace("\"", "");
                        this.lblCurrentFolder.Text = this.currentFolder;

                        break;
                    }
                    //内容を一行ずつ読み込む  Read the contents line by line
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        string[] splitLine = line.Split(',');
                        if (splitLine.Length == 3)
                        {
                            splitLine[0] = RemoveDQ(splitLine[0]);
                            splitLine[1] = RemoveDQ(splitLine[1]);
                            splitLine[2] = RemoveDQ(splitLine[2]);

                            MusicFolder MF = new MusicFolder();
                            MF.Name = splitLine[0];
                            MF.Path = splitLine[1];
                            if (splitLine[2] == "True")
                            {
                                MF.Checked = true;
                                this.checkedListBox1.Items.Add(MF.Name, CheckState.Checked);
                            }
                            else
                            {
                                MF.Checked = false;
                                this.checkedListBox1.Items.Add(MF.Name);
                            }
                            MFolders.Add(MF);
                        }
                        else if (splitLine.Length == 1)
                        {
                            splitLine[0] = RemoveDQ(splitLine[0]);

                            this.playlist.Add(splitLine[0]);
                            //Console.WriteLine(splitLine[0]);

                            string Parent;
                            string FolderName = myGetDirectoryName(splitLine[0], out Parent);
                            string FileName = myGetFileName(splitLine[0], Parent, FolderName);

                            this.listBox1.Items.Add(FolderName + " : " + FileName);
                            if (this.FirstItem == "")
                            {
                                this.FirstItem = FolderName + " : " + FileName;
                            }

                            MusicFile MFI = new MusicFile();
                            MFI.ID = System.Guid.NewGuid();
                            //MFI.FolderID = subMF.ID;
                            //MFI.Path = path;
                            MFI.ListName = FolderName + " : " + FileName;
                            MFI.Title = System.IO.Path.GetFileNameWithoutExtension(splitLine[0]);

                            FolderName = System.IO.Path.GetDirectoryName(Parent);
                            FolderName = Parent.Replace(FolderName, "");
                            FolderName = FolderName.Replace(@"\", "");

                            MFI.FolderName = FolderName;
                            this.MFiles.Add(MFI);
                        }
                        else if (splitLine.Length == 4)
                        {
                            splitLine[1] = RemoveDQ(splitLine[1]);
                            this.listBox1.Text = splitLine[1];
                            splitLine[2] = RemoveDQ(splitLine[2]);
                            this.currentPosition = double.Parse(splitLine[2]);
                            this.axWindowsMediaPlayer1.settings.volume = Int32.Parse(splitLine[3]);

                            MusicFile MFI = this.MFiles.Find(ee => ee.ListName == this.listBox1.Text);
                            if (MFI != null)
                            {
                                MusicFolder MF = this.MFolders.Find(ee => ee.Name == MFI.FolderName);
                                this.checkedListBox1.Text = MF.Name;
                            }
                        }
                    }
                    //閉じる
                    sr.Close();
                }
                catch
                {
                    sr.Close();
                }

                foreach (string song in this.playlist)
                {
                    WMPLib.IWMPMedia songs = this.axWindowsMediaPlayer1.newMedia(song);
                    this.axWindowsMediaPlayer1.currentPlaylist.appendItem(songs);
                }

                int selectedItem = this.listBox1.SelectedIndex;
                try
                {
                    this.axWindowsMediaPlayer1.Ctlcontrols.currentItem = this.axWindowsMediaPlayer1.currentPlaylist.get_Item(selectedItem);
                    this.axWindowsMediaPlayer1.Ctlcontrols.currentPosition = this.currentPosition;
                }
                catch(System.Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            nowTitle = this.listBox1.Text;

            //Shift-JISコードとして開く
            //System.IO.StreamReader sr = new System.IO.StreamReader(
            //        appPath,
            //        System.Text.Encoding.GetEncoding("shift_jis"));
            //try
            //{
            //    System.IO.StreamReader sr = new System.IO.StreamReader(
            //        appPath,
            //        System.Text.Encoding.GetEncoding("shift_jis"));
            //}
            //catch (System.Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.Width < 700)
                this.Width = 700;

            if (this.Height < 300)
                this.Height = 300;

            this.axWindowsMediaPlayer1.Top = this.Height - 88;
            this.cmdSet.Top = this.Height - 117;
            this.cmdStart.Top = this.Height - 117;
            this.cmdStop.Top = this.Height - 117;
            this.chbRepeat.Top = this.Height - 139;
            this.checkedListBox1.Height = this.Height - 25 - 159;
            this.listBox1.Height = this.Height - 25 - 67;
            this.lblSearch.Top = this.Height - 58;
            this.txtSearch.Top = this.Height - 61;
            this.cmdSearch.Top = this.Height - 61;
            this.listBox1.Width = this.Width - 280 - 23;
        }

        private string PreviousState;
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Test the current state of the player and display a message for each state.
            switch (e.newState)
            {
                case 0:    // Undefined
                    this.lblCurrentState.Text = "Undefined";
                    break;

                case 1:    // Stopped
                    this.lblCurrentState.Text = "Stopped";
                    break;

                case 2:    // Paused
                    this.lblCurrentState.Text = "Paused";
                    break;

                case 3:    // Playing
                    int index = 0;
                    for (int i = 0; i < this.axWindowsMediaPlayer1.currentPlaylist.count; i++)
                    {
                        if (this.axWindowsMediaPlayer1.currentMedia.isIdentical[this.axWindowsMediaPlayer1.currentPlaylist.Item[i]])
                        {
                            index = i;
                            break;
                        }
                    }
                    this.lblCurrentState.Text = "Playing 【" + (index+1).ToString() +   "】 " + 
                        "(" + this.axWindowsMediaPlayer1.currentPlaylist.Item[index].durationString +")" +
                        this.axWindowsMediaPlayer1.currentPlaylist.Item[index].name;
                    this.listBox1.SelectedIndex = index;

                    if (this.axWindowsMediaPlayer1.currentPlaylist.count == this.listBox1.SelectedIndex + 1)
                    {
                        this.LastItemPlaying = true;
                    }
                    else
                    {
                        this.LastItemPlaying = false;
                    }

                    //Console.WriteLine(this.listBox1.Text);
                    MusicFile MFI = this.MFiles.Find(ee => ee.ListName == this.listBox1.Text);
                    MusicFolder MF = this.MFolders.Find(ee => ee.Name == MFI.FolderName);
                    this.checkedListBox1.Text = MF.Name;
                    break;

                case 4:    // ScanForward
                    this.lblCurrentState.Text = "ScanForward";
                    break;

                case 5:    // ScanReverse
                    this.lblCurrentState.Text = "ScanReverse";
                    break;

                case 6:    // Buffering
                    this.lblCurrentState.Text = "Buffering";
                    break;

                case 7:    // Waiting
                    this.lblCurrentState.Text = "Waiting";
                    break;

                case 8:    // MediaEnded
                    this.lblCurrentState.Text = "MediaEnded";
                    break;

                case 9:    // Transitioning
                    this.lblCurrentState.Text = "Transitioning";
                    break;

                case 10:   // Ready
                    this.lblCurrentState.Text = "Ready";
                    if (this.PreviousState == "Transitioning" && this.lblCurrentState.Text == "Ready" && this.chbRepeat.Checked == true)
                    {
                        if (this.LastItemPlaying == true)
                        {
                            this.listBox1.SelectedIndex = 0;
                            this.cmdStart.PerformClick();
                        }
                    }                    
                    break;

                case 11:   // Reconnecting
                    this.lblCurrentState.Text = "Reconnecting";
                    break;

                case 12:   // Last
                    this.lblCurrentState.Text = "Last";
                    break;

                default:
                    this.lblCurrentState.Text = ("Unknown State: " + e.newState.ToString());
                    break;
            }
            this.PreviousState = this.lblCurrentState.Text;
        }

        private string myGetFileName(string path, string Parent, string FolderName)
        {
            string FileName = path;
            FileName = FileName.Replace(Parent, "");
            FileName = FileName.Replace(FolderName, "");
            FileName = FileName.Replace(@"\", "");
            return FileName;
        }

        private string myGetDirectoryName(string path, out string Parent)
        {
            string FolderName = System.IO.Path.GetDirectoryName(path);
            Parent = System.IO.Directory.GetParent(FolderName).ToString();
            FolderName = FolderName.Replace(Parent, "");
            FolderName = FolderName.Replace(@"\", "");
            return FolderName;
        }

        private string RemoveDQ(string str)
        {
            return Mid(str, 2, str.Length - 2);
        }

        /// <summary>
        /// 文字列の指定した位置から指定した長さを取得する  Get the specified length from the specified position of the string
        /// </summary>
        /// <param name="str">文字列</param>    String
        /// <param name="start">開始位置</param>   Starting position
        /// <param name="len">長さ</param>   length
        /// <returns>取得した文字列</returns>   Obtained character string
        public static string Mid(string str, int start, int len)
        {
            if (start <= 0)
            {
                throw new ArgumentException("Argument'start' must be greater than or equal to 1"); // 引数'start'は1以上でなければなりません。");
            }
            if (len < 0)
            {
                throw new ArgumentException("Argument'len' must be greater than or equal to 0"); // 引数'len'は0以上でなければなりません。");
            }
            if (str == null || str.Length < start)
            {
                return "";
            }
            if (str.Length < (start + len))
            {
                return str.Substring(start - 1);
            }
            return str.Substring(start - 1, len);
        }

        /// <summary>
        /// 文字列の指定した位置から末尾までを取得する Get from the specified position of the string to the end
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="start">開始位置</param>
        /// <returns>取得した文字列</returns>
        public static string Mid(string str, int start)
        {
            return Mid(str, start, str.Length);
        }

        /// <summary>
        /// 文字列の先頭から指定した長さの文字列を取得する Get a string of the specified length from the beginning of the string
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="len">長さ</param>
        /// <returns>取得した文字列</returns>
        public static string Left(string str, int len)
        {
            if (len < 0)
            {
                throw new ArgumentException("Argument'len' must be greater than or equal to 0"); // 引数'len'は0以上でなければなりません。");
            }
            if (str == null)
            {
                return "";
            }
            if (str.Length <= len)
            {
                return str;
            }
            return str.Substring(0, len);
        }

        /// <summary>
        /// 文字列の末尾から指定した長さの文字列を取得する  Get a string of the specified length from the end of the string
        /// </summary>
        /// <param name="str">文字列</param>
        /// <param name="len">長さ</param>
        /// <returns>取得した文字列</returns>
        public static string Right(string str, int len)
        {
            if (len < 0)
            {
                throw new ArgumentException("Argument'len' must be greater than or equal to 0"); // 引数'len'は0以上でなければなりません。");
            }
            if (str == null)
            {
                return "";
            }
            if (str.Length <= len)
            {
                return str;
            }
            return str.Substring(str.Length - len, len);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentPosition = 0;
        }

        IEnumerable<MusicFile> search = null;
        string nowTitle = "";
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            this.cmdNext.Enabled = true;
            nowTitle = this.listBox1.Text;

            search = from file in MFiles
                         where file.Title.Contains(this.txtSearch.Text)
                         select file;
            if (search.Count() >= 1)
            {
                foreach (MusicFile MFI in search)
                {
                    this.listBox1.Text = MFI.ListName;
                    break;
                }
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            bool GoNext = false;

            if (search !=null && search.Count() >= 1)
            {
                foreach (MusicFile MFI in search)
                {
                    if (GoNext == true)
                    {
                        this.listBox1.Text = MFI.ListName;
                        break;
                    }
                    if (this.listBox1.Text == MFI.ListName)
                    {
                        GoNext = true;
                    }
                }
            }
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            if (search != null && search.Count() >= 1 && nowTitle != "")
            {
                this.listBox1.Text = nowTitle;
                nowTitle = "";
                search = null;
            }
        }

        private void rabNo_Click(object sender, EventArgs e)
        {
            this.rabNo.Checked = true;
        }

        private void rabFolder_Click(object sender, EventArgs e)
        {
            this.rabFolder.Checked = true;
        }

        private void rabFile_Click(object sender, EventArgs e)
        {
            this.rabFile.Checked = true;
        }
    }

    public class MusicFolder
    {
        public Guid ID;
        public string Name;
        public string Path;
        public bool Checked;
        public bool SubFolder;
    }

    public class MusicFile
    {
        public Guid ID;
        public Guid FolderID;
        public string Path;
        public string ListName;
        public string FolderName;
        public string Title;
    }
}

//
//自動スタート
//axWindowsMediaPlayer1.settings.autoStart = false;

//再生ファイル名
//axWindowsMediaPlayer1.URL = "c:\\xxxxxxxxxx.avi";

//再生ファイルの現在位置
//axWindowsMediaPlayer1.Ctlcontrols.currentPosition = 500;

//音量（0～100）
//axWindowsMediaPlayer1.settings.volume = 5;

//音量バランス（-50～50）
//axWindowsMediaPlayer1.settings.balance = 0;

//ミュート
//axWindowsMediaPlayer1.settings.mute

//再生開始
//axWindowsMediaPlayer1.Ctlcontrols.play();

//再生停止
//axWindowsMediaPlayer1.Ctlcontrols.stop();

//再生一時停止コマンド
//axWindowsMediaPlayer1.Ctlcontrols.pause();

//早戻し
//axWindowsMediaPlayer1.Ctlcontrols.fastReverse();

//早送り
//axWindowsMediaPlayer1.Ctlcontrols.fastForward();

//再生位置(秒数)
//Ctlcontrols.currentPosition

//再生位置(mm:ss形式)
//Ctlcontrols.currentPositionString

//消音
//settings.mute