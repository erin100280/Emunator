/* User: Erin
 * Date: 2/2/2013
 * Time: 5:43 PM
 */
using System;
namespace Emu.Memory {
	public class Mem_Base {
		#region vars
		protected byte[] m_bank;
		protected uint m_size;
		protected ushort m_startAddress;
		protected int m_romSize;
		protected int m_startRomAddress;
		protected int m_stopRomAddress;
		protected int m_ramSize;
		protected int m_startRamAddress;

		#endregion
		#region constructors
		public Mem_Base() { InitMem_Base(); }
		public Mem_Base(uint size) { InitMem_Base(); }
		protected virtual void InitMem_Base(uint size=0) {
			if(size==0) size=4096;
			m_size=size;
			m_bank=new byte[m_size];
		}
		#endregion
		#region properties
		public virtual uint size{ get { return m_size; } }
		public virtual byte[] bank{ get { return m_bank; } }
		#endregion
		public virtual void Reset() {}
	}
}
