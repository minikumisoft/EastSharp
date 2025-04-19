using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class SolidObject : BaseObject
	{
		public SolidObject(Vector2 position)
		{
			Position = position;
			CollisionDetect = new Rectangle(Position, 25, 25);
		}

		public override void Draw()
		{
			base.Draw();
			DrawRectangleRec(CollisionDetect, Color.Black);
		}

		public override void Update()
		{
			base.Update();
			CollisionDetect = new Rectangle(Position, 25, 25);
		}
	}
}