using System;
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{
    enum BossMoveType
    {
        Linear,
        Sine
    }

    class BaseBossObject : BaseObject
    {
        
        public int HP{get; set;}
        public int chap{get; set;}
        public RTimer chapTimer{get; set;}
        public bool functionRunOnes{get; set;}
        public bool isDeleted{ get; set; }

        public RTimer moveTime { get; set; }
        public bool moveTimerStart = false;

        public List<Bullet> localBullets;
        public List<Bullet> gBullets;

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
                moveTimerStart = false;
                return;
            }
        }

        public void MoveToV2(Vector2 pos, float frames, BossMoveType type)
        {
            var shit = frames;
            if(moveTimerStart == false)
            {
                mmmmmmmmmmmmmmm = 0;
                moveTimerStart = true;
            }
            mmmmmmmmmmmmmmm++;
            
            switch(type)
            {
                case BossMoveType.Linear:
                    Position = new Vector2(Easings.EaseLinearInOut(mmmmmmmmmmmmmmm, Position.X, pos.X, frames-50), Easings.EaseLinearInOut(mmmmmmmmmmmmmmm, Position.Y, pos.Y, frames-50));
                break;
                case BossMoveType.Sine:
                    Position = new Vector2(Easings.EaseSineInOut(mmmmmmmmmmmmmmm, Position.X, pos.X, frames-50), Easings.EaseSineInOut(mmmmmmmmmmmmmmm, Position.Y, pos.Y, frames-50));
                break;
            }
            
            if(mmmmmmmmmmmmmmm >= frames)
            {
                Console.WriteLine("Stoped");
                functionRunOnes = true;
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