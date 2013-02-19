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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebuggerPanel));
			this.menuStrip_main = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.executeX10InstructionsfastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x40ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x60ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x70ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x80ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x90ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.executeXxxInstructionsfastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x300ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x500ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x600ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x700ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x800ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x900ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x1000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
			this.splitContainer_Left = new System.Windows.Forms.SplitContainer();
			this.groupBox_display = new System.Windows.Forms.GroupBox();
			this.splitContainer_BottomLeft = new System.Windows.Forms.SplitContainer();
			this.groupBox_registers = new System.Windows.Forms.GroupBox();
			this.propertyList_registers = new Emu.Core.Controls.PropertyList();
			this.groupBox_misc = new System.Windows.Forms.GroupBox();
			this.propertyList_misc = new Emu.Core.Controls.PropertyList();
			this.groupBox_flow = new System.Windows.Forms.GroupBox();
			this.lbl_cycleCountValue = new System.Windows.Forms.Label();
			this.lbl_pcDecimal = new System.Windows.Forms.Label();
			this.lbl_cycleCount = new System.Windows.Forms.Label();
			this.lbl_pc = new System.Windows.Forms.Label();
			this.numericUpDown_pc = new System.Windows.Forms.NumericUpDown();
			this.panel_flowContainer = new System.Windows.Forms.Panel();
			this.panel_flow = new System.Windows.Forms.Panel();
			this.toolStrip_flow = new System.Windows.Forms.ToolStrip();
			this.toolStripSplitButton_run = new System.Windows.Forms.ToolStripSplitButton();
			this.doCyclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.do10CyclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButton_stop = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_stepInto = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_stepOver = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_temp_run = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_temp_pause = new System.Windows.Forms.ToolStripButton();
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
			this.toolTip_main = new System.Windows.Forms.ToolTip(this.components);
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
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_pc)).BeginInit();
			this.panel_flowContainer.SuspendLayout();
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
									this.stepToolStripMenuItem,
									this.executeX10InstructionsfastToolStripMenuItem,
									this.executeXxxInstructionsfastToolStripMenuItem});
			this.flowToolStripMenuItem.Name = "flowToolStripMenuItem";
			this.flowToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.flowToolStripMenuItem.Text = "F&low";
			// 
			// stepToolStripMenuItem
			// 
			this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
			this.stepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
			this.stepToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.stepToolStripMenuItem.Text = "S&tep";
			this.stepToolStripMenuItem.Click += new System.EventHandler(this.StepToolStripMenuItemClick);
			// 
			// executeX10InstructionsfastToolStripMenuItem
			// 
			this.executeX10InstructionsfastToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.x10ToolStripMenuItem,
									this.x20ToolStripMenuItem,
									this.x30ToolStripMenuItem,
									this.x40ToolStripMenuItem,
									this.x50ToolStripMenuItem,
									this.x60ToolStripMenuItem,
									this.x70ToolStripMenuItem,
									this.x80ToolStripMenuItem,
									this.x90ToolStripMenuItem});
			this.executeX10InstructionsfastToolStripMenuItem.Name = "executeX10InstructionsfastToolStripMenuItem";
			this.executeX10InstructionsfastToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.executeX10InstructionsfastToolStripMenuItem.Text = "Execute xx Instructions (fast)";
			// 
			// x10ToolStripMenuItem
			// 
			this.x10ToolStripMenuItem.Name = "x10ToolStripMenuItem";
			this.x10ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
			this.x10ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.x10ToolStripMenuItem.Tag = "10";
			this.x10ToolStripMenuItem.Text = "x10";
			this.x10ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x20ToolStripMenuItem
			// 
			this.x20ToolStripMenuItem.Name = "x20ToolStripMenuItem";
			this.x20ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
			this.x20ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.x20ToolStripMenuItem.Tag = "20";
			this.x20ToolStripMenuItem.Text = "x20";
			this.x20ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x30ToolStripMenuItem
			// 
			this.x30ToolStripMenuItem.Name = "x30ToolStripMenuItem";
			this.x30ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
			this.x30ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.x30ToolStripMenuItem.Tag = "30";
			this.x30ToolStripMenuItem.Text = "x30";
			this.x30ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x40ToolStripMenuItem
			// 
			this.x40ToolStripMenuItem.Name = "x40ToolStripMenuItem";
			this.x40ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
			this.x40ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.x40ToolStripMenuItem.Tag = "40";
			this.x40ToolStripMenuItem.Text = "x40";
			this.x40ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x50ToolStripMenuItem
			// 
			this.x50ToolStripMenuItem.Name = "x50ToolStripMenuItem";
			this.x50ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
			this.x50ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.x50ToolStripMenuItem.Tag = "50";
			this.x50ToolStripMenuItem.Text = "x50";
			this.x50ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x60ToolStripMenuItem
			// 
			this.x60ToolStripMenuItem.Name = "x60ToolStripMenuItem";
			this.x60ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F6)));
			this.x60ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.x60ToolStripMenuItem.Tag = "60";
			this.x60ToolStripMenuItem.Text = "x60";
			this.x60ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x70ToolStripMenuItem
			// 
			this.x70ToolStripMenuItem.Name = "x70ToolStripMenuItem";
			this.x70ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F7)));
			this.x70ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.x70ToolStripMenuItem.Tag = "70";
			this.x70ToolStripMenuItem.Text = "x70";
			this.x70ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x80ToolStripMenuItem
			// 
			this.x80ToolStripMenuItem.Name = "x80ToolStripMenuItem";
			this.x80ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F8)));
			this.x80ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.x80ToolStripMenuItem.Tag = "80";
			this.x80ToolStripMenuItem.Text = "x80";
			this.x80ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x90ToolStripMenuItem
			// 
			this.x90ToolStripMenuItem.Name = "x90ToolStripMenuItem";
			this.x90ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F9)));
			this.x90ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.x90ToolStripMenuItem.Tag = "90";
			this.x90ToolStripMenuItem.Text = "x90";
			this.x90ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// executeXxxInstructionsfastToolStripMenuItem
			// 
			this.executeXxxInstructionsfastToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.x100ToolStripMenuItem,
									this.x200ToolStripMenuItem,
									this.x300ToolStripMenuItem,
									this.x400ToolStripMenuItem,
									this.x500ToolStripMenuItem,
									this.x600ToolStripMenuItem,
									this.x700ToolStripMenuItem,
									this.x800ToolStripMenuItem,
									this.x900ToolStripMenuItem,
									this.x1000ToolStripMenuItem});
			this.executeXxxInstructionsfastToolStripMenuItem.Name = "executeXxxInstructionsfastToolStripMenuItem";
			this.executeXxxInstructionsfastToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
			this.executeXxxInstructionsfastToolStripMenuItem.Text = "Execute xxx Instructions (fast)";
			// 
			// x100ToolStripMenuItem
			// 
			this.x100ToolStripMenuItem.Name = "x100ToolStripMenuItem";
			this.x100ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F1)));
			this.x100ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.x100ToolStripMenuItem.Tag = "100";
			this.x100ToolStripMenuItem.Text = "x100";
			this.x100ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x200ToolStripMenuItem
			// 
			this.x200ToolStripMenuItem.Name = "x200ToolStripMenuItem";
			this.x200ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F2)));
			this.x200ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.x200ToolStripMenuItem.Tag = "200";
			this.x200ToolStripMenuItem.Text = "x200";
			this.x200ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x300ToolStripMenuItem
			// 
			this.x300ToolStripMenuItem.Name = "x300ToolStripMenuItem";
			this.x300ToolStripMenuItem.ShortcutKeyDisplayString = "Shift+F3";
			this.x300ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.x300ToolStripMenuItem.Tag = "300";
			this.x300ToolStripMenuItem.Text = "x300";
			this.x300ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x400ToolStripMenuItem
			// 
			this.x400ToolStripMenuItem.Name = "x400ToolStripMenuItem";
			this.x400ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F4)));
			this.x400ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.x400ToolStripMenuItem.Tag = "400";
			this.x400ToolStripMenuItem.Text = "x400";
			this.x400ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x500ToolStripMenuItem
			// 
			this.x500ToolStripMenuItem.Name = "x500ToolStripMenuItem";
			this.x500ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
			this.x500ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.x500ToolStripMenuItem.Tag = "500";
			this.x500ToolStripMenuItem.Text = "x500";
			this.x500ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x600ToolStripMenuItem
			// 
			this.x600ToolStripMenuItem.Name = "x600ToolStripMenuItem";
			this.x600ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F6)));
			this.x600ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.x600ToolStripMenuItem.Tag = "600";
			this.x600ToolStripMenuItem.Text = "x600";
			this.x600ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x700ToolStripMenuItem
			// 
			this.x700ToolStripMenuItem.Name = "x700ToolStripMenuItem";
			this.x700ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F7)));
			this.x700ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.x700ToolStripMenuItem.Tag = "700";
			this.x700ToolStripMenuItem.Text = "x700";
			this.x700ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x800ToolStripMenuItem
			// 
			this.x800ToolStripMenuItem.Name = "x800ToolStripMenuItem";
			this.x800ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F8)));
			this.x800ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.x800ToolStripMenuItem.Tag = "800";
			this.x800ToolStripMenuItem.Text = "x800";
			this.x800ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x900ToolStripMenuItem
			// 
			this.x900ToolStripMenuItem.Name = "x900ToolStripMenuItem";
			this.x900ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F9)));
			this.x900ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.x900ToolStripMenuItem.Tag = "900";
			this.x900ToolStripMenuItem.Text = "x900";
			this.x900ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
			// 
			// x1000ToolStripMenuItem
			// 
			this.x1000ToolStripMenuItem.Name = "x1000ToolStripMenuItem";
			this.x1000ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F10)));
			this.x1000ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.x1000ToolStripMenuItem.Tag = "1000";
			this.x1000ToolStripMenuItem.Text = "x1000";
			this.x1000ToolStripMenuItem.Click += new System.EventHandler(this.HandleExecXInstructs);
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
			this.groupBox_flow.Controls.Add(this.lbl_cycleCountValue);
			this.groupBox_flow.Controls.Add(this.lbl_pcDecimal);
			this.groupBox_flow.Controls.Add(this.lbl_cycleCount);
			this.groupBox_flow.Controls.Add(this.lbl_pc);
			this.groupBox_flow.Controls.Add(this.numericUpDown_pc);
			this.groupBox_flow.Controls.Add(this.panel_flowContainer);
			this.groupBox_flow.Location = new System.Drawing.Point(6, 293);
			this.groupBox_flow.Name = "groupBox_flow";
			this.groupBox_flow.Size = new System.Drawing.Size(474, 65);
			this.groupBox_flow.TabIndex = 3;
			this.groupBox_flow.TabStop = false;
			this.groupBox_flow.Text = "Flow";
			// 
			// lbl_cycleCountValue
			// 
			this.lbl_cycleCountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_cycleCountValue.Location = new System.Drawing.Point(403, 16);
			this.lbl_cycleCountValue.Name = "lbl_cycleCountValue";
			this.lbl_cycleCountValue.Size = new System.Drawing.Size(65, 13);
			this.lbl_cycleCountValue.TabIndex = 7;
			this.lbl_cycleCountValue.Text = "0";
			// 
			// lbl_pcDecimal
			// 
			this.lbl_pcDecimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_pcDecimal.Location = new System.Drawing.Point(403, 41);
			this.lbl_pcDecimal.Name = "lbl_pcDecimal";
			this.lbl_pcDecimal.Size = new System.Drawing.Size(65, 13);
			this.lbl_pcDecimal.TabIndex = 5;
			this.lbl_pcDecimal.Text = "512";
			this.toolTip_main.SetToolTip(this.lbl_pcDecimal, "Program Counter (in Decimal)");
			// 
			// lbl_cycleCount
			// 
			this.lbl_cycleCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_cycleCount.AutoSize = true;
			this.lbl_cycleCount.Location = new System.Drawing.Point(330, 16);
			this.lbl_cycleCount.Name = "lbl_cycleCount";
			this.lbl_cycleCount.Size = new System.Drawing.Size(67, 13);
			this.lbl_cycleCount.TabIndex = 6;
			this.lbl_cycleCount.Text = "Cycle Count:";
			// 
			// lbl_pc
			// 
			this.lbl_pc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_pc.AutoSize = true;
			this.lbl_pc.Location = new System.Drawing.Point(285, 41);
			this.lbl_pc.Name = "lbl_pc";
			this.lbl_pc.Size = new System.Drawing.Size(24, 13);
			this.lbl_pc.TabIndex = 3;
			this.lbl_pc.Text = "PC:";
			this.toolTip_main.SetToolTip(this.lbl_pc, "Program Counter");
			// 
			// numericUpDown_pc
			// 
			this.numericUpDown_pc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDown_pc.Hexadecimal = true;
			this.numericUpDown_pc.Location = new System.Drawing.Point(315, 39);
			this.numericUpDown_pc.Maximum = new decimal(new int[] {
									4095,
									0,
									0,
									0});
			this.numericUpDown_pc.Name = "numericUpDown_pc";
			this.numericUpDown_pc.Size = new System.Drawing.Size(82, 20);
			this.numericUpDown_pc.TabIndex = 4;
			this.toolTip_main.SetToolTip(this.numericUpDown_pc, "Program Counter (in Hexa Decimal)");
			this.numericUpDown_pc.Value = new decimal(new int[] {
									512,
									0,
									0,
									0});
			// 
			// panel_flowContainer
			// 
			this.panel_flowContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel_flowContainer.Controls.Add(this.panel_flow);
			this.panel_flowContainer.Location = new System.Drawing.Point(6, 35);
			this.panel_flowContainer.MaximumSize = new System.Drawing.Size(600000, 24);
			this.panel_flowContainer.MinimumSize = new System.Drawing.Size(0, 24);
			this.panel_flowContainer.Name = "panel_flowContainer";
			this.panel_flowContainer.Size = new System.Drawing.Size(273, 24);
			this.panel_flowContainer.TabIndex = 2;
			// 
			// panel_flow
			// 
			this.panel_flow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel_flow.Controls.Add(this.toolStrip_flow);
			this.panel_flow.Location = new System.Drawing.Point(0, 0);
			this.panel_flow.MaximumSize = new System.Drawing.Size(600000, 25);
			this.panel_flow.MinimumSize = new System.Drawing.Size(4, 25);
			this.panel_flow.Name = "panel_flow";
			this.panel_flow.Size = new System.Drawing.Size(274, 25);
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
			this.toolStrip_flow.Size = new System.Drawing.Size(274, 25);
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
			this.toolStripSplitButton_run.Text = "Run: Begins execution.";
			this.toolStripSplitButton_run.ButtonClick += new System.EventHandler(this.ToolStripSplitButton_runButtonClick);
			// 
			// doCyclesToolStripMenuItem
			// 
			this.doCyclesToolStripMenuItem.Name = "doCyclesToolStripMenuItem";
			this.doCyclesToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.doCyclesToolStripMenuItem.Text = "Do ?? cycles";
			// 
			// do10CyclesToolStripMenuItem
			// 
			this.do10CyclesToolStripMenuItem.Name = "do10CyclesToolStripMenuItem";
			this.do10CyclesToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
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
			this.toolStripButton_stop.Text = "Stop: Halts execution.";
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
			this.toolStripButton_stepInto.ToolTipText = "Step Into: Executes the current instruction.";
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
			this.toolStripButton_stepOver.ToolTipText = "Step Over: Skips the current instruction.";
			this.toolStripButton_stepOver.Click += new System.EventHandler(this.ToolStripButton_stepOverClick);
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
			this.groupBox_flow.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_pc)).EndInit();
			this.panel_flowContainer.ResumeLayout(false);
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
		private System.Windows.Forms.Label lbl_cycleCount;
		private System.Windows.Forms.Label lbl_cycleCountValue;
		private System.Windows.Forms.ToolStripMenuItem x1000ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x900ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x800ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x700ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x600ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x500ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x400ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x300ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x200ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x100ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem executeXxxInstructionsfastToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x90ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x80ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x70ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x60ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x50ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x40ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x30ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x20ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x10ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem executeX10InstructionsfastToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip_main;
		private System.Windows.Forms.NumericUpDown numericUpDown_pc;
		private System.Windows.Forms.Label lbl_pc;
		private System.Windows.Forms.Label lbl_pcDecimal;
		private System.Windows.Forms.Panel panel_flowContainer;
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
