using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class Box3DObjectTest : D3object
	{
		private Texture2D textureA;
		
		public Box3DObjectTest(Vector3 pos, Shader shader)
		{
			model = LoadModel("assets/models/WoodBox/WoodBox.obj");
			textureA = LoadTexture("assets/models/WoodBox/cmn_woodbox01_dfsp_a.png");

			SetMaterialTexture(ref model, 0, MaterialMapIndex.Albedo, ref textureA);
			

			SetMaterialShader(ref model, 0, ref shader);

			Position = pos;
		}

		public override void Draw()
		{
			DrawModel(model, Position, 0.01f, Color.White);
		}

		public override void Unload()
		{
			UnloadModel(model);
			UnloadTexture(textureA);
		}
	}
}