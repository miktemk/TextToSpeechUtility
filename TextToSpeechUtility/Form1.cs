using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SpeechLib;
using SpeechTest.Properties;
using System.Diagnostics;
using System.IO;

namespace SpeechTest
{
	public partial class Form1 : Form
	{
		private bool appRunning;
		private Thread checker;
		private SpVoice vox;
        private int languageIndex = 0;
        private string[] voiceNames;

		public Form1()
		{
			InitializeComponent();
            InitializeComponentMy();
		}

        private void InitializeComponentMy()
        {
			vox = new SpVoice();
            var voices = vox.GetVoices();
            voiceNames = new string[voices.Count];
            for (int i = 0; i < voices.Count; i++)
            {
                var voice = voices.Item(i);
                var name = voice.GetDescription();
                ddlLang.Items.Add(name);
                voiceNames[i] = name;
            }
        }

		private void SelectPreferredDefaultVoice()
		{
			if (voiceNames.Length > 0)
			{
				var indexOfEva = IndexOfLanguageByName("Microsoft Eva Mobile");
				if (indexOfEva != -1)
					ddlLang.SelectedIndex = indexOfEva;
				else
					ddlLang.SelectedIndex = 0;
			}
		}

		#region ------------------------ event handlers ------------------------

		private void Form1_Load(object sender, EventArgs e) {
			LastFolder = Path.GetDirectoryName(Application.ExecutablePath);

			ddlRate.SelectedItem = "2";
			checker = new Thread(CheckPlayState);
			checker.Start();
			appRunning = true;
			textArea.GotFocus += textArea_GotFocus;

			//SpeechSynthesizer synth = new SpeechSynthesizer();
			//var voices = synth.GetInstalledVoices();
			//var shit = voices.Select(x => x.VoiceInfo.Description).ToArray();
			//synth.SpeakAsync(new Prompt("hello you bitches I am the best"));

			// make textbox non editable
			// see: http://stackoverflow.com/questions/85702/how-can-i-make-a-combobox-non-editable-in-net
			ddlLang.DropDownStyle = ComboBoxStyle.DropDownList;
			SelectPreferredDefaultVoice();
		}
		
        // start button
        private void btnStart_Click(object sender, EventArgs e)
		{
			switch (vox.Status.RunningState)
			{
				case SpeechRunState.SRSEIsSpeaking:
					vox.Pause();
					buttonPlay.Text = Resources.Form1_button1_Text_Play;
					break;
				case SpeechRunState.SRSEDone:
					{
						SayIt();
						buttonPlay.Text = Resources.Form1_button1_Text_Pause;
					}
					break;
				default:
					vox.Resume();
					buttonPlay.Text = Resources.Form1_button1_Text_Pause;
					break;
			}
		}

		// stop button
		private void btnStop_Click(object sender, EventArgs e)
		{
			stopTalking();
			buttonPlay.Text = Resources.Form1_button1_Text_Play;
		}

        // wiki clean button
        private void btnWikiClean_Click(object sender, EventArgs e)
        {
            textArea.Text = textArea.Text.WikiStringStrip();
        }

        private void btnNoNewline_Click(object sender, EventArgs e)
        {
            textArea.Text = textArea.Text.RemoveAllNewlines();
        }

