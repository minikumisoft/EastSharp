using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	unsafe class TestBackground : D3background
	{
		private Image testImage;
		private Texture2D testTexture;


		public TestBackground()
		{
			backgroundCamera.Position = new Vector3(10, 10, 10);
			backgroundCamera.Target = new Vector3(0, 0, 0);
			backgroundCamera.Up = new Vector3(0, 1, 0);
			backgroundCamera.FovY = 45;
			backgroundCamera.Projection = CameraProjection.Perspective;

			testImage = GenImageChecked(100, 100, 10, 10, Color.White, Color.Blue);
			testTexture = LoadTextureFromImage(testImage);

			backgroundModel = LoadModelFromMesh(GenMeshPlane(10, 10, 1, 1));
			SetMaterialTexture(ref backgroundModel, 0, MaterialMapIndex.Albedo, ref testTexture);
			
			// baseShader.Locs[(int)ShaderLocationIndex.MatrixModel] = GetShaderLocation(baseShader, "matModel");
			// baseShader.Locs[(int)ShaderLocationIndex.VectorView] = GetShaderLocation(baseShader, "viewPos");

			// int ambientLoc = GetShaderLocation(baseShader, "ambient");
			// SetShaderValue(baseShader, ambientLoc, new float[] {0.2f, 0.2f, 0.2f, 1.0f}, ShaderUniformDataType.Vec4);

			// float fogDestiny = 0.15f;
			// int fogDestinyLoc = GetShaderLocation(baseShader, "fogDestiny");
			// SetShaderValue(baseShader, fogDestinyLoc, fogDestiny, ShaderUniformDataType.Float);

			// SetMaterialShader(ref backgroundModel, 0, ref baseShader);
			InitShaders();

			Rlights.CreateLight(0, LightType.Point, new Vector3(0, 0.2f, 0), Vector3.Zero, Color.Blue, baseShader);
		}

		public override void Draw()
		{
			BeginMode3D(backgroundCamera);
			base.Draw();
			EndMode3D();
		}

		public override void Update()
		{
			base.Update();
			UpdateCamera(ref backgroundCamera, CameraMode.Free);
		}
	}
}