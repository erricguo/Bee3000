using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BeeBeeBee
{
    class ClassBossBeeBull : ClassBeeBull
    {
        List<Bitmap> BmpBossBeeBullList;
        new public enum status_BullStatus { active, hit, miss };//可能狀態 活動或死亡
        new public status_BullStatus Current_BullStatus;//目前狀態

        public ClassBossBeeBull() { }
        public ClassBossBeeBull(Device gd, int BX, int EX, int Y, status_BullStatus Current_BeeBullStatus, List<Bitmap> BmpBossBeeBullList)
        {
            this.BmpBossBeeBullList = BmpBossBeeBullList;
            this.Current_BullStatus = Current_BeeBullStatus;
            this.BX = BX - Width / 2;
            this.EX = EX;
            this.Y = Y;
            Distance = Math.Sqrt((BX - EX) * (BX - EX) + Y * Y);
            DX = EX - BX;
            DY = Y;
        }


        public override  bool CheckCollision(int P1_x, int P1_y, int P1_w, int P1_h)//傳入座標為(bee_x + bee_Width/2 , bee_y)
        {
            if (X > P1_x && X < P1_x + P1_w)
            {
                if (Y > P1_y -_Height && Y <  P1_y + P1_h - _Height)
                {
                    return true;
                }
            }
            return false;
        }

        System.Drawing.Point rotationPoint = new Point();
        System.Drawing.Point position = new Point();
        int rot = 0;
        int bullcount = 21;
        public void Draw(Device gd, Sprite s, Texture t)
        {
            if (Current_BullStatus == status_BullStatus.miss) return;
            RiseCount++;
            X = BX + (int)(RiseCount * (step * 4 / Distance) * DX);
            Y = Y + (int)(RiseCount * (step /32/ Distance) * DY);

            position.X = X;
            position.Y = Y;

            s.Begin(SpriteFlags.AlphaBlend);
            for (int j = 0; j < 16; j++)
            {
                for (int i = 0; i < bullcount; i++)
                {
                    if (i <= bullcount/2-1)
                    {//(bullcount/2 - i) *
                        position.X = X - (bullcount / 2 - i) *  RiseCount ;
                        position.Y = Y - (bullcount / 2 - i) * (bullcount/2 - i) * RiseCount / 30 + 30;
                    }
                    else if (i >= bullcount/2+1)
                    {//(i - bullcount/2) *
                        position.X = X + (i - bullcount / 2) *  RiseCount;
                        position.Y = Y - (i - bullcount / 2) * (i - bullcount/2) * RiseCount / 30 + 30;
                    }
                    else
                    {
                        position.X = X;
                        position.Y = Y+30;
                    }

                    s.Draw2D(t, rotationPoint, j*0.4f, position, Color.White);
                }
            }
            /*position.X = X + RiseCount * RiseCount;
            position.Y = Y;
            s.Draw2D(t, rotationPoint, 0, position, Color.White);*/
            s.End();
            if (Y > 600)
            {
                Current_BullStatus = status_BullStatus.miss;
            }
        }
    }
}
