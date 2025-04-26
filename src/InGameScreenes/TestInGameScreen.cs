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
		private List<BaseEffectObject> effects;
		private D3background testBackground;

		public TestInGameScreen(TestScreen screen)
		{

			baseScreen = screen;

			//PlayMusicStream(GlobalResources.yorigamiMusic);
			rand = new Random();
			player = new PlayerObject(new Vector2(10, 10));
			enemies = new List<BaseEnemy>();
			bullets = new List<Bullet>();
			items = new List<Item>();
			effects = new List<BaseEffectObject>();
			// enemies.Add(new TestEnemy(new Vector2(GSCREENW/2, GSCREENH/2), 2, BaseEnemy.EnemyMoveType.Static, 20, bullets));
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
				ClearBackground(Color.Black);
				testBackground.Draw();
				player.Draw();

				DrawEnemies();
				DrawBullets();
				DrawItems();
				DrawEffects();

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

			UpdateEnemies();
			UpdateBullets();
			UpdateItems();
			UpdateEffects();
			
			if(IsKeyDown(KeyboardKey.P))
			{
				items.Add(new PointItem(new Vector2(player.Position.X, player.Position.Y - 100), YorigamiMath.GetRandomNumber(-2f, -3f)));
				items.Add(new PowerItem(new Vector2(player.Position.X, player.Position.Y - 100), YorigamiMath.GetRandomNumber(-2f, -3f)));
			}

			if(IsKeyPressed(KeyboardKey.E))
			{
				enemies.Add(new TestEnemy(player.Position, 0, BaseEnemy.EnemyMoveType.Static, 0, bullets));
			}

			if(IsKeyPressed(KeyboardKey.R))
			{
				GlobalsAndHud.resetInfo();
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


		/*ПАРАМЕТРИ КУЛЬ*/

		private void DrawBullets()
		{
			for(int i = 0; i < bullets.Count(); i++)
			{
				bullets[i].Draw();
			}
		}

		private void UpdateBullets()
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

		/*ПАРАМЕТРИ ВОРОГІВ*/

		private void DrawEnemies()
		{
			for(int i = 0; i < enemies.Count(); i++)
			{
				enemies[i].Draw();
			}
		}

		private void UpdateEnemies()
		{
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
					effects.Add(new EnemyBoomEffect(enemies[i].Position));
					for(int k = 0; k < 5; k++)
					{
						items.Add(new PointItem(new Vector2(GetRandomValue((int)enemies[i].Position.X - 100, (int)enemies[i].Position.X + 100), enemies[i].Position.Y), YorigamiMath.GetRandomNumber(-2f, -5f)));
						items.Add(new PowerItem(new Vector2(GetRandomValue((int)enemies[i].Position.X - 100, (int)enemies[i].Position.X + 100), enemies[i].Position.Y), YorigamiMath.GetRandomNumber(-2f, -5f)));
					}
					enemies.Remove(enemies[i]);
				}
			}
		}

		/*ПАРАМЕТРИ ПРЕДМЕТІВ*/
		
		private void DrawItems()
		{
			for(int i = 0; i < items.Count(); i++)
			{
				items[i].Draw();
			}
		}

		private void UpdateItems()
		{
			for(int i = 0; i < items.Count(); i++)
			{
				items[i].Update();

				if(CheckCollisionCircleRec(new Vector2(player.Position.X + 17, player.Position.Y + 25), 75, items[i].collisionRect))
				{
					player.isCollided = true;
					player.collidedWith = "Item";
					float angle = YorigamiMath.GetAngleToPlayer(new Vector2(player.Position.X + 17, player.Position.Y + 25), items[i].Position);
					items[i].velocity = new Vector2(MathF.Cos(angle) * 5, MathF.Sin(angle) * 5);
				}

				if(CheckCollisionCircleRec(new Vector2(player.Position.X + 17, player.Position.Y + 25), 10, items[i].collisionRect))
				{
					PlaySound(GlobalResources.itemCollectSound);

					if(items[i] is PointItem)
					{
						effects.Add(new ShowScoreEffect(items[i].Position, "+200", new Color(0, 0, 255, 255), YorigamiMath.GetRandomNumber(-5, -7)));
						GlobalsAndHud.score += 200;
					}
					else if(items[i] is PowerItem)
					{
						if(GlobalsAndHud.power >= 400)
						{
							effects.Add(new ShowScoreEffect(items[i].Position, "MAX", new Color(255, 0, 0, 255), YorigamiMath.GetRandomNumber(-5, -7)));
						}
						else
						{
							effects.Add(new ShowScoreEffect(items[i].Position, "+1", new Color(255, 0, 0, 255), YorigamiMath.GetRandomNumber(-5, -7)));
						}
						GlobalsAndHud.power++;
					}

					items[i].isDeleted = true;
				}

				if(items[i].isDeleted)
				{
					items.Remove(items[i]);
				}
			}
		}

		private void DrawEffects()
		{
			for(int i = 0; i < effects.Count(); i++)
			{
				effects[i].Draw();
			}
		}

		private void UpdateEffects()
		{
			for(int i = 0; i < effects.Count(); i++)
			{
				effects[i].Update();

				if(effects[i].isDeleted)
				{
					effects.Remove(effects[i]);
				}
			}
		}
	}
}