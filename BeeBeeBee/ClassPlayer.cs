using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace BeeBeeBee
{
    class ClassPlayer
    {
        List<Bitmap> BmpPlayerList;
        List<Bitmap> BmpPlayerDefenseList_Left;
        List<Bitmap> BmpPlayerDefenseList_Right;
    /*    Bitmap[] Bmp_Player = new Bitmap[]
        {
            Properties.Resources.玩家,
            Properties.Resources.玩家Invincible_1,
            Properties.Resources.玩家Invincible_2,
            Properties.Resources.玩家Invincible_2,
            Properties.Resources.玩家Invincible_1,
            Properties.Resources.玩家
        };*/
    /*    Bitmap[] Bmp_Player_Defense = new Bitmap[]
        {
            Properties.Resources.PlayerDefense1,
            Properties.Resources.PlayerDefense2,
            Properties.Resources.PlayerDefense3,
            Properties.Resources.PlayerDefense4,
            Properties.Resources.PlayerDefense5,
            Properties.Resources.PlayerDefense6,
            Properties.Resources.PlayerDefense7,
            Properties.Resources.PlayerDefense8,
            Properties.Resources.PlayerDefense9,
            Properties.Resources.PlayerDefense10,
            Properties.Resources.PlayerDefense11,
            Properties.Resources.PlayerDefense12
        };*/
        System.Drawing.Drawing2D.Matrix PlayerMatrix;
        int[] LevelUp_Exp = new int[] {10000,28000,54000,89000,135000,0 };
       // int DefenseTime = 0;
        int Bmp_Player_Index = 0;//玩家無敵圖片索引
        int Bmp_Player_Defense_Index_Left = 0;
        int Bmp_Player_Defense_Index_Right = 0;
        int Player_Defense_Life = 0;
        int Width = 60; //機身寬
        int Height = 45;//機身高        
        int BX ; //起始位置
        int BY ; //起始位置
        int X, Y;//目前位置
        bool GameOver = false;//遊戲是否結束
        int Player_Life = 3;//生命值 預設:3
        int Player_PowerCount = 3; //子彈數目 預設:1
        int Player_PowerCount_Limit = 5;
        int Player_PowerUp = 1;//多重子彈  1=1 2=3 3=5
        double Player_Speed = 3;
        bool Player_BigBull=false; //子彈大小 預設:false
        bool Player_Defense = false ; //防護罩 預設:false
        bool Player_SuperBomb = false;
        bool Player_SuperType = false;
        int Player_NowExp = 0;
        int Player_NowMoney=0;
        int Player_NowLevel = 1;
        int Combo = 0;//連擊數
        int MaxCombo = 0;//最大連擊
        int ResetTime = 100;
        bool PLayer_Invincible = true;//玩家是否無敵
        int  Player_ShootCount = 0;//發射彈數
        bool IsDrag = false; //是否使用拖曳
        public bool IsVisible = true;

        public bool IsMoveLeft { get; set; }
        public bool IsMoveRight { get; set; }

        // public Sprite player = null;
        // public  Texture showPicture;//定义图片对象


        public int _X  { get { return X; } set { X = value; }}
        public int _Y  { get { return Y; } set { Y = value; }}
        public int _Height {get { return Height; } set { Height = value; }}
        public int _Width  {get { return Width;  } set { Width = value; }}
        public bool _IsDrag { get { return IsDrag; } set { IsDrag = value; } }
        public int _Player_PowerUp
        {
            get { return Player_PowerUp; }
            set { if (value > 6) { value = 6; } Player_PowerUp = value; }
        }
        public int _Player_PowerCount
        {
            get { return Player_PowerCount; }
            set 
            {
                if (value >= Player_PowerCount_Limit) Player_PowerCount = Player_PowerCount_Limit; 
                else Player_PowerCount = value; 
            }
        }
        public double _Player_Speed
        {
            get { return Player_Speed; }
            set { if (value > 7) { value = 7; } Player_Speed = value; }
        }
        public bool _GameOver { get { return GameOver; } set { GameOver = value; } }
        public int _Player_Life { get { return Player_Life; } set { Player_Life = value ; } }
        public bool _Player_BigBull { get { return Player_BigBull; } set { Player_BigBull = value; } }
        public bool _Player_SuperBomb { get { return Player_SuperBomb; } set { Player_SuperBomb = value; } }
        public bool _Player_Defense { get { return Player_Defense; } set { Player_Defense = value; } }
        public int _Player_Defense_Life { get { return Player_Defense_Life; } set { Player_Defense_Life = value; } }
        public bool _Player_SuperType { get { return Player_SuperType; } set { Player_SuperType = value; } }
        public int _Player_NowExp { get { return Player_NowExp; } set { Player_NowExp = value; } }
        public int _PLayer_NowMoney { get{ return Player_NowMoney ;} set { Player_NowMoney=value; } }
        public int _Player_NowLevel { get { return Player_NowLevel; } set { Player_NowLevel = value; } }
        public bool _PLayer_Invincible { get { return PLayer_Invincible; } set { PLayer_Invincible = value; } }
        public int _Player_PowerCount_Limit { get { return Player_PowerCount_Limit; } set { Player_PowerCount_Limit = value; } }
        public int _Combo { get { return Combo; } set { Combo = value; } }
        public int _MaxCombo { get { return MaxCombo; } set { MaxCombo = value; } }
        public int _Player_ShootCount { get { return Player_ShootCount; } set { Player_ShootCount = value; } }
        public int _LevelUp_Exp { get { return LevelUp_Exp[Player_NowLevel-1]; }  }
 
        public void Check_Player_Exp(int Player_NowExp , int Player_NowLevel)
        {
            switch (Player_NowLevel)
            {
                case 1://Lv2
                    if (Player_NowExp >= LevelUp_Exp[0])
                    {
                        this.Player_NowLevel = ++Player_NowLevel;
                        Player_PowerCount_Limit++;
                        _Player_PowerCount++;
                        Player_PowerUp++;
                    }
                    break;
                case 2://Lv3
                    if (Player_NowExp >= LevelUp_Exp[1])
                    {
                        this.Player_NowLevel = ++Player_NowLevel;
                        Player_PowerCount_Limit++;
                        _Player_PowerCount++;
                        _Player_Speed++;
                        Player_PowerUp++;
                    }
                    break;
                case 3://Lv4
                    if (Player_NowExp >= LevelUp_Exp[2])
                    {
                        this.Player_NowLevel = ++Player_NowLevel;
                        Player_PowerCount_Limit++;
                        _Player_PowerCount += 2;
                        _Player_Speed++;
                        Player_PowerUp++;
                    }
                    break;
                case 4://Lv5
                    if (Player_NowExp >= LevelUp_Exp[3])
                    {
                        this.Player_NowLevel = ++Player_NowLevel;
                        Player_PowerCount_Limit++;
                        _Player_PowerCount +=2 ;
                        _Player_Speed++;
                        Player_PowerUp++;
                    }
                    break;
                case 5:
                    if (Player_NowExp >= LevelUp_Exp[4])
                    {
                        this.Player_NowLevel = ++Player_NowLevel;
                        Player_PowerCount_Limit++;
                        _Player_PowerCount += 2;
                        _Player_Speed++;
                        Player_PowerUp++;
                    }
                    break;
                /*case 6:
                        Player_PowerCount_Limit =100;
                        Player_PowerCount = 100;
                        Player_Speed = 7;
                        break;*/
                default:
                        break;
            }
        }


        public void Check_Player_Level(int Player_NowLevel)
        {
            switch (Player_NowLevel)
            {
                case 1:
                    Player_PowerCount_Limit = 5;
                    Player_PowerCount = 3;
                    Player_PowerUp = 1;
                    Player_Speed = 3;
                    break;
                case 2:
                    Player_PowerCount_Limit = 6;
                    Player_PowerCount = 3;
                    Player_PowerUp = 1;
                    Player_Speed = 3;
                    break;
                case 3:
                    Player_PowerCount_Limit = 7;
                    Player_PowerCount = 4;
                    Player_PowerUp = 1;
                    Player_Speed = 4;
                    break;
                case 4:
                    Player_PowerCount_Limit = 8;
                    Player_PowerCount = 6;
                    Player_PowerUp = 1;
                    Player_Speed = 5;
                    break;
                case 5:
                    Player_PowerCount_Limit = 9;
                    Player_PowerCount = 8;
                    Player_PowerUp = 1;
                    Player_Speed = 6;
                    break;
                case 6:
                    Player_PowerCount_Limit = 100;
                    Player_PowerCount = 100;
                    Player_PowerUp = 1;
                    Player_Speed = 7;
                    break;
                default:
                    break;
            }
        }

        public ClassPlayer()//建構式
        {
            BX = 300 - Width / 2; //起始位置
            BY = 470 + Height ;
            X = BX;
            Y = BY;
            PlayerMatrix = new System.Drawing.Drawing2D.Matrix(BX, BY, BX + Width, BY + Height, 0, 0);
        }
        public void SetBmp_Player(List<Bitmap> BmpPlayerList, List<Bitmap> BmpPlayerDefenseList_Left, List<Bitmap> BmpPlayerDefenseList_Right)
        {
            //player = new Sprite(gd);
            //showPicture = new Texture(gd, BmpPlayerList[0], 0, Pool.Managed);
            //string imagePath = @"G:\cocos2d-2.0-x-2.0.3\FLIGHTDEMO\Resources\map.png";
            //showPicture = TextureLoader.FromFile(gd, imagePath);
            this.BmpPlayerList = BmpPlayerList;
            this.BmpPlayerDefenseList_Left = BmpPlayerDefenseList_Left;
            this.BmpPlayerDefenseList_Right = BmpPlayerDefenseList_Right;
        }
        public void Reset_Player()//玩家爆炸之後重置
        {
            IsDrag = false;
            X = BX;
            Y = BY;
            Player_Life--;
            if (Player_Life < 0) { Player_Life = 0; GameOver = true; };
            PLayer_Invincible = true;
            Player_BigBull = false;
            Player_Defense = false;
            Player_SuperBomb = false;
            Combo = 0;
            PlayerMatrix = new System.Drawing.Drawing2D.Matrix(BX, BY, BX + Width, BY + Height, 0, 0);
            ResetTime = 0;
            Check_Player_Level(Player_NowLevel);
        }

        public void Get_Player_Left()//左移
        {
          X -=(int) Player_Speed;
          if (X <= 0) X = 0;
        }
        public void Get_Player_Right()//右移
        {
          X += (int)Player_Speed;
          if (X + Width >= 600) X = 600 - Width; 
        }

        //public void Draw(Graphics G, bool Invincible)
        System.Drawing.Point rotationPoint = new Point();
        System.Drawing.Point position = new Point();
        public void Draw(Device gd, Sprite s, Sprite DL, Sprite DR, List<Texture> t, List<Texture> t2, bool Invincible)
        {
            if (GameOver) return;
            
            if (Player_Defense_Life > 0)
            {
                Bmp_Player_Defense_Index_Left %= BmpPlayerDefenseList_Left.Count;
                Bmp_Player_Defense_Index_Right %= BmpPlayerDefenseList_Right.Count;
                Bmp_Player_Defense_Index_Right += BmpPlayerDefenseList_Left.Count;
                //G.DrawImage(BmpPlayerDefenseList_Left[Bmp_Player_Defense_Index_Left++], X - 45, Y);
                DrawImage(gd, DL, t2[Bmp_Player_Defense_Index_Left++], X-45, Y);
                //G.DrawImage(BmpPlayerDefenseList_Right[Bmp_Player_Defense_Index_Right++], X + 60, Y);
                DrawImage(gd, DR, t2[Bmp_Player_Defense_Index_Right++], X+60, Y);
            }

            if (!Invincible)//NOT無敵
            {
                DrawImage(gd, s, t[0], X, Y);
            }
            else
            {
                ResetTime++;
                if (ResetTime < 110)
                {
                    IsVisible = false;
                    return;
                }
                else
                {
                    IsVisible = true;
                    Bmp_Player_Index %= BmpPlayerList.Count;
                    DrawImage(gd, s, t[Bmp_Player_Index++], X, Y);
                }
            }

           /* if (Player_Defense_Life > 0)
            {
                Bmp_Player_Defense_Index_Left  %= BmpPlayerDefenseList_Left.Count;
                Bmp_Player_Defense_Index_Right %= BmpPlayerDefenseList_Right.Count;
                G.DrawImage(BmpPlayerDefenseList_Left[Bmp_Player_Defense_Index_Left++], X -45, Y );
                G.DrawImage(BmpPlayerDefenseList_Right[Bmp_Player_Defense_Index_Right++], X + 60, Y );
            }

            if (!Invincible)//NOT無敵
                Graphics.DrawImage(BmpPlayerList[0], X, Y);
            else//無敵
            {
                ResetTime++;
                if (ResetTime < 100)  return;
                else
                {                    
                    Bmp_Player_Index %= BmpPlayerList.Count;
                    G.DrawImage(BmpPlayerList[Bmp_Player_Index++], X, Y);
                }
            }*/
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        private void DrawImage(Device gd, Sprite s, Texture t, int X, int Y)
        {
            position.X = X;
            position.Y = Y;
            s.Begin(SpriteFlags.AlphaBlend);
            s.Draw2D(t, rotationPoint, 0f, position, Color.White);
            s.End();
        }
      /*  public void DisposeSprite()
        {
            showPicture.Dispose();
            player.Dispose();
        }*/
    }

}
