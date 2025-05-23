using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
using System.Configuration;
using Pbzx.DBUtility;//�����������

namespace Pbzx.SQLServerDAL
{
    public class Basic
    {
        #region ��������DBO����.

        #endregion

        #region ���๫������.
        public string strTableName;//���ݱ���
        public string strPKName;//��������
        #endregion

        #region ���캯��
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
        /// �Ƿ���CST��
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

        #region ���ݷ��ʴ���������
        /// <summary>
        /// ɾ��ָ��������.
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
        /// ����ɾ��ָ��������.
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
        /// ��ȡ����ID.
        /// </summary>
        public int GetInsertID()
        {
            string strSql = "SELECT @@IDENTITY;";
            return Convert.ToInt32(this.GetValueBySql(strSql));
        }


        /// <summary>
        /// ��ȡ�����б�.
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
        /// ��ȡ����ѯ���������б�.
        /// </summary>
        /// <param name="strWhere">��ѯ����.</param>
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
        /// ��ȡ����ѯ����������.
        /// </summary>
        /// <param name="strWhere">��ѯ����.</param>
        /// <param name="strName">��������.</param>
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
        /// ��ȡָ�������ĵ���ֵ.
        /// </summary>
        /// <param name="strName">����.</param>
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
        /// ��ȡָ�������ĵ���ֵ,����ѯ,��������.
        /// </summary>
        /// <param name="strName">����.</param>
        /// <param name="strName">��ѯ����.</param>
        /// <param name="strName">��������.</param>
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
        /// ִ��SQL��ȡ�����б�.
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
        /// ִ��SQL��ȡ������.
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
        /// ִ��SQL���ص���ֵ.
        /// </summary>
        /// <param name="strName">����.</param>
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
        /// ִ��SQL����Ӱ������.
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
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="keyfield">������</param>
        /// <param name="TableName">����</param>
        /// <param name="SearchStr">��ѯ�ַ���</param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
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
        /// �������״̬
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
        /// ��ҳ��ѯ���ݷ���Datatable
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

            ///�����������ݿ�Ĳ���	���ؼ�¼��


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
        ///  ��ҳ��ѯ���ݷ���Datatable
        /// </summary>
        /// <param name="tblName">����</param>
        /// <param name="strGetFields">��Ҫ���ص��У�ȫ��Ϊ*</param>
        /// <param name="fldName">������ֶ���(���������������β������գ����������ֶ��������� Time Desc,Count asc)</param>
        /// <param name="keyfield">�������ֶ���</param>
        /// <param name="PageSize">ҳ�ߴ�</param>
        /// <param name="PageIndex">��ǰҳҳ��</param>
        /// <param name="doCount">�ؼ�¼����,true�򷵻�</param>
        /// <param name="OrderType">������������(��������1����������2�������ֶ�����3)</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="TotalPageCount">���ؼ�¼������</param>
        /// <returns>��ѯ���</returns>     
        public static DataTable CstGetRecordFromPagesDs(string tblName, string strGetFields, string fldName, string keyfield, int PageSize, int PageIndex, bool doCount, int OrderType, string strWhere, out int TotalPageCount)
        {
            if (!string.IsNullOrEmpty(strWhere))
            {
                strWhere = "" + strWhere;
            }
            ///�����������ݿ�Ĳ���	���ؼ�¼��


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
