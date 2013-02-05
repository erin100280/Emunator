/* User: Erin
 * Date: 2/2/2013
 * Time: 5:51 PM
 */
using System;
using System.Collections.Generic;

namespace Emu.Memory {
	public class Mem_Chip8 : Mem_Base {
		#region vars
			protected int StartChip8Font = 0x00;
			protected int StopChip8Font = 0x50;
			protected int StartSuperFont = 0x51;
			protected int StopSuperFont = 0xF0;
		#endregion
		#region constructors
		public Mem_Chip8(): base(4096) { InitMem_Chip8(); }
		protected virtual void InitMem_Chip8() {
			
		}
		#endregion
		#region properties
		#endregion
		public override void Reset() {
			//m_bank;
			m_size=4096;
			m_startAddress=0x200; // 512
			m_romSize=0x1FF;
			m_startRomAddress=0x0;
			m_stopRomAddress=0x1FF;
			m_ramSize=0xE00;//? 3584 ?
			m_startRamAddress=0x200;
		}
	}
}
