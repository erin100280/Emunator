#region header
/* User: Erin
 * Date: 2/20/2013
 * Time: 2:10 AM
 */
#endregion
#region defs
#define DBG
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
	public partial class C_Chip8 : C_Base {
		public override bool DoCycle_Debug_NoConsole() {
			#region vars
			//ebug.WriteLine("C_Chip8.DoCycle()");
			//string str;
			Size res;//, siz;
			byte[] bytes;
			int i, ii, ix, iy, l, len;
			byte[] regs = m_vRegisters;
			//byte bt;
			UInt64 romSA = m_romStartAddress;
			//ushort oc=m_opcode=(ushort)(m_bank[m_romStartAddress+m_counter] << 8
			//			| m_bank[m_romStartAddress+m_counter+1]);
			ushort oc=m_opcode=(ushort)(m_bank[m_counter] << 8
						| m_bank[m_counter+1]);
			ushort x, y, h, pxl, I = m_indexRegister;
			#endregion
			#region DBG
			#if(DBG)
			cycleCount++;
			#endif
			#endregion

			m_lastCounter=m_counter;
			m_counter+=2;
			
			if(m_delayTimer > 0) m_delayTimer--;
			if(m_soundTimer > 0) m_soundTimer--;
			
			switch(oc & 0xF000) {
			#region 0x0...  0x00CN, 0x00E0, 0x00EE, 0x00FB - 0x00FF
			case 0x0000:
   			switch(oc & 0x00F0) {
				#region 0x00CN  SCHIP: Scroll down N lines
				case 0x00C0:
					#region DBG
					#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0x00CN", "Scroll down N[" + (oc & 0x000F) +"] lines");
					#endif
					#endregion
					res = video.resolution;
					bytes = new byte[(res.Width + 1) * (res.Height + 1)];
					i = (res.Width * (oc & 0x000F));
					len = (res.Width * res.Height);
					
					Array.Copy(m_buffer, bytes, len);
					Array.Clear(m_buffer, 0, len);
					Array.Copy(bytes, 0, m_buffer, i, len - i);

					m_video.updated=true;
   				break;
   			#endregion
   			#region 0x00E.  0x00E0, 0x00EE
				case 0x00E0:
	   			switch(oc & 0x000F) {
	   			#region 0x00E0  clear screen
					case 0x0000:
						#region DBG
						#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x00E0", "clear screen");
						#endif
						#endregion
						for(i=0, l=(int)m_video.bufferSize; i<l; i++)
	   					m_buffer[i]=0x0;
	   				m_video.updated=true;
	   				break;
	   			#endregion
	   			#region 0x00EE  return from sub
	   			case 0x000E:
						#region DBG
						#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x00EE"
		            ,	"return from sub to: " + m_stack[m_stackCount-1]
						);
						#endif
						#endregion
	   				if(m_stackCount > 0) {
	   					m_stackCount--;
	   					m_counter = m_stack[m_stackCount];
	   				}
	   				break;
	   			#endregion
					#region default
		   		default:
						#region DBG
						#if (DBG_SHOW_COMMAND)
							WriteDoCycle("0x00E.", "ERROR - opcode = " + oc.ToString("X"));
						#endif
						#endregion
	   				DoRuntimeError("Invalid opcode");
	   				break;
	   			#endregion
	      		}
	      		break;
   			#endregion
   			#region 0x00F.  SCHIP: 0x00FB - 0x00FF
				case 0x00F0:
	   			switch(oc & 0x000F) {
	   			#region 0x00FB  Scroll 4 pixels right
					case 0x000B:
						#region DBG
						#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x00FB", "Scroll 4 pixels right");
						#endif
						#endregion
	   				
						res = video.resolution;
						bytes = new byte[(res.Width + 1) * (res.Height + 1)];
						len = res.Width * res.Height;

						//sg.Box("bytes.Length = " + bytes.Length + "  |  m_buffer.Length = " + m_buffer.Length);
						
						Array.Copy(m_buffer, bytes, len);
		            Array.Clear(m_buffer, 0, len);
		
		            for(iy = 0; iy < res.Height; iy++) {
							for (ix = 4; ix < res.Width; ix++) {
								i = (res.Width * iy) + ix;
								if(i >= len) i = 0;
								ii = (res.Width * iy) + (ix - 4);
								if(ii >= len) ii = 0;
								
								m_buffer[i] = bytes[ii];
							}
		            }
						m_video.updated = true;
		            break;
	   			#endregion
	   			#region 0x00FC  Scroll 4 pixels left
					case 0x000C:
						#region DBG
						#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x00FC", "Scroll 4 pixels left");
						#endif
						#endregion
	   				
						res = video.resolution;
						bytes = new byte[(res.Width + 1) * (res.Height + 1)];
						
						len = (res.Width * res.Height);
		            Array.Copy(m_buffer, bytes, len);
		            Array.Clear(m_buffer, 0, len);
		
		            for(iy = 0; iy < res.Height; iy++) {
							for (ix = 4; ix < res.Width; ix++) {
								i = (res.Width * iy) + ix;
								if(i >= len) i = 0;
								ii = (res.Width * iy) + (ix + 4);
								if(ii >= len) ii = 0;
								
								m_buffer[i] = bytes[ii];
							}
		            }
						m_video.updated = true;
						break;
	   			#endregion
	   			#region 0x00FD  Quit the emulator
					case 0x000D:
						#region DBG
						#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x00FD", "Quit the emulator");
						#endif
						#endregion
						return false;
	   			#endregion
	   				//====//====//====//====//====//====//====//====//
	   			#region 0x00FE  CHIP-8 graphics mode
					case 0x000E:
						#region DBG
						#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x00FE", "CHIP-8 graphics mode");
						#endif
						#endregion
						//video.resolution = new Size(64, 32);
						//m_buffer = video.buffer;
						//m_bufferSize = video.bufferSize;
						//video.ClearBuffer();
						m_video.updated = true;
						break;
	   			#endregion
	   			#region 0x00FF  SCHIP graphics mode
					case 0x000F:
						#region DBG
						#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x00FF", "SCHIP graphics mode");
						#endif
						#endregion
						video.resolution = new Size(128, 64);
						m_buffer = video.buffer;
						m_bufferSize = video.bufferSize;
						video.ClearBuffer();
						m_video.updated = true;
						break;
	   			#endregion
					#region default
		   		default:
						#region DBG
						#if (DBG_SHOW_COMMAND)
							WriteDoCycle("0x00F.", "ERROR - opcode = " + oc.ToString("X"));
						#endif
						#endregion
	   				DoRuntimeError("Invalid opcode");
	   				break;
	   			#endregion
	      		}
	      		break;
   			#endregion
				#region default
	   		default:
					#region DBG
					#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0x0...", "ERROR - opcode = " + oc.ToString("X"));
					#endif
					#endregion
   				DoRuntimeError("Invalid opcode");
   				break;
   			#endregion
   			}
   			break;
			#endregion
			#region 0x1NNN - jump to NNN
      	case 0x1000:
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0x1NNN", "jump to " + (int)(oc & 0x0FFF));
				#endif
				#endregion
				//m_counter=(ushort)((int)romSA + (oc & 0x0FFF));
				//m_counter=(ushort)((int)(oc & 0x0FFF) - (int)m_romStartAddress);
				m_counter=(ushort)(oc & 0x0FFF);
      		break;
			#endregion
			#region 0x2NNN - run sub at NNN
      	case 0x2000:
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0x2NNN", "run sub NNN[" + (oc & 0x0FFF) + "]");
				#endif
				#endregion
      		m_stack[m_stackCount]=m_counter;
      		m_stackCount++;
      		//m_counter=(ushort)((int)romSA + (oc & 0x0FFF));
      		m_counter=(ushort)(oc & 0x0FFF);
      		break;
			#endregion
			#region 0x3XNN - skip next instruction if VX == NN
      	case 0x3000:
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0x3XNN"
				   ,	"skip next instruction if "
				   +	"VX" + regInfoString((oc & 0x0F00) >> 8) + " == NN"
				   +	"[" + (oc & 0x00FF) + "]"
					);
				#endif
				#endregion
				if(regs[(oc & 0x0F00) >> 8] == (oc & 0x00FF))
      		   m_counter+=2;
      		break;
			#endregion
			#region 0x4XNN - skip next instruction if VX != NN
      	case 0x4000:
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0x4XNN"
				   ,	"skip next instruction if "
				   +	"VX" + regInfoString((oc & 0x0F00) >> 8) + " != NN"
				   +	"[" + (oc & 0x00FF) + "]"
					);
				#endif
				#endregion
				if(regs[(oc & 0x0F00) >> 8] != (oc & 0x00FF))
      		   m_counter+=2;
      		break;
			#endregion
			#region 0x5XY0 - skip next instruction if VX == VY
      	case 0x5000:
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0x5XY0"
				   ,	"skip next instruction if "
				   +	"VX" + regInfoString((oc & 0x0F00) >> 8) + " == "
				   +	"VY" + regInfoString((oc & 0x00F0) >> 4) + ""
					);
				#endif
				#endregion
      		if(regs[(oc & 0x0F00) >> 8] == regs[(oc & 0x00F0) >> 4])
      		   m_counter+=2;
      		break;
			#endregion
			#region 0x6XNN - store NN at VX
      	case 0x6000:
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0x6XNN"
					,	"store NN[" + (oc & 0x00FF) + "]"
					+	" at VX" + regInfoString((oc & 0x0F00) >> 8)
					);
				#endif
				#endregion
				regs[(oc & 0x0F00) >> 8]=(byte)(oc & 0x00FF);
      		break;
			#endregion
			#region 0x7XNN - add NN to VX
      	case 0x7000:
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0x7XNN"
					,	"add NN[" + (oc & 0x00FF) + "]"
					+	" to VX" + regInfoString((oc & 0x0F00) >> 8)
					+	" - val=" + (regs[(oc & 0x0F00) >> 8] + (oc & 0x00FF))
					);
				#endif
				#endregion
				unchecked {
					regs[(oc & 0x0F00) >> 8] += (byte)(oc & 0x00FF);
				}
