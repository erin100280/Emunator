/* User: Erin
 * Date: 2/12/2013
 * Time: 4:52 PM
 */
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Emu.Core {
	public class Msg {
		public static void Box(string val) {
			MessageBox.Show(val);
		}
		public static void Dbg(string val) {
			Debug.WriteLine(val);
		}
		public static void _Dbg(string val) {
			Debug.Write(val);
		}
	}
}
