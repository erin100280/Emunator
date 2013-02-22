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
	#region dictionaries: ByteArrayDict
	public class byteArrayDict : Dictionary<string, byte[]> {}
	public class boolDict : Dictionary<string, bool> {}
	public class byteDict : Dictionary<string, byte> {}
	public class intDict : Dictionary<string, int> {}
	public class longDict : Dictionary<string, long> {}
	public class shortDict : Dictionary<string, short> {}
	public class stringDict : Dictionary<string, string> {}
	public class uintDict : Dictionary<string, uint> {}
	public class ulongDict : Dictionary<string, ulong> {}
	public class ushortDict : Dictionary<string, ushort> {}
	#endregion
	#region class: state
	public class state {
		#region vars
		public string name = "";
		public byteArrayDict byteArrays;
		public boolDict bools;
		public byteDict bytes;
		public intDict ints;
		public longDict longs;
		public shortDict shorts;
		public stringDict strings;
		public uintDict uints;
		public ulongDict ulongs;
		public ushortDict ushorts;
		#endregion
		#region constructors
		public state() { InitState(); }
		protected virtual void InitState() {
			byteArrays = new byteArrayDict();
			bools = new boolDict();
			bytes = new byteDict();
			ints = new intDict();
			longs = new longDict();
			shorts = new shortDict();
			strings = new stringDict();
			uints = new uintDict();
			ulongs = new ulongDict();
			ushorts = new ushortDict();
		}
		#endregion
		#region function: GetByteArray
		public virtual byte[] GetByteArray(string name) {
			if(byteArrays.ContainsKey(name))
				return byteArrays[name];
			else return null;
		}
		public virtual void GetByteArray(string name, byte[] val) {
			byteArrays.Add(name, val);
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
	#region class: state
	public static class stateSystem {
		
	}
	#endregion

}