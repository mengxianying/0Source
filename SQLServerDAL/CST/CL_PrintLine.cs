using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CL_PrintLine。
    /// </summary>
    public class CL_PrintLine : ICL_PrintLine
    {
        public CL_PrintLine()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CL_PrintLine");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CL_PrintLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CL_PrintLine(");
            strSql.Append("SN,CreateTime,Creator,AcceptTime,Accepter,SellTime,Seller,Status,Type,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@SN,@CreateTime,@Creator,@AcceptTime,@Accepter,@SellTime,@Seller,@Status,@Type,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.Char,16),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Creator", SqlDbType.NVarChar,16),
					new SqlParameter("@AcceptTime", SqlDbType.DateTime),
					new SqlParameter("@Accepter", SqlDbType.NVarChar,16),
					new SqlParameter("@SellTime", SqlDbType.DateTime),
					new SqlParameter("@Seller", SqlDbType.NVarChar,16),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Type", SqlDbType.TinyInt,1),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.SN;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.Creator;
            parameters[3].Value = model.AcceptTime;
            parameters[4].Value = model.Accepter;
            parameters[5].Value = model.SellTime;
            parameters[6].Value = model.Seller;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Type;
            parameters[9].Value = model.Remarks;

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
        public int Update(Pbzx.Model.CL_PrintLine model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CL_PrintLine set ");
            strSql.Append("SN=@SN,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Accepter=@Accepter,");
            strSql.Append("SellTime=@SellTime,");
            strSql.Append("Seller=@Seller,");
            strSql.Append("Status=@Status,");
            strSql.Append("Type=@Type,");
            strSql.Append("Remarks=@Remarks");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SN", SqlDbType.Char,16),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Creator", SqlDbType.NVarChar,16),
					new SqlParameter("@AcceptTime", SqlDbType.DateTime),
					new SqlParameter("@Accepter", SqlDbType.NVarChar,16),
					new SqlParameter("@SellTime", SqlDbType.DateTime),
					new SqlParameter("@Seller", SqlDbType.NVarChar,16),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Type", SqlDbType.TinyInt,1),
					new SqlParameter("@Remarks", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SN;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.Creator;
            parameters[4].Value = model.AcceptTime;
            parameters[5].Value = model.Accepter;
            parameters[6].Value = model.SellTime;
            parameters[7].Value = model.Seller;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Type;
            parameters[10].Value = model.Remarks;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CL_PrintLine ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CL_PrintLine GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,SN,CreateTime,Creator,AcceptTime,Accepter,SellTime,Seller,Status,Type,Remarks from CL_PrintLine ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.CL_PrintLine model = new Pbzx.Model.CL_PrintLine();
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
                model.Creator = ds.Tables[0].Rows[0]["Creator"].ToString();
                if (ds.Tables[0].Rows[0]["AcceptTime"].ToString() != "")
                {
                    model.AcceptTime = DateTime.Parse(ds.Tables[0].Rows[0]["AcceptTime"].ToString());
                }
                model.Accepter = ds.Tables[0].Rows[0]["Accepter"].ToString();
                if (ds.Tables[0].Rows[0]["SellTime"].ToString() != "")
                {
                    model.SellTime = DateTime.Parse(ds.Tables[0].Rows[0]["SellTime"].ToString());
                }
                model.Seller = ds.Tables[0].Rows[0]["Seller"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
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
            strSql.Append("select ID,SN,CreateTime,Creator,AcceptTime,Accepter,SellTime,Seller,Status,Type,Remarks ");
            strSql.Append(" FROM CL_PrintLine ");
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
            parameters[0].Value = "CL_PrintLine";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL1.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        /// <summary>
        /// 根据sql语句查询
        /// </summary>
        /// <param name="strSql">sql语句</param>
        /// <returns>返回值</returns>
        public DataSet Query(string strSql)
        {
            return DbHelperSQL1.Query(strSql);
        }
    }
}

