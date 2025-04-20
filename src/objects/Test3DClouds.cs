using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class Clouds3D : D3object
	{	
		private Image image;
		private Texture2D texture;

		public Clouds3D(Vector3 pos, Shader shader, Vector3 rotation)
		{
			model = LoadModelFromMesh(GenMeshPlane(100, 50, 1, 1));
			image = GenImagePerlinNoise(1000, 1000, 0, 0, 5);
			ImageColorTint(ref image, Color.Orange);
			texture = LoadTextureFromImage(image);
			SetMaterialTexture(ref model, 0, MaterialMapIndex.Albedo, ref texture);
			//SetMaterialShader(ref model, 0, ref shader);
			Position = pos;
			Rotation = rotation;
		}

		public override void Draw()
		{
			BeginBlendMode(BlendMode.Additive);
				DrawModelEx(model, Position, Rotation, Rotation.X + Rotation.Y + Rotation.Z, new Vector3(1, 1, 1), Color.White);
			EndBlendMode();
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Unload()
		{
			base.Unload();
		}
	}
}