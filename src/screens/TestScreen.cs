using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class TestScreen : BaseScreen
	{
		private InGameScreen gameScreen;

		private Texture2D logoTexture;

		public TestScreen()
		{
			gameScreen = new TestInGameScreen();
			logoTexture = LoadTexture("eastSharpEng.png");
		}

		public override void Draw()
		{
			base.Draw();
			BeginDrawing();
			ClearBackground(Color.RayWhite);
			DrawTextureEx(logoTexture, new Vector2(480, 570), -90, 0.3f, Color.Gray);
			DrawText($"FPS: {GetFPS()}", 620, 280, 20, Color.Gray);
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