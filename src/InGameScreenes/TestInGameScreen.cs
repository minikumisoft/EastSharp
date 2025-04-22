using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	unsafe class TestInGameScreen : InGameScreen
	{
		private PlayerObject player;
		private List<BaseEnemy> enemies;
		private List<Bullet> bullets;
		private D3background testBackground;

		private Texture2D logoDebugTexture;

		public TestInGameScreen()
		{
			player = new PlayerObject(new Vector2(10, 10));
			enemies = new List<BaseEnemy>();
			bullets = new List<Bullet>();
			enemies.Add(new TestEnemy(new Vector2(300, 300), 2, BaseEnemy.EnemyMoveType.Static, 20, bullets));

			testBackground = new TestBackground();
			logoDebugTexture = LoadTexture("eastSharp.png");
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

				if(Debug.Debugging)
				{
					DrawTextureEx(logoDebugTexture, new Vector2(12, 12), 0, 0.2f, Color.Black);
					DrawTextureEx(logoDebugTexture, new Vector2(10, 10), 0, 0.2f, Color.White);
					DrawText($"FPS: {GetFPS()}\nBulletInScreen: {bullets.Count}", 10, 90, 10, Color.White);
				}
			EndTextureMode();

			DrawTexturePro(renderTexture.Texture, new Rectangle(0, 0, GSCREENW, -GSCREENH), new Rectangle(25, 25, GSCREENW, GSCREENH), new Vector2(0, 0), 0, Color.White);
		}

		public override void Update()
		{
			base.Update();
			player.Update();

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
						}
					}
				}

				if(enemies[i].isDeleted)
				{
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
			

			testBackground.Update();
		}

		public override void Unload()
		{
			base.Unload();
			testBackground.Unload();
			player.Unload();
			UnloadTexture(logoDebugTexture);
		}
	}
}