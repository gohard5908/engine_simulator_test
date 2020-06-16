using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.Dictionary;
using WHC.Framework.BaseUI;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;

using ZS.TestProject.BLL;
using ZS.TestProject.Entity;

namespace ZS.TestProject.UI
{
    /// <summary>
    /// 
    /// </summary>	
    public partial class FrmInput_para_setup : BaseDock
    {
        public FrmInput_para_setup()
        {
            InitializeComponent();

            InitDictItem();

            this.winGridViewPager1.OnPageChanged += new EventHandler(winGridViewPager1_OnPageChanged);
            this.winGridViewPager1.OnStartExport += new EventHandler(winGridViewPager1_OnStartExport);
            this.winGridViewPager1.OnEditSelected += new EventHandler(winGridViewPager1_OnEditSelected);
            this.winGridViewPager1.OnAddNew += new EventHandler(winGridViewPager1_OnAddNew);
            this.winGridViewPager1.OnDeleteSelected += new EventHandler(winGridViewPager1_OnDeleteSelected);
            this.winGridViewPager1.OnRefresh += new EventHandler(winGridViewPager1_OnRefresh);
            this.winGridViewPager1.AppendedMenu = this.contextMenuStrip1;
            this.winGridViewPager1.ShowLineNumber = true;
            this.winGridViewPager1.BestFitColumnWith = false;//是否设置为自动调整宽度，false为不设置
			this.winGridViewPager1.gridView1.DataSourceChanged +=new EventHandler(gridView1_DataSourceChanged);
            this.winGridViewPager1.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.winGridViewPager1.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

            //关联回车键进行查询
            foreach (Control control in this.layoutControl1.Controls)
            {
                control.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SearchControl_KeyUp);
            }
        }
        void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (e.Column.FieldName == "OrderStatus")
            //{
            //    string status = this.winGridViewPager1.gridView1.GetRowCellValue(e.RowHandle, "OrderStatus").ToString();
            //    Color color = Color.White;
            //    if (status == "已审核")
            //    {
            //        e.Appearance.BackColor = Color.Red;
            //        e.Appearance.BackColor2 = Color.LightCyan;
            //    }
            //}
        }
        void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
        	string columnName = e.Column.FieldName;
            if (e.Column.ColumnType == typeof(DateTime))
            {   
                if (e.Value != null)
                {
                    if (e.Value == DBNull.Value || Convert.ToDateTime(e.Value) <= Convert.ToDateTime("1900-1-1"))
                    {
                        e.DisplayText = "";
                    }
                    else
                    {
                        e.DisplayText = Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd HH:mm");//yyyy-MM-dd
                    }
                }
            }
            //else if (columnName == "Age")
            //{
            //    e.DisplayText = string.Format("{0}岁", e.Value);
            //}
            //else if (columnName == "ReceivedMoney")
            //{
            //    if (e.Value != null)
            //    {
            //        e.DisplayText = e.Value.ToString().ToDecimal().ToString("C");
            //    }
            //}
        }
        
        /// <summary>
        /// 绑定数据后，分配各列的宽度
        /// </summary>
        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.winGridViewPager1.gridView1.Columns.Count > 0 && this.winGridViewPager1.gridView1.RowCount > 0)
            {
                //统一设置100宽度
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.winGridViewPager1.gridView1.Columns)
                {
                    column.Width = 100;
                }

                //可特殊设置特别的宽度
                //SetGridColumWidth("Note", 200);
            }
        }

        private void SetGridColumWidth(string columnName, int width)
        {
            DevExpress.XtraGrid.Columns.GridColumn column = this.winGridViewPager1.gridView1.Columns.ColumnByFieldName(columnName);
            if (column != null)
            {
                column.Width = width;
            }
        }

        /// <summary>
        /// 编写初始化窗体的实现，可以用于刷新
        /// </summary>
        public override void  FormOnLoad()
        {   
            BindData();
        }
        
        /// <summary>
        /// 初始化字典列表内容
        /// </summary>
        private void InitDictItem()
        {
			//初始化代码
        }
        
        /// <summary>
        /// 分页控件刷新操作
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// 分页控件删除操作
        /// </summary>
        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndTips("您确定删除选定的记录么？") == DialogResult.No)
            {
                return;
            }

            int[] rowSelected = this.winGridViewPager1.GridView1.GetSelectedRows();
            foreach (int iRow in rowSelected)
            {
                string ID = this.winGridViewPager1.GridView1.GetRowCellDisplayText(iRow, "ID");
                BLLFactory<Input_para_setup>.Instance.Delete(ID);
            }
             
            BindData();
        }
        
        /// <summary>
        /// 分页控件编辑项操作
        /// </summary>
        private void winGridViewPager1_OnEditSelected(object sender, EventArgs e)
        {
            string ID = this.winGridViewPager1.gridView1.GetFocusedRowCellDisplayText("ID");
            List<string> IDList = new List<string>();
            for (int i = 0; i < this.winGridViewPager1.gridView1.RowCount; i++)
            {
                string strTemp = this.winGridViewPager1.GridView1.GetRowCellDisplayText(i, "ID");
                IDList.Add(strTemp);
            }

            if (!string.IsNullOrEmpty(ID))
            {
                FrmEditInput_para_setup dlg = new FrmEditInput_para_setup();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
                dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
                
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    BindData();
                }
            }
        }        
        
        void dlg_OnDataSaved(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// 分页控件新增操作
        /// </summary>        
        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            btnAddNew_Click(null, null);
        }
        
        /// <summary>
        /// 分页控件全部导出操作前的操作
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetConditionSql();
            this.winGridViewPager1.AllToExport = BLLFactory<Input_para_setup>.Instance.FindToDataTable(where);
         }

        /// <summary>
        /// 分页控件翻页的操作
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// 高级查询条件语句对象
        /// </summary>
        private SearchCondition advanceCondition;
        
        /// <summary>
        /// 根据查询条件构造查询语句
        /// </summary> 
        private string GetConditionSql()
        {
            //如果存在高级查询对象信息，则使用高级查询条件，否则使用主表条件查询
            SearchCondition condition = advanceCondition;
            if (condition == null)
            {
                condition = new SearchCondition();
                condition.AddNumericCondition("Altitude", this.txtAltitude1, this.txtAltitude2); //数值类型
                condition.AddNumericCondition("DeltaTamb", this.txtDeltaTamb1, this.txtDeltaTamb2); //数值类型
                condition.AddNumericCondition("MachNumb", this.txtMachNumb1, this.txtMachNumb2); //数值类型
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }
        
        /// <summary>
        /// 绑定列表数据
        /// </summary>
        private void BindData()
        {
        	//entity
            this.winGridViewPager1.DisplayColumns = "W,Fan_Rline,BPR,LPC_Rline,HPC_Rline,HPT_PR,LPT_PR,LP_shaft,HP_shaft,Altitude,DeltaTamb,MachNumb,Wfin";
            this.winGridViewPager1.ColumnNameAlias = BLLFactory<Input_para_setup>.Instance.GetColumnNameAlias();//字段列显示名称转义

            #region 添加别名解析

            //this.winGridViewPager1.AddColumnAlias("W", "W");
            //this.winGridViewPager1.AddColumnAlias("Fan_Rline", "Fan_Rline");
            //this.winGridViewPager1.AddColumnAlias("BPR", "BPR");
            //this.winGridViewPager1.AddColumnAlias("LPC_Rline", "LPC_Rline");
            //this.winGridViewPager1.AddColumnAlias("HPC_Rline", "HPC_Rline");
            //this.winGridViewPager1.AddColumnAlias("HPT_PR", "HPT_PR");
            //this.winGridViewPager1.AddColumnAlias("LPT_PR", "LPT_PR");
            //this.winGridViewPager1.AddColumnAlias("LP_shaft", "LP_shaft");
            //this.winGridViewPager1.AddColumnAlias("HP_shaft", "HP_shaft");
            //this.winGridViewPager1.AddColumnAlias("Altitude", "Altitude");
            //this.winGridViewPager1.AddColumnAlias("DeltaTamb", "DeltaTamb");
            //this.winGridViewPager1.AddColumnAlias("MachNumb", "MachNumb");
            //this.winGridViewPager1.AddColumnAlias("Wfin", "Wfin");

            #endregion

            string where = GetConditionSql();
	            List<Input_para_setupInfo> list = BLLFactory<Input_para_setup>.Instance.FindWithPager(where, this.winGridViewPager1.PagerInfo);
            this.winGridViewPager1.DataSource = new WHC.Pager.WinControl.SortableBindingList<Input_para_setupInfo>(list);
                this.winGridViewPager1.PrintTitle = "报表";
         }
        
        /// <summary>
        /// 查询数据操作
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
        	advanceCondition = null;//必须重置查询条件，否则可能会使用高级查询条件了
            BindData();
        }
        
        /// <summary>
        /// 新增数据操作
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmEditInput_para_setup dlg = new FrmEditInput_para_setup();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//给子窗体赋值用户权限信息
            
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BindData();
            }
        }
        
        /// <summary>
        /// 提供给控件回车执行查询的操作
        /// </summary>
        private void SearchControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }        

		 		 		 		 		 		 		 		 		 		 		 		 		 		 
        private string moduleName = "";
        /// <summary>
        /// 导入Excel的操作
        /// </summary>          
        private void btnImport_Click(object sender, EventArgs e)
        {
            string templateFile = string.Format("{0}-模板.xls", moduleName);
            FrmImportExcelData dlg = new FrmImportExcelData();
            dlg.SetTemplate(templateFile, System.IO.Path.Combine(Application.StartupPath, templateFile));
            dlg.OnDataSave += new FrmImportExcelData.SaveDataHandler(ExcelData_OnDataSave);
            dlg.OnRefreshData += new EventHandler(ExcelData_OnRefreshData);
            dlg.ShowDialog();
        }

        void ExcelData_OnRefreshData(object sender, EventArgs e)
        {
            BindData();
        }
        
        bool ExcelData_OnDataSave(DataRow dr)
        {
            bool success = false;
            bool converted = false;
            DateTime dtDefault = Convert.ToDateTime("1900-01-01");
            DateTime dt;
            Input_para_setupInfo info = new Input_para_setupInfo();
            info.Input_para_ID = dr["input_para_ID"].ToString().ToInt32();
              info.W = dr["W"].ToString();
              info.Fan_Rline = dr["Fan_Rline"].ToString();
              info.BPR = dr["BPR"].ToString();
              info.LPC_Rline = dr["LPC_Rline"].ToString();
              info.HPC_Rline = dr["HPC_Rline"].ToString();
              info.HPT_PR = dr["HPT_PR"].ToString();
              info.LPT_PR = dr["LPT_PR"].ToString();
              info.LP_shaft = dr["LP_shaft"].ToString();
              info.HP_shaft = dr["HP_shaft"].ToString();
              info.Altitude = dr["Altitude"].ToString();
              info.DeltaTamb = dr["DeltaTamb"].ToString();
              info.MachNumb = dr["MachNumb"].ToString();
              info.Wfin = dr["Wfin"].ToString();
  
            success = BLLFactory<Input_para_setup>.Instance.Insert(info);
             return success;
        }

        /// <summary>
        /// 导出Excel的操作
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string file = FileDialogHelper.SaveExcel(string.Format("{0}.xls", moduleName));
            if (!string.IsNullOrEmpty(file))
            {
                string where = GetConditionSql();
                List<Input_para_setupInfo> list = BLLFactory<Input_para_setup>.Instance.Find(where);
                 DataTable dtNew = DataTableHelper.CreateTable("序号|int,input_para_ID,W,Fan_Rline,BPR,LPC_Rline,HPC_Rline,HPT_PR,LPT_PR,LP_shaft,HP_shaft,Altitude,DeltaTamb,MachNumb,Wfin");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                    dr["序号"] = j++;
                    dr["input_para_ID"] = list[i].Input_para_ID;
                     dr["W"] = list[i].W;
                     dr["Fan_Rline"] = list[i].Fan_Rline;
                     dr["BPR"] = list[i].BPR;
                     dr["LPC_Rline"] = list[i].LPC_Rline;
                     dr["HPC_Rline"] = list[i].HPC_Rline;
                     dr["HPT_PR"] = list[i].HPT_PR;
                     dr["LPT_PR"] = list[i].LPT_PR;
                     dr["LP_shaft"] = list[i].LP_shaft;
                     dr["HP_shaft"] = list[i].HP_shaft;
                     dr["Altitude"] = list[i].Altitude;
                     dr["DeltaTamb"] = list[i].DeltaTamb;
                     dr["MachNumb"] = list[i].MachNumb;
                     dr["Wfin"] = list[i].Wfin;
                     dtNew.Rows.Add(dr);
                }

                try
                {
                    string error = "";
                    AsposeExcelTools.DataTableToExcel2(dtNew, file, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageDxUtil.ShowError(string.Format("导出Excel出现错误：{0}", error));
                    }
                    else
                    {
                        if (MessageDxUtil.ShowYesNoAndTips("导出成功，是否打开文件？") == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
         }
         
        private FrmAdvanceSearch dlg;
        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            if (dlg == null)
            {
                dlg = new FrmAdvanceSearch();
                dlg.FieldTypeTable = BLLFactory<Input_para_setup>.Instance.GetFieldTypeList();
                dlg.ColumnNameAlias = BLLFactory<Input_para_setup>.Instance.GetColumnNameAlias();                
                 dlg.DisplayColumns = "input_para_ID,W,Fan_Rline,BPR,LPC_Rline,HPC_Rline,HPT_PR,LPT_PR,LP_shaft,HP_shaft,Altitude,DeltaTamb,MachNumb,Wfin";

                #region 下拉列表数据

                //dlg.AddColumnListItem("UserType", Portal.gc.GetDictData("人员类型"));//字典列表
                //dlg.AddColumnListItem("Sex", "男,女");//固定列表
                //dlg.AddColumnListItem("Credit", BLLFactory<Input_para_setup>.Instance.GetFieldList("Credit"));//动态列表

                #endregion

                dlg.ConditionChanged += new FrmAdvanceSearch.ConditionChangedEventHandler(dlg_ConditionChanged);
            }
            dlg.ShowDialog();
        }

        void dlg_ConditionChanged(SearchCondition condition)
        {
            advanceCondition = condition;
            BindData();
        }
    }
}
