using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;


namespace MetroUI_ver2
{
    public partial class home_ctr : UserControl
    {

        private PerformanceCounter cpu =
        new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PerformanceCounter ram = new PerformanceCounter("Memory", "Available MBytes");

        string process_name = Process.GetCurrentProcess().ProcessName;

        private PerformanceCounter prcess_cpu =
            new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName);



        private bool loop_state = true;

        



        
        public home_ctr()
        {
            InitializeComponent();

            

            DriveInfo[] drv = DriveInfo.GetDrives();
            foreach (DriveInfo d in drv )
            {
                if (d.DriveType == DriveType.Fixed) // sd카드는 removable로 수정
                {
                    diskLabel.Text = d.Name + " " + (d.TotalFreeSpace / 1024 / 1024) + "MB Free";
                }
            }
        }


        private void home_ctr_Load(object sender, EventArgs e)
        {
            Thread my_thread = new Thread(check_system);
            my_thread.Start();
        }

        private void check_system()
        {
            

            do
            {
                if (this.InvokeRequired)
                {
                    this.cpuLabel1.BeginInvoke(new Action(() =>
                    {
                        this.cpuLabel1.Text = "전체 cpu : " + cpu.NextValue().ToString("N2") + " %";
                        this.ramLabel.Text = "ram : " + ram.NextValue().ToString() + " MB";
                        this.cpuLabel2.Text =
                            "뷰어 cpu : " + prcess_cpu.NextValue().ToString("N2") + " %";
                        //this.metroLabel4.Text =
                        //    process_name + " cpu 사용 : " + prcess_cpu.NextValue().ToString() + " %";
                    }));
                }
                else
                {
                    this.cpuLabel1.Text = "전체 cpu : " + cpu.NextValue().ToString("N2") + " %";
                    this.ramLabel.Text = "ram : " + ram.NextValue().ToString() + " MB";
                    this.cpuLabel2.Text =
                        "뷰어 cpu : " + prcess_cpu.NextValue().ToString("N2") + " %";
                    //this.metroLabel4.Text =
                    //    process_name + " cpu 사용 : " + prcess_cpu.NextValue().ToString() + " %";
                }
                Thread.Sleep(3000);
            } while (loop_state);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loop_state = false;  // for worker thread exit....
            
        }

        private void home_ctr_Leave(object sender, EventArgs e)
        {
            loop_state = false;  // for worker thread exit....
        }
    }
}
