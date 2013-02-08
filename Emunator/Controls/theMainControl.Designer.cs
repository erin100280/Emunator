﻿/* User: Erin
 * Date: 2/7/2013
 * Time: 9:12 PM
 */
namespace Emunator.Controls
{
	partial class theMainControl
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
			this.menuStrip_main = new System.Windows.Forms.MenuStrip();
			this.TSMnuItm_File = new System.Windows.Forms.ToolStripMenuItem();
			this.TSMnuItm_File_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.TSSep_File_1 = new System.Windows.Forms.ToolStripSeparator();
			this.TSMnuItm_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tstyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.picSep = new System.Windows.Forms.PictureBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.pnl_display = new System.Windows.Forms.Panel();
			this.menuStrip_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picSep)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip_main
			// 
			this.menuStrip_main.BackColor = System.Drawing.Color.Black;
			this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.TSMnuItm_File,
									this.testToolStripMenuItem});
			this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
			this.menuStrip_main.Name = "menuStrip_main";
			this.menuStrip_main.Size = new System.Drawing.Size(540, 24);
			this.menuStrip_main.TabIndex = 1;
			this.menuStrip_main.Text = "menuStrip1";
			// 
			// TSMnuItm_File
			// 
			this.TSMnuItm_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.TSMnuItm_File_Open,
									this.TSSep_File_1,
									this.TSMnuItm_File_Exit});
			this.TSMnuItm_File.ForeColor = System.Drawing.Color.White;
			this.TSMnuItm_File.Name = "TSMnuItm_File";
			this.TSMnuItm_File.Size = new System.Drawing.Size(35, 20);
			this.TSMnuItm_File.Text = "&File";
			// 
			// TSMnuItm_File_Open
			// 
			this.TSMnuItm_File_Open.Name = "TSMnuItm_File_Open";
			this.TSMnuItm_File_Open.Size = new System.Drawing.Size(111, 22);
			this.TSMnuItm_File_Open.Text = "&Open";
			// 
			// TSSep_File_1
			// 
			this.TSSep_File_1.Name = "TSSep_File_1";
			this.TSSep_File_1.Size = new System.Drawing.Size(108, 6);
			// 
			// TSMnuItm_File_Exit
			// 
			this.TSMnuItm_File_Exit.Name = "TSMnuItm_File_Exit";
			this.TSMnuItm_File_Exit.Size = new System.Drawing.Size(111, 22);
			this.TSMnuItm_File_Exit.Text = "E&xit";
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.loadRomToolStripMenuItem,
									this.tstyToolStripMenuItem});
			this.testToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.testToolStripMenuItem.Text = "Test";
			// 
			// loadRomToolStripMenuItem
			// 
			this.loadRomToolStripMenuItem.Name = "loadRomToolStripMenuItem";
			this.loadRomToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.loadRomToolStripMenuItem.Text = "load rom";
			this.loadRomToolStripMenuItem.Click += new System.EventHandler(this.LoadRomToolStripMenuItemClick);
			// 
			// tstyToolStripMenuItem
			// 
			this.tstyToolStripMenuItem.Name = "tstyToolStripMenuItem";
			this.tstyToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.tstyToolStripMenuItem.Text = "tsty";
			this.tstyToolStripMenuItem.Click += new System.EventHandler(this.TstyToolStripMenuItemClick);
			// 
			// picSep
			// 
			this.picSep.BackColor = System.Drawing.Color.DimGray;
			this.picSep.Dock = System.Windows.Forms.DockStyle.Top;
			this.picSep.Location = new System.Drawing.Point(0, 24);
			this.picSep.MaximumSize = new System.Drawing.Size(4000, 1);
			this.picSep.MinimumSize = new System.Drawing.Size(20, 1);
			this.picSep.Name = "picSep";
			this.picSep.Size = new System.Drawing.Size(540, 1);
			this.picSep.TabIndex = 3;
			this.picSep.TabStop = false;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			this.openFileDialog.Filter = "All Files|*.*";
			// 
			// pnl_display
			// 
			this.pnl_display.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnl_display.Location = new System.Drawing.Point(0, 25);
			this.pnl_display.Name = "pnl_display";
			this.pnl_display.Size = new System.Drawing.Size(540, 159);
			this.pnl_display.TabIndex = 4;
			// 
			// theMainControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.pnl_display);
			this.Controls.Add(this.picSep);
			this.Controls.Add(this.menuStrip_main);
			this.Name = "theMainControl";
			this.Size = new System.Drawing.Size(540, 184);
			this.menuStrip_main.ResumeLayout(false);
			this.menuStrip_main.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picSep)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Panel pnl_display;
		private System.Windows.Forms.ToolStripMenuItem tstyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSMnuItm_File_Exit;
		private System.Windows.Forms.ToolStripSeparator TSSep_File_1;
		private System.Windows.Forms.ToolStripMenuItem TSMnuItm_File_Open;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ToolStripMenuItem loadRomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.PictureBox picSep;
		private System.Windows.Forms.ToolStripMenuItem TSMnuItm_File;
		private System.Windows.Forms.MenuStrip menuStrip_main;

	}
}
