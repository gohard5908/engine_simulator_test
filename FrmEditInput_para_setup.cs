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
    public partial class FrmEditInput_para_setup : BaseEditForm
    {
    	/// <summary>
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
    	private Input_para_setupInfo tempInfo = new Input_para_setupInfo();
    	
        public FrmEditInput_para_setup()
        {
            InitializeComponent();
        }
                
        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            #region MyRegion
            if (this.txtAltitude.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtAltitude.Focus();
                result = false;
            }
             else if (this.txtDeltaTamb.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtDeltaTamb.Focus();
                result = false;
            }
             else if (this.txtMachNumb.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtMachNumb.Focus();
                result = false;
            }
            #endregion

            return result;
        }

        /// <summary>
        /// 初始化数据字典
        /// </summary>
        private void InitDictItem()
        {
			//初始化代码
        }                        

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            if (!string.IsNullOrEmpty(ID))
            {
                #region 显示信息
                Input_para_setupInfo info = BLLFactory<Input_para_setup>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象
                	
                        txtAltitude.Value = info.Altitude;
                               txtDeltaTamb.Value = info.DeltaTamb;
                               txtMachNumb.Value = info.MachNumb;
                         } 
                #endregion
                //this.btnOK.Enabled = HasFunction("Input_para_setup/Edit");             
            }
            else
            {
   
                //this.btnOK.Enabled = Portal.gc.HasFunction("Input_para_setup/Add");  
            }
            
            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(Input_para_setupInfo info)
        //{
        //    this.attachmentGUID.AttachmentGUID = info.AttachGUID;
        //    this.attachmentGUID.userId = LoginUserInfo.Name;

        //    string name = txtName.Text;
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        string dir = string.Format("{0}", name);
        //        this.attachmentGUID.Init(dir, tempInfo.ID, LoginUserInfo.Name);
        //    }
        //}

        public override void ClearScreen()
        {
            this.tempInfo = new Input_para_setupInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// 编辑或者保存状态下取值函数
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(Input_para_setupInfo info)
        {
                info.Altitude = Convert.ToSingle(txtAltitude.Value);
                       info.DeltaTamb = Convert.ToSingle(txtDeltaTamb.Value);
                       info.MachNumb = Convert.ToSingle(txtMachNumb.Value);
               }
         
        /// <summary>
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            Input_para_setupInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据

                bool succeed = BLLFactory<Input_para_setup>.Instance.Insert(info);
                if (succeed)
                {
                    //可添加其他关联操作

                    return true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }
            return false;
        }                 

        /// <summary>
        /// 编辑状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {

            Input_para_setupInfo info = BLLFactory<Input_para_setup>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = BLLFactory<Input_para_setup>.Instance.Update(info, info.ID);
                    if (succeed)
                    {
                        //可添加其他关联操作
                       
                        return true;
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
           return false;
        }
    }
}
