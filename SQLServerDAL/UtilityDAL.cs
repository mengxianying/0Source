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
    /// ����SQL������
    /// </summary>
    public class UtilityDAL
    {

        #region ���캯��
        public UtilityDAL()
        {
            this.IsCst = false;
        }
        #endregion

        #region ����SqlDataReader ��ʱ����
        /// <summary>
        /// ��ҳ��ѯ���ݷ���SqlDataReader
        /// </summary>
        /// <param name="tblName">����</param>
        /// <param name="strGetFields">��Ҫ���ص��У�ȫ��Ϊ'*'</param>
        /// <param name="fldName">������ֶ���</param>
        /// <param name="PageSize">ҳ�ߴ�</param>
        /// <param name="PageIndex">ҳ��</param>
        /// <param name="doCount">���ؼ�¼����,�� 0 ֵ�򷵻�</param>
        /// <param name="OrderType">������������, �� 0 ֵ����</param>
        /// <param name="strWhere">��ѯ���� (ע��: ��Ҫ�� where)</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns>SqlDataReader</returns>
        //public static SqlDataReader GetRecordFromPages(string tblName, string strGetFields, string fldName, int PageSize, int PageIndex, bool doCount, bool OrderType, string strWhere, out int Counts)
        //{
        //    SqlDataReader sdr = null;
        //    ///�����������ݿ�Ĳ���	���ؼ�¼��
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

        //    ///�����������ݿ�Ĳ���	��������
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
        /// �Ƿ���CST��
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
        ///  ��ҳ��ѯ���ݷ���Datatable
        /// </summary>
        /// <param name="tblName">����</param>
        /// <param name="strGetFields">��Ҫ���ص��У�ȫ��Ϊ'*'</param>
        /// <param name="fldName">������ֶ���(���������������β������գ����������ֶ��������� Time Desc,Count asc)</param>
        /// <param name="keyfield">�������ֶ���</param>
        /// <param name="PageSize">ҳ�ߴ�</param>
        /// <param name="PageIndex">��ǰҳҳ��</param>
        /// <param name="doCount">���ؼ�¼����,true�򷵻�<</param>
        /// <param name="OrderType">������������(��������1����������2�������ֶ�����3)</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="TotalPageCount">���ؼ�¼������</param>
        /// <returns>��ѯ���</returns>
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
            ///�����������ݿ�Ĳ���	���ؼ�¼��


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
        /// ִ��һ��SQL���
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
