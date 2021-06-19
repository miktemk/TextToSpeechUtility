namespace SpeechTest
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonPlay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlRate = new System.Windows.Forms.ComboBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonWiki = new System.Windows.Forms.Button();
            this.chkIsXml = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlLang = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bgwrkSaveToFile = new System.ComponentModel.BackgroundWorker();
            this.textArea = new System.Windows.Forms.RichTextBox();
            this.btnNoNewline = new System.Windows.Forms.Button();
            this.btnAcronyms = new System.Windows.Forms.Button();
            this.buttonSlackClean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(154, 463);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(153, 40);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 476);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rate:";
            // 
            // ddlRate
            // 
            this.ddlRate.FormattingEnabled = true;
            this.ddlRate.Items.AddRange(new object[] {
            "-4",
            "-3",
            "-2",
            "-1",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.ddlRate.Location = new System.Drawing.Point(55, 474);
            this.ddlRate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ddlRate.Name = "ddlRate";
            this.ddlRate.Size = new System.Drawing.Size(85, 21);
            this.ddlRate.TabIndex = 4;
            this.ddlRate.SelectedIndexChanged += new System.EventHandler(this.ddlRate_SelectedIndexChanged_1);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(323, 467);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(91, 36);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // buttonWiki
            // 
            this.buttonWiki.Location = new System.Drawing.Point(13, 3);
            this.buttonWiki.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonWiki.Name = "buttonWiki";
            this.buttonWiki.Size = new System.Drawing.Size(91, 23);
            this.buttonWiki.TabIndex = 7;
            this.buttonWiki.Text = "Wiki clean";
            this.buttonWiki.UseVisualStyleBackColor = true;
            this.buttonWiki.Click += new System.EventHandler(this.btnWikiClean_Click);
            // 
            // chkIsXml
            // 
            this.chkIsXml.AutoSize = true;
            this.chkIsXml.Location = new System.Drawing.Point(20, 522);
            this.chkIsXml.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chkIsXml.Name = "chkIsXml";
            this.chkIsXml.Size = new System.Drawing.Size(43, 17);
            this.chkIsXml.TabIndex = 6;
            this.chkIsXml.Text = "Xml";
            this.chkIsXml.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 439);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lang:";
            // 
            // ddlLang
            // 
            this.ddlLang.DropDownHeight = 200;
            this.ddlLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlLang.FormattingEnabled = true;
            this.ddlLang.IntegralHeight = false;
            this.ddlLang.Location = new System.Drawing.Point(63, 432);
            this.ddlLang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ddlLang.Name = "ddlLang";
            this.ddlLang.Size = new System.Drawing.Size(352, 28);
            this.ddlLang.TabIndex = 4;
            this.ddlLang.SelectedIndexChanged += new System.EventHandler(this.ddlLang_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(80, 513);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 33);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save to file";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(265, 525);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(150, 13);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Where did I save that last file?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 551);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(433, 8);
            this.progressBar1.TabIndex = 14;
            // 
            // bgwrkSaveToFile
            // 
            this.bgwrkSaveToFile.WorkerReportsProgress = true;
            this.bgwrkSaveToFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwrkSaveToFile_DoWork);
            this.bgwrkSaveToFile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwrkSaveToFile_ProgressChanged);
            this.bgwrkSaveToFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwrkSaveToFile_RunWorkerCompleted);
            // 
            // textArea
            // 
            this.textArea.Location = new System.Drawing.Point(13, 30);
            this.textArea.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textArea.Name = "textArea";
            this.textArea.Size = new System.Drawing.Size(402, 394);
            this.textArea.TabIndex = 1;
            this.textArea.Text = "";
            this.textArea.TextChanged += new System.EventHandler(this.textArea_TextChanged);
            // 
            // btnNoNewline
            // 
            this.btnNoNewline.Location = new System.Drawing.Point(209, 4);
            this.btnNoNewline.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnNoNewline.Name = "btnNoNewline";
            this.btnNoNewline.Size = new System.Drawing.Size(80, 20);
            this.btnNoNewline.TabIndex = 15;
            this.btnNoNewline.Text = "no \\n";
            this.btnNoNewline.UseVisualStyleBackColor = true;
            this.btnNoNewline.Click += new System.EventHandler(this.btnNoNewline_Click);
            // 
            // btnAcronyms
            // 
            this.btnAcronyms.Location = new System.Drawing.Point(291, 4);
            this.btnAcronyms.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnAcronyms.Name = "btnAcronyms";
            this.btnAcronyms.Size = new System.Drawing.Size(69, 20);
            this.btnAcronyms.TabIndex = 16;
            this.btnAcronyms.Text = "acronyms";
            this.btnAcronyms.UseVisualStyleBackColor = true;
            this.btnAcronyms.Click += new System.EventHandler(this.btnAcronyms_Click);
            // 
            // buttonSlackClean
            // 
            this.buttonSlackClean.Location = new System.Drawing.Point(108, 3);
            this.buttonSlackClean.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSlackClean.Name = "buttonSlackClean";
            this.buttonSlackClean.Size = new System.Drawing.Size(91, 23);
            this.buttonSlackClean.TabIndex = 7;
            this.buttonSlackClean.Text = "Slack clean";
            this.buttonSlackClean.UseVisualStyleBackColor = true;
            this.buttonSlackClean.Click += new System.EventHandler(this.buttonSlackClean_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(433, 559);
            this.Controls.Add(this.btnAcronyms);
            this.Controls.Add(this.btnNoNewline);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.buttonSlackClean);
            this.Controls.Add(this.buttonWiki);
            this.Controls.Add(this.chkIsXml);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.ddlLang);
            this.Controls.Add(this.ddlRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textArea);
            this.Controls.Add(this.buttonPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Blah Blah Speaquer";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonPlay;
		private System.Windows.Forms.RichTextBox textArea;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox ddlRate;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonWiki;
        private System.Windows.Forms.CheckBox chkIsXml;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlLang;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.ComponentModel.BackgroundWorker bgwrkSaveToFile;
        private System.Windows.Forms.Button btnNoNewline;
        private System.Windows.Forms.Button btnAcronyms;
        private System.Windows.Forms.Button buttonSlackClean;
    }
}

