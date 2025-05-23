using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���CL_PrintLine ��ժҪ˵����
    /// </summary>
    public class CL_PrintLine
    {
        private readonly ICL_PrintLine dal = DataAccess.CreateCL_PrintLine();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CL_PrintLine", "ID");
        public CL_PrintLine()
        {
            basicDAL.IsCst = true;
        }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.CL_PrintLine model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.CL_PrintLine model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID) > 0 ? true : false;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.CL_PrintLine GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.CL_PrintLine GetModelByCache(int ID)
        {

            string CacheKey = "CL_PrintLineModel-" + ID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.CL_PrintLine)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.CL_PrintLine> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CL_PrintLine> modelList = new List<Pbzx.Model.CL_PrintLine>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CL_PrintLine model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CL_PrintLine();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.SN = ds.Tables[0].Rows[n]["SN"].ToString();
                    if (ds.Tables[0].Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[n]["CreateTime"].ToString());
                    }
                    model.Creator = ds.Tables[0].Rows[n]["Creator"].ToString();
                    if (ds.Tables[0].Rows[n]["AcceptTime"].ToString() != "")
                    {
                        model.AcceptTime = DateTime.Parse(ds.Tables[0].Rows[n]["AcceptTime"].ToString());
                    }
                    model.Accepter = ds.Tables[0].Rows[n]["Accepter"].ToString();
                    if (ds.Tables[0].Rows[n]["SellTime"].ToString() != "")
                    {
                        model.SellTime = DateTime.Parse(ds.Tables[0].Rows[n]["SellTime"].ToString());
                    }
                    model.Seller = ds.Tables[0].Rows[n]["Seller"].ToString();
                    if (ds.Tables[0].Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(ds.Tables[0].Rows[n]["Type"].ToString());
                    }
                    model.Remarks = ds.Tables[0].Rows[n]["Remarks"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����
        #region �Զ��巽��
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>
        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "CL_PrintLine", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        public Pbzx.Model.CL_PrintLine GetModelBySN(string sn)
        {
            List<Pbzx.Model.CL_PrintLine> ls = GetModelList(" SN='"+sn+"' ");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ִ��SQL��ȡ�����б�.
        /// </summary>
        public DataTable GetLisBySql(string strSql)
        {
            return basicDAL.GetLisBySql(strSql);
        }

        //public string GetTotalMoney(string where)
        //{
        //    string result = "";
        //    string sql = "select count(ID) as TotalID,sum(PayMoney) as TotalMoney from [RegisterInfo2]";
        //    if (!string.IsNullOrEmpty(where))
        //    {
        //        sql += " where " + where;
        //    }
        //    DataSet ds = dal.Query(sql);
        //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        result = ds.Tables[0].Rows[0]["TotalID"] + "&" + ds.Tables[0].Rows[0]["TotalMoney"];
        //    }
        //    else
        //    {
        //        result = "0&0";
        //    }
        //    return result;
        //}


        #endregion
    }
}

