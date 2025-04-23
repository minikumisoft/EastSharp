using System;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	static class GlobalResources
	{

		public static Texture2D PlayerBulletCardTexture;
		public static Texture2D EnemyBlueMidBallTexture;
		private static int[] codepoints;
		public static Font debugFontSmall;
		public static Font debugFontMidMedium;
		public static Font debugFontMedium;
		public static Font debugFontLarge;
		public static Font debugFontLargeItalic;

		public static void InitResources()
		{
			PlayerBulletCardTexture = LoadTexture("assets/images/91685.png");
			EnemyBlueMidBallTexture = LoadTexture("assets/images/91834.png");

			codepoints = new int[512];
            for(int i = 0; i < 95; i++)
            {
                codepoints[i] = 32 + i;
            }

            for(int i = 0; i < 255; i++)
            {
                codepoints[95 + i] = 0x400 + i;
            }


			debugFontSmall = LoadFontEx("assets/fonts/JetBrainsMono-bold.ttf", 10, codepoints, 512);
			debugFontMidMedium = LoadFontEx("assets/fonts/JetBrainsMono-bold.ttf", 15, codepoints, 512);
			debugFontMedium = LoadFontEx("assets/fonts/JetBrainsMono-bold.ttf", 20, codepoints, 512);
			debugFontLarge = LoadFontEx("assets/fonts/JetBrainsMono-bold.ttf", 40, codepoints, 512);
			debugFontLargeItalic = LoadFontEx("assets/fonts/JetBrainsMono-BoldItalic.ttf", 40, codepoints, 512);
		}

		public static void Unload()
		{
			UnloadTexture(PlayerBulletCardTexture);
			UnloadTexture(EnemyBlueMidBallTexture);
		}
	}
}