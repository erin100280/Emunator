/* User: Erin
 * Date: 1/30/2013
 * Time: 8:57 AM
 */
using System;
using System.Windows.Forms;

namespace Emunator
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			InitProgram();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		private static void InitProgram() {}
		
		public static void test01() {
			byte bt1=0x000F;
			byte bt2=0x00E0;
			byte bt3=0x0000;
			ushort bt4=(ushort)(bt1 & bt2);
			ushort bt5=(ushort)(bt1 & bt3);
			byte bt6=0x000E;
			ushort bt7=(ushort)(bt1 & bt6);
			MessageBox.Show(
				"bt1="+bt1.ToString()+"\n"
			+	"bt2="+bt2.ToString()+"\n"
			+	"bt3="+bt3.ToString()+"\n"
			+	"bt4="+bt4.ToString()+"\n"
			+	"bt5="+bt5.ToString()+"\n"
			+	"bt6="+bt6.ToString()+"\n"
			+	"bt7="+bt7.ToString()+"\n"
				
			);

		}
		
	}
}
