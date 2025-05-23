using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.Model;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 添加项目信息数据访问类
    /// 创建人： 杨良伟
    /// 2010-10-25
    /// </summary>
    public class Market_ApplicationItemService : IMarket_ApplicationItem
    {

        PBnet_LotteryMenu lotteryMenu = new PBnet_LotteryMenu();
        PBnet_UserTable usertable = new PBnet_UserTable();
        #region IMarket_ApplicationItem 成员
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Market_ApplicationItem");
            strSql.Append(" where Id= @Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Market_ApplicationItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Market_ApplicationItem(");
            strSql.Append("AppLotteryID,ItemName,AppUserId,ItemViscera,ApplicationTime,FettleNumber,Gloze,ReplyTime,State)");
            strSql.Append(" values (");
            strSql.Append("@AppLotteryID,@ItemName,@AppUserId,@ItemViscera,@ApplicationTime,@FettleNumber,@Gloze,@ReplyTime,@State)");
            SqlParameter[] parameters = {
					new SqlParameter("@AppLotteryID", SqlDbType.Int,4),
					new SqlParameter("@ItemName", SqlDbType.NVarChar),
					new SqlParameter("@AppUserId", SqlDbType.Int,4),
					new SqlParameter("@ItemViscera", SqlDbType.NVarChar),
					new SqlParameter("@ApplicationTime", SqlDbType.DateTime),
					new SqlParameter("@FettleNumber", SqlDbType.Int,4),
					new SqlParameter("@Gloze", SqlDbType.NVarChar),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4)};
            parameters[0].Value = model.Applotteryid.IntId;
            parameters[1].Value = model.Itemname;
            parameters[2].Value = model.Appuserid.Id;
            parameters[3].Value = model.Itemviscera;
            parameters[4].Value = model.Applicationtime;
            parameters[5].Value = model.Fettlenumber;
            parameters[6].Value = model.Gloze;
            parameters[7].Value = model.Replytime;
            parameters[8].Value = model.State;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Market_ApplicationItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Market_ApplicationItem set ");
            strSql.Append("AppLotteryID=@AppLotteryID,");
            strSql.Append("ItemName=@ItemName,");
            strSql.Append("AppUserId=@AppUserId,");
            strSql.Append("ItemViscera=@ItemViscera,");
            strSql.Append("ApplicationTime=@ApplicationTime,");
            strSql.Append("FettleNumber=@FettleNumber,");
            strSql.Append("Gloze=@Gloze,");
            strSql.Append("ReplyTime=@ReplyTime,");
            strSql.Append("State=@State");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@AppLotteryID", SqlDbType.Int,4),
					new SqlParameter("@ItemName", SqlDbType.NVarChar),
					new SqlParameter("@AppUserId", SqlDbType.Int,4),
					new SqlParameter("@ItemViscera", SqlDbType.NVarChar),
					new SqlParameter("@ApplicationTime", SqlDbType.DateTime),
					new SqlParameter("@FettleNumber", SqlDbType.Int,4),
					new SqlParameter("@Gloze", SqlDbType.NVarChar),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Applotteryid.IntId;
            parameters[2].Value = model.Itemname;
            parameters[3].Value = model.Appuserid.Id;
            parameters[4].Value = model.Itemviscera;
            parameters[5].Value = model.Applicationtime;
            parameters[6].Value = model.Fettlenumber;
            parameters[7].Value = model.Gloze;
            parameters[8].Value = model.Replytime;
            parameters[9].Value = model.State;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Market_ApplicationItem ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Market_ApplicationItem GetMain(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Market_ApplicationItem ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            Market_ApplicationItem model = new Market_ApplicationItem();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.Id = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AppLotteryID"].ToString() != "")
                {
                    model.Applotteryid =lotteryMenu.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["AppLotteryID"]));
                }
                model.Itemname = ds.Tables[0].Rows[0]["ItemName"].ToString();
                if (ds.Tables[0].Rows[0]["AppUserId"].ToString() != "")
                {
                    model.Appuserid = usertable.GetModel(Convert.ToInt32(ds.Tables[0].Rows[0]["AppUserId"]));
                }
                model.Itemviscera = ds.Tables[0].Rows[0]["ItemViscera"].ToString();
                if (ds.Tables[0].Rows[0]["ApplicationTime"].ToString() != "")
                {
                    model.Applicationtime = DateTime.Parse(ds.Tables[0].Rows[0]["ApplicationTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FettleNumber"].ToString() != "")
                {
                    model.Fettlenumber = int.Parse(ds.Tables[0].Rows[0]["FettleNumber"].ToString());
                }
                model.Gloze = ds.Tables[0].Rows[0]["Gloze"].ToString();
                if (ds.Tables[0].Rows[0]["ReplyTime"].ToString() != "")
                {
                    model.Replytime = DateTime.Parse(ds.Tables[0].Rows[0]["ReplyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
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
            strSql.Append("select * from Market_ApplicationItem ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Id ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion
    }
}
