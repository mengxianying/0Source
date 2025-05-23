using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//�����������
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// ���ݷ�����PBnet_qjqi��
	/// </summary>
	public class PBnet_qjqi:IPBnet_qjqi
	{
		public PBnet_qjqi()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("qiuid", "PBnet_qjqi"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int qiuid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_qjqi");
			strSql.Append(" where qiuid=@qiuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@qiuid", SqlDbType.Int,4)};
			parameters[0].Value = qiuid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Pbzx.Model.PBnet_qjqi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_qjqi(");
			strSql.Append("qname)");
			strSql.Append(" values (");
			strSql.Append("@qname)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@qname", SqlDbType.Int,4)};
			parameters[0].Value = model.qname;

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
		public void Update(Pbzx.Model.PBnet_qjqi model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_qjqi set ");
			strSql.Append("qname=@qname");
			strSql.Append(" where qiuid=@qiuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@qiuid", SqlDbType.Int,4),
					new SqlParameter("@qname", SqlDbType.Int,4)};
			parameters[0].Value = model.qiuid;
			parameters[1].Value = model.qname;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int qiuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_qjqi ");
			strSql.Append(" where qiuid=@qiuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@qiuid", SqlDbType.Int,4)};
			parameters[0].Value = qiuid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_qjqi GetModel(int qiuid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 qiuid,qname from PBnet_qjqi ");
			strSql.Append(" where qiuid=@qiuid ");
			SqlParameter[] parameters = {
					new SqlParameter("@qiuid", SqlDbType.Int,4)};
			parameters[0].Value = qiuid;

			Pbzx.Model.PBnet_qjqi model=new Pbzx.Model.PBnet_qjqi();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["qiuid"].ToString()!="")
				{
					model.qiuid=int.Parse(ds.Tables[0].Rows[0]["qiuid"].ToString());
				}
				if(ds.Tables[0].Rows[0]["qname"].ToString()!="")
				{
					model.qname=int.Parse(ds.Tables[0].Rows[0]["qname"].ToString());
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
			strSql.Append("select qiuid,qname ");
			strSql.Append(" FROM PBnet_qjqi ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
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
			parameters[0].Value = "PBnet_qjqi";
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

