#region header
/* User: Erin
 * Date: 2/20/2013
 * Time: 2:10 AM
 */
#endregion
#region notes
//NB: For JMP. Not implemented yet.
//An original 6502 has does not correctly fetch the target address if
//the indirect vector falls on a page boundary (e.g. $xxFF where xx is
//and value from $00 to $FF). In this case fetches the LSB from $xxFF
//as expected but takes the MSB from $xx00. This is fixed in some later
//chips like the 65SC02 so for compatibility always ensure the indirect
//vector is not at the end of the page.
#endregion
#region defs
#undef DBG
#undef DBG_SHOW_COMMAND
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
		public override Int32 DoCycle_Main() {
			#region vars
			Int32 cc = -1, i = 0;
			UInt16 us;
			byte oc=_programRam[PC];
			byte bt, bt2 = 0x0, bt3 = 0x0, bt4, lsb;
			#endregion

			PPC = PC++;

			switch(oc) {
				#region math
				#region ADC: add with carry - 69, 65, 75, 6D, 7D, 79, 61, 71
				#region 0x69: I - bytes=2, cycles=2
				case 0x69:
					Instruction_ADC(_programRam[PC++], "0x69");
					cc = 2;
					break;
				#endregion
				#region 0x65: Z - bytes=2, cycles=3
				case 0x65:
					Instruction_ADC(_workingRam[_programRam[PC++]], "0x65");
					cc = 3;
					break;
				#endregion
				#region 0x75: ZX - bytes=2, cycles=4
				case 0x75:
					unchecked { bt = (byte)(_programRam[PC++] + X); }
					Instruction_ADC(_workingRam[bt], "0x75");
					cc = 4;
					break;
				#endregion
				#region 0x6D: A - bytes=3, cycles=4
				case 0x6D:
					lsb = _programRam[PC++];
					bt = _workingRam[_programRam[PC++] << 8 | lsb];
					Instruction_ADC(bt, "0x6D");
					cc = 4;
					break;
				#endregion
				#region 0x7D: AX - bytes=3, cycles=4(+1 if page crossed)
				case 0x7D:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + X); }
					bt = _workingRam[us];
					if(lsb + X > 0xff)
						bt2 = 1;
					else bt2 = 0;
					Instruction_ADC(bt, "0x7D");
					cc = 4 + bt2;
					break;
				#endregion
				#region 0x79: AY - bytes=3, cycles=4(+1 if page crossed)
				case 0x79:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + Y); }
					bt = _workingRam[us];
					if(lsb + Y > 0xff)
						bt2 = 1;
					else bt2 = 0;
					Instruction_ADC(bt, "0x79");
					cc = 4 + bt2;
					break;
				#endregion
				#region 0x61: IX - bytes=2, cycles=6
				case 0x61:
					bt = _programRam[PC++];
					bt = (byte)((bt + X) & 0xFF);
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					bt2 = _workingRam[us];
					Instruction_ADC(bt2, "0x61");
					cc = 6;
					break;
				#endregion
				#region 0x71: IY - bytes=2, cycles=5(+1 if page crossed)
				case 0x71:
					bt = _programRam[PC++];
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					us += Y;
					bt2 = _workingRam[us];
					Instruction_ADC(bt2, "0x71");
					cc = 5;
					if(us > 255) cc++;
					break;
				#endregion
				#endregion
				#region BIT: Bit test - 24, 2C
				#region 0x24: Z - bytes=2, cycles=3
				case 0x24:
					bt = _programRam[PC++];
					SetStatus(statusFlag_negative, (bt & 0x80) != 0);
					SetStatus(statusFlag_overflow, (bt & 0x40) != 0);
					SetStatus(statusFlag_zero, (bt & A) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("BIT:0x24:Z"
						,	"Bit testing " + ByteString(bt)
						+	" - negative=" + GetStatus(statusFlag_negative)
						+	", overflow=" + GetStatus(statusFlag_overflow)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0x2C: A - bytes=3, cycles=4
				case 0x2C:
					lsb = _programRam[PC++];
					bt = _workingRam[_programRam[PC++] << 8 | lsb];
					SetStatus(statusFlag_negative, (bt & 0x80) != 0);
					SetStatus(statusFlag_overflow, (bt & 0x40) != 0);
					SetStatus(statusFlag_zero, (bt & A) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("BIT:0x2C:A"
						,	"Bit testing " + ByteString(bt)
						+	" - negative=" + GetStatus(statusFlag_negative)
						+	", overflow=" + GetStatus(statusFlag_overflow)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#endregion
				#region CMP: compare A with mem - C9, C5, D5, CD, DD, D9, C1, D1
								//- sets CF, ZF and CF
				#region 0xC9: I - bytes=2, cycles=2
				case 0xC9:
					bt = _programRam[PC++];
					unchecked { bt2 = (byte)(A - bt); }
					SetStatus(statusFlag_carry, (A >= bt));
					SetStatus(statusFlag_negative, (bt2 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt2 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CMP:0xC9:I"
						,	"Comparing " + AString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0xC5: Z - bytes=2, cycles=3
				case 0xC5:
					bt = _workingRam[_programRam[PC++]];
					unchecked { bt2 = (byte)(A - bt); }
					SetStatus(statusFlag_carry, (A >= bt));
					SetStatus(statusFlag_negative, (bt2 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt2 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CMP:0xC5:Z"
						,	"Comparing " + AString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0xD5: ZX - bytes=2, cycles=4
				case 0xD5:
					unchecked { bt = (byte)(_programRam[PC++] + X); }
					bt = _workingRam[bt];
					unchecked { bt2 = (byte)(A - bt); }
					SetStatus(statusFlag_carry, (A >= bt));
					SetStatus(statusFlag_negative, (bt2 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt2 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CMP:0xD5:ZX"
						,	"Comparing " + AString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0xCD: A - bytes=3, cycles=4
				case 0xCD:
					lsb = _programRam[PC++];
					bt = _workingRam[_programRam[PC++] << 8 | lsb];
					unchecked { bt2 = (byte)(A - bt); }
					SetStatus(statusFlag_carry, (A >= bt));
					SetStatus(statusFlag_negative, (bt2 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt2 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CMP:0xCD:A"
						,	"Comparing " + AString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0xDD: AX - bytes=3, cycles=4(+1 if page crossed)
				case 0xDD:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + X); }
					bt = _workingRam[us];
					if(lsb + X > 0xff)
						bt2 = 1;
					else bt2 = 0;
					unchecked { bt3 = (byte)(A - bt); }
					SetStatus(statusFlag_carry, (A >= bt));
					SetStatus(statusFlag_negative, (bt3 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt3 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CMP:0xDD:AX"
						,	"Comparing " + AString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#region 0xD9: AY - bytes=3, cycles=4(+1 if page crossed)
				case 0xD9:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + Y); }
					bt = _workingRam[us];
					if(lsb + Y > 0xff)
						bt2 = 1;
					else bt2 = 0;
					unchecked { bt3 = (byte)(A - bt); }
					SetStatus(statusFlag_carry, (A >= bt));
					SetStatus(statusFlag_negative, (bt3 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt3 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CMP:0xD9:AY"
						,	"Comparing " + AString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#region 0xC1: IX - bytes=2, cycles=6
				case 0xC1:
					bt = _programRam[PC++];
					bt = (byte)((bt + X) & 0xFF);
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					bt = _workingRam[us];
					unchecked { bt3 = (byte)(A - bt); }
					SetStatus(statusFlag_carry, (A >= bt));
					SetStatus(statusFlag_negative, (bt3 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt3 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CMP:0xC1:IX"
						,	"Comparing " + AString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0xD1: IY - bytes=2, cycles=5(+1 if page crossed)
				case 0xD1:
					bt = _programRam[PC++];
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					us += Y;
					bt = _workingRam[us];
					unchecked { bt3 = (byte)(A - bt); }
					SetStatus(statusFlag_carry, (A >= bt));
					SetStatus(statusFlag_negative, (bt3 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt3 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CMP:0xD1:IY"
						,	"Comparing " + AString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 5;
					if(us > 255) cc++;
					break;
				#endregion
				#endregion
				#region CPX: compare X with mem - E0, E4, EC
								//- sets CF, ZF and CF
				#region 0xE0: I - bytes=2, cycles=2
				case 0xE0:
					bt = _programRam[PC++];
					unchecked { bt2 = (byte)(X - bt); }
					SetStatus(statusFlag_carry, (X >= bt));
					SetStatus(statusFlag_negative, (bt2 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt2 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CPX:0xE0:I"
						,	"Comparing " + XString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0xE4: Z - bytes=2, cycles=3
				case 0xE4:
					bt = _workingRam[_programRam[PC++]];
					unchecked { bt2 = (byte)(X - bt); }
					SetStatus(statusFlag_carry, (X >= bt));
					SetStatus(statusFlag_negative, (bt2 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt2 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CPX:0xE4:Z"
						,	"Comparing " + XString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0xEC: A - bytes=3, cycles=4
				case 0xEC:
					lsb = _programRam[PC++];
					bt = _workingRam[_programRam[PC++] << 8 | lsb];
					unchecked { bt2 = (byte)(X - bt); }
					SetStatus(statusFlag_carry, (X >= bt));
					SetStatus(statusFlag_negative, (bt2 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt2 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CPX:0xEC:A"
						,	"Comparing " + XString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#endregion
				#region CPY: compare X with mem - C0, C4, CC
								//- sets CF, ZF and CF
				#region 0xC0: I - bytes=2, cycles=2
				case 0xC0:
					bt = _programRam[PC++];
					unchecked { bt2 = (byte)(Y - bt); }
					SetStatus(statusFlag_carry, (Y >= bt));
					SetStatus(statusFlag_negative, (bt2 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt2 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CPY:0xC0:I"
						,	"Comparing " + YString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0xC4: Z - bytes=2, cycles=3
				case 0xC4:
					bt = _workingRam[_programRam[PC++]];
					unchecked { bt2 = (byte)(Y - bt); }
					SetStatus(statusFlag_carry, (Y >= bt));
					SetStatus(statusFlag_negative, (bt2 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt2 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CPY:0xC4:Z"
						,	"Comparing " + YString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0xCC: A - bytes=3, cycles=4
				case 0xCC:
					lsb = _programRam[PC++];
					bt = _workingRam[_programRam[PC++] << 8 | lsb];
					unchecked { bt2 = (byte)(Y - bt); }
					SetStatus(statusFlag_carry, (Y >= bt));
					SetStatus(statusFlag_negative, (bt2 & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt2 & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CPY:0xCC:A"
						,	"Comparing " + YString() + " with " + ByteString(bt)
						+	" - carry=" + GetStatus(statusFlag_carry)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#endregion
				#region DEC: Decrement Memory(-1) - C6, D6, CE, DE
				#region 0xC6: Z - bytes=2, cycles=5
				case 0xC6:
					unchecked {
						us = (ushort)_programRam[PC++];
						bt = (byte)((_workingRam[us] - 1));
					}
					SetStatus(statusFlag_negative, (bt & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt & 0xff) == 0);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("DEC:0xC6:Z"
						,	"Decrement byte at "
						+	UShortString(us)
						+	" - val=" + ByteString(bt)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 5;
					break;
				#endregion
				#region 0xD6: ZX - bytes=2, cycles=6
				case 0xD6:
					unchecked {
						bt2 = (byte)(_programRam[PC++] + X);
						bt = (byte)(_workingRam[bt2] - 1);
					}
					SetStatus(statusFlag_negative, (bt & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt & 0xff) == 0);
					_workingRam[bt2] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("DEC:0xD6:ZX"
						,	"Decrement byte at " +	UShortString(bt2)
						+	" - val=" + ByteString(bt)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0xCE: A - bytes=3, cycles=6
				case 0xCE:
					us = ((UInt16)(_programRam[PC + 1] << 8 | _programRam[PC]));
					PC += 2;
					unchecked { bt = (byte)(_workingRam[us] - 1); }
					SetStatus(statusFlag_negative, (bt & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt & 0xff) == 0);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("DEC:0xCE:A"
						,	"Decrement byte at " +	UShortString(us)
						+	" - val=" + ByteString(bt)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0xDE: AX - bytes=3, cycles=7
				case 0xDE:
					lsb = _programRam[PC++];
					unchecked {
						us = (UInt16)((_programRam[PC++] << 8 | lsb) + X);
						bt = (byte)(_workingRam[us] - 1);
					}
					SetStatus(statusFlag_negative, (bt & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt & 0xff) == 0);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("DEC:0xDE:AX"
						,	"Decrement byte at " +	UShortString(us)
						+	" - val=" + ByteString(bt)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 7;
					break;
				#endregion
				#endregion
				#region DEX:0xCA:Im Decrement X(-1) - bytes=1, cycles=2
				case 0xCA:
					unchecked { X--; }
					SetStatus(statusFlag_negative, (X & 0x80) != 0);
					SetStatus(statusFlag_zero, (X & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("DEX:0xCA:Im"
						,	"Decremented " + XString()
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region DEY:0x88:Im Decrement Y(-1) - bytes=1, cycles=2
				case 0x88:
					unchecked { Y--; }
					SetStatus(statusFlag_negative, (Y & 0x80) != 0);
					SetStatus(statusFlag_zero, (Y & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("DEY:0x88:Im"
						,	"Decremented " + YString()
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region INC: Increment Memory(+1) - E6, F6, EE, FE
				#region 0xE6: Z - bytes=2, cycles=5
				case 0xE6:
					unchecked {
						us = (ushort)_programRam[PC++];
						bt = (byte)((_workingRam[us] + 1));
					}
					SetStatus(statusFlag_negative, (bt & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt & 0xff) == 0);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("INC:0xE6:Z"
						,	"Increment byte at "
						+	UShortString(us)
						+	" - val=" + ByteString(bt)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 5;
					break;
				#endregion
				#region 0xF6: ZX - bytes=2, cycles=6
				case 0xF6:
					unchecked {
						bt2 = (byte)(_programRam[PC++] + X);
						bt = (byte)(_workingRam[bt2] + 1);
					}
					SetStatus(statusFlag_negative, (bt & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt & 0xff) == 0);
					_workingRam[bt2] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("INC:0xF6:ZX"
						,	"Increment byte at " +	UShortString(bt2)
						+	" - val=" + ByteString(bt)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0xEE: A - bytes=3, cycles=6
				case 0xEE:
					us = ((UInt16)(_programRam[PC + 1] << 8 | _programRam[PC]));
					PC += 2;
					unchecked { bt = (byte)(_workingRam[us] + 1); }
					SetStatus(statusFlag_negative, (bt & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt & 0xff) == 0);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("INC:0xEE:A"
						,	"Increment byte at " +	UShortString(us)
						+	" - val=" + ByteString(bt)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0xFE: AX - bytes=3, cycles=7
				case 0xFE:
					lsb = _programRam[PC++];
					unchecked {
						us = (UInt16)((_programRam[PC++] << 8 | lsb) + X);
						bt = (byte)(_workingRam[us] + 1);
					}
					SetStatus(statusFlag_negative, (bt & 0x80) != 0);
					SetStatus(statusFlag_zero, (bt & 0xff) == 0);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("INC:0xFE:AX"
						,	"Increment byte at " +	UShortString(us)
						+	" - val=" + ByteString(bt)
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 7;
					break;
				#endregion
				#endregion
				#region INX:0xE8:Im Increment X(+1) - bytes=1, cycles=2
				case 0xE8:
					unchecked { X++; }
					SetStatus(statusFlag_negative, (X & 0x80) != 0);
					SetStatus(statusFlag_zero, (X & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("INX:0xE8:Im"
						,	"Incremented " + XString()
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region INY:0xC8:Im Increment Y(+1) - bytes=1, cycles=2
				case 0xC8:
					unchecked { Y++; }
					SetStatus(statusFlag_negative, (Y & 0x80) != 0);
					SetStatus(statusFlag_zero, (Y & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("INY:0xC8:Im"
						,	"Incremented " + YString()
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region SBC: subtract with carry - E9, E5, F5, ED, FD, F9, E1, F1
				#region 0xE9:I - bytes=2, cycles=2
				case 0xE9:
					bt = _programRam[PC++];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					bt2 = (byte)(GetStatus(statusFlag_carry)? 1 : 0);
					i = A - bt - bt2;
					SetStatus(statusFlag_overflow
									, ((A^bt) & (A^(i & 0xff)) & 0x80) != 0);
					if(GetStatus(statusFlag_decimalMode))
						A = Instruction_SBC_dec(bt, "po");
					else { 
						unchecked { A = (byte)i; }
						SetStatus(statusFlag_carry, (i & 0x0100) != 0);
						SetStatus(statusFlag_negative, (i & 0x80) != 0);
						SetStatus(statusFlag_zero, (i & 0xff) == 0);
					}
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("SBC:0xE9:I"
						,	"subtracted " + ByteString(bt)
						+	" from " + AString(bt3)
						+	" - val=" + AString() + ", " + StatString()
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0xE5:Z - bytes=2, cycles=3
				case 0xE5:
					bt = _workingRam[_programRam[PC++]];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					bt2 = (byte)(GetStatus(statusFlag_carry)? 1 : 0);
					i = A - bt - bt2;
					SetStatus(statusFlag_overflow
									, ((A^bt) & (A^(i & 0xff)) & 0x80) != 0);
					if(GetStatus(statusFlag_decimalMode))
						A = Instruction_SBC_dec(bt, "po");
					else {
						unchecked { A = (byte)i; }
						SetStatus(statusFlag_carry, (i & 0x0100) != 0);
						SetStatus(statusFlag_negative, (i & 0x80) != 0);
						SetStatus(statusFlag_zero, (i & 0xff) == 0);
					}
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("SBC:0xE5:Z"
						,	"subtracted " + ByteString(bt)
						+	" from " + AString(bt3)
						+	" - val=" + AString() + ", " + StatString()
						);
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0xF5:ZX - bytes=2, cycles=4
				case 0xF5:
					unchecked { bt = (byte)(_programRam[PC++] + X); }
					bt = _workingRam[bt];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					bt2 = (byte)(GetStatus(statusFlag_carry)? 1 : 0);
					i = A - bt - bt2;
					SetStatus(statusFlag_overflow
									, ((A^bt) & (A^(i & 0xff)) & 0x80) != 0);
					if(GetStatus(statusFlag_decimalMode))
						A = Instruction_SBC_dec(bt, "po");
					else {
						unchecked { A = (byte)i; }
						SetStatus(statusFlag_carry, (i & 0x0100) != 0);
						SetStatus(statusFlag_negative, (i & 0x80) != 0);
						SetStatus(statusFlag_zero, (i & 0xff) == 0);
					}
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("SBC:0xF5:ZX"
						,	"subtracted " + ByteString(bt)
						+	" from " + AString(bt3)
						+	" - val=" + AString() + ", " + StatString()
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0xED: A - bytes=3, cycles=4
				case 0xED:
					lsb = _programRam[PC++];
					bt = _workingRam[_programRam[PC++] << 8 | lsb];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					bt2 = (byte)(GetStatus(statusFlag_carry)? 1 : 0);
					i = A - bt - bt2;
					SetStatus(statusFlag_overflow
									, ((A^bt) & (A^(i & 0xff)) & 0x80) != 0);
					if(GetStatus(statusFlag_decimalMode))
						A = Instruction_SBC_dec(bt, "po");
					else {
						unchecked { A = (byte)i; }
						SetStatus(statusFlag_carry, (i & 0x0100) != 0);
						SetStatus(statusFlag_negative, (i & 0x80) != 0);
						SetStatus(statusFlag_zero, (i & 0xff) == 0);
					}
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("SBC:0xED:A"
						,	"subtracted " + ByteString(bt)
						+	" from " + AString(bt3)
						+	" - val=" + AString() + ", " + StatString()
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0xFD: AX - bytes=3, cycles=4(+1 if page crossed)
				case 0xFD:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + X); }
					bt = _workingRam[us];
					if(lsb + X > 0xff)
						bt2 = 1;
					else bt2 = 0;
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					bt4 = (byte)(GetStatus(statusFlag_carry)? 1 : 0);
					i = A - bt - bt4;
					SetStatus(statusFlag_overflow
									, ((A^bt) & (A^(i & 0xff)) & 0x80) != 0);
					if(GetStatus(statusFlag_decimalMode))
						A = Instruction_SBC_dec(bt, "po");
					else {
						unchecked { A = (byte)i; }
						SetStatus(statusFlag_carry, (i & 0x0100) != 0);
						SetStatus(statusFlag_negative, (i & 0x80) != 0);
						SetStatus(statusFlag_zero, (i & 0xff) == 0);
					}
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("SBC:0xFD:AX"
						,	"subtracted " + ByteString(bt)
						+	" from " + AString(bt3)
						+	" - val=" + AString() + ", " + StatString()
						);
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#region 0xF9: AY - bytes=3, cycles=4(+1 if page crossed)
				case 0xF9:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + Y); }
					bt = _workingRam[us];
					if(lsb + Y > 0xff)
						bt2 = 1;
					else bt2 = 0;
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					bt4 = (byte)(GetStatus(statusFlag_carry)? 1 : 0);
					i = A - bt - bt4;
					SetStatus(statusFlag_overflow
									, ((A^bt) & (A^(i & 0xff)) & 0x80) != 0);
					if(GetStatus(statusFlag_decimalMode))
						A = Instruction_SBC_dec(bt, "po");
					else {
						unchecked { A = (byte)i; }
						SetStatus(statusFlag_carry, (i & 0x0100) != 0);
						SetStatus(statusFlag_negative, (i & 0x80) != 0);
						SetStatus(statusFlag_zero, (i & 0xff) == 0);
					}
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("SBC:0xF9:AY"
						,	"subtracted " + ByteString(bt)
						+	" from " + AString(bt3)
						+	" - val=" + AString() + ", " + StatString()
						);
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#region 0xE1: IX - bytes=2, cycles=6
				case 0xE1:
					bt = _programRam[PC++];
					bt = (byte)((bt + X) & 0xFF);
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					bt4 = (byte)(GetStatus(statusFlag_carry)? 1 : 0);
					i = A - bt - bt4;
					SetStatus(statusFlag_overflow
									, ((A^bt) & (A^(i & 0xff)) & 0x80) != 0);
					if(GetStatus(statusFlag_decimalMode))
						A = Instruction_SBC_dec(bt, "po");
					else {
						unchecked { A = (byte)i; }
						SetStatus(statusFlag_carry, (i & 0x0100) != 0);
						SetStatus(statusFlag_negative, (i & 0x80) != 0);
						SetStatus(statusFlag_zero, (i & 0xff) == 0);
					}
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("SBC:0xE1:IX"
						,	"subtracted " + ByteString(bt)
						+	" from " + AString(bt3)
						+	" - val=" + AString() + ", " + StatString()
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0xF1: IY - bytes=2, cycles=5(+1 if page crossed)
				case 0xF1:
					bt = _programRam[PC++];
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					us += Y;
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					bt4 = (byte)(GetStatus(statusFlag_carry)? 1 : 0);
					i = A - bt - bt4;
					SetStatus(statusFlag_overflow
									, ((A^bt) & (A^(i & 0xff)) & 0x80) != 0);
					if(GetStatus(statusFlag_decimalMode))
						A = Instruction_SBC_dec(bt, "po");
					else {
						unchecked { A = (byte)i; }
						SetStatus(statusFlag_carry, (i & 0x0100) != 0);
						SetStatus(statusFlag_negative, (i & 0x80) != 0);
						SetStatus(statusFlag_zero, (i & 0xff) == 0);
					}
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("SBC:0xF1:IY"
						,	"subtracted " + ByteString(bt)
						+	" from " + AString(bt3)
						+	" - val=" + AString() + ", " + StatString()
						);
					#endregion
					cc = 5;
					if(us > 255) cc++;
					break;
				#endregion
				#endregion
				#endregion
				#region branch
				#region BCC:0x90:R Branch if carry clear- bytes=2, cycles=2(
								//- +1 if branch, +2 if to new pg.)
				case 0x90:
					cc = 2;
					bt = _programRam[PC++];
					if(!GetStatus(statusFlag_carry)) {
						unchecked { us = (ushort)(PC + bt); }
						if((PC & 0xFF00) != (us & 0xFF0))
							cc += 2;
						else
							cc++;
						PC = us;
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BCC:0x90:R"
							,	"carry=0 - branching +" + bt
							+	"[" + UShortString(PC) + "]"
						);
						#endregion
					}
					else {
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BCC:0x90:R", "carry=1 - no branch");
						#endregion
					}
				break;
				#endregion
				#region BCS:0xB0:R Branch if carry set - bytes=2, cycles=2(
								//- +1 if branch, +2 if to new pg.)
				case 0xB0:
					cc = 2;
					bt = _programRam[PC++];
					if(GetStatus(statusFlag_carry)) {
						unchecked { us = (ushort)(PC + bt); }
						if((PC & 0xFF00) != (us & 0xFF0))
							cc += 2;
						else
							cc++;
						PC = us;
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BCS:0xB0:R"
							,	"carry=1 - branching +" + bt
							+	"[" + UShortString(PC) + "]"
						);
						#endregion
					}
					else {
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BCS:0xB0:R", "carry=0 - no branch");
						#endregion
					}
				break;
				#endregion
				#region BEQ:0xF0:R Branch if equal(zero set) - bytes=2, cycles=2(
								//- +1 if branch, +2 if to new pg.)
				case 0xF0:
					cc = 2;
					bt = _programRam[PC++];
					if(GetStatus(statusFlag_zero)) {
						unchecked { us = (ushort)(PC + bt); }
						if((PC & 0xFF00) != (us & 0xFF0))
							cc += 2;
						else
							cc++;
						PC = us;
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BEQ:0xF0:R"
							,	"zero=1 - branching +" + bt + " " + PCString()
							);
						#endregion
					}
					else {
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BCS:0xF0:R", "zero=0 - no branch");
						#endregion
					}
				break;
				#endregion
				#region BMI:0x30:R Branch if minus(negative set) - bytes=2, cycles=2(
								//- +1 if branch, +2 if to new pg.)
				case 0x30:
					cc = 2;
					bt = _programRam[PC++];
					if(GetStatus(statusFlag_negative)) {
						unchecked { us = (ushort)(PC + bt); }
						if((PC & 0xFF00) != (us & 0xFF0))
							cc += 2;
						else
							cc++;
						PC = us;
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BMI:0x30:R"
							,	"negative=1 - branching +" + bt + " " + PCString()
							);
						#endregion
					}
					else {
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BMI:0x30:R", "negative=0 - no branch");
						#endregion
					}
				break;
				#endregion
				#region BNE:0xD0:R Branch if not equal(zero clear) - bytes=2, cycles=2(
								//- +1 if branch, +2 if to new pg.)
				case 0xD0:
					cc = 2;
					bt = _programRam[PC++];
					if(!GetStatus(statusFlag_zero)) {
						unchecked { us = (ushort)(PC + bt); }
						if((PC & 0xFF00) != (us & 0xFF0))
							cc += 2;
						else
							cc++;
						PC = us;
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BNE:0xD0:R"
							,	"zero=0 - branching +" + bt + " " + PCString()
							);
						#endregion
					}
					else {
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BNE:0xD0:R", "zero=1 - no branch");
						#endregion
					}
				break;
				#endregion
				#region BPL:0x10:R Branch if positive(negative clear) - bytes=2, cycles=2(
								//- +1 if branch, +2 if to new pg.)
				case 0x10:
					cc = 2;
					bt = _programRam[PC++];
					if(!GetStatus(statusFlag_negative)) {
						unchecked { us = (ushort)(PC + bt); }
						if((PC & 0xFF00) != (us & 0xFF0))
							cc += 2;
						else
							cc++;
						PC = us;
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BPL:0x10:R"
							,	"negative=0 - branching +" + bt + " " + PCString()
							);
						#endregion
					}
					else {
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BPL:0x10:R", "negative=1 - no branch");
						#endregion
					}
				break;
				#endregion
				#region BVC:0x50:R Branch if overflow clear- bytes=2, cycles=2(
								//- +1 if branch, +2 if to new pg.)
				case 0x50:
					cc = 2;
					bt = _programRam[PC++];
					if(!GetStatus(statusFlag_overflow)) {
						unchecked { us = (ushort)(PC + bt); }
						if((PC & 0xFF00) != (us & 0xFF0))
							cc += 2;
						else
							cc++;
						PC = us;
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BVC:0x50:R"
							,	"overflow=0 - branching +" + bt
							+	"[" + UShortString(PC) + "]"
						);
						#endregion
					}
					else {
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BVC:0x50:R", "overflow=1 - no branch");
						#endregion
					}
				break;
				#endregion
				#region BVS:0x70:R Branch if overflow set- bytes=2, cycles=2(
								//- +1 if branch, +2 if to new pg.)
				case 0x70:
					cc = 2;
					bt = _programRam[PC++];
					if(GetStatus(statusFlag_overflow)) {
						unchecked { us = (ushort)(PC + bt); }
						if((PC & 0xFF00) != (us & 0xFF0))
							cc += 2;
						else
							cc++;
						PC = us;
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BVS:0x70:R"
							,	"overflow=1 - branching +" + bt
							+	"[" + UShortString(PC) + "]"
						);
						#endregion
					}
					else {
						#region DBG
						if(DBG_SHOW_COMMAND)
							WriteDoCycle("BVS:0x70:R", "overflow=0 - no branch");
						#endregion
					}
				break;
				#endregion
				#endregion
				#region clear / set
				#region CLC: Clear Carry Flag - 18
				case 0x18: //- Im - bytes=1, cycles=2
					SetStatus(statusFlag_carry, false);
					cc = 2;
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CLC:0xD8:Im", "Clear Carry Flag");
					break;
				#endregion
				#region CLD: Clear Decimal Mode - D8
				case 0xD8: //- Im - bytes=1, cycles=2
					SetStatus(statusFlag_decimalMode, false);
					cc = 2;
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CLD:0xD8:Im", "Clear Decimal Flag");
					break;
				#endregion
				#region CLI: Clear Interrupt Disable - 58
				case 0x58: //- Im - bytes=1, cycles=2
					SetStatus(statusFlag_interruptDisable, false);
					cc = 2;
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CLI:0x58:Im", "Clear Interrupt Disable");
					break;
				#endregion
				#region CLV: Clear Overflow Flag - B8
				case 0xB8: //- Im - bytes=1, cycles=2
					SetStatus(statusFlag_overflow, false);
					cc = 2;
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("CLV:0xB8:Im", "Clear Overflow Flag");
					break;
				#endregion

				#region SEC: Set Carry Flag - 38
				case 0x38: //- Im - bytes=1, cycles=2
					SetStatus(statusFlag_carry, true);
					cc = 2;
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("SEC:0x38:Im", "Set Carry Flag");
					break;
				#endregion
				#region SED: Set Decimal Mode - F8
				case 0xF8: //- Im - bytes=1, cycles=2
					SetStatus(statusFlag_decimalMode, true);
					cc = 2;
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("SED:0xF8:Im", "Set Decimal Mode");
					break;
				#endregion
				#region SEI: Set Interrupt Disable - 78
				case 0x78: //- Im - bytes=1, cycles=2
					SetStatus(statusFlag_interruptDisable, true);
					cc = 2;
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("SEI:0x78:Im", "Set Interrupt Disable");
					break;
				#endregion
				#endregion
				#region load / store
				#region LDA: Load Accumulator - A9, A5, B5, AD, BD, B9, A1, B1
				#region 0xA9: I - bytes=2, cycles=2
				case 0xA9:
					A = _programRam[PC++];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDA:0xA9:I", AString());
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0xA5: Z - bytes=2, cycles=3
				case 0xA5:
					A = _workingRam[_programRam[PC++]];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDA:0xA5:Z", AString());
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0xB5: ZX - bytes=2, cycles=4
				case 0xB5:
					unchecked { bt = (byte)(_programRam[PC++] + X); }
					A = _workingRam[bt];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDA:0xB5:ZX", AString());
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0xAD: A - bytes=3, cycles=4
				case 0xAD:
					lsb = _programRam[PC++];
					A = _workingRam[_programRam[PC++] << 8 | lsb];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDA:0xAD:A", AString());
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0xBD: AX - bytes=3, cycles=4(+1 if page crossed)
				case 0xBD:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + X); }
					bt = _workingRam[us];
					if(lsb + X > 0xff)
						bt2 = 1;
					else bt2 = 0;
					A = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDA:0x8D:AX", AString());
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#region 0xB9: AY - bytes=3, cycles=4(+1 if page crossed)
				case 0xB9:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + Y); }
					//bt = _workingRam[us];
					if(lsb + Y > 0xff)
						bt2 = 1;
					else bt2 = 0;
					//A = bt;
					A = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDA:0xB9:AY", AString());
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#region 0xA1: IX - bytes=2, cycles=6
				case 0xA1:
					bt = _programRam[PC++];
					bt = (byte)((bt + X) & 0xFF);
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					A = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDA:0xA1:IX", AString());
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0xB1: IY - bytes=2, cycles=5(+1 if page crossed)
				case 0xB1:
					bt = _programRam[PC++];
					us = (ushort)((_workingRam[bt + 1] << 8 | _workingRam[bt]) + Y);
					A = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDA:0xB1:IY", AString());
					#endregion
					cc = 5;
					if(us > 255) cc++;
					break;
				#endregion
				#endregion
				#region LDX: Load X - A2, A6, B6, AE, BE
				#region 0xA2: I - bytes=2, cycles=2
				case 0xA2:
					X = _programRam[PC++];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDX:0xA2:I", XString());
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0xA6: Z - bytes=2, cycles=3
				case 0xA6:
					X = _workingRam[_programRam[PC++]];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDX:0xA6:Z", XString());
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0xB6: ZY - bytes=2, cycles=4
				case 0xB6:
					unchecked { bt = (byte)(_programRam[PC++] + Y); }
					X = _workingRam[bt];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDX:0xB6:ZY", XString());
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0xAE: A - bytes=3, cycles=4
				case 0xAE:
					lsb = _programRam[PC++];
					X = _workingRam[_programRam[PC++] << 8 | lsb];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDX:0xAE:A", XString());
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0xBE: AY - bytes=3, cycles=4(+1 if page crossed)
				case 0xBE:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + Y); }
					if(lsb + Y > 0xff)
						bt2 = 1;
					else bt2 = 0;
					X = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDX:0xAE:AY", XString());
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#endregion
				#region LDY: Load Y - A0, A4, B4, AC, BC
				#region 0xA0: I - bytes=2, cycles=2
				case 0xA0:
					Y = _programRam[PC++];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDY:0xA0:I", YString());
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0xA4: Z - bytes=2, cycles=3
				case 0xA4:
					Y = _workingRam[_programRam[PC++]];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDY:0xA4:Z", YString());
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0xB4: ZX - bytes=2, cycles=4
				case 0xB4:
					unchecked { bt = (byte)(_programRam[PC++] + X); }
					Y = _workingRam[bt];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDY:0xB4:ZX", YString());
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0xAC: A - bytes=3, cycles=4
				case 0xAC:
					lsb = _programRam[PC++];
					Y = _workingRam[_programRam[PC++] << 8 | lsb];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDY:0xAC:A", YString());
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0xBC: AX - bytes=3, cycles=4(+1 if page crossed)
				case 0xBC:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + X); }
					if(lsb + X > 0xff)
						bt2 = 1;
					else bt2 = 0;
					Y = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LDY:0xBC:AX", YString());
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#endregion
				
				#region STA: Store Accumulator - 85, 95, 8D, 9D, 99, 81, 91
				#region 0x85: Z - bytes=2, cycles=3
				case 0x85:
					_workingRam[_programRam[PC++]] = A;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STA:0x85:Z"
						,	"Store " + AString()
						+	" at " + ByteString(_programRam[PC-1])
						);
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0x95: ZX - bytes=2, cycles=4
				case 0x95:
					unchecked { bt = (byte)(_programRam[PC++] + X); }
					_workingRam[bt] = A;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STA:0x95:ZX"
						,	"Store " + AString()
						+	" at " + ByteString(bt)
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0x8D: A - bytes=3, cycles=4
				case 0x8D:
					lsb = _programRam[PC++];
					_workingRam[_programRam[PC++] << 8 | lsb] = A;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STA:0x8D:A"
						,	"Store " + AString()
						+	" at " + UShortString((ushort)(_programRam[PC-1]<<8 | lsb))
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0x9D: AX - bytes=3, cycles=5
				case 0x9D:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + X); }
					_workingRam[us] = A;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STA:0x9D:AX"
						,	"Store " + AString()
						+	" at " + UShortString(us)
						);
					#endregion
					cc = 5;
					break;
				#endregion
				#region 0x99: AY - bytes=3, cycles=5
				case 0x99:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + Y); }
					_workingRam[us] = A;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STA:0x99:AY"
						,	"Store " + AString()
						+	" at " + UShortString(us)
						);
					#endregion
					cc = 5;
					break;
				#endregion
				#region 0x81: IX - bytes=2, cycles=6
				case 0x81:
					bt = _programRam[PC++];
					bt = (byte)((bt + X) & 0xFF);
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					_workingRam[us] = A;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STA:0x81:IX"
						,	"Store " + AString()
						+	" at " + UShortString(us)
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0x91: IY - bytes=2, cycles=6
				case 0x91:
					bt = _programRam[PC++];
					us = (ushort)((_workingRam[bt + 1] << 8 | _workingRam[bt]) + Y);
					_workingRam[us] = A;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STA:0x91:IY"
						,	"Store " + AString()
						+	" at " + UShortString(us)
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#endregion
				#region STX: Store X - 86, 96, 8E
				#region 0x86: Z - bytes=2, cycles=3
				case 0x86:
					_workingRam[_programRam[PC++]] = X;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STX:0x86:Z"
						,	"Store " + XString()
						+	" at " + ByteString(_programRam[PC-1])
						);
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0x96: ZY - bytes=2, cycles=4
				case 0x96:
					unchecked { bt = (byte)(_programRam[PC++] + Y); }
					_workingRam[bt] = X;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STX:0x96:ZY"
						,	"Store " + XString()
						+	" at " + ByteString(bt)
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0x8E: A - bytes=3, cycles=4
				case 0x8E:
					lsb = _programRam[PC++];
					_workingRam[_programRam[PC++] << 8 | lsb] = X;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STX:0x8E:A"
						,	"Store " + XString()
						+	" at " + UShortString((ushort)(_programRam[PC-1]<<8 | lsb))
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#endregion
				#region STY: Store Y - 84, 94, 8C
				#region 0x84: Z - bytes=2, cycles=3
				case 0x84:
					_workingRam[_programRam[PC++]] = Y;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STY:0x84:Z"
						,	"Store " + YString()
						+	" at " + ByteString(_programRam[PC-1])
						);
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0x94: ZX - bytes=2, cycles=4
				case 0x94:
					unchecked { bt = (byte)(_programRam[PC++] + X); }
					_workingRam[bt] = Y;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STY:0x94:ZX"
						,	"Store " + YString()
						+	" at " + ByteString(bt)
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0x8C: A - bytes=3, cycles=4
				case 0x8C:
					lsb = _programRam[PC++];
					_workingRam[_programRam[PC++] << 8 | lsb] = Y;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("STY:0x8C:A"
						,	"Store " + YString()
						+	" at " + UShortString((ushort)(_programRam[PC-1]<<8 | lsb))
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#endregion
				#endregion
				#region logical: AND, ASL, EOR, LSR, ORA, ROL, ROR
				#region AND: logical AND on A with val - 29, 25, 35, 2D, 3D, 39, 21, 31
				#region 0x29: I - bytes=2, cycles=2
				case 0x29:
					Instruction_AND(_programRam[PC++], "0x69");
					cc = 2;
					break;
				#endregion
				#region 0x25: Z - bytes=2, cycles=3
				case 0x25:
					Instruction_AND(_workingRam[_programRam[PC++]], "0x25");
					cc = 3;
					break;
				#endregion
				#region 0x35: ZX - bytes=2, cycles=4
				case 0x35:
					unchecked { bt = (byte)(_programRam[PC++] + X); }
					Instruction_AND(_workingRam[bt], "0x35");
					cc = 4;
					break;
				#endregion
				#region 0x2D: A - bytes=3, cycles=4
				case 0x2D:
					lsb = _programRam[PC++];
					bt = _workingRam[_programRam[PC++] << 8 | lsb];
					Instruction_AND(bt, "0x2D");
					cc = 4;
					break;
				#endregion
				#region 0x3D: AX - bytes=3, cycles=4(+1 if page crossed)
				case 0x3D:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + X); }
					bt = _workingRam[us];
					if(lsb + X > 0xff)
						bt2 = 1;
					else bt2 = 0;
					Instruction_AND(bt, "0x3D");
					cc = 4 + bt2;
					break;
				#endregion
				#region 0x39: AY - bytes=3, cycles=4(+1 if page crossed)
				case 0x39:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + Y); }
					bt = _workingRam[us];
					if(lsb + Y > 0xff)
						bt2 = 1;
					else bt2 = 0;
					Instruction_AND(bt, "0x39");
					cc = 4 + bt2;
					break;
				#endregion
				#region 0x21: IX - bytes=2, cycles=6
				case 0x21:
					bt = _programRam[PC++];
					bt = (byte)((bt + X) & 0xFF);
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					bt2 = _workingRam[us];
					Instruction_AND(bt2, "0x21");
					cc = 6;
					break;
				#endregion
				#region 0x31: IY - bytes=2, cycles=5(+1 if page crossed)
				case 0x31:
					bt = _programRam[PC++];
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					us += Y;
					bt2 = _workingRam[us];
					Instruction_AND(bt2, "0x31");
					cc = 5;
					if(us > 255) cc++;
					break;
				#endregion
				#endregion
				#region ASL: Shift A or mem left 1 - 0A, 06, 16, 0E, 1E
							//- set carry to bit7 before.
				#region 0x0A: Acc - bytes=1, cycles=2
				case 0x0A:
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = A;
					#endregion
					SetStatus(statusFlag_carry, A >> 7);
					A <<= 1;
					if(A == 0)
						SetStatus(statusFlag_zero, true);
					else if((A >> 7) == 1)
						SetStatus(statusFlag_negative, true);
					
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ASL:0x0A:Acc"
						,	"Shift " + AString(bt2) + " left by 1 bit"
						+	" - val=" + ByteString(A)
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0x06: Z - bytes=2, cycles=5
				case 0x06:
					unchecked { us = (ushort)_programRam[PC++]; }
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					SetStatus(statusFlag_carry, bt >> 7);
					bt <<= 1;
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt >> 7) == 1)
						SetStatus(statusFlag_negative, true);
					
					_workingRam[us] = bt;
					
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ASL:0x06:Z"
						,	"Shift " + ByteString(bt2) 
						+	"[mem#" + UShortString(us) + "]"
						+	" left by 1 bit" + " - val=" + ByteString(bt)
						);
					#endregion
					cc = 5;
					break;
				#endregion
				#region 0x16: ZX - bytes=2, cycles=6
				case 0x16:
					unchecked { us = (ushort)(_programRam[PC++] + X); }
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					SetStatus(statusFlag_carry, bt >> 7);
					bt <<= 1;
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt >> 7) == 1)
						SetStatus(statusFlag_negative, true);
					
					_workingRam[us] = bt;
					
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ASL:0x16:ZX"
						,	"Shift " + ByteString(bt2) 
						+	"[mem#" + UShortString(us) + "]"
						+	" left by 1 bit" + " - val=" + ByteString(bt)
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0x0E: A - bytes=3, cycles=6
				case 0x0E:
					lsb = _programRam[PC++];
					us = (ushort)(_programRam[PC++] << 8 | lsb);
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					SetStatus(statusFlag_carry, bt >> 7);
					bt <<= 1;
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt >> 7) == 1)
						SetStatus(statusFlag_negative, true);
					
					_workingRam[us] = bt;
					
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ASL:0x0E:A"
						,	"Shift " + ByteString(bt2) 
						+	"[mem#" + UShortString(us) + "]"
						+	" left by 1 bit" + " - val=" + ByteString(bt)
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0x1E: AX - bytes=3, cycles=7
				case 0x1E:
					lsb = _programRam[PC++];
					us = (ushort)((_programRam[PC++] << 8 | lsb) + X);
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					SetStatus(statusFlag_carry, bt >> 7);
					bt <<= 1;
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt >> 7) == 1)
						SetStatus(statusFlag_negative, true);
					
					_workingRam[us] = bt;
					
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ASL:0x1E:AX"
						,	"Shift " + ByteString(bt2) 
						+	"[mem#" + UShortString(us) + "]"
						+	" left by 1 bit" + " - val=" + ByteString(bt)
						);
					#endregion
					cc = 7;
					break;
				#endregion
				#endregion
				#region EOR: logical XOR on A with val - 49, 45, 55, 4D, 5D, 59, 41, 51
				#region 0x49: I - bytes=2, cycles=2
				case 0x49:
					bt = _programRam[PC++];
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A ^= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("EOR:0x49:I"
						,	" - EX-ORing " + ByteString(bt) + " to " + AString(bt3)
						+	" - val=" + ByteString(A)
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0x45: Z - bytes=2, cycles=3
				case 0x45:
					bt = _workingRam[_programRam[PC++]];
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A ^= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("EOR:0x45:Z"
						,	" - EX-ORing " + ByteString(bt) + " to " + AString(bt3)
						+	" - val=" + ByteString(A)
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0x55: ZX - bytes=2, cycles=4
				case 0x55:
					unchecked { bt = _workingRam[(byte)(_programRam[PC++] + X)]; }
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A ^= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("EOR:0x55:ZX"
						,	" - EX-ORing " + ByteString(bt) + " to " + AString(bt3)
						+	" - val=" + ByteString(A)
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0x4D: A - bytes=3, cycles=4
				case 0x4D:
					bt = _workingRam[_programRam[PC + 1] << 8 | _programRam[PC]];
		         PC += 2;
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A ^= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("EOR:0x4D:A"
						,	" - EX-ORing " + ByteString(bt) + " to " + AString(bt3)
						+	" - val=" + ByteString(A)
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0x5D: AX - bytes=3, cycles=4(+1 if page crossed)
				case 0x5D:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + X); }
					bt = _workingRam[us];
					if(lsb + X > 0xff)
						bt2 = 1;
					else bt2 = 0;
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A ^= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("EOR:0x5D:AX"
						,	" - EX-ORing " + ByteString(bt) + " to " + AString(bt3)
						+	" - val=" + ByteString(A)
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#region 0x59: AY - bytes=3, cycles=4(+1 if page crossed)
				case 0x59:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + Y); }
					bt = _workingRam[us];
					if(lsb + Y > 0xff)
						bt2 = 1;
					else bt2 = 0;
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A ^= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("EOR:0x59:AY"
						,	" - EX-ORing " + ByteString(bt) + " to " + AString(bt3)
						+	" - val=" + ByteString(A)
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#region 0x41: IX - bytes=2, cycles=6
				case 0x41:
					bt = (byte)((_programRam[PC++] + X) & 0xFF);
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					bt = _workingRam[us];
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A ^= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("EOR:0x41:IX"
						,	" - EX-ORing " + ByteString(bt) + " to " + AString(bt3)
						+	" - val=" + ByteString(A)
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0x51: IY - bytes=2, cycles=5(+1 if page crossed)
				case 0x51:
					bt = _programRam[PC++];
					unchecked {
						us = (ushort)((_workingRam[bt+1] << 8 | _workingRam[bt]) + Y);
					}
					bt = _workingRam[us];
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A ^= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("EOR:0x51:IY"
						,	" - EX-ORing " + ByteString(bt) + " to " + AString(bt3)
						+	" - val=" + ByteString(A)
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 5;
					if(us > 255) cc++;
					break;
				#endregion
				#endregion
				#region LSR: Logical Shift A or mem right 1 - 4A, 46, 56, 4E, 5E
							//- set carry to bit0 before.
				#region 0x4A: Acc - bytes=1, cycles=2
				case 0x4A:
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = A;
					#endregion
					SetStatus(statusFlag_carry, A & 0x01);
					A >>= 1;
					if(A == 0)
						SetStatus(statusFlag_zero, true);
					else if((A >> 7) == 1)
						SetStatus(statusFlag_negative, true);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LSR:0x4A:Acc"
						,	"Shift " + AString(bt2) + " right by 1 bit"
						+	" - val=" + ByteString(A)
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0x46: Z - bytes=2, cycles=5
				case 0x46:
					bt = _workingRam[_programRam[PC++]];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					SetStatus(statusFlag_carry, bt & 0x01);
					bt >>= 1;
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt >> 7) == 1)
						SetStatus(statusFlag_negative, true);
					
					_workingRam[_programRam[PC-1]] = bt;
					
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LSR:0x46:Z"
						,	"Shift " + ByteString(bt2) 
						+	"[mem#" + ByteString(_programRam[PC-1]) + "]"
						+	" right by 1 bit" + " - val=" + ByteString(bt)
						);
					#endregion
					cc = 5;
					break;
				#endregion
				#region 0x56: ZX - bytes=2, cycles=6
				case 0x56:
					unchecked { bt = _workingRam[_programRam[PC++] + X]; }
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					SetStatus(statusFlag_carry, bt & 0x01);
					bt >>= 1;
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt >> 7) == 1)
						SetStatus(statusFlag_negative, true);
					
					_workingRam[_programRam[PC-1] + X] = bt;
					
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LSR:0x56:ZX"
						,	"Shift " + ByteString(bt2) 
						+	"[mem#" + UShortString((ushort)(_programRam[PC-1]+X)) + "]"
						+	" right by 1 bit" + " - val=" + ByteString(bt)
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0x4E: A - bytes=3, cycles=6
				case 0x4E:
					lsb = _programRam[PC++];
					us = (ushort)(_programRam[PC++] << 8 | lsb);
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					SetStatus(statusFlag_carry, bt & 0x01);
					bt >>= 1;
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt >> 7) == 1)
						SetStatus(statusFlag_negative, true);
					
					_workingRam[us] = bt;
					
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LSR:0x4E:A"
						,	"Shift " + ByteString(bt2) 
						+	"[mem#" + UShortString(us) + "]"
						+	" right by 1 bit" + " - val=" + ByteString(bt)
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0x5E: AX - bytes=3, cycles=7
				case 0x5E:
					lsb = _programRam[PC++];
					us = (ushort)((_programRam[PC++] << 8 | lsb) + X);
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					SetStatus(statusFlag_carry, bt & 0x01);
					bt >>= 1;
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt >> 7) == 1)
						SetStatus(statusFlag_negative, true);
					
					_workingRam[us] = bt;
					
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("LSR:0x5E:AX"
						,	"Shift " + ByteString(bt2) 
						+	"[mem#" + UShortString(us) + "]"
						+	" right by 1 bit" + " - val=" + ByteString(bt)
						);
					#endregion
					cc = 7;
					break;
				#endregion
				#endregion
				#region ORA: logical XOR on A with val - 09, 05, 15, 0D, 1D, 19, 01, 11
				#region 0x09:I - bytes=2, cycles=2
				case 0x09:
					bt = _programRam[PC++];
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A |= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("ORA:0x09:I"
						,	" - ORing " + AString(bt3) + " with " + ByteString(bt)
						+	" - val=" + AString()
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0x05:Z - bytes=2, cycles=3
				case 0x05:
					bt = _workingRam[_programRam[PC++]];
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A |= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("ORA:0x05:Z"
						,	" - ORing " + AString(bt3) + " with " + ByteString(bt)
						+	" - val=" + AString()
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0x15:ZX - bytes=2, cycles=4
				case 0x15:
					unchecked { bt = _workingRam[(byte)(_programRam[PC++] + X)]; }
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A |= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("ORA:0x15:ZX"
						,	" - ORing " + AString(bt3) + " with " + ByteString(bt)
						+	" - val=" + AString()
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0x0D: A - bytes=3, cycles=4
				case 0x0D:
					bt = _workingRam[_programRam[PC + 1] << 8 | _programRam[PC]];
		         PC += 2;
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A |= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("ORA:0x0D:A"
						,	" - ORing " + AString(bt3) + " with " + ByteString(bt)
						+	" - val=" + AString()
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 4;
					break;
				#endregion
				#region 0x1D: AX - bytes=3, cycles=4(+1 if page crossed)
				case 0x1D:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + X); }
					bt = _workingRam[us];
					if(lsb + X > 0xff)
						bt2 = 1;
					else bt2 = 0;
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A |= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("ORA:0x1D:AX"
						,	" - ORing " + AString(bt3) + " with " + ByteString(bt)
						+	" - val=" + AString()
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#region 0x19: AY - bytes=3, cycles=4(+1 if page crossed)
				case 0x19:
					lsb = _programRam[PC++];
					unchecked { us = (UInt16)((_programRam[PC++] << 8 | lsb) + Y); }
					bt = _workingRam[us];
					if(lsb + Y > 0xff)
						bt2 = 1;
					else bt2 = 0;
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A |= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("ORA:0x19:AY"
						,	" - ORing " + AString(bt3) + " with " + ByteString(bt)
						+	" - val=" + AString()
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 4 + bt2;
					break;
				#endregion
				#region 0x01: IX - bytes=2, cycles=6
				case 0x01:
					bt = (byte)((_programRam[PC++] + X) & 0xFF);
					us = (ushort)(_workingRam[bt + 1] << 8 | _workingRam[bt]);
					bt = _workingRam[us];
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A |= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("ORA:0x01:IX"
						,	" - ORing " + AString(bt3) + " with " + ByteString(bt)
						+	" - val=" + AString()
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0x11: IY - bytes=2, cycles=5(+1 if page crossed)
				case 0x11:
					bt = _programRam[PC++];
					unchecked {
						us = (ushort)((_workingRam[bt+1] << 8 | _workingRam[bt]) + Y);
					}
					bt = _workingRam[us];
		         #region DBG
					if(DBG_SHOW_COMMAND)
						bt3 = A;
					#endregion
					unchecked { A |= bt; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND) {
						WriteDoCycle("ORA:0x11:ZY"
						,	" - ORing " + AString(bt3) + " with " + ByteString(bt)
						+	" - val=" + AString()
						+	" - negative = " + GetStatus(statusFlag_negative)
						+	" - zero = " + GetStatus(statusFlag_zero)
						);
					}
					#endregion
					cc = 5;
					if(us > 255) cc++;
					break;
				#endregion
				#endregion
				#region ROL: Shift A or mem left 1 - 2A, 26, 36, 2E, 3E
							//- set carry to old bit7. set new bit0 to old carry.
				#region 0x2A: Acc - bytes=1, cycles=2
				case 0x2A:
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = A;
					#endregion
					bt3 = (byte)(A & 0x80);
					A <<= 1;
					A = (byte)(GetStatus(statusFlag_carry) ? A | 0x01 : A & ~0x01);
					SetStatus(statusFlag_carry, bt3);
					if(A == 0)
						SetStatus(statusFlag_zero, true);
					else if((A & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ROL:0x2A:Acc"
						,	"Rotated " + AString(bt2) + " left by 1 bit"
						+	" - val=" + ByteString(A) + ", " + StatString()
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0x26: Z - bytes=2, cycles=5
				case 0x26:
					unchecked { us = (ushort)_programRam[PC++]; }
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					bt3 = (byte)(bt & 0x80);
					bt <<= 1;
					bt = (byte)(GetStatus(statusFlag_carry)? bt | 0x01 : bt & ~0x01);
					SetStatus(statusFlag_carry, bt3 != 0);
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ROL:0x26:Z"
						,	"Rotated " + "val" + ByteString(bt2)
						+	"at ram" + UShortString(us)
						+ " left by 1 bit"
						+	" - val=" + ByteString(A) + ", " + StatString()
						);
					#endregion
					cc = 5;
					break;
				#endregion
				#region 0x36: ZX - bytes=2, cycles=6
				case 0x36:
					unchecked { bt = _workingRam[_programRam[PC++] + X]; }
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					bt3 = (byte)(bt & 0x80);
					bt <<= 1;
					bt = (byte)(GetStatus(statusFlag_carry)? bt | 0x01 : bt & ~0x01);
					SetStatus(statusFlag_carry, bt3 != 0);
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					_workingRam[_programRam[PC-1] + X] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ROL:0x36:ZX"
						,	"Rotated " + "val" + ByteString(bt2)
						+	"at ram" + UShortString((ushort)(_programRam[PC-1] + X))
						+ " left by 1 bit"
						+	" - val=" + ByteString(A) + ", " + StatString()
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0x2E: A - bytes=3, cycles=6
				case 0x2E:
					lsb = _programRam[PC++];
					us = (ushort)(_programRam[PC++] << 8 | lsb);
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					bt3 = (byte)(bt & 0x80);
					bt <<= 1;
					bt = (byte)(GetStatus(statusFlag_carry)? bt | 0x01 : bt & ~0x01);
					SetStatus(statusFlag_carry, bt3 != 0);
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ROL:0x2E:A"
						,	"Rotated " + "val" + ByteString(bt2)
						+	"at ram" + UShortString(us)
						+ " left by 1 bit"
						+	" - val=" + ByteString(A) + ", " + StatString()
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0x3E: AX - bytes=3, cycles=7
				case 0x3E:
					lsb = _programRam[PC++];
					us = (ushort)((_programRam[PC++] << 8 | lsb) + X);
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					bt3 = (byte)(bt & 0x80);
					bt <<= 1;
					bt = (byte)(GetStatus(statusFlag_carry)? bt | 0x01 : bt & ~0x01);
					SetStatus(statusFlag_carry, bt3 != 0);
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ROL:0x3E:AX"
						,	"Rotated " + "val" + ByteString(bt2)
						+	"at ram" + UShortString(us)
						+ " left by 1 bit"
						+	" - val=" + ByteString(A) + ", " + StatString()
						);
					#endregion
					cc = 7;
					break;
				#endregion
				#endregion
				#region ROR: Shift A or mem right 1 - 6A, 66, 76, 6E, 7E
							//- set carry to old bit7. set new bit0 to old carry.
				#region 0x6A: Acc - bytes=1, cycles=2
				case 0x6A:
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = A;
					#endregion
					bt3 = (byte)(A & 0x01);
					A >>= 1;
					A = (byte)(GetStatus(statusFlag_carry) ? A | 0x80 : A & ~0x80);
					SetStatus(statusFlag_carry, bt3);
					if(A == 0)
						SetStatus(statusFlag_zero, true);
					else if((A & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ROR:0x6A:Acc"
						,	"Rotated " + AString(bt2) + " right by 1 bit"
						+	" - val=" + ByteString(A) + ", " + StatString()
						);
					#endregion
					cc = 2;
					break;
				#endregion
				#region 0x66: Z - bytes=2, cycles=5
				case 0x66:
					unchecked { us = (ushort)_programRam[PC++]; }
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					bt3 = (byte)(bt & 0x01);
					bt >>= 1;
					bt = (byte)(GetStatus(statusFlag_carry)? bt | 0x80 : bt & ~0x80);
					SetStatus(statusFlag_carry, bt3 != 0);
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ROR:0x66:Z"
						,	"Rotated " + ByteString(bt2)
						+	"at ram" + UShortString(us)
						+ " right by 1 bit"
						+	" - val=" + ByteString(bt) + ", " + StatString()
						);
					#endregion
					cc = 5;
					break;
				#endregion
				#region 0x76: ZX - bytes=2, cycles=6
				case 0x76:
					unchecked { bt = _workingRam[_programRam[PC++] + X]; }
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					bt3 = (byte)(bt & 0x01);
					bt >>= 1;
					bt = (byte)(GetStatus(statusFlag_carry)? bt | 0x80 : bt & ~0x80);
					SetStatus(statusFlag_carry, bt3 != 0);
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					_workingRam[_programRam[PC-1] + X] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ROR:0x76:ZX"
						,	"Rotated " + "val" + ByteString(bt2)
						+	"at ram" + UShortString((ushort)(_programRam[PC-1] + X))
						+ " right by 1 bit"
						+	" - val=" + ByteString(bt) + ", " + StatString()
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0x6E: A - bytes=3, cycles=6
				case 0x6E:
					lsb = _programRam[PC++];
					us = (ushort)(_programRam[PC++] << 8 | lsb);
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					bt3 = (byte)(bt & 0x01);
					bt >>= 1;
					bt = (byte)(GetStatus(statusFlag_carry)? bt | 0x80 : bt & ~0x80);
					SetStatus(statusFlag_carry, bt3 != 0);
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ROR:0x6E:A"
						,	"Rotated " + "val" + ByteString(bt2)
						+	"at ram" + UShortString(us)
						+ " right by 1 bit"
						+	" - val=" + ByteString(bt) + ", " + StatString()
						);
					#endregion
					cc = 6;
					break;
				#endregion
				#region 0x7E: AX - bytes=3, cycles=7
				case 0x7E:
					lsb = _programRam[PC++];
					us = (ushort)((_programRam[PC++] << 8 | lsb) + X);
					bt = _workingRam[us];
					#region DBG
					if(DBG_SHOW_COMMAND)
						bt2 = bt;
					#endregion
					bt3 = (byte)(bt & 0x01);
					bt >>= 1;
					bt = (byte)(GetStatus(statusFlag_carry)? bt | 0x80 : bt & ~0x80);
					SetStatus(statusFlag_carry, bt3 != 0);
					if(bt == 0)
						SetStatus(statusFlag_zero, true);
					else if((bt & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					_workingRam[us] = bt;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("ROR:0x7E:AX"
						,	"Rotated " + "val" + ByteString(bt2)
						+	"at ram" + UShortString(us)
						+ " right by 1 bit"
						+	" - val=" + ByteString(bt) + ", " + StatString()
						);
					#endregion
					cc = 7;
					break;
				#endregion
				#endregion
				#endregion
				#region misc.
				#region BRK:0x00:Im - bytes=1, cycles=7
				case 0x00:
					SetStatus(statusFlag_breakCommand, true);
					unchecked {
						_workingRam[0x0100 + ++S] = (byte)(PC & 0xFF00);
						_workingRam[0x0100 + ++S] = (byte)(PC & 0x00FF);
						_workingRam[0x0100 + ++S] = P;
					}
					SetStatus(statusFlag_interruptDisable, true);
					PC = (ushort)((_workingRam[vectorIRQ + 1] << 8)
									| _workingRam[vectorIRQ]);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("BRK:0x00:I", PCString());
					#endregion
					cc = 7;
					break;
				#endregion
				#region JMP: Jump to address - 4C, 6C
				#region 0x4C:A - bytes=3, cycles=3
				case 0x4C:
					#region DBG
					PC = (ushort)((_programRam[PC+1] << 8) | _programRam[PC]);
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("JMP:0x4C:A", "Jumping to " + PCString());
					#endregion
					cc = 3;
					break;
				#endregion
				#region 0x6C:In - bytes=3, cycles=5
				case 0x6C:
					us = (ushort)((_programRam[PC+1] << 8) | _programRam[PC]);
					PC = (ushort)((_programRam[us+1] << 8) | _programRam[us]);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("JMP:0x6C:In", "Jumping to " + PCString());
					#endregion
					cc = 5;
					break;
				#endregion
				#endregion
				#region JSR:0x20:A - Jump to sub - bytes=3, cycles=6
								//- pushes PC(before jump) and P
				case 0x20:
					//mos6502/7 quirk - I add 1 to PC instead of 2. RTS pushes PC-1: iRTS compensates
					us = (ushort)((_programRam[PC+1] << 8) | _programRam[PC++]);
					unchecked {
						_workingRam[0x0100 + ++S] = (byte)(PC & 0xFF00);
						_workingRam[0x0100 + ++S] = (byte)(PC & 0x00FF);
					}
					PC = (ushort)((_programRam[us+1] << 8) | _programRam[us]);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("JSR:0x20:A", "Jumping to sub - " + PCString());
					#endregion
					cc = 6;
					break;
				#endregion
				#region NOP:0xEA:Im - No Operation - bytes=1, cycles=2
				case 0xEA:
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("NOP:0xEA:Im", "doing nothing");
					#endregion
					cc = 2;
					break;
				#endregion
				#region PHA:0x48:Im - Push Accumulator - bytes=1, cycles=3
				case 0x48:
					unchecked { _workingRam[01 << 8 | ++S] = A; }
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("PHA:0x48:Im"
						, "pushed " + AString() + " - " + SString()
						);
					#endregion
					cc = 3;
					break;
				#endregion
				#region PHP:0x08:Im - Push Processor Status - bytes=1, cycles=3
				case 0x08:
					unchecked { _workingRam[01 << 8 | ++S] = P; }
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("PHP:0x08:Im"
						, "pushed " + PString() + " - " + SString()
						);
					#endregion
					cc = 3;
					break;
				#endregion
				#region PLA:0x68:Im - Pull A - bytes=1, cycles=4
				case 0x68:
					unchecked { A = _workingRam[01 << 8 | S--]; }
					SetStatus(statusFlag_negative, (A & 0x80) != 0);
					SetStatus(statusFlag_zero, (A & 0xff) == 0);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("PLA:0x68:Im"
						,	"pulled " + AString() + "from stack - " + SString()
						+	", negative=" + GetStatus(statusFlag_negative)
						+	", zero=" + GetStatus(statusFlag_zero)
						);
					#endregion
					cc = 4;
					break;
				#endregion
				#region PLP:0x28:Im - Pull Processor Status - bytes=1, cycles=4
				case 0x28:
					unchecked { P = _workingRam[01 << 8 | S--]; }
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("PLP:0x28:Im"
						,	"pulled " + PString() + "from stack - " + SString()
						+	StatString()
					);
					#endregion
					cc = 4;
					break;
				#endregion
				#region RTI:0x40:Im - Return from Interrupt - bytes=1, cycles=6
				case 0x40:
					unchecked {
						_workingRam[(0x01 << 8) | S--] = P;
						PC = (UInt16)(
							(_workingRam[(0x01 << 8) | (byte)(S - 1)] << 8)
						|	_workingRam[(0x01 << 8) | S]
						);
					}
					S -= 2;
					//SetStatus(statusFlag_breakCommand, true);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("RTI:0x40:Im", PCString() +" - "+ StatString());
					#endregion
					cc = 6;
					break;
				#endregion
				#region RTS:0x60:Im - Return from Sub - bytes=1, cycles=6
				case 0x60:
					unchecked {
						//mos6502/7 quirk - Add 1 to PC to compensate for JSR(pushes PC-1)
						PC = (UInt16)((
							(_workingRam[(0x01 << 8) | (byte)(S - 1)] << 8)
						|	_workingRam[(0x01 << 8) | S])
						+	1
						);
					}
					S -= 2;
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("RTS:0x60:Im", PCString() +" - "+ StatString());
					#endregion
					cc = 6;
					break;
				#endregion
				#region TAX:0xAA:Im - Copy A to X - bytes=1, cycles=2
								// - Set FZ if X==0, Set FN if bit7 of X is set
				case 0xAA:
					X = A;
					if(X == 0)
						SetStatus(statusFlag_zero, true);
					else if((X & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("TAX:0xAA:Im"
						,	"Transfering " + AString() + " to X"
	             	+	", " + StatString()
	             );
					#endregion
					cc = 2;
					break;
				#endregion
				#region TAY:0xA8:Im - Copy A to Y - bytes=1, cycles=2
								// - Set FZ if X==0, Set FN if bit7 of X is set
				case 0xA8:
					Y = A;
					if(Y == 0)
						SetStatus(statusFlag_zero, true);
					else if((Y & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("TAY:0xA8:Im"
						,	"Transfering " + AString() + " to Y"
	             	+	", " + StatString()
	             );
					#endregion
					cc = 2;
					break;
				#endregion
				#region TSX:0xBA:Im - Copy S to X - bytes=1, cycles=2
								// - Set FZ if X==0, Set FN if bit7 of X is set
				case 0xBA:
					X = S;
					if(X == 0)
						SetStatus(statusFlag_zero, true);
					else if((X & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("TSX:0xBA:Im"
						,	"Transfering " + SString() + " to X"
	             	+	", " + StatString()
	             );
					#endregion
					cc = 2;
					break;
				#endregion
				#region TXA:0x8A:Im - Copy X to A - bytes=1, cycles=2
								// - Set FZ if X==0, Set FN if bit7 of X is set
				case 0x8A:
					A = X;
					if(A == 0)
						SetStatus(statusFlag_zero, true);
					else if((A & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("TXA:0x8A:Im"
						,	"Transfering " + XString() + " to A"
	             	+	", " + StatString()
	             );
					#endregion
					cc = 2;
					break;
				#endregion
				#region TXS:0x9A:Im - Copy X to S - bytes=1, cycles=2
								// - Set FZ if X==0, Set FN if bit7 of X is set
				case 0x9A:
					S = X;
					if(S == 0)
						SetStatus(statusFlag_zero, true);
					else if((S & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("TXS:0x9A:Im"
						,	"Transfering " + XString() + " to S"
	             	+	", " + StatString()
	             );
					#endregion
					cc = 2;
					break;
				#endregion
				#region TYA:0x98:Im - Copy Y to A - bytes=1, cycles=2
								// - Set FZ if X==0, Set FN if bit7 of X is set
				case 0x98:
					A = Y;
					if(A == 0)
						SetStatus(statusFlag_zero, true);
					else if((A & 0x80) != 0)
						SetStatus(statusFlag_negative, true);
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("TYA:0x98:Im"
						,	"Transfering " + YString() + " to A"
	             	+	", " + StatString()
	             );
					#endregion
					cc = 2;
					break;
				#endregion
				#endregion
				#region default
				default:
					#region DBG
					if(DBG_SHOW_COMMAND)
						WriteDoCycle("Error", "Unknown opcode: 0x" + oc.ToString("X"));
					break;
					#endregion
				#endregion
			}

			if(cc > 0) cycleCount += (UInt64)cc;
			return cc;
		}
	}
}

