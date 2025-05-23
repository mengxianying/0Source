using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Text;
using Pbzx.Common;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���PBnet_UserTradeInfo ��ժҪ˵����
    /// </summary>
    public class PBnet_UserTradeInfo
    {
        private readonly IPBnet_UserTradeInfo dal = DataAccess.CreatePBnet_UserTradeInfo();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_UserTradeInfo", "ID");
        public PBnet_UserTradeInfo()
        { }
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
        public bool  Add(Pbzx.Model.PBnet_UserTradeInfo model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_UserTradeInfo model)
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
        public Pbzx.Model.PBnet_UserTradeInfo GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_UserTradeInfo GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_UserTradeInfoModel-" + ID;
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
            return (Pbzx.Model.PBnet_UserTradeInfo)objModel;
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
        public List<Pbzx.Model.PBnet_UserTradeInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_UserTradeInfo> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_UserTradeInfo> modelList = new List<Pbzx.Model.PBnet_UserTradeInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_UserTradeInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_UserTradeInfo();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    if (dt.Rows[n]["TradeMoney"].ToString() != "")
                    {
                        model.TradeMoney = decimal.Parse(dt.Rows[n]["TradeMoney"].ToString());
                    }
                    if (dt.Rows[n]["TradeTime"].ToString() != "")
                    {
                        model.TradeTime = DateTime.Parse(dt.Rows[n]["TradeTime"].ToString());
                    }
                    if (dt.Rows[n]["TradeType"].ToString() != "")
                    {
                        model.TradeType = int.Parse(dt.Rows[n]["TradeType"].ToString());
                    }
                    model.BankName = dt.Rows[n]["BankName"].ToString();
                    model.AccountNumber = dt.Rows[n]["AccountNumber"].ToString();
                    model.Account_UserName = dt.Rows[n]["Account_UserName"].ToString();
                    model.OperateManager = dt.Rows[n]["OperateManager"].ToString();
                    if (dt.Rows[n]["CurrentMoney"].ToString() != "")
                    {
                        model.CurrentMoney = decimal.Parse(dt.Rows[n]["CurrentMoney"].ToString());
                    }
                        model.ForeignKey_id = dt.Rows[n]["ForeignKey_id"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();
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
            return basicDAL.GuestGetBySearch("ID", "PBnet_UserTradeInfo", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

    }
}

