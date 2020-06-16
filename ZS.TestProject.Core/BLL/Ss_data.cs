using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using ZS.TestProject.Entity;
using ZS.TestProject.IDAL;
using WHC.Pager.Entity;
using WHC.Framework.ControlUtil;

namespace ZS.TestProject.BLL
{
    /// <summary>
    /// 
    /// </summary>
	public class Ss_data : BaseBLL<Ss_dataInfo>
    {
        public Ss_data() : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}
