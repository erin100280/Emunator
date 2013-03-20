#region header
/* User: Erin
 * Date: 3/9/2013
 * Time: 3:40 PM
 */
#endregion
#region using....
using Emu.Core;
using Emu.CPU;
using Emu.Memory;
using System;
#endregion

namespace Emu.IC {
	#region meta
	/// <summary>
	/// Description of IC_Base.
	/// </summary>
	#endregion
	public class IC_Base : baseClass {
		#region vars
		const string IC_NAME = "IC.Base";
		public Mem_Base _memory = null;
		public bool hardResetMemory = false;
		public bool softResetMemory = false;
		#endregion
		#region constructors
		public IC_Base(): base(IC_NAME) { InitIC_Base(null); }
		public IC_Base(string name): base(name) { InitIC_Base(null); }
		public IC_Base(string name, Mem_Base mem): base(name) { InitIC_Base(mem); }
		public IC_Base(Mem_Base mem): base(IC_NAME) { InitIC_Base(mem); }
		protected virtual void InitIC_Base(Mem_Base mem) {
			memory = mem;
		}
		#endregion
		#region events
		public event EventHandler MemoryChanged;
		public event EventHandler BeforeMemoryChanged;
		#endregion
		#region properties
		public virtual Mem_Base memory {
			get { return _memory; }
			set {
				if(_memory != value) {
					OnBeforeMetaDataChanged(blankEventArgs);
					_memory = value;
					OnMemoryChanged(blankEventArgs);
				}
			}
		}
		#endregion
		#region On....
		public virtual void OnMemoryChanged(EventArgs e) {
			if(MemoryChanged != null)
				MemoryChanged(this, e);
		}
		public virtual void OnBeforeMemoryChanged(EventArgs e) {
			if(BeforeMemoryChanged != null)
				BeforeMemoryChanged(this, e);
		}
		#endregion
		#region function: HardReset, SoftReset
		public override void HardReset() {
			base.HardReset();
			if(_memory != null && hardResetMemory)
				_memory.HardReset();
			SoftReset();
		}
		public override void SoftReset() {
			base.SoftReset();
			if(_memory != null && softResetMemory)
				_memory.SoftReset();
		}
		#endregion
		#region function: blah
		#endregion
	}
}
