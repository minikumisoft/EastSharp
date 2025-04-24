using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class TestEnemy : BaseEnemy
	{

		private float clock;
		private float cooldown;

		public TestEnemy(Vector2 pos, float speed, EnemyMoveType type, float angle, List<Bullet> bul)
		{
			cooldown = 60;
			clock = 0;
			HP = 100;
			isDeleted = false;
			bullets = bul;
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

			// for(int i = 0; i < bullets.Count(); i++)
			// {
			// 	bullets[i].Draw();
			// }

			if(Debug.Debugging)
			{
				DrawCircle((int)Position.X + 15, (int)Position.Y + 15, 10, new Color(45, 127, 222, 200));
				// DrawText($"HP: {HP}", (int)Position.X, (int)Position.Y, 10, Color.White);
				DrawTextEx(GlobalResources.debugFontMidMedium, $"HP: {HP}", Position, 15, 0.5f, Color.White);
			}
		}

		public override void Update()
		{
			base.Update();
			cooldown--;

			if(cooldown <= 0)
			{
				clock += 5;
				for(int i = 0; i < 25; i++)
				{
					float ang = 360/25;
					bullets.Add(new Bullet(Position, 2, YorigamiMath.AngleToRadians(i * ang), BulletType.EnemyBlueMidBall));
				}
				cooldown = 15;
			}

			if(clock >= 360)
			{
				clock = 0;
			}

			// for(int i = 0; i < bullets.Count(); i++)
			// {
			// 	bullets[i].Update();

			// 	if(bullets[i].isDeleted)
			// 	{
			// 		bullets[i].Unload();
			// 		bullets.Remove(bullets[i]);
			// 	}
			// }

			
		}

		public override void Unload()
		{
			base.Unload();
		}
	}
}