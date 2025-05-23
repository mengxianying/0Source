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
    /// ҵ���߼���FCSSCData_XinJ ��ժҪ˵����
    /// </summary>
    public class FCSSCData_XinJ
    {
        private readonly IFCSSCData_XinJ dal = DataAccess.CreateFCSSCData_XinJ();
        public FCSSCData_XinJ()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Issue)
        {
            return dal.Exists(Issue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.FCSSCData_XinJ model)
        {
            return dal.Add(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.FCSSCData_XinJ model)
        {
            return dal.Add(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int Issue)
        {
            return dal.Delete(Issue) > 0 ? true : false; 
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.FCSSCData_XinJ GetModel(int Issue)
        {

            return dal.GetModel(Issue);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.FCSSCData_XinJ GetModelByCache(int Issue)
        {

            string CacheKey = "FCSSCData_XinJModel-" + Issue;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Issue);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.FCSSCData_XinJ)objModel;
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
        public List<Pbzx.Model.FCSSCData_XinJ> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.FCSSCData_XinJ> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.FCSSCData_XinJ> modelList = new List<Pbzx.Model.FCSSCData_XinJ>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.FCSSCData_XinJ model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.FCSSCData_XinJ();
                    if (dt.Rows[n]["Issue"].ToString() != "")
                    {
                        model.Issue = int.Parse(dt.Rows[n]["Issue"].ToString());
                    }
                    if (dt.Rows[n]["date"].ToString() != "")
                    {
                        model.date = DateTime.Parse(dt.Rows[n]["date"].ToString());
                    }
                    model.Code = dt.Rows[n]["Code"].ToString();
                    if (dt.Rows[n]["LastModifytime"].ToString() != "")
                    {
                        model.LastModifytime = DateTime.Parse(dt.Rows[n]["LastModifytime"].ToString());
                    }
                    model.OpName = dt.Rows[n]["OpName"].ToString();
                    model.OpIp = dt.Rows[n]["OpIp"].ToString();
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
    }
}