        private void btnAcronyms_Click(object sender, EventArgs e)
        {
            textArea.Text = textArea.Text.FixAcronymsForReadability();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            var fff = new SaveFileDialog() {
                //CheckFileExists = true,
                Filter = "WAV|*.wav",
            };
            var result = fff.ShowDialog();
            if (result != DialogResult.OK)
                return;

            LastFolder = Path.GetDirectoryName(fff.FileName);
            SayItToFile(fff.FileName);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnStart_Click(textArea, null);
            }
            else if (e.Control && e.KeyCode == Keys.W)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnWikiClean_Click(textArea, null);
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                textArea.SelectAll();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                ddlRate.SelectedItem = "7";
            }
            else if (e.Control && e.KeyCode == Keys.Oemplus)
            {
                if (ddlRate.SelectedIndex < ddlRate.Items.Count-1)
                    ddlRate.SelectedIndex++;
            }
            else if (e.Control && e.KeyCode == Keys.OemMinus)
            {
                if (ddlRate.SelectedIndex > 0)
                    ddlRate.SelectedIndex--;
            }
        }

        // rate DDL
        private void ddlRate_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var val = ddlRate.SelectedItem;
            var rate = 2;
            int.TryParse("" + val, out rate);
            vox.Rate = rate;

        }

        // language DDL
        private void ddlLang_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            languageIndex = ddlLang.SelectedIndex;
            if (voiceNames != null)
            {
                if (IsCurrentLanguageThisOne("Microsoft David Desktop") ||
                    IsCurrentLanguageThisOne("Microsoft Hazel Desktop") ||
                    IsCurrentLanguageThisOne("Microsoft Zira Desktop"))
                    ddlRate.SelectedItem = "2";
                if (IsCurrentLanguageThisOne("Microsoft Eva Mobile") ||
					IsCurrentLanguageThisOne("Microsoft Irina Desktop"))
                    ddlRate.SelectedItem = "7";
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            textArea.Focus();
            this.ActiveControl = textArea;
            textArea.SelectAll();
        }

        private void textArea_TextChanged(object sender, EventArgs e)
        {
            var langy = Utils.WhatLanguage(textArea.Text);
            if (langy == QLanguage.WTF)
                return;
            if (langy == QLanguage.Russian)
                SelectLang("Microsoft Irina Desktop");
            else if (langy != QLanguage.Russian && IsCurrentLanguageThisOne("Microsoft Irina Desktop"))
                SelectLang("Microsoft David Desktop");
        }

		private void textArea_GotFocus(object sender, EventArgs e)
		{
			textArea.SelectAll();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			Process.Start(LastFolder);
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			appRunning = false;
			//Trace.WriteLine("running set!!!!: " + appRunning);
			checker.Join();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
			Application.Exit();
		}

		#endregion

		#region ------------------------ private functions -----------------------------------

		//public void SayIt(string text){}
		private void SayIt()
		{
            vox.Voice = vox.GetVoices().Item(languageIndex);
			//vox.Speak("", SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
			try
			{
				var options = SpeechVoiceSpeakFlags.SVSFlagsAsync;
				//if (chkIsXml.Checked)
				//	options |= SpeechVoiceSpeakFlags.SVSFIsXML;
				vox.Speak(TextToSay, options);
				//vox.Speak("i can count green eggs.", SpeechVoiceSpeakFlags.SVSFlagsAsync);
				//vox.Speak("the best part is the end.", SpeechVoiceSpeakFlags.SVSFlagsAsync);
			}
			catch (Exception ex) { }
		}

		private void stopTalking()
		{
			vox.Resume();
			vox.Skip("Sentence", Int32.MaxValue);
		}

        private void SayItToFile(string filename) {
			bgwrkSaveToFile.RunWorkerAsync();
			SaveToFileFilename = filename;
        }


		//---------- checker thread ----------

		private void CheckPlayState()
		{
			MethodInvoker setText = delegate { buttonPlay.Text = Resources.Form1_button1_Text_Play; };
			while (appRunning)
			{
				Trace.WriteLine("running: " + appRunning);
				var state = vox.Status.RunningState;
				switch (vox.Status.RunningState)
				{
					case SpeechRunState.SRSEIsSpeaking:
						break;
					case SpeechRunState.SRSEDone:
						if (InvokeRequired)
							this.BeginInvoke(setText);
						break;
					default:
						break;
				}
				Thread.Sleep(200);
			}
		}

        private void SelectLang(string lang)
        {
            ddlLang.SelectedIndex = voiceNames.IndexOf(lang, (x, obj) => x.Contains(obj));
        }

        private bool IsCurrentLanguageThisOne(string lang)
        {
            return voiceNames[ddlLang.SelectedIndex].Contains(lang);
        }

		private int IndexOfLanguageByName(string lang)
		{
			// NOTE: copied from Miktemk, since we dont have linq/dlls here
			var index = 0;
			foreach (var x in voiceNames)
			{
				if (x.Contains(lang))
					return index;
				index++;
			}
			return -1;
		}

		#endregion

		#region ------------------------ global vars.... I mean, just vars, lol, not global ------------------------

		public string TextToSay {
            get {
                var text = textArea.Text;
                if (String.IsNullOrWhiteSpace(text))
                    text = "No text";
                return text;
            }
        }
        public string LastFolder { get; private set; }
		public string SaveToFileFilename { get; set; }

		#endregion

        #region ------------------------ background worker (saving in file) ------------------------

        private void bgwrkSaveToFile_DoWork(object sender, DoWorkEventArgs e) {
			var texts = TextToSay.SplitIntoPages();
			var index = 0;
			foreach (var text in texts) {
				vox.Voice = vox.GetVoices().Item(languageIndex);
				//vox.Speak("", SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
				try {
					bgwrkSaveToFile.ReportProgress(100 * index / texts.Length);
					index++;
					var options = SpeechVoiceSpeakFlags.SVSFlagsAsync;
					var stream = new SpFileStream();
					var filename = SaveToFileFilename.Replace(".wav", String.Format("_{0:D4}.wav", index));
					stream.Open(filename, SpeechStreamFileMode.SSFMCreateForWrite, true);
					vox.AudioOutputStream = stream;
					vox.Speak(text, options);
					vox.WaitUntilDone(100000);
					stream.Close();
					vox.AudioOutputStream = null;
				}
				catch (Exception ex) { }
			}
		}

		private void bgwrkSaveToFile_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			// Change the value of the ProgressBar to the BackgroundWorker progress.
			progressBar1.Value = e.ProgressPercentage;
			// Set the text.
			this.Text = "Saving to wav... " + e.ProgressPercentage.ToString() + "%";
		}

		private void bgwrkSaveToFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			this.Text = "Done saving.";
			progressBar1.Value = 100;
		}


        #endregion

    }
}
