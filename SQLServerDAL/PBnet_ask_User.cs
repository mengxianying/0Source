using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_ask_User。
    /// </summary>
    public class PBnet_ask_User : IPBnet_ask_User
    {
        public PBnet_ask_User()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_ask_User");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_ask_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_ask_User(");
            strSql.Append("UserName,Point,Pointpenalty,OtherPointpenalty,AskNum,ReplyNum,Best_ReplyNum,OpenTime,Ask_DelNum,UserGroup,State,Score)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Point,@Pointpenalty,@OtherPointpenalty,@AskNum,@ReplyNum,@Best_ReplyNum,@OpenTime,@Ask_DelNum,@UserGroup,@State,@Score)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Point", SqlDbType.Int,4),
					new SqlParameter("@Pointpenalty", SqlDbType.Int,4),
					new SqlParameter("@OtherPointpenalty", SqlDbType.Int,4),				
					new SqlParameter("@AskNum", SqlDbType.Int,4),
					new SqlParameter("@ReplyNum", SqlDbType.Int,4),
					new SqlParameter("@Best_ReplyNum", SqlDbType.Int,4),
					new SqlParameter("@OpenTime", SqlDbType.DateTime),
					new SqlParameter("@Ask_DelNum", SqlDbType.Int,4),
					new SqlParameter("@UserGroup", SqlDbType.NVarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Score", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Point;
            parameters[2].Value = model.Pointpenalty;
            parameters[3].Value = model.OtherPointpenalty;
            parameters[4].Value = model.AskNum;
            parameters[5].Value = model.ReplyNum;
            parameters[6].Value = model.Best_ReplyNum;
            parameters[7].Value = model.OpenTime;
            parameters[8].Value = model.Ask_DelNum;
            parameters[9].Value = model.UserGroup;
            parameters[10].Value = model.State;
            parameters[11].Value = model.Score;

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
        public int Update(Pbzx.Model.PBnet_ask_User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_ask_User set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Point=@Point,");
            strSql.Append("Pointpenalty=@Pointpenalty,");
            strSql.Append("OtherPointpenalty=@OtherPointpenalty,");
            strSql.Append("AskNum=@AskNum,");
            strSql.Append("ReplyNum=@ReplyNum,");
            strSql.Append("Best_ReplyNum=@Best_ReplyNum,");
            strSql.Append("OpenTime=@OpenTime,");
            strSql.Append("Ask_DelNum=@Ask_DelNum,");
            strSql.Append("UserGroup=@UserGroup,");
            strSql.Append("State=@State,");
            strSql.Append("Score=@Score");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Point", SqlDbType.Int,4),
					new SqlParameter("@Pointpenalty", SqlDbType.Int,4),
					new SqlParameter("@OtherPointpenalty", SqlDbType.Int,4),
					new SqlParameter("@AskNum", SqlDbType.Int,4),
					new SqlParameter("@ReplyNum", SqlDbType.Int,4),
					new SqlParameter("@Best_ReplyNum", SqlDbType.Int,4),
					new SqlParameter("@OpenTime", SqlDbType.DateTime),
					new SqlParameter("@Ask_DelNum", SqlDbType.Int,4),
					new SqlParameter("@UserGroup", SqlDbType.NVarChar,50),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Score", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Point;
            parameters[3].Value = model.Pointpenalty;
            parameters[4].Value = model.OtherPointpenalty;
            parameters[5].Value = model.AskNum;
            parameters[6].Value = model.ReplyNum;
            parameters[7].Value = model.Best_ReplyNum;
            parameters[8].Value = model.OpenTime;
            parameters[9].Value = model.Ask_DelNum;
            parameters[10].Value = model.UserGroup;
            parameters[11].Value = model.State;
            parameters[12].Value = model.Score;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_ask_User ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_ask_User GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,Point,Pointpenalty,OtherPointpenalty,AskNum,ReplyNum,Best_ReplyNum,OpenTime,Ask_DelNum,UserGroup,State,Score from PBnet_ask_User ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_ask_User model = new Pbzx.Model.PBnet_ask_User();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["Point"].ToString() != "")
                {
                    model.Point = int.Parse(ds.Tables[0].Rows[0]["Point"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pointpenalty"].ToString() != "")
                {
                    model.Pointpenalty = int.Parse(ds.Tables[0].Rows[0]["Pointpenalty"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OtherPointpenalty"].ToString() != "")
                {
                    model.OtherPointpenalty = int.Parse(ds.Tables[0].Rows[0]["OtherPointpenalty"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AskNum"].ToString() != "")
                {
                    model.AskNum = int.Parse(ds.Tables[0].Rows[0]["AskNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReplyNum"].ToString() != "")
                {
                    model.ReplyNum = int.Parse(ds.Tables[0].Rows[0]["ReplyNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Best_ReplyNum"].ToString() != "")
                {
                    model.Best_ReplyNum = int.Parse(ds.Tables[0].Rows[0]["Best_ReplyNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OpenTime"].ToString() != "")
                {
                    model.OpenTime = DateTime.Parse(ds.Tables[0].Rows[0]["OpenTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Ask_DelNum"].ToString() != "")
                {
                    model.Ask_DelNum = int.Parse(ds.Tables[0].Rows[0]["Ask_DelNum"].ToString());
                }
                model.UserGroup = ds.Tables[0].Rows[0]["UserGroup"].ToString();
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Score"].ToString() != "")
                {
                    model.Score = int.Parse(ds.Tables[0].Rows[0]["Score"].ToString());
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
            strSql.Append("select ID,UserName,Point,Pointpenalty,OtherPointpenalty,AskNum,ReplyNum,Best_ReplyNum,OpenTime,Ask_DelNum,UserGroup,State,Score ");
            strSql.Append(" FROM PBnet_ask_User ");
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
            strSql.Append(" ID,UserName,Point,Pointpenalty,OtherPointpenalty,AskNum,ReplyNum,Best_ReplyNum,OpenTime,Ask_DelNum,UserGroup,State,Score ");
            strSql.Append(" FROM PBnet_ask_User ");
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
            parameters[0].Value = "PBnet_ask_User";
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

