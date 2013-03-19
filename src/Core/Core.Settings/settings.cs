#region header
/* User: Erin
 * Date: 2/24/2013
 * Time: 4:01 AM
 */
#endregion
#region using....
using Emu.Core;
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
		public pathSettings _paths = null;
		public systemSettings _system = null;
		public inputHandler _inputHandler = null;
		#endregion
		#region constructors
		public settings() { InitSettings(); }
		protected virtual void InitSettings() {}
		#endregion
		#region events
		public event EventHandler Chip8Changed;
		public event EventHandler BeforeChip8Changed;

		public event EventHandler InputHandlerChanged;
		public event EventHandler BeforeInputHandlerChanged;

		public event EventHandler PathsChanged;
		public event EventHandler BeforePathsChanged;

		public event EventHandler SystemChanged;
		public event EventHandler BeforeSystemChanged;
		#endregion
		#region On....
		protected virtual void OnChip8Changed(EventArgs e) {
			if(Chip8Changed != null) Chip8Changed(this, e);
		}
		protected virtual void OnBeforeChip8Changed(EventArgs e) {
			if(BeforeChip8Changed != null) BeforeChip8Changed(this, e);
		}

		protected virtual void OnInputHandlerChanged(EventArgs e) {
			if(InputHandlerChanged != null) InputHandlerChanged(this, e);
		}
		protected virtual void OnBeforeInputHandlerChanged(EventArgs e) {
			if(BeforeInputHandlerChanged != null) BeforeInputHandlerChanged(this, e);
		}

		protected virtual void OnPathsChanged(EventArgs e) {
			if(PathsChanged != null) PathsChanged(this, e);
		}
		protected virtual void OnBeforePathsChanged(EventArgs e) {
			if(BeforePathsChanged != null) BeforePathsChanged(this, e);
		}

		protected virtual void OnSystemChanged(EventArgs e) {
			if(SystemChanged != null) SystemChanged(this, e);
		}
		protected virtual void OnBeforeSystemChanged(EventArgs e) {
			if(BeforeSystemChanged != null) BeforeSystemChanged(this, e);
		}
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
		public virtual inputHandler inputHandler {
			get {
				if(_inputHandler == null)
					inputHandler = new inputHandler();
				return _inputHandler;
			}
			set {
				if(_inputHandler != value) {
					OnBeforeInputHandlerChanged(blankEventArgs);
					_inputHandler = value;
					OnInputHandlerChanged(blankEventArgs);
				}
			}
		}
		public virtual pathSettings paths {
			get {
				if(_paths == null)
					paths = new pathSettings();
				return _paths;
			}
			set {
				if(_paths != value) {
					OnBeforePathsChanged(blankEventArgs);
					_paths = value;
					OnPathsChanged(blankEventArgs);
				}
			}
		}
		public virtual systemSettings system {
			get {
				if(_system == null)
					system = new systemSettings();
				return _system;
			}
			set {
				if(_system != value) {
					OnBeforeSystemChanged(blankEventArgs);
					_system = value;
					OnSystemChanged(blankEventArgs);
				}
			}
		}
		#endregion
	}
}
