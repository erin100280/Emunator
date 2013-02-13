/* User: Erin
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
			this.machineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dumpMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editVideoMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hexEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
									this.machineToolStripMenuItem,
									this.debugToolStripMenuItem,
									this.toolsToolStripMenuItem,
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
			this.TSMnuItm_File_Open.Size = new System.Drawing.Size(143, 22);
			this.TSMnuItm_File_Open.Text = "&Open";
			// 
			// TSSep_File_1
			// 
			this.TSSep_File_1.Name = "TSSep_File_1";
			this.TSSep_File_1.Size = new System.Drawing.Size(140, 6);
			// 
			// TSMnuItm_File_Exit
			// 
			this.TSMnuItm_File_Exit.Name = "TSMnuItm_File_Exit";
			this.TSMnuItm_File_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.TSMnuItm_File_Exit.Size = new System.Drawing.Size(143, 22);
			this.TSMnuItm_File_Exit.Text = "E&xit";
			this.TSMnuItm_File_Exit.Click += new System.EventHandler(this.TSMnuItm_File_ExitClick);
			// 
			// machineToolStripMenuItem
			// 
			this.machineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.runToolStripMenuItem,
									this.pauseToolStripMenuItem,
									this.stepToolStripMenuItem,
									this.resumeToolStripMenuItem,
									this.stopToolStripMenuItem,
									this.resetToolStripMenuItem});
			this.machineToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.machineToolStripMenuItem.Name = "machineToolStripMenuItem";
			this.machineToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.machineToolStripMenuItem.Text = "&Machine";
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.ShortcutKeyDisplayString = "";
			this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
			this.runToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.runToolStripMenuItem.Text = "&Run";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItemClick);
			// 
			// pauseToolStripMenuItem
			// 
			this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
			this.pauseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.pauseToolStripMenuItem.Text = "&Pause";
			this.pauseToolStripMenuItem.Click += new System.EventHandler(this.PauseToolStripMenuItemClick);
			// 
			// stepToolStripMenuItem
			// 
			this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
			this.stepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
			this.stepToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.stepToolStripMenuItem.Text = "&Step";
			this.stepToolStripMenuItem.Click += new System.EventHandler(this.StepToolStripMenuItemClick);
			// 
			// resumeToolStripMenuItem
			// 
			this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
			this.resumeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.resumeToolStripMenuItem.Text = "Resu&me";
			this.resumeToolStripMenuItem.Click += new System.EventHandler(this.ResumeToolStripMenuItemClick);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.stopToolStripMenuItem.Text = "&Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItemClick);
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.resetToolStripMenuItem.Text = "Rese&t";
			this.resetToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItemClick);
			// 
			// debugToolStripMenuItem
			// 
			this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.dumpMemoryToolStripMenuItem,
									this.editMemoryToolStripMenuItem,
									this.editVideoMemoryToolStripMenuItem});
			this.debugToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.debugToolStripMenuItem.Text = "&Debug";
			// 
			// dumpMemoryToolStripMenuItem
			// 
			this.dumpMemoryToolStripMenuItem.Name = "dumpMemoryToolStripMenuItem";
			this.dumpMemoryToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.dumpMemoryToolStripMenuItem.Text = "&Dump Memory";
			// 
			// editMemoryToolStripMenuItem
			// 
			this.editMemoryToolStripMenuItem.Name = "editMemoryToolStripMenuItem";
			this.editMemoryToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.editMemoryToolStripMenuItem.Text = "&Edit Memory";
			this.editMemoryToolStripMenuItem.Click += new System.EventHandler(this.EditMemoryToolStripMenuItemClick);
			// 
			// editVideoMemoryToolStripMenuItem
			// 
			this.editVideoMemoryToolStripMenuItem.Name = "editVideoMemoryToolStripMenuItem";
			this.editVideoMemoryToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.editVideoMemoryToolStripMenuItem.Text = "Edit Video Memory";
			this.editVideoMemoryToolStripMenuItem.Click += new System.EventHandler(this.EditVideoMemoryToolStripMenuItemClick);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.hexEditorToolStripMenuItem});
			this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// hexEditorToolStripMenuItem
			// 
			this.hexEditorToolStripMenuItem.Name = "hexEditorToolStripMenuItem";
			this.hexEditorToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.hexEditorToolStripMenuItem.Text = "&Hex Editor";
			this.hexEditorToolStripMenuItem.Click += new System.EventHandler(this.HexEditorToolStripMenuItemClick);
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
			this.openFileDialog.Filter = "All Files|*.*|Chip8|*.ch8";
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
		private System.Windows.Forms.ToolStripMenuItem editVideoMemoryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editMemoryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem hexEditorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dumpMemoryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem machineToolStripMenuItem;
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