/*				i = regs[(oc & 0x0F00) >> 8] + (oc & 0x00FF);
      		if(i > 255) i -= 256;
      		//if(i > 255) i -= 255;
      		regs[(oc & 0x0F00) >> 8] = (byte)i;
//*/
      		break;
			#endregion
      	#region 0x8... - 0x8XY0 - 0x8XY7, 0x8XYE
      	case 0x8000:
      		switch(oc & 0x000F) {
				#region 0x8XY0 - copy VY to VX
   			case 0x0000:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x8XY0"
						,	"copy VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" to VY" + regInfoString((oc & 0x00F0) >> 4)
						);
					#endif
					#endregion
         		regs[(oc & 0x0F00) >> 8] = regs[(oc & 0x00F0) >> 4];
         		break;
				#endregion
				#region 0x8XY1 - set VX to VX-OR-VY
   			case 0x0001:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x8XY1"
						,	"set VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" to (VX | VY)" + regInfoString((oc & 0x00F0) >> 4)
						+	" - val=" + ((byte)regs[(oc & 0x0F00) >> 8] | (byte)regs[(oc & 0x00F0) >> 4])
						);
					#endif
					#endregion
					regs[(oc & 0x0F00) >> 8] |= regs[(oc & 0x00F0) >> 4];
/*					i = regs[(oc & 0x0F00) >> 8] | regs[(oc & 0x00F0) >> 4];
         		if(i > 255) i -= 255;
         		if(i < 0) i += 256;
         		regs[(oc & 0x0F00) >> 8] = (byte)i;
//*/
         		break;
				#endregion
				#region 0x8XY2 - set VX to VX-AND-VY
   			case 0x0002:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x8XY2"
						,	"set VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" to (VX & VY)" + regInfoString((oc & 0x00F0) >> 4)
						+	" - val=" + ((byte)regs[(oc & 0x0F00) >> 8] & (byte)regs[(oc & 0x00F0) >> 4])
						);
					#endif
					#endregion
					regs[(oc & 0x0F00) >> 8] &= regs[(oc & 0x00F0) >> 4];
