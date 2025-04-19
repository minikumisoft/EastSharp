using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class InGameScreen
	{
		public const int GSCREENW = 450;
		public const int GSCREENH = 540;

		public RenderTexture2D renderTexture = LoadRenderTexture(GSCREENW, GSCREENH);

		public virtual void Draw()
		{

		}


		public virtual void Update()
		{

		}

		public virtual void Unload()
		{

		}
	}
}