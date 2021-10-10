namespace MediaPlayer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.cmdFolder = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.cmdSet = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblCurrentFolder = new System.Windows.Forms.Label();
            this.lblCurrentState = new System.Windows.Forms.Label();
            this.chbRepeat = new System.Windows.Forms.CheckBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.rabNo = new System.Windows.Forms.RadioButton();
            this.rabFolder = new System.Windows.Forms.RadioButton();
            this.rabFile = new System.Windows.Forms.RadioButton();
            this.grbRandom = new System.Windows.Forms.GroupBox();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.grbRandom.SuspendLayout();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(3, 212);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(270, 46);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            this.axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axWindowsMediaPlayer1_PlayStateChange);
            // 
            // cmdStart
            // 
            this.cmdStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdStart.Location = new System.Drawing.Point(98, 183);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 1;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdStop.Location = new System.Drawing.Point(185, 183);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(75, 23);
            this.cmdStop.TabIndex = 2;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // cmdFolder
            // 
            this.cmdFolder.Location = new System.Drawing.Point(2, 5);
            this.cmdFolder.Name = "cmdFolder";
            this.cmdFolder.Size = new System.Drawing.Size(75, 23);
            this.cmdFolder.TabIndex = 3;
            this.cmdFolder.Text = "Folder";
            this.cmdFolder.UseVisualStyleBackColor = true;
            this.cmdFolder.Click += new System.EventHandler(this.cmdFolder_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 25);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(260, 116);
            this.checkedListBox1.TabIndex = 5;
            // 
            // cmdSet
            // 
            this.cmdSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSet.Location = new System.Drawing.Point(15, 183);
            this.cmdSet.Name = "cmdSet";
            this.cmdSet.Size = new System.Drawing.Size(71, 21);
            this.cmdSet.TabIndex = 6;
            this.cmdSet.Text = "Set";
            this.cmdSet.UseVisualStyleBackColor = true;
            this.cmdSet.Click += new System.EventHandler(this.cmdSet_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(280, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(397, 208);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblCurrentFolder
            // 
            this.lblCurrentFolder.AutoSize = true;
            this.lblCurrentFolder.Location = new System.Drawing.Point(79, 8);
            this.lblCurrentFolder.Name = "lblCurrentFolder";
            this.lblCurrentFolder.Size = new System.Drawing.Size(35, 12);
            this.lblCurrentFolder.TabIndex = 8;
            this.lblCurrentFolder.Text = "label1";
            // 
            // lblCurrentState
            // 
            this.lblCurrentState.AutoSize = true;
            this.lblCurrentState.Location = new System.Drawing.Point(277, 8);
            this.lblCurrentState.Name = "lblCurrentState";
            this.lblCurrentState.Size = new System.Drawing.Size(35, 12);
            this.lblCurrentState.TabIndex = 9;
            this.lblCurrentState.Text = "label1";
            // 
            // chbRepeat
            // 
            this.chbRepeat.AutoSize = true;
            this.chbRepeat.Checked = global::MediaPlayer.Properties.Settings.Default.Repeat;
            this.chbRepeat.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MediaPlayer.Properties.Settings.Default, "Repeat", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chbRepeat.Location = new System.Drawing.Point(185, 161);
            this.chbRepeat.Name = "chbRepeat";
            this.chbRepeat.Size = new System.Drawing.Size(60, 16);
            this.chbRepeat.TabIndex = 10;
            this.chbRepeat.Text = "Repeat";
            this.chbRepeat.UseVisualStyleBackColor = true;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(281, 242);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(40, 12);
            this.lblSearch.TabIndex = 12;
            this.lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(326, 239);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(268, 19);
            this.txtSearch.TabIndex = 13;
            // 
            // cmdSearch
            // 
            this.cmdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSearch.Location = new System.Drawing.Point(596, 239);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(30, 19);
            this.cmdSearch.TabIndex = 14;
            this.cmdSearch.Text = "🔍";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // rabNo
            // 
            this.rabNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rabNo.AutoSize = true;
            this.rabNo.Checked = global::MediaPlayer.Properties.Settings.Default.RandomNo;
            this.rabNo.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MediaPlayer.Properties.Settings.Default, "RandomNo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rabNo.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rabNo.Location = new System.Drawing.Point(12, 10);
            this.rabNo.Name = "rabNo";
            this.rabNo.Size = new System.Drawing.Size(40, 18);
            this.rabNo.TabIndex = 0;
            this.rabNo.TabStop = true;
            this.rabNo.Text = "↓";
            this.rabNo.UseVisualStyleBackColor = true;
            this.rabNo.Click += new System.EventHandler(this.rabNo_Click);
            // 
            // rabFolder
            // 
            this.rabFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rabFolder.AutoSize = true;
            this.rabFolder.Checked = global::MediaPlayer.Properties.Settings.Default.RandomFolder;
            this.rabFolder.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MediaPlayer.Properties.Settings.Default, "RandomFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rabFolder.Location = new System.Drawing.Point(53, 11);
            this.rabFolder.Name = "rabFolder";
            this.rabFolder.Size = new System.Drawing.Size(55, 16);
            this.rabFolder.TabIndex = 1;
            this.rabFolder.Text = "Folder";
            this.rabFolder.UseVisualStyleBackColor = true;
            this.rabFolder.Click += new System.EventHandler(this.rabFolder_Click);
            // 
            // rabFile
            // 
            this.rabFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rabFile.AutoSize = true;
            this.rabFile.Checked = global::MediaPlayer.Properties.Settings.Default.RandomFile;
            this.rabFile.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::MediaPlayer.Properties.Settings.Default, "RandomFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rabFile.Location = new System.Drawing.Point(119, 11);
            this.rabFile.Name = "rabFile";
            this.rabFile.Size = new System.Drawing.Size(42, 16);
            this.rabFile.TabIndex = 2;
            this.rabFile.Text = "File";
            this.rabFile.UseVisualStyleBackColor = true;
            this.rabFile.Click += new System.EventHandler(this.rabFile_Click);
            // 
            // grbRandom
            // 
            this.grbRandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grbRandom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grbRandom.Controls.Add(this.rabFile);
            this.grbRandom.Controls.Add(this.rabFolder);
            this.grbRandom.Controls.Add(this.rabNo);
            this.grbRandom.Location = new System.Drawing.Point(3, 147);
            this.grbRandom.Name = "grbRandom";
            this.grbRandom.Size = new System.Drawing.Size(172, 31);
            this.grbRandom.TabIndex = 11;
            this.grbRandom.TabStop = false;
            this.grbRandom.Text = "Random";
            // 
            // cmdNext
            // 
            this.cmdNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNext.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmdNext.Location = new System.Drawing.Point(628, 239);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(23, 19);
            this.cmdNext.TabIndex = 15;
            this.cmdNext.Text = "→";
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBack.Location = new System.Drawing.Point(653, 239);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(23, 19);
            this.cmdBack.TabIndex = 16;
            this.cmdBack.Text = "×";
            this.cmdBack.UseVisualStyleBackColor = true;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = global::MediaPlayer.Properties.Settings.Default.サイズ;
            this.Controls.Add(this.cmdBack);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.grbRandom);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.chbRepeat);
            this.Controls.Add(this.lblCurrentState);
            this.Controls.Add(this.lblCurrentFolder);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cmdSet);
            this.Controls.Add(this.cmdFolder);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::MediaPlayer.Properties.Settings.Default, "位置", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::MediaPlayer.Properties.Settings.Default, "サイズ", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::MediaPlayer.Properties.Settings.Default.位置;
            this.Name = "Form1";
            this.Text = "PlayMusic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.grbRandom.ResumeLayout(false);
            this.grbRandom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Button cmdFolder;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button cmdSet;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblCurrentFolder;
        private System.Windows.Forms.Label lblCurrentState;
        private System.Windows.Forms.CheckBox chbRepeat;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.RadioButton rabNo;
        private System.Windows.Forms.RadioButton rabFolder;
        private System.Windows.Forms.RadioButton rabFile;
        private System.Windows.Forms.GroupBox grbRandom;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdBack;
    }
}

