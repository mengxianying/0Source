using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CN_RegisterLog。
    /// </summary>
    public class CN_RegisterLog : ICN_RegisterLog
    {
        public CN_RegisterLog()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CN_RegisterLog");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CN_RegisterLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CN_RegisterLog(");
            strSql.Append("BbsName,SoftwareType,InstallType,UseType,UseValue,PayType,PayMoney,PayStatus,PayTime,PayDetails,RegisterType,Operator,AgentName,CardInfo,CreateTime,Username,Remarks,CNUserID,CNUserDetailsID,Old_UserType,Old_ExpireDate,Old_ValidDays,RegisterMode)");
            strSql.Append(" values (");
            strSql.Append("@BbsName,@SoftwareType,@InstallType,@UseType,@UseValue,@PayType,@PayMoney,@PayStatus,@PayTime,@PayDetails,@RegisterType,@Operator,@AgentName,@CardInfo,@CreateTime,@Username,@Remarks,@CNUserID,@CNUserDetailsID,@Old_UserType,@Old_ExpireDate,@Old_ValidDays,@RegisterMode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@BbsName", SqlDbType.NVarChar,16),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@UseType", SqlDbType.TinyInt,1),
					new SqlParameter("@UseValue", SqlDbType.Int,4),
					new SqlParameter("@PayType", SqlDbType.NVarChar,32),
					new SqlParameter("@PayMoney", SqlDbType.Real,4),
					new SqlParameter("@PayStatus", SqlDbType.TinyInt,1),
					new SqlParameter("@PayTime", SqlDbType.DateTime),
					new SqlParameter("@PayDetails", SqlDbType.NVarChar,128),
					new SqlParameter("@RegisterType", SqlDbType.TinyInt,1),
					new SqlParameter("@Operator", SqlDbType.NVarChar,16),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,16),
					new SqlParameter("@CardInfo", SqlDbType.NVarChar,32),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.NVarChar,16),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,256),
					new SqlParameter("@CNUserID", SqlDbType.Int,4),
					new SqlParameter("@CNUserDetailsID", SqlDbType.Int,4),
					new SqlParameter("@Old_UserType", SqlDbType.TinyInt,1),
					new SqlParameter("@Old_ExpireDate", SqlDbType.SmallDateTime),
					new SqlParameter("@Old_ValidDays", SqlDbType.SmallInt,2),
                    new SqlParameter("@RegisterMode", SqlDbType.SmallInt,2)
            };
            parameters[0].Value = model.BbsName;
            parameters[1].Value = model.SoftwareType;
            parameters[2].Value = model.InstallType;
            parameters[3].Value = model.UseType;
            parameters[4].Value = model.UseValue;
            parameters[5].Value = model.PayType;
            parameters[6].Value = model.PayMoney;
            parameters[7].Value = model.PayStatus;
            parameters[8].Value = model.PayTime;
            parameters[9].Value = model.PayDetails;
            parameters[10].Value = model.RegisterType;
            parameters[11].Value = model.Operator;
            parameters[12].Value = model.AgentName;
            parameters[13].Value = model.CardInfo;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.Username;
            parameters[16].Value = model.Remarks;
            parameters[17].Value = model.CNUserID;
            parameters[18].Value = model.CNUserDetailsID;
            parameters[19].Value = model.Old_UserType;
            parameters[20].Value = model.Old_ExpireDate;
            parameters[21].Value = model.Old_ValidDays;
            parameters[22].Value = model.RegisterMode;

            object obj = DbHelperSQL1.GetSingle(strSql.ToString(), parameters);
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
        public int  Update(Pbzx.Model.CN_RegisterLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CN_RegisterLog set ");
            strSql.Append("BbsName=@BbsName,");
            strSql.Append("SoftwareType=@SoftwareType,");
            strSql.Append("UseType=@UseType,");
            strSql.Append("UseValue=@UseValue,");
            strSql.Append("PayType=@PayType,");
            strSql.Append("PayMoney=@PayMoney,");
            strSql.Append("PayStatus=@PayStatus,");
            strSql.Append("PayTime=@PayTime,");
            strSql.Append("PayDetails=@PayDetails,");
            strSql.Append("RegisterType=@RegisterType,");
            strSql.Append("Operator=@Operator,");
            strSql.Append("AgentName=@AgentName,");
            strSql.Append("CardInfo=@CardInfo,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Username=@Username,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("CNUserID=@CNUserID,");
            strSql.Append("CNUserDetailsID=@CNUserDetailsID,");
            strSql.Append("Old_UserType=@Old_UserType,");
            strSql.Append("Old_ExpireDate=@Old_ExpireDate,");
            strSql.Append("Old_ValidDays=@Old_ValidDays,");
            strSql.Append("RegisterMode=@RegisterMode ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@BbsName", SqlDbType.NVarChar,16),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@UseType", SqlDbType.TinyInt,1),
					new SqlParameter("@UseValue", SqlDbType.Int,4),
					new SqlParameter("@PayType", SqlDbType.NVarChar,32),
					new SqlParameter("@PayMoney", SqlDbType.Real,4),
					new SqlParameter("@PayStatus", SqlDbType.TinyInt,1),
					new SqlParameter("@PayTime", SqlDbType.DateTime),
					new SqlParameter("@PayDetails", SqlDbType.NVarChar,128),
					new SqlParameter("@RegisterType", SqlDbType.TinyInt,1),
					new SqlParameter("@Operator", SqlDbType.NVarChar,16),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,16),
					new SqlParameter("@CardInfo", SqlDbType.NVarChar,32),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.NVarChar,16),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,256),
					new SqlParameter("@CNUserID", SqlDbType.Int,4),
					new SqlParameter("@CNUserDetailsID", SqlDbType.Int,4),
					new SqlParameter("@Old_UserType", SqlDbType.TinyInt,1),
					new SqlParameter("@Old_ExpireDate", SqlDbType.SmallDateTime),
					new SqlParameter("@Old_ValidDays", SqlDbType.SmallInt,2),
                    new SqlParameter("@RegisterMode", SqlDbType.SmallInt,2)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BbsName;
            parameters[2].Value = model.SoftwareType;
            parameters[3].Value = model.InstallType;
            parameters[4].Value = model.UseType;
            parameters[5].Value = model.UseValue;
            parameters[6].Value = model.PayType;
            parameters[7].Value = model.PayMoney;
            parameters[8].Value = model.PayStatus;
            parameters[9].Value = model.PayTime;
            parameters[10].Value = model.PayDetails;
            parameters[11].Value = model.RegisterType;
            parameters[12].Value = model.Operator;
            parameters[13].Value = model.AgentName;
            parameters[14].Value = model.CardInfo;
            parameters[15].Value = model.CreateTime;
            parameters[16].Value = model.Username;
            parameters[17].Value = model.Remarks;
            parameters[18].Value = model.CNUserID;
            parameters[19].Value = model.CNUserDetailsID;
            parameters[20].Value = model.Old_UserType;
            parameters[21].Value = model.Old_ExpireDate;
            parameters[22].Value = model.Old_ValidDays;
            parameters[23].Value = model.RegisterMode;


          return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CN_RegisterLog ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

          return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CN_RegisterLog GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,BbsName,SoftwareType,InstallType,UseType,UseValue,PayType,PayMoney,PayStatus,PayTime,PayDetails,RegisterType,Operator,AgentName,CardInfo,CreateTime,Username,Remarks,CNUserID,CNUserDetailsID,Old_UserType,Old_ExpireDate,Old_ValidDays,RegisterMode from CN_RegisterLog ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.CN_RegisterLog model = new Pbzx.Model.CN_RegisterLog();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.BbsName = ds.Tables[0].Rows[0]["BbsName"].ToString();
                if (ds.Tables[0].Rows[0]["SoftwareType"].ToString() != "")
                {
                    model.SoftwareType = int.Parse(ds.Tables[0].Rows[0]["SoftwareType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InstallType"].ToString() != "")
                {
                    model.InstallType = int.Parse(ds.Tables[0].Rows[0]["InstallType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UseType"].ToString() != "")
                {
                    model.UseType = int.Parse(ds.Tables[0].Rows[0]["UseType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UseValue"].ToString() != "")
                {
                    model.UseValue = int.Parse(ds.Tables[0].Rows[0]["UseValue"].ToString());
                }
                model.PayType = ds.Tables[0].Rows[0]["PayType"].ToString();
                if (ds.Tables[0].Rows[0]["PayMoney"].ToString() != "")
                {
                    model.PayMoney = decimal.Parse(ds.Tables[0].Rows[0]["PayMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayStatus"].ToString() != "")
                {
                    model.PayStatus = int.Parse(ds.Tables[0].Rows[0]["PayStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayTime"].ToString() != "")
                {
                    model.PayTime = DateTime.Parse(ds.Tables[0].Rows[0]["PayTime"].ToString());
                }
                model.PayDetails = ds.Tables[0].Rows[0]["PayDetails"].ToString();
                if (ds.Tables[0].Rows[0]["RegisterType"].ToString() != "")
                {
                    model.RegisterType = int.Parse(ds.Tables[0].Rows[0]["RegisterType"].ToString());
                }
                model.Operator = ds.Tables[0].Rows[0]["Operator"].ToString();
                model.AgentName = ds.Tables[0].Rows[0]["AgentName"].ToString();
                model.CardInfo = ds.Tables[0].Rows[0]["CardInfo"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                model.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                if (ds.Tables[0].Rows[0]["CNUserID"].ToString() != "")
                {
                    model.CNUserID = int.Parse(ds.Tables[0].Rows[0]["CNUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CNUserDetailsID"].ToString() != "")
                {
                    model.CNUserDetailsID = int.Parse(ds.Tables[0].Rows[0]["CNUserDetailsID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Old_UserType"].ToString() != "")
                {
                    model.Old_UserType = int.Parse(ds.Tables[0].Rows[0]["Old_UserType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Old_ExpireDate"].ToString() != "")
                {
                    model.Old_ExpireDate = DateTime.Parse(ds.Tables[0].Rows[0]["Old_ExpireDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Old_ValidDays"].ToString() != "")
                {
                    model.Old_ValidDays = int.Parse(ds.Tables[0].Rows[0]["Old_ValidDays"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegisterMode"].ToString() != "")
                {
                    model.RegisterMode = int.Parse(ds.Tables[0].Rows[0]["RegisterMode"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BbsName,SoftwareType,InstallType,UseType,UseValue,PayType,PayMoney,PayStatus,PayTime,PayDetails,RegisterType,Operator,AgentName,CardInfo,CreateTime,Username,Remarks,CNUserID,CNUserDetailsID,Old_UserType,Old_ExpireDate,Old_ValidDays,RegisterMode ");
            strSql.Append(" FROM CN_RegisterLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL1.Query(strSql.ToString());
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
            parameters[0].Value = "CN_RegisterLog";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL1.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法


        public DataSet Query(string strSql)
        {
            return DbHelperSQL1.Query(strSql);
        }
    }
}

