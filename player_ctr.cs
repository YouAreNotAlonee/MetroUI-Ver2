using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.DirectX.AudioVideoPlayback;
using System.Threading;
using Microsoft.DirectX.Direct3D;
using OpenCvSharp;

using managedCTAT;
using static MetroUI_ver2.Form1;








namespace MetroUI_ver2
{
    public unsafe partial class player_ctr : UserControl
    {
       






        public player_ctr()
        {
            InitializeComponent();
            
            //TAT_device();
            //TAT_showlist();
            this.metroListView1.View = View.Details;
            this.metroListView1.Columns.Add("파일이름", 80, HorizontalAlignment.Center);
            this.metroListView1.Columns.Add("파일크기", 50, HorizontalAlignment.Center);
            this.metroListView1.Columns.Add("재생시간", 50, HorizontalAlignment.Center);
            this.metroListView1.Columns.Add("상대경로", 80, HorizontalAlignment.Center);
            

        }

        private void mapBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string url = Environment.CurrentDirectory + "\\daumMapAPI.html";
                this.webBrowser1.Navigate(url);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        // fetch list
        private void listBtn_Click(object sender, EventArgs e)
        {

            string curdir;
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.SelectedPath = @"D:\testvideo\";//deafult 디렉토리 설정

            if (fd.ShowDialog() == DialogResult.OK) // 확인을 눌렀을 때
            {
                curdir = fd.SelectedPath;
                //initFileList(curdir);
            }
            else
                MessageBox.Show("취소");    

        }

        private void metroListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fname;
            fname = metroListView1.FocusedItem.SubItems[0].Text;
            //vDownLoadFile(fname);
        }

        private void metroListView1_DoubleClick(object sender, EventArgs e)
        {

            string fname;
            fname = metroListView1.FocusedItem.SubItems[0].Text;
            //vDownLoadFile(fname);
        }

        /*
        private void GSensor_Chart()
        {
            Gsensor.ChartAreas.Add("Gsensor");
            Gsensor.ChartAreas["Xaxis"].AxisX.Minimum = 0;
            Gsensor.ChartAreas["Xaxis"].AxisX.Maximum = 100;
            Gsensor.ChartAreas["Yaxis"].AxisY.Minimum = 0;
            Gsensor.ChartAreas["Yaxis"].AxisY.Maximum = 100;
            Gsensor.Series.Add("Xaxis");
            Gsensor.Series["Xaxis"].ChartArea = "Gsensor";
            Gsensor.Series["Xaxis"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            Gsensor.Series.Add("Yaxis");
            Gsensor.Series["Yaxis"].ChartArea = "Gsensor";
            Gsensor.Series["Yaxis"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            Gsensor.Series.Add("Zaxis");
            Gsensor.Series["Zaxis"].ChartArea = "Gsensor";
            Gsensor.Series["Zaxis"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            Gsensor.ChartAreas["Xaxis"].AxisX.Minimum = 0;
            Gsensor.ChartAreas["Xaxis"].AxisX.Maximum = 100;
            Gsensor.ChartAreas["Yaxis"].AxisY.Minimum = 0;
            Gsensor.ChartAreas["Yaxis"].AxisY.Maximum = 100;

            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                Gsensor.Series["Xaxis"].Points.Add(rand.Next(500));
                Gsensor.Series["Yaxis"].Points.Add(rand.Next(500));
                Gsensor.Series["Zaxis"].Points.Add(rand.Next(500));
            }

        }
        */

    }
}
