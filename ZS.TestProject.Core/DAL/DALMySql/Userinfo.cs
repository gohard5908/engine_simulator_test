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
	public class Userinfo : BaseDALMySql<UserinfoInfo>, IUserinfo
	{
		#region 对象实例及构造函数

		public static Userinfo Instance
		{
			get
			{
				return new Userinfo();
			}
		}
		public Userinfo() : base("userinfo","ID")
		{
		}

		#endregion

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <returns>实体类对象</returns>
		protected override UserinfoInfo DataReaderToEntity(IDataReader dataReader)
		{
			UserinfoInfo info = new UserinfoInfo();
			SmartDataReader reader = new SmartDataReader(dataReader);
			
			info.ID = reader.GetInt32("ID");
			info.Username = reader.GetString("username");
			
			return info;
		}

		/// <summary>
		/// 将实体对象的属性值转化为Hashtable对应的键值
		/// </summary>
		/// <param name="obj">有效的实体对象</param>
		/// <returns>包含键值映射的Hashtable</returns>
        protected override Hashtable GetHashByEntity(UserinfoInfo obj)
		{
		    UserinfoInfo info = obj as UserinfoInfo;
			Hashtable hash = new Hashtable(); 
			
			hash.Add("ID", info.ID);
 			hash.Add("username", info.Username);
 				
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
            dict.Add("ID", "编号");
             dict.Add("Username", "姓名");
             #endregion

            return dict;
        }

    }
}