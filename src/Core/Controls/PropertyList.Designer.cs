/* User: Erin
 * Date: 2/16/2013
 * Time: 1:06 AM
 */
namespace Emu.Core.Controls
{
	partial class PropertyList
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.vScrollBar_main = new System.Windows.Forms.VScrollBar();
			this.panel_main = new System.Windows.Forms.Panel();
			this.splitContainer_main = new System.Windows.Forms.SplitContainer();
			this.panel_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
			this.splitContainer_main.SuspendLayout();
			this.SuspendLayout();
			// 
			// vScrollBar_main
			// 
			this.vScrollBar_main.Dock = System.Windows.Forms.DockStyle.Right;
			this.vScrollBar_main.Location = new System.Drawing.Point(285, 0);
			this.vScrollBar_main.Name = "vScrollBar_main";
			this.vScrollBar_main.Size = new System.Drawing.Size(19, 270);
			this.vScrollBar_main.TabIndex = 1;
			// 
			// panel_main
			// 
			this.panel_main.Controls.Add(this.splitContainer_main);
			this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_main.Location = new System.Drawing.Point(0, 0);
			this.panel_main.Name = "panel_main";
			this.panel_main.Size = new System.Drawing.Size(285, 270);
			this.panel_main.TabIndex = 2;
			// 
			// splitContainer_main
			// 
			this.splitContainer_main.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer_main.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_main.Name = "splitContainer_main";
			// 
			// splitContainer_main.Panel1
			// 
			this.splitContainer_main.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			// 
			// splitContainer_main.Panel2
			// 
			this.splitContainer_main.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.splitContainer_main.Size = new System.Drawing.Size(285, 270);
			this.splitContainer_main.SplitterDistance = 75;
			this.splitContainer_main.TabIndex = 1;
			// 
			// PropertyList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel_main);
			this.Controls.Add(this.vScrollBar_main);
			this.Name = "PropertyList";
			this.Size = new System.Drawing.Size(304, 270);
			this.panel_main.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).EndInit();
			this.splitContainer_main.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.SplitContainer splitContainer_main;
		private System.Windows.Forms.Panel panel_main;
		private System.Windows.Forms.VScrollBar vScrollBar_main;
	}
}
