#region header
/* User: Erin
 * Date: 3/8/2013
 * Time: 10:34 PM
 */
#endregion
#region using....
using Emu.Core;
using Emu.CPU;
using Emu.Memory;
using System;
#endregion

namespace Emu.Machine.KIM1 {
	#region meta
	/// <summary>
	/// Description of M_KIM_1.
	/// </summary>
	#endregion
	public class M_KIM1 : M_Base {
		#region static
		#region static consts
		private const string MACHINE_NAME="KIM-1";
		#endregion
		#endregion
		#region vars
			public C_6502 _cpu6502 = null;
		#endregion
		#region constructors
		public M_KIM1(): base(MACHINE_NAME) { InitM_KIM1(); }
		protected virtual void InitM_KIM1() {
			m_cpu = _cpu6502 = new C_6502();
		}
		#endregion
		#region events
		#endregion
		#region properties
		#endregion
		#region On....
		#endregion
		#region function: HardReset, SoftReset
		public override void HardReset(bool run) {
			if(running & !paused) Stop();
			base.HardReset(false);
			SoftReset(false);
			
			if(run) {
				if(running) Resume();
				else Run();
			}
		}
		public override void SoftReset(bool run) {
			base.SoftReset(run);
		}
		#endregion
	}
}
