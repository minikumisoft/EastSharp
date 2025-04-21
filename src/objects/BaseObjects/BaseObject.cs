using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
	class BaseObject
	{
		public Vector2 Position{get; set;}
		public bool isCollided{get; set;}
		public string collidedWith = "";

		public virtual void Draw()
		{

		}

		public virtual void Update()
		{
			
		}

		public virtual void Unload()
		{
			
		}
	}
}