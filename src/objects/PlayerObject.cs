using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class PlayerObject : BaseObject
	{
		private Texture2D playerTexture;
		private Vector2 tTarget;
		private float playerSpeed;

		public PlayerObject(Vector2 position)
		{
			Position = position;
			playerTexture = LoadTexture("assets/images/91685.png");
			playerSpeed = 3;
		}

		public override void Draw()
		{
			DrawTexturePro(playerTexture, new Rectangle(0, 0, 34, 48), new Rectangle(Position.X, Position.Y, 34, 48), new Vector2(0, 0), 0, Color.White);
			if(Debug.Debugging)
			{
				DrawCircleV(new Vector2(Position.X + 17, Position.Y + 25), 5, new Color(45, 127, 222, 200));
				DrawText($"Pos: {Position}", (int)Position.X, (int)Position.Y, 10, Color.White);
			}
		}

		public override void Update()
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

			Vector2.Normalize(Position);
		}

		public override void Unload()
		{
			base.Unload();
			UnloadTexture(playerTexture);
		}
	}
}