using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ToneGenerator
{
	/// <summary>
	/// Summary description for CannedWCAtones.
	/// </summary>
	public class CannedWCAtones
	{

		[DllImport("kernel32.dll")]
		private static extern bool Beep( int frequency, int duration );

		public CannedWCAtones()
		{
			// No constructor logic
		}

		public static void PlayMasterCaution()
		{
		}

		public static void PlayMasterWarning(bool loopSound, int fixedReps)
		{

			int startFreq = 700;
			int endFreq = 1700;
			int duration = 85;
			int dwell = 12;
			int steps = 20;
			int reps = 1;

			if (loopSound == false)
			{
				reps = 1;
			}
			else
			{
				if (fixedReps != 0)
				{
					reps = fixedReps;
				}
			}

			int diff = Math.Abs(startFreq - endFreq);
			diff = Convert.ToInt32(diff/duration);

			for (int rep=0; rep<reps; rep++)
			{
				// tone
				int CurrentFreq = startFreq;

				for(int i=0; i<steps-1; i++)
				{
					Beep(CurrentFreq, Convert.ToInt32(duration/steps));
					CurrentFreq = CurrentFreq + diff;
				}

				// dwell
                Thread.Sleep(dwell);
			}
		}

        public static void PlayMasterWarning2(bool loopSound, int fixedReps)
        {

            int startFreq = 700;
            int endFreq = 1700;
            int duration = 255;
            int dwell = 15;
            int steps = 20;
            int reps = 1;

            if (loopSound == false)
            {
                reps = 1;
            }
            else
            {
                if (fixedReps != 0)
                {
                    reps = fixedReps;
                }
            }

            int diff = Math.Abs(startFreq - endFreq);
            diff = Convert.ToInt32(diff / duration);

            for (int rep = 0; rep < reps; rep++)
            {
                // tone
                int CurrentFreq = startFreq;

                for (int i = 0; i < steps - 1; i++)
                {
                    Beep(CurrentFreq, Convert.ToInt32(duration / steps));
                    CurrentFreq = CurrentFreq + diff;
                }

                // dwell
                Thread.Sleep(dwell);
            }
        }

		public static void PlayWheels()
		{
			int freq1 = 250;
			int duration1 = 200;
			int dwell1 = 1;
			int freq2 = 1;
			int duration2 = 200;
			int dwell2 = 1;
			int reps = 10;

			for (int i=0; i<reps; i++)
			{
				Beep(freq1, duration1);
                Thread.Sleep(dwell1);
				Beep(freq2, duration2);
                Thread.Sleep(dwell2);
			}
		}

		public static void Radiation()
		{
			int freq1 = 500;
			int duration1 = 32;
			int dwell1 = 2;
			int freq2 = 400;
			int duration2 = 30;
			int dwell2 = 2;
			int reps = 20;

			for (int i=0; i<reps; i++)
			{
				Beep(freq1, duration1);
                Thread.Sleep(dwell1);
				Beep(freq2, duration2);
                Thread.Sleep(dwell2);
			}
		}

	}
}
