#region header
/* User: Erin
 * Date: 2/16/2013
 * Time: 8:19 AM
 */
#endregion
#region using....
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

		}
		public override void SetupRegisters(PropertyList list) {

		}
		#endregion
	}
}
