using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_sms。
	/// </summary>
	public class PBnet_sms:IPBnet_sms
	{
		public PBnet_sms()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "PBnet_sms"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_sms");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_sms model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_sms(");
			strSql.Append("servicename,serviceid,serviceclass,instruction,paytype,paymoney,sendf,serviceintro,comid,delfshow)");
			strSql.Append(" values (");
			strSql.Append("@servicename,@serviceid,@serviceclass,@instruction,@paytype,@paymoney,@sendf,@serviceintro,@comid,@delfshow)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@servicename", SqlDbType.NVarChar,50),
					new SqlParameter("@serviceid", SqlDbType.Int,4),
					new SqlParameter("@serviceclass", SqlDbType.NVarChar,50),
					new SqlParameter("@instruction", SqlDbType.NVarChar,50),
					new SqlParameter("@paytype", SqlDbType.NVarChar,50),
					new SqlParameter("@paymoney", SqlDbType.NVarChar,50),
					new SqlParameter("@sendf", SqlDbType.NVarChar,50),
					new SqlParameter("@serviceintro", SqlDbType.NText),
					new SqlParameter("@comid", SqlDbType.NVarChar,50),
					new SqlParameter("@delfshow", SqlDbType.Int,4)};
			parameters[0].Value = model.servicename;
			parameters[1].Value = model.serviceid;
			parameters[2].Value = model.serviceclass;
			parameters[3].Value = model.instruction;
			parameters[4].Value = model.paytype;
			parameters[5].Value = model.paymoney;
			parameters[6].Value = model.sendf;
			parameters[7].Value = model.serviceintro;
			parameters[8].Value = model.comid;
			parameters[9].Value = model.delfshow;

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
		public void Update(Pbzx.Model.PBnet_sms model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_sms set ");
			strSql.Append("servicename=@servicename,");
			strSql.Append("serviceid=@serviceid,");
			strSql.Append("serviceclass=@serviceclass,");
			strSql.Append("instruction=@instruction,");
			strSql.Append("paytype=@paytype,");
			strSql.Append("paymoney=@paymoney,");
			strSql.Append("sendf=@sendf,");
			strSql.Append("serviceintro=@serviceintro,");
			strSql.Append("comid=@comid,");
			strSql.Append("delfshow=@delfshow");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@servicename", SqlDbType.NVarChar,50),
					new SqlParameter("@serviceid", SqlDbType.Int,4),
					new SqlParameter("@serviceclass", SqlDbType.NVarChar,50),
					new SqlParameter("@instruction", SqlDbType.NVarChar,50),
					new SqlParameter("@paytype", SqlDbType.NVarChar,50),
					new SqlParameter("@paymoney", SqlDbType.NVarChar,50),
					new SqlParameter("@sendf", SqlDbType.NVarChar,50),
					new SqlParameter("@serviceintro", SqlDbType.NText),
					new SqlParameter("@comid", SqlDbType.NVarChar,50),
					new SqlParameter("@delfshow", SqlDbType.Int,4)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.servicename;
			parameters[2].Value = model.serviceid;
			parameters[3].Value = model.serviceclass;
			parameters[4].Value = model.instruction;
			parameters[5].Value = model.paytype;
			parameters[6].Value = model.paymoney;
			parameters[7].Value = model.sendf;
			parameters[8].Value = model.serviceintro;
			parameters[9].Value = model.comid;
			parameters[10].Value = model.delfshow;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_sms ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_sms GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,servicename,serviceid,serviceclass,instruction,paytype,paymoney,sendf,serviceintro,comid,delfshow from PBnet_sms ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			Pbzx.Model.PBnet_sms model=new Pbzx.Model.PBnet_sms();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.servicename=ds.Tables[0].Rows[0]["servicename"].ToString();
				if(ds.Tables[0].Rows[0]["serviceid"].ToString()!="")
				{
					model.serviceid=int.Parse(ds.Tables[0].Rows[0]["serviceid"].ToString());
				}
				model.serviceclass=ds.Tables[0].Rows[0]["serviceclass"].ToString();
				model.instruction=ds.Tables[0].Rows[0]["instruction"].ToString();
				model.paytype=ds.Tables[0].Rows[0]["paytype"].ToString();
				model.paymoney=ds.Tables[0].Rows[0]["paymoney"].ToString();
				model.sendf=ds.Tables[0].Rows[0]["sendf"].ToString();
				model.serviceintro=ds.Tables[0].Rows[0]["serviceintro"].ToString();
				model.comid=ds.Tables[0].Rows[0]["comid"].ToString();
				if(ds.Tables[0].Rows[0]["delfshow"].ToString()!="")
				{
					model.delfshow=int.Parse(ds.Tables[0].Rows[0]["delfshow"].ToString());
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
			strSql.Append("select id,servicename,serviceid,serviceclass,instruction,paytype,paymoney,sendf,serviceintro,comid,delfshow ");
			strSql.Append(" FROM PBnet_sms ");
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
			parameters[0].Value = "PBnet_sms";
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

