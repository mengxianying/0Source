using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_ipdata。
	/// </summary>
	public class PBnet_ipdata:IPBnet_ipdata
	{
		public PBnet_ipdata()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ip1,decimal ip2)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_ipdata");
			strSql.Append(" where ip1=@ip1 and ip2=@ip2 ");
			SqlParameter[] parameters = {
					new SqlParameter("@ip1", SqlDbType.Float),
					new SqlParameter("@ip2", SqlDbType.Float)};
			parameters[0].Value = ip1;
			parameters[1].Value = ip2;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Pbzx.Model.PBnet_ipdata model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_ipdata(");
			strSql.Append("ip1,ip2,country,city)");
			strSql.Append(" values (");
			strSql.Append("@ip1,@ip2,@country,@city)");
			SqlParameter[] parameters = {
					new SqlParameter("@ip1", SqlDbType.Float,8),
					new SqlParameter("@ip2", SqlDbType.Float,8),
					new SqlParameter("@country", SqlDbType.NVarChar,255),
					new SqlParameter("@city", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.ip1;
			parameters[1].Value = model.ip2;
			parameters[2].Value = model.country;
			parameters[3].Value = model.city;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_ipdata model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_ipdata set ");
			strSql.Append("country=@country,");
			strSql.Append("city=@city");
			strSql.Append(" where ip1=@ip1 and ip2=@ip2 ");
			SqlParameter[] parameters = {
					new SqlParameter("@ip1", SqlDbType.Float,8),
					new SqlParameter("@ip2", SqlDbType.Float,8),
					new SqlParameter("@country", SqlDbType.NVarChar,255),
					new SqlParameter("@city", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.ip1;
			parameters[1].Value = model.ip2;
			parameters[2].Value = model.country;
			parameters[3].Value = model.city;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(decimal ip1,decimal ip2)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_ipdata ");
			strSql.Append(" where ip1=@ip1 and ip2=@ip2 ");
			SqlParameter[] parameters = {
					new SqlParameter("@ip1", SqlDbType.Float),
					new SqlParameter("@ip2", SqlDbType.Float)};
			parameters[0].Value = ip1;
			parameters[1].Value = ip2;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_ipdata GetModel(decimal ip1,decimal ip2)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ip1,ip2,country,city from PBnet_ipdata ");
			strSql.Append(" where ip1=@ip1 and ip2=@ip2 ");
			SqlParameter[] parameters = {
					new SqlParameter("@ip1", SqlDbType.Float),
					new SqlParameter("@ip2", SqlDbType.Float)};
			parameters[0].Value = ip1;
			parameters[1].Value = ip2;

			Pbzx.Model.PBnet_ipdata model=new Pbzx.Model.PBnet_ipdata();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ip1"].ToString()!="")
				{
					model.ip1=decimal.Parse(ds.Tables[0].Rows[0]["ip1"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ip2"].ToString()!="")
				{
					model.ip2=decimal.Parse(ds.Tables[0].Rows[0]["ip2"].ToString());
				}
				model.country=ds.Tables[0].Rows[0]["country"].ToString();
				model.city=ds.Tables[0].Rows[0]["city"].ToString();
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
			strSql.Append("select ip1,ip2,country,city ");
			strSql.Append(" FROM PBnet_ipdata ");
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
			parameters[0].Value = "PBnet_ipdata";
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