/*					i = regs[(oc & 0x0F00) >> 8] & regs[(oc & 0x00F0) >> 4];
         		if(i > 255) i -= 255;
         		if(i < 0) i += 256;
         		regs[(oc & 0x0F00) >> 8] = (byte)i;
//*/
         		break;
				#endregion
				#region 0x8XY3 - set VX to VX-XOR-VY
   			case 0x0003:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x8XY3"
						,	"set VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" to (VX ^ VY)" + regInfoString((oc & 0x00F0) >> 4)
						+	" - val=" + ((byte)regs[(oc & 0x0F00) >> 8] ^ (byte)regs[(oc & 0x00F0) >> 4])
						);
					#endif
					#endregion
					regs[(oc & 0x0F00) >> 8] ^= regs[(oc & 0x00F0) >> 4];
/*					i = regs[(oc & 0x0F00) >> 8] ^ regs[(oc & 0x00F0) >> 4];
         		if(i > 255) i -= 255;
         		if(i < 0) i += 256;
         		regs[(oc & 0x0F00) >> 8] = (byte)i;
//*/
         		break;
				#endregion
								//**
   			#region 0x8XY4 - add VY to VX.
			   					//Set VF to 01 if carry, 00 if no carry
	   		case 0x0004:
					#region DBG
					#if (DBG_SHOW_COMMAND)
         			i = 0;
						if(regs[(oc & 0x00F0) >> 4]
										> (0xFF-regs[(oc & 0x0F00) >> 8]))
							i = 1;

						WriteDoCycle("0x8XY4"
						,	"add VY" + regInfoString((oc & 0x00F0) >> 4)
						+	" to VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" - val=" + ((byte)regs[(oc & 0x0F00) >> 8] + (byte)regs[(oc & 0x00F0) >> 4])
						+	" - carry=" + i
						);
					#endif
					#endregion
					unchecked {
						if(regs[(oc & 0x00F0) >> 4] > (0xFF - regs[(oc & 0x0F00) >> 8]))
							regs[0xF] = 1;
						else
							regs[0xF] = 0;
						regs[(oc & 0x0F00) >> 8] += regs[(oc & 0x00F0) >> 4];
					}
