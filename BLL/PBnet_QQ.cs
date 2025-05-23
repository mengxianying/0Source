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
    /// ҵ���߼���PBnet_QQ ��ժҪ˵����
    /// </summary>
    public class PBnet_QQ
    {
        private readonly IPBnet_QQ dal = DataAccess.CreatePBnet_QQ();
        public PBnet_QQ()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int IntId)
        {
            return dal.Exists(IntId);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_QQ model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_QQ model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int IntId)
        {

            return dal.Delete(IntId) > 0 ? true : false;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_QQ GetModel(int IntId)
        {

            return dal.GetModel(IntId);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_QQ GetModelByCache(int IntId)
        {

            string CacheKey = "PBnet_QQModel-" + IntId;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(IntId);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_QQ)objModel;
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
        public List<Pbzx.Model.PBnet_QQ> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_QQ> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_QQ> modelList = new List<Pbzx.Model.PBnet_QQ>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_QQ model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_QQ();
                    if (dt.Rows[n]["IntId"].ToString() != "")
                    {
                        model.IntId = int.Parse(dt.Rows[n]["IntId"].ToString());
                    }
                    model.VarQQNumber = dt.Rows[n]["VarQQNumber"].ToString();
                    model.VarName = dt.Rows[n]["VarName"].ToString();
                    if (dt.Rows[n]["IntDisplayPosition"].ToString() != "")
                    {
                        model.IntDisplayPosition = int.Parse(dt.Rows[n]["IntDisplayPosition"].ToString());
                    }
                    if (dt.Rows[n]["IntOrderID"].ToString() != "")
                    {
                        model.IntOrderID = int.Parse(dt.Rows[n]["IntOrderID"].ToString());
                    }
                    if (dt.Rows[n]["BitIsAuditing"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsAuditing"].ToString() == "1") || (dt.Rows[n]["BitIsAuditing"].ToString().ToLower() == "true"))
                        {
                            model.BitIsAuditing = true;
                        }
                        else
                        {
                            model.BitIsAuditing = false;
                        }
                    }
                    model.Team = dt.Rows[n]["Team"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
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
