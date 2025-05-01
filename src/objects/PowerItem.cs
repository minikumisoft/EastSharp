using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class PowerItem : Item
	{
		public PowerItem(Vector2 pos, float power)
		{
			Position = pos;
			gravity = 0.02f;
			collisionRect = new Rectangle(Position, 12, 12);
			velocity.Y = power;
			texture = GlobalResources.EnemyBlueMidBallTexture;
			textureRecangle = new Rectangle(260, 356, 12, 12);
		}

		public override void Draw()
		{
			base.Draw();
			if(Debug.Debugging)
			{
				DrawRectangleRec(collisionRect, new Color(45, 127, 222, 200));
			}
		}

		public override void Update()
		{
			collisionRect = new Rectangle(Position, collisionRect.Width, collisionRect.Height);
			velocity.Y += gravity;

			if(Position.Y >= 540)
			{
				isDeleted = true;
			}
			base.Update();
		}
	}
}