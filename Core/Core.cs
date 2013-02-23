/* User: Erin
 * Date: 2/3/2013
 * Time: 1:22 AM
 */
using ConsoleControl;
using SdlDotNet.Graphics;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
namespace Emu.Core {

	public class errorEventArgs : CancelEventArgs {
		#region vars
		protected string m_error="";
		#endregion
		#region constructors
		public errorEventArgs() { InitErrorEventArgs(); }
		public errorEventArgs(string err) { InitErrorEventArgs(err); }
		protected virtual void InitErrorEventArgs(string err="") {
			m_error=err;
		}
		#endregion
		#region properties
		public virtual string error{ get { return m_error; } }
		#endregion
	}
	
	public delegate void void_delegate();
	public delegate void void_Int16_delegate(Int16 val);
	public delegate void void_Int32_delegate(Int32 val);
	public delegate void void_Int64_delegate(Int64 val);
	public delegate void void_point_delegate(Point val);
	public delegate void void_size_delegate(Size val);
	public delegate void void_string_delegate(string val);
	public delegate void void_Surface_delegate(Surface val);
	public delegate void void_UInt16_delegate(UInt16 val);
	public delegate void void_UInt32_delegate(UInt32 val);
	public delegate void void_UInt64_delegate(UInt64 val);
	public delegate Point point_delegate();
	public delegate Size size_delegate();

	#region class: consoleRef
	public class consoleRef {
		protected ConsoleControl.consoleControl _console;
		public consoleRef(object _Console) {
			_console = (consoleControl)_Console;
			_console.BackColor = Color.DarkGray;
		}
		public virtual void Clear() { _console.ClearOutput(); }
		public virtual void Write(string val) {
			Write(val, Color.Black);
		}
		public virtual void Write(string val, Color clr) {
			_console.WriteOutput(val, clr);
		}
		public virtual void WriteLine(string val) {
			_console.WriteLine(val, Color.Black);
		}
		public virtual void WriteLine(string val, Color clr) {
			_console.WriteLine(val, clr);
		}
	}
	#endregion

}
