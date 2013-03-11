using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices; 
//using SAMPLETTSENGLib;
using System.Threading;
using SpeechLib;

namespace ToneGenerator
{
	/// <summary>
	/// This application is used to define and test tones for use in the 
	/// warning/caution/advisory system.  It supports sine and sawtooth
	/// wave forms and can be used to define tones in accordance with 
	/// MIL-STD-411F (or other non-standardized aural alerts)
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		[DllImport("kernel32.dll")]
		private static extern bool Beep( int frequency, int duration );

		private SpeechVoiceSpeakFlags SpFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
		private SpVoice Voice = new SpVoice();

		private System.Windows.Forms.GroupBox gbxParameters;
		private System.Windows.Forms.TextBox txtDuration;
		private System.Windows.Forms.Label lblSteps;
		private System.Windows.Forms.TextBox txtSteps;
		private System.Windows.Forms.Button btnPlayAdhoc;
		private System.Windows.Forms.GroupBox gbxPresets;
		private System.Windows.Forms.ComboBox cboPresets;
		private System.Windows.Forms.Button btnPlayPresets;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.TextBox txtStartFreq;
		private System.Windows.Forms.TextBox txtEndFreq;
		private System.Windows.Forms.TabControl tabSinus;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label lblEndFreq;
		private System.Windows.Forms.Label lblDuration;
		private System.Windows.Forms.Label lblStartFreq;
		private System.Windows.Forms.Label lblDwell;
		private System.Windows.Forms.TextBox txtDwell;
		private System.Windows.Forms.Button btnPlaySawtooth;
		private System.Windows.Forms.Label lblRepetitions;
		private System.Windows.Forms.TextBox txtRepetitions;
		private System.Windows.Forms.GroupBox gbxSawTooth;
		private System.Windows.Forms.Label lblDwell1;
		private System.Windows.Forms.TextBox txtDwell1;
		private System.Windows.Forms.Label lblDuration1;
		private System.Windows.Forms.Label lblFreq1;
		private System.Windows.Forms.TextBox txtDuration1;
		private System.Windows.Forms.TextBox txtFreq1;
		private System.Windows.Forms.Label lblDwell2;
		private System.Windows.Forms.TextBox txtDwell2;
		private System.Windows.Forms.Label lblDuration2;
		private System.Windows.Forms.Label lblFreq2;
		private System.Windows.Forms.TextBox txtDuration2;
		private System.Windows.Forms.TextBox txtFreq2;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lblRepetitions2;
		private System.Windows.Forms.TextBox txtSawToothReps;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblSpeaker;
		private System.Windows.Forms.Label lblVoxMessage;
		private System.Windows.Forms.ComboBox cboVox;
		private System.Windows.Forms.Button btnPlayVox;
		private System.Windows.Forms.CheckBox chkSaveToWavFile;
		private System.Windows.Forms.TextBox txtSpeakText;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Get System Voices
			string strVoice;
			foreach (SpeechLib.ISpeechObjectToken sot in Voice.GetVoices("", "") )
			{
				strVoice = sot.GetDescription(0);     //'The token's name
				cboVox.Items.Add(strVoice);
			}

