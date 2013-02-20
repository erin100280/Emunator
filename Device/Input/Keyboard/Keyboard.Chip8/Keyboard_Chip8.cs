#region header
/* User: Erin
 * Date: 2/15/2013
 * Time: 8:43 PM
 */
#endregion
#region using....
using Emu.Device.Input.Keyboard;
using System;
#endregion

namespace Emu.Device.Input.Keyboard {
	#region meta
	/// <summary>
	/// Description of Keyboard_Chip8.
	/// </summary>
	#endregion
	public class Keyboard_Chip8 : Keyboard_Base {
		#region vars
		#endregion
		#region constructors
		public Keyboard_Chip8(): base("Keyboard.Chip8") {
			InitKeyboard_Chip8();
		}
		public Keyboard_Chip8(byte[] bffr): base("Keyboard.Chip8", null, bffr) {
			InitKeyboard_Chip8();
		}
		protected virtual void InitKeyboard_Chip8() {
			if(_keyBuffer == null) _keyBuffer = new byte[16];
			_keyMap = new KeyMap(16);

			_keyMap._keys[0].mapKeyboard = 88;
			_keyMap._keys[1].mapKeyboard = 49;
			_keyMap._keys[2].mapKeyboard = 50;
			_keyMap._keys[3].mapKeyboard = 51;

			_keyMap._keys[4].mapKeyboard = 81;
			_keyMap._keys[5].mapKeyboard = 87;
			_keyMap._keys[6].mapKeyboard = 69;
			_keyMap._keys[7].mapKeyboard = 65;

			_keyMap._keys[8].mapKeyboard = 83;
			_keyMap._keys[9].mapKeyboard = 68;
			_keyMap._keys[10].mapKeyboard = 90;
			_keyMap._keys[11].mapKeyboard = 67;

			_keyMap._keys[12].mapKeyboard = 52;
			_keyMap._keys[13].mapKeyboard = 82;
			_keyMap._keys[14].mapKeyboard = 70;
			_keyMap._keys[15].mapKeyboard = 86;
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#endregion
		#region function: blah
		#endregion
	}
}
