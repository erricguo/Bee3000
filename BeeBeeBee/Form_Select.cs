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
    public partial class Form_Select : Form
    {
        DialogResult result=new DialogResult();
        public Form_Select()
        {
            InitializeComponent();
        }

        private void Form_Select_Load(object sender, EventArgs e)
        {

        }
        public DialogResult Rs
        {
            get { return result; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            SendKeys.Send("{I}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_BackToTitle Fb = new Form_BackToTitle();
          //  Fb.ShowDialog();
           // result = MessageBox.Show("確定要返回主選單?", "返回主選單", MessageBoxButtons.OKCancel);
            if (Fb.ShowDialog() == DialogResult.OK )
            {
                SendKeys.Send("{I}");
                result = DialogResult.OK;
            }
        }

        private void Form_Select_FormClosed(object sender, FormClosedEventArgs e)
        {            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_ExitGame Fe = new Form_ExitGame();
           // DialogResult result = MessageBox.Show("確定要離開遊戲?", "離開遊戲", MessageBoxButtons.OKCancel);
            if (Fe.ShowDialog()  == DialogResult.OK)
            {
                 Application.Exit();
            }
        }

        private void Form_Select_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { SendKeys.Send("{Up}"); }
            if (e.KeyCode == Keys.S) { SendKeys.Send("{Down}"); }
        }


    }
}
