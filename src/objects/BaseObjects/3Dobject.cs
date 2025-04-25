using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class D3object
	{
		public Model model;
		public Vector3 Position{get; set;}
		public Vector3 Rotation{get; set;}
		public bool isUnload{get; set;}

		public virtual void Draw()
		{
			
		}

		public virtual void Unload()
		{
			
		}

		public virtual void Update()
		{

		}
	}
}