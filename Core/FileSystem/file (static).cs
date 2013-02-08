/* User: Erin
 * Date: 2/7/2013
 * Time: 9:01 PM
 */

using System;
using System.IO;

namespace Emu.Core.FileSystem {
		public partial class file {
		#region static function: GetFileInfo
		public static file GetFileInfo(string filename) {
			file rv = new file();
			
			FileInfo fi = new FileInfo(filename);
			rv.fileInfo = fi;
			rv.exists = fi.Exists;
			rv.fileSize = fi.Length;
			
			return rv;
		}
		#endregion
		#region static function: LoadBinaryStream
		public static file LoadBinaryStream(string filename) {
			file rv = GetFileInfo(filename);
			rv.fileStream = new FileStream(
			  filename
			, FileMode.Open
			, FileAccess.Read
			);
			rv.binaryReader = new BinaryReader(rv.fileStream);
			return rv;
		}
		#endregion
	}
	
}
