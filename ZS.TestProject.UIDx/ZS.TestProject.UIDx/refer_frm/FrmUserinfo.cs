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

namespace ZS.TestProject.UIDx
{
    /// <summary>
    /// 
    /// </summary>	
    public partial class FrmUserinfo : BaseDock
    {
        public FrmUserinfo()
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
            this.winGridViewPager1.BestFitColumnWith = false;//�Ƿ�����Ϊ�Զ�������ȣ�falseΪ������
			this.winGridViewPager1.gridView1.DataSourceChanged +=new EventHandler(gridView1_DataSourceChanged);
            this.winGridViewPager1.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(gridView1_CustomColumnDisplayText);
            this.winGridViewPager1.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(gridView1_RowCellStyle);

            //�����س������в�ѯ
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
            //    if (status == "�����")
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
            //    e.DisplayText = string.Format("{0}��", e.Value);
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
        /// �����ݺ󣬷�����еĿ��
        /// </summary>
        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.winGridViewPager1.gridView1.Columns.Count > 0 && this.winGridViewPager1.gridView1.RowCount > 0)
            {
                //ͳһ����100���
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in this.winGridViewPager1.gridView1.Columns)
                {
                    column.Width = 100;
                }

                //�����������ر�Ŀ��
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
        /// ��д��ʼ�������ʵ�֣���������ˢ��
        /// </summary>
        public override void  FormOnLoad()
        {   
            BindData();
        }
        
        /// <summary>
        /// ��ʼ���ֵ��б�����
        /// </summary>
        private void InitDictItem()
        {
			//��ʼ������
        }
        
        /// <summary>
        /// ��ҳ�ؼ�ˢ�²���
        /// </summary>
        private void winGridViewPager1_OnRefresh(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// ��ҳ�ؼ�ɾ������
        /// </summary>
        private void winGridViewPager1_OnDeleteSelected(object sender, EventArgs e)
        {
            if (MessageDxUtil.ShowYesNoAndTips("��ȷ��ɾ��ѡ���ļ�¼ô��") == DialogResult.No)
            {
                return;
            }

            int[] rowSelected = this.winGridViewPager1.GridView1.GetSelectedRows();
            foreach (int iRow in rowSelected)
            {
                string ID = this.winGridViewPager1.GridView1.GetRowCellDisplayText(iRow, "ID");
                BLLFactory<Userinfo>.Instance.Delete(ID);
            }
             
            BindData();
        }
        
        /// <summary>
        /// ��ҳ�ؼ��༭�����
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
                FrmEditUserinfo dlg = new FrmEditUserinfo();
                dlg.ID = ID;
                dlg.IDList = IDList;
                dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
                dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
                
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
        /// ��ҳ�ؼ���������
        /// </summary>        
        private void winGridViewPager1_OnAddNew(object sender, EventArgs e)
        {
            btnAddNew_Click(null, null);
        }
        
        /// <summary>
        /// ��ҳ�ؼ�ȫ����������ǰ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnStartExport(object sender, EventArgs e)
        {
            string where = GetConditionSql();
            this.winGridViewPager1.AllToExport = BLLFactory<Userinfo>.Instance.FindToDataTable(where);
         }

        /// <summary>
        /// ��ҳ�ؼ���ҳ�Ĳ���
        /// </summary> 
        private void winGridViewPager1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        
        /// <summary>
        /// �߼���ѯ����������
        /// </summary>
        private SearchCondition advanceCondition;
        
        /// <summary>
        /// ���ݲ�ѯ���������ѯ���
        /// </summary> 
        private string GetConditionSql()
        {
            //������ڸ߼���ѯ������Ϣ����ʹ�ø߼���ѯ����������ʹ������������ѯ
            SearchCondition condition = advanceCondition;
            if (condition == null)
            {
                condition = new SearchCondition();
                condition.AddCondition("Username", this.txtUsername.Text.Trim(), SqlOperator.Like);
            }
            string where = condition.BuildConditionSql().Replace("Where", "");
            return where;
        }
        
        /// <summary>
        /// ���б�����
        /// </summary>
        private void BindData()
        {
        	//datatable
            this.winGridViewPager1.DisplayColumns = "username";
            this.winGridViewPager1.ColumnNameAlias = BLLFactory<Userinfo>.Instance.GetColumnNameAlias();//�ֶ�����ʾ����ת��

            #region ��ӱ�������

            this.winGridViewPager1.AddColumnAlias("Username", "username");

            #endregion

            string where = GetConditionSql();
	    		DataTable dt = BLLFactory<Userinfo>.Instance.FindToDataTable(where, this.winGridViewPager1.PagerInfo);
    		this.winGridViewPager1.DataSource = dt;
                this.winGridViewPager1.PrintTitle = "����";
         }
        
        /// <summary>
        /// ��ѯ���ݲ���
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
        	advanceCondition = null;//�������ò�ѯ������������ܻ�ʹ�ø߼���ѯ������
            BindData();
        }
        
        /// <summary>
        /// �������ݲ���
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmEditUserinfo dlg = new FrmEditUserinfo();
            dlg.OnDataSaved += new EventHandler(dlg_OnDataSaved);
            dlg.InitFunction(LoginUserInfo, FunctionDict);//���Ӵ��帳ֵ�û�Ȩ����Ϣ
            
            if (DialogResult.OK == dlg.ShowDialog())
            {
                BindData();
            }
        }
        
        /// <summary>
        /// �ṩ���ؼ��س�ִ�в�ѯ�Ĳ���
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
        /// ����Excel�Ĳ���
        /// </summary>          
        private void btnImport_Click(object sender, EventArgs e)
        {
            string templateFile = string.Format("{0}-ģ��.xls", moduleName);
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
            UserinfoInfo info = new UserinfoInfo();
             info.Username = dr["username"].ToString();
  
            success = BLLFactory<Userinfo>.Instance.Insert(info);
             return success;
        }

        /// <summary>
        /// ����Excel�Ĳ���
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string file = FileDialogHelper.SaveExcel(string.Format("{0}.xls", moduleName));
            if (!string.IsNullOrEmpty(file))
            {
                string where = GetConditionSql();
                List<UserinfoInfo> list = BLLFactory<Userinfo>.Instance.Find(where);
                 DataTable dtNew = DataTableHelper.CreateTable("���|int,username");
                DataRow dr;
                int j = 1;
                for (int i = 0; i < list.Count; i++)
                {
                    dr = dtNew.NewRow();
                    dr["���"] = j++;
                     dr["username"] = list[i].Username;
                     dtNew.Rows.Add(dr);
                }

                try
                {
                    string error = "";
                    AsposeExcelTools.DataTableToExcel2(dtNew, file, out error);
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageDxUtil.ShowError(string.Format("����Excel���ִ���{0}", error));
                    }
                    else
                    {
                        if (MessageDxUtil.ShowYesNoAndTips("�����ɹ����Ƿ���ļ���") == System.Windows.Forms.DialogResult.Yes)
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
                dlg.FieldTypeTable = BLLFactory<Userinfo>.Instance.GetFieldTypeList();
                dlg.ColumnNameAlias = BLLFactory<Userinfo>.Instance.GetColumnNameAlias();                
                 dlg.DisplayColumns = "username";

                #region �����б�����

                //dlg.AddColumnListItem("UserType", Portal.gc.GetDictData("��Ա����"));//�ֵ��б�
                //dlg.AddColumnListItem("Sex", "��,Ů");//�̶��б�
                //dlg.AddColumnListItem("Credit", BLLFactory<Userinfo>.Instance.GetFieldList("Credit"));//��̬�б�

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
