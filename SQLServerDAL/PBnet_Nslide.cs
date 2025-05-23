using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//�����������
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// ���ݷ�����PBnet_Nslide��
    /// </summary>
    public class PBnet_Nslide : IPBnet_Nslide
    {
        public PBnet_Nslide()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_Nslide");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Nslide model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_Nslide(");
            strSql.Append("LinkUrl,PicUrl,NOrder,Title,IsEnable,IsInitial,width,height)");
            strSql.Append(" values (");
            strSql.Append("@LinkUrl,@PicUrl,@NOrder,@Title,@IsEnable,@IsInitial,@width,@height)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@PicUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@NOrder", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,255),
					new SqlParameter("@IsEnable", SqlDbType.Bit,1),
					new SqlParameter("@IsInitial", SqlDbType.Bit,1),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@height", SqlDbType.Int,4)};
            parameters[0].Value = model.LinkUrl;
            parameters[1].Value = model.PicUrl;
            parameters[2].Value = model.NOrder;
            parameters[3].Value = model.Title;
            parameters[4].Value = model.IsEnable;
            parameters[5].Value = model.IsInitial;
            parameters[6].Value = model.width;
            parameters[7].Value = model.height;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.PBnet_Nslide model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_Nslide set ");
            strSql.Append("LinkUrl=@LinkUrl,");
            strSql.Append("PicUrl=@PicUrl,");
            strSql.Append("NOrder=@NOrder,");
            strSql.Append("Title=@Title,");
            strSql.Append("IsEnable=@IsEnable,");
            strSql.Append("IsInitial=@IsInitial,");
            strSql.Append("width=@width,");
            strSql.Append("height=@height");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@LinkUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@PicUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@NOrder", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,255),
					new SqlParameter("@IsEnable", SqlDbType.Bit,1),
					new SqlParameter("@IsInitial", SqlDbType.Bit,1),
					new SqlParameter("@width", SqlDbType.Int,4),
					new SqlParameter("@height", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.LinkUrl;
            parameters[2].Value = model.PicUrl;
            parameters[3].Value = model.NOrder;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.IsEnable;
            parameters[6].Value = model.IsInitial;
            parameters[7].Value = model.width;
            parameters[8].Value = model.height;

           return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_Nslide ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_Nslide GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,LinkUrl,PicUrl,NOrder,Title,IsEnable,IsInitial,width,height from PBnet_Nslide ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_Nslide model = new Pbzx.Model.PBnet_Nslide();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
                model.PicUrl = ds.Tables[0].Rows[0]["PicUrl"].ToString();
                if (ds.Tables[0].Rows[0]["NOrder"].ToString() != "")
                {
                    model.NOrder = int.Parse(ds.Tables[0].Rows[0]["NOrder"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                if (ds.Tables[0].Rows[0]["IsEnable"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsEnable"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsEnable"].ToString().ToLower() == "true"))
                    {
                        model.IsEnable = true;
                    }
                    else
                    {
                        model.IsEnable = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsInitial"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsInitial"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsInitial"].ToString().ToLower() == "true"))
                    {
                        model.IsInitial = true;
                    }
                    else
                    {
                        model.IsInitial = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["width"].ToString() != "")
                {
                    model.width = int.Parse(ds.Tables[0].Rows[0]["width"].ToString());
                }
                if (ds.Tables[0].Rows[0]["height"].ToString() != "")
                {
                    model.height = int.Parse(ds.Tables[0].Rows[0]["height"].ToString());
                }
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
            strSql.Append("select ID,LinkUrl,PicUrl,NOrder,Title,IsEnable,IsInitial,width,height ");
            strSql.Append(" FROM PBnet_Nslide ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" ID,LinkUrl,PicUrl,NOrder,Title,IsEnable,IsInitial,width,height ");
            strSql.Append(" FROM PBnet_Nslide ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "PBnet_Nslide";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  ��Ա����
    }
}

