#region header
/* User: Erin
 * Date: 2/24/2013
 * Time: 6:04 AM
 */
#endregion
#region using....
using System;
using System.Windows.Forms;
#endregion

namespace ConsoleControl {
	#region meta
	/// <summary>
	/// Description of RichTxtBox.
	/// </summary>
	#endregion
	public class RicherTextBox : RichTextBox {
		#region static
		#region static vars
		#endregion
		#region static events
		#endregion
		#region static properties
		#endregion
		#region static On....
		#endregion
		#region static functions
		#endregion
		#region static function: blah
		#endregion
		#endregion
		public delegate string string_delegate();
		#region vars
		public string_delegate GetText;
		#endregion
		#region constructors
		public RicherTextBox() { InitRicherTextBox(); }
		protected virtual void InitRicherTextBox() {
			GetText = new string_delegate(GetTextSafe);
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#endregion
		#region function: Get...Safe, Set...Safe
		protected virtual string GetTextSafe() { return Text; }
		#endregion
		#region function: blah
		#endregion
	}
}
