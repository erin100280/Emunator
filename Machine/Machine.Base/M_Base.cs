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
using Emu.Core.States;
using Emu.CPU;
using Emu.Display;
using Emu.Memory;
using Emu.Video;
using System;
using System.Diagnostics;
using System.Timers;
#endregion

namespace Emu.Machine {
	public class M_Base {
		#region vars
		protected UInt64 _cycleCount = 0;
		protected bool _stopNow = false;
		protected bool _pauseNow = false;
		protected Timer _timer = null;
		protected Disp_Base m_display=null;
		protected C_Base m_cpu=null;
		protected Mem_Base m_memory=null;
		protected Vid_Base m_video=null;
		protected UInt64 _hertz = 0;
		#endregion
		#region constructors
		public M_Base(string name) { InitM_Base(name); }
		public M_Base(string name, Disp_Base disp) {
			InitM_Base(name, null, null, null, disp);
		}
		public M_Base(string name, C_Base cpu, Mem_Base mem
					, Vid_Base vid, Disp_Base disp) {
			InitM_Base(name, cpu, mem, vid, disp);
		}
		protected virtual void InitM_Base(string name="", C_Base cpu=null
					, Mem_Base mem=null, Vid_Base vid=null, Disp_Base disp=null) {

			meta = new metaData(name);
			_timer = new Timer();
			_timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
			
			m_cpu = cpu;
			m_memory = mem;
			m_video = vid;
			m_display = disp;

		}
		#endregion
		#region properties
		public virtual bool running { get; protected set; }
		public virtual bool paused { get; protected set; }
		public virtual metaData meta { get; protected set; }

		public virtual Disp_Base display{
			get { return m_display; }
			set {
				if(m_display!=value) {
					m_display=value;
					OnDisplayChanged(new EventArgs());
				}
			}
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
		public virtual Mem_Base memory {
			get { return m_memory; }
			set {
				if(m_memory!=value) {
					m_memory=value;
					OnMemoryChanged(new EventArgs());
				}
			}
		}
		public virtual Vid_Base video {
			get { return m_video; }
			set {
				if(m_video!=value) {
					m_video=value;
					OnVideoChanged(new EventArgs());
				}
			}
		}
		public virtual machineState state {
			get { return GetMachineState(); }
			set { SetMachineState(value); }
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
		public virtual double interval { get; set; }
		#endregion
		#region events
		public event EventHandler DisplayChanged;
		public event EventHandler CpuChanged;
		public event EventHandler MemoryChanged;
		public event EventHandler VideoChanged;
		//public event EventHandler TimerElapsed;

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
		protected virtual void OnMemoryChanged(EventArgs e) {
			if(MemoryChanged!=null) MemoryChanged(this, e);
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
		#region function: Pause, Reset, Resume, Run, Stop
		public virtual void Pause() {
			if(running && !paused)
				_pauseNow = true;
		}
		public virtual void Reset() {
			running = paused=false;
			if(m_cpu!=null) m_cpu.Reset();
			if(m_memory!=null) m_memory.Reset();
			if(m_cpu!=null) m_video.Reset();
		}
		public virtual void Resume() {
			if(running && paused) {
				paused=false;
				_timer.Start();
				OnEmulationResumed(new EventArgs());
			}
		}
		public virtual void Run() {
			if(running) return;
			_stopNow = false;
			running = true;
			_timer.Interval = interval;
			_timer.Start();
			OnEmulationStarted(new EventArgs());
		}
		public virtual void Stop() {
			if(running) {
				_stopNow = true;
				if(paused) Resume();
			}
		}
		#endregion
		#region function: GetState, SetState
		protected virtual machineState GetMachineState() {
			return new machineState();
		}
		protected virtual void SetMachineState(machineState state) {}
		#endregion
		#region function: LoadRom
		public virtual void LoadRom(string filename) {
			file fil = file.LoadBinaryStream(filename);
			m_memory.Reset();
			m_memory.SetMemory(fil, m_cpu.romStartAddress);
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
		#region protected function: Do....
		protected virtual void DoCycle() {
			if(m_cpu != null) m_cpu.DoCycle();
		}
		protected virtual void DoInput() {}
		protected virtual void DoGraphics() {
			if(display != null) display.UpdateScreen();
		}
		#endregion
	}
}
