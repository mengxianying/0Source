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
    /// ҵ���߼���FCPL5Data_HeB ��ժҪ˵����
    /// </summary>
    public class FCPL5Data_HeB
    {
        private readonly IFCPL5Data_HeB dal = DataAccess.CreateFCPL5Data_HeB();
        public FCPL5Data_HeB()
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
        public bool Exists(int issue)
        {
            return dal.Exists(issue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.FCPL5Data_HeB model)
        {
            return dal.Add(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.FCPL5Data_HeB model)
        {
            return dal.Update(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int issue)
        {

           return dal.Delete(issue) > 0 ? true : false; 
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.FCPL5Data_HeB GetModel(string issue)
        {

            return dal.GetModel(issue);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.FCPL5Data_HeB GetModelByCache(string  issue)
        {

            string CacheKey = "FCPL5Data_HeBModel-" + issue;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(issue);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.FCPL5Data_HeB)objModel;
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
        public List<Pbzx.Model.FCPL5Data_HeB> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.FCPL5Data_HeB> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.FCPL5Data_HeB> modelList = new List<Pbzx.Model.FCPL5Data_HeB>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.FCPL5Data_HeB model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.FCPL5Data_HeB();
                    if (dt.Rows[n]["date"].ToString() != "")
                    {
                        model.date = DateTime.Parse(dt.Rows[n]["date"].ToString());
                    }
                    model.issue =int.Parse(dt.Rows[n]["issue"].ToString());
                    model.code = dt.Rows[n]["code"].ToString();

                    if (dt.Rows[n]["LastModifytime"].ToString() != "")
                    {
                        model.LastModifytime = DateTime.Parse(dt.Rows[n]["LastModifyTime"].ToString());
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

