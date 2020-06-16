using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Threading; //引入多线程机制

using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using WHC.Framework.BaseUI;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraCharts;


using ZS.TestProject.Entity;
using ZS.TestProject.BLL;

using ZS.TestProject.MLApp_BLL;





namespace ZS.TestProject.UIDx
{
    public partial class Frm_simulator_Deterioration : BaseDock 
    {
        MLApp.MLApp matlab = new MLApp.MLApp();
        string str_chartPath = "D:\\Engine_Simulator\\Matlab_Simulator_Deterioration\\Deter_sim_data";


        /// 退化仿真线程是否工作标记位
        /// </summary>
        public static bool bRun = false;



        /// <summary>
        delegate void update_chart_delegate(String str); //str将来为chart地址
        /// </summary>

        public Frm_simulator_Deterioration()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //根据所选
            bRun = true;//仿真工作开始

            Thread sim_thread = new Thread(start_deter_sim);
            sim_thread.Start(matlab);

        /*    if(ifsuccess)
            {
                bRun = false;  //仿真结束
                //MessageBox.Show("仿真结束！");
            }
          */
        }

        //退化仿真的工作线程
        private void start_deter_sim(object matlab_obj)
        {

            MLApp.MLApp matlab = (MLApp.MLApp)matlab_obj;
            Matlab_Sim_Helper simHelper = new Matlab_Sim_Helper();
            simHelper.set_HealthPara_Data(matlab);
            bool ifsuccess = simHelper.sim_Deter_Model(matlab);
        //    MessageBox.Show(ifsuccess.ToString());
            if(ifsuccess)
            {   
                bRun = false;  //仿真结束
                //MessageBox.Show(bRun.ToString());
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Thread update_chart = new Thread(update_result_chart);
            update_chart.Start();
       

            
            //this.webBrowser1.Url = new Uri(str_chartPath + "\\test_charts.html");
        }

        //刷新UI的子线程函数，内部使用委托
        private void update_result_chart()
        {
            while (bRun)
            {
                //
                this.BeginInvoke(new update_chart_delegate(updata_chart), new object[] { str_chartPath + "\\test_charts.html" });
                Thread.Sleep(2000); //线程休眠5秒
              //  MessageBox.Show("更新了一次");
                if (!bRun)
                {
                    break;
                }
            }

        }

        //委托调用的函数，主线程函数，用来更新UI
        public void updata_webBroeser(string url_str)
        {
            this.webBrowser1.Url = new Uri(url_str);
        }
        //委托调用的函数，主线程函数，用来更新UI
        public void updata_chart(string url_str)
        {
            
            Degraded_simulation_process_data sim_data = jiexi_json(return_SSdataStruct(str_chartPath + "\\Deter_Sim_Data.json"));//获取了数据；

            ((XYDiagram)chartControl1.Diagram).AxisX.WholeRange.SetMinMaxValues(0, 200);
            for (int i = 1; i < sim_data.cycles_out.Count - 1; i++)
            {
                SeriesPoint point = new SeriesPoint(sim_data.cycles_out[i], sim_data.EGT_out[i]);
                chartControl1.Series[0].Points.Add(point);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Degraded_simulation_process_data sim_data = jiexi_json(return_SSdataStruct(str_chartPath + "\\Deter_Sim_Data.json"));//获取了数据；

           for (int i=0;i<sim_data.cycles_out.Count-1;i++)
           {
               SeriesPoint point = new SeriesPoint(sim_data.cycles_out[i], sim_data.EGT_out[i]);
               chartControl1.Series[0].Points.Add(point);
               ((XYDiagram)chartControl1.Diagram).AxisX.WholeRange.SetMinMaxValues(0,200);
               //((XYDiagram)chartControl1.Diagram).AxisX.WholeRange.MaxValue = 200; 

           }
         // chartControl1.Series[0].Points.   

        }


        //读取指定JSON文件到字符串
        public string return_SSdataStruct(string pathof_sim_data_json)
        {
            string jsonstring = File.ReadAllText(pathof_sim_data_json);
            return jsonstring;

        }
        //解析json 到 Sim_data_Root 类
        public Degraded_simulation_process_data jiexi_json(string json_str)
        {
            Degraded_simulation_process_data simdata = Newtonsoft.Json.JsonConvert.DeserializeObject<Degraded_simulation_process_data>(json_str);
            return simdata;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bRun = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bRun = false;
        }
    }

    #region 定义退化仿真过程数据类
    public class Degraded_simulation_process_data
    {
        /// <summary>
        /// 
        /// </summary>
        public int nowlength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> cycles_out { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<double> TSFC_out { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<double> EGT_out { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<double> Fnet_out { get; set; }
    }
    #endregion 


}
