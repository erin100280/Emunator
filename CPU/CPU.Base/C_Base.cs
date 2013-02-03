/* User: Erin
 * Date: 1/30/2013
 * Time: 9:06 AM
 */
using Emu;
using Emu.Memory;
using System;
using System.Collections.Generic;

namespace Emu.CPU {

	public class C_Base {
		#region vars
		protected Mem_Base m_memSystem=null;
		protected byte[] m_memArray=null;
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
		public C_Base() { InitC_Base(); }
		protected virtual void InitC_Base() {}
		#endregion
		#region events
		public event EventHandler MemorySystemChanged;
		#endregion
		#region properties
		public virtual byte[] memoryArray{ get { return m_memArray; } }
		public virtual Mem_Base memorySystem {
			get { return m_memSystem; }
			set {
				if(m_memSystem!=value) {
					byte[] bt=null;
					m_memSystem=value;
				
					if(m_memSystem!=null) {
						bt=m_memSystem.values;
					}
				
					m_memArray=bt;
					OnMemorySystemChanged(new EventArgs());
				}
			}
		}
		#endregion
		#region On....
		protected virtual void OnMemorySystemChanged(EventArgs e) {
			if(MemorySystemChanged!=null) MemorySystemChanged(this, e);
		}
		#endregion
		public virtual void Initialize() {}
		public virtual void DoCycle() {}
	}

}