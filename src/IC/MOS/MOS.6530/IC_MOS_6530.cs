#region header
/* User: Erin
 * Date: 3/9/2013
 * Time: 5:18 PM
 */
/* for Emunator */
#endregion
#region using....
using Emu.Core;
using Emu.Memory;
using System;
#endregion

namespace Emu.IC.MOS {
	#region meta
	/// <summary>
	/// Description of IC_MOS_6530.
	/// </summary>
	#endregion
	public class IC_MOS_6530 : IC_Base {
		#region class: timerClass
		public class timerClass : baseClass {
			#region vars
			const string NAME = "MOS.6530.Timer";
			public byte interval = 0x0;
			public bool doInterupt = false;
			public UInt16 IrqVector = 0xFFFF;
			#endregion
			#region constructors
			public timerClass(): base(NAME) { InitTimerClass(); }
			public timerClass(string name): base(name) { InitTimerClass(); }
			protected virtual void InitTimerClass() {
			
			}
			#endregion
			#region events
			#endregion
			#region properties
			#endregion
			#region On....
			#endregion
			#region function: HardReset, SoftReset
			public override void HardReset() {
				base.HardReset();
				SoftReset();
			}
			public override void SoftReset() {
				base.SoftReset();
			}
			#endregion
			#region function: blah
			#endregion
			#region function: blah
			#endregion
		}
		#endregion
		#region vars
		const string IC_NAME = "MOS.6530";
		#endregion
		#region constructors
		public IC_MOS_6530(): base(IC_NAME) { InitIC_MOS_6530(); }
		public IC_MOS_6530(string name): base(name) { InitIC_MOS_6530(); }
		public IC_MOS_6530(string name, Mem_Base mem): base(name, mem) {
			InitIC_MOS_6530();
		}
		public IC_MOS_6530(Mem_Base mem): base(IC_NAME, mem) { InitIC_MOS_6530(); }
		protected virtual void InitIC_MOS_6530() {
		
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#endregion
		#region function: HardReset, SoftReset
		public override void HardReset() {
			base.HardReset();
			SoftReset();
		}
		public override void SoftReset() {
			base.SoftReset();
		}
		#endregion
		#region function: blah
		#endregion
		#region function: blah
		#endregion
	}
}
