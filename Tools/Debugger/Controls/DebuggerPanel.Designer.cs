/* User: Erin
 * Date: 2/16/2013
 * Time: 12:10 AM
 */
namespace Emu.Debugger.Controls {
	partial class DebuggerPanel {
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
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
			this.splitContainer_Left = new System.Windows.Forms.SplitContainer();
			this.groupBox_display = new System.Windows.Forms.GroupBox();
			this.groupBox_flow = new System.Windows.Forms.GroupBox();
			this.groupBox_memory = new System.Windows.Forms.GroupBox();
			this.tabControl_memory = new System.Windows.Forms.TabControl();
			this.tabPage_memory_program = new System.Windows.Forms.TabPage();
			this.hexBox_memory_program = new Be.Windows.Forms.HexBox();
			this.tabPage_memory_working = new System.Windows.Forms.TabPage();
			this.tabPage_memory_video = new System.Windows.Forms.TabPage();
			this.groupBox_details = new System.Windows.Forms.GroupBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.splitContainer_BottomLeft = new System.Windows.Forms.SplitContainer();
			this.groupBox_misc = new System.Windows.Forms.GroupBox();
			this.groupBox_registers = new System.Windows.Forms.GroupBox();
			this.propertyList_registers = new Emu.Core.Controls.PropertyList();
			this.propertyList_misc = new Emu.Core.Controls.PropertyList();
			this.menuStrip_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
			this.splitContainer_Main.Panel1.SuspendLayout();
			this.splitContainer_Main.Panel2.SuspendLayout();
			this.splitContainer_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Left)).BeginInit();
			this.splitContainer_Left.Panel1.SuspendLayout();
			this.splitContainer_Left.Panel2.SuspendLayout();
			this.splitContainer_Left.SuspendLayout();
			this.groupBox_memory.SuspendLayout();
			this.tabControl_memory.SuspendLayout();
			this.tabPage_memory_program.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_BottomLeft)).BeginInit();
			this.splitContainer_BottomLeft.Panel1.SuspendLayout();
			this.splitContainer_BottomLeft.Panel2.SuspendLayout();
			this.splitContainer_BottomLeft.SuspendLayout();
			this.groupBox_misc.SuspendLayout();
			this.groupBox_registers.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip_main
			// 
			this.menuStrip_main.BackColor = System.Drawing.SystemColors.Control;
			this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem});
			this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
			this.menuStrip_main.Name = "menuStrip_main";
			this.menuStrip_main.Size = new System.Drawing.Size(699, 24);
			this.menuStrip_main.TabIndex = 0;
			this.menuStrip_main.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			// 
			// splitContainer_Main
			// 
			this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer_Main.Location = new System.Drawing.Point(0, 24);
			this.splitContainer_Main.Name = "splitContainer_Main";
			// 
			// splitContainer_Main.Panel1
			// 
			this.splitContainer_Main.Panel1.Controls.Add(this.splitContainer_Left);
			// 
			// splitContainer_Main.Panel2
			// 
			this.splitContainer_Main.Panel2.Controls.Add(this.groupBox_flow);
			this.splitContainer_Main.Panel2.Controls.Add(this.groupBox_memory);
			this.splitContainer_Main.Panel2.Controls.Add(this.groupBox_details);
			this.splitContainer_Main.Panel2.Controls.Add(this.splitter1);
			this.splitContainer_Main.Size = new System.Drawing.Size(699, 469);
			this.splitContainer_Main.SplitterDistance = 208;
			this.splitContainer_Main.TabIndex = 1;
			// 
			// splitContainer_Left
			// 
			this.splitContainer_Left.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer_Left.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_Left.Name = "splitContainer_Left";
			this.splitContainer_Left.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer_Left.Panel1
			// 
			this.splitContainer_Left.Panel1.Controls.Add(this.groupBox_display);
			// 
			// splitContainer_Left.Panel2
			// 
			this.splitContainer_Left.Panel2.Controls.Add(this.splitContainer_BottomLeft);
			this.splitContainer_Left.Size = new System.Drawing.Size(208, 469);
			this.splitContainer_Left.SplitterDistance = 136;
			this.splitContainer_Left.TabIndex = 0;
			// 
			// groupBox_display
			// 
			this.groupBox_display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_display.Location = new System.Drawing.Point(6, 3);
			this.groupBox_display.Name = "groupBox_display";
			this.groupBox_display.Size = new System.Drawing.Size(199, 130);
			this.groupBox_display.TabIndex = 0;
			this.groupBox_display.TabStop = false;
			this.groupBox_display.Text = "Display";
			// 
			// groupBox_flow
			// 
			this.groupBox_flow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_flow.Location = new System.Drawing.Point(6, 401);
			this.groupBox_flow.Name = "groupBox_flow";
			this.groupBox_flow.Size = new System.Drawing.Size(474, 60);
			this.groupBox_flow.TabIndex = 3;
			this.groupBox_flow.TabStop = false;
			this.groupBox_flow.Text = "Flow";
			// 
			// groupBox_memory
			// 
			this.groupBox_memory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_memory.Controls.Add(this.tabControl_memory);
			this.groupBox_memory.Location = new System.Drawing.Point(6, 3);
			this.groupBox_memory.Name = "groupBox_memory";
			this.groupBox_memory.Size = new System.Drawing.Size(474, 329);
			this.groupBox_memory.TabIndex = 1;
			this.groupBox_memory.TabStop = false;
			this.groupBox_memory.Text = "Memory";
			// 
			// tabControl_memory
			// 
			this.tabControl_memory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl_memory.Controls.Add(this.tabPage_memory_program);
			this.tabControl_memory.Controls.Add(this.tabPage_memory_working);
			this.tabControl_memory.Controls.Add(this.tabPage_memory_video);
			this.tabControl_memory.Location = new System.Drawing.Point(6, 19);
			this.tabControl_memory.Name = "tabControl_memory";
			this.tabControl_memory.SelectedIndex = 0;
			this.tabControl_memory.Size = new System.Drawing.Size(462, 304);
			this.tabControl_memory.TabIndex = 0;
			// 
			// tabPage_memory_program
			// 
			this.tabPage_memory_program.Controls.Add(this.hexBox_memory_program);
			this.tabPage_memory_program.Location = new System.Drawing.Point(4, 22);
			this.tabPage_memory_program.Name = "tabPage_memory_program";
			this.tabPage_memory_program.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_memory_program.Size = new System.Drawing.Size(454, 278);
			this.tabPage_memory_program.TabIndex = 0;
			this.tabPage_memory_program.Text = "Program";
			this.tabPage_memory_program.UseVisualStyleBackColor = true;
			// 
			// hexBox_memory_program
			// 
			this.hexBox_memory_program.Dock = System.Windows.Forms.DockStyle.Fill;
			this.hexBox_memory_program.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hexBox_memory_program.InfoForeColor = System.Drawing.Color.Empty;
			this.hexBox_memory_program.Location = new System.Drawing.Point(3, 3);
			this.hexBox_memory_program.Name = "hexBox_memory_program";
			this.hexBox_memory_program.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
			this.hexBox_memory_program.Size = new System.Drawing.Size(448, 272);
			this.hexBox_memory_program.TabIndex = 0;
			// 
			// tabPage_memory_working
			// 
			this.tabPage_memory_working.Location = new System.Drawing.Point(4, 22);
			this.tabPage_memory_working.Name = "tabPage_memory_working";
			this.tabPage_memory_working.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_memory_working.Size = new System.Drawing.Size(473, 275);
			this.tabPage_memory_working.TabIndex = 1;
			this.tabPage_memory_working.Text = "Working";
			this.tabPage_memory_working.UseVisualStyleBackColor = true;
			// 
			// tabPage_memory_video
			// 
			this.tabPage_memory_video.Location = new System.Drawing.Point(4, 22);
			this.tabPage_memory_video.Name = "tabPage_memory_video";
			this.tabPage_memory_video.Size = new System.Drawing.Size(473, 275);
			this.tabPage_memory_video.TabIndex = 2;
			this.tabPage_memory_video.Text = "Video";
			this.tabPage_memory_video.UseVisualStyleBackColor = true;
			// 
			// groupBox_details
			// 
			this.groupBox_details.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_details.Location = new System.Drawing.Point(6, 338);
			this.groupBox_details.Name = "groupBox_details";
			this.groupBox_details.Size = new System.Drawing.Size(474, 57);
			this.groupBox_details.TabIndex = 2;
			this.groupBox_details.TabStop = false;
			this.groupBox_details.Text = "Details";
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(0, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 469);
			this.splitter1.TabIndex = 0;
			this.splitter1.TabStop = false;
			// 
			// splitContainer_BottomLeft
			// 
			this.splitContainer_BottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer_BottomLeft.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_BottomLeft.Name = "splitContainer_BottomLeft";
			this.splitContainer_BottomLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer_BottomLeft.Panel1
			// 
			this.splitContainer_BottomLeft.Panel1.Controls.Add(this.groupBox_registers);
			// 
			// splitContainer_BottomLeft.Panel2
			// 
			this.splitContainer_BottomLeft.Panel2.Controls.Add(this.groupBox_misc);
			this.splitContainer_BottomLeft.Size = new System.Drawing.Size(208, 329);
			this.splitContainer_BottomLeft.SplitterDistance = 199;
			this.splitContainer_BottomLeft.TabIndex = 0;
			// 
			// groupBox_misc
			// 
			this.groupBox_misc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_misc.Controls.Add(this.propertyList_misc);
			this.groupBox_misc.Location = new System.Drawing.Point(6, 3);
			this.groupBox_misc.Name = "groupBox_misc";
			this.groupBox_misc.Size = new System.Drawing.Size(199, 115);
			this.groupBox_misc.TabIndex = 0;
			this.groupBox_misc.TabStop = false;
			this.groupBox_misc.Text = "Misc.";
			// 
			// groupBox_registers
			// 
			this.groupBox_registers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_registers.Controls.Add(this.propertyList_registers);
			this.groupBox_registers.Location = new System.Drawing.Point(6, 3);
			this.groupBox_registers.Name = "groupBox_registers";
			this.groupBox_registers.Size = new System.Drawing.Size(199, 193);
			this.groupBox_registers.TabIndex = 0;
			this.groupBox_registers.TabStop = false;
			this.groupBox_registers.Text = "Registers";
			// 
			// propertyList_registers
			// 
			this.propertyList_registers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyList_registers.innerSpacer = 0;
			this.propertyList_registers.Location = new System.Drawing.Point(6, 19);
			this.propertyList_registers.Name = "propertyList_registers";
			this.propertyList_registers.outterSpacer = 2;
			this.propertyList_registers.setupMode = false;
			this.propertyList_registers.Size = new System.Drawing.Size(187, 164);
			this.propertyList_registers.TabIndex = 0;
			this.propertyList_registers.verticalSpacer = 1;
			// 
			// propertyList_misc
			// 
			this.propertyList_misc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyList_misc.innerSpacer = 0;
			this.propertyList_misc.Location = new System.Drawing.Point(6, 19);
			this.propertyList_misc.Name = "propertyList_misc";
			this.propertyList_misc.outterSpacer = 2;
			this.propertyList_misc.setupMode = false;
			this.propertyList_misc.Size = new System.Drawing.Size(187, 90);
			this.propertyList_misc.TabIndex = 0;
			this.propertyList_misc.verticalSpacer = 1;
			// 
			// DebuggerPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer_Main);
			this.Controls.Add(this.menuStrip_main);
			this.Name = "DebuggerPanel";
			this.Size = new System.Drawing.Size(699, 493);
			this.menuStrip_main.ResumeLayout(false);
			this.menuStrip_main.PerformLayout();
			this.splitContainer_Main.Panel1.ResumeLayout(false);
			this.splitContainer_Main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
			this.splitContainer_Main.ResumeLayout(false);
			this.splitContainer_Left.Panel1.ResumeLayout(false);
			this.splitContainer_Left.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Left)).EndInit();
			this.splitContainer_Left.ResumeLayout(false);
			this.groupBox_memory.ResumeLayout(false);
			this.tabControl_memory.ResumeLayout(false);
			this.tabPage_memory_program.ResumeLayout(false);
			this.splitContainer_BottomLeft.Panel1.ResumeLayout(false);
			this.splitContainer_BottomLeft.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_BottomLeft)).EndInit();
			this.splitContainer_BottomLeft.ResumeLayout(false);
			this.groupBox_misc.ResumeLayout(false);
			this.groupBox_registers.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private Emu.Core.Controls.PropertyList propertyList_misc;
		private System.Windows.Forms.GroupBox groupBox_misc;
		private Emu.Core.Controls.PropertyList propertyList_registers;
		private System.Windows.Forms.GroupBox groupBox_registers;
		private System.Windows.Forms.SplitContainer splitContainer_BottomLeft;
		private System.Windows.Forms.GroupBox groupBox_details;
		private Be.Windows.Forms.HexBox hexBox_memory_program;
		private System.Windows.Forms.GroupBox groupBox_flow;
		private System.Windows.Forms.GroupBox groupBox_display;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TabPage tabPage_memory_video;
		private System.Windows.Forms.TabPage tabPage_memory_working;
		private System.Windows.Forms.TabPage tabPage_memory_program;
		private System.Windows.Forms.TabControl tabControl_memory;
		private System.Windows.Forms.GroupBox groupBox_memory;
		private System.Windows.Forms.SplitContainer splitContainer_Left;
		private System.Windows.Forms.SplitContainer splitContainer_Main;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip_main;
	}
}
