/* User: Erin
 * Date: 2/7/2013
 * Time: 9:12 PM
 */
using Emu.Core;
using Emu.Display;
using Emu.Machine;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Emunator.Controls {
	#region meta
	/// <summary>
	/// theMainControl is the main control.
	/// </summary>
	#endregion
	public partial class theMainControl : UserControl
	{
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
				
			
			}
		}
		#endregion
		#region properties
		public virtual MenuStrip menuStrip { get; protected set; }
		public virtual Disp_Base display { get; protected set; }
		public virtual M_Base machine { get; protected set; }
		public virtual M_Chip8 machine_Chip8 { get; protected set; }
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
			ResetProperties_machine();
		}
		protected virtual void ResetProperties_machine() {
			display = null;
			machine = null;
			machine_Chip8 = null;
		}
		#endregion
		
		void TstyToolStripMenuItemClick(object sender, EventArgs e) {
			LoadMachine_Chip8();
		}
	}
}
