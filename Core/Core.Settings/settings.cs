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
	public partial class settings {
		#region static
		#region static vars
			public static settings _main = null;
			public static EventArgs _blankEventArgs = null; 
		#endregion
		#region static events
		public static event EventHandler MainChanged;
		#endregion
		#region static properties
		public static EventArgs blankEventArgs {
			get {
				if(_blankEventArgs == null)
					_blankEventArgs = new EventArgs();
				return _blankEventArgs;
			}
		}
		public static settings main {
			get {
				if(_main == null)
					main = new settings();
				return _main;
			}
			set {
				if(_main != value) {
					_main = value;
					OnMainChanged(new EventArgs());
				}
			}
		}
		#endregion
		#region static On....
		private static void OnMainChanged(EventArgs e) {
			if(MainChanged != null) MainChanged(_main, e);
		}
		#endregion
		#region static functions
		#endregion
		#region static function: blah
		#endregion
		#endregion
		#region vars
		public machineSettings _Chip8 = null;
		#endregion
		#region constructors
		public settings() { InitSettings(); }
		protected virtual void InitSettings() {
		}
		#endregion
		#region events
		public event EventHandler Chip8Changed;
		public event EventHandler BeforeChip8Changed;
		#endregion
		#region properties
		public virtual machineSettings Chip8 {
			get {
				if(_Chip8 == null)
					Chip8 = new machineSettings();
				return _Chip8;
			}
			set {
				if(_Chip8 != value) {
					OnBeforeChip8Changed(blankEventArgs);
					_Chip8 = value;
					OnChip8Changed(blankEventArgs);
				}
			}
		}
		#endregion
		#region On....
		protected virtual void OnChip8Changed(EventArgs e) {
			if(Chip8Changed != null) Chip8Changed(this, e);
		}
		protected virtual void OnBeforeChip8Changed(EventArgs e) {
			if(BeforeChip8Changed != null) BeforeChip8Changed(this, e);
		}
		#endregion
		#region functions
		#endregion
		#region function: blah
		#endregion
	}
}
