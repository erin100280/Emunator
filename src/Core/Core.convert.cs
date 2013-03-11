#region header
/* User: Erin
 * Date: 2/23/2013
 * Time: 2:16 AM
 */
#endregion
#region using....
using System;
#endregion

namespace Emu.Core {
	#region meta
	/// <summary>
	/// Description of Core_convert.
	/// </summary>
	#endregion
	public static class convert {
		#region static function IntToHex, HexToInt
		public static string IntToHex(Int32 v) { return v.ToString("X"); }
		public static Int32 HexToInt(string v) {
			return int.Parse(v, System.Globalization.NumberStyles.HexNumber);
		}
		#endregion
	}
}
