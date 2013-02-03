/* User: Erin
 * Date: 2/2/2013
 * Time: 5:51 PM
 */
using System;
using System.Collections.Generic;

namespace Emu.Memory {
	public class Mem_Chip8 : Mem_Base {
		#region vars
			protected int StartChip8Font = 0x00;  // Les fonts chip8 sont stockés au débuts de la mémoire
			protected int StopChip8Font = 0x50; // 75 
			protected int StartSuperFont = 0x51; // Adresse de début des fonts Super Chip-8
			protected int StopSuperFont = 0xF0; // Adresse de fin des fonts Super Chip-8
			
		#endregion
		#region constructors
		public Mem_Chip8(): base() { InitMem_Chip8(); }
		protected virtual void InitMem_Chip8() {
			
		}
		#endregion
		#region properties
		#endregion
	}
}
