using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;

namespace Pbzx.BLL
{
    public class PBnet_Group
    {
        private readonly Pbzx.SQLServerDAL.PBnet_Group dal = new Pbzx.SQLServerDAL.PBnet_Group();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_Group", "ID");
        public PBnet_Group()
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
        public bool Add(Pbzx.Model.PBnet_Group model)
        {
            return dal.Add(model) > 0 ? true : false; 
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_Group model)
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
        public Pbzx.Model.PBnet_Group GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_Group GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_GroupModel-" + ID;
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
            return (Pbzx.Model.PBnet_Group)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_Group> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.PBnet_Group> modelList = new List<Pbzx.Model.PBnet_Group>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Group model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Group();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.GroupName = ds.Tables[0].Rows[n]["GroupName"].ToString();
                    if (ds.Tables[0].Rows[n]["Authority"].ToString() != "")
                    {
                        model.Authority = (byte[])ds.Tables[0].Rows[n]["Authority"];
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

        #region �Զ��巽��
        public object GetAuthorityByName(string strGroupName)
        {

            return basicDAL.GetValue("Authority", "GroupName='" + strGroupName + "'", "");
        }
        #endregion
    }
}
