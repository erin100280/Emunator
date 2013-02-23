#region header
/* User: Erin
 * Date: 1/30/2013
 * Time: 9:06 AM
 */
#endregion
#region using....
using Emu;
using Emu.Core;
using Emu.Memory;
using Emu.Video;
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace Emu.CPU {
	public class C_Base {
		#region delegates
		public delegate bool DoCycleDelegate();
		#endregion
		#region vars
		//protected byte[] m_buffer=null;
		public consoleRef _console = null;
		public UInt64 cycleCount = 0;
		
		public DoCycleDelegate DoCycle;
		public byte m_delayTimer;
		public byte m_soundTimer;
		public byte[] m_key;
		public byte[] m_vRegisters=null;
		public ushort m_counter;
		protected ushort m_lastCounter;
		public ushort m_indexRegister;
		public ushort m_opcode;
		public ushort m_stackSize;
		public ushort[] m_stack;
		public ushort m_stackCount;

		protected int m_ramSize;
		protected UInt64 m_startAddress;
		protected UInt64 m_ramStartAddress;
		protected UInt64 m_romStartAddress;

		protected string m_name;
		protected metaData m_meta=null;

		protected byte[] m_bank=null;
		protected Mem_Base m_memory=null;
		protected byte[] m_buffer=null;
		protected Int32 m_bufferSize;
		protected Vid_Base m_video=null;
		#endregion
		#region constructors
		public C_Base(string name) { InitC_Base(name); }
		public C_Base(string name, Mem_Base mem, Vid_Base vid) {
			InitC_Base(name, mem, vid);
		}
		protected virtual void InitC_Base(string name="", Mem_Base mem=null
					, Vid_Base vid=null) {

			DoCycle = new DoCycleDelegate(DoCycle_Main);
			m_meta=new metaData(name);
			memory=mem;
			video=vid;
		}
		#endregion
		#region events
		public event EventHandler BeforeVideoChanged;
		public event EventHandler BufferChanged;
		public event EventHandler MemoryChanged;
		public event EventHandler VideoChanged;
		public event EventHandler<errorEventArgs> RuntimeError;
		#endregion
		#region properties
		public virtual byte[] keys { get { return m_key; } }
		public virtual state state {
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
					OnBeforeVideoChanged(new EventArgs());
					m_video=value;
					OnVideoChanged(new EventArgs());
				}
			}
		}
		public virtual metaData meta{ get { return m_meta; } }
		public virtual UInt64 ramStartAddress { get { return m_ramStartAddress; } }
		public virtual UInt64 romStartAddress { get { return m_romStartAddress; } }
		
		#endregion
		#region event handlers
		public virtual void Video_BufferChanged(object obj, EventArgs e) {
			OnBufferChanged(e);
		}
		#endregion

		#region On....
		protected virtual void OnBeforeVideoChanged(EventArgs e) {
			if(m_video != null) m_video.BufferChanged -= Video_BufferChanged;
			if(BeforeVideoChanged != null) BeforeVideoChanged(this, e);
		}
		protected virtual void OnBufferChanged(EventArgs e) {
			m_buffer = video.buffer;
			m_bufferSize = video.bufferSize;
			if(BufferChanged != null) BufferChanged(this, e);
		}
		protected virtual void OnMemoryChanged(EventArgs e) {
			if(MemoryChanged!=null) MemoryChanged(this, e);
		}
		protected virtual void OnVideoChanged(EventArgs e) {
			Int32 bs=0;
			byte[] bt=null;
		
			if(m_video != null) m_video.BufferChanged += Video_BufferChanged;
			if(m_video!=null) {
				bt=m_video.buffer;
				bs = m_video.bufferSize;
			}
		
			m_buffer=bt;
			m_bufferSize=bs;
			if(VideoChanged!=null) VideoChanged(this, e);
		}
		protected virtual void OnRuntimeError(errorEventArgs e) {
			if(RuntimeError!=null) RuntimeError(this, e);
		}
		#endregion
		#region function GetState, SetState
		public virtual state GetState() { return UpdateState(new state()); }
		public virtual void SetState(state State) {}
		public virtual state UpdateState(state State) { return State; }
		#endregion
		#region function: WriteDoCycle
		public virtual void WriteDoCycle(string op, string desc) {
			WriteDoCycle(m_lastCounter, op, desc);
		}
		public virtual void WriteDoCycle(UInt64 counter, string op, string desc) {
			string val = ("DoCycle"
			+	"["
			+		"PC=0x" + counter.ToString("X") + " // " 
			+						counter.ToString().PadLeft(3, '0')
			+	"]"
			);
			
			if(op != "") val +=	" - " + op;
			if(desc != "") val +=	" - " + desc;

			if(_console != null) _console.WriteLine(val);
			else Debug.WriteLine(val);
		}
		public virtual void WriteDoCycle(UInt16 counter, string op, string desc) {
			WriteDoCycle((UInt64)counter, op, desc);
		}
		public virtual void WriteDoCycle(int counter, string op, string desc) {
			WriteDoCycle((UInt64)counter, op, desc);
		}

		public virtual string regInfoString(UInt16 reg, bool brackets = true) {
			string rv = "";
			if(brackets) rv += "[";
			rv += "#:" + reg + ", val:" + m_vRegisters[reg];
			if(brackets) rv += "]";
			return rv;
		}
		public virtual string regInfoString(int reg, bool brackets = true) {
			return regInfoString((UInt16)reg, brackets);
		}
		#endregion
		#region function: HardReset, Reset, SoftReset
		public virtual void HardReset(bool run = false) {
			
		}
		public virtual void Reset() {}
		public virtual void SoftReset(bool run = false) {
			
		}
		#endregion
		protected virtual void DoRuntimeError(string err) {
			OnRuntimeError(new errorEventArgs(err));
		}
		public virtual void Initialize() {}
		//public delegate bool DoCycle_delegate();
		public virtual bool DoCycle_Main() { return false; }
		public virtual bool DoCycle_Debug() { return false; }
		public virtual bool DoCycle_Debug_NoConsole() { return false; }
		public virtual void SoftReset() {}
		public virtual void SetDoCycle(DoCycleDelegate val) {
			DoCycle = val;
		}
		public virtual void SetDoCycle(DoCycleMode val) {
			switch(val) {
				case DoCycleMode.Debug:
					DoCycle = new DoCycleDelegate(DoCycle_Debug);
					break;
				case DoCycleMode.Debug_NoConsole:
					DoCycle = new DoCycleDelegate(DoCycle_Debug_NoConsole);
					break;
				default:
					DoCycle = new DoCycleDelegate(DoCycle_Main);
					break;
			}
		}
		
	}

}