using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class StageTitleEffectObject : BaseEffectObject
	{
		
		private float animation;

		private float someShit;
		private float titleX;

		private string Title;
		private string Desc;

		private ETimer eTimer;

		public StageTitleEffectObject(string Title, string Desc)
		{
			Position = new Vector2(0, 30);
			eTimer = new ETimer(400);
			animation = 0;
			someShit = 0;
			titleX = 0;
			this.Title = Title;
			this.Desc = Desc;
		}

		public override void Draw()
		{
			base.Draw();
			DrawRectangleV(Position, new Vector2(450, someShit), new Color(0, 0, 0, 200));
			DrawTextEx(GlobalResources.debugFontLargeItalic, Title, new Vector2(Position.X + titleX + 2, Position.Y + 2 + 2), 40, 1, Color.Black);
			DrawTextEx(GlobalResources.debugFontLargeItalic, Title, new Vector2(Position.X + titleX, Position.Y + 2), 40, 1, Color.White);
			DrawTextEx(GlobalResources.debugFontMidMediumItalic, Desc, new Vector2(Position.X + titleX + 2, Position.Y + 40), 15, 1, Color.White);
		}

		public override void Update()
		{
			base.Update();
			eTimer.UpdateTimer();

			if(animation !<= 200 && !eTimer.TimerDone())
			{
				animation++;
			}

			if(eTimer.TimerDone())
			{
				animation--;
			}

			someShit = Easings.EaseSineOut(animation, 0, 100, 200);
			titleX = Easings.EaseSineOut(animation, -1000, 1010, 200);

			if(animation < 0)
			{
				isDeleted = true;
			}
		}
	}
}