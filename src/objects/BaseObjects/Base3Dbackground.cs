using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	unsafe class D3background
	{
		public Model backgroundModel;
		public Camera3D backgroundCamera;
		public Shader baseShader = LoadShader("assets/shaders/lighting.vs", "assets/shaders/fog.fs");

		public void InitShaders()
		{
			baseShader.Locs[(int)ShaderLocationIndex.MatrixModel] = GetShaderLocation(baseShader, "matModel");
			baseShader.Locs[(int)ShaderLocationIndex.VectorView] = GetShaderLocation(baseShader, "viewPos");

			int ambientLoc = GetShaderLocation(baseShader, "ambient");
			SetShaderValue(baseShader, ambientLoc, new float[] {0.2f, 0.2f, 0.2f, 1.0f}, ShaderUniformDataType.Vec4);

			float fogDestiny = 0.15f;
			int fogDestinyLoc = GetShaderLocation(baseShader, "fogDestiny");
			SetShaderValue(baseShader, fogDestinyLoc, fogDestiny, ShaderUniformDataType.Float);

			SetMaterialShader(ref backgroundModel, 0, ref baseShader);
		}

		public virtual void Draw()
		{
			DrawModel(backgroundModel, new Vector3(0, 0, 0), 1, Color.White);
		}

		public virtual void Update()
		{
			
		}
	}
}