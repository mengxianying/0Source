using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类SoftDogInfo。
    /// </summary>
    public class SoftDogInfo : ISoftDogInfo
    {
        public SoftDogInfo()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SoftDogInfo");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.SoftDogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SoftDogInfo(");
            strSql.Append("SN,CreateTime,Creater,OldSN,SellPrice,Status,Remarks,AgentID,AgentName,Seller,SellTime,PayType)");
            strSql.Append(" values (");
            strSql.Append("@SN,@CreateTime,@Creater,@OldSN,@SellPrice,@Status,@Remarks,@AgentID,@AgentName,@Seller,@SellTime,@PayType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.Char,9),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Creater", SqlDbType.NVarChar,20),
					new SqlParameter("@OldSN", SqlDbType.NVarChar,9),
					new SqlParameter("@SellPrice", SqlDbType.SmallInt,2),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,128),
					new SqlParameter("@AgentID", SqlDbType.Int,4),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,20),
					new SqlParameter("@Seller", SqlDbType.NVarChar,20),
					new SqlParameter("@SellTime", SqlDbType.DateTime),
					new SqlParameter("@PayType", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.SN;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.Creater;
            parameters[3].Value = model.OldSN;
            parameters[4].Value = model.SellPrice;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.Remarks;
            parameters[7].Value = model.AgentID;
            parameters[8].Value = model.AgentName;
            parameters[9].Value = model.Seller;
            parameters[10].Value = model.SellTime;
            parameters[11].Value = model.PayType;

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
        public int Update(Pbzx.Model.SoftDogInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SoftDogInfo set ");
            strSql.Append("SN=@SN,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Creater=@Creater,");
            strSql.Append("OldSN=@OldSN,");
            strSql.Append("SellPrice=@SellPrice,");
            strSql.Append("Status=@Status,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("AgentID=@AgentID,");
            strSql.Append("AgentName=@AgentName,");
            strSql.Append("Seller=@Seller,");
            strSql.Append("SellTime=@SellTime,");
            strSql.Append("PayType=@PayType");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SN", SqlDbType.Char,9),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Creater", SqlDbType.NVarChar,20),
					new SqlParameter("@OldSN", SqlDbType.NVarChar,9),
					new SqlParameter("@SellPrice", SqlDbType.SmallInt,2),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,128),
					new SqlParameter("@AgentID", SqlDbType.Int,4),
					new SqlParameter("@AgentName", SqlDbType.NVarChar,20),
					new SqlParameter("@Seller", SqlDbType.NVarChar,20),
					new SqlParameter("@SellTime", SqlDbType.DateTime),
					new SqlParameter("@PayType", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SN;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.Creater;
            parameters[4].Value = model.OldSN;
            parameters[5].Value = model.SellPrice;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.Remarks;
            parameters[8].Value = model.AgentID;
            parameters[9].Value = model.AgentName;
            parameters[10].Value = model.Seller;
            parameters[11].Value = model.SellTime;
            parameters[12].Value = model.PayType;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SoftDogInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

          return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.SoftDogInfo GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SN,CreateTime,Creater,OldSN,SellPrice,Status,Remarks,AgentID,AgentName,Seller,SellTime,PayType from SoftDogInfo ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.SoftDogInfo model = new Pbzx.Model.SoftDogInfo();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.SN = ds.Tables[0].Rows[0]["SN"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                model.Creater = ds.Tables[0].Rows[0]["Creater"].ToString();
                model.OldSN = ds.Tables[0].Rows[0]["OldSN"].ToString();
                if (ds.Tables[0].Rows[0]["SellPrice"].ToString() != "")
                {
                    model.SellPrice = int.Parse(ds.Tables[0].Rows[0]["SellPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                if (ds.Tables[0].Rows[0]["AgentID"].ToString() != "")
                {
                    model.AgentID = int.Parse(ds.Tables[0].Rows[0]["AgentID"].ToString());
                }
                model.AgentName = ds.Tables[0].Rows[0]["AgentName"].ToString();
                model.Seller = ds.Tables[0].Rows[0]["Seller"].ToString();
                if (ds.Tables[0].Rows[0]["SellTime"].ToString() != "")
                {
                    model.SellTime = DateTime.Parse(ds.Tables[0].Rows[0]["SellTime"].ToString());
                }
                model.PayType = ds.Tables[0].Rows[0]["PayType"].ToString();
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
            strSql.Append("select ID,SN,CreateTime,Creater,OldSN,SellPrice,Status,Remarks,AgentID,AgentName,Seller,SellTime,PayType ");
            strSql.Append(" FROM SoftDogInfo ");
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
            parameters[0].Value = "SoftDogInfo";
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

