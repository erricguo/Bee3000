using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BeeBeeBee
{
    class ClassItems
    {
        List<Bitmap> BmpItemsList;
   /*     Bitmap[] Bmp_Items = new Bitmap[] 
        {
            Properties.Resources.增加子彈,
            Properties.Resources.子彈變多,
            Properties.Resources.PowerBomb,
            Properties.Resources.子彈變大,
            Properties.Resources.PowerStep,
            Properties.Resources.Defense 
        };
*/
        int BmpItems_Index = 0;
        int X, Y;//目前座標
        double step=0.1;
        double Distance = 0;
        int Width = 15;
        int Height = 15;
        bool Falling = true;
        int FallingCount = 0;
        int DY;
        //Random Rd=new Random();
        int Rd_Num = 0;
        static int Rd_Range = 0;
        //public Sprite s_item = null;
        //public Texture showPicture;//定义图片对象

        public bool _Falling
        {
            get { return Falling; }
            set {  Falling=value ; }
        }
        public int _Rd_Range
        {
            get { return Rd_Range; }
            set { Rd_Range = value; }
        }
        public bool Get_Item_Empty
        {
            get { return (BmpItems_Index == 6); }
        }
        public ClassItems() { }
        public ClassItems(Device gd,int bee_x,int bee_y,bool Falling,List<Bitmap> BmpItemsList )
        {
            X = bee_x +Width/2;
            Y = bee_y+Height  ;
            Distance = Y;
            DY = Y;
            this.Falling = Falling;
            this.BmpItemsList = BmpItemsList;
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            Rd_Num = rand.Next(50+Rd_Range);
            if (Rd_Num >= 0 && Rd_Num < 8) { BmpItems_Index = 0; Rd_Range++; }//Power_Count
            else if (Rd_Num >= 10 && Rd_Num < 14) { BmpItems_Index = 1; Rd_Range += 1; }//Power_Up
            else if (Rd_Num >= 20 && Rd_Num < 22) { BmpItems_Index = 2; Rd_Range += 2; }//Power_Bomb
            else if (Rd_Num >= 30 && Rd_Num < 33) { BmpItems_Index = 3; Rd_Range += 2; }//Big_Bull
            else if (Rd_Num >= 40 && Rd_Num < 45) { BmpItems_Index = 4; Rd_Range += 1; }//Power_Step
            else if (Rd_Num == 50) { BmpItems_Index = 5; Rd_Range += 3; Rd_Range += 2; }//Defense
            else { BmpItems_Index = 6; }//Empty
           /* if (BmpItems_Index < 6)
            {

                s_item = new Sprite(gd);
                 for (int i = 0; i < BmpItemsList.Count(); i++)
                 {
                     showPicture.Add(new Texture(gd, BmpItemsList[i], 0, Pool.Managed));
                 }
                showPicture = (new Texture(gd, BmpItemsList[BmpItems_Index], 0, Pool.Managed));
            }*/
            
        }
        //碰撞測試
        public int CheckCollision(int P1_x, int P1_y, int P1_w, int P1_h)
        {
            if (X > P1_x - Width / 2 && X < P1_x + P1_w + Width / 2)
            {
                if (Y > P1_y - Height / 2 && Y < P1_y + P1_h + Height / 2)
                {
                    return BmpItems_Index ;
                }
            }
            return 9;
        }

        System.Drawing.Point rotationPoint = new Point();
        System.Drawing.Point position = new Point();
        public void Draw(Device gd, Sprite s, List<Texture> t)
        {
            if (!Falling) return;

            FallingCount++;
            Y = Y+(int)(FallingCount * (step / Distance) * DY);


            if (BmpItems_Index == 0) //Bull_Count
                DrawImageUnscaled(gd,s, t[0], X, Y);
            if (BmpItems_Index == 1)//Bull_Power
                DrawImageUnscaled(gd,s, t[1], X, Y);
            if (BmpItems_Index == 2)//Bull_Bomb
                DrawImageUnscaled(gd,s, t[2], X, Y);
            if (BmpItems_Index == 3)//Big BUll
                DrawImageUnscaled(gd,s, t[3], X, Y);
            if (BmpItems_Index == 4)//Player_Step
                DrawImageUnscaled(gd,s, t[4], X, Y);
            if (BmpItems_Index == 5)//Player_Defense
                DrawImageUnscaled(gd,s, t[5], X, Y);
            if (Y > 600)
            {
                Falling = false;
            }
        }
        private void DrawImageUnscaled(Device gd, Sprite s, Texture t,int X, int Y)
        {
            position.X = X;
            position.Y = Y;
            s.Begin(SpriteFlags.AlphaBlend);
            s.Draw2D(t, rotationPoint, 0f, position, Color.White);
            s.End();
        }
        /*public void DisposeSprite()
        {
            showPicture.Dispose();
            s_item.Dispose();
        }*/
    }
}
