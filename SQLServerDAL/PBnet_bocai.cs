using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_bocai。
	/// </summary>
	public class PBnet_bocai:IPBnet_bocai
	{
		public PBnet_bocai()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("cid", "PBnet_bocai"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int cid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_bocai");
			strSql.Append(" where cid=@cid ");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)};
			parameters[0].Value = cid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_bocai model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_bocai(");
			strSql.Append("cname,cren,ctime,cneirong,cchuchu,yntj,gglbid)");
			strSql.Append(" values (");
			strSql.Append("@cname,@cren,@ctime,@cneirong,@cchuchu,@yntj,@gglbid)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,50),
					new SqlParameter("@cren", SqlDbType.NVarChar,50),
					new SqlParameter("@ctime", SqlDbType.NVarChar,50),
					new SqlParameter("@cneirong", SqlDbType.NText),
					new SqlParameter("@cchuchu", SqlDbType.NVarChar,50),
					new SqlParameter("@yntj", SqlDbType.NVarChar,50),
					new SqlParameter("@gglbid", SqlDbType.Int,4)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.cren;
			parameters[2].Value = model.ctime;
			parameters[3].Value = model.cneirong;
			parameters[4].Value = model.cchuchu;
			parameters[5].Value = model.yntj;
			parameters[6].Value = model.gglbid;

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
		public void Update(Pbzx.Model.PBnet_bocai model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_bocai set ");
			strSql.Append("cname=@cname,");
			strSql.Append("cren=@cren,");
			strSql.Append("ctime=@ctime,");
			strSql.Append("cneirong=@cneirong,");
			strSql.Append("cchuchu=@cchuchu,");
			strSql.Append("yntj=@yntj,");
			strSql.Append("gglbid=@gglbid");
			strSql.Append(" where cid=@cid ");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@cname", SqlDbType.NVarChar,50),
					new SqlParameter("@cren", SqlDbType.NVarChar,50),
					new SqlParameter("@ctime", SqlDbType.NVarChar,50),
					new SqlParameter("@cneirong", SqlDbType.NText),
					new SqlParameter("@cchuchu", SqlDbType.NVarChar,50),
					new SqlParameter("@yntj", SqlDbType.NVarChar,50),
					new SqlParameter("@gglbid", SqlDbType.Int,4)};
			parameters[0].Value = model.cid;
			parameters[1].Value = model.cname;
			parameters[2].Value = model.cren;
			parameters[3].Value = model.ctime;
			parameters[4].Value = model.cneirong;
			parameters[5].Value = model.cchuchu;
			parameters[6].Value = model.yntj;
			parameters[7].Value = model.gglbid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_bocai ");
			strSql.Append(" where cid=@cid ");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)};
			parameters[0].Value = cid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_bocai GetModel(int cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 cid,cname,cren,ctime,cneirong,cchuchu,yntj,gglbid from PBnet_bocai ");
			strSql.Append(" where cid=@cid ");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)};
			parameters[0].Value = cid;

			Pbzx.Model.PBnet_bocai model=new Pbzx.Model.PBnet_bocai();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["cid"].ToString()!="")
				{
					model.cid=int.Parse(ds.Tables[0].Rows[0]["cid"].ToString());
				}
				model.cname=ds.Tables[0].Rows[0]["cname"].ToString();
				model.cren=ds.Tables[0].Rows[0]["cren"].ToString();
				model.ctime=ds.Tables[0].Rows[0]["ctime"].ToString();
				model.cneirong=ds.Tables[0].Rows[0]["cneirong"].ToString();
				model.cchuchu=ds.Tables[0].Rows[0]["cchuchu"].ToString();
				model.yntj=ds.Tables[0].Rows[0]["yntj"].ToString();
				if(ds.Tables[0].Rows[0]["gglbid"].ToString()!="")
				{
					model.gglbid=int.Parse(ds.Tables[0].Rows[0]["gglbid"].ToString());
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
			strSql.Append("select cid,cname,cren,ctime,cneirong,cchuchu,yntj,gglbid ");
			strSql.Append(" FROM PBnet_bocai ");
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
			parameters[0].Value = "PBnet_bocai";
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

