#region header
/* User: Erin
 * Date: 2/16/2013
 * Time: 8:19 AM
 */
#endregion
#region using....
using Be.Windows.Forms;
using Emu;
using Emu.Core;
using Emu.Core.Controls;
using Emu.CPU;
using Emu.Debugger;
using Emu.Device;
using Emu.Device.Input;
using Emu.Device.Input.Keyboard;
using Emu.Display;
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
	public class DebuggerModule_Chip8 : DebuggerModule_Base {
		#region vars
		#endregion
		#region constructors
		public DebuggerModule_Chip8() { InitDebuggerModule_Chip8(); }
		protected virtual void InitDebuggerModule_Chip8() {
		
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
			propertyListItem itm = new propertyListItem("I", propertyType.hex, "0");
			itm.maxValue = 6000;
			list.AddItem(itm);
			list.RefreshList();
		}
		public override void SetupRegisters(PropertyList list) {
			for(Int32 i = 0; i < 16; i++)
				list.AddItem(new propertyListItem(
					"V" + IntToHex(i)
				,	propertyType.hex
				,	"0"
				));
			list.RefreshList();
		}
		#endregion
		#region function: UpdateGui....
		public override void UpdateGui_misc(PropertyList list) {
			list.SetValue("I", machine.cpu.m_indexRegister);
		}
		public override void UpdateGui_registers(PropertyList list) {
			for(Int32 i = 0; i < 16; i++)
				list.SetValue("V" + IntToHex(i), machine.cpu.m_vRegisters[i]);
		}
		public override void UpdateGui_programMemory(HexBox hb) {
			UInt16 pc = machine.cpu.m_counter;
			hb.ByteProvider = new DynamicByteProvider(machine.memory.bank);
			hb.ScrollByteIntoView(pc);
			hb.Select(pc, 1);
		}
		public override void UpdateGui_videoMemory(HexBox hb) {}
		public override void UpdateGui_workingMemory(HexBox hb) {}
		#endregion
		#region function: UpdateValues....
		public override void UpdateValues_misc(PropertyList list) {}
		public override void UpdateValues_registers(PropertyList list) {}
		public override void UpdateValues_programMemory(HexBox hb) {}
		public override void UpdateValues_videoMemory(HexBox hb) {}
		public override void UpdateValues_workingMemory(HexBox hb) {}
		#endregion
	}
}
