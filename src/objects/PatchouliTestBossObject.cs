using System;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace EastSharp
{

    class testBals
    {
        public Vector2 position;
        public testBals(Vector2 pos)
        {
            position = pos;
        }

        public void draw()
        {
            DrawCircleV(position, 3, Color.Red);
        }
    }


    class PathouliBoss : BaseBossObject
    {
        private Texture2D texture;
        private RTimer rTimer;
        private int m;

        private List<testBals> bals;

        public PathouliBoss(Vector2 pos, List<Bullet> bul)
        {
            Position = pos;
            HP = 3;
            functionRunOnes = false;
            texture = GlobalResources.pathouliAstmaTexture;
            moveTime = new RTimer();
            moveTime.StartTimer(double.MaxValue);
            rTimer = new RTimer();
            rTimer.StartTimer(3);
            moveTimerStart = false;
            m = 0;
            bals = new List<testBals>();
            localBullets = new List<Bullet>();
            gBullets = bul;
            isDeleted = false;
            
        }

        public override void Draw()
        {
            DrawTexturePro(texture, new Rectangle(1, 0, 23, 46), new Rectangle(Position, 23 * 1.3f, 46 * 1.3f), new Vector2(0, 0), 0, Color.White);

            for (int i = 0; i < localBullets.Count() - 1; i++)
            {
                localBullets[i].Draw();
            }


            if (Debug.Debugging)
                {
                    bals.Add(new testBals(Position));
                    for (int i = 0; i < bals.Count(); i++)
                    {
                        bals[i].draw();
                    }

                    for (int i = 0; i < bals.Count() - 1000; i++)
                    {
                        bals.Remove(bals[i]);
                    }
                    // DrawText($"Pos: {Position}", (int)Position.X, (int)Position.Y, 10, Color.White);
                    DrawTextEx(GlobalResources.debugFontMedium, $"{HP}", Position, 20, 1, Color.White);
                    DrawCircle((int)Position.X + 17, (int)Position.Y + 25, 10, new Color(45, 127, 222, 200));
                }
            base.Draw();
        }

        public override void Update()
        {
            base.Update();

            for (int i = 0; i < localBullets.Count() - 1; i++)
            {
                localBullets[i].Update();
            }



            localMove(new Vector2(1, 0), 0, 3);
            localMove(new Vector2(1, -1), 1, 3);
            localMove(new Vector2(1, 4), 2, 3);
            localMove(new Vector2(-1, -4), 3, 3);
        }

        private void localMove(Vector2 pos, int mm, double timer)
        {
            if (rTimer.TimerDone() && m == mm)
            {
                localBullets.Add(new Bullet(Position, 2, YorigamiMath.AngleToRadians(90), BulletType.EnemyBlueMidBall));
                functionRunOnes = false;
                if (functionRunOnes == false)
                {
                    MoveToV2(pos, 100, BossMoveType.Linear);
                }
                Console.WriteLine(m);
                if (mmmmmmmmmmmmmmm >= 100)
                {
                    m++;
                    // Console.WriteLine();
                    rTimer.StartTimer(timer);
                }
            }
        }
    }
}