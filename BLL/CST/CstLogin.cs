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
    /// ҵ���߼���CstLogin ��ժҪ˵����
    /// </summary>
    public class CstLogin
    {
        private readonly ICstLogin dal = DataAccess.CreateCstLogin();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CstLogin", "ID");
        public CstLogin()
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
        public int Add(Pbzx.Model.CstLogin model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.CstLogin model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {

            dal.Delete(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.CstLogin GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.CstLogin GetModelByCache(int ID)
        {

            string CacheKey = "CstLoginModel-" + ID;
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
            return (Pbzx.Model.CstLogin)objModel;
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
        public List<Pbzx.Model.CstLogin> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CstLogin> modelList = new List<Pbzx.Model.CstLogin>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CstLogin model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CstLogin();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.HDSN = ds.Tables[0].Rows[n]["HDSN"].ToString();
                    model.RN = ds.Tables[0].Rows[n]["RN"].ToString();
                    if (ds.Tables[0].Rows[n]["SoftwareType"].ToString() != "")
                    {
                        model.SoftwareType = int.Parse(ds.Tables[0].Rows[n]["SoftwareType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["InstallType"].ToString() != "")
                    {
                        model.InstallType = int.Parse(ds.Tables[0].Rows[n]["InstallType"].ToString());
                    }
                    model.Version = ds.Tables[0].Rows[n]["Version"].ToString();
                    model.OSVersion = ds.Tables[0].Rows[n]["OSVersion"].ToString();
                    if (ds.Tables[0].Rows[n]["LoginTime"].ToString() != "")
                    {
                        model.LoginTime = DateTime.Parse(ds.Tables[0].Rows[n]["LoginTime"].ToString());
                    }
                    model.IP = ds.Tables[0].Rows[n]["IP"].ToString();
                    if (ds.Tables[0].Rows[n]["LoginCount"].ToString() != "")
                    {
                        model.LoginCount = int.Parse(ds.Tables[0].Rows[n]["LoginCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["TotalCount"].ToString() != "")
                    {
                        model.TotalCount = int.Parse(ds.Tables[0].Rows[n]["TotalCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["FirstLoginTime"].ToString() != "")
                    {
                        model.FirstLoginTime = DateTime.Parse(ds.Tables[0].Rows[n]["FirstLoginTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["AginTime"].ToString() != "")
                    {
                        model.AginTime = DateTime.Parse(ds.Tables[0].Rows[n]["AginTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["HDSNType"].ToString() != "")
                    {
                        model.HDSNType = int.Parse(ds.Tables[0].Rows[n]["HDSNType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ExpireDate"].ToString() != "")
                    {
                        model.ExpireDate = DateTime.Parse(ds.Tables[0].Rows[n]["ExpireDate"].ToString());
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
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         
        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "CstLogin", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// <summary>
        /// ������²����ID.
        /// </summary>
        public int GetInsertID()
        {
            return Convert.ToInt32(basicDAL.GetValue("TOP 1 ID", "", " ID DESC"));
        }
    }
}

