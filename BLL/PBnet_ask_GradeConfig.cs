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
    /// ҵ���߼���PBnet_ask_GradeConfig ��ժҪ˵����
    /// </summary>
    public class PBnet_ask_GradeConfig
    {
        private readonly IPBnet_ask_GradeConfig dal = DataAccess.CreatePBnet_ask_GradeConfig();
        public PBnet_ask_GradeConfig()
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
        public bool Add(Pbzx.Model.PBnet_ask_GradeConfig model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_ask_GradeConfig model)
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
        public Pbzx.Model.PBnet_ask_GradeConfig GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_ask_GradeConfig GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_ask_GradeConfigModel-" + ID;
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
            return (Pbzx.Model.PBnet_ask_GradeConfig)objModel;
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
        public List<Pbzx.Model.PBnet_ask_GradeConfig> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_ask_GradeConfig> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_ask_GradeConfig> modelList = new List<Pbzx.Model.PBnet_ask_GradeConfig>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_ask_GradeConfig model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_ask_GradeConfig();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.GradeName = dt.Rows[n]["GradeName"].ToString();
                    if (dt.Rows[n]["MinPoint"].ToString() != "")
                    {
                        model.MinPoint = int.Parse(dt.Rows[n]["MinPoint"].ToString());
                    }
                    if (dt.Rows[n]["MaxPoint"].ToString() != "")
                    {
                        model.MaxPoint = int.Parse(dt.Rows[n]["MaxPoint"].ToString());
                    }
                    model.GradeID = dt.Rows[n]["GradeID"].ToString();
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

