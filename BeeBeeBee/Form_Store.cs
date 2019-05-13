using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeeBeeBee
{
    public partial class Form_Store : Form
    {
        DialogResult Rs = new DialogResult();

        int[] Exp = new int[] {400,600,1000,1200,1600,2400,120000 };
        int[] Money = new int[] {600,800,1200,4000,10000,15000,200000 };
        int[] Level = new int[] {1,1,2,3,4,5,6,};

        int Player_PowerCount = 2; //子彈數目 預設:1
        int Player_PowerCount_Limit = 5;
        double Player_Speed = 3;
        int Player_PowerUp = 1;//多重子彈  1=1 2=3 3=5
        bool Player_BigBull = false; //子彈大小 預設:false
        bool Player_Defense = false; //防護罩 預設:false
        bool Player_SuperBomb = false;
        bool Player_SuperType = false;
        int Player_NowExp = 0;
        int Player_NowMoney = 0;
        int Player_NowLevel = 0;
        int CostExp_Total = 0;
        int CostMoney_Total = 0;

        //Temp------------------------------------------------
        int Temp_Player_PowerCount = 2; //子彈數目 預設:1
        int Temp_Player_PowerCount_Limit = 5;
        double Temp_Player_Speed = 3;
        int Temp_Player_PowerUp = 1;//多重子彈  1=1 2=3 3=5
        bool Temp_Player_BigBull = false; //子彈大小 預設:false
        bool Temp_Player_Defense = false; //防護罩 預設:false
        bool Temp_Player_SuperBomb = false;
        bool Temp_Player_SuperType = false;
        int Temp_Player_NowExp = 0;
        int Temp_Player_NowMoney = 0;
        int Temp_Player_NowLevel = 0;
        //-----------------------------------------------------
        public Form_Play MainForm;

        public Form_Store()
        {
            InitializeComponent();
        }
        public DialogResult Result
        {
            get { return Rs; }
            set { Rs = value; }
        }
        public int _Player_PowerCount
        {
            get { return Player_PowerCount; }
            set { Player_PowerCount = value; }
        }
        public int _Player_PowerCount_Limit
        {
            get { return Player_PowerCount_Limit; }
            set { Player_PowerCount_Limit = value; }
        }
        public double _Player_Speed
        {
            get { return Player_Speed; }
            set { Player_Speed = value; }
        }
        public int _Player_PowerUp
        {
            get { return Player_PowerUp; }
            set { Player_PowerUp = value; }
        }
        public bool _Player_BigBull
        {
            get { return Player_BigBull; }
            set { Player_BigBull = value; }
        }
        public bool _Player_SuperBomb
        {
            get { return Player_SuperBomb; }
            set { Player_SuperBomb = value; }
        }
        public bool _Player_Defense
        {
            get { return Player_Defense; }
            set { Player_Defense = value; }
        }
        public bool _Player_SuperType
        {
            get { return Player_SuperType; }
            set { Player_SuperType = value; }
        }
        public int _PlayerExp
        {
            get { return Player_NowExp; }
            set { Player_NowExp = value; }
        }
        public int _PlayerMoney
        {
            get { return Player_NowMoney; }
            set { Player_NowMoney = value; }
        }
        public int _PlayerLevel
        {
            get { return Player_NowLevel; }
            set { Player_NowLevel = value; }
        }

        private void btn_PowerCount_MouseEnter(object sender, EventArgs e)
        {
            btn_PowerCount.Size = new Size(50, 50);
            btn_PowerCount.Location = new Point(95, 19);

        }

        private void btn_PowerCount_MouseLeave(object sender, EventArgs e)
        {
            btn_PowerCount.Size = new Size(40, 40);
            btn_PowerCount.Location = new Point(100, 24);
        }

        private void btn_PlayerSpeed_MouseEnter(object sender, EventArgs e)
        {
            btn_PowerSpeed.Size = new Size(50, 50);
            btn_PowerSpeed.Location = new Point(145, 19);
        }

        private void btn_PlayerSpeed_MouseLeave(object sender, EventArgs e)
        {
            btn_PowerSpeed.Size = new Size(40, 40);
            btn_PowerSpeed.Location = new Point(150, 24);
        }

        private void btn_PowerUp_MouseEnter(object sender, EventArgs e)
        {
            btn_PlayerUp.Size = new Size(50, 50);
            btn_PlayerUp.Location = new Point(195, 19);
        }

        private void btn_PowerUp_MouseLeave(object sender, EventArgs e)
        {
            btn_PlayerUp.Size = new Size(40, 40);
            btn_PlayerUp.Location = new Point(200, 24);
        }

        private void btn_BigBull_MouseEnter(object sender, EventArgs e)
        {
            btn_BigBull.Size = new Size(50, 50);
            btn_BigBull.Location = new Point(245, 19);
        }

        private void btn_BigBull_MouseLeave(object sender, EventArgs e)
        {
            btn_BigBull.Size = new Size(40, 40);
            btn_BigBull.Location = new Point(250, 24);
        }

        private void btn_SuperBomb_MouseEnter(object sender, EventArgs e)
        {
            btn_SuperBomb.Size = new Size(50, 50);
            btn_SuperBomb.Location = new Point(295, 19);
        }

        private void btn_SuperBomb_MouseLeave(object sender, EventArgs e)
        {
            btn_SuperBomb.Size = new Size(40, 40);
            btn_SuperBomb.Location = new Point(300, 24);
        }

        private void btn_Defense_MouseEnter(object sender, EventArgs e)
        {
            btn_Defense.Size = new Size(50, 50);
            btn_Defense.Location = new Point(345, 19);
        }

        private void btn_Defense_MouseLeave(object sender, EventArgs e)
        {
            btn_Defense.Size = new Size(40, 40);
            btn_Defense.Location = new Point(350, 24);
        }

        private void btn_SuperType_MouseEnter(object sender, EventArgs e)
        {
            btn_SuperType.Size = new Size(50, 50);
            btn_SuperType.Location = new Point(395, 19);
        }

        private void btn_SuperType_MouseLeave(object sender, EventArgs e)
        {
            btn_SuperType.Size = new Size(40, 40);
            btn_SuperType.Location = new Point(400, 24);
        }
        private void btn_Reset_MouseEnter(object sender, EventArgs e)
        {
            btn_Reset.Size = new Size(50, 30);
            btn_Reset.Location = new Point(395, 190);
            btn_Reset.BackColor = Color.Pink;
            btn_Reset.Font = new Font("微軟正黑體", 11, FontStyle.Bold);
        }

        private void btn_Reset_MouseLeave(object sender, EventArgs e)
        {
            btn_Reset.Size = new Size(40, 24);
            btn_Reset.Location = new Point(400, 193);
            btn_Reset.BackColor = Color.Lavender;
            btn_Reset.Font = new Font("微軟正黑體", 9, FontStyle.Bold);
        }

        private void btn_確定購買_MouseEnter(object sender, EventArgs e)
        {
            btn_確定購買.Size = new Size(80, 30);
            btn_確定購買.Location = new Point(445, 190);
            btn_確定購買.BackColor = Color.LightGreen;
            btn_確定購買.Font = new Font("微軟正黑體", 11, FontStyle.Bold);
        }

        private void btn_確定購買_MouseLeave(object sender, EventArgs e)
        {
            btn_確定購買.Size = new Size(70, 24);
            btn_確定購買.Location = new Point(450, 193);
            btn_確定購買.BackColor = Color.FromArgb(192, 255, 255);
            btn_確定購買.Font = new Font("微軟正黑體", 9, FontStyle.Bold);
        }
        private void Form_Store_Load(object sender, EventArgs e)
        {
            StatusTemp();//紀錄傳入的初始值
            Status_Info();//將值顯示在Labels
            CheckInfo(); //CheckColor
        }
        public void Status_Info()
        {
            Status_1.Text = Player_PowerCount.ToString() + "/" + Player_PowerCount_Limit.ToString();
            Status_2.Text = "Lv" + Player_Speed.ToString();
            Status_3.Text = "Lv" + Player_PowerUp.ToString();
            if (Player_BigBull) Status_4.Text = "ON";
            else Status_4.Text = "OFF";
            if (Player_SuperBomb) Status_5.Text = "ON";
            else Status_5.Text = "OFF";
            if (Player_Defense ) Status_6.Text = "ON";
            else Status_6.Text = "OFF";
            if (Player_SuperType ) Status_7.Text = "ON";
            else Status_7.Text = "OFF";
            lab_CostExp_Total.Text = CostExp_Total.ToString();
            lab_CostMoney_Total.Text = CostMoney_Total.ToString();
            lab_Player_NowExp.Text = Player_NowExp.ToString();
            lab_Player_NowMoney.Text = Player_NowMoney.ToString();
            lab_Player_NowLevel.Text = Player_NowLevel.ToString();
        }
        public void StatusTemp()
        {
            Temp_Player_PowerCount = Player_PowerCount ; //子彈數目 預設:1
            Temp_Player_PowerCount_Limit = Player_PowerCount_Limit;
            Temp_Player_Speed = Player_Speed ;
            Temp_Player_PowerUp = Player_PowerUp  ;//多重子彈  1=1 2=3 3=5
            Temp_Player_BigBull = Player_BigBull ; //子彈大小 預設:false
            Temp_Player_Defense = Player_Defense ; //防護罩 預設:false
            Temp_Player_SuperBomb = Player_SuperBomb ;
            Temp_Player_SuperType = Player_SuperType ;
            Temp_Player_NowExp = Player_NowExp ;
            Temp_Player_NowMoney = Player_NowMoney ;
            Temp_Player_NowLevel = Player_NowLevel ;
        }
        public void CheckInfo()
        {
            //--Check Exp
            if (Exp[0] < Player_NowExp) Exp_1.BackColor = Color.LightGreen;
            else Exp_1.BackColor = Color.Pink;
            if (Exp[1] < Player_NowExp) Exp_2.BackColor = Color.LightGreen;
            else Exp_2.BackColor = Color.Pink;
            if (Exp[2] < Player_NowExp) Exp_3.BackColor = Color.LightGreen;
            else Exp_3.BackColor = Color.Pink;
            if (Exp[3] < Player_NowExp) Exp_4.BackColor = Color.LightGreen;
            else Exp_4.BackColor = Color.Pink;
            if (Exp[4] < Player_NowExp) Exp_5.BackColor = Color.LightGreen;
            else Exp_5.BackColor = Color.Pink;
            if (Exp[5] < Player_NowExp) Exp_6.BackColor = Color.LightGreen;
            else Exp_6.BackColor = Color.Pink;
            if (Exp[6] < Player_NowExp) Exp_7.BackColor = Color.LightGreen;
            else Exp_7.BackColor = Color.Pink;
            Exp_1.Text = Exp[0].ToString();
            Exp_2.Text = Exp[1].ToString();
            Exp_3.Text = Exp[2].ToString();
            Exp_4.Text = Exp[3].ToString();
            Exp_5.Text = Exp[4].ToString();
            Exp_6.Text = Exp[5].ToString();
            Exp_7.Text = Exp[6].ToString();

      /*      if (int.Parse(Exp_1.Text) <= int.Parse(lab_NowExp.Text)) Exp_1.BackColor = Color.LightGreen;
            else Exp_1.BackColor = Color.Pink ;
            if (int.Parse(Exp_2.Text) <= int.Parse(lab_NowExp.Text)) Exp_2.BackColor = Color.LightGreen;
            else Exp_2.BackColor = Color.Pink;
            if (int.Parse(Exp_3.Text) <= int.Parse(lab_NowExp.Text)) Exp_3.BackColor = Color.LightGreen;
            else Exp_3.BackColor = Color.Pink;
            if (int.Parse(Exp_4.Text) <= int.Parse(lab_NowExp.Text)) Exp_4.BackColor = Color.LightGreen;
            else Exp_4.BackColor = Color.Pink;
            if (int.Parse(Exp_5.Text) <= int.Parse(lab_NowExp.Text)) Exp_5.BackColor = Color.LightGreen;
            else Exp_5.BackColor = Color.Pink;
            if (int.Parse(Exp_6.Text) <= int.Parse(lab_NowExp.Text)) Exp_6.BackColor = Color.LightGreen;
            else Exp_6.BackColor = Color.Pink;
            if (int.Parse(Exp_7.Text) <= int.Parse(lab_NowExp.Text)) Exp_7.BackColor = Color.LightGreen;
            else Exp_7.BackColor = Color.Pink;*/

            //Check Money
            if (Money[0] < Player_NowMoney) Money_1.BackColor = Color.LightGreen;
            else Money_1.BackColor = Color.Pink;
            if (Money[1] < Player_NowMoney) Money_2.BackColor = Color.LightGreen;
            else Money_2.BackColor = Color.Pink;
            if (Money[2] < Player_NowMoney) Money_3.BackColor = Color.LightGreen;
            else Money_3.BackColor = Color.Pink;
            if (Money[3] < Player_NowMoney) Money_4.BackColor = Color.LightGreen;
            else Money_4.BackColor = Color.Pink;
            if (Money[4] < Player_NowMoney) Money_5.BackColor = Color.LightGreen;
            else Money_5.BackColor = Color.Pink;
            if (Money[5] < Player_NowMoney) Money_6.BackColor = Color.LightGreen;
            else Money_6.BackColor = Color.Pink;
            if (Money[6] < Player_NowMoney) Money_7.BackColor = Color.LightGreen;
            else Money_7.BackColor = Color.Pink;
            Money_1.Text = Money[0].ToString();
            Money_2.Text = Money[1].ToString();
            Money_3.Text = Money[2].ToString();
            Money_4.Text = Money[3].ToString();
            Money_5.Text = Money[4].ToString();
            Money_6.Text = Money[5].ToString();
            Money_7.Text = Money[6].ToString();
     /*       if (int.Parse(Money_1.Text) <= int.Parse(lab_NowMoney.Text)) Money_1.BackColor = Color.LightGreen;
            else Money_1.BackColor = Color.Pink;
            if (int.Parse(Money_2.Text) <= int.Parse(lab_NowMoney.Text)) Money_2.BackColor = Color.LightGreen;
            else Money_2.BackColor = Color.Pink;
            if (int.Parse(Money_3.Text) <= int.Parse(lab_NowMoney.Text)) Money_3.BackColor = Color.LightGreen;
            else Money_3.BackColor = Color.Pink;
            if (int.Parse(Money_4.Text) <= int.Parse(lab_NowMoney.Text)) Money_4.BackColor = Color.LightGreen;
            else Money_4.BackColor = Color.Pink;
            if (int.Parse(Money_5.Text) <= int.Parse(lab_NowMoney.Text)) Money_5.BackColor = Color.LightGreen;
            else Money_5.BackColor = Color.Pink;
            if (int.Parse(Money_6.Text) <= int.Parse(lab_NowMoney.Text)) Money_6.BackColor = Color.LightGreen;
            else Money_6.BackColor = Color.Pink;
            if (int.Parse(Money_7.Text) <= int.Parse(lab_NowMoney.Text)) Money_7.BackColor = Color.LightGreen;
            else Money_7.BackColor = Color.Pink;*/

            //Check Lv
            if (Level[0] <= Player_NowLevel) Level_1.BackColor = Color.LightGreen;
            else Level_1.BackColor = Color.Pink;
            if (Level[1] <= Player_NowLevel) Level_2.BackColor = Color.LightGreen;
            else Level_2.BackColor = Color.Pink;
            if (Level[2] <= Player_NowLevel) Level_3.BackColor = Color.LightGreen;
            else Level_3.BackColor = Color.Pink;
            if (Level[3] <= Player_NowLevel) Level_4.BackColor = Color.LightGreen;
            else Level_4.BackColor = Color.Pink;
            if (Level[4] <= Player_NowLevel) Level_5.BackColor = Color.LightGreen;
            else Level_5.BackColor = Color.Pink;
            if (Level[5] <= Player_NowLevel) Level_6.BackColor = Color.LightGreen;
            else Level_6.BackColor = Color.Pink;
            if (Level[6] <= Player_NowLevel) Level_7.BackColor = Color.LightGreen;
            else Level_7.BackColor = Color.Pink;
            Level_1.Text = Level[0].ToString();
            Level_2.Text = Level[1].ToString();
            Level_3.Text = Level[2].ToString();
            Level_4.Text = Level[3].ToString();
            Level_5.Text = Level[4].ToString();
            Level_6.Text = Level[5].ToString();
            Level_7.Text = Level[6].ToString();

        /*    if (int.Parse(Level_1.Text) <= int.Parse(lab_NowLevel.Text.Substring (2,1))) Level_1.BackColor = Color.LightGreen;
            else Level_1.BackColor = Color.Pink;
            if (int.Parse(Level_2.Text) <= int.Parse(lab_NowLevel.Text.Substring (2,1))) Level_2.BackColor = Color.LightGreen;
            else Level_2.BackColor = Color.Pink;
            if (int.Parse(Level_3.Text) <= int.Parse(lab_NowLevel.Text.Substring (2,1))) Level_3.BackColor = Color.LightGreen;
            else Level_3.BackColor = Color.Pink;
            if (int.Parse(Level_4.Text) <= int.Parse(lab_NowLevel.Text.Substring (2,1))) Level_4.BackColor = Color.LightGreen;
            else Level_4.BackColor = Color.Pink;
            if (int.Parse(Level_5.Text) <= int.Parse(lab_NowLevel.Text.Substring (2,1))) Level_5.BackColor = Color.LightGreen;
            else Level_5.BackColor = Color.Pink;
            if (int.Parse(Level_6.Text) <= int.Parse(lab_NowLevel.Text.Substring (2,1))) Level_6.BackColor = Color.LightGreen;
            else Level_6.BackColor = Color.Pink;
            if (int.Parse(Level_7.Text) <= int.Parse(lab_NowLevel.Text.Substring (2,1))) Level_7.BackColor = Color.LightGreen;
            else Level_7.BackColor = Color.Pink;*/

            //Check Status
            if (Player_PowerCount < Player_PowerCount_Limit ) Status_1.BackColor = Color.LightGreen;
            else if (Player_PowerCount == 10) Status_1.BackColor = Color.LightBlue;
            else Status_1.BackColor = Color.Pink;
            if (Player_Speed  < 5) Status_2.BackColor = Color.LightGreen;
            else if (Player_Speed == 5) Status_2.BackColor = Color.LightBlue;
            else Status_2.BackColor = Color.Pink;
            if (Player_PowerUp  < 3) Status_3.BackColor = Color.LightGreen;
            else if (Player_PowerUp == 3) Status_3.BackColor = Color.LightBlue;
            else Status_3.BackColor = Color.Pink;
            if (Player_BigBull  == false) Status_4.BackColor = Color.LightGreen;
            else Status_4.BackColor = Color.LightBlue;
            if (Player_SuperBomb  == false) Status_5.BackColor = Color.LightGreen;
            else Status_5.BackColor = Color.LightBlue;
            if (Player_Defense  == false) Status_6.BackColor = Color.LightGreen;
            else Status_6.BackColor = Color.LightBlue;
            if (Player_SuperType  == false) Status_7.BackColor = Color.LightGreen;
            else Status_7.BackColor = Color.LightBlue;

      /*      if (int.Parse(Status_1.Text) < 10) Status_1.BackColor = Color.LightGreen;
            else if (int.Parse(Status_1.Text) == 10) Status_1.BackColor = Color.LightBlue;
            else Status_1.BackColor = Color.Pink;
            if (int.Parse(Status_2.Text.Substring(2, 1)) < 5) Status_2.BackColor = Color.LightGreen;
            else if (int.Parse(Status_2.Text.Substring(2, 1)) == 5) Status_2.BackColor = Color.LightBlue;
            else Status_2.BackColor = Color.Pink;
            if (int.Parse(Status_3.Text.Substring(2, 1)) < 3) Status_3.BackColor = Color.LightGreen;
            else if (int.Parse(Status_3.Text.Substring(2, 1)) == 3) Status_3.BackColor = Color.LightBlue;
            else Status_3.BackColor = Color.Pink;
            if (Status_4.Text == "OFF") Status_4.BackColor = Color.LightGreen;
            else Status_4.BackColor = Color.LightBlue;
            if (Status_5.Text == "OFF") Status_5.BackColor = Color.LightGreen;
            else Status_5.BackColor = Color.LightBlue;
            if (Status_6.Text == "OFF") Status_6.BackColor = Color.LightGreen;
            else Status_6.BackColor = Color.LightBlue;
            if (Status_7.Text == "OFF") Status_7.BackColor = Color.LightGreen;
            else Status_7.BackColor = Color.LightBlue;*/
        }


        private void btn_PowerCount_Click(object sender, EventArgs e)
        {
            if (Exp_1.BackColor == Color.LightGreen && Money_1.BackColor == Color.LightGreen && Level_1.BackColor == Color.LightGreen && Status_1.BackColor == Color.LightGreen)
            {
                Player_NowExp -= Exp[0];
                Player_NowMoney -= Money[0];
                if (Player_PowerCount < Player_PowerCount_Limit) Player_PowerCount++;
                CostExp_Total += Exp[0];
                CostMoney_Total += Money[0];
                Status_Info();
                CheckInfo();
            }
            else
            {
 
            }
        }
        private void btn_PlayerSpeed_Click(object sender, EventArgs e)
        {
            if (Exp_2.BackColor == Color.LightGreen && Money_2.BackColor == Color.LightGreen && Level_2.BackColor == Color.LightGreen && Status_2.BackColor == Color.LightGreen)
            {
                Player_NowExp -= Exp[1];
                Player_NowMoney -= Money[1];
                if (Player_Speed  < 5) Player_Speed++ ;
                CostExp_Total += Exp[1];
                CostMoney_Total += Money[1];
                Status_Info();
                CheckInfo();
            }
        }

        private void btn_PlayerUp_Click(object sender, EventArgs e)
        {
            if (Exp_3.BackColor == Color.LightGreen && Money_3.BackColor == Color.LightGreen && Level_3.BackColor == Color.LightGreen && Status_3.BackColor == Color.LightGreen)
            {
                Player_NowExp -= Exp[2];
                Player_NowMoney -= Money[2];
                if (Player_PowerUp  < 3) Player_PowerUp++;
                CostExp_Total += Exp[2];
                CostMoney_Total += Money[2];
                Status_Info();
                CheckInfo();
            }
        }

        private void btn_BigBull_Click(object sender, EventArgs e)
        {
            if (Exp_4.BackColor == Color.LightGreen && Money_4.BackColor == Color.LightGreen && Level_4.BackColor == Color.LightGreen && Status_4.BackColor == Color.LightGreen)
            {
                Player_NowExp -= Exp[3];
                Player_NowMoney -= Money[3];
                Player_BigBull=true ;
                CostExp_Total += Exp[3];
                CostMoney_Total += Money[3];
                Status_Info();
                CheckInfo();
            }
        }

        private void btn_SuperBomb_Click(object sender, EventArgs e)
        {
            if (Exp_5.BackColor == Color.LightGreen && Money_5.BackColor == Color.LightGreen && Level_5.BackColor == Color.LightGreen && Status_5.BackColor == Color.LightGreen)
            {
                Player_NowExp -= Exp[4];
                Player_NowMoney -= Money[4];
                Player_SuperBomb = true;
                CostExp_Total += Exp[4];
                CostMoney_Total += Money[4];
                Status_Info();
                CheckInfo();
            }
        }

        private void btn_Defense_Click(object sender, EventArgs e)
        {
            if (Exp_6.BackColor == Color.LightGreen && Money_6.BackColor == Color.LightGreen && Level_6.BackColor == Color.LightGreen && Status_6.BackColor == Color.LightGreen)
            {
                Player_NowExp -= Exp[5];
                Player_NowMoney -= Money[5];
                Player_Defense = true;
                CostExp_Total += Exp[5];
                CostMoney_Total += Money[5];
                Status_Info();
                CheckInfo();
            }
        }

        private void btn_SuperType_Click(object sender, EventArgs e)
        {
            if (Exp_7.BackColor == Color.LightGreen && Money_7.BackColor == Color.LightGreen && Level_7.BackColor == Color.LightGreen && Status_7.BackColor == Color.LightGreen)
            {
                Player_NowExp -= Exp[6];
                Player_NowMoney -= Money[6];
                Player_SuperType = true;
                CostExp_Total += Exp[6];
                CostMoney_Total += Money[6];
                Status_Info();
                CheckInfo();
            }
        }

        private void btn_確定購買_Click(object sender, EventArgs e)
        {
            Rs = DialogResult.OK;
            this.Close();
            this.Dispose();
        }

        private void Form_Store_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.U)
            {
                Rs = DialogResult.OK;
                this.Close();
                this.Dispose();
            }
            if (e.KeyCode == Keys.A)
            {
                SendKeys.Send("{Left}");
            }
            if (e.KeyCode == Keys.D)
            {
                SendKeys.Send("{Right}");
            }

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Player_PowerCount = Temp_Player_PowerCount;
            Player_PowerCount_Limit = Temp_Player_PowerCount_Limit;
            Player_Speed = Temp_Player_Speed;
            Player_PowerUp = Temp_Player_PowerUp;
            Player_BigBull = Temp_Player_BigBull;
            Player_Defense = Temp_Player_Defense;
            Player_SuperBomb = Temp_Player_SuperBomb;
            Player_SuperType = Temp_Player_SuperType;

            CostExp_Total = 0;
            CostMoney_Total = 0;
            Player_NowExp = Temp_Player_NowExp;
            Player_NowMoney = Temp_Player_NowMoney;
            Player_NowLevel = Temp_Player_NowLevel;

            Status_Info();
            CheckInfo();
        }











    }
}
