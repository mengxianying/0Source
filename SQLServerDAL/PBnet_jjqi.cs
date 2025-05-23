using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_jjqi。
	/// </summary>
	public class PBnet_jjqi:IPBnet_jjqi
	{
		public PBnet_jjqi()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("jiid", "PBnet_jjqi"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int jiid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_jjqi");
			strSql.Append(" where jiid=@jiid ");
			SqlParameter[] parameters = {
					new SqlParameter("@jiid", SqlDbType.Int,4)};
			parameters[0].Value = jiid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_jjqi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_jjqi(");
			strSql.Append("jname)");
			strSql.Append(" values (");
			strSql.Append("@jname)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@jname", SqlDbType.Int,4)};
			parameters[0].Value = model.jname;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_jjqi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_jjqi set ");
			strSql.Append("jname=@jname");
			strSql.Append(" where jiid=@jiid ");
			SqlParameter[] parameters = {
					new SqlParameter("@jiid", SqlDbType.Int,4),
					new SqlParameter("@jname", SqlDbType.Int,4)};
			parameters[0].Value = model.jiid;
			parameters[1].Value = model.jname;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int jiid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_jjqi ");
			strSql.Append(" where jiid=@jiid ");
			SqlParameter[] parameters = {
					new SqlParameter("@jiid", SqlDbType.Int,4)};
			parameters[0].Value = jiid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_jjqi GetModel(int jiid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 jiid,jname from PBnet_jjqi ");
			strSql.Append(" where jiid=@jiid ");
			SqlParameter[] parameters = {
					new SqlParameter("@jiid", SqlDbType.Int,4)};
			parameters[0].Value = jiid;

			Pbzx.Model.PBnet_jjqi model=new Pbzx.Model.PBnet_jjqi();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["jiid"].ToString()!="")
				{
					model.jiid=int.Parse(ds.Tables[0].Rows[0]["jiid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["jname"].ToString()!="")
				{
					model.jname=int.Parse(ds.Tables[0].Rows[0]["jname"].ToString());
				}
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
			strSql.Append("select jiid,jname ");
			strSql.Append(" FROM PBnet_jjqi ");
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
			parameters[0].Value = "PBnet_jjqi";
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

