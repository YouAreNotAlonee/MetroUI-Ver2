namespace MetroUI_ver2
{
    partial class statistics_ctr
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroListView1
            // 
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.Location = new System.Drawing.Point(14, 55);
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(228, 379);
            this.metroListView1.TabIndex = 0;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.metroButton1);
            this.panel1.Controls.Add(this.metroButton3);
            this.panel1.Controls.Add(this.metroListView1);
            this.panel1.Location = new System.Drawing.Point(26, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 511);
            this.panel1.TabIndex = 17;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(167, 440);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 18;
            this.metroButton1.Text = "분석";
            this.metroButton1.UseSelectable = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MetroUI_ver2.Properties.Resources.dashboard;
            this.pictureBox1.Location = new System.Drawing.Point(465, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // metroButton3
            // 
            this.metroButton3.BackColor = System.Drawing.Color.White;
            this.metroButton3.BackgroundImage = global::MetroUI_ver2.Properties.Resources.folder;
            this.metroButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroButton3.Location = new System.Drawing.Point(14, 14);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(83, 35);
            this.metroButton3.TabIndex = 16;
            this.metroButton3.Text = "불러오기";
            this.metroButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroButton3.UseSelectable = true;
            // 
            // statistics_ctr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "statistics_ctr";
            this.Size = new System.Drawing.Size(1000, 550);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroListView metroListView1;
        private MetroFramework.Controls.MetroButton metroButton3;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
