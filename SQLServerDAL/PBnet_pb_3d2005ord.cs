using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_pb_3d2005ord。
	/// </summary>
	public class PBnet_pb_3d2005ord:IPBnet_pb_3d2005ord
	{
		public PBnet_pb_3d2005ord()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_pb_3d2005ord");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_pb_3d2005ord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_pb_3d2005ord(");
			strSql.Append("username,usertel,usermail,useraddress,ordfrom,ordfromnum,orddate,State,userip,usedate,userlog)");
			strSql.Append(" values (");
			strSql.Append("@username,@usertel,@usermail,@useraddress,@ordfrom,@ordfromnum,@orddate,@State,@userip,@usedate,@userlog)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,20),
					new SqlParameter("@usertel", SqlDbType.NVarChar,20),
					new SqlParameter("@usermail", SqlDbType.NVarChar,30),
					new SqlParameter("@useraddress", SqlDbType.NVarChar,50),
					new SqlParameter("@ordfrom", SqlDbType.NVarChar,15),
					new SqlParameter("@ordfromnum", SqlDbType.Int,4),
					new SqlParameter("@orddate", SqlDbType.SmallDateTime),
					new SqlParameter("@State", SqlDbType.Bit,1),
					new SqlParameter("@userip", SqlDbType.NVarChar,20),
					new SqlParameter("@usedate", SqlDbType.SmallDateTime),
					new SqlParameter("@userlog", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.username;
			parameters[1].Value = model.usertel;
			parameters[2].Value = model.usermail;
			parameters[3].Value = model.useraddress;
			parameters[4].Value = model.ordfrom;
			parameters[5].Value = model.ordfromnum;
			parameters[6].Value = model.orddate;
			parameters[7].Value = model.State;
			parameters[8].Value = model.userip;
			parameters[9].Value = model.usedate;
			parameters[10].Value = model.userlog;

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
		public void Update(Pbzx.Model.PBnet_pb_3d2005ord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_pb_3d2005ord set ");
			strSql.Append("username=@username,");
			strSql.Append("usertel=@usertel,");
			strSql.Append("usermail=@usermail,");
			strSql.Append("useraddress=@useraddress,");
			strSql.Append("ordfrom=@ordfrom,");
			strSql.Append("ordfromnum=@ordfromnum,");
			strSql.Append("orddate=@orddate,");
			strSql.Append("State=@State,");
			strSql.Append("userip=@userip,");
			strSql.Append("usedate=@usedate,");
			strSql.Append("userlog=@userlog");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@username", SqlDbType.NVarChar,20),
					new SqlParameter("@usertel", SqlDbType.NVarChar,20),
					new SqlParameter("@usermail", SqlDbType.NVarChar,30),
					new SqlParameter("@useraddress", SqlDbType.NVarChar,50),
					new SqlParameter("@ordfrom", SqlDbType.NVarChar,15),
					new SqlParameter("@ordfromnum", SqlDbType.Int,4),
					new SqlParameter("@orddate", SqlDbType.SmallDateTime),
					new SqlParameter("@State", SqlDbType.Bit,1),
					new SqlParameter("@userip", SqlDbType.NVarChar,20),
					new SqlParameter("@usedate", SqlDbType.SmallDateTime),
					new SqlParameter("@userlog", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.username;
			parameters[2].Value = model.usertel;
			parameters[3].Value = model.usermail;
			parameters[4].Value = model.useraddress;
			parameters[5].Value = model.ordfrom;
			parameters[6].Value = model.ordfromnum;
			parameters[7].Value = model.orddate;
			parameters[8].Value = model.State;
			parameters[9].Value = model.userip;
			parameters[10].Value = model.usedate;
			parameters[11].Value = model.userlog;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_pb_3d2005ord ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_pb_3d2005ord GetModel(long id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,username,usertel,usermail,useraddress,ordfrom,ordfromnum,orddate,State,userip,usedate,userlog from PBnet_pb_3d2005ord ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
			parameters[0].Value = id;

			Pbzx.Model.PBnet_pb_3d2005ord model=new Pbzx.Model.PBnet_pb_3d2005ord();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=long.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.username=ds.Tables[0].Rows[0]["username"].ToString();
				model.usertel=ds.Tables[0].Rows[0]["usertel"].ToString();
				model.usermail=ds.Tables[0].Rows[0]["usermail"].ToString();
				model.useraddress=ds.Tables[0].Rows[0]["useraddress"].ToString();
				model.ordfrom=ds.Tables[0].Rows[0]["ordfrom"].ToString();
				if(ds.Tables[0].Rows[0]["ordfromnum"].ToString()!="")
				{
					model.ordfromnum=int.Parse(ds.Tables[0].Rows[0]["ordfromnum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["orddate"].ToString()!="")
				{
					model.orddate=DateTime.Parse(ds.Tables[0].Rows[0]["orddate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["State"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["State"].ToString()=="1")||(ds.Tables[0].Rows[0]["State"].ToString().ToLower()=="true"))
					{
						model.State=true;
					}
					else
					{
						model.State=false;
					}
				}
				model.userip=ds.Tables[0].Rows[0]["userip"].ToString();
				if(ds.Tables[0].Rows[0]["usedate"].ToString()!="")
				{
					model.usedate=DateTime.Parse(ds.Tables[0].Rows[0]["usedate"].ToString());
				}
				model.userlog=ds.Tables[0].Rows[0]["userlog"].ToString();
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
			strSql.Append("select id,username,usertel,usermail,useraddress,ordfrom,ordfromnum,orddate,State,userip,usedate,userlog ");
			strSql.Append(" FROM PBnet_pb_3d2005ord ");
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
			parameters[0].Value = "PBnet_pb_3d2005ord";
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

