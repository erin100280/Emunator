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
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
#endregion

namespace Emu.Core {
	#region dictionaries: ByteArrayDict
	public class byteArrayDict : Dictionary<string, byte[]> {}
	public class boolDict : Dictionary<string, bool> {}
	public class byteDict : Dictionary<string, byte> {}
	public class charDict : Dictionary<string, char> {}
	public class doubleDict : Dictionary<string, double> {}
	public class floatDict : Dictionary<string, float> {}
	public class intDict : Dictionary<string, int> {}
	public class longDict : Dictionary<string, long> {}
	public class pointDict : Dictionary<string, Point> {}
	public class shortDict : Dictionary<string, short> {}
	public class sizeDict : Dictionary<string, Size> {}
	public class stringDict : Dictionary<string, string> {}
	public class uintDict : Dictionary<string, uint> {}
	public class ulongDict : Dictionary<string, ulong> {}
	public class ushortDict : Dictionary<string, ushort> {}
	#endregion
	#region class: state
	[Serializable]
	public class state {
		#region vars
		public string name = "";
		public byteArrayDict byteArrays;
		public boolDict bools;
		public byteDict bytes;
		public charDict chars;
		public doubleDict doubles;
		public floatDict floats;
		public intDict ints;
		public longDict longs;
		public pointDict points;
		public shortDict shorts;
		public sizeDict sizes;
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
			chars = new charDict();
			doubles = new doubleDict();
			floats = new floatDict();
			ints = new intDict();
			longs = new longDict();
			points = new pointDict();
			shorts = new shortDict();
			sizes = new sizeDict();
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
	}
	#endregion
	#region class: stateSystem
	public static class stateSystem {
		public static void SaveState(state val, string filename) {
			try {
				byte[] btArr;
				FileStream fs = new FileStream(filename, FileMode.Create
								, FileAccess.Write, FileShare.None);
				BinaryWriter bw = new BinaryWriter(fs);

				bw.Write(val.name); //-write name
				#region bools
				bw.Write(val.bools.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, bool> v in val.bools) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write bool
				}
				#endregion
				#region bytes
				bw.Write(val.bytes.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, byte> v in val.bytes) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write byte
				}
				#endregion
				#region bools
				bw.Write(val.chars.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, char> v in val.chars) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write char
				}
				#endregion
				#region doubles
				bw.Write(val.doubles.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, double> v in val.doubles) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write double
				}
				#endregion
				#region floats
				bw.Write(val.floats.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, float> v in val.floats) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write float
				}
				#endregion
				#region ints
				//sg.Box("val.ints.Count = " + val.ints.Count);
				bw.Write(val.ints.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, int> v in val.ints) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write byte
				}
				#endregion
				#region longs
				bw.Write(val.longs.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, long> v in val.longs) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write byte
				}
				#endregion
				#region points
				bw.Write(val.points.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, Point> v in val.points) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value.X); //-write X
		         bw.Write(v.Value.Y); //-write Y
				}
				#endregion
				#region shorts
				bw.Write(val.shorts.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, short> v in val.shorts) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write byte
				}
				#endregion
				#region sizes
				bw.Write(val.sizes.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, Size> v in val.sizes) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value.Width); //-write width
		         bw.Write(v.Value.Height); //-write height
				}
				#endregion
				#region strings
				bw.Write(val.strings.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, string> v in val.strings) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write byte
				}
				#endregion
				#region uints
				bw.Write(val.uints.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, uint> v in val.uints) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write byte
				}
				#endregion
				#region ulongs
				bw.Write(val.ulongs.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, ulong> v in val.ulongs) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write byte
				}
				#endregion
				#region ushorts
				bw.Write(val.ushorts.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, ushort> v in val.ushorts) {
		         bw.Write(v.Key); //-write key
		         bw.Write(v.Value); //-write byte
				}
				#endregion
				#region byteArrays
				bw.Write(val.byteArrays.Count); //-write dict count (4 bytes)
				//- write values
				foreach(KeyValuePair<string, byte[]> v in val.byteArrays) {
		         bw.Write(v.Key); //-write key
		         btArr = v.Value;
		         if(btArr == null) //-if array is null, create empty one
		         	btArr = new byte[0];
		         bw.Write(btArr.Length); //-write arr len (4b)
		         bw.Write(btArr); //-write arr
				}
				#endregion

				fs.Close();
			}
			catch(Exception ex) {
				Msg.Box(
					"Error: Could not save state to \"" + filename + "\"."
				+	"\n\n\n\n" + ex.Message
				);
			}
		}
		public static state LoadState(string filename) {
			var rv = new state();
			FileStream fs = null;
			BinaryReader br = null;
			int i, il;
			
			try {
				fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
				br = new BinaryReader(fs);
				
				rv.name = br.ReadString();
				#region bools
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.bools.Add(br.ReadString(), br.ReadBoolean());
				#endregion
				#region bytes
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.bytes.Add(br.ReadString(), br.ReadByte());
				#endregion
				#region chars
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.chars.Add(br.ReadString(), br.ReadChar());
				#endregion
				#region doubles
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.doubles.Add(br.ReadString(), br.ReadDouble());
				#endregion
				#region floats
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.floats.Add(br.ReadString(), br.ReadSingle());
				#endregion
				#region ints
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.ints.Add(br.ReadString(), br.ReadInt32());
				//sg.Box("rv.ints.Count = " + rv.ints.Count);
				#endregion
				#region longs
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.longs.Add(br.ReadString(), br.ReadInt64());
				#endregion
				#region points
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.points.Add(
						br.ReadString()
					,	new Point(br.ReadInt32(), br.ReadInt32())
				);
				#endregion
				#region shorts
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.shorts.Add(br.ReadString(), br.ReadInt16());
				#endregion
				#region sizes
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.sizes.Add(
						br.ReadString()
					,	new Size(br.ReadInt32(), br.ReadInt32())
				);
				#endregion
				#region strings
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.strings.Add(br.ReadString(), br.ReadString());
				#endregion
				#region uints
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.uints.Add(br.ReadString(), br.ReadUInt32());
				#endregion
				#region ulongs
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.ulongs.Add(br.ReadString(), br.ReadUInt64());
				#endregion
				#region ushorts
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.ushorts.Add(br.ReadString(), br.ReadUInt16());
				#endregion

				#region byteArrays
				for(i = 0, il = br.ReadInt32(); i < il; i++)
					rv.byteArrays.Add(br.ReadString(), br.ReadBytes(br.ReadInt32()));
				#endregion
				
				br.Close();
			}
			catch(Exception ex) {
				Msg.Box(
					"Error: Could not load state \"" + filename + "\""
				+	"\n\n\n\n" + ex.Message
				);
				if(br != null) br.Close();
				if(fs != null && fs.CanRead) fs.Close();
				return null;
			}
			
			return rv;
		}
	}
	#endregion

}