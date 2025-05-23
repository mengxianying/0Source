using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Text;
using System.Data.SqlClient;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���CN_User ��ժҪ˵����
    /// </summary>
    public class CN_User
    {
        private readonly ICN_User dal = DataAccess.CreateCN_User();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CN_User", "ID");

        public CN_User()
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
        public bool Add(Pbzx.Model.CN_User model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.CN_User model)
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
        public Pbzx.Model.CN_User GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.CN_User GetModelByCache(int ID)
        {

            string CacheKey = "CN_UserModel-" + ID;
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
            return (Pbzx.Model.CN_User)objModel;
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
        public List<Pbzx.Model.CN_User> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CN_User> modelList = new List<Pbzx.Model.CN_User>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CN_User model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CN_User();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.Username = ds.Tables[0].Rows[n]["Username"].ToString();
                    if (ds.Tables[0].Rows[n]["SoftwareType"].ToString() != "")
                    {
                        model.SoftwareType = int.Parse(ds.Tables[0].Rows[n]["SoftwareType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["InstallType"].ToString() != "")
                    {
                        model.InstallType = int.Parse(ds.Tables[0].Rows[n]["InstallType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UserType"].ToString() != "")
                    {
                        model.UserType = int.Parse(ds.Tables[0].Rows[n]["UserType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ExpireDate"].ToString() != "")
                    {
                        model.ExpireDate = DateTime.Parse(ds.Tables[0].Rows[n]["ExpireDate"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ValidDays"].ToString() != "")
                    {
                        model.ValidDays = int.Parse(ds.Tables[0].Rows[n]["ValidDays"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[n]["CreateTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["LastPayTime"].ToString() != "")
                    {
                        model.LastPayTime = DateTime.Parse(ds.Tables[0].Rows[n]["LastPayTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UseCount"].ToString() != "")
                    {
                        model.UseCount = int.Parse(ds.Tables[0].Rows[n]["UseCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["LastLoginID"].ToString() != "")
                    {
                        model.LastLoginID = int.Parse(ds.Tables[0].Rows[n]["LastLoginID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ServiceID"].ToString() != "")
                    {
                        model.ServiceID = int.Parse(ds.Tables[0].Rows[n]["ServiceID"].ToString());
                    }
                    model.HDSNList = ds.Tables[0].Rows[n]["HDSNList"].ToString();
                    if (ds.Tables[0].Rows[n]["StatResult"].ToString() != "")
                    {
                        model.StatResult = int.Parse(ds.Tables[0].Rows[n]["StatResult"].ToString());
                    }
                    model.UserRemarks = ds.Tables[0].Rows[n]["UserRemarks"].ToString();
                    model.Remarks = ds.Tables[0].Rows[n]["Remarks"].ToString();
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


        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "CN_User", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

    }
}
