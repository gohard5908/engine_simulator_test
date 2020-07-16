using System;
using ZS.TestProject.Entity;
using ZS.TestProject.BLL;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using WHC.Framework.BaseUI;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ZS.TestProject.UIDx
{   

    public partial class FrmInputData : BaseDock
    {   
        public  MLApp.MLApp matlab;  //这里加 static 会报错  这里定义MATLAB引擎
        public FrmInputData()
        {
            InitializeComponent();
         // BindData();  %2020.2.12  部署数据后续需开放
         // BindData_tabPage_setPara();
     
        }

        # region 表单显示函数
        private void BindData()
        {
            this.winGridViewPager1.DisplayColumns = "Input_para_ID,W,Fan_Rline,BPR,LPC_Rline,HPC_Rline,HPT_PR,LPT_PR,LP_shaft,HP_shaft,Altitude,DeltaTamb,MachNumb,Wfin";

            #region 添加别名解析
            this.winGridViewPager1.AddColumnAlias("Input_para_ID", "编号");
            this.winGridViewPager1.AddColumnAlias("W", "进口流量");
            this.winGridViewPager1.AddColumnAlias("Fan_Rline", "风扇R线值");
            this.winGridViewPager1.AddColumnAlias("BPR", "燃烧室");
            this.winGridViewPager1.AddColumnAlias("LPC_Rline", "低压风扇R值");
            this.winGridViewPager1.AddColumnAlias("HPC_Rline", "高压风扇R值");
            this.winGridViewPager1.AddColumnAlias("HPT_PR", "高压涡轮压比");
            this.winGridViewPager1.AddColumnAlias("LPT_PR", "低压涡轮压比");
            this.winGridViewPager1.AddColumnAlias("LP_shaft", "低速轴转速");
            this.winGridViewPager1.AddColumnAlias("HP_shaft", "高速轴转速");
            this.winGridViewPager1.AddColumnAlias("Altitude", "高度");
            this.winGridViewPager1.AddColumnAlias("DeltaTamb", "温差");
            this.winGridViewPager1.AddColumnAlias("MachNumb", "马赫数");
            this.winGridViewPager1.AddColumnAlias("Wfin", "燃油流量");
            #endregion

            SearchCondition condition = new SearchCondition();
            condition.AddCondition("Altitude", this.textSearchAltitude.Text, SqlOperator.Equal)
                .AddCondition("MachNumb", this.textSearchMachNum.Text, SqlOperator.Like);
               // .AddCondition("DeltaTamb", "27", SqlOperator.Equal)     //这里先约束好是27，仿真大部分基于deltaTemp=27
                

            string filter = condition.BuildConditionSql();

            string sql = string.Format(@"Select Input_para_ID,W,Fan_Rline,BPR,LPC_Rline,HPC_Rline,HPT_PR,LPT_PR,
                                LP_shaft,HP_shaft,Altitude,DeltaTamb,MachNumb,Wfin from input_para_setup {0}", filter);
             
           // MessageBox.Show(sql);  //测试所构建的SQL语句是否合理
            DataTable dt = BLLFactory<Input_para_setup>.Instance.SqlTable(sql);
            this.winGridViewPager1.DataSource = dt;
            /*
            DataTable dtNew = new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                dtNew.Columns.Add(col.ColumnName, col.DataType);
            }
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                if (!dict.ContainsKey(row["ID"].ToString()))
                {
                    dtNew.ImportRow(row);
                    dict.Add(row["ID"].ToString(), row["ID"].ToString());
                }
            }

            this.winGridView1.DataSource = dtNew.DefaultView;
           // this.winGridView1.PrintTitle = Portal.gc.gAppUnit + " -- " + "入库单查询报表";
             */           
        }

        //入口参数配置页的表格显示函数
        private void BindData_tabPage_setPara()
        {
            this.winGridView1.DisplayColumns = "Input_para_ID,Altitude,DeltaTamb,MachNumb,Wfin";
            #region 添加别名解析
            this.winGridView1.AddColumnAlias("Input_para_ID", "编号");
            this.winGridView1.AddColumnAlias("Altitude", "高度");
            this.winGridView1.AddColumnAlias("DeltaTamb", "温差");
            this.winGridView1.AddColumnAlias("MachNumb", "马赫数");
            this.winGridView1.AddColumnAlias("Wfin", "燃油流量");
            #endregion
            DataTable dt = BLLFactory<Input_para_setup>.Instance.GetAllToDataTable();
            this.winGridView1.DataSource = dt;
        }
        #endregion 

        #region winGridViewPager的右键事件处理函数
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
        }

        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
            if (MessageUtil.ShowYesNoAndTips("您确定删除选定的记录么？") == DialogResult.No)
            {
                return;
            }

            int[] rowSelected = this.winGridViewPager1.GridView1.GetSelectedRows();
            if (rowSelected != null)
            {
                foreach (int iRow in rowSelected)
                {
                    string ID = this.winGridViewPager1.GridView1.GetRowCellDisplayText(iRow, "INPUT_PARA_ID");     //此处列名必须为全大写，否则报错
                    BLLFactory<Input_para_setup>.Instance.Delete(Convert.ToInt32(ID));

                    //MessageBox.Show(ID);
                }
                BindData();
            } 
        }

        private void winGridViewPager1_OnEditSelected(object sender, EventArgs e)
        {
            int[] rowSelected = this.winGridViewPager1.GridView1.GetSelectedRows();
            foreach (int iRow in rowSelected)
            {
                FrmEditInputData dlg = new FrmEditInputData();
                dlg.ID = this.winGridViewPager1.GridView1.GetRowCellDisplayText(iRow, "INPUT_PARA_ID");
                dlg.Init();
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    BindData();
                }

                break;
            }
           
        }

        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            btnAddNew_Click(null, null);
        }
        #endregion
        private void btnSearch_Click(object sender, EventArgs e)  //搜索按钮
        {
            BindData();
            // DataTable dt = BLLFactory<Input_para_setup>.Instance.GetAllToDataTable();
            // this.winGridView1.DataSource = dt;
        }
        private void btnAddNew_Click(object sender, EventArgs e) //增加按钮
        {
            FrmEditInputData Form = new FrmEditInputData();

            Form.ShowDialog(); //显示FrmEditInputData窗口
        }
        private void btnRefresh_Click(object sender, EventArgs e)  //刷新按钮
        {
           BindData();
           BindData_tabPage_setPara();
        }

        //入口参数配置应当在稳态运行模块中体现
        #region 参数配置页   

        //点击某行，获取对应数剧编号ID,显示在配置text控件          
        private void getDataID_whenClick(object sender, EventArgs e)
        {

            int[] rowSelected = this.winGridView1.GridView1.GetSelectedRows();

            string ID = this.winGridView1.gridView1.GetRowCellDisplayText(rowSelected[0], "input_para_ID");  //此处与分页控件有区别，分页控件不分大小写，此控件区分，而且按照数据库中的设计来写

           this.textEdit1.Text = ID;
      
        }

        // 配置入口参数按钮，
        private void btnSetData_inMatlab_Click(object sender, EventArgs e)
        {
              if(this.textEdit1.Text!=null)
              {
                 
                  try
                  {
                      string ID=this.textEdit1.Text;
                      if(BLLFactory<Input_para_setup>.Instance.IsExistKey("input_para_ID", Convert.ToInt32(ID)))
                      {
                          // 此处写利用matlab引擎将入口参数配置到matlab工作区的函数
                          Input_para_setupInfo info = BLLFactory<Input_para_setup>.Instance.FindByID(Convert.ToInt32(ID)); //按照ID查询得到实体
                          MLApp_BLL.Matlab_Sim_Helper.set_inputData_forSim(matlab,info);
                          MessageBox.Show("配置成功");
                      }


                  }
                  catch
                  {
                      MessageBox.Show("数据编号不正确");
                  }
              }
              else
              {    
                  MessageBox.Show("未配置数据编号，请检查！");
              }
        }


       //  测试能否建立静态matlab MLapp
        public static void  Init()
        {
            MLApp.MLApp matlab_test = null;
            Type matlabAppType = System.Type.GetTypeFromProgID("Matlab.Application");
            matlab_test = System.Activator.CreateInstance(matlabAppType) as MLApp.MLApp;
        }

        #endregion
           












    }
}
