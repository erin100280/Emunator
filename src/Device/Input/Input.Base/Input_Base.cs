﻿#region header
/* User: Erin
 * Date: 02/14/2013
 * Time: 09:17
 */
#endregion
#region using....
using System;
#endregion

namespace Emu.Device.Input {
	#region meta
	/// <summary>
	/// Description of Input_Base.
	/// </summary>
	#endregion
	public class Input_Base : Device_Base {
		#region static
		#region static vars
		#endregion
		#region static events
		#endregion
		#region static properties
		#endregion
		#region static On....
		#endregion
		#region static functions
		#endregion
		#region static function: blah
		#endregion
		#endregion
		#region vars
		#endregion
		#region constructors
		public Input_Base() { InitInput_Base(); }
		protected virtual void InitInput_Base() {
		
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#endregion
		#region functions
		#endregion
		#region function: blah
		#endregion
		#region function: HardReset, Reset, SoftReset
		public virtual void HardReset(bool run = false) {
			
		}
		public virtual void Reset() {}
		public virtual void SoftReset(bool run = false) {
			
		}
		#endregion
	}
}