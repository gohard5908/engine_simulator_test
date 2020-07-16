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
	public class Input_para_setup : BaseDALMySql<Input_para_setupInfo>, IInput_para_setup
	{
		#region 对象实例及构造函数

		public static Input_para_setup Instance
		{
			get
			{
				return new Input_para_setup();
			}
		}
		public Input_para_setup() : base("input_para_setup","input_para_ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override Input_para_setupInfo DataReaderToEntity(IDataReader dataReader)
		{
			Input_para_setupInfo info = new Input_para_setupInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.Input_para_ID = reader.GetInt32("input_para_ID");
			info.W = reader.GetSingle("W");
			info.Fan_Rline = reader.GetSingle("Fan_Rline");
			info.BPR = reader.GetSingle("BPR");
			info.LPC_Rline = reader.GetSingle("LPC_Rline");
			info.HPC_Rline = reader.GetSingle("HPC_Rline");
			info.HPT_PR = reader.GetSingle("HPT_PR");
			info.LPT_PR = reader.GetSingle("LPT_PR");
			info.LP_shaft = reader.GetSingle("LP_shaft");
			info.HP_shaft = reader.GetSingle("HP_shaft");
			info.Altitude = reader.GetSingle("Altitude");
			info.DeltaTamb = reader.GetSingle("DeltaTamb");
			info.MachNumb = reader.GetSingle("MachNumb");
			info.Wfin = reader.GetSingle("Wfin");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(Input_para_setupInfo obj)
		{
		    Input_para_setupInfo info = obj as Input_para_setupInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("input_para_ID", info.Input_para_ID);
 			hash.Add("W", info.W);
 			hash.Add("Fan_Rline", info.Fan_Rline);
 			hash.Add("BPR", info.BPR);
 			hash.Add("LPC_Rline", info.LPC_Rline);
 			hash.Add("HPC_Rline", info.HPC_Rline);
 			hash.Add("HPT_PR", info.HPT_PR);
 			hash.Add("LPT_PR", info.LPT_PR);
 			hash.Add("LP_shaft", info.LP_shaft);
 			hash.Add("HP_shaft", info.HP_shaft);
 			hash.Add("Altitude", info.Altitude);
 			hash.Add("DeltaTamb", info.DeltaTamb);
 			hash.Add("MachNumb", info.MachNumb);
 			hash.Add("Wfin", info.Wfin);
 				
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
            dict.Add("Input_para_ID", "编号");
             dict.Add("W", "进气流量");
             dict.Add("Fan_Rline", "风扇R值");
             dict.Add("BPR", "燃烧室");
             dict.Add("LPC_Rline", "低压风扇R值");
             dict.Add("HPC_Rline", "高压风扇R值");
             dict.Add("HPT_PR", "高压涡轮压比");
             dict.Add("LPT_PR", "低压涡轮压比");
             dict.Add("LP_shaft", "低速轴转速");
             dict.Add("HP_shaft", "高速轴转速");
             dict.Add("Altitude", "高度");
             dict.Add("DeltaTamb", "温差");
             dict.Add("MachNumb", "马赫数");
             dict.Add("Wfin", "燃油流量");
             #endregion

            return dict;
        }

    }
}