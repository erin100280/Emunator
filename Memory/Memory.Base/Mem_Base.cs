/* User: Erin
 * Date: 2/2/2013
 * Time: 5:43 PM
 */
using System;
using System.IO;

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
		public virtual void SetMemory(byte[] val, int startPos) {
			for(uint i = 0, l = (uint)val.Length; i < l; i++)
				m_bank[startPos + i] = val[i];
		}
		public virtual void SetMemory(BinaryReader val, int startPos) {
			uint i = 0;
			int byt = val.Read();
			
			try {
				while(true) {
					m_bank[startPos + i] = val.ReadByte();
					i++;
				}
			}
			catch(Exception ex) { if(ex.Data == null) {} }
		}
		public virtual void Reset() {}
	}
}
