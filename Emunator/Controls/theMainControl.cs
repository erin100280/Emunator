#region header
/* User: Erin
 * Date: 2/7/2013
 * Time: 9:12 PM
 */
#endregion
#region using....
using Emunator.Forms;
using Be.HexEditor;
using Be.Windows.Forms;
using Emu.Core;
using Emu.Core.Settings;
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
	public enum romFileType {
		unknown
	,	chip8
	}
	
	#region meta
	/// <summary>
	/// theMainControl is the main control.
	/// </summary>
	#endregion
	public partial class theMainControl : UserControl {
		#region vars
		protected DebuggerForm _debuggerForm = null;
		protected DebuggerModule_Base _debuggerModule = null;
		public string lastDir_openRom = "";
		public bool startOnOpen = false;
		#endregion
		#region constructors
		public theMainControl() { InitTheMainControl(); }
		protected virtual void InitTheMainControl() {
			InitializeComponent();
			BackColor = Color.Black;
			ResetProperties();
		}
		#endregion
		#region On....
		protected override void OnLoad(EventArgs e) {
			
		}
		#endregion
		#region menu handlers
		#region Debug
		void DebuggerToolStripMenuItemClick(object sender, EventArgs e) {
			LoadDebugger();
		}
		void EditMemoryToolStripMenuItemClick(object sender, EventArgs e) {
			if(machine != null) {
				hexEditorOptions ops = new hexEditorOptions();
				ops.byteProvider = new DynamicByteProvider(machine.memory.bank);
				ops.showMnuItm_File_Open = false;
				ops.showMnuItm_File_Recent = false;
				ops.showMnuItm_File_Save = false;
				
				FormHexEditor frm =  new FormHexEditor(ops);
				if(ParentForm != null) frm.Show(ParentForm);
				else frm.Show();
			}
		}
		void EditVideoMemoryToolStripMenuItemClick(object sender, EventArgs e) {
			if(machine != null) {
				hexEditorOptions ops = new hexEditorOptions();
				ops.byteProvider = new DynamicByteProvider(machine.video.buffer);
				ops.showMnuItm_File_Open = false;
				ops.showMnuItm_File_Recent = false;
				ops.showMnuItm_File_Save = false;
				
				FormHexEditor frm =  new FormHexEditor(ops);
				if(ParentForm != null) frm.Show(ParentForm);
				else frm.Show();
			}
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
				if(!LoadFile(openFileDialog.FileName)) {
					if(running && !paused)
						machine.Resume();
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
			machine.Reset();
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
			display.displayArg = 6;
			display.displaySizeMode = displaySizeMode.times;
			Refresh();
			display.Refresh();
		}
		#endregion
		#region Tools
		void HexEditorToolStripMenuItemClick(object sender, EventArgs e) {
			FormHexEditor frm =  new FormHexEditor();
			if(ParentForm != null) frm.Show(ParentForm);
			else frm.Show();
		}
		#endregion
		#endregion
		#region properties
		public virtual MenuStrip menuStrip { get; protected set; }
		public virtual Disp_Base display { get; protected set; }
		public virtual M_Base machine { get; protected set; }
		public virtual M_Chip8 machine_Chip8 { get; protected set; }

		public virtual FormHexEditor hexEditor { get; protected set; }
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
		public virtual void LoadMachine_Chip8() {
			displaySettings ds = settings.main.Chip8.display;
			machine_Chip8 = (M_Chip8)LoadMachine(new M_Chip8());
			machine.keyboard.ConnectTo(this);
			machine.display.displaySizeMode = ds._sizeMode;
			machine.display.displayArg = ds._sizeModeInt;
			machine.display.Focus();
		}
		#endregion
		#region function: UnloadMachine
		public virtual void UnloadMachine() {
			if(machine != null) {
				machine.Unload();
				ResetProperties_machine();
			}
		}
		#endregion
		#region protected function: ResetProperties....
		protected virtual void ResetProperties() {
			menuStrip = menuStrip_main;
			hexEditor = null;
			ResetProperties_machine();
		}
		protected virtual void ResetProperties_machine() {
			display = null;
			machine = null;
			machine_Chip8 = null;
		}
		#endregion
		#region function: LoadDebugger....
		public virtual void LoadDebugger() {
			if(machine != null) {
				switch(machine.meta.name) {
					case "Machine.Chip8":
						LoadDebugger_Chip8();
						break;
					default: break;
				}
			}
		}
		protected virtual void LoadDebugger_Chip8() {
			machine.Pause();
			_debuggerModule = new DebuggerModule_Chip8();
			_debuggerForm = new DebuggerForm(machine, _debuggerModule);
			_debuggerForm.ShowDialog();
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
			}
			
			return rv;
		}
		#endregion
		
	}
}
