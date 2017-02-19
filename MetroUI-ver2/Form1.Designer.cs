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
            this.statisticsBtn = new MetroFramework.Controls.MetroButton();
            this.settingBtn = new MetroFramework.Controls.MetroButton();
            this.converBtn = new MetroFramework.Controls.MetroButton();
            this.playerBtn = new MetroFramework.Controls.MetroButton();
            this.homeBtn = new MetroFramework.Controls.MetroButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statistics_ctr1 = new MetroUI_ver2.statistics_ctr();
            this.setting_ctr1 = new MetroUI_ver2.setting_ctr();
            this.convert_ctr1 = new MetroUI_ver2.convert_ctr();
            this.player_ctr1 = new MetroUI_ver2.player_ctr();
            this.home_ctr1 = new MetroUI_ver2.home_ctr();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.statisticsBtn);
            this.panel1.Controls.Add(this.settingBtn);
            this.panel1.Controls.Add(this.converBtn);
            this.panel1.Controls.Add(this.playerBtn);
            this.panel1.Controls.Add(this.homeBtn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 650);
            this.panel1.TabIndex = 1;
            // 
            // statisticsBtn
            // 
            this.statisticsBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.statisticsBtn.Location = new System.Drawing.Point(0, 431);
            this.statisticsBtn.Name = "statisticsBtn";
            this.statisticsBtn.Size = new System.Drawing.Size(300, 40);
            this.statisticsBtn.Style = MetroFramework.MetroColorStyle.White;
            this.statisticsBtn.TabIndex = 6;
            this.statisticsBtn.Text = "STATISTICS";
            this.statisticsBtn.UseSelectable = true;
            this.statisticsBtn.Click += new System.EventHandler(this.statisticsBtn_Click);
            // 
            // settingBtn
            // 
            this.settingBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.settingBtn.Location = new System.Drawing.Point(0, 504);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(300, 40);
            this.settingBtn.Style = MetroFramework.MetroColorStyle.White;
            this.settingBtn.TabIndex = 5;
            this.settingBtn.Text = "SETTING";
            this.settingBtn.UseSelectable = true;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // converBtn
            // 
            this.converBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.converBtn.Location = new System.Drawing.Point(0, 350);
            this.converBtn.Name = "converBtn";
            this.converBtn.Size = new System.Drawing.Size(300, 40);
            this.converBtn.Style = MetroFramework.MetroColorStyle.White;
            this.converBtn.TabIndex = 4;
            this.converBtn.Text = "CONVERT";
            this.converBtn.UseSelectable = true;
            this.converBtn.Click += new System.EventHandler(this.converBtn_Click);
            // 
            // playerBtn
            // 
            this.playerBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.playerBtn.Location = new System.Drawing.Point(0, 271);
            this.playerBtn.Name = "playerBtn";
            this.playerBtn.Size = new System.Drawing.Size(300, 40);
            this.playerBtn.Style = MetroFramework.MetroColorStyle.White;
            this.playerBtn.TabIndex = 3;
            this.playerBtn.Text = "PLAYER";
            this.playerBtn.UseSelectable = true;
            this.playerBtn.Click += new System.EventHandler(this.playerBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.homeBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.homeBtn.Location = new System.Drawing.Point(0, 195);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(300, 40);
            this.homeBtn.Style = MetroFramework.MetroColorStyle.Orange;
            this.homeBtn.TabIndex = 2;
            this.homeBtn.Text = "HOME";
            this.homeBtn.UseSelectable = true;
            this.homeBtn.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 100);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(100, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 54);
            this.label1.TabIndex = 3;
            this.label1.Text = "CNS";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(345, 33);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(47, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "CNS";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(300, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 5);
            this.panel3.TabIndex = 3;
            // 
            // statistics_ctr1
            // 
            this.statistics_ctr1.BackColor = System.Drawing.Color.White;
            this.statistics_ctr1.Location = new System.Drawing.Point(300, 100);
            this.statistics_ctr1.Name = "statistics_ctr1";
            this.statistics_ctr1.Size = new System.Drawing.Size(1000, 550);
            this.statistics_ctr1.TabIndex = 8;
            this.statistics_ctr1.Visible = false;
            // 
            // setting_ctr1
            // 
            this.setting_ctr1.BackColor = System.Drawing.Color.White;
            this.setting_ctr1.Location = new System.Drawing.Point(300, 100);
            this.setting_ctr1.Name = "setting_ctr1";
            this.setting_ctr1.Size = new System.Drawing.Size(1000, 550);
            this.setting_ctr1.TabIndex = 7;
            this.setting_ctr1.Visible = false;
            // 
            // convert_ctr1
            // 
            this.convert_ctr1.BackColor = System.Drawing.Color.White;
            this.convert_ctr1.Location = new System.Drawing.Point(300, 100);
            this.convert_ctr1.Name = "convert_ctr1";
            this.convert_ctr1.Size = new System.Drawing.Size(1000, 550);
            this.convert_ctr1.TabIndex = 6;
            this.convert_ctr1.Visible = false;
            // 
            // player_ctr1
            // 
            this.player_ctr1.BackColor = System.Drawing.Color.White;
            this.player_ctr1.Location = new System.Drawing.Point(300, 100);
            this.player_ctr1.Name = "player_ctr1";
            this.player_ctr1.Size = new System.Drawing.Size(1000, 550);
            this.player_ctr1.TabIndex = 5;
            this.player_ctr1.Visible = false;
            // 
            // home_ctr1
            // 
            this.home_ctr1.BackColor = System.Drawing.Color.White;
            this.home_ctr1.Location = new System.Drawing.Point(300, 100);
            this.home_ctr1.Name = "home_ctr1";
            this.home_ctr1.Size = new System.Drawing.Size(1000, 550);
            this.home_ctr1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.statistics_ctr1);
            this.Controls.Add(this.setting_ctr1);
            this.Controls.Add(this.convert_ctr1);
            this.Controls.Add(this.player_ctr1);
            this.Controls.Add(this.home_ctr1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.TransparencyKey = System.Drawing.Color.LawnGreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroButton homeBtn;
        private MetroFramework.Controls.MetroButton converBtn;
        private MetroFramework.Controls.MetroButton playerBtn;
        private MetroFramework.Controls.MetroButton settingBtn;
        private MetroFramework.Controls.MetroButton statisticsBtn;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Panel panel3;
        private home_ctr home_ctr1;
        private player_ctr player_ctr1;
        private convert_ctr convert_ctr1;
        private setting_ctr setting_ctr1;
        private statistics_ctr statistics_ctr1;
    }
}

