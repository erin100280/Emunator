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
		public delegate Int32 DoCycleDelegate();
		#endregion
		#region vars
		
		#region debug
		public consoleRef _console = null;
		public bool DBG = false;
		public bool DBG_SHOW_COMMAND = false;
		
		#endregion
		public UInt16 PPC = 0x0;	//- previous program counter
		public UInt16 PC = 0x0;		//- program counter
		public UInt16 NPC = 0x0;	//- next start-of-instruction program counter
		public UInt16 I = 0x0;		//- index register
		public byte S = 0x0;			//- stack pointer (always 100 - 1FF)
		public byte A = 0x0;			//- Accumulator
		public byte X = 0x0;			//- X register
		public byte Y = 0x0;			//- Y register
		public byte P = 0x0;			//- processor status
		public byte IR = 0x0;		//- prefetched instruction register

		public UInt64 cycleCount = 0;
		//public UInt64 instructionStart = 0;

		#region DoCycle stuff
		public DoCycleDelegate DoCycle = null;
		public DoCycleDelegate _DoCycle_Main = null;
		public DoCycleDelegate _DoCycle_Debug = null;
		public DoCycleDelegate _DoCycle_Debug_NoConsole = null;
		#endregion

		public byte m_delayTimer;
		public byte m_soundTimer;
		public byte[] m_key;
		public byte[] m_vRegisters=null;
		public ushort m_opcode;
		public ushort m_stackSize;
		public ushort[] m_stack;

		protected int m_ramSize;
		protected UInt64 m_startAddress;
		protected UInt64 m_ramStartAddress;
		protected UInt64 m_romStartAddress;

		protected string m_name;
		protected metaData m_meta=null;

		protected byte[] _programRam = null;
		protected byte[] _workingRam = null;
		protected Mem_Base _workingMemory = null;
		protected Mem_Base _programMemory = null;
		protected byte[] m_buffer = null;
		protected Int32 m_bufferSize = 0;
		protected Vid_Base m_video = null;

		#region vectors: NMI, RST, IRQ
		public UInt16 vectorNMI = 0x0;
		public UInt16 vectorRST = 0x0;
		public UInt16 vectorIRQ = 0x0;
		#endregion
      #endregion
		#region constructors
		public C_Base(string name) { InitC_Base(name); }
		public C_Base(string name, Mem_Base sharedMem, Vid_Base vid) {
			InitC_Base(name, sharedMem, sharedMem, vid);
		}
		public C_Base(string name, Mem_Base sharedMem
						, Mem_Base prgMem, Mem_Base wrkMem, Vid_Base vid) {
			InitC_Base(name, prgMem, wrkMem, vid);
		}
		protected virtual void InitC_Base(string name = ""
						, Mem_Base prgMem = null, Mem_Base wrkMem = null
						, Vid_Base vid=null) {

			DoCycle = new DoCycleDelegate(DoCycle_Main);
			m_meta=new metaData(name);
			programMemory = prgMem;
			workingMemory = wrkMem;
			video=vid;
		}
		#endregion
		#region events
		public event EventHandler BufferChanged;

		public event EventHandler ProgramMemoryChanged;
		public event EventHandler BeforeProgramMemoryChanged;

		public event EventHandler WorkingMemoryChanged;
		public event EventHandler BeforeWorkingMemoryChanged;

		public event EventHandler VideoChanged;
		public event EventHandler BeforeVideoChanged;

		public event EventHandler<errorEventArgs> RuntimeError;
		#endregion
		#region properties
		public virtual byte[] keys { get { return m_key; } }
		public virtual state state {
			get { return GetState(); }
			set { SetState(value); }
		}
		//public virtual byte[] bank{ get { return _workingRam; } }
		public virtual Mem_Base programMemory {
			get { return _programMemory; }
			set {
				if(_programMemory != value) {
					OnBeforeProgramMemoryChanged(new EventArgs());
					byte[] bt = null;
					_programMemory = value;
				
					if(_programMemory != null) {
						bt = _programMemory.bank;
					}
				
					_programRam = bt;
					OnProgramMemoryChanged(new EventArgs());
				}
			}
		}
		public virtual Mem_Base workingMemory {
			get { return _workingMemory; }
			set {
				if(_workingMemory != value) {
					OnBeforeWorkingMemoryChanged(new EventArgs());
					byte[] bt = null;
					_workingMemory = value;
				
					if(_workingMemory != null) {
						bt = _workingMemory.bank;
					}
				
					_workingRam = bt;
					OnWorkingMemoryChanged(new EventArgs());
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
		protected virtual void OnBufferChanged(EventArgs e) {
			m_buffer = video.buffer;
			m_bufferSize = video.bufferSize;
			if(BufferChanged != null) BufferChanged(this, e);
		}

		protected virtual void OnProgramMemoryChanged(EventArgs e) {
			if(ProgramMemoryChanged != null)
				ProgramMemoryChanged(this, e);
		}
		protected virtual void OnBeforeProgramMemoryChanged(EventArgs e) {
			if(BeforeProgramMemoryChanged != null)
				BeforeProgramMemoryChanged(this, e);
		}

				protected virtual void OnWorkingMemoryChanged(EventArgs e) {
			if(WorkingMemoryChanged != null)
				WorkingMemoryChanged(this, e);
		}
		protected virtual void OnBeforeWorkingMemoryChanged(EventArgs e) {
			if(BeforeWorkingMemoryChanged != null)
				BeforeWorkingMemoryChanged(this, e);
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
		protected virtual void OnBeforeVideoChanged(EventArgs e) {
			if(m_video != null) m_video.BufferChanged -= Video_BufferChanged;
			if(BeforeVideoChanged != null) BeforeVideoChanged(this, e);
		}
		protected virtual void OnRuntimeError(errorEventArgs e) {
			if(RuntimeError!=null) RuntimeError(this, e);
		}
		#endregion
		#region function: DoCycle....
		public virtual Int32 DoCycle_Main() {
			Msg.Box("C_Base.DoCycle_Main()");
			return -1;
		}
		public virtual Int32 DoCycle_Debug() {
			Msg.Box("C_Base.DoCycle_Debug()");
			return -1;
		}
		public virtual Int32 DoCycle_Debug_NoConsole() {
			Msg.Box("C_Base.DoCycle_Debug_NoConsole()");
			return -1;
		}
		#endregion
		#region function: SetDoCycle....
		public virtual void SetDoCycle(DoCycleDelegate val) {
			DoCycle = val;
		}
		public virtual void SetDoCycle(DoCycleMode val) {
			//sg.Box("SetDoCycle  -  val = " + val.ToString());
			switch(val) {
				case DoCycleMode.Debug:
					if(_DoCycle_Debug != null) {
						DoCycle = _DoCycle_Debug;
					}
					else {
						DoCycle = new DoCycleDelegate(DoCycle_Debug);
					}
					break;
				case DoCycleMode.Debug_NoConsole:
					if(_DoCycle_Debug_NoConsole != null)
						DoCycle = _DoCycle_Debug_NoConsole;
					else
						DoCycle = new DoCycleDelegate(DoCycle_Debug_NoConsole);
					break;
				default:
					if(_DoCycle_Main != null)
						DoCycle = _DoCycle_Main;
					else
						DoCycle = new DoCycleDelegate(DoCycle_Main);
					break;
			}
		}
		#endregion
		#region function: GetBit, SetBit
		public virtual bool GetBit(byte byt, byte bitNum) {
			bitNum = (byte)(1 << bitNum);
			return (byt & bitNum) != 0;
		}
		public virtual byte SetBit(byte byt, byte bitNum, bool val) {
			bitNum = (byte)(1 << bitNum);
         byt = (byte)(val ? byt | bitNum : byt & ~bitNum);
			return byt;
		}
		#endregion
		#region function: GetStatus, SetStatus
		public virtual bool GetStatus(byte flag) { return (P & flag) != 0; }
		public virtual void SetStatus(byte flag, bool val) {
         P = (byte)(val ? P | flag : P & ~flag);
		}
		public virtual void SetStatus(byte flag, int val) {
         P = (byte)(val!=0 ? P | flag : P & ~flag);
		}
		#endregion
		#region function: GetState, SetState
		public virtual state GetState() { return UpdateState(new state()); }
		public virtual void SetState(state State) {}
		public virtual state UpdateState(state State) { return State; }
		#endregion
		#region function: WriteDoCycle
		public virtual void WriteDoCycle(string op, string desc) {
			WriteDoCycle(PPC, op, desc);
		}
		public virtual void WriteDoCycle(UInt64 counter, string op, string desc) {
			string val = ("DoCycle"
			+	"["
			+		"PC=0x" + counter.ToString("X") + "/" 
			+						counter.ToString().PadLeft(4, '0')
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

		public virtual string AString() {
			return AString(true, false, 0x0);
		}
		public virtual string AString(byte other) {
			return AString(true, true, other);
		}
		public virtual string AString(bool brackets) {
			return AString(brackets, false, 0x0);
		}
		public virtual string AString(bool brackets
						, bool useOther, byte other) {
			
			byte bt = useOther ? other : A;
			string rv = "A";
			//if(useOther) bt = other;
			if(brackets) rv += "[";
			rv += ByteString(bt);
			if(brackets) rv += "]";
			return rv;
		}
		public virtual string XString() {
			return "X[" + ByteString(X) + "]";
		}
		public virtual string YString() {
			return "Y[" + ByteString(Y) + "]";
		}
		public virtual string PString() {
			return "P[" + UShortString(P) + "]";
		}
		public virtual string PCString() {
			return "PC[" + UShortString(PC) + "]";
		}
		public virtual string SString() {
			return "S[" + UShortString(S) + "]";
		}
		public virtual string StatString() { return BitString(P); }
		public virtual string BitString(byte val) {
			return ""
			+ ((val & 0x80) != 0 ? "1" : "0")
			+ ((val & 0x40) != 0 ? "1" : "0")
			+ ((val & 0x20) != 0 ? "1" : "0")
			+ ((val & 0x10) != 0 ? "1" : "0")
			+ ((val & 0x08) != 0 ? "1" : "0")
			+ ((val & 0x04) != 0 ? "1" : "0")
			+ ((val & 0x02) != 0 ? "1" : "0")
			+ ((val & 0x01) != 0 ? "1" : "0");
		}
		public virtual string ByteString(byte bt) {
			string rv = bt.ToString("X").PadLeft(2, '0');
			return rv + "/" + bt.ToString().PadLeft(3, '0');
		}
		public virtual string UShortString(ushort us) {
			string rv = us.ToString("X").PadLeft(4, '0');
			return rv + "/" + us.ToString().PadLeft(5, '0');
		}
		public virtual string regInfoString(UInt16 reg, bool brackets = true) {
			string rv = "";
			if(brackets) rv += "[";
			rv += "#:" + reg + ", val:" + ByteString(m_vRegisters[reg]);
			//rv += "/" + m_vRegisters[reg].ToString().PadLeft(3, '0');
			if(brackets) rv += "]";
			return rv;
		}
		public virtual string regInfoString(int reg, bool brackets = true) {
			return regInfoString((UInt16)reg, brackets);
		}
		#endregion
		#region function: HardReset, SoftReset
		public virtual void HardReset() {}
		public virtual void SoftReset() {
			PC = 0x0; //- reset program counter
		}
		#endregion
		#region function: Initialize
		public virtual void Initialize() {}
		#endregion
		#region error stuff
		protected virtual void DoRuntimeError(string err) {
			OnRuntimeError(new errorEventArgs(err));
		}
		#endregion
	}

}