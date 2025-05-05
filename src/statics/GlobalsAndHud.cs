using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	static class GlobalsAndHud
	{
		public static float score = 0;
		public static float power = 0;

		private static Color[] powerColor = [Color.Red, Color.Orange, Color.Gold, Color.Green, Color.Lime];

		public static int BulletCount;
		
		public static void resetInfo()
		{
			score = 0;
			power = 0;
		}

		public static void DrawGameHud()
		{
			DrawTextEx(GlobalResources.debugFontLargeItalic, "Помірний", new Vector2(600+2, 10+2), 40, 1, Color.Black);
			DrawTextEx(GlobalResources.debugFontLargeItalic, "Помірний", new Vector2(600, 10), 40, 1, Color.Blue);
			// DrawText("Score: ", 500, 30, 20, Color.Gray);
			DrawTextEx(GlobalResources.debugFontMedium, "Очки: ", new Vector2(500, 30), 20, 0.5f, Color.Gray);
			// DrawText(score.ToString("000,000,000"), 500, 50, 40, Color.Gray);
			DrawTextEx(GlobalResources.debugFontLargeItalic, score.ToString("000 000 000"), new Vector2(500, 50), 40, 0, Color.Gray);
			// DrawText($"FPS: {GetFPS()}", 620, 280, 20, Color.Gray);
			DrawTextEx(GlobalResources.debugFontMedium, "Потужність: ", new Vector2(500, 100), 20, 0.5f, Color.Gray);
			DrawTextEx(GlobalResources.debugFontMidMediumItalic, "Ніхуя не потужно", new Vector2(500, 116), 15, 0.5f, Color.Red);
			DrawTextEx(GlobalResources.debugFontMidMediumItalic, "Капець потужно", new Vector2(680, 116), 15, 0.5f, Color.Lime);

			for(int i = 0; i<5; i++)
			{
				DrawRectangle(500 + 55 * i, 130, 50, 50, powerColor[i]);
			}

			DrawRectangleV(new Vector2(500 + power/1.5f, 130), new Vector2(3, 55), Color.Red);

			DrawTextEx(GlobalResources.debugFontMidMediumItalic, ((int)(power/400 * 100)).ToString() + "%", new Vector2(500 + power/1.5f, 185), 15, 0.5f, Color.Gray);
			


			if(power > 400)
			{
				power = 400;
			}
			
			if(IsKeyPressed(KeyboardKey.C))
			{
				power = 400;
			}
			DrawTextEx(GlobalResources.debugFontMedium, $"FPS:{GetFPS()}", new Vector2(620, 280), 20, 0.5f, Color.Gray);
		}
	}
}