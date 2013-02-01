/* User: Erin
 * Date: 1/30/2013
 * Time: 8:57 AM
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Emunator {
	public partial class MainForm : Form {
		#region vars
		Emu.CPU.C_Chip8 cpu=null;
		#endregion
		public MainForm() {
			InitializeComponent();
			
		}
	}
}
