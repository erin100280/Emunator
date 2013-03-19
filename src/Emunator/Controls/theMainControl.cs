#region header
/* User: Erin
 * Date: 2/7/2013
 * Time: 9:12 PM
 */
#endregion
#region using....
using Emunator.Forms;
using Be.Windows.Forms;
using Emu.Core;
using Emu.Core.Interfaces;
using Emu.Core.Settings;
using Emu.CPU;
using Emu.Debugger;
using Emu.Debugger.Controls;
using Emu.Debugger.Modules;
using Emu.Display;
using Emu.Machine;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
#endregion

namespace Emunator.Controls {

	#region meta
	/// <summary>
	/// theMainControl is the main control.
	/// </summary>
	#endregion
	public partial class theMainControl : UserControl, iInput {
		#region vars
		public int _openCouunt = 0;
		protected DebuggerForm _debuggerForm = null;
		protected DebuggerModule_Base _debuggerModule = null;
		public string lastDir_openRom = "";
		public bool startOnOpen = false;
		
		protected settings _settings = null;
		protected systemSettings _systemSettings = null;

		#endregion
		#region constructors
		public theMainControl() { InitTheMainControl(); }
		protected virtual void InitTheMainControl() {
			InitializeComponent();
			inputHandler ih = settings.main.inputHandler;
			BackColor = Color.Black;
			//pnl_display.GotFocus += new EventHandler(pnlDisplay_GotFocus);
			_settings = settings.main;
			_systemSettings = _settings.system;
			_systemSettings.focusControl = this;
			
			ih.altHandler = this;
			KeyDown += new KeyEventHandler(ih.HandleKeyDown);
			pnl_display.KeyDown += new KeyEventHandler(ih.HandleKeyDown);
			KeyUp += new KeyEventHandler(ih.HandleKeyUp);
			pnl_display.KeyUp += new KeyEventHandler(ih.HandleKeyUp);
			
			ResetProperties();
		}
		#endregion
		#region On....
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
		}
		public virtual bool OnKeyDownMain(KeyEventArgs e) {
			//base.OnKeyDown(e);
			bool bl = false;
			if(machine != null && machine.keyboard != null)
				bl = machine.keyboard.KeyDownInput(e);
			
			if(!bl) {
				if(e.KeyCode == Keys.Back && machine != null) {
					machine.Rewind();
					return true;
				}
				
			}
		
			return bl;
		}
		public virtual bool OnKeyUpMain(KeyEventArgs e) {
			bool bl = false;
			if(machine != null && machine.keyboard != null)
				bl = machine.keyboard.KeyUpInput(e);
			
			if(!bl) {
				if(e.KeyCode == Keys.Back && machine != null) {}
				
			}
			
			return bl;
			//base.OnKeyUp(e);
		}
		#endregion
		#region menu handlers
		#region Debug
		void DebuggerToolStripMenuItemClick(object sender, EventArgs e) {
			RunDebugger();
		}
		#endregion
		#region File
		void LoadStateToolStripMenuItemClick(object sender, EventArgs e) {
			
		}
		void SaveStateToolStripMenuItemClick(object sender, EventArgs e) {
			
		}
		void ImportStateToolStripMenuItemClick(object sender, EventArgs e) {
			if(openFileDialog.ShowDialog() != DialogResult.Cancel) {
				if(machine != null)
					machine.SetState(stateSystem.LoadState(openFileDialog.FileName));
			}
		}
		void ExportStateToolStripMenuItemClick(object sender, EventArgs e) {
			if(machine != null) {
				state st = machine.GetState();
				if(saveFileDialog.ShowDialog() != DialogResult.Cancel) {
					stateSystem.SaveState(st, saveFileDialog.FileName);
			   }
			}
		}
		void TSMnuItm_File_ExitClick(object sender, EventArgs e) {
			if(machine != null) {
				machine.Stop();
				machine.Unload();
			}
			Application.Exit();
		}
		void TSMnuItm_File_OpenClick(object sender, EventArgs e) {
			bool paused = false;
			bool running = false;

			if(machine != null) {
				paused = machine.paused;
				running = machine.running;
				if(running && !paused)
					machine.Pause();
			}

			openFileDialog.Title = "Open Rom";
			openFileDialog.FileName = "";
			if(lastDir_openRom !="")
				openFileDialog.InitialDirectory = lastDir_openRom;
			openFileDialog.Filter = (""
			+	"all files(*.*)|*.*"
			+	"|all known types|*.c8;*.ch8;*.sc"
			+	"|CHIP-8, SuperChip(*.c8;*.ch8;*.sc)|*.c8;*.ch8;*.sc"
			);
		
			if(openFileDialog.ShowDialog() != DialogResult.Cancel) {
				lastDir_openRom = openFileDialog.InitialDirectory;
				if(!LoadFile(openFileDialog.FileName)) {
					if(running && !paused)
						machine.Resume();
				}
				else {
					machine.display.Tag = ++_openCouunt;
				}
			}
			else {
				if(running && !paused)
					machine.Resume();
			}
		
			this.Focus();

		}
		#endregion
		#region Machine
		void PauseToolStripMenuItemClick(object sender, EventArgs e) {
			if(machine != null) machine.Pause();
		}
		void ResumeToolStripMenuItemClick(object sender, EventArgs e) {
			if(machine != null) machine.Resume();
		}
		void RunToolStripMenuItemClick(object sender, EventArgs e) {
			machine.Run();
			Refresh();
			machine.display.Refresh();
		}
		void StepToolStripMenuItemClick(object sender, EventArgs e) {
			machine.StepInto();
		}
		void StopToolStripMenuItemClick(object sender, EventArgs e) {
			machine.Stop();
		}
		void ResetToolStripMenuItemClick(object sender, EventArgs e) {
			machine.HardReset();
		}
		#endregion
		#region Temp
		void LoadRomToolStripMenuItemClick(object sender, EventArgs e) {
			DialogResult dr = openFileDialog.ShowDialog();
			if(dr == DialogResult.OK) {
				LoadMachine_Chip8();
				machine.LoadRom(openFileDialog.FileName);
				//machine.Run();
			}
		}
		void TstyToolStripMenuItemClick(object sender, EventArgs e) {
			Msg.Box("ticks = " + eTimer.mainTimer.ticks);
		}
		#endregion
		#region Tools
		void HexEditorToolStripMenuItemClick(object sender, EventArgs e) {}
		#endregion
		#endregion
		#region properties
		public virtual MenuStrip menuStrip { get; protected set; }
		public virtual Disp_Base display { get; protected set; }
		public virtual M_Base machine { get; protected set; }
		public virtual M_C64 machine_C64 { get; protected set; }
		public virtual M_Chip8 machine_Chip8 { get; protected set; }
		public virtual M_test6502 machine_test6502 { get; protected set; }
		
