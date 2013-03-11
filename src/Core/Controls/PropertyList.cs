#region header
/* User: Erin
 * Date: 2/16/2013
 * Time: 1:06 AM
 */
#endregion
#region using....
using Emu.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Emu.Core.Controls {
	#region meta
	/// <summary>
	/// Description of PropertyList.
	/// </summary>
	#endregion
	public partial class PropertyList : UserControl {
		#region vars
		protected Collection<propertyListItem> _items;
		protected Int32 _lineCount = 0;
		protected Collection<PictureBox> _lines = null;
		#endregion
		#region constructors
		public PropertyList() { InitPropertyList(); }
		protected virtual void InitPropertyList() {
			InitializeComponent();
			_items = new Collection<propertyListItem>();
			_lines = new Collection<PictureBox>();
			
			vScrollBar_main.Scroll += new ScrollEventHandler(
							vScrollBar_main_Scroll);
			splitContainer_main.SplitterMoved += new SplitterEventHandler(
							splitContainer_main_SplitterMoved);
			innerSpacer = 0;
			outterSpacer = 2;
			verticalSpacer = 1;
		}
		#endregion
		#region events
		#endregion
		#region properties
		public virtual bool setupMode { get; set; }
		public virtual Int32 innerSpacer { get; set; }
		public virtual Int32 outterSpacer { get; set; }
		public virtual Int32 verticalSpacer { get; set; }
		#endregion
		#region On....
		protected override void OnSizeChanged(EventArgs e) {
			base.OnSizeChanged(e);
			RefreshList();
		}
		#endregion
		#region function: AddItem, RemoveItem
		public virtual propertyListItem AddItem(propertyListItem itm) {
			Control ctrl;
			Label lbl;
			if(itm != null && !_items.Contains(itm)) {
				ctrl = itm.control;
				lbl = itm.label;
				if(ctrl != null) {
					_items.Add(itm);
					lbl.Visible = false;
					splitContainer_main.Panel1.Controls.Add(lbl);
					lbl.Location = new Point(60000, 60000);
					lbl.Visible = true;
					ctrl.Visible = false;
					splitContainer_main.Panel2.Controls.Add(ctrl);
					ctrl.Location = new Point(60000, 60000);
					ctrl.Visible = true;
					ctrl.Anchor = AnchorStyles.Left & AnchorStyles.Right 
									& AnchorStyles.Top;
					//lbl.AutoSize = true;
					if(!setupMode) RefreshList();
				}
				else Msg.Dbg("ctrl == null");
			}
			
			return itm;
		}
		#endregion
		#region function: RefreshList
		public virtual void RefreshList() {
			//base.Refresh();
			ResetLines();
			
			panel_main.Size = new Size(ClientSize.Width - vScrollBar_main.Width
			                           , ClientSize.Height);
			splitContainer_main.Top = 0 - vScrollBar_main.Value;
			
			
			Int32 it, iz;
			Int32 itp = verticalSpacer;
			Int32 iwc = splitContainer_main.Panel2.ClientSize.Width
							- (innerSpacer + outterSpacer);
			Int32 iwl = splitContainer_main.Panel1.ClientSize.Width
							- (innerSpacer + outterSpacer);
			Control ctrl;
			Label lbl;
			Color clrPnl = splitContainer_main.Panel1.BackColor;
			PictureBox line;
			
			if(_lines == null) return;

			foreach(var itm in _items) {
				ctrl = itm.control;
				lbl = itm.label;
				it = itp;

				lbl.BackColor = clrPnl;
				lbl.Size = new Size(iwl, ctrl.Height);
				
				ctrl.Width = iwc;

				if(lbl.Height > ctrl.Height) iz = lbl.Height;
				else iz = ctrl.Height;
				
				itp += (iz + verticalSpacer);
				
				ctrl.Location = new Point(innerSpacer, it+((iz - ctrl.Height) / 2));
				lbl.Location = new Point(outterSpacer, it+((iz - lbl.Height) / 2));
//*				
				line = GetLine(splitContainer_main.Panel1);
				line.Location = new Point(1, itp);
				line.Width = splitContainer_main.Panel1.ClientSize.Width - 2;
				
				line = GetLine(splitContainer_main.Panel2);
				line.Location = new Point(1, itp);
				line.Width = splitContainer_main.Panel2.ClientSize.Width - 2;
//*/				
				itp += verticalSpacer;
/*
				Msg._Dbg("- ctrl:");
				Msg._Dbg(" w=" + ctrl.Width + " h=" + ctrl.Height);
				Msg._Dbg(" x=" + ctrl.Left + " y=" + ctrl.Top);
				if(ctrl.Parent == null) Msg._Dbg(" Parent=null");
				Msg._Dbg("\n");				
//*/
			}
			itp += 8;
			if(itp <= panel_main.ClientSize.Height) {
				itp = panel_main.ClientSize.Height;
				vScrollBar_main.Value = vScrollBar_main.Maximum = 0;
				vScrollBar_main.Enabled = false;
			}
			else {
				vScrollBar_main.Enabled = true;
				vScrollBar_main.Maximum = (itp - panel_main.Height);
			}
			splitContainer_main.Height = itp;
			//for(i = 0, il = _items.Count; i < il; i++) {}
			
		}
		#endregion
		#region function: Integer, String
		public virtual Int32 Integer(string name) {
			propertyListItem itm;
			for(Int32 i = 0, il = _items.Count; i < il; i++) {
				itm = _items[i];
				if(itm.name == name)
					return itm.Int32();
			}
			return 0;
		}
		public virtual string String(string name) {
			propertyListItem itm;
			for(Int32 i = 0, il = _items.Count; i < il; i++) {
				itm = _items[i];
				if(itm.name == name)
					return itm.String();
			}
			return "";
		}
		
		#endregion
		#region function: SetValue
		public virtual void SetValue(string name, Int32 val) {
			propertyListItem itm;
			for(Int32 i = 0, il = _items.Count; i < il; i++) {
				itm = _items[i];
				if(itm.name == name)
					itm.SetValue(val);
			}
		}
		
		#endregion
		#region line stuff
		protected virtual void ResetLines() { _lineCount = 0; }
		protected virtual void RemoveUnusedLines() {
			PictureBox pb;
			for(Int32 i = _lineCount, il = _lines.Count; i < il; i++) {
				pb = _lines[_lineCount];
				_lines.Remove(pb);
				if(pb.Parent != null) pb.Parent.Controls.Remove(pb);
				pb.Dispose();
			}
		}
		protected virtual PictureBox GetLine(Control ctrl) {
			PictureBox rv;
			if(_lines.Count > _lineCount)
				rv = _lines[_lineCount];
			else {
				rv = new PictureBox();
				_lines.Add(rv);
			}
			
			_lineCount++;
			
			rv.BackColor = Color.DarkGray;
			rv.BorderStyle = BorderStyle.None;
			rv.Height = 1;
			rv.MaximumSize = new Size(60000, 1);
			rv.MinimumSize = new Size(0, 1);
			rv.Anchor = AnchorStyles.Left & AnchorStyles.Right & AnchorStyles.Top;
			
			if(rv.Parent != null) {
				if(rv.Parent != ctrl) {
					rv.Parent.Controls.Remove(rv);
					ctrl.Controls.Add(rv);
				}
			}
			else ctrl.Controls.Add(rv);

			return rv;
		}
		#endregion
		protected virtual void vScrollBar_main_Scroll(object sender
		                                              , ScrollEventArgs e) {
			splitContainer_main.Top = (0 - vScrollBar_main.Value);
		}
		protected virtual void splitContainer_main_SplitterMoved(object sender
		                                                , SplitterEventArgs e) {
			RefreshList();
		}
		public virtual void Clear() {
			Control ctrl;
			Label lbl;
			propertyListItem itm;
			
			while(_items.Count > 0) {
				itm = _items[_items.Count - 1];
				ctrl = itm.control;
				lbl = itm.label;
				
				if(ctrl != null && ctrl.Parent != null)
					ctrl.Parent.Controls.Remove(ctrl);
				if(lbl != null && lbl.Parent != null)
					lbl.Parent.Controls.Remove(lbl);
				
				_items.Remove(itm);
			}
			
			ResetLines();
			RemoveUnusedLines();
		}
	}
}
