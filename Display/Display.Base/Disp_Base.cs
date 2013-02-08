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
		protected displayMode _displayMode = displayMode.original;
		protected byte[] m_buffer = null;
		protected uint m_bufferSize = 0;
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
					m_video = value;
					if(value != null) {
						m_buffer=value.buffer;
						m_bufferSize = value.bufferSize;
					}
					else {
						m_buffer = null;
						m_bufferSize = 0;
					}
					
					OnVideoChanged(new EventArgs());
				}
			}
		}
		public metaData meta { get { return m_meta; } }
		#endregion
		#region events
		public event EventHandler DisplayModeChanged;
		public event EventHandler VideoChanged;
		#endregion
		#region On....
		protected virtual void OnDisplayModeChanged(EventArgs e) {
			if(DisplayModeChanged != null) DisplayModeChanged(this, e);
		}
		protected virtual void OnVideoChanged(EventArgs e) {
			if(VideoChanged!=null) VideoChanged(this, e);
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
			base.Refresh();
			RefreshScreen();
		}
		#endregion
	}
}