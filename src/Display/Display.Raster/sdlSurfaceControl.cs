#region header
/* User: Erin
 * Date: 2/14/2013
 * Time: 4:23 AM
 */
#endregion
#region using....
using Emu.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Windows;
using System;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Emu.Display {
	#region meta
	/// <summary>
	/// Description of dslSurfaceControl.
	/// </summary>
	#endregion
	public class sdlSurfaceControl : SurfaceControl {
		#region vars
		public void_Surface_delegate Blit_delegate;
		
		public point_delegate GetLocation;
		public size_delegate GetMaximumSize;
		public size_delegate GetMinimumSize;
		public size_delegate GetSize;

		public void_point_delegate SetLocation;
		public void_size_delegate SetMaximumSize;
		public void_size_delegate SetMinimumSize;
		public void_size_delegate SetSize;
		#endregion
		#region constructors
		public sdlSurfaceControl() { InitSdlSurfaceControl(); }
		protected virtual void InitSdlSurfaceControl() {
			Blit_delegate = new void_Surface_delegate(Blit);
			
			GetLocation = new point_delegate(GetLocation_Safe);
			GetMaximumSize = new size_delegate(GetMaximumSize_Safe);
			GetMinimumSize = new size_delegate(GetMinimumSize_Safe);
			GetSize = new size_delegate(GetSize_Safe);

			SetLocation = new void_point_delegate(SetLocation_Safe);
			SetMaximumSize = new void_size_delegate(SetMaximumSize_Safe);
			SetMinimumSize = new void_size_delegate(SetMinimumSize_Safe);
			SetSize = new void_size_delegate(SetSize_Safe);
		
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#region HMM?
/*
		protected override void OnInvalidated(InvalidateEventArgs e) {
			Msg.Dbg("MainForm - OnInvalidated");
		}
		protected override void OnPaint(PaintEventArgs e) {
			Msg.Dbg("MainForm - OnPaint");
		}
		protected override void OnPaintBackground(PaintEventArgs e) {
			Msg.Dbg("MainForm - OnPaintBackground");
		}
		protected override void OnValidated(EventArgs e) {
			Msg.Dbg("MainForm - OnValidated");
		}
//*/
		#endregion
		#endregion
		#region function: Get...._Safe
		protected virtual Point GetLocation_Safe() {
			return this.Location;
		}
		protected virtual Size GetMaximumSize_Safe() {
			return this.MaximumSize;
		}
		protected virtual Size GetMinimumSize_Safe() {
			return this.MinimumSize;
		}
		protected virtual Size GetSize_Safe() {
			return this.Size;
		}
		#endregion
		#region function: Set...._Safe
		protected virtual void SetLocation_Safe(Point val) {
			this.Location = val;
		}
		protected virtual void SetMaximumSize_Safe(Size val) {
			this.MaximumSize = val;
		}
		protected virtual void SetMinimumSize_Safe(Size val) {
			this.MinimumSize = val;
		}
		protected virtual void SetSize_Safe(Size val) {
			this.Size = val;
		}
		#endregion
		#region function: blah
		#endregion
	}
}
