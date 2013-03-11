/* User: Erin
 * Date: 1/30/2013
 * Time: 8:57 AM
 */
using Emu.Core;
using Emunator.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Emunator {
	public partial class MainForm : Form {
		#region vars
		public Keys _cmdKey = Keys.None;
		#endregion
		#region constructors
		public MainForm() {
			InitializeComponent();
			
		}
		#endregion
		#region On....
		protected override void OnFormClosing(FormClosingEventArgs e) {
			if(theMainControl_main.machine != null)
				theMainControl_main.machine.Stop();
			Application.Exit();
			base.OnFormClosing(e);
		}		
		#endregion
		#region message handlers OLD
/*		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			//sg.Dbg("ProcessCmdKey - m.Msg = " + msg.Msg + " - keyData = " + keyData.ToString());
			_cmdKey = keyData;
			return base.ProcessCmdKey(ref msg, keyData);
		}
		protected override bool ProcessKeyPreview(ref Message m) {
			//sg.Dbg("ProcessKeyPreview - m.Msg = " + m.Msg);
			theMainControl tmc = theMainControl_main;
			//object obj = m.GetLParam(KeyEventArgs);
			if(_cmdKey != Keys.None && tmc != null) {
				KeyEventArgs e = new KeyEventArgs(_cmdKey);
				if(m.Msg == 256)
					return theMainControl_main.OnKeyDownMain(e);
				else if(m.Msg == 257)
					return theMainControl_main.OnKeyUpMain(e);
				else
					return base.ProcessKeyPreview(ref m);
			}
			return base.ProcessKeyPreview(ref m);
		}
		protected override bool ProcessKeyEventArgs(ref Message m) {
			//sg.Dbg("ProcessKeyEventArgs - m.Msg = " + m.Msg);
			return base.ProcessKeyEventArgs(ref m);
		}
*/		
		#endregion
	}
}
