using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BeeBeeBee
{
    class ClassBeeBull:ClassPlayerBull 
    {
        List<Bitmap> BmpBeeBullList;
    /*    Bitmap[] Bmp_BeeBull = new Bitmap[]
        {
            Properties.Resources.bee_Shoot 
        };*/
         //new public enum status_BullType { Bull, SuperBomb };//可能狀態 活動或死亡
         //new public status_BullType Current_BullType;//目前狀態
         new public enum status_BullStatus { active, hit, miss };//可能狀態 活動或死亡
         new public status_BullStatus Current_BullStatus;//目前狀態

        // public Sprite s_bull = null;
        // public Texture showPicture;//定义图片对象

        public ClassBeeBull() { }
        public ClassBeeBull(Device gd,int BX, int EX, int Y, status_BullStatus Current_BeeBullStatus,List<Bitmap> BmpBeeBullList)
        {
            this.BmpBeeBullList = BmpBeeBullList;
            this.Current_BullStatus = Current_BeeBullStatus;
            this.BX = BX - Width / 2;
            this.EX = EX;
            this.Y = Y;
            Distance = Math.Sqrt((BX - EX) * (BX - EX) + Y * Y);
            DX = EX - BX;
            DY = Y;
           // s_bull = new Sprite(gd);
          //  showPicture = new Texture(gd, BmpBeeBullList[0], 0, Pool.Managed);
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
        public void Draw(Device gd, Sprite s, Texture t)
        {
            if (Current_BullStatus == status_BullStatus.miss) return;
            RiseCount++;
            X = BX + (int)(RiseCount * (step * 4 / Distance) * DX);
            Y = Y + (int)(RiseCount * (step /32/ Distance) * DY);


            position.X = X;
            position.Y = Y;
            s.Begin(SpriteFlags.AlphaBlend);
            s.Draw2D(t, rotationPoint, 0f, position, Color.White);
            s.End();
            if (Y > 600)
            {
                Current_BullStatus = status_BullStatus.miss;
            }
        }
       /* public void DisposeSprite()
        {
            showPicture.Dispose();
            s_bull.Dispose();
        }*/
    }
}
