using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class Item : BaseObject
	{
		public Vector2 velocity;
		public Texture2D texture;
		public Rectangle textureRecangle;
		public Rectangle collisionRect;
		public float gravity;
		public bool isDeleted;

		public override void Draw()
		{
			base.Draw();
			DrawTexturePro(texture, textureRecangle, new Rectangle(Position, textureRecangle.Width, textureRecangle.Height), new Vector2(0, 0), 0, Color.White);
		}

		public override void Update()
		{
			base.Update();
			Position += velocity;
		}
	}
}