#region meta
/* User: Erin
 * Date: 1/31/2013
 * Time: 6:20 AM
 */
#endregion
#region using
using Emu;
using Emu.Core;
using Emu.Core.FileSystem;
using Emu.Core.Settings;
using Emu.CPU;
using Emu.Device.Input.Keyboard;
using Emu.Display;
using Emu.Memory;
using Emu.Video;
using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
#endregion

namespace Emu.Machine {
	public class M_Base {
		#region vars
		public string stateName = "base";
		public UInt32 InstructsPerMilisec = 0;
		protected Keyboard_Base _keyboard = null;
		protected Thread _thread = null;
		protected ThreadStart _threadStart = null;
		protected UInt64 _cycleCount = 0;
		protected bool _stopNow = false;
		protected bool _pauseNow = false;
		protected System.Timers.Timer _timer = null;
		protected Disp_Base m_display=null;
		protected C_Base m_cpu=null;
		protected Vid_Base m_video=null;
		protected UInt64 _hertz = 0;
		
		public Mem_Base _programMemory = null;
		public Mem_Base _workingMemory = null;

		public long nextTick = 0;
		public UInt16 refreshCount = 0;
		public UInt16 refreshVal = 0;
		public Int32 interval;
		
		public bool rewindEnabled = true;
		public bool rewindPaused = true;
		public bool rewindOn = false;

		public int rewindLen = 0;
		public int rewindIndex = 0;
		public int rewindCount = 0;
		public int rewindMax = 60;
		public state[] rewindStates = null;
		#endregion
		#region constructors
		public M_Base(string name) { InitM_Base(name); }
		public M_Base(string name, Disp_Base disp) {
			InitM_Base(name, null, null, null, null, disp);
		}
		public M_Base(string name, C_Base cpu, Mem_Base mem
					, Vid_Base vid, Disp_Base disp) {
			InitM_Base(name, cpu, mem, mem, vid, disp);
		}
		public M_Base(string name, C_Base cpu, Mem_Base prgMem, Mem_Base wrkMem
					, Vid_Base vid, Disp_Base disp) {
			InitM_Base(name, cpu, prgMem, wrkMem, vid, disp);
		}
		protected virtual void InitM_Base(string name="", C_Base cpu=null
					, Mem_Base prgMem = null, Mem_Base wrkMem = null
					, Vid_Base vid=null, Disp_Base disp=null) {

			meta = new metaData(name);
			_timer = new System.Timers.Timer();
			_timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
			
			m_cpu = cpu;
			_programMemory = prgMem;
			_workingMemory = wrkMem;
			m_video = vid;
			m_display = disp;

			//ThreadStart ts = new ThreadStart(
			interval = 0;
			_threadStart = new ThreadStart(this.Runner);
			
			rewindStates = new state[rewindMax];
		
		}
		#endregion
		#region properties
		public virtual bool running { get; protected set; }
		public virtual bool paused { get; protected set; }
		public virtual metaData meta { get; protected set; }
		public virtual state state {
			get { return GetState(); }
			set { SetState(value); }
		}

		public virtual Disp_Base display{
			get { return m_display; }
			set {
				if(m_display!=value) {
					m_display=value;
					OnDisplayChanged(new EventArgs());
				}
			}
		}
		public virtual Int32 displayArg {
			get { return m_display.displayArg; }
			set { m_display.displayArg = value; }
		}
		public virtual displaySizeMode displaySizeMode {
			get { return m_display.displaySizeMode; }
			set { m_display.displaySizeMode = value; }
		}

		public virtual C_Base cpu {
			get { return m_cpu; }
			set {
				if(m_cpu!=value) {
					m_cpu=value;
					OnCpuChanged(new EventArgs());
				}
			}
		}
		public virtual Keyboard_Base keyboard { get { return _keyboard; } }
		public virtual Vid_Base video {
			get { return m_video; }
			set {
				if(m_video!=value) {
					m_video=value;
					OnVideoChanged(new EventArgs());
				}
			}
		}
		
