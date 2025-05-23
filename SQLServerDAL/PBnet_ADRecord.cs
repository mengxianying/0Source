using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_ADRecord。
	/// </summary>
	public class PBnet_ADRecord:IPBnet_ADRecord
	{
		public PBnet_ADRecord()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_ADRecord");
			strSql.Append(" where pb_ADid=@pb_ADid and pb_VsTime=@pb_VsTime and pb_VsIP=@pb_VsIP and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@pb_ADid", SqlDbType.BigInt),
					new SqlParameter("@pb_VsTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_VsIP", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = pb_ADid;
			parameters[1].Value = pb_VsTime;
			parameters[2].Value = pb_VsIP;
			parameters[3].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_ADRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_ADRecord(");
			strSql.Append("pb_ADid,pb_VsTime,pb_VsIP)");
			strSql.Append(" values (");
			strSql.Append("@pb_ADid,@pb_VsTime,@pb_VsIP)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pb_ADid", SqlDbType.BigInt,8),
					new SqlParameter("@pb_VsTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_VsIP", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.pb_ADid;
			parameters[1].Value = model.pb_VsTime;
			parameters[2].Value = model.pb_VsIP;

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
		public void Update(Pbzx.Model.PBnet_ADRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_ADRecord set ");
			strSql.Append(" where pb_ADid=@pb_ADid and pb_VsTime=@pb_VsTime and pb_VsIP=@pb_VsIP and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@pb_ADid", SqlDbType.BigInt,8),
					new SqlParameter("@pb_VsTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_VsIP", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.pb_ADid;
			parameters[2].Value = model.pb_VsTime;
			parameters[3].Value = model.pb_VsIP;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_ADRecord ");
			strSql.Append(" where pb_ADid=@pb_ADid and pb_VsTime=@pb_VsTime and pb_VsIP=@pb_VsIP and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@pb_ADid", SqlDbType.BigInt),
					new SqlParameter("@pb_VsTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_VsIP", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = pb_ADid;
			parameters[1].Value = pb_VsTime;
			parameters[2].Value = pb_VsIP;
			parameters[3].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_ADRecord GetModel(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,pb_ADid,pb_VsTime,pb_VsIP from PBnet_ADRecord ");
			strSql.Append(" where pb_ADid=@pb_ADid and pb_VsTime=@pb_VsTime and pb_VsIP=@pb_VsIP and id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@pb_ADid", SqlDbType.BigInt),
					new SqlParameter("@pb_VsTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_VsIP", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = pb_ADid;
			parameters[1].Value = pb_VsTime;
			parameters[2].Value = pb_VsIP;
			parameters[3].Value = id;

			Pbzx.Model.PBnet_ADRecord model=new Pbzx.Model.PBnet_ADRecord();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pb_ADid"].ToString()!="")
				{
					model.pb_ADid=long.Parse(ds.Tables[0].Rows[0]["pb_ADid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pb_VsTime"].ToString()!="")
				{
					model.pb_VsTime=DateTime.Parse(ds.Tables[0].Rows[0]["pb_VsTime"].ToString());
				}
				model.pb_VsIP=ds.Tables[0].Rows[0]["pb_VsIP"].ToString();
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
			strSql.Append("select id,pb_ADid,pb_VsTime,pb_VsIP ");
			strSql.Append(" FROM PBnet_ADRecord ");
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
			parameters[0].Value = "PBnet_ADRecord";
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

