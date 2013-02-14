#region header
/* User: Erin
 * Date: 2/6/2013
 * Time: 5:22 PM
 */
#endregion
#region using
using Emu.Video;
using SdlDotNet;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Windows;
using System;
using System.Drawing;
using System.Windows.Forms;
using Tao.Sdl;
#endregion

namespace Emu.Display {
	public class Disp_Raster : Disp_Base {
		#region vars
		protected SurfaceControl _frontBuffer = null;
		protected Surface _backBuffer = null;
		protected Size _defaultSize = new Size(164, 32);
		protected Surface _background = null;
		protected Box _backgroundBox;
		protected Int32 _black = Color.Black.ToArgb();
		protected Int32 _white = Color.White.ToArgb();
		#endregion
		#region constructors
		public Disp_Raster(): base("RasterDisplay") { InitDisp_Raster(); }
		public Disp_Raster(Vid_Base vid): base("RasterDisplay", vid) {
			InitDisp_Raster();
		}
		protected virtual void InitDisp_Raster() {
			SdlDotNet.Graphics.Video.Initialize();
			//Sdl.SDL_Init(
			_frontBuffer = new SurfaceControl();
			_frontBuffer.BackColor = Color.Pink;
			if(video != null) _frontBuffer.Size = video.resolution;
			else _frontBuffer.Size = _defaultSize;
			_backBuffer = new Surface(_defaultSize);
			Controls.Add(_frontBuffer);
			Refresh();
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		protected override void OnDisplayModeChanged(EventArgs e) {
			Refresh();
			base.OnDisplayModeChanged(e);
		}
		protected override void OnResize(EventArgs e) {
			Refresh();
			base.OnResize(e);
		}
		#endregion
		#region override protected function: PaintStreen, RenderScreen
		protected override void PaintScreen() {
			_frontBuffer.Blit(_backBuffer);
			//essageBox.Show("PaintScreen");
			
		}
		protected override void RenderScreen() {
			unsafe {
				Int32 *pxls = (Int32 *)_backBuffer.Pixels;
				for(int i = 0; i < m_bufferSize; i++) {
					if(m_buffer[i] == 0)
						pxls[i] = _black;
					else
						pxls[i] = _white;
				}
				//essageBox.Show("RenderScreen");
			}
		}
		public virtual void RenderScreen_OLD() {
			unsafe {
				Int32 black = Color.Black.ToArgb();
				Int32 white = Color.White.ToArgb();
				uint ptr = 0;
				//short *pxls = (short *)_backBuffer.Pixels;
				
				Int32 *pxls = (Int32 *)_backBuffer.Pixels;
				_backBuffer.Draw(_backgroundBox, Color.White, false, true);
				for(int iy = 0, ly = _defaultSize.Height; iy < ly; iy++) {
					for(int ix = 0, lx = _defaultSize.Width; ix < lx; ix++) {
						
						if(m_buffer[ptr] == 0)
							pxls[ptr] = black;
						else
							pxls[ptr] = white;
						ptr++;
					}
				}
				MessageBox.Show("RenderScreen");
			}
		}
		#endregion
		#region override function Refresh
		public override void Refresh() {
			base.Refresh();
			if(video != null) {
				SurfaceControl fb = _frontBuffer;
				Size res = video.resolution;
				switch(_displayMode) {
					#region displayMode.original
					case displayMode.original:
						fb.Size = fb.MaximumSize = fb.MinimumSize = res;
						break;
					#endregion
					#region default	
					default:
						break;
					#endregion
				}
				
				fb.Location = new Point(
					((ClientSize.Width / 2) - (fb.Width / 2))
				,	((ClientSize.Height / 2) - (fb.Height / 2))
				);
			}
		}
		#endregion
		#region override function: RefreshScreen, UpdateScreen
		
		#endregion
		
	}
}



