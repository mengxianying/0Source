using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    
    public class Chipped_InfoManage
    {
        private readonly IChipped_Info dal = DataAccess.CreateIChipped_Info();

        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Chipped_info", "QNumber");
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
        public int Add(Pbzx.Model.Chipped_Info model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.Chipped_Info model)
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
        public int Delete(string QNumber, string username)
        {
            return dal.Delete(QNumber,username);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Chipped_Info GetModel(string QNumber)
        {

            return dal.GetModel(QNumber);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.Chipped_Info GetModelByCache(string QNumber)
        {

            string CacheKey = "Chipped_infoModel-" + QNumber;
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
            return (Pbzx.Model.Chipped_Info)objModel;
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
        public List<Pbzx.Model.Chipped_Info> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Chipped_Info> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Chipped_Info> modelList = new List<Pbzx.Model.Chipped_Info>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Chipped_Info model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Chipped_Info();
                    model.QNumber = dt.Rows[n]["QNumber"].ToString();
                    model.ChippedName = dt.Rows[n]["ChippedName"].ToString();
                    if (dt.Rows[n]["ChippedShare"].ToString() != "")
                    {
                        model.ChippedShare = int.Parse(dt.Rows[n]["ChippedShare"].ToString());
                    }
                    if (dt.Rows[n]["ChippedTime"].ToString() != "")
                    {
                        model.ChippedTime = DateTime.Parse(dt.Rows[n]["ChippedTime"].ToString());
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

        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: xiaowei
        /// ����ʱ��: 2011-03-01
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchChipped_Info(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Chipped_info", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
    }
}
