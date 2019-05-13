namespace BeeBeeBee
{
    partial class Form_Info
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.綜合評價DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.得分DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxComboDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.使用時間DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hit機率DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.擊落總數DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.發射彈數DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bee通過DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.未擊中DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.死亡次數DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beeInfoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bee3000DBDataSet = new BeeBeeBee.Bee3000DBDataSet();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.bee_InfoTableAdapter1 = new BeeBeeBee.Bee3000DBDataSetTableAdapters.Bee_InfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.beeInfoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bee3000DBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.日期,
            this.姓名DataGridViewTextBoxColumn,
            this.綜合評價DataGridViewTextBoxColumn,
            this.得分DataGridViewTextBoxColumn,
            this.maxComboDataGridViewTextBoxColumn,
            this.使用時間DataGridViewTextBoxColumn,
            this.hit機率DataGridViewTextBoxColumn,
            this.擊落總數DataGridViewTextBoxColumn,
            this.發射彈數DataGridViewTextBoxColumn,
            this.bee通過DataGridViewTextBoxColumn,
            this.未擊中DataGridViewTextBoxColumn,
            this.死亡次數DataGridViewTextBoxColumn,
            this.moneyDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.beeInfoBindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(734, 460);
            this.dataGridView1.TabIndex = 0;
            // 
            // 日期
            // 
            this.日期.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.日期.DataPropertyName = "日期";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.日期.DefaultCellStyle = dataGridViewCellStyle1;
            this.日期.HeaderText = "日期";
            this.日期.Name = "日期";
            this.日期.ReadOnly = true;
            this.日期.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.日期.Width = 54;
            // 
            // 姓名DataGridViewTextBoxColumn
            // 
            this.姓名DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.姓名DataGridViewTextBoxColumn.DataPropertyName = "姓名";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.NullValue = null;
            this.姓名DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.姓名DataGridViewTextBoxColumn.HeaderText = "姓名";
            this.姓名DataGridViewTextBoxColumn.MaxInputLength = 50;
            this.姓名DataGridViewTextBoxColumn.Name = "姓名DataGridViewTextBoxColumn";
            this.姓名DataGridViewTextBoxColumn.ReadOnly = true;
            this.姓名DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.姓名DataGridViewTextBoxColumn.Width = 54;
            // 
            // 綜合評價DataGridViewTextBoxColumn
            // 
            this.綜合評價DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.綜合評價DataGridViewTextBoxColumn.DataPropertyName = "綜合評價";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.Format = "0.00";
            dataGridViewCellStyle3.NullValue = null;
            this.綜合評價DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.綜合評價DataGridViewTextBoxColumn.HeaderText = "綜合評價";
            this.綜合評價DataGridViewTextBoxColumn.Name = "綜合評價DataGridViewTextBoxColumn";
            this.綜合評價DataGridViewTextBoxColumn.ReadOnly = true;
            this.綜合評價DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.綜合評價DataGridViewTextBoxColumn.Width = 78;
            // 
            // 得分DataGridViewTextBoxColumn
            // 
            this.得分DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.得分DataGridViewTextBoxColumn.DataPropertyName = "得分";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.得分DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.得分DataGridViewTextBoxColumn.HeaderText = "得分";
            this.得分DataGridViewTextBoxColumn.Name = "得分DataGridViewTextBoxColumn";
            this.得分DataGridViewTextBoxColumn.ReadOnly = true;
            this.得分DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.得分DataGridViewTextBoxColumn.Width = 54;
            // 
            // maxComboDataGridViewTextBoxColumn
            // 
            this.maxComboDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.maxComboDataGridViewTextBoxColumn.DataPropertyName = "MaxCombo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.SteelBlue;
            this.maxComboDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.maxComboDataGridViewTextBoxColumn.HeaderText = "MaxCombo";
            this.maxComboDataGridViewTextBoxColumn.Name = "maxComboDataGridViewTextBoxColumn";
            this.maxComboDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxComboDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.maxComboDataGridViewTextBoxColumn.Width = 86;
            // 
            // 使用時間DataGridViewTextBoxColumn
            // 
            this.使用時間DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.使用時間DataGridViewTextBoxColumn.DataPropertyName = "使用時間";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.NullValue = null;
            this.使用時間DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.使用時間DataGridViewTextBoxColumn.HeaderText = "使用時間";
            this.使用時間DataGridViewTextBoxColumn.MaxInputLength = 11;
            this.使用時間DataGridViewTextBoxColumn.Name = "使用時間DataGridViewTextBoxColumn";
            this.使用時間DataGridViewTextBoxColumn.ReadOnly = true;
            this.使用時間DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.使用時間DataGridViewTextBoxColumn.Width = 78;
            // 
            // hit機率DataGridViewTextBoxColumn
            // 
            this.hit機率DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.hit機率DataGridViewTextBoxColumn.DataPropertyName = "Hit機率";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle7.Format = "0.00%";
            dataGridViewCellStyle7.NullValue = null;
            this.hit機率DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.hit機率DataGridViewTextBoxColumn.HeaderText = "Hit機率";
            this.hit機率DataGridViewTextBoxColumn.Name = "hit機率DataGridViewTextBoxColumn";
            this.hit機率DataGridViewTextBoxColumn.ReadOnly = true;
            this.hit機率DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.hit機率DataGridViewTextBoxColumn.Width = 68;
            // 
            // 擊落總數DataGridViewTextBoxColumn
            // 
            this.擊落總數DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.擊落總數DataGridViewTextBoxColumn.DataPropertyName = "擊落總數";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.擊落總數DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.擊落總數DataGridViewTextBoxColumn.HeaderText = "擊落總數";
            this.擊落總數DataGridViewTextBoxColumn.Name = "擊落總數DataGridViewTextBoxColumn";
            this.擊落總數DataGridViewTextBoxColumn.ReadOnly = true;
            this.擊落總數DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.擊落總數DataGridViewTextBoxColumn.Width = 78;
            // 
            // 發射彈數DataGridViewTextBoxColumn
            // 
            this.發射彈數DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.發射彈數DataGridViewTextBoxColumn.DataPropertyName = "發射彈數";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.發射彈數DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.發射彈數DataGridViewTextBoxColumn.HeaderText = "發射彈數";
            this.發射彈數DataGridViewTextBoxColumn.Name = "發射彈數DataGridViewTextBoxColumn";
            this.發射彈數DataGridViewTextBoxColumn.ReadOnly = true;
            this.發射彈數DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.發射彈數DataGridViewTextBoxColumn.Width = 78;
            // 
            // bee通過DataGridViewTextBoxColumn
            // 
            this.bee通過DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bee通過DataGridViewTextBoxColumn.DataPropertyName = "Bee通過";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.bee通過DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.bee通過DataGridViewTextBoxColumn.HeaderText = "Bee通過";
            this.bee通過DataGridViewTextBoxColumn.Name = "bee通過DataGridViewTextBoxColumn";
            this.bee通過DataGridViewTextBoxColumn.ReadOnly = true;
            this.bee通過DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.bee通過DataGridViewTextBoxColumn.Width = 72;
            // 
            // 未擊中DataGridViewTextBoxColumn
            // 
            this.未擊中DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.未擊中DataGridViewTextBoxColumn.DataPropertyName = "未擊中";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Red;
            this.未擊中DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.未擊中DataGridViewTextBoxColumn.HeaderText = "未擊中";
            this.未擊中DataGridViewTextBoxColumn.Name = "未擊中DataGridViewTextBoxColumn";
            this.未擊中DataGridViewTextBoxColumn.ReadOnly = true;
            this.未擊中DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.未擊中DataGridViewTextBoxColumn.Width = 66;
            // 
            // 死亡次數DataGridViewTextBoxColumn
            // 
            this.死亡次數DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.死亡次數DataGridViewTextBoxColumn.DataPropertyName = "死亡次數";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.死亡次數DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.死亡次數DataGridViewTextBoxColumn.HeaderText = "死亡次數";
            this.死亡次數DataGridViewTextBoxColumn.Name = "死亡次數DataGridViewTextBoxColumn";
            this.死亡次數DataGridViewTextBoxColumn.ReadOnly = true;
            this.死亡次數DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.死亡次數DataGridViewTextBoxColumn.Width = 78;
            // 
            // moneyDataGridViewTextBoxColumn
            // 
            this.moneyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.moneyDataGridViewTextBoxColumn.DataPropertyName = "Money";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.moneyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.moneyDataGridViewTextBoxColumn.HeaderText = "Money";
            this.moneyDataGridViewTextBoxColumn.Name = "moneyDataGridViewTextBoxColumn";
            this.moneyDataGridViewTextBoxColumn.ReadOnly = true;
            this.moneyDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.moneyDataGridViewTextBoxColumn.Width = 63;
            // 
            // beeInfoBindingSource1
            // 
            this.beeInfoBindingSource1.DataMember = "Bee_Info";
            this.beeInfoBindingSource1.DataSource = this.bee3000DBDataSet;
            // 
            // bee3000DBDataSet
            // 
            this.bee3000DBDataSet.DataSetName = "Bee3000DBDataSet";
            this.bee3000DBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_Exit
            // 
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit.Location = new System.Drawing.Point(324, 477);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(76, 23);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.Text = "離開";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // bee_InfoTableAdapter1
            // 
            this.bee_InfoTableAdapter1.ClearBeforeFill = true;
            // 
            // Form_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Exit;
            this.ClientSize = new System.Drawing.Size(734, 512);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_Info";
            this.Load += new System.EventHandler(this.Form_Info_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.beeInfoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bee3000DBDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_Exit;
        private Bee3000DBDataSet bee3000DBDataSet;
        private System.Windows.Forms.BindingSource beeInfoBindingSource1;
        private Bee3000DBDataSetTableAdapters.Bee_InfoTableAdapter bee_InfoTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 綜合評價DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 得分DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxComboDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 使用時間DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hit機率DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 擊落總數DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 發射彈數DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bee通過DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 未擊中DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 死亡次數DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneyDataGridViewTextBoxColumn;
    }
}