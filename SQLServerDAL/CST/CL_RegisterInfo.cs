using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CL_RegisterInfo。
    /// </summary>
    public class CL_RegisterInfo : ICL_RegisterInfo
    {
        public CL_RegisterInfo()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CL_RegisterInfo");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CL_RegisterInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CL_RegisterInfo(");
            strSql.Append("SoftwareType,InstallType,SNs,Status,Operator,PayType,PayMoney,PayDetails,PayStatus,PayTime,RegisterType,AgentName,CardInfo,CreateTime,UserName,UserEmail,UserTel,UserAddress,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@SoftwareType,@InstallType,@SNs,@Status,@Operator,@PayType,@PayMoney,@PayDetails,@PayStatus,@PayTime,@RegisterType,@AgentName,@CardInfo,@CreateTime,@UserName,@UserEmail,@UserTel,@UserAddress,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@SNs", SqlDbType.NVarChar,128),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Operator", SqlDbType.NVarChar,16),
					new SqlParameter("@PayType", SqlDbType.NVarChar,32),
					new SqlParameter("@PayMoney", SqlDbType.SmallInt,2),
					new SqlParameter("@PayDetails", SqlDbType.NVarChar,128),
					new SqlParameter("@PayStatus", SqlDbType.TinyInt,1),
					new SqlParameter("@PayTime", SqlDbType.DateTime),
					new SqlParameter("@RegisterType", SqlDbType.TinyInt,1),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,16),
					new SqlParameter("@CardInfo", SqlDbType.NVarChar,32),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UserName", SqlDbType.NVarChar,16),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,64),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,32),
					new SqlParameter("@UserAddress", SqlDbType.NVarChar,128),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.SoftwareType;
            parameters[1].Value = model.InstallType;
            parameters[2].Value = model.SNs;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.Operator;
            parameters[5].Value = model.PayType;
            parameters[6].Value = model.PayMoney;
            parameters[7].Value = model.PayDetails;
            parameters[8].Value = model.PayStatus;
            parameters[9].Value = model.PayTime;
            parameters[10].Value = model.RegisterType;
            parameters[11].Value = model.AgentName;
            parameters[12].Value = model.CardInfo;
            parameters[13].Value = model.CreateTime;
            parameters[14].Value = model.UserName;
            parameters[15].Value = model.UserEmail;
            parameters[16].Value = model.UserTel;
            parameters[17].Value = model.UserAddress;
            parameters[18].Value = model.Remarks;

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
        public int Update(Pbzx.Model.CL_RegisterInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CL_RegisterInfo set ");
            strSql.Append("SoftwareType=@SoftwareType,");
            strSql.Append("InstallType=@InstallType,");
            strSql.Append("SNs=@SNs,");
            strSql.Append("Operator=@Operator,");
            strSql.Append("PayType=@PayType,");
            strSql.Append("PayMoney=@PayMoney,");
            strSql.Append("PayDetails=@PayDetails,");
            strSql.Append("PayStatus=@PayStatus,");
            strSql.Append("AgentName=@AgentName,");
            strSql.Append("CardInfo=@CardInfo,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserEmail=@UserEmail,");
            strSql.Append("UserTel=@UserTel,");
            strSql.Append("UserAddress=@UserAddress,");
            strSql.Append("Remarks=@Remarks");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@SNs", SqlDbType.NVarChar,128),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Operator", SqlDbType.NVarChar,16),
					new SqlParameter("@PayType", SqlDbType.NVarChar,32),
					new SqlParameter("@PayMoney", SqlDbType.SmallInt,2),
					new SqlParameter("@PayDetails", SqlDbType.NVarChar,128),
					new SqlParameter("@PayStatus", SqlDbType.TinyInt,1),
					new SqlParameter("@PayTime", SqlDbType.DateTime),
					new SqlParameter("@RegisterType", SqlDbType.TinyInt,1),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,16),
					new SqlParameter("@CardInfo", SqlDbType.NVarChar,32),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UserName", SqlDbType.NVarChar,16),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,64),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,32),
					new SqlParameter("@UserAddress", SqlDbType.NVarChar,128),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SoftwareType;
            parameters[2].Value = model.InstallType;
            parameters[3].Value = model.SNs;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.Operator;
            parameters[6].Value = model.PayType;
            parameters[7].Value = model.PayMoney;
            parameters[8].Value = model.PayDetails;
            parameters[9].Value = model.PayStatus;
            parameters[10].Value = model.PayTime;
            parameters[11].Value = model.RegisterType;
            parameters[12].Value = model.AgentName;
            parameters[13].Value = model.CardInfo;
            parameters[14].Value = model.CreateTime;
            parameters[15].Value = model.UserName;
            parameters[16].Value = model.UserEmail;
            parameters[17].Value = model.UserTel;
            parameters[18].Value = model.UserAddress;
            parameters[19].Value = model.Remarks;

           return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CL_RegisterInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

           return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CL_RegisterInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SoftwareType,InstallType,SNs,Status,Operator,PayType,PayMoney,PayDetails,PayStatus,PayTime,RegisterType,AgentName,CardInfo,CreateTime,UserName,UserEmail,UserTel,UserAddress,Remarks from CL_RegisterInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.CL_RegisterInfo model = new Pbzx.Model.CL_RegisterInfo();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SoftwareType"].ToString() != "")
                {
                    model.SoftwareType = int.Parse(ds.Tables[0].Rows[0]["SoftwareType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InstallType"].ToString() != "")
                {
                    model.InstallType = int.Parse(ds.Tables[0].Rows[0]["InstallType"].ToString());
                }
                model.SNs = ds.Tables[0].Rows[0]["SNs"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                model.Operator = ds.Tables[0].Rows[0]["Operator"].ToString();
                model.PayType = ds.Tables[0].Rows[0]["PayType"].ToString();
                if (ds.Tables[0].Rows[0]["PayMoney"].ToString() != "")
                {
                    model.PayMoney = int.Parse(ds.Tables[0].Rows[0]["PayMoney"].ToString());
                }
                model.PayDetails = ds.Tables[0].Rows[0]["PayDetails"].ToString();
                if (ds.Tables[0].Rows[0]["PayStatus"].ToString() != "")
                {
                    model.PayStatus = int.Parse(ds.Tables[0].Rows[0]["PayStatus"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PayTime"].ToString() != "")
                {
                    model.PayTime = DateTime.Parse(ds.Tables[0].Rows[0]["PayTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegisterType"].ToString() != "")
                {
                    model.RegisterType = int.Parse(ds.Tables[0].Rows[0]["RegisterType"].ToString());
                }
                model.AgentName = ds.Tables[0].Rows[0]["AgentName"].ToString();
                model.CardInfo = ds.Tables[0].Rows[0]["CardInfo"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.UserEmail = ds.Tables[0].Rows[0]["UserEmail"].ToString();
                model.UserTel = ds.Tables[0].Rows[0]["UserTel"].ToString();
                model.UserAddress = ds.Tables[0].Rows[0]["UserAddress"].ToString();
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
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
            strSql.Append("select ID,SoftwareType,InstallType,SNs,Status,Operator,PayType,PayMoney,PayDetails,PayStatus,PayTime,RegisterType,AgentName,CardInfo,CreateTime,UserName,UserEmail,UserTel,UserAddress,Remarks ");
            strSql.Append(" FROM CL_RegisterInfo ");
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
            parameters[0].Value = "CL_RegisterInfo";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL1.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        /// <summary>
        /// 根据sql语句查询
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>返回值</returns>
        public DataSet Query(string strSql)
        {
            return DbHelperSQL1.Query(strSql);
        }
    }
}

