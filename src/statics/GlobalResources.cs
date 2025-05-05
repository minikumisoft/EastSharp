using System;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	static class GlobalResources
	{

		public static Texture2D eastSharpLogoTexture;

		public static Texture2D PlayerBulletCardTexture;
		public static Texture2D EnemyBlueMidBallTexture;
		public static Texture2D cloudTexture;
		public static Texture2D woodBoxTexture;
		public static Texture2D reimuTexture;
		public static Texture2D enemyBlue;

		public static Image cloudImage;

		private static int[] codepoints;
		public static Font debugFontSmall;
		public static Font debugFontMidMediumItalic;
		public static Font debugFontMidMedium;
		public static Font debugFontMedium;
		public static Font debugFontLarge;
		public static Font debugFontLargeItalic;

		public static Music yorigamiMusic;

		public static Sound itemCollectSound;
		public static Sound enemyDeath;
		public static Sound playerShot;
		public static Sound playerDeath;

		public static Model cloudModel;
		public static Model woodBoxModel;

		public static Shader baseShader;

		public static void InitResources()
		{
			eastSharpLogoTexture = LoadTexture("eastSharp.png");
			PlayerBulletCardTexture = LoadTexture("assets/images/91685.png");
			EnemyBlueMidBallTexture = LoadTexture("assets/images/91834.png");
			reimuTexture = LoadTexture("assets/images/91685.png");
			cloudImage = GenImagePerlinNoise(1000, 1000, 0, 0, 5);
			cloudTexture = LoadTextureFromImage(cloudImage);
			woodBoxTexture = LoadTexture("assets/models/WoodBox/cmn_woodbox01_dfsp_a.png");
			enemyBlue = LoadTexture("assets/images/enemies/faily_blue.png");

			codepoints = new int[512];
            for(int i = 0; i < 95; i++)
            {
                codepoints[i] = 32 + i;
            }

            for(int i = 0; i < 255; i++)
            {
                codepoints[95 + i] = 0x400 + i;
            }


			debugFontSmall = LoadFontEx("assets/fonts/JetBrainsMono-Bold.ttf", 10, codepoints, 512);
			debugFontMidMediumItalic = LoadFontEx("assets/fonts/JetBrainsMono-BoldItalic.ttf", 15, codepoints, 512);
			debugFontMidMedium = LoadFontEx("assets/fonts/JetBrainsMono-Bold.ttf", 15, codepoints, 512);
			debugFontMedium = LoadFontEx("assets/fonts/JetBrainsMono-Bold.ttf", 20, codepoints, 512);
			debugFontLarge = LoadFontEx("assets/fonts/JetBrainsMono-Bold.ttf", 40, codepoints, 512);
			debugFontLargeItalic = LoadFontEx("assets/fonts/JetBrainsMono-BoldItalic.ttf", 40, codepoints, 512);

			yorigamiMusic = LoadMusicStream("assets/audio/EgoistFlowers.ogg");

			itemCollectSound = LoadSound("assets/audio/THSSounds/se_item00.wav");
			enemyDeath = LoadSound("assets/audio/THSSounds/se_enep00.wav");
			playerShot = LoadSound("assets/audio/THSSounds/se_plst00.wav");
			playerDeath = LoadSound("assets/audio/THSSounds/se_pldead00.wav");

			cloudModel = LoadModelFromMesh(GenMeshPlane(100, 50, 1, 1));
			woodBoxModel = LoadModel("assets/models/WoodBox/WoodBox.obj");

			baseShader = LoadShader("assets/shaders/lighting.vs", "assets/shaders/fog.fs");
		}

		public static void Unload()
		{
			UnloadTexture(eastSharpLogoTexture);
			UnloadTexture(PlayerBulletCardTexture);
			UnloadTexture(EnemyBlueMidBallTexture);
			UnloadTexture(cloudTexture);
			UnloadTexture(reimuTexture);
			UnloadTexture(woodBoxTexture);
			UnloadTexture(enemyBlue);

			UnloadImage(cloudImage);

			UnloadFont(debugFontSmall);
			UnloadFont(debugFontMidMediumItalic);
			UnloadFont(debugFontMidMedium);
			UnloadFont(debugFontMedium);
			UnloadFont(debugFontLarge);
			UnloadFont(debugFontLargeItalic);
			UnloadMusicStream(yorigamiMusic);

			UnloadSound(itemCollectSound);
			UnloadSound(enemyDeath);
			UnloadSound(playerShot);
			UnloadSound(playerDeath);
		}
	}
}