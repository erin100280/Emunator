/* User: Erin
 * Date: 2/2/2013
 * Time: 5:43 PM
 */
using System;
namespace Emu.Memory {
	public class Mem_Base {
		#region vars
			protected byte[] m_values;
			protected uint m_size = 4096;
			protected ushort startAddress = 0x200; // 512
			protected int RomSize = 0x1FF; 			// Mémoire morte 511 octets
			protected int StartRomAddress = 0x0;	// Adresse de début de la Ram
			protected int StopRomAddress = 0x1FF;	// Adresse de fin de la Ram
			protected int RamSize = 0xE00;			// Mémoire vive de 3584 octets
			protected int StartRamAddress = 0x200; 	// Adresse de début de la Rom
		#endregion
		#region constructors
		public Mem_Base() { InitMem_Base(); }
		public Mem_Base(uint size) { InitMem_Base(); }
		protected virtual void InitMem_Base(uint size=0) {
			if(size<0) size=4096;
			m_size=size;
			m_values=new byte[m_size];
		}
		#endregion
		#region properties
		public virtual uint size{ get { return m_size; } }
		public virtual byte[] values{ get { return m_values; } }
		#endregion
	}
}
