using System;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	static class GameWindow
	{
		public static int gameWindowWidth = 800;
        public static int gameWindowHeight = 600;


		private static BaseScreen screen;

		public static void Run()
		{
			InitWindow(800, 600, "EastSharp");
			InitAudioDevice();
			//ToggleFullscreen();
			SetTargetFPS(60);
			screen = new TestScreen();
			MainLoop(); 
		}

		private static void MainLoop()
		{
			while(!WindowShouldClose())
			{
				MainDraw();
				MainUpdate();
			}
			screen.Unload();
			CloseWindow();
		}

		private static void MainDraw()
		{
			screen.Draw();
		}

		private static void MainUpdate()
		{
			screen.Update();
			baseInputs();
		}

		public static void ChangeScreen(BaseScreen newScreen)
		{
			screen.Unload();
			screen = newScreen;
		}

		private static void baseInputs()
		{
			if(IsKeyPressed(KeyboardKey.Tab))
			{
				if(Debug.Debugging == false)
				{
					Debug.Debugging = true;
				}
				else
				{
					Debug.Debugging = false;
				}

			}
			
			if(IsKeyPressed(KeyboardKey.F2))
			{
				TakeScreenshot("funnymemescreenshot.png");
			}

			if(Debug.Debugging)
			{
				//SetMousePosition(800/2, 600/2);
			}

			if(IsKeyPressed(KeyboardKey.F11))
			{
				ToggleFullscreen();
			}
		}
	}
}