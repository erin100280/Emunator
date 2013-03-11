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
			this.loadStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectStateSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateSlot0toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateSlot1toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateSlot2toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateSlot3toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateSlot4toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateSlot5toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateSlot6toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateSlot7toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateSlot8toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateSlot9toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.importStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.TSMnuItm_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.machineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debuggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dumpMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hexEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadRomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tstyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.picSep = new System.Windows.Forms.PictureBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.pnl_display = new System.Windows.Forms.Panel();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.test6502ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
									this.loadStateToolStripMenuItem,
									this.selectStateSlotToolStripMenuItem,
									this.saveStateToolStripMenuItem,
									this.importStateToolStripMenuItem,
									this.exportStateToolStripMenuItem,
									this.toolStripSeparator1,
									this.TSMnuItm_File_Exit});
			this.TSMnuItm_File.ForeColor = System.Drawing.Color.White;
			this.TSMnuItm_File.Name = "TSMnuItm_File";
			this.TSMnuItm_File.Size = new System.Drawing.Size(35, 20);
			this.TSMnuItm_File.Text = "&File";
			// 
			// TSMnuItm_File_Open
			// 
			this.TSMnuItm_File_Open.Name = "TSMnuItm_File_Open";
			this.TSMnuItm_File_Open.Size = new System.Drawing.Size(164, 22);
			this.TSMnuItm_File_Open.Text = "&Open";
			this.TSMnuItm_File_Open.Click += new System.EventHandler(this.TSMnuItm_File_OpenClick);
			// 
			// TSSep_File_1
			// 
			this.TSSep_File_1.Name = "TSSep_File_1";
			this.TSSep_File_1.Size = new System.Drawing.Size(161, 6);
			// 
			// loadStateToolStripMenuItem
			// 
			this.loadStateToolStripMenuItem.Name = "loadStateToolStripMenuItem";
			this.loadStateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.loadStateToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.loadStateToolStripMenuItem.Text = "&Load State";
			this.loadStateToolStripMenuItem.Click += new System.EventHandler(this.LoadStateToolStripMenuItemClick);
			// 
			// selectStateSlotToolStripMenuItem
			// 
			this.selectStateSlotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.stateSlot0toolStripMenuItem,
									this.stateSlot1toolStripMenuItem,
									this.stateSlot2toolStripMenuItem,
									this.stateSlot3toolStripMenuItem,
									this.stateSlot4toolStripMenuItem,
									this.stateSlot5toolStripMenuItem,
									this.stateSlot6toolStripMenuItem,
									this.stateSlot7toolStripMenuItem,
									this.stateSlot8toolStripMenuItem,
									this.stateSlot9toolStripMenuItem});
			this.selectStateSlotToolStripMenuItem.Name = "selectStateSlotToolStripMenuItem";
			this.selectStateSlotToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.selectStateSlotToolStripMenuItem.Text = "Select State Slo&t";
			// 
			// stateSlot0toolStripMenuItem
			// 
			this.stateSlot0toolStripMenuItem.Checked = true;
			this.stateSlot0toolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.stateSlot0toolStripMenuItem.Name = "stateSlot0toolStripMenuItem";
			this.stateSlot0toolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.stateSlot0toolStripMenuItem.Text = "0";
			// 
			// stateSlot1toolStripMenuItem
			// 
			this.stateSlot1toolStripMenuItem.Name = "stateSlot1toolStripMenuItem";
			this.stateSlot1toolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.stateSlot1toolStripMenuItem.Text = "1";
			// 
			// stateSlot2toolStripMenuItem
			// 
			this.stateSlot2toolStripMenuItem.Name = "stateSlot2toolStripMenuItem";
			this.stateSlot2toolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.stateSlot2toolStripMenuItem.Text = "2";
			// 
			// stateSlot3toolStripMenuItem
			// 
			this.stateSlot3toolStripMenuItem.Name = "stateSlot3toolStripMenuItem";
			this.stateSlot3toolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.stateSlot3toolStripMenuItem.Text = "3";
			// 
			// stateSlot4toolStripMenuItem
			// 
			this.stateSlot4toolStripMenuItem.Name = "stateSlot4toolStripMenuItem";
			this.stateSlot4toolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.stateSlot4toolStripMenuItem.Text = "4";
			// 
			// stateSlot5toolStripMenuItem
			// 
			this.stateSlot5toolStripMenuItem.Name = "stateSlot5toolStripMenuItem";
			this.stateSlot5toolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.stateSlot5toolStripMenuItem.Text = "5";
			// 
			// stateSlot6toolStripMenuItem
			// 
			this.stateSlot6toolStripMenuItem.Name = "stateSlot6toolStripMenuItem";
			this.stateSlot6toolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.stateSlot6toolStripMenuItem.Text = "6";
			// 
			// stateSlot7toolStripMenuItem
			// 
			this.stateSlot7toolStripMenuItem.Name = "stateSlot7toolStripMenuItem";
			this.stateSlot7toolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.stateSlot7toolStripMenuItem.Text = "7";
			// 
			// stateSlot8toolStripMenuItem
			// 
			this.stateSlot8toolStripMenuItem.Name = "stateSlot8toolStripMenuItem";
			this.stateSlot8toolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.stateSlot8toolStripMenuItem.Text = "8";
			// 
			// stateSlot9toolStripMenuItem
			// 
			this.stateSlot9toolStripMenuItem.Name = "stateSlot9toolStripMenuItem";
			this.stateSlot9toolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.stateSlot9toolStripMenuItem.Text = "9";
			// 
			// saveStateToolStripMenuItem
			// 
			this.saveStateToolStripMenuItem.Name = "saveStateToolStripMenuItem";
			this.saveStateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.saveStateToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.saveStateToolStripMenuItem.Text = "&Save State";
			this.saveStateToolStripMenuItem.Click += new System.EventHandler(this.SaveStateToolStripMenuItemClick);
			// 
			// importStateToolStripMenuItem
			// 
			this.importStateToolStripMenuItem.Name = "importStateToolStripMenuItem";
			this.importStateToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.importStateToolStripMenuItem.Text = "&Import State";
			this.importStateToolStripMenuItem.Click += new System.EventHandler(this.ImportStateToolStripMenuItemClick);
			// 
			// exportStateToolStripMenuItem
			// 
			this.exportStateToolStripMenuItem.Name = "exportStateToolStripMenuItem";
			this.exportStateToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.exportStateToolStripMenuItem.Text = "&Export State";
			this.exportStateToolStripMenuItem.Click += new System.EventHandler(this.ExportStateToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
			// 
			// TSMnuItm_File_Exit
			// 
			this.TSMnuItm_File_Exit.Name = "TSMnuItm_File_Exit";
			this.TSMnuItm_File_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.TSMnuItm_File_Exit.Size = new System.Drawing.Size(164, 22);
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
			this.runToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.runToolStripMenuItem.Text = "&Run";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItemClick);
			// 
			// pauseToolStripMenuItem
			// 
			this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
			this.pauseToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.pauseToolStripMenuItem.Text = "&Pause";
			this.pauseToolStripMenuItem.Click += new System.EventHandler(this.PauseToolStripMenuItemClick);
			// 
			// stepToolStripMenuItem
			// 
			this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
			this.stepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
			this.stepToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.stepToolStripMenuItem.Text = "&Step";
			this.stepToolStripMenuItem.Click += new System.EventHandler(this.StepToolStripMenuItemClick);
			// 
			// resumeToolStripMenuItem
			// 
			this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
			this.resumeToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.resumeToolStripMenuItem.Text = "Resu&me";
			this.resumeToolStripMenuItem.Click += new System.EventHandler(this.ResumeToolStripMenuItemClick);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.stopToolStripMenuItem.Text = "&Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItemClick);
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.resetToolStripMenuItem.Text = "Rese&t";
			this.resetToolStripMenuItem.Click += new System.EventHandler(this.ResetToolStripMenuItemClick);
			// 
			// debugToolStripMenuItem
			// 
			this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.debuggerToolStripMenuItem,
									this.dumpMemoryToolStripMenuItem});
			this.debugToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.debugToolStripMenuItem.Text = "&Debug";
			// 
			// debuggerToolStripMenuItem
			// 
			this.debuggerToolStripMenuItem.Name = "debuggerToolStripMenuItem";
			this.debuggerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
			this.debuggerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.debuggerToolStripMenuItem.Text = "&Debugger";
			this.debuggerToolStripMenuItem.Click += new System.EventHandler(this.DebuggerToolStripMenuItemClick);
			// 
			// dumpMemoryToolStripMenuItem
			// 
			this.dumpMemoryToolStripMenuItem.Name = "dumpMemoryToolStripMenuItem";
			this.dumpMemoryToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.dumpMemoryToolStripMenuItem.Text = "D&ump Memory";
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
									this.tstyToolStripMenuItem,
									this.test6502ToolStripMenuItem});
			this.testToolStripMenuItem.ForeColor = System.Drawing.Color.White;
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.testToolStripMenuItem.Text = "Test";
			// 
			// loadRomToolStripMenuItem
			// 
			this.loadRomToolStripMenuItem.Name = "loadRomToolStripMenuItem";
			this.loadRomToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadRomToolStripMenuItem.Text = "load rom";
			this.loadRomToolStripMenuItem.Click += new System.EventHandler(this.LoadRomToolStripMenuItemClick);
			// 
			// tstyToolStripMenuItem
			// 
			this.tstyToolStripMenuItem.Name = "tstyToolStripMenuItem";
			this.tstyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
			this.pnl_display.BackColor = System.Drawing.Color.Black;
			this.pnl_display.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnl_display.Location = new System.Drawing.Point(0, 25);
			this.pnl_display.Name = "pnl_display";
			this.pnl_display.Size = new System.Drawing.Size(540, 159);
			this.pnl_display.TabIndex = 4;
			// 
			// test6502ToolStripMenuItem
			// 
			this.test6502ToolStripMenuItem.Name = "test6502ToolStripMenuItem";
			this.test6502ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.test6502ToolStripMenuItem.Text = "test6502";
			this.test6502ToolStripMenuItem.Click += new System.EventHandler(this.Test6502ToolStripMenuItemClick);
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
		private System.Windows.Forms.ToolStripMenuItem test6502ToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exportStateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importStateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveStateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateSlot9toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateSlot8toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateSlot7toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateSlot6toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateSlot5toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateSlot4toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateSlot3toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateSlot2toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateSlot1toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateSlot0toolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectStateSlotToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadStateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem debuggerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
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
