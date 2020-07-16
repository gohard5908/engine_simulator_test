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
    public partial class FrmEditInputData : BaseForm
    {
        public string ID = string.Empty;

        public FrmEditInputData()
        {
            InitializeComponent();
            Init();

        }
        //视情况选择性显示，应对新建和编辑两种状况
        public void Init()  
        {
            if(string.IsNullOrEmpty(ID))
            {
                btnSave.Visible = false;
               
            }
            else
            {
                btnAdd.Visible = false;
                btnSave.Visible = true;
                Input_para_setupInfo info = BLLFactory<Input_para_setup>.Instance.FindByID(Convert.ToInt32(ID));
                showOldData(info);
            }
        }
        public void showOldData(Input_para_setupInfo info)
        {
            textEdit_ID.Text = info.Input_para_ID.ToString();
            textEdit_W.Text = info.W.ToString();
            textEdit_FanRline.Text = info.Fan_Rline.ToString();
            textEdit_BPR.Text = info.BPR.ToString();
            textEdit_LPCRline.Text = info.LPC_Rline.ToString();
            textEdit_HPCRline.Text = info.HPC_Rline.ToString();
            textEdit_HPCPR.Text = info.HPT_PR.ToString();
            textEdit_LPCPR.Text = info.LPT_PR.ToString();
            textEdit_LPShaft.Text = info.LP_shaft.ToString();
            textEdit_HPShaft.Text = info.HP_shaft.ToString();
            textEdit_Altitude.Text = info.Altitude.ToString();
            textEdit_DeltaTemp.Text = info.DeltaTamb.ToString();
            textEdit_MachNum.Text = info.MachNumb.ToString();
            textEdit_Wfin.Text = info.Wfin.ToString();
        }
        //添加入口参数记录按钮处理事件
        public void btnAdd_Click(object sender, EventArgs e)
        {
            Input_para_setupInfo info=new Input_para_setupInfo();
            SetInfo(info);
            try
            {
                #region 新增数据
                bool exist = BLLFactory<Input_para_setup>.Instance.IsExistKey("Input_para_ID", info.Input_para_ID);
                if (exist)
                {
                    MessageDxUtil.ShowTips("指定的数据编号已经存在，不能重复添加，请修改");
                    //return false;
                }

                bool succeed = BLLFactory<Input_para_setup>.Instance.Insert(info);
              
                if (succeed)
                {
                    /*  try
                     {
                         //不管是更新还是新增，如果对应的备件编码在库房没有初始化，初始化之
                         bool isInit = BLLFactory<Stock>.Instance.CheckIsInitedWareHouse(this.txtBelongWareHouse.Text, this.txtItemNo.Text);
                         if (!isInit)
                         {
                             BLLFactory<Stock>.Instance.InitStockQuantity(info, 0, this.txtBelongWareHouse.Text);
                         }
                     }
                     catch (Exception ex)
                     {
                         MessageDxUtil.ShowTips(string.Format("初始化库存为0失败：", ex.Message));
                     }
                  */
                   // return true;
                    MessageDxUtil.ShowTips("入口参数数据保存成功");
                    this.DialogResult = DialogResult.OK;
                }
               
                #endregion
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }
           // return false;

        }

        /// 编辑状态下从控件取值函数
        private void SetInfo(Input_para_setupInfo info)
        {
            info.Input_para_ID =Convert.ToInt32(textEdit_ID.Text);
            info.W = float.Parse(textEdit_W.Text);
            info.Fan_Rline = float.Parse(textEdit_FanRline.Text);
            info.BPR = float.Parse(textEdit_BPR.Text);
            info.LPC_Rline = float.Parse(textEdit_LPCRline.Text);
            info.HPC_Rline = float.Parse(textEdit_HPCRline.Text);
            info.HPT_PR = float.Parse(textEdit_HPCPR.Text);
            info.LPT_PR = float.Parse(textEdit_LPCPR.Text);
            info.LP_shaft = float.Parse(textEdit_LPShaft.Text);
            info.HP_shaft = float.Parse(textEdit_HPShaft.Text);
            info.Altitude = float.Parse(textEdit_Altitude.Text);
            info.DeltaTamb = float.Parse(textEdit_DeltaTemp.Text);
            info.MachNumb = float.Parse(textEdit_MachNum.Text);
            info.Wfin = float.Parse(textEdit_Wfin.Text);
        

        }
        //编辑状态保存按钮事件处理
        private void btnSave_Click(object sender, EventArgs e)
        {
            Input_para_setupInfo info = BLLFactory<Input_para_setup>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    bool succeed = BLLFactory<Input_para_setup>.Instance.Update(info, info.Input_para_ID);
                    if (succeed)
                    {
                        MessageDxUtil.ShowTips("保存成功");
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
        }
        //取消按钮事件
        private void btnCancer_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }



    }
}