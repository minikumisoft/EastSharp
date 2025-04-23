using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	static class GlobalsAndHud
	{
		public static float score = 0;
		
		public static void resetInfo()
		{
			score = 0;
		}

		public static void DrawGameHud()
		{
			DrawTextEx(GlobalResources.debugFontLargeItalic, "Помірний", new Vector2(600+2, 10+2), 40, 1, Color.Black);
			DrawTextEx(GlobalResources.debugFontLargeItalic, "Помірний", new Vector2(600, 10), 40, 1, Color.Blue);
			// DrawText("Score: ", 500, 30, 20, Color.Gray);
			DrawTextEx(GlobalResources.debugFontMedium, "Score: ", new Vector2(500, 30), 20, 0.5f, Color.Gray);
			// DrawText(score.ToString("000,000,000"), 500, 50, 40, Color.Gray);
			DrawTextEx(GlobalResources.debugFontLargeItalic, score.ToString("000 000 000"), new Vector2(500, 50), 40, 0, Color.Gray);
			// DrawText($"FPS: {GetFPS()}", 620, 280, 20, Color.Gray);
			DrawTextEx(GlobalResources.debugFontMedium, $"FPS:{GetFPS()}", new Vector2(620, 280), 20, 0.5f, Color.Gray);
		}
	}
}