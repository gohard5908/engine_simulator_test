using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using WHC.Framework.BaseUI;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft;

using ZS.TestProject.Entity;
using ZS.TestProject.BLL;

using ZS.TestProject.MLApp_BLL;

namespace ZS.TestProject.UIDx
{
   
    public partial class Frm_simulator_SS : BaseDock
    {
        MLApp.MLApp matlab = new MLApp.MLApp();  //创建matlab引擎

        public static Frm_simulator_SS frm_SS;

        string str_chartPath = "D:\\Engine_Simulator\\Matlab_Simulator_SS\\SS_Sim_Data";   //
        string strJson_FAN = null;
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public Frm_simulator_SS()
        {
            InitializeComponent();
            frm_SS=this;

            asc.controllInitializeSize(this);
          // webBrowser1.ObjectForScripting = this; //（这个属性比较重要，可以通过这个属性，把WINFROM中的变量，传递到JS中，供内嵌的网页使用；但设置到的类型必须是COM可见的，所以要设置     [System.Runtime.InteropServices.ComVisibleAttribute(true)]，因为我的值设置为this,所以这个特性要加载窗体类上）
            
            ObjectForScriptingHelper helper = new ObjectForScriptingHelper(this);
            this.webBrowser1.ObjectForScripting = helper;
            
        }

        private void Page_SizeChanged(object sender, EventArgs e)  //页面大小改变，控件随之改变
        {
            asc.controlAutoSize(this);
        }


        //选择好工况之后的确认按钮
        private void simpleButton1_Click(object sender, EventArgs e) 
        {
            //这部分模拟运行，调用matlab引擎；
            #region 这里模拟从数据库中获取输入配置，构造一个固定的Input_para_setupInfo类，
            Input_para_setupInfo sim_input_data2setup = new Input_para_setupInfo();//
            sim_input_data2setup.Input_para_ID = 0;
            sim_input_data2setup.W = 674.22f;
            sim_input_data2setup.Fan_Rline = 2.3706f;
            sim_input_data2setup.BPR = 5.0408f;
            sim_input_data2setup.LPC_Rline = 1.7664f;
            sim_input_data2setup.HPC_Rline = 2.0424f;
            sim_input_data2setup.HPT_PR = 2.670f;
            sim_input_data2setup.LPT_PR = 4.886f;
            sim_input_data2setup.LP_shaft = 3667.6f;
            sim_input_data2setup.HP_shaft = 7390.0f;
            sim_input_data2setup.Altitude = 34000;
            sim_input_data2setup.DeltaTamb = 0;
            sim_input_data2setup.MachNumb = 0.8f;
            sim_input_data2setup.Wfin = 1.914f;
            #endregion
            // bool ifSucceed;
          // 
            Matlab_Sim_Helper.set_inputData_forSim(matlab, sim_input_data2setup);
        }

        //模拟运行按钮，模拟运行成果结果存入JSON
        public void button1_Click(object sender, EventArgs e)
        {
            
            Matlab_Sim_Helper simHelper = new Matlab_Sim_Helper();

            if (simHelper.sim_SS_Model(matlab))
            {
                MessageBox.Show("仿真成功");

                // 这里应该将仿真结果呈现

                Sim_data_Root simdata = jiexi_json(return_SSdataStruct(str_chartPath + "\\SS_Sim_Data.json")); //取出仿真得到的json，并解析到对应实体类

                MessageBox.Show(simdata.SS_simData.Altitude.ToString());  //这里成功验证取出了值
                //显示函数，将稳态仿真结果呈现
                showSimResultInForm(simdata);
                

            }
            else
            {
                MessageBox.Show(simHelper._strError);
            }  

            
            /*
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

            */
            /*
            this.strJson_FAN = make_Json_test(); //返回了json格式的对象
          // this.webBrowser1.Url = new Uri(str + "\\test_charts_Fan.html");
            

            //换一种方式，将数据保存为JSON格式，保存路径固定下来   测试地址：str

            //首先删除JSON格式文件，防止重名
            
            //将要绘制的数据存入JSON中，保存位置： str 首先检查是否有重名

            string fp = str_chartPath + "\\test.json";
            if (!File.Exists(fp))  // 判断是否已有相同文件  using system.IO
            {
                FileStream fs1 = new FileStream(fp, FileMode.Create, FileAccess.ReadWrite);   //创建了json文件
                fs1.Close();
            }
            File.WriteAllText(fp, strJson_FAN);  //将strJson_FAN写入了文件test.json
            */
        }

