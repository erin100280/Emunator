/* User: Erin
 * Date: 1/30/2013
 * Time: 9:06 AM
 */
using Emu;
using Emu.Core;
using Emu.Core.States;
using Emu.Memory;
using Emu.Video;
using System;
using System.Collections.Generic;

namespace Emu.CPU {

	public class C_Base {
		#region vars
		//protected byte[] m_buffer=null;
		protected byte m_delayTimer;
		protected byte m_soundTimer;
		protected byte[] m_key;
		protected byte[] m_vRegisters=null;
		protected ushort m_counter;
		protected ushort m_lastCounter;
		protected ushort m_indexRegister;
		protected ushort m_opcode;
		protected ushort m_stackSize;
		protected ushort[] m_stack;
		protected ushort m_stackCount;

		protected int m_ramSize;
		protected UInt64 m_startAddress;
		protected UInt64 m_ramStartAddress;
		protected UInt64 m_romStartAddress;

		protected string m_name;
		protected metaData m_meta=null;

		protected byte[] m_bank=null;
		protected Mem_Base m_memory=null;
		protected byte[] m_buffer=null;
		protected UInt32 m_bufferSize;
		protected Vid_Base m_video=null;
		#endregion
		#region constructors
		public C_Base(string name) { InitC_Base(name); }
		public C_Base(string name, Mem_Base mem, Vid_Base vid) {
			InitC_Base(name, mem, vid);
		}
		protected virtual void InitC_Base(string name="", Mem_Base mem=null
					, Vid_Base vid=null) {
			m_meta=new metaData(name);
			memory=mem;
			video=vid;
		}
		#endregion
		#region events
		public event EventHandler MemoryChanged;
		public event EventHandler VideoChanged;
		public event EventHandler<errorEventArgs> RuntimeError;
		#endregion
		#region properties
		public virtual cpuState state {
			get { return GetState(); }
			set { SetState(value); }
		}
		public virtual byte[] bank{ get { return m_bank; } }
		public virtual Mem_Base memory {
			get { return m_memory; }
			set {
				if(m_memory!=value) {
					byte[] bt=null;
					m_memory=value;
				
					if(m_memory!=null) {
						bt=m_memory.bank;
					}
				
					m_bank=bt;
					OnMemoryChanged(new EventArgs());
				}
			}
		}
		public virtual Vid_Base video {
			get { return m_video; }
			set {
				if(m_video!=value) {
					UInt32 bs=0;
					byte[] bt=null;
					m_video=value;
				
					if(m_video!=null) {
						bt=m_video.buffer;
					}
				
					m_buffer=bt;
					m_bufferSize=bs;
					OnVideoChanged(new EventArgs());
				}
			}
		}
		public virtual metaData meta{ get { return m_meta; } }
		public virtual UInt64 ramStartAddress { get { return m_ramStartAddress; } }
		public virtual UInt64 romStartAddress { get { return m_romStartAddress; } }
		
		#endregion
		#region On....
		protected virtual void OnMemoryChanged(EventArgs e) {
			if(MemoryChanged!=null) MemoryChanged(this, e);
		}
		protected virtual void OnVideoChanged(EventArgs e) {
			if(VideoChanged!=null) VideoChanged(this, e);
		}
		protected virtual void OnRuntimeError(errorEventArgs e) {
			if(RuntimeError!=null) RuntimeError(this, e);
		}
		#endregion
		#region function GetState, SetState
		protected virtual cpuState GetState() { return new cpuState(); }
		protected virtual void SetState(cpuState state) {}
		#endregion
		protected virtual void DoRuntimeError(string err) {
			OnRuntimeError(new errorEventArgs(err));
		}
		public virtual void Initialize() {}
		public virtual void DoCycle() {}
		public virtual void Reset() {}
	}

}