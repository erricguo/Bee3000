namespace BeeBeeBee
{
    partial class Form_Main
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_GameStart = new System.Windows.Forms.Button();
            this.btn_Board = new System.Windows.Forms.Button();
            this.btn_GameFinishi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_GameStart
            // 
            this.btn_GameStart.Font = new System.Drawing.Font("新細明體-ExtB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_GameStart.Location = new System.Drawing.Point(315, 435);
            this.btn_GameStart.Name = "btn_GameStart";
            this.btn_GameStart.Size = new System.Drawing.Size(172, 34);
            this.btn_GameStart.TabIndex = 0;
            this.btn_GameStart.Text = "開始遊戲";
            this.btn_GameStart.UseVisualStyleBackColor = true;
            this.btn_GameStart.Click += new System.EventHandler(this.btn_GameStart_Click);
            // 
            // btn_Board
            // 
            this.btn_Board.Font = new System.Drawing.Font("新細明體-ExtB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Board.Location = new System.Drawing.Point(315, 475);
            this.btn_Board.Name = "btn_Board";
            this.btn_Board.Size = new System.Drawing.Size(172, 34);
            this.btn_Board.TabIndex = 2;
            this.btn_Board.Text = "排  行  榜";
            this.btn_Board.UseVisualStyleBackColor = true;
            this.btn_Board.Click += new System.EventHandler(this.btn_Board_Click);
            // 
            // btn_GameFinishi
            // 
            this.btn_GameFinishi.Font = new System.Drawing.Font("新細明體-ExtB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_GameFinishi.Location = new System.Drawing.Point(315, 515);
            this.btn_GameFinishi.Name = "btn_GameFinishi";
            this.btn_GameFinishi.Size = new System.Drawing.Size(172, 34);
            this.btn_GameFinishi.TabIndex = 3;
            this.btn_GameFinishi.Text = "結束遊戲";
            this.btn_GameFinishi.UseVisualStyleBackColor = true;
            this.btn_GameFinishi.Click += new System.EventHandler(this.btn_GameFinishi_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BeeBeeBee.Properties.Resources.Bee_Title1;
            this.ClientSize = new System.Drawing.Size(796, 572);
            this.Controls.Add(this.btn_GameFinishi);
            this.Controls.Add(this.btn_Board);
            this.Controls.Add(this.btn_GameStart);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BeeBeeBee";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Main_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Main_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_GameStart;
        private System.Windows.Forms.Button btn_Board;
        private System.Windows.Forms.Button btn_GameFinishi;




    }
}

