using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class PlayerObject : BaseObject
	{
		private Texture2D playerTexture;
		private float playerSpeed;
		private float shootCooldown;
		public List<Bullet> playerBullet;
		public Color debugColor;

		public PlayerObject(Vector2 position)
		{
			shootCooldown = 5;
			Position = position;
			playerTexture = GlobalResources.reimuTexture;
			playerSpeed = 3;
			debugColor = new Color(127, 127, 127, 200);
			playerBullet = new List<Bullet>();
		}

		public override void Draw()
		{
			DrawTexturePro(playerTexture, new Rectangle(0, 0, 34, 48), new Rectangle(Position.X, Position.Y, 34, 48), new Vector2(0, 0), 0, Color.White);

			for(int i = 0; i < playerBullet.Count(); i++)
			{
				playerBullet[i].Draw();
			}

			if(Debug.Debugging)
			{
				DrawCircleV(new Vector2(Position.X + 17, Position.Y + 25), 75, debugColor);
				DrawCircleV(new Vector2(Position.X + 17, Position.Y + 25), 5, new Color(45, 127, 222, 200));
				// DrawText($"Pos: {Position}\nBullets: {playerBullet.Count}", (int)Position.X, (int)Position.Y, 10, Color.White);
				DrawTextEx(GlobalResources.debugFontMidMedium, $"Pos: {Position}\nBullets: {playerBullet.Count}", Position, 15, 0.5f, Color.White);
			}
		}

		public override void Update()
		{
			HandleInput();
			CheckCorners();
			CollisionHandle();
			if(shootCooldown == 0)
			{
				PlaySound(GlobalResources.playerShot);
				shootCooldown = 5;
				playerBullet.Add(new Bullet(new Vector2(Position.X + 10, Position.Y), 10, YorigamiMath.AngleToRadians(-90), BulletType.PlayerBulletCard));
				playerBullet.Add(new Bullet(new Vector2(Position.X + 25, Position.Y), 10, YorigamiMath.AngleToRadians(-90), BulletType.PlayerBulletCard));
			}


			for(int i = 0; i < playerBullet.Count(); i++)
			{
				playerBullet[i].Update();
				if(playerBullet[i].isDeleted)
				{
					playerBullet[i].Unload();
					playerBullet.Remove(playerBullet[i]);
				}
			}

			Vector2.Normalize(Position);
		}

		public override void Unload()
		{
			base.Unload();
		}

		// PRIVATE FUNCTIONS
		private void HandleInput()
		{
			if(IsKeyDown(KeyboardKey.Down))
			{
				Position += new Vector2(0, 1) * playerSpeed;
			}

			if(IsKeyDown(KeyboardKey.Up))
			{
				Position += new Vector2(0, -1) * playerSpeed;
			}

			if(IsKeyDown(KeyboardKey.Left))
			{
				Position += new Vector2(-1, 0) * playerSpeed;
			}

			if(IsKeyDown(KeyboardKey.Right))
			{
				Position += new Vector2(1, 0) * playerSpeed;
			}

			if(IsKeyDown(KeyboardKey.Z))
			{
				shootCooldown--;
			}
		}

		private void CheckCorners()
		{
			if(Position.X >= 450 - 17)
			{
				Position = new Vector2(450 - 17, Position.Y);
			}
			else if(Position.X < 0 - 17)
			{
				Position = new Vector2(0 - 17, Position.Y); 
			}

			if(Position.Y >= 540 - 25)
			{
				Position = new Vector2(Position.X, 540 - 25);
			}
			else if(Position.Y < 0 - 25)
			{
				Position = new Vector2(Position.X, 0 - 25);
			}
		}

		private void CollisionHandle()
		{
			if(isCollided && collidedWith == "Point")
			{
				debugColor = new Color(157, 157, 157, 200);
			}
			else
			{
				debugColor = new Color(127, 127, 127, 200);
			}
		}
	}
}