﻿namespace SpeechTest
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
            this.textArea = new SpeechTest.MyTextBox();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(380, 990);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(408, 95);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 1027);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 32);
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
            "4"});
            this.ddlRate.Location = new System.Drawing.Point(144, 1015);
            this.ddlRate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ddlRate.Name = "ddlRate";
            this.ddlRate.Size = new System.Drawing.Size(220, 39);
            this.ddlRate.TabIndex = 4;
            this.ddlRate.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(860, 998);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(242, 85);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonWiki
            // 
            this.buttonWiki.Location = new System.Drawing.Point(860, 1106);
            this.buttonWiki.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonWiki.Name = "buttonWiki";
            this.buttonWiki.Size = new System.Drawing.Size(242, 72);
            this.buttonWiki.TabIndex = 7;
            this.buttonWiki.Text = "Wiki clean";
            this.buttonWiki.UseVisualStyleBackColor = true;
            this.buttonWiki.Click += new System.EventHandler(this.button3_Click);
            // 
            // chkIsXml
            // 
            this.chkIsXml.AutoSize = true;
            this.chkIsXml.Location = new System.Drawing.Point(56, 1180);
            this.chkIsXml.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkIsXml.Name = "chkIsXml";
            this.chkIsXml.Size = new System.Drawing.Size(102, 36);
            this.chkIsXml.TabIndex = 6;
            this.chkIsXml.Text = "Xml";
            this.chkIsXml.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 1106);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lang:";
            // 
            // ddlLang
            // 
            this.ddlLang.FormattingEnabled = true;
            this.ddlLang.Location = new System.Drawing.Point(144, 1100);
            this.ddlLang.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ddlLang.Name = "ddlLang";
            this.ddlLang.Size = new System.Drawing.Size(640, 39);
            this.ddlLang.TabIndex = 4;
            this.ddlLang.SelectedIndexChanged += new System.EventHandler(this.ddlLang_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(202, 1174);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(328, 79);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save to file";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(688, 1221);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(393, 32);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Where did I save that last file?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-2, 1283);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1154, 19);
            this.progressBar1.TabIndex = 14;
            // 
            // bgwrkSaveToFile
            // 
            this.bgwrkSaveToFile.WorkerReportsProgress = true;
            this.bgwrkSaveToFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwrkSaveToFile_DoWork);
            // 
            // textArea
            // 
            this.textArea.Location = new System.Drawing.Point(34, 50);
            this.textArea.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textArea.MaxLength = 2147483647;
            this.textArea.Multiline = true;
            this.textArea.Name = "textArea";
            this.textArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textArea.Size = new System.Drawing.Size(1066, 905);
            this.textArea.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 1302);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnSave);
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
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Blah Blah Speaquer";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonPlay;
		private MyTextBox textArea;
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
	}
}
