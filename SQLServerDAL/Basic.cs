using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
using System.Configuration;
using Pbzx.DBUtility;//请先添加引用

namespace Pbzx.SQLServerDAL
{
    public class Basic
    {
        #region 创建公共DBO对象.

        #endregion

        #region 基类公共属性.
        public string strTableName;//数据表名
        public string strPKName;//主键表名
        #endregion

        #region 构造函数
        public Basic()
        {
            IsCst = false;
        }
        public Basic(string strTableName1, string strPKName1)
        {
            this.strTableName = strTableName1;
            this.strPKName = strPKName1;
            IsCst = false;
        }
        #endregion


        /// <summary>
        /// 是否是CST库
        /// </summary>
        private bool _IsCst = false;

        public bool IsCst
        {
            get
            {
                return _IsCst;
            }
            set
            {
                _IsCst = value;
                UtilityDAL utd = new UtilityDAL();
                utd.IsCst = value;
                //UtilityDAL.IsCst = value;
            }
        }

        #region 数据访问处理公共方法
        /// <summary>
        /// 删除指定的数据.
        /// </summary>
        public bool Delete(int ID)
        {
            string strSql = string.Format("DELETE FROM {0} WHERE {1} in ({2})", this.strTableName, this.strPKName, ID);
            bool result = false;
            if (IsCst)
            {
                if (DbHelperSQL1.ExecuteSql(strSql) > 0)
                {
                    result = true;

                }
            }
            else
            {
                if (DbHelperSQL.ExecuteSql(strSql) > 0)
                {
                    result = true;

                }
            }
            return result;
        }


        /// <summary>
        /// 批量删除指定的数据.
        /// </summary>
        public int Delete(string ID)
        {
            string strSql = string.Format("DELETE FROM {0} WHERE {1} in ({2})", this.strTableName, this.strPKName, ID);
            if (IsCst)
            {
                return DbHelperSQL1.ExecuteSql(strSql);
            }
            else
            {
                return DbHelperSQL.ExecuteSql(strSql);
            }
        }


        /// <summary>
        /// 获取插入ID.
        /// </summary>
        public int GetInsertID()
        {
            string strSql = "SELECT @@IDENTITY;";
            return Convert.ToInt32(this.GetValueBySql(strSql));
        }


        /// <summary>
        /// 获取数据列表.
        /// </summary>
        public DataTable GetList()
        {
            string strSql = string.Format("SELECT * FROM {0} ORDER BY ID DESC", this.strTableName);
            if (IsCst)
            {
                return DbHelperSQL1.Query(strSql).Tables[0];
            }
            else
            {
                return DbHelperSQL.Query(strSql).Tables[0];
            }
        }


        /// <summary>
        /// 获取带查询条件数据列表.
        /// </summary>
        /// <param name="strWhere">查询条件.</param>
        public DataTable GetList(string strWhere)
        {
            if (strWhere.Trim().Length == 0) strWhere = "1=1";
            string strSql = string.Format("SELECT * FROM {0} WHERE {1} ORDER BY ID DESC", this.strTableName, strWhere);
            if (IsCst)
            {
                return DbHelperSQL1.Query(strSql).Tables[0];
            }
            else
            {
                return DbHelperSQL.Query(strSql).Tables[0];
            }
        }


        /// <summary>
        /// 获取带查询条件数据行.
        /// </summary>
        /// <param name="strWhere">查询条件.</param>
        /// <param name="strName">排序条件.</param>
        public DataRow GetRow(string strWhere, string strOrderBy)
        {
            if (strWhere.Trim().Length == 0) strWhere = "1=1";
            if (strOrderBy.Trim().Length == 0) strOrderBy = this.strPKName;
            string strSql = string.Format("SELECT * FROM {0} WHERE {1} ORDER BY {2}", this.strTableName, strWhere, strOrderBy);
            if (IsCst)
            {
                return DbHelperSQL1.Query(strSql).Tables[0].Rows[0];
            }
            else
            {
                return DbHelperSQL.Query(strSql).Tables[0].Rows[0];
            }
        }


        /// <summary>
        /// 获取指定列名的单个值.
        /// </summary>
        /// <param name="strName">列名.</param>
        public object GetValue(string strName)
        {
            string strSql = string.Format("SELECT {1} FROM {0} ", this.strTableName, strName);
            if (IsCst)
            {
                return DbHelperSQL1.GetSingle(strSql);
            }
            else
            {
                return DbHelperSQL.GetSingle(strSql);
            }
        }

        /// <summary>
        /// 获取指定列名的单个值,带查询,排序条件.
        /// </summary>
        /// <param name="strName">列名.</param>
        /// <param name="strName">查询条件.</param>
        /// <param name="strName">排序条件.</param>
        public object GetValue(string strName, string strWhere, string strOrderBy)
        {
            if (strWhere.Trim().Length == 0) strWhere = "1=1";
            if (strOrderBy.Trim().Length == 0) strOrderBy = "''";
            string strSql = string.Format("SELECT {1} FROM {0} WHERE {2} ORDER BY {3}", this.strTableName, strName, strWhere, strOrderBy);
            if (IsCst)
            {
                return DbHelperSQL1.GetSingle(strSql);
            }
            else
            {
                return DbHelperSQL.GetSingle(strSql);
            }
        }


        /// <summary>
        /// 执行SQL获取数据列表.
        /// </summary>
        public DataTable GetLisBySql(string strSql)
        {
            if (IsCst)
            {
                return DbHelperSQL1.Query(strSql).Tables[0];
            }
            else
            {
                return DbHelperSQL.Query(strSql).Tables[0];
            }
        }


        /// <summary>
        /// 执行SQL获取数据行.
        /// </summary>
        public DataRow GetRowBySql(string strSql)
        {
            if (IsCst)
            {
                DataTable dt = DbHelperSQL1.Query(strSql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                DataTable dt = DbHelperSQL.Query(strSql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// 执行SQL返回单个值.
        /// </summary>
        /// <param name="strName">列名.</param>
        public object GetValueBySql(string strSql)
        {
            if (IsCst)
            {
                return DbHelperSQL1.GetSingle(strSql);
            }
            else
            {
                return DbHelperSQL.GetSingle(strSql);
            }
        }


        /// <summary>
        /// 执行SQL返回影响行数.
        /// </summary>
        public int ExecuteSql(string strSql)
        {
            if (IsCst)
            {
                return DbHelperSQL1.ExecuteSql(strSql);
            }
            else
            {
                return DbHelperSQL.ExecuteSql(strSql);
            }

        }
        #endregion


        /// <summary>
        /// 根据查询字符串获取分页数据
        /// </summary>
        /// <param name="keyfield">主键名</param>
        /// <param name="TableName">表名</param>
        /// <param name="SearchStr">查询字符串</param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>
        public DataTable GuestGetBySearch(string keyfield, string TableName, string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            if (orderType == 3)
            {
                string[] orderSZ = OrderStr.Split(new char[] { ' ' });
                if (orderSZ.Length > 0)
                {
                    if (orderSZ[0] != keyfield)
                    {
                        OrderStr += "," + keyfield + " asc";
                    }
                }

            }
            DataSet ds = UtilityDAL.GetRecordFromPagesDs(TableName, getFileds, OrderStr, keyfield, PageNum, CurrentPage, true, orderType, SearchStr, out Counts);

            if (ds.Tables.Count < 1)
            {
                return null;
            }
            else
            {
                return ds.Tables[0];
            }
        }





        /// <summary>
        /// 更改审核状态
        /// </summary>
        public void ChangeAudit(int id, string filed)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + this.strTableName + " set " + filed + " = 1- " + filed + " ");
            strSql.Append(" where " + this.strPKName + "=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            if (IsCst)
            {
                DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
            }
            else
            {
                DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }

        /// <summary>
        /// 分页查询数据返回Datatable
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="strGetFields">需要返回的列，全部为'*'</param>
        /// <param name="fldName">排序的字段名(如果按照主键排序次参数留空，按照其它字段排序例如 Time Desc,Count asc)</param>
        /// <param name="keyfield">主键的字段名</param>
        /// <param name="PageSize">页尺寸</param>
        /// <param name="PageIndex">当前页页码</param>
        /// <param name="doCount">返回记录总数,true则返回<</param>
        /// <param name="OrderType">设置排序类型(主键升序：1，主键降序：2，其它字段排序：3)</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="TotalPageCount">返回记录集总数</param>
        /// <returns>查询结果</returns>
        public static DataTable BbsGetRecordFromPagesDs(string tblName, string strGetFields, string fldName, string keyfield, int PageSize, int PageIndex, bool doCount, int OrderType, string strWhere, out int TotalPageCount)
        {
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = "" + strWhere;
            }

            //if (OrderType == 3)
            //{
            //    string[] orderSZ = fldName.Split(new char[] { ' ' });
            //    if (orderSZ.Length > 0)
            //    {
            //        if (orderSZ[0] != keyfield)
            //        {
            //            fldName += "," + keyfield + " asc";
            //        }
            //    }
            //}

            ///创建访问数据库的参数	返回记录数


            SqlParameter[] paramList = {
                
            BbsSQLDal.MakeInParam("@TableName",SqlDbType.NVarChar,200,tblName),
            BbsSQLDal.MakeInParam("@FieldList",SqlDbType.NVarChar,1000,strGetFields),
            BbsSQLDal.MakeInParam("@Order",SqlDbType.NVarChar,200,fldName),

            BbsSQLDal.MakeInParam("@PrimaryKey",SqlDbType.NVarChar,150,keyfield),
                
            BbsSQLDal.MakeInParam("@PageSize",SqlDbType.Int,4,PageSize),

            BbsSQLDal.MakeInParam("@PageIndex",SqlDbType.Int,4,PageIndex),
           // SQLHelper.MakeInParam("@doCount",SqlDbType.Bit,1,true),
            BbsSQLDal.MakeInParam("@SortType",SqlDbType.Int,4,OrderType),
            BbsSQLDal.MakeInParam("@Where",SqlDbType.NVarChar,1000,strWhere),
            BbsSQLDal.MakeInParam("@RecorderCount",SqlDbType.Int,4,0),

            BbsSQLDal.MakeOutParam("@TotalPageCount",SqlDbType.Int,4,1),
            BbsSQLDal.MakeOutParam("@TotalCount",SqlDbType.Int,4,1)
            };
            TotalPageCount = 0;
            DataSet dsFenYe = BbsSQLDal.RunProcedure1("rzrs_GetRecordFromPage", paramList, "ds", ref TotalPageCount);
            if (dsFenYe.Tables.Count > 0)
            {
                return dsFenYe.Tables[0];
            }
            else
            {
                return null;
            }

        }




        /// <summary>
        ///  分页查询数据返回Datatable
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="strGetFields">需要返回的列，全部为*</param>
        /// <param name="fldName">排序的字段名(如果按照主键排序次参数留空，按照其它字段排序例如 Time Desc,Count asc)</param>
        /// <param name="keyfield">主键的字段名</param>
        /// <param name="PageSize">页尺寸</param>
        /// <param name="PageIndex">当前页页码</param>
        /// <param name="doCount">回记录总数,true则返回</param>
        /// <param name="OrderType">设置排序类型(主键升序：1，主键降序：2，其它字段排序：3)</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="TotalPageCount">返回记录集总数</param>
        /// <returns>查询结果</returns>     
        public static DataTable CstGetRecordFromPagesDs(string tblName, string strGetFields, string fldName, string keyfield, int PageSize, int PageIndex, bool doCount, int OrderType, string strWhere, out int TotalPageCount)
        {
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = "" + strWhere;
            }
            ///创建访问数据库的参数	返回记录数


            SqlParameter[] paramList = {
                
            BbsSQLDal.MakeInParam("@TableName",SqlDbType.NVarChar,200,tblName),
            BbsSQLDal.MakeInParam("@FieldList",SqlDbType.NVarChar,1000,strGetFields),
            BbsSQLDal.MakeInParam("@Order",SqlDbType.NVarChar,200,fldName),

            BbsSQLDal.MakeInParam("@PrimaryKey",SqlDbType.NVarChar,150,keyfield),
                
            BbsSQLDal.MakeInParam("@PageSize",SqlDbType.Int,4,PageSize),

            BbsSQLDal.MakeInParam("@PageIndex",SqlDbType.Int,4,PageIndex),
           // SQLHelper.MakeInParam("@doCount",SqlDbType.Bit,1,true),
            BbsSQLDal.MakeInParam("@SortType",SqlDbType.Int,4,OrderType),
            BbsSQLDal.MakeInParam("@Where",SqlDbType.NVarChar,1000,strWhere),
            BbsSQLDal.MakeInParam("@RecorderCount",SqlDbType.Int,4,0),

            BbsSQLDal.MakeOutParam("@TotalPageCount",SqlDbType.Int,4,1),
            BbsSQLDal.MakeOutParam("@TotalCount",SqlDbType.Int,4,1)
            };
            TotalPageCount = 0;
            DataSet dsFenYe = CstSQLDal.RunProcedure1("rzrs_GetRecordFromPage", paramList, "ds", ref TotalPageCount);

            return dsFenYe.Tables[0];
        }


    }
}
