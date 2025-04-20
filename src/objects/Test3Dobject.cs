using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class Test3Dobject : D3object
	{
		private Texture2D bodyTexture;
		private Texture2D eyesTexture;
		private Texture2D mouthTexture;
		
		public Test3Dobject(Vector3 pos)
		{
			model = LoadModel("assets/models/aya/Aya.obj");
			bodyTexture = LoadTexture("assets/models/aya/body01.png");
			Position = pos;
		}
	}
}