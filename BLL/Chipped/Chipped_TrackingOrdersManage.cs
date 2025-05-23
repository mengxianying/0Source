using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Collections.Generic;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���Chipped_TrackingOrders ��ժҪ˵����
    /// </summary>
    public class Chipped_TrackingOrders
    {
        private static readonly IChipped_TrackingOrders dal = DataAccess.CreateChipped_TrackingOrders();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Chipped_TrackingOrders", "TrackingID");
        public Chipped_TrackingOrders()
        { }
        #region  Method
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int TrackingID)
        {
            return dal.Exists(TrackingID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Chipped_TrackingOrders model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_TrackingOrders model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int TrackingID)
        {

            return dal.Delete(TrackingID);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string TrackingIDlist)
        {
            return dal.DeleteList(TrackingIDlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Chipped_TrackingOrders GetModel(int TrackingID)
        {

            return dal.GetModel(TrackingID);
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
        public List<Pbzx.Model.Chipped_TrackingOrders> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Chipped_TrackingOrders> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Chipped_TrackingOrders> modelList = new List<Pbzx.Model.Chipped_TrackingOrders>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Chipped_TrackingOrders model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Chipped_TrackingOrders();
                    if (dt.Rows[n]["TrackingID"].ToString() != "")
                    {
                        model.TrackingID = int.Parse(dt.Rows[n]["TrackingID"].ToString());
                    }
                    model.UserN = dt.Rows[n]["UserN"].ToString();
                    if (dt.Rows[n]["TrackingLNum"].ToString() != "")
                    {
                        model.TrackingLNum = int.Parse(dt.Rows[n]["TrackingLNum"].ToString());
                    }
                    model.TrackingName = dt.Rows[n]["TrackingName"].ToString();
                    if (dt.Rows[n]["TrackingTime"].ToString() != "")
                    {
                        model.TrackingTime = DateTime.Parse(dt.Rows[n]["TrackingTime"].ToString());
                    }
                    if (dt.Rows[n]["SubscribeNum"].ToString() != "")
                    {
                        model.SubscribeNum = int.Parse(dt.Rows[n]["SubscribeNum"].ToString());
                    }
                    if (dt.Rows[n]["BuyMoney"].ToString() != "")
                    {
                        model.BuyMoney = decimal.Parse(dt.Rows[n]["BuyMoney"].ToString());
                    }
                    if (dt.Rows[n]["TrackingState"].ToString() != "")
                    {
                        model.TrackingState = int.Parse(dt.Rows[n]["TrackingState"].ToString());
                    }
                    if (dt.Rows[n]["TrackingN"].ToString() != "")
                    {
                        model.TrackingN = int.Parse(dt.Rows[n]["TrackingN"].ToString());
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
        /// ����ʱ��: 2011-03-21
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchTracking(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Chipped_TrackingOrders", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  ��Ա����
    }
}


