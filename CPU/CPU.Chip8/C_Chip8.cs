/* User: Erin
 * Date: 1/30/2013
 * Time: 9:03 AM
 * --------------------------------
 * lsb = least significant bit
 * msb = most significant bit
 *   I = index register
 *   O = 
 */
using Emu.Core;
using Emu.Core.States;
using Emu.Memory;
using Emu.Video;
using System;
using System.Collections.Generic;

namespace Emu.CPU {
	public class C_Chip8 : C_Base {
		#region static vars
		public Random rand=new Random(DateTime.Now.Millisecond);
		private static byte[] m_defaultFontSet = {
			0xF0, 0x90, 0x90, 0x90, 0xF0 //0
		,	0x20, 0x60, 0x20, 0x20, 0x70 //1
		,	0xF0, 0x10, 0xF0, 0x80, 0xF0 //2
		,	0xF0, 0x10, 0xF0, 0x10, 0xF0 //3
		,	0x90, 0x90, 0xF0, 0x10, 0x10 //4
		,	0xF0, 0x80, 0xF0, 0x10, 0xF0 //5
		,	0xF0, 0x80, 0xF0, 0x90, 0xF0 //6
		,	0xF0, 0x10, 0x20, 0x40, 0x40 //7
		,	0xF0, 0x90, 0xF0, 0x90, 0xF0 //8
		,	0xF0, 0x90, 0xF0, 0x10, 0xF0 //9
		,	0xF0, 0x90, 0xF0, 0x90, 0x90 //A
		,	0xE0, 0x90, 0xE0, 0x90, 0xE0 //B
		,	0xF0, 0x80, 0x80, 0x80, 0xF0 //C
		,	0xE0, 0x90, 0x90, 0x90, 0xE0 //D
		,	0xF0, 0x80, 0xF0, 0x80, 0xF0 //E
		,	0xF0, 0x80, 0xF0, 0x80, 0x80 //F
		};
		#endregion
		#region static consts
		private const string CHIP_NAME="Chip6";
		#endregion
		#region static properties
		public static byte[] defaultFontSet{ get { return m_defaultFontSet; } }
		#endregion
		#region vars
		protected byte[] m_fontSet;
		//protected 
		#endregion
		#region constructors
		public C_Chip8(): base(CHIP_NAME) { InitC_Chip8(); }
		public C_Chip8(Mem_Base mem, Vid_Base vid): base(CHIP_NAME, mem, vid) {
			InitC_Chip8();
		}
		protected virtual void InitC_Chip8() {}
		#endregion
		#region state stuff
		protected override cpuState GetState() { return null; }
		protected override void SetState(cpuState state) {}
		#endregion
		public override void Reset() {
			base.Reset();
			m_vRegisters=new byte[16];
			m_key=new byte[16];
			m_counter=0;
			m_indexRegister=0;
			m_opcode=0;
			m_stackSize=16;
			m_stack=new ushort[m_stackSize];
			m_stackCount=0;
			m_delayTimer=0;
			m_soundTimer=0;
		
			m_ramStartAddress=0x200;
			m_romStartAddress=0x200;
		}
		public override void Initialize() {
			Reset();
			if(m_fontSet==null) m_fontSet=C_Chip8.m_defaultFontSet;

		}
		public override void DoCycle() {
			int i, ix, iy, l;
			byte[] regs=m_vRegisters;
			ushort romSA=m_romStartAddress;
			ushort oc=m_opcode=(ushort)(m_bank[m_romStartAddress+m_counter] << 8
						| m_bank[m_romStartAddress+m_counter+1]);
			ushort x, y, h, pxl;

			m_lastCounter=m_counter;
			m_counter+=2;
			
			switch(oc & 0xF000) {
			#region 0x0...  0x00E0, 0x00EE
			case 0x0000:
   			switch(oc & 0x000F) {
   			case 0x0000:	//0x00E0 - clear screen
					for(i=0, l=(int)m_video.bufferSize; i<l; i++)
   					m_buffer[i]=0;
   				m_video.updated=true;
   				break;
   				
   			case 0x000E:	//0x00EE - return from sub
   				if(m_stackCount>0) {
   					m_counter=m_stack[romSA + m_stackCount-1];
   					m_stackCount--;
   				}
   				break;
   				
				default:
   				DoRuntimeError("Invalid opcode");
   				break;
      		}
      		break;
			#endregion
			#region 0x1NNN - jump to NNN
      	case 0x1000:
				m_counter=(ushort)(romSA + (oc & 0x0FFF));
      		break;
			#endregion
			#region 0x2NNN - run sub at NNN
      	case 0x2000:
      		m_stack[m_stackCount]=m_counter;
      		++m_stackCount;
      		m_counter=(ushort)(romSA + (oc & 0x0FFF));
      		break;
			#endregion
			#region 0x3XNN - skip next instruction if val at
			               //register X is equal to NN
      	case 0x3000:
				if(regs[(oc & 0x0F00) >> 8] == (oc & 0x00FF))
      		   m_counter+=2;
      		break;
			#endregion
			#region 0x4XNN - skip next instruction if val at 
			               //register X is not equal to NN
      	case 0x4000:
				if(regs[(oc & 0x0F00) >> 8] != (oc & 0x00FF))
      		   m_counter+=2;
      		break;
			#endregion
			#region 0x5XY0 - skip next instruction if val at 
			               //register X is equal to val at register Y
      	case 0x5000:
      		if(regs[(oc & 0x0F00) >> 8] == regs[(oc & 0x00F0) >> 4])
      		   m_counter+=2;
      		break;
			#endregion
			#region 0x6XNN - store NN at VX
      	case 0x6000:
      		regs[(oc & 0x0F00) >> 8]=(byte)(oc & 0x00FF);
      		break;
			#endregion
			#region 0x7XNN - add NN to VX
      	case 0x7000:
      		regs[(oc & 0x0F00) >> 8]+=(byte)(oc & 0x00FF);
				break;
			#endregion
      	#region 0x8...  0x8XY0 - 0x8XY7, 0x8XYE
      	case 0x8000:
      		switch(oc & 0x000F) {
   			case 0x0000:	//0x8XY0 - copy VY to VX
         		regs[(oc & 0x0F00) >> 8] = regs[(oc & 0x00F0) >> 4];
         		break;

   			case 0x0001:	//0x8XY1 - set VX to VX-OR-VY
         		regs[(oc & 0x0F00) >> 8] |= regs[(oc & 0x00F0) >> 4];
         		break;

   			case 0x0002:	//0x8XY2 - set VX to VX-AND-VY
         		regs[(oc & 0x0F00) >> 8] &= regs[(oc & 0x00F0) >> 4];
         		break;

   			case 0x0003:	//0x8XY3 - set VX to VX-XOR-VY
         		regs[(oc & 0x0F00) >> 8] ^= regs[(oc & 0x00F0) >> 4];
         		break;

   			case 0x0004:	//0x8XY4 - add VY to VX.
									//Set VF to 01 if carry, 00 if no carry
         		if(regs[(oc & 0x00F0) >> 4]
								> (0xFF-regs[(oc & 0x0F00) >> 8]))
						regs[0xF]=1;
					else
						regs[0xF]=0;
	         		regs[(oc & 0x0F00) >> 8] += regs[(oc & 0x00F0) >> 4];
         		break;

   			case 0x0005:	//0x8XY5 - set VX to (VX - VY).
									//Set VF to 00 if borrow, 01 if no borrow
         		if(regs[(oc & 0x00F0) >> 4]
							   > (regs[(oc & 0x0F00) >> 8]))
						regs[0xF]=0;
					else
						regs[0xF]=1;
	         		regs[(oc & 0x0F00) >> 8] -= regs[(oc & 0x00F0) >> 4];
         		break;

         	case 0x0006:	//0x8XY6 - shift VX right 1. set VF to lsb
         		regs[0xF]=(byte)(regs[(oc & 0x0F00) >> 8] & 0x1);
         		regs[(oc & 0x0F00) >> 8] >>=1;
         		break;

   			case 0x0007:	//0x8XY7 - set VX to (VY - VX).
									//Set VF to 00 if borrow, 01 if no borrow
         		if(regs[(oc & 0x0F00) >> 8]
							   > (regs[(oc & 0x00F0) >> 4]))
						regs[0xF]=0;
					else
						regs[0xF]=1;
         		regs[(oc & 0x0F00) >> 8] = (byte)(regs[(oc & 0x00F0) >> 4]
								- regs[(oc & 0x0F00) >> 8]);
         		break;

         	case 0x000E:	//0x8XYE - shift VX left 1. set VF to msb
         		regs[0xF]=(byte)(regs[(oc & 0x0F00) >> 8] >> 7);
         		regs[(oc & 0x0F00) >> 8] <<=1;
         		break;

         	default:
   				DoRuntimeError(
						"Invalid opcode in ox8000 at: "+m_lastCounter.ToString()
					+	" / "+(m_lastCounter+1).ToString()
					);
   				break;

      		}
				break;
      	#endregion
			#region 0x9XY0 - skip next instruction if VX != VY
			case 0x9000:
				if(regs[(oc & 0x0F00) >> 8] != regs[(oc & 0x00F0) >> 4])
					m_counter+=2;
				break;
			#endregion
			#region 0xANNN - set I to address NNN
			case 0xA000:
				m_indexRegister=(ushort)(romSA + (oc & 0x0FFF));
				break;
			#endregion
			#region 0xBNNN - jump to address (NNN + V0)
			case 0xB000:
				m_counter=(ushort)(romSA + ((oc & 0x0FFF) + regs[0]));
				break;
			#endregion
			#region 0xCXYN - set VX to (randomNumber & NN)
			case 0xC000:
				regs[(oc & 0x0F00) >> 8]
							= (byte)((rand.Next() % 0xFF) & (oc & 0x00FF));
				break;
			#endregion
			#region 0xDXYN - draw sprite at VX,VY with height of N
			               //starting at address I
			case 0xD000:	
				x=regs[(oc & 0x0F00) >>8];
				y=regs[(oc & 0x00F0) >>4];
				h=(ushort)(oc & 0x000F);

				regs[0xF]=0; //collision flag
				for(iy=0; iy<h; iy++) {
					pxl=m_bank[m_indexRegister + iy];
					for(ix=0; ix<8; ix++) {
						if((pxl & (0x80 >> ix)) != 0) {
							if(m_buffer[(x + ix + ((y + iy) * 64))] == 1)
								regs[0xF] = 1;//collision occured
							m_buffer[x + ix + ((y + iy) * 64)] ^= 1;
						}
					}
				}
				m_video.updated=true;
				break;
			#endregion
			#region 0xE... - 0xEX9E, 0xEXA1
			case 0x0E00:
				switch(oc & 0x00FF) {
				#region 0xEX9E - skip next instruction if key in VX is pressed
				case 0x009E:
					if(m_key[regs[(oc & 0x0F00) >> 8]] != 0)
						m_counter += 2;
					break;
				#endregion
				#region 0xEXA1 - skip next instruction if key in VX is not pressed
				case 0x00A1:
					if(m_key[regs[(oc & 0x0F00) >> 8]] == 0)
						m_counter += 2;
					break;
				#endregion
				}
				break;
			#endregion
			#region 0xF... - 0xFX07, 0xFX0A, FX15, FX18, FX1E, FX29, FX33, FX55, FX65
			case 0x0F00:
				switch(oc & 0x00FF) {
				#region 0xFX07 - set VX to val of delay timer
				case 0x0007:
					regs[(oc & 0x0F00) >> 8] = m_delayTimer;
					break;
				#endregion
				#region 0xFX0A - wait fo key press, then store in VX
					case 0x000A:
					for(i=0; i<16; i++) {
						if(m_key[i] != 0) {
							regs[(oc & 0x0F00) >> 8] = (byte)i;
							return;
						}
					}
					m_counter = m_lastCounter;
					break;
				#endregion
				#region 0xFX15 - set delay timer to VX
				case 0x0015:
					m_delayTimer = regs[(oc & 0x0F00) >> 8];
					break;
				#endregion
				#region 0xFX18 - set sound timer to VX
				case 0x0018:
					m_soundTimer = regs[(oc & 0x0F00) >> 8];
					break;
				#endregion
				#region 0xFX1E - add val VX to I. set VF to 1 if overflow, 0 if not
				case 0x001E:
					if((m_indexRegister + regs[(oc & 0x0F00) >> 8]) > 0xFFF)
						regs[0xF] = 1;
					else
						regs[0xF] = 0;
					m_indexRegister += regs[(oc & 0x0F00) >> 8];
					break;
				#endregion
				#region 0xFX29 - set I to address of font data for key hex val VX
				case 0x0029:
				m_indexRegister = (ushort)(regs[(oc & 0x0F00) >> 8] * 0x5);
					break;
				#endregion
				#region 0xFX33 - SEE: info (end of file)
				case 0x0033:
					ushort I = m_indexRegister;
					byte val = regs[(oc & 0x0F00) >> 8];
					m_bank[I] = (byte)(val / 100);
					m_bank[I + 1] = (byte)((val / 10) % 10);
	            m_bank[I + 2] = (byte)((val % 100) % 10);
					break;
				#endregion
				#region 0xFX55 - store V0 through VX in mem starting at I
				case 0x0055:
					for(i=0, l=(((oc & 0x0F00) >> 8) + 1); i < l; i++)
						m_bank[m_ramStartAddress + m_indexRegister + i] = regs[i];
						break;
				#endregion
				#region 0xFX65 - fills V0 through VX with mem starting at I
				case 0x0065:
					for(i=0, l=(((oc & 0x0F00) >> 8) + 1); i < l; i++)
						regs[i] = m_bank[m_ramStartAddress + m_indexRegister + i];
						
						//for original interpreter
						m_indexRegister += (ushort)l;
						break;
				#endregion
					
				}
				break;
			#endregion
			#region default
			default:
				DoRuntimeError(
					"Invalid opcode at: "+m_lastCounter.ToString()
				+	" / "+(m_lastCounter+1).ToString()
				);
				break;
			#endregion
   		}
			
			
		}
	}
}

#region info
/*
0xFX33 - Stores the Binary-coded decimal representation of VX, with the most
significant of three digits at the address in I, the middle digit 
at I plus 1, and the least significant digit at I plus 2. (In other words
, take the decimal representation of VX, place the hundreds digit in 
memory at location in I, the tens digit at location I+1, and the ones 
digit at location I+2.)
//*/
#endregion
	
	
