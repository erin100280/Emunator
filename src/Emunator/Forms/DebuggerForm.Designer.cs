/* User: Erin
 * Date: 2/16/2013
 * Time: 9:44 PM
 */
namespace Emunator.Forms
{
	partial class DebuggerForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.debuggerPanel_main = new Emu.Debugger.Controls.DebuggerPanel();
			this.SuspendLayout();
			// 
			// debuggerPanel_main
			// 
			this.debuggerPanel_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.debuggerPanel_main.Location = new System.Drawing.Point(0, 0);
			this.debuggerPanel_main.machine = null;
			this.debuggerPanel_main.module = null;
			this.debuggerPanel_main.Name = "debuggerPanel_main";
			this.debuggerPanel_main.Size = new System.Drawing.Size(688, 496);
			this.debuggerPanel_main.TabIndex = 0;
			// 
			// DebuggerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(688, 496);
			this.Controls.Add(this.debuggerPanel_main);
			this.Name = "DebuggerForm";
			this.Text = "Debugger";
			this.ResumeLayout(false);
		}
		private Emu.Debugger.Controls.DebuggerPanel debuggerPanel_main;
	}
}
