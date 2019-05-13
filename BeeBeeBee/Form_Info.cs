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
    public partial class Form_Info : Form
    {
        public Form_Info()
        {
            InitializeComponent();
        }

        private void Form_Info_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'bee3000DBDataSet.Bee_Info' 資料表。您可以視需要進行移動或移除。
            this.bee_InfoTableAdapter1.Fill(this.bee3000DBDataSet.Bee_Info);
           
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Form_Main.Fm.btnShow = true;
            this.Dispose();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.bee_InfoTableAdapter1.Fill(this.bee3000DBDataSet.Bee_Info);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
