using System;
using System.Numerics;
using Raylib_cs;

namespace EastSharp
{
    public static class YorigamiMath
    {
        public static float AngleToRadians(float angle)
        {
            return angle * MathF.PI/180;
        }

        public static float GetAngleToPlayer(Vector2 pos1, Vector2 pos2)
        {
            return MathF.Atan2(pos1.Y - pos2.Y, pos1.X - pos2.X);
        }
    }
}