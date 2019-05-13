using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BeeBeeBee
{
    class ClassPlayerBull
    {
        List<Bitmap> BmpPlayerBullList;
        List<Bitmap> BmpPlayerBullLinkBombList;
   /*     Bitmap[] Bmp_PlayerBull = new Bitmap[]
        {
           Properties.Resources.玩家子彈_S,
           Properties.Resources.玩家子彈_B,
           Properties.Resources.SuperBomb
        };*/
  /*      Bitmap[] Bmp_PlayerBull_LinkBomb = new Bitmap[]
        {
            Properties.Resources.LinkBomb_1,
            Properties.Resources.LinkBomb_2,
            Properties.Resources.LinkBomb_3,
            Properties.Resources.LinkBomb_4,
            Properties.Resources.LinkBomb_3,
            Properties.Resources.LinkBomb_2,
            Properties.Resources.LinkBomb_1
        };*/

        int Bomb_Index = 0;

        protected int X = 0;
        protected int Y = 0;
        protected int Width = 10;
        protected int Height = 20;
    //    int BullLife = 1;
        protected double step = 3;
        protected double Distance = 0;
    //    public bool Rise = true;
        protected int RiseCount = 0;
        protected int BX,EX;
        protected int DX;
        protected int DY;
        protected bool Big_Bull = false;
    //    bool Super_Bomb=false;
    //    bool Super_Bombing = false;

        public Sprite s_bull = null;
        public Texture showPicture;//定义图片对象

        public int _X
        { 
            get { return X; }
            set { X = value ; } 
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
        public enum status_BullType { Bull,SuperBomb,LinkBomb };//可能狀態 活動或死亡
        public status_BullType Current_BullType;//目前狀態
        public enum status_BullStatus { active, hit,miss };//可能狀態 活動或死亡
        public status_BullStatus Current_BullStatus;//目前狀態

        public ClassPlayerBull() { }
        ~ClassPlayerBull() 
        {
            Console.WriteLine("Delete Bull");
        }
        public ClassPlayerBull(Device gd,int BX, int EX, int Y, bool Big_Bull, status_BullType Current_BullType, status_BullStatus Current_BullStatus, List<Bitmap> BmpPlayerBullList, List<Bitmap> BmpPlayerBullLinkBombList)
        {
            this.BmpPlayerBullLinkBombList= BmpPlayerBullLinkBombList;
            this.BmpPlayerBullList = BmpPlayerBullList;
            this.Current_BullStatus = Current_BullStatus;
            this.Current_BullType = Current_BullType;
            this.Big_Bull = Big_Bull;
            
            if (Big_Bull == true) { Width = 20; Height = 40; }
            else { Width = 10; Height = 20; }
            if (this.Current_BullType == status_BullType.LinkBomb) { Width = 40; Height = 40; }
            this.BX = BX - Width / 2;
            this.EX = EX;
            this.Y = Y - Height ;
            Distance = Math.Sqrt((BX - EX) * (BX - EX) + Y * Y);
            DX = EX - BX;
            DY = Y;
            s_bull = new Sprite(gd);

            if (Current_BullType == status_BullType.SuperBomb)
            {
                showPicture = new Texture(gd, BmpPlayerBullList[2], 0, Pool.Managed);
            }
            else if (Current_BullType == status_BullType.LinkBomb)
            {
                showPicture = new Texture(gd, BmpPlayerBullLinkBombList[Bomb_Index++], 0, Pool.Managed);
            }
            else
            {
                if (Big_Bull == false)
                    showPicture = new Texture(gd, BmpPlayerBullList[0], 0, Pool.Managed);
                else
                    showPicture = new Texture(gd, BmpPlayerBullList[1], 0, Pool.Managed);
            }
            
        }

        public virtual bool CheckCollision(int bee_x, int bee_y,int bee_w,int bee_h)//傳入座標為(bee_x + bee_Width/2 , bee_y)
        {
            if (X > bee_x -Width/2  && X < bee_x + bee_w + Width/2 )
            {
                if (Y > bee_y-Height/2  && Y < bee_y + bee_h+Height/2 )
                {
                    return true ;
                }
            }
            return false;
        }

        System.Drawing.Point rotationPoint = new Point();
        System.Drawing.Point position = new Point();
        public virtual void Draw(Device gd, Sprite s, List<Texture> t, List<Texture> t2)
        {
            if (Current_BullStatus !=status_BullStatus.active ) return;


            RiseCount++;

            if (Current_BullType ==status_BullType.SuperBomb)
            {
                X = BX + (int)(RiseCount * (step * 4 / Distance) * DX);
                Y = Y - (int)(RiseCount * (step / 12 / Distance) * DY);
            }
            else if (Current_BullType ==status_BullType.Bull)
            {
                X = BX + (int)(RiseCount * (step * 4 / Distance) * DX);
                Y = Y - (int)(RiseCount * (step / Distance) * DY);
            }
            else if (Current_BullType == status_BullType.LinkBomb)
            {
                Bomb_Index %= (BmpPlayerBullLinkBombList.Count);

                X = BX + (int)(RiseCount * (step * 4 / Distance) * DX);
                Y = Y - (int)(RiseCount * (step /4  / Distance) * DY);
            }


            if (Current_BullType == status_BullType.SuperBomb)
            {
                DrawImage(gd,s, t[2], X - Width / 2 - 2, Y);
            }
            else if(Current_BullType == status_BullType.LinkBomb)
            {
                DrawImage(gd,s, t2[Bomb_Index++], X, Y);

            }
            else
            {
                if (Big_Bull == false)
                    DrawImage(gd,s, t[0], X, Y);
                else
                    DrawImage(gd, s,t[1], X, Y);
            }

                if (Current_BullType == status_BullType.SuperBomb)
                {
                    if (Y<200)
                    Current_BullStatus = status_BullStatus.hit;
                }
                else 
                {
                    if (Y<0)
                    Current_BullStatus = status_BullStatus.miss;
                }
            
        }
        private void DrawImage(Device gd,Sprite s,  Texture t, int X, int Y)
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
            s_bull.Dispose();            
        }*/
                   
    }
}
