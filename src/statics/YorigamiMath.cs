using System;
using System.Numerics;
using Raylib_cs;

namespace EastSharp
{
    public static class YorigamiMath
    {

        public static Random publicRandom = new Random();

        public static float AngleToRadians(float angle)
        {
            return angle * MathF.PI/180;
        }

        public static float GetAngleToPlayer(Vector2 pos1, Vector2 pos2)
        {
            return MathF.Atan2(pos1.Y - pos2.Y, pos1.X - pos2.X);
        }

        public static float GetRandomNumber(float minimum, float maximum)
		{ 
    		return (float)publicRandom.NextDouble() * (maximum - minimum) + minimum;
		}
    }
}