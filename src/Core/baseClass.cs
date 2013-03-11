#region header
/* User: Erin
 * Date: 3/9/2013
 * Time: 4:08 PM
 */
#endregion
#region using....
using System;
#endregion

namespace Emu.Core {
	#region meta
	/// <summary>
	/// Description of baseClass.
	/// </summary>
	#endregion
	public class baseClass {
		#region static
		#region static vars
		public static EventArgs blankEventArgs = EventArgs.Empty;
		#endregion
		#endregion
		#region vars
		public metaData _metaData;
		#endregion
		#region constructors
		public baseClass() { InitbaseClass(""); }
		public baseClass(string name) { InitbaseClass(name); }
		protected virtual void InitbaseClass(string name) {
			_metaData = new metaData(name);
		}
		#endregion
		#region events
		public event EventHandler BeforeMetaDataChanged;
		public event EventHandler MetaDataChanged;
		#endregion
		#region properties
		public metaData meta {
			get { return _metaData; }
			set {
				if(_metaData != value) {
					OnBeforeMetaDataChanged(blankEventArgs);
					_metaData = value;
					OnMetaDataChanged(blankEventArgs);
				}
			}
		}
		#endregion
		#region On....
		public virtual void OnMetaDataChanged(EventArgs e) {
			if(MetaDataChanged != null)
				MetaDataChanged(this, e);
		}
		public virtual void OnBeforeMetaDataChanged(EventArgs e) {
			if(BeforeMetaDataChanged != null)
				BeforeMetaDataChanged(this, e);
		}
		#endregion
		#region function: HardReset, SoftReset
		public virtual void HardReset() {}
		public virtual void SoftReset() {}
		#endregion
	}
}
