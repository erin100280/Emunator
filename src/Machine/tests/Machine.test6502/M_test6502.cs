/* User: Erin
 * Date: 2/28/2013
 * Time: 6:48 PM
 */
#region using....
using Emu;
using Emu.Core;
using Emu.CPU;
using Emu.Device.Input.Keyboard;
using Emu.Display;
using Emu.Memory;
using Emu.Video;
using System;
using System.Collections.Generic;
using System.Drawing;
#endregion

namespace Emu.Machine {
	public class M_test6502 : M_Base {
		#region vars
		public C_6502 cpu_test6502 = null;
		#endregion
		#region constructors
		public M_test6502(): base("Machine.test6502") { InitM_test6502(); }
		protected virtual void InitM_test6502() {
			Disp_Raster dr;
			stateName = "test6502";
			interval = 1;
			InstructsPerMilisec = 2;
			refreshVal = 8;
			
			_programMemory = _workingMemory = new Mem_Base(4069);
			m_video = new Vid_Base();
			m_cpu = cpu_test6502 = new C_6502(_programMemory, m_video);
			m_display = new Disp_Raster(m_video);
			m_video.resolution = new Size(64, 32);
			dr = (Disp_Raster)m_display;
		}
		#endregion
		#region events
		#endregion
		#region properties
		
		#endregion
		#region On....
		#endregion
		#region function: Do....
		#endregion
		#region function: HardReset
		public override void HardReset(bool run = false) {
			SoftReset(false);
			base.HardReset(false);
			if(run) Run();
		}
		public override void SoftReset(bool run = false) {
			base.SoftReset(false);
			if(run) Run();
		}
		#endregion
		#region function: Unload
		public override void Unload() {
			//_keyboard.DisconnectFrom(m_display);
			base.Unload();
		}
		#endregion
		public override void StepOver(uint num = 2) { base.StepOver(num); }
	}
}