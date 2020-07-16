using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;


using DevExpress.XtraBars;
using DevExpress.XtraTabbedMdi;

namespace ZS.TestProject.UIDx
{
    public partial class Mainform : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       // public  MLApp.MLApp matlab_test=new MLApp.MLApp();  //这部分首先在
        public Mainform()
        {
            InitializeComponent();
        }

        #region Tab顶部右键菜单

        private void xtraTabbedMdiManager1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DevExpress.XtraTab.ViewInfo.BaseTabHitInfo hi = xtraTabbedMdiManager1.CalcHitInfo(new Point(e.X, e.Y));
            if (hi.HitTest == DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeader)
            {
                //Form f = (hi.Page as DevExpress.XtraTabbedMdi.XtraMdiTabPage).MdiChild;
                //do something
                popupMenu1.ShowPopup(Cursor.Position);
            }
        }

        private void popMenuCloseCurrent_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMdiTabPage page = xtraTabbedMdiManager1.SelectedPage;
            if (page != null && page.MdiChild != null)
            {
                page.MdiChild.Close();
            }
        }

        private void popMenuCloseAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CloseAllDocuments();
        }

        private void popMenuCloseOther_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraMdiTabPage selectedPage = xtraTabbedMdiManager1.SelectedPage;
            Type currentType = selectedPage.MdiChild.GetType();

            for (int i = xtraTabbedMdiManager1.Pages.Count - 1; i >= 0; i--)
            {
                XtraMdiTabPage page = xtraTabbedMdiManager1.Pages[i];
                if (page != null && page.MdiChild != null)
                {
                    Form form = page.MdiChild;
                    if (form.GetType() != currentType)
                    {
                        form.Close();
                        if (form != null && !form.IsDisposed)
                        {
                            form.Dispose();
                        }
                    }
                }
            }
        }

        public void CloseAllDocuments()
        {
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
                if (form != null && !form.IsDisposed)
                {
                    form.Dispose();
                }
            }
        }
        #endregion



        private void Mainform_Load(object sender, EventArgs e)
        {

        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            /*  FrmInputData frm;
              frm = (FrmInputData)ChildWinManagement.LoadMdiForm(this, typeof(FrmInputData));
              frm.matlab = this.matlab_test;
            */
            CloseAllDocuments(); //首先关掉所有子页面
            Frm_datamanager frm;
            frm = (Frm_datamanager)ChildWinManagement.LoadMdiForm(this, typeof(Frm_datamanager));

            ChildWinManagement.LoadMdiForm(this, typeof(FrmInputData));

            frm.Activate();
            /*
            xtraTabbedMdiManager1.MdiParent = this;   //设置控件的父表单..
            FrmInputData frm = new FrmInputData ();
            frm.MdiParent = this;    //设置新建窗体的父表单为当前活动窗口
            frm.matlab = this.matlab_test;
            frm.Show();
             */

            //  ChildWinManagement.LoadMdiForm(this, typeof(FrmInputData));
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try {
                CloseAllDocuments(); //首先关掉所有子页面，譬如数据管理的
                ChildWinManagement.LoadMdiForm(this, typeof(Frm_simulator_SS)); //弹出稳态仿真功能页
            }
            catch
            {
                MessageBox.Show("有问题");
            }

        }

        public void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

            CloseAllDocuments(); //首先关掉所有子页面，譬如数据管理的
            ChildWinManagement.LoadMdiForm(this, typeof(Frm_simulator_Dyn)); //弹出动态仿真功能页
          
            /*FrmShowEngineMap frm;
            frm = (FrmShowEngineMap)ChildWinManagement.LoadMdiForm(this, typeof(FrmShowEngineMap));
            */
           // frm.matlab = this.matlab_test;               

            /*
            xtraTabbedMdiManager1.MdiParent = this;   //设置控件的父表单..
            FrmShowEngineMap frm = new FrmShowEngineMap();
            frm.MdiParent = this;    //设置新建窗体的父表单为当前活动窗口
            frm.matlab = this.matlab_test;
            frm.Show();
            */

           // ChildWinManagement.LoadMdiForm(this, typeof(FrmShowEngineMap));
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            CloseAllDocuments(); //首先关掉所有子页面，譬如数据管理的
            ChildWinManagement.LoadMdiForm(this, typeof(Frm_simulator_Deterioration)); //弹出动态仿真功能页
        }

        private void btnTestPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTestPage frm;
            frm = (FrmTestPage)ChildWinManagement.LoadMdiForm(this, typeof(FrmTestPage));
            //frm.matlab = this.matlab_test; 
        }

    }
}