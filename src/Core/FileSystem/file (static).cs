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
			if(rv.exists) {
				rv.fileStream = new FileStream(
				  filename
				, FileMode.Open
				, FileAccess.Read
				);
				rv.binaryReader = new BinaryReader(rv.fileStream);
			}
			return rv;
		}
		#endregion
		#region static function: LoadBytes
		public static byte[] LoadBytes(string filename, byte[] defData = null) {
			bool noGo = true;
			byte[] rv = defData;

			if(File.Exists(filename)) {
				try {
					//sg.Box("File.Exists(\"" + filename + "\");");
					FileInfo fi = new FileInfo(filename);
					BinaryReader br = new BinaryReader(new FileStream(
						filename
					,	FileMode.Open
					,	FileAccess.Read
					,	FileShare.Read
					));
					rv = br.ReadBytes((int)fi.Length);
					noGo = false;
				}
				catch(Exception ex) { if(ex.Message == "") {} }
			}

			if(noGo) {
				//sg.Box("noGo - " + filename);
				if(defData == null) defData = new byte[0];
				rv = defData;
			}

/*			string str = "";
			foreach (var elem in rv)
				str += elem.ToString("X");
			Msg.Box("rv = " + str);
//*/			
			return rv;
		}
		#endregion
	
	}
	
}
