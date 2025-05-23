using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_FreeReg。
	/// </summary>
	public class PBnet_FreeReg:IPBnet_FreeReg
	{
		public PBnet_FreeReg()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Status", "PBnet_FreeReg"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string RN,int Status,int SoftwareType,int InstallType,int intFrID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PBnet_FreeReg");
			strSql.Append(" where RN=@RN and Status=@Status and SoftwareType=@SoftwareType and InstallType=@InstallType and intFrID=@intFrID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RN", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt),
					new SqlParameter("@InstallType", SqlDbType.TinyInt),
					new SqlParameter("@intFrID", SqlDbType.Int,4)};
			parameters[0].Value = RN;
			parameters[1].Value = Status;
			parameters[2].Value = SoftwareType;
			parameters[3].Value = InstallType;
			parameters[4].Value = intFrID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Pbzx.Model.PBnet_FreeReg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PBnet_FreeReg(");
			strSql.Append("RN,HDSN,Status,SoftwareType,InstallType,RequestTime,RegisterTime,Username,UserTel,UserEmail,UserAddress,BbsID,NameError,AddressError,ErrorInfo,Remarks,QueryCount,QueryTime,QueryIP)");
			strSql.Append(" values (");
			strSql.Append("@RN,@HDSN,@Status,@SoftwareType,@InstallType,@RequestTime,@RegisterTime,@Username,@UserTel,@UserEmail,@UserAddress,@BbsID,@NameError,@AddressError,@ErrorInfo,@Remarks,@QueryCount,@QueryTime,@QueryIP)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@RN", SqlDbType.NVarChar,32),
					new SqlParameter("@HDSN", SqlDbType.NVarChar,16),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@RequestTime", SqlDbType.DateTime),
					new SqlParameter("@RegisterTime", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.NVarChar,16),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,16),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,64),
					new SqlParameter("@UserAddress", SqlDbType.NVarChar,64),
					new SqlParameter("@BbsID", SqlDbType.NVarChar,16),
					new SqlParameter("@NameError", SqlDbType.Bit,1),
					new SqlParameter("@AddressError", SqlDbType.Bit,1),
					new SqlParameter("@ErrorInfo", SqlDbType.NVarChar,128),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,255),
					new SqlParameter("@QueryCount", SqlDbType.SmallInt,2),
					new SqlParameter("@QueryTime", SqlDbType.SmallDateTime),
					new SqlParameter("@QueryIP", SqlDbType.NVarChar,128)};
			parameters[0].Value = model.RN;
			parameters[1].Value = model.HDSN;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.SoftwareType;
			parameters[4].Value = model.InstallType;
			parameters[5].Value = model.RequestTime;
			parameters[6].Value = model.RegisterTime;
			parameters[7].Value = model.Username;
			parameters[8].Value = model.UserTel;
			parameters[9].Value = model.UserEmail;
			parameters[10].Value = model.UserAddress;
			parameters[11].Value = model.BbsID;
			parameters[12].Value = model.NameError;
			parameters[13].Value = model.AddressError;
			parameters[14].Value = model.ErrorInfo;
			parameters[15].Value = model.Remarks;
			parameters[16].Value = model.QueryCount;
			parameters[17].Value = model.QueryTime;
			parameters[18].Value = model.QueryIP;

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
		public void Update(Pbzx.Model.PBnet_FreeReg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PBnet_FreeReg set ");
			strSql.Append("HDSN=@HDSN,");
			strSql.Append("RequestTime=@RequestTime,");
			strSql.Append("RegisterTime=@RegisterTime,");
			strSql.Append("Username=@Username,");
			strSql.Append("UserTel=@UserTel,");
			strSql.Append("UserEmail=@UserEmail,");
			strSql.Append("UserAddress=@UserAddress,");
			strSql.Append("BbsID=@BbsID,");
			strSql.Append("NameError=@NameError,");
			strSql.Append("AddressError=@AddressError,");
			strSql.Append("ErrorInfo=@ErrorInfo,");
			strSql.Append("Remarks=@Remarks,");
			strSql.Append("QueryCount=@QueryCount,");
			strSql.Append("QueryTime=@QueryTime,");
			strSql.Append("QueryIP=@QueryIP");
			strSql.Append(" where RN=@RN and Status=@Status and SoftwareType=@SoftwareType and InstallType=@InstallType and intFrID=@intFrID ");
			SqlParameter[] parameters = {
					new SqlParameter("@intFrID", SqlDbType.Int,4),
					new SqlParameter("@RN", SqlDbType.NVarChar,32),
					new SqlParameter("@HDSN", SqlDbType.NVarChar,16),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@RequestTime", SqlDbType.DateTime),
					new SqlParameter("@RegisterTime", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.NVarChar,16),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,16),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,64),
					new SqlParameter("@UserAddress", SqlDbType.NVarChar,64),
					new SqlParameter("@BbsID", SqlDbType.NVarChar,16),
					new SqlParameter("@NameError", SqlDbType.Bit,1),
					new SqlParameter("@AddressError", SqlDbType.Bit,1),
					new SqlParameter("@ErrorInfo", SqlDbType.NVarChar,128),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,255),
					new SqlParameter("@QueryCount", SqlDbType.SmallInt,2),
					new SqlParameter("@QueryTime", SqlDbType.SmallDateTime),
					new SqlParameter("@QueryIP", SqlDbType.NVarChar,128)};
			parameters[0].Value = model.intFrID;
			parameters[1].Value = model.RN;
			parameters[2].Value = model.HDSN;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.SoftwareType;
			parameters[5].Value = model.InstallType;
			parameters[6].Value = model.RequestTime;
			parameters[7].Value = model.RegisterTime;
			parameters[8].Value = model.Username;
			parameters[9].Value = model.UserTel;
			parameters[10].Value = model.UserEmail;
			parameters[11].Value = model.UserAddress;
			parameters[12].Value = model.BbsID;
			parameters[13].Value = model.NameError;
			parameters[14].Value = model.AddressError;
			parameters[15].Value = model.ErrorInfo;
			parameters[16].Value = model.Remarks;
			parameters[17].Value = model.QueryCount;
			parameters[18].Value = model.QueryTime;
			parameters[19].Value = model.QueryIP;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string RN,int Status,int SoftwareType,int InstallType,int intFrID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete PBnet_FreeReg ");
			strSql.Append(" where RN=@RN and Status=@Status and SoftwareType=@SoftwareType and InstallType=@InstallType and intFrID=@intFrID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RN", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt),
					new SqlParameter("@InstallType", SqlDbType.TinyInt),
					new SqlParameter("@intFrID", SqlDbType.Int,4)};
			parameters[0].Value = RN;
			parameters[1].Value = Status;
			parameters[2].Value = SoftwareType;
			parameters[3].Value = InstallType;
			parameters[4].Value = intFrID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_FreeReg GetModel(string RN,int Status,int SoftwareType,int InstallType,int intFrID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 intFrID,RN,HDSN,Status,SoftwareType,InstallType,RequestTime,RegisterTime,Username,UserTel,UserEmail,UserAddress,BbsID,NameError,AddressError,ErrorInfo,Remarks,QueryCount,QueryTime,QueryIP from PBnet_FreeReg ");
			strSql.Append(" where RN=@RN and Status=@Status and SoftwareType=@SoftwareType and InstallType=@InstallType and intFrID=@intFrID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RN", SqlDbType.NVarChar,50),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt),
					new SqlParameter("@InstallType", SqlDbType.TinyInt),
					new SqlParameter("@intFrID", SqlDbType.Int,4)};
			parameters[0].Value = RN;
			parameters[1].Value = Status;
			parameters[2].Value = SoftwareType;
			parameters[3].Value = InstallType;
			parameters[4].Value = intFrID;

			Pbzx.Model.PBnet_FreeReg model=new Pbzx.Model.PBnet_FreeReg();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["intFrID"].ToString()!="")
				{
					model.intFrID=int.Parse(ds.Tables[0].Rows[0]["intFrID"].ToString());
				}
				model.RN=ds.Tables[0].Rows[0]["RN"].ToString();
				model.HDSN=ds.Tables[0].Rows[0]["HDSN"].ToString();
				if(ds.Tables[0].Rows[0]["Status"].ToString()!="")
				{
					model.Status=int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SoftwareType"].ToString()!="")
				{
					model.SoftwareType=int.Parse(ds.Tables[0].Rows[0]["SoftwareType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InstallType"].ToString()!="")
				{
					model.InstallType=int.Parse(ds.Tables[0].Rows[0]["InstallType"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RequestTime"].ToString()!="")
				{
					model.RequestTime=DateTime.Parse(ds.Tables[0].Rows[0]["RequestTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["RegisterTime"].ToString()!="")
				{
					model.RegisterTime=DateTime.Parse(ds.Tables[0].Rows[0]["RegisterTime"].ToString());
				}
				model.Username=ds.Tables[0].Rows[0]["Username"].ToString();
				model.UserTel=ds.Tables[0].Rows[0]["UserTel"].ToString();
				model.UserEmail=ds.Tables[0].Rows[0]["UserEmail"].ToString();
				model.UserAddress=ds.Tables[0].Rows[0]["UserAddress"].ToString();
				model.BbsID=ds.Tables[0].Rows[0]["BbsID"].ToString();
				if(ds.Tables[0].Rows[0]["NameError"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["NameError"].ToString()=="1")||(ds.Tables[0].Rows[0]["NameError"].ToString().ToLower()=="true"))
					{
						model.NameError=true;
					}
					else
					{
						model.NameError=false;
					}
				}
				if(ds.Tables[0].Rows[0]["AddressError"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["AddressError"].ToString()=="1")||(ds.Tables[0].Rows[0]["AddressError"].ToString().ToLower()=="true"))
					{
						model.AddressError=true;
					}
					else
					{
						model.AddressError=false;
					}
				}
				model.ErrorInfo=ds.Tables[0].Rows[0]["ErrorInfo"].ToString();
				model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
				if(ds.Tables[0].Rows[0]["QueryCount"].ToString()!="")
				{
					model.QueryCount=int.Parse(ds.Tables[0].Rows[0]["QueryCount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QueryTime"].ToString()!="")
				{
					model.QueryTime=DateTime.Parse(ds.Tables[0].Rows[0]["QueryTime"].ToString());
				}
				model.QueryIP=ds.Tables[0].Rows[0]["QueryIP"].ToString();
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
			strSql.Append("select intFrID,RN,HDSN,Status,SoftwareType,InstallType,RequestTime,RegisterTime,Username,UserTel,UserEmail,UserAddress,BbsID,NameError,AddressError,ErrorInfo,Remarks,QueryCount,QueryTime,QueryIP ");
			strSql.Append(" FROM PBnet_FreeReg ");
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
			parameters[0].Value = "PBnet_FreeReg";
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

