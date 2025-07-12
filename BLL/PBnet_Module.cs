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
    /// ҵ���߼���PBnet_Module ��ժҪ˵����
    /// </summary>
    public class PBnet_Module
    {
        private readonly Pbzx.SQLServerDAL.PBnet_Module dal = new Pbzx.SQLServerDAL.PBnet_Module();// Pbzx.SQLServerDAL.PBnet_Module();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_Module", "ID");
        public PBnet_Module()
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
        public bool Add(Pbzx.Model.PBnet_Module model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_Module model)
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
        public Pbzx.Model.PBnet_Module GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_Module GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_ModuleModel-" + ID;
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
            return (Pbzx.Model.PBnet_Module)objModel;
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
        public List<Pbzx.Model.PBnet_Module> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_Module> modelList = new List<Pbzx.Model.PBnet_Module>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Module model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Module();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.URL = dt.Rows[n]["URL"].ToString();
                    model.LinkUrl = dt.Rows[n]["LinkUrl"].ToString();
                    if (dt.Rows[n]["Depth"].ToString() != "")
                    {
                        model.Depth = int.Parse(dt.Rows[n]["Depth"].ToString());
                    }
                    if (dt.Rows[n]["RootID"].ToString() != "")
                    {
                        model.RootID = int.Parse(dt.Rows[n]["RootID"].ToString());
                    }
                    if (dt.Rows[n]["FlagMenu"].ToString() != "")
                    {
                        model.FlagMenu = int.Parse(dt.Rows[n]["FlagMenu"].ToString());
                    }
                    if (dt.Rows[n]["Sort"].ToString() != "")
                    {
                        model.Sort = int.Parse(dt.Rows[n]["Sort"].ToString());
                    }
                    if (dt.Rows[n]["Format"].ToString() != "")
                    {
                        model.Format = int.Parse(dt.Rows[n]["Format"].ToString());
                    }
                    if (dt.Rows[n]["IsHome"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsHome"].ToString() == "1") || (dt.Rows[n]["IsHome"].ToString().ToLower() == "true"))
                        {
                            model.IsHome = true;
                        }
                        else
                        {
                            model.IsHome = false;
                        }
                    }
                    if (dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    model.TempID = dt.Rows[n]["TempID"].ToString();
                    if (dt.Rows[n]["AllSort"].ToString() != "")
                    {
                        model.AllSort = int.Parse(dt.Rows[n]["AllSort"].ToString());
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
        public DataTable GetListBySort()
        {

            return dal.GetLisBySql("SELECT * FROM PBnet_Module ORDER BY RootID asc,Depth asc ,Sort ASC");
        }

        public DataTable GetRootList()
        {
            return dal.GetLisBySql("SELECT * FROM PBnet_Module WHERE Depth=0 and FlagMenu=1 order by Sort asc ");
        }

        public DataTable GetRootList(bool showAll)
        {
            if (showAll)
            {
                return dal.GetLisBySql("SELECT * FROM PBnet_Module WHERE Depth=0 order by Sort asc ");
            }
            else
            {
                return dal.GetLisBySql("SELECT * FROM PBnet_Module WHERE Depth=0 and FlagMenu=1 order by Sort asc ");
            }
           
        }


        public int GetURLCount(string strUrl)
        {
            return Convert.ToInt32(dal.GetValue("COUNT(ID) AS CT", "URL='" + strUrl + "'", "CT"));
        }

        /// <summary>
        /// ������²����ID.
        /// </summary>
        public int GetInsertID()
        {
            return Convert.ToInt32(dal.GetValue("TOP 1 ID", "", " ID DESC"));
        }
        #endregion

        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ���</param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>
        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_Module", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// ����ID�õ�url
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetUrlByID(int id)
        {
            string url = "";
            Model.PBnet_Module m = GetModel(id);
            if (m != null)
            {
                url = GetModel(id).URL;
            }
            return url;

        }
    }
}

