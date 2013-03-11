#region header
/* User: Erin
 * Date: 2/26/2013
 * Time: 3:45 PM
 */
#endregion
#region using....
using Emu.Core.Interfaces;
using System;
using System.Windows.Forms;
#endregion

namespace Emu.Core {
	#region meta
	/// <summary>
	/// Description of Core_inputHandler.
	/// </summary>
	#endregion
	public class inputHandler {
		#region vars
		public iInput mainHandler = null;
		public iInput altHandler = null;
		public iInput sysHandler = null;
		#endregion
		#region function: HandleKeyDown, HandleKeyUp
		public void HandleKeyDown(object sender, KeyEventArgs e) {
			bool bl = false;
			
			if(!bl && mainHandler != null)
				bl = mainHandler.KeyDownInput(e);
			if(!bl && altHandler != null)
				bl = altHandler.KeyDownInput(e);
			if(!bl && sysHandler != null)
				bl = sysHandler.KeyDownInput(e);

		}
		public void HandleKeyUp(object sender, KeyEventArgs e) {
			bool bl = false;
			
			if(!bl && mainHandler != null)
				bl = mainHandler.KeyUpInput(e);
			if(!bl && altHandler != null)
				bl = altHandler.KeyUpInput(e);
			if(!bl && sysHandler != null)
				bl = sysHandler.KeyUpInput(e);

		}
		#endregion
	}
}