//*/
/*					i = regs[(oc & 0x0F00) >> 8] + regs[(oc & 0x00F0) >> 4];
         		if(i > 255) {
         			regs[0xF] = 1;
         			i -= 255;
         			//i -= 255;
         		}
         		else regs[0xF] = 0;
         		regs[(oc & 0x0F00) >> 8] = (byte)i;
//*/
         		break;
   			#endregion
						//-------------------------------------------
   			#region 0x8XY5 - set VX to (VX - VY).
									//Set VF to 00 if borrow, 01 if no borrow
	   		case 0x0005:
					#region DBG
					#if (DBG_SHOW_COMMAND)
         			i = 1;
						if(regs[(oc & 0x00F0) >> 4]
										> (regs[(oc & 0x0F00) >> 8]))
							i = 0;

						WriteDoCycle("0x8XY5"
						,	"set VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" to VX - VY" + regInfoString((oc & 0x00F0) >> 4)
						+	" - val=" + ((byte)regs[(oc & 0x0F00) >> 8] - (byte)regs[(oc & 0x00F0) >> 4])
						+	" - borrow(0=true)=" + i
						);
					#endif
					#endregion
					unchecked {
						if(regs[(oc & 0x00F0) >> 4] > regs[(oc & 0x0F00) >> 8])
							regs[0xF] = 0;
						else
							regs[0xF] = 1;
						regs[(oc & 0x0F00) >> 8] -= regs[(oc & 0x00F0) >> 4];
					}
//*/
					
