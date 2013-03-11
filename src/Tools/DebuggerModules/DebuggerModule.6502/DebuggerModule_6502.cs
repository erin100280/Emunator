#region header
/* User: Erin
 * Date: 3/1/2013
 * Time: 6:36 PM
 */
#endregion

#region using....
using Be.Windows.Forms;
using Emu;
using Emu.Core;
using Emu.Core.Controls;
using Emu.CPU;
using Emu.Debugger;
using Emu.Machine;
using Emu.Memory;
using System;
using System.Windows.Forms;
#endregion

namespace Emu.Debugger.Modules {
	#region meta
	/// <summary>
	/// Description of DebuggerModule_Chip8.
	/// </summary>
	#endregion
	public class DebuggerModule_6502 : DebuggerModule_Base {
		#region vars
		#endregion
		#region constructors
		public DebuggerModule_6502() { InitDebuggerModule_6502(); }
		protected virtual void InitDebuggerModule_6502() {
			//sg.Box("InitDebuggerModule_6502");
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#endregion
		#region function: Setup....
		public override void SetupMisc(PropertyList list) {
			//sg.Box("SetupMisc");
			list.AddItem(new propertyListItem(
				"Overflow"
			,	propertyType.hex
			,	"0"
			));
			list.AddItem(new propertyListItem(
				"Negative"
			,	propertyType.hex
			,	"0"
			));
			list.RefreshList();
		}
		public override void SetupRegisters(PropertyList list) {
			list.AddItem(new propertyListItem(
				"A"
			,	propertyType.hex
			,	"0"
			));
			list.AddItem(new propertyListItem(
				"X"
			,	propertyType.hex
			,	"0"
			));
			list.AddItem(new propertyListItem(
				"Y"
			,	propertyType.hex
			,	"0"
			));
			list.RefreshList();
		}
		#endregion
		#region function: UpdateGui....
		public override void UpdateGui_misc(PropertyList list) {
			C_6502 c = (C_6502)machine.cpu;
			
			list.SetValue("Overflow", c.GetStatus(c.statusFlag_overflow) ? 1 : 0);
			list.SetValue("Negative", c.GetStatus(c.statusFlag_negative) ? 1 : 0);
		}
		public override void UpdateGui_registers(PropertyList list) {
			list.SetValue("A", machine.cpu.A);
			list.SetValue("X", machine.cpu.X);
			list.SetValue("Y", machine.cpu.Y);
		}
		#endregion
		#region function: UpdateValues....
		public override void UpdateValues_misc(PropertyList list) {}
		public override void UpdateValues_registers(PropertyList list) {
		}
		#endregion
	}
}



