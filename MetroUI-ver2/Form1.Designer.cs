namespace MetroUI_ver2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.setting_ctr1 = new MetroUI_ver2.setting_ctr();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.panel1.Controls.Add(this.metroButton5);
            this.panel1.Controls.Add(this.metroButton4);
            this.panel1.Controls.Add(this.metroButton3);
            this.panel1.Controls.Add(this.metroButton2);
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 650);
            this.panel1.TabIndex = 1;
            // 
            // metroButton5
            // 
            this.metroButton5.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton5.Location = new System.Drawing.Point(0, 431);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(300, 40);
            this.metroButton5.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton5.TabIndex = 6;
            this.metroButton5.Text = "STATISTICS";
            this.metroButton5.UseSelectable = true;
            // 
            // metroButton4
            // 
            this.metroButton4.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton4.Location = new System.Drawing.Point(0, 504);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(300, 40);
            this.metroButton4.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton4.TabIndex = 5;
            this.metroButton4.Text = "SETTING";
            this.metroButton4.UseSelectable = true;
            // 
            // metroButton3
            // 
            this.metroButton3.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton3.Location = new System.Drawing.Point(0, 350);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(300, 40);
            this.metroButton3.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton3.TabIndex = 4;
            this.metroButton3.Text = "CONVERT";
            this.metroButton3.UseSelectable = true;
            // 
            // metroButton2
            // 
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton2.Location = new System.Drawing.Point(0, 271);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(300, 40);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "PLAYER";
            this.metroButton2.UseSelectable = true;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.Location = new System.Drawing.Point(0, 195);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(300, 40);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "HOME";
            this.metroButton1.UseSelectable = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(129)))), ((int)(((byte)(49)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 100);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(320, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 54);
            this.label1.TabIndex = 3;
            this.label1.Text = "BBBBBBBBBBBBBBBBBBBBBBB";
            // 
            // setting_ctr1
            // 
            this.setting_ctr1.BackColor = System.Drawing.Color.White;
            this.setting_ctr1.Location = new System.Drawing.Point(296, 97);
            this.setting_ctr1.Name = "setting_ctr1";
            this.setting_ctr1.Size = new System.Drawing.Size(1000, 550);
            this.setting_ctr1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.setting_ctr1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.TransparencyKey = System.Drawing.Color.LawnGreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton5;
        private System.Windows.Forms.Label label1;
        private setting_ctr setting_ctr1;
    }
}

