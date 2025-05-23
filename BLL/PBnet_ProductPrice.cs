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
	/// ҵ���߼���PBnet_ProductPrice ��ժҪ˵����
	/// </summary>
    public class PBnet_ProductPrice
    {
        private readonly IPBnet_ProductPrice dal = DataAccess.CreatePBnet_ProductPrice();
        public PBnet_ProductPrice()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int IntPriceID)
        {
            return dal.Exists(IntPriceID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_ProductPrice model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_ProductPrice model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int IntPriceID)
        {

            return dal.Delete(IntPriceID) > 0 ? true : false;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_ProductPrice GetModel(int IntPriceID)
        {

            return dal.GetModel(IntPriceID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_ProductPrice GetModelByCache(int IntPriceID)
        {

            string CacheKey = "PBnet_ProductPriceModel-" + IntPriceID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(IntPriceID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_ProductPrice)objModel;
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
        public List<Pbzx.Model.PBnet_ProductPrice> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.PBnet_ProductPrice> modelList = new List<Pbzx.Model.PBnet_ProductPrice>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_ProductPrice model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_ProductPrice();
                    if (ds.Tables[0].Rows[n]["IntPriceID"].ToString() != "")
                    {
                        model.IntPriceID = int.Parse(ds.Tables[0].Rows[n]["IntPriceID"].ToString());
                    }
                    model.VarVersionType = ds.Tables[0].Rows[n]["VarVersionType"].ToString();
                    model.VarUseTime = ds.Tables[0].Rows[n]["VarUseTime"].ToString();
                    model.VarPrice = ds.Tables[0].Rows[n]["VarPrice"].ToString();
                    if (ds.Tables[0].Rows[n]["DatUpdateTime"].ToString() != "")
                    {
                        model.DatUpdateTime = DateTime.Parse(ds.Tables[0].Rows[n]["DatUpdateTime"].ToString());
                    }
                    model.VarAdmin = ds.Tables[0].Rows[n]["VarAdmin"].ToString();
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

        public string GetPriceByTypeTime(string type, string time)
        {
            List<Pbzx.Model.PBnet_ProductPrice> lsPrice = GetModelList(" VarVersionType='" + type + "' and VarUseTime='" + time + "' ");

            if (lsPrice.Count > 0)
            {
                return lsPrice[0].VarPrice;
            }
            else
            {
                return "";
            }
        }

        public Pbzx.Model.PBnet_ProductPrice GetModelByTypeTime(string type, string time)
        {
            List<Pbzx.Model.PBnet_ProductPrice> lsPrice = GetModelList(" VarVersionType='" + type + "' and VarUseTime='" + time + "' ");

            if (lsPrice.Count > 0)
            {
                return lsPrice[0];
            }
            else
            {
                return null;
            }
        }
        public string[] GetModelTime(string type)
        {
            string[] result = new string[4];
            List<Pbzx.Model.PBnet_ProductPrice> lsPrice = GetModelList(" VarVersionType='" + type + "'");
            if (lsPrice.Count > 0)
            {
                for (int i = 0; i < lsPrice.Count; i++)
                {
                    Pbzx.Model.PBnet_ProductPrice priceModel = lsPrice[i];
                    result[i] = priceModel.VarPrice + "/" + priceModel.VarUseTime;
                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public DataSet SelectAllProductPrice()
        {
           return dal.SelectAllProductPrice();
        }

         /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere, string orderbyStr)
        {
            return dal.GetList(strWhere,orderbyStr);
        }

         /// <summary>

        //public string GetSoftTime(string Type)
        //{
        //    DataSet ds = GetList(" VarVersionType='" + Type + "'");         
        //    int rowsCount = ds.Tables[0].Rows.Count;
        //    string Price = "";
        //    string UseTime = "";
        //    if (rowsCount > 0)
        //    {
        //        Pbzx.Model.PBnet_ProductPrice model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = new Pbzx.Model.PBnet_ProductPrice();
        //            Price = model.VarPrice = ds.Tables[0].Rows[n]["VarPrice"].ToString();
        //            UseTime = model.VarUseTime = ds.Tables[0].Rows[n]["VarUseTime"].ToString();
        //            return Price + "/" + UseTime;
        //        }
        //    }
        //    return null;
        //}
    }
	
}

