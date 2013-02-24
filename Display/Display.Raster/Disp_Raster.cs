#region header
/* User: Erin
 * Date: 2/6/2013
 * Time: 5:22 PM
 */
#endregion
#region using
using Emu.Core;
using Emu.Core.Settings;
using Emu.Video;
using SdlDotNet;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Windows;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Tao.Sdl;
#endregion

namespace Emu.Display {
	public class Disp_Raster : Disp_Base {
		#region vars
		protected sdlSurfaceControl _frontBuffer = null;
		protected sdlSurface _backBuffer = null;
		protected Size _defaultSize = new Size(364, 32);
		protected sdlSurface _background = null;
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
			_frontBuffer = new sdlSurfaceControl();
			_frontBuffer.BackColor = Color.Pink;
			if(video != null) _frontBuffer.Size = video.resolution;
			else _frontBuffer.Size = _defaultSize;
			_backBuffer = new sdlSurface(_frontBuffer.Size);
			Controls.Add(_frontBuffer);
			Refresh();
		}
		#endregion
		#region events
		public event EventHandler BackBufferChanged;
		public event EventHandler BeforeBackBufferChanged;
		public event EventHandler BeforeFrontBufferChanged;
		public event EventHandler FrontBufferChanged;
		#endregion
		#region properties
		public virtual sdlSurface backBuffer {
			get { return _backBuffer; }
			set {
				if(_backBuffer != value) {
					EventArgs e = new EventArgs();
					OnBeforeBackBufferChanged(e);
					_backBuffer = value;
					OnBackBufferChanged(e);
				}
			}
		}
		public virtual sdlSurfaceControl frontBuffer {
			get { return _frontBuffer; }
			set {
				if(_frontBuffer != value) {
					EventArgs e = new EventArgs();
					OnBeforeFrontBufferChanged(e);
					_frontBuffer = value;
					OnFrontBufferChanged(e);
				}
			}
		}
		#endregion
		#region On....
		protected virtual void OnBeforeBackBufferChanged(EventArgs e) {
			if(BeforeBackBufferChanged != null) BeforeBackBufferChanged(this, e);
		}
		protected virtual void OnBeforeFrontBufferChanged(EventArgs e) {
			if(BeforeFrontBufferChanged != null) BeforeFrontBufferChanged(this, e);
		}
		protected virtual void OnBackBufferChanged(EventArgs e) {
			if(BackBufferChanged != null) BackBufferChanged(this, e);
		}
		protected override void OnDisplayArgChanged(EventArgs e) {
			Refresh();
			base.OnDisplayArgChanged(e);
		}
		protected override void OnDisplayModeChanged(EventArgs e) {
			Refresh();
			base.OnDisplayModeChanged(e);
		}
		protected virtual void OnFrontBufferChanged(EventArgs e) {
			if(FrontBufferChanged != null) FrontBufferChanged(this, e);
		}
		protected override void OnResize(EventArgs e) {
			Refresh();
			base.OnResize(e);
		}
		protected override void OnResolutionChanged(EventArgs e) {
			base.OnResolutionChanged(e);
		}
		
		
		#endregion
		#region override protected function: PaintStreen, RenderScreen
		protected override void PaintScreen() {
			if(_frontBuffer != null) {
				Surface img;
				img = _backBuffer.CreateStretchedSurface(_frontBuffer.Size);
				
				if(_frontBuffer.InvokeRequired) {
					Size siz = (Size)this.Invoke(_frontBuffer.GetSize);
					if(siz == _backBuffer.Size)
						this.Invoke(_frontBuffer.Blit_delegate, _backBuffer);
					else
						this.Invoke(_frontBuffer.Blit_delegate, img);
				}
				else {
					if(_frontBuffer.Size == _backBuffer.Size)
						_frontBuffer.Blit(_backBuffer);
					else _frontBuffer.Blit(img);
				}
				img.Dispose();
			}
			//Debug.//riteLine("PaintScreen");
		}
		protected override void RenderScreen() {
			switch(_displayMode) {
				#region displaySizeMode - original, times
				case displaySizeMode.original: case displaySizeMode.times:
					unsafe {
						_backBuffer.Lock();
						Int32 *pxls = (Int32 *)_backBuffer.Pixels;
						for(int i = 0; i < m_bufferSize; i++) {
							if(m_buffer[i] == 0)
								pxls[i] = _black;
							else
								pxls[i] = _white;
						}
						_backBuffer.Unlock();
						//essageBox.Show("RenderScreen");
					}
					break;
				#endregion
				#region
				case displaySizeMode.stretch:
				
					break;
				#endregion
			}
			//Debug.//riteLine("RenderScreen");
		}
		#endregion
		#region override function Refresh
		public override void Refresh() {
			base.Refresh();
			if(video != null && _frontBuffer != null) {
				sdlSurface bb = _backBuffer;
				sdlSurfaceControl fb = _frontBuffer;
				Size res = video.resolution;
				Size sz = res;
				
				if(bb.Size != res) {
					bb.Dispose();
					bb = _backBuffer = new sdlSurface(res);
				}

				switch(_displayMode) {
					#region displaySizeMode.original
					case displaySizeMode.original:
						break;
					#endregion
					#region displaySizeMode.stretch
					case displaySizeMode.times:
						if(_displayArg < 1) _displayArg = 1;
						sz = new Size(
							res.Width * _displayArg
						,	res.Height * _displayArg
						);
						break;
					#endregion
					#region default	
					default:
						break;
					#endregion
				}

				if(fb.InvokeRequired) {
					Size sz2 = (Size)this.Invoke(fb.GetSize);
					
					object objs = new object[]{ sz };
					this.Invoke(fb.SetMaximumSize, sz);
					this.Invoke(fb.SetMinimumSize, sz);
					this.Invoke(fb.SetSize, sz);
					
					this.Invoke(fb.SetLocation
					,	new Point(
							((ClientSize.Width / 2) - (sz2.Width / 2))
						,	((ClientSize.Height / 2) - (sz2.Height / 2))
						)
	            );
					//sg.Box("pow!");
				}
				else {
					fb.Size = fb.MaximumSize = fb.MinimumSize = sz;
					fb.Location = new Point(
						((ClientSize.Width / 2) - (fb.Width / 2))
					,	((ClientSize.Height / 2) - (fb.Height / 2))
					);
				}
			}
		}
		#endregion
		#region override function: RefreshScreen, UpdateScreen
		
		#endregion
	}
}



