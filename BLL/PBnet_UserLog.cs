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
    /// ҵ���߼���PBnet_UserLog ��ժҪ˵����
    /// </summary>
    public class PBnet_UserLog
    {
        private readonly IPBnet_UserLog dal = DataAccess.CreatePBnet_UserLog();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_UserLog", "id");

        public PBnet_UserLog()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(long id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.PBnet_UserLog model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.PBnet_UserLog model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(long id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_UserLog GetModel(long id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_UserLog GetModelByCache(long id)
        {

            string CacheKey = "PBnet_UserLogModel-" + id;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_UserLog)objModel;
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
        public List<Pbzx.Model.PBnet_UserLog> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_UserLog> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_UserLog> modelList = new List<Pbzx.Model.PBnet_UserLog>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_UserLog model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_UserLog();
                    //model.id=dt.Rows[n]["id"].ToString();
                    model.log_username = dt.Rows[n]["log_username"].ToString();
                    model.log_password = dt.Rows[n]["log_password"].ToString();
                    if (dt.Rows[n]["log_time"].ToString() != "")
                    {
                        model.log_time = DateTime.Parse(dt.Rows[n]["log_time"].ToString());
                    }
                    model.log_Ip = dt.Rows[n]["log_Ip"].ToString();
                    model.log_state = dt.Rows[n]["log_state"].ToString();
                    model.log_stepinto = dt.Rows[n]["log_stepinto"].ToString();
                    model.log_urlname = dt.Rows[n]["log_urlname"].ToString();
                    model.log_allhttp = dt.Rows[n]["log_allhttp"].ToString();
                    model.log_country = dt.Rows[n]["log_country"].ToString();
                    model.log_city = dt.Rows[n]["log_city"].ToString();
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_UserLog", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }



    }
}

