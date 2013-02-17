#region header
/* User: Erin
 * Date: 2/16/2013
 * Time: 12:10 AM
 */
#endregion
#region using....
using Emu.Debugger.Modules;
using Emu.Machine;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Emu.Debugger.Controls {
	#region meta
	/// <summary>
	/// Description of DebuggerPanel.
	/// </summary>
	#endregion
	public partial class DebuggerPanel : UserControl {
		#region vars
		protected DebuggerModule_Base _module = null;
		protected M_Base _machine = null;
		#endregion
		#region constructors
		public DebuggerPanel() { InitDebuggerPanel(null, null); }
		public DebuggerPanel(M_Base _Machine) {
			InitDebuggerPanel(_Machine, null);
		}
		public DebuggerPanel(M_Base _Machine, DebuggerModule_Base mod) {
			InitDebuggerPanel(_Machine, mod);
		}
		protected virtual void InitDebuggerPanel(M_Base _Machine
		                                         , DebuggerModule_Base mod) {
			InitializeComponent();
			machine = _Machine;
			module = mod;
		}
		#endregion
		#region events
		#endregion
		#region properties
		public virtual M_Base machine {
			get { return _machine; }
			set {
				if(_machine != value) {
					OnBeforeMachineChanged(new EventArgs());
					_machine = value;
					OnMachineChanged(new EventArgs());
				}
			}
		}
		public virtual DebuggerModule_Base module {
			get { return _module; }
			set {
				if(_module != value) {
					OnBeforeModuleChanged(new EventArgs());
					_module = value;
					OnModuleChanged(new EventArgs());
				}
			}
		}
		#endregion
		#region On....
		protected virtual void OnBeforeMachineChanged(EventArgs e) {
			
		}
		protected virtual void OnBeforeModuleChanged(EventArgs e) {
			
		}
		protected virtual void OnMachineChanged(EventArgs e) {
			
		}
		protected virtual void OnModuleChanged(EventArgs e) {
			if(_machine != null) {
				//_module.Init(_machine, 
			}
		}
		#endregion
		#region function: blah
		#endregion
	}
}
