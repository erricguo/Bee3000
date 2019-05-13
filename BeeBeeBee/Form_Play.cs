using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.Runtime.InteropServices;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectSound;
using System.Threading;
using QuartzTypeLib;

namespace BeeBeeBee
{
    public partial class Form_Play : Form
    {
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        public Microsoft.DirectX.Direct3D.Device gd = null;
        // 建立声音设备
        Microsoft.DirectX.DirectSound.Device dev = new Microsoft.DirectX.DirectSound.Device();
        Microsoft.DirectX.DirectSound.SecondaryBuffer sndBee_Boom = null;
        Microsoft.DirectX.DirectSound.SecondaryBuffer sndBackGround = null;

        private const int frameCount = 7;//定义动画帧数目
        private int currentFrame = 0;//定义当前动画帧
        private System.Windows.Forms.Timer aniTimer;//定义计时器

        private System.Drawing.Font currentFont;//定义字体
        private System.Drawing.Font currentFont2;//定义字体        
        private Microsoft.DirectX.Direct3D.Font myFont;//定义文字对象
        private Microsoft.DirectX.Direct3D.Font myFont2;//定义文字对象

        // 主體運算時間
        const int r_timeDelta = (int)(1000 / 75);              // 頻率是每秒大約多少次
        static int r_lastTime = System.Environment.TickCount + r_timeDelta;  // 「上次主體運算時間」

        // 繪圖時間
        const int m_timeDelta = (int)(1000 / 75);                    // 頻率是每秒大約多少張
        static int lastTime = System.Environment.TickCount + m_timeDelta;  // 「上次繪圖時間」

        // FPS時間(每秒即1000)
        const int gm_timeDelta = 1000;
        static int glastTime = System.Environment.TickCount + gm_timeDelta; //「上次FPS時間」

        static int countFPS = 0; //計算FPS
        static int nowFPS = 0; //目前FPS
        bool IsPause = false;
        bool RunEnd = false;
        bool IsGameStart = false;
        bool RunBossBee = false;
        bool BullLV1 = false;
        bool BullLV2 = false;
        bool BullLV3 = false;
        bool BullLV4 = false;
        bool BullLV5 = false;
        bool BullLV6 = false;
        bool BullLink = false;

        public enum status { game_start,game_over };//可能狀態 活動或死亡
        public status game_Status;//目前狀態

        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[ 宣告 ]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        List<ClassLandscape> LandscapeList = new List<ClassLandscape>();
        List<ClassPlayerBull> PlayerBullList = new List<ClassPlayerBull>();
        List<ClassBeeBull> BeeBullList = new List<ClassBeeBull>();
        List<ClassSuperBoom> SuperBoomList = new List<ClassSuperBoom>();
        List<ClassBee> BeeList = new List<ClassBee>();
        List<ClassBoom> BoomList = new List<ClassBoom>();
        List<ClassItems> ItemsList = new List<ClassItems>();
        List<ClassBossBeeBull> BossBeeBullList = new List<ClassBossBeeBull>();        
        ClassPlayer P1 = new ClassPlayer();
        ClassBossBee Boss1 = new ClassBossBee();
        //--------BitMap 載入---------------------------------------------------------------------------------
        List<Bitmap> BmpPlayerList = new List<Bitmap>();
        List<Bitmap> BmpPlayerDefenseList_Left = new List<Bitmap>();
        List<Bitmap> BmpPlayerDefenseList_Right = new List<Bitmap>();
        List<Bitmap> BmpPlayerBullList = new List<Bitmap>();
        List<Bitmap> BmpPlayerBullLinkBombList = new List<Bitmap>();
        List<Bitmap> BmpBossBeeList = new List<Bitmap>();
        List<Bitmap> BmpBossHitList = new List<Bitmap>();
        List<Bitmap> BmpBeeList = new List<Bitmap>();
        List<Bitmap> BmpBeeBullList = new List<Bitmap>();
        List<Bitmap> BmpBoomList = new List<Bitmap>();
        List<Bitmap> BmpSuperBoomList = new List<Bitmap>();
        List<Bitmap> BmpLinkBoomList = new List<Bitmap>();
        List<Bitmap> BmpItemsList = new List<Bitmap>();
        List<Bitmap> BmpBossBeeBullList = new List<Bitmap>();
        Brush[] BshGameOver = new Brush[] { Brushes.White, Brushes.Yellow, Brushes.SandyBrown, Brushes.Orange, Brushes.Tomato, Brushes.OrangeRed, Brushes .Red };
        Color[] CLGameOver = new Color[] { Color.White, Color.Yellow, Color.SandyBrown, Color.Orange, Color.Tomato, Color.OrangeRed, Color.Red };
        int BshGameOver_Index = 0;
        int BshGameOver_Y = 0;
        Brush[] BshStartGame = new Brush[] { Brushes.AliceBlue,Brushes.Black};
        Color[] CLS = new Color[] { Color.AliceBlue, Color.Black };
        string[] BshStartGame_str = new string[] {"S","T","A","R","T" };
        int BshStartGame_Index = 0;
        int[] BshStartGame_X_2 = new int[] {70,170,270,370,470 };
        //--------BitMap 載入---------------------------------------------------------------------------------
        Random Rd = new Random();
        int StartTime = 0;//開始時間間隔，等待EEE出現
        int EndTime = 0;//結束時間間隔，結束畫面
        double Bee_Add_Random = 0.04;//Bee產生機率
        int TotalScores = 0;//總得分
        double DieCount = 0;//總擊落數
        int BeeCount_Stage_1 = 500;
        double BeeCount_Up = 0;
        int Miss_Bee = 0;//Bee通過數量
        int Miss_Bull = 0;//未擊中Bee數量
        int PlayerDieCount = 0;//玩家死亡次數
        double HitCalcu = 0;//命中率計算
        bool SoundOn = true;//聲音開啟
        int t = 0;//計時器
        int PlayerDie_ResetTIme =120;//玩家爆炸無敵時間



        //SoundPlayer sound_Bee_Die = new SoundPlayer(Properties.Resources.Bee_Boom);
        SecondaryBuffer sound_Bee_Die = null;
        //SoundPlayer sound_BossBee_hit = new SoundPlayer(Properties.Resources.hit);
        SecondaryBuffer sound_BossBee_hit = null;
        //SoundPlayer soune_Player_Die = new SoundPlayer(Properties.Resources.Player_Die);
        Computer myComputer = new Computer();//撥放音效
          //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[ 宣告 ]^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        public Form_Play()
        {
            InitializeComponent();
            //InitializeDirect3D();

            game_Status = status.game_start;

        }
        public void SetDevice()
        {
            //device = gDevice.GetInstance();
        }
        public bool InitializeDirect3D()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                presentParams.Windowed = true; //指定以Windows窗体形式显示
                presentParams.SwapEffect = SwapEffect.Copy; //当前屏幕绘制后它将自动从内存中删除
                gd = new Microsoft.DirectX.Direct3D.Device(0, DeviceType.Hardware, this, CreateFlags.HardwareVertexProcessing, presentParams); //实例化device对象

                var task = new Thread(() =>
                {
                    InitailizeImages();
                });
                task.Start();

                
                

                dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
                sndBee_Boom = new SecondaryBuffer(Properties.Resources.Bee_Boom, dev);
                sound_Bee_Die = new SecondaryBuffer(Properties.Resources.Bee_Boom, dev);
                sound_BossBee_hit = new SecondaryBuffer(Properties.Resources.hit, dev);
                //string s = Directory.GetCurrentDirectory() + "\\BackGround.wav";
                string s = Directory.GetCurrentDirectory() + "\\BackGround.mp3";
                InitSound();
                //sndBackGround = new Microsoft.DirectX.DirectSound.SecondaryBuffer(s, dev);
                //sndBackGround.Volume = -700;//音量为0表示最大的音量，因此设置时必须为负。
                if (SoundOn) BGSound(true);
                //sprite = new Sprite(device);//实例化Sprite对象
               // string imagePath = @"G:\cocos2d-2.0-x-2.0.3\FLIGHTDEMO\Resources\map.png";
                //showPicture = TextureLoader.FromFile(device, imagePath);
                currentFont = new System.Drawing.Font("Times New Roman", 16, FontStyle.Regular);//设置字体
                myFont = new Microsoft.DirectX.Direct3D.Font(gd, currentFont);//创建文字对象
                currentFont2 = new System.Drawing.Font("微軟正黑體", 60, FontStyle.Regular);//设置字体
                myFont2 = new Microsoft.DirectX.Direct3D.Font(gd, currentFont2);//创建文字对象
                return true;
            }
            catch (DirectXException e)
            {
                MessageBox.Show(e.ToString(), "Error"); //处理异常
                return false;
            }
        }

        private FilgraphManager m_objFilterGraph = null;
        private IBasicAudio m_objBasicAudio = null;
        private IVideoWindow m_objVideoWindow = null;
        private IMediaEvent m_objMediaEvent = null;
        private IMediaEventEx m_objMediaEventEx = null;
        private IMediaPosition m_objMediaPosition = null;
        private IMediaControl m_objMediaControl = null;
        enum MediaStatus { None, Stopped, Paused, Running };
        private MediaStatus m_CurrentStatus = MediaStatus.None;
        private void CleanUp()
        {
            if (m_objMediaControl != null)
                m_objMediaControl.Stop();

            m_CurrentStatus = MediaStatus.Stopped;

            if (m_objMediaEventEx != null)
                m_objMediaEventEx.SetNotifyWindow(0, 0, 0);

            if (m_objVideoWindow != null)
            {
                m_objVideoWindow.Visible = 0;
                m_objVideoWindow.Owner = 0;
            }

            if (m_objMediaControl != null) m_objMediaControl = null;
            if (m_objMediaPosition != null) m_objMediaPosition = null;
            if (m_objMediaEventEx != null) m_objMediaEventEx = null;
            if (m_objMediaEvent != null) m_objMediaEvent = null;
            if (m_objVideoWindow != null) m_objVideoWindow = null;
            if (m_objBasicAudio != null) m_objBasicAudio = null;
            if (m_objFilterGraph != null) m_objFilterGraph = null;
        }
        public void InitSound()
        {
            CleanUp();

            m_objFilterGraph = new FilgraphManager();
            m_objFilterGraph.RenderFile(Directory.GetCurrentDirectory() + "\\BackGround.mp3");

            m_objBasicAudio = m_objFilterGraph as IBasicAudio;

            /*try
            {
                m_objVideoWindow = m_objFilterGraph as IVideoWindow;
                m_objVideoWindow.Owner = (int)panel1.Handle;
                m_objVideoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;
                m_objVideoWindow.SetWindowPosition(panel1.ClientRectangle.Left,
                    panel1.ClientRectangle.Top,
                    panel1.ClientRectangle.Width,
                    panel1.ClientRectangle.Height);
            }
            catch (Exception ex)
            {
                m_objVideoWindow = null;
            }*/

            m_objMediaEvent = m_objFilterGraph as IMediaEvent;

            //m_objMediaEventEx = m_objFilterGraph as IMediaEventEx;
            //m_objMediaEventEx.SetNotifyWindow((int)this.Handle, WM_GRAPHNOTIFY, 0);

            m_objMediaPosition = m_objFilterGraph as IMediaPosition;

            m_objMediaControl = m_objFilterGraph as IMediaControl;
        }

        public void UpdateFPS(int xfps)
        {
            nowFPS = xfps;
        }
        public void Run()
        {
            if (!IsPause)
            {
                if (P1.IsMoveLeft)
                {
                    P1._X -= (int)P1._Player_Speed;
                    if (P1._X <= 0) P1._X = 0;
                }
                else if (P1.IsMoveRight)
                {
                    P1._X += (int)P1._Player_Speed;
                    if (P1._X >= 560) P1._X = 560;
                }
                //P1._PLayer_Invincible = true;
                Run_Bee();
                if (RunBossBee)
                {
                    Run_BossBee();
                    Run_BossBeeBull();
                }
                Run_Bull();
                Run_Items();
                Run_Boom();
                Run_Time1();
                Run_UseTime();
                if (RunEnd)
                    Run_End();
            }
        }

        public void Render()
        {
            if (gd == null || game_Status == status.game_over)   //如果device为空则不渲染
            {
                return;
            }

            if (StartTime < 450) StartTime++;

            gd.Clear(ClearFlags.Target, Color.Black, 1.0f, 0);  //清除windows界面为深蓝色
            gd.BeginScene();

            //玩家移動
            if (!P1._GameOver)
                P1.Draw(gd, s_Player, s_PlayerDefenseList_L, s_PlayerDefenseList_R, TexPlayerList, TexPlayerDefenseList, P1._PLayer_Invincible);

            //Bee 繪出
            foreach (ClassBee E in BeeList)
            {
                E.Draw(gd, s_BeeList, TexBeeList);
            }
            //畫出Player子彈
            foreach (ClassPlayerBull B in PlayerBullList)
            {
                B.Draw(gd, s_PlayerBullList, TexPlayerBullList, TexPlayerBullLinkbombList);
            }
            //畫出Bee子彈
            foreach (ClassBeeBull BB in BeeBullList)
            {
                BB.Draw(gd, s_BeeBullList, TexBeeBullList);
            }
            //Boom
            foreach (ClassBoom M in BoomList)
            {
                M.Draw(gd, s_BoomList, TexBoomList, TexBoomList_Player, TexBoomList_BossBee);
            }
            //SuperBoom
            foreach (ClassSuperBoom SB in SuperBoomList)
            {
                SB.Draw(gd, s_SuperBoomList, TexSuperBoomList, TexLinkBoomList);
            }
            //Items
            foreach (ClassItems I in ItemsList)
            {
                I.Draw(gd, s_ItemsList, TexItemsList);
            }
            if (BeeCount_Stage_1 == 0 && Boss1._BossBee_Life > 0)
            {
                Boss1.Draw(gd, s_BossBeeList, TexBossBeeList, TexBossHitList);
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 18, FontStyle.Bold))
                {
                    myFont.DrawText(null, "BossLife " + Boss1._BossBee_Life.ToString(), new Point(20, 220), Color.LightBlue);
                }
                //畫出Bee子彈
                foreach (ClassBossBeeBull BB in BossBeeBullList)
                {
                    BB.Draw(gd, s_BossBeeBullList, TexBossBeeBullList);
                }
            }


            //遊戲開始畫面
            if (!P1._GameOver && StartTime > 50 && StartTime <= 450)
            {
                BshStartGame_Index %= BshStartGame.Length;

                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 60, FontStyle.Bold))
                {
                    if (StartTime < 60)
                    {
                        //  if (BshStartGame_X < BshStartGame_X_2[0]) BshStartGame_X++;
                        myFont2.DrawText(null, BshStartGame_str[0], new Point(BshStartGame_X_2[0], 250), Color.AliceBlue);
                    }
                    else if (StartTime >= 60 && StartTime < 70)
                    {
                        // if (BshStartGame_X < BshStartGame_X_2[0]) BshStartGame_X++;
                        myFont2.DrawText(null, BshStartGame_str[0], new Point(BshStartGame_X_2[0], 250), Color.AliceBlue);
                        myFont2.DrawText(null, BshStartGame_str[1], new Point(BshStartGame_X_2[1], 250), Color.AliceBlue);
                    }
                    else if (StartTime >= 70 && StartTime < 80)
                    {
                        myFont2.DrawText(null, BshStartGame_str[0], new Point(BshStartGame_X_2[0], 250), Color.AliceBlue);
                        myFont2.DrawText(null, BshStartGame_str[1], new Point(BshStartGame_X_2[1], 250), Color.AliceBlue);
                        myFont2.DrawText(null, BshStartGame_str[2], new Point(BshStartGame_X_2[2], 250), Color.AliceBlue);
                    }
                    else if (StartTime >= 80 && StartTime < 90)
                    {
                        myFont2.DrawText(null, BshStartGame_str[0], new Point(BshStartGame_X_2[0], 250), Color.AliceBlue);
                        myFont2.DrawText(null, BshStartGame_str[1], new Point(BshStartGame_X_2[1], 250), Color.AliceBlue);
                        myFont2.DrawText(null, BshStartGame_str[2], new Point(BshStartGame_X_2[2], 250), Color.AliceBlue);
                        myFont2.DrawText(null, BshStartGame_str[3], new Point(BshStartGame_X_2[3], 250), Color.AliceBlue);
                    }
                    else if (StartTime >= 90 && StartTime < 100)
                    {
                        myFont2.DrawText(null, BshStartGame_str[0], new Point(BshStartGame_X_2[0], 250), Color.AliceBlue);
                        myFont2.DrawText(null, BshStartGame_str[1], new Point(BshStartGame_X_2[1], 250), Color.AliceBlue);
                        myFont2.DrawText(null, BshStartGame_str[2], new Point(BshStartGame_X_2[2], 250), Color.AliceBlue);
                        myFont2.DrawText(null, BshStartGame_str[3], new Point(BshStartGame_X_2[3], 250), Color.AliceBlue);
                        myFont2.DrawText(null, BshStartGame_str[4], new Point(BshStartGame_X_2[4], 250), Color.AliceBlue);
                    }
                    else if (StartTime >= 100 && StartTime < 350)
                    {
                        myFont2.DrawText(null, BshStartGame_str[0], new Point(BshStartGame_X_2[0], 250), CLS[BshStartGame_Index]);
                        myFont2.DrawText(null, BshStartGame_str[1], new Point(BshStartGame_X_2[1], 250), CLS[BshStartGame_Index]);
                        myFont2.DrawText(null, BshStartGame_str[2], new Point(BshStartGame_X_2[2], 250), CLS[BshStartGame_Index]);
                        myFont2.DrawText(null, BshStartGame_str[3], new Point(BshStartGame_X_2[3], 250), CLS[BshStartGame_Index]);
                        myFont2.DrawText(null, BshStartGame_str[4], new Point(BshStartGame_X_2[4], 250), CLS[BshStartGame_Index]);
                    }
                    else if (StartTime >= 450)
                    {
                        IsGameStart = true;
                    }
                    if (StartTime == 140) BshStartGame_Index++;
                    else if (StartTime == 180) BshStartGame_Index++;
                    else if (StartTime == 220) BshStartGame_Index++;
                    else if (StartTime == 260) BshStartGame_Index++;
                }
            }
            if (P1._GameOver && EndTime > 150)
            {
                if (BshGameOver_Y < 250) BshGameOver_Y++;
                BshGameOver_Index %= BshGameOver.Length;
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 60, FontStyle.Bold))
                {
                   // e.Graphics.DrawString(" GAME OVER ", font, BshGameOver[BshGameOver_Index++], new Point(20, BshGameOver_Y));
                    myFont2.DrawText(null, " GAME OVER ", new Point(40, BshGameOver_Y), CLGameOver[BshGameOver_Index++]);
                }
            }
            else if (!P1._GameOver && EndTime > 150)
            {
                if (BshGameOver_Y < 250) BshGameOver_Y++;
                BshGameOver_Index %= BshGameOver.Length;
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 60, FontStyle.Bold))
                {
                   // e.Graphics.DrawString(" COMPLETE!! ", font, BshStartGame[0], new Point(20, BshGameOver_Y));
                    myFont2.DrawText(null, " COMPLETE!! ", new Point(40, BshGameOver_Y), Color.White);
                }
            }

            myFont.DrawText(null, string.Format("FPS:{0:0}", nowFPS), new Point(10, 430), Color.Red);
            myFont.DrawText(null, "Lv " + P1._Player_NowLevel.ToString() + '\n' + "剩餘：" + (BeeCount_Stage_1).ToString(), new Point(20, 150), Color.LightBlue);

            gd.EndScene();
            gd.Present();
            
        }
        private void Form_Play_Load(object sender, EventArgs e)
        {
            
            //string s = Directory.GetCurrentDirectory() + "\\BackGround.mp3";
            Update_PlayerInfo();
            /*axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.settings.autoStart = false;
            axWindowsMediaPlayer1.settings.volume = 30;
            axWindowsMediaPlayer1.URL = s;*/
            timer1.Enabled = false;
            timer_UseTime.Enabled = false;
            timer_Bee.Enabled = false;
            timer_Bull.Enabled = false;
            timer_Landscape.Enabled = false;
            timer_Boom.Enabled=false;
            timer_Items.Enabled = false;
            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Play_Paint);

            Form_GameTips f3 = new Form_GameTips();
          //  f3.DesktopLocation = new Point(this.Left, this.Top);
            if (f3.ShowDialog() == DialogResult.OK)
            {
                //if (SoundOn) BGSound(true);
                    //axWindowsMediaPlayer1.Ctlcontrols.play();
               /* timer_Bee.Enabled = true;
                timer_Bull.Enabled = true;
                timer_Landscape.Enabled = true;
                timer_Boom.Enabled = true;
                timer_Items.Enabled = true;

                timer_UseTime.Enabled = true;
                timer1.Enabled = true;
                timer_StartTime.Enabled = true;*/
            }

        }
        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[ Keyboard_Control ]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        // 按鍵A : 玩家左移   按鍵D:玩家右移  ESC:遊戲暫停/遊戲選單 J:1發子彈  K:3發子彈 L:5發子彈
        private void Form_Play_KeyDown(object sender, KeyEventArgs e)
        {
            if (!P1._GameOver)
            {
                if (e.KeyCode == Keys.A)
                {/*
                    if (PlayerDie_ResetTIme == 0 || PlayerDie_ResetTIme > 110)
                        timer_Player_Move_Left.Enabled = true;*/
                    P1.IsMoveLeft = true;

                }
                else if (e.KeyCode == Keys.D)
                {
                    /*if (PlayerDie_ResetTIme == 0 || PlayerDie_ResetTIme > 110)
                        timer_Player_Move_Right.Enabled = true;*/

                    P1.IsMoveRight = true;
                }

                if (e.KeyCode == Keys.I)
                {
                    if (!IsPause)
                    {
                        IsPause = true;
                       /* timer_UseTime.Enabled = false;
                        timer1.Enabled = false;

                        timer_Bee.Enabled = false;
                        timer_Bull.Enabled = false;
                        timer_Landscape.Enabled = false;
                        timer_Boom.Enabled = false;
                        timer_Items.Enabled = false;
                        timer_StartTime.Enabled = false;

                        timer_Player_Move_Left.Enabled = false;
                        timer_Player_Move_Right.Enabled = false;*/
                        if (SoundOn) BGSound(false);

                        Form_Select fs = new Form_Select();
                        fs.ShowDialog();
                        if (fs.Rs == DialogResult.OK)
                        {
                            Form_Main.Fm.btnShow = true;
                            this.ParentForm.Show();
                            this.Visible = false;
                            this.Dispose();
                        }

                    }
                    else if (IsPause)
                    {
                        IsPause = false;
                        if (SoundOn) BGSound(true);

                       /* timer_Bee.Enabled = true ;
                        timer_Bull.Enabled = true ;
                        timer_Landscape.Enabled = true ;
                        timer_Boom.Enabled = true ;
                        timer_Items.Enabled = true ;
                        timer_StartTime.Enabled = true ;

                        timer_UseTime.Enabled = true;
                        timer1.Enabled = true;*/
                    }
                }

                //一發子彈
                if (e.KeyCode == Keys.J)
                {
                    CheckPowerUp();
                    return;

                    if (PlayerDie_ResetTIme > 0 && PlayerDie_ResetTIme < 110) return;

                    if (P1._Player_PowerUp == 1)
                    {
                        if (P1._Player_PowerCount - PlayerBullList.Count > 0)
                        {
                            Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                        }
                    }
                    else if (P1._Player_PowerUp == 2)
                    {
                        if (P1._Player_PowerCount - PlayerBullList.Count > 1)
                        {
                            Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 30, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 30, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                        }
                    }
                    else if (P1._Player_PowerUp == 3)
                    {
                        if (P1._Player_PowerCount - PlayerBullList.Count > 2)
                        {
                            Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 30, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 30, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                        }
                    }
                 }

                //三發子彈
                if (e.KeyCode == Keys.K)
                {
                    return;
                    if (PlayerDie_ResetTIme > 0 && PlayerDie_ResetTIme < 110) return;
                    if (P1._Player_PowerUp >= 2)
                    {
                        if (P1._Player_PowerCount - PlayerBullList.Count > 2)
                        {
                            BullLV2 = true;
                            return;
                            Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 350, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 350, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                        }
                    }
                }

                //五發子彈
                if (e.KeyCode == Keys.L)
                {
                    return;
                    if (PlayerDie_ResetTIme > 0 && PlayerDie_ResetTIme < 110) return;
                    if (P1._Player_PowerUp == 3)
                    {
                        if (P1._Player_PowerCount - PlayerBullList.Count > 4)
                        {
                            BullLV3 = true;
                            return;
                            Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            Create_PlayerBull(P1._X + P1._Width / 2 - 60, (P1._X + P1._Width / 2) - 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            Create_PlayerBull(P1._X + P1._Width / 2 + 60, (P1._X + P1._Width / 2) + 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                        }
                    }
                }
                //SuperBomb
                if (e.KeyCode == Keys.Space)
                {
                    if (P1._Player_SuperBomb)
                    {
                        Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, false, ClassPlayerBull.status_BullType.SuperBomb, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                        P1._Player_SuperBomb = false ;
                        Update_PlayerInfo(); 
                    }
                }
                //LinkBomb
                if (e.KeyCode == Keys.N)
                {
                    if (PlayerDie_ResetTIme > 0 && PlayerDie_ResetTIme < 110) return;
                    if (P1._Player_SuperType)
                    {
                        BullLink = true;
                        return;
                        Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, false, ClassPlayerBull.status_BullType.LinkBomb, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                    }

                }
                //Defense
                if (e.KeyCode == Keys.H)
                {
                    if (P1._Player_Defense)
                    {
                        P1._Player_Defense_Life = 10;
                        P1._Player_Defense = false;
                        Update_PlayerInfo();
                    }
                }
                if (e.KeyCode == Keys.F2)
                {
                   P1._Player_SuperBomb = true;
                   P1._Player_Defense = true;
                   P1._Player_BigBull = true;
                   P1._Player_SuperType = true;
                   P1._Player_NowLevel = 6;
                   P1.Check_Player_Level(P1._Player_NowLevel);
                   Update_PlayerInfo();
                }
                if (e.KeyCode == Keys.F3)
                {
                    if (SoundOn)
                    {
                        SoundOn = false;
                        BGSound(false);
                    }
                    else
                    {
                        SoundOn = true;
                        BGSound(true);
                    }
                }
                //購買選單
                if (e.KeyCode == Keys.U)
                {

                    if (!IsPause)
                    {
                        IsPause = true;
                        /*timer_Bee.Enabled = false;
                        timer_Bull.Enabled = false;
                        timer_Landscape.Enabled = false;
                        timer_Boom.Enabled = false;
                        timer_Items.Enabled = false;
                        timer_StartTime.Enabled = false;

                        timer_UseTime.Enabled = false;
                        timer1.Enabled = false;
                        timer_Player_Move_Left.Enabled = false;
                        timer_Player_Move_Right.Enabled = false;*/
                        if (SoundOn) BGSound(false );

                        Form_Store Fs = new Form_Store();
                        Fs.MainForm = this;
                        Fs._Player_PowerCount = P1._Player_PowerCount;
                        Fs._Player_PowerCount_Limit = P1._Player_PowerCount_Limit;
                        Fs._Player_Speed = P1._Player_Speed-2;
                        Fs._Player_PowerUp =P1._Player_PowerUp;
                        if (P1._Player_BigBull ) Fs._Player_BigBull = true;
                        else Fs._Player_BigBull = false ;
                        if (P1._Player_SuperBomb ) Fs._Player_SuperBomb = true;
                        else Fs._Player_SuperBomb = false ;
                        if (P1._Player_Defense ) Fs._Player_Defense = true;
                        else Fs._Player_Defense = false ;
                        if (P1._Player_SuperType) Fs._Player_SuperType = true;
                        else Fs._Player_SuperType = false ;
                        Fs._PlayerExp = P1._Player_NowExp ;
                        Fs._PlayerMoney =P1._PLayer_NowMoney ;
                        Fs._PlayerLevel = P1._Player_NowLevel;
                        Fs.ShowDialog();
                        if ( Fs.Result == DialogResult.OK)
                        {
                            if (SoundOn) BGSound(true);
                           /* timer_Bee.Enabled = true;
                            timer_Bull.Enabled = true;
                            timer_Landscape.Enabled = true;
                            timer_Boom.Enabled = true;
                            timer_Items.Enabled = true;
                            timer_StartTime.Enabled = true ;

                            timer_UseTime.Enabled = true;
                            timer1.Enabled = true;*/
                            IsPause = false;

                            P1._Player_PowerCount = Fs._Player_PowerCount;
                            P1._Player_Speed =Fs._Player_Speed+2;
                            P1._Player_PowerUp =Fs._Player_PowerUp;
                            if (Fs._Player_BigBull) P1._Player_BigBull = true;
                            else pBox_Player_BigBull.Visible = false;
                            if (Fs._Player_SuperBomb) P1._Player_SuperBomb  = true;
                            else pBox_Player_SuperBomb.Visible = false;
                            if (Fs._Player_Defense ) P1._Player_Defense  = true;
                            else pBox_Player_Defense.Visible = false;
                            if (Fs._Player_SuperType) P1._Player_SuperType = true;
                            else P1._Player_SuperType = false;
                            P1._Player_NowExp = Fs._PlayerExp;
                            P1._PLayer_NowMoney = Fs._PlayerMoney;
                            P1._Player_NowLevel = Fs._PlayerLevel;
                            Update_PlayerInfo();
                        }
                    }
                }
            }
        }

        private void CheckPowerUp()
        {
            if (P1._Player_PowerUp >= 6)
            {
                BullLV6 = true;
                BullLV5 = false;
                BullLV4 = false;
                BullLV3 = false;
                BullLV2 = false;
                BullLV1 = false;
            }
            else if (P1._Player_PowerUp >= 5)
            {
                BullLV5 = true;
                BullLV4 = false;
                BullLV3 = false;
                BullLV2 = false;
                BullLV1 = false;
            }
            else if (P1._Player_PowerUp >= 4)
            {
                BullLV4 = true;
                BullLV3 = false;
                BullLV2 = false;
                BullLV1 = false;
            }
            else if (P1._Player_PowerUp >= 3)
            {
                BullLV3 = true;
                BullLV2 = false;
                BullLV1 = false;
            }
            else if (P1._Player_PowerUp >= 2)
            {
                BullLV2 = true;
                BullLV1 = false;
            }
            else if (P1._Player_PowerUp >= 1)
            {
                BullLV1 = true;
            }
        }

        //按鍵彈起時 A:停止左移 D:停止右移
        private void Form_Play_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                //timer_Player_Move_Left.Enabled = false;
                P1.IsMoveLeft = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                P1.IsMoveRight = false;
                //timer_Player_Move_Right.Enabled = false;
            }
            else if (e.KeyCode == Keys.J)
            {
                BullLV1 = false;
                BullLV2 = false;
                BullLV3 = false;
                BullLV4 = false;
                BullLV5 = false;
                BullLV6 = false;
                //timer_Player_Move_Runight.Enabled = false;
            }
            else if (e.KeyCode == Keys.K)
            {
                //BullLV2 = false;
                //timer_Player_Move_Right.Enabled = false;
            }
            else if (e.KeyCode == Keys.L)
            {
                //BullLV3 = false;
                //timer_Player_Move_Right.Enabled = false;
            }
            else if (e.KeyCode == Keys.N)
            {
                BullLink = false;
                //timer_Player_Move_Right.Enabled = false;
            }
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[ Keyboard_Control ]^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        //重繪事件
        int yy = 0;
        private void Form_Play_Paint(object sender, PaintEventArgs e)
        {


            //Properties.Resources.玩家

            //e.Graphics.DrawImage(Properties.Resources.map, 0, yy, Properties.Resources.map.Width, Properties.Resources.map.Height);

            /*using (System.Drawing.Font font = new System.Drawing.Font("Arial", 18, FontStyle.Bold))
            {
                e.Graphics.DrawString("Lv " + P1._Player_NowLevel.ToString() + '\n' + "剩餘：" + (BeeCount_Stage_1).ToString(), font, Brushes.LightBlue, new Point(20, 150));
            }*/

            //玩家移動
          /*  if (!P1._GameOver )
            P1.Draw(e.Graphics,P1._PLayer_Invincible);*/
            //畫出光點
           /* foreach (ClassLandscape L in LandscapeList)
            {
                L.Draw(e.Graphics);
            }*/
            //Bee 繪出
            /*foreach (ClassBee E in BeeList)
            {
                E.Draw(e.Graphics);
            }*/
            //畫出Player子彈
           /* foreach (ClassPlayerBull B in PlayerBullList)
            {
                B.Draw(e.Graphics);
            }
            //畫出Bee子彈
            foreach (ClassBeeBull BB in BeeBullList)
            {
                BB.Draw(e.Graphics);
            }
            //Boom
            foreach (ClassBoom M in BoomList)
            {
                M.Draw(e.Graphics);
            }
            //SuperBoom
            foreach (ClassSuperBoom SB in SuperBoomList)
            {
                SB.Draw(e.Graphics);
            }
            //Items
            foreach (ClassItems I in ItemsList)
            {
                I.Draw(e.Graphics);
            }*/


            /*
            //BossBee
            if (BeeCount_Stage_1 == 0 && Boss1._BossBee_Life > 0)
            {
                Boss1.Draw(e.Graphics);
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 18, FontStyle.Bold))
                {                    
                    e.Graphics.DrawString("BossLife " + Boss1._BossBee_Life.ToString(), font, Brushes.LightBlue, new Point(20, 200));
                }
            }


            //遊戲開始畫面
            if (!P1._GameOver && StartTime > 50 && StartTime < 400)
            {
                BshStartGame_Index %= BshStartGame.Length;

                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 60, FontStyle.Bold))
                {
                    if (StartTime < 60)
                    {
                      //  if (BshStartGame_X < BshStartGame_X_2[0]) BshStartGame_X++;
                        e.Graphics.DrawString(BshStartGame_str[0], font, BshStartGame[0], new Point(BshStartGame_X_2[0], 250));
                    }
                    else if (StartTime >= 60 && StartTime < 70)
                    {
                       // if (BshStartGame_X < BshStartGame_X_2[0]) BshStartGame_X++;
                        e.Graphics.DrawString(BshStartGame_str[0], font, BshStartGame[0], new Point(BshStartGame_X_2[0], 250));
                        e.Graphics.DrawString(BshStartGame_str[1], font, BshStartGame[0], new Point(BshStartGame_X_2[1], 250));
                    }
                    else if (StartTime >= 70 && StartTime < 80)
                    {
                        e.Graphics.DrawString(BshStartGame_str[0], font, BshStartGame[0], new Point(BshStartGame_X_2[0], 250));
                        e.Graphics.DrawString(BshStartGame_str[1], font, BshStartGame[0], new Point(BshStartGame_X_2[1], 250));
                        e.Graphics.DrawString(BshStartGame_str[2], font, BshStartGame[0], new Point(BshStartGame_X_2[2], 250));
                    }
                    else if (StartTime >= 80 && StartTime < 90)
                    {
                        e.Graphics.DrawString(BshStartGame_str[0], font, BshStartGame[0], new Point(BshStartGame_X_2[0], 250));
                        e.Graphics.DrawString(BshStartGame_str[1], font, BshStartGame[0], new Point(BshStartGame_X_2[1], 250));
                        e.Graphics.DrawString(BshStartGame_str[2], font, BshStartGame[0], new Point(BshStartGame_X_2[2], 250));
                        e.Graphics.DrawString(BshStartGame_str[3], font, BshStartGame[0], new Point(BshStartGame_X_2[3], 250));
                    }
                    else if (StartTime >= 90 && StartTime < 100)
                    {
                        e.Graphics.DrawString(BshStartGame_str[0], font, BshStartGame[0], new Point(BshStartGame_X_2[0], 250));
                        e.Graphics.DrawString(BshStartGame_str[1], font, BshStartGame[0], new Point(BshStartGame_X_2[1], 250));
                        e.Graphics.DrawString(BshStartGame_str[2], font, BshStartGame[0], new Point(BshStartGame_X_2[2], 250));
                        e.Graphics.DrawString(BshStartGame_str[3], font, BshStartGame[0], new Point(BshStartGame_X_2[3], 250));
                        e.Graphics.DrawString(BshStartGame_str[4], font, BshStartGame[0], new Point(BshStartGame_X_2[4], 250));
                    }
                    else if (StartTime >= 100 && StartTime < 350)
                    {
                        e.Graphics.DrawString(BshStartGame_str[0], font, BshStartGame[BshStartGame_Index], new Point(BshStartGame_X_2[0], 250));
                        e.Graphics.DrawString(BshStartGame_str[1], font, BshStartGame[BshStartGame_Index], new Point(BshStartGame_X_2[1], 250));
                        e.Graphics.DrawString(BshStartGame_str[2], font, BshStartGame[BshStartGame_Index], new Point(BshStartGame_X_2[2], 250));
                        e.Graphics.DrawString(BshStartGame_str[3], font, BshStartGame[BshStartGame_Index], new Point(BshStartGame_X_2[3], 250));
                        e.Graphics.DrawString(BshStartGame_str[4], font, BshStartGame[BshStartGame_Index], new Point(BshStartGame_X_2[4], 250));
                    }
                    if(StartTime == 140)BshStartGame_Index++;
                    else if (StartTime == 180) BshStartGame_Index++;
                    else if (StartTime == 220) BshStartGame_Index++;
                    else if (StartTime == 260) BshStartGame_Index++;
                }
            }
            if (P1._GameOver && EndTime > 150 ) 
            {
                if (BshGameOver_Y < 250) BshGameOver_Y++;
                BshGameOver_Index %= BshGameOver.Length;
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 60, FontStyle.Bold))
                {
                    e.Graphics.DrawString(" GAME OVER ", font, BshGameOver[BshGameOver_Index++], new Point(20, BshGameOver_Y));
                }
            }
            else if (!P1._GameOver && EndTime >150)
            {
                if (BshGameOver_Y < 250) BshGameOver_Y++;
                BshGameOver_Index %= BshGameOver.Length;
                using (System.Drawing.Font font = new System.Drawing.Font("Arial", 60, FontStyle.Bold))
                {
                    e.Graphics.DrawString(" COMPLETE!! ", font, BshStartGame[0], new Point(20, BshGameOver_Y));
                }
            }
            */
        }


        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[ timer ]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

        //玩家左移
        private void timer2_Player_Move_Left_Tick(object sender, EventArgs e)
        {
            P1.Get_Player_Left();
        }
        //玩家右移
        private void timer_Player_Move_Right_Tick(object sender, EventArgs e)
        {
            //P1.Get_Player_Right();
        }
        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[ Timer Bee ]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        private void Run_Bee()
        {
            //Bee與玩家碰撞Check
            if (P1.IsVisible)
            foreach (ClassBee Bee in BeeList)
            {
                if (P1._GameOver) break;
                if (Bee.Current_Status != ClassBee.status.active) continue;
                if (!P1._PLayer_Invincible) //若玩家不在無敵狀態
                {
                    if (P1._Player_Defense_Life > 0)//防護罩開啟狀態
                    {
                        if (Bee.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            //myComputer.Audio.Play(Properties.Resources.Bee_Boom, AudioPlayMode.Background);
                            Bee.Bee_Life = 0;
                            P1._Player_Defense_Life--;
                            Bee.Current_Status = ClassBee.status.kill_defense;
                            Get_Scores_Bee();
                            Update_PlayerInfo();
                        }
                    }
                    else//防護罩關閉狀態 -- 玩家DIE
                    {
                        if (Bee.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            //myComputer.Audio.Play(Properties.Resources.Bee_Boom, AudioPlayMode.Background);
                            if (SoundOn) Sound(true);
                            Bee._X = P1._X;
                            Bee._Y = P1._Y;
                            Bee.Bee_Life = 0;
                            Bee.Current_Status = ClassBee.status.kill_player;
                            Reset_Player();
                            PlayerDieCount++;
                            if (P1._GameOver)
                            {
                                EndTime = 0;
                                //timer_EndTime.Enabled = true;
                                RunEnd = true;
                                P1._X = 800;
                                P1._Y = 600;
                            }

                            Update_PlayerInfo();
                        }
                    }
                }
                else//若玩家在無敵狀態
                {
                    if (P1._Player_Defense_Life > 0)//防護罩開啟狀態
                    {
                        if (Bee.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            //myComputer.Audio.Play(Properties.Resources.Bee_Boom, AudioPlayMode.Background);
                            Bee.Bee_Life = 0;
                            P1._Player_Defense_Life--;
                            Bee.Current_Status = ClassBee.status.kill_defense;
                            Get_Scores_Bee();
                            Update_PlayerInfo();
                        }
                    }
                }
            }

            //BeeShoot
            foreach (ClassBee Bee in BeeList)
            {
                if (P1._GameOver) break;
                if (Bee.Current_Status != ClassBee.status.active) continue;
                if (Bee.Bee_Shoot_Count <= 0) continue;

                if (Rd.NextDouble() < Bee_Add_Random)
                {
                    Bee.Bee_Shoot_Count--;
                    ClassBeeBull BeeBull = new ClassBeeBull(gd, Bee._X + Bee._Width / 2, Bee._X + Bee._Width / 2, Bee._Y + Bee._Height, ClassBeeBull.status_BullStatus.active, BmpBeeBullList);
                    BeeBullList.Add(BeeBull);
                }
                else
                {
                    Bee.Bee_Shoot_Count--;
                }

            }


            //Bee回收 到底 OR 碰撞子彈 OR 碰撞玩家 OR 碰撞防護罩 OR 碰撞SuperBomb (生命值: 到底=1 , 碰撞=0) 以及掉落物品
            for (int i = BeeList.Count - 1; i >= 0; i--)
            {
                if (BeeList[i].Current_Status != ClassBee.status.active)
                {
                    if (BeeList[i].Current_Status == ClassBee.status.pass)//若從下方通過 
                    {
                        //BeeList[i].DisposeSprite();
                        BeeList[i] = null;
                        BeeList.RemoveAt(i);
                        Miss_Bee++;
                        lab_Miss_Bee.Text = Miss_Bee.ToString();
                    }
                    else
                    {
                        if (BeeList[i].Current_Status == ClassBee.status.kill_player)//若玩家死亡
                        {
                            ClassBoom Boom = new ClassBoom(gd, BeeList[i]._X, BeeList[i]._Y, 20, ClassBoom.status.playerdie, BmpBoomList);
                            BoomList.Add(Boom);

                        }
                        else if (BeeList[i].Current_Status == ClassBee.status.kill_superbomb)
                        {
                            ClassSuperBoom SuperBoom = new ClassSuperBoom(gd, BeeList[i]._X, BeeList[i]._Y, 50, ClassSuperBoom.status.active, BmpSuperBoomList);
                            SuperBoomList.Add(SuperBoom);
                            ClassItems Items = new ClassItems(gd, BeeList[i]._X, BeeList[i]._Y, true, BmpItemsList);
                            ItemsList.Add(Items);
                            if (Items.Get_Item_Empty) ItemsList.Remove(Items);
                        }
                        else if (BeeList[i].Current_Status == ClassBee.status.kill_linkbomb)
                        {
                            //ClassSuperBoom SuperBoom = new ClassSuperBoom(gd, BeeList[i]._X, BeeList[i]._Y, Rd.Next(5, 15), ClassSuperBoom.status.link, BmpSuperBoomList);
                            ClassSuperBoom SuperBoom = new ClassSuperBoom(gd, BeeList[i]._X, BeeList[i]._Y, 7, ClassSuperBoom.status.link, BmpSuperBoomList);
                            SuperBoomList.Add(SuperBoom);
                            ClassItems Items = new ClassItems(gd, BeeList[i]._X, BeeList[i]._Y, true, BmpItemsList);
                            ItemsList.Add(Items);
                            if (Items.Get_Item_Empty) ItemsList.Remove(Items);
                        }
                        else //Die By Bull
                        {
                            ClassBoom Boom = new ClassBoom(gd, BeeList[i]._X, BeeList[i]._Y, 3, ClassBoom.status.active, BmpBoomList);
                            BoomList.Add(Boom);
                            ClassItems Items = new ClassItems(gd, BeeList[i]._X, BeeList[i]._Y, true, BmpItemsList);
                            ItemsList.Add(Items);
                            if (Items.Get_Item_Empty) ItemsList.Remove(Items);
                        }
                        //BeeList[i].DisposeSprite();
                        BeeList[i] = null;
                        BeeList.RemoveAt(i);
                    }
                }
            }

            //產生Bee
            if (BeeCount_Stage_1 > 0)
            {
                //if (timer_StartTime.Enabled == false)
                if(IsGameStart)
                {
                    if (Rd.NextDouble() < Bee_Add_Random)
                    {
                        ClassBee Bee = new ClassBee(gd, Rd.Next(600), Rd.Next(600), ClassBee.status.active, BmpBeeList);
                        BeeList.Add(Bee);
                        BeeCount_Stage_1--;
                    }
                }
            }
            //遊戲結束
            else
            {
                //if (BeeList.Count == 0)
                if (BeeCount_Stage_1 == 0)
                {
                    RunBossBee = true;
                    //timer_BossBee.Enabled = true;
                }
            }
        }
        private void timer_Bee_Tick(object sender, EventArgs e)
        {
            
            //Bee與玩家碰撞Check
            foreach (ClassBee Bee in BeeList)
            {
                if (P1._GameOver) return;
                if (Bee.Current_Status != ClassBee.status.active) continue;
                if (!P1._PLayer_Invincible) //若玩家不在無敵狀態
                {
                    if (P1._Player_Defense_Life > 0)//防護罩開啟狀態
                    {
                        if (Bee.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            //myComputer.Audio.Play(Properties.Resources.Bee_Boom, AudioPlayMode.Background);
                            Bee.Bee_Life = 0;
                            P1._Player_Defense_Life--;
                            Bee.Current_Status = ClassBee.status.kill_defense;
                            Get_Scores_Bee();
                            Update_PlayerInfo();
                        }
                    }
                    else//防護罩關閉狀態 -- 玩家DIE
                    {
                        if (Bee.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            //myComputer.Audio.Play(Properties.Resources.Bee_Boom, AudioPlayMode.Background);
                            if (SoundOn) Sound(true);
                            Bee._X = P1._X;
                            Bee._Y = P1._Y;
                            Bee.Bee_Life = 0;
                            Bee.Current_Status = ClassBee.status.kill_player;
                            Reset_Player();
                            PlayerDieCount++;
                            if (P1._GameOver)
                            {
                                EndTime = 0;
                                //timer_EndTime.Enabled = true;
                                RunEnd = true;
                                P1._X = 800;
                                P1._Y = 600;
                            }
                            
                            Update_PlayerInfo();
                        }
                    }
                }
                else//若玩家在無敵狀態
                {
                    if (P1._Player_Defense_Life > 0)//防護罩開啟狀態
                    {
                        if (Bee.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            //myComputer.Audio.Play(Properties.Resources.Bee_Boom, AudioPlayMode.Background);
                            Bee.Bee_Life = 0;
                            P1._Player_Defense_Life--;
                            Bee.Current_Status = ClassBee.status.kill_defense;
                            Get_Scores_Bee();
                            Update_PlayerInfo();
                        }
                    }
                }
            }

            //BeeShoot
            foreach (ClassBee Bee in BeeList)
            {
                if (P1._GameOver) return;
                if (Bee.Current_Status != ClassBee.status.active) continue;
                if (Bee.Bee_Shoot_Count <= 0) continue;

                if (Rd.NextDouble() < Bee_Add_Random)
                {
                    Bee.Bee_Shoot_Count--;
                    ClassBeeBull BeeBull = new ClassBeeBull(gd,Bee._X + Bee._Width / 2, Bee._X + Bee._Width / 2, Bee._Y + Bee._Height, ClassBeeBull.status_BullStatus.active, BmpBeeBullList);
                    BeeBullList.Add(BeeBull);
                }
                else
                {
                    Bee.Bee_Shoot_Count--;
                }

            }


            //Bee回收 到底 OR 碰撞子彈 OR 碰撞玩家 OR 碰撞防護罩 OR 碰撞SuperBomb (生命值: 到底=1 , 碰撞=0) 以及掉落物品
            for (int i = BeeList.Count - 1; i >= 0; i--)
            {
                if (BeeList[i].Current_Status != ClassBee.status.active)
                {
                    if (BeeList[i].Current_Status == ClassBee.status.pass)//若從下方通過 
                    {
                        //BeeList[i].DisposeSprite();
                        BeeList[i] = null;
                        BeeList.RemoveAt(i);
                        Miss_Bee++;
                        lab_Miss_Bee.Text = Miss_Bee.ToString();
                    }
                    else
                    {
                        if (BeeList[i].Current_Status == ClassBee.status.kill_player)//若玩家死亡
                        {
                            ClassBoom Boom = new ClassBoom(gd,BeeList[i]._X, BeeList[i]._Y, 20, ClassBoom.status.playerdie, BmpBoomList);
                            BoomList.Add(Boom);

                        }
                        else if (BeeList[i].Current_Status == ClassBee.status.kill_superbomb)
                        {
                            ClassSuperBoom SuperBoom = new ClassSuperBoom(gd,BeeList[i]._X, BeeList[i]._Y, 50, ClassSuperBoom.status.active, BmpSuperBoomList);
                            SuperBoomList.Add(SuperBoom);
                            ClassItems Items = new ClassItems(gd,BeeList[i]._X, BeeList[i]._Y, true, BmpItemsList);
                            ItemsList.Add(Items);
                            if (Items.Get_Item_Empty) ItemsList.Remove(Items);
                        }
                        else if (BeeList[i].Current_Status == ClassBee.status.kill_linkbomb)
                        {
                            ClassSuperBoom SuperBoom = new ClassSuperBoom(gd, BeeList[i]._X, BeeList[i]._Y, Rd.Next(5, 15), ClassSuperBoom.status.link, BmpSuperBoomList);
                            SuperBoomList.Add(SuperBoom);
                            ClassItems Items = new ClassItems(gd, BeeList[i]._X, BeeList[i]._Y, true, BmpItemsList);
                            ItemsList.Add(Items);
                            if (Items.Get_Item_Empty) ItemsList.Remove(Items);
                        }
                        else //Die By Bull
                        {
                            ClassBoom Boom = new ClassBoom(gd, BeeList[i]._X, BeeList[i]._Y, 3, ClassBoom.status.active, BmpBoomList);
                            BoomList.Add(Boom);
                            ClassItems Items = new ClassItems(gd, BeeList[i]._X, BeeList[i]._Y, true, BmpItemsList);
                            ItemsList.Add(Items);
                            if (Items.Get_Item_Empty) ItemsList.Remove(Items);
                        }
                        //BeeList[i].DisposeSprite();
                        BeeList[i] = null;
                        BeeList.RemoveAt(i);
                    }
                }
            }

            //產生Bee
            if (BeeCount_Stage_1 > 0)
            {
                if (timer_StartTime.Enabled == false)
                {
                    if (Rd.NextDouble() < Bee_Add_Random)
                    {
                        ClassBee Bee = new ClassBee(gd, Rd.Next(600), Rd.Next(600), ClassBee.status.active, BmpBeeList);
                        BeeList.Add(Bee);
                        BeeCount_Stage_1--;
                    }
                }
            }
            //遊戲結束
            else
            {
                //if (BeeList.Count == 0)
                if(BeeCount_Stage_1 == 0 )
                {
                    timer_BossBee.Enabled = true;
                }
            }
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[ Timer Bee ]^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[ Landscape ]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        private void timer_Landscape_Tick(object sender, EventArgs e)
        {
            yy += 1;

           /* //背景光點Die --> 移除
            for (int i = LandscapeList.Count - 1; i >= 0; i--)
            {
                if (LandscapeList[i].Current_Status == ClassLandscape.status.die) LandscapeList.RemoveAt(i);
            }

            //背景產生光點
            if (Rd.NextDouble() < 0.05)
            {
                ClassLandscape Landscape = new ClassLandscape(Rd.Next(600), Rd.Next(600), 2, ClassLandscape.status.active);
                ClassLandscape Landscape1 = new ClassLandscape(Rd.Next(600), Rd.Next(600), 1, ClassLandscape.status.active);
                LandscapeList.Add(Landscape);
                LandscapeList.Add(Landscape1);
            }   */
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[ Landscape ]^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[ BossBee ]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        private void Run_BossBee()
        {
                        //BossBee與子彈碰撞Check

            foreach (ClassPlayerBull Bull in PlayerBullList)
            {
                if (Boss1.Current_Status == ClassBossBee.status.Die) return;
                if (Bull.Current_BullStatus != ClassPlayerBull.status_BullStatus.active) continue;
                if (Bull.CheckCollision(Boss1._X, Boss1._Y, Boss1._Width, Boss1._Height))
                {
                    Bull.Current_BullStatus = ClassPlayerBull.status_BullStatus.hit;

                    if (Bull.Current_BullType == ClassPlayerBull.status_BullType.LinkBomb)
                    {
                        Boss1._BossBee_Life -= 3;
                        if (Boss1._BossBee_Life <= 0)
                        {
                            ClassBoom Boom = new ClassBoom(gd, Boss1._X, Boss1._Y - 10, 70, ClassBoom.status.Bossdie, BmpBoomList);
                            BoomList.Add(Boom);
                            Boss1.Current_Status = ClassBossBee.status.Die;
                            //timer_EndTime.Enabled = true;
                            RunEnd = true;
                        }
                        ClassSuperBoom SuperBoom = new ClassSuperBoom(gd, Bull._X, Bull._Y, 5, ClassSuperBoom.status.link, BmpSuperBoomList);
                        SuperBoomList.Add(SuperBoom);
                        Boss1._BossHti = true;
                        sound_BossBee_hit.Play(0, Microsoft.DirectX.DirectSound.BufferPlayFlags.Default);

                    }
                    else
                    {
                        Boss1._BossBee_Life -= 1;
                        if (Boss1._BossBee_Life <= 0)
                        {
                            ClassBoom Boom1 = new ClassBoom(gd, Boss1._X, Boss1._Y - 10, 70, ClassBoom.status.Bossdie, BmpBoomList);
                            BoomList.Add(Boom1);
                            Boss1.Current_Status = ClassBossBee.status.Die;
                            //timer_EndTime.Enabled = true;
                            RunEnd = true;
                        }
                        ClassBoom Boom = new ClassBoom(gd, Bull._X, Bull._Y - 10, 3, ClassBoom.status.active, BmpBoomList);
                        BoomList.Add(Boom);
                        Boss1._BossHti = true;
                        sound_BossBee_hit.Play(0, Microsoft.DirectX.DirectSound.BufferPlayFlags.Default);
                    }
                    Get_Scores_BossBee();
                    Update_PlayerInfo();
                }
            }

            foreach (ClassSuperBoom SuperBoom in SuperBoomList)
            {
                if (SuperBoom.Current_Status == ClassSuperBoom.status.die) continue;

                if (Boss1.Current_Status == ClassBossBee.status.Die) return;

                    if (SuperBoom.CheskCollision(Boss1._X, Boss1._Y, Boss1._Width, Boss1._Height))
                    {
                        if (SuperBoom.Current_Status == ClassSuperBoom.status.active)
                        {
                            ClassBoom Boom = new ClassBoom(gd, Boss1._X + Boss1._Width / 2, Boss1._Y + Boss1._Height / 2, 5, ClassBoom.status.active, BmpBoomList);
                            BoomList.Add(Boom);
                            Boss1._BossBee_Life -= 5;
                            Boss1._BossHti = true;
                            sound_BossBee_hit.Play(0, Microsoft.DirectX.DirectSound.BufferPlayFlags.Default);

                        if (Boss1._BossBee_Life <= 0)
                            {
                                ClassBoom Boom1 = new ClassBoom(gd, Boss1._X, Boss1._Y - 10, 70, ClassBoom.status.Bossdie, BmpBoomList);
                                BoomList.Add(Boom1);
                                Boss1.Current_Status = ClassBossBee.status.Die;
                                //timer_EndTime.Enabled = true;
                                RunEnd = true;
                            }
                        }
                        Get_Scores_BossBee();
                        Update_PlayerInfo();
                    }
                
            }
        }
        private void timer_BossBee_Tick(object sender, EventArgs e)
        {
            //BossBee與子彈碰撞Check

            foreach (ClassPlayerBull Bull in PlayerBullList)
            {
                if (Boss1.Current_Status == ClassBossBee.status.Die) return;
                if (Bull.Current_BullStatus != ClassPlayerBull.status_BullStatus.active) continue;
                if (Bull.CheckCollision(Boss1._X, Boss1._Y, Boss1._Width, Boss1._Height))
                {
                    Bull.Current_BullStatus = ClassPlayerBull.status_BullStatus.hit;

                    if (Bull.Current_BullType == ClassPlayerBull.status_BullType.LinkBomb)
                    {
                        Boss1._BossBee_Life -= 3;
                        if (Boss1._BossBee_Life <= 0)
                        {
                            ClassBoom Boom = new ClassBoom(gd, Boss1._X, Boss1._Y - 10, 70, ClassBoom.status.Bossdie, BmpBoomList);
                            BoomList.Add(Boom);
                            Boss1.Current_Status = ClassBossBee.status.Die;
                            timer_EndTime.Enabled = true;
                        }
                        ClassSuperBoom SuperBoom = new ClassSuperBoom(gd, Bull._X, Bull._Y, 5, ClassSuperBoom.status.link, BmpSuperBoomList);
                        SuperBoomList.Add(SuperBoom);
                        Boss1._BossHti = true;

                    }
                    else
                    {
                        Boss1._BossBee_Life -= 1;
                        if (Boss1._BossBee_Life <= 0)
                        {
                            ClassBoom Boom1 = new ClassBoom(gd, Boss1._X, Boss1._Y - 10, 70, ClassBoom.status.Bossdie, BmpBoomList);
                            BoomList.Add(Boom1);
                            Boss1.Current_Status = ClassBossBee.status.Die;
                            timer_EndTime.Enabled = true;
                        }
                        ClassBoom Boom = new ClassBoom(gd, Bull._X, Bull._Y - 10, 3, ClassBoom.status.active, BmpBoomList);
                        BoomList.Add(Boom);
                        Boss1._BossHti = true;
                    }
                    Get_Scores_BossBee();
                    Update_PlayerInfo();
                }
            }

            foreach (ClassSuperBoom SuperBoom in SuperBoomList)
            {
                if (SuperBoom.Current_Status == ClassSuperBoom.status.die) continue;

                if (Boss1.Current_Status == ClassBossBee.status.Die) return;

                    if (SuperBoom.CheskCollision(Boss1._X, Boss1._Y, Boss1._Width, Boss1._Height))
                    {
                        if (SuperBoom.Current_Status == ClassSuperBoom.status.active)
                        {
                            ClassBoom Boom = new ClassBoom(gd, Boss1._X + Boss1._Width / 2, Boss1._Y + Boss1._Height / 2, 5, ClassBoom.status.active, BmpBoomList);
                            BoomList.Add(Boom);
                            Boss1._BossBee_Life -= 5;

                            if (Boss1._BossBee_Life <= 0)
                            {
                                ClassBoom Boom1 = new ClassBoom(gd, Boss1._X, Boss1._Y - 10, 70, ClassBoom.status.Bossdie, BmpBoomList);
                                BoomList.Add(Boom1);
                                Boss1.Current_Status = ClassBossBee.status.Die;
                                timer_EndTime.Enabled = true;
                            }
                        }
                        Get_Scores_BossBee();
                        Update_PlayerInfo();
                    }
                
            }
        }


        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[ BossBee ]^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        int bullSpeed = 0;

        private void CreateBull(int LV,int type)
        {
            if (LV == 6)
            {
                Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 - 15, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 15, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);

                Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 - 60, (P1._X + P1._Width / 2) - 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 60, (P1._X + P1._Width / 2) + 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);

                Create_PlayerBull(P1._X + P1._Width / 2 - 40, (P1._X + P1._Width / 2) - 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 40, (P1._X + P1._Width / 2) + 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 - 50, (P1._X + P1._Width / 2) - 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 50, (P1._X + P1._Width / 2) + 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);

            }
            else if (LV == 5)
            {
                Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 - 15, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 15, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);

                Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 - 60, (P1._X + P1._Width / 2) - 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 60, (P1._X + P1._Width / 2) + 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);

                Create_PlayerBull(P1._X + P1._Width / 2 - 45, (P1._X + P1._Width / 2) - 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 45, (P1._X + P1._Width / 2) + 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);

            }
            else if (LV == 4)
            {
                Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2-15, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2+15, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);

                Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 - 60, (P1._X + P1._Width / 2) - 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 60, (P1._X + P1._Width / 2) + 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
            }
            else if (LV == 3)
            {
                Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 - 60, (P1._X + P1._Width / 2) - 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 60, (P1._X + P1._Width / 2) + 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
            }
            else if (LV == 2)
            {
                Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 30, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 30, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
            }
            else if (LV == 1 && type == 0)
            {
                Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
            }
            else if (LV == 1 && type == 1)
            {
                Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, false, ClassPlayerBull.status_BullType.LinkBomb, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
            }
        }
        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[ Timer Bull [Player] [Bee] ]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        private void Run_Bull()
        {

            bullSpeed++;
            if (bullSpeed > 10 && !P1._GameOver && P1.IsVisible)
            {
                //一發子彈
                {
                    if (PlayerDie_ResetTIme > 0 && PlayerDie_ResetTIme < 110)
                    { }
                    else
                    {
                        if (BullLink)
                        {
                            CreateBull(1, 1);
                        }
                        else if (P1._Player_PowerUp >= 6)
                        {
                            if (BullLV6)
                            {
                                CreateBull(6, 0);
                            }
                        }
                        else if (P1._Player_PowerUp >= 5)
                        {
                            if (BullLV5)
                            {
                                CreateBull(5, 0);
                            }
                        }
                        else if (P1._Player_PowerUp >= 4)
                        {
                            if (BullLV4)
                            {
                                CreateBull(4, 0);
                            }
                        }
                        else if (P1._Player_PowerUp >= 3)
                        {

                            if (BullLV3)
                            {
                                CreateBull(3, 0);
                            }

                            /*if (P1._Player_PowerCount - PlayerBullList.Count > 4)
                            {
                                if (BullLV3)
                                {
                                    Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                    Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                    Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                    Create_PlayerBull(P1._X + P1._Width / 2 - 60, (P1._X + P1._Width / 2) - 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                    Create_PlayerBull(P1._X + P1._Width / 2 + 60, (P1._X + P1._Width / 2) + 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                }
                            }
                            else if (P1._Player_PowerCount - PlayerBullList.Count > 2)
                            {
                                if (BullLV3)
                                {
                                    Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                    Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 350, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                    Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 350, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                }
                            }*/
                        }
                        else if (P1._Player_PowerUp >= 2)
                        {
                            if (BullLV2)
                            {
                                CreateBull(2, 0);
                            }
                            /*if (P1._Player_PowerCount - PlayerBullList.Count > 1)
                            {
                                if (BullLV2)
                                {
                                    Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 30, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                    Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 30, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                }
                            }*/
                        }
                        else if (P1._Player_PowerUp >= 1)
                        {
                            if (BullLV1)
                            {
                                CreateBull(1, 0);
                            }
                            /*if (P1._Player_PowerCount - PlayerBullList.Count > 0)
                            {
                                if(BullLV1)
                                Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                else if (BullLink)
                                {
                                    Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, false, ClassPlayerBull.status_BullType.LinkBomb, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                }
                            }*/
                        }
                        
                        
                    }
                }
                bullSpeed = 0;
            }
            //Player子彈回收   若子彈狀態=false 
            for (int i = PlayerBullList.Count - 1; i >= 0; i--)
            {
                if (PlayerBullList[i].Current_BullStatus == ClassPlayerBull.status_BullStatus.active) continue;

                if (PlayerBullList[i].Current_BullStatus == ClassPlayerBull.status_BullStatus.miss)
                {
                    Miss_Bull++;
                    lab_Miss_Bull.Text = Miss_Bull.ToString();
                }
                if (PlayerBullList[i].Current_BullStatus == ClassPlayerBull.status_BullStatus.hit && (PlayerBullList[i].Current_BullType == ClassPlayerBull.status_BullType.SuperBomb))
                {
                    ClassSuperBoom SuperBoom = new ClassSuperBoom(gd, PlayerBullList[i]._X, PlayerBullList[i]._Y, 50, ClassSuperBoom.status.active, BmpSuperBoomList);
                    SuperBoomList.Add(SuperBoom);
                }
                // PlayerBullList[i].DisposeSprite();
                PlayerBullList[i] = null;
                PlayerBullList.RemoveAt(i);
                lab_Player_PowerCount.Text = (P1._Player_PowerCount - PlayerBullList.Count).ToString() + " / " + P1._Player_PowerCount_Limit.ToString();


            }
            //Bee子彈回收   若子彈狀態=false 
            for (int i = BeeBullList.Count - 1; i >= 0; i--)
            {
                if (BeeBullList[i].Current_BullStatus == ClassBeeBull.status_BullStatus.active) continue;

                if (BeeBullList[i].Current_BullStatus == ClassBeeBull.status_BullStatus.miss)
                {
                    //BeeBullList[i].DisposeSprite();
                    BeeBullList[i] = null;
                    BeeBullList.RemoveAt(i);
                }
                else if (BeeBullList[i].Current_BullStatus == ClassBeeBull.status_BullStatus.hit)
                {
                    ClassBoom Boom = new ClassBoom(gd, BeeBullList[i]._X, BeeBullList[i]._Y, 20, ClassBoom.status.playerdie, BmpBoomList);
                    BoomList.Add(Boom);
                    //BeeBullList[i].DisposeSprite();
                    BeeBullList[i] = null;
                    BeeBullList.RemoveAt(i);
                }

            }

            //Bee與子彈碰撞Check
            foreach (ClassBee Bee in BeeList)
            {
                if (Bee.Current_Status != ClassBee.status.active) continue;
                foreach (ClassPlayerBull Bull in PlayerBullList)
                {
                    if (Bull.Current_BullStatus != ClassPlayerBull.status_BullStatus.active) continue;
                    if (Bull.CheckCollision(Bee._X, Bee._Y, Bee._Width, Bee._Height))
                    {

                        //myComputer.Audio.Play(Properties.Resources.Bee_Boom, AudioPlayMode.Background);
                        Bee.Bee_Life = 0;
                        // Bull.BullLife = 0;
                        Bull.Current_BullStatus = ClassPlayerBull.status_BullStatus.hit;

                        if (Bull.Current_BullType == ClassPlayerBull.status_BullType.SuperBomb)
                        {
                            Bee._X = Bull._X;
                            Bee._Y = Bull._Y;
                            Bee.Current_Status = ClassBee.status.kill_superbomb;
                        }
                        else if (Bull.Current_BullType == ClassPlayerBull.status_BullType.LinkBomb)
                        {
                            Bee._X = Bull._X;
                            Bee._Y = Bull._Y;
                            Bee.Current_Status = ClassBee.status.kill_linkbomb;
                        }
                        else
                        {
                            Bee.Current_Status = ClassBee.status.kill_bull;
                        }
                        Get_Scores_Bee();
                        Update_PlayerInfo();
                    }
                }
            }




            //BeeBull與玩家碰撞
            foreach (ClassBeeBull BeeBull in BeeBullList)
            {
                if (P1._GameOver) break;
                if (BeeBull.Current_BullStatus != ClassBeeBull.status_BullStatus.active) continue;
                if (P1._PLayer_Invincible == false) //若玩家不在無敵狀態
                {
                    if (P1._Player_Defense_Life > 0)//防護罩開啟狀態
                    {
                        if (BeeBull.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            P1._Player_Defense_Life--;
                            BeeBull.Current_BullStatus = ClassBeeBull.status_BullStatus.miss;
                        }
                    }
                    else//防護罩關閉狀態 -- 玩家DIE
                    {
                        if (BeeBull.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            if (SoundOn) Sound(true);
                            BeeBull._X = P1._X;
                            BeeBull._Y = P1._Y;
                            BeeBull.Current_BullStatus = ClassBeeBull.status_BullStatus.hit;
                            Reset_Player();
                            PlayerDieCount++;
                            if (P1._GameOver)
                            {
                                EndTime = 0;
                                //timer_EndTime.Enabled = true;
                                RunEnd = true;
                                P1._X = 800;
                                P1._Y = 600;
                            }

                            Update_PlayerInfo();
                        }
                    }
                }
                else//若玩家在無敵狀態
                {
                    if (P1._Player_Defense_Life > 0)//防護罩開啟狀態
                    {
                        if (BeeBull.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            BeeBull.Current_BullStatus = ClassBeeBull.status_BullStatus.miss;
                            P1._Player_Defense_Life--;
                        }
                    }
                }
            } 
        }
        private void timer_Bull_Tick(object sender, EventArgs e)
        {

            bullSpeed++;
            if (bullSpeed > 10 && !P1._GameOver)
            {
                //一發子彈
                {
                    if (PlayerDie_ResetTIme > 0 && PlayerDie_ResetTIme < 110)
                    { }
                    else
                    {
                        if (P1._Player_PowerUp == 1)
                        {
                            if (P1._Player_PowerCount - PlayerBullList.Count > 0)
                            {
                                Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            }
                        }
                        else if (P1._Player_PowerUp == 2)
                        {
                            if (P1._Player_PowerCount - PlayerBullList.Count > 1)
                            {
                                Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 30, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 30, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            }
                        }
                        else if (P1._Player_PowerUp == 3)
                        {
                            if (P1._Player_PowerCount - PlayerBullList.Count > 4)
                            {
                                Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 250, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                Create_PlayerBull(P1._X + P1._Width / 2 - 60, (P1._X + P1._Width / 2) - 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                Create_PlayerBull(P1._X + P1._Width / 2 + 60, (P1._X + P1._Width / 2) + 450, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            }
                            else
                            if (P1._Player_PowerCount - PlayerBullList.Count > 2)
                            {
                                Create_PlayerBull(P1._X + P1._Width / 2, P1._X + P1._Width / 2, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                Create_PlayerBull(P1._X + P1._Width / 2 - 30, (P1._X + P1._Width / 2) - 350, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                                Create_PlayerBull(P1._X + P1._Width / 2 + 30, (P1._X + P1._Width / 2) + 350, P1._Y, P1._Player_BigBull, ClassPlayerBull.status_BullType.Bull, ClassPlayerBull.status_BullStatus.active, BmpPlayerBullList, BmpPlayerBullLinkBombList);
                            }
                        }
                    }
                }
                bullSpeed = 0;
            }
            //Player子彈回收   若子彈狀態=false 
            for (int i = PlayerBullList.Count - 1; i >= 0; i--)
            {
                if (PlayerBullList[i].Current_BullStatus == ClassPlayerBull.status_BullStatus.active) continue;

                if (PlayerBullList[i].Current_BullStatus == ClassPlayerBull.status_BullStatus.miss)
                {
                    Miss_Bull++;
                    lab_Miss_Bull.Text = Miss_Bull.ToString();
                }
                if (PlayerBullList[i].Current_BullStatus == ClassPlayerBull.status_BullStatus.hit && (PlayerBullList[i].Current_BullType == ClassPlayerBull.status_BullType.SuperBomb))
                {
                    ClassSuperBoom SuperBoom = new ClassSuperBoom(gd, PlayerBullList[i]._X, PlayerBullList[i]._Y, 50, ClassSuperBoom.status.active, BmpSuperBoomList);
                    SuperBoomList.Add(SuperBoom);
                }
               // PlayerBullList[i].DisposeSprite();
                PlayerBullList[i] = null;
                PlayerBullList.RemoveAt(i);
                lab_Player_PowerCount.Text = (P1._Player_PowerCount - PlayerBullList.Count).ToString() + " / " + P1._Player_PowerCount_Limit.ToString();


            }
            //Bee子彈回收   若子彈狀態=false 
            for (int i = BeeBullList.Count - 1; i >= 0; i--)
            {
                if (BeeBullList[i].Current_BullStatus == ClassBeeBull.status_BullStatus.active) continue;

                if (BeeBullList[i].Current_BullStatus == ClassBeeBull.status_BullStatus.miss)
                {
                    //BeeBullList[i].DisposeSprite();
                    BeeBullList[i] = null;
                    BeeBullList.RemoveAt(i);
                }
                else if (BeeBullList[i].Current_BullStatus == ClassBeeBull.status_BullStatus.hit)
                {
                    ClassBoom Boom = new ClassBoom(gd, BeeBullList[i]._X, BeeBullList[i]._Y, 20, ClassBoom.status.playerdie, BmpBoomList);
                    BoomList.Add(Boom);
                    //BeeBullList[i].DisposeSprite();
                    BeeBullList[i] = null;
                    BeeBullList.RemoveAt(i);
                }

            }

            //Bee與子彈碰撞Check
            foreach (ClassBee Bee in BeeList)
            {
                if (Bee.Current_Status != ClassBee.status.active) continue;
                foreach (ClassPlayerBull Bull in PlayerBullList)
                {
                    if (Bull.Current_BullStatus != ClassPlayerBull.status_BullStatus.active) continue;
                    if (Bull.CheckCollision(Bee._X, Bee._Y, Bee._Width, Bee._Height))
                    {

                        //myComputer.Audio.Play(Properties.Resources.Bee_Boom, AudioPlayMode.Background);
                        Bee.Bee_Life = 0;
                        // Bull.BullLife = 0;
                        Bull.Current_BullStatus = ClassPlayerBull.status_BullStatus.hit;

                        if (Bull.Current_BullType == ClassPlayerBull.status_BullType.SuperBomb)
                        {
                            Bee._X = Bull._X;
                            Bee._Y = Bull._Y;
                            Bee.Current_Status = ClassBee.status.kill_superbomb;
                        }
                        else if (Bull.Current_BullType == ClassPlayerBull.status_BullType.LinkBomb)
                        {
                            Bee._X = Bull._X;
                            Bee._Y = Bull._Y;
                            Bee.Current_Status = ClassBee.status.kill_linkbomb;
                        }
                        else
                        {
                            Bee.Current_Status = ClassBee.status.kill_bull;
                        }
                        Get_Scores_Bee();
                        Update_PlayerInfo();
                    }
                }
            }

          
            

            //BeeBull與玩家碰撞
            foreach (ClassBeeBull BeeBull in BeeBullList)
            {
                if (P1._GameOver) return;
                if (BeeBull.Current_BullStatus != ClassBeeBull.status_BullStatus.active) continue;
                if (P1._PLayer_Invincible == false) //若玩家不在無敵狀態
                {
                    if (P1._Player_Defense_Life > 0)//防護罩開啟狀態
                    {
                        if (BeeBull.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            P1._Player_Defense_Life--;
                            BeeBull.Current_BullStatus = ClassBeeBull.status_BullStatus.miss;
                        }
                    }
                    else//防護罩關閉狀態 -- 玩家DIE
                    {
                        if (BeeBull.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            if (SoundOn) Sound(true);
                            BeeBull._X = P1._X;
                            BeeBull._Y = P1._Y;
                            BeeBull.Current_BullStatus = ClassBeeBull.status_BullStatus.hit;
                            Reset_Player();
                            PlayerDieCount++;
                            if (P1._GameOver)
                            {
                                EndTime = 0;
                                timer_EndTime.Enabled = true;
                                P1._X = 800;
                                P1._Y = 600;
                            }
                            
                            Update_PlayerInfo();
                        }
                    }
                }
                else//若玩家在無敵狀態
                {
                    if (P1._Player_Defense_Life > 0)//防護罩開啟狀態
                    {
                        if (BeeBull.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            BeeBull.Current_BullStatus = ClassBeeBull.status_BullStatus.miss;
                            P1._Player_Defense_Life--;
                        }
                    }
                }
            } 
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[ Timer Bull [Player] [Bee] ]^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[ Run Bull [Boss] vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        int BossBeeBulltime = 0;
        int BossBeeEndtime = 0;

        private void Run_BossBeeBull()
        {
            BossBeeBulltime++;

            if (BossBeeEndtime == 0)
            {
                //if (BossBeeBulltime > 100 && BossBeeBulltime < 160)
                {
                    if (Rd.NextDouble() > 0.8)
                        BossBeeEndtime = 160;
                    else if (Rd.NextDouble() > 0.65)
                        BossBeeEndtime = 145;
                    else if (Rd.NextDouble() > 0.4)
                        BossBeeEndtime = 130;
                    else
                        BossBeeEndtime = 115;
                }
            }
            else
            {
                if (BossBeeBulltime <= BossBeeEndtime)
                {
                    if (BossBeeBulltime == 100 || BossBeeBulltime == 115 || BossBeeBulltime == 130 || BossBeeBulltime == 145 || BossBeeBulltime == 160)
                    {
                        ClassBossBeeBull BeeBull = new ClassBossBeeBull(gd, Boss1._X + Boss1._Width / 2, Boss1._X + Boss1._Width / 2, Boss1._Y + Boss1._Height, ClassBossBeeBull.status_BullStatus.active, BmpBossBeeBullList);
                        BossBeeBullList.Add(BeeBull);
                    }   
                }
            }
            if (BossBeeBulltime > BossBeeEndtime && BossBeeBulltime > 100)
            {
                BossBeeBulltime = 0;
                BossBeeEndtime = 0;
            }

            //Bee子彈回收   若子彈狀態=false 
            for (int i = BossBeeBullList.Count - 1; i >= 0; i--)
            {
                if (BossBeeBullList[i].Current_BullStatus == ClassBossBeeBull.status_BullStatus.active) continue;

                if (BossBeeBullList[i].Current_BullStatus == ClassBossBeeBull.status_BullStatus.miss)
                {
                    //BeeBullList[i].DisposeSprite();
                    BossBeeBullList[i] = null;
                    BossBeeBullList.RemoveAt(i);
                }
                else if (BossBeeBullList[i].Current_BullStatus == ClassBossBeeBull.status_BullStatus.hit)
                {
                    ClassBoom Boom = new ClassBoom(gd, BossBeeBullList[i]._X, BossBeeBullList[i]._Y, 20, ClassBoom.status.playerdie, BmpBoomList);
                    BoomList.Add(Boom);
                    //BeeBullList[i].DisposeSprite();
                    BossBeeBullList[i] = null;
                    BossBeeBullList.RemoveAt(i);
                }
            }
            //BossBeeBull與玩家碰撞
            foreach (ClassBossBeeBull BossBeeBull in BossBeeBullList)
            {
                if (P1._GameOver) return;
                if (BossBeeBull.Current_BullStatus != ClassBossBeeBull.status_BullStatus.active) continue;
                if (P1._PLayer_Invincible == false) //若玩家不在無敵狀態
                {
                    if (P1._Player_Defense_Life > 0)//防護罩開啟狀態
                    {
                        if (BossBeeBull.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            P1._Player_Defense_Life--;
                            BossBeeBull.Current_BullStatus = ClassBossBeeBull.status_BullStatus.miss;
                        }
                    }
                    else//防護罩關閉狀態 -- 玩家DIE
                    {
                        if (BossBeeBull.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            if (SoundOn) Sound(true);
                            BossBeeBull._X = P1._X;
                            BossBeeBull._Y = P1._Y;
                            BossBeeBull.Current_BullStatus = ClassBossBeeBull.status_BullStatus.hit;
                            Reset_Player();
                            PlayerDieCount++;
                            if (P1._GameOver)
                            {
                                EndTime = 0;
                                timer_EndTime.Enabled = true;
                                P1._X = 800;
                                P1._Y = 600;
                            }

                            Update_PlayerInfo();
                        }
                    }
                }
                else//若玩家在無敵狀態
                {
                    if (P1._Player_Defense_Life > 0)//防護罩開啟狀態
                    {
                        if (BossBeeBull.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                        {
                            BossBeeBull.Current_BullStatus = ClassBossBeeBull.status_BullStatus.miss;
                            P1._Player_Defense_Life--;
                        }
                    }
                }
            } 
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[ Run Bull [Boss] ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[ Timer Items ]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        private void Run_Items()
        {
            //掉落物品碰撞
            if (P1.IsVisible)
            foreach (ClassItems Items in ItemsList)
            {
                if (P1._GameOver) break;
                switch (Items.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                {
                    case 0://掉落子彈Count
                        Items._Falling = false;
                        P1._Player_PowerCount = ++P1._Player_PowerCount;
                        TotalScores += 500;
                        P1._PLayer_NowMoney += 500;
                        break;
                    case 1://掉落子彈PowerUp
                        Items._Falling = false;
                        ++P1._Player_PowerUp;
                        TotalScores += 1000;
                        P1._PLayer_NowMoney += 1000;
                        CheckPowerUp();
                        break;
                    case 2://掉落SuperBomb
                        Items._Falling = false;
                        TotalScores += 2000;
                        P1._Player_SuperBomb = true;
                        P1._PLayer_NowMoney += 2000;
                        break;
                    case 3://掉落子彈變大
                        Items._Falling = false;
                        P1._Player_BigBull = true;
                        TotalScores += 1000;
                        P1._Player_BigBull = true;
                        P1._PLayer_NowMoney += 1000;
                        break;
                    case 4://Power_Step
                        Items._Falling = false;
                        P1._Player_Speed = ++P1._Player_Speed;
                        TotalScores += 500;
                        P1._PLayer_NowMoney += 500;
                        break;
                    case 5://掉落防護罩
                        Items._Falling = false;
                        TotalScores += 2000;
                        P1._Player_Defense = true;
                        P1._PLayer_NowMoney += 2000;
                        break;
                    default:
                        break;
                }
                Update_PlayerInfo();
            }

            //掉落物品回收
            for (int i = ItemsList.Count - 1; i >= 0; i--)
            {
                if (ItemsList[i]._Falling == false)
                {
                    //ItemsList[i].DisposeSprite();
                    ItemsList[i] = null;
                    ItemsList.RemoveAt(i);
                }
            }  
        }
        private void timer_Items_Tick(object sender, EventArgs e)
        {    
            //掉落物品碰撞
            foreach (ClassItems Items in ItemsList)
            {
                if (P1._GameOver) return;
                switch (Items.CheckCollision(P1._X, P1._Y, P1._Width, P1._Height))
                {
                    case 0://掉落子彈Count
                        Items._Falling = false;
                        P1._Player_PowerCount = ++P1._Player_PowerCount;
                        TotalScores += 500;
                        P1._PLayer_NowMoney += 500;
                        break;
                    case 1://掉落子彈PowerUp
                        Items._Falling = false;
                        ++P1._Player_PowerUp;
                        TotalScores += 1000;
                        P1._PLayer_NowMoney += 1000;
                        break;
                    case 2://掉落SuperBomb
                        Items._Falling = false;
                        TotalScores += 2000;
                        P1._Player_SuperBomb = true;
                        P1._PLayer_NowMoney += 2000;
                        break;
                    case 3://掉落子彈變大
                        Items._Falling = false;
                        P1._Player_BigBull = true;
                        TotalScores += 1000;
                        P1._Player_BigBull = true;
                        P1._PLayer_NowMoney += 1000;
                        break;
                    case 4://Power_Step
                        Items._Falling = false;
                        P1._Player_Speed = ++P1._Player_Speed;
                        TotalScores += 500;
                        P1._PLayer_NowMoney += 500;
                        break;
                    case 5://掉落防護罩
                        Items._Falling = false;
                        TotalScores += 2000;
                        P1._Player_Defense = true;
                        P1._PLayer_NowMoney += 2000;
                        break;
                    default:
                        break;
                }
                Update_PlayerInfo();
            }

            //掉落物品回收
            for (int i = ItemsList.Count - 1; i >= 0; i--)
            {
                if (ItemsList[i]._Falling == false)
                {
                    //ItemsList[i].DisposeSprite();
                    ItemsList[i] = null;
                    ItemsList.RemoveAt(i);
                }
            }  
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[ Timer Items ]^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[ Timer Boom ]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
        private void Run_Boom()
        {
            //爆炸回收
            for (int i = BoomList.Count - 1; i >= 0; i--)
            {
                if (BoomList[i].Current_Status == ClassBoom.status.die)
                {
                    //BoomList[i].DisposeSprite();
                    BoomList[i] = null;
                    BoomList.RemoveAt(i);
                }
            }

            //爆炸回收
            for (int i = SuperBoomList.Count - 1; i >= 0; i--)
            {
                if (SuperBoomList[i].Current_Status == ClassSuperBoom.status.die)
                {
                    //SuperBoomList[i].DisposeSprite();
                    SuperBoomList[i] = null;
                    SuperBoomList.RemoveAt(i);
                }
            }

            //Bee與SuperBoom碰撞Check
            foreach (ClassSuperBoom SuperBoom in SuperBoomList)
            {
                if (SuperBoom.Current_Status == ClassSuperBoom.status.die) continue;
                foreach (ClassBee Bee in BeeList)
                {
                    if (Bee.Current_Status != ClassBee.status.active) continue;
                    if (SuperBoom.CheskCollision(Bee._X, Bee._Y, Bee._Width, Bee._Height))
                    {
                        Bee.Bee_Life = 0;
                        if (SuperBoom.Current_Status == ClassSuperBoom.status.active)
                        {
                            Bee.Current_Status = ClassBee.status.kill_bull;
                        }
                        else if (SuperBoom.Current_Status == ClassSuperBoom.status.link)
                        {
                            Bee.Current_Status = ClassBee.status.kill_linkbomb;
                        }
                        //myComputer.Audio.Play(Properties.Resources.Bee_Boom, AudioPlayMode.Background);
                        Get_Scores_Bee();
                        Update_PlayerInfo();
                    }
                }
            }

            //BeeBull與SuperBoom碰撞Check
            foreach (ClassSuperBoom SuperBoom in SuperBoomList)
            {
                if (SuperBoom.Current_Status == ClassSuperBoom.status.die) continue;
                foreach (ClassBeeBull BeeBull in BeeBullList)
                {
                    if (BeeBull.Current_BullStatus != ClassBeeBull.status_BullStatus.active) continue;
                    if (SuperBoom.CheskCollision(BeeBull._X, BeeBull._Y, BeeBull._Width, BeeBull._Height))
                    {

                        BeeBull.Current_BullStatus = ClassBeeBull.status_BullStatus.miss;
                    }
                }
            }
        }
        private void timer_Boom_Tick(object sender, EventArgs e)
        {          
            //爆炸回收
            for (int i = BoomList.Count - 1; i >= 0; i--)
            {
                if (BoomList[i].Current_Status == ClassBoom.status.die)
                {
                    //BoomList[i].DisposeSprite();
                    BoomList[i] = null;
                    BoomList.RemoveAt(i);
                }
            }

            //爆炸回收
            for (int i = SuperBoomList.Count - 1; i >= 0; i--)
            {
                if (SuperBoomList[i].Current_Status == ClassSuperBoom.status.die)
                {
                    //SuperBoomList[i].DisposeSprite();
                    SuperBoomList[i] = null;
                    SuperBoomList.RemoveAt(i);
                }
            }

            //Bee與SuperBoom碰撞Check
            foreach (ClassSuperBoom SuperBoom in SuperBoomList)
            {
                if (SuperBoom.Current_Status == ClassSuperBoom.status.die) continue;
                foreach (ClassBee Bee in BeeList)
                {
                    if (Bee.Current_Status != ClassBee.status.active) continue;
                    if (SuperBoom.CheskCollision(Bee._X, Bee._Y, Bee._Width, Bee._Height))
                    {
                        Bee.Bee_Life = 0;
                        if (SuperBoom.Current_Status == ClassSuperBoom.status.active)
                        {
                            Bee.Current_Status = ClassBee.status.kill_bull;
                        }
                        else if (SuperBoom.Current_Status == ClassSuperBoom.status.link)
                        {
                            Bee.Current_Status = ClassBee.status.kill_linkbomb;
                        }
                        //myComputer.Audio.Play(Properties.Resources.Bee_Boom, AudioPlayMode.Background);
                        Get_Scores_Bee();
                        Update_PlayerInfo();
                    }
                }
            }

            //BeeBull與SuperBoom碰撞Check
            foreach (ClassSuperBoom SuperBoom in SuperBoomList)
            {
                if (SuperBoom.Current_Status == ClassSuperBoom.status.die) continue;
                foreach (ClassBeeBull BeeBull in BeeBullList)
                {
                    if (BeeBull.Current_BullStatus != ClassBeeBull.status_BullStatus.active) continue;
                    if (SuperBoom.CheskCollision(BeeBull._X, BeeBull._Y, BeeBull._Width, BeeBull._Height))
                    {

                        BeeBull.Current_BullStatus = ClassBeeBull.status_BullStatus.miss;
                    }
                }
            }


         
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[ Timer Boom  ]^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //重繪timer
        private void Run_Time1()
        {
            if (DieCount > 0) HitCalcu = DieCount / (P1._Player_ShootCount + Miss_Bull / 5 + Miss_Bee);
            lab_HitCalcu.Text = HitCalcu.ToString("P2");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DieCount  >0)  HitCalcu = DieCount / (P1._Player_ShootCount+Miss_Bull/5+Miss_Bee) ;
            lab_HitCalcu.Text = HitCalcu.ToString("P2");
        }
        //計時器
        private void Run_UseTime()
        {
            t += 1; //計時器
            lab_UseTime.Text = GetTime(t);//顯示現在使用時間

            if (P1._PLayer_Invincible == true)//若玩家無敵
            {
                PlayerDie_ResetTIme++;
                if (PlayerDie_ResetTIme >= 350)
                {
                    PlayerDie_ResetTIme = 0;
                    P1._PLayer_Invincible = false;
                }
            }
        }
        private void timer_UseTime_Tick(object sender, EventArgs e)
        {
            t += 1; //計時器
            lab_UseTime.Text = GetTime(t);//顯示現在使用時間

            if (P1._PLayer_Invincible == true)//若玩家無敵
            {
                PlayerDie_ResetTIme++;
                if (PlayerDie_ResetTIme >= 350)
                {
                    PlayerDie_ResetTIme = 0;
                    P1._PLayer_Invincible = false;
                }
            }
        }
        //開始時間間隔
        
        private void timer_StartTime_Tick(object sender, EventArgs e)
        {
           /* if (StartTime < 450) StartTime++;
            else timer_StartTime.Enabled = false; */
        }
        //遊戲結束時間間隔
        private void Run_End()
        {
            if (EndTime < 450)
            {
                EndTime++;
            }
            else
            {
                //timer_EndTime.Enabled = false;
                GameOver();
            }
        }
        private void timer_EndTime_Tick(object sender, EventArgs e)
        {
            if (EndTime < 450)
            {
                EndTime++;
            }
            else
            {
                timer_EndTime.Enabled = false;
                GameOver();
            }
        }
        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[ timer ]^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv[ ** Function ** ]vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

        //設定各Combo狀態
        public void Get_ComboColor(int Combo)
        {
            if (Combo < 5)
            {
                Bee_Add_Random = 0.04 + BeeCount_Up ;
                lab_Combo.ForeColor = Color.Black ;
                lab_Combo.Visible = false;
            }
            else if (Combo >= 10 && Combo < 50)
            {
                Bee_Add_Random = 0.06 + BeeCount_Up;
                lab_Combo.Font = new System.Drawing.Font("微軟正黑體", 11, FontStyle.Bold);
                lab_Combo.ForeColor = Color.MediumPurple;
                lab_Combo.Visible=true;
            }
            else if (Combo >= 50 && Combo < 100)
            {
                Bee_Add_Random = 0.08 + BeeCount_Up;
                lab_Combo.Font = new System.Drawing.Font("微軟正黑體", 12, FontStyle.Bold);
                lab_Combo.ForeColor = Color.BlueViolet ; 
            }
            else if (Combo >= 100 && Combo < 200)
            {
                Bee_Add_Random = 0.13 + BeeCount_Up;
                lab_Combo.Font = new System.Drawing.Font("微軟正黑體", 14, FontStyle.Bold); 
                lab_Combo.ForeColor = Color.ForestGreen;
            }
            else if (Combo >= 200 && Combo < 500)
            {
                Bee_Add_Random = 0.18 + BeeCount_Up;
                lab_Combo.Font = new System.Drawing.Font("微軟正黑體", 15, FontStyle.Bold);
                lab_Combo.ForeColor = Color. PaleGoldenrod ; 
            }
            else if (Combo >= 500 && Combo < 2000)
            {
                Bee_Add_Random = 0.25 + BeeCount_Up;
                lab_Combo.Font = new System.Drawing.Font("微軟正黑體", 18, FontStyle.Bold);
                lab_Combo.ForeColor = Color.LightGreen ;
            }
            else if (Combo >= 2000)
            {
                Bee_Add_Random = 0.3 + BeeCount_Up;
                lab_Combo.Font = new System.Drawing.Font("微軟正黑體", 20, FontStyle.Bold);
                lab_Combo.ForeColor = Color.LightBlue;
            }
   
        }
        //計時器 
        private string GetTime(int gTime)
        {
            string hh, mm, ss, fff;
            int f = gTime % 100;
            int s = gTime / 100;
            int m = s / 60;
            int h = m / 60;
            s = s % 60;
            //毫秒格式00
            if (f < 10) { fff = "0" + f.ToString(); }
            else { fff = f.ToString(); }
            //秒格式00
            if (s < 10) { ss = "0" + s.ToString(); }
            else { ss = s.ToString(); }
            //分格式00
            if (m < 10) { mm = "0" + m.ToString(); }
            else { mm = m.ToString(); }
            //时格式00
            if (h < 10) { hh = "0" + h.ToString(); }
            else { hh = h.ToString(); }
            //返回 hh:mm:ss.ff            
            return hh + ":" + mm + ":" + ss +"." + fff;
        }
        //遊戲結束
        private void GameOver()
        {
           
            /*timer_BossBee.Enabled = false;
            timer_Bee.Enabled = false;
            timer_Bull.Enabled = false;
            timer_Landscape.Enabled = false;
            timer_Boom.Enabled = false;
            timer_Items.Enabled = false;
            timer_UseTime.Enabled = false;
            timer1.Enabled = false;
            timer_Player_Move_Left.Enabled = false;
            timer_Player_Move_Right.Enabled = false;
            timer_StartTime.Enabled = false;*/
            //axWindowsMediaPlayer1.Ctlcontrols.stop();
            BGSound(false);

            double Evalution = ((TotalScores * 10 + DieCount + P1._Player_ShootCount * 5 + (DieCount / (P1._Player_ShootCount + Miss_Bull / 5 + Miss_Bee)) + P1._MaxCombo * 30 + P1._PLayer_NowMoney * 20) /
                                      (Miss_Bee * 100 + Miss_Bull * 50 + PlayerDieCount * 1000 + t * 5));

            Form_PlayerInfo P_I = new Form_PlayerInfo();
            P_I.MainForm = this;
            P_I.lab_Scores_P_Info = lab_Scores.Text;
            P_I.lab_DieCount_P_Info = lab_DieCount.Text;
            P_I.lab_PlayerShootCount_P_Info = lab_Player_ShootCount.Text;
            P_I.lab_Miss_Bee_P_Info = lab_Miss_Bee.Text;
            P_I.lab_Miss_Bull_P_Info = lab_Miss_Bull.Text;
            P_I.lab_PlayerDieCount_P_Info = lab_Player_DieCount.Text;
            P_I.lab_HitCalcu_P_Info = lab_HitCalcu.Text;
            P_I.Hit_Calcu = (float)HitCalcu;
            P_I.lab_UseTime_P_Info = lab_UseTime.Text;
            P_I.lab_MaxCombo_P_Info = lab_MaxCombo.Text;
            P_I.lab_Money_P_Info = lab_Player_NowMoney.Text;
            P_I.lab_Evalution_P_Info = Evalution.ToString("F2");
            //評分表
            if (P_I.ShowDialog() == DialogResult.OK)
            {
                game_Status = status.game_over;
                IsPause = true;
                Form_Main.Fm.btnShow = true;
                this.ParentForm.Show();
                this.Visible = false;
                this.Dispose();
            }

        }
        //圖片設置
        int BmpBoom_Index = 0;
        public Sprite s_PlayerList = null;
        public Sprite s_PlayerDefenseList_L = null;
        public Sprite s_PlayerDefenseList_R = null;
        public Sprite s_Player = null;
        public Sprite s_PlayerBullList = null;
        public Sprite s_PlayerBullLinkbombList = null;
        public Sprite s_BossBeeList = null;
        public Sprite s_BossHitList = null;
        public Sprite s_BeeList = null;
        public Sprite s_BeeBullList = null;
        public Sprite s_BoomList = null;
        public Sprite s_SuperBoomList = null;                
        public Sprite s_ItemsList = null;
        public Sprite s_BossBeeBullList = null;

        public List<Texture> TexPlayerList = new List<Texture>();//定义图片对象
        public List<Texture> TexPlayerDefenseList = new List<Texture>();//定义图片对象
        public Texture TexPlayer = null;//定义图片对象
        public List<Texture> TexPlayerBullList = new List<Texture>();//定义图片对象
        public List<Texture> TexPlayerBullLinkbombList = new List<Texture>();//定义图片对象
        public Texture TexBossBeeList = null;//定义图片对象
        public List<Texture> TexBossHitList = new List<Texture>();//定义图片对象
        public Texture TexBeeList = null;//定义图片对象
        public Texture TexBeeBullList = null;//定义图片对象
        public List<Texture> TexBoomList = new List<Texture>();//定义图片对象
        public List<Texture> TexBoomList_Player = new List<Texture>();//定义图片对象
        public List<Texture> TexBoomList_BossBee = new List<Texture>();//定义图片对象
        public List<Texture> TexSuperBoomList = new List<Texture>();//定义图片对象
        public List<Texture> TexLinkBoomList = new List<Texture>();//定义图片对象
        public List<Texture> TexItemsList = new List<Texture>();//定义图片对象
        public Texture TexBossBeeBullList = null;//定义图片对象

        public void InitailizeImages()
        {
            //PlayerList
            BmpPlayerList.Add(ResizeImage(Properties.Resources.玩家, 60, 45));
            BmpPlayerList.Add(ResizeImage(Properties.Resources.玩家Invincible_1, 60, 45));
            BmpPlayerList.Add(ResizeImage(Properties.Resources.玩家Invincible_2, 60, 45));
            BmpPlayerList.Add(ResizeImage(Properties.Resources.玩家Invincible_1, 60, 45));
            BmpPlayerList.Add(ResizeImage(Properties.Resources.玩家, 60, 45));
            s_PlayerList = new Sprite(gd);
            for (int i = 0; i < BmpPlayerList.Count(); i++)
            {
                TexPlayerList.Add(new Texture(gd, BmpPlayerList[i], 0, Pool.Managed));
            }
            //PlayerDefenseList
            BmpPlayerDefenseList_Left.Add(ResizeImage(Properties.Resources.Defense_L1, 45, 45));
            BmpPlayerDefenseList_Left.Add(ResizeImage(Properties.Resources.Defense_L2, 45, 45));
            BmpPlayerDefenseList_Left.Add(ResizeImage(Properties.Resources.Defense_L3, 45, 45));
            BmpPlayerDefenseList_Right.Add(ResizeImage(Properties.Resources.Defense_R1, 45, 45));
            BmpPlayerDefenseList_Right.Add(ResizeImage(Properties.Resources.Defense_R2, 45, 45));
            BmpPlayerDefenseList_Right.Add(ResizeImage(Properties.Resources.Defense_R3, 45, 45));
            s_PlayerDefenseList_L = new Sprite(gd);
            s_PlayerDefenseList_R = new Sprite(gd);
            for (int i = 0; i < BmpPlayerDefenseList_Left.Count(); i++)
            {
                TexPlayerDefenseList.Add(new Texture(gd, BmpPlayerDefenseList_Left[i], 0, Pool.Managed));
            }
            for (int i = 0; i < BmpPlayerDefenseList_Right.Count(); i++)
            {
                TexPlayerDefenseList.Add(new Texture(gd, BmpPlayerDefenseList_Right[i], 0, Pool.Managed));
            }
         /*   BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense1, 90, 90));
            BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense2, 90, 90));
            BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense3, 90, 90));
            BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense4, 90, 90));
            BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense5, 90, 90));
            BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense6, 90, 90));
            BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense7, 90, 90));
            BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense8, 90, 90));
            BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense9, 90, 90));
            BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense10, 90, 90));
            BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense11, 90, 90));
            BmpPlayerDefenseList.Add(ResizeImage(Properties.Resources.PlayerDefense12, 90, 90));*/
            //載入Player
            P1.SetBmp_Player(BmpPlayerList, BmpPlayerDefenseList_Left,BmpPlayerDefenseList_Right);
            s_Player = new Sprite(gd);
            TexPlayer = new Texture(gd, BmpPlayerList[0], 0, Pool.Managed);
            //PlayerBullListvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
            BmpPlayerBullList.Add(ResizeImage(Properties.Resources.p_bulletS, 10, 20));
            BmpPlayerBullList.Add(ResizeImage(Properties.Resources.p_bulletB, 20, 40));
            BmpPlayerBullList.Add(ResizeImage(Properties.Resources.SuperBomb, 25, 25));
            s_PlayerBullList = new Sprite(gd);
            for (int i = 0; i < BmpPlayerBullList.Count(); i++)
            {
                TexPlayerBullList.Add(new Texture(gd, BmpPlayerBullList[i], 0, Pool.Managed));
            }
            //PlayerBullLinkbombList
            BmpPlayerBullLinkBombList.Add(ResizeImage(Properties.Resources.LinkBomb_10, 40, 40));
            BmpPlayerBullLinkBombList.Add(ResizeImage(Properties.Resources.LinkBomb_11, 35, 35));
            s_PlayerBullLinkbombList = new Sprite(gd);
            for (int i = 0; i < BmpPlayerBullLinkBombList.Count(); i++)
            {
                TexPlayerBullLinkbombList.Add(new Texture(gd, BmpPlayerBullLinkBombList[i], 0, Pool.Managed));
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

            //BossBeeListtvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
            BmpBossBeeList.Add(ResizeImage(Properties.Resources.BossBee ,180,150));
            s_BossBeeList = new Sprite(gd);
            TexBossBeeList = new Texture(gd, BmpBossBeeList[0], 0, Pool.Managed);
            //BossHitList
            BmpBossHitList.Add(ResizeImage(Properties.Resources.Boss_Hit_1, 180, 150));
            BmpBossHitList.Add(ResizeImage(Properties.Resources.Boss_Hit_2, 180, 150));
            BmpBossHitList.Add(ResizeImage(Properties.Resources.Boss_Hit_3, 180, 150));
            BmpBossHitList.Add(ResizeImage(Properties.Resources.Boss_Hit_4, 180, 150));
            BmpBossHitList.Add(ResizeImage(Properties.Resources.Boss_Hit_5, 180, 150));
            Boss1.SetBmp_BossBee(BmpBossBeeList,BmpBossHitList );
            s_BossHitList = new Sprite(gd);
            for (int i = 0; i < BmpBossHitList.Count(); i++)
            {
                TexBossHitList.Add(new Texture(gd, BmpBossHitList[i], 0, Pool.Managed));
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            //BeeList
            BmpBeeList.Add(ResizeImage(Properties.Resources.bee_v1,30,20));
            s_BeeList = new Sprite(gd);
            TexBeeList = new Texture(gd, BmpBeeList[0], 0, Pool.Managed);
            //BeeBullList
            BmpBeeBullList.Add(ResizeImage(Properties.Resources.bee_Shoot, 7, 14));
            s_BeeBullList = new Sprite(gd);
            TexBeeBullList = new Texture(gd, BmpBeeBullList[0], 0, Pool.Managed);

            //BossBeeBullList
            BmpBossBeeBullList.Add(ResizeImage(Properties.Resources.bee_Shoot, 7, 14));
            s_BossBeeBullList = new Sprite(gd);
            TexBossBeeBullList = new Texture(gd, BmpBeeBullList[0], 0, Pool.Managed);
            //BoomList
            BmpBoomList.Add(Properties.Resources.bomb1);
            BmpBoomList.Add(Properties.Resources.bomb2);
            BmpBoomList.Add(Properties.Resources.bomb3);
            BmpBoomList.Add(Properties.Resources.bomb2);
            BmpBoomList.Add(Properties.Resources.bomb1);
            s_BoomList = new Sprite(gd);
            for (int i = 0; i < BmpBoomList.Count(); i++)
            {
                TexBoomList.Add(new Texture(gd, BmpBoomList[i], 0, Pool.Managed));
            }
            //TexBoomList_Player
            BmpBossHitList.Add(ResizeImage(Properties.Resources.bomb1, 60, 45));

            TexBoomList_Player.Add(new Texture(gd, ResizeImage(Properties.Resources.bomb1, 60, 45), 0, Pool.Managed));
            TexBoomList_Player.Add(new Texture(gd, ResizeImage(Properties.Resources.bomb2, 60, 45), 0, Pool.Managed));
            TexBoomList_Player.Add(new Texture(gd, ResizeImage(Properties.Resources.bomb3, 60, 45), 0, Pool.Managed));
            TexBoomList_Player.Add(new Texture(gd, ResizeImage(Properties.Resources.bomb2, 60, 45), 0, Pool.Managed));
            TexBoomList_Player.Add(new Texture(gd, ResizeImage(Properties.Resources.bomb1, 60, 45), 0, Pool.Managed));
            //TexBoomList_BossBee
            TexBoomList_BossBee.Add(new Texture(gd, ResizeImage(Properties.Resources.bomb1, 180, 150), 0, Pool.Managed));
            TexBoomList_BossBee.Add(new Texture(gd, ResizeImage(Properties.Resources.bomb2, 180, 150), 0, Pool.Managed));
            TexBoomList_BossBee.Add(new Texture(gd, ResizeImage(Properties.Resources.bomb3, 180, 150), 0, Pool.Managed));
            TexBoomList_BossBee.Add(new Texture(gd, ResizeImage(Properties.Resources.bomb2, 180, 150), 0, Pool.Managed));
            TexBoomList_BossBee.Add(new Texture(gd, ResizeImage(Properties.Resources.bomb1, 180, 150), 0, Pool.Managed));

            //LinkBoomList
            BmpLinkBoomList.Add(ResizeImage(Properties.Resources.Super_Bomb_1, 120, 80));
            BmpLinkBoomList.Add(ResizeImage(Properties.Resources.Super_Bomb_2, 120, 80));
            BmpLinkBoomList.Add(ResizeImage(Properties.Resources.Super_Bomb_3, 120, 80));
            BmpLinkBoomList.Add(ResizeImage(Properties.Resources.Super_Bomb_4, 120, 80));
            BmpLinkBoomList.Add(ResizeImage(Properties.Resources.Super_Bomb_5, 120, 80));
            BmpLinkBoomList.Add(ResizeImage(Properties.Resources.Super_Bomb_6, 120, 80));
            BmpLinkBoomList.Add(ResizeImage(Properties.Resources.Super_Bomb_7, 120, 80));
            for (int i = 0; i < frameCount; i++)
            {
                BmpBoom_Index %= BmpLinkBoomList.Count;
                TexLinkBoomList.Add(new Texture(gd, BmpLinkBoomList[BmpBoom_Index++], 0, Pool.Managed));
            }
            BmpSuperBoomList.Add(Properties.Resources.Super_Bomb_1);
            BmpSuperBoomList.Add(Properties.Resources.Super_Bomb_2);
            BmpSuperBoomList.Add(Properties.Resources.Super_Bomb_3);
            BmpSuperBoomList.Add(Properties.Resources.Super_Bomb_4);
            BmpSuperBoomList.Add(Properties.Resources.Super_Bomb_5);
            BmpSuperBoomList.Add(Properties.Resources.Super_Bomb_6);
            BmpSuperBoomList.Add(Properties.Resources.Super_Bomb_7);
            s_SuperBoomList = new Sprite(gd);
            for (int i = 0; i < frameCount; i++)
            {
                BmpBoom_Index %= BmpSuperBoomList.Count;
                TexSuperBoomList.Add(new Texture(gd, BmpSuperBoomList[BmpBoom_Index++], 0, Pool.Managed));
            }
            //ItemsList
            BmpItemsList.Add( ResizeImage ( Properties.Resources.增加子彈,20,20));
            BmpItemsList.Add( ResizeImage ( Properties.Resources.子彈變多,20,20));
            BmpItemsList.Add( ResizeImage ( Properties.Resources.PowerBomb,20,20));
            BmpItemsList.Add( ResizeImage ( Properties.Resources.子彈變大,20,20));
            BmpItemsList.Add( ResizeImage ( Properties.Resources.PowerStep,20,20));
            BmpItemsList.Add( ResizeImage ( Properties.Resources.Defense,20,20));
            s_ItemsList = new Sprite(gd);
            for (int i = 0; i < BmpItemsList.Count(); i++)
            {
                TexItemsList.Add(new Texture(gd, BmpItemsList[i], 0, Pool.Managed));
            }
        }
        //ResizeImage
        private static Bitmap ResizeImage(Image ImageToResize, int Width, int Height)
        {
            Bitmap Bmp = new Bitmap(Width,Height);
            using (Graphics G = Graphics.FromImage(Bmp))
            {
                G.DrawImage(ImageToResize, 0, 0, Width, Height);
            }
            return Bmp;
        }
        //擊落BEE 計分
        private void Get_Scores_Bee()
          {
              P1._Combo++; //連擊++
              DieCount++;//擊落BEE++
              if (DieCount % 500 == 0) P1._Player_Life++; //擊落50隻Bee + 1UP
              P1._PLayer_NowMoney += 100;
              P1._Player_NowExp += 90;
              P1.Check_Player_Exp(P1._Player_NowExp, P1._Player_NowLevel);
              TotalScores += 300;
              if (SoundOn) Sound(true);
          }
        //擊落BEE 計分
        private void Get_Scores_BossBee()
        {
            P1._Combo++; //連擊++
            TotalScores += 300;
            
        }
        //更新資訊
        private void Update_PlayerInfo()
          {
              //lab_Bee通過.Text = Boss1._BossBee_Life.ToString();
              lab_Player_Life.Text = P1._Player_Life.ToString();
         
              lab_Player_PowerCount.Text = (P1._Player_PowerCount-PlayerBullList.Count).ToString()+" / " + P1._Player_PowerCount_Limit.ToString();

              lab_Player_Speed.Text = "LEVEL " + (P1._Player_Speed - 2).ToString();
              if (P1._Player_Speed == 3) { lab_Player_Speed.ForeColor = Color.Gold ; }
              else if (P1._Player_Speed == 4) { lab_Player_Speed.ForeColor = Color.LawnGreen; }
              else if (P1._Player_Speed == 5) { lab_Player_Speed.ForeColor = Color.OrangeRed; }
              else if (P1._Player_Speed == 6) { lab_Player_Speed.ForeColor = Color.Red; }
              else if (P1._Player_Speed == 7) { lab_Player_Speed.Text = "MAX"; lab_Player_Speed.ForeColor = Color.LightBlue; }

              lab_Player_PowerUp.Text = "LEVEL " + P1._Player_PowerUp.ToString();
              if (P1._Player_PowerUp == 1) { lab_Player_PowerUp.ForeColor = Color.Gold; }
              else if (P1._Player_PowerUp == 2) { lab_Player_PowerUp.ForeColor = Color.LawnGreen; }
              else if (P1._Player_PowerUp == 3) { lab_Player_PowerUp.ForeColor = Color.PaleGreen; }
              else if (P1._Player_PowerUp == 4) { lab_Player_PowerUp.ForeColor = Color.Orchid; }
              else if (P1._Player_PowerUp == 5) { lab_Player_PowerUp.ForeColor = Color.Red; }
              else if (P1._Player_PowerUp == 6) { lab_Player_PowerUp.Text = "MAX"; lab_Player_PowerUp.ForeColor = Color.LightBlue; }

              if (P1._Player_BigBull) pBox_Player_BigBull.Visible = true;
              else pBox_Player_BigBull.Visible = false;

              if (P1._Player_SuperBomb) pBox_Player_SuperBomb.Visible = true;
              else pBox_Player_SuperBomb.Visible = false;

              if (P1._Player_Defense) pBox_Player_Defense.Visible = true;
              else pBox_Player_Defense.Visible = false;

              if (P1._Combo > P1._MaxCombo) { P1._MaxCombo = P1._Combo; }
              lab_MaxCombo.Text = P1._MaxCombo.ToString();

              Get_ComboColor(P1._Combo);
              lab_Combo.Text = "Combo " + P1._Combo.ToString();
              lab_DieCount.Text = DieCount.ToString();
              lab_Player_DieCount.Text  = PlayerDieCount.ToString();
              lab_Player_NowMoney.Text = P1._PLayer_NowMoney.ToString();
              if (P1._LevelUp_Exp != 0)
              { lab_Player_NowExp.Text = P1._Player_NowExp.ToString() + " / " + (P1._LevelUp_Exp).ToString(); }
              else lab_Player_NowExp.Text = P1._Player_NowExp.ToString() + " / MAX";
              lab_Player_NowLevel.Text = "Lv " + P1._Player_NowLevel.ToString() + "：";
              lab_Player_Life.Text = "X " + P1._Player_Life.ToString();
              lab_Scores.Text = TotalScores.ToString();           
          }
        //玩家死亡 重設
        private void Reset_Player()
          {
              P1.Reset_Player();
              Update_PlayerInfo();
          }
        //玩家BULL CREATE
        private void Create_PlayerBull( int BX, int EX, int Y, bool Big_Bull, ClassPlayerBull.status_BullType Current_BullType, ClassPlayerBull.status_BullStatus Current_BullStatus, List<Bitmap> BmpPlayerBullList, List<Bitmap> BmpPlayerBullLinkBombList)
          {
              ClassPlayerBull PlayerBull = new ClassPlayerBull(gd,BX, EX, Y, Big_Bull, Current_BullType, Current_BullStatus, BmpPlayerBullList, BmpPlayerBullLinkBombList);
              PlayerBullList.Add(PlayerBull);
              P1._Player_ShootCount += 1;
              lab_Player_ShootCount.Text = P1._Player_ShootCount.ToString();
              lab_Player_PowerCount.Text = (P1._Player_PowerCount - PlayerBullList.Count).ToString() + " / " + P1._Player_PowerCount_Limit.ToString(); 
          }
        //等級提升影響BEE出現機率
        private void lab_Player_NowLevel_TextChanged(object sender, EventArgs e)
          {
              switch (P1._Player_NowLevel)
              {
                  case 2:
                      BeeCount_Up += 0.015;
                      break;
                  case 3:
                      BeeCount_Up += 0.025;
                      break;
                  case 4:
                      BeeCount_Up += 0.055;
                      break;
                  case 5:
                      BeeCount_Up += 0.08;
                      break;
                  case 6:
                      BeeCount_Up += 0.1;
                      break;
              }
          }
        //開啟/關閉音樂
        private void BGSound(bool Set)
        {
            //if (Set) axWindowsMediaPlayer1.Ctlcontrols.play();
            //else axWindowsMediaPlayer1.Ctlcontrols.pause();
            if (Set)  // 播放声音
                m_objMediaControl.Run();
            //sndBackGround.Play(0, Microsoft.DirectX.DirectSound.BufferPlayFlags.Default);
            else
                //  sndBackGround.Stop();
                m_objMediaControl.Stop();
        }
        private void Sound(bool Set)
        {
            sndBee_Boom = new Microsoft.DirectX.DirectSound.SecondaryBuffer(Properties.Resources.Bee_Boom, dev);
            sndBee_Boom.Volume = -1000;
            //StringBuilder sb = new StringBuilder();
            //mciSendString("play Bee_Boom.wav", sb, 0, IntPtr.Zero);
            //if (Set) sound_Bee_Die.Play();

             if (Set)  // 播放声音
                 sndBee_Boom.Play(0, Microsoft.DirectX.DirectSound.BufferPlayFlags.Default);
            /* else
                 sndBee_Boom.Stop();*/
        }
        private void PlaySound(bool Set,int xtype)
        {
            // 为声音建立二级缓冲区
            try
            {
                if (xtype == 0)
                {
                    if (Set)  // 播放声音
                        sndBee_Boom.Play(0, Microsoft.DirectX.DirectSound.BufferPlayFlags.Default);
                    else
                        sndBee_Boom.Stop();
                }
                else if (xtype == 1)
                {
                    if (Set)  // 播放声音
                        sndBackGround.Play(0, Microsoft.DirectX.DirectSound.BufferPlayFlags.Default);
                    else
                        sndBackGround.Stop();
                }
                
            }
            catch (Exception ex)
            {
                
            }
        }

        private void Form_Play_MouseDown(object sender, MouseEventArgs e)
        {
            if (!P1.IsVisible) return;
            P1._IsDrag = true;
            P1._X = e.X - P1._Width / 2;
            P1._Y = e.Y - P1._Height / 2;
        }

        private void Form_Play_MouseMove(object sender, MouseEventArgs e)
        {
            if (P1._IsDrag)
            {
                P1._X = e.X-P1._Width/2;
                P1._Y = e.Y-P1._Height/2;
            }
        }

        private void Form_Play_MouseUp(object sender, MouseEventArgs e)
        {
            P1._IsDrag = false; 
        }

        private void Form_Play_Shown(object sender, EventArgs e)
        {
            if (InitializeDirect3D() == false) //检查Direct3D是否启动
            {
                MessageBox.Show("无法启动Direct3D！", "错误！");
                return;
            }
            while (game_Status == status.game_start ) //设置一个循环用于实时更新渲染状态
            {
                //&&  (!P1._GameOver)
                Thread.Sleep(1);
                if (System.Environment.TickCount > r_lastTime)
                {
                    Run();
                    r_lastTime = System.Environment.TickCount + r_timeDelta;	// 「上次主體運算時間」
                }
                if (System.Environment.TickCount > lastTime)
                {

                    Render(); //保持device渲染，直到程序结束
                    lastTime = System.Environment.TickCount + m_timeDelta;	// 「上次繪圖時間」
                    countFPS++;
                    if (System.Environment.TickCount > glastTime)
                    {
                        // 更新FPS數據
                        UpdateFPS(countFPS);
                        countFPS = 0;
                        // 下次追蹤FPS的時間
                        glastTime = System.Environment.TickCount + gm_timeDelta;
                    }
                }

                Application.DoEvents(); //处理键盘鼠标等输入事件
            }
        }

        private void Form_Play_FormClosing(object sender, FormClosingEventArgs e)
        {
            game_Status = status.game_over;
        }
        




        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^[ ** Function ** ]^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^







   }
}