/*					i = regs[(oc & 0x0F00) >> 8] - regs[(oc & 0x00F0) >> 4];
         		if(i < 0) {
         			regs[0xF]=0;
         			i *= -1;
         		}
         		else regs[0xF]=1;
         		regs[(oc & 0x0F00) >> 8] = (byte)i;
//*/
         		break;
				#endregion
				#region 0x8XY6 - shift VX right 1. set VF to lsb
         	case 0x0006:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x8XY6"
						,	"shift VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" right by 1. set VF to lsb"
						+	" - lsb=" + (regs[(oc & 0x0F00) >> 8] & 0x1)
						+	" - val=" + (byte)(regs[(oc & 0x0F00) >> 8] >> 1)
						);
					#endif
					#endregion
         		regs[0xF]=(byte)(regs[(oc & 0x0F00) >> 8] & 0x1);
         		regs[(oc & 0x0F00) >> 8] >>=1;
         		break;
				#endregion
				#region 0x8XY7 - set VX to (VY - VX).
									//Set VF to 00 if borrow, 01 if no borrow
   			case 0x0007:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						i = 1;
	         		if(regs[(oc & 0x0F00) >> 8]
										> (regs[(oc & 0x00F0) >> 4]))
							i = 0;
						WriteDoCycle("0x8XY7"
						,	"set VX" + regInfoString((oc & 0x0F00) >> 8)
						+	"to VY" + regInfoString((oc & 0x00F0) >> 4) + "- VX" 
						+	" - val=" + (regs[(oc & 0x00F0) >> 4]
									- regs[(oc & 0x0F00) >> 8])
						+	" - borrow(0=true)=" + i
						);
					#endif
					#endregion
					unchecked {
						if(regs[(oc & 0x0F00) >> 8] > regs[(oc & 0x00F0) >> 4])
							regs[0xF] = 0;
						else
							regs[0xF] = 1;
						regs[(oc & 0x0F00) >> 8] = (byte)(regs[(oc & 0x00F0) >> 4]
						                                  - regs[(oc & 0x0F00) >> 8]);
					}
/*					i = (regs[(oc & 0x00F0) >> 4] - regs[(oc & 0x0F00) >> 8]);
         		if(i < 0) {
         			regs[0xF]=0;
         			i += 256;
         		}
         		else regs[0xF]=1;
         		regs[(oc & 0x0F00) >> 8] = (byte)i;
//*/
         		break;
				#endregion
				#region 0x8XYE - shift VX left 1. set VF to msb
         	case 0x000E:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0x8XYE"
						,	"shift VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" left by 1. set VF to msb" 
						+	" - msb=" + (regs[(oc & 0x0F00) >> 8] >> 7)
						+	" - val=" + (regs[(oc & 0x0F00) >> 8] << 1)
						);
					#endif
					#endregion
					unchecked {
						regs[0xF]=(byte)(regs[(oc & 0x0F00) >> 8] >> 7);
	         		regs[(oc & 0x0F00) >> 8] <<=1;
					}
         		break;
				#endregion
				#region default - ERROR
         	default:
					#region DBG
					#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0x8...", "ERROR - opcode = " + oc.ToString("X"));
					#endif
					#endregion
   				DoRuntimeError(
						"Invalid opcode in 0x8000 at: "+m_lastCounter.ToString()
					+	" / "+(m_lastCounter+1).ToString()
					);
   				break;
				#endregion
      		}
				break;
      	#endregion
			#region 0x9XY0 - skip next instruction if VX != VY
			case 0x9000:
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0x9XY0"
					,	"skip next instruction if"
					+	" VX" + regInfoString((oc & 0x0F00) >> 8)
					+	" != VY" + regInfoString((oc & 0x00F0) >> 4)
					+	" - val=" + (regs[(oc & 0x0F00) >> 8] != regs[(oc & 0x00F0) >> 4])
					);
				#endif
				#endregion
				if(regs[(oc & 0x0F00) >> 8] != regs[(oc & 0x00F0) >> 4])
					m_counter+=2;
				break;
			#endregion
			#region 0xANNN - set I to address NNN
			case 0xA000:
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0xANNN"
					,	"set I[" + m_indexRegister + "]"
					+	" to NNN[" + (oc & 0x0FFF) + "]"
					);
				#endif
				#endregion
				m_indexRegister=(ushort)(oc & 0x0FFF);
				break;
			#endregion
			#region 0xBNNN - jump to address (NNN + V0)
			case 0xB000:
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0xBNNN"
					,	" jump to address NNN[" + (oc & 0x0FFF) + "]"
					+	" + V0" + regInfoString(0)
					+	" - val=" + ((int)romSA + ((oc & 0x0FFF) + regs[0]))
					);
				#endif
				#endregion
				m_counter=(ushort)((oc & 0x0FFF) + regs[0x0]);
				break;
			#endregion
			#region 0xCXYN - set VX to (randomNumber & NN)
			case 0xC000:
				Random r = new Random();
				regs[(oc & 0x0F00) >> 8] = (byte)(r.Next(0, 255)
				                                     % ((oc & 0x00FF) + 1));
				i = (Int32)regs[(oc & 0x0F00) >> 8];
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0xCXYN"
					,	"set VX" + regInfoString((oc & 0x0F00) >> 8)
					+	" to RND +"
					+	" NN[" + (oc & 0x00FF) + "]"
					+	" - val=" + i
					);
				#endif
				#endregion
				
