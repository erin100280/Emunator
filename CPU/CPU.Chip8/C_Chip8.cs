/* User: Erin
 * Date: 1/30/2013
 * Time: 9:03 AM
 */
using System;
using System.Collections.Generic;

namespace Emu.CPU {
	public class C_Chip8 : C_Base {
		#region vars
		protected byte[] m_memory;
		protected byte[] m_V;
		protected byte[] m_graphics;
		protected byte m_delayTimer;
		protected byte m_soundTimer;
		protected byte[] m_key;
		protected ushort m_counter;
		protected ushort m_indexRegister;
		protected ushort m_opcode;
		protected ushort[] m_stack;
		protected ushort m_stackPointer;
		
		
		#endregion
		#region constructors
		public C_Chip8() { InitC_Chip8(); }
		protected virtual void InitC_Chip8() {
			InitVars();
		}
		#endregion
		protected virtual void InitVars() {
			m_memory=new byte[4069];
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
		public virtual void Initialize() {
			InitVars();
		}
		public virtual void EmulateCycle() {
			
		}
	}
}