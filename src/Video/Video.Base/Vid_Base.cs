/* User: Erin
 * Date: 1/30/2013
 * Time: 7:53 PM
 */
using Emu.Core;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Emu.Video {
	public class Vid_Base {
		#region vars
		public bool updated=false;
		protected Size _resolution = new Size(2, 2);
		public Int32 _resolutionSum = 0;
		protected byte[] m_buffer=null;
		protected Int32 m_bufferSize;
		protected metaData m_meta=null;
		protected Int32 m_videoRegisterCount;
		protected byte[] m_videoRegisters=null;
		#endregion
		#region constructors
		public Vid_Base(string name="") { InitVid_Base(name, 0, 0, _resolution); }
		public Vid_Base(string name, Int32 bufferSize, Int32 registerCount) {
			InitVid_Base(name, bufferSize, registerCount, _resolution);
		}
		public Vid_Base(string name, Size res, Int32 registerCount) {
			InitVid_Base(name, (res.Width*res.Height), registerCount, res);
		}
		protected virtual void InitVid_Base(string name, Int32 bufferSize
						, Int32 registerCount, Size res) {
			m_meta=new metaData(name);
			
			m_bufferSize=bufferSize;
			m_buffer=new byte[bufferSize];

			m_videoRegisterCount=registerCount;
			if(registerCount>0)
				m_videoRegisters=new byte[registerCount];
			
			resolution = res;
			
		}
		#endregion
		#region properties
		public virtual Size resolution {
			get { return _resolution; }
			set {
				if(_resolution != value) {
					_resolution = value;
					//sg.Box("_resolution = " + _resolution.Width + "x" + _resolution.Height);
					OnResolutionChanged(new EventArgs());
				}
			}
		}
		public virtual byte[] buffer {
			get { return m_buffer; }
			set {
				if(m_buffer != value) {
					m_buffer = value;
					OnBufferChanged(new EventArgs());
				}
			}
		}
		public virtual Int32 bufferSize {
			get { return m_bufferSize; }
			set {
				if(m_bufferSize != value) {
					m_bufferSize = value;
					OnBufferSizeChanged(new EventArgs());
				}
			}
		}
		public virtual Int32 videoRegisterCount {
			get { return m_videoRegisterCount; }
		}
		public virtual byte[] videoRegisters {
			get { return m_videoRegisters; }
			set {
				if(m_videoRegisters != value) {
					m_videoRegisters = value;
					OnVideoRegistersChanged(new EventArgs());
				}
			}
		}
		#endregion
		#region events
		//public event EventHandler VideoUpdated;
		public event EventHandler BufferChanged;
		public event EventHandler BufferSizeChanged;
		public event EventHandler ResolutionChanged;
		public event EventHandler VideoRegistersChanged;
		#endregion
		#region On....
		protected virtual void OnBufferChanged(EventArgs e) {
			if(BufferChanged != null) BufferChanged(this, e);
		}
		protected virtual void OnBufferSizeChanged(EventArgs e) {
			if(BufferSizeChanged != null) BufferSizeChanged(this, e);
		}
		protected virtual void OnResolutionChanged(EventArgs e) {
			_resolutionSum = (_resolution.Width * _resolution.Height);
			if(m_bufferSize < _resolutionSum) {
				m_bufferSize = _resolutionSum;
				m_buffer = new byte[_resolutionSum];
			}
			if(ResolutionChanged != null) ResolutionChanged(this, e);
		}
		protected virtual void OnVideoRegistersChanged(EventArgs e) {
			if(VideoRegistersChanged != null) VideoRegistersChanged(this, e);
		}
		#endregion
		#region state stuff
		public virtual state GetState() { return UpdateState(new state()); }
		public virtual void SetState(state val) {
			Int32 i, il;
			//string s;
			
			Msg.Dbg("Vid_Base.SetState");
			
			resolution = val.sizes["VID-RES"];
			
			il = val.ints["VID-BUFFER-SIZ"];
			if(m_buffer.Length < il)
				buffer = new Byte[il];
			Array.Copy(val.byteArrays["VID-BUFFER"], m_buffer, il);
		
			il = val.ints["VID-REG-COUNT"];
			if(m_videoRegisters.Length < il)
				videoRegisters = new Byte[il];
			for(i = 0; i < il; i++)
				m_videoRegisters[i] = val.bytes["VID-REG" + i];
			
		}
		public virtual state UpdateState(state val) {
			val.sizes.Add("VID-RES", _resolution);
			val.ints.Add("VID-BUFFER-SIZ", m_buffer.Length);
			val.byteArrays.Add("VID-BUFFER", m_buffer);
			val.ints.Add("VID-REG-COUNT", m_videoRegisters.Length);
			for(Int32 i = 0, il = m_videoRegisters.Length; i < il; i++)
				val.bytes.Add("VID-REG" + i, m_videoRegisters[i]);
			return val;
		}
		
		#endregion
		#region function: ClearBuffer
		public virtual void ClearBuffer() {
			for(UInt32 i = 0; i < m_bufferSize; i++)
				m_buffer[i] = 0x0;
		}
		#endregion
		#region function: HardReset, Reset, SoftReset
		public virtual void HardReset(bool run = false) {
			
		}
		public virtual void Reset() {
			ClearBuffer();
			if(m_videoRegisters!=null)
				for(UInt32 i=0; i<m_videoRegisterCount; i++)
					m_videoRegisters[i]=0;
		}
		public virtual void SoftReset(bool run = false) {
			
		}
		#endregion
	}
}