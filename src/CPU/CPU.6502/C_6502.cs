#region header
/* User: Erin
 * Date: 2/18/2013
 * Time: 6:26 AM
 */
#endregion
#region using....
using Emu.Core;
using Emu.Memory;
using Emu.Video;
using System;
#endregion

namespace Emu.CPU {
	#region meta
	/// <summary>
	/// Description of C_6502.
	/// </summary>
	#endregion
	public partial class C_6502 : C_Base {
		#region vars
		#region status flags
		public byte statusFlag_carry            = (1 << 0);
		public byte statusFlag_zero             = (1 << 1);
		public byte statusFlag_interruptDisable = (1 << 2);
		public byte statusFlag_decimalMode      = (1 << 3);
		public byte statusFlag_breakCommand     = (1 << 4);
		public byte statusFlag_expansion        = (1 << 5);
		public byte statusFlag_overflow         = (1 << 6);
		public byte statusFlag_negative         = (1 << 7);
		#endregion
		#endregion
		#region constructors
		public C_6502(): base("CPU.6502") { InitC_6502(); }
		public C_6502(Mem_Base mem, Vid_Base vid): base("CPU.6502", mem, vid) {
			InitC_6502();
		}
		protected virtual void InitC_6502() {
			HardReset();
			DoCycle = _DoCycle_Debug = _DoCycle_Debug_NoConsole = _DoCycle_Main
							= new DoCycleDelegate(DoCycle_Main);
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#endregion
		#region function: Initialize, HardReset, SoftReset
		public override void Initialize() {
			base.Initialize();
			HardReset();
		}
		public override void HardReset() {
			SoftReset();
			base.HardReset();
		}
		public override void SoftReset() {
			base.SoftReset();
			S = 0xFF; //- clear stack;
			P = 1 << 5; //- reset processor status(bit 5[expansion flag] always set)
			vectorNMI = 0xFFFA;
			vectorRST = 0xFFFC;
			vectorIRQ = 0xFFFE;
		}
		#endregion
		#region function: StatString
		public override string StatString() {
			return "P{"
			+ ((P & 0x80) != 0 ? "N" : "_")
			+ ((P & 0x40) != 0 ? "O" : "_")
			+ ((P & 0x20) != 0 ? "E" : "_")
			+ ((P & 0x10) != 0 ? "B" : "_")
			+ ((P & 0x08) != 0 ? "D" : "_")
			+ ((P & 0x04) != 0 ? "I" : "_")
			+ ((P & 0x02) != 0 ? "Z" : "_")
			+ ((P & 0x01) != 0 ? "C" : "_")
			+	"}";
		}
		#endregion
	}
}



 