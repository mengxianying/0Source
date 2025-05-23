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
    /// ҵ���߼���CN_StatLog ��ժҪ˵����
    /// </summary>
    public class CN_StatLog
    {
        private readonly ICN_StatLog dal = DataAccess.CreateCN_StatLog();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CN_StatLog", "ID");
        public CN_StatLog()
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
        public bool Add(Pbzx.Model.CN_StatLog model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.CN_StatLog model)
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
        public Pbzx.Model.CN_StatLog GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.CN_StatLog GetModelByCache(int ID)
        {

            string CacheKey = "CN_StatLogModel-" + ID;
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
            return (Pbzx.Model.CN_StatLog)objModel;
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
        public List<Pbzx.Model.CN_StatLog> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CN_StatLog> modelList = new List<Pbzx.Model.CN_StatLog>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CN_StatLog model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CN_StatLog();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["StartTime"].ToString() != "")
                    {
                        model.StartTime = DateTime.Parse(ds.Tables[0].Rows[n]["StartTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["EndTime"].ToString() != "")
                    {
                        model.EndTime = DateTime.Parse(ds.Tables[0].Rows[n]["EndTime"].ToString());
                    }
                    model.Result = ds.Tables[0].Rows[n]["Result"].ToString();
                    model.ErrorInfo = ds.Tables[0].Rows[n]["ErrorInfo"].ToString();
                    if (ds.Tables[0].Rows[n]["EndDate"].ToString() != "")
                    {
                        model.EndDate = DateTime.Parse(ds.Tables[0].Rows[n]["EndDate"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Days"].ToString() != "")
                    {
                        model.Days = int.Parse(ds.Tables[0].Rows[n]["Days"].ToString());
                    }
                    model.Flag = ds.Tables[0].Rows[n]["Flag"].ToString();
                    model.StatTableName = ds.Tables[0].Rows[n]["StatTableName"].ToString();
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


        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "CN_StatLog", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

    }
}

