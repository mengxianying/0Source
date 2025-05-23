using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_ask_Reply。
    /// </summary>
    public class PBnet_ask_Reply : IPBnet_ask_Reply
    {
        public PBnet_ask_Reply()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_ask_Reply");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_ask_Reply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_ask_Reply(");
            strSql.Append("QuestionId,Content,Replyer,ReplyTime,IsBest,ReferenceBook,Comment,GoodComment,BadComment,AttachId,ReplyerId,Deleted,Auditing)");
            strSql.Append(" values (");
            strSql.Append("@QuestionId,@Content,@Replyer,@ReplyTime,@IsBest,@ReferenceBook,@Comment,@GoodComment,@BadComment,@AttachId,@ReplyerId,@Deleted,@Auditing)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@QuestionId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Replyer", SqlDbType.NVarChar,50),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime),
					new SqlParameter("@IsBest", SqlDbType.Bit,1),
					new SqlParameter("@ReferenceBook", SqlDbType.NVarChar,1000),
					new SqlParameter("@Comment", SqlDbType.NText),
					new SqlParameter("@GoodComment", SqlDbType.Int,4),
					new SqlParameter("@BadComment", SqlDbType.Int,4),
					new SqlParameter("@AttachId", SqlDbType.Int,4),
					new SqlParameter("@ReplyerId", SqlDbType.Int,4),
					new SqlParameter("@Deleted", SqlDbType.Bit,1),
                    new SqlParameter("@Auditing",SqlDbType.Bit,1)};
            parameters[0].Value = model.QuestionId;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.Replyer;
            parameters[3].Value = model.ReplyTime;
            parameters[4].Value = model.IsBest;
            parameters[5].Value = model.ReferenceBook;
            parameters[6].Value = model.Comment;
            parameters[7].Value = model.GoodComment;
            parameters[8].Value = model.BadComment;
            parameters[9].Value = model.AttachId;
            parameters[10].Value = model.ReplyerId;
            parameters[11].Value = model.Deleted;
            parameters[12].Value = model.Auditing;

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
        public int Update(Pbzx.Model.PBnet_ask_Reply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_ask_Reply set ");
            strSql.Append("Content=@Content,");
            strSql.Append("Replyer=@Replyer,");
            strSql.Append("IsBest=@IsBest,");
            strSql.Append("ReferenceBook=@ReferenceBook,");
            strSql.Append("Comment=@Comment,");
            strSql.Append("GoodComment=@GoodComment,");
            strSql.Append("BadComment=@BadComment,");
            strSql.Append("AttachId=@AttachId,");
            strSql.Append("ReplyerId=@ReplyerId,");
            strSql.Append("Deleted=@Deleted,");
            strSql.Append("Auditing=@Auditing");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@QuestionId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Replyer", SqlDbType.NVarChar,50),
					new SqlParameter("@ReplyTime", SqlDbType.DateTime),
					new SqlParameter("@IsBest", SqlDbType.Bit,1),
					new SqlParameter("@ReferenceBook", SqlDbType.NVarChar,1000),
					new SqlParameter("@Comment", SqlDbType.NText),
					new SqlParameter("@GoodComment", SqlDbType.Int,4),
					new SqlParameter("@BadComment", SqlDbType.Int,4),
					new SqlParameter("@AttachId", SqlDbType.Int,4),
					new SqlParameter("@ReplyerId", SqlDbType.Int,4),
					new SqlParameter("@Deleted", SqlDbType.Bit,1),
                    new SqlParameter("@Auditing",SqlDbType.Bit,1) };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.QuestionId;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Replyer;
            parameters[4].Value = model.ReplyTime;
            parameters[5].Value = model.IsBest;
            parameters[6].Value = model.ReferenceBook;
            parameters[7].Value = model.Comment;
            parameters[8].Value = model.GoodComment;
            parameters[9].Value = model.BadComment;
            parameters[10].Value = model.AttachId;
            parameters[11].Value = model.ReplyerId;
            parameters[12].Value = model.Deleted;
            parameters[13].Value = model.Auditing;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_ask_Reply ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_ask_Reply GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,QuestionId,Content,Replyer,ReplyTime,IsBest,ReferenceBook,Comment,GoodComment,BadComment,AttachId,ReplyerId,Deleted,Auditing from PBnet_ask_Reply ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_ask_Reply model = new Pbzx.Model.PBnet_ask_Reply();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QuestionId"].ToString() != "")
                {
                    model.QuestionId = int.Parse(ds.Tables[0].Rows[0]["QuestionId"].ToString());
                }
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.Replyer = ds.Tables[0].Rows[0]["Replyer"].ToString();
                if (ds.Tables[0].Rows[0]["ReplyTime"].ToString() != "")
                {
                    model.ReplyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReplyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsBest"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsBest"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsBest"].ToString().ToLower() == "true"))
                    {
                        model.IsBest = true;
                    }
                    else
                    {
                        model.IsBest = false;
                    }
                }
                model.ReferenceBook = ds.Tables[0].Rows[0]["ReferenceBook"].ToString();
                model.Comment = ds.Tables[0].Rows[0]["Comment"].ToString();
                if (ds.Tables[0].Rows[0]["GoodComment"].ToString() != "")
                {
                    model.GoodComment = int.Parse(ds.Tables[0].Rows[0]["GoodComment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BadComment"].ToString() != "")
                {
                    model.BadComment = int.Parse(ds.Tables[0].Rows[0]["BadComment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AttachId"].ToString() != "")
                {
                    model.AttachId = int.Parse(ds.Tables[0].Rows[0]["AttachId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReplyerId"].ToString() != "")
                {
                    model.ReplyerId = int.Parse(ds.Tables[0].Rows[0]["ReplyerId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Deleted"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Deleted"].ToString() == "1") || (ds.Tables[0].Rows[0]["Deleted"].ToString().ToLower() == "true"))
                    {
                        model.Deleted = true;
                    }
                    else
                    {
                        model.Deleted = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["Auditing"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Auditing"].ToString() == "1") || (ds.Tables[0].Rows[0]["Auditing"].ToString().ToLower() == "true"))
                    {
                        model.Auditing = true;
                    }
                    else
                    {
                        model.Auditing = false;
                    }
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
            strSql.Append("select ID,QuestionId,Content,Replyer,ReplyTime,IsBest,ReferenceBook,Comment,GoodComment,BadComment,AttachId,ReplyerId,Deleted,Auditing ");
            strSql.Append(" FROM PBnet_ask_Reply ");
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
            strSql.Append(" ID,QuestionId,Content,Replyer,ReplyTime,IsBest,ReferenceBook,Comment,GoodComment,BadComment,AttachId,ReplyerId,Deleted,Auditing ");
            strSql.Append(" FROM PBnet_ask_Reply ");
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
            parameters[0].Value = "PBnet_ask_Reply";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
        public int ExecuteBySql(string sql)
        {
            return DbHelperSQL.ExecuteSql(sql);
        }
    }
}

