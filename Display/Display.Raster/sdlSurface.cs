#region header
/* User: Erin
 * Date: 2/14/2013
 * Time: 4:16 AM
 */
#endregion
#region using....
using SdlDotNet.Graphics;
using System;
using System.Drawing;
#endregion

namespace Emu.Display {
	#region meta
	/// <summary>
	/// Description of surface.
	/// </summary>
	#endregion
	public class sdlSurface : Surface {
		#region vars
		#endregion
		#region constructors
		public sdlSurface(Size val) : base(val) { InitSdlSurface(); }
		public sdlSurface(Surface val) : base(val) { InitSdlSurface(); }
		protected virtual void InitSdlSurface() {
		
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#endregion
		#region functions
		#endregion
		#region function: blah
		#endregion
	}
}
