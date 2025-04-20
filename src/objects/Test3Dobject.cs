using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class Test3Dobject : D3object
	{
		private Texture2D bodyTexture;
		private Texture2D mouthTexture;

		public Test3Dobject(Vector3 pos, Shader shader)
		{
			model = LoadModel("assets/models/marisa/Marisa_Kirisame.obj");
			bodyTexture = LoadTexture("assets/models/marisa/marisa.png");
			mouthTexture = LoadTexture("assets/models/marisa/mouth_smile.png");
			
			SetMaterialTexture(ref model, 2, MaterialMapIndex.Albedo, ref bodyTexture);
			SetMaterialTexture(ref model, 0, MaterialMapIndex.Albedo, ref bodyTexture);
			SetMaterialShader(ref model, 0, ref shader);
			SetMaterialShader(ref model, 1, ref shader);
			SetMaterialShader(ref model, 2, ref shader);

			Position = pos;
		}

		public override void Draw()
		{
			DrawModel(model, Position, 1, Color.White);
		}

		public override void Unload()
		{
			UnloadModel(model);
			UnloadTexture(bodyTexture);
			UnloadTexture(mouthTexture);
		}
	}
}