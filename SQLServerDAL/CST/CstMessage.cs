using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CstMessage。
    /// </summary>
    public class CstMessage : ICstMessage
    {
        public CstMessage()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CstMessage");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CstMessage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CstMessage(");
            strSql.Append("MsgSender,MsgLevel,MsgType,MsgCategory,MsgSend,MsgTitle,MsgTime,MsgContent,MsgST,MsgPV,MsgIT,LoginCount,TotalCount,LLTime,PostTime1,PostTime2,UserID)");
            strSql.Append(" values (");
            strSql.Append("@MsgSender,@MsgLevel,@MsgType,@MsgCategory,@MsgSend,@MsgTitle,@MsgTime,@MsgContent,@MsgST,@MsgPV,@MsgIT,@LoginCount,@TotalCount,@LLTime,@PostTime1,@PostTime2,@UserID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MsgSender", SqlDbType.VarChar,50),
					new SqlParameter("@MsgLevel", SqlDbType.Int,4),
					new SqlParameter("@MsgType", SqlDbType.Int,4),
					new SqlParameter("@MsgCategory", SqlDbType.VarChar,128),
					new SqlParameter("@MsgSend", SqlDbType.Bit,1),
					new SqlParameter("@MsgTitle", SqlDbType.VarChar,200),
					new SqlParameter("@MsgTime", SqlDbType.DateTime),
					new SqlParameter("@MsgContent", SqlDbType.NText),
					new SqlParameter("@MsgST", SqlDbType.TinyInt,1),
					new SqlParameter("@MsgPV", SqlDbType.Char,10),
					new SqlParameter("@MsgIT", SqlDbType.TinyInt,1),
					new SqlParameter("@LoginCount", SqlDbType.SmallInt,2),
					new SqlParameter("@TotalCount", SqlDbType.Int,4),
					new SqlParameter("@LLTime", SqlDbType.SmallDateTime),
					new SqlParameter("@PostTime1", SqlDbType.SmallDateTime),
					new SqlParameter("@PostTime2", SqlDbType.SmallDateTime),
					new SqlParameter("@UserID", SqlDbType.NText)};
            parameters[0].Value = model.MsgSender;
            parameters[1].Value = model.MsgLevel;
            parameters[2].Value = model.MsgType;
            parameters[3].Value = model.MsgCategory;
            parameters[4].Value = model.MsgSend;
            parameters[5].Value = model.MsgTitle;
            parameters[6].Value = model.MsgTime;
            parameters[7].Value = model.MsgContent;
            parameters[8].Value = model.MsgST;
            parameters[9].Value = model.MsgPV;
            parameters[10].Value = model.MsgIT;
            parameters[11].Value = model.LoginCount;
            parameters[12].Value = model.TotalCount;
            parameters[13].Value = model.LLTime;
            parameters[14].Value = model.PostTime1;
            parameters[15].Value = model.PostTime2;
            parameters[16].Value = model.UserID;

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
        public int Update(Pbzx.Model.CstMessage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CstMessage set ");
            strSql.Append("MsgSender=@MsgSender,");
            strSql.Append("MsgLevel=@MsgLevel,");
            strSql.Append("MsgType=@MsgType,");
            strSql.Append("MsgCategory=@MsgCategory,");
            strSql.Append("MsgSend=@MsgSend,");            
            strSql.Append("MsgTitle=@MsgTitle,");
            strSql.Append("MsgTime=@MsgTime,");
            strSql.Append("MsgContent=@MsgContent,");
            strSql.Append("MsgST=@MsgST,");
            strSql.Append("MsgPV=@MsgPV,");
            strSql.Append("MsgIT=@MsgIT,");
            strSql.Append("LoginCount=@LoginCount,");
            strSql.Append("TotalCount=@TotalCount,");
            strSql.Append("LLTime=@LLTime,");
            strSql.Append("PostTime1=@PostTime1,");
            strSql.Append("PostTime2=@PostTime2,");
            strSql.Append("UserID=@UserID");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MsgSender", SqlDbType.VarChar,50),
					new SqlParameter("@MsgLevel", SqlDbType.Int,4),
					new SqlParameter("@MsgType", SqlDbType.Int,4),
					new SqlParameter("@MsgCategory", SqlDbType.VarChar,128),
					new SqlParameter("@MsgSend", SqlDbType.Bit,1),
					new SqlParameter("@MsgTitle", SqlDbType.VarChar,200),
					new SqlParameter("@MsgTime", SqlDbType.DateTime),
					new SqlParameter("@MsgContent", SqlDbType.NText),
					new SqlParameter("@MsgST", SqlDbType.TinyInt,1),
					new SqlParameter("@MsgPV", SqlDbType.Char,10),
					new SqlParameter("@MsgIT", SqlDbType.TinyInt,1),
					new SqlParameter("@LoginCount", SqlDbType.SmallInt,2),
					new SqlParameter("@TotalCount", SqlDbType.Int,4),
					new SqlParameter("@LLTime", SqlDbType.SmallDateTime),
					new SqlParameter("@PostTime1", SqlDbType.SmallDateTime),
					new SqlParameter("@PostTime2", SqlDbType.SmallDateTime),
					new SqlParameter("@UserID", SqlDbType.NText)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.MsgSender;
            parameters[2].Value = model.MsgLevel;
            parameters[3].Value = model.MsgType;
            parameters[4].Value = model.MsgCategory;
            parameters[5].Value = model.MsgSend;
            parameters[6].Value = model.MsgTitle;
            parameters[7].Value = model.MsgTime;
            parameters[8].Value = model.MsgContent;
            parameters[9].Value = model.MsgST;
            parameters[10].Value = model.MsgPV;
            parameters[11].Value = model.MsgIT;
            parameters[12].Value = model.LoginCount;
            parameters[13].Value = model.TotalCount;
            parameters[14].Value = model.LLTime;
            parameters[15].Value = model.PostTime1;
            parameters[16].Value = model.PostTime2;
            parameters[17].Value = model.UserID;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CstMessage ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CstMessage GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,MsgSender,MsgLevel,MsgType,MsgCategory,MsgSend,MsgTitle,MsgTime,MsgContent,MsgST,MsgPV,MsgIT,LoginCount,TotalCount,LLTime,PostTime1,PostTime2,UserID from CstMessage ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.CstMessage model = new Pbzx.Model.CstMessage();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.MsgSender = ds.Tables[0].Rows[0]["MsgSender"].ToString();
                if (ds.Tables[0].Rows[0]["MsgLevel"].ToString() != "")
                {
                    model.MsgLevel = int.Parse(ds.Tables[0].Rows[0]["MsgLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MsgType"].ToString() != "")
                {
                    model.MsgType = int.Parse(ds.Tables[0].Rows[0]["MsgType"].ToString());
                }
                model.MsgCategory = ds.Tables[0].Rows[0]["MsgCategory"].ToString();
                if (ds.Tables[0].Rows[0]["MsgSend"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["MsgSend"].ToString() == "1") || (ds.Tables[0].Rows[0]["MsgSend"].ToString().ToLower() == "true"))
                    {
                        model.MsgSend = true;
                    }
                    else
                    {
                        model.MsgSend = false;
                    }
                }
                model.MsgTitle = ds.Tables[0].Rows[0]["MsgTitle"].ToString();
                if (ds.Tables[0].Rows[0]["MsgTime"].ToString() != "")
                {
                    model.MsgTime = DateTime.Parse(ds.Tables[0].Rows[0]["MsgTime"].ToString());
                }
                model.MsgContent = ds.Tables[0].Rows[0]["MsgContent"].ToString();
                if (ds.Tables[0].Rows[0]["MsgST"].ToString() != "")
                {
                    model.MsgST = int.Parse(ds.Tables[0].Rows[0]["MsgST"].ToString());
                }
                model.MsgPV = ds.Tables[0].Rows[0]["MsgPV"].ToString();
                if (ds.Tables[0].Rows[0]["MsgIT"].ToString() != "")
                {
                    model.MsgIT = int.Parse(ds.Tables[0].Rows[0]["MsgIT"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoginCount"].ToString() != "")
                {
                    model.LoginCount = int.Parse(ds.Tables[0].Rows[0]["LoginCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalCount"].ToString() != "")
                {
                    model.TotalCount = int.Parse(ds.Tables[0].Rows[0]["TotalCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LLTime"].ToString() != "")
                {
                    model.LLTime = DateTime.Parse(ds.Tables[0].Rows[0]["LLTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PostTime1"].ToString() != "")
                {
                    model.PostTime1 = DateTime.Parse(ds.Tables[0].Rows[0]["PostTime1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PostTime2"].ToString() != "")
                {
                    model.PostTime2 = DateTime.Parse(ds.Tables[0].Rows[0]["PostTime2"].ToString());
                }
                model.UserID = ds.Tables[0].Rows[0]["UserID"].ToString();
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
            strSql.Append("select ID,MsgSender,MsgLevel,MsgType,MsgCategory,MsgSend,MsgTitle,MsgTime,MsgContent,MsgST,MsgPV,MsgIT,LoginCount,TotalCount,LLTime,PostTime1,PostTime2,UserID ");
            strSql.Append(" FROM CstMessage ");
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
            parameters[0].Value = "CstMessage";
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