/*
				i = ((rand.Next() % 0xFF) & (oc & 0x00FF));
				regs[(oc & 0x0F00) >> 8] = (byte)i;
//*/
				break;
			#endregion
			#region 0xDXYN - draw sprite at VX,VY with height of N
			               //starting at address I
			case 0xD000:	
				#region DBG
				#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0xDXYN"
					,	"draw sprite at"
					+	" VX" + regInfoString((oc & 0x0F00) >> 8)
					+	", VY" + regInfoString((oc & 0x00F0) >> 4)
					+	"; ht=N[" + (oc & 0x000F) + "]"
					+	"; start addr=I[" + m_indexRegister + "]"
					);
				#endif
				#endregion
				x=regs[(oc & 0x0F00) >>8];
				y=regs[(oc & 0x00F0) >>4];
				h=(ushort)(oc & 0x000F);

				regs[0xF]=0; //collision flag
				for(iy=0; iy<h; iy++) {
					pxl=m_bank[m_indexRegister + iy];
					for(ix=0; ix<8; ix++) {
						if((pxl & (0x80 >> ix)) != 0) {
							if((x + ix + ((y + iy) * 64)) < (64*32)) {
								if(m_buffer[(x + ix + ((y + iy) * 64))] == 1)
									regs[0xF] = 1;//collision occured
								m_buffer[x + ix + ((y + iy) * 64)] ^= 1;
							}
						}
					}
				}
				m_video.updated=true;
				break;
			#endregion
			#region 0xE... - 0xEX9E, 0xEXA1
			case 0xE000:
				switch(oc & 0x00FF) {
				#region 0xEX9E - skip next instruction if key in VX is pressed
				case 0x009E:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xEX9E"
						,	"skip next instruction if"
						+	" key stored in VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" is pressed"
						+	" - val=" + (m_key[regs[(oc & 0x0F00) >> 8]] != 0)
						);
					#endif
					#endregion
					if(m_key[regs[(oc & 0x0F00) >> 8]] != 0)
						m_counter += 2;
					break;
				#endregion
				#region 0xEXA1 - skip next instruction if key in VX is not pressed
				case 0x00A1:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xEXA1"
						,	"skip next instruction if"
						+	" key stored in VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" is not pressed"
						+	" - val=" + (m_key[regs[(oc & 0x0F00) >> 8]] == 0)
						);
					#endif
					#endregion
					if(m_key[regs[(oc & 0x0F00) >> 8]] == 0)
						m_counter += 2;
					break;
				#endregion
				#region default - ERROR
         	default:
					#region DBG
					#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0xE...", "ERROR - opcode = " + oc.ToString("X"));
					#endif
					#endregion
   				DoRuntimeError(
						"Invalid opcode in 0xE... at: "+m_lastCounter.ToString()
					+	" / "+(m_lastCounter+1).ToString()
					);
   				break;
				#endregion
				}
				break;
			#endregion
			#region 0xF... - 0xFX07, 0xFX0A, FX15, FX18, FX1E, FX29, FX33, FX55, FX65
			case 0xF000:
				switch(oc & 0x00FF) {
				#region 0xFX07 - set VX to val of delay timer
				case 0x0007:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xFX07"
						,	" set VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" to cal of delay_timer[" + m_delayTimer +"]"
						);
					#endif
					#endregion
					regs[(oc & 0x0F00) >> 8] = m_delayTimer;
					break;
				#endregion
				#region 0xFX0A - wait fo key press, then store in VX
				case 0x000A:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xFX0A"
						,	"wait fo key press, then store in"
						+	" VX" + regInfoString((oc & 0x0F00) >> 8)
						);
					#endif
					#endregion
					for(i=0; i<16; i++) {
						if(m_key[i] != 0) {
							regs[(oc & 0x0F00) >> 8] = (byte)i;
							#region DBG
							#if (DBG_SHOW_COMMAND)
								WriteDoCycle("0xFX0A", "key val=" + i);
							#endif
							#endregion
							return true;
						}
					}
					m_counter = m_lastCounter;
					break;
				#endregion
				#region 0xFX15 - set delay timer to VX
				case 0x0015:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xFX15"
						,	"set DT to VX" + regInfoString((oc & 0x0F00) >> 8)
						);
					#endif
					#endregion
					m_delayTimer = regs[(oc & 0x0F00) >> 8];
					break;
				#endregion
				#region 0xFX18 - set sound timer to VX
				case 0x0018:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xFX18"
						,	"set ST to VX" + regInfoString((oc & 0x0F00) >> 8)
						);
					#endif
					#endregion
					m_soundTimer = regs[(oc & 0x0F00) >> 8];
					break;
				#endregion
				#region 0xFX1E - add val VX to I. set VF to 1 if overflow, 0 if not
				case 0x001E:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						i = 0;
						if((m_indexRegister + regs[(oc & 0x0F00) >> 8]) > 0xFFF)
							i = 1;
						WriteDoCycle("0xFX1E"
						,	"add VX" + regInfoString((oc & 0x0F00) >> 8)
						+	"to I[" + m_indexRegister + "]"
						+	" overflow=" + i
						+	" val=" + (m_indexRegister + regs[(oc & 0x0F00) >> 8])
						);
					#endif
					#endregion
					unchecked {
						if((m_indexRegister + regs[(oc & 0x0F00) >> 8]) > 0xFFF)
							regs[0xF] = 1;
						else
							regs[0xF] = 0;
						m_indexRegister += regs[(oc & 0x0F00) >> 8];
					}
