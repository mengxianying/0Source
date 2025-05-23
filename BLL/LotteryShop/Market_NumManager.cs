using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using Pbzx.Model;

namespace Pbzx.BLL
{

    /// <summary>
    /// ҵ���߼���Market_Num ��ժҪ˵����
    /// </summary>
    public class Market_NumManager
    {
        private readonly IMarket_Num dal = DataAccess.CreateIMarket_Num();

        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Market_Num", "id");

        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        /// <summary>
        /// ���ط���
        /// ������: zhouwei
        /// ����ʱ��: 2010-11-25
        /// </summary>
        /// <param name="id">��ĿID</param>
        /// <param name="expctNum">�ں�</param>
        /// <returns></returns>
        public bool Exists(int id, string expctNum, string radio)
        {
            return dal.Exists(id, expctNum, radio);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Market_Num model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.Market_Num model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int id)
        {

            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Market_Num GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.Market_Num GetModelByCache(int id)
        {

            string CacheKey = "Market_NumModel-" + id;
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
            return (Pbzx.Model.Market_Num)objModel;
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
        public List<Pbzx.Model.Market_Num> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Market_Num> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Market_Num> modelList = new List<Pbzx.Model.Market_Num>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Market_Num model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Market_Num();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["ItemID"].ToString() != "")
                    {
                        model.ItemID = int.Parse(dt.Rows[n]["ItemID"].ToString());
                    }
                    model.ExpectNum = dt.Rows[n]["ExpectNum"].ToString();
                    model.appendName = dt.Rows[n]["appendName"].ToString();
                    model.IssueTime = dt.Rows[n]["IssueTime"].ToString();
                    if (dt.Rows[n]["Commend"].ToString() != "")
                    {
                        model.Commend = int.Parse(dt.Rows[n]["Commend"].ToString());
                    }
                    model.Content = dt.Rows[n]["Content"].ToString();
                    if (dt.Rows[n]["itemidentity"].ToString() != "")
                    {
                        model.itemidentity = int.Parse(dt.Rows[n]["itemidentity"].ToString());
                    }
                    model.itemradio = dt.Rows[n]["itemradio"].ToString();
                    model.itemcheck = dt.Rows[n]["itemcheck"].ToString();
                    model.itemnumber = dt.Rows[n]["itemnumber"].ToString();
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
        /// ����ʱ��: 2010-11-10
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchNum(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Market_Num", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        /// <summary>
        /// �н���Ԥ���н��Ա�
        /// </summary>
        /// <param name="AwardIssue">�н�����</param>
        /// <param name="ForeIssue">Ԥ���ں�</param>
        /// 
        public void ExistsAward(string AwardNumber, string ForeIssue)
        {
            //�����ںţ��õ�Ԥ������������Ϣ

            //��Ԥ�������н�����Ա�
            //��������ͬ��������ʱ��������ʶΪ�н�
        }

        #endregion  ��Ա����
    }
}
