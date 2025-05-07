using System;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
    class PathouliBoss : BaseBossObject
    {
        private Texture2D texture;
        private RTimer rTimer;
        private int m;

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
            m = 0;
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
            //Console.WriteLine(rTimer.GetElapsed());
            if(rTimer.TimerDone() && m == 0)
            {
                if(functionRunOnes == false)
                {
                    MoveTo(new Vector2(10, 100), 30);
                }
                Console.WriteLine(m);
                if(mmmmmmmmmmmmmmm <= 0)
                {
                    m++;
                    Console.WriteLine(m);
                    rTimer.StartTimer(3);
                }
            }
            
            if(rTimer.TimerDone() && m == 1)
            {
                functionRunOnes = false;
                if(functionRunOnes == false)
                {
                    Console.WriteLine("Its, Shit");
                    MoveTo(new Vector2(-100, -10), 70);
                }
                if(mmmmmmmmmmmmmmm <= 0)
                {
                    functionRunOnes = true;
                    m++;
                    rTimer.StartTimer(2);
                }
                Console.WriteLine("Ahuet");
            }

            if(rTimer.TimerDone() && m == 2)
            {
                functionRunOnes = false;
                if(functionRunOnes == false)
                {
                    Console.WriteLine("Its, Shit");
                    MoveTo(new Vector2(100, 40), 70);
                }
                if(mmmmmmmmmmmmmmm <= 0)
                {
                    functionRunOnes = true;
                    m++;
                    rTimer.StartTimer(double.MaxValue);
                }
                Console.WriteLine("Ahuet");
            }

        }
    }
}