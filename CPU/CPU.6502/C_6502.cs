#region header
/* User: Erin
 * Date: 2/18/2013
 * Time: 6:26 AM
 */
#endregion
#region using....
using Emu.Core;
using Emu.Memory;
using Emu.Video;
using System;
#endregion

namespace Emu.CPU {
	#region meta
	/// <summary>
	/// Description of C_6502.
	/// </summary>
	#endregion
	public class C_6502 : C_Base {
		#region vars
		#endregion
		#region constructors
		public C_6502(): base("CPU.6502") { InitC_6502(); }
		public C_6502(Mem_Base mem, Vid_Base vid): base("CPU.6502", mem, vid) {
			InitC_6502();
		}
		protected virtual void InitC_6502() {
		
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#endregion
		#region function: DoCycle....
		public override bool DoCycle_Main() { return false; }
		#endregion
	}
}
