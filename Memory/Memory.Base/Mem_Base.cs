/* User: Erin
 * Date: 2/2/2013
 * Time: 5:43 PM
 */
using Emu.Core.FileSystem;
using System;
using System.IO;

namespace Emu.Memory {
	public class Mem_Base {
		#region vars
		protected byte[] _bank;
		protected UInt64 _size;
		protected ushort _startAddress;
		protected Int64 _romSize;
		protected int _startRomAddress;
		protected int _stopRomAddress;
		protected int _ramSize;
		protected int _startRamAddress;

		#endregion
		#region constructors
		public Mem_Base() { InitMem_Base(); }
		public Mem_Base(uint size) { InitMem_Base(); }
		protected virtual void InitMem_Base(uint size=0) {
			if(size==0) size=4096;
			_size=size;
			_bank=new byte[_size];
		}
		#endregion
		#region properties
		public virtual UInt64 size { get { return _size; } }
		public virtual byte[] bank { get { return _bank; } }
		public virtual Int64 romSize { get { return _romSize; } }
		#endregion
		public virtual void SetMemory(byte[] val, UInt64 startPos) {
			for(uint i = 0, l = (uint)val.Length; i < l; i++)
				_bank[startPos + i] = val[i];
		}
		public virtual void SetMemory(BinaryReader val, UInt64 startPos) {
			uint i = 0;
			int byt = val.Read();
			
			try {
				while(true) {
					_bank[startPos + i] = val.ReadByte();
					i++;
				}
			}
			catch(Exception ex) { if(ex.Data == null) {} }
		}
		public virtual void SetMemory(file val, UInt64 startPos) {
			if(val.exists) {
				_romSize = val.fileSize;
				for(UInt64 i = 0, l = (UInt64)val.fileSize; i < l; i++)
					_bank[startPos + i] = val.ReadByte();
			}
		}
		public virtual void Reset(bool clearBank = true) {
			if(clearBank) ClearBank();
		
		}
		public virtual void ClearBank() {
			for(UInt64 i = 0, l = _size; i < l; i++)
				_bank[i] = 0x0;
		
		}
	
	}
}
