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
		}
		public override void Initialize() {
			Reset();
			if(m_fontSet==null) m_fontSet=C_Chip8.m_defaultFontSet;

		}
		public override void DoCycle() {
			byte[] regs=m_vRegisters;
			ushort oc=m_opcode=(ushort)
						(m_bank[m_counter] << 8 | m_bank[m_counter+1]);
			m_lastCounter=m_counter;
			m_counter+=2;
			
			switch(oc & 0xF000) {

         	case 0x0000:
      			switch(oc & 0x000F) {
         			case 0x0000:	//0x00E0 - clear screen
         				for(UInt32 i=0, l=m_video.bufferSize; i<l; i++)
         					m_buffer[i]=0;
         				m_video.updated=true;
         				break;
         				
         			case 0x000E:	//0x00EE - return from sub
         				if(m_stackCount>0) {
         					m_counter=m_stack[m_stackCount-1];
         					m_stackCount--;
         				}
         				break;
         				
      				default:
         				DoRuntimeError("Invalid opcode");
         				break;
         		}
         		break;

         	case 0x1000:	//0x1NNN - jump to NNN
         		m_counter=(ushort)(oc & 0x0FFF);
         		break;

         	case 0x2000:	//0x2NNN - run sub at NNN
         		m_stack[m_stackCount]=m_counter;
         		++m_stackCount;
         		m_counter=(ushort)(oc & 0x0FFF);
         		break;

         	case 0x3000:	//0x3XNN - skip next instruction if val at
         						//register X is equal to NN
					if(regs[(oc & 0x0F00) >> 8] == (oc & 0x00FF))
         		   m_counter+=2;
         		break;

         	case 0x4000:	//0x4XNN - skip next instruction if val at 
         						//register X is not equal to NN
					if(regs[(oc & 0x0F00) >> 8] != (oc & 0x00FF))
         		   m_counter+=2;
         		break;

         	case 0x5000:	//0x5XY0 - skip next instruction if val at 
         						//register X is equal to val at register Y
         		if(regs[(oc & 0x0F00) >> 8] == regs[(oc & 0x00F0) >> 4])
         		   m_counter+=2;
         		break;
         		
         	case 0x6000:	//0x6XNN - store NN at VX
         		regs[(oc & 0x0F00) >> 8]=(byte)(oc & 0x00FF);
         		break;
         	
         	case 0x7000:	//0x7XNN - add NN to VX
         		regs[(oc & 0x0F00) >> 8]+=(byte)(oc & 0x00FF);
					break;
         		
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

				case 0x9000:	//0x9XY0 - skip next instruction if VX != VY
					if(regs[(oc & 0x0F00) >> 8] != regs[(oc & 0x00F0) >> 4])
						m_counter+=2;
					break;

				case 0xA000:	//0xANNN - set I to address NNN
					m_indexRegister=(ushort)(oc & 0x0FFF);
					break;

				case 0xB000:	//0xBNNN - jump to address (NNN + V0)
					m_counter=(ushort)((oc & 0x0FFF) + regs[0]);
					break;

				case 0xC000:	//0xCXNN - set VX to (randomNumber & NN)
					regs[(oc & 0x0F00) >> 8]
								= (byte)((rand.Next() % 0xFF) & (oc & 0x00FF));
					break;

				case 0xD000:	//0xBNNN - jump to address (NNN + V0)
					m_counter=(ushort)((oc & 0x0FFF) + regs[0]);
					break;

				default:
   				DoRuntimeError(
						"Invalid opcode at: "+m_lastCounter.ToString()
					+	" / "+(m_lastCounter+1).ToString()
					);
   				break;
				
			
   		}
			
			
		}
	}
}