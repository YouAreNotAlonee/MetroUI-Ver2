using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroUI_ver2
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            
            InitializeComponent();
                    }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            home_ctr1.Visible = true;
            player_ctr1.Visible = false;
            setting_ctr1.Visible = false;
            convert_ctr1.Visible = false;
            statistics_ctr1.Visible = false;
        }

        private void playerBtn_Click(object sender, EventArgs e)
        {
            home_ctr1.Visible = false;
            player_ctr1.Visible = true;
            setting_ctr1.Visible = false;
            convert_ctr1.Visible = false;
            statistics_ctr1.Visible = false;
        }

        private void converBtn_Click(object sender, EventArgs e)
        {
            home_ctr1.Visible = false;
            player_ctr1.Visible = false;
            setting_ctr1.Visible = false;
            convert_ctr1.Visible = true;
            statistics_ctr1.Visible = false;
        }

        private void statisticsBtn_Click(object sender, EventArgs e)
        {
            home_ctr1.Visible = false;
            player_ctr1.Visible = false;
            setting_ctr1.Visible = false;
            convert_ctr1.Visible = false;
            statistics_ctr1.Visible = true;
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            home_ctr1.Visible = false;
            player_ctr1.Visible = false;
            setting_ctr1.Visible = true;
            convert_ctr1.Visible = false;
            statistics_ctr1.Visible = false;
        }
    }
}
