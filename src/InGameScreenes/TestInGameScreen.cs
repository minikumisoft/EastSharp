using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	unsafe class TestInGameScreen : InGameScreen
	{
		private Random rand;
		private PlayerObject player;
		private List<BaseEnemy> enemies;
		private List<Bullet> bullets;
		private List<Item> items;
		private D3background testBackground;

		public TestInGameScreen(TestScreen screen)
		{

			baseScreen = screen;

			PlayMusicStream(GlobalResources.yorigamiMusic);
			rand = new Random();
			player = new PlayerObject(new Vector2(10, 10));
			enemies = new List<BaseEnemy>();
			bullets = new List<Bullet>();
			items = new List<Item>();
			enemies.Add(new TestEnemy(new Vector2(GSCREENW/2, GSCREENH/2), 2, BaseEnemy.EnemyMoveType.Static, 20, bullets));
			//enemies.Add(new TestEnemy(new Vector2(300, 400), 0.1f, BaseEnemy.EnemyMoveType.Static, YorigamiMath.AngleToRadians(-90), bullets));
			for(int i = 0; i < 3; i++)
			{
				enemies.Add(new TestEnemy(new Vector2((GSCREENW/2) + 15 * i, GSCREENH/2), 2, BaseEnemy.EnemyMoveType.Static, 20, bullets));
			}

			testBackground = new TestBackground();
		}

		public override void Draw()
		{
			base.Draw();
			BeginTextureMode(renderTexture);
				ClearBackground(Color.Gray);
				testBackground.Draw();
				player.Draw();

				for(int i = 0; i < enemies.Count(); i++)
				{
					enemies[i].Draw();
				}

				for(int i = 0; i < bullets.Count(); i++)
				{
					bullets[i].Draw();
				}

				for(int i = 0; i < items.Count(); i++)
				{
					items[i].Draw();
				}

				if(Debug.Debugging)
				{
					// DrawText($"BulletCount: {bullets.Count()}", 10, 10, 20, Color.White);
					DrawTextEx(GlobalResources.debugFontMedium, $"Кількість куль на єкрані: {bullets.Count()}\nКількість предметів на єкрані: {items.Count()}", new Vector2(10+2, 10+2), 20, 0.5f, Color.Black);
					DrawTextEx(GlobalResources.debugFontMedium, $"Кількість куль на єкрані: {bullets.Count()}\nКількість предметів на єкрані: {items.Count()}", new Vector2(10, 10), 20, 0.5f, Color.White);
				}
			EndTextureMode();

			DrawTexturePro(renderTexture.Texture, new Rectangle(0, 0, GSCREENW, -GSCREENH), new Rectangle(25, 25, GSCREENW, GSCREENH), new Vector2(0, 0), 0, Color.White);
		}

		public override void Update()
		{
			base.Update();
			player.Update();
			player.isCollided = false;
			player.collidedWith = "None";


			for(int i = 0; i < enemies.Count(); i++)
			{
				enemies[i].Update();
				enemies[i].isCollided = false;

				foreach(Bullet bullet in player.playerBullet)
				{
					if(CheckCollisionCircleRec(new Vector2(enemies[i].Position.X + 15, enemies[i].Position.Y + 15), 10, bullet.collision))
					{
						if(bullet.isPlayerBullet)
						{
							enemies[i].HP -= 1;
							bullet.isDeleted = true;
							GlobalsAndHud.score += 10;
						}
					}
				}

				if(enemies[i].isDeleted)
				{
					PlaySound(GlobalResources.enemyDeath);
					for(int k = 0; k < 10000; k++)
					{
						items.Add(new PointItem(new Vector2(GetRandomValue((int)enemies[i].Position.X - 100, (int)enemies[i].Position.X + 100), enemies[i].Position.Y), YorigamiMath.GetRandomNumber(-2f, -5f)));
					}
					enemies.Remove(enemies[i]);
				}
			}

			for(int i = 0; i < bullets.Count(); i++)
			{
				bullets[i].Update();


				if(bullets[i].isDeleted)
				{
					bullets[i].Unload();
					bullets.Remove(bullets[i]);
				}
			}

			for(int i = 0; i < items.Count(); i++)
			{
				items[i].Update();

				if(CheckCollisionCircleRec(new Vector2(player.Position.X + 17, player.Position.Y + 25), 75, items[i].collisionRect))
				{
					player.isCollided = true;
					player.collidedWith = "Point";
					float angle = YorigamiMath.GetAngleToPlayer(new Vector2(player.Position.X + 17, player.Position.Y + 25), items[i].Position);
					items[i].velocity = new Vector2(MathF.Cos(angle) * 5, MathF.Sin(angle) * 5);
				}

				if(CheckCollisionCircleRec(new Vector2(player.Position.X + 17, player.Position.Y + 25), 10, items[i].collisionRect))
				{
					PlaySound(GlobalResources.itemCollectSound);
					GlobalsAndHud.score += 200;
					items[i].isDeleted = true;
				}

				if(items[i].isDeleted)
				{
					items.Remove(items[i]);
				}
			}
			
			if(IsKeyPressed(KeyboardKey.P))
			{
				items.Add(new PointItem(new Vector2(player.Position.X, player.Position.Y - 100), YorigamiMath.GetRandomNumber(-2f, -3f)));
			}

			if(IsKeyPressed(KeyboardKey.R))
			{
				Unload();
				baseScreen.gameScreen = new TestInGameScreen(baseScreen);
			}

			UpdateMusicStream(GlobalResources.yorigamiMusic);
			
			testBackground.Update();
		}

		public override void Unload()
		{
			base.Unload();
			testBackground.Unload();
			player.Unload();
			UnloadRenderTexture(renderTexture);
		}
	}
}