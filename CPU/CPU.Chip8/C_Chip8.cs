#region header
/* User: Erin
 * Date: 1/30/2013
 * Time: 9:03 AM
 * --------------------------------
 * lsb = least significant bit
 * msb = most significant bit
 *   I = index register
 *   O = 
 */
#endregion
#region defs
#define aDBG_SHOW_COMMAND
#endregion
#region using....
using Emu.Core;
using Emu.Memory;
using Emu.Video;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace Emu.CPU {
	public partial class C_Chip8 : C_Base {
		#region static
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
		#endregion
		#region vars
		public byte[] HP48_flags;
		protected byte[] m_fontSet;
		//protected 
		#endregion
		#region constructors
		public C_Chip8(): base(CHIP_NAME) { InitC_Chip8(); }
		public C_Chip8(Mem_Base mem, Vid_Base vid): base(CHIP_NAME, mem, vid) {
			InitC_Chip8();
		}
		protected virtual void InitC_Chip8() {
			DoCycle = new DoCycleDelegate(DoCycle_Main);
			Reset();
		}
		#endregion
		#region state stuff
		//protected override state GetState() { return null; }
		public override void SetState(state state) {
			int i;//, il;
			
			//- read registers
			for(i = 0; i < 16; i++)
				m_vRegisters[i] = state.bytes["CPU-V" + i];
			
			//- write HP48 flags
			for(i = 0; i < 8; i++)
				HP48_flags[i] = state.bytes["CPU-HP" + i];
			
			//- timers
         m_delayTimer = state.bytes["CPU-DT"];
         m_soundTimer = state.bytes["CPU-ST"];
			
			//- index
			m_indexRegister = state.ushorts["CPU-I"];

			//- program counter
			m_counter = state.ushorts["CPU-PC"];
		}
		public override state UpdateState(state state) {
			int i;//, il;
			
			//- write registers
			for(i = 0; i < 16; i++)
				state.bytes.Add("CPU-V" + i, m_vRegisters[i]);
			
			//- write HP48 flags
			for(i = 0; i < 8; i++)
				state.bytes.Add("CPU-HP" + i, HP48_flags[i]);
			
			//- timers
			state.bytes.Add("CPU-DT", m_delayTimer);
			state.bytes.Add("CPU-ST", m_soundTimer);
			
			//- index
			state.ushorts.Add("CPU-I", m_indexRegister);

			//- program counter
			state.ushorts.Add("CPU-PC", m_counter);

			return state;			
		}
		#endregion
		#region function: Initialize, Reset, SoftReset
		public override void Initialize() {
			Reset();
			if(m_fontSet==null) m_fontSet=C_Chip8.m_defaultFontSet;

		}
		public override void Reset() {
			Int16 ii;//, il;
			
			base.Reset();
			if(HP48_flags == null) HP48_flags = new Byte[8];
			for(ii = 0; ii < 8; ii++) HP48_flags[ii] = 0x0;
			if(m_vRegisters == null) m_vRegisters=new byte[16];
			for(ii = 0; ii < 16; ii++) m_vRegisters[ii] = 0x00;
			if(m_key == null) m_key=new byte[16];
			for(ii = 0; ii < 16; ii++) m_key[ii] = 0x00;
			
			m_counter=0x200;
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
		public override void SoftReset() {
			base.SoftReset();
			int i;
			for(i = 0; i < 16; i++) {
				m_key[i] = 0;
				m_stack[i] = 0;
				m_vRegisters[i] = 0;
			}
			m_counter = 0x200;
			m_indexRegister = 0;
			m_opcode = 0;
			m_stackCount = 0;
			m_delayTimer = 0;
			m_soundTimer = 0;
		}
		#endregion
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
	
	
