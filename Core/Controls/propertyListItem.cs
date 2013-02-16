#region header
/* User: Erin
 * Date: 2/16/2013
 * Time: 1:16 AM
 */
#endregion
#region using....
using System;
using System.Windows.Forms;
#endregion

namespace Emu.Core.Controls {
	#region enum: propertyType
	public enum propertyType {
		NONE
	,	boolean
	,	color
	,	date
	,	hex
	,	multipleChoice
	,	number
	,	text
	,	textMultipleChoice
	,	time
	}
	#endregion
	#region class: propertyListItem
	#region meta
	/// <summary>
	/// Used in Emu.Debugger.ControlsPropertyList.
	/// </summary>
	#endregion
	public class propertyListItem {
		#region vars
		protected propertyType _type = propertyType.NONE;
		protected Control _control = null;
		protected Label _label = null;
		protected string _name = "";
		protected string _description = "";
		
		protected Int32 _minValue = 0;
		protected Int32 _maxValue = 255;
		#endregion
		#region constructors
		public propertyListItem() {
			InitpropertyListItem("", propertyType.NONE, "");
		}
		public propertyListItem(string name) {
			InitpropertyListItem(name, propertyType.NONE, "");
		}
		public propertyListItem(propertyType type) {
			InitpropertyListItem("", type, "");
		}
		public propertyListItem(string name, propertyType type) {
			InitpropertyListItem(name, type, "");
		}
		public propertyListItem(string name, propertyType type, string val) {
			InitpropertyListItem(name, type, val);
		}
		public propertyListItem(string name, propertyType type, Int32 val) {
			InitpropertyListItem(name, type, val.ToString());
		}
		protected virtual void InitpropertyListItem(string name, propertyType type
						, string val) {

			if(name != "")
				this.name = name;
			if(type != propertyType.NONE)
				this.type = type;

			Setup();
			if(val != "")
				this.SetValue(val);
			
		}
		#endregion
		#region events
		#endregion
		#region properties
		public virtual Control control {
			get {
				if(_control == null) Setup();
				return _control;
			}
		}
		public virtual Label label {
			get {
				if(_label == null) Setup();
				return _label;
			}
		}
		
		public virtual string description {
			get { return _description; }
			set {
				if(_description != value) {
					_description = value;
					//if(_label != null)
						//_label.Text = _name;
				}
			}
		}
		public virtual string name {
			get { return _name; }
			set {
				if(_name != value) {
					_name = value;
					if(_label != null)
						_label.Text = _name;
				}
			}
		}
		public virtual propertyType type {
			get { return _type; }
			set {
				if(_type != value) {
					_type = value;
					Setup();
				}
			}
			
		}
		
		public virtual Int32 maxValue {
			get { return _maxValue; }
			set {
				if(_maxValue != value) {
					_maxValue = value;
					Refresh();
				}
			}
		}
		public virtual Int32 minValue {
			get { return _minValue; }
			set {
				if(_minValue != value) {
					_minValue = value;
					Refresh();
				}
			}
		}
		#endregion
		#region protected function: Reset
		protected virtual void Reset() {
			if(_control != null) {
				if(_control.Parent != null)
					_control.Parent.Controls.Remove(_control);
				_control.Dispose();
				_control = null;
			}
			if(_label != null) _label.Text = "";
		}
		#endregion
		#region protected function: Setup....
		protected virtual void Setup() {
			if(_label == null) {
				_label = new Label();
				_label.AutoSize = true;
				Int32 ht = _label.Height;
				_label.MinimumSize = new System.Drawing.Size(0, ht);
				_label.MaximumSize = new System.Drawing.Size(60000, ht);
				_label.AutoSize = false;
			}
			_label.Text = _name;
			
			switch(_type) {
				case propertyType.hex:
					Setup_hex();
					break;
				case propertyType.number:
					Setup_number();
					break;
				default: break;
			}
		}
		protected virtual void Setup_hex() {
			if(_control == null)
				_control = new NumericUpDown();
			Refresh();
		}
		protected virtual void Setup_number() {
			_control = new NumericUpDown();
			Refresh();
		}
		#endregion
		#region Refresh....
		public virtual void Refresh() {
			
			if(_label != null)
				_label.Text = _name;
			
			switch(_type) {
				case propertyType.hex:
					Refresh_hex();
					break;
				default: break;
			}
		}
		protected virtual void Refresh_hex() {
			NumericUpDown nud = (NumericUpDown)_control;
			nud.Anchor = AnchorStyles.Top & AnchorStyles.Left & AnchorStyles.Right;
			nud.Hexadecimal = true;
			nud.Minimum = _minValue;
			nud.Maximum = _maxValue;
		}
		#endregion
		#region function: Int32, Int64, String
		public virtual Int32 Int32() {
			return Convert.ToInt32(GetVal_string());
		}
		public virtual Int64 Int64() {
			return Convert.ToInt64(GetVal_string());
		}
		public virtual string String() { return GetVal_string(); }
		#endregion
		#region function: GetVal....
		protected virtual string GetVal_string() {
			string rv = "";
			switch(_type) {
				case propertyType.hex:
					rv = GetVal_string_hex();
					break;
				default: break;
			}
			return rv;
		}
		protected virtual string GetVal_string_hex() {
			if(_control != null)
				return ((NumericUpDown)_control).Value.ToString();
			return "";
		}
		protected virtual string GetVal_string_number() {
			if(_control != null)
				return ((NumericUpDown)_control).Value.ToString();
			return "";
		}
		protected virtual string GetVal_string_text() {
			if(_control != null)
				return ((TextBox)_control).Text;
			return "";
		}
		#endregion
		#region function: SetValue....
		public virtual void SetValue(Int32 val) {
			SetValue_string(val.ToString());
		}
		public virtual void SetValue(string val) { SetValue_string(val); }
		
		protected virtual void SetValue_string(string val) {
			if(_control != null) {
				switch(_type) {
					case propertyType.hex:
						SetValue_string_hex(val);
						break;
					case propertyType.number:
						SetValue_string_number(val);
						break;
					case propertyType.text:
						SetValue_string_text(val);
						break;
					default: break;
				}
			}
		}
		protected virtual void SetValue_string_hex(string val) {
			((NumericUpDown)_control).Value = Convert.ToDecimal(val);
		}
		protected virtual void SetValue_string_number(string val) {
			((NumericUpDown)_control).Value = Convert.ToDecimal(val);
		}
		protected virtual void SetValue_string_text(string val) {
			((TextBox)_control).Text = val;
		}
		
		#endregion
	}
	#endregion
}