			if (cboVox.Items.Count <= 0)
			{
				MessageBox.Show(this, "This system does not contain Text-to-Speech capability.");
			}

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gbxParameters = new System.Windows.Forms.GroupBox();
            this.lblRepetitions = new System.Windows.Forms.Label();
            this.txtRepetitions = new System.Windows.Forms.TextBox();
            this.lblDwell = new System.Windows.Forms.Label();
            this.txtDwell = new System.Windows.Forms.TextBox();
            this.lblEndFreq = new System.Windows.Forms.Label();
            this.txtEndFreq = new System.Windows.Forms.TextBox();
            this.btnPlayAdhoc = new System.Windows.Forms.Button();
            this.lblSteps = new System.Windows.Forms.Label();
            this.txtSteps = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblStartFreq = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtStartFreq = new System.Windows.Forms.TextBox();
            this.gbxPresets = new System.Windows.Forms.GroupBox();
            this.btnPlayPresets = new System.Windows.Forms.Button();
            this.cboPresets = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabSinus = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbxSawTooth = new System.Windows.Forms.GroupBox();
            this.lblRepetitions2 = new System.Windows.Forms.Label();
            this.txtSawToothReps = new System.Windows.Forms.TextBox();
            this.lblDwell2 = new System.Windows.Forms.Label();
            this.txtDwell2 = new System.Windows.Forms.TextBox();
            this.lblDuration2 = new System.Windows.Forms.Label();
            this.lblFreq2 = new System.Windows.Forms.Label();
            this.txtDuration2 = new System.Windows.Forms.TextBox();
            this.txtFreq2 = new System.Windows.Forms.TextBox();
            this.lblDwell1 = new System.Windows.Forms.Label();
            this.txtDwell1 = new System.Windows.Forms.TextBox();
            this.btnPlaySawtooth = new System.Windows.Forms.Button();
            this.lblDuration1 = new System.Windows.Forms.Label();
            this.lblFreq1 = new System.Windows.Forms.Label();
            this.txtDuration1 = new System.Windows.Forms.TextBox();
            this.txtFreq1 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSaveToWavFile = new System.Windows.Forms.CheckBox();
            this.cboVox = new System.Windows.Forms.ComboBox();
            this.btnPlayVox = new System.Windows.Forms.Button();
            this.lblSpeaker = new System.Windows.Forms.Label();
            this.lblVoxMessage = new System.Windows.Forms.Label();
            this.txtSpeakText = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbxParameters.SuspendLayout();
            this.gbxPresets.SuspendLayout();
            this.tabSinus.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbxSawTooth.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxParameters
            // 
            this.gbxParameters.Controls.Add(this.lblRepetitions);
            this.gbxParameters.Controls.Add(this.txtRepetitions);
            this.gbxParameters.Controls.Add(this.lblDwell);
            this.gbxParameters.Controls.Add(this.txtDwell);
            this.gbxParameters.Controls.Add(this.lblEndFreq);
            this.gbxParameters.Controls.Add(this.txtEndFreq);
            this.gbxParameters.Controls.Add(this.btnPlayAdhoc);
            this.gbxParameters.Controls.Add(this.lblSteps);
            this.gbxParameters.Controls.Add(this.txtSteps);
            this.gbxParameters.Controls.Add(this.lblDuration);
            this.gbxParameters.Controls.Add(this.lblStartFreq);
            this.gbxParameters.Controls.Add(this.txtDuration);
            this.gbxParameters.Controls.Add(this.txtStartFreq);
            this.gbxParameters.Location = new System.Drawing.Point(8, 8);
            this.gbxParameters.Name = "gbxParameters";
            this.gbxParameters.Size = new System.Drawing.Size(280, 296);
            this.gbxParameters.TabIndex = 0;
            this.gbxParameters.TabStop = false;
            this.gbxParameters.Text = "Set Sine Wave Parameters";
            // 
            // lblRepetitions
            // 
            this.lblRepetitions.Location = new System.Drawing.Point(16, 192);
            this.lblRepetitions.Name = "lblRepetitions";
            this.lblRepetitions.Size = new System.Drawing.Size(64, 16);
            this.lblRepetitions.TabIndex = 12;
            this.lblRepetitions.Text = "Repetitions: ";
            this.lblRepetitions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRepetitions
            // 
            this.txtRepetitions.Location = new System.Drawing.Point(88, 192);
            this.txtRepetitions.Name = "txtRepetitions";
            this.txtRepetitions.Size = new System.Drawing.Size(176, 20);
            this.txtRepetitions.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtRepetitions, "Number of times to repeat the cycle.");
            // 
            // lblDwell
            // 
            this.lblDwell.Location = new System.Drawing.Point(16, 160);
            this.lblDwell.Name = "lblDwell";
            this.lblDwell.Size = new System.Drawing.Size(64, 16);
            this.lblDwell.TabIndex = 10;
            this.lblDwell.Text = "Dwell: ";
            this.lblDwell.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDwell
            // 
            this.txtDwell.Location = new System.Drawing.Point(88, 160);
            this.txtDwell.Name = "txtDwell";
            this.txtDwell.Size = new System.Drawing.Size(176, 20);
            this.txtDwell.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtDwell, "Delay between repetitions (in milliseconds)");
            // 
            // lblEndFreq
            // 
            this.lblEndFreq.Location = new System.Drawing.Point(16, 64);
            this.lblEndFreq.Name = "lblEndFreq";
            this.lblEndFreq.Size = new System.Drawing.Size(64, 16);
            this.lblEndFreq.TabIndex = 8;
            this.lblEndFreq.Text = "End Freq: ";
            this.lblEndFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEndFreq
            // 
            this.txtEndFreq.Location = new System.Drawing.Point(88, 64);
            this.txtEndFreq.Name = "txtEndFreq";
            this.txtEndFreq.Size = new System.Drawing.Size(176, 20);
            this.txtEndFreq.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtEndFreq, "Frequency (Hz)");
            // 
            // btnPlayAdhoc
            // 
            this.btnPlayAdhoc.Location = new System.Drawing.Point(152, 264);
            this.btnPlayAdhoc.Name = "btnPlayAdhoc";
            this.btnPlayAdhoc.Size = new System.Drawing.Size(112, 23);
            this.btnPlayAdhoc.TabIndex = 6;
            this.btnPlayAdhoc.Text = "&Play Tone";
            this.toolTip1.SetToolTip(this.btnPlayAdhoc, "Play example of sine wave tone.");
            this.btnPlayAdhoc.Click += new System.EventHandler(this.btnPlayAdhoc_Click);
            // 
            // lblSteps
            // 
            this.lblSteps.Location = new System.Drawing.Point(16, 128);
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.Size = new System.Drawing.Size(64, 16);
            this.lblSteps.TabIndex = 5;
            this.lblSteps.Text = "Steps: ";
            this.lblSteps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSteps
            // 
            this.txtSteps.Location = new System.Drawing.Point(88, 128);
            this.txtSteps.Name = "txtSteps";
            this.txtSteps.Size = new System.Drawing.Size(176, 20);
            this.txtSteps.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtSteps, "Number of steps to break increments into over the duration (smooths the tone\'s ra" +
                    "mp up)");
            // 
            // lblDuration
            // 
            this.lblDuration.Location = new System.Drawing.Point(16, 96);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(64, 16);
            this.lblDuration.TabIndex = 3;
            this.lblDuration.Text = "Duration: ";
            this.lblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStartFreq
            // 
            this.lblStartFreq.Location = new System.Drawing.Point(16, 32);
            this.lblStartFreq.Name = "lblStartFreq";
            this.lblStartFreq.Size = new System.Drawing.Size(64, 16);
            this.lblStartFreq.TabIndex = 2;
            this.lblStartFreq.Text = "Start Freq: ";
            this.lblStartFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(88, 96);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(176, 20);
            this.txtDuration.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtDuration, "Time of play in milliseconds");
            // 
            // txtStartFreq
            // 
            this.txtStartFreq.Location = new System.Drawing.Point(88, 32);
            this.txtStartFreq.Name = "txtStartFreq";
            this.txtStartFreq.Size = new System.Drawing.Size(176, 20);
            this.txtStartFreq.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtStartFreq, "Frequency (Hz)");
            // 
            // gbxPresets
            // 
            this.gbxPresets.Controls.Add(this.btnPlayPresets);
            this.gbxPresets.Controls.Add(this.cboPresets);
            this.gbxPresets.Location = new System.Drawing.Point(8, 8);
            this.gbxPresets.Name = "gbxPresets";
            this.gbxPresets.Size = new System.Drawing.Size(280, 104);
            this.gbxPresets.TabIndex = 1;
            this.gbxPresets.TabStop = false;
            this.gbxPresets.Text = "Preset Sounds";
            // 
            // btnPlayPresets
            // 
            this.btnPlayPresets.Location = new System.Drawing.Point(136, 72);
            this.btnPlayPresets.Name = "btnPlayPresets";
            this.btnPlayPresets.Size = new System.Drawing.Size(112, 23);
            this.btnPlayPresets.TabIndex = 7;
            this.btnPlayPresets.Text = "&Play Preset";
            this.btnPlayPresets.Click += new System.EventHandler(this.btnPlayPresets_Click);
            // 
            // cboPresets
            // 
            this.cboPresets.Items.AddRange(new object[] {
            "Master Warning",
            "Master Warning2",
            "Radiation",
            "Landing Gear"});
            this.cboPresets.Location = new System.Drawing.Point(16, 32);
            this.cboPresets.Name = "cboPresets";
            this.cboPresets.Size = new System.Drawing.Size(232, 21);
            this.cboPresets.TabIndex = 0;
            this.cboPresets.Text = "Master Warning";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(232, 352);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "E&xit";
            this.toolTip1.SetToolTip(this.btnExit, "Exit this application");
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabSinus
            // 
            this.tabSinus.Controls.Add(this.tabPage1);
            this.tabSinus.Controls.Add(this.tabPage2);
            this.tabSinus.Controls.Add(this.tabPage3);
            this.tabSinus.Controls.Add(this.tabPage4);
            this.tabSinus.Location = new System.Drawing.Point(8, 8);
            this.tabSinus.Name = "tabSinus";
            this.tabSinus.SelectedIndex = 0;
            this.tabSinus.Size = new System.Drawing.Size(304, 336);
            this.tabSinus.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbxParameters);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(296, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sine";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbxSawTooth);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(296, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Saw Tooth";
            // 
            // gbxSawTooth
            // 
            this.gbxSawTooth.Controls.Add(this.lblRepetitions2);
            this.gbxSawTooth.Controls.Add(this.txtSawToothReps);
            this.gbxSawTooth.Controls.Add(this.lblDwell2);
            this.gbxSawTooth.Controls.Add(this.txtDwell2);
            this.gbxSawTooth.Controls.Add(this.lblDuration2);
            this.gbxSawTooth.Controls.Add(this.lblFreq2);
            this.gbxSawTooth.Controls.Add(this.txtDuration2);
            this.gbxSawTooth.Controls.Add(this.txtFreq2);
            this.gbxSawTooth.Controls.Add(this.lblDwell1);
            this.gbxSawTooth.Controls.Add(this.txtDwell1);
            this.gbxSawTooth.Controls.Add(this.btnPlaySawtooth);
            this.gbxSawTooth.Controls.Add(this.lblDuration1);
            this.gbxSawTooth.Controls.Add(this.lblFreq1);
            this.gbxSawTooth.Controls.Add(this.txtDuration1);
            this.gbxSawTooth.Controls.Add(this.txtFreq1);
            this.gbxSawTooth.Location = new System.Drawing.Point(8, 8);
            this.gbxSawTooth.Name = "gbxSawTooth";
            this.gbxSawTooth.Size = new System.Drawing.Size(280, 296);
            this.gbxSawTooth.TabIndex = 1;
            this.gbxSawTooth.TabStop = false;
            this.gbxSawTooth.Text = "Set Sawtooth Wave Parameters";
            // 
            // lblRepetitions2
            // 
            this.lblRepetitions2.Location = new System.Drawing.Point(16, 224);
            this.lblRepetitions2.Name = "lblRepetitions2";
            this.lblRepetitions2.Size = new System.Drawing.Size(64, 16);
            this.lblRepetitions2.TabIndex = 18;
            this.lblRepetitions2.Text = "Repetitions: ";
            this.lblRepetitions2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.lblRepetitions2, "Number of repetitions of the tone.");
            // 
            // txtSawToothReps
            // 
            this.txtSawToothReps.Location = new System.Drawing.Point(88, 224);
            this.txtSawToothReps.Name = "txtSawToothReps";
            this.txtSawToothReps.Size = new System.Drawing.Size(176, 20);
            this.txtSawToothReps.TabIndex = 17;
            this.toolTip1.SetToolTip(this.txtSawToothReps, "Number of repetitions when playing tone.");
            // 
            // lblDwell2
            // 
            this.lblDwell2.Location = new System.Drawing.Point(16, 192);
            this.lblDwell2.Name = "lblDwell2";
            this.lblDwell2.Size = new System.Drawing.Size(64, 16);
            this.lblDwell2.TabIndex = 16;
            this.lblDwell2.Text = "Dwell: ";
            this.lblDwell2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDwell2
            // 
            this.txtDwell2.Location = new System.Drawing.Point(88, 192);
            this.txtDwell2.Name = "txtDwell2";
            this.txtDwell2.Size = new System.Drawing.Size(176, 20);
            this.txtDwell2.TabIndex = 15;
            // 
            // lblDuration2
            // 
            this.lblDuration2.Location = new System.Drawing.Point(16, 160);
            this.lblDuration2.Name = "lblDuration2";
            this.lblDuration2.Size = new System.Drawing.Size(64, 16);
            this.lblDuration2.TabIndex = 14;
            this.lblDuration2.Text = "Duration: ";
            this.lblDuration2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFreq2
            // 
            this.lblFreq2.Location = new System.Drawing.Point(8, 128);
            this.lblFreq2.Name = "lblFreq2";
            this.lblFreq2.Size = new System.Drawing.Size(72, 16);
            this.lblFreq2.TabIndex = 13;
            this.lblFreq2.Text = "Second Freq: ";
            this.lblFreq2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDuration2
            // 
            this.txtDuration2.Location = new System.Drawing.Point(88, 160);
            this.txtDuration2.Name = "txtDuration2";
            this.txtDuration2.Size = new System.Drawing.Size(176, 20);
            this.txtDuration2.TabIndex = 12;
            // 
            // txtFreq2
            // 
            this.txtFreq2.Location = new System.Drawing.Point(88, 128);
            this.txtFreq2.Name = "txtFreq2";
            this.txtFreq2.Size = new System.Drawing.Size(176, 20);
            this.txtFreq2.TabIndex = 11;
            // 
            // lblDwell1
            // 
            this.lblDwell1.Location = new System.Drawing.Point(16, 96);
            this.lblDwell1.Name = "lblDwell1";
            this.lblDwell1.Size = new System.Drawing.Size(64, 16);
            this.lblDwell1.TabIndex = 10;
            this.lblDwell1.Text = "Dwell: ";
            this.lblDwell1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDwell1
            // 
            this.txtDwell1.Location = new System.Drawing.Point(88, 96);
            this.txtDwell1.Name = "txtDwell1";
            this.txtDwell1.Size = new System.Drawing.Size(176, 20);
            this.txtDwell1.TabIndex = 9;
            // 
            // btnPlaySawtooth
            // 
            this.btnPlaySawtooth.Location = new System.Drawing.Point(152, 264);
            this.btnPlaySawtooth.Name = "btnPlaySawtooth";
            this.btnPlaySawtooth.Size = new System.Drawing.Size(112, 23);
            this.btnPlaySawtooth.TabIndex = 6;
            this.btnPlaySawtooth.Text = "&Play Tone";
            this.btnPlaySawtooth.Click += new System.EventHandler(this.btnPlaySawtooth_Click);
            // 
            // lblDuration1
            // 
            this.lblDuration1.Location = new System.Drawing.Point(16, 64);
            this.lblDuration1.Name = "lblDuration1";
            this.lblDuration1.Size = new System.Drawing.Size(64, 16);
            this.lblDuration1.TabIndex = 3;
            this.lblDuration1.Text = "Duration: ";
            this.lblDuration1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFreq1
            // 
            this.lblFreq1.Location = new System.Drawing.Point(16, 32);
            this.lblFreq1.Name = "lblFreq1";
            this.lblFreq1.Size = new System.Drawing.Size(64, 16);
            this.lblFreq1.TabIndex = 2;
            this.lblFreq1.Text = "First Freq: ";
            this.lblFreq1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDuration1
            // 
            this.txtDuration1.Location = new System.Drawing.Point(88, 64);
            this.txtDuration1.Name = "txtDuration1";
            this.txtDuration1.Size = new System.Drawing.Size(176, 20);
            this.txtDuration1.TabIndex = 1;
            // 
            // txtFreq1
            // 
            this.txtFreq1.Location = new System.Drawing.Point(88, 32);
            this.txtFreq1.Name = "txtFreq1";
            this.txtFreq1.Size = new System.Drawing.Size(176, 20);
            this.txtFreq1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gbxPresets);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(296, 310);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Preset";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(296, 310);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Voice";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSaveToWavFile);
            this.groupBox1.Controls.Add(this.cboVox);
            this.groupBox1.Controls.Add(this.btnPlayVox);
            this.groupBox1.Controls.Add(this.lblSpeaker);
            this.groupBox1.Controls.Add(this.lblVoxMessage);
            this.groupBox1.Controls.Add(this.txtSpeakText);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 296);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Voice Parameters";
            // 
            // chkSaveToWavFile
            // 
            this.chkSaveToWavFile.Location = new System.Drawing.Point(88, 152);
            this.chkSaveToWavFile.Name = "chkSaveToWavFile";
            this.chkSaveToWavFile.Size = new System.Drawing.Size(176, 24);
            this.chkSaveToWavFile.TabIndex = 20;
            this.chkSaveToWavFile.Text = "Save to WAV file";
            // 
            // cboVox
            // 
            this.cboVox.Location = new System.Drawing.Point(88, 112);
            this.cboVox.Name = "cboVox";
            this.cboVox.Size = new System.Drawing.Size(176, 21);
            this.cboVox.TabIndex = 19;
            this.cboVox.Text = "Select Speaker...";
            this.cboVox.SelectedIndexChanged += new System.EventHandler(this.cboVox_SelectedIndexChanged);
            // 
            // btnPlayVox
            // 
            this.btnPlayVox.Location = new System.Drawing.Point(152, 264);
            this.btnPlayVox.Name = "btnPlayVox";
            this.btnPlayVox.Size = new System.Drawing.Size(112, 23);
            this.btnPlayVox.TabIndex = 6;
            this.btnPlayVox.Text = "&Play Tone";
            this.btnPlayVox.Click += new System.EventHandler(this.btnPlayVox_Click);
            // 
            // lblSpeaker
            // 
            this.lblSpeaker.Location = new System.Drawing.Point(16, 112);
            this.lblSpeaker.Name = "lblSpeaker";
            this.lblSpeaker.Size = new System.Drawing.Size(64, 16);
            this.lblSpeaker.TabIndex = 3;
            this.lblSpeaker.Text = "Speaker: ";
            this.lblSpeaker.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVoxMessage
            // 
            this.lblVoxMessage.Location = new System.Drawing.Point(16, 32);
            this.lblVoxMessage.Name = "lblVoxMessage";
            this.lblVoxMessage.Size = new System.Drawing.Size(64, 16);
            this.lblVoxMessage.TabIndex = 2;
            this.lblVoxMessage.Text = "Message: ";
            this.lblVoxMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSpeakText
            // 
            this.txtSpeakText.Location = new System.Drawing.Point(88, 32);
            this.txtSpeakText.Multiline = true;
            this.txtSpeakText.Name = "txtSpeakText";
            this.txtSpeakText.Size = new System.Drawing.Size(176, 72);
            this.txtSpeakText.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(320, 382);
            this.Controls.Add(this.tabSinus);
            this.Controls.Add(this.btnExit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Aural Alerts";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxParameters.ResumeLayout(false);
            this.gbxParameters.PerformLayout();
            this.gbxPresets.ResumeLayout(false);
            this.tabSinus.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.gbxSawTooth.ResumeLayout(false);
            this.gbxSawTooth.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			// do nothing on form load
		}


		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Dispose();
		}

		private void btnPlayAdhoc_Click(object sender, System.EventArgs e)
		{
            try
            {

			    // Set vars for sine wave tone
			    int startFreq = Convert.ToInt32(txtStartFreq.Text);
			    int endFreq = Convert.ToInt32(txtEndFreq.Text);
			    int duration = Convert.ToInt32(txtDuration.Text);
			    int dwell = Convert.ToInt32(txtDwell.Text);
			    int steps = Convert.ToInt32(txtSteps.Text);
			    int reps = Convert.ToInt32(txtRepetitions.Text);

			    int diff = Math.Abs(startFreq - endFreq);
			    diff = Convert.ToInt32(diff/duration);

			    for (int rep=0; rep<reps; rep++)
			    {
				    // tone
				    int CurrentFreq = startFreq;

				    for(int i=0; i<steps-1; i++)
				    {
					    Beep(CurrentFreq, Convert.ToInt32(duration/steps));
					    CurrentFreq = CurrentFreq + diff;
				    }

				    // dwell
                    Thread.Sleep(dwell);
			    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString() + "::" + ex.StackTrace.ToString());	
            }
		}

		private void btnPlayPresets_Click(object sender, System.EventArgs e)
		{
			
			switch (cboPresets.Text.ToString()) 
			{
					
				case "Master Warning":

					CannedWCAtones.PlayMasterWarning(true, 5);
					break;

                case "Master Warning2":

                    CannedWCAtones.PlayMasterWarning2(true, 5);
                    break;

				case "Radiation":

					CannedWCAtones.Radiation();
					break;

				case "Landing Gear":

					CannedWCAtones.PlayWheels();
					break;
			}

		}

		private void btnPlaySawtooth_Click(object sender, System.EventArgs e)
		{
            try
            {
                int freq1 = Convert.ToInt32(txtFreq1.Text);
                int duration1 = Convert.ToInt32(txtDuration1.Text);
                int dwell1 = Convert.ToInt32(txtDwell1.Text);
                int freq2 = Convert.ToInt32(txtFreq2.Text);
                int duration2 = Convert.ToInt32(txtDuration2.Text);
                int dwell2 = Convert.ToInt32(txtDwell2.Text);
                int reps = Convert.ToInt32(txtSawToothReps.Text);

                for (int i = 0; i < reps; i++)
                {
                    Beep(freq1, duration1);
                    Thread.Sleep(dwell1);
                    Beep(freq2, duration2);
                    Thread.Sleep(dwell2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
		}

		private void btnPlayVox_Click(object sender, System.EventArgs e)
		{
			try 
			{

				if (chkSaveToWavFile.Checked)
				{
					Voice.Speak(txtSpeakText.Text, SpFlags);

					SaveFileDialog sfd = new SaveFileDialog();
	    
					sfd.Filter = "All files (*.*)|*.*|wav files (*.wav)|*.wav";
					sfd.Title = "Save to a wave file";
					sfd.FilterIndex = 2;
					sfd.RestoreDirectory = true;
	    
					if (sfd.ShowDialog()== DialogResult.OK) 
					{

						SpeechStreamFileMode SpFileMode = SpeechStreamFileMode.SSFMCreateForWrite;

						SpFileStream SpFileStream = new SpFileStream();
						SpFileStream.Open(sfd.FileName, SpFileMode, false);

						Voice.AudioOutputStream = SpFileStream;
						Voice.Speak(txtSpeakText.Text, SpFlags);
						Voice.WaitUntilDone(Timeout.Infinite);

						SpFileStream.Close();

					}
				}
				else
				{
					try
					{
						Voice.Speak(txtSpeakText.Text, SpFlags);
					} 
					catch (System.Exception ex)
					{
						MessageBox.Show(this, ex.Message.ToString() + "::" + ex.StackTrace.ToString());		
					}
				}
			}
			catch(Exception ex)
			{
                MessageBox.Show(this, ex.Message.ToString() + "::" + ex.StackTrace.ToString());	
			}
		}

		private void cboVox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
			Voice.Voice = Voice.GetVoices("","").Item(cboVox.SelectedIndex);	
		}


	}
}
