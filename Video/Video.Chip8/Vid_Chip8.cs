/* User: Erin
 * Date: 2/4/2013
 * Time: 5:16 AM
 */
using System;
using System.Collections.Generic;

namespace Emu.Video {
	public class Vid_Chip8 : Vid_Base {
		#region constructors
		public Vid_Chip8(): base("Chip8 Video", 64*32, 16) {}
		#endregion
		public override void Reset() {
			for(UInt32 i=0; i<16; i++)
				base.Reset();
		}
	}
}