		public virtual Mem_Base programMemory {
			get { return _programMemory; }
			set {
				if(_programMemory != value) {
					OnBeforeProgramMemoryChanged(new EventArgs());
					_programMemory = value;
					OnProgramMemoryChanged(new EventArgs());
				}
			}
		}
		public virtual Mem_Base workingMemory {
			get { return _workingMemory; }
			set {
				if(_workingMemory != value) {
					OnBeforeWorkingMemoryChanged(new EventArgs());
					_workingMemory = value;
					OnWorkingMemoryChanged(new EventArgs());
				}
			}
		}

		public virtual UInt64 defaultHertz { get; protected set; }
		public virtual UInt64 hertz {
			get { return _hertz; }
			set {
				if(_hertz != value) {
					_hertz = value;
					
				}
			}
		}
		#endregion
		#region events
		public event EventHandler DisplayChanged;
		public event EventHandler CpuChanged;
		public event EventHandler VideoChanged;
		//public event EventHandler TimerElapsed;

		public event EventHandler ProgramMemoryChanged;
		public event EventHandler BeforeProgramMemoryChanged;
		public event EventHandler WorkingMemoryChanged;
		public event EventHandler BeforeWorkingMemoryChanged;

		public event EventHandler EmulationPaused;
		public event EventHandler EmulationResumed;
		public event EventHandler EmulationStarted;
		public event EventHandler EmulationStopped;
		protected event EventHandler _EmulationPaused;
		protected event EventHandler _EmulationResumed;
		protected event EventHandler _EmulationStarted;
		protected event EventHandler _EmulationStopped;
		#endregion
		#region On....
		protected virtual void OnDisplayChanged(EventArgs e) {
			if(DisplayChanged!=null) DisplayChanged(this, e);
		}
		protected virtual void OnCpuChanged(EventArgs e) {
			if(CpuChanged!=null) CpuChanged(this, e);
		}
		protected virtual void OnVideoChanged(EventArgs e) {
			if(VideoChanged!=null) VideoChanged(this, e);
		}
		protected virtual void OnTimerElapsed(EventArgs e) {
			_timer.Stop();
			//if(TimerElapsed != null) TimerElapsed(this, e);
			//ebug.WriteLine("cycle# " + _cycleCount++);
			
			#region handle pauseNow & stopNow
			if(_stopNow) {
				Debug.WriteLine("cycle - _stopNow");
				_stopNow = _pauseNow = running = false;
				OnEmulationStopped(new EventArgs());
				return;
			}
			if(_pauseNow) {
				Debug.WriteLine("cycle - _pauseNow");
				_pauseNow = false;
				paused = true;
				OnEmulationPaused(new EventArgs());
				return;
			}
			#endregion
			DoInput();
			DoCycle();
			DoGraphics();
			_timer.Start();
		}

		protected virtual void OnProgramMemoryChanged(EventArgs e) {
			if(ProgramMemoryChanged != null) ProgramMemoryChanged(this, e);
		}
		protected virtual void OnBeforeProgramMemoryChanged(EventArgs e) {
			if(BeforeProgramMemoryChanged != null)
				BeforeProgramMemoryChanged(this, e);
		}
		protected virtual void OnWorkingMemoryChanged(EventArgs e) {
			if(WorkingMemoryChanged != null) WorkingMemoryChanged(this, e);
		}
		protected virtual void OnBeforeWorkingMemoryChanged(EventArgs e) {
			if(BeforeWorkingMemoryChanged != null)
				BeforeWorkingMemoryChanged(this, e);
		}

