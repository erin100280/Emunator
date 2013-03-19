#region header
/* User: Erin
 * Date: 3/18/2013
 * Time: 8:40 AM
 */
/* for Emunator */
#endregion
#region using....
using Emu.Core.FileSystem;
using System;
using System.Windows.Forms;
#endregion

namespace Emu.Core.Settings {
	#region meta
	/// <summary>
	/// Description of Core_settings.
	/// </summary>
	#endregion
	public class pathSettings : baseClass {
		#region static
		#region static vars
		#endregion
		#region static events
		#endregion
		#region static properties
		#endregion
		#region static On....
		#endregion
		#region static function: blah
		#endregion
		#endregion
		#region vars
		public string _resources = "";
		public string _bios = "";
		public string _bios_commodore = "";
		public string _bios_commodore_c64 = "";
		#endregion
		#region constructors
		public pathSettings() { InitPathSettings(); }
		protected virtual void InitPathSettings() {
		
		}
		#endregion
		#region events
		public event EventHandler BiosChanged;
		public event EventHandler BeforeBiosChanged;
		public event EventHandler Bios_CommodoreChanged;
		public event EventHandler BeforeBios_CommodoreChanged;
		public event EventHandler Bios_Commodore_C64Changed;
		public event EventHandler BeforeBios_Commodore_C64Changed;
		public event EventHandler ResourcesChanged;
		public event EventHandler BeforeResourcesChanged;
		#endregion
		#region On....
		protected virtual void OnBiosChanged(EventArgs e) {
			if(BiosChanged != null)
				BiosChanged(this, e);
		}
		protected virtual void OnBeforeBiosChanged(EventArgs e) {
			if(BeforeBiosChanged != null)
				BeforeBiosChanged(this, e);
		}
		protected virtual void OnBios_CommodoreChanged(EventArgs e) {
			if(Bios_CommodoreChanged != null)
				Bios_CommodoreChanged(this, e);
		}
		protected virtual void OnBeforeBios_CommodoreChanged(EventArgs e) {
			if(BeforeBios_CommodoreChanged != null)
				BeforeBios_CommodoreChanged(this, e);
		}
		protected virtual void OnBios_Commodore_C64Changed(EventArgs e) {
			if(Bios_Commodore_C64Changed != null)
				Bios_Commodore_C64Changed(this, e);
		}
		protected virtual void OnBeforeBios_Commodore_C64Changed(EventArgs e) {
			if(BeforeBios_Commodore_C64Changed != null)
				BeforeBios_Commodore_C64Changed(this, e);
		}
		protected virtual void OnResourcesChanged(EventArgs e) {
			if(ResourcesChanged != null)
				ResourcesChanged(this, e);
		}
		protected virtual void OnBeforeResourcesChanged(EventArgs e) {
			if(BeforeResourcesChanged != null)
				BeforeResourcesChanged(this, e);
		}
		#endregion
		#region properties
		public virtual string bios {
			get {
				if(_bios == "")
					bios = dir.Join(resources, "bios");
				return _bios;
			}
			set {
				if(_bios != value) {
					OnBeforeBiosChanged(blankEventArgs);
					_bios = dir.Validate(value);
					OnBiosChanged(blankEventArgs);
				}
			}
		}
		public virtual string bios_commodore {
			get {
				if(_bios_commodore == "")
					bios_commodore = dir.Join(bios, "Commodore");
				return _bios_commodore;
			}
			set {
				if(_bios_commodore != value) {
					OnBeforeBios_CommodoreChanged(blankEventArgs);
					_bios_commodore = dir.Validate(value);
					OnBios_CommodoreChanged(blankEventArgs);
				}
			}
		}
		public virtual string bios_commodore_c64 {
			get {
				if(_bios_commodore_c64 == "")
					bios_commodore_c64 = dir.Join(bios_commodore, "C64");
				return _bios_commodore_c64;
			}
			set {
				if(_bios_commodore_c64 != value) {
					OnBeforeBios_Commodore_C64Changed(blankEventArgs);
					_bios_commodore_c64 = dir.Validate(value);
					OnBios_Commodore_C64Changed(blankEventArgs);
				}
			}
		}
		public virtual string resources {
			get {
				if(_resources == "")
					resources = dir.Join("Resources");
				return _resources;
			}
			set {
				if(_resources != value) {
					OnBeforeResourcesChanged(blankEventArgs);
					_resources = dir.Validate(value);
					OnResourcesChanged(blankEventArgs);
				}
			}
		}
		#endregion
		#region function: blah
		#endregion
	}
}
