#region header
/* User: Erin
 * Date: 2/16/2013
 * Time: 7:49 AM
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
	/// Description of DebuggerModule_Base.
	/// </summary>
	#endregion
	public class DebuggerModule_Base {
		#region vars
		public M_Base machine = null;
		public TextBox textBox = null;
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
		public void Init(M_Base _machine, TextBox txtbox) {
			machine = _machine;
			textBox = txtbox;
			OnInit(new EventArgs());
		}
		#endregion
		#region function: Setup....
		public virtual void SetupMisc(PropertyList list) {}
		public virtual void SetupRegisters(PropertyList list) {}
		#endregion
	}
}
