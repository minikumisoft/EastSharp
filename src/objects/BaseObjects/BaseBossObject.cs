using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
    class BaseBossObject : BaseObject
    {
        public int HP{get; set;}
        public int chap{get; set;}
        public RTimer chapTimer{get; set;}
        public bool functionRunOnes{get; set;}

        public RTimer moveTime{get; set;}
        public bool moveTimerStart = false;

        public float mmmmmmmmmmmmmmm = 0;

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {
            base.Update();
        }

        public void MoveTo(Vector2 pos, float frames)
        {
            if(moveTimerStart == false)
            {
                mmmmmmmmmmmmmmm = frames;
                moveTimerStart = true;
            }
            mmmmmmmmmmmmmmm--;
            Position += pos * GetFrameTime();

            if(mmmmmmmmmmmmmmm <= 0)
            {
                Console.WriteLine("Stoped");
                functionRunOnes = true;
                moveTime.StartTimer(double.MaxValue);
                moveTimerStart = false;
                return;
            }
        }

        public void SetTimer(double frames)
        {
            moveTime.StartTimer(frames);
        }
    }
}