        //读取指定JSON文件到字符串
        public string return_SSdataStruct(string pathofSS_sim_data_json)
        {
            string jsonstring = File.ReadAllText(pathofSS_sim_data_json);
            return jsonstring;

        }
        //解析json 到 Sim_data_Root 类
        public Sim_data_Root jiexi_json(string json_str)
        {
            Sim_data_Root simdata = Newtonsoft.Json.JsonConvert.DeserializeObject<Sim_data_Root>(json_str);
            return simdata;
           
        }
        
        //显示数据到“稳态数据”页
        public void showSimResultInForm(Sim_data_Root simdata)
        {
            textEdit1.Text = simdata.SS_simData.Altitude.ToString();
            textEdit2.Text = simdata.SS_simData.Mach.ToString();
            textEdit3.Text = simdata.SS_simData.Delta.ToString();
            textEdit4.Text = simdata.SS_simData.S15.T15.ToString();
            textEdit5.Text = simdata.SS_simData.S2.P2.ToString();
            textEdit6.Text = simdata.SS_simData.S2.T2.ToString();
            textEdit7.Text = simdata.SS_simData.S21.P21.ToString();
            textEdit8.Text = simdata.SS_simData.S21.T21.ToString();
            textEdit9.Text = simdata.SS_simData.S25.P25.ToString();
            textEdit10.Text = simdata.SS_simData.S25.T25.ToString();
            textEdit11.Text = simdata.SS_simData.S3.P3.ToString();
            textEdit12.Text = simdata.SS_simData.S3.T3.ToString();
            textEdit13.Text = simdata.SS_simData.S3all.Ps3.ToString();
            textEdit14.Text = simdata.SS_simData.S3all.Ts3.ToString();
            textEdit15.Text = simdata.SS_simData.S4.P4.ToString();
            textEdit16.Text = simdata.SS_simData.S4.T4.ToString();
            textEdit17.Text = simdata.SS_simData.S45.P45.ToString();
            textEdit18.Text = simdata.SS_simData.S45.T45.ToString();
            textEdit19.Text = simdata.SS_simData.S5.P5.ToString();
            textEdit20.Text = simdata.SS_simData.S5.T5.ToString();
            textEdit21.Text = simdata.SS_simData.Thrust.Fgross.ToString();
            textEdit22.Text = simdata.SS_simData.Thrust.Fnet.ToString();
            textEdit23.Text = simdata.SS_simData.TSFC.ToString();

            textEdit24.Text = simdata.SS_simData.S15.P15.ToString();


            //构造SS_data实体类，准备存数据库
            
            Ss_dataInfo ss_data = new Ss_dataInfo();
            ss_data.Sim_date = DateTime.Now;
            ss_data.Altitude = simdata.SS_simData.Altitude;
            ss_data.Mach = simdata.SS_simData.Mach;
            ss_data.P15 = simdata.SS_simData.S15.P15;
            ss_data.T15= simdata.SS_simData.S15.T15;
            ss_data.P2 = simdata.SS_simData.S2.P2;
            ss_data.T2 = simdata.SS_simData.S2.T2;
            ss_data.P21= simdata.SS_simData.S21.P21;
            ss_data.T21 = simdata.SS_simData.S21.T21;
            ss_data.P25= simdata.SS_simData.S25.P25;
            ss_data.T25= simdata.SS_simData.S25.T25;
            ss_data.P3 = simdata.SS_simData.S3.P3;
            ss_data.T3 = simdata.SS_simData.S3.T3;
            ss_data.Ps3= simdata.SS_simData.S3all.Ps3;
            ss_data.Ts3 = simdata.SS_simData.S3all.Ts3;
            ss_data.P4 = simdata.SS_simData.S4.P4;
            ss_data.T4 = simdata.SS_simData.S4.T4;
            ss_data.P45= simdata.SS_simData.S45.P45;
            ss_data.T45 = simdata.SS_simData.S45.T45;
            ss_data.P5= simdata.SS_simData.S5.P5;
            ss_data.T5= simdata.SS_simData.S5.T5;
            ss_data.Fgross= simdata.SS_simData.Thrust.Fgross;
            ss_data.Fnet = simdata.SS_simData.Thrust.Fnet;
            ss_data.TSFC = simdata.SS_simData.TSFC;

            

            try {

                bool succeed = BLLFactory<Ss_data>.Instance.Insert(ss_data);
                if (succeed)
                {
                    // MessageDxUtil.ShowTips("数据保存成功");
                    //this.DialogResult = DialogResult.OK;
                }
            } catch
            {
                MessageBox.Show("出现问题");
            }



        }

        //历史仿真数据浏览按钮
        private void simpleButton3_Click(object sender, EventArgs e)
        {   
            //调出历史仿真数据窗口
            Frm_SS_historydata frm_historydata = new Frm_SS_historydata();

            frm_historydata.Show();
   
        }
        #region 定义稳态仿真结果数据类 SS_simData
        public class S15
        {
            public double P15 { get; set; }
            public double T15 { get; set; }
        }

