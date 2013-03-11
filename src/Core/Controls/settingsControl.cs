#region header
/* User: Erin
 * Date: 2/27/2013
 * Time: 12:22 AM
 */
#endregion
#region using....
using System;
using System.ComponentModel;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Windows.Forms;
#endregion

namespace Emu.Core.Controls {
	#region control: settingsPanel
	#region meta
	/// <summary>
	/// Description of settingsControl.
	/// </summary>
	#endregion
	public partial class settingsPanel : UserControl {
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
		public bool dirty = false;
		#endregion
		#region constructors
		public settingsPanel() { InitSettingsPanel(); }
		protected virtual void InitSettingsPanel() {
			//InitializeComponent();
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#endregion
		#region menu handlers
		#endregion
		#region functions
		#endregion
		#region function: blah
		#endregion
	}
	#endregion
	#region class: settingsClass
	#region meta
	/// <summary>
	/// Description of settingsControl.
	/// </summary>
	#endregion
	public partial class settingsClass {
		#region vars
		public string catagory = "settingsCatagory";
		public string name = "settingsName";
		protected bool _dirty = false;
		public settingsPanel _panel = null;
		public state _values = null;
		#endregion
		#region constructors
		public settingsClass() { InitSettingsClass(); }
		protected virtual void InitSettingsClass() {}
		#endregion
		#region events
		#endregion
		#region properties
		public virtual bool dirty {
			get {
				if(_dirty)
					return true;
				else if(_panel != null)
					return _panel.dirty;
				else
					return false;
			}
		}
		public virtual settingsPanel panel {
			get { return _panel; }
		}
		public virtual state values {
			get { return _values; }
			set {
				if(_values != value) {
					_values = value;
					_dirty = true;
				}
			}
		}
		#endregion
		#region On....
		#endregion
		#region menu handlers
		#endregion
		#region function: blah
		#endregion
	}
	#endregion
	#region class: settingsClassCollection
	public class settingsClassCollection
					: Collection<settingsClass> {}
	#endregion
	#region control: settingsControl
	#region meta
	/// <summary>
	/// Description of settingsControl.
	/// </summary>
	#endregion
	public partial class settingsControl : UserControl {
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
		public bool dirty = false;
		public settingsClassCollection settingsClasses = null;
		#endregion
		#region constructors
		public settingsControl() { InitsettingsControl(); }
		protected virtual void InitsettingsControl() {
			InitializeComponent();
			settingsClasses = new settingsClassCollection();
			
		}
		#endregion
		#region events
		#endregion
		#region properties
		
		#endregion
		#region On....
		#endregion
		#region menu handlers
		void CloseToolStripMenuItemClick(object sender, EventArgs e) {
			if(dirty) {}
			if(ParentForm != null)
				ParentForm.Close();
		}
		#endregion
		#region functions
		#endregion
		#region function: blah
		#endregion
	}
	#endregion
}