		protected virtual void OnEmulationPaused(EventArgs e) {
			if(_EmulationPaused != null) _EmulationPaused(this, e);
			if(EmulationPaused != null) EmulationPaused(this, e);
		}
		protected virtual void OnEmulationResumed(EventArgs e) {
			if(_EmulationResumed != null) _EmulationResumed(this, e);
			if(EmulationResumed != null) EmulationResumed(this, e);
		}
		protected virtual void OnEmulationStarted(EventArgs e) {
			if(_EmulationStarted != null) _EmulationStarted(this, e);
			if(EmulationStarted != null) EmulationStarted(this, e);
		}
		protected virtual void OnEmulationStopped(EventArgs e) {
			if(_EmulationStopped != null) _EmulationStopped(this, e);
			if(EmulationStopped != null) EmulationStopped(this, e);
		}
		#endregion
		#region function: Pause, Reset, Resume, Run, StepInto, StepOver, Stop
		public virtual void Pause() {
			if(running && !paused) {
				int i = 0, to = 1000;
				_pauseNow = true;
				while(!paused && i++ < to) { Application.DoEvents(); }
				if(i == to - 1) {
					Msg.Box("WOW!");
				}
			}
				
		}
		public virtual void Resume() {
			if(running && !paused) return;
			_thread = CreateThread();
			paused = false;
			_thread.Start();
			OnEmulationResumed(new EventArgs());
		}
		public virtual void Run() {
			if(running) return;
			_thread = CreateThread();
			running = true;
			paused = false;
			_thread.Start();
			OnEmulationStarted(new EventArgs());
		}
		public virtual void StepInto() {
			if(running && !paused) Pause();
			if(!running) {
				running = true;
				paused = true;
				OnEmulationStarted(new EventArgs());
			}
			DoInput();
			DoCycle();
			DoGraphics();
		}
		public virtual void StepOver(UInt32 num = 1) {
			if(running && !paused) {
				_pauseNow = true;
				return;
			}
			else if(!running) {
				running = true;
				paused = true;
				OnEmulationStarted(new EventArgs());
			}
			m_cpu.PC += 1;
		}
		public virtual void Stop() {
			if(running) {
				Pause();
				paused = _pauseNow = running = _stopNow = false;
				SoftReset();
			}
		}
		#endregion
		#region function: LoadRom
		public virtual void LoadRom(string filename) {
			//sg.Box("m_cpu.romStartAddress = " + m_cpu.romStartAddress);
			file fil = file.LoadBinaryStream(filename);
			_programMemory.HardReset();
			_programMemory.SetMemory(fil, m_cpu.romStartAddress);
		}
		#endregion
		#region function: Unload
		public virtual void Unload() {
			if(m_display != null) {
				if(m_display.Parent != null)
					m_display.Parent.Controls.Remove(m_display);
				m_display.Dispose();
				m_display = null;
			}
		}
		#endregion
		#region event handlers
		protected void _timer_Elapsed(object sender, EventArgs e) {
			OnTimerElapsed(e);
		}
		#endregion
		#region delegates
		public delegate void DoCycle_delegate();
		public delegate void DoInput_delegate();
		public delegate void DoGraphics_delegate();
		public delegate void Runner_delegate();
		#endregion
		#region state stuff
		public virtual state GetState() {
			return UpdateState(new state(), false);
		}
		public virtual state GetState(bool doPause) {
			return UpdateState(new state(), doPause);
		}
		public virtual void SetState(state State) {
			if(cpu != null) cpu.SetState(State);
			if(_programMemory != null) _programMemory.SetState(State);
			if(_workingMemory != null && _workingMemory != _programMemory)
				_workingMemory.SetState(State);
			if(video != null) video.SetState(State);
			else Msg.Box("PP");
		}
		public virtual state UpdateState(state State) {
			return UpdateState(State, false);
		}
		public virtual state UpdateState(state State, bool doPause) {
			bool pause = paused;
			if(doPause && running && !paused) Pause();
			
			State.name = stateName;
			if(cpu != null) cpu.UpdateState(State);
			if(_programMemory != null) _programMemory.UpdateState(State);
			if(_workingMemory != null && _workingMemory != _programMemory)
				_workingMemory.UpdateState(State);
			if(video != null) video.UpdateState(State);
			
			if(doPause && running && !pause) Resume();
			
			return State;
		}
		#endregion
		#region protected function: Do....
		public virtual Int32 DoCycle() {
			if(m_cpu != null)
				return m_cpu.DoCycle.Invoke();
			return -1;
		}
		public virtual void DoInput() {}
		public virtual void DoGraphics() {
			if(refreshCount++ >= refreshVal) {
				refreshCount = 0;
				if(display != null && video.updated) {
					if(rewindEnabled) {
						rewindStates[rewindIndex] = GetState(false);
						if(rewindCount < rewindMax) rewindCount++;
						rewindIndex++;
						if(rewindIndex >= rewindMax) rewindIndex = 0;
					}
					display.UpdateScreen();
					video.updated = false;
				}
			}
		}
		public virtual void DoGraphicsNow() {
			if(display != null) {
				display.UpdateScreen();
				video.updated = false;
			}
		}
		#endregion
		#region protected function: CreateThread, Runner
		protected virtual Thread CreateThread() {
			//if(_thread != null) {}
			return new Thread(_threadStart);
		}
		protected virtual void Runner() {
			//sg.Dbg("interval = " + interval);
			//if(m_cpu != null) m_cpu.DoCycle();
			bool go = true;
			long di = Convert.ToInt64(interval);
			Int32 iCnt;
			while(go) {
				if(true) {
					if(_stopNow) {
						_pauseNow = _stopNow = go = false;
						running = false;
						this.cpu.SoftReset();
					}
					else if(_pauseNow) {
						_pauseNow = _stopNow = go = false;
						paused = true;
					}
					else {
						if(rewindOn) {
							if(rewindCount >= 1 && running) {
								if(rewindLen == -1 || rewindLen > 0) {
									if(rewindLen > 0) rewindLen--;
									rewindCount--;
									rewindIndex--;
									//Msg.Dbg("rewindCount = " + rewindCount + " - rewindIndex = "
									//        + rewindIndex + "  -  rewindLen = " + rewindLen);
									if(rewindIndex < 0) rewindIndex = rewindCount;
									SetState(rewindStates[rewindIndex]);
									//sg.Dbg("Rewind");
									DoGraphicsNow();
									Thread.Sleep(20);

								}
								else rewindOn = false;
							}
							else rewindOn = false;
						}
						else {
							iCnt = 0;
							DoInput();
							while(go && iCnt++ < InstructsPerMilisec) {
								if(DoCycle() < 1) {
									Msg.Box("Program Stopped!!!");
									_pauseNow = _stopNow = go = false;
									running = false;
									cpu.SoftReset();
								}
								DoGraphics();
							}
						}
						Thread.Sleep(interval);
					}
				}
			}
		
			//sg.Box("wow");
			//sg.Box("Running = " + running);
			//sg.Box("paused = " + paused);
		}
		#endregion
		#region function: HardReset, Reset, SoftReset
		public virtual void HardReset(bool run = false) {
			SoftReset();
			running = paused=false;

			if(m_cpu!=null) m_cpu.HardReset();
			if(_programMemory != null) _programMemory.HardReset();
			if(_workingMemory != null) _workingMemory.HardReset();
			if(m_cpu!=null) m_video.Reset();

			if(run) Run();
		}
		public virtual void SoftReset(bool run = false) {
			
		}
		#endregion
		#region function: Rewind
		public virtual bool Rewind() { return Rewind(-1); }
		public virtual bool Rewind(int count) {
			Msg.Dbg("RW");
			if(count > rewindMax) count = rewindMax;
			if(count > rewindCount) count = rewindCount;
			if(rewindCount >= 1 && running) {
				rewindLen = count;
				rewindOn = true;
				return true;
			}
			return false;
		}
		#endregion
	}
}
