using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BeeBeeBee
{
    class ClassBoom
    {

   /*     Bitmap[] BmpBomb =new Bitmap[] //爆炸圖片設置
        {
            Properties.Resources.bomb1,
            Properties.Resources.bomb2,
            Properties.Resources.bomb3,
            Properties.Resources.bomb2,
            Properties.Resources.bomb1
        };*/
      /*  Bitmap[] BmpSuperBomb = new Bitmap[] //爆炸圖片設置
         {
             Properties.Resources.Super_Bomb_1,
             Properties.Resources.Super_Bomb_2,
             Properties.Resources.Super_Bomb_3,
             Properties.Resources.Super_Bomb_4,
             Properties.Resources.Super_Bomb_5,
             Properties.Resources.Super_Bomb_6,
             Properties.Resources.Super_Bomb_7,
             Properties.Resources.Super_Bomb_6,
             Properties.Resources.Super_Bomb_5,
             Properties.Resources.Super_Bomb_4,
             Properties.Resources.Super_Bomb_3,
             Properties.Resources.Super_Bomb_2,
             Properties.Resources.Super_Bomb_1,
         };*/
        List<Bitmap> BmpBoomList;
        int BmpBoom_Index = 0;//圖片索引
     //   int BmpSuperBomb_Index = 0;
        protected int Count = 0;//現在爆炸次數
        protected int Total_Count;//呈現總次數
    //    int SuperBomb_Width = 600;
    //    int SuperBomb_Height = 400;
    //    int SuperBomb_Range = 30;//爆炸擴散範圍

        public int X = 0;//爆炸發生 X 位置
        public int Y = 0;//爆炸發生 Y 位置

        int X1 = 0;
        int Y1 = 0;

        //public Sprite s_boom = null;
        //public Texture showPicture;//定义图片对象

        public enum status { active, playerdie,/*superbomb,*/die ,Bossdie};//可能狀態 活動或死亡
        public status Current_Status;//目前狀態

        public ClassBoom() { }
        public ClassBoom(Device gd,int X,int Y,int Total_Count,status Current_Status,List<Bitmap> BmpBoomList) 
        {
            this.X = X;
            this.Y = Y;
            this.Total_Count = Total_Count;
            this.Current_Status = Current_Status;
            this.BmpBoomList = BmpBoomList;
            if (Current_Status == status.active) { X1 = 30; Y1 = 20; } //設定Bee爆炸大小
            else if (Current_Status == status.playerdie) { X1 = 60; Y1 = 45; }//設定玩家爆炸大小
            else if (Current_Status == status.Bossdie) { X1 = 180; Y1 = 150; }
           // s_boom = new Sprite(gd);
           // showPicture = new Texture(gd, BmpBoomList[BmpBoom_Index++], 0, Pool.Managed);
        }


        System.Drawing.Point rotationPoint = new Point();
        System.Drawing.Point position = new Point();
        public virtual void Draw(Device gd, Sprite s, List<Texture> t, List<Texture> t2, List<Texture> t3)
        {
            if (Current_Status == status.die  ) return;

                BmpBoom_Index %= BmpBoomList.Count ;
                //DrawImage(gd,BmpBoomList[BmpBoom_Index++], X, this.Y, X1, Y1);
                if (Current_Status == status.active) { DrawImage(gd, s, t[BmpBoom_Index++], X, this.Y); } //設定Bee爆炸大小
                else if (Current_Status == status.playerdie) { DrawImage(gd, s, t2[BmpBoom_Index++], X, this.Y); }//設定玩家爆炸大小
                else if (Current_Status == status.Bossdie) { DrawImage(gd, s, t3[BmpBoom_Index++], X, this.Y); }

               // DrawImage(gd,s,t[BmpBoom_Index++], X, this.Y);

            Count++;
            if (Count >= Total_Count)
                Current_Status = status.die;
        }

        private void DrawImage(Device gd, Sprite s, Texture t, int X, int Y)
        {

            position.X = X;
            position.Y = Y;
            s.Begin(SpriteFlags.AlphaBlend);
            s.Draw2D(t, rotationPoint, 0f, position, Color.White);
            s.End();

        }
        /*public virtual void DisposeSprite()
        {
            showPicture.Dispose();
            s_boom.Dispose();
        }*/
    }

    
}