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
    /// ҵ���߼���CN_Software ��ժҪ˵����
    /// </summary>
    public class CN_Software
    {
        private readonly ICN_Software dal = DataAccess.CreateCN_Software();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CN_Software", "ID");
        public CN_Software()
        {
            basicDAL.IsCst = true;
        }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID, int InstallType)
        {
            return dal.Exists(ID, InstallType);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.CN_Software model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.CN_Software model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int ID, int InstallType)
        {

            return dal.Delete(ID, InstallType) > 0 ? true : false;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.CN_Software GetModel(int ID, int InstallType)
        {

            return dal.GetModel(ID, InstallType);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.CN_Software GetModelByCache(int ID, int InstallType)
        {

            string CacheKey = "CN_SoftwareModel-" + ID + InstallType;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID, InstallType);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.CN_Software)objModel;
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
        public List<Pbzx.Model.CN_Software> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CN_Software> modelList = new List<Pbzx.Model.CN_Software>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CN_Software model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CN_Software();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["SoftwareType"].ToString() != "")
                    {
                        model.SoftwareType = int.Parse(ds.Tables[0].Rows[n]["SoftwareType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["InstallType"].ToString() != "")
                    {
                        model.InstallType = int.Parse(ds.Tables[0].Rows[n]["InstallType"].ToString());
                    }
                    model.Boards = ds.Tables[0].Rows[n]["Boards"].ToString();
                    model.MinTopics = ds.Tables[0].Rows[n]["MinTopics"].ToString();
                    model.MinAnncounts = ds.Tables[0].Rows[n]["MinAnncounts"].ToString();
                    if (ds.Tables[0].Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Flag"].ToString() != "")
                    {
                        model.Flag = int.Parse(ds.Tables[0].Rows[n]["Flag"].ToString());
                    }
                    model.MinDays = ds.Tables[0].Rows[n]["MinDays"].ToString();
                    model.MinBests = ds.Tables[0].Rows[n]["MinBests"].ToString();
                    model.Lottery = ds.Tables[0].Rows[n]["Lottery"].ToString();
                    if (ds.Tables[0].Rows[n]["LotteryID"].ToString() != "")
                    {
                        model.LotteryID = int.Parse(ds.Tables[0].Rows[n]["LotteryID"].ToString());
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

        #endregion  ��Ա����
        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "CN_Software", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

    }
}

