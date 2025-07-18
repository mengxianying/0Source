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
    /// 业务逻辑类CL_PrintLine 的摘要说明。
    /// </summary>
    public class CL_PrintLine
    {
        private readonly ICL_PrintLine dal = DataAccess.CreateCL_PrintLine();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CL_PrintLine", "ID");
        public CL_PrintLine()
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
        public bool Add(Pbzx.Model.CL_PrintLine model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.CL_PrintLine model)
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
        public Pbzx.Model.CL_PrintLine GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.CL_PrintLine GetModelByCache(int ID)
        {

            string CacheKey = "CL_PrintLineModel-" + ID;
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
            return (Pbzx.Model.CL_PrintLine)objModel;
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
        public List<Pbzx.Model.CL_PrintLine> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CL_PrintLine> modelList = new List<Pbzx.Model.CL_PrintLine>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CL_PrintLine model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CL_PrintLine();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.SN = ds.Tables[0].Rows[n]["SN"].ToString();
                    if (ds.Tables[0].Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[n]["CreateTime"].ToString());
                    }
                    model.Creator = ds.Tables[0].Rows[n]["Creator"].ToString();
                    if (ds.Tables[0].Rows[n]["AcceptTime"].ToString() != "")
                    {
                        model.AcceptTime = DateTime.Parse(ds.Tables[0].Rows[n]["AcceptTime"].ToString());
                    }
                    model.Accepter = ds.Tables[0].Rows[n]["Accepter"].ToString();
                    if (ds.Tables[0].Rows[n]["SellTime"].ToString() != "")
                    {
                        model.SellTime = DateTime.Parse(ds.Tables[0].Rows[n]["SellTime"].ToString());
                    }
                    model.Seller = ds.Tables[0].Rows[n]["Seller"].ToString();
                    if (ds.Tables[0].Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(ds.Tables[0].Rows[n]["Status"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(ds.Tables[0].Rows[n]["Type"].ToString());
                    }
                    model.Remarks = ds.Tables[0].Rows[n]["Remarks"].ToString();
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
        #region 自定义方法
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
        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "CL_PrintLine", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        public Pbzx.Model.CL_PrintLine GetModelBySN(string sn)
        {
            List<Pbzx.Model.CL_PrintLine> ls = GetModelList(" SN='"+sn+"' ");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 执行SQL获取数据列表.
        /// </summary>
        public DataTable GetLisBySql(string strSql)
        {
            return basicDAL.GetLisBySql(strSql);
        }

        //public string GetTotalMoney(string where)
        //{
        //    string result = "";
        //    string sql = "select count(ID) as TotalID,sum(PayMoney) as TotalMoney from [RegisterInfo2]";
        //    if (!string.IsNullOrEmpty(where))
        //    {
        //        sql += " where " + where;
        //    }
        //    DataSet ds = dal.Query(sql);
        //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        result = ds.Tables[0].Rows[0]["TotalID"] + "&" + ds.Tables[0].Rows[0]["TotalMoney"];
        //    }
        //    else
        //    {
        //        result = "0&0";
        //    }
        //    return result;
        //}


        #endregion
    }
}

