#region header
/* User: Erin
 * Date: 2/16/2013
 * Time: 12:10 AM
 */
#endregion
#region using....
using Be.Windows.Forms;
using ConsoleControl;
using Emu.Core;
using Emu.Display;
using Emu.Debugger.Modules;
using Emu.Machine;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
#endregion

namespace Emu.Debugger.Controls {
	#region meta
	/// <summary>
	/// Full Debugger GUI.
	/// </summary>
	#endregion
	public partial class DebuggerPanel : UserControl {
		#region vars
		public bool _dirty = false;
		protected Disp_Base _display = null;
		protected DebuggerModule_Base _module = null;
		protected M_Base _machine = null;
		
		protected bool InHexBox_memory_program_CurrentLineChanged = false;
		#endregion
		#region constructors
		public DebuggerPanel() { InitDebuggerPanel(null, null); }
		public DebuggerPanel(M_Base _Machine) {
			InitDebuggerPanel(_Machine, null);
		}
		public DebuggerPanel(M_Base _Machine, DebuggerModule_Base mod) {
			InitDebuggerPanel(_Machine, mod);
		}
		protected virtual void InitDebuggerPanel(M_Base _Machine
		                                         , DebuggerModule_Base mod) {
			InitializeComponent();
			hexBox_memory_program.CurrentLineChanged
							+= hexBox_memory_program_CurrentLineChanged;
			hexBox_memory_program.CurrentPositionInLineChanged
							+= hexBox_memory_program_CurrentLineChanged;

			hexBox_memory_program.VScrollBarVisible = true;
			hexBox_memory_program.StringViewVisible = true;
			hexBox_memory_program.LineInfoVisible = true;
			hexBox_memory_program.HexCasing = HexCasing.Upper;
			hexBox_memory_program.GroupSeparatorVisible = true;
			hexBox_memory_program.ColumnInfoVisible = true;

			machine = _Machine;
			module = mod;
			
		}
		#endregion
		#region events
		#endregion
		#region properties
		public virtual M_Base machine {
			get { return _machine; }
			set {
				if(_machine != value) {
					OnBeforeMachineChanged(new EventArgs());
					_machine = value;
					OnMachineChanged(new EventArgs());
				}
			}
		}
		public virtual DebuggerModule_Base module {
			get { return _module; }
			set {
				if(_module != value) {
					OnBeforeModuleChanged(new EventArgs());
					_module = value;
					OnModuleChanged(new EventArgs());
				}
			}
		}
		#endregion
		#region On....
		protected virtual void OnBeforeMachineChanged(EventArgs e) {
			if(machine != null) {
				machine.cpu._console = null;
			}
		}
		protected virtual void OnBeforeModuleChanged(EventArgs e) {
			
		}
		protected virtual void OnMachineChanged(EventArgs e) {
			_display = machine.display;
			if(_display != null) {
				if(_display.Parent != null)
					_display.Parent.Controls.Remove(_display);
				groupBox_display.Controls.Add(_display);
				_display.Dock = DockStyle.Fill;
			}
			machine.cpu._console = new consoleRef(consoleControl_main);
		}
		protected virtual void OnModuleChanged(EventArgs e) {
			if(_machine != null) {
				_module.Init(machine, new consoleRef(consoleControl_main));
				propertyList_misc.Clear();
				propertyList_registers.Clear();
				_module.SetupMisc(propertyList_misc);
				_module.SetupRegisters(propertyList_registers);
				_module.UpdateGui_programMemory(hexBox_memory_program);
			}
		}
		#endregion
		#region function: blah
		#endregion
		#region handlers: flow toolbar
		protected virtual void ToolStripSplitButton_runButtonClick(object sender, EventArgs e) {
			if(!machine.running) {
				toolStripSplitButton_run.Image
								= toolStripButton_temp_pause.Image;
				machine.Run();
			}
			else if(machine.paused) {
				UpdateValues();
				toolStripSplitButton_run.Image
								= toolStripButton_temp_pause.Image;
				machine.Resume();
			}
			else {
				machine.Pause();
				toolStripSplitButton_run.Image
								= toolStripButton_temp_run.Image;
				UpdateGui();
			}
		}
		protected virtual void ToolStripButton_stopClick(object sender, EventArgs e) {
			machine.Stop();
			UpdateGui();
		}
		protected virtual void ToolStripButton_stepIntoClick(object sender, EventArgs e) {
			Step();
		}
		protected virtual void ToolStripButton_stepOverClick(object sender, EventArgs e) {
			machine.StepOver();
			UpdateGui();
		}
		protected virtual void Do10CyclesToolStripMenuItemClick(object sender, EventArgs e) {
			StepX(10);
		}
		#endregion
		#region function: Step, StepX
		public virtual void Step() {
			UpdateValues();
			machine.StepInto();
			UpdateGui();
		}
		public virtual void StepX(Int32 x
						, bool updateValues=true, bool updateGui = true) {
			if(updateValues)
				UpdateValues();
			for(int i = 0; i < x; i++)
				machine.StepInto();
			if(updateGui)
				UpdateGui();
		}
		#endregion
		#region function: UpdateGui, UpdateValues
		public virtual void UpdateGui() {
			Int32 i;
			
			_module.UpdateGui_misc(propertyList_misc);
			_module.UpdateGui_programMemory(hexBox_memory_program);
			_module.UpdateGui_registers(propertyList_registers);
			_module.UpdateGui_videoMemory(null);
			_module.UpdateGui_workingMemory(null);
			
			i = _module.GetPC();
			lbl_pcDecimal.Text = i.ToString();
			numericUpDown_pc.Value = i;

			lbl_cycleCountValue.Text = _module.GetCycleCount().ToString();
			
			_dirty = false;
		}
		public virtual void UpdateValues() {
			_module.UpdateValues_misc(propertyList_misc);
			_module.UpdateValues_programMemory(hexBox_memory_program);
			_module.UpdateValues_registers(propertyList_registers);
			_module.UpdateValues_videoMemory(null);
			_module.UpdateValues_workingMemory(null);
		}
		#endregion
		
		void CloseToolStripMenuItemClick(object sender, EventArgs e) {
			if(machine != null) machine.Pause();
			if(ParentForm != null) ParentForm.Close();
		}
		
		void StepToolStripMenuItemClick(object sender, EventArgs e) {
			Step();
		}
		
		void HandleExecXInstructs(object sender, EventArgs e) {
			machine.Pause();
			ToolStripMenuItem itm = (ToolStripMenuItem)sender;
			
			Int32 i = Convert.ToInt32((string)itm.Tag);
			StepX(i);
		}
	
		protected virtual void hexBox_memory_program_CurrentLineChanged(
						object sender, EventArgs e) {

			if(InHexBox_memory_program_CurrentLineChanged) return;
			InHexBox_memory_program_CurrentLineChanged = true;

			

			InHexBox_memory_program_CurrentLineChanged = false;
		}
	}
}
