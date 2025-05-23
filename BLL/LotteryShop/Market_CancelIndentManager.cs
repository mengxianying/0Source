using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;

namespace Pbzx.BLL
{
    public class Market_CancelIndent
    {
        private readonly IMarket_CancelIndent dal = DataAccess.CreateIMarket_CancelIndent();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Market_CancelIndent", "CancelID");
        public Market_CancelIndent()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int CancelID)
        {
            return dal.Exists(CancelID);
        }
        public bool Exists(string name, int Item)
        {
            return dal.Exists(name,Item);
            
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Market_CancelIndent model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.Market_CancelIndent model)
        {
           return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int CancelID)
        {

            return dal.Delete(CancelID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Market_CancelIndent GetModel(int CancelID)
        {

            return dal.GetModel(CancelID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.Market_CancelIndent GetModelByCache(int CancelID)
        {

            string CacheKey = "Market_CancelIndentModel-" + CancelID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(CancelID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.Market_CancelIndent)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Market_CancelIndent> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Market_CancelIndent> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Market_CancelIndent> modelList = new List<Pbzx.Model.Market_CancelIndent>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Market_CancelIndent model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Market_CancelIndent();
                    if (dt.Rows[n]["CancelID"].ToString() != "")
                    {
                        model.CancelID = int.Parse(dt.Rows[n]["CancelID"].ToString());
                    }
                    if (dt.Rows[n]["CancelIndent"].ToString() != "")
                    {
                        model.CancelIndent = int.Parse(dt.Rows[n]["CancelIndent"].ToString());
                    }
                    if (dt.Rows[n]["CTime"].ToString() != "")
                    {
                        model.CTime = DateTime.Parse(dt.Rows[n]["CTime"].ToString());
                    }
                    if (dt.Rows[n]["CApprove"].ToString() != "")
                    {
                        model.CApprove = int.Parse(dt.Rows[n]["CApprove"].ToString());
                    }
                    model.CancelName = dt.Rows[n]["CancelName"].ToString();
                    if (dt.Rows[n]["CancelItem"].ToString() != "")
                    {
                        model.CancelItem = int.Parse(dt.Rows[n]["CancelItem"].ToString());
                    }
                    model.CancelSake = dt.Rows[n]["CancelSake"].ToString();
                    model.Other = dt.Rows[n]["Other"].ToString();
                    if (dt.Rows[n]["approveTime"].ToString() != "")
                    {
                        model.approveTime = DateTime.Parse(dt.Rows[n]["approveTime"].ToString());
                    }
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
        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: zhouwei
        /// ����ʱ��: 2011-1-18
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Market_CancelIndent", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        #endregion  ��Ա����
    }
}
