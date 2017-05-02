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

namespace MetroUI_ver2
{
    public partial class statistics_ctr : UserControl
    {
        public statistics_ctr()
        {
            InitializeComponent();
            this.metroListView1.Columns.Add("이름");
            this.metroListView1.Columns.Add("크기");
        }

        private void statistics_ctr_Load(object sender, EventArgs e)
        {

           
        }


        private void initFileList(string curdir)
        {
            DirectoryInfo di = new DirectoryInfo(curdir);
            FileInfo[] files = di.GetFiles();
            metroListView1.BeginUpdate();
            metroListView1.View = View.Details;
            string f_name, f_extention;
            foreach (var fi in files)
            {
                f_name = Path.GetFileNameWithoutExtension(fi.ToString());
                f_extention = Path.GetExtension(fi.ToString());

                if (f_extention == ".avi")
                    continue;
                //일단 zip파일만 거르게 해놓았음
                //추가로 확장자를 넣어주면 됨
                ListViewItem lvi = new ListViewItem(f_name);//첫번째 인자는 파일의 이름(확장자 제외)

                lvi.SubItems.Add(fi.Length.ToString());//파일크기
                lvi.SubItems.Add(f_extention);//확장자
                lvi.SubItems.Add(fi.FullName);//절대경로
                lvi.ImageIndex = 0;
                metroListView1.Items.Add(lvi);
            }
            metroListView1.EndUpdate();
        }


        private void listButton_Click(object sender, EventArgs e)
        {

            string curdir;
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.SelectedPath = @"D:\testvideo\";//deafult 디렉토리 설정

            if (fd.ShowDialog() == DialogResult.OK) // 확인을 눌렀을 때
            {
                curdir = fd.SelectedPath;
                initFileList(curdir);
            }
            else
            {
                MessageBox.Show("Select Folder");
            }

        }


        public double CalDistance(double lat1, double lon1, double lat2, double lon2)
        {

            double theta, dist;
            theta = lon1 - lon2;
            dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1))
                  * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);

            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;    // 단위 mile 에서 km 변환.  
            dist = dist * 1000.0;      // 단위  km 에서 m 로 변환  

            return dist;
            
        }

        // 주어진 도(degree) 값을 라디언으로 변환  
        private double deg2rad(double deg)
        {
            return (double)(deg * Math.PI / (double)180d);
        }

        // 주어진 라디언(radian) 값을 도(degree) 값으로 변환  
        private double rad2deg(double rad)
        {
            return (double)(rad * (double)180d / Math.PI);
        }

        private void analysisBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CalDistance(37.56682, 126.97865, 37.57682, 126.98865).ToString("N2")+ " M");
            
        }
    }
}
