using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//�����������
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// ���ݷ�����TC22X5Data��
    /// </summary>
    public class TC22X5Data : ITC22X5Data
    {
        public TC22X5Data()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL1.GetMaxID("issue", "TC22X5Data");
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int issue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TC22X5Data");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Int,4)};
            parameters[0].Value = issue;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.TC22X5Data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TC22X5Data(");
            strSql.Append("date,issue,code,LastModifytime,OpName,OpIp)");
            strSql.Append(" values (");
            strSql.Append("@date,@issue,@code,@LastModifytime,@OpName,@OpIp)");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Int,4),
					new SqlParameter("@code", SqlDbType.Char,10),
					new SqlParameter("@LastModifytime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,32),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,32)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.LastModifytime;
            parameters[4].Value = model.OpName;
            parameters[5].Value = model.OpIp;

           return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.TC22X5Data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TC22X5Data set ");
            strSql.Append("date=@date,");
            strSql.Append("code=@code,");
            strSql.Append("LastModifytime=@LastModifytime,");
            strSql.Append("OpName=@OpName,");
            strSql.Append("OpIp=@OpIp");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Int,4),
					new SqlParameter("@code", SqlDbType.Char,10),
					new SqlParameter("@LastModifytime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,32),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,32)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.LastModifytime;
            parameters[4].Value = model.OpName;
            parameters[5].Value = model.OpIp;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TC22X5Data ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Int,4)};
            parameters[0].Value = issue;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.TC22X5Data GetModel(int issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 date,issue,code,LastModifytime,OpName,OpIp from TC22X5Data ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Int,4)};
            parameters[0].Value = issue;

            Pbzx.Model.TC22X5Data model = new Pbzx.Model.TC22X5Data();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["issue"].ToString() != "")
                {
                    model.issue = int.Parse(ds.Tables[0].Rows[0]["issue"].ToString());
                }
                model.code = ds.Tables[0].Rows[0]["code"].ToString();
                if (ds.Tables[0].Rows[0]["LastModifytime"].ToString() != "")
                {
                    model.LastModifytime = DateTime.Parse(ds.Tables[0].Rows[0]["LastModifytime"].ToString());
                }
                model.OpName = ds.Tables[0].Rows[0]["OpName"].ToString();
                model.OpIp = ds.Tables[0].Rows[0]["OpIp"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select date,issue,code,LastModifytime,OpName,OpIp ");
            strSql.Append(" FROM TC22X5Data ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL1.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" date,issue,code,LastModifytime,OpName,OpIp ");
            strSql.Append(" FROM TC22X5Data ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL1.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// ��ҳ��ȡ�����б�
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
            parameters[0].Value = "TC22X5Data";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL1.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  ��Ա����
    }
}

