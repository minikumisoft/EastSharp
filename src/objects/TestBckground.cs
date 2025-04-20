using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	unsafe class TestBackground : D3background
	{
		private Random rand;


		public TestBackground()
		{
			rand = new Random();
			backgroundCamera.Position = new Vector3(10, 10, 10);
			backgroundCamera.Target = new Vector3(0, 0, 0);
			backgroundCamera.Up = new Vector3(0, 1, 0);
			backgroundCamera.FovY = 45;
			backgroundCamera.Projection = CameraProjection.Perspective;

			InitShaders();

			backgroundD3objects.Add(new Test3Dobject(new Vector3(0, 0, 0), baseShader));

			backgroundD3objects.Add(new Box3DObjectTest(new Vector3(5, 0, 0), baseShader));
			for(int i = 0; i < 100; i++)
			{
				backgroundD3objects.Add(new Box3DObjectTest(new Vector3(rand.Next(-10, 10), rand.Next(-10, 10), rand.Next(-10, 10)), baseShader));
			}

			fogDestiny = 0.50f;
			
			// baseShader.Locs[(int)ShaderLocationIndex.MatrixModel] = GetShaderLocation(baseShader, "matModel");
			// baseShader.Locs[(int)ShaderLocationIndex.VectorView] = GetShaderLocation(baseShader, "viewPos");

			// int ambientLoc = GetShaderLocation(baseShader, "ambient");
			// SetShaderValue(baseShader, ambientLoc, new float[] {0.2f, 0.2f, 0.2f, 1.0f}, ShaderUniformDataType.Vec4);

			// float fogDestiny = 0.15f;
			// int fogDestinyLoc = GetShaderLocation(baseShader, "fogDestiny");
			// SetShaderValue(baseShader, fogDestinyLoc, fogDestiny, ShaderUniformDataType.Float);

			// SetMaterialShader(ref backgroundModel, 0, ref baseShader);

			Rlights.CreateLight(0, LightType.Point, new Vector3(2, 2, 0), Vector3.Zero, Color.White, baseShader);
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
			UpdateCamera(ref backgroundCamera, CameraMode.Orbital);
		}

		public override void Unload()
		{
			base.Unload();
		}
	}
}