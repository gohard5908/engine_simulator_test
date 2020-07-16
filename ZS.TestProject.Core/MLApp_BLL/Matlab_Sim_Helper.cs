using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.TestProject.MLApp_BLL
{
    public class Matlab_Sim_Helper
    {

       // public static MLApp.MLApp matlab_test;   // 试试在这里可不可以全局的使用MLApp, 比如获取父窗体的属性？

        public string _strError = String.Empty; //报错字符串

        public static MLApp.MLApp creatNew_MLApp()
        {
            MLApp.MLApp matlab = new MLApp.MLApp();
            return matlab;
        }
        
        public static void excute_test(MLApp.MLApp matlab)
        {
            string command = "cd E:/Engine_Control_Design/TTECTrA";
            matlab.Execute(command);
            command = "JT9D_setup_everything_Dyn();sim('JT9D_Model_Dyn.slx');";
            matlab.Visible = 1;
            matlab.Execute(command);
        }
        #region 静态仿真
        // 在matlab工作区配置初始参数
        public static void set_inputData_forSim(MLApp.MLApp matlab,Entity.Input_para_setupInfo info)
        {
           // string command = "cd E:/Engine_Control_Design/TTECTrA";

            //  这里测试新的文件夹
            string command = "cd D:/Engine_Simulator/Matlab_Simulator_SS";  //软件专属SS文件夹  这部分后续要摘清楚，2020.02.26
            matlab.Execute(command);
            command = "JT9D_setup_everything_Dyn();";     //  工作区先将基础变量都配置
            matlab.Visible = 1;
            matlab.Execute(command);

            string para_str = "MWS=CSharp_setup_Inputs(MWS," + info.W.ToString() + "," + info.Fan_Rline.ToString() + "," + info.BPR.ToString() + "," + info.LPC_Rline.ToString() + ","
    + info.HPC_Rline.ToString() + "," + info.LPT_PR.ToString() + "," + info.HPT_PR.ToString() + "," + info.LP_shaft.ToString() + "," + info.HP_shaft.ToString()
   + "," + info.Altitude.ToString() + "," + info.DeltaTamb.ToString() + "," + info.MachNumb.ToString() + "," + info.Wfin.ToString() + ");";

            matlab.Execute(para_str);       // 复写可供编辑的相关变量，此处是
          //  matlab.Execute("sim('JT9D_Model_Dyn.slx');");
           

        }

        // 驱动simulink仿真静态模型 
        public bool sim_SS_Model(MLApp.MLApp matlab)
        {  
            try
            {
                object result;
                matlab.GetWorkspaceData("MWS", "base", out result);
            }
            catch
            {
                _strError = "未配置仿真初始参数";
                return false;
            }
            matlab.Visible = 1;
            matlab.Execute("sim('JT9D_Model_SS_test_with_alti.slx');");
            matlab.Execute("save_SS_data_Json();");   //将稳态结果保存为JSON  (在指定文件夹D:\Engine_Simulator\Matlab_Simulator_SS\SS_Sim_Data)
            return true;
        }
        #endregion

        #region 动态仿真
        // 驱动simulink仿真动态模型
        public bool sim_Dyn_Model(MLApp.MLApp matlab)
        {
            try
            {
                object result;
                matlab.GetWorkspaceData("MWS", "base", out result);
            }
            catch
            {
                _strError = "未配置仿真初始参数";
                return false;
            }
            matlab.Execute("sim('JT9D_Model_Dyn.slx');");
            return true;
        }
        #endregion

        #region 退化仿真

        //设定退化趋势
        public void set_HealthPara_Data(MLApp.MLApp matlab)
        {
            string command = "cd D:/Engine_Simulator/Matlab_Simulator_Deterioration";  //软件专属Deter文件夹  这部分后续要摘清楚，2020.02.26
            matlab.Execute(command);
            matlab.Execute("make_HealthPara_data_2020_0415;");

        }

        //进行退化仿真,特定固定工况，即Nf恒定，部件退化。按仿真步长（最多到200），暂未考虑工况，
         public bool sim_Deter_Model(MLApp.MLApp matlab)
         {

             object result;
           //  object result1;
             try
             {
                
                 matlab.GetWorkspaceData("x", "base", out result);  //x代表飞行循环数据，make_HealthPara_data_2020_0415.m
             }
             catch
             {
                 _strError = "未配置退化趋势参数";
                 return false;
             }
             matlab.Execute("sim_all_loss;");
             result = null;

           //matlab.GetWorkspaceData("TSFC_out", "base", out result); //这里会报错 result改为result1，报错消失,或者清空一次result；
             try  
             {
                 
                 matlab.GetWorkspaceData("TSFC_out", "base", out result);  //x代表飞行循环数据，make_HealthPara_data_2020_0415.m
             }
             catch
             {
                 _strError = "未仿真成功";
                 
                 return false;
             }
              //这部分总会给出一个false结果，推测是刚开始sim、就进入了try里面判断。
             return true;
         }

        public bool test(MLApp.MLApp matlab)
         {
             object result;
             matlab.GetWorkspaceData("TSFC_out", "base", out result);
             return true;
         }
        #endregion 



        #region 公共支持函数
        // 取出matlab 工作区 指定 【名称】 的变量， 返回结构体
        public object getValue_fromWorkspace(MLApp.MLApp matlab,string ValueName,string workspace=null)
        {
            object result;
            try
            {
                if (workspace == null)
                {

                    matlab.GetWorkspaceData(ValueName, "base", out result);
                    return result;
                }
                else
                {
                    matlab.GetWorkspaceData(ValueName, workspace, out result);
                    return result;
                }
            }
            catch
            {
                _strError = "未能取到对应的值";
                return null;
            }

        }

        #endregion


    }
}
