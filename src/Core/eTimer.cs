#region header
/* User: Erin
 * Date: 3/11/2013
 * Time: 2:35 AM
 */
/* for Emunator */
#endregion
#region using....
using Emu.Core;
using System;
using System.Timers;
#endregion

namespace Emu.Core {
	#region meta
	/// <summary>
	/// Description of eTimer.
	/// </summary>
	#endregion
	public class eTimer : baseClass {
		#region static
		#region static vars
		public static eTimer _mainTimer = null;
		#endregion
		#region static properties
		public static eTimer mainTimer {
			get {
				if(_mainTimer == null)
					_mainTimer = new eTimer();
				return _mainTimer;
			}
			set { _mainTimer = value; }
		}
		#endregion
		#endregion
		#region vars
		protected Timer _timer = null;
		public UInt64 ticks;
		public double interval;
		#endregion
		#region constructors
		public eTimer(): base("eTimer") { IniteTimer(); }
		public eTimer(string name): base(name) { IniteTimer(); }
		protected virtual void IniteTimer() { running = false; HardReset(); }
		#endregion
		#region properties
		public virtual bool running { get; protected set; }
		#endregion
		#region function: HardReset, SoftReset
		public override void HardReset() { HardReset(false); }
		public virtual void HardReset(bool autoStart) {
			base.HardReset();
			SoftReset();
			interval = 0.00000000000002;
			if(_timer != null)
				_timer.Dispose();
			_timer = new Timer(interval);
			_timer.Interval = interval;
			_timer.Elapsed += new ElapsedEventHandler(Tick);
			
			if(autoStart) Start();
		}
		public override void SoftReset() { SoftReset(false); }
		public virtual void SoftReset(bool autoStart) {
			base.SoftReset();
			ticks = 0;
			if(_timer != null) {
				Stop();
				_timer.Interval = interval;
			}

			if(autoStart) Start();
		}
		#endregion
		#region function: Tick
		public virtual void Tick(object s, object e) { unchecked { ticks++; } }
		#endregion
		#region function: Start, Stop
		public virtual void Start() {
			if(!running) {
				_timer.Start();
				running = true;
			}
		}
		public virtual void Stop() {
			if(running) {
				_timer.Stop();
				running = false;
			}
		}
		#endregion
	}
}
