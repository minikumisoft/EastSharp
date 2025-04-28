using System;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	struct ETimer
	{
		public int startTime;

		public ETimer(int frames)
		{
			startTime = frames;
		}


		public void UpdateTimer()
		{
			startTime--;

			if(startTime <= 0)
			{
				startTime = 0;
			}
		}

		public bool TimerDone()
		{
			return startTime <= 0;
		}

		public void SetTimer(int framses)
		{
			startTime = framses;
		}
		
	}
}