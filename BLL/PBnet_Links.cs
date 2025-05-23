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
    /// 业务逻辑类PBnet_Links 的摘要说明。
    /// </summary>
    public class PBnet_Links
    {
        private readonly IPBnet_Links dal = DataAccess.CreatePBnet_Links();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_Links", "IntID");
        public PBnet_Links()
        { }
        #region  成员方法


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int IntID)
        {
            return dal.Exists(IntID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_Links model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_Links model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int IntID)
        {

            return dal.Delete(IntID) > 0 ? true : false;
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Links GetModel(int IntID)
        {

            return dal.GetModel(IntID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_Links GetModelByCache(int IntID)
        {

            string CacheKey = "PBnet_LinksModel-" + IntID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(IntID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_Links)objModel;
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
        public List<Pbzx.Model.PBnet_Links> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_Links> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_Links> modelList = new List<Pbzx.Model.PBnet_Links>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Links model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Links();
                    if (dt.Rows[n]["IntID"].ToString() != "")
                    {
                        model.IntID = int.Parse(dt.Rows[n]["IntID"].ToString());
                    }
                    if (dt.Rows[n]["IntLinkType"].ToString() != "")
                    {
                        model.IntLinkType = int.Parse(dt.Rows[n]["IntLinkType"].ToString());
                    }
                    model.IntSiteName = dt.Rows[n]["IntSiteName"].ToString();
                    model.NteSiteUrl = dt.Rows[n]["NteSiteUrl"].ToString();
                    model.NteSiteIntro = dt.Rows[n]["NteSiteIntro"].ToString();
                    model.NteLogoUrl = dt.Rows[n]["NteLogoUrl"].ToString();
                    model.NvarSiteAdmin = dt.Rows[n]["NvarSiteAdmin"].ToString();
                    model.NvarEmail = dt.Rows[n]["NvarEmail"].ToString();
                    model.NvarSitePassword = dt.Rows[n]["NvarSitePassword"].ToString();
                    if (dt.Rows[n]["BitIsGood"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsGood"].ToString() == "1") || (dt.Rows[n]["BitIsGood"].ToString().ToLower() == "true"))
                        {
                            model.BitIsGood = true;
                        }
                        else
                        {
                            model.BitIsGood = false;
                        }
                    }
                    if (dt.Rows[n]["BitIsOK"].ToString() != "")
                    {
                        model.BitIsOK = Convert.ToInt32(dt.Rows[n]["BitIsOK"].ToString());

                        //if ((dt.Rows[n]["BitIsOK"].ToString() == "1") || (dt.Rows[n]["BitIsOK"].ToString().ToLower() == "true"))
                        //{
                        //    model.BitIsOK = true;
                        //}
                        //else
                        //{
                        //    model.BitIsOK = false;
                        //}
                    }
                    if (dt.Rows[n]["ModifyTime"].ToString() != "")
                    {
                        model.ModifyTime = DateTime.Parse(dt.Rows[n]["ModifyTime"].ToString());
                    }
                    if (dt.Rows[n]["SortOrder"].ToString() != "")
                    {
                        model.SortOrder = int.Parse(dt.Rows[n]["SortOrder"].ToString());
                    }
                    model.QQ = dt.Rows[n]["QQ"].ToString();
                    model.Tel = dt.Rows[n]["Tel"].ToString();
                    model.Remark = dt.Rows[n]["Remark"].ToString();
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

        #region Delete:删除友情链接.
        /// <summary>
        /// 删除友情链接.
        /// </summary>
        /// <param name="linkid">多个ID.</param>
        /// <returns>被删除的记录数.</returns>
        public int Delete(string linkid)
        {
            return dal.Delete(linkid);
        }
        #endregion

        #region OK:审核友情链接.
        /// <summary>
        /// 审核友情链接.
        /// </summary>
        /// <param name="linkid">多个ID.</param>
        /// <returns>被审核友情链接记录数.</returns>
        public int Auditing(string linkid)
        {
            return dal.Auditing(linkid);
        }
        #endregion


        #region No:审核友情链接.
        /// <summary>
        /// 不审核友情链接.
        /// </summary>
        /// <param name="linkid">多个ID.</param>
        /// <returns>不被审核友情链接记录数.</returns>
        public int NoAuditing(string linkid)
        {
            return dal.NoAuditing(linkid);
        }
        #endregion





        /// <summary>
        /// 根据查询字符串获取分页数据
        /// </summary>
        /// <param name="SearchStr">查询字符串</param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>
        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_Links", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        #endregion

        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_Links", "IntID");
            basicDAL1.ChangeAudit(id, filed);
        }
        ///// <summary>
        ///// 比较并返回两个MusicEntry对象的排列次序
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <returns></returns>
        //private int CompareProductEntry(Pbzx.Model.PBnet_Links x, Pbzx.Model.PBnet_Links y)
        //{
        //    return  x.SortOrder.CompareTo(y.SortOrder);
        //}

        /// <summary>
        /// 得到排序后友情链接列表
        /// </summary>
        /// <returns></returns>
        //public List<Pbzx.Model.PBnet_Links> GetProductListSort(string strWhere)
        //{
        //    if(strWhere == null)
        //    {
        //        strWhere = "";
        //    }
        //    List<Pbzx.Model.PBnet_Links> data = GetModelList(strWhere);
        //    if (data.Count > 1)
        //    {
        //        Pbzx.Model.PBnet_Links productM = new Pbzx.Model.PBnet_Links();
        //        data.Sort(productM);
        //    }
        //    return data;
        //}


    }
}

