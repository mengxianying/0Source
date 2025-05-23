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
    /// ҵ���߼���FC4DData_ShangH ��ժҪ˵����
    /// </summary>
    public class FC4DData_ShangH
    {
        private readonly IFC4DData_ShangH dal = DataAccess.CreateFC4DData_ShangH();
        public FC4DData_ShangH()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(string issue)
        {
            return dal.Exists(issue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.FC4DData_ShangH model)
        {
            return dal.Add(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.FC4DData_ShangH model)
        {
            return dal.Update(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(string issue)
        {

            return dal.Delete(issue) > 0 ? true : false; 
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.FC4DData_ShangH GetModel(string issue)
        {

            return dal.GetModel(issue);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.FC4DData_ShangH GetModelByCache(string issue)
        {

            string CacheKey = "FC4DData_ShangHModel-" + issue;
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
            return (Pbzx.Model.FC4DData_ShangH)objModel;
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
        public List<Pbzx.Model.FC4DData_ShangH> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.FC4DData_ShangH> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.FC4DData_ShangH> modelList = new List<Pbzx.Model.FC4DData_ShangH>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.FC4DData_ShangH model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.FC4DData_ShangH();
                     if (dt.Rows[n]["date"].ToString() != "")
                    {
                        model.date = DateTime.Parse(dt.Rows[n]["date"].ToString());
                    }
                //    model.issueSeq = int.Parse(dt.Rows[n][issueSeq].ToString());
                    model.issue = dt.Rows[n]["issue"].ToString();
                    model.code = dt.Rows[n]["code"].ToString();

                    if (dt.Rows[n]["LastModifyTime"].ToString() != "")
                    {
                        model.LastModifyTime = DateTime.Parse(dt.Rows[n]["LastModifyTime"].ToString());
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

