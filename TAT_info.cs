using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.DirectX.AudioVideoPlayback;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using OpenCvSharp;
using System.Collections.Generic;
using managedCTAT;
using System.Windows.Forms.DataVisualization.Charting;


namespace MetroUI_ver2
{
    unsafe class TAT_Info
    {
        double cursor_x = 0.0, xVal, yVal, zVal; //커서의 x값과 그 x에서의 각각 축의 값
        List<List<double>> GsensorVal = new List<List<double>>(); //센서값 저장할 리스트
        Series X, Y, Z;
        int tatTime;

        int i = 0;

        public struct FILE_INFO
        {//name fps, header
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
            public string name;
            public uint pos;
            public uint fcode;
            public byte video;
            public byte audio;
            public byte header_size;
            public byte etc1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] //public string fps;
            public byte[] fps;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] //public string fps;
            public ushort[] frame;                //한파일의 비디오 프래임의 합. 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]// public short frame;
            public uint[] size;             //한파일의 비디오+ audio size 합. audio 는 Ch0에만 함산됨. 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] //public int size;
            public ushort[] height;               //녹화 해상도 1280*702   1280 	
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)] //public int size;
            public ushort[] width;
            public uint start_tt;                 // 녹화 시작 시간 
            public uint stop_tt;                  // 녹화 종료 시간 
            public uint gsen_pos;
            public uint gsen_size;
            public char gps;       //해당 파일의  시작 GPS점 및 종료 GPS 데이타 
            public uint user_pos;                 //Tail Data pos  for ESV	
            public uint user_size;                    //Tail Data size for ESV	
            public uint audio_sample;
            public byte audio_bit;
            public byte audio_ch;
            public byte obd;
            public byte reserv;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 120)]
            public string header;
            public uint findex;
        }
        /// <summary>
        /// 
        /// </summary>
        Video vid;
        public char[] m_rdata = new char[1024 * 1024];
        int hour, minute, second, VideoDuration, VideoPosition, handle = 0, file_sum = 0;
        string Video_Time, Video_Path = "C:\\TEST\\";
        bool Video_Timer_Enable = false, Mute_Mode = false, ScrollEnable = false;
        bool P_check = true, E_check = true, N_check = true, M_check = true;//리스트 뷰 위 체크박스 플래그 //parking Event Normal
        static int mode_0 = 254, mode_1 = 254, mode_2 = 254, mode_3 = 254, mode = 254, file_num = 1, file_cnt;
        string[] name = new string[mode_0];
        string[] Only_name = new string[mode_0];
        string[] name1 = new string[mode_1 + 1];
        string[] Only_name1 = new string[mode_1 + 1];
        string[] name2 = new string[file_cnt];
        string[] Only_name2 = new string[file_cnt];
        string[] name3 = new string[file_cnt];
        string[] Only_name3 = new string[file_cnt];
        string Eevent = "", Nnormal = "", Pparking = "", Rreserve = "";

        /// <summary>
        /// openCV 이미지
        /// </summary>

        //CvCapture capture;
        //IplImage imgSrc = new IplImage(640, 480, BitDepth.U8, 3);
        //private string video_path;
        //Device _device;

        /// <summary>
        /// TATLib에 필요한 함수와 인자들 
        /// </summary>
        [DllImport("TATLib.dll")]
        public static extern int TAT_Create();

        [DllImport("TATLib.dll")]
        public static extern void TAT_Delete(int handle);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Open(int handle, byte* device);

        [DllImport("TATLib.dll")]
        public static extern void TAT_Close(int handle, int fp);

        [DllImport("TATLib.dll")]
        public static extern uint TAT_Read(int handle, int fp, uint pos, string data, uint size);//

        [DllImport("TATLib.dll")]
        public static extern uint TAT_Write(int handle, int fp, uint pos, uint bytes, string data, uint size);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Format(int handle);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Check_Tat_Device(int handle, string device);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Check_Version(int handle);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Get_File_Frame_Cnt(int handle, Byte mode, string fname, string front, string rear);//unsigned char pointer??????????

        [DllImport("TATLib.dll")]
        public static extern int TAT_Get_File_Index_Info(int handle, byte mode, string fname, ref FILE_INFO f_info);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Get_File_Cnt(int handle, char mode);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Get_File_List(int handle, char mode, int list_cnt, string fname, uint* findex, uint* fsize);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Get_File_List_tt(int handle, char mode, int list_cnt, byte[] fname, uint[] findex, uint[] fsize, uint[] ftime);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Get_File_Flag(int handle, string Eevent, string Nnormal, string Pparking, string Rreserv);

        [DllImport("TATLib.dll")]
        public static extern Byte TAT_Find_Start_Stop(int handle, int fp, uint* mode, uint* start, uint* stop, uint* last_pos);

        [DllImport("TATLib.dll")]
        public static extern uint TAT_Get_PB_Pos(int handle, byte mode, string file);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Get_Seek_Pos(int handle, Byte seek, Byte total);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Set_PcFolder(int handle, string folder);

        [DllImport("TATLib.dll")]
        public static extern void TAT_PB_Init(int handle);

        [DllImport("TATLib.dll")]
        public static extern void TAT_PB_DeInit(int handle);

        [DllImport("TATLib.dll")]
        public static extern void TAT_PB_Start(int handle, byte mode, Byte ch, uint pb_pos);//int char char int

        [DllImport("TATLib.dll")]
        public static extern void TAT_PB_Stop(int handle);

        [DllImport("TATLib.dll")]
        public static extern void TAT_FAT_PB_Start(int handle, string file, uint* frame_cnt);

        [DllImport("TATLib.dll")]
        public static extern void TAT_FAT_PB_Stop(int handle);

        [DllImport("TATLib.dll")]
        public static extern uint TAT_Read_Frame(int handle, ref Byte ch, ref Byte f_type, ref Byte p_type, ref uint size, byte[] data, ref uint timestamp);

        [DllImport("TATLib.dll")]
        public static extern uint TAT_Make_Avi_File(int handle, string fname);

        [DllImport("TATLib.dll")]
        public static extern uint TAT_Make_Play_File(int handle, string fname, string Gsensor, string Gps);//TATLib에 없음

        [DllImport("TATLib.dll")]
        public static extern uint TAT_Make_Tat_File(int handle, string fname);

        [DllImport("TATLib.dll")]
        public static extern uint TAT_Make_Data_File(int handle, string fname, uint* frame_cnt, string gps_data, char tat, Byte fps, uint width, uint height, string bGsen, string obd);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Set_Config_Data(int handle, string data, uint* size);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Get_Config_Data(int handle, string data, uint* size);

        [DllImport("TATLib.dll")]
        public static extern void TAT_Get_Device_Name(int handle, string dname);

        [DllImport("TATLib.dll")]
        public static extern int TAT_Make_Picture_File(int handle, string fname, uint* pictrue_size, string picture_data);//TATLib에 없음


        public int TAT_device()
        {
            int result = 0;
            string device = "";
            string path = null;
            handle = TAT_Create();
            result = TAT_Check_Tat_Device(handle, device);

            if (device.Equals("2"))
                path = "D\\: 에 TAT파일이 있습니다.";
            else if (device.Equals("3"))
                path = "E\\: 에 TAT파일이 있습니다.";
            else if (device.Equals("4"))
                path = "F\\: 에 TAT파일이 있습니다.";
            Console.WriteLine(path);
            path = "path";
            return handle;

        }

        /*
        public void initFileList(string curdir)
        {
            DirectoryInfo di = new DirectoryInfo(curdir);
            FileInfo[] files = di.GetFiles();
            listView.BeginUpdate();
            listView.View = View.Details;
            string f_name, f_extention;
            foreach (var fi in files)
            {
                f_name = Path.GetFileNameWithoutExtension(fi.ToString());//이름
                f_extention = Path.GetExtension(fi.ToString());//확장자

                ListViewItem lvi = new ListViewItem(f_name);//첫번째 인자는 파일의 이름(확장자 제외)
                lvi.SubItems.Add(fi.Length.ToString());//파일크기
                lvi.SubItems.Add(f_extention);//확장자
                lvi.SubItems.Add(fi.FullName);//절대경로
                lvi.ImageIndex = 0;
                listView.Items.Add(lvi);
            }
            listView.EndUpdate();
        }

        unsafe public TAT_showlist()
        {
            string temp = "";
            int nPos = 0, ePos = 0, pPos = 0, mPos = 0;
            int EfileCnt = 0, NfileCnt = 0, PfileCnt = 0, MfileCnt = 0;
            uint EfileSize = 0, NfileSize = 0, PfileSize = 0, MfileSize = 0;

            listView.Items.Clear();

            TAT_Get_File_Flag(handle, Eevent, Nnormal, Pparking, Rreserve);

            mode_0 = TAT_Get_File_Cnt(handle, (char)0);
            mode_1 = TAT_Get_File_Cnt(handle, (char)1);
            mode_2 = TAT_Get_File_Cnt(handle, (char)2);
            mode_3 = TAT_Get_File_Cnt(handle, (char)3);
            file_cnt = mode_0 + mode_1 + mode_2 + mode_3;

            char[] list_name_0 = new char[1000 * mode_0];
            byte[] list_name_temp_0 = new byte[45 * mode_0];
            uint[] list_index_0 = new uint[sizeof(uint) * mode_0];
            uint[] list_size_0 = new uint[sizeof(uint) * mode_0];
            uint[] list_time_0 = new uint[sizeof(uint) * mode_0];
            string[] name_0 = new string[mode_0];

            char[] list_name_1 = new char[1000 * mode_1];
            byte[] list_name_temp_1 = new byte[45 * mode_1];
            uint[] list_index_1 = new uint[sizeof(uint) * mode_1];
            uint[] list_size_1 = new uint[sizeof(uint) * mode_1];
            uint[] list_time_1 = new uint[sizeof(uint) * mode_1];
            string[] name_1 = new string[mode_1];

            char[] list_name_2 = new char[1000 * mode_2];
            byte[] list_name_temp_2 = new byte[45 * mode_2];
            uint[] list_index_2 = new uint[sizeof(uint) * mode_2];
            uint[] list_size_2 = new uint[sizeof(uint) * mode_2];
            uint[] list_time_2 = new uint[sizeof(uint) * mode_2];
            string[] name_2 = new string[mode_2];

            char[] list_name_3 = new char[1000 * mode_3];
            byte[] list_name_temp_3 = new byte[45 * mode_3];
            uint[] list_index_3 = new uint[sizeof(uint) * mode_3];
            uint[] list_size_3 = new uint[sizeof(uint) * mode_3];
            uint[] list_time_3 = new uint[sizeof(uint) * mode_3];
            string[] name_3 = new string[mode_3];

            file_sum += TAT_Get_File_List_tt(handle, (char)0, mode_0, list_name_temp_0, list_index_0, list_size_0, list_time_0);
            file_sum += TAT_Get_File_List_tt(handle, (char)1, mode_1, list_name_temp_1, list_index_1, list_size_1, list_time_1);
            file_sum += TAT_Get_File_List_tt(handle, (char)2, mode_2, list_name_temp_2, list_index_2, list_size_2, list_time_2);
            file_sum += TAT_Get_File_List_tt(handle, (char)3, mode_3, list_name_temp_3, list_index_3, list_size_3, list_time_3);

            for (int i = 0; i < 40 * mode_0; i++)
                list_name_0[i] = (char)list_name_temp_0[i];
            for (int i = 0; i < 40 * mode_1; i++)
                list_name_1[i] = (char)list_name_temp_1[i];
            for (int i = 0; i < 40 * mode_2; i++)
                list_name_2[i] = (char)list_name_temp_2[i];
            for (int i = 0; i < 40 * mode_3; i++)
                list_name_3[i] = (char)list_name_temp_3[i];
            int e = name_0.Length;
            int I = name_1.Length;
            int M = name_2.Length;
            int U = name_3.Length;

            for (int j = 0; j < e; j++)
            {
                for (int i = j * 20; i < j * 20 + 21; i++)
                    temp += list_name_0[j * 20 + i].ToString();
                int size = int.Parse(list_size_0[j].ToString());
                size /= (1024 * 1024);
                ListViewItem lvi = new ListViewItem(temp);
                lvi.SubItems.Add(size.ToString() + "MB");
                lvi.SubItems.Add(list_time_0[j].ToString() + "초");
                listView.Items.Add(lvi);
                ePos++;
                EfileCnt++;
                EfileSize += list_size_0[j];
                temp = "";
            }
            for (int j = 0; j < I; j++)
            {
                for (int i = j * 20; i < j * 20 + 21; i++)
                    temp += list_name_1[j * 20 + i].ToString();
                int size = int.Parse(list_size_1[j].ToString());
                size /= (1024 * 1024);
                ListViewItem lvi = new ListViewItem(temp);
                lvi.SubItems.Add(size.ToString() + "MB");
                lvi.SubItems.Add(list_time_1[j].ToString() + "초");
                listView.Items.Add(lvi);
                nPos++;
                NfileCnt++;
                NfileSize += list_size_1[j];
                temp = "";
            }
            for (int j = 0; j < M; j++)
            {
                for (int i = j * 40 + 0; i < j * 40 + 21; i++)
                    temp += list_name_2[j * 40 + i].ToString();
                int size = int.Parse(list_size_2[j].ToString());
                size /= (1024 * 1024);
                ListViewItem lvi = new ListViewItem(temp);
                lvi.SubItems.Add(size.ToString() + "MB");
                lvi.SubItems.Add(list_time_2[j].ToString() + "초");
                listView.Items.Add(lvi);
                mPos++;
                MfileCnt++;
                MfileSize += list_size_2[j];
            }

            for (int j = 0; j < U; j++)
            {
                for (int i = j * 40 + 0; i < j * 40 + 21; i++)
                    temp += list_name_3[j * 40 + i].ToString();
                int size = int.Parse(list_size_3[j].ToString());
                size /= (1024 * 1024);
                ListViewItem lvi = new ListViewItem(temp);
                lvi.SubItems.Add(size.ToString() + "MB");
                lvi.SubItems.Add(list_time_3[j].ToString() + "초");
                listView.Items.Add(lvi);
                pPos++;
                PfileCnt++;
                PfileSize += list_size_3[j];
            }
            listView.Update();
            listView.EndUpdate();
        }
        */
    }


}
