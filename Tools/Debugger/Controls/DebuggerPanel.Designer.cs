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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebuggerPanel));
			this.menuStrip_main = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
			this.splitContainer_Left = new System.Windows.Forms.SplitContainer();
			this.groupBox_display = new System.Windows.Forms.GroupBox();
			this.splitContainer_BottomLeft = new System.Windows.Forms.SplitContainer();
			this.groupBox_registers = new System.Windows.Forms.GroupBox();
			this.propertyList_registers = new Emu.Core.Controls.PropertyList();
			this.groupBox_misc = new System.Windows.Forms.GroupBox();
			this.propertyList_misc = new Emu.Core.Controls.PropertyList();
			this.groupBox_flow = new System.Windows.Forms.GroupBox();
			this.panel_flow = new System.Windows.Forms.Panel();
			this.toolStrip_flow = new System.Windows.Forms.ToolStrip();
			this.toolStripSplitButton_run = new System.Windows.Forms.ToolStripSplitButton();
			this.doCyclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.do10CyclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButton_stop = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_stepInto = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_stepOver = new System.Windows.Forms.ToolStripButton();
			this.groupBox_memory = new System.Windows.Forms.GroupBox();
			this.tabControl_memory = new System.Windows.Forms.TabControl();
			this.tabPage_memory_program = new System.Windows.Forms.TabPage();
			this.hexBox_memory_program = new Be.Windows.Forms.HexBox();
			this.tabPage_memory_working = new System.Windows.Forms.TabPage();
			this.tabPage_memory_video = new System.Windows.Forms.TabPage();
			this.groupBox_details = new System.Windows.Forms.GroupBox();
			this.splitContainer_base = new System.Windows.Forms.SplitContainer();
			this.groupBox_console = new System.Windows.Forms.GroupBox();
			this.consoleControl_main = new ConsoleControl.consoleControl();
			this.toolStripButton_temp_run = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_temp_pause = new System.Windows.Forms.ToolStripButton();
			this.menuStrip_main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
			this.splitContainer_Main.Panel1.SuspendLayout();
			this.splitContainer_Main.Panel2.SuspendLayout();
			this.splitContainer_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Left)).BeginInit();
			this.splitContainer_Left.Panel1.SuspendLayout();
			this.splitContainer_Left.Panel2.SuspendLayout();
			this.splitContainer_Left.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_BottomLeft)).BeginInit();
			this.splitContainer_BottomLeft.Panel1.SuspendLayout();
			this.splitContainer_BottomLeft.Panel2.SuspendLayout();
			this.splitContainer_BottomLeft.SuspendLayout();
			this.groupBox_registers.SuspendLayout();
			this.groupBox_misc.SuspendLayout();
			this.groupBox_flow.SuspendLayout();
			this.panel_flow.SuspendLayout();
			this.toolStrip_flow.SuspendLayout();
			this.groupBox_memory.SuspendLayout();
			this.tabControl_memory.SuspendLayout();
			this.tabPage_memory_program.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_base)).BeginInit();
			this.splitContainer_base.Panel1.SuspendLayout();
			this.splitContainer_base.Panel2.SuspendLayout();
			this.splitContainer_base.SuspendLayout();
			this.groupBox_console.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip_main
			// 
			this.menuStrip_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.flowToolStripMenuItem});
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
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
			// 
			// flowToolStripMenuItem
			// 
			this.flowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.stepToolStripMenuItem});
			this.flowToolStripMenuItem.Name = "flowToolStripMenuItem";
			this.flowToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.flowToolStripMenuItem.Text = "F&low";
			// 
			// stepToolStripMenuItem
			// 
			this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
			this.stepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
			this.stepToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.stepToolStripMenuItem.Text = "S&tep";
			this.stepToolStripMenuItem.Click += new System.EventHandler(this.StepToolStripMenuItemClick);
			// 
			// splitContainer_Main
			// 
			this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
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
			this.splitContainer_Main.Size = new System.Drawing.Size(699, 361);
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
			this.splitContainer_Left.Size = new System.Drawing.Size(208, 361);
			this.splitContainer_Left.SplitterDistance = 104;
			this.splitContainer_Left.TabIndex = 0;
			// 
			// groupBox_display
			// 
			this.groupBox_display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_display.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.groupBox_display.Location = new System.Drawing.Point(6, 3);
			this.groupBox_display.Name = "groupBox_display";
			this.groupBox_display.Size = new System.Drawing.Size(199, 98);
			this.groupBox_display.TabIndex = 0;
			this.groupBox_display.TabStop = false;
			this.groupBox_display.Text = "Display";
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
			this.splitContainer_BottomLeft.Size = new System.Drawing.Size(208, 253);
			this.splitContainer_BottomLeft.SplitterDistance = 153;
			this.splitContainer_BottomLeft.TabIndex = 0;
			// 
			// groupBox_registers
			// 
			this.groupBox_registers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_registers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.groupBox_registers.Controls.Add(this.propertyList_registers);
			this.groupBox_registers.Location = new System.Drawing.Point(6, 3);
			this.groupBox_registers.Name = "groupBox_registers";
			this.groupBox_registers.Size = new System.Drawing.Size(199, 147);
			this.groupBox_registers.TabIndex = 0;
			this.groupBox_registers.TabStop = false;
			this.groupBox_registers.Text = "Registers";
			// 
			// propertyList_registers
			// 
			this.propertyList_registers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyList_registers.BackColor = System.Drawing.SystemColors.Control;
			this.propertyList_registers.innerSpacer = 0;
			this.propertyList_registers.Location = new System.Drawing.Point(6, 19);
			this.propertyList_registers.Name = "propertyList_registers";
			this.propertyList_registers.outterSpacer = 2;
			this.propertyList_registers.setupMode = false;
			this.propertyList_registers.Size = new System.Drawing.Size(187, 122);
			this.propertyList_registers.TabIndex = 0;
			this.propertyList_registers.verticalSpacer = 1;
			// 
			// groupBox_misc
			// 
			this.groupBox_misc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_misc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.groupBox_misc.Controls.Add(this.propertyList_misc);
			this.groupBox_misc.Location = new System.Drawing.Point(6, 3);
			this.groupBox_misc.Name = "groupBox_misc";
			this.groupBox_misc.Size = new System.Drawing.Size(199, 90);
			this.groupBox_misc.TabIndex = 0;
			this.groupBox_misc.TabStop = false;
			this.groupBox_misc.Text = "Misc.";
			// 
			// propertyList_misc
			// 
			this.propertyList_misc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyList_misc.BackColor = System.Drawing.SystemColors.Control;
			this.propertyList_misc.innerSpacer = 0;
			this.propertyList_misc.Location = new System.Drawing.Point(6, 19);
			this.propertyList_misc.Name = "propertyList_misc";
			this.propertyList_misc.outterSpacer = 2;
			this.propertyList_misc.setupMode = false;
			this.propertyList_misc.Size = new System.Drawing.Size(187, 65);
			this.propertyList_misc.TabIndex = 0;
			this.propertyList_misc.verticalSpacer = 1;
			// 
			// groupBox_flow
			// 
			this.groupBox_flow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_flow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.groupBox_flow.Controls.Add(this.panel_flow);
			this.groupBox_flow.Location = new System.Drawing.Point(6, 293);
			this.groupBox_flow.Name = "groupBox_flow";
			this.groupBox_flow.Size = new System.Drawing.Size(474, 65);
			this.groupBox_flow.TabIndex = 3;
			this.groupBox_flow.TabStop = false;
			this.groupBox_flow.Text = "Flow";
			// 
			// panel_flow
			// 
			this.panel_flow.Controls.Add(this.toolStrip_flow);
			this.panel_flow.Location = new System.Drawing.Point(6, 19);
			this.panel_flow.MaximumSize = new System.Drawing.Size(600000, 25);
			this.panel_flow.MinimumSize = new System.Drawing.Size(4, 25);
			this.panel_flow.Name = "panel_flow";
			this.panel_flow.Size = new System.Drawing.Size(462, 25);
			this.panel_flow.TabIndex = 1;
			// 
			// toolStrip_flow
			// 
			this.toolStrip_flow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.toolStrip_flow.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip_flow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripSplitButton_run,
									this.toolStripButton_stop,
									this.toolStripButton_stepInto,
									this.toolStripButton_stepOver,
									this.toolStripButton_temp_run,
									this.toolStripButton_temp_pause});
			this.toolStrip_flow.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_flow.Name = "toolStrip_flow";
			this.toolStrip_flow.Size = new System.Drawing.Size(462, 25);
			this.toolStrip_flow.TabIndex = 0;
			this.toolStrip_flow.Text = "toolStrip1";
			// 
			// toolStripSplitButton_run
			// 
			this.toolStripSplitButton_run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton_run.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.doCyclesToolStripMenuItem,
									this.do10CyclesToolStripMenuItem});
			this.toolStripSplitButton_run.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_run.Image")));
			this.toolStripSplitButton_run.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton_run.Name = "toolStripSplitButton_run";
			this.toolStripSplitButton_run.Size = new System.Drawing.Size(32, 22);
			this.toolStripSplitButton_run.Text = "toolStripSplitButton1";
			this.toolStripSplitButton_run.ButtonClick += new System.EventHandler(this.ToolStripSplitButton_runButtonClick);
			// 
			// doCyclesToolStripMenuItem
			// 
			this.doCyclesToolStripMenuItem.Name = "doCyclesToolStripMenuItem";
			this.doCyclesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.doCyclesToolStripMenuItem.Text = "Do ?? cycles";
			// 
			// do10CyclesToolStripMenuItem
			// 
			this.do10CyclesToolStripMenuItem.Name = "do10CyclesToolStripMenuItem";
			this.do10CyclesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.do10CyclesToolStripMenuItem.Text = "Do 10 cycles";
			this.do10CyclesToolStripMenuItem.Click += new System.EventHandler(this.Do10CyclesToolStripMenuItemClick);
			// 
			// toolStripButton_stop
			// 
			this.toolStripButton_stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_stop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_stop.Image")));
			this.toolStripButton_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_stop.Name = "toolStripButton_stop";
			this.toolStripButton_stop.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_stop.Text = "toolStripButton1";
			this.toolStripButton_stop.Click += new System.EventHandler(this.ToolStripButton_stopClick);
			// 
			// toolStripButton_stepInto
			// 
			this.toolStripButton_stepInto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_stepInto.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_stepInto.Image")));
			this.toolStripButton_stepInto.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_stepInto.Name = "toolStripButton_stepInto";
			this.toolStripButton_stepInto.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_stepInto.Text = "toolStripButton2";
			this.toolStripButton_stepInto.Click += new System.EventHandler(this.ToolStripButton_stepIntoClick);
			// 
			// toolStripButton_stepOver
			// 
			this.toolStripButton_stepOver.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_stepOver.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_stepOver.Image")));
			this.toolStripButton_stepOver.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_stepOver.Name = "toolStripButton_stepOver";
			this.toolStripButton_stepOver.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_stepOver.Text = "toolStripButton3";
			this.toolStripButton_stepOver.Click += new System.EventHandler(this.ToolStripButton_stepOverClick);
			// 
			// groupBox_memory
			// 
			this.groupBox_memory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_memory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.groupBox_memory.Controls.Add(this.tabControl_memory);
			this.groupBox_memory.Location = new System.Drawing.Point(6, 3);
			this.groupBox_memory.Name = "groupBox_memory";
			this.groupBox_memory.Size = new System.Drawing.Size(474, 221);
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
			this.tabControl_memory.Size = new System.Drawing.Size(462, 196);
			this.tabControl_memory.TabIndex = 0;
			// 
			// tabPage_memory_program
			// 
			this.tabPage_memory_program.Controls.Add(this.hexBox_memory_program);
			this.tabPage_memory_program.Location = new System.Drawing.Point(4, 22);
			this.tabPage_memory_program.Name = "tabPage_memory_program";
			this.tabPage_memory_program.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_memory_program.Size = new System.Drawing.Size(454, 170);
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
			this.hexBox_memory_program.Size = new System.Drawing.Size(448, 164);
			this.hexBox_memory_program.TabIndex = 0;
			// 
			// tabPage_memory_working
			// 
			this.tabPage_memory_working.Location = new System.Drawing.Point(4, 22);
			this.tabPage_memory_working.Name = "tabPage_memory_working";
			this.tabPage_memory_working.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_memory_working.Size = new System.Drawing.Size(454, 170);
			this.tabPage_memory_working.TabIndex = 1;
			this.tabPage_memory_working.Text = "Working";
			this.tabPage_memory_working.UseVisualStyleBackColor = true;
			// 
			// tabPage_memory_video
			// 
			this.tabPage_memory_video.Location = new System.Drawing.Point(4, 22);
			this.tabPage_memory_video.Name = "tabPage_memory_video";
			this.tabPage_memory_video.Size = new System.Drawing.Size(454, 170);
			this.tabPage_memory_video.TabIndex = 2;
			this.tabPage_memory_video.Text = "Video";
			this.tabPage_memory_video.UseVisualStyleBackColor = true;
			// 
			// groupBox_details
			// 
			this.groupBox_details.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_details.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.groupBox_details.Location = new System.Drawing.Point(6, 230);
			this.groupBox_details.Name = "groupBox_details";
			this.groupBox_details.Size = new System.Drawing.Size(474, 57);
			this.groupBox_details.TabIndex = 2;
			this.groupBox_details.TabStop = false;
			this.groupBox_details.Text = "Details";
			// 
			// splitContainer_base
			// 
			this.splitContainer_base.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.splitContainer_base.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer_base.Location = new System.Drawing.Point(0, 24);
			this.splitContainer_base.Name = "splitContainer_base";
			this.splitContainer_base.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer_base.Panel1
			// 
			this.splitContainer_base.Panel1.Controls.Add(this.splitContainer_Main);
			// 
			// splitContainer_base.Panel2
			// 
			this.splitContainer_base.Panel2.Controls.Add(this.groupBox_console);
			this.splitContainer_base.Size = new System.Drawing.Size(699, 469);
			this.splitContainer_base.SplitterDistance = 361;
			this.splitContainer_base.TabIndex = 2;
			// 
			// groupBox_console
			// 
			this.groupBox_console.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox_console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.groupBox_console.Controls.Add(this.consoleControl_main);
			this.groupBox_console.Location = new System.Drawing.Point(6, 3);
			this.groupBox_console.Name = "groupBox_console";
			this.groupBox_console.Size = new System.Drawing.Size(686, 94);
			this.groupBox_console.TabIndex = 0;
			this.groupBox_console.TabStop = false;
			this.groupBox_console.Text = "Console";
			// 
			// consoleControl_main
			// 
			this.consoleControl_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.consoleControl_main.IsInputEnabled = true;
			this.consoleControl_main.Location = new System.Drawing.Point(6, 19);
			this.consoleControl_main.Name = "consoleControl_main";
			this.consoleControl_main.SendKeyboardCommandsToProcess = false;
			this.consoleControl_main.ShowDiagnostics = false;
			this.consoleControl_main.Size = new System.Drawing.Size(674, 69);
			this.consoleControl_main.TabIndex = 0;
			// 
			// toolStripButton_temp_run
			// 
			this.toolStripButton_temp_run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_temp_run.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_temp_run.Image")));
			this.toolStripButton_temp_run.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_temp_run.Name = "toolStripButton_temp_run";
			this.toolStripButton_temp_run.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_temp_run.Text = "toolStripButton1";
			this.toolStripButton_temp_run.Visible = false;
			// 
			// toolStripButton_temp_pause
			// 
			this.toolStripButton_temp_pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton_temp_pause.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_temp_pause.Image")));
			this.toolStripButton_temp_pause.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_temp_pause.Name = "toolStripButton_temp_pause";
			this.toolStripButton_temp_pause.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton_temp_pause.Text = "toolStripButton2";
			this.toolStripButton_temp_pause.Visible = false;
			// 
			// DebuggerPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
			this.Controls.Add(this.splitContainer_base);
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
			this.splitContainer_BottomLeft.Panel1.ResumeLayout(false);
			this.splitContainer_BottomLeft.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_BottomLeft)).EndInit();
			this.splitContainer_BottomLeft.ResumeLayout(false);
			this.groupBox_registers.ResumeLayout(false);
			this.groupBox_misc.ResumeLayout(false);
			this.groupBox_flow.ResumeLayout(false);
			this.panel_flow.ResumeLayout(false);
			this.panel_flow.PerformLayout();
			this.toolStrip_flow.ResumeLayout(false);
			this.toolStrip_flow.PerformLayout();
			this.groupBox_memory.ResumeLayout(false);
			this.tabControl_memory.ResumeLayout(false);
			this.tabPage_memory_program.ResumeLayout(false);
			this.splitContainer_base.Panel1.ResumeLayout(false);
			this.splitContainer_base.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_base)).EndInit();
			this.splitContainer_base.ResumeLayout(false);
			this.groupBox_console.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripButton toolStripButton_temp_pause;
		private System.Windows.Forms.ToolStripButton toolStripButton_temp_run;
		private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem flowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem do10CyclesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem doCyclesToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton_stepOver;
		private System.Windows.Forms.ToolStripButton toolStripButton_stepInto;
		private System.Windows.Forms.ToolStripButton toolStripButton_stop;
		private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_run;
		private System.Windows.Forms.ToolStrip toolStrip_flow;
		private System.Windows.Forms.Panel panel_flow;
		private ConsoleControl.consoleControl consoleControl_main;
		private System.Windows.Forms.GroupBox groupBox_console;
		private System.Windows.Forms.SplitContainer splitContainer_base;
		private Emu.Core.Controls.PropertyList propertyList_misc;
		private System.Windows.Forms.GroupBox groupBox_misc;
		private Emu.Core.Controls.PropertyList propertyList_registers;
		private System.Windows.Forms.GroupBox groupBox_registers;
		private System.Windows.Forms.SplitContainer splitContainer_BottomLeft;
		private System.Windows.Forms.GroupBox groupBox_details;
		private Be.Windows.Forms.HexBox hexBox_memory_program;
		private System.Windows.Forms.GroupBox groupBox_flow;
		private System.Windows.Forms.GroupBox groupBox_display;
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
