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
    /// 业务逻辑类PBnet_LyBook 的摘要说明。
    /// </summary>
    public class PBnet_LyBook
    {
        private readonly IPBnet_LyBook dal = DataAccess.CreatePBnet_LyBook();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_LyBook", "SystemNumber");
        public PBnet_LyBook()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SystemNumber)
        {
            return dal.Exists(SystemNumber);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_LyBook model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_LyBook model)
        {
           return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SystemNumber)
        {

            return dal.Delete(SystemNumber) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_LyBook GetModel(int SystemNumber)
        {

            return dal.GetModel(SystemNumber);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_LyBook GetModelByCache(int SystemNumber)
        {

            string CacheKey = "PBnet_LyBookModel-" + SystemNumber;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(SystemNumber);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_LyBook)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_LyBook> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_LyBook> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_LyBook> modelList = new List<Pbzx.Model.PBnet_LyBook>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_LyBook model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_LyBook();
                    if (dt.Rows[n]["SystemNumber"].ToString() != "")
                    {
                        model.SystemNumber = int.Parse(dt.Rows[n]["SystemNumber"].ToString());
                    }
                    model.LyUserName = dt.Rows[n]["LyUserName"].ToString();
                    if (dt.Rows[n]["LyUserID"].ToString() != "")
                    {
                        model.LyUserID = int.Parse(dt.Rows[n]["LyUserID"].ToString());
                    }
                    if (dt.Rows[n]["LySort"].ToString() != "")
                    {
                        model.LySort = int.Parse(dt.Rows[n]["LySort"].ToString());
                    }
                    model.Ly_Phone = dt.Rows[n]["Ly_Phone"].ToString();
                    model.Ly_Email = dt.Rows[n]["Ly_Email"].ToString();
                    model.LyContent = dt.Rows[n]["LyContent"].ToString();
                    if (dt.Rows[n]["LyState"].ToString() != "")
                    {
                        model.LyState = int.Parse(dt.Rows[n]["LyState"].ToString());
                    }
                    if (dt.Rows[n]["LyLogTime"].ToString() != "")
                    {
                        model.LyLogTime = DateTime.Parse(dt.Rows[n]["LyLogTime"].ToString());
                    }
                    model.LyLogIp = dt.Rows[n]["LyLogIp"].ToString();
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

        //public static string GetType(object nType)
        //{
        //    string type = "";
        //    int intType = int.Parse(nType.ToString());
        //    switch (intType)
        //    {
        //        case 1:
        //            type = "问题咨询";
        //            break;
        //        case 2:
        //            type = "建议";
        //            break;
        //        case 3:
        //            type = "其他";
        //            break;
        //        default:
        //            type = "<font color=red>未知</font>";
        //            break;

        //    }
        //    return type.ToString();
        //}



        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_LyBook", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// 根据查询字符串获取分页数据
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>
        public DataTable GuestGetBySearch2(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_LyBook", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_LyBook", "SystemNumber");
            basicDAL1.ChangeAudit(id, filed);
        }
    }
}

