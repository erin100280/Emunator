#region header
/* User: Erin
 * Date: 2/3/2013
 * Time: 5:59 AM
 */
#endregion
#region using
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
#endregion

namespace Emu.Core {
	#region class: ByteArrayDict
	public class ByteArrayDict : Dictionary<string, byte[]> {}
	#endregion
	#region class: stateBase
	public class stateBase {
		#region vars
		public ByteArrayDict _dict;
		#endregion
		#region constructors
		public stateBase() {
			_dict = new ByteArrayDict();
		}
		#endregion
		#region function: GetByteArray
		public virtual byte[] GetByteArray(string name) {
			if(_dict.ContainsKey(name))
				return _dict[name];
			else return null;
		}
		public virtual void GetByteArray(string name, byte[] val) {
			_dict.Add(name, val);
		}
		#endregion
		#region function: Load....
		public virtual void LoadFromFile(string nam) {}
		public virtual void LoadFromMemory(byte[] val) {}
		#endregion
		#region function: Save....
		public virtual void SaveToFile(string nam) {}
		public virtual byte[] SaveToMemory() { return null; }
		#endregion
	}
	#endregion
}