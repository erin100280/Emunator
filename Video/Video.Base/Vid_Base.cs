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
		protected byte[] m_buffer=null;
		protected UInt32 m_bufferSize;
		protected metaData m_meta=null;
		protected UInt32 m_videoRegisterCount;
		protected byte[] m_videoRegisters=null;
		#endregion
		#region constructors
		public Vid_Base(string name="") { InitVid_Base(name, 0, 0, _resolution); }
		public Vid_Base(string name, UInt32 bufferSize, UInt32 registerCount) {
			InitVid_Base(name, bufferSize, registerCount, _resolution);
		}
		public Vid_Base(string name, Size res, UInt32 registerCount) {
			InitVid_Base(name, (UInt32)(res.Width*res.Height), registerCount, res);
		}
		protected virtual void InitVid_Base(string name, UInt32 bufferSize, UInt32 registerCount, Size res) {
			m_meta=new metaData(name);
			
			m_bufferSize=bufferSize;
			if(bufferSize>0)
				m_buffer=new byte[bufferSize];

			m_videoRegisterCount=registerCount;
			if(registerCount>0)
				m_videoRegisters=new byte[registerCount];
			
			_resolution = res;
			
		}
		#endregion
		#region properties
		public virtual Size resolution {
			get { return _resolution; }
			set {
				if(_resolution != value) {
					_resolution = value;
					OnResolutionChanged(new EventArgs());
				}
			}
		}
		public virtual byte[] buffer{ get { return m_buffer; } }
		public virtual UInt32 bufferSize{ get { return m_bufferSize; } }
		public virtual UInt32 videoRegisterCount {
			get { return m_videoRegisterCount; }
		}
		public virtual byte[] videoRegisters { get { return m_videoRegisters; } }
		#endregion
		#region events
		//public event EventHandler VideoUpdated;
		public event EventHandler ResolutionChanged;
		#endregion
		#region On....
		protected virtual void OnResolutionChanged(EventArgs e) {
			if(ResolutionChanged != null) ResolutionChanged(this, e);
		}
		#endregion
		#region function: ClearBuffer
		public virtual void ClearBuffer() {
		
		}
		#endregion
		public virtual void Reset() {
			if(m_buffer!=null)
				for(UInt32 i=0; i<m_bufferSize; i++)
					m_buffer[i]=0;
			if(m_videoRegisters!=null)
				for(UInt32 i=0; i<m_videoRegisterCount; i++)
					m_videoRegisters[i]=0;
		}
	}
}