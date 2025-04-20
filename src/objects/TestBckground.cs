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

			InitShaders();

			backgroundD3objects.Add(new Test3Dobject(new Vector3(0, 0, 0), baseShader, new Vector3(0, 0, 0)));

			backgroundCamera.Position = new Vector3(10, 10, 10);
			backgroundCamera.Target = backgroundD3objects[0].Position;
			backgroundCamera.Up = new Vector3(0, 1, 0);
			backgroundCamera.FovY = 45;
			backgroundCamera.Projection = CameraProjection.Perspective;

			//backgroundD3objects.Add(new Box3DObjectTest(new Vector3(5, 0, 0), baseShader));
			for(int i = 0; i < 100; i++)
			{
				backgroundD3objects.Add(new Box3DObjectTest(new Vector3(rand.Next(-10, 10), rand.Next(-10, 10), rand.Next(-10, 10)), baseShader, new Vector3(rand.Next(0, 360), rand.Next(0, 360), rand.Next(0, 360))));
			}

			fogDestiny = 0.50f;

			Rlights.CreateLight(0, LightType.Point, new Vector3(2, 2, 0), Vector3.Zero, Color.White, baseShader);
			Rlights.CreateLight(1, LightType.Directorional, new Vector3(30, 30, 30), new Vector3(0, 0, 0), Color.Orange, baseShader);
		}

		public override void Draw()
		{
			BeginMode3D(backgroundCamera);
			base.Draw();
			EndMode3D();
		}

		public override void Update()
		{
			//UpdateCamera(ref backgroundCamera, CameraMode.Orbital);
			base.Update();
		}

		public override void Unload()
		{
			base.Unload();
		}
	}
}