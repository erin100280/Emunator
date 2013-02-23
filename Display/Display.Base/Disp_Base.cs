/* User: Erin
 * Date: 1/30/2013
 * Time: 8:02 PM
 */
using Emu.Core;
using Emu.Video;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Emu.Display {
	public class Disp_Base : UserControl {
		#region vars
		protected Int32 _displayArg =2;
		protected displayMode _displayMode = displayMode.original;
		protected Size _curResolution;
		protected byte[] m_buffer = null;
		protected int m_bufferSize = 0;
		protected Vid_Base m_video = null;
		protected metaData m_meta = null;
		#endregion
		#region constructors
		public Disp_Base(): base() { InitDisplay("", null); }
		public Disp_Base(string name): base() { InitDisplay(name, null); }
		public Disp_Base(string name, Vid_Base vid): base() {
			InitDisplay(name, vid);
		}
		protected virtual void InitDisplay(string name, Vid_Base vid) {
			BackColor=Color.Black;
			m_meta = new metaData(name);
			video = vid;
		}
		#endregion
		#region properties
		public Int32 displayArg {
			get { return _displayArg; }
			set {
				if(_displayArg != value) {
					_displayArg = value;
					OnDisplayArgChanged(new EventArgs());
				}
			}
		}
		public displayMode displayMode {
			get { return _displayMode; }
			set {
				if(_displayMode != value) {
					_displayMode = value;
					OnDisplayModeChanged(new EventArgs());
				}
			}
		}
		public Video.Vid_Base video {
			get { return m_video; }
			set {
				if(m_video != value) {
					if(m_video != null)
						m_video.ResolutionChanged -= Video_ResolutionChanged;
					m_video = value;
					if(value != null) {
						m_buffer=value.buffer;
						m_bufferSize = value.bufferSize;
					}
					else {
						m_buffer = null;
						m_bufferSize = 0;
					}
					
					Video_ResolutionChanged(video, new EventArgs());
					m_video.ResolutionChanged += Video_ResolutionChanged;
					OnVideoChanged(new EventArgs());
				}
			}
		}
		public metaData meta { get { return m_meta; } }
		#endregion
		#region events
		public event EventHandler DisplayArgChanged;
		public event EventHandler DisplayModeChanged;
		public event EventHandler ResolutionChanged;
		public event EventHandler VideoChanged;
		#endregion
		#region event handlers
		protected virtual void Video_ResolutionChanged(object obj, EventArgs e) {
			OnResolutionChanged(e);
		}
		#endregion
		#region On....
		protected virtual void OnDisplayArgChanged(EventArgs e) {
			Refresh();
			if(DisplayArgChanged != null) DisplayArgChanged(this, e);
		}
		protected virtual void OnDisplayModeChanged(EventArgs e) {
			Refresh();
			if(DisplayModeChanged != null) DisplayModeChanged(this, e);
		}
		protected virtual void OnVideoChanged(EventArgs e) {
			Refresh();
			if(VideoChanged!=null) VideoChanged(this, e);
		}
		protected virtual void OnResolutionChanged(EventArgs e) {
			//sg.Box("buff changed");
			Refresh();
			if(ResolutionChanged != null) ResolutionChanged(this, e);
		}
		#endregion
		#region protected function: PaintScreen, RenderScreen
		protected virtual void PaintScreen() {}
		protected virtual void RenderScreen() {}
		#endregion
		#region function: RefreshScreen, UpdateScreen
		public virtual void RefreshScreen() {
			if(m_video==null) return;
			PaintScreen();
		}
		public virtual void UpdateScreen() {
			if(m_video==null) return;
			RenderScreen();
			RefreshScreen();
		}
		#endregion
		#region override function: Refresh
		public override void Refresh() {
			void_delegate vd;
			m_buffer = video.buffer;
			if(base.InvokeRequired) {
				vd = new void_delegate(base.Refresh);
				this.Invoke(vd);
			}
			else base.Refresh();
			RefreshScreen();
			//void_delegate vd;
		}
		public virtual void Tester(object obj) {}
		#endregion
	}
}