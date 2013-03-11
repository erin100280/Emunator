/* User: Erin
 * Date: 2/27/2013
 * Time: 12:22 AM
 */
namespace Emu.Core.Controls
{
	partial class settingsControl
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
			this.splitContainer_main = new System.Windows.Forms.SplitContainer();
			this.treeView_main = new System.Windows.Forms.TreeView();
			this.menuStrip_main = new System.Windows.Forms.MenuStrip();
			this.panel_settings = new System.Windows.Forms.Panel();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).BeginInit();
			this.splitContainer_main.Panel1.SuspendLayout();
			this.splitContainer_main.Panel2.SuspendLayout();
			this.splitContainer_main.SuspendLayout();
			this.menuStrip_main.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer_main
			// 
			this.splitContainer_main.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer_main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer_main.Location = new System.Drawing.Point(0, 24);
			this.splitContainer_main.Name = "splitContainer_main";
			// 
			// splitContainer_main.Panel1
			// 
			this.splitContainer_main.Panel1.Controls.Add(this.treeView_main);
			// 
			// splitContainer_main.Panel2
			// 
			this.splitContainer_main.Panel2.Controls.Add(this.panel_settings);
			this.splitContainer_main.Size = new System.Drawing.Size(528, 297);
			this.splitContainer_main.SplitterDistance = 176;
			this.splitContainer_main.TabIndex = 0;
			// 
			// treeView_main
			// 
			this.treeView_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.treeView_main.Location = new System.Drawing.Point(3, 3);
			this.treeView_main.Name = "treeView_main";
			this.treeView_main.Size = new System.Drawing.Size(170, 291);
			this.treeView_main.TabIndex = 0;
			// 
			// menuStrip_main
			// 
			this.menuStrip_main.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem});
			this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
			this.menuStrip_main.Name = "menuStrip_main";
			this.menuStrip_main.Size = new System.Drawing.Size(528, 24);
			this.menuStrip_main.TabIndex = 1;
			this.menuStrip_main.Text = "menuStrip1";
			// 
			// panel_settings
			// 
			this.panel_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel_settings.Location = new System.Drawing.Point(3, 3);
			this.panel_settings.Name = "panel_settings";
			this.panel_settings.Size = new System.Drawing.Size(342, 291);
			this.panel_settings.TabIndex = 0;
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.exportSettingsToolStripMenuItem,
									this.importSettingsToolStripMenuItem,
									this.toolStripSeparator1,
									this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// exportSettingsToolStripMenuItem
			// 
			this.exportSettingsToolStripMenuItem.Name = "exportSettingsToolStripMenuItem";
			this.exportSettingsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.exportSettingsToolStripMenuItem.Text = "&Export Settings";
			// 
			// importSettingsToolStripMenuItem
			// 
			this.importSettingsToolStripMenuItem.Name = "importSettingsToolStripMenuItem";
			this.importSettingsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.importSettingsToolStripMenuItem.Text = "&Import Settings";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
			// 
			// settingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer_main);
			this.Controls.Add(this.menuStrip_main);
			this.Name = "settingsControl";
			this.Size = new System.Drawing.Size(528, 321);
			this.splitContainer_main.Panel1.ResumeLayout(false);
			this.splitContainer_main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_main)).EndInit();
			this.splitContainer_main.ResumeLayout(false);
			this.menuStrip_main.ResumeLayout(false);
			this.menuStrip_main.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem importSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportSettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.Panel panel_settings;
		private System.Windows.Forms.MenuStrip menuStrip_main;
		private System.Windows.Forms.TreeView treeView_main;
		private System.Windows.Forms.SplitContainer splitContainer_main;
	}
}
