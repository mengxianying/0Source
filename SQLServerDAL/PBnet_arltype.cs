using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_arltype。
	/// </summary>
	public class PBnet_arltype:IPBnet_arltype
	{
		public PBnet_arltype()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "PBnet_arltype"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_arltype");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_arltype model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_arltype(");
			strSql.Append("pb_Title,pb_Code,pb_Type,pb_Info,pb_ViewNum,pb_CountNum,pb_MangerNum,pb_IsOut,pb_OutURL,pb_StyleId,pb_IsReview,pb_IsPost,pb_IsTop)");
			strSql.Append(" values (");
			strSql.Append("@pb_Title,@pb_Code,@pb_Type,@pb_Info,@pb_ViewNum,@pb_CountNum,@pb_MangerNum,@pb_IsOut,@pb_OutURL,@pb_StyleId,@pb_IsReview,@pb_IsPost,@pb_IsTop)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@pb_Title", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_Code", SqlDbType.NVarChar,250),
					new SqlParameter("@pb_Type", SqlDbType.TinyInt,1),
					new SqlParameter("@pb_Info", SqlDbType.NVarChar,150),
					new SqlParameter("@pb_ViewNum", SqlDbType.Int,4),
					new SqlParameter("@pb_CountNum", SqlDbType.Int,4),
					new SqlParameter("@pb_MangerNum", SqlDbType.Int,4),
					new SqlParameter("@pb_IsOut", SqlDbType.Bit,1),
					new SqlParameter("@pb_OutURL", SqlDbType.NVarChar,150),
					new SqlParameter("@pb_StyleId", SqlDbType.Int,4),
					new SqlParameter("@pb_IsReview", SqlDbType.Bit,1),
					new SqlParameter("@pb_IsPost", SqlDbType.Bit,1),
					new SqlParameter("@pb_IsTop", SqlDbType.Bit,1)};
			parameters[0].Value = model.pb_Title;
			parameters[1].Value = model.pb_Code;
			parameters[2].Value = model.pb_Type;
			parameters[3].Value = model.pb_Info;
			parameters[4].Value = model.pb_ViewNum;
			parameters[5].Value = model.pb_CountNum;
			parameters[6].Value = model.pb_MangerNum;
			parameters[7].Value = model.pb_IsOut;
			parameters[8].Value = model.pb_OutURL;
			parameters[9].Value = model.pb_StyleId;
			parameters[10].Value = model.pb_IsReview;
			parameters[11].Value = model.pb_IsPost;
			parameters[12].Value = model.pb_IsTop;

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
		public void Update(Pbzx.Model.PBnet_arltype model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_arltype set ");
			strSql.Append("pb_Title=@pb_Title,");
			strSql.Append("pb_Code=@pb_Code,");
			strSql.Append("pb_Type=@pb_Type,");
			strSql.Append("pb_Info=@pb_Info,");
			strSql.Append("pb_ViewNum=@pb_ViewNum,");
			strSql.Append("pb_CountNum=@pb_CountNum,");
			strSql.Append("pb_MangerNum=@pb_MangerNum,");
			strSql.Append("pb_IsOut=@pb_IsOut,");
			strSql.Append("pb_OutURL=@pb_OutURL,");
			strSql.Append("pb_StyleId=@pb_StyleId,");
			strSql.Append("pb_IsReview=@pb_IsReview,");
			strSql.Append("pb_IsPost=@pb_IsPost,");
			strSql.Append("pb_IsTop=@pb_IsTop");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@pb_Title", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_Code", SqlDbType.NVarChar,250),
					new SqlParameter("@pb_Type", SqlDbType.TinyInt,1),
					new SqlParameter("@pb_Info", SqlDbType.NVarChar,150),
					new SqlParameter("@pb_ViewNum", SqlDbType.Int,4),
					new SqlParameter("@pb_CountNum", SqlDbType.Int,4),
					new SqlParameter("@pb_MangerNum", SqlDbType.Int,4),
					new SqlParameter("@pb_IsOut", SqlDbType.Bit,1),
					new SqlParameter("@pb_OutURL", SqlDbType.NVarChar,150),
					new SqlParameter("@pb_StyleId", SqlDbType.Int,4),
					new SqlParameter("@pb_IsReview", SqlDbType.Bit,1),
					new SqlParameter("@pb_IsPost", SqlDbType.Bit,1),
					new SqlParameter("@pb_IsTop", SqlDbType.Bit,1)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.pb_Title;
			parameters[2].Value = model.pb_Code;
			parameters[3].Value = model.pb_Type;
			parameters[4].Value = model.pb_Info;
			parameters[5].Value = model.pb_ViewNum;
			parameters[6].Value = model.pb_CountNum;
			parameters[7].Value = model.pb_MangerNum;
			parameters[8].Value = model.pb_IsOut;
			parameters[9].Value = model.pb_OutURL;
			parameters[10].Value = model.pb_StyleId;
			parameters[11].Value = model.pb_IsReview;
			parameters[12].Value = model.pb_IsPost;
			parameters[13].Value = model.pb_IsTop;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_arltype ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_arltype GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,pb_Title,pb_Code,pb_Type,pb_Info,pb_ViewNum,pb_CountNum,pb_MangerNum,pb_IsOut,pb_OutURL,pb_StyleId,pb_IsReview,pb_IsPost,pb_IsTop from PBnet_arltype ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			Pbzx.Model.PBnet_arltype model=new Pbzx.Model.PBnet_arltype();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				model.pb_Title=ds.Tables[0].Rows[0]["pb_Title"].ToString();
				model.pb_Code=ds.Tables[0].Rows[0]["pb_Code"].ToString();
				if(ds.Tables[0].Rows[0]["pb_Type"].ToString()!="")
				{
					model.pb_Type=int.Parse(ds.Tables[0].Rows[0]["pb_Type"].ToString());
				}
				model.pb_Info=ds.Tables[0].Rows[0]["pb_Info"].ToString();
				if(ds.Tables[0].Rows[0]["pb_ViewNum"].ToString()!="")
				{
					model.pb_ViewNum=int.Parse(ds.Tables[0].Rows[0]["pb_ViewNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pb_CountNum"].ToString()!="")
				{
					model.pb_CountNum=int.Parse(ds.Tables[0].Rows[0]["pb_CountNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pb_MangerNum"].ToString()!="")
				{
					model.pb_MangerNum=int.Parse(ds.Tables[0].Rows[0]["pb_MangerNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pb_IsOut"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["pb_IsOut"].ToString()=="1")||(ds.Tables[0].Rows[0]["pb_IsOut"].ToString().ToLower()=="true"))
					{
						model.pb_IsOut=true;
					}
					else
					{
						model.pb_IsOut=false;
					}
				}
				model.pb_OutURL=ds.Tables[0].Rows[0]["pb_OutURL"].ToString();
				if(ds.Tables[0].Rows[0]["pb_StyleId"].ToString()!="")
				{
					model.pb_StyleId=int.Parse(ds.Tables[0].Rows[0]["pb_StyleId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pb_IsReview"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["pb_IsReview"].ToString()=="1")||(ds.Tables[0].Rows[0]["pb_IsReview"].ToString().ToLower()=="true"))
					{
						model.pb_IsReview=true;
					}
					else
					{
						model.pb_IsReview=false;
					}
				}
				if(ds.Tables[0].Rows[0]["pb_IsPost"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["pb_IsPost"].ToString()=="1")||(ds.Tables[0].Rows[0]["pb_IsPost"].ToString().ToLower()=="true"))
					{
						model.pb_IsPost=true;
					}
					else
					{
						model.pb_IsPost=false;
					}
				}
				if(ds.Tables[0].Rows[0]["pb_IsTop"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["pb_IsTop"].ToString()=="1")||(ds.Tables[0].Rows[0]["pb_IsTop"].ToString().ToLower()=="true"))
					{
						model.pb_IsTop=true;
					}
					else
					{
						model.pb_IsTop=false;
					}
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
			strSql.Append("select Id,pb_Title,pb_Code,pb_Type,pb_Info,pb_ViewNum,pb_CountNum,pb_MangerNum,pb_IsOut,pb_OutURL,pb_StyleId,pb_IsReview,pb_IsPost,pb_IsTop ");
			strSql.Append(" FROM PBnet_arltype ");
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
			parameters[0].Value = "PBnet_arltype";
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

