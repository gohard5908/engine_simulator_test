using System;

using System.Runtime.InteropServices;  // 重要，与引用 [DllImport("user32.dll")] 有关
using System.Threading;                //多线程命名空间

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using WHC.Framework.BaseUI;

using ZS.TestProject.BLL;
using ZS.TestProject.Entity;
using ZS.TestProject.MLApp_BLL;

namespace ZS.TestProject.UIDx
{
    public partial class FrmShowEngineMap : BaseDock
    {
        public MLApp.MLApp matlab;  //testttttttttttt


        #region
        //定义在窗体内

        public delegate void UpdateUI();//委托用于更新UI

        Thread startload;//线程用于matlab窗体处理

        IntPtr figure1;//图像句柄

        #endregion






        public FrmShowEngineMap()
        {
            InitializeComponent();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {

            startload = new Thread(new ThreadStart(startload_run));
            startload.Start();


        }



        void startload_run()
        {

            int count50ms = 0;

            //实例化matlab对象


            //循环查找figure1窗体

            while (figure1 == IntPtr.Zero)
            {

                //查找matlab的Figure 1窗体

                figure1 = FindWindow("SunAwtFrame", "Figure 1");

                //延时50ms

                Thread.Sleep(50);

                count50ms++;

                //20s超时设置

                if (count50ms >= 200)       // 每50ms捕捉一下 是否存在指定 figure , 10s检测不到就抛出资源加载时间过长  
                {

                    MessageBox.Show( "matlab资源加载时间过长！");

                    return;

                }

            }

            //跨线程，用委托方式执行

            UpdateUI update = delegate
            {

                //隐藏标签

                //label1.Visible = false;

                //设置matlab图像窗体的父窗体为panel

                SetParent(figure1, panel1.Handle);

                //获取窗体原来的风格

                var style = GetWindowLong(figure1, GWL_STYLE);

                //设置新风格，去掉标题,不能通过边框改变尺寸

                SetWindowLong(figure1, GWL_STYLE, style & ~WS_CAPTION & ~WS_THICKFRAME);

                //移动到panel里合适的位置并重绘
                int x0 = 0;
                int y0 = -55; 

                MoveWindow(figure1, x0, y0, 400 + 0, 300 + 0, true);

            };

            panel1.Invoke(update);

            //再移动一次，防止显示错误

            Thread.Sleep(100);

            int x = 50;
            int y = -55;    // y 设为负数意在遮挡matlab的figure图片工具栏等干扰因素，可以更美观

            MoveWindow(figure1, x, y, 600 + 0, 450 + 0, true); // 800 600是图片宽度*高度

        }




        #region //Windows API

        [DllImport("user32.dll")]

        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);//

        [DllImport("user32.dll")]

        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);

        const int GWL_STYLE = -16;

        const int WS_CAPTION = 0x00C00000;

        const int WS_THICKFRAME = 0x00040000;

        const int WS_SYSMENU = 0X00080000;

        [DllImport("user32")]

        private static extern int GetWindowLong(System.IntPtr hwnd, int nIndex);

        [DllImport("user32")]

        private static extern int SetWindowLong(System.IntPtr hwnd, int index, int newLong);

        #endregion






    }
}
