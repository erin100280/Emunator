/* User: Erin
 * Date: 2/2/2013
 * Time: 5:43 PM
 */
using Emu.Core;
using Emu.Core.FileSystem;
using System;
using System.IO;

namespace Emu.Memory {
	public class Mem_Base : baseClass {
		#region vars
		public const string NAME = "Mem_Base";
		public bool _readOnly = false;
		public string _statePrefix = "";
		public byte[] _bank;
		public UInt64 _size;

		public byte _blankByte = 0x00;
		public byte[] _data = null;
		public byte[] _defData = {};
		#endregion
		#region constructors
		public Mem_Base() : base(NAME) { InitMem_Base(); }
		public Mem_Base(uint size) : base(NAME) {
			InitMem_Base(size);
		}
		public Mem_Base(uint size, byte[] data) : base(NAME) {
			InitMem_Base(size, data);
		}
		public Mem_Base(byte[] data) : base(NAME) {
			InitMem_Base((UInt32)data.Length, data);
		}
		public Mem_Base(string name) : base(name) { InitMem_Base(); }
		public Mem_Base(string name, uint size) : base(name) {
			InitMem_Base(size);
		}
		public Mem_Base(string name, uint size, byte[] data) : base(name) {
			InitMem_Base(size, data);
		}
		public Mem_Base(string name, byte[] data) : base(name) {
			InitMem_Base((UInt32)data.Length, data);
		}
		protected virtual void InitMem_Base(uint size = 0, byte[] data = null) {
			if(size == 0) size = 4;
			_size = size;
			_bank = new byte[_size];
			if(data != null)
				_defData = data;
			HardReset();
		}
		#endregion
		#region events
		public event EventHandler BankChanged;
		public event EventHandler BeforeBankChanged;

		public event EventHandler ReadOnlyChanged;
		public event EventHandler BeforeReadOnlyChanged;
		#endregion
		#region On....
		protected virtual void OnBankChanged(EventArgs e) {
			if(BankChanged != null) BankChanged(this, e);
		}
		protected virtual void OnBeforeBankChanged(EventArgs e) {
			if(BeforeBankChanged != null) BeforeBankChanged(this, e);
		}

		protected virtual void OnReadOnlyChanged(EventArgs e) {
			if(ReadOnlyChanged != null) ReadOnlyChanged(this, e);
		}
		protected virtual void OnBeforeReadOnlyChanged(EventArgs e) {
			if(BeforeReadOnlyChanged != null) BeforeReadOnlyChanged(this, e);
		}
		#endregion
		#region properties
		public virtual UInt64 size { get { return _size; } }
		public virtual byte[] bank {
			get { return _bank; }
			set {
				if(_bank != value) {
					EventArgs e = new EventArgs();
					OnBeforeBankChanged(e);
					_bank = value;
					OnBankChanged(e);
				}
			}
		}
		public virtual bool readOnly {
			get { return _readOnly; }
			set {
				if(_readOnly != value) {
					OnBeforeReadOnlyChanged(blankEventArgs);
					_readOnly = value;
					OnReadOnlyChanged(blankEventArgs);
				}
			}
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
				
				SetMemory(State.byteArrays[_statePrefix + "MEM-WORKING"], 0);
			}
			catch(Exception ex) { Msg.Box("Error: State was all messed up and stuff.\n\n\n\n" + ex.Message); }
		}
		public virtual state UpdateState(state State) {
			State.byteArrays.Add(_statePrefix + "MEM-WORKING", _bank);
			State.ints.Add(_statePrefix + "MEM-SIZ", _bank.Length);
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
				for(UInt64 i = 0, l = (UInt64)val.fileSize; i < l; i++)
					_bank[startPos + i] = val.ReadByte();
			}
		}
		#endregion
		#region function: HardReset, SoftReset
		public override void HardReset() {
			base.HardReset();
			_data = new byte[_defData.Length];
			Array.Copy(_defData, _data, _defData.Length);
			SoftReset();
		}
		public override void SoftReset() {
			base.SoftReset();
			if(_bank != null) {
				for(Int32 iI = 0, iL = (Int32)_size; iI < iL; iI++)
					_bank[iI] = _blankByte;
				Array.Copy(_data, _bank, _data.Length);
			}
		}
		#endregion
		#region function: ClearBank
		public virtual void ClearBank() { ClearBank(0x00); }
		public virtual void ClearBank(byte bt) {
			for(UInt64 i = 0, l = _size; i < l; i++)
				_bank[i] = bt;
		}
		#endregion
		#region function Write
		public virtual void Write(byte val, int start, int len) {
			int aLen = _bank.Length;
			while(len-- >= 0)
				_bank[start + len] = val;
		}
		#endregion
	}
}
