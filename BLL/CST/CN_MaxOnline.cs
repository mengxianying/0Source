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
    /// ҵ���߼���CN_MaxOnline ��ժҪ˵����
    /// </summary>
    public class CN_MaxOnline
    {
        private readonly ICN_MaxOnline dal = DataAccess.CreateCN_MaxOnline();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CN_MaxOnline", "ID");
        public CN_MaxOnline()
        {
            basicDAL.IsCst = true;
        }
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
        public bool Add(Pbzx.Model.CN_MaxOnline model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.CN_MaxOnline model)
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
        public Pbzx.Model.CN_MaxOnline GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.CN_MaxOnline GetModelByCache(int ID)
        {

            string CacheKey = "CN_MaxOnlineModel-" + ID;
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
            return (Pbzx.Model.CN_MaxOnline)objModel;
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
        public List<Pbzx.Model.CN_MaxOnline> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CN_MaxOnline> modelList = new List<Pbzx.Model.CN_MaxOnline>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CN_MaxOnline model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CN_MaxOnline();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["SoftwareType"].ToString() != "")
                    {
                        model.SoftwareType = int.Parse(ds.Tables[0].Rows[n]["SoftwareType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["InstallType"].ToString() != "")
                    {
                        model.InstallType = int.Parse(ds.Tables[0].Rows[n]["InstallType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["MaxCount"].ToString() != "")
                    {
                        model.MaxCount = int.Parse(ds.Tables[0].Rows[n]["MaxCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["RecodeTime"].ToString() != "")
                    {
                        model.RecodeTime = DateTime.Parse(ds.Tables[0].Rows[n]["RecodeTime"].ToString());
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
        public int GetCountm()
        {
            return int.Parse(basicDAL.GetValueBySql("select top 1 MaxCount  from CN_MaxOnline Order By MaxCount  Desc").ToString());

        }
        public string GetName()
        {
            return basicDAL.GetValueBySql("select top 1 RecodeTime  from CN_MaxOnline Order By MaxCount  Desc").ToString();

        }
        public Pbzx.Model.CN_MaxOnline GetModelByType(string sfType,string insType)
        {
            List<Pbzx.Model.CN_MaxOnline> ls = GetModelList(" SoftwareType=" + sfType + " and InstallType=" + insType + " ");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }
    }
}

