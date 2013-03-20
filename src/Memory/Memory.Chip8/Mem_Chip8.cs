﻿/* User: Erin
 * Date: 2/2/2013
 * Time: 5:51 PM
 */
using Emu.Core;
using System;
using System.Collections.Generic;

namespace Emu.Memory {
	public class Mem_Chip8 : Mem_Base {
		#region static vars: _defaultFontSet, _defaultSFontSet
		#region _defaultFontSet
		protected static byte[] _defaultFontSet = {
			0xF0, 0x90, 0x90, 0x90, 0xF0 //0
		,	0x20, 0x60, 0x20, 0x20, 0x70 //1
		,	0xF0, 0x10, 0xF0, 0x80, 0xF0 //2
		,	0xF0, 0x10, 0xF0, 0x10, 0xF0 //3
		,	0x90, 0x90, 0xF0, 0x10, 0x10 //4
		,	0xF0, 0x80, 0xF0, 0x10, 0xF0 //5
		,	0xF0, 0x80, 0xF0, 0x90, 0xF0 //6
		,	0xF0, 0x10, 0x20, 0x40, 0x40 //7
		,	0xF0, 0x90, 0xF0, 0x90, 0xF0 //8
		,	0xF0, 0x90, 0xF0, 0x10, 0xF0 //9
		,	0xF0, 0x90, 0xF0, 0x90, 0x90 //A
		,	0xE0, 0x90, 0xE0, 0x90, 0xE0 //B
		,	0xF0, 0x80, 0x80, 0x80, 0xF0 //C
		,	0xE0, 0x90, 0x90, 0x90, 0xE0 //D
		,	0xF0, 0x80, 0xF0, 0x80, 0xF0 //E
		,	0xF0, 0x80, 0xF0, 0x80, 0x80 //F
		};
		#endregion
		#region _defaultSFontSet
		protected static byte[] _defaultSFontSet = {
			0x7C, 0xC6, 0xCE, 0xDE, 0xD6, 0xF6, 0xE6, 0xC6, 0x7C, 0x00 //- 0
		,	0x10, 0x30, 0xF0, 0x30, 0x30, 0x30, 0x30, 0x30, 0xFC, 0x00 //- 1
		,	0x78, 0xCC, 0xCC, 0x0C, 0x18, 0x30, 0x60, 0xCC, 0xFC, 0x00 //- 2
		,	0x78, 0xCC, 0x0C, 0x0C, 0x38, 0x0C, 0x0C, 0xCC, 0x78, 0x00 //- 3
		,	0x0C, 0x1C, 0x3C, 0x6C, 0xCC, 0xFE, 0x0C, 0x0C, 0x1E, 0x00 //- 4
		,	0xFC, 0xC0, 0xC0, 0xC0, 0xF8, 0x0C, 0x0C, 0xCC, 0x78, 0x00 //- 5
		,	0x38, 0x60, 0xC0, 0xC0, 0xF8, 0xCC, 0xCC, 0xCC, 0x78, 0x00 //- 6
		,	0xFE, 0xC6, 0xC6, 0x06, 0x0C, 0x18, 0x30, 0x30, 0x30, 0x00 //- 7
		,	0x78, 0xCC, 0xCC, 0xEC, 0x78, 0xDC, 0xCC, 0xCC, 0x78, 0x00 //- 8
		,	0x7C, 0xC6, 0xC6, 0xC6, 0x7C, 0x18, 0x18, 0x30, 0x70, 0x00 //- 9
		,	0x30, 0x78, 0xCC, 0xCC, 0xCC, 0xFC, 0xCC, 0xCC, 0xCC, 0x00 //- A
		,	0xFC, 0x66, 0x66, 0x66, 0x7C, 0x66, 0x66, 0x66, 0xFC, 0x00 //- B
		,	0x3C, 0x66, 0xC6, 0xC0, 0xC0, 0xC0, 0xC6, 0x66, 0x3C, 0x00 //- C
		,	0xF8, 0x6C, 0x66, 0x66, 0x66, 0x66, 0x66, 0x6C, 0xF8, 0x00 //- D
		,	0xFE, 0x62, 0x60, 0x64, 0x7C, 0x64, 0x60, 0x62, 0xFE, 0x00 //- E
		,	0xFE, 0x66, 0x62, 0x64, 0x7C, 0x64, 0x60, 0x60, 0xF0, 0x00 //- F
		};
		#endregion
		#endregion
		#region vars
		protected byte[] _fontSet = null;
		protected byte[] _sFontSet = null;
		protected int StartChip8Font = 0x00;
		protected int StopChip8Font = 0x50;
		protected int StartSuperFont = 0x51;
		protected int StopSuperFont = 0xF0;
		#endregion
		#region constructors
		public Mem_Chip8(): base(4096) { InitMem_Chip8(); }
		protected virtual void InitMem_Chip8() {
		
		}
		#endregion
		#region properties
		#endregion
		public override void HardReset() {
			base.HardReset();
			UInt16 i;
			
			#region load fonts
			if(_fontSet == null) {
				_fontSet = new byte[80];
				Array.Copy(_defaultFontSet, _fontSet, _defaultFontSet.Length);
			}
			if(_sFontSet == null) {
				_sFontSet = new byte[160];
				Array.Copy(_defaultSFontSet, _sFontSet, _defaultSFontSet.Length);
			}
			#endregion

			_size=4096;
			for(i = 0; i < 80; i++)
				_bank[StartChip8Font + i] = _fontSet[i];
			for(i = 0; i < 160; i++)
				_bank[StartSuperFont + i] = _sFontSet[i];
		}
	}
}
