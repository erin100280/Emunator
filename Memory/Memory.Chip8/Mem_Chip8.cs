﻿/* User: Erin
 * Date: 2/2/2013
 * Time: 5:51 PM
 */
using Emu.Core;
using System;
using System.Collections.Generic;

namespace Emu.Memory {
	public class Mem_Chip8 : Mem_Base {
		#region static vars: _defaultFontSet
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
		#region vars
		protected byte[] _fontSet = null;
		protected int StartChip8Font = 0x00;
		protected int StopChip8Font = 0x50;
		protected int StartSuperFont = 0x51;
		protected int StopSuperFont = 0xF0;
		#endregion
		#region constructors
		public Mem_Chip8(): base(4096) { InitMem_Chip8(); }
		protected virtual void InitMem_Chip8() {
			_fontSet = new byte[80];
			for(UInt16 i = 0; i < 80; i++)
				_fontSet[i] = _defaultFontSet[i];
		}
		#endregion
		#region properties
		#endregion
		#region state stuff
		public override void SetState(state State) {
			int i;
			try {
				i = State.ints["MEM-SIZ"];
				if(_bank.Length != i)
					bank = new Byte[i];
				
				SetMemory(State.byteArrays["MEM-WORKING"], 0);
				
				_ramSize = State.longs["MEM-RAM-SIZ"];
				_romSize = State.longs["MEM-ROM-SIZ"];
				_startRamAddress = State.ints["MEM-RAM-START"];
				_startRomAddress = State.ints["MEM-ROM-START"];
				
			}
			catch(Exception ex) { Msg.Box("Error: State was all messed up and stuff.\n\n\n\n" + ex.Message); }
			
		
		
		}
		public override state UpdateState(state State) {
			State.byteArrays.Add("MEM-WORKING", _bank);
			State.ints.Add("MEM-RAM-START", _startRamAddress);
			State.ints.Add("MEM-ROM-START", _startRomAddress);
			State.longs.Add("MEM-RAM-SIZ", _ramSize);
			State.longs.Add("MEM-ROM-SIZ", _romSize);
			State.ints.Add("MEM-SIZ", _bank.Length);
			return State;
		}
		#endregion
		public override void Reset(bool clearBank = true) {
			base.Reset(false);
			UInt16 i;
			
			_size=4096;
			_startAddress=0x200; // 512
			_romSize=0x1FF;
			_startRomAddress=0x0;
			_stopRomAddress=0x1FF;
			_ramSize=0xE00;//? 3584 ?
			_startRamAddress=0x200;
			
			if(clearBank) ClearBank();
			for(i = 0; i < 80; i++)
				_bank[i] = _fontSet[i];
			//for(i = 80; i < 160; i++)
				//_bank[i] = _fontSet[i - 80];
			
		}
	}
}
