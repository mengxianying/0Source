using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类RegisterInfo2。
    /// </summary>
    public class RegisterInfo2 : IRegisterInfo2
    {
        public RegisterInfo2()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RegisterInfo2");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.RegisterInfo2 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RegisterInfo2(");
            strSql.Append("RN,HDSN,Status,SoftwareType,InstallType,UserType,UseType,Operator,AgentID,AgentName,PayType,PayMoney,PayDetails,CardNo,CardPassword,TimeType,RegisterDate,ExpireDate,Username,UserTel,UserEmail,UserAddress,UpdateCount,LastUpdateDate,LastUpdateVersion,DD_Time,DD_Date,DD_Count,Remarks,BBsID,OrgSN,OldSN,IsReRegistered,RegisterMode)");
            strSql.Append(" values (");
            strSql.Append("@RN,@HDSN,@Status,@SoftwareType,@InstallType,@UserType,@UseType,@Operator,@AgentID,@AgentName,@PayType,@PayMoney,@PayDetails,@CardNo,@CardPassword,@TimeType,@RegisterDate,@ExpireDate,@Username,@UserTel,@UserEmail,@UserAddress,@UpdateCount,@LastUpdateDate,@LastUpdateVersion,@DD_Time,@DD_Date,@DD_Count,@Remarks,@BBsID,@OrgSN,@OldSN,@IsReRegistered,@RegisterMode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@RN", SqlDbType.NVarChar,32),
					new SqlParameter("@HDSN", SqlDbType.NVarChar,32),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@UserType", SqlDbType.TinyInt,1),
					new SqlParameter("@UseType", SqlDbType.TinyInt,1),
					new SqlParameter("@Operator", SqlDbType.NVarChar,16),
					new SqlParameter("@AgentID", SqlDbType.Int,4),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,20),
					new SqlParameter("@PayType", SqlDbType.NVarChar,20),
					new SqlParameter("@PayMoney", SqlDbType.Real,4),
					new SqlParameter("@PayDetails", SqlDbType.NVarChar,128),
					new SqlParameter("@CardNo", SqlDbType.NVarChar,16),
					new SqlParameter("@CardPassword", SqlDbType.NVarChar,8),
					new SqlParameter("@TimeType", SqlDbType.TinyInt,1),
					new SqlParameter("@RegisterDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.NVarChar,16),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,16),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,64),
					new SqlParameter("@UserAddress", SqlDbType.NVarChar,64),
					new SqlParameter("@UpdateCount", SqlDbType.Int,4),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateVersion", SqlDbType.NVarChar,16),
					new SqlParameter("@DD_Time", SqlDbType.DateTime),
					new SqlParameter("@DD_Date", SqlDbType.SmallDateTime),
					new SqlParameter("@DD_Count", SqlDbType.SmallInt,2),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,255),
					new SqlParameter("@BBsID", SqlDbType.NVarChar,20),
					new SqlParameter("@OrgSN", SqlDbType.NVarChar,10),
					new SqlParameter("@OldSN", SqlDbType.NVarChar,16),
					new SqlParameter("@IsReRegistered", SqlDbType.TinyInt,1),
                    new SqlParameter("@RegisterMode", SqlDbType.TinyInt,1)
            };
            parameters[0].Value = model.RN;
            parameters[1].Value = model.HDSN;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.SoftwareType;
            parameters[4].Value = model.InstallType;
            parameters[5].Value = model.UserType;
            parameters[6].Value = model.UseType;
            parameters[7].Value = model.Operator;
            parameters[8].Value = model.AgentID;
            parameters[9].Value = model.AgentName;
            parameters[10].Value = model.PayType;
            parameters[11].Value = model.PayMoney;
            parameters[12].Value = model.PayDetails;
            parameters[13].Value = model.CardNo;
            parameters[14].Value = model.CardPassword;
            parameters[15].Value = model.TimeType;
            parameters[16].Value = model.RegisterDate;
            parameters[17].Value = model.ExpireDate;
            parameters[18].Value = model.Username;
            parameters[19].Value = model.UserTel;
            parameters[20].Value = model.UserEmail;
            parameters[21].Value = model.UserAddress;
            parameters[22].Value = model.UpdateCount;
            parameters[23].Value = model.LastUpdateDate;
            parameters[24].Value = model.LastUpdateVersion;
            parameters[25].Value = model.DD_Time;
            parameters[26].Value = model.DD_Date;
            parameters[27].Value = model.DD_Count;
            parameters[28].Value = model.Remarks;
            parameters[29].Value = model.BBsID;
            parameters[30].Value = model.OrgSN;
            parameters[31].Value = model.OldSN;
            parameters[32].Value = model.IsReRegistered;
            parameters[33].Value = model.RegisterMode;

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
        public int Update(Pbzx.Model.RegisterInfo2 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RegisterInfo2 set ");
            strSql.Append("RN=@RN,");
            strSql.Append("HDSN=@HDSN,");
            strSql.Append("Status=@Status,");
            strSql.Append("SoftwareType=@SoftwareType,");
            strSql.Append("InstallType=@InstallType,");
            strSql.Append("UserType=@UserType,");
            strSql.Append("UseType=@UseType,");
            strSql.Append("Operator=@Operator,");
            strSql.Append("AgentID=@AgentID,");
            strSql.Append("AgentName=@AgentName,");
            strSql.Append("PayType=@PayType,");
            strSql.Append("PayMoney=@PayMoney,");
            strSql.Append("PayDetails=@PayDetails,");
            strSql.Append("CardNo=@CardNo,");
            strSql.Append("CardPassword=@CardPassword,");
            strSql.Append("TimeType=@TimeType,");
            strSql.Append("RegisterDate=@RegisterDate,");
            strSql.Append("ExpireDate=@ExpireDate,");
            strSql.Append("Username=@Username,");
            strSql.Append("UserTel=@UserTel,");
            strSql.Append("UserEmail=@UserEmail,");
            strSql.Append("UserAddress=@UserAddress,");
            strSql.Append("UpdateCount=@UpdateCount,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("LastUpdateVersion=@LastUpdateVersion,");
            strSql.Append("DD_Time=@DD_Time,");
            strSql.Append("DD_Date=@DD_Date,");
            strSql.Append("DD_Count=@DD_Count,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("BBsID=@BBsID,");
            strSql.Append("OrgSN=@OrgSN,");
            strSql.Append("OldSN=@OldSN,");
            strSql.Append("IsReRegistered=@IsReRegistered,");
            strSql.Append("RegisterMode=@RegisterMode");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@RN", SqlDbType.NVarChar,32),
					new SqlParameter("@HDSN", SqlDbType.NVarChar,32),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@UserType", SqlDbType.TinyInt,1),
					new SqlParameter("@UseType", SqlDbType.TinyInt,1),
					new SqlParameter("@Operator", SqlDbType.NVarChar,16),
					new SqlParameter("@AgentID", SqlDbType.Int,4),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,20),
					new SqlParameter("@PayType", SqlDbType.NVarChar,20),
					new SqlParameter("@PayMoney", SqlDbType.Real,4),
					new SqlParameter("@PayDetails", SqlDbType.NVarChar,128),
					new SqlParameter("@CardNo", SqlDbType.NVarChar,16),
					new SqlParameter("@CardPassword", SqlDbType.NVarChar,8),
					new SqlParameter("@TimeType", SqlDbType.TinyInt,1),
					new SqlParameter("@RegisterDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.DateTime),
					new SqlParameter("@Username", SqlDbType.NVarChar,16),
					new SqlParameter("@UserTel", SqlDbType.NVarChar,16),
					new SqlParameter("@UserEmail", SqlDbType.NVarChar,64),
					new SqlParameter("@UserAddress", SqlDbType.NVarChar,64),
					new SqlParameter("@UpdateCount", SqlDbType.Int,4),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateVersion", SqlDbType.NVarChar,16),
					new SqlParameter("@DD_Time", SqlDbType.DateTime),
					new SqlParameter("@DD_Date", SqlDbType.SmallDateTime),
					new SqlParameter("@DD_Count", SqlDbType.SmallInt,2),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,255),
					new SqlParameter("@BBsID", SqlDbType.NVarChar,20),
					new SqlParameter("@OrgSN", SqlDbType.NVarChar,10),
					new SqlParameter("@OldSN", SqlDbType.NVarChar,16),
					new SqlParameter("@IsReRegistered", SqlDbType.TinyInt,1),
                    new SqlParameter("@RegisterMode", SqlDbType.TinyInt,1)            
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.RN;
            parameters[2].Value = model.HDSN;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.SoftwareType;
            parameters[5].Value = model.InstallType;
            parameters[6].Value = model.UserType;
            parameters[7].Value = model.UseType;
            parameters[8].Value = model.Operator;
            parameters[9].Value = model.AgentID;
            parameters[10].Value = model.AgentName;
            parameters[11].Value = model.PayType;
            parameters[12].Value = model.PayMoney;
            parameters[13].Value = model.PayDetails;
            parameters[14].Value = model.CardNo;
            parameters[15].Value = model.CardPassword;
            parameters[16].Value = model.TimeType;
            parameters[17].Value = model.RegisterDate;
            parameters[18].Value = model.ExpireDate;
            parameters[19].Value = model.Username;
            parameters[20].Value = model.UserTel;
            parameters[21].Value = model.UserEmail;
            parameters[22].Value = model.UserAddress;
            parameters[23].Value = model.UpdateCount;
            parameters[24].Value = model.LastUpdateDate;
            parameters[25].Value = model.LastUpdateVersion;
            parameters[26].Value = model.DD_Time;
            parameters[27].Value = model.DD_Date;
            parameters[28].Value = model.DD_Count;
            parameters[29].Value = model.Remarks;
            parameters[30].Value = model.BBsID;
            parameters[31].Value = model.OrgSN;
            parameters[32].Value = model.OldSN;
            parameters[33].Value = model.IsReRegistered;
            parameters[34].Value = model.RegisterMode;

           return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RegisterInfo2 ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

          return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.RegisterInfo2 GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,RN,HDSN,Status,SoftwareType,InstallType,UserType,UseType,Operator,AgentID,AgentName,PayType,PayMoney,PayDetails,CardNo,CardPassword,TimeType,RegisterDate,ExpireDate,Username,UserTel,UserEmail,UserAddress,UpdateCount,LastUpdateDate,LastUpdateVersion,DD_Time,DD_Date,DD_Count,Remarks,BBsID,OrgSN,OldSN,IsReRegistered,RegisterMode from RegisterInfo2 ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.RegisterInfo2 model = new Pbzx.Model.RegisterInfo2();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.RN = ds.Tables[0].Rows[0]["RN"].ToString();
                model.HDSN = ds.Tables[0].Rows[0]["HDSN"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SoftwareType"].ToString() != "")
                {
                    model.SoftwareType = int.Parse(ds.Tables[0].Rows[0]["SoftwareType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["InstallType"].ToString() != "")
                {
                    model.InstallType = int.Parse(ds.Tables[0].Rows[0]["InstallType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserType"].ToString() != "")
                {
                    model.UserType = int.Parse(ds.Tables[0].Rows[0]["UserType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UseType"].ToString() != "")
                {
                    model.UseType = int.Parse(ds.Tables[0].Rows[0]["UseType"].ToString());
                }
                model.Operator = ds.Tables[0].Rows[0]["Operator"].ToString();
                if (ds.Tables[0].Rows[0]["AgentID"].ToString() != "")
                {
                    model.AgentID = int.Parse(ds.Tables[0].Rows[0]["AgentID"].ToString());
                }
                model.AgentName = ds.Tables[0].Rows[0]["AgentName"].ToString();
                model.PayType = ds.Tables[0].Rows[0]["PayType"].ToString();
                if (ds.Tables[0].Rows[0]["PayMoney"].ToString() != "")
                {
                    model.PayMoney = decimal.Parse(ds.Tables[0].Rows[0]["PayMoney"].ToString());
                }
                model.PayDetails = ds.Tables[0].Rows[0]["PayDetails"].ToString();
                model.CardNo = ds.Tables[0].Rows[0]["CardNo"].ToString();
                model.CardPassword = ds.Tables[0].Rows[0]["CardPassword"].ToString();
                if (ds.Tables[0].Rows[0]["TimeType"].ToString() != "")
                {
                    model.TimeType = int.Parse(ds.Tables[0].Rows[0]["TimeType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegisterDate"].ToString() != "")
                {
                    model.RegisterDate = DateTime.Parse(ds.Tables[0].Rows[0]["RegisterDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ExpireDate"].ToString() != "")
                {
                    model.ExpireDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpireDate"].ToString());
                }
                model.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                model.UserTel = ds.Tables[0].Rows[0]["UserTel"].ToString();
                model.UserEmail = ds.Tables[0].Rows[0]["UserEmail"].ToString();
                model.UserAddress = ds.Tables[0].Rows[0]["UserAddress"].ToString();
                if (ds.Tables[0].Rows[0]["UpdateCount"].ToString() != "")
                {
                    model.UpdateCount = int.Parse(ds.Tables[0].Rows[0]["UpdateCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastUpdateDate"].ToString() != "")
                {
                    model.LastUpdateDate = DateTime.Parse(ds.Tables[0].Rows[0]["LastUpdateDate"].ToString());
                }
                model.LastUpdateVersion = ds.Tables[0].Rows[0]["LastUpdateVersion"].ToString();
                if (ds.Tables[0].Rows[0]["DD_Time"].ToString() != "")
                {
                    model.DD_Time = DateTime.Parse(ds.Tables[0].Rows[0]["DD_Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DD_Date"].ToString() != "")
                {
                    model.DD_Date = DateTime.Parse(ds.Tables[0].Rows[0]["DD_Date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DD_Count"].ToString() != "")
                {
                    model.DD_Count = int.Parse(ds.Tables[0].Rows[0]["DD_Count"].ToString());
                }
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                model.BBsID = ds.Tables[0].Rows[0]["BBsID"].ToString();
                model.OrgSN = ds.Tables[0].Rows[0]["OrgSN"].ToString();
                model.OldSN = ds.Tables[0].Rows[0]["OldSN"].ToString();
                if (ds.Tables[0].Rows[0]["IsReRegistered"].ToString() != "")
                {
                    model.IsReRegistered = int.Parse(ds.Tables[0].Rows[0]["IsReRegistered"].ToString());
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
            strSql.Append("select ID,RN,HDSN,Status,SoftwareType,InstallType,UserType,UseType,Operator,AgentID,AgentName,PayType,PayMoney,PayDetails,CardNo,CardPassword,TimeType,RegisterDate,ExpireDate,Username,UserTel,UserEmail,UserAddress,UpdateCount,LastUpdateDate,LastUpdateVersion,DD_Time,DD_Date,DD_Count,Remarks,BBsID,OrgSN,OldSN,IsReRegistered,RegisterMode ");
            strSql.Append(" FROM RegisterInfo2 ");
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
            parameters[0].Value = "RegisterInfo2";
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

