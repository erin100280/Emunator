#region header
/* User: Erin
 * Date: 2/7/2013
 * Time: 9:12 PM
 */
#endregion
#region using....
using Be.HexEditor;
using Be.Windows.Forms;
using Emu.Core;
using Emu.Display;
using Emu.Machine;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Emunator.Controls {
	#region meta
	/// <summary>
	/// theMainControl is the main control.
	/// </summary>
	#endregion
	public partial class theMainControl : UserControl {
		#region vars
		
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
			display.displayMode = displayMode.times;
			display.Refresh();
		}
		void PauseToolStripMenuItemClick(object sender, EventArgs e) {
			if(machine != null) machine.Pause();
		}
		void ResumeToolStripMenuItemClick(object sender, EventArgs e) {
			if(machine != null) machine.Resume();
		}
		void HexEditorToolStripMenuItemClick(object sender, EventArgs e) {
			FormHexEditor frm =  new FormHexEditor();
			if(ParentForm != null) frm.Show(ParentForm);
			else frm.Show();
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
		void RunToolStripMenuItemClick(object sender, EventArgs e) {
			machine.Run();
		}
		void StepToolStripMenuItemClick(object sender, EventArgs e) {
			machine.Step();
		}
		void StopToolStripMenuItemClick(object sender, EventArgs e) {
			machine.Stop();
		}
		void ResetToolStripMenuItemClick(object sender, EventArgs e) {
			machine.Reset();
		}
		void TSMnuItm_File_ExitClick(object sender, EventArgs e) {
			Application.Exit();
		}
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
			machine_Chip8 = (M_Chip8)LoadMachine(new M_Chip8());
			machine.keyboard.ConnectTo(this);
			//machine.keyboard.ConnectTo(this.ParentForm);
			
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
		
	}
}
