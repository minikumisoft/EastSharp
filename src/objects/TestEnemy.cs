using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class TestEnemy : BaseEnemy
	{
		public TestEnemy(Vector2 pos, float speed, EnemyMoveType type, float angle)
		{
			HP = 100;
			isDeleted = false;
			bullets = new List<Bullet>();
			texture = LoadTexture("assets/images/enemies/faily_blue.png");
			textureRect = new Rectangle(1, 1, 29, 29);
			Position = pos;
			enemyMoveType = type;
			this.speed = speed;
			this.angle = angle;
		}

		public override void Draw()
		{
			base.Draw();
			DrawTexturePro(texture, textureRect, new Rectangle(Position, textureRect.Width, textureRect.Height), new Vector2(0, 0), 0, Color.White);
			if(Debug.Debugging)
			{
				DrawCircle((int)Position.X + 15, (int)Position.Y + 15, 10, new Color(45, 127, 222, 200));
				DrawText($"HP: {HP}", (int)Position.X, (int)Position.Y, 10, Color.White);
			}
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Unload()
		{
			base.Unload();
		}
	}
}