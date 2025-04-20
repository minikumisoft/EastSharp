using System;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	static class GameWindow
	{
		private static BaseScreen screen;

		public static void Run()
		{
			InitWindow(800, 600, "EastSharp");
			ToggleFullscreen();
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

			if(Debug.Debugging)
			{
				SetMousePosition(800/2, 600/2);
			}
		}

		public static void ChangeScreen(BaseScreen newScreen)
		{
			screen.Unload();
			screen = newScreen;
		}
	}
}