/* User: Erin
 * Date: 1/31/2013
 * Time: 6:20 AM
 */
using Emu;
using Emu.Core;
using Emu.Core.FileSystem;
using Emu.Core.States;
using Emu.CPU;
using Emu.Display;
using Emu.Memory;
using Emu.Video;
using System;

namespace Emu.Machine {
	public class M_Base {
		#region vars
		protected bool m_running=false;
		protected bool m_paused=false;
		protected Disp_Base m_display=null;
		protected metaData m_meta=null;
		protected C_Base m_cpu=null;
		protected Mem_Base m_memory=null;
		protected Vid_Base m_video=null;
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

			m_meta=new metaData(name);
			m_cpu=cpu;
			m_memory=mem;
			m_video=vid;
			m_display=disp;

		}
		#endregion
		#region properties
		public virtual bool running{ get { return m_running; } }
		public virtual bool paused{ get { return m_paused; } }
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
		#endregion
		#region events
		public event EventHandler DisplayChanged;
		public event EventHandler CpuChanged;
		public event EventHandler MemoryChanged;
		public event EventHandler VideoChanged;
		#endregion
		#region On....
		public virtual void OnDisplayChanged(EventArgs e) {
			if(DisplayChanged!=null) DisplayChanged(this, e);
		}
		public virtual void OnCpuChanged(EventArgs e) {
			if(CpuChanged!=null) CpuChanged(this, e);
		}
		public virtual void OnMemoryChanged(EventArgs e) {
			if(MemoryChanged!=null) MemoryChanged(this, e);
		}
		public virtual void OnVideoChanged(EventArgs e) {
			if(VideoChanged!=null) VideoChanged(this, e);
		}
		#endregion
		#region function: Pause, Reset, Resume, Run, Stop
		public virtual void Pause() { m_paused=m_running; }
		public virtual void Reset() {
			m_running=m_paused=false;
			if(m_cpu!=null) m_cpu.Reset();
			if(m_memory!=null) m_memory.Reset();
			if(m_cpu!=null) m_video.Reset();
		}
		public virtual void Resume() { if(m_running) m_paused=false; }
		public virtual void Run() {
			m_running=true;
			
		}
		public virtual void Stop() { m_running=m_paused=false; }
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
	}
}
