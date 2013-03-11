/* User: Erin
 * Date: 02/14/2013
 * Time: 08:58
 */
using System;
using System.Collections.Generic;

namespace Emu.Device {
	public class Device_Base  {
		#region vars
		#endregion
		#region constructors
		public Device_Base(string nam = "", string typ = ""
		                   , deviceAccessMode dam = deviceAccessMode.io) {
			InitDevice_Base(nam, typ, dam);
		}
		public Device_Base(deviceAccessMode dam) { InitDevice_Base("", "", dam); }
		protected virtual void InitDevice_Base(string nam, string typ
      				, deviceAccessMode dam) {
			name = nam;
			type = typ;
			accessMode = dam;
		}
		#endregion
		#region properties
		public virtual string name { get; protected set; }
		public virtual string type { get; protected set; }
		public virtual deviceAccessMode accessMode { get; protected set; }
		#endregion
		#region events
		#endregion
		#region On....
		#endregion
	}
}