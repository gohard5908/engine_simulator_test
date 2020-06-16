using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ZS.TestProject.Entity;
using ZS.TestProject.IDAL;

namespace ZS.TestProject.DALMySql
{
    /// <summary>
    /// 
    /// </summary>
	public class Ss_data : BaseDALMySql<Ss_dataInfo>, ISs_data
	{
		#region 对象实例及构造函数

		public static Ss_data Instance
		{
			get
			{
				return new Ss_data();
			}
		}
		public Ss_data() : base("ss_data","sim_date")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Ss_dataInfo DataReaderToEntity(IDataReader dataReader)
		{
			Ss_dataInfo info = new Ss_dataInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.Sim_date = reader.GetDateTime("sim_date");
			info.Altitude = reader.GetDouble("altitude");
			info.Mach = reader.GetDouble("mach");
			info.P15 = reader.GetDouble("P15");
			info.T15 = reader.GetDouble("T15");
			info.P2 = reader.GetDouble("P2");
			info.T2 = reader.GetDouble("T2");
			info.P21 = reader.GetDouble("P21");
			info.T21 = reader.GetDouble("T21");
			info.P25 = reader.GetDouble("P25");
			info.T25 = reader.GetDouble("T25");
			info.P3 = reader.GetDouble("P3");
			info.T3 = reader.GetDouble("T3");
			info.Ps3 = reader.GetDouble("Ps3");
			info.Ts3 = reader.GetDouble("Ts3");
			info.P4 = reader.GetDouble("P4");
			info.T4 = reader.GetDouble("T4");
			info.P45 = reader.GetDouble("P45");
			info.T45 = reader.GetDouble("T45");
			info.P5 = reader.GetDouble("P5");
			info.T5 = reader.GetDouble("T5");
			info.Fgross = reader.GetDouble("Fgross");
			info.Fnet = reader.GetDouble("Fnet");
			info.TSFC = reader.GetDouble("TSFC");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Ss_dataInfo obj)
		{
		    Ss_dataInfo info = obj as Ss_dataInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("sim_date", info.Sim_date);
 			hash.Add("altitude", info.Altitude);
 			hash.Add("mach", info.Mach);
 			hash.Add("P15", info.P15);
 			hash.Add("T15", info.T15);
 			hash.Add("P2", info.P2);
 			hash.Add("T2", info.T2);
 			hash.Add("P21", info.P21);
 			hash.Add("T21", info.T21);
 			hash.Add("P25", info.P25);
 			hash.Add("T25", info.T25);
 			hash.Add("P3", info.P3);
 			hash.Add("T3", info.T3);
 			hash.Add("Ps3", info.Ps3);
 			hash.Add("Ts3", info.Ts3);
 			hash.Add("P4", info.P4);
 			hash.Add("T4", info.T4);
 			hash.Add("P45", info.P45);
 			hash.Add("T45", info.T45);
 			hash.Add("P5", info.P5);
 			hash.Add("T5", info.T5);
 			hash.Add("Fgross", info.Fgross);
 			hash.Add("Fnet", info.Fnet);
 			hash.Add("TSFC", info.TSFC);
 				
			return hash;
		}

        /// <summary>
        /// 获取字段中文别名（用于界面显示）的字典集合
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, string> GetColumnNameAlias()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            #region 添加别名解析
            //dict.Add("ID", "编号");
            dict.Add("Sim_date", "");
             dict.Add("Altitude", "");
             dict.Add("Mach", "");
             dict.Add("P15", "");
             dict.Add("T15", "");
             dict.Add("P2", "");
             dict.Add("T2", "");
             dict.Add("P21", "");
             dict.Add("T21", "");
             dict.Add("P25", "");
             dict.Add("T25", "");
             dict.Add("P3", "");
             dict.Add("T3", "");
             dict.Add("Ps3", "");
             dict.Add("Ts3", "");
             dict.Add("P4", "");
             dict.Add("T4", "");
             dict.Add("P45", "");
             dict.Add("T45", "");
             dict.Add("P5", "");
             dict.Add("T5", "");
             dict.Add("Fgross", "");
             dict.Add("Fnet", "");
             dict.Add("TSFC", "");
             #endregion

            return dict;
        }

    }
}