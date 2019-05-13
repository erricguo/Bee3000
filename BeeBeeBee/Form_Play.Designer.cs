namespace BeeBeeBee
{
    partial class Form_Play
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Play));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer_Player_Move_Left = new System.Windows.Forms.Timer(this.components);
            this.timer_Player_Move_Right = new System.Windows.Forms.Timer(this.components);
            this.gBox_Data = new System.Windows.Forms.GroupBox();
            this.lab_Player_NowExp = new System.Windows.Forms.Label();
            this.lab_Player_NowLevel = new System.Windows.Forms.Label();
            this.lab_Player_NowMoney = new System.Windows.Forms.Label();
            this.lab_金錢 = new System.Windows.Forms.Label();
            this.lab_Player_Speed = new System.Windows.Forms.Label();
            this.lab_Combo = new System.Windows.Forms.Label();
            this.pBox_Player_Speed = new System.Windows.Forms.PictureBox();
            this.pBox_Player_Defense = new System.Windows.Forms.PictureBox();
            this.pBox_Player_SuperBomb = new System.Windows.Forms.PictureBox();
            this.pBox_Player_BigBull = new System.Windows.Forms.PictureBox();
            this.lab_MaxCombo = new System.Windows.Forms.Label();
            this.lab_最大連擊 = new System.Windows.Forms.Label();
            this.lab_Player_PowerUp = new System.Windows.Forms.Label();
            this.pBox_Player_PowerUp = new System.Windows.Forms.PictureBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.lab_Player_PowerCount = new System.Windows.Forms.Label();
            this.pBox_Player_PowerCount = new System.Windows.Forms.PictureBox();
            this.lab_Player_Life = new System.Windows.Forms.Label();
            this.pBox_Player = new System.Windows.Forms.PictureBox();
            this.lab_HitCalcu = new System.Windows.Forms.Label();
            this.lab_Miss機率 = new System.Windows.Forms.Label();
            this.lab_Player_DieCount = new System.Windows.Forms.Label();
            this.lab_死亡次數 = new System.Windows.Forms.Label();
            this.lab_Miss_Bee = new System.Windows.Forms.Label();
            this.lab_Bee通過 = new System.Windows.Forms.Label();
            this.lab_Miss_Bull = new System.Windows.Forms.Label();
            this.lab_未擊中 = new System.Windows.Forms.Label();
            this.lab_Player_ShootCount = new System.Windows.Forms.Label();
            this.lab_發射彈數 = new System.Windows.Forms.Label();
            this.lab_UseTime = new System.Windows.Forms.Label();
            this.lab_DieCount = new System.Windows.Forms.Label();
            this.lab_Scores = new System.Windows.Forms.Label();
            this.lab使用時間 = new System.Windows.Forms.Label();
            this.lab擊落總數 = new System.Windows.Forms.Label();
            this.lab_得分 = new System.Windows.Forms.Label();
            this.timer_UseTime = new System.Windows.Forms.Timer(this.components);
            this.timer_StartTime = new System.Windows.Forms.Timer(this.components);
            this.timer_Bee = new System.Windows.Forms.Timer(this.components);
            this.timer_Landscape = new System.Windows.Forms.Timer(this.components);
            this.timer_Bull = new System.Windows.Forms.Timer(this.components);
            this.timer_Items = new System.Windows.Forms.Timer(this.components);
            this.timer_Boom = new System.Windows.Forms.Timer(this.components);
            this.timer_EndTime = new System.Windows.Forms.Timer(this.components);
            this.timer_BossBee = new System.Windows.Forms.Timer(this.components);
            this.gBox_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_Speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_Defense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_SuperBomb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_BigBull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_PowerUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_PowerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer_Player_Move_Left
            // 
            this.timer_Player_Move_Left.Interval = 15;
            this.timer_Player_Move_Left.Tick += new System.EventHandler(this.timer2_Player_Move_Left_Tick);
            // 
            // timer_Player_Move_Right
            // 
            this.timer_Player_Move_Right.Interval = 15;
            this.timer_Player_Move_Right.Tick += new System.EventHandler(this.timer_Player_Move_Right_Tick);
            // 
            // gBox_Data
            // 
            this.gBox_Data.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.gBox_Data.BackColor = System.Drawing.Color.Black;
            this.gBox_Data.Controls.Add(this.lab_Player_NowExp);
            this.gBox_Data.Controls.Add(this.lab_Player_NowLevel);
            this.gBox_Data.Controls.Add(this.lab_Player_NowMoney);
            this.gBox_Data.Controls.Add(this.lab_金錢);
            this.gBox_Data.Controls.Add(this.lab_Player_Speed);
            this.gBox_Data.Controls.Add(this.lab_Combo);
            this.gBox_Data.Controls.Add(this.pBox_Player_Speed);
            this.gBox_Data.Controls.Add(this.pBox_Player_Defense);
            this.gBox_Data.Controls.Add(this.pBox_Player_SuperBomb);
            this.gBox_Data.Controls.Add(this.pBox_Player_BigBull);
            this.gBox_Data.Controls.Add(this.lab_MaxCombo);
            this.gBox_Data.Controls.Add(this.lab_最大連擊);
            this.gBox_Data.Controls.Add(this.lab_Player_PowerUp);
            this.gBox_Data.Controls.Add(this.pBox_Player_PowerUp);
            this.gBox_Data.Controls.Add(this.axWindowsMediaPlayer1);
            this.gBox_Data.Controls.Add(this.lab_Player_PowerCount);
            this.gBox_Data.Controls.Add(this.pBox_Player_PowerCount);
            this.gBox_Data.Controls.Add(this.lab_Player_Life);
            this.gBox_Data.Controls.Add(this.pBox_Player);
            this.gBox_Data.Controls.Add(this.lab_HitCalcu);
            this.gBox_Data.Controls.Add(this.lab_Miss機率);
            this.gBox_Data.Controls.Add(this.lab_Player_DieCount);
            this.gBox_Data.Controls.Add(this.lab_死亡次數);
            this.gBox_Data.Controls.Add(this.lab_Miss_Bee);
            this.gBox_Data.Controls.Add(this.lab_Bee通過);
            this.gBox_Data.Controls.Add(this.lab_Miss_Bull);
            this.gBox_Data.Controls.Add(this.lab_未擊中);
            this.gBox_Data.Controls.Add(this.lab_Player_ShootCount);
            this.gBox_Data.Controls.Add(this.lab_發射彈數);
            this.gBox_Data.Controls.Add(this.lab_UseTime);
            this.gBox_Data.Controls.Add(this.lab_DieCount);
            this.gBox_Data.Controls.Add(this.lab_Scores);
            this.gBox_Data.Controls.Add(this.lab使用時間);
            this.gBox_Data.Controls.Add(this.lab擊落總數);
            this.gBox_Data.Controls.Add(this.lab_得分);
            this.gBox_Data.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gBox_Data.Location = new System.Drawing.Point(591, 0);
            this.gBox_Data.Name = "gBox_Data";
            this.gBox_Data.Size = new System.Drawing.Size(200, 566);
            this.gBox_Data.TabIndex = 0;
            this.gBox_Data.TabStop = false;
            this.gBox_Data.Text = "狀態欄";
            // 
            // lab_Player_NowExp
            // 
            this.lab_Player_NowExp.BackColor = System.Drawing.Color.Transparent;
            this.lab_Player_NowExp.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Player_NowExp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_Player_NowExp.Location = new System.Drawing.Point(87, 330);
            this.lab_Player_NowExp.Name = "lab_Player_NowExp";
            this.lab_Player_NowExp.Size = new System.Drawing.Size(102, 12);
            this.lab_Player_NowExp.TabIndex = 34;
            this.lab_Player_NowExp.Text = "0";
            this.lab_Player_NowExp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_Player_NowLevel
            // 
            this.lab_Player_NowLevel.AutoSize = true;
            this.lab_Player_NowLevel.BackColor = System.Drawing.Color.Transparent;
            this.lab_Player_NowLevel.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Player_NowLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_Player_NowLevel.Location = new System.Drawing.Point(46, 330);
            this.lab_Player_NowLevel.Name = "lab_Player_NowLevel";
            this.lab_Player_NowLevel.Size = new System.Drawing.Size(42, 13);
            this.lab_Player_NowLevel.TabIndex = 33;
            this.lab_Player_NowLevel.Text = "Lv 1：";
            this.lab_Player_NowLevel.TextChanged += new System.EventHandler(this.lab_Player_NowLevel_TextChanged);
            // 
            // lab_Player_NowMoney
            // 
            this.lab_Player_NowMoney.BackColor = System.Drawing.Color.Transparent;
            this.lab_Player_NowMoney.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Player_NowMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_Player_NowMoney.Location = new System.Drawing.Point(87, 300);
            this.lab_Player_NowMoney.Name = "lab_Player_NowMoney";
            this.lab_Player_NowMoney.Size = new System.Drawing.Size(102, 12);
            this.lab_Player_NowMoney.TabIndex = 32;
            this.lab_Player_NowMoney.Text = "0";
            this.lab_Player_NowMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_金錢
            // 
            this.lab_金錢.AutoSize = true;
            this.lab_金錢.BackColor = System.Drawing.Color.Transparent;
            this.lab_金錢.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_金錢.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_金錢.Location = new System.Drawing.Point(62, 300);
            this.lab_金錢.Name = "lab_金錢";
            this.lab_金錢.Size = new System.Drawing.Size(26, 13);
            this.lab_金錢.TabIndex = 31;
            this.lab_金錢.Text = "$：";
            // 
            // lab_Player_Speed
            // 
            this.lab_Player_Speed.BackColor = System.Drawing.Color.Transparent;
            this.lab_Player_Speed.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Player_Speed.ForeColor = System.Drawing.Color.Gold;
            this.lab_Player_Speed.Location = new System.Drawing.Point(91, 440);
            this.lab_Player_Speed.Name = "lab_Player_Speed";
            this.lab_Player_Speed.Size = new System.Drawing.Size(98, 32);
            this.lab_Player_Speed.TabIndex = 30;
            this.lab_Player_Speed.Text = "LEVEL 1";
            this.lab_Player_Speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_Combo
            // 
            this.lab_Combo.AutoSize = true;
            this.lab_Combo.BackColor = System.Drawing.Color.Transparent;
            this.lab_Combo.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Combo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_Combo.Location = new System.Drawing.Point(7, 361);
            this.lab_Combo.Name = "lab_Combo";
            this.lab_Combo.Size = new System.Drawing.Size(110, 35);
            this.lab_Combo.TabIndex = 6;
            this.lab_Combo.Text = "Combo";
            this.lab_Combo.Visible = false;
            // 
            // pBox_Player_Speed
            // 
            this.pBox_Player_Speed.BackColor = System.Drawing.Color.Transparent;
            this.pBox_Player_Speed.Image = global::BeeBeeBee.Properties.Resources.Pic_2;
            this.pBox_Player_Speed.Location = new System.Drawing.Point(46, 440);
            this.pBox_Player_Speed.Name = "pBox_Player_Speed";
            this.pBox_Player_Speed.Size = new System.Drawing.Size(32, 32);
            this.pBox_Player_Speed.TabIndex = 29;
            this.pBox_Player_Speed.TabStop = false;
            // 
            // pBox_Player_Defense
            // 
            this.pBox_Player_Defense.BackColor = System.Drawing.Color.Transparent;
            this.pBox_Player_Defense.Image = global::BeeBeeBee.Properties.Resources.Pic_6;
            this.pBox_Player_Defense.Location = new System.Drawing.Point(8, 402);
            this.pBox_Player_Defense.Name = "pBox_Player_Defense";
            this.pBox_Player_Defense.Size = new System.Drawing.Size(32, 32);
            this.pBox_Player_Defense.TabIndex = 28;
            this.pBox_Player_Defense.TabStop = false;
            this.pBox_Player_Defense.Visible = false;
            // 
            // pBox_Player_SuperBomb
            // 
            this.pBox_Player_SuperBomb.BackColor = System.Drawing.Color.Transparent;
            this.pBox_Player_SuperBomb.Image = ((System.Drawing.Image)(resources.GetObject("pBox_Player_SuperBomb.Image")));
            this.pBox_Player_SuperBomb.Location = new System.Drawing.Point(8, 440);
            this.pBox_Player_SuperBomb.Name = "pBox_Player_SuperBomb";
            this.pBox_Player_SuperBomb.Size = new System.Drawing.Size(32, 32);
            this.pBox_Player_SuperBomb.TabIndex = 27;
            this.pBox_Player_SuperBomb.TabStop = false;
            this.pBox_Player_SuperBomb.Visible = false;
            // 
            // pBox_Player_BigBull
            // 
            this.pBox_Player_BigBull.BackColor = System.Drawing.Color.Transparent;
            this.pBox_Player_BigBull.Image = global::BeeBeeBee.Properties.Resources.Pic_4;
            this.pBox_Player_BigBull.Location = new System.Drawing.Point(8, 478);
            this.pBox_Player_BigBull.Name = "pBox_Player_BigBull";
            this.pBox_Player_BigBull.Size = new System.Drawing.Size(32, 32);
            this.pBox_Player_BigBull.TabIndex = 26;
            this.pBox_Player_BigBull.TabStop = false;
            this.pBox_Player_BigBull.Visible = false;
            // 
            // lab_MaxCombo
            // 
            this.lab_MaxCombo.BackColor = System.Drawing.Color.Transparent;
            this.lab_MaxCombo.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_MaxCombo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_MaxCombo.Location = new System.Drawing.Point(87, 270);
            this.lab_MaxCombo.Name = "lab_MaxCombo";
            this.lab_MaxCombo.Size = new System.Drawing.Size(102, 12);
            this.lab_MaxCombo.TabIndex = 25;
            this.lab_MaxCombo.Text = "0";
            this.lab_MaxCombo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_最大連擊
            // 
            this.lab_最大連擊.AutoSize = true;
            this.lab_最大連擊.BackColor = System.Drawing.Color.Transparent;
            this.lab_最大連擊.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_最大連擊.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_最大連擊.Location = new System.Drawing.Point(10, 270);
            this.lab_最大連擊.Name = "lab_最大連擊";
            this.lab_最大連擊.Size = new System.Drawing.Size(78, 13);
            this.lab_最大連擊.TabIndex = 24;
            this.lab_最大連擊.Text = "MaxCmobo：";
            // 
            // lab_Player_PowerUp
            // 
            this.lab_Player_PowerUp.BackColor = System.Drawing.Color.Transparent;
            this.lab_Player_PowerUp.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Player_PowerUp.ForeColor = System.Drawing.Color.Gold;
            this.lab_Player_PowerUp.Location = new System.Drawing.Point(91, 402);
            this.lab_Player_PowerUp.Name = "lab_Player_PowerUp";
            this.lab_Player_PowerUp.Size = new System.Drawing.Size(98, 32);
            this.lab_Player_PowerUp.TabIndex = 23;
            this.lab_Player_PowerUp.Text = "LEVEL 1";
            this.lab_Player_PowerUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBox_Player_PowerUp
            // 
            this.pBox_Player_PowerUp.BackColor = System.Drawing.Color.Transparent;
            this.pBox_Player_PowerUp.Image = global::BeeBeeBee.Properties.Resources.Pic_3;
            this.pBox_Player_PowerUp.Location = new System.Drawing.Point(46, 402);
            this.pBox_Player_PowerUp.Name = "pBox_Player_PowerUp";
            this.pBox_Player_PowerUp.Size = new System.Drawing.Size(32, 32);
            this.pBox_Player_PowerUp.TabIndex = 22;
            this.pBox_Player_PowerUp.TabStop = false;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(150, 358);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(39, 38);
            this.axWindowsMediaPlayer1.TabIndex = 21;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // lab_Player_PowerCount
            // 
            this.lab_Player_PowerCount.BackColor = System.Drawing.Color.Transparent;
            this.lab_Player_PowerCount.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Player_PowerCount.Location = new System.Drawing.Point(91, 478);
            this.lab_Player_PowerCount.Name = "lab_Player_PowerCount";
            this.lab_Player_PowerCount.Size = new System.Drawing.Size(98, 32);
            this.lab_Player_PowerCount.TabIndex = 20;
            this.lab_Player_PowerCount.Text = "1 / 1";
            this.lab_Player_PowerCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBox_Player_PowerCount
            // 
            this.pBox_Player_PowerCount.BackColor = System.Drawing.Color.Transparent;
            this.pBox_Player_PowerCount.Image = global::BeeBeeBee.Properties.Resources.Pic_1;
            this.pBox_Player_PowerCount.Location = new System.Drawing.Point(46, 478);
            this.pBox_Player_PowerCount.Name = "pBox_Player_PowerCount";
            this.pBox_Player_PowerCount.Size = new System.Drawing.Size(32, 32);
            this.pBox_Player_PowerCount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox_Player_PowerCount.TabIndex = 19;
            this.pBox_Player_PowerCount.TabStop = false;
            // 
            // lab_Player_Life
            // 
            this.lab_Player_Life.BackColor = System.Drawing.Color.Transparent;
            this.lab_Player_Life.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Player_Life.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lab_Player_Life.Location = new System.Drawing.Point(91, 516);
            this.lab_Player_Life.Name = "lab_Player_Life";
            this.lab_Player_Life.Size = new System.Drawing.Size(98, 45);
            this.lab_Player_Life.TabIndex = 18;
            this.lab_Player_Life.Text = "X 3";
            this.lab_Player_Life.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBox_Player
            // 
            this.pBox_Player.BackColor = System.Drawing.Color.Transparent;
            this.pBox_Player.Image = global::BeeBeeBee.Properties.Resources.玩家;
            this.pBox_Player.Location = new System.Drawing.Point(13, 516);
            this.pBox_Player.Name = "pBox_Player";
            this.pBox_Player.Size = new System.Drawing.Size(60, 45);
            this.pBox_Player.TabIndex = 17;
            this.pBox_Player.TabStop = false;
            // 
            // lab_HitCalcu
            // 
            this.lab_HitCalcu.BackColor = System.Drawing.Color.Transparent;
            this.lab_HitCalcu.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_HitCalcu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_HitCalcu.Location = new System.Drawing.Point(87, 210);
            this.lab_HitCalcu.Name = "lab_HitCalcu";
            this.lab_HitCalcu.Size = new System.Drawing.Size(102, 12);
            this.lab_HitCalcu.TabIndex = 15;
            this.lab_HitCalcu.Text = "0";
            this.lab_HitCalcu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_Miss機率
            // 
            this.lab_Miss機率.AutoSize = true;
            this.lab_Miss機率.BackColor = System.Drawing.Color.Transparent;
            this.lab_Miss機率.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Miss機率.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_Miss機率.Location = new System.Drawing.Point(18, 210);
            this.lab_Miss機率.Name = "lab_Miss機率";
            this.lab_Miss機率.Size = new System.Drawing.Size(70, 13);
            this.lab_Miss機率.TabIndex = 14;
            this.lab_Miss機率.Text = "Hit   機率：";
            // 
            // lab_Player_DieCount
            // 
            this.lab_Player_DieCount.BackColor = System.Drawing.Color.Transparent;
            this.lab_Player_DieCount.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Player_DieCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_Player_DieCount.Location = new System.Drawing.Point(87, 180);
            this.lab_Player_DieCount.Name = "lab_Player_DieCount";
            this.lab_Player_DieCount.Size = new System.Drawing.Size(102, 12);
            this.lab_Player_DieCount.TabIndex = 13;
            this.lab_Player_DieCount.Text = "0";
            this.lab_Player_DieCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_死亡次數
            // 
            this.lab_死亡次數.AutoSize = true;
            this.lab_死亡次數.BackColor = System.Drawing.Color.Transparent;
            this.lab_死亡次數.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_死亡次數.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_死亡次數.Location = new System.Drawing.Point(16, 180);
            this.lab_死亡次數.Name = "lab_死亡次數";
            this.lab_死亡次數.Size = new System.Drawing.Size(72, 13);
            this.lab_死亡次數.TabIndex = 12;
            this.lab_死亡次數.Text = "死亡次數：";
            // 
            // lab_Miss_Bee
            // 
            this.lab_Miss_Bee.BackColor = System.Drawing.Color.Transparent;
            this.lab_Miss_Bee.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Miss_Bee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_Miss_Bee.Location = new System.Drawing.Point(87, 120);
            this.lab_Miss_Bee.Name = "lab_Miss_Bee";
            this.lab_Miss_Bee.Size = new System.Drawing.Size(102, 12);
            this.lab_Miss_Bee.TabIndex = 11;
            this.lab_Miss_Bee.Text = "0";
            this.lab_Miss_Bee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_Bee通過
            // 
            this.lab_Bee通過.AutoSize = true;
            this.lab_Bee通過.BackColor = System.Drawing.Color.Transparent;
            this.lab_Bee通過.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Bee通過.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_Bee通過.Location = new System.Drawing.Point(15, 120);
            this.lab_Bee通過.Name = "lab_Bee通過";
            this.lab_Bee通過.Size = new System.Drawing.Size(73, 13);
            this.lab_Bee通過.TabIndex = 10;
            this.lab_Bee通過.Text = "Bee   通過：";
            // 
            // lab_Miss_Bull
            // 
            this.lab_Miss_Bull.BackColor = System.Drawing.Color.Transparent;
            this.lab_Miss_Bull.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Miss_Bull.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_Miss_Bull.Location = new System.Drawing.Point(87, 150);
            this.lab_Miss_Bull.Name = "lab_Miss_Bull";
            this.lab_Miss_Bull.Size = new System.Drawing.Size(102, 12);
            this.lab_Miss_Bull.TabIndex = 9;
            this.lab_Miss_Bull.Text = "0";
            this.lab_Miss_Bull.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_未擊中
            // 
            this.lab_未擊中.AutoSize = true;
            this.lab_未擊中.BackColor = System.Drawing.Color.Transparent;
            this.lab_未擊中.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_未擊中.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_未擊中.Location = new System.Drawing.Point(17, 150);
            this.lab_未擊中.Name = "lab_未擊中";
            this.lab_未擊中.Size = new System.Drawing.Size(71, 13);
            this.lab_未擊中.TabIndex = 8;
            this.lab_未擊中.Text = "未  擊  中：";
            // 
            // lab_Player_ShootCount
            // 
            this.lab_Player_ShootCount.BackColor = System.Drawing.Color.Transparent;
            this.lab_Player_ShootCount.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Player_ShootCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_Player_ShootCount.Location = new System.Drawing.Point(87, 90);
            this.lab_Player_ShootCount.Name = "lab_Player_ShootCount";
            this.lab_Player_ShootCount.Size = new System.Drawing.Size(102, 12);
            this.lab_Player_ShootCount.TabIndex = 7;
            this.lab_Player_ShootCount.Text = "0";
            this.lab_Player_ShootCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_發射彈數
            // 
            this.lab_發射彈數.AutoSize = true;
            this.lab_發射彈數.BackColor = System.Drawing.Color.Transparent;
            this.lab_發射彈數.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_發射彈數.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_發射彈數.Location = new System.Drawing.Point(16, 90);
            this.lab_發射彈數.Name = "lab_發射彈數";
            this.lab_發射彈數.Size = new System.Drawing.Size(72, 13);
            this.lab_發射彈數.TabIndex = 6;
            this.lab_發射彈數.Text = "發射彈數：";
            // 
            // lab_UseTime
            // 
            this.lab_UseTime.BackColor = System.Drawing.Color.Transparent;
            this.lab_UseTime.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_UseTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_UseTime.Location = new System.Drawing.Point(87, 240);
            this.lab_UseTime.Name = "lab_UseTime";
            this.lab_UseTime.Size = new System.Drawing.Size(102, 12);
            this.lab_UseTime.TabIndex = 5;
            this.lab_UseTime.Text = "0";
            this.lab_UseTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_DieCount
            // 
            this.lab_DieCount.BackColor = System.Drawing.Color.Transparent;
            this.lab_DieCount.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_DieCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_DieCount.Location = new System.Drawing.Point(87, 60);
            this.lab_DieCount.Name = "lab_DieCount";
            this.lab_DieCount.Size = new System.Drawing.Size(102, 12);
            this.lab_DieCount.TabIndex = 4;
            this.lab_DieCount.Text = "0";
            this.lab_DieCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_Scores
            // 
            this.lab_Scores.BackColor = System.Drawing.Color.Transparent;
            this.lab_Scores.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Scores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_Scores.Location = new System.Drawing.Point(87, 30);
            this.lab_Scores.Name = "lab_Scores";
            this.lab_Scores.Size = new System.Drawing.Size(102, 12);
            this.lab_Scores.TabIndex = 3;
            this.lab_Scores.Text = "0";
            this.lab_Scores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab使用時間
            // 
            this.lab使用時間.AutoSize = true;
            this.lab使用時間.BackColor = System.Drawing.Color.Transparent;
            this.lab使用時間.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab使用時間.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab使用時間.Location = new System.Drawing.Point(16, 240);
            this.lab使用時間.Name = "lab使用時間";
            this.lab使用時間.Size = new System.Drawing.Size(72, 13);
            this.lab使用時間.TabIndex = 2;
            this.lab使用時間.Text = "使用時間：";
            // 
            // lab擊落總數
            // 
            this.lab擊落總數.AutoSize = true;
            this.lab擊落總數.BackColor = System.Drawing.Color.Transparent;
            this.lab擊落總數.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab擊落總數.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab擊落總數.Location = new System.Drawing.Point(16, 60);
            this.lab擊落總數.Name = "lab擊落總數";
            this.lab擊落總數.Size = new System.Drawing.Size(72, 13);
            this.lab擊落總數.TabIndex = 1;
            this.lab擊落總數.Text = "擊落總數：";
            // 
            // lab_得分
            // 
            this.lab_得分.AutoSize = true;
            this.lab_得分.BackColor = System.Drawing.Color.Transparent;
            this.lab_得分.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_得分.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lab_得分.Location = new System.Drawing.Point(16, 30);
            this.lab_得分.Name = "lab_得分";
            this.lab_得分.Size = new System.Drawing.Size(72, 13);
            this.lab_得分.TabIndex = 0;
            this.lab_得分.Text = "得　　分：";
            // 
            // timer_UseTime
            // 
            this.timer_UseTime.Enabled = true;
            this.timer_UseTime.Interval = 1;
            this.timer_UseTime.Tick += new System.EventHandler(this.timer_UseTime_Tick);
            // 
            // timer_StartTime
            // 
            this.timer_StartTime.Interval = 10;
            this.timer_StartTime.Tick += new System.EventHandler(this.timer_StartTime_Tick);
            // 
            // timer_Bee
            // 
            this.timer_Bee.Interval = 10;
            this.timer_Bee.Tick += new System.EventHandler(this.timer_Bee_Tick);
            // 
            // timer_Landscape
            // 
            this.timer_Landscape.Interval = 10;
            this.timer_Landscape.Tick += new System.EventHandler(this.timer_Landscape_Tick);
            // 
            // timer_Bull
            // 
            this.timer_Bull.Interval = 10;
            this.timer_Bull.Tick += new System.EventHandler(this.timer_Bull_Tick);
            // 
            // timer_Items
            // 
            this.timer_Items.Interval = 10;
            this.timer_Items.Tick += new System.EventHandler(this.timer_Items_Tick);
            // 
            // timer_Boom
            // 
            this.timer_Boom.Interval = 10;
            this.timer_Boom.Tick += new System.EventHandler(this.timer_Boom_Tick);
            // 
            // timer_EndTime
            // 
            this.timer_EndTime.Interval = 10;
            this.timer_EndTime.Tick += new System.EventHandler(this.timer_EndTime_Tick);
            // 
            // timer_BossBee
            // 
            this.timer_BossBee.Interval = 10;
            this.timer_BossBee.Tick += new System.EventHandler(this.timer_BossBee_Tick);
            // 
            // Form_Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(792, 567);
            this.ControlBox = false;
            this.Controls.Add(this.gBox_Data);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Play";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bee ~ 小蜜蜂";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Play_FormClosing);
            this.Load += new System.EventHandler(this.Form_Play_Load);
            this.Shown += new System.EventHandler(this.Form_Play_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Play_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_Play_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_Play_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_Play_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_Play_MouseUp);
            this.gBox_Data.ResumeLayout(false);
            this.gBox_Data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_Speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_Defense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_SuperBomb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_BigBull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_PowerUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player_PowerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_Player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer_Player_Move_Left;
        private System.Windows.Forms.Timer timer_Player_Move_Right;
        private System.Windows.Forms.GroupBox gBox_Data;
        private System.Windows.Forms.Label lab_UseTime;
        private System.Windows.Forms.Label lab_DieCount;
        private System.Windows.Forms.Label lab_Scores;
        private System.Windows.Forms.Label lab使用時間;
        private System.Windows.Forms.Label lab擊落總數;
        private System.Windows.Forms.Label lab_得分;
        private System.Windows.Forms.Label lab_Combo;
        private System.Windows.Forms.Label lab_Player_ShootCount;
        private System.Windows.Forms.Label lab_發射彈數;
        private System.Windows.Forms.Label lab_Miss_Bee;
        private System.Windows.Forms.Label lab_Bee通過;
        private System.Windows.Forms.Label lab_Miss_Bull;
        private System.Windows.Forms.Label lab_未擊中;
        private System.Windows.Forms.Label lab_Player_DieCount;
        private System.Windows.Forms.Label lab_死亡次數;
        private System.Windows.Forms.Label lab_HitCalcu;
        private System.Windows.Forms.Label lab_Miss機率;
        private System.Windows.Forms.Timer timer_UseTime;
        private System.Windows.Forms.Label lab_Player_Life;
        private System.Windows.Forms.PictureBox pBox_Player;
        private System.Windows.Forms.PictureBox pBox_Player_PowerCount;
        private System.Windows.Forms.Label lab_Player_PowerCount;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Label lab_Player_PowerUp;
        private System.Windows.Forms.PictureBox pBox_Player_PowerUp;
        private System.Windows.Forms.Label lab_MaxCombo;
        private System.Windows.Forms.Label lab_最大連擊;
        private System.Windows.Forms.PictureBox pBox_Player_Defense;
        private System.Windows.Forms.PictureBox pBox_Player_SuperBomb;
        private System.Windows.Forms.PictureBox pBox_Player_BigBull;
        private System.Windows.Forms.Label lab_Player_Speed;
        private System.Windows.Forms.PictureBox pBox_Player_Speed;
        private System.Windows.Forms.Label lab_Player_NowMoney;
        private System.Windows.Forms.Label lab_金錢;
        private System.Windows.Forms.Timer timer_StartTime;
        private System.Windows.Forms.Label lab_Player_NowExp;
        private System.Windows.Forms.Label lab_Player_NowLevel;
        private System.Windows.Forms.Timer timer_Bee;
        private System.Windows.Forms.Timer timer_Landscape;
        private System.Windows.Forms.Timer timer_Bull;
        private System.Windows.Forms.Timer timer_Items;
        private System.Windows.Forms.Timer timer_Boom;
        private System.Windows.Forms.Timer timer_EndTime;
        private System.Windows.Forms.Timer timer_BossBee;
    }
}