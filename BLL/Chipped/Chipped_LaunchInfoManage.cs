using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;


namespace Pbzx.BLL
{
    public class Chipped_LaunchInfoManage
    {
        private readonly IChipped_LaunchInfo dal = DataAccess.CreateIChipped_LaunchInfo();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Chipped_LaunchInfo", "QNumber");

        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string QNumber)
        {
            return dal.Exists(QNumber);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.chipped_LaunchInfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.chipped_LaunchInfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(string QNumber)
        {

           return dal.Delete(QNumber);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.chipped_LaunchInfo GetModel(string QNumber)
        {

            return dal.GetModel(QNumber);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.chipped_LaunchInfo GetModelByCache(string QNumber)
        {

            string CacheKey = "Chipped_LaunchInfoModel-" + QNumber;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(QNumber);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.chipped_LaunchInfo)objModel;
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
        public List<Pbzx.Model.chipped_LaunchInfo> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.chipped_LaunchInfo> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.chipped_LaunchInfo> modelList = new List<Pbzx.Model.chipped_LaunchInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.chipped_LaunchInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.chipped_LaunchInfo();
                    model.QNumber = dt.Rows[n]["QNumber"].ToString();
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.Say = dt.Rows[n]["Say"].ToString();
                    if (dt.Rows[n]["LaunchTime"].ToString() != "")
                    {
                        model.LaunchTime = DateTime.Parse(dt.Rows[n]["LaunchTime"].ToString());
                    }
                    if (dt.Rows[n]["playName"].ToString() != "")
                    {
                        model.playName = int.Parse(dt.Rows[n]["playName"].ToString());
                    }
                    if (dt.Rows[n]["ExpectNum"].ToString() != "")
                    {
                        model.ExpectNum = int.Parse(dt.Rows[n]["ExpectNum"].ToString());
                    }
                    model.ChoiceNum = dt.Rows[n]["ChoiceNum"].ToString();
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    if (dt.Rows[n]["doubles"].ToString() != "")
                    {
                        model.doubles = int.Parse(dt.Rows[n]["doubles"].ToString());
                    }
                    if (dt.Rows[n]["Share"].ToString() != "")
                    {
                        model.Share = int.Parse(dt.Rows[n]["Share"].ToString());
                    }
                    model.Object = dt.Rows[n]["Object"].ToString();
                    if (dt.Rows[n]["BuyShare"].ToString() != "")
                    {
                        model.BuyShare = int.Parse(dt.Rows[n]["BuyShare"].ToString());
                    }
                    if (dt.Rows[n]["Protect"].ToString() != "")
                    {
                        model.Protect = int.Parse(dt.Rows[n]["Protect"].ToString());
                    }
                    if (dt.Rows[n]["opens"].ToString() != "")
                    {
                        model.opens = int.Parse(dt.Rows[n]["opens"].ToString());
                    }
                    if (dt.Rows[n]["Commission"].ToString() != "")
                    {
                        model.Commission = int.Parse(dt.Rows[n]["Commission"].ToString());
                    }
                    if (dt.Rows[n]["Winning"].ToString() != "")
                    {
                        model.Winning = int.Parse(dt.Rows[n]["Winning"].ToString());
                    }
                    if (dt.Rows[n]["Purchasing"].ToString() != "")
                    {
                        model.Purchasing = int.Parse(dt.Rows[n]["Purchasing"].ToString());
                    }
                    if (dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    if (dt.Rows[n]["AtotalMoney"].ToString() != "")
                    {
                        model.AtotalMoney = decimal.Parse(dt.Rows[n]["AtotalMoney"].ToString());
                    }
                    model.bounsAllost = dt.Rows[n]["bounsAllost"].ToString();
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
        /// ����ʱ��: 2011-02-28
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchChipped(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Chipped_LaunchInfo", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  ��Ա����
    }
}
