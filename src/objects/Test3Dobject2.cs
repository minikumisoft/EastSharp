using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class Box3DObjectTest : D3object
	{
		private Texture2D textureA;
		private float time;
		
		public Box3DObjectTest(Vector3 pos, Shader shader, Vector3 rotation)
		{
			model = LoadModel("assets/models/WoodBox/WoodBox.obj");
			textureA = LoadTexture("assets/models/WoodBox/cmn_woodbox01_dfsp_a.png");
			time = 0;
			SetMaterialTexture(ref model, 0, MaterialMapIndex.Albedo, ref textureA);
			

			SetMaterialShader(ref model, 0, ref shader);

			Position = pos;
			Rotation = rotation;
		}

		public override void Draw()
		{
			//DrawModel(model, Position, 0.01f, Color.White);
			DrawModelEx(model, Position, Rotation, Rotation.X + Rotation.Y + Rotation.Z, new Vector3(0.01f, 0.01f, 0.01f), Color.White);
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Unload()
		{
			UnloadModel(model);
			UnloadTexture(textureA);
		}
	}
}