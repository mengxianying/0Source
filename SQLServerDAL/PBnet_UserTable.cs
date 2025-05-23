using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_UserTable。
    /// </summary>
    public class PBnet_UserTable : IPBnet_UserTable
    {
        public PBnet_UserTable()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_UserTable");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_UserTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_UserTable(");
            strSql.Append("UserName,RealName,TradePwd,CardID,Province,City,PostCode,Address,Telphone,Mobile,Email,QQ,MSN,Birthday,Sex,BankName,BankInfo,AccountNumber,CurrentMoney,FrozenMoney,LastTrade_time,State,CreatTime,OperateTime,OperateManager,OperateResult,Remark,EmailState,AccountNumberState,EmailCode,AccountNumberCode,EmailCodeTime,AccountNumberCodeTime,EmailCodeCount,AccountNumberCodeCount)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@RealName,@TradePwd,@CardID,@Province,@City,@PostCode,@Address,@Telphone,@Mobile,@Email,@QQ,@MSN,@Birthday,@Sex,@BankName,@BankInfo,@AccountNumber,@CurrentMoney,@FrozenMoney,@LastTrade_time,@State,@CreatTime,@OperateTime,@OperateManager,@OperateResult,@Remark,@EmailState,@AccountNumberState,@EmailCode,@AccountNumberCode,@EmailCodeTime,@AccountNumberCodeTime,@EmailCodeCount,@AccountNumberCodeCount)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@RealName", SqlDbType.NVarChar,20),
					new SqlParameter("@TradePwd", SqlDbType.NVarChar,50),
					new SqlParameter("@CardID", SqlDbType.VarChar,20),
					new SqlParameter("@Province", SqlDbType.NVarChar,20),
					new SqlParameter("@City", SqlDbType.NVarChar,20),
					new SqlParameter("@PostCode", SqlDbType.VarChar,20),
					new SqlParameter("@Address", SqlDbType.NVarChar,255),
					new SqlParameter("@Telphone", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@MSN", SqlDbType.VarChar,20),
					new SqlParameter("@Birthday", SqlDbType.SmallDateTime),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@BankName", SqlDbType.NVarChar,20),
					new SqlParameter("@BankInfo", SqlDbType.NVarChar,50),
					new SqlParameter("@AccountNumber", SqlDbType.VarChar,50),
					new SqlParameter("@CurrentMoney", SqlDbType.Money,8),
					new SqlParameter("@FrozenMoney", SqlDbType.Money,8),
					new SqlParameter("@LastTrade_time", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.TinyInt,1),
					new SqlParameter("@CreatTime", SqlDbType.DateTime),
					new SqlParameter("@OperateTime", SqlDbType.DateTime),
					new SqlParameter("@OperateManager", SqlDbType.NVarChar,20),
					new SqlParameter("@OperateResult", SqlDbType.NVarChar,128),
					new SqlParameter("@Remark", SqlDbType.NVarChar,255),
					new SqlParameter("@EmailState", SqlDbType.SmallInt,2),
					new SqlParameter("@AccountNumberState", SqlDbType.SmallInt,2),
					new SqlParameter("@EmailCode", SqlDbType.VarChar,50),
					new SqlParameter("@AccountNumberCode", SqlDbType.VarChar,20),
					new SqlParameter("@EmailCodeTime", SqlDbType.SmallDateTime),
					new SqlParameter("@AccountNumberCodeTime", SqlDbType.SmallDateTime),
					new SqlParameter("@EmailCodeCount", SqlDbType.Int,4),
					new SqlParameter("@AccountNumberCodeCount", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.TradePwd;
            parameters[3].Value = model.CardID;
            parameters[4].Value = model.Province;
            parameters[5].Value = model.City;
            parameters[6].Value = model.PostCode;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.Telphone;
            parameters[9].Value = model.Mobile;
            parameters[10].Value = model.Email;
            parameters[11].Value = model.QQ;
            parameters[12].Value = model.MSN;
            parameters[13].Value = model.Birthday;
            parameters[14].Value = model.Sex;
            parameters[15].Value = model.BankName;
            parameters[16].Value = model.BankInfo;
            parameters[17].Value = model.AccountNumber;
            parameters[18].Value = model.CurrentMoney;
            parameters[19].Value = model.FrozenMoney;
            parameters[20].Value = model.LastTrade_time;
            parameters[21].Value = model.State;
            parameters[22].Value = model.CreatTime;
            parameters[23].Value = model.OperateTime;
            parameters[24].Value = model.OperateManager;
            parameters[25].Value = model.OperateResult;
            parameters[26].Value = model.Remark;
            parameters[27].Value = model.EmailState;
            parameters[28].Value = model.AccountNumberState;
            parameters[29].Value = model.EmailCode;
            parameters[30].Value = model.AccountNumberCode;
            parameters[31].Value = model.EmailCodeTime;
            parameters[32].Value = model.AccountNumberCodeTime;
            parameters[33].Value = model.EmailCodeCount;
            parameters[34].Value = model.AccountNumberCodeCount;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public int  Update(Pbzx.Model.PBnet_UserTable model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_UserTable set ");
            strSql.Append("RealName=@RealName,");
            strSql.Append("TradePwd=@TradePwd,");
            strSql.Append("CardID=@CardID,");
            strSql.Append("Province=@Province,");
            strSql.Append("City=@City,");
            strSql.Append("PostCode=@PostCode,");
            strSql.Append("Address=@Address,");
            strSql.Append("Telphone=@Telphone,");
            strSql.Append("Mobile=@Mobile,");
            strSql.Append("Email=@Email,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("MSN=@MSN,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("BankName=@BankName,");
            strSql.Append("BankInfo=@BankInfo,");
            strSql.Append("AccountNumber=@AccountNumber,");
            strSql.Append("CurrentMoney=@CurrentMoney,");
            strSql.Append("FrozenMoney=@FrozenMoney,");
            strSql.Append("LastTrade_time=@LastTrade_time,");
            strSql.Append("State=@State,");
            strSql.Append("CreatTime=@CreatTime,");
            strSql.Append("OperateTime=@OperateTime,");
            strSql.Append("OperateManager=@OperateManager,");
            strSql.Append("OperateResult=@OperateResult,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("EmailState=@EmailState,");
            strSql.Append("AccountNumberState=@AccountNumberState,");
            strSql.Append("EmailCode=@EmailCode,");
            strSql.Append("AccountNumberCode=@AccountNumberCode,");
            strSql.Append("EmailCodeTime=@EmailCodeTime,");
            strSql.Append("AccountNumberCodeTime=@AccountNumberCodeTime,");
            strSql.Append("EmailCodeCount=@EmailCodeCount,");
            strSql.Append("AccountNumberCodeCount=@AccountNumberCodeCount");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@RealName", SqlDbType.NVarChar,20),
					new SqlParameter("@TradePwd", SqlDbType.NVarChar,50),
					new SqlParameter("@CardID", SqlDbType.VarChar,20),
					new SqlParameter("@Province", SqlDbType.NVarChar,20),
					new SqlParameter("@City", SqlDbType.NVarChar,20),
					new SqlParameter("@PostCode", SqlDbType.VarChar,20),
					new SqlParameter("@Address", SqlDbType.NVarChar,255),
					new SqlParameter("@Telphone", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@MSN", SqlDbType.VarChar,20),
					new SqlParameter("@Birthday", SqlDbType.SmallDateTime),
					new SqlParameter("@Sex", SqlDbType.Bit,1),
					new SqlParameter("@BankName", SqlDbType.NVarChar,20),
					new SqlParameter("@BankInfo", SqlDbType.NVarChar,50),
					new SqlParameter("@AccountNumber", SqlDbType.VarChar,50),
					new SqlParameter("@CurrentMoney", SqlDbType.Money,8),
					new SqlParameter("@FrozenMoney", SqlDbType.Money,8),
					new SqlParameter("@LastTrade_time", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.TinyInt,1),
					new SqlParameter("@CreatTime", SqlDbType.DateTime),
					new SqlParameter("@OperateTime", SqlDbType.DateTime),
					new SqlParameter("@OperateManager", SqlDbType.NVarChar,20),
					new SqlParameter("@OperateResult", SqlDbType.NVarChar,128),
					new SqlParameter("@Remark", SqlDbType.NVarChar,255),
					new SqlParameter("@EmailState", SqlDbType.SmallInt,2),
					new SqlParameter("@AccountNumberState", SqlDbType.SmallInt,2),
					new SqlParameter("@EmailCode", SqlDbType.VarChar,50),
					new SqlParameter("@AccountNumberCode", SqlDbType.VarChar,20),
					new SqlParameter("@EmailCodeTime", SqlDbType.SmallDateTime),
					new SqlParameter("@AccountNumberCodeTime", SqlDbType.SmallDateTime),
					new SqlParameter("@EmailCodeCount", SqlDbType.Int,4),
					new SqlParameter("@AccountNumberCodeCount", SqlDbType.Int,4)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.RealName;
            parameters[3].Value = model.TradePwd;
            parameters[4].Value = model.CardID;
            parameters[5].Value = model.Province;
            parameters[6].Value = model.City;
            parameters[7].Value = model.PostCode;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.Telphone;
            parameters[10].Value = model.Mobile;
            parameters[11].Value = model.Email;
            parameters[12].Value = model.QQ;
            parameters[13].Value = model.MSN;
            parameters[14].Value = model.Birthday;
            parameters[15].Value = model.Sex;
            parameters[16].Value = model.BankName;
            parameters[17].Value = model.BankInfo;
            parameters[18].Value = model.AccountNumber;
            parameters[19].Value = model.CurrentMoney;
            parameters[20].Value = model.FrozenMoney;
            parameters[21].Value = model.LastTrade_time;
            parameters[22].Value = model.State;
            parameters[23].Value = model.CreatTime;
            parameters[24].Value = model.OperateTime;
            parameters[25].Value = model.OperateManager;
            parameters[26].Value = model.OperateResult;
            parameters[27].Value = model.Remark;
            parameters[28].Value = model.EmailState;
            parameters[29].Value = model.AccountNumberState;
            parameters[30].Value = model.EmailCode;
            parameters[31].Value = model.AccountNumberCode;
            parameters[32].Value = model.EmailCodeTime;
            parameters[33].Value = model.AccountNumberCodeTime;
            parameters[34].Value = model.EmailCodeCount;
            parameters[35].Value = model.AccountNumberCodeCount;

           return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_UserTable ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

           return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UserTable GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserName,RealName,TradePwd,CardID,Province,City,PostCode,Address,Telphone,Mobile,Email,QQ,MSN,Birthday,Sex,BankName,BankInfo,AccountNumber,CurrentMoney,FrozenMoney,LastTrade_time,State,CreatTime,OperateTime,OperateManager,OperateResult,Remark,EmailState,AccountNumberState,EmailCode,AccountNumberCode,EmailCodeTime,AccountNumberCodeTime,EmailCodeCount,AccountNumberCodeCount from PBnet_UserTable ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Pbzx.Model.PBnet_UserTable model = new Pbzx.Model.PBnet_UserTable();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.TradePwd = ds.Tables[0].Rows[0]["TradePwd"].ToString();
                model.CardID = ds.Tables[0].Rows[0]["CardID"].ToString();
                model.Province = ds.Tables[0].Rows[0]["Province"].ToString();
                model.City = ds.Tables[0].Rows[0]["City"].ToString();
                model.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Telphone = ds.Tables[0].Rows[0]["Telphone"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                model.MSN = ds.Tables[0].Rows[0]["MSN"].ToString();
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Sex"].ToString() == "1") || (ds.Tables[0].Rows[0]["Sex"].ToString().ToLower() == "true"))
                    {
                        model.Sex = true;
                    }
                    else
                    {
                        model.Sex = false;
                    }
                }
                model.BankName = ds.Tables[0].Rows[0]["BankName"].ToString();
                model.BankInfo = ds.Tables[0].Rows[0]["BankInfo"].ToString();
                model.AccountNumber = ds.Tables[0].Rows[0]["AccountNumber"].ToString();
                if (ds.Tables[0].Rows[0]["CurrentMoney"].ToString() != "")
                {
                    model.CurrentMoney = decimal.Parse(ds.Tables[0].Rows[0]["CurrentMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FrozenMoney"].ToString() != "")
                {
                    model.FrozenMoney = decimal.Parse(ds.Tables[0].Rows[0]["FrozenMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastTrade_time"].ToString() != "")
                {
                    model.LastTrade_time = DateTime.Parse(ds.Tables[0].Rows[0]["LastTrade_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreatTime"].ToString() != "")
                {
                    model.CreatTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreatTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OperateTime"].ToString() != "")
                {
                    model.OperateTime = DateTime.Parse(ds.Tables[0].Rows[0]["OperateTime"].ToString());
                }
                model.OperateManager = ds.Tables[0].Rows[0]["OperateManager"].ToString();
                model.OperateResult = ds.Tables[0].Rows[0]["OperateResult"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["EmailState"].ToString() != "")
                {
                    model.EmailState = int.Parse(ds.Tables[0].Rows[0]["EmailState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AccountNumberState"].ToString() != "")
                {
                    model.AccountNumberState = int.Parse(ds.Tables[0].Rows[0]["AccountNumberState"].ToString());
                }
                model.EmailCode = ds.Tables[0].Rows[0]["EmailCode"].ToString();
                model.AccountNumberCode = ds.Tables[0].Rows[0]["AccountNumberCode"].ToString();
                if (ds.Tables[0].Rows[0]["EmailCodeTime"].ToString() != "")
                {
                    model.EmailCodeTime = DateTime.Parse(ds.Tables[0].Rows[0]["EmailCodeTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AccountNumberCodeTime"].ToString() != "")
                {
                    model.AccountNumberCodeTime = DateTime.Parse(ds.Tables[0].Rows[0]["AccountNumberCodeTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EmailCodeCount"].ToString() != "")
                {
                    model.EmailCodeCount = int.Parse(ds.Tables[0].Rows[0]["EmailCodeCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AccountNumberCodeCount"].ToString() != "")
                {
                    model.AccountNumberCodeCount = int.Parse(ds.Tables[0].Rows[0]["AccountNumberCodeCount"].ToString());
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
            strSql.Append("select Id,UserName,RealName,TradePwd,CardID,Province,City,PostCode,Address,Telphone,Mobile,Email,QQ,MSN,Birthday,Sex,BankName,BankInfo,AccountNumber,CurrentMoney,FrozenMoney,LastTrade_time,State,CreatTime,OperateTime,OperateManager,OperateResult,Remark,EmailState,AccountNumberState,EmailCode,AccountNumberCode,EmailCodeTime,AccountNumberCodeTime,EmailCodeCount,AccountNumberCodeCount ");
            strSql.Append(" FROM PBnet_UserTable ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,UserName,RealName,TradePwd,CardID,Province,City,PostCode,Address,Telphone,Mobile,Email,QQ,MSN,Birthday,Sex,BankName,BankInfo,AccountNumber,CurrentMoney,FrozenMoney,LastTrade_time,State,CreatTime,OperateTime,OperateManager,OperateResult,Remark,EmailState,AccountNumberState,EmailCode,AccountNumberCode,EmailCodeTime,AccountNumberCodeTime,EmailCodeCount,AccountNumberCodeCount ");
            strSql.Append(" FROM PBnet_UserTable ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            parameters[0].Value = "PBnet_UserTable";
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

