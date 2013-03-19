#region header
/* User: Erin
 * Date: 2/28/2013
 * Time: 6:48 PM
 */
#endregion
#region using....
using Emu;
using Emu.Core;
using Emu.Core.FileSystem;
using Emu.Core.Settings;
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
	public class M_C64 : M_Base {
		#region vars
		public C_6502 cpu_6502 = null;
		public Mem_ROM _basicROM;
		public Mem_ROM _kernalROM;
		#endregion
		#region constructors
		public M_C64(): base("Machine.C64") { InitM_C64(); }
		protected virtual void InitM_C64() {
			//byte[] bts;
			Disp_Raster dr;
			stateName = "C64";
			interval = 1;
			InstructsPerMilisec = 2;
			refreshVal = 8;
			_programMemory = _workingMemory = new Mem_Base(80000);

			#region Connect ROMs
			#region Basic
			_basicROM = new Mem_ROM(
				_programMemory
			,	file.LoadBytes(dir.Join(
					_pathSettings.bios_commodore_c64
				,	"Basic.bin"
				))
				,	0xA000, (0xBFFF - 0xA000), 0x0000
			);
			#endregion
			#region Kernal
			_kernalROM = new Mem_ROM(
				_programMemory
			,	file.LoadBytes(dir.Join(
					_pathSettings.bios_commodore_c64
				,	"Kernal.bin"
				))
				,	0xE000, (0xFFFF - 0xE000), 0x0000
			);
			#endregion
			#endregion

			m_video = new Vid_Base();
			m_cpu = cpu_6502 = new C_6502(_programMemory, m_video);
			m_display = new Disp_Raster(m_video);
			m_video.resolution = new Size(320, 200);
			dr = (Disp_Raster)m_display;
			m_cpu.PC = (ushort)(
				(_programMemory._bank[0xFFFD] << 8)
			|	_programMemory._bank[0xFFFC]
			);
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
		#region function: HardReset, SoftReset
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
		#region function: StepOver
		public override void StepOver(uint num = 2) { base.StepOver(num); }
		#endregion
		#region function: Unload
		public override void Unload() {
			//_keyboard.DisconnectFrom(m_display);
			base.Unload();
		}
		#endregion
	}
}