/*					i = m_indexRegister + regs[(oc & 0x0F00) >> 8];
					if(i > 3840) {
						regs[0xF] = 1;
						i -= 3840;
					}
					else regs[0xF] = 0;
					m_indexRegister = (UInt16)i;
//*/
					break;
				#endregion
				#region 0xFX29 - set I to address of font data for key hex val VX
				case 0x0029:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xFX29"
						,	"set I[" + m_indexRegister + "]"
						+	" to sprite addr for char in"
						+	" VX" + regInfoString((oc & 0x0F00) >> 8)
						+	"val=" + (regs[(oc & 0x0F00) >> 8] * 0x5)
						);
					#endif
					#endregion
					m_indexRegister = (ushort)(regs[(oc & 0x0F00) >> 8] * 0x5);
					break;
				#endregion
				#region 0xFX30 SCHIP?: set I to address of superFont data for key hex val VX
				case 0x0030:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xFX30"
						,	"set I[" + m_indexRegister + "]"
						+	" to s-font addr for char in"
						+	" VX" + regInfoString((oc & 0x0F00) >> 8)
						+	"val=" + ((regs[(oc & 0x0F00) >> 8] * 0x10) + 0xF0)
						);
					#endif
					#endregion
					m_indexRegister = (ushort)
									((regs[(oc & 0x0F00) >> 8] * 0x10) + 0xF0);
					break;
				#endregion
				#region 0xFX33 - SEE: info (end of file)
				case 0x0033:
					I = m_indexRegister;
					byte val = regs[(oc & 0x0F00) >> 8];
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xFX33"
						,	"store bin-coded representation of"
						+	" VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" with msd(most significant digit)[" + (val / 100)
						+	" at I[" + I + "]"
						+	" , (msd+1)[" +((val / 10) % 10)+ "] at (I+1)["+(I+1)+"]"
						+	" , (msd+2)[" +((val % 100) % 10)+ "] at (I+2)["+(I+2)+"]"
						);
					#endif
					#endregion
					m_bank[I] = (byte)(val / 100);
					m_bank[I + 1] = (byte)((val / 10) % 10);
	            m_bank[I + 2] = (byte)((val % 100) % 10);
					break;
				#endregion
				#region 0xFX55 - store V0 through VX in mem starting at I
				case 0x0055:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xFX55"
						,	"store V0" + regInfoString(0)
						+	" to VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" in memory starting at addr I[" + I + "]"
						);
					#endif
					#endregion
					for(i=0, l=((oc & 0x0F00) >> 8); i <= l; i++)
						m_bank[m_indexRegister + i] = regs[i];
					//for original interpreter
					m_indexRegister += (UInt16)(((oc & 0x0F00) >> 8) + 1);
					break;
				#endregion
				#region 0xFX65 - fills V0 through VX with mem starting at I
				case 0x0065:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xFX65"
						,	"fill V0" + regInfoString(0)
						+	" to VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" with memory from addr I[" + I + "]"
						+	" to addr (I+X[" + (I + ((oc & 0x0F00) >> 8)) + "]"
						);
					#endif
					#endregion
					for(i=0, l=((oc & 0x0F00) >> 8); i <= l; i++)
						regs[i] = m_bank[m_indexRegister + i];
						
					//for original interpreter
					m_indexRegister += (UInt16)(((oc & 0x0F00) >> 8) + 1);
					break;
				#endregion
				#region 0xFX75  SCHIP: store V0 through VX in HP48 flags
				case 0x0075:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xFX75"
						,	"store V0" + regInfoString(0)
						+	" to VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" in HP48 flags"
						);
					#endif
					#endregion
					for(i = 0, l = ((oc & 0x0F00) >> 8); i <= l; i++)
						HP48_flags[i] = regs[i];
					break;
				#endregion
				#region 0xFX85  SCHIP: fill V0 through VX with HP48 flags
				case 0x0085:
					#region DBG
					#if (DBG_SHOW_COMMAND)
						WriteDoCycle("0xFX85"
						,	"fill V0" + regInfoString(0)
						+	" to VX" + regInfoString((oc & 0x0F00) >> 8)
						+	" with HP48 flags"
						);
					#endif
					#endregion
					for(i = 0, l = ((oc & 0x0F00) >> 8); i <= l; i++)
						regs[i] = HP48_flags[i];
					break;
				#endregion
				#region default - ERROR
         	default:
					#region DBG
					#if (DBG_SHOW_COMMAND)
					WriteDoCycle("0xF...", "ERROR - opcode = " + oc.ToString("X"));
					#endif
					#endregion
   				DoRuntimeError(
						"Invalid opcode in 0xF000 at: "+m_lastCounter.ToString()
					+	" / "+(m_lastCounter+1).ToString()
					);
   				break;
				#endregion
				}
				break;
			#endregion
			#region default - ERROR
      	default:
				#region DBG
				#if (DBG_SHOW_COMMAND)
				WriteDoCycle("0x....", "ERROR - opcode = " + oc.ToString("X"));
				#endif
				#endregion
				DoRuntimeError(
					"Invalid opcode in 0xF000 at: "+m_lastCounter.ToString()
				+	" / "+(m_lastCounter+1).ToString()
				);
				break;
			#endregion
   		}
			//ebug.WriteLine("DoCycle - end");
			return true;
		}
	}
}

