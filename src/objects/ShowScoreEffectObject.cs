using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class ShowScoreEffect : BaseEffectObject
	{
		private string text;
		private Color color;
		private float gravity;
		private Vector2 velocity;

		public ShowScoreEffect(Vector2 pos, string text, Color color, float jumpPower)
		{
			isDeleted = false;
			Position = pos;
			this.text = text;
			this.color = color;
			gravity = 0.1f;
			velocity.Y = jumpPower;
		}

		public override void Draw()
		{
			base.Draw();
			//BeginBlendMode(BlendMode.Additive);
			DrawTextEx(GlobalResources.debugFontMidMediumItalic, text, new Vector2(Position.X + 1f, Position.Y + 1f), 15, 1, new Color(0, 0, 0, 255));
			DrawTextEx(GlobalResources.debugFontMidMediumItalic, text, Position, 15, 1, color);
			//EndBlendMode();
		}

		public override void Update()
		{
			base.Update();
			velocity.Y += gravity;


			if(Position.Y >= 540)
			{
				isDeleted = true;
			}

			Position += velocity;
		}
	}
}