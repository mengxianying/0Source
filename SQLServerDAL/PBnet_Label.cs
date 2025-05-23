using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_Label。
    /// </summary>
    public class PBnet_Label : IPBnet_Label
    {
        public PBnet_Label()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_Label");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Label model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_Label(");
            strSql.Append("Labelid,LabelName,Content,LabelType)");
            strSql.Append(" values (");
            strSql.Append("@Labelid,@LabelName,@Content,@LabelType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Labelid", SqlDbType.Int,4),
					new SqlParameter("@LabelName", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@LabelType", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Labelid;
            parameters[1].Value = model.LabelName;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.LabelType;

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
        public void Update(Pbzx.Model.PBnet_Label model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_Label set ");
            strSql.Append("Labelid=@Labelid,");
            strSql.Append("LabelName=@LabelName,");
            strSql.Append("Content=@Content,");
            strSql.Append("LabelType=@LabelType");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@Labelid", SqlDbType.Int,4),
					new SqlParameter("@LabelName", SqlDbType.NVarChar,50),
					new SqlParameter("@Content", SqlDbType.Text),
					new SqlParameter("@LabelType", SqlDbType.VarChar,50)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.Labelid;
            parameters[2].Value = model.LabelName;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.LabelType;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_Label ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Label GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,Labelid,LabelName,Content,LabelType from PBnet_Label ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Pbzx.Model.PBnet_Label model = new Pbzx.Model.PBnet_Label();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Labelid"].ToString() != "")
                {
                    model.Labelid = int.Parse(ds.Tables[0].Rows[0]["Labelid"].ToString());
                }
                model.LabelName = ds.Tables[0].Rows[0]["LabelName"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.LabelType = ds.Tables[0].Rows[0]["LabelType"].ToString();
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
            strSql.Append("select id,Labelid,LabelName,Content,LabelType ");
            strSql.Append(" FROM PBnet_Label ");
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
            strSql.Append(" id,Labelid,LabelName,Content,LabelType ");
            strSql.Append(" FROM PBnet_Label ");
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
            parameters[0].Value = "PBnet_Label";
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

