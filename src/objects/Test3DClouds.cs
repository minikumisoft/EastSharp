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
			isUnload = false;
			model = GlobalResources.cloudModel;
			image = GlobalResources.cloudImage;
			//ImageColorTint(ref image, Color.Gray);
			texture = GlobalResources.cloudTexture;
			SetMaterialTexture(ref model, 0, MaterialMapIndex.Albedo, ref texture);
			//SetMaterialShader(ref model, 0, ref shader);
			Position = pos;
			Rotation = rotation;
		}

		public override void Draw()
		{
			BeginBlendMode(BlendMode.Additive);
				if(isUnload == false)
				{
					DrawModelEx(model, Position, Rotation, Rotation.X + Rotation.Y + Rotation.Z, new Vector3(1, 1, 1), Color.White);
				}
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