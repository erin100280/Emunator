#region header
/* User: Erin
 * Date: 3/18/2013
 * Time: 8:14 AM
 */
#endregion
using System;
using System.IO;

namespace Emu.Core.FileSystem {
	public partial class dir : baseClass {
		#region static function: Join
		public static string Join(string s2) {
			return Join("C:\\Dev\\Projects\\Emunator", s2);
		}
		public static string Join(string s1, string s2) {
			int i = 0;
			if(!s1.EndsWith("\\")) s1 += "\\";
			if(s2.StartsWith("\\")) i++;
			return s1 + s2.Substring(i, s2.Length - i);
		}
		#endregion
		#region static function: Validate
		public static string Validate(string dir) {
			int ii, il;
			string s = "";
			string[] dirs = dir.Split('\\');
			if(dirs.Length > 0) {
				s = dirs[0];
				if(s != "") {
					if(s.Contains(":")) s += "\\";
					if(!Directory.Exists(s)) Directory.CreateDirectory(s);
				}
			}
			for(ii = 1, il = dirs.Length; ii < il; ii++) {
				s = Join(s, dirs[ii]);
				if(!Directory.Exists(s)) Directory.CreateDirectory(s);
			}
			
			return dir;
		}
		#endregion
	}
}
