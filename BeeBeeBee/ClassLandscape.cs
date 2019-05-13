using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace BeeBeeBee
{
    class ClassLandscape
    {
        Brush[] Light = new Brush[]
        {
            Brushes.WhiteSmoke,
            Brushes.Gold,
            Brushes.Magenta,
            Brushes.Red,
            Brushes.LightBlue,
            Brushes.LightGreen,
            Brushes.Orange
        };
        public enum status { active, die };
        public status Current_Status;

        int Light_index = 0;
        int X = 0;//光點X座標
        int Y = 0;//光點Y座標
        int D = 5;//半徑
        int r = 0;//變化半徑
        int Delta_r = 1;//半徑變化量
        int Count = 0;//光點目前閃爍次數
        int Total_Count;//光點總共閃爍次數
        Random Rd=new Random();

        public ClassLandscape(int X,int Y,int Total_Count,status Current_Status)//建構式
        {
            this.X = X;
            this.Y = Y;
            this.Total_Count = Total_Count;
            this.Current_Status = Current_Status;
        }
        public void Draw(Graphics G)//畫圖
        {
            if (Current_Status != status.active) return;
            Light_index = Rd.Next(100);
            Light_index %= Light.Length;


            if (r > D || r < 0) Delta_r = -Delta_r;
            r = r + Delta_r;
            G.FillEllipse(Light[Light_index], X - r, Y - r, 2 * r, 2 * r);

            if (r == -1)
            {
                Count++;
                if (Count >= Total_Count)
                   Current_Status = status.die;
                    
            }
        }

    }
}
