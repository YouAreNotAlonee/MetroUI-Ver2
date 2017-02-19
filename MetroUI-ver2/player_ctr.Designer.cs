namespace MetroUI_ver2
{
    partial class player_ctr
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroTrackBar1 = new MetroFramework.Controls.MetroTrackBar();
            this.metroTrackBar2 = new MetroFramework.Controls.MetroTrackBar();
            this.metroTrackBar3 = new MetroFramework.Controls.MetroTrackBar();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.metroToggle2 = new MetroFramework.Controls.MetroToggle();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.mapBtn = new MetroFramework.Controls.MetroButton();
            this.updownBtn = new MetroFramework.Controls.MetroButton();
            this.leftrightBtn = new MetroFramework.Controls.MetroButton();
            this.volumeBtn = new MetroFramework.Controls.MetroButton();
            this.fowardBtn = new MetroFramework.Controls.MetroButton();
            this.stopBtn = new MetroFramework.Controls.MetroButton();
            this.playBtn = new MetroFramework.Controls.MetroButton();
            this.backBtn = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.listTab = new MetroFramework.Controls.MetroTabPage();
            this.metroListView1 = new MetroFramework.Controls.MetroListView();
            this.mapTab = new MetroFramework.Controls.MetroTabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.metroTabControl1.SuspendLayout();
            this.listTab.SuspendLayout();
            this.mapTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 350);
            this.panel1.TabIndex = 0;
            // 
            // metroTrackBar1
            // 
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.Location = new System.Drawing.Point(-15, -15);
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Size = new System.Drawing.Size(75, 23);
            this.metroTrackBar1.TabIndex = 1;
            this.metroTrackBar1.Text = "metroTrackBar1";
            // 
            // metroTrackBar2
            // 
            this.metroTrackBar2.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar2.Location = new System.Drawing.Point(12, 370);
            this.metroTrackBar2.Name = "metroTrackBar2";
            this.metroTrackBar2.Size = new System.Drawing.Size(700, 23);
            this.metroTrackBar2.TabIndex = 2;
            this.metroTrackBar2.Text = "metroTrackBar2";
            // 
            // metroTrackBar3
            // 
            this.metroTrackBar3.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar3.Location = new System.Drawing.Point(633, 404);
            this.metroTrackBar3.Name = "metroTrackBar3";
            this.metroTrackBar3.Size = new System.Drawing.Size(75, 23);
            this.metroTrackBar3.TabIndex = 8;
            this.metroTrackBar3.Text = "metroTrackBar3";
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Location = new System.Drawing.Point(628, 448);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 16);
            this.metroToggle1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroToggle1.TabIndex = 12;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.UseSelectable = true;
            // 
            // metroToggle2
            // 
            this.metroToggle2.AutoSize = true;
            this.metroToggle2.Location = new System.Drawing.Point(628, 491);
            this.metroToggle2.Name = "metroToggle2";
            this.metroToggle2.Size = new System.Drawing.Size(80, 16);
            this.metroToggle2.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroToggle2.TabIndex = 13;
            this.metroToggle2.Text = "Off";
            this.metroToggle2.UseSelectable = true;
            // 
            // metroButton2
            // 
            this.metroButton2.BackgroundImage = global::MetroUI_ver2.Properties.Resources.download;
            this.metroButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroButton2.Location = new System.Drawing.Point(725, 493);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(35, 35);
            this.metroButton2.TabIndex = 16;
            this.metroButton2.UseSelectable = true;
            // 
            // metroButton3
            // 
            this.metroButton3.BackColor = System.Drawing.Color.White;
            this.metroButton3.BackgroundImage = global::MetroUI_ver2.Properties.Resources.folder;
            this.metroButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroButton3.Location = new System.Drawing.Point(3, 10);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(83, 35);
            this.metroButton3.TabIndex = 15;
            this.metroButton3.Text = "불러오기";
            this.metroButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroButton3.UseSelectable = true;
            // 
            // mapBtn
            // 
            this.mapBtn.BackColor = System.Drawing.Color.White;
            this.mapBtn.BackgroundImage = global::MetroUI_ver2.Properties.Resources.location_point;
            this.mapBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mapBtn.Location = new System.Drawing.Point(3, 10);
            this.mapBtn.Name = "mapBtn";
            this.mapBtn.Size = new System.Drawing.Size(82, 35);
            this.mapBtn.TabIndex = 14;
            this.mapBtn.Text = "연결하기";
            this.mapBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mapBtn.UseSelectable = true;
            // 
            // updownBtn
            // 
            this.updownBtn.BackgroundImage = global::MetroUI_ver2.Properties.Resources.updown;
            this.updownBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.updownBtn.Location = new System.Drawing.Point(592, 481);
            this.updownBtn.Name = "updownBtn";
            this.updownBtn.Size = new System.Drawing.Size(35, 35);
            this.updownBtn.TabIndex = 11;
            this.updownBtn.UseSelectable = true;
            // 
            // leftrightBtn
            // 
            this.leftrightBtn.BackgroundImage = global::MetroUI_ver2.Properties.Resources.leftright;
            this.leftrightBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.leftrightBtn.Location = new System.Drawing.Point(592, 440);
            this.leftrightBtn.Name = "leftrightBtn";
            this.leftrightBtn.Size = new System.Drawing.Size(35, 35);
            this.leftrightBtn.TabIndex = 10;
            this.leftrightBtn.UseSelectable = true;
            // 
            // volumeBtn
            // 
            this.volumeBtn.BackgroundImage = global::MetroUI_ver2.Properties.Resources.speaker__1_;
            this.volumeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.volumeBtn.Location = new System.Drawing.Point(592, 399);
            this.volumeBtn.Name = "volumeBtn";
            this.volumeBtn.Size = new System.Drawing.Size(35, 35);
            this.volumeBtn.TabIndex = 7;
            this.volumeBtn.UseSelectable = true;
            // 
            // fowardBtn
            // 
            this.fowardBtn.BackgroundImage = global::MetroUI_ver2.Properties.Resources.fast_forward_arrows_button;
            this.fowardBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.fowardBtn.Location = new System.Drawing.Point(150, 399);
            this.fowardBtn.Name = "fowardBtn";
            this.fowardBtn.Size = new System.Drawing.Size(35, 35);
            this.fowardBtn.TabIndex = 6;
            this.fowardBtn.UseSelectable = true;
            // 
            // stopBtn
            // 
            this.stopBtn.BackgroundImage = global::MetroUI_ver2.Properties.Resources.stop_button;
            this.stopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.stopBtn.Location = new System.Drawing.Point(104, 399);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(35, 35);
            this.stopBtn.TabIndex = 5;
            this.stopBtn.UseSelectable = true;
            // 
            // playBtn
            // 
            this.playBtn.BackgroundImage = global::MetroUI_ver2.Properties.Resources.play_button__1_;
            this.playBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.playBtn.Location = new System.Drawing.Point(58, 399);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(35, 35);
            this.playBtn.TabIndex = 4;
            this.playBtn.UseSelectable = true;
            // 
            // backBtn
            // 
            this.backBtn.BackgroundImage = global::MetroUI_ver2.Properties.Resources.previous;
            this.backBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.backBtn.Location = new System.Drawing.Point(12, 399);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(35, 35);
            this.backBtn.TabIndex = 3;
            this.backBtn.UseSelectable = true;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.listTab);
            this.metroTabControl1.Controls.Add(this.mapTab);
            this.metroTabControl1.Location = new System.Drawing.Point(718, 16);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(275, 475);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTabControl1.TabIndex = 17;
            this.metroTabControl1.UseSelectable = true;
            // 
            // listTab
            // 
            this.listTab.Controls.Add(this.metroListView1);
            this.listTab.Controls.Add(this.metroButton3);
            this.listTab.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listTab.HorizontalScrollbarBarColor = true;
            this.listTab.HorizontalScrollbarHighlightOnWheel = false;
            this.listTab.HorizontalScrollbarSize = 10;
            this.listTab.Location = new System.Drawing.Point(4, 38);
            this.listTab.Name = "listTab";
            this.listTab.Size = new System.Drawing.Size(267, 433);
            this.listTab.Style = MetroFramework.MetroColorStyle.Black;
            this.listTab.TabIndex = 0;
            this.listTab.Text = "PlayLists";
            this.listTab.VerticalScrollbarBarColor = true;
            this.listTab.VerticalScrollbarHighlightOnWheel = false;
            this.listTab.VerticalScrollbarSize = 10;
            // 
            // metroListView1
            // 
            this.metroListView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListView1.FullRowSelect = true;
            this.metroListView1.Location = new System.Drawing.Point(3, 49);
            this.metroListView1.Name = "metroListView1";
            this.metroListView1.OwnerDraw = true;
            this.metroListView1.Size = new System.Drawing.Size(261, 372);
            this.metroListView1.TabIndex = 16;
            this.metroListView1.UseCompatibleStateImageBehavior = false;
            this.metroListView1.UseSelectable = true;
            // 
            // mapTab
            // 
            this.mapTab.Controls.Add(this.webBrowser1);
            this.mapTab.Controls.Add(this.mapBtn);
            this.mapTab.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mapTab.HorizontalScrollbarBarColor = true;
            this.mapTab.HorizontalScrollbarHighlightOnWheel = false;
            this.mapTab.HorizontalScrollbarSize = 10;
            this.mapTab.Location = new System.Drawing.Point(4, 38);
            this.mapTab.Name = "mapTab";
            this.mapTab.Size = new System.Drawing.Size(267, 433);
            this.mapTab.Style = MetroFramework.MetroColorStyle.Black;
            this.mapTab.TabIndex = 1;
            this.mapTab.Text = "Map";
            this.mapTab.VerticalScrollbarBarColor = true;
            this.mapTab.VerticalScrollbarHighlightOnWheel = false;
            this.mapTab.VerticalScrollbarSize = 10;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(3, 55);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(261, 266);
            this.webBrowser1.TabIndex = 2;
            // 
            // player_ctr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroToggle2);
            this.Controls.Add(this.metroToggle1);
            this.Controls.Add(this.updownBtn);
            this.Controls.Add(this.leftrightBtn);
            this.Controls.Add(this.metroTrackBar3);
            this.Controls.Add(this.volumeBtn);
            this.Controls.Add(this.fowardBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.metroTrackBar2);
            this.Controls.Add(this.metroTrackBar1);
            this.Controls.Add(this.panel1);
            this.Name = "player_ctr";
            this.Size = new System.Drawing.Size(1000, 550);
            this.metroTabControl1.ResumeLayout(false);
            this.listTab.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar2;
        private MetroFramework.Controls.MetroButton backBtn;
        private MetroFramework.Controls.MetroButton playBtn;
        private MetroFramework.Controls.MetroButton stopBtn;
        private MetroFramework.Controls.MetroButton fowardBtn;
        private MetroFramework.Controls.MetroButton volumeBtn;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar3;
        private MetroFramework.Controls.MetroButton leftrightBtn;
        private MetroFramework.Controls.MetroButton updownBtn;
        private MetroFramework.Controls.MetroToggle metroToggle1;
        private MetroFramework.Controls.MetroToggle metroToggle2;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton mapBtn;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage listTab;
        private MetroFramework.Controls.MetroTabPage mapTab;
        private MetroFramework.Controls.MetroListView metroListView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
