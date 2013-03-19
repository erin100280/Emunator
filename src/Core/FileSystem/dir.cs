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
		#region vars
		#endregion
		#region constructors
		public dir(): base("dir") { InitDir(); }
		protected virtual void InitDir() {}
		#endregion
	}
}
