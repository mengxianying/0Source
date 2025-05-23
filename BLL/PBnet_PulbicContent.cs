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
    /// ҵ���߼���PBnet_PulbicContent ��ժҪ˵����
    /// </summary>
    public class PBnet_PulbicContent
    {
        private readonly IPBnet_PulbicContent dal = DataAccess.CreatePBnet_PulbicContent();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_PulbicContent", "IntID");

        public PBnet_PulbicContent()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int IntID)
        {
            return dal.Exists(IntID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_PulbicContent model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_PulbicContent model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int IntID)
        {

            return dal.Delete(IntID) > 0 ? true : false;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_PulbicContent GetModel(int IntID)
        {

            return dal.GetModel(IntID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_PulbicContent GetModelByCache(int IntID)
        {

            string CacheKey = "PBnet_PulbicContentModel-" + IntID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(IntID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_PulbicContent)objModel;
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
        public List<Pbzx.Model.PBnet_PulbicContent> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_PulbicContent> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_PulbicContent> modelList = new List<Pbzx.Model.PBnet_PulbicContent>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_PulbicContent model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_PulbicContent();
                    if (dt.Rows[n]["IntID"].ToString() != "")
                    {
                        model.IntID = int.Parse(dt.Rows[n]["IntID"].ToString());
                    }
                    model.NvarTitle = dt.Rows[n]["NvarTitle"].ToString();
                    model.NteContent = dt.Rows[n]["NteContent"].ToString();
                    if (dt.Rows[n]["BitState"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitState"].ToString() == "1") || (dt.Rows[n]["BitState"].ToString().ToLower() == "true"))
                        {
                            model.BitState = true;
                        }
                        else
                        {
                            model.BitState = false;
                        }
                    }
                    model.NvarClass = dt.Rows[n]["NvarClass"].ToString();
                    model.HtmUrl = dt.Rows[n]["HtmUrl"].ToString();
                    model.AspxUrl = dt.Rows[n]["AspxUrl"].ToString();
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_PulbicContent", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// ����Bool�����ֶ�״̬
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="filed">�ֶ���</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_PulbicContent", "IntID");
            basicDAL1.ChangeAudit(id, filed);
        }
        /// <summary>
        /// �Լ���������û����õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_PulbicContent GetModelName(string Name)
        {
            List<Pbzx.Model.PBnet_PulbicContent> ls = GetModelList(" NvarClass='" + Name + "'");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }
    }
}

