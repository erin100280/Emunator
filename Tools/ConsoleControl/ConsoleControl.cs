using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace ConsoleControl {
    /// <summary>
    /// The console event handler is used for console events.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="ConsoleEventArgs"/> instance containing the event data.</param>
    public delegate void ConsoleEventHanlder(object sender, ConsoleEventArgs args);

    /// <summary>
    /// The Console Control allows you to embed a basic console in your application.
    /// </summary>
	[ToolboxBitmap(typeof(resfinder), "ConsoleControl.ConsoleControl.bmp")]
	public partial class consoleControl : UserControl {
		#region vars
		#endregion
		#region constructors
		#region meta
		/// <summary>
		/// Initializes a new instance of the <see cref="ConsoleControl"/> class.
		/// </summary>
		#endregion
		public consoleControl() { InitConsoleControl(); }
		protected virtual void  InitConsoleControl() {
			//  Initialise the component.
			InitializeComponent();
			
			//  Show diagnostics disabled by default.
			ShowDiagnostics = false;
			
			//  Input enabled by default.
			IsInputEnabled = true;
			
			//  Disable special commands by default.
			SendKeyboardCommandsToProcess = false;
			
			//  Initialise the keymappings.
			InitialiseKeyMappings();
			
			//  Handle process events.
			processInterace.OnProcessOutput += new ProcessInterface.ProcessEventHanlder(processInterace_OnProcessOutput);
			processInterace.OnProcessError += new ProcessInterface.ProcessEventHanlder(processInterace_OnProcessError);
			processInterace.OnProcessInput += new ProcessInterface.ProcessEventHanlder(processInterace_OnProcessInput);
			processInterace.OnProcessExit += new ProcessInterface.ProcessEventHanlder(processInterace_OnProcessExit);
			
			//  Wait for key down messages on the rich text box.
			richTextBoxConsole.KeyDown += new KeyEventHandler(richTextBoxConsole_KeyDown);
		}
		#endregion
		#region properties
		public override Color BackColor {
			get { return base.BackColor; }
			set { base.BackColor = richTextBoxConsole.BackColor = value; }
		} 
		#endregion
		#region misc.
		#region meta
		/// <summary>
		/// Handles the OnProcessError event of the processInterace control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="args">The <see cref="ProcessInterface.ProcessEventArgs"/> instance containing the event data.</param>
		#endregion
		void processInterace_OnProcessError(object sender, ProcessInterface.ProcessEventArgs args)
		{
		//  Write the output, in red
		WriteOutput(args.Content, Color.Red);
		
		//  Fire the output event.
		FireConsoleOutputEvent(args.Content);
		}
		
		#region meta
		/// <summary>
		/// Handles the OnProcessOutput event of the processInterace control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="args">The <see cref="ProcessInterface.ProcessEventArgs"/> instance containing the event data.</param>
		#endregion
		void processInterace_OnProcessOutput(object sender, ProcessInterface.ProcessEventArgs args)
		{
		//  Write the output, in white
		WriteOutput(args.Content, Color.White);
		
		//  Fire the output event.
		FireConsoleOutputEvent(args.Content);
		}
		
		#region meta
		/// <summary>
		/// Handles the OnProcessInput event of the processInterace control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="args">The <see cref="ProcessInterface.ProcessEventArgs"/> instance containing the event data.</param>
		#endregion
		void processInterace_OnProcessInput(object sender, ProcessInterface.ProcessEventArgs args)
		{
		throw new NotImplementedException();
		}
		
		#region meta
		/// <summary>
		/// Handles the OnProcessExit event of the processInterace control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="args">The <see cref="ProcessInterface.ProcessEventArgs"/> instance containing the event data.</param>
		#endregion
		void processInterace_OnProcessExit(object sender, ProcessInterface.ProcessEventArgs args)
		{
		//  Are we showing diagnostics?
		if (ShowDiagnostics)
		{
		WriteOutput(System.Environment.NewLine + processInterace.ProcessFileName + " exited.", Color.FromArgb(255, 0, 255, 0));
		}
		
		//  Read only again.
		Invoke((Action)(() =>
		{
		richTextBoxConsole.ReadOnly = true;
		}));
		}
		
		#region meta
		/// <summary>
		/// Initialises the key mappings.
		/// </summary>
		#endregion
		private void InitialiseKeyMappings()
		{
		//  Map 'tab'.
		keyMappings.Add(new KeyMapping(false, false, false, Keys.Tab, "{TAB}", "\t"));
		
		//  Map 'Ctrl-C'.
		keyMappings.Add(new KeyMapping(true, false, false, Keys.C, "^(c)", "\x03\r\n"));
		}
		
		#region meta
		/// <summary>
		/// Handles the KeyDown event of the richTextBoxConsole control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
		#endregion
		void richTextBoxConsole_KeyDown(object sender, KeyEventArgs e)
		{
		//  Are we sending keyboard commands to the process?
		if (SendKeyboardCommandsToProcess && IsProcessRunning)
		{
		//  Get key mappings for this key event?
		var mappings = from k in keyMappings
		where 
		(k.KeyCode == e.KeyCode &&
		k.IsAltPressed == e.Alt &&
		k.IsControlPressed == e.Control &&
		k.IsShiftPressed == e.Shift)
		select k;
		
		//  Go through each mapping, send the message.
		foreach (var mapping in mappings)
		{
		//SendKeysEx.SendKeys(CurrentProcessHwnd, mapping.SendKeysMapping);
		//inputWriter.WriteLine(mapping.StreamMapping);
		//WriteInput("\x3", Color.White, false);
		}
		
		//  If we handled a mapping, we're done here.
		if (mappings.Count() > 0)
		{
		e.SuppressKeyPress = true;
		return;
		}
		}
		
		//  If we're at the input point and it's backspace, bail.
		if ((richTextBoxConsole.SelectionStart <= inputStart) && e.KeyCode == Keys.Back) e.SuppressKeyPress = true;
		
		//  Are we in the read-only zone?
		if (richTextBoxConsole.SelectionStart < inputStart)
		{
		//  Allow arrows and Ctrl-C.
		if (!(e.KeyCode == Keys.Left ||
		e.KeyCode == Keys.Right ||
		e.KeyCode == Keys.Up ||
		e.KeyCode == Keys.Down ||
		(e.KeyCode == Keys.C && e.Control)))
		{
		e.SuppressKeyPress = true;
		}
		}
		
		//  Is it the return key?
		if (e.KeyCode == Keys.Return)
		{
		//  Get the input.
		string input = richTextBoxConsole.Text.Substring(inputStart, (richTextBoxConsole.SelectionStart) - inputStart);
		
		//  Write the input (without echoing).
		WriteInput(input, Color.White, false);
		}
		}
		
		#region meta
		/// <summary>
		/// Writes the output to the console control.
		/// </summary>
		/// <param name="output">The output.</param>
		/// <param name="color">The color.</param>
		#endregion
		public void WriteOutput(string output, Color color)
		{
		if (string.IsNullOrEmpty(lastInput) == false && 
		(output == lastInput || output.Replace("\r\n", "") == lastInput))
		return;
		
		Invoke((Action)(() =>
		{
		//  Write the output.
		richTextBoxConsole.SelectionColor = color;
		richTextBoxConsole.SelectedText += output;
		inputStart = richTextBoxConsole.SelectionStart;
		}));
		}
		
		public void ClearOutput()
		{
		richTextBoxConsole.Clear();
		inputStart = 0;
		}
		
		#region meta
		/// <summary>
		/// Writes the input to the console control.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="color">The color.</param>
		/// <param name="echo">if set to <c>true</c> echo the input.</param>
		#endregion
		public void WriteInput(string input, Color color, bool echo)
		{
		Invoke((Action)(() =>
		{
		//  Are we echoing?
		if (echo)
		{
		richTextBoxConsole.SelectionColor = color;
		richTextBoxConsole.SelectedText += input;
		inputStart = richTextBoxConsole.SelectionStart;
		}
		
		lastInput = input;
		
		//  Write the input.
		processInterace.WriteInput(input);
		
		//  Fire the event.
		FireConsoleInputEvent(input);
		}));
		}
		
		
		
		#region meta
		/// <summary>
		/// Runs a process.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="arguments">The arguments.</param>
		#endregion
		public void StartProcess(string fileName, string arguments)
		{
		//  Are we showing diagnostics?
		if (ShowDiagnostics)
		{
		WriteOutput("Preparing to run " + fileName, Color.FromArgb(255, 0, 255, 0));
		if (!string.IsNullOrEmpty(arguments))
		WriteOutput(" with arguments " + arguments + "." + Environment.NewLine, Color.FromArgb(255, 0, 255, 0));
		else
		WriteOutput("." + Environment.NewLine, Color.FromArgb(255, 0, 255, 0));
		}
		
		//  Start the process.
		processInterace.StartProcess(fileName, arguments);
		
		//  If we enable input, make the control not read only.
		if (IsInputEnabled)
		richTextBoxConsole.ReadOnly = false;
		}
		
		#region meta
		/// <summary>
		/// Stops the process.
		/// </summary>
		#endregion
		public void StopProcess()
		{
		//  Stop the interface.
		processInterace.StopProcess();
		}
		
		#region meta
		/// <summary>
		/// Fires the console output event.
		/// </summary>
		/// <param name="content">The content.</param>
		#endregion
		private void FireConsoleOutputEvent(string content)
		{
		//  Get the event.
		var theEvent = OnConsoleOutput;
		if (theEvent != null)
		theEvent(this, new ConsoleEventArgs(content));
		}
		
		#region meta
		/// <summary>
		/// Fires the console input event.
		/// </summary>
		/// <param name="content">The content.</param>
		#endregion
		private void FireConsoleInputEvent(string content)
		{
		//  Get the event.
		var theEvent = OnConsoleInput;
		if (theEvent != null)
		theEvent(this, new ConsoleEventArgs(content));
		}
		
		#region meta
		/// <summary>
		/// The internal process interface used to interface with the process.
		/// </summary>
		#endregion
		private ProcessInterface.ProcessInterface processInterace = new ProcessInterface.ProcessInterface();
		
		#region meta
		/// <summary>
		/// Current position that input starts at.
		/// </summary>
		#endregion
		int inputStart = -1;
		
		#region meta
		/// <summary>
		/// The is input enabled flag.
		/// </summary>
		#endregion
		private bool isInputEnabled = true;
		
		#region meta
		/// <summary>
		/// The last input string (used so that we can make sure we don't echo input twice).
		/// </summary>
		#endregion
		private string lastInput;
		
		#region meta
		/// <summary>
		/// The key mappings.
		/// </summary>
		#endregion
		private List<KeyMapping> keyMappings = new List<KeyMapping>();
		
		#region meta
		/// <summary>
		/// Occurs when console output is produced.
		/// </summary>
		#endregion
		public event ConsoleEventHanlder OnConsoleOutput;
		
		#region meta
		/// <summary>
		/// Occurs when console input is produced.
		/// </summary>
		#endregion
		public event ConsoleEventHanlder OnConsoleInput;
		
		#region meta
		/// <summary>
		/// Gets or sets a value indicating whether to show diagnostics.
		/// </summary>
		/// <value>
		///   <c>true</c> if show diagnostics; otherwise, <c>false</c>.
		/// </value>
		[Category("Console Control"), Description("Show diagnostic information, such as exceptions.")]
		#endregion
		public bool ShowDiagnostics
		{
		get;
		set;
		}
		
		#region meta
		/// <summary>
		/// Gets or sets a value indicating whether this instance is input enabled.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is input enabled; otherwise, <c>false</c>.
		/// </value>
		[Category("Console Control"), Description("If true, the user can key in input.")]
		#endregion
		public bool IsInputEnabled
		{
		get { return isInputEnabled; }
		set
		{
		isInputEnabled = value;
		if (IsProcessRunning)
		richTextBoxConsole.ReadOnly = !value;
		}
		}
		
		#region meta
		/// <summary>
		/// Gets or sets a value indicating whether [send keyboard commands to process].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [send keyboard commands to process]; otherwise, <c>false</c>.
		/// </value>
		[Category("Console Control"), Description("If true, special keyboard commands like Ctrl-C and tab are sent to the process.")]
		#endregion
		public bool SendKeyboardCommandsToProcess
		{
		get;
		set;
		}
		
		#region meta
		/// <summary>
		/// Gets a value indicating whether this instance is process running.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is process running; otherwise, <c>false</c>.
		/// </value>
		[Browsable(false)]
		#endregion
		public bool IsProcessRunning
		{
		get { return processInterace.IsProcessRunning; }
		}
		
		#region meta
		/// <summary>
		/// Gets the internal rich text box.
		/// </summary>
		[Browsable(false)]
		#endregion
		public RichTextBox InternalRichTextBox
		{
		get { return richTextBoxConsole; }
		}
		
		#region meta
		/// <summary>
		/// Gets the process interface.
		/// </summary>
		[Browsable(false)]
		#endregion
		public ProcessInterface.ProcessInterface ProcessInterface
		{
		get { return processInterace; }
		}
		
		#region meta
		/// <summary>
		/// Gets the key mappings.
		/// </summary>
		[Browsable(false)]
		#endregion
		public List<KeyMapping> KeyMappings
		{
		get { return keyMappings; }
		}
		
		#region meta
		/// <summary>
		/// Gets or sets the font of the text displayed by the control.
		/// </summary>
		/// <returns>The <see cref="T:System.Drawing.Font" /> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont" /> property.</returns>
		///   <PermissionSet>
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   </PermissionSet>
		#endregion
		public override Font Font
		{
		get
		{
		//  Return the base class font.
		return base.Font;
		}
		set
		{
		//  Set the base class font...
		base.Font = value;
		
		//  ...and the internal control font.
		richTextBoxConsole.Font = value;
		}
		}
		#endregion
	}
}