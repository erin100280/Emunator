#region header
/* User: Erin
 * Date: 3/19/2013
 * Time: 4:27 PM
 */
/* for Emunator */
#endregion
#region using....
using Emu.Core;
using System;
#endregion

namespace Emu.Glue {
	#region meta
	/// <summary>
	/// Description of Glue_Base.
	/// </summary>
	#endregion
	public class Glue_Base : baseClass {
		#region static
		#region static vars
		public const string NAME = "Glue.Base";
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
		public Glue_Base(): base(NAME) { InitGlue_Base(); }
		public Glue_Base(string name): base(name) { InitGlue_Base(); }
		protected virtual void InitGlue_Base() {
			ReadShort = new ReadShort_delegate(ReadShort_littleEndian);
			WriteShort = new WriteShort_delegate(WriteShort_littleEndian);
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
		#region function: Read....
		public virtual byte ReadByte(UInt64 addrs) {
			return 0;
		}
		public ReadShort_delegate ReadShort;
		public virtual UInt16 ReadRawShort(UInt64 addrs) {
			return 0;
		}
		public delegate UInt16 ReadShort_delegate(UInt64 addrs);
		public virtual UInt16 ReadShort_bigEndian(UInt64 addrs) {
			return 0;
		}
		public virtual UInt16 ReadShort_littleEndian(UInt64 addrs) {
			return 0;
		}
		
		#endregion
		#region function: Write....
		public virtual void WriteByte(UInt64 addrs, short val) {

		}
		public WriteShort_delegate WriteShort;
		public virtual void WriteRawShort(UInt64 addrs, short val) {
			
		}
		public delegate void WriteShort_delegate(UInt64 addrs, short val);
		public virtual void WriteShort_bigEndian(UInt64 addrs, short val) {

		}
		public virtual void WriteShort_littleEndian(UInt64 addrs, short val) {

		}
		#endregion
	}
}
