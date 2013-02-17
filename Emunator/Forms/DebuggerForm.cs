/* User: Erin
 * Date: 2/16/2013
 * Time: 9:44 PM
 */
using Emu.Debugger;
using Emu.Debugger.Controls;
using Emu.Debugger.Modules;
using Emu.Machine;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Emunator.Forms {
	/// <summary>
	/// Description of DebuggerForm.
	/// </summary>
	public partial class DebuggerForm : Form {
		#region constructors
		public DebuggerForm() { InitDebuggerForm(null, null); }
		public DebuggerForm(M_Base m, DebuggerModule_Base md) {
			InitDebuggerForm(m, md);
		}
		protected virtual void InitDebuggerForm(M_Base m, DebuggerModule_Base md) {
			InitializeComponent();
			debuggerPanel_main.machine = m;
			debuggerPanel_main.module = md;
		}
		#endregion
	}
}
