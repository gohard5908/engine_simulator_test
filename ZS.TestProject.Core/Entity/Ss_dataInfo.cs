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
    public class Ss_dataInfo : BaseEntity
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public Ss_dataInfo()
		{
             this.Altitude= 0;
             this.Mach= 0;
             this.P15= 0;
             this.T15= 0;
             this.P2= 0;
             this.T2= 0;
             this.P21= 0;
             this.T21= 0;
             this.P25= 0;
             this.T25= 0;
             this.P3= 0;
             this.T3= 0;
             this.Ps3= 0;
             this.Ts3= 0;
             this.P4= 0;
             this.T4= 0;
             this.P45= 0;
             this.T45= 0;
             this.P5= 0;
             this.T5= 0;
             this.Fgross= 0;
             this.Fnet= 0;
             this.TSFC= 0;
  
		}

        #region Property Members
        
		[DataMember]
        public virtual DateTime Sim_date { get; set; }

		[DataMember]
        public virtual double Altitude { get; set; }

		[DataMember]
        public virtual double Mach { get; set; }

		[DataMember]
        public virtual double P15 { get; set; }

		[DataMember]
        public virtual double T15 { get; set; }

		[DataMember]
        public virtual double P2 { get; set; }

		[DataMember]
        public virtual double T2 { get; set; }

		[DataMember]
        public virtual double P21 { get; set; }

		[DataMember]
        public virtual double T21 { get; set; }

		[DataMember]
        public virtual double P25 { get; set; }

		[DataMember]
        public virtual double T25 { get; set; }

		[DataMember]
        public virtual double P3 { get; set; }

		[DataMember]
        public virtual double T3 { get; set; }

		[DataMember]
        public virtual double Ps3 { get; set; }

		[DataMember]
        public virtual double Ts3 { get; set; }

		[DataMember]
        public virtual double P4 { get; set; }

		[DataMember]
        public virtual double T4 { get; set; }

		[DataMember]
        public virtual double P45 { get; set; }

		[DataMember]
        public virtual double T45 { get; set; }

		[DataMember]
        public virtual double P5 { get; set; }

		[DataMember]
        public virtual double T5 { get; set; }

		[DataMember]
        public virtual double Fgross { get; set; }

		[DataMember]
        public virtual double Fnet { get; set; }

		[DataMember]
        public virtual double TSFC { get; set; }


        #endregion

    }
}