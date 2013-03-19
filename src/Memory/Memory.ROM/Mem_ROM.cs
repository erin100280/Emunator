#region header
/* User: Erin
 * Date: 3/18/2013
 * Time: 2:56 AM
 */
/* for Emunator */
#endregion
#region using....
using Emu.Core;
using Emu.Memory;
using System;
#endregion

namespace Emu.Memory {
	#region meta
	/// <summary>
	/// Description of Mem_ROM.
	/// </summary>
	#endregion
	public class Mem_ROM : baseClass {
		#region static
		#region static vars
		public const string NAME = "Mem_ROM";
		#endregion
		#region static events
		#endregion
		#region static properties
		#endregion
		#region static On....
		#endregion
		#region static functions
		#endregion
		#region static function: blah
		#endregion
		#endregion
		#region vars
		public Mem_Base _map = null;
		public Int32 _start;
		public Int32 _defStart;
		public Int32 _len;
		public Int32 _defLen;
		public Int32 _offset;
		public Int32 _defOffset;
		public byte _blankByte = 0x00;
		public byte[] _data = null;
		public byte[] _defData = {};
		#endregion
		#region constructors
		public Mem_ROM(): base(NAME) { InitMem_ROM(null, null, 0, 0, 0); }
		public Mem_ROM(Mem_Base map): base(NAME) {
			InitMem_ROM(map, null, 0, 0, 0);
		}
		public Mem_ROM(Mem_Base map, Int32 start, Int32 len
						, Int32 offset): base(NAME) {
			InitMem_ROM(map, null, start, len, offset);
		}
		public Mem_ROM(Mem_Base map, byte[] data): base(NAME) {
			InitMem_ROM(map, data, 0, 0, 0);
		}
		public Mem_ROM(Mem_Base map, byte[] data, Int32 start, Int32 len
						, Int32 offset): base(NAME) {
			InitMem_ROM(map, data, start, len, offset);
		}
		public Mem_ROM(string name): base(name) {
			InitMem_ROM(null, null, 0, 0, 0);
		}
		public Mem_ROM(string name, Mem_Base map): base(name) {
			InitMem_ROM(map, null, 0, 0, 0);
		}
		public Mem_ROM(string name, Mem_Base map, Int32 start, Int32 len
						, Int32 offset): base(name) {
			InitMem_ROM(map, null, start, len, offset);
		}
		public Mem_ROM(string name, Mem_Base map, byte[] data): base(name) {
			InitMem_ROM(map, data, 0, 0, 0);
		}
		public Mem_ROM(string name, Mem_Base map, byte[] data, Int32 start
						, Int32 len, Int32 offset): base(name) {
			InitMem_ROM(map, data, start, len, offset);
		}
		protected virtual void InitMem_ROM(Mem_Base map, byte[] data
						, Int32 start, Int32 len, Int32 offset) {
			this.map = map;
			_defStart = start;
			_defLen = len;
			_defOffset = offset;
			if(data != null) {
				_defData = data;
			}
			HardReset();
		}
		#endregion
		#region events
		public event EventHandler MapChanged;
		public event EventHandler BeforeMapChanged;
		#endregion
		#region properties
		public virtual Mem_Base map {
			get { return _map; }
			set {
				if(_map != value) {
					OnBeforeMapChanged(blankEventArgs);
					_map = value;
					OnMapChanged(blankEventArgs);
				}
			}
		}
		#endregion
		#region On....
		public virtual void OnMapChanged(EventArgs e) {
			if(MapChanged != null) MapChanged(this, e);
		}
		public virtual void OnBeforeMapChanged(EventArgs e) {
			if(BeforeMapChanged != null) BeforeMapChanged(this, e);
		}
		#endregion
		#region function: HardReset, SoftReset
		public override void HardReset() {
			base.HardReset();
			_start = _defStart;
			_len = _defLen;
			_offset = _defOffset;
			_data = new byte[_defData.Length];
			Array.Copy(_defData, _data, _defData.Length);
			SoftReset();
		}
		public override void SoftReset() {
			base.SoftReset();
			if(_map != null) {
				Int32 iI, iL;
				byte[] bank = _map._bank;

				
				for(iI = _start, iL = (_start + _len); iI < iL; iI++)
					bank[iI] = _blankByte;

				for(iI = 0, iL = _data.Length; iI < iL; iI++)
					bank[(_start + iI) + _offset] = _data[iI];
			}
		}
		#endregion
	}
}
