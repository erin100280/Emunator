#region header
/* User: Erin
 * Date: 3/9/2013
 * Time: 4:50 PM
 */
/* for Emunator */
#endregion
#region using....
using Emu.Core;
using System;
#endregion

namespace Emu {
	#region meta
	/// <summary>
	/// Description of Class1.
	/// </summary>
	#endregion
	public class Class1 : baseClass {
		#region static
		#region static vars
		#endregion
		#region static events
		#endregion
		#region static properties
		#endregion
		#region static On....
		#endregion
		#region static functions
		#endregion
		#region static function: blah
		#endregion
		#endregion
		#region vars
		#endregion
		#region constructors
		public Class1(): base("") { InitClass1(); }
		public Class1(string name): base(name) { InitClass1(); }
		protected virtual void InitClass1() {
		
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
