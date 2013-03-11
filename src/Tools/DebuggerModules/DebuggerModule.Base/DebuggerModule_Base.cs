#region header
/* User: Erin
 * Date: 2/16/2013
 * Time: 7:49 AM
 */
#endregion
#region using....
using Be.Windows.Forms;
using ConsoleControl;
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
using Emu.Video;
using System;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Emu.Debugger.Modules {
	#region class: DebuggerModule_Base
	#region meta
	/// <summary>
	/// Description of DebuggerModule_Base.
	/// </summary>
	#endregion
	public class DebuggerModule_Base {
		#region static function IntToHex, HexToInt
		public static string IntToHex(Int32 v) { return v.ToString("X"); }
		public static Int32 HexToInt(string v) {
			return int.Parse(v, System.Globalization.NumberStyles.HexNumber);
		}
		#endregion
		#region vars
		public M_Base machine = null;
		public C_Base cpu = null;
		public Mem_Base programMemory = null;
		public Mem_Base workingMemory = null;
		public Vid_Base video = null;
		public Disp_Base display = null;
		
		public TextBox textBox = null;
		public consoleRef console = null;
		#endregion
		#region constructors
		public DebuggerModule_Base() { InitDebuggerModule_Base(); }
		protected virtual void InitDebuggerModule_Base() {
		
		}
		#endregion
		#region events
		public event EventHandler Initialize;
		#endregion
		#region properties
		//public virtual M_Base machine { get; set;
		#endregion
		#region On....
		protected virtual void OnInit(EventArgs e) {
			if(Initialize != null) Initialize(this, e);
		}
		#endregion
		#region function: Init
		public void Init(M_Base _machine, consoleRef _Console) {
			machine = _machine;
			cpu = machine.cpu;
			programMemory = machine.programMemory;
			workingMemory = machine.workingMemory;
			video = machine.video;
			display = machine.display;
			
			console = _Console;
			OnInit(new EventArgs());
		}
		#endregion
		#region function: Setup....
		public virtual void SetupMisc(PropertyList list) {}
		public virtual void SetupRegisters(PropertyList list) {}
		#endregion
		#region function: Get...., Set....
		#region PC
		public virtual Int32 GetPC() {
			return cpu.PC;
		}
		public virtual void SetPC(Int32 val) {
			cpu.PC = (UInt16)val;
		}
		#endregion
		#region CycleCount
		public virtual UInt64 GetCycleCount() {
			return cpu.cycleCount;
		}
		public virtual void SetCycleCount(UInt64 val) {
			cpu.cycleCount = val;
		}
		#endregion
		#endregion
		#region function: UpdateGui....
		public virtual void UpdateGui_misc(PropertyList list) {}
		public virtual void UpdateGui_registers(PropertyList list) {}
		public virtual void UpdateGui_programMemory(HexBox hb) {
			UInt16 pc = machine.cpu.PC;
			hb.ByteProvider = new DynamicByteProvider(machine.programMemory.bank);
			hb.ScrollByteIntoView(pc);
			hb.Select(pc, 1);
		}
		public virtual void UpdateGui_PC(NumericUpDown upDown) {
		
		}
		public virtual void UpdateGui_videoMemory(HexBox hb) {}
		public virtual void UpdateGui_workingMemory(HexBox hb) {}
		#endregion
		#region function: UpdateValues....
		public virtual void UpdateValues_misc(PropertyList list) {}
		public virtual void UpdateValues_registers(PropertyList list) {}
		public virtual void UpdateValues_programMemory(HexBox hb) {
			if(machine != null && machine._programMemory != null
			  				&& machine._programMemory._bank != null) {

				IByteProvider bp = hb.ByteProvider;
				byte[] bts = machine._programMemory._bank;
				long i, il = bp.Length;
				if(bts.Length < il)
					il = bts.Length;
				
				for(i = 0; i < il; i++)
					bts[i] = bp.ReadByte(i);

			}
		}
		public virtual void UpdateValues_videoMemory(HexBox hb) {}
		public virtual void UpdateValues_workingMemory(HexBox hb) {
			hb.ByteProvider = new DynamicByteProvider(machine.workingMemory.bank);
		}
		#endregion
	}
	#endregion

}



