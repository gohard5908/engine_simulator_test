using System;

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
    public partial class FrmTestPage : BaseDock
    {
        public  MLApp.MLApp matlab;  //testttttttttttt
        
        public FrmTestPage()
        {
            InitializeComponent();
        }

        //  此按钮测试别的窗口的MLApp进程，是否可以在此窗口继续沿用。
        private void button1_Click(object sender, EventArgs e)
        {   
            object result = null;
            matlab.GetWorkspaceData("Fnet", "base", out result);
            if (result == null)
            {
                MessageBox.Show("又未获取到值！");
            }
            else
            {

                MessageBox.Show("取到");
                double[,] arraryresult = result as double[,];
                int lenth = arraryresult.Length;
                MessageBox.Show("取到" + lenth.ToString() + "个数据。。。");
            }

        }

        private MLApp.MLApp getFrmInputData_MLApp(FrmInputData form)
        {
            return form.matlab;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // bool ifSucceed;
            Matlab_Sim_Helper simHelper=new Matlab_Sim_Helper();

            if(simHelper.sim_SS_Model(matlab))
            {
                MessageBox.Show("仿真成功");

            }
            else
            {
                MessageBox.Show(simHelper._strError);
            }   
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Matlab_Sim_Helper simHelper = new Matlab_Sim_Helper();

            object result = simHelper.getValue_fromWorkspace(matlab, "Fnet");

            if (result == null)
            {
                MessageBox.Show("又未获取到值！");
            }
            else
            {

                MessageBox.Show("取到");
                double[,] arraryresult = result as double[,];
                int lenth = arraryresult.Length;
                MessageBox.Show("取到" + lenth.ToString() + "个数据。。。");
            }

        }




    }
    

}
