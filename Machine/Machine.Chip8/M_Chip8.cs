/* User: Erin
 * Date: 2/4/2013
 * Time: 10:19 PM
 */
using Emu;
using Emu.Core;
using Emu.Core.States;
using Emu.CPU;
using Emu.Display;
using Emu.Memory;
using Emu.Video;
using System;
using System.Collections.Generic;

namespace Emu.Machine {

	public class M_Chip8 : M_Base {
		#region vars
		#endregion
		#region constructors
		public M_Chip8(): base("Chip8 Machine") { InitM_Chip8(); }
		protected virtual void InitM_Chip8() {
			interval = 100;
			
			m_memory=new Mem_Chip8();
			m_video=new Vid_Chip8();
			m_cpu=new C_Chip8(m_memory, m_video);
			m_display=new Disp_Raster(m_video);
		}
		#endregion
		#region events
		#endregion
		#region properties
		
		#endregion
		#region On....
		#endregion
		#region function: Reset
		public override void Reset() {
			base.Reset();
		}
		#endregion
	}
}