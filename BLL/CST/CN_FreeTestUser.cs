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
    /// 业务逻辑类CN_FreeTestUser 的摘要说明。
    /// </summary>
    public class CN_FreeTestUser
    {
        private readonly ICN_FreeTestUser dal = DataAccess.CreateCN_FreeTestUser();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CN_FreeTestUser", "ID");


        public CN_FreeTestUser()
        {
            basicDAL.IsCst = true;
        }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.CN_FreeTestUser model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.CN_FreeTestUser model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CN_FreeTestUser GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.CN_FreeTestUser GetModelByCache(int ID)
        {

            string CacheKey = "CN_FreeTestUserModel-" + ID;
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
            return (Pbzx.Model.CN_FreeTestUser)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.CN_FreeTestUser> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CN_FreeTestUser> modelList = new List<Pbzx.Model.CN_FreeTestUser>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CN_FreeTestUser model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CN_FreeTestUser();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.HDSN = ds.Tables[0].Rows[n]["HDSN"].ToString();
                    model.DiskCVol = ds.Tables[0].Rows[n]["DiskCVol"].ToString();
                    if (ds.Tables[0].Rows[n]["SoftwareType"].ToString() != "")
                    {
                        model.SoftwareType = int.Parse(ds.Tables[0].Rows[n]["SoftwareType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["InstallType"].ToString() != "")
                    {
                        model.InstallType = int.Parse(ds.Tables[0].Rows[n]["InstallType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["FirstLoginTime"].ToString() != "")
                    {
                        model.FirstLoginTime = DateTime.Parse(ds.Tables[0].Rows[n]["FirstLoginTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["LastLoginTime"].ToString() != "")
                    {
                        model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[n]["LastLoginTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UseCount"].ToString() != "")
                    {
                        model.UseCount = int.Parse(ds.Tables[0].Rows[n]["UseCount"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["LastLoginID"].ToString() != "")
                    {
                        model.LastLoginID = int.Parse(ds.Tables[0].Rows[n]["LastLoginID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ServiceID"].ToString() != "")
                    {
                        model.ServiceID = int.Parse(ds.Tables[0].Rows[n]["ServiceID"].ToString());
                    }
                    model.LastLoginIP = ds.Tables[0].Rows[n]["LastLoginIP"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "CN_FreeTestUser", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
    }
}

