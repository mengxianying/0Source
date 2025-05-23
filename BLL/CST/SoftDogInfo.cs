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
    /// ҵ���߼���SoftDogInfo ��ժҪ˵����
    /// </summary>
    public class SoftDogInfo
    {
        private readonly ISoftDogInfo dal = DataAccess.CreateSoftDogInfo();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("SoftDogInfo", "ID");

        public SoftDogInfo()
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
        public bool Add(Pbzx.Model.SoftDogInfo model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.SoftDogInfo model)
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
        public Pbzx.Model.SoftDogInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.SoftDogInfo GetModelByCache(int ID)
        {

            string CacheKey = "SoftDogInfoModel-" + ID;
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
            return (Pbzx.Model.SoftDogInfo)objModel;
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
        public List<Pbzx.Model.SoftDogInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.SoftDogInfo> modelList = new List<Pbzx.Model.SoftDogInfo>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.SoftDogInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.SoftDogInfo();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.SN = ds.Tables[0].Rows[n]["SN"].ToString();
                    if (ds.Tables[0].Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[n]["CreateTime"].ToString());
                    }
                    model.Creater = ds.Tables[0].Rows[n]["Creater"].ToString();
                    model.OldSN = ds.Tables[0].Rows[n]["OldSN"].ToString();
                    if (ds.Tables[0].Rows[n]["SellPrice"].ToString() != "")
                    {
                        model.SellPrice = int.Parse(ds.Tables[0].Rows[n]["SellPrice"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
                    }
                    model.Remarks = ds.Tables[0].Rows[n]["Remarks"].ToString();
                    if (ds.Tables[0].Rows[n]["AgentID"].ToString() != "")
                    {
                        model.AgentID = int.Parse(ds.Tables[0].Rows[n]["AgentID"].ToString());
                    }
                    model.AgentName = ds.Tables[0].Rows[n]["AgentName"].ToString();
                    model.Seller = ds.Tables[0].Rows[n]["Seller"].ToString();
                    if (ds.Tables[0].Rows[n]["SellTime"].ToString() != "")
                    {
                        model.SellTime = DateTime.Parse(ds.Tables[0].Rows[n]["SellTime"].ToString());
                    }
                    model.PayType = ds.Tables[0].Rows[n]["PayType"].ToString();
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "SoftDogInfo", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        public string GetTotalMoney(string where)
        {
            string result = "";
            string sql = "select count(ID) as TotalID,sum(SellPrice) as TotalMoney from [SoftDogInfo]";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
            DataSet ds = dal.Query(sql);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0].Rows[0]["TotalID"] + "&" + ds.Tables[0].Rows[0]["TotalMoney"];
            }
            else
            {
                result = "0&0";
            }
            return result;
        }
    }
}

