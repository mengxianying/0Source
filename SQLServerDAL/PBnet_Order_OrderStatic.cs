using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_Order_OrderStatic。
	/// </summary>
	public class PBnet_Order_OrderStatic
	{
		public PBnet_Order_OrderStatic()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string OrderID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_Order_OrderStatic");
			strSql.Append(" where OrderID=@OrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)};
			parameters[0].Value = OrderID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Pbzx.Model.PBnet_Order_OrderStatic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_Order_OrderStatic(");
			strSql.Append("OrderID,StaticID,AddedDate,YesOrNo)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@StaticID,@AddedDate,@YesOrNo)");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@StaticID", SqlDbType.SmallInt,2),
					new SqlParameter("@AddedDate", SqlDbType.SmallDateTime),
					new SqlParameter("@YesOrNo", SqlDbType.Bit,1)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.StaticID;
			parameters[2].Value = model.AddedDate;
			parameters[3].Value = model.YesOrNo;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_Order_OrderStatic model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_Order_OrderStatic set ");
			strSql.Append("StaticID=@StaticID,");
			strSql.Append("AddedDate=@AddedDate,");
			strSql.Append("YesOrNo=@YesOrNo");
			strSql.Append(" where OrderID=@OrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@StaticID", SqlDbType.SmallInt,2),
					new SqlParameter("@AddedDate", SqlDbType.SmallDateTime),
					new SqlParameter("@YesOrNo", SqlDbType.Bit,1)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.StaticID;
			parameters[2].Value = model.AddedDate;
			parameters[3].Value = model.YesOrNo;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string OrderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PBnet_Order_OrderStatic ");
			strSql.Append(" where OrderID=@OrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)};
			parameters[0].Value = OrderID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_Order_OrderStatic GetModel(string OrderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OrderID,StaticID,AddedDate,YesOrNo from PBnet_Order_OrderStatic ");
			strSql.Append(" where OrderID=@OrderID ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50)};
			parameters[0].Value = OrderID;

			Pbzx.Model.PBnet_Order_OrderStatic model=new Pbzx.Model.PBnet_Order_OrderStatic();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.OrderID=ds.Tables[0].Rows[0]["OrderID"].ToString();
				if(ds.Tables[0].Rows[0]["StaticID"].ToString()!="")
				{
					model.StaticID=int.Parse(ds.Tables[0].Rows[0]["StaticID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AddedDate"].ToString()!="")
				{
					model.AddedDate=DateTime.Parse(ds.Tables[0].Rows[0]["AddedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["YesOrNo"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["YesOrNo"].ToString()=="1")||(ds.Tables[0].Rows[0]["YesOrNo"].ToString().ToLower()=="true"))
					{
						model.YesOrNo=true;
					}
					else
					{
						model.YesOrNo=false;
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
			strSql.Append("select OrderID,StaticID,AddedDate,YesOrNo ");
			strSql.Append(" FROM PBnet_Order_OrderStatic ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" OrderID,StaticID,AddedDate,YesOrNo ");
			strSql.Append(" FROM PBnet_Order_OrderStatic ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "PBnet_Order_OrderStatic";
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

