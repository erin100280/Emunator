#region header
/* User: Erin
 * Date: 3/18/2013
 * Time: 2:56 AM
 */
/* for Emunator */
#endregion
#region using....
using Emu.Core;
using Emu.Memory;
using System;
#endregion

namespace Emu.Memory {
	#region meta
	/// <summary>
	/// Description of Mem_ROM.
	/// </summary>
	#endregion
	public class Mem_ROM : Mem_Base {
		#region vars
		#endregion
		#region constructors
		public Mem_ROM(): base("Mem_ROM") { InitMem_ROM(); }
		public Mem_ROM(UInt32 len): base("Mem_ROM", len) { InitMem_ROM(); }
		public Mem_ROM(UInt32 len, byte[] data): base("Mem_ROM", len, data) {
			InitMem_ROM();
		}
		public Mem_ROM(string name): base(name) {
			InitMem_ROM();
		}
		public Mem_ROM(string name, UInt32 len): base(name, len) {
			InitMem_ROM();
		}
		public Mem_ROM(string name, UInt32 len, byte[] data)
						: base(name, len, data) {
			InitMem_ROM();
		}
		protected virtual void InitMem_ROM() {}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#endregion
		#region function: HardReset, SoftReset
		#endregion
	}
}
