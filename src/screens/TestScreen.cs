using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class TestScreen : BaseScreen
	{
		private InGameScreen gameScreen;

		public TestScreen()
		{
			gameScreen = new TestInGameScreen();
		}

		public override void Draw()
		{
			base.Draw();
			BeginDrawing();
			ClearBackground(Color.RayWhite);
			gameScreen.Draw();
			EndDrawing();
		}

		public override void Update()
		{
			base.Update();
			gameScreen.Update();
		}

		public override void Unload()
		{
			base.Unload();
			gameScreen.Unload();
		}
	}
}