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
    public class Input_para_setupInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Input_para_setupInfo()
		{
             this.Input_para_ID= 0;
             this.W= 0;
             this.Fan_Rline= 0;
             this.BPR= 0;
             this.LPC_Rline= 0;
             this.HPC_Rline= 0;
             this.HPT_PR= 0;
             this.LPT_PR= 0;
             this.LP_shaft= 0;
             this.HP_shaft= 0;
             this.Altitude= 0;
             this.DeltaTamb= 0;
             this.MachNumb= 0;
             this.Wfin= 0;
  
		}

        #region Property Members
        
		[DataMember]
        public virtual int Input_para_ID { get; set; }

		[DataMember]
        public virtual float W { get; set; }

		[DataMember]
        public virtual float Fan_Rline { get; set; }

		[DataMember]
        public virtual float BPR { get; set; }

		[DataMember]
        public virtual float LPC_Rline { get; set; }

		[DataMember]
        public virtual float HPC_Rline { get; set; }

		[DataMember]
        public virtual float HPT_PR { get; set; }

		[DataMember]
        public virtual float LPT_PR { get; set; }

		[DataMember]
        public virtual float LP_shaft { get; set; }

		[DataMember]
        public virtual float HP_shaft { get; set; }

		[DataMember]
        public virtual float Altitude { get; set; }

		[DataMember]
        public virtual float DeltaTamb { get; set; }

		[DataMember]
        public virtual float MachNumb { get; set; }

		[DataMember]
        public virtual float Wfin { get; set; }


        #endregion

    }
}