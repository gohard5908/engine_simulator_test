using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using WHC.Framework.ControlUtil;

namespace ZS.TestProject.Entity
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class UserinfoInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public UserinfoInfo()
		{
            this.ID= 0;
   
		}

        #region Property Members
        
		[DataMember]
        public virtual int ID { get; set; }

		[DataMember]
        public virtual string Username { get; set; }


        #endregion

    }
}