using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CN_Software。
    /// </summary>
    public class CN_Software : ICN_Software
    {
        public CN_Software()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, int InstallType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CN_Software");
            strSql.Append(" where ID=@ID and InstallType=@InstallType ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@InstallType", SqlDbType.TinyInt)};
            parameters[0].Value = ID;
            parameters[1].Value = InstallType;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CN_Software model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CN_Software(");
            strSql.Append("SoftwareType,InstallType,Boards,MinTopics,MinAnncounts,Status,Flag,MinDays,MinBests,Lottery,LotteryID)");
            strSql.Append(" values (");
            strSql.Append("@SoftwareType,@InstallType,@Boards,@MinTopics,@MinAnncounts,@Status,@Flag,@MinDays,@MinBests,@Lottery,@LotteryID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@Boards", SqlDbType.NVarChar,126),
					new SqlParameter("@MinTopics", SqlDbType.NVarChar,256),
					new SqlParameter("@MinAnncounts", SqlDbType.NVarChar,256),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Flag", SqlDbType.TinyInt,1),
					new SqlParameter("@MinDays", SqlDbType.NVarChar,256),
					new SqlParameter("@MinBests", SqlDbType.NVarChar,256),
					new SqlParameter("@Lottery", SqlDbType.NVarChar,16),
					new SqlParameter("@LotteryID", SqlDbType.Int,4)};
            parameters[0].Value = model.SoftwareType;
            parameters[1].Value = model.InstallType;
            parameters[2].Value = model.Boards;
            parameters[3].Value = model.MinTopics;
            parameters[4].Value = model.MinAnncounts;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.Flag;
            parameters[7].Value = model.MinDays;
            parameters[8].Value = model.MinBests;
            parameters[9].Value = model.Lottery;
            parameters[10].Value = model.LotteryID;

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
        public int Update(Pbzx.Model.CN_Software model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CN_Software set ");
            strSql.Append("SoftwareType=@SoftwareType,");
            strSql.Append("Boards=@Boards,");
            strSql.Append("MinAnncounts=@MinAnncounts,");
            strSql.Append("Status=@Status,");
            strSql.Append("Flag=@Flag,");
            strSql.Append("MinDays=@MinDays,");

            strSql.Append("MinTopics=@MinTopics,");
            strSql.Append("MinBests=@MinBests,");
            strSql.Append("Lottery=@Lottery,");
            strSql.Append("LotteryID=@LotteryID");
            strSql.Append(" where ID=@ID and InstallType=@InstallType ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@Boards", SqlDbType.NVarChar,126),
					new SqlParameter("@MinTopics", SqlDbType.NVarChar,256),
					new SqlParameter("@MinAnncounts", SqlDbType.NVarChar,256),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Flag", SqlDbType.TinyInt,1),
					new SqlParameter("@MinDays", SqlDbType.NVarChar,256),
					new SqlParameter("@MinBests", SqlDbType.NVarChar,256),
					new SqlParameter("@Lottery", SqlDbType.NVarChar,16),
					new SqlParameter("@LotteryID", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SoftwareType;
            parameters[2].Value = model.InstallType;
            parameters[3].Value = model.Boards;
            parameters[4].Value = model.MinTopics;
            parameters[5].Value = model.MinAnncounts;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.Flag;
            parameters[8].Value = model.MinDays;
            parameters[9].Value = model.MinBests;
            parameters[10].Value = model.Lottery;
            parameters[11].Value = model.LotteryID;

           return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID, int InstallType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CN_Software ");
            strSql.Append(" where ID=@ID and InstallType=@InstallType ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@InstallType", SqlDbType.TinyInt)};
            parameters[0].Value = ID;
            parameters[1].Value = InstallType;

          return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CN_Software GetModel(int ID, int InstallType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SoftwareType,InstallType,Boards,MinTopics,MinAnncounts,Status,Flag,MinDays,MinBests,Lottery,LotteryID from CN_Software ");
            strSql.Append(" where ID=@ID and InstallType=@InstallType ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@InstallType", SqlDbType.TinyInt)};
            parameters[0].Value = ID;
            parameters[1].Value = InstallType;

            Pbzx.Model.CN_Software model = new Pbzx.Model.CN_Software();
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
                model.Boards = ds.Tables[0].Rows[0]["Boards"].ToString();
                model.MinTopics = ds.Tables[0].Rows[0]["MinTopics"].ToString();
                model.MinAnncounts = ds.Tables[0].Rows[0]["MinAnncounts"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                model.MinDays = ds.Tables[0].Rows[0]["MinDays"].ToString();
                model.MinBests = ds.Tables[0].Rows[0]["MinBests"].ToString();
                model.Lottery = ds.Tables[0].Rows[0]["Lottery"].ToString();
                if (ds.Tables[0].Rows[0]["LotteryID"].ToString() != "")
                {
                    model.LotteryID = int.Parse(ds.Tables[0].Rows[0]["LotteryID"].ToString());
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
            strSql.Append("select ID,SoftwareType,InstallType,Boards,MinTopics,MinAnncounts,Status,Flag,MinDays,MinBests,Lottery,LotteryID ");
            strSql.Append(" FROM CN_Software ");
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
            parameters[0].Value = "CN_Software";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL1.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

