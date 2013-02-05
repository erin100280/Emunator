/* User: Erin
 * Date: 2/3/2013
 * Time: 12:56 AM
 */

namespace Emu.Core {
	public class metaData {
		#region constructors
		public metaData(string name) { InitMetaData(name); }
		private void InitMetaData(string name="") {
			this.name=name;
		}
		#endregion
		public string name;
	}
}
