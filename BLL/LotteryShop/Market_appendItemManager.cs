using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    public class Market_appendItemManager
    {
        private readonly IMarket_appendItem dal = DataAccess.CreateIPBnet_Lottery_appendItem();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("v_appendItem", "appendid");
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Market_appendItem model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.Market_appendItem model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int Id)
        {

            return dal.Delete(Id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Market_appendItem GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.Market_appendItem GetModelByCache(int Id)
        {

            string CacheKey = "Market_appendItemModel-" + Id ;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.Market_appendItem)objModel;
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
        public List<Pbzx.Model.Market_appendItem> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Market_appendItem> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Market_appendItem> modelList = new List<Pbzx.Model.Market_appendItem>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Market_appendItem model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Market_appendItem();
                    if (dt.Rows[n]["appendID"].ToString() != "")
                    {
                        model.appendID = int.Parse(dt.Rows[n]["appendID"].ToString());
                    }
                    if (dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = int.Parse(dt.Rows[n]["TypeID"].ToString());
                    }
                    model.UserId = dt.Rows[n]["UserId"].ToString();
                    if (dt.Rows[n]["Charge"].ToString() != "")
                    {
                        model.Charge = int.Parse(dt.Rows[n]["Charge"].ToString());
                    }
                    if (dt.Rows[n]["On_off"].ToString() != "")
                    {
                        model.On_off = int.Parse(dt.Rows[n]["On_off"].ToString());
                    }
                    model.Say = dt.Rows[n]["Say"].ToString();
                    if (dt.Rows[n]["Time"].ToString() != "")
                    {
                        model.Time = DateTime.Parse(dt.Rows[n]["Time"].ToString());
                    }
                    if (dt.Rows[n]["Agio"].ToString() != "")
                    {
                        model.Agio = decimal.Parse(dt.Rows[n]["Agio"].ToString());
                    }
                    if (dt.Rows[n]["Price"].ToString() != "")
                    {
                        model.Price = decimal.Parse(dt.Rows[n]["Price"].ToString());
                    }
                    model.IssueTime = dt.Rows[n]["IssueTime"].ToString();
                    if (dt.Rows[n]["Commend"].ToString() != "")
                    {
                        model.Commend = int.Parse(dt.Rows[n]["Commend"].ToString());
                    }
                    if (dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    if (dt.Rows[n]["Confine"].ToString() != "")
                    {
                        model.Confine = int.Parse(dt.Rows[n]["Confine"].ToString());
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
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: zhouwei
        /// ����ʱ��: 2010-10-27
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_appendItem", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  ��Ա����
    }
}
