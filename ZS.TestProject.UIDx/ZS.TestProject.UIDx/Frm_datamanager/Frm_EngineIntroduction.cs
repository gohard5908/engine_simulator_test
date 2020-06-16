using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using WHC.Framework.BaseUI;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;


namespace ZS.TestProject.UIDx
{   
     
    public partial class Frm_datamanager : BaseDock
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        public Frm_datamanager()
        {
            InitializeComponent();
            asc.controllInitializeSize(this);
        }

        private void Page_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           // panel1.Visible = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            simpleButton1.Visible = true;
            simpleButton2.Visible = true;
        }
    }
}
