#region header
/* User: Erin
 * Date: 2/4/2013
 * Time: 10:19 PM
 */
#endregion
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
	public class M_Chip8 : M_Base {
		#region vars
		public C_Chip8 cpu_Chip8 = null;
		#endregion
		#region constructors
		public M_Chip8(): base("Machine.Chip8") { InitM_Chip8(); }
		protected virtual void InitM_Chip8() {
			Disp_Raster dr;
			stateName = "CHIP8";
			interval = 1;
			InstructsPerMilisec = 2;
			refreshVal = 8;
			//refreshVal = 10;
			
			_programMemory = new Mem_Chip8();
			_workingMemory = _programMemory;
			m_video = new Vid_Chip8();
			m_cpu = cpu_Chip8 = new C_Chip8(_programMemory, m_video);
			_keyboard = new Keyboard_Chip8(m_cpu.keys);
			m_display = new Disp_Raster(m_video);
			m_video.resolution = new Size(64, 32);
			dr = (Disp_Raster)m_display;
			//m_video.buffer = dr.pixels;
			//_keyboard.ConnectTo(m_display);
			
			//interval = 16.666666666666666666666666666667;
			//interval = 6.6;
		}
		#endregion
		#region events
		#endregion
		#region properties
		
		#endregion
		#region On....
		#endregion
		#region function: Do....
		public override Int32 DoCycle() {
			if(m_cpu != null) {
				Int64 v = ((Int64)cpu.romStartAddress + _programMemory.romSize);
				if(cpu.PC >= (v)) {
			   	return -1;
				}
				else {
					return m_cpu.DoCycle();
				}
			}
			return -1;
		}
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