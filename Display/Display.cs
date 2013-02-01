/* User: Erin
 * Date: 1/30/2013
 * Time: 8:02 PM
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Emu {
	public class Display : UserControl {
		#region vars
		#endregion
		#region constructors
		public Display(): base() { InitDisplay(); }
		protected virtual void InitDisplay() {
			BackColor=Color.Black;
		}
		#endregion
		#region events
		#endregion
		#region On....
		#endregion
	}
}