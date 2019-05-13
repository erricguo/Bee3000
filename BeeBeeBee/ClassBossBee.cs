using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BeeBeeBee
{
    class ClassBossBee
    {
        List<Bitmap> BmpBossBeeList;
        List<Bitmap> BmpBossHitList;
        int BmpBossHitList_Index = 0;
        int Width = 180;
        int Height = 150;
        int BossBee_Life = 1000;
        int MovingCount = 1;
        int BX = 0;//出現位置
        int SX = 0;//移動最左邊位置
        int EX = 0;//移動最右邊位置
        int X = 0;//現在位置X
        int Y = 0;//現在位置Y
        public double step = 4; //移動距離
        bool BossHit=false;

       // public Sprite s_boss = null;
        //public Texture showPicture;//定义图片对象

        public enum status { Lv1,Lv2,Lv3,Die };//可能狀態 活動或死亡
        public status Current_Status;//目前狀態

        public int _BX{ get { return BX; }set { BX = value; }}
        public int _EX { get { return EX; } set { EX = value; } }
        public int _X { get { return X; } set { X = value; } }
        public int _Y { get { return Y; } set { Y = value; }}
        public int _Height  {get { return Height; }  set { Height = value; }}
        public int _Width  {get { return Width; } set { Width = value; }}
        public int _BossBee_Life { get { return BossBee_Life; } set { BossBee_Life = value; } }
        public bool _BossHti { get { return BossHit; } set { BossHit = value; } }

        public ClassBossBee()
        {
            
            X = BX = 300-Width/2;
            EX = 600 - Width;
            this.Current_Status = status.Lv1;
        }
        public void SetBmp_BossBee(List<Bitmap> BmpBossBeeList, List<Bitmap> BmpBossHitList)
        {
            this.BmpBossBeeList = BmpBossBeeList;
            this.BmpBossHitList = BmpBossHitList;
        }

        System.Drawing.Point rotationPoint = new Point();
        System.Drawing.Point position = new Point();
        public void Draw(Device gd, Sprite s, Texture t, List<Texture> t2)
        {
            if (Current_Status == status.Die) return;

            if (Current_Status == status.Lv1)
            {

                if (X > EX  || X < SX )
                {
                    MovingCount = -MovingCount;
                }
                X += (int)(MovingCount * step);

                if (BossHit) 
                    //G.DrawImage(BmpBossHitList[BmpBossHitList_Index ++], X, Y);
                    DrawImage(gd, s, t2[BmpBossHitList_Index++], X, Y);
                else
                    //G.DrawImage(BmpBossBeeList[0], X, Y);
                    DrawImage(gd, s, t, X, Y);
            }

            if (BmpBossHitList_Index == BmpBossHitList.Count - 1)
            {
                BossHit = false;
                BmpBossHitList_Index = 0;
            }


            if (_BossBee_Life == 0)
            {
                Current_Status = status.Die;
            }
        }
        private void DrawImage(Device gd, Sprite s, Texture t, int X, int Y)
        {
            position.X = X;
            position.Y = Y;
            s.Begin(SpriteFlags.AlphaBlend);
            s.Draw2D(t, rotationPoint, 0f, position, Color.White);
            s.End();

        }
       /* public void DisposeSprite()
        {
            showPicture.Dispose();
            s_boss.Dispose();
        }*/
    }
}
