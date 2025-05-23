using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_ask_Question。
    /// </summary>
    public class PBnet_ask_Question : IPBnet_ask_Question
    {
        public PBnet_ask_Question()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_ask_Question");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_ask_Question model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_ask_Question(");
            strSql.Append("Title,Content,Relay,Asker,AskTime,OverTime,UpdateTime,Views,TypeName,TypeID,FTypeID,State,Answerer,LargessPoint,IsCommend,IsAnonymous,AttachId,Replys,AskerId,AnswererId,BitIsHot,Deleted,Auditing)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Content,@Relay,@Asker,@AskTime,@OverTime,@UpdateTime,@Views,@TypeName,@TypeID,@FTypeID,@State,@Answerer,@LargessPoint,@IsCommend,@IsAnonymous,@AttachId,@Replys,@AskerId,@AnswererId,@BitIsHot,@Deleted,@Auditing)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Relay", SqlDbType.NText),
					new SqlParameter("@Asker", SqlDbType.NVarChar,50),
					new SqlParameter("@AskTime", SqlDbType.DateTime),
					new SqlParameter("@OverTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@FTypeID", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.TinyInt,1),
					new SqlParameter("@Answerer", SqlDbType.NVarChar,50),
					new SqlParameter("@LargessPoint", SqlDbType.Int,4),
					new SqlParameter("@IsCommend", SqlDbType.Bit,1),
					new SqlParameter("@IsAnonymous", SqlDbType.Bit,1),
					new SqlParameter("@AttachId", SqlDbType.Int,4),
					new SqlParameter("@Replys", SqlDbType.Int,4),
					new SqlParameter("@AskerId", SqlDbType.Int,4),
					new SqlParameter("@AnswererId", SqlDbType.Int,4),
					new SqlParameter("@BitIsHot", SqlDbType.Bit,1),
					new SqlParameter("@Deleted", SqlDbType.Bit,1),
                    new SqlParameter("@Auditing",SqlDbType.Bit,1)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.Relay;
            parameters[3].Value = model.Asker;
            parameters[4].Value = model.AskTime;
            parameters[5].Value = model.OverTime;
            parameters[6].Value = model.UpdateTime;
            parameters[7].Value = model.Views;
            parameters[8].Value = model.TypeName;
            parameters[9].Value = model.TypeID;
            parameters[10].Value = model.FTypeID;
            parameters[11].Value = model.State;
            parameters[12].Value = model.Answerer;
            parameters[13].Value = model.LargessPoint;
            parameters[14].Value = model.IsCommend;
            parameters[15].Value = model.IsAnonymous;
            parameters[16].Value = model.AttachId;
            parameters[17].Value = model.Replys;
            parameters[18].Value = model.AskerId;
            parameters[19].Value = model.AnswererId;
            parameters[20].Value = model.BitIsHot;
            parameters[21].Value = model.Deleted;
            parameters[22].Value = model.Auditing;

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
        public int Update(Pbzx.Model.PBnet_ask_Question model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_ask_Question set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Content=@Content,");
            strSql.Append("Relay=@Relay,");
            strSql.Append("Asker=@Asker,");

            strSql.Append("AskTime=@AskTime,");
            strSql.Append("UpdateTime=@UpdateTime,");

            strSql.Append("OverTime=@OverTime,");
            strSql.Append("Views=@Views,");
            strSql.Append("TypeName=@TypeName,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("FTypeID=@FTypeID,");
            strSql.Append("State=@State,");
            strSql.Append("Answerer=@Answerer,");
            strSql.Append("LargessPoint=@LargessPoint,");
            strSql.Append("IsCommend=@IsCommend,");
            strSql.Append("IsAnonymous=@IsAnonymous,");
            strSql.Append("AttachId=@AttachId,");
            strSql.Append("Replys=@Replys,");
            strSql.Append("AskerId=@AskerId,");
            strSql.Append("AnswererId=@AnswererId,");
            strSql.Append("BitIsHot=@BitIsHot,");
            strSql.Append("Deleted=@Deleted,");
            strSql.Append("Auditing=@Auditing");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@Relay", SqlDbType.NText),
					new SqlParameter("@Asker", SqlDbType.NVarChar,50),
					new SqlParameter("@AskTime", SqlDbType.DateTime),
					new SqlParameter("@OverTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Views", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@FTypeID", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.TinyInt,1),
					new SqlParameter("@Answerer", SqlDbType.NVarChar,50),
					new SqlParameter("@LargessPoint", SqlDbType.Int,4),
					new SqlParameter("@IsCommend", SqlDbType.Bit,1),
					new SqlParameter("@IsAnonymous", SqlDbType.Bit,1),
					new SqlParameter("@AttachId", SqlDbType.Int,4),
					new SqlParameter("@Replys", SqlDbType.Int,4),
					new SqlParameter("@AskerId", SqlDbType.Int,4),
					new SqlParameter("@AnswererId", SqlDbType.Int,4),
					new SqlParameter("@BitIsHot", SqlDbType.Bit,1),
					new SqlParameter("@Deleted", SqlDbType.Bit,1),
                     new SqlParameter("@Auditing",SqlDbType.Bit,1) };
            parameters[0].Value = model.Id;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.Relay;
            parameters[4].Value = model.Asker;
            parameters[5].Value = model.AskTime;
            parameters[6].Value = model.OverTime;
            parameters[7].Value = model.UpdateTime;
            parameters[8].Value = model.Views;
            parameters[9].Value = model.TypeName;
            parameters[10].Value = model.TypeID;
            parameters[11].Value = model.FTypeID;
            parameters[12].Value = model.State;
            parameters[13].Value = model.Answerer;
            parameters[14].Value = model.LargessPoint;
            parameters[15].Value = model.IsCommend;
            parameters[16].Value = model.IsAnonymous;
            parameters[17].Value = model.AttachId;
            parameters[18].Value = model.Replys;
            parameters[19].Value = model.AskerId;
            parameters[20].Value = model.AnswererId;
            parameters[21].Value = model.BitIsHot;
            parameters[22].Value = model.Deleted;
            parameters[23].Value = model.Auditing;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_ask_Question ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_ask_Question GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Title,Content,Relay,Asker,AskTime,OverTime,UpdateTime,Views,TypeName,TypeID,FTypeID,State,Answerer,LargessPoint,IsCommend,IsAnonymous,AttachId,Replys,AskerId,AnswererId,BitIsHot,Deleted,Auditing from PBnet_ask_Question ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Pbzx.Model.PBnet_ask_Question model = new Pbzx.Model.PBnet_ask_Question();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.Relay = ds.Tables[0].Rows[0]["Relay"].ToString();
                model.Asker = ds.Tables[0].Rows[0]["Asker"].ToString();
                if (ds.Tables[0].Rows[0]["AskTime"].ToString() != "")
                {
                    model.AskTime = DateTime.Parse(ds.Tables[0].Rows[0]["AskTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OverTime"].ToString() != "")
                {
                    model.OverTime = DateTime.Parse(ds.Tables[0].Rows[0]["OverTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Views"].ToString() != "")
                {
                    model.Views = int.Parse(ds.Tables[0].Rows[0]["Views"].ToString());
                }
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FTypeID"].ToString() != "")
                {
                    model.FTypeID = int.Parse(ds.Tables[0].Rows[0]["FTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                model.Answerer = ds.Tables[0].Rows[0]["Answerer"].ToString();
                if (ds.Tables[0].Rows[0]["LargessPoint"].ToString() != "")
                {
                    model.LargessPoint = int.Parse(ds.Tables[0].Rows[0]["LargessPoint"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsCommend"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsCommend"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsCommend"].ToString().ToLower() == "true"))
                    {
                        model.IsCommend = true;
                    }
                    else
                    {
                        model.IsCommend = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsAnonymous"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsAnonymous"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsAnonymous"].ToString().ToLower() == "true"))
                    {
                        model.IsAnonymous = true;
                    }
                    else
                    {
                        model.IsAnonymous = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["AttachId"].ToString() != "")
                {
                    model.AttachId = int.Parse(ds.Tables[0].Rows[0]["AttachId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Replys"].ToString() != "")
                {
                    model.Replys = int.Parse(ds.Tables[0].Rows[0]["Replys"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AskerId"].ToString() != "")
                {
                    model.AskerId = int.Parse(ds.Tables[0].Rows[0]["AskerId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AnswererId"].ToString() != "")
                {
                    model.AnswererId = int.Parse(ds.Tables[0].Rows[0]["AnswererId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BitIsHot"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BitIsHot"].ToString() == "1") || (ds.Tables[0].Rows[0]["BitIsHot"].ToString().ToLower() == "true"))
                    {
                        model.BitIsHot = true;
                    }
                    else
                    {
                        model.BitIsHot = false;
                    }
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
            strSql.Append("select Id,Title,Content,Relay,Asker,AskTime,OverTime,UpdateTime,Views,TypeName,TypeID,FTypeID,State,Answerer,LargessPoint,IsCommend,IsAnonymous,AttachId,Replys,AskerId,AnswererId,BitIsHot,Deleted,Auditing ");
            strSql.Append(" FROM PBnet_ask_Question ");
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
            strSql.Append(" Id,Title,Content,Relay,Asker,AskTime,OverTime,UpdateTime,Views,TypeName,TypeID,FTypeID,State,Answerer,LargessPoint,IsCommend,IsAnonymous,AttachId,Replys,AskerId,AnswererId,BitIsHot,Deleted,Auditing ");
            strSql.Append(" FROM PBnet_ask_Question ");
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
            parameters[0].Value = "PBnet_ask_Question";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        /// <summary>
        /// 根据类别编号得到问题数量
        /// </summary>
        /// <param name="typeId">类别id</param>
        /// <returns>问题数量</returns>
        /// author:meng
        /// date:09-08-17
        public object GetCountByTypeId(string typeId)
        {
            return DbHelperSQL.GetSingle("select count(1) from PBnet_ask_Question where TypeID=" + typeId + " ");
        }
        public int ExecuteBySql(string sql)
        {
            return DbHelperSQL.ExecuteSql(sql);
        }

    }
}

