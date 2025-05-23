using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_smsfs。
	/// </summary>
	public class PBnet_smsfs:IPBnet_smsfs
	{
		public PBnet_smsfs()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "PBnet_smsfs"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_smsfs");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_smsfs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_smsfs(");
			strSql.Append("pb_smsid,PBnet_smsfsmsg,pb_intime,pb_author,pb_isnew,pb_cpnum)");
			strSql.Append(" values (");
			strSql.Append("@pb_smsid,@PBnet_smsfsmsg,@pb_intime,@pb_author,@pb_isnew,@pb_cpnum)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pb_smsid", SqlDbType.Int,4),
					new SqlParameter("@PBnet_smsfsmsg", SqlDbType.NVarChar,1000),
					new SqlParameter("@pb_intime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_author", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_isnew", SqlDbType.Bit,1),
					new SqlParameter("@pb_cpnum", SqlDbType.Int,4)};
			parameters[0].Value = model.pb_smsid;
			parameters[1].Value = model.PBnet_smsfsmsg;
			parameters[2].Value = model.pb_intime;
			parameters[3].Value = model.pb_author;
			parameters[4].Value = model.pb_isnew;
			parameters[5].Value = model.pb_cpnum;

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
		public void Update(Pbzx.Model.PBnet_smsfs model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_smsfs set ");
			strSql.Append("pb_smsid=@pb_smsid,");
			strSql.Append("PBnet_smsfsmsg=@PBnet_smsfsmsg,");
			strSql.Append("pb_intime=@pb_intime,");
			strSql.Append("pb_author=@pb_author,");
			strSql.Append("pb_isnew=@pb_isnew,");
			strSql.Append("pb_cpnum=@pb_cpnum");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@pb_smsid", SqlDbType.Int,4),
					new SqlParameter("@PBnet_smsfsmsg", SqlDbType.NVarChar,1000),
					new SqlParameter("@pb_intime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_author", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_isnew", SqlDbType.Bit,1),
					new SqlParameter("@pb_cpnum", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.pb_smsid;
			parameters[2].Value = model.PBnet_smsfsmsg;
			parameters[3].Value = model.pb_intime;
			parameters[4].Value = model.pb_author;
			parameters[5].Value = model.pb_isnew;
			parameters[6].Value = model.pb_cpnum;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_smsfs ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_smsfs GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,pb_smsid,PBnet_smsfsmsg,pb_intime,pb_author,pb_isnew,pb_cpnum from PBnet_smsfs ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Pbzx.Model.PBnet_smsfs model=new Pbzx.Model.PBnet_smsfs();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pb_smsid"].ToString()!="")
				{
					model.pb_smsid=int.Parse(ds.Tables[0].Rows[0]["pb_smsid"].ToString());
				}
				model.PBnet_smsfsmsg=ds.Tables[0].Rows[0]["PBnet_smsfsmsg"].ToString();
				if(ds.Tables[0].Rows[0]["pb_intime"].ToString()!="")
				{
					model.pb_intime=DateTime.Parse(ds.Tables[0].Rows[0]["pb_intime"].ToString());
				}
				model.pb_author=ds.Tables[0].Rows[0]["pb_author"].ToString();
				if(ds.Tables[0].Rows[0]["pb_isnew"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["pb_isnew"].ToString()=="1")||(ds.Tables[0].Rows[0]["pb_isnew"].ToString().ToLower()=="true"))
					{
						model.pb_isnew=true;
					}
					else
					{
						model.pb_isnew=false;
					}
				}
				if(ds.Tables[0].Rows[0]["pb_cpnum"].ToString()!="")
				{
					model.pb_cpnum=int.Parse(ds.Tables[0].Rows[0]["pb_cpnum"].ToString());
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
			strSql.Append("select id,pb_smsid,PBnet_smsfsmsg,pb_intime,pb_author,pb_isnew,pb_cpnum ");
			strSql.Append(" FROM PBnet_smsfs ");
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
			parameters[0].Value = "PBnet_smsfs";
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

