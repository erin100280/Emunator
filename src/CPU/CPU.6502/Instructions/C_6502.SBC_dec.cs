#region header
/* User: Erin
 * Date: 2/20/2013
 * Time: 2:10 AM
 */
#endregion
#region using....
using Emu.Core;
using Emu.Memory;
using Emu.Video;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
#endregion

namespace Emu.CPU {
	public partial class C_6502 {
		public virtual byte Instruction_SBC_dec(byte bt, string opCode) {
			byte bt2, btZ = 0x0;
			Int32 i, i2, i3;
			
			bt2 = (byte)(GetStatus(statusFlag_carry) ? 1 : 0);
         i = A + bt + bt2;

         SetStatus(
				statusFlag_overflow
			,	((~(A ^ bt) & (A ^ (i & 0xff)) & 0x80) != 0)
			);

         #region DBG
			if(DBG_SHOW_COMMAND)
				btZ = A;
			#endregion

			if(GetStatus(statusFlag_decimalMode)) {
				i2 = (A & 0xf) + (bt & 0xf) + bt2;
				i3 = (A >> 4) + (bt >> 4);
				if(i2 > 9) {
					i2 += 6;
					i3++;
				}
				if(i3 > 9) i3 += 6;

				unchecked { A = (byte)((i2 & 0xf) | (i3 << 4)); }
				SetStatus(statusFlag_carry, (i3 & 0x10) != 0);
			}
			else {
				unchecked { A = (byte)i; }
				SetStatus(statusFlag_carry, ((i & 0x100) != 0));
			}

			SetStatus(statusFlag_negative, (i & 0x80) != 0);
			SetStatus(statusFlag_zero, (i & 0xff) == 0);
			#region DBG
			if(DBG_SHOW_COMMAND) {
				WriteDoCycle(
					opCode
				,	"ADC:"+opCode
				+	" - adding " + ByteString(bt) + " to " + AString(btZ)
				+	" with carry(" + bt2 + ")"
				+	" - val = " + ByteString(A)
				+	" - overflow = " + GetStatus(statusFlag_overflow)
				+	" - negative = " + GetStatus(statusFlag_negative)
				+	" - carry = " + GetStatus(statusFlag_carry)
				);
			}
			#endregion
			return bt2;
		}
	}
}

