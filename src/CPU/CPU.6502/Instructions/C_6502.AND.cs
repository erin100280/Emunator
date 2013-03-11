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
		public virtual void Instruction_AND(byte bt, string opCode) {
			byte btZ;
			btZ = 0x0;
         #region DBG
			if(DBG_SHOW_COMMAND)
				btZ = A;
			#endregion
			unchecked { A &= bt; }
			SetStatus(statusFlag_negative, (A & 0x80) != 0);
			SetStatus(statusFlag_zero, (A & 0xff) == 0);
			#region DBG
			if(DBG_SHOW_COMMAND) {
				WriteDoCycle(
					opCode
				,	"AND:" + opCode
				+	" - ANDing " + ByteString(bt) + " to " + AString(btZ)
				+	" - val = " + ByteString(A)
				+	" - negative = " + GetStatus(statusFlag_negative)
				);
			}
			#endregion
		}
	}
}

