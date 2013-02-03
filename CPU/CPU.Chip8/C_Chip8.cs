/* User: Erin
 * Date: 1/30/2013
 * Time: 9:03 AM
 */
using System;
using System.Collections.Generic;

namespace Emu.CPU {
	public class C_Chip8 : C_Base {
		#region static vars
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
		#region static properties
		public static byte[] defaultFontSet{ get { return m_defaultFontSet; } }
		#endregion
		#region vars
		protected byte[] m_V;
		protected byte[] m_graphics;
		protected byte[] m_fontSet;
		//protected 
		#endregion
		#region constructors
		public C_Chip8() { InitC_Chip8(); }
		protected virtual void InitC_Chip8() {}
		#endregion
		protected virtual void InitVars() {
			m_V=new byte[16];
			m_graphics=new byte[64 * 32];
			m_key=new byte[16];
			m_counter=0;
			m_indexRegister=0;
			m_opcode=0;
			m_stack=new ushort[16];
			m_stackPointer=0;
			m_delayTimer=0;
			m_soundTimer=0;
		}
		public override void Initialize() {
			InitVars();
			if(m_fontSet==null) m_fontSet=C_Chip8.m_defaultFontSet;

		}
		public override void DoCycle() {
			m_opcode=(ushort)(m_memArray[m_counter] << 8 | m_memArray[m_counter+1]);
			//m_opcode=(ushort)((m_memArray[m_counter] << 8) + m_memArray[m_counter+1]);
		
			switch(m_opcode) {
				default: break;
			}
			
			
		}
	}
}