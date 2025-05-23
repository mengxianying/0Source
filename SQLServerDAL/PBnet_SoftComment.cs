using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_SoftComment。
	/// </summary>
	public class PBnet_SoftComment:IPBnet_SoftComment
	{
		public PBnet_SoftComment()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("pb_CommentID", "PBnet_SoftComment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int pb_CommentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_SoftComment");
			strSql.Append(" where pb_CommentID=@pb_CommentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pb_CommentID", SqlDbType.Int,4)};
			parameters[0].Value = pb_CommentID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_SoftComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_SoftComment(");
			strSql.Append("pb_ClassID,pb_SoftID,pb_UserType,pb_UserName,pb_Sex,pb_qq,pb_Msn,pb_Email,pb_Homepage,pb_IP,pb_WriteTime,pb_Score,pb_Content,pb_ReplyName,pb_ReplyContent,pb_ReplyTime)");
			strSql.Append(" values (");
			strSql.Append("@pb_ClassID,@pb_SoftID,@pb_UserType,@pb_UserName,@pb_Sex,@pb_qq,@pb_Msn,@pb_Email,@pb_Homepage,@pb_IP,@pb_WriteTime,@pb_Score,@pb_Content,@pb_ReplyName,@pb_ReplyContent,@pb_ReplyTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pb_ClassID", SqlDbType.Int,4),
					new SqlParameter("@pb_SoftID", SqlDbType.Int,4),
					new SqlParameter("@pb_UserType", SqlDbType.Int,4),
					new SqlParameter("@pb_UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@pb_Sex", SqlDbType.NVarChar,10),
					new SqlParameter("@pb_qq", SqlDbType.NVarChar,20),
					new SqlParameter("@pb_Msn", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_Email", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_Homepage", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_IP", SqlDbType.NVarChar,15),
					new SqlParameter("@pb_WriteTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_Score", SqlDbType.Int,4),
					new SqlParameter("@pb_Content", SqlDbType.NText),
					new SqlParameter("@pb_ReplyName", SqlDbType.NVarChar,20),
					new SqlParameter("@pb_ReplyContent", SqlDbType.NText),
					new SqlParameter("@pb_ReplyTime", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.pb_ClassID;
			parameters[1].Value = model.pb_SoftID;
			parameters[2].Value = model.pb_UserType;
			parameters[3].Value = model.pb_UserName;
			parameters[4].Value = model.pb_Sex;
			parameters[5].Value = model.pb_qq;
			parameters[6].Value = model.pb_Msn;
			parameters[7].Value = model.pb_Email;
			parameters[8].Value = model.pb_Homepage;
			parameters[9].Value = model.pb_IP;
			parameters[10].Value = model.pb_WriteTime;
			parameters[11].Value = model.pb_Score;
			parameters[12].Value = model.pb_Content;
			parameters[13].Value = model.pb_ReplyName;
			parameters[14].Value = model.pb_ReplyContent;
			parameters[15].Value = model.pb_ReplyTime;

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
		public void Update(Pbzx.Model.PBnet_SoftComment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_SoftComment set ");
			strSql.Append("pb_ClassID=@pb_ClassID,");
			strSql.Append("pb_SoftID=@pb_SoftID,");
			strSql.Append("pb_UserType=@pb_UserType,");
			strSql.Append("pb_UserName=@pb_UserName,");
			strSql.Append("pb_Sex=@pb_Sex,");
			strSql.Append("pb_qq=@pb_qq,");
			strSql.Append("pb_Msn=@pb_Msn,");
			strSql.Append("pb_Email=@pb_Email,");
			strSql.Append("pb_Homepage=@pb_Homepage,");
			strSql.Append("pb_IP=@pb_IP,");
			strSql.Append("pb_WriteTime=@pb_WriteTime,");
			strSql.Append("pb_Score=@pb_Score,");
			strSql.Append("pb_Content=@pb_Content,");
			strSql.Append("pb_ReplyName=@pb_ReplyName,");
			strSql.Append("pb_ReplyContent=@pb_ReplyContent,");
			strSql.Append("pb_ReplyTime=@pb_ReplyTime");
			strSql.Append(" where pb_CommentID=@pb_CommentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pb_CommentID", SqlDbType.Int,4),
					new SqlParameter("@pb_ClassID", SqlDbType.Int,4),
					new SqlParameter("@pb_SoftID", SqlDbType.Int,4),
					new SqlParameter("@pb_UserType", SqlDbType.Int,4),
					new SqlParameter("@pb_UserName", SqlDbType.NVarChar,20),
					new SqlParameter("@pb_Sex", SqlDbType.NVarChar,10),
					new SqlParameter("@pb_qq", SqlDbType.NVarChar,20),
					new SqlParameter("@pb_Msn", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_Email", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_Homepage", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_IP", SqlDbType.NVarChar,15),
					new SqlParameter("@pb_WriteTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_Score", SqlDbType.Int,4),
					new SqlParameter("@pb_Content", SqlDbType.NText),
					new SqlParameter("@pb_ReplyName", SqlDbType.NVarChar,20),
					new SqlParameter("@pb_ReplyContent", SqlDbType.NText),
					new SqlParameter("@pb_ReplyTime", SqlDbType.SmallDateTime)};
			parameters[0].Value = model.pb_CommentID;
			parameters[1].Value = model.pb_ClassID;
			parameters[2].Value = model.pb_SoftID;
			parameters[3].Value = model.pb_UserType;
			parameters[4].Value = model.pb_UserName;
			parameters[5].Value = model.pb_Sex;
			parameters[6].Value = model.pb_qq;
			parameters[7].Value = model.pb_Msn;
			parameters[8].Value = model.pb_Email;
			parameters[9].Value = model.pb_Homepage;
			parameters[10].Value = model.pb_IP;
			parameters[11].Value = model.pb_WriteTime;
			parameters[12].Value = model.pb_Score;
			parameters[13].Value = model.pb_Content;
			parameters[14].Value = model.pb_ReplyName;
			parameters[15].Value = model.pb_ReplyContent;
			parameters[16].Value = model.pb_ReplyTime;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int pb_CommentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_SoftComment ");
			strSql.Append(" where pb_CommentID=@pb_CommentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pb_CommentID", SqlDbType.Int,4)};
			parameters[0].Value = pb_CommentID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_SoftComment GetModel(int pb_CommentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 pb_CommentID,pb_ClassID,pb_SoftID,pb_UserType,pb_UserName,pb_Sex,pb_qq,pb_Msn,pb_Email,pb_Homepage,pb_IP,pb_WriteTime,pb_Score,pb_Content,pb_ReplyName,pb_ReplyContent,pb_ReplyTime from PBnet_SoftComment ");
			strSql.Append(" where pb_CommentID=@pb_CommentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@pb_CommentID", SqlDbType.Int,4)};
			parameters[0].Value = pb_CommentID;

			Pbzx.Model.PBnet_SoftComment model=new Pbzx.Model.PBnet_SoftComment();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["pb_CommentID"].ToString()!="")
				{
					model.pb_CommentID=int.Parse(ds.Tables[0].Rows[0]["pb_CommentID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pb_ClassID"].ToString()!="")
				{
					model.pb_ClassID=int.Parse(ds.Tables[0].Rows[0]["pb_ClassID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pb_SoftID"].ToString()!="")
				{
					model.pb_SoftID=int.Parse(ds.Tables[0].Rows[0]["pb_SoftID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pb_UserType"].ToString()!="")
				{
					model.pb_UserType=int.Parse(ds.Tables[0].Rows[0]["pb_UserType"].ToString());
				}
				model.pb_UserName=ds.Tables[0].Rows[0]["pb_UserName"].ToString();
				model.pb_Sex=ds.Tables[0].Rows[0]["pb_Sex"].ToString();
				model.pb_qq=ds.Tables[0].Rows[0]["pb_qq"].ToString();
				model.pb_Msn=ds.Tables[0].Rows[0]["pb_Msn"].ToString();
				model.pb_Email=ds.Tables[0].Rows[0]["pb_Email"].ToString();
				model.pb_Homepage=ds.Tables[0].Rows[0]["pb_Homepage"].ToString();
				model.pb_IP=ds.Tables[0].Rows[0]["pb_IP"].ToString();
				if(ds.Tables[0].Rows[0]["pb_WriteTime"].ToString()!="")
				{
					model.pb_WriteTime=DateTime.Parse(ds.Tables[0].Rows[0]["pb_WriteTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pb_Score"].ToString()!="")
				{
					model.pb_Score=int.Parse(ds.Tables[0].Rows[0]["pb_Score"].ToString());
				}
				model.pb_Content=ds.Tables[0].Rows[0]["pb_Content"].ToString();
				model.pb_ReplyName=ds.Tables[0].Rows[0]["pb_ReplyName"].ToString();
				model.pb_ReplyContent=ds.Tables[0].Rows[0]["pb_ReplyContent"].ToString();
				if(ds.Tables[0].Rows[0]["pb_ReplyTime"].ToString()!="")
				{
					model.pb_ReplyTime=DateTime.Parse(ds.Tables[0].Rows[0]["pb_ReplyTime"].ToString());
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
			strSql.Append("select pb_CommentID,pb_ClassID,pb_SoftID,pb_UserType,pb_UserName,pb_Sex,pb_qq,pb_Msn,pb_Email,pb_Homepage,pb_IP,pb_WriteTime,pb_Score,pb_Content,pb_ReplyName,pb_ReplyContent,pb_ReplyTime ");
			strSql.Append(" FROM PBnet_SoftComment ");
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
			parameters[0].Value = "PBnet_SoftComment";
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

