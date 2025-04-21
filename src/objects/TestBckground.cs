using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	unsafe class TestBackground : D3background
	{
		private Random rand;
		private float time;

		public TestBackground()
		{
			rand = new Random();
			time = 0;
			InitShaders();

			//backgroundD3objects.Add(new Test3Dobject(new Vector3(0, 0, 0), baseShader, new Vector3(0, 0, 0)));

			backgroundCamera.Position = new Vector3(20, 20, 0);
			backgroundCamera.Target = new Vector3(0, 0, 0);
			backgroundCamera.Up = new Vector3(0, 1, 0);
			backgroundCamera.FovY = 45;
			backgroundCamera.Projection = CameraProjection.Perspective;
			//backgroundD3objects.Add(new Box3DObjectTest(new Vector3(5, 0, 0), baseShader));
			for(int i = 0; i < 30; i++)
			{
				for(int j = 0; j < 20; j++)
				{
					backgroundD3objects.Add(new Box3DObjectTest(new Vector3(-40 + 2 * i, 0, -20 + 2 * j), baseShader, new Vector3(0, 0, 0)));
				}
			}

			for(int i = 0; i < 3; i++)
			{
				backgroundD3objects.Add(new Clouds3D(new Vector3(-100 + 100 * i, 3, 0), baseShader, new Vector3(0, 0, 0)));
			}

			fogDestiny = 0.50f;

			Rlights.CreateLight(0, LightType.Directorional, new Vector3(30, 30, 30), new Vector3(0, 0, 0), Color.Orange, baseShader);
		}

		public override void Draw()
		{
			BeginMode3D(backgroundCamera);
			DrawGrid(5, 5);
			base.Draw();
			EndMode3D();
		}

		public override void Update()
		{
			time++;
			UpdateCamera(ref backgroundCamera, CameraMode.Custom);

			backgroundCamera.Target = new Vector3(0, 0, MathF.Cos(time / 60));
			backgroundCamera.Up = new Vector3(0, 1, 0 + 0.02f * MathF.Cos(time / 60));

			for(int i = 0; i < backgroundD3objects.Count(); i++)
			{
				if(backgroundD3objects[i] is Box3DObjectTest)
				{
					backgroundD3objects[i].Position += new Vector3(0.1f, 0, 0);
					if(backgroundD3objects[i].Position.X > 20)
					{
						backgroundD3objects[i].Position = new Vector3(-40, backgroundD3objects[i].Position.Y, backgroundD3objects[i].Position.Z);
					}
				}

				if(backgroundD3objects[i] is Clouds3D)
				{
					backgroundD3objects[i].Position += new Vector3(0.2f, 0, 0);
					if(backgroundD3objects[i].Position.X > 200)
					{
						backgroundD3objects[i].Position = new Vector3(-100, backgroundD3objects[i].Position.Y, backgroundD3objects[i].Position.Z);
					}
				}
			}
			base.Update();
		}

		public override void Unload()
		{
			base.Unload();
		}
	}
}