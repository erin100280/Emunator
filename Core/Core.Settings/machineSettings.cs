#region header
/* User: Erin
 * Date: 2/24/2013
 * Time: 4:01 AM
 */
#endregion
#region using....
using System;
#endregion

namespace Emu.Core.Settings {
	#region meta
	/// <summary>
	/// Description of Core_settings.
	/// </summary>
	#endregion
	public class machineSettings {
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
		public displaySettings _display = null;
		protected EventArgs blankEventArgs = settings.blankEventArgs;
		#endregion
		#region constructors
		public machineSettings() { InitMachineSettings(); }
		protected virtual void InitMachineSettings() {
		
		}
		#endregion
		#region events
		public event EventHandler DisplayChanged;
		public event EventHandler BeforeDisplayChanged;
		#endregion
		#region properties
		public virtual displaySettings display {
			get {
				if(_display == null)
					display = new displaySettings();
				return _display;
			}
			set {
				if(_display != value) {
					OnBeforeDisplayChanged(blankEventArgs);
					_display = value;
					OnDisplayChanged(blankEventArgs);
				}
			}
		}
		#endregion
		#region On....
		protected virtual void OnDisplayChanged(EventArgs e) {
			if(DisplayChanged != null) DisplayChanged(this, e);
		}
		protected virtual void OnBeforeDisplayChanged(EventArgs e) {
			if(BeforeDisplayChanged != null) BeforeDisplayChanged(this, e);
		}
		#endregion
		#region functions
		#endregion
		#region function: blah
		#endregion
	}
}
