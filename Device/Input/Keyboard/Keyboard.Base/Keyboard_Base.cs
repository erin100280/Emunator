#region header
/* User: Erin
 * Date: 2/15/2013
 * Time: 5:12 AM
 */
#endregion
#region using....
using Emu.Core;
using SdlDotNet;
using SdlDotNet.Input;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Tao.Sdl;
#endregion

namespace Emu.Device.Input.Keyboard {
	#region class: Key
	#region meta
	/// <summary>
	/// Represents a keyboard-key. Holds value, map data, name, and description.
	/// </summary>
	#endregion
	public class Key {
		#region constructors
		public Key() { InitKey(); }
		protected virtual void InitKey() {
			keyValue = mapJoypad = mapKeyboard = mapMouse = -1;
		}
		#endregion
		#region properties
		public virtual Int32 keyValue { get; set; }
		public virtual Int32 mapJoypad { get; set; }
		public virtual Int32 mapKeyboard { get; set; }
		public virtual Int32 mapMouse { get; set; }
		public virtual string description { get; set; }
		public virtual string name { get; set; }
		#endregion
	}
	#endregion
	#region class: KeyMap
	#region meta
	/// <summary>
	/// Map keyboard, joypad, and mouse to keyboard output.
	/// </summary>
	#endregion
	public class KeyMap {
		#region vars
		public Key[] _keys = null;
		#endregion
		#region constructors
		public KeyMap() { InitKeyMap(2); }
		public KeyMap(Int32 size) { InitKeyMap(size); }
		protected virtual void InitKeyMap(Int32 size) {
			Int32 i;
			if(size > 0) {
				_keys = new Key[size];
				for(i=0; i < size; i++) {
					_keys[i] = new Key();
					_keys[i].keyValue = _keys[i].mapKeyboard = i;
				}
			}
		}
		#endregion
		#region properties
		public virtual Int32 size {
			get {
				if(_keys != null) return _keys.Length;
				else return 0;
			}
		}
		#endregion
		#region function: Get, Set
		#endregion
	}
	#endregion
	#region class: Keyboard_Base
	#region meta
	/// <summary>
	/// The base for all keyboard devices.... duhh.
	/// </summary>
	#endregion
	public class Keyboard_Base {
		#region vars
		protected KeyMap _keyMap = null;
		protected byte[] _keyBuffer = null;
		//protected Collection<
		#endregion
		#region constructors
		public Keyboard_Base() { InitKeyboard_Base("", null, null, null, -1, -1); }
		public Keyboard_Base(string name) {
			InitKeyboard_Base(name, null, null, null, -1, -1);
		}
		public Keyboard_Base(string name, KeyMap map, byte[] buffer) {
			InitKeyboard_Base(name, map, buffer, null, -1, -1);
		}
		public Keyboard_Base(string name, KeyMap map) {
			InitKeyboard_Base(name, map, null, null, -1, -1);
		}
		protected virtual void InitKeyboard_Base(string name, KeyMap map
						, byte[] bffr, metaData _meta, Int32 mapSiz, Int32 bufSiz) {

			mapSize = mapSiz;
			bufferSize = bufSiz;
			
			if(_meta != null) meta = _meta;
			else meta = new metaData(name);
			
			if(map != null) _keyMap = map;
			else if(mapSiz > 0) _keyMap = new KeyMap(mapSiz);
			
			if(bffr != null) _keyBuffer = bffr;
			else if(bufSiz > 0) _keyBuffer = new byte[bufSiz];
			
		}
		#endregion
		#region events
		#endregion
		#region properties
		public virtual metaData meta { get; protected set; }
		public virtual Int32 bufferSize { get; protected set; }
		public virtual Int32 mapSize { get; protected set; }
		#endregion
		#region function: ConnectTo, DisconnectFrom
		public virtual void ConnectTo(Control val) {
			val.KeyDown += Handler_KeyDown;
			val.KeyUp += Handler_KeyUp;
		}
		public virtual void DisconnectFrom(Control val) {
			val.KeyDown -= Handler_KeyDown;
			val.KeyUp -= Handler_KeyUp;
		}
		#endregion
		#region event handlers: (keys, mouse, joystick)
		#region keyboard
		protected virtual void Handler_KeyDown(object sender, KeyEventArgs e) {
			//Msg.Dbg("KeyDown - " + e.KeyValue.ToString());
			if(_keyBuffer != null && _keyMap != null) {
				Int32 ii = 0;
				Int32 il = _keyMap._keys.Length;
				Int32 iv = -1;
				Key k;
				
				while(ii < il && iv < 0) {
					k = _keyMap._keys[ii];
					if(k.mapKeyboard == e.KeyValue) iv = k.keyValue;
					ii++;
				}
				if(iv >= 0) {
					_keyBuffer[iv] = 0x01;
				}
			}
		}
		protected virtual void Handler_KeyUp(object sender, KeyEventArgs e) {
			//Msg.Dbg("KeyUp - " + e.KeyValue.ToString());
			if(_keyBuffer != null && _keyMap != null) {
				Int32 ii = 0;
				Int32 il = _keyMap._keys.Length;
				Int32 iv = -1;
				Key k;
				
				while(ii < il && iv < 0) {
					k = _keyMap._keys[ii];
					if(k.mapKeyboard == e.KeyValue) iv = k.keyValue;
					ii++;
				}
				if(iv >= 0)
					_keyBuffer[iv] = 0x00;
			}
		}
		#endregion
		#endregion
	}
	#endregion
}
