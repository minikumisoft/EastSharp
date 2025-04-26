using System;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class BaseEffectObject : BaseObject
	{
		public bool isDeleted;

		public override void Draw()
		{
			base.Draw();
		}

		public override void Update()
		{
			base.Update();
		}
	}
}