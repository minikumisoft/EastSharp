using System;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	struct RTimer
	{
		public double startTime;
		public double lifeTime;

		public RTimer()
		{
			
		}

		public void StartTimer(double lifeTime)
		{
			startTime = GetTime();
			this.lifeTime = lifeTime;
		}

		public bool TimerDone()
		{
			return GetTime() - startTime >= lifeTime;
		}

		public double GetElapsed()
		{
			return GetTime() - startTime;
		}

	}
}