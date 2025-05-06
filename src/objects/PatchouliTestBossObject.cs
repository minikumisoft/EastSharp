using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
    class PathouliBoss : BaseBossObject
    {
        private Texture2D texture;
        private RTimer rTimer;

        public PathouliBoss(Vector2 pos)
        {
            Position = pos;
            functionRunOnes = false;
            texture = GlobalResources.pathouliAstmaTexture;
            moveTime = new RTimer();
            moveTime.StartTimer(double.MaxValue);
            rTimer = new RTimer();
            rTimer.StartTimer(3);
            moveTimerStart = false;
        }

        public override void Draw()
        {
            DrawTexturePro(texture, new Rectangle(1, 0, 23, 46), new Rectangle(Position, 23*1.3f, 46*1.3f), new Vector2(0, 0), 0, Color.White);
            if(Debug.Debugging)
            {
                DrawText($"Pos: {Position}", (int)Position.X, (int)Position.Y, 10, Color.White);
            }
            base.Draw();
        }

        public override void Update()
        {
            base.Update();
            if(rTimer.TimerDone())
            {
                if(functionRunOnes == false)
                {
                    MoveTo(new Vector2(10, 100), 30);
                }
                
            }
        }
    }
}