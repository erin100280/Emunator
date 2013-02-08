/* User: Erin
 * Date: 2/7/2013
 * Time: 9:00 PM
 */

using System;
using System.IO;

namespace Emu.Core.FileSystem {
		public partial class file {
		#region vars
		#endregion
		#region constructors
		public file() { InitFile(); }
		protected virtual void InitFile() {
			ResetProperties();
		}
		#endregion
		#region properties
		public virtual FileInfo fileInfo { get; protected set; }
		public virtual bool exists { get; protected set; }
		public virtual long fileSize { get; protected set; }

		public virtual BinaryReader binaryReader { get; protected set; }
		public virtual FileStream fileStream { get; protected set; }

		public virtual bool hasInfo { get; protected set; }
		#endregion
		#region function: ResetProperties
		protected virtual void ResetProperties() {
			fileInfo = null;
			exists = false;
			fileSize = 0;
		
			binaryReader = null;
			fileStream = null;
			
			hasInfo = false;
		}
		#endregion
	}


	
}
