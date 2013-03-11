#region header
/* User: Erin
 * Date: 2/24/2013
 * Time: 4:01 AM
 */
#endregion
#region using....
using System;
using System.Windows.Forms;
#endregion

namespace Emu.Core.Settings {
	#region meta
	/// <summary>
	/// Description of Core_settings.
	/// </summary>
	#endregion
	public class systemSettings {
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
		public displaySizeMode _sizeMode = displaySizeMode.times;
		public int _sizeModeInt = 4;
		public Control focusControl = null;

		protected EventArgs blankEventArgs = settings.blankEventArgs;
		#endregion
		#region constructors
		public systemSettings() { InitSystemSettings(); }
		protected virtual void InitSystemSettings() {
		
		}
		#endregion
		#region events
		public event EventHandler SizeModeChanged;
		public event EventHandler BeforeSizeModeChanged;

		public event EventHandler SizeModeIntChanged;
		public event EventHandler BeforeSizeModeIntChanged;

		#endregion
		#region On....
		protected virtual void OnSizeModeChanged(EventArgs e) {
			if(SizeModeChanged != null) SizeModeChanged(this, e);
		}
		protected virtual void OnBeforeSizeModeChanged(EventArgs e) {
			if(BeforeSizeModeChanged != null) BeforeSizeModeChanged(this, e);
		}

		protected virtual void OnSizeModeIntChanged(EventArgs e) {
			if(SizeModeIntChanged != null) SizeModeIntChanged(this, e);
		}
		protected virtual void OnBeforeSizeModeIntChanged(EventArgs e) {
			if(BeforeSizeModeIntChanged != null)
				BeforeSizeModeIntChanged(this, e);
		}

		#endregion
		#region properties
		public virtual displaySizeMode sizeMode {
			get { return _sizeMode; }
			set {
				if(_sizeMode != value) {
					OnBeforeSizeModeChanged(blankEventArgs);
					_sizeMode = value;
					OnSizeModeChanged(blankEventArgs);
				}
			}
		}
		public virtual int sizeModeInt {
			get { return _sizeModeInt; }
			set {
				if(_sizeModeInt != value) {
					OnBeforeSizeModeIntChanged(blankEventArgs);
					_sizeModeInt = value;
					OnSizeModeIntChanged(blankEventArgs);
				}
			}
		}
		#endregion
		#region function: blah
		#endregion
	}
}
