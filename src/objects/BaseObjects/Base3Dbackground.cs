using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	unsafe class D3background
	{
		public List<D3object> backgroundD3objects = new List<D3object>();
		public Camera3D backgroundCamera;
		public Shader baseShader = LoadShader("assets/shaders/lighting.vs", "assets/shaders/fog.fs");
		public float fogDestiny{get; set;}

		public void InitShaders()
		{
			baseShader.Locs[(int)ShaderLocationIndex.MatrixModel] = GetShaderLocation(baseShader, "matModel");
			baseShader.Locs[(int)ShaderLocationIndex.VectorView] = GetShaderLocation(baseShader, "viewPos");

			int ambientLoc = GetShaderLocation(baseShader, "ambient");
			SetShaderValue(baseShader, ambientLoc, new float[] {0.2f, 0.2f, 0.2f, 1.0f}, ShaderUniformDataType.Vec4);

			int fogDestinyLoc = GetShaderLocation(baseShader, "fogDestiny");
			SetShaderValue(baseShader, fogDestinyLoc, fogDestiny, ShaderUniformDataType.Float);

		}

		public void UpdateShaders()
		{
			int ambientLoc = GetShaderLocation(baseShader, "ambient");
			SetShaderValue(baseShader, ambientLoc, new float[] {0.0f, 1.0f, 0.0f, 1.0f}, ShaderUniformDataType.Vec4);

			int fogDestinyLoc = GetShaderLocation(baseShader, "fogDestiny");
			SetShaderValue(baseShader, fogDestinyLoc, fogDestiny, ShaderUniformDataType.Float);
		}

		public virtual void Draw()
		{
			for(int i = 0; i < backgroundD3objects.Count; i++)
			{
				backgroundD3objects[i].Draw();
			}
		}

		public virtual void Update()
		{
			for(int i = 0; i < backgroundD3objects.Count; i++)
			{
				backgroundD3objects[i].Update();
			}
		}

		public virtual void Unload()
		{
			for(int i = 0; i < backgroundD3objects.Count; i++)
			{
				backgroundD3objects[i].Unload();
			}
		}
	}
}