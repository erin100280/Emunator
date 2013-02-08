/* User: Erin
 * Date: 1/30/2013
 * Time: 8:02 PM
 */
using Emu.Video;
using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Emu.Display {
	public class Disp_OLD : UserControl {
		#region vars
		protected byte[] m_buffer = null;
		protected uint m_bufferSize = 0;
		protected Vid_Base m_video = null;
		protected Device m_device3D = null;
		protected PresentParameters m_presentParameters = null;
		protected SwapChain m_swapChain = null;
		#endregion
		#region constructors
		public Display(): base() { InitDisplay(null, null, null, null); }
		public Display(Vid_Base vid): base() {
			InitDisplay(vid, null, null, null);
		}
		public Display(Vid_Base vid, Device dvc): base() {
			InitDisplay(vid, dvc, null, null);
		}
		public Display(Vid_Base vid, Device dvc, SwapChain sc): base() {
			InitDisplay(vid, dvc, sc, null);
		}
		public Display(Vid_Base vid, Device dvc, SwapChain sc
						, PresentParameters pp): base() {
			InitDisplay(vid, dvc, sc, pp);
		}
		protected virtual void InitDisplay(Vid_Base vid, Device dvc, SwapChain sc
		                                   , PresentParameters pp) {
			
			if(dvc==null) dvc = Device.FromPointer(this.Handle);
			if(pp==null) pp = new PresentParameters();
			if(sc==null) sc = new SwapChain(dvc, pp);
			
			m_device3D = dvc;
			m_presentParameters = pp;
			m_swapChain = sc;
			m_video = vid;
		}
		#endregion
		#region properties
		public Device device3D {
			get { return m_device3D; }
			set {
				if(m_device3D != value) {
					m_device3D = value;
					OnDevice3DChanged(new EventArgs());
				}
			}
		}
		public PresentParameters presentParameters {
			get { return m_presentParameters; }
			set {
				if(m_presentParameters != value) {
					m_presentParameters = value;
					OnPresentParametersChanged(new EventArgs());
				}
			}
		}
		public SwapChain swapChain {
			get { return m_swapChain; }
			set {
				if(m_swapChain != value) {
					m_swapChain = value;
					OnSwapChainChanged(new EventArgs());
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
		#endregion
		#region events
		public event EventHandler Device3dChanged;
		public event EventHandler PresentParametersChanged;
		public event EventHandler SwapChainChanged;
		public event EventHandler VideoChanged;
		#endregion
		#region On....
		public virtual void OnDevice3DChanged(EventArgs e) {
			if(Device3dChanged!=null) Device3dChanged(this, e);
		}
		public virtual void OnPresentParametersChanged(EventArgs e) {
			if(PresentParametersChanged!=null) PresentParametersChanged(this, e);
		}
		public virtual void OnSwapChainChanged(EventArgs e) {
			if(SwapChainChanged!=null) SwapChainChanged(this, e);
		}
		public virtual void OnVideoChanged(EventArgs e) {
			if(VideoChanged!=null) VideoChanged(this, e);
		}
		#endregion
		#region protected function: PaintScreen, RenderScreen
		protected virtual void PaintScreen() {
			if(m_video==null) return;
		
		
		}
		protected virtual void RenderScreen() {
		}
		#endregion
		#region function: RefreshScreen, UpdateScreen
		public virtual void RefreshScreen() {
			if(m_video==null) return;
		}
		public virtual void UpdateScreen() {
			if(m_video==null) return;
			RenderScreen();
			PaintScreen();
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