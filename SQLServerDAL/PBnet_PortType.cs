using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.Model;//�����������
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// ���ݷ�����PBnet_PortType��
	/// </summary>
	public class PBnet_PortType
	{
		public PBnet_PortType()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PortTypeID", "PBnet_PortType"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int PortTypeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_PortType");
			strSql.Append(" where PortTypeID=@PortTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PortTypeID", SqlDbType.SmallInt)};
			parameters[0].Value = PortTypeID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Pbzx.Model.PBnet_PortType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_PortType(");
			strSql.Append("PortTypeID,PortTypeName,PortPrice)");
			strSql.Append(" values (");
			strSql.Append("@PortTypeID,@PortTypeName,@PortPrice)");
			SqlParameter[] parameters = {
					new SqlParameter("@PortTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@PortTypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@PortPrice", SqlDbType.Money,8)};
			parameters[0].Value = model.PortTypeID;
			parameters[1].Value = model.PortTypeName;
			parameters[2].Value = model.PortPrice;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_PortType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_PortType set ");
			strSql.Append("PortTypeName=@PortTypeName,");
			strSql.Append("PortPrice=@PortPrice");
			strSql.Append(" where PortTypeID=@PortTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PortTypeID", SqlDbType.SmallInt,2),
					new SqlParameter("@PortTypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@PortPrice", SqlDbType.Money,8)};
			parameters[0].Value = model.PortTypeID;
			parameters[1].Value = model.PortTypeName;
			parameters[2].Value = model.PortPrice;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PortTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PBnet_PortType ");
			strSql.Append(" where PortTypeID=@PortTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PortTypeID", SqlDbType.SmallInt)};
			parameters[0].Value = PortTypeID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_PortType GetModel(int PortTypeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PortTypeID,PortTypeName,PortPrice from PBnet_PortType ");
			strSql.Append(" where PortTypeID=@PortTypeID ");
			SqlParameter[] parameters = {
					new SqlParameter("@PortTypeID", SqlDbType.SmallInt)};
			parameters[0].Value = PortTypeID;

			Pbzx.Model.PBnet_PortType model=new Pbzx.Model.PBnet_PortType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["PortTypeID"].ToString()!="")
				{
					model.PortTypeID=int.Parse(ds.Tables[0].Rows[0]["PortTypeID"].ToString());
				}
				model.PortTypeName=ds.Tables[0].Rows[0]["PortTypeName"].ToString();
				if(ds.Tables[0].Rows[0]["PortPrice"].ToString()!="")
				{
					model.PortPrice=decimal.Parse(ds.Tables[0].Rows[0]["PortPrice"].ToString());
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
			strSql.Append("select PortTypeID,PortTypeName,PortPrice ");
			strSql.Append(" FROM PBnet_PortType ");
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
			strSql.Append(" PortTypeID,PortTypeName,PortPrice ");
			strSql.Append(" FROM PBnet_PortType ");
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
			parameters[0].Value = "PBnet_PortType";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����

        public DataSet SelectAllPortType()
        {
            return SQLHelper.GetDataSet(DbHelperSQL.ConnectionString, CommandType.StoredProcedure, StoredProcedureName.sp_SelectAllPortType.ToString(), null);
        }
	}
}

