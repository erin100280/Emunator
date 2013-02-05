/* User: Erin
 * Date: 1/30/2013
 * Time: 8:02 PM
 */
using Emu.Video;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Emu {
	public class Display : UserControl {
		#region vars
		protected Vid_Base m_video=null;
		#endregion
		#region constructors
		public Display(): base() { InitDisplay(); }
		public Display(Vid_Base vid): base() { InitDisplay(vid); }
		protected virtual void InitDisplay(Vid_Base vid=null) {
			BackColor=Color.Black;
			m_video=vid;
		}
		#endregion
		#region properties
		#endregion
		#region events
		#endregion
		#region On....
		#endregion
	}
}