/* User: Erin
 * Date: 1/30/2013
 * Time: 8:57 AM
 */
namespace Emunator
{
	partial class MainForm
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
			this.theMainControl_main = new Emunator.Controls.theMainControl();
			this.SuspendLayout();
			// 
			// theMainControl_main
			// 
			this.theMainControl_main.BackColor = System.Drawing.Color.Black;
			this.theMainControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.theMainControl_main.Location = new System.Drawing.Point(0, 0);
			this.theMainControl_main.Name = "theMainControl_main";
			this.theMainControl_main.Size = new System.Drawing.Size(569, 220);
			this.theMainControl_main.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(569, 220);
			this.Controls.Add(this.theMainControl_main);
			this.Name = "MainForm";
			this.Text = "Emunator";
			this.ResumeLayout(false);
		}
		private Emunator.Controls.theMainControl theMainControl_main;
	}
}
