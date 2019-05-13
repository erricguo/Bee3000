namespace BeeBeeBee
{
    partial class Form_PlayerInfo
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
            this.lab_Money = new System.Windows.Forms.Label();
            this.lab_金錢 = new System.Windows.Forms.Label();
            this.lab_MaxCombo = new System.Windows.Forms.Label();
            this.lab_最大連擊 = new System.Windows.Forms.Label();
            this.lab_HitCalcu = new System.Windows.Forms.Label();
            this.lab_Miss機率 = new System.Windows.Forms.Label();
            this.lab_PlayerDieCount = new System.Windows.Forms.Label();
            this.lab_死亡次數 = new System.Windows.Forms.Label();
            this.lab_Miss_Bee = new System.Windows.Forms.Label();
            this.lab_Bee通過 = new System.Windows.Forms.Label();
            this.lab_Miss_Bull = new System.Windows.Forms.Label();
            this.lab_未擊中 = new System.Windows.Forms.Label();
            this.lab_PlayerShootCount = new System.Windows.Forms.Label();
            this.lab_發射彈數 = new System.Windows.Forms.Label();
            this.lab_UseTime = new System.Windows.Forms.Label();
            this.lab_DieCount = new System.Windows.Forms.Label();
            this.lab_Scores = new System.Windows.Forms.Label();
            this.lab使用時間 = new System.Windows.Forms.Label();
            this.lab擊落總數 = new System.Windows.Forms.Label();
            this.lab_得分 = new System.Windows.Forms.Label();
            this.lab_Evalution = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lab_姓名 = new System.Windows.Forms.Label();
            this.tBox_Name = new System.Windows.Forms.TextBox();
            this.btn_確定 = new System.Windows.Forms.Button();
            this.bee3000DBDataSet = new BeeBeeBee.Bee3000DBDataSet();
            this.beeInfoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bee_InfoTableAdapter1 = new BeeBeeBee.Bee3000DBDataSetTableAdapters.Bee_InfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bee3000DBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beeInfoBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_Money
            // 
            this.lab_Money.BackColor = System.Drawing.Color.Transparent;
            this.lab_Money.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Money.ForeColor = System.Drawing.Color.Black;
            this.lab_Money.Location = new System.Drawing.Point(101, 289);
            this.lab_Money.Name = "lab_Money";
            this.lab_Money.Size = new System.Drawing.Size(102, 12);
            this.lab_Money.TabIndex = 52;
            this.lab_Money.Text = "0";
            this.lab_Money.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_金錢
            // 
            this.lab_金錢.AutoSize = true;
            this.lab_金錢.BackColor = System.Drawing.Color.Transparent;
            this.lab_金錢.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_金錢.ForeColor = System.Drawing.Color.Black;
            this.lab_金錢.Location = new System.Drawing.Point(76, 289);
            this.lab_金錢.Name = "lab_金錢";
            this.lab_金錢.Size = new System.Drawing.Size(26, 13);
            this.lab_金錢.TabIndex = 51;
            this.lab_金錢.Text = "$：";
            // 
            // lab_MaxCombo
            // 
            this.lab_MaxCombo.BackColor = System.Drawing.Color.Transparent;
            this.lab_MaxCombo.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_MaxCombo.ForeColor = System.Drawing.Color.Black;
            this.lab_MaxCombo.Location = new System.Drawing.Point(101, 259);
            this.lab_MaxCombo.Name = "lab_MaxCombo";
            this.lab_MaxCombo.Size = new System.Drawing.Size(102, 12);
            this.lab_MaxCombo.TabIndex = 50;
            this.lab_MaxCombo.Text = "0";
            this.lab_MaxCombo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_最大連擊
            // 
            this.lab_最大連擊.AutoSize = true;
            this.lab_最大連擊.BackColor = System.Drawing.Color.Transparent;
            this.lab_最大連擊.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_最大連擊.ForeColor = System.Drawing.Color.Black;
            this.lab_最大連擊.Location = new System.Drawing.Point(24, 259);
            this.lab_最大連擊.Name = "lab_最大連擊";
            this.lab_最大連擊.Size = new System.Drawing.Size(78, 13);
            this.lab_最大連擊.TabIndex = 49;
            this.lab_最大連擊.Text = "MaxCmobo：";
            // 
            // lab_HitCalcu
            // 
            this.lab_HitCalcu.BackColor = System.Drawing.Color.Transparent;
            this.lab_HitCalcu.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_HitCalcu.ForeColor = System.Drawing.Color.Black;
            this.lab_HitCalcu.Location = new System.Drawing.Point(101, 199);
            this.lab_HitCalcu.Name = "lab_HitCalcu";
            this.lab_HitCalcu.Size = new System.Drawing.Size(102, 12);
            this.lab_HitCalcu.TabIndex = 48;
            this.lab_HitCalcu.Text = "0";
            this.lab_HitCalcu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_Miss機率
            // 
            this.lab_Miss機率.AutoSize = true;
            this.lab_Miss機率.BackColor = System.Drawing.Color.Transparent;
            this.lab_Miss機率.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Miss機率.ForeColor = System.Drawing.Color.Black;
            this.lab_Miss機率.Location = new System.Drawing.Point(32, 199);
            this.lab_Miss機率.Name = "lab_Miss機率";
            this.lab_Miss機率.Size = new System.Drawing.Size(70, 13);
            this.lab_Miss機率.TabIndex = 47;
            this.lab_Miss機率.Text = "Hit   機率：";
            // 
            // lab_PlayerDieCount
            // 
            this.lab_PlayerDieCount.BackColor = System.Drawing.Color.Transparent;
            this.lab_PlayerDieCount.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_PlayerDieCount.ForeColor = System.Drawing.Color.Black;
            this.lab_PlayerDieCount.Location = new System.Drawing.Point(101, 169);
            this.lab_PlayerDieCount.Name = "lab_PlayerDieCount";
            this.lab_PlayerDieCount.Size = new System.Drawing.Size(102, 12);
            this.lab_PlayerDieCount.TabIndex = 46;
            this.lab_PlayerDieCount.Text = "0";
            this.lab_PlayerDieCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_死亡次數
            // 
            this.lab_死亡次數.AutoSize = true;
            this.lab_死亡次數.BackColor = System.Drawing.Color.Transparent;
            this.lab_死亡次數.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_死亡次數.ForeColor = System.Drawing.Color.Black;
            this.lab_死亡次數.Location = new System.Drawing.Point(30, 169);
            this.lab_死亡次數.Name = "lab_死亡次數";
            this.lab_死亡次數.Size = new System.Drawing.Size(72, 13);
            this.lab_死亡次數.TabIndex = 45;
            this.lab_死亡次數.Text = "死亡次數：";
            // 
            // lab_Miss_Bee
            // 
            this.lab_Miss_Bee.BackColor = System.Drawing.Color.Transparent;
            this.lab_Miss_Bee.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Miss_Bee.ForeColor = System.Drawing.Color.Black;
            this.lab_Miss_Bee.Location = new System.Drawing.Point(101, 109);
            this.lab_Miss_Bee.Name = "lab_Miss_Bee";
            this.lab_Miss_Bee.Size = new System.Drawing.Size(102, 12);
            this.lab_Miss_Bee.TabIndex = 44;
            this.lab_Miss_Bee.Text = "0";
            this.lab_Miss_Bee.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_Bee通過
            // 
            this.lab_Bee通過.AutoSize = true;
            this.lab_Bee通過.BackColor = System.Drawing.Color.Transparent;
            this.lab_Bee通過.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Bee通過.ForeColor = System.Drawing.Color.Black;
            this.lab_Bee通過.Location = new System.Drawing.Point(29, 109);
            this.lab_Bee通過.Name = "lab_Bee通過";
            this.lab_Bee通過.Size = new System.Drawing.Size(73, 13);
            this.lab_Bee通過.TabIndex = 43;
            this.lab_Bee通過.Text = "Bee   通過：";
            // 
            // lab_Miss_Bull
            // 
            this.lab_Miss_Bull.BackColor = System.Drawing.Color.Transparent;
            this.lab_Miss_Bull.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Miss_Bull.ForeColor = System.Drawing.Color.Black;
            this.lab_Miss_Bull.Location = new System.Drawing.Point(101, 139);
            this.lab_Miss_Bull.Name = "lab_Miss_Bull";
            this.lab_Miss_Bull.Size = new System.Drawing.Size(102, 12);
            this.lab_Miss_Bull.TabIndex = 42;
            this.lab_Miss_Bull.Text = "0";
            this.lab_Miss_Bull.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_未擊中
            // 
            this.lab_未擊中.AutoSize = true;
            this.lab_未擊中.BackColor = System.Drawing.Color.Transparent;
            this.lab_未擊中.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_未擊中.ForeColor = System.Drawing.Color.Black;
            this.lab_未擊中.Location = new System.Drawing.Point(31, 139);
            this.lab_未擊中.Name = "lab_未擊中";
            this.lab_未擊中.Size = new System.Drawing.Size(71, 13);
            this.lab_未擊中.TabIndex = 41;
            this.lab_未擊中.Text = "未  擊  中：";
            // 
            // lab_PlayerShootCount
            // 
            this.lab_PlayerShootCount.BackColor = System.Drawing.Color.Transparent;
            this.lab_PlayerShootCount.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_PlayerShootCount.ForeColor = System.Drawing.Color.Black;
            this.lab_PlayerShootCount.Location = new System.Drawing.Point(101, 79);
            this.lab_PlayerShootCount.Name = "lab_PlayerShootCount";
            this.lab_PlayerShootCount.Size = new System.Drawing.Size(102, 12);
            this.lab_PlayerShootCount.TabIndex = 40;
            this.lab_PlayerShootCount.Text = "0";
            this.lab_PlayerShootCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_發射彈數
            // 
            this.lab_發射彈數.AutoSize = true;
            this.lab_發射彈數.BackColor = System.Drawing.Color.Transparent;
            this.lab_發射彈數.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_發射彈數.ForeColor = System.Drawing.Color.Black;
            this.lab_發射彈數.Location = new System.Drawing.Point(30, 79);
            this.lab_發射彈數.Name = "lab_發射彈數";
            this.lab_發射彈數.Size = new System.Drawing.Size(72, 13);
            this.lab_發射彈數.TabIndex = 39;
            this.lab_發射彈數.Text = "發射彈數：";
            // 
            // lab_UseTime
            // 
            this.lab_UseTime.BackColor = System.Drawing.Color.Transparent;
            this.lab_UseTime.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_UseTime.ForeColor = System.Drawing.Color.Black;
            this.lab_UseTime.Location = new System.Drawing.Point(101, 229);
            this.lab_UseTime.Name = "lab_UseTime";
            this.lab_UseTime.Size = new System.Drawing.Size(102, 12);
            this.lab_UseTime.TabIndex = 38;
            this.lab_UseTime.Text = "0";
            this.lab_UseTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_DieCount
            // 
            this.lab_DieCount.BackColor = System.Drawing.Color.Transparent;
            this.lab_DieCount.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_DieCount.ForeColor = System.Drawing.Color.Black;
            this.lab_DieCount.Location = new System.Drawing.Point(101, 49);
            this.lab_DieCount.Name = "lab_DieCount";
            this.lab_DieCount.Size = new System.Drawing.Size(102, 12);
            this.lab_DieCount.TabIndex = 37;
            this.lab_DieCount.Text = "0";
            this.lab_DieCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab_Scores
            // 
            this.lab_Scores.BackColor = System.Drawing.Color.Transparent;
            this.lab_Scores.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Scores.ForeColor = System.Drawing.Color.Black;
            this.lab_Scores.Location = new System.Drawing.Point(101, 19);
            this.lab_Scores.Name = "lab_Scores";
            this.lab_Scores.Size = new System.Drawing.Size(102, 12);
            this.lab_Scores.TabIndex = 36;
            this.lab_Scores.Text = "0";
            this.lab_Scores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lab使用時間
            // 
            this.lab使用時間.AutoSize = true;
            this.lab使用時間.BackColor = System.Drawing.Color.Transparent;
            this.lab使用時間.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab使用時間.ForeColor = System.Drawing.Color.Black;
            this.lab使用時間.Location = new System.Drawing.Point(30, 229);
            this.lab使用時間.Name = "lab使用時間";
            this.lab使用時間.Size = new System.Drawing.Size(72, 13);
            this.lab使用時間.TabIndex = 35;
            this.lab使用時間.Text = "使用時間：";
            // 
            // lab擊落總數
            // 
            this.lab擊落總數.AutoSize = true;
            this.lab擊落總數.BackColor = System.Drawing.Color.Transparent;
            this.lab擊落總數.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab擊落總數.ForeColor = System.Drawing.Color.Black;
            this.lab擊落總數.Location = new System.Drawing.Point(30, 49);
            this.lab擊落總數.Name = "lab擊落總數";
            this.lab擊落總數.Size = new System.Drawing.Size(72, 13);
            this.lab擊落總數.TabIndex = 34;
            this.lab擊落總數.Text = "擊落總數：";
            // 
            // lab_得分
            // 
            this.lab_得分.AutoSize = true;
            this.lab_得分.BackColor = System.Drawing.Color.Transparent;
            this.lab_得分.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_得分.ForeColor = System.Drawing.Color.Black;
            this.lab_得分.Location = new System.Drawing.Point(30, 19);
            this.lab_得分.Name = "lab_得分";
            this.lab_得分.Size = new System.Drawing.Size(72, 13);
            this.lab_得分.TabIndex = 33;
            this.lab_得分.Text = "得　　分：";
            // 
            // lab_Evalution
            // 
            this.lab_Evalution.BackColor = System.Drawing.Color.Transparent;
            this.lab_Evalution.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_Evalution.ForeColor = System.Drawing.Color.Black;
            this.lab_Evalution.Location = new System.Drawing.Point(101, 319);
            this.lab_Evalution.Name = "lab_Evalution";
            this.lab_Evalution.Size = new System.Drawing.Size(102, 12);
            this.lab_Evalution.TabIndex = 54;
            this.lab_Evalution.Text = "0";
            this.lab_Evalution.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(30, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "綜合評價：";
            // 
            // lab_姓名
            // 
            this.lab_姓名.AutoSize = true;
            this.lab_姓名.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lab_姓名.Location = new System.Drawing.Point(4, 351);
            this.lab_姓名.Name = "lab_姓名";
            this.lab_姓名.Size = new System.Drawing.Size(98, 13);
            this.lab_姓名.TabIndex = 55;
            this.lab_姓名.Text = "輸入您的姓名：";
            // 
            // tBox_Name
            // 
            this.tBox_Name.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tBox_Name.Location = new System.Drawing.Point(102, 345);
            this.tBox_Name.MaxLength = 50;
            this.tBox_Name.Name = "tBox_Name";
            this.tBox_Name.Size = new System.Drawing.Size(101, 23);
            this.tBox_Name.TabIndex = 56;
            // 
            // btn_確定
            // 
            this.btn_確定.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_確定.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_確定.Location = new System.Drawing.Point(74, 390);
            this.btn_確定.Name = "btn_確定";
            this.btn_確定.Size = new System.Drawing.Size(75, 23);
            this.btn_確定.TabIndex = 57;
            this.btn_確定.Text = "確定";
            this.btn_確定.UseVisualStyleBackColor = true;
            this.btn_確定.Click += new System.EventHandler(this.btn_確定_Click);
            // 
            // bee3000DBDataSet
            // 
            this.bee3000DBDataSet.DataSetName = "Bee3000DBDataSet";
            this.bee3000DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // beeInfoBindingSource1
            // 
            this.beeInfoBindingSource1.DataMember = "Bee_Info";
            this.beeInfoBindingSource1.DataSource = this.bee3000DBDataSet;
            // 
            // bee_InfoTableAdapter1
            // 
            this.bee_InfoTableAdapter1.ClearBeforeFill = true;
            // 
            // Form_PlayerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 430);
            this.Controls.Add(this.btn_確定);
            this.Controls.Add(this.tBox_Name);
            this.Controls.Add(this.lab_姓名);
            this.Controls.Add(this.lab_Evalution);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lab_Money);
            this.Controls.Add(this.lab_金錢);
            this.Controls.Add(this.lab_MaxCombo);
            this.Controls.Add(this.lab_最大連擊);
            this.Controls.Add(this.lab_HitCalcu);
            this.Controls.Add(this.lab_Miss機率);
            this.Controls.Add(this.lab_PlayerDieCount);
            this.Controls.Add(this.lab_死亡次數);
            this.Controls.Add(this.lab_Miss_Bee);
            this.Controls.Add(this.lab_Bee通過);
            this.Controls.Add(this.lab_Miss_Bull);
            this.Controls.Add(this.lab_未擊中);
            this.Controls.Add(this.lab_PlayerShootCount);
            this.Controls.Add(this.lab_發射彈數);
            this.Controls.Add(this.lab_UseTime);
            this.Controls.Add(this.lab_DieCount);
            this.Controls.Add(this.lab_Scores);
            this.Controls.Add(this.lab使用時間);
            this.Controls.Add(this.lab擊落總數);
            this.Controls.Add(this.lab_得分);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_PlayerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "詳細資訊";
            this.Load += new System.EventHandler(this.Form_PlayerInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bee3000DBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beeInfoBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_Money;
        private System.Windows.Forms.Label lab_金錢;
        private System.Windows.Forms.Label lab_MaxCombo;
        private System.Windows.Forms.Label lab_最大連擊;
        private System.Windows.Forms.Label lab_HitCalcu;
        private System.Windows.Forms.Label lab_Miss機率;
        private System.Windows.Forms.Label lab_PlayerDieCount;
        private System.Windows.Forms.Label lab_死亡次數;
        private System.Windows.Forms.Label lab_Miss_Bee;
        private System.Windows.Forms.Label lab_Bee通過;
        private System.Windows.Forms.Label lab_Miss_Bull;
        private System.Windows.Forms.Label lab_未擊中;
        private System.Windows.Forms.Label lab_PlayerShootCount;
        private System.Windows.Forms.Label lab_發射彈數;
        private System.Windows.Forms.Label lab_UseTime;
        private System.Windows.Forms.Label lab_DieCount;
        private System.Windows.Forms.Label lab_Scores;
        private System.Windows.Forms.Label lab使用時間;
        private System.Windows.Forms.Label lab擊落總數;
        private System.Windows.Forms.Label lab_得分;
        private System.Windows.Forms.Label lab_Evalution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lab_姓名;
        private System.Windows.Forms.TextBox tBox_Name;
        private System.Windows.Forms.Button btn_確定;
        private Bee3000DBDataSet bee3000DBDataSet;
        private System.Windows.Forms.BindingSource beeInfoBindingSource1;
        private Bee3000DBDataSetTableAdapters.Bee_InfoTableAdapter bee_InfoTableAdapter1;
    }
}