		#endregion
		#region event handlers
		protected virtual void pnlDisplay_GotFocus(object sender, EventArgs e) {
			//sg.Dbg("pnlDisplay_GotFocus");
			if(_systemSettings.focusControl != null)
				_systemSettings.focusControl.Focus();
			else this.Focus();
		}
		#endregion
		#region function LoadMachine....
		protected virtual M_Base LoadMachine(M_Base val) {
			UnloadMachine();
			machine = val;
			display = val.display;
			pnl_display.Controls.Add(display);
			display.Dock = DockStyle.Fill;
			//OnResize(new EventArgs());
			return val;
		}
		public virtual void LoadMachine_C64() {
			displaySettings ds = settings.main.Chip8.display;
			machine_C64 = (M_C64)LoadMachine(new M_C64());
			machine.display.displaySizeMode = ds._sizeMode;
			machine.display.displayArg = ds._sizeModeInt;
			settings.main.inputHandler.mainHandler = machine.keyboard;
			this.Focus();
		}
		public virtual void LoadMachine_Chip8() {
			displaySettings ds = settings.main.Chip8.display;
			machine_Chip8 = (M_Chip8)LoadMachine(new M_Chip8());
			machine.display.displaySizeMode = ds._sizeMode;
			machine.display.displayArg = ds._sizeModeInt;
			settings.main.inputHandler.mainHandler = machine.keyboard;
			
			this.Focus();
		}
		public virtual void LoadMachine_test6502() {
			displaySettings ds = settings.main.Chip8.display;
			machine_test6502 = (M_test6502)LoadMachine(new M_test6502());
			machine.display.displaySizeMode = ds._sizeMode;
			machine.display.displayArg = ds._sizeModeInt;
			settings.main.inputHandler.mainHandler = machine.keyboard;
			this.Focus();
		}
		#endregion
		#region function: UnloadMachine
		public virtual void UnloadMachine() {
			if(machine != null) {
				machine.Unload();
				settings.main.inputHandler.mainHandler = null;
				ResetProperties_machine();
			}
		}
		#endregion
		#region function: ResetProperties....
		protected virtual void ResetProperties() {
			menuStrip = menuStrip_main;
			ResetProperties_machine();
		}
		protected virtual void ResetProperties_machine() {
			display = null;
			machine = null;
			machine_Chip8 = null;
		}
		#endregion
		#region function: GetFileType, LoadFile
		public virtual romFileType GetFileType(string fil) {
			romFileType rv = romFileType.unknown;
			FileInfo fi = new FileInfo(fil);
			
			if(!fi.Exists) {}
			else {
				//sg.Box("fi.Extension = " + fi.Extension.ToLower());
				switch(fi.Extension) {
					case ".c8": case ".ch8": case ".sc":
						rv = romFileType.chip8;
						break;
					
					default: break;
				}
			}
			
			
			return rv;
		}
		public virtual bool LoadFile(string fil) {
			return LoadFile(fil, romFileType.unknown);
		}
		public virtual bool LoadFile(string fil, romFileType type) {
			bool rv = true;
			
			if(type == romFileType.unknown)
				type = GetFileType(fil);

			if(type == romFileType.unknown) {
				Msg.Box("Could not load file \"" + fil + "\".\nUnknown file-type");
				rv = false;
			}
			else {
				if(machine != null && machine.running) machine.Stop();
				switch(type) {
					case romFileType.chip8:
						LoadMachine_Chip8();
						machine.LoadRom(fil);
						break;
					default: break;
				}
				if(startOnOpen) machine.Run();
				Refresh();
				display.Refresh();
				this.Focus();
			}
			
			return rv;
		}
		#endregion
		#region function: RunDebugger....
		public virtual void RunDebugger() {
			if(machine != null) {
				switch(machine.meta.name) {
					case "Machine.C64":
						RunDebugger_C64();
						break;
					case "Machine.Chip8":
						RunDebugger_Chip8();
						break;
					case "Machine.test6502":
						RunDebugger_test6502();
						break;
					default: break;
				}
			}
		}
		protected virtual void RunDebugger_C64() {
			displaySizeMode dsm = displaySizeMode.original;

			machine.Pause();

			_debuggerModule = new DebuggerModule_C64();
			_debuggerForm = new DebuggerForm(machine, _debuggerModule);

			if(ParentForm != null)
				ParentForm.Visible = false;

			if(machine.display != null) {
				dsm = machine.display.displaySizeMode;
				machine.display.displaySizeMode = displaySizeMode.original;
			}
			
			if(machine.cpu != null)
				machine.cpu.DBG = machine.cpu.DBG_SHOW_COMMAND = true;
			
			_debuggerForm.ShowDialog();
			machine.Pause();
			
			if(ParentForm != null)
				ParentForm.Visible = true;

			if(machine.display != null) {
				if(machine.display.Parent != null)
					machine.display.Parent.Controls.Remove(machine.display);
				pnl_display.Controls.Add(machine.display);
				machine.display.displaySizeMode = dsm;
				machine.display.Refresh();
			}

			if(machine.keyboard != null)
				settings.main.inputHandler.mainHandler = machine.keyboard;
			else
				settings.main.inputHandler.mainHandler = null;
			settings.main.inputHandler.altHandler = this;				
		}
		protected virtual void RunDebugger_Chip8() {
			displaySizeMode dsm = displaySizeMode.original;

			machine.Pause();

			_debuggerModule = new DebuggerModule_Chip8();
			_debuggerForm = new DebuggerForm(machine, _debuggerModule);

			if(ParentForm != null)
				ParentForm.Visible = false;

			if(machine.display != null) {
				dsm = machine.display.displaySizeMode;
				machine.display.displaySizeMode = displaySizeMode.original;
			}
			
			_debuggerForm.ShowDialog();
			machine.Pause();
			
			if(ParentForm != null)
				ParentForm.Visible = true;

			if(machine.display != null) {
				if(machine.display.Parent != null)
					machine.display.Parent.Controls.Remove(machine.display);
				pnl_display.Controls.Add(machine.display);
				machine.display.displaySizeMode = dsm;
				machine.display.Refresh();
			}

			if(machine.keyboard != null)
				settings.main.inputHandler.mainHandler = machine.keyboard;
			else
				settings.main.inputHandler.mainHandler = null;

			settings.main.inputHandler.altHandler = this;				
			machine_Chip8.cpu_Chip8.SetDoCycle(DoCycleMode.Main);
			
		}
		protected virtual void RunDebugger_test6502() {
			displaySizeMode dsm = displaySizeMode.original;

			machine.Pause();

			_debuggerModule = new DebuggerModule_6502();
			_debuggerForm = new DebuggerForm(machine, _debuggerModule);

			if(ParentForm != null)
				ParentForm.Visible = false;

			if(machine.display != null) {
				dsm = machine.display.displaySizeMode;
				machine.display.displaySizeMode = displaySizeMode.original;
			}
			
			if(machine.cpu != null)
				machine.cpu.DBG = machine.cpu.DBG_SHOW_COMMAND = true;
			
			_debuggerForm.ShowDialog();
			machine.Pause();
			
			if(ParentForm != null)
				ParentForm.Visible = true;

			if(machine.display != null) {
				if(machine.display.Parent != null)
					machine.display.Parent.Controls.Remove(machine.display);
				pnl_display.Controls.Add(machine.display);
				machine.display.displaySizeMode = dsm;
				machine.display.Refresh();
			}

			if(machine.keyboard != null)
				settings.main.inputHandler.mainHandler = machine.keyboard;
			else
				settings.main.inputHandler.mainHandler = null;

			settings.main.inputHandler.altHandler = this;				
			//machine_Chip8.cpu_Chip8.SetDoCycle(DoCycleMode.Main);
			
		}
		#endregion
		#region (iInput) KeyDownInput, KeyUpInput
		public bool KeyDownInput(KeyEventArgs e) {
			bool rv = false;

			if(machine != null && machine.keyboard != null)
				rv = machine.keyboard.KeyDownInput(e);
			
			if(!rv) {
				if(e.KeyCode == Keys.Back && machine != null) {
					rv = true;
					machine.Rewind();
				}
			}
		
			return rv;
		}
		public bool KeyUpInput(KeyEventArgs e) {
			bool rv = false;

			if(machine != null && machine.keyboard != null)
				rv = machine.keyboard.KeyUpInput(e);
			
			if(!rv) {
				if(e.KeyCode == Keys.Back && machine != null) {
					rv = true;
				}
			}
		
			return rv;
		}
		#endregion
		
		void Test6502ToolStripMenuItemClick(object sender, EventArgs e) {
			LoadMachine_test6502();
		}
		
		void TestC64ToolStripMenuItemClick(object sender, EventArgs e) {
			LoadMachine_C64();
		}
	}
}
