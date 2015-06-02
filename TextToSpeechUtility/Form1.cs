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
using System.Speech.Synthesis;
using System.Diagnostics;
using System.IO;

namespace SpeechTest
{
	public partial class Form1 : Form
	{
		private bool appRunning;
		private Thread checker;
		private readonly SpVoice vox;
        private int languageIndex = 0;
        private string[] voiceNames;

		public Form1()
		{
			InitializeComponent();

            vox = new SpVoice();
            InitializeComponentMy();

            LastFolder = Path.GetDirectoryName(Application.ExecutablePath);
            
            ddlRate.SelectedItem = "2";
			checker = new Thread(CheckPlayState);
			checker.Start();
			appRunning = true;
            textArea.GotFocus += textBox1_GotFocus;

            SpeechSynthesizer synth = new SpeechSynthesizer();
            var voices = synth.GetInstalledVoices();
            var shit = voices.Select(x => x.VoiceInfo.Description).ToArray();
            //synth.SpeakAsync(new Prompt("hello you bitches I am the best"));
		}

        private void InitializeComponentMy()
        {
            var voices = vox.GetVoices();
            voiceNames = new string[voices.Count];
            for (int i = 0; i < voices.Count; i++)
            {
                var voice = voices.Item(i);
                var name = voice.GetDescription();
                ddlLang.Items.Add(name);
                voiceNames[i] = name;
            }
            if (voices.Count > 0)
                ddlLang.SelectedIndex = 0;
        }

		#region event handlers

        // start button
        private void button1_Click(object sender, EventArgs e)
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
		private void button2_Click(object sender, EventArgs e)
		{
			stopTalking();
			buttonPlay.Text = Resources.Form1_button1_Text_Play;
		}

        // wiki clean button
        private void button3_Click(object sender, EventArgs e)
        {
            textArea.Text = textArea.Text.WikiStringStrip();
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

        // rate DDL
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
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
                if (voiceNames[languageIndex].Contains("Microsoft David Desktop") ||
                    voiceNames[languageIndex].Contains("Microsoft Hazel Desktop") ||
                    voiceNames[languageIndex].Contains("Microsoft Zira Desktop"))
                    ddlRate.SelectedItem = "2";
                if (voiceNames[languageIndex].Contains("Microsoft Irina Desktop"))
                    ddlRate.SelectedItem = "3";
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            textArea.Focus();
            this.ActiveControl = textArea;
            textArea.SelectAll();
        }

		private void textBox1_GotFocus(object sender, EventArgs e)
		{
			textArea.SelectAll();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			appRunning = false;
			Trace.WriteLine("running set!!!!: " + appRunning);
			checker.Join();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
			Application.Exit();
		}

		#endregion

		#region private functions

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

		#endregion


        public string TextToSay {
            get {
                var text = textArea.Text;
                if (String.IsNullOrWhiteSpace(text))
                    text = "No text";
                return text;
            }
        }

        public string LastFolder { get; private set; }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(LastFolder);
        }

		public string SaveToFileFilename { get; set; }
		private void bgwrkSaveToFile_DoWork(object sender, DoWorkEventArgs e) {
			var texts = TextToSay.SplitIntoPages();
			var index = 0;
			foreach (var text in texts) {
				vox.Voice = vox.GetVoices().Item(languageIndex);
				//vox.Speak("", SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
				try {
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
					bgwrkSaveToFile.ReportProgress(100 * index / texts.Length);
				}
				catch (Exception ex) { }
			}
		}

		private void bgwrkSaveToFile_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			// Change the value of the ProgressBar to the BackgroundWorker progress.
			progressBar1.Value = e.ProgressPercentage;
			// Set the text.
			this.Text = e.ProgressPercentage.ToString();
		}

	}
}
