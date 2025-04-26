using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class EnemyBoomEffect : BaseEffectObject
	{
		private float radius;
		private float frama;
		private Color color;
		private RTimer lifeTime;

		public EnemyBoomEffect(Vector2 pos)
		{
			Position = pos;
			this.radius = 0;
			frama = 0;
			color = new Color(255, 255, 255, 255);
			lifeTime.StartTimer(3);
		}

		public override void Draw()
		{
			base.Draw();
			DrawCircleV(Position, radius, color);
		}

		public override void Update()
		{
			base.Update();
			frama++;
			if(frama >= 50)
			{
				frama = 50;
			}

			radius = Easings.EaseSineOut(frama, 0, 100, 50);
			color = new Color(255, 255, 255, (int)Easings.EaseSineOut(frama, 255, -255, 50));

			if(lifeTime.TimerDone())
			{
				isDeleted = true;
			}
		}
	}
}