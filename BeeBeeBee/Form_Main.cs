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
    public partial class Form_Main : Form
    {
        public static Form_Main Fm = null;
        
        public Form_Main()
        {
            InitializeComponent();
        }
        public bool btnShow
        {
            set 
            {
                btn_Board.Visible = value;
                btn_GameStart.Visible=value;
                btn_GameFinishi.Visible = value;
            }
        }
        private void btn_GameStart_Click(object sender, EventArgs e)
        {
            this.btnShow = false;
            /*Form_Main f1 = new Form_Main();
            f1.Hide();*/
            Form_Play f2 = new Form_Play();
            f2.FormBorderStyle = FormBorderStyle.None;
            f2.MdiParent = this;
            f2.Show();
         /*   Form_GameTips f3 = new Form_GameTips();
            f3.MdiParent = this;
            f3.Show();*/
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            Fm = this;
            this.Invalidate();
            
            
        }

        private void btn_GameFinishi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Board_Click(object sender, EventArgs e)
        {
            //this.btnShow = false;
            //Form_Info Info = new Form_Info();
            //Info.ShowDialog();
        }

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) SendKeys.Send("{Up}");
            if (e.KeyCode == Keys.S) SendKeys.Send("{Down}"); 
        }

        private void Form_Main_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            G.DrawImage(Properties.Resources.BossBee, 200, 200);
        }

   }
}
