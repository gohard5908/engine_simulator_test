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

namespace ZS.TestProject.UIDx
{
    public partial class Frm_SS_historydata : BaseForm
    {
        public Frm_SS_historydata()
        {
            InitializeComponent();
            showHistorydata();

        }

        //显示所有历史仿真记录
        public void showHistorydata()
        {

             DataTable dt= BLLFactory<Ss_data>.Instance.GetAllToDataTable();
             this.winGridView1.DataSource = dt;
        }

    }
}
