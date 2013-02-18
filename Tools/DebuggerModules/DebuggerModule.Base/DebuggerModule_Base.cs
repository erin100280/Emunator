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
using System;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Emu.Debugger.Modules {
	#region class: consoleRef
	public class consoleRef {
		protected ConsoleControl.consoleControl _console;
		public consoleRef(object _Console) {
			_console = (consoleControl)_Console;
			_console.BackColor = Color.DarkGray;
		}
		public virtual void Clear() { _console.ClearOutput(); }
		public virtual void Write(string val) {
			Write(val, Color.White);
		}
		public virtual void Write(string val, Color clr) {
			_console.WriteOutput(val, clr);
		}
	}
	#endregion
	#region class: DebuggerModule_Base
	#region meta
	/// <summary>
	/// Description of DebuggerModule_Base.
	/// </summary>
	#endregion
	public class DebuggerModule_Base {
		#region statci function IntToHex, HexToInt
		public static string IntToHex(Int32 v) { return v.ToString("X"); }
		public static Int32 HexToInt(string v) {
			return int.Parse(v, System.Globalization.NumberStyles.HexNumber);
		}
		#endregion
		#region vars
		public M_Base machine = null;
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
			console = _Console;			
			OnInit(new EventArgs());
		}
		#endregion
		#region function: Setup....
		public virtual void SetupMisc(PropertyList list) {}
		public virtual void SetupRegisters(PropertyList list) {}
		#endregion
		#region function: UpdateGui....
		public virtual void UpdateGui_misc(PropertyList list) {}
		public virtual void UpdateGui_registers(PropertyList list) {}
		public virtual void UpdateGui_programMemory(HexBox hb) {}
		public virtual void UpdateGui_videoMemory(HexBox hb) {}
		public virtual void UpdateGui_workingMemory(HexBox hb) {}
		#endregion
		#region function: UpdateValues....
		public virtual void UpdateValues_misc(PropertyList list) {}
		public virtual void UpdateValues_registers(PropertyList list) {}
		public virtual void UpdateValues_programMemory(HexBox hb) {}
		public virtual void UpdateValues_videoMemory(HexBox hb) {}
		public virtual void UpdateValues_workingMemory(HexBox hb) {}
		#endregion
	}
	#endregion
}
