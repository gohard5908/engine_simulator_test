using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using ZS.TestProject.Entity;
using ZS.TestProject.IDAL;
using WHC.Pager.Entity;
using WHC.Framework.ControlUtil;
using ZS.TestProject.DALMySql;

namespace ZS.TestProject.BLL
{
    /// <summary>
    /// 
    /// </summary>
	public class Input_para_setup : BaseBLL<Input_para_setupInfo>
    {
        public Input_para_setup() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }


    }
}
