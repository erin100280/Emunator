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
#endregion

namespace Emu.Machine {
	public class M_Chip8 : M_Base {
		#region vars
		#endregion
		#region constructors
		public M_Chip8(): base("Machine.Chip8") { InitM_Chip8(); }
		protected virtual void InitM_Chip8() {
			Disp_Raster dr;

			interval = 0;
			m_memory=new Mem_Chip8();
			m_video=new Vid_Chip8();
			m_cpu=new C_Chip8(m_memory, m_video);
			_keyboard = new Keyboard_Chip8(m_cpu.keys);
			m_display = new Disp_Raster(m_video);
			dr = (Disp_Raster)m_display;
			//m_video.buffer = dr.pixels;
			_keyboard.ConnectTo(m_display);
			
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
		public override void DoCycle() {
			if(m_cpu != null) {
				Int64 v = ((Int64)cpu.romStartAddress + memory.romSize);
				if(cpu.m_counter >= (v)) {
					Msg.Box("assssa");
					Stop();
			   }
				else m_cpu.DoCycle();
			}
		}
		#endregion
		#region function: Reset
		public override void Reset() {
			base.Reset();
		}
		#endregion
		#region function: Unload
		public override void Unload() {
			_keyboard.DisconnectFrom(m_display);
			base.Unload();
		}
		#endregion
		public override void StepOver(uint num = 2) { base.StepOver(num); }
	}
}