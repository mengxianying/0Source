using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;
using System.Configuration;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 公共SQL函数库
    /// </summary>
    public class UtilityDAL
    {

        #region 构造函数
        public UtilityDAL()
        {
            this.IsCst = false;
        }
        #endregion

        #region 返回SqlDataReader 暂时不用
        /// <summary>
        /// 分页查询数据返回SqlDataReader
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="strGetFields">需要返回的列，全部为'*'</param>
        /// <param name="fldName">排序的字段名</param>
        /// <param name="PageSize">页尺寸</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="doCount">返回记录总数,非 0 值则返回</param>
        /// <param name="OrderType">设置排序类型, 非 0 值则降序</param>
        /// <param name="strWhere">查询条件 (注意: 不要加 where)</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns>SqlDataReader</returns>
        //public static SqlDataReader GetRecordFromPages(string tblName, string strGetFields, string fldName, int PageSize, int PageIndex, bool doCount, bool OrderType, string strWhere, out int Counts)
        //{
        //    SqlDataReader sdr = null;
        //    ///创建访问数据库的参数	返回记录数
        //    SqlParameter[] paramList = {
        //    SQLHelper.MakeInParam("@tblName",SqlDbType.VarChar,255,tblName),
        //    SQLHelper.MakeInParam("@strGetFields",SqlDbType.VarChar,1000,strGetFields),
        //    SQLHelper.MakeInParam("@fldName",SqlDbType.VarChar,255,fldName),
        //    SQLHelper.MakeInParam("@pageSize",SqlDbType.Int,4,PageSize),
        //    SQLHelper.MakeInParam("@PageIndex",SqlDbType.Int,4,PageIndex),
        //    SQLHelper.MakeInParam("@doCount",SqlDbType.Bit,1,true),
        //    SQLHelper.MakeInParam("@OrderType",SqlDbType.Bit,1,OrderType),
        //    SQLHelper.MakeInParam("@strWhere",SqlDbType.VarChar,1500,strWhere)
        //    };
        //    Counts = SQLHelper.RunProcPage("rzrs_GetRecordFromPage", paramList);

        //    ///创建访问数据库的参数	返回数据
        //    ///
        //    SqlParameter[] paramList1 = {
        //    SQLHelper.MakeInParam("@tblName",SqlDbType.VarChar,255,tblName),
        //    SQLHelper.MakeInParam("@strGetFields",SqlDbType.VarChar,1000,strGetFields),
        //    SQLHelper.MakeInParam("@fldName",SqlDbType.VarChar,255,fldName),
        //    SQLHelper.MakeInParam("@pageSize",SqlDbType.Int,4,PageSize),
        //    SQLHelper.MakeInParam("@PageIndex",SqlDbType.Int,4,PageIndex),
        //    SQLHelper.MakeInParam("@doCount",SqlDbType.Bit,1,false),
        //    SQLHelper.MakeInParam("@OrderType",SqlDbType.Bit,1,OrderType),
        //    SQLHelper.MakeInParam("@strWhere",SqlDbType.VarChar,1500,strWhere)
        //    };
        //    SQLHelper.RunProcPage("rzrs_GetRecordFromPage", paramList1, out sdr);
        //    return sdr;
        //}
        #endregion

        /// <summary>
        /// 是否是CST库
        /// </summary>
        private  bool _IsCst;

        public  bool IsCst
        {
            get
            {
                if (SQLHelper.ConnectionString == ConfigurationManager.AppSettings["ConnectionString2"])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                _IsCst = value;
                if (_IsCst)
                {
                    SQLHelper.ConnectionString = ConfigurationManager.AppSettings["ConnectionString2"];
                }
                else
                {
                    SQLHelper.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                }
            }
            
        }


        /// <summary>
        ///  分页查询数据返回Datatable
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
        public static DataSet GetRecordFromPagesDs(string tblName, string strGetFields, string fldName, string keyfield, int PageSize, int PageIndex, bool doCount, int OrderType, string strWhere, out int TotalPageCount)
        {
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = ""+strWhere;
            }
            string tName = tblName;
            if (tblName.ToUpper().IndexOf("[PINBLE_WEB]") < 0 && tblName.ToUpper().IndexOf("[PINBLE_CST]") < 0 && tblName.ToUpper().IndexOf("PBNET_") >= 0 && !string.IsNullOrEmpty(tblName))
            {
                tName = "[Pinble_Web].dbo." + tName;
            }
            ///创建访问数据库的参数	返回记录数


            SqlParameter[] paramList = {
                
            BbsSQLDal.MakeInParam("@TableName",SqlDbType.NVarChar,200,tName),
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
            //if()
            //{
            
            //}

            DataSet dsFenYe = SQLHelper.RunProcedure1("rzrs_GetRecordFromPage", paramList, "ds", ref TotalPageCount);

            return dsFenYe;
        }



        /// <summary>
        /// 执行一条SQL语句
        /// </summary>
        /// <param name="SqlStr"></param>
        //public SqlDataReader GetRecordBysql(string SqlStr)
        //{
        //    try
        //    {
        //        SqlDataReader sdr = null;
        //        SqlParameter[] paramList = {
        //    SQLHelper.MakeInParam("@QueryStr",SqlDbType.VarChar,500,SqlStr)
        //    };
        //        SQLHelper.RunProc("rzrs_GetRecordBysql", paramList, out sdr);
        //        return sdr;
        //    }
        //    catch (Exception) { return null; }
        //}
    }
}