        public class S2
        {
            public double P2 { get; set; }
            public double T2 { get; set; }
        }

        public class S21
        {

            public double P21 { get; set; }
            public double T21 { get; set; }
        }

        public class S25
        {
            public double P25 { get; set; }

            public double T25 { get; set; }
        }

        public class S3
        {
            public double P3 { get; set; }

            public double T3 { get; set; }
        }

        public class S3all
        {
            public double Ps3 { get; set; }

            public double Ts3 { get; set; }
        }

        public class S4
        {

            public double P4 { get; set; }
            public double T4 { get; set; }
        }

        public class S45
        {
            /// <summary>
            /// 
            /// </summary>
            public double P45 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double T45 { get; set; }
        }

        public class S5
        {
            /// <summary>
            /// 
            /// </summary>
            public double P5 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double T5 { get; set; }
        }

        public class Thrust
        {
            /// <summary>
            /// 
            /// </summary>
            public double Fgross { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double Fnet { get; set; }
        }

        public class FAN
        {
            /// <summary>
            /// 
            /// </summary>
            public double Wc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double PR { get; set; }
        }

        public class LPC
        {
            /// <summary>
            /// 
            /// </summary>
            public double Wc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double PR { get; set; }
        }

        public class HPC
        {
            /// <summary>
            /// 
            /// </summary>
            public double Wc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double PR { get; set; }
        }

        public class HPT
        {
            /// <summary>
            /// 
            /// </summary>
            public double Wc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double PR { get; set; }
        }

        public class LPT
        {
            /// <summary>
            /// 
            /// </summary>
            public double Wc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double PR { get; set; }
        }

        public class SS_simData
        {
            /// <summary>
            /// 
            /// </summary>
            public int Altitude { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double Mach { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int Delta { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public S15 S15 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public S2 S2 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public S21 S21 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public S25 S25 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public S3 S3 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public S3all S3all { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public S4 S4 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public S45 S45 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public S5 S5 { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Thrust Thrust { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double TSFC { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public FAN FAN { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public LPC LPC { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public HPC HPC { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public HPT HPT { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public LPT LPT { get; set; }
        }
        public class Sim_data_Root
        {
            /// <summary>
            /// 
            /// </summary>
            public SS_simData SS_simData { get; set; }
        }

        #endregion

        //显示仿真结果数据按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Url = new Uri(str_chartPath + "\\test_charts_Fan.html");
            this.webBrowser2.Url = new Uri(str_chartPath + "\\test_charts_Fan.html");
            this.webBrowser3.Url = new Uri(str_chartPath + "\\test_charts_Fan.html");
            this.webBrowser4.Url = new Uri(str_chartPath + "\\test_charts_Fan.html");
            this.webBrowser5.Url = new Uri(str_chartPath + "\\test_charts_Fan.html");
        }

        # region echarts相关(自己测试用：2020-02-19)
        //  这里定义一个类 series 用于后续通过Json向echarts中动态添加数据
        class Series
        {
            public string name
            {
                get;
                set;
            }
            public string type
            {
                get;
                set;
            }
            public List<double> x_data
            {
                get;
                set;
            }
            public List<double> y_data
            {
                get;
                set;
            }
        }


        //构造Json
        public string make_Json_test()
        {
            List<Series> series = new List<Series>(); //定义一个 series序列 列表

            Series test_series = new Series() { };
           // test_series.data = new List<double>() { };
            double test_data_x = Convert.ToDouble("3000");
            double test_data_y = Convert.ToDouble("2.0");
            test_series.name = "风扇特性图";
            test_series.x_data = new List<double>() { test_data_x };
            test_series.y_data = new List<double>() { test_data_y };

            series.Add(test_series);

            string strJson = Newtonsoft.Json.JsonConvert.SerializeObject(series, Newtonsoft.Json.Formatting.None);

            return strJson;
        }
        #endregion



    }


    [System.Runtime.InteropServices.ComVisibleAttribute(true)]//将该类设置为com可访问 
    public class ObjectForScriptingHelper
    {
        BaseDock mainWindow;
        public ObjectForScriptingHelper(BaseDock main)
        {
            mainWindow = main;
        }
        //这个方法就是网页上要反问的方法
        public void HtmlCmd(string cmd)
        {
            MessageBox.Show(cmd);
        }

        public void MyMessageBox(string message)
        {

            MessageBox.Show(message);
         }

        public string test()
        {
            string str = "hahahah";
            return str;
        }

    }

    

}
