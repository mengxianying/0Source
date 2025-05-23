using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_boclb。
	/// </summary>
	public class PBnet_boclb:IPBnet_boclb
	{
		public PBnet_boclb()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("bocid", "PBnet_boclb"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int bocid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_boclb");
			strSql.Append(" where bocid=@bocid ");
			SqlParameter[] parameters = {
					new SqlParameter("@bocid", SqlDbType.Int,4)};
			parameters[0].Value = bocid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_boclb model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_boclb(");
			strSql.Append("PBnet_boclbname)");
			strSql.Append(" values (");
			strSql.Append("@PBnet_boclbname)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PBnet_boclbname", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.PBnet_boclbname;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return -1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_boclb model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_boclb set ");
			strSql.Append("PBnet_boclbname=@PBnet_boclbname");
			strSql.Append(" where bocid=@bocid ");
			SqlParameter[] parameters = {
					new SqlParameter("@bocid", SqlDbType.Int,4),
					new SqlParameter("@PBnet_boclbname", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.bocid;
			parameters[1].Value = model.PBnet_boclbname;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int bocid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_boclb ");
			strSql.Append(" where bocid=@bocid ");
			SqlParameter[] parameters = {
					new SqlParameter("@bocid", SqlDbType.Int,4)};
			parameters[0].Value = bocid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_boclb GetModel(int bocid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 bocid,PBnet_boclbname from PBnet_boclb ");
			strSql.Append(" where bocid=@bocid ");
			SqlParameter[] parameters = {
					new SqlParameter("@bocid", SqlDbType.Int,4)};
			parameters[0].Value = bocid;

			Pbzx.Model.PBnet_boclb model=new Pbzx.Model.PBnet_boclb();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["bocid"].ToString()!="")
				{
					model.bocid=int.Parse(ds.Tables[0].Rows[0]["bocid"].ToString());
				}
				model.PBnet_boclbname=ds.Tables[0].Rows[0]["PBnet_boclbname"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select bocid,PBnet_boclbname ");
			strSql.Append(" FROM PBnet_boclb ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "PBnet_boclb";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

