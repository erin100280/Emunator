/* User: Erin
 * Date: 1/30/2013
 * Time: 8:57 AM
 */
using Emu.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Emunator {
	public partial class MainForm : Form {
		#region vars
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
		#region menu handlers
		#endregion
	}

	
}
