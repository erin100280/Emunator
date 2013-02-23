/* User: Erin
 * Date: 2/2/2013
 * Time: 5:43 PM
 */
using Emu.Core;
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
		protected Int64 _ramSize;
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
		public virtual byte[] bank {
			get { return _bank; }
			set {
				EventArgs e = new EventArgs();
				OnBeforeBankChanged(e);
				_bank = value;
				OnBankChanged(e);
			}
		}
		public virtual Int64 romSize { get { return _romSize; } }
		#endregion
		#region events
		public event EventHandler BankChanged;
		public event EventHandler BeforeBankChanged;
		#endregion
		#region On....
		protected virtual void OnBankChanged(EventArgs e) {
			if(BankChanged != null) BankChanged(this, e);
		}
		protected virtual void OnBeforeBankChanged(EventArgs e) {
			if(BeforeBankChanged != null) BeforeBankChanged(this, e);
		}
		#endregion
		#region state stuff
		public virtual state GetState() { return UpdateState(new state()); }
		public virtual void SetState(state State) {
			int i;
			try {
				i = State.ints["MEM-SIZ"];
				if(_bank.Length != i)
					bank = new Byte[i];
				
				SetMemory(State.byteArrays["MEM-WORKING"], 0);
				
				_ramSize = State.longs["MEM-RAM-SIZ"];
				_romSize = State.longs["MEM-ROM-SIZ"];
				_startRamAddress = State.ints["MEM-RAM-START"];
				_startRomAddress = State.ints["MEM-ROM-START"];
				
			}
			catch(Exception ex) { Msg.Box("Error: State was all messed up and stuff.\n\n\n\n" + ex.Message); }
		}
		public virtual state UpdateState(state State) {
			State.byteArrays.Add("MEM-WORKING", _bank);
			State.ints.Add("MEM-RAM-START", _startRamAddress);
			State.ints.Add("MEM-ROM-START", _startRomAddress);
			State.longs.Add("MEM-RAM-SIZ", _ramSize);
			State.longs.Add("MEM-ROM-SIZ", _romSize);
			State.ints.Add("MEM-SIZ", _bank.Length);
			return State;
		}
		#endregion
		#region function: SetMemory....
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
		#endregion
		#region function: HardReset, Reset, SoftReset
		public virtual void HardReset(bool run = false) {
			
		}
		public virtual void Reset(bool clearBank = true) {
			if(clearBank) ClearBank();
		
		}
		public virtual void SoftReset(bool run = false) {
			
		}
		#endregion
		public virtual void ClearBank() {
			for(UInt64 i = 0, l = _size; i < l; i++)
				_bank[i] = 0x0;
		
		}
	
	}
}
