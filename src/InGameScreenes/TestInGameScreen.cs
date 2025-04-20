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
		private D3background testBackground;

		private Texture2D logoDebugTexture;

		public TestInGameScreen()
		{
			player = new PlayerObject(new Vector2(10, 10));
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
				if(Debug.Debugging)
				{
					DrawTextureEx(logoDebugTexture, new Vector2(12, 12), 0, 0.2f, Color.Black);
					DrawTextureEx(logoDebugTexture, new Vector2(10, 10), 0, 0.2f, Color.White);
				}
			EndTextureMode();

			DrawTexturePro(renderTexture.Texture, new Rectangle(0, 0, GSCREENW, -GSCREENH), new Rectangle(25, 25, GSCREENW, GSCREENH), new Vector2(0, 0), 0, Color.White);
		}

		public override void Update()
		{
			base.Update();
			player.Update();
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