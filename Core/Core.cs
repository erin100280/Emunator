/* User: Erin
 * Date: 2/3/2013
 * Time: 1:22 AM
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

}
