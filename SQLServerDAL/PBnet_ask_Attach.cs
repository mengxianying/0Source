using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//�����������
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// ���ݷ�����PBnet_ask_Attach��
	/// </summary>
	public class PBnet_ask_Attach:IPBnet_ask_Attach
	{
		public PBnet_ask_Attach()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "PBnet_ask_Attach"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_ask_Attach");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Pbzx.Model.PBnet_ask_Attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_ask_Attach(");
			strSql.Append("QuestionId,OriginalFile,UserName,Addtime,FileSize,ReplayId)");
			strSql.Append(" values (");
			strSql.Append("@QuestionId,@OriginalFile,@UserName,@Addtime,@FileSize,@ReplayId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@QuestionId", SqlDbType.Int,4),
					new SqlParameter("@OriginalFile", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Addtime", SqlDbType.DateTime),
					new SqlParameter("@FileSize", SqlDbType.Float,8),
					new SqlParameter("@ReplayId", SqlDbType.Int,4)};
			parameters[0].Value = model.QuestionId;
			parameters[1].Value = model.OriginalFile;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Addtime;
			parameters[4].Value = model.FileSize;
			parameters[5].Value = model.ReplayId;

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
		/// ����һ������
		/// </summary>
		public int Update(Pbzx.Model.PBnet_ask_Attach model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_ask_Attach set ");
			strSql.Append("QuestionId=@QuestionId,");
			strSql.Append("OriginalFile=@OriginalFile,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Addtime=@Addtime,");
			strSql.Append("FileSize=@FileSize,");
			strSql.Append("ReplayId=@ReplayId");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@QuestionId", SqlDbType.Int,4),
					new SqlParameter("@OriginalFile", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Addtime", SqlDbType.DateTime),
					new SqlParameter("@FileSize", SqlDbType.Float,8),
					new SqlParameter("@ReplayId", SqlDbType.Int,4)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.QuestionId;
			parameters[2].Value = model.OriginalFile;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.Addtime;
			parameters[5].Value = model.FileSize;
			parameters[6].Value = model.ReplayId;

		return	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public int Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PBnet_ask_Attach ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

		return	DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_ask_Attach GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,QuestionId,OriginalFile,UserName,Addtime,FileSize,ReplayId from PBnet_ask_Attach ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = Id;

			Pbzx.Model.PBnet_ask_Attach model=new Pbzx.Model.PBnet_ask_Attach();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QuestionId"].ToString()!="")
				{
					model.QuestionId=int.Parse(ds.Tables[0].Rows[0]["QuestionId"].ToString());
				}
				model.OriginalFile=ds.Tables[0].Rows[0]["OriginalFile"].ToString();
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				if(ds.Tables[0].Rows[0]["Addtime"].ToString()!="")
				{
					model.Addtime=DateTime.Parse(ds.Tables[0].Rows[0]["Addtime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FileSize"].ToString()!="")
				{
					model.FileSize=decimal.Parse(ds.Tables[0].Rows[0]["FileSize"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReplayId"].ToString()!="")
				{
					model.ReplayId=int.Parse(ds.Tables[0].Rows[0]["ReplayId"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,QuestionId,OriginalFile,UserName,Addtime,FileSize,ReplayId ");
			strSql.Append(" FROM PBnet_ask_Attach ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,QuestionId,OriginalFile,UserName,Addtime,FileSize,ReplayId ");
			strSql.Append(" FROM PBnet_ask_Attach ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "PBnet_ask_Attach";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����
	}
}

