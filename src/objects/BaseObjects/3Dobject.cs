using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class D3object
	{
		public Model model{get; set;}
		public Vector3 Position{get; set;}

		public virtual void Draw(float Scale)
		{
			DrawModel(model, Position, Scale, Color.White);
		}
	}
}