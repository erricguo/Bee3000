using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BeeBeeBee
{
    class ClassSuperBoom:ClassBoom 
    {
   /*     private static Bitmap ResizeImage(Image ImageToResize, int Width, int Height)
        {
            Bitmap Bmp = new Bitmap(Width,Height);
            using (Graphics G = Graphics.FromImage(Bmp))
            {
                G.DrawImage(ImageToResize, 0, 0, Width, Height);
            }
            return Bmp;
        }*/
     /*   public void InitailizeImages_Bomb()
        {
            BmpSuperBomb[0] = ResizeImage(Properties.Resources.Super_Bomb_1, 600, 400);
            BmpSuperBomb[1] = ResizeImage(Properties.Resources.Super_Bomb_2, 600, 400);
            BmpSuperBomb[2] = ResizeImage(Properties.Resources.Super_Bomb_3, 600, 400);
            BmpSuperBomb[3] = ResizeImage(Properties.Resources.Super_Bomb_4, 600, 400);
            BmpSuperBomb[4] = ResizeImage(Properties.Resources.Super_Bomb_5, 600, 400);
            BmpSuperBomb[5] = ResizeImage(Properties.Resources.Super_Bomb_6, 600, 400);
            BmpSuperBomb[6] = ResizeImage(Properties.Resources.Super_Bomb_7, 600, 400);
            BmpSuperBomb[7] = ResizeImage(Properties.Resources.Super_Bomb_6, 600, 400);
            BmpSuperBomb[8] = ResizeImage(Properties.Resources.Super_Bomb_5, 600, 400);
            BmpSuperBomb[9] = ResizeImage(Properties.Resources.Super_Bomb_4, 600, 400);
            BmpSuperBomb[10] = ResizeImage(Properties.Resources.Super_Bomb_3, 600, 400);
            BmpSuperBomb[11] = ResizeImage(Properties.Resources.Super_Bomb_2, 600, 400);
            BmpSuperBomb[12] = ResizeImage(Properties.Resources.Super_Bomb_1, 600, 400);

            BmpLinkBomb[0] = ResizeImage(Properties.Resources.Super_Bomb_1, 150, 100);
            BmpLinkBomb[1] = ResizeImage(Properties.Resources.Super_Bomb_2, 150, 100);
            BmpLinkBomb[2] = ResizeImage(Properties.Resources.Super_Bomb_3, 150, 100);
            BmpLinkBomb[3] = ResizeImage(Properties.Resources.Super_Bomb_4, 150, 100);
            BmpLinkBomb[4] = ResizeImage(Properties.Resources.Super_Bomb_5, 150, 100);
            BmpLinkBomb[5] = ResizeImage(Properties.Resources.Super_Bomb_6, 150, 100);
            BmpLinkBomb[6] = ResizeImage(Properties.Resources.Super_Bomb_7, 150, 100);
            BmpLinkBomb[7] = ResizeImage(Properties.Resources.Super_Bomb_6, 150, 100);
            BmpLinkBomb[8] = ResizeImage(Properties.Resources.Super_Bomb_5, 150, 100);
            BmpLinkBomb[9] = ResizeImage(Properties.Resources.Super_Bomb_4, 150, 100);
            BmpLinkBomb[10] = ResizeImage(Properties.Resources.Super_Bomb_3, 150, 100);
            BmpLinkBomb[11] = ResizeImage(Properties.Resources.Super_Bomb_2, 150, 100);
            BmpLinkBomb[12] = ResizeImage(Properties.Resources.Super_Bomb_1, 150, 100);
        }*/

 /*       Bitmap[] BmpSuperBomb = new Bitmap[]//爆炸圖片設置
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
            Properties.Resources.Super_Bomb_1
        }; 
        Bitmap[] BmpLinkBomb = new Bitmap[]
        {
             Properties.Resources.Link_Bomb_1,
             Properties.Resources.Link_Bomb_2,
             Properties.Resources.Link_Bomb_3,
             Properties.Resources.Link_Bomb_4,
             Properties.Resources.Link_Bomb_5,
             Properties.Resources.Link_Bomb_6,
             Properties.Resources.Link_Bomb_7,
             Properties.Resources.Link_Bomb_6,
             Properties.Resources.Link_Bomb_5,
             Properties.Resources.Link_Bomb_4,
             Properties.Resources.Link_Bomb_3,
             Properties.Resources.Link_Bomb_2,
             Properties.Resources.Link_Bomb_1
        };
        */
        List<Bitmap> BmpSuperBoomList = new List<Bitmap>();
   //     int BmpBomb_Index = 0;//圖片索引
        int BmpBoom_Index = 0;
    //    int Count = 0;//現在爆炸次數
    //    int Total_Count;//呈現總次數
       public  int SuperBoom_Width = 600;
       public  int SuperBoom_Height =400;
        int SuperBoom_Range = 30;//爆炸擴散範圍

   //     int X = 0;//爆炸發生 X 位置
    //    int Y = 0;//爆炸發生 Y 位置
        //public Sprite s_boom = null;
        //public List<Texture> showPicture = null;//定义图片对象
        private const int frameCount = 7;//定义动画帧数目
        private int currentFrame = 0;//定义当前动画帧

       new  public enum   status  { active, die ,link };//可能狀態 活動或死亡
       new  public status Current_Status;//目前狀態
   //     int X1 = 0;
    //    int Y1 = 0;
        public ClassSuperBoom() { }
        public ClassSuperBoom(Device gd,int X,int Y,int Total_Count,status Current_Status,List<Bitmap> BmpSuperBoomList) 
        {
            this.X = X;
            this.Y = Y;
            this.Total_Count = Total_Count;
            this.Current_Status =Current_Status;
            if (Current_Status == status.link)
            {
                 SuperBoom_Width =120;
                 SuperBoom_Height = 80;
                 SuperBoom_Range = 0;//爆炸擴散範圍
            }
            this.BmpSuperBoomList = BmpSuperBoomList;
           /* s_boom = new Sprite(gd);
            for (int i = 0; i < frameCount; i++)
            {
                BmpBoom_Index %= BmpSuperBoomList.Count;
                showPicture.Add(new Texture(gd, BmpSuperBoomList[BmpBoom_Index++], 0, Pool.Managed));
            }*/
            //BmpBoom_Index %= BmpSuperBoomList.Count;
            //showPicture = new Texture(gd, BmpSuperBoomList[BmpBoom_Index++], 0, Pool.Managed);
        }

        public bool CheskCollision(int bee_x, int bee_y, int bee_w, int bee_h)//傳入座標為(bee_x + bee_Width/2 , bee_y)
        {
            if (bee_x > X - (SuperBoom_Width / 2 + SuperBoom_Range) && bee_x < X + (SuperBoom_Width / 2 + SuperBoom_Range))
            {
                if (bee_y > Y - (SuperBoom_Height / 2 + SuperBoom_Range) && bee_y < Y + (SuperBoom_Height / 2 + SuperBoom_Range))
                {
                    return true;
                }
            }
            return false;
        }

        System.Drawing.Point rotationPoint = new Point();
        System.Drawing.Point position = new Point();

        public void Draw(Device gd, Sprite s_boom, List<Texture> t, List<Texture> t2)
        {
            if (Current_Status == status.die) return;


            //BmpBoom_Index %= BmpSuperBoomList.Count;
            //G.DrawImage(BmpSuperBoomList[BmpBoom_Index++], X - SuperBoom_Width / 2, Y - SuperBoom_Height / 2, SuperBoom_Width, SuperBoom_Height);
            //DrawImage(gd, BmpSuperBoomList[BmpBoom_Index++], X - SuperBoom_Width / 2, Y - SuperBoom_Height / 2);
            if (Current_Status == status.link)
                DrawImage(gd, s_boom, t2, X - SuperBoom_Width / 2, Y - SuperBoom_Height / 2);
            else
                DrawImage(gd, s_boom, t, X - SuperBoom_Width / 2, Y - SuperBoom_Height / 2);
        /*    if (Current_Status == status.active)
            {

                BmpBomb_Index %= BmpSuperBombList.Count;
                G.DrawImage(BmpSuperBombList[BmpBomb_Index++], X - SuperBomb_Width / 2, Y - SuperBomb_Height / 2, SuperBomb_Width, SuperBomb_Height);
            }
            else if (Current_Status == status.link)
            {
                BmpBomb_Index %= BmpLinkBomb.Length;
                G.DrawImage(BmpLinkBomb[BmpBomb_Index++], X - SuperBomb_Width / 2, Y - SuperBomb_Height / 2, SuperBomb_Width, SuperBomb_Height);
            }*/
            Count++;
            if (Count >= Total_Count)
                Current_Status = status.die;
        }
        private void DrawImage(Device gd, Sprite s_boom, List<Texture> showPicture, int X, int Y)
        {
            if (currentFrame >= frameCount - 1)
            {
                currentFrame = 0;
            }
            else
            {
                currentFrame++;
            }

            position.X = X;
            position.Y = Y;
            s_boom.Begin(SpriteFlags.AlphaBlend);
            s_boom.Draw2D(showPicture[currentFrame], rotationPoint, 0f, position, Color.White);
            s_boom.End();

        }
        public void DisposeSprite()
        {
         /*   for (int i = 0; i < frameCount; i++)
            {
                showPicture[i].Dispose();
                showPicture[i] = null;
            }            
            s_boom.Dispose();*/
        }
    }
}
