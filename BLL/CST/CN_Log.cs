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
    /// 业务逻辑类CN_Log 的摘要说明。
    /// </summary>
    public class CN_Log
    {

        private readonly ICN_Log dal = DataAccess.CreateCN_Log();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CN_Log", "ID");
        public CN_Log()
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
        public bool Add(Pbzx.Model.CN_Log model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.CN_Log model)
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
        public Pbzx.Model.CN_Log GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.CN_Log GetModelByCache(int ID)
        {

            string CacheKey = "CN_LogModel-" + ID;
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
            return (Pbzx.Model.CN_Log)objModel;
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
        public List<Pbzx.Model.CN_Log> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CN_Log> modelList = new List<Pbzx.Model.CN_Log>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CN_Log model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CN_Log();
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
                    model.ProgramVer = ds.Tables[0].Rows[n]["ProgramVer"].ToString();
                    model.HDSN = ds.Tables[0].Rows[n]["HDSN"].ToString();
                    model.RN = ds.Tables[0].Rows[n]["RN"].ToString();
                    model.IP = ds.Tables[0].Rows[n]["IP"].ToString();
                    if (ds.Tables[0].Rows[n]["Port"].ToString() != "")
                    {
                        model.Port = int.Parse(ds.Tables[0].Rows[n]["Port"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["StartTime"].ToString() != "")
                    {
                        model.StartTime = DateTime.Parse(ds.Tables[0].Rows[n]["StartTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["EndTime"].ToString() != "")
                    {
                        model.EndTime = DateTime.Parse(ds.Tables[0].Rows[n]["EndTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["LoginMutex"].ToString() != "")
                    {
                        model.LoginMutex = int.Parse(ds.Tables[0].Rows[n]["LoginMutex"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ServiceID"].ToString() != "")
                    {
                        model.ServiceID = int.Parse(ds.Tables[0].Rows[n]["ServiceID"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UserIndex"].ToString() != "")
                    {
                        model.UserIndex = int.Parse(ds.Tables[0].Rows[n]["UserIndex"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UseType"].ToString() != "")
                    {
                        model.UseType = int.Parse(ds.Tables[0].Rows[n]["UseType"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["UseValue"].ToString() != "")
                    {
                        model.UseValue = int.Parse(ds.Tables[0].Rows[n]["UseValue"].ToString());
                    }
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "CN_Log", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
     
    }
}

