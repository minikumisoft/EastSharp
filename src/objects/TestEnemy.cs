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
		private float ccccooollldoown;
		private ETimer shootCooldown;
		private RTimer shootYield;

		public TestEnemy(Vector2 pos, float speed, EnemyMoveType type, float angle, List<Bullet> bul)
		{
			cooldown = 0;
			ccccooollldoown = 50;
			shootCooldown = new ETimer(60);
			shootYield = new RTimer();
			clock = 0;
			HP = 2;
			isDeleted = false;
			bullets = new List<Bullet>();
			globalBullets = bul;
			texture = GlobalResources.enemyBlue;
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

			DrawLocalBullets();

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
			shootCooldown.UpdateTimer();

			if(shootCooldown.TimerDone())
			{
				bullets.Add(new Bullet(new Vector2(Position.X + 14, Position.Y + 14), 5, YorigamiMath.AngleToRadians(clock), BulletType.EnemyBlueMidBall));
				if(cooldown < 50)
				{
					shootCooldown.SetTimer(10);
					for(int i = 0; i < bullets.Count() - 3; i++)
					{
						bullets[i].speed = 2;
					}
					cooldown++;
					clock += 5;
				}
				else
				{
					shootCooldown.SetTimer(120);
					for(int i = 0; i < bullets.Count(); i++)
					{
						bullets[i].speed = 2;
					}
					cooldown = 0;
					clock = 0;
				}
			}

			if(clock >= 360)
			{
				clock = 0;
			}

			UpdateLocalBullets();

			if(isDeleted)
			{
				for(int i = 0; i < bullets.Count(); i++)
				{
					bullets[i].speed = 2;
				}


				for(int i = 0; i < bullets.Count(); i++)
				{
					globalBullets.Add(bullets[i]);
				}
			}
		}

		public override void Unload()
		{
			base.Unload();
		}

		private void DrawLocalBullets()
		{
			for(int i = 0; i < bullets.Count(); i++)
			{
				bullets[i].Draw();
			}
		}

		private void UpdateLocalBullets()
		{
			for(int i = 0; i < bullets.Count(); i++)
			{
				bullets[i].Update();

				if(bullets[i].isDeleted)
				{
					bullets[i].Unload();
					bullets.Remove(bullets[i]);
				}
			}
		}
	}
}