using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BeeBeeBee
{
    public partial class Form_PlayerInfo : Form
    {
        DialogResult result = new DialogResult();
        float  Hit=0;
     //   float Eva = 0;
        public Form_Play MainForm;
        public Form_PlayerInfo()
        {
            InitializeComponent();
        }
        public float Hit_Calcu
        {
            get { return Hit; }
            set { Hit = value; }
        }
   /*     public float Eva_Value
        {
            get { return Eva_Value ; }
            set { Eva_Value  = value; }
        }*/
        public DialogResult Rs
        {
            get { return result; }
        }
        public string lab_Scores_P_Info
        {
            get { return lab_Scores.Text ; }
            set { lab_Scores.Text = value; }
        }
        public string lab_DieCount_P_Info
        {
            get { return lab_DieCount.Text; }
            set { lab_DieCount.Text = value; }
        }
        public string lab_PlayerShootCount_P_Info
        {
            get { return lab_PlayerShootCount.Text; }
            set { lab_PlayerShootCount.Text = value; }
        }
        public string lab_Miss_Bee_P_Info
        {
            get { return lab_Miss_Bee.Text; }
            set { lab_Miss_Bee.Text = value; }
        }
        public string lab_Miss_Bull_P_Info
        {
            get { return lab_Miss_Bull.Text; }
            set { lab_Miss_Bull.Text = value; }
        }
        public string lab_PlayerDieCount_P_Info
        {
            get { return lab_PlayerDieCount.Text; }
            set { lab_PlayerDieCount.Text = value; }
        }
        public string lab_HitCalcu_P_Info
        {
            get { return lab_HitCalcu.Text; }
            set { lab_HitCalcu.Text = value; }
        }
        public string lab_UseTime_P_Info
        {
            get { return lab_UseTime.Text; }
            set { lab_UseTime.Text = value; }
        }
        public string lab_MaxCombo_P_Info
        {
            get { return lab_MaxCombo.Text; }
            set { lab_MaxCombo.Text = value; }
        }
        public string lab_Money_P_Info
        {
            get { return lab_Money.Text; }
            set { lab_Money.Text = value; }
        }
        public string lab_Evalution_P_Info
        {
            get { return lab_Evalution.Text ; }
            set { lab_Evalution.Text = value; }
        }
        private void Form_PlayerInfo_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'beeDBDataSet.Bee_Info' 資料表。您可以視需要進行移動或移除。
            return;
            this.bee_InfoTableAdapter1.Fill(this.bee3000DBDataSet.Bee_Info);
        }

        private void btn_確定_Click(object sender, EventArgs e)
        {
            return;
            if (tBox_Name.Text == "")
            { 
                lab_姓名.ForeColor = Color.Red;
                return;
            }
            try
            {
                using (SqlConnection cn = new SqlConnection(Properties.Settings.Default.Bee3000DBConnectionString))
                {
                    cn.Open();

                   string sqlStr = "INSERT INTO Bee_Info(姓名,得分,擊落總數,發射彈數,Bee通過,未擊中,死亡次數,Hit機率,使用時間,MaxCombo,Money,綜合評價,日期)" +
                                                        "VALUES(@Name,@Scores,@DieCount,@PlayerShootCount,@Miss_Bee,@Miss_Bull,@PlayerDieCount,@HitCalcu,@UseTime,@MaxCombo,@Money,@Evalution,@NowTime)";

                    SqlCommand cmd = new SqlCommand(sqlStr, cn);
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@Scores", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@DieCount", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@PlayerShootCount", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Miss_Bee", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Miss_Bull", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@PlayerDieCount", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@HitCalcu", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlParameter("@UseTime", SqlDbType.Time));
                    cmd.Parameters.Add(new SqlParameter("@MaxCombo", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Money", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Evalution", SqlDbType.Float));
                    cmd.Parameters.Add(new SqlParameter("@NowTime", SqlDbType.DateTime));

                    cmd.Parameters["@Name"].Value = tBox_Name.Text;
                    cmd.Parameters["@Scores"].Value = int.Parse( lab_Scores.Text );
                    cmd.Parameters["@DieCount"].Value = int.Parse(lab_DieCount.Text);
                    cmd.Parameters["@PlayerShootCount"].Value = int.Parse(lab_PlayerShootCount.Text);
                    cmd.Parameters["@Miss_Bee"].Value = int.Parse(lab_Miss_Bee.Text);
                    cmd.Parameters["@Miss_Bull"].Value = int.Parse(lab_Miss_Bull.Text);
                    cmd.Parameters["@PlayerDieCount"].Value = int.Parse(lab_PlayerDieCount.Text);
                    cmd.Parameters["@HitCalcu"].Value = Hit;
                    cmd.Parameters["@UseTime"].Value = lab_UseTime.Text;
                    cmd.Parameters["@MaxCombo"].Value = int.Parse(lab_MaxCombo.Text);
                    cmd.Parameters["@Money"].Value = int.Parse(lab_Money.Text);
                    cmd.Parameters["@Evalution"].Value = float.Parse(lab_Evalution.Text);
                    cmd.Parameters["@NowTime"].Value = DateTime.Now;

                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("資料更新成功!!");
                    cn.Close();
                    this.Close();
                    result = DialogResult.OK;
                    Form_Info Info = new Form_Info();
                    Info.ShowDialog();
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ", 新增資料發生錯誤");
            }
        }


    }
}
