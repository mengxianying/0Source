using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Pbzx.SQLServerDAL
{
    public class PBnet_SysConfig
    {
		public PBnet_SysConfig()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_SysConfig");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_SysConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_SysConfig(");
			strSql.Append("Title,Master,Email,Telephone,Address,CopyRight,CharSet,MailSender,Sender,ReplyTo,UserName,Password,MailServer,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Title,@Master,@Email,@Telephone,@Address,@CopyRight,@CharSet,@MailSender,@Sender,@ReplyTo,@UserName,@Password,@MailServer,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Master", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@Telephone", SqlDbType.VarChar,100),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@CopyRight", SqlDbType.VarChar,200),
					new SqlParameter("@CharSet", SqlDbType.VarChar,20),
					new SqlParameter("@MailSender", SqlDbType.VarChar,100),
					new SqlParameter("@Sender", SqlDbType.VarChar,100),
					new SqlParameter("@ReplyTo", SqlDbType.VarChar,100),
					new SqlParameter("@UserName", SqlDbType.VarChar,100),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@MailServer", SqlDbType.VarChar,100),
					new SqlParameter("@Remark", SqlDbType.Text)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Master;
			parameters[2].Value = model.Email;
			parameters[3].Value = model.Telephone;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.CopyRight;
			parameters[6].Value = model.CharSet;
			parameters[7].Value = model.MailSender;
			parameters[8].Value = model.Sender;
			parameters[9].Value = model.ReplyTo;
			parameters[10].Value = model.UserName;
			parameters[11].Value = model.Password;
			parameters[12].Value = model.MailServer;
			parameters[13].Value = model.Remark;

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
		public void Update(Pbzx.Model.PBnet_SysConfig model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_SysConfig set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Master=@Master,");
			strSql.Append("Email=@Email,");
			strSql.Append("Telephone=@Telephone,");
			strSql.Append("Address=@Address,");
			strSql.Append("CopyRight=@CopyRight,");
			strSql.Append("CharSet=@CharSet,");
			strSql.Append("MailSender=@MailSender,");
			strSql.Append("Sender=@Sender,");
			strSql.Append("ReplyTo=@ReplyTo,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Password=@Password,");
			strSql.Append("MailServer=@MailServer,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Master", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,100),
					new SqlParameter("@Telephone", SqlDbType.VarChar,100),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@CopyRight", SqlDbType.VarChar,200),
					new SqlParameter("@CharSet", SqlDbType.VarChar,20),
					new SqlParameter("@MailSender", SqlDbType.VarChar,100),
					new SqlParameter("@Sender", SqlDbType.VarChar,100),
					new SqlParameter("@ReplyTo", SqlDbType.VarChar,100),
					new SqlParameter("@UserName", SqlDbType.VarChar,100),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@MailServer", SqlDbType.VarChar,100),
					new SqlParameter("@Remark", SqlDbType.Text)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Title;
			parameters[2].Value = model.Master;
			parameters[3].Value = model.Email;
			parameters[4].Value = model.Telephone;
			parameters[5].Value = model.Address;
			parameters[6].Value = model.CopyRight;
			parameters[7].Value = model.CharSet;
			parameters[8].Value = model.MailSender;
			parameters[9].Value = model.Sender;
			parameters[10].Value = model.ReplyTo;
			parameters[11].Value = model.UserName;
			parameters[12].Value = model.Password;
			parameters[13].Value = model.MailServer;
			parameters[14].Value = model.Remark;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_SysConfig ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
        /// 得到一个对象实体 
		/// </summary>
		public Pbzx.Model.PBnet_SysConfig GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Title,Master,Email,Telephone,Address,CopyRight,CharSet,MailSender,Sender,ReplyTo,UserName,Password,MailServer,Remark from PBnet_SysConfig ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = ID;

			Pbzx.Model.PBnet_SysConfig model=new Pbzx.Model.PBnet_SysConfig();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.Title=ds.Tables[0].Rows[0]["Title"].ToString();
				model.Master=ds.Tables[0].Rows[0]["Master"].ToString();
				model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				model.Telephone=ds.Tables[0].Rows[0]["Telephone"].ToString();
				model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				model.CopyRight=ds.Tables[0].Rows[0]["CopyRight"].ToString();
				model.CharSet=ds.Tables[0].Rows[0]["CharSet"].ToString();
				model.MailSender=ds.Tables[0].Rows[0]["MailSender"].ToString();
				model.Sender=ds.Tables[0].Rows[0]["Sender"].ToString();
				model.ReplyTo=ds.Tables[0].Rows[0]["ReplyTo"].ToString();
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				model.MailServer=ds.Tables[0].Rows[0]["MailServer"].ToString();
				model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
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
			strSql.Append("select ID,Title,Master,Email,Telephone,Address,CopyRight,CharSet,MailSender,Sender,ReplyTo,UserName,Password,MailServer,Remark ");
			strSql.Append(" FROM PBnet_SysConfig ");
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
			parameters[0].Value = "PBnet_SysConfig";
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
