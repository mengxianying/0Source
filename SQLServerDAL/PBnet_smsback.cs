using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_smsback。
	/// </summary>
	public class PBnet_smsback:IPBnet_smsback
	{
		public PBnet_smsback()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "PBnet_smsback"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_smsback");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_smsback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_smsback(");
			strSql.Append("pbactionid,pbresultid,pbrestring,pbserviceid,pbmobileid,pbpassword,vsurl,vstime)");
			strSql.Append(" values (");
			strSql.Append("@pbactionid,@pbresultid,@pbrestring,@pbserviceid,@pbmobileid,@pbpassword,@vsurl,@vstime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pbactionid", SqlDbType.Int,4),
					new SqlParameter("@pbresultid", SqlDbType.Int,4),
					new SqlParameter("@pbrestring", SqlDbType.NVarChar,50),
					new SqlParameter("@pbserviceid", SqlDbType.Int,4),
					new SqlParameter("@pbmobileid", SqlDbType.NVarChar,50),
					new SqlParameter("@pbpassword", SqlDbType.NVarChar,50),
					new SqlParameter("@vsurl", SqlDbType.NVarChar,50),
					new SqlParameter("@vstime", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.pbactionid;
			parameters[1].Value = model.pbresultid;
			parameters[2].Value = model.pbrestring;
			parameters[3].Value = model.pbserviceid;
			parameters[4].Value = model.pbmobileid;
			parameters[5].Value = model.pbpassword;
			parameters[6].Value = model.vsurl;
			parameters[7].Value = model.vstime;

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
		public void Update(Pbzx.Model.PBnet_smsback model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_smsback set ");
			strSql.Append("pbactionid=@pbactionid,");
			strSql.Append("pbresultid=@pbresultid,");
			strSql.Append("pbrestring=@pbrestring,");
			strSql.Append("pbserviceid=@pbserviceid,");
			strSql.Append("pbmobileid=@pbmobileid,");
			strSql.Append("pbpassword=@pbpassword,");
			strSql.Append("vsurl=@vsurl,");
			strSql.Append("vstime=@vstime");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@pbactionid", SqlDbType.Int,4),
					new SqlParameter("@pbresultid", SqlDbType.Int,4),
					new SqlParameter("@pbrestring", SqlDbType.NVarChar,50),
					new SqlParameter("@pbserviceid", SqlDbType.Int,4),
					new SqlParameter("@pbmobileid", SqlDbType.NVarChar,50),
					new SqlParameter("@pbpassword", SqlDbType.NVarChar,50),
					new SqlParameter("@vsurl", SqlDbType.NVarChar,50),
					new SqlParameter("@vstime", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.pbactionid;
			parameters[2].Value = model.pbresultid;
			parameters[3].Value = model.pbrestring;
			parameters[4].Value = model.pbserviceid;
			parameters[5].Value = model.pbmobileid;
			parameters[6].Value = model.pbpassword;
			parameters[7].Value = model.vsurl;
			parameters[8].Value = model.vstime;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_smsback ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_smsback GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,pbactionid,pbresultid,pbrestring,pbserviceid,pbmobileid,pbpassword,vsurl,vstime from PBnet_smsback ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Pbzx.Model.PBnet_smsback model=new Pbzx.Model.PBnet_smsback();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pbactionid"].ToString()!="")
				{
					model.pbactionid=int.Parse(ds.Tables[0].Rows[0]["pbactionid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pbresultid"].ToString()!="")
				{
					model.pbresultid=int.Parse(ds.Tables[0].Rows[0]["pbresultid"].ToString());
				}
				model.pbrestring=ds.Tables[0].Rows[0]["pbrestring"].ToString();
				if(ds.Tables[0].Rows[0]["pbserviceid"].ToString()!="")
				{
					model.pbserviceid=int.Parse(ds.Tables[0].Rows[0]["pbserviceid"].ToString());
				}
				model.pbmobileid=ds.Tables[0].Rows[0]["pbmobileid"].ToString();
				model.pbpassword=ds.Tables[0].Rows[0]["pbpassword"].ToString();
				model.vsurl=ds.Tables[0].Rows[0]["vsurl"].ToString();
				if(ds.Tables[0].Rows[0]["vstime"].ToString()!="")
				{
					model.vstime=DateTime.Parse(ds.Tables[0].Rows[0]["vstime"].ToString());
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
			strSql.Append("select id,pbactionid,pbresultid,pbrestring,pbserviceid,pbmobileid,pbpassword,vsurl,vstime ");
			strSql.Append(" FROM PBnet_smsback ");
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
			parameters[0].Value = "PBnet_smsback";
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

