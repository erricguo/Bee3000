using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BeeBeeBee
{
    class ClassBee
    {

        List<Bitmap> BmpBeeList;

        int Width = 30; //Bee身寬
        int Height = 20;//Bee身高
        int BX, EX;//開始位置，結束位置
        double Distance;//距離底端位置
        public double step = 1; //移動距離
      //  int W = 600;//遊戲畫面寬
        int H = 600;//遊戲畫面高
        int MovingCount = 0;//開始移動起始點
        int DX;//距離底端X距離
        int DY;//距離底端Y距離
        int X = 0;
        int Y = 0; //目前位置
        public int Bee_Life = 1;//Bee生命值 預設1
        public int Bee_Shoot_Count = 1;
        Random Rd = new Random();

        //public Sprite s_bee = null;
        //public Texture showPicture;//定义图片对象

        public enum status { active, pass,kill_bull,kill_player,kill_superbomb,kill_defense ,kill_linkbomb};//可能狀態 活動或死亡
        public status Current_Status;//目前狀態

        public int _X
        { 
            get{return X;}
            set { X = value; } 
        }
        public int _Y
        {
            get { return Y; }
            set { Y = value; } 
        }

        public int _Height
        { 
            get { return Height; }
            set { Height = value; }
        }
        public int _Width
        { 
            get { return Width; }
            set { Width = value; }
        }

        public ClassBee(Device gd,int BX,int EX,status Current_Status,List<Bitmap> BmpBeeList)
        {
            this.BmpBeeList = BmpBeeList;
            this.Current_Status = Current_Status;
            step = Rd.Next(1, 10);
            this.BX = BX;// +Rd.Next(300);
            this.EX = EX;
            Distance = Math.Sqrt((BX - EX) * (BX - EX) + H * H);
            DX = EX - BX;
            DY = H;
            //s_bee = new Sprite(gd);
            //showPicture = new Texture(gd, BmpBeeList[0], 0, Pool.Managed);
        }

        public bool CheckCollision(int P1_x, int P1_y, int P1_w, int P1_h)//傳入座標為(bee_x + bee_Width/2 , bee_y)
        {
            if (X > P1_x -Width/2 && X < P1_x + P1_w - Width/2)
            {
                if (Y > P1_y -Height/2 && Y < P1_y + P1_h -Height/2)
                {
                    return true;
                }
            }
            return false;
        }
        //public void Draw(Graphics G)
        System.Drawing.Point rotationPoint = new Point();
        System.Drawing.Point position = new Point();
        public void Draw(Device gd,Sprite s,Texture t)
        {
            if (Current_Status != status.active) return;

            MovingCount++;
            X = BX + (int)(MovingCount * (step / Distance) * DX);
            Y =(int)(MovingCount * (step / Distance) * DY);

            //G.DrawImage(BmpBeeList[0], X, Y);

            position.X = X;
            position.Y = Y;
            s.Begin(SpriteFlags.AlphaBlend);
            s.Draw2D(t, rotationPoint, 0f, position, Color.White);
            s.End();

            if (Y > 600)
            {
                Current_Status = status.pass;
            }
        }
        /*public void DisposeSprite()
        {
            showPicture.Dispose();
            s_bee.Dispose();
        }*/
    }
}
