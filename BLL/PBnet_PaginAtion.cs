using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using Pbzx.Common;
using System.Text;
using System.Collections;
namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类PBnet_PaginAtion 的摘要说明。
    /// </summary>
    public class PBnet_PaginAtion
    {
        private readonly Pbzx.IDAL.IPBnet_PaginAtion  dal = DataAccess.CreatePBnet_PaginAtion();
        public PBnet_PaginAtion()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PaginationID)
        {
            return dal.Exists(PaginationID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_PaginAtion model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.PBnet_PaginAtion model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int PaginationID)
        {

            dal.Delete(PaginationID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_PaginAtion GetModel(int PaginationID)
        {

            return dal.GetModel(PaginationID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_PaginAtion GetModelByCache(int PaginationID)
        {

            string CacheKey = "PBnet_PaginAtionModel-" + PaginationID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(PaginationID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_PaginAtion)objModel;
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
        public List<Pbzx.Model.PBnet_PaginAtion> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_PaginAtion> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_PaginAtion> modelList = new List<Pbzx.Model.PBnet_PaginAtion>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_PaginAtion model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_PaginAtion();
                    if (dt.Rows[n]["PaginationID"].ToString() != "")
                    {
                        model.PaginationID = int.Parse(dt.Rows[n]["PaginationID"].ToString());
                    }
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
                    model.PhysicPath = dt.Rows[n]["PhysicPath"].ToString();
                    model.FileName = dt.Rows[n]["FileName"].ToString();
                    model.Suffix = dt.Rows[n]["Suffix"].ToString();
                    if (dt.Rows[n]["PageNo"].ToString() != "")
                    {
                        model.PageNo = int.Parse(dt.Rows[n]["PageNo"].ToString());
                    }
                    if (dt.Rows[n]["PageType"].ToString() != "")
                    {
                        model.PageType = int.Parse(dt.Rows[n]["PageType"].ToString());
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

        #region 新闻内容分页
        /// <summary>
        /// 添加分页数据
        /// </summary>
        public int PaginationCreate(Pbzx.Model.PBnet_PaginAtion paginAtionInfo)
        {            
            try
            {
                return dal.PaginationCreate(paginAtionInfo);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// 根据新闻ID删除分页
        /// </summary>
        /// <param name="id">新闻ID</param>
        /// <param name="moduletype">新闻类型</param>
        public void PaginationDelete(int id, EModuleType moduletype)
        {
            try
            {
                dal.PaginationDelete(id, moduletype);
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 根据新闻ID获取分页数据
        /// </summary>
        /// <param name="id">新闻ID</param>
        /// <param name="moduletype">新闻类型</param>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_PaginAtion> PaginationGet(int id, EModuleType moduletype)
        {
            try
            {
                return dal.PaginationGet(id, moduletype);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据ID获取新闻网页地址
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="moduletype">类型</param>
        /// <returns></returns>
        public string PaginationGetUrl(int id, EModuleType moduletype)
        {
            try
            {
                return PaginationGet(id, moduletype)[0].FilePath.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }


        /// <summary>
        /// 根据分页标志拆分数据
        /// </summary>
        /// <param name="source">要分隔的字符</param>
        /// <returns>string[]</returns>
        public string[] PaginationContent(string source)
        {
            if (source.IndexOf(WebInit.webBaseConfig.PaginAtion) > -1)
            {
                string split = WebInit.webBaseConfig.PaginAtion;
                int len = split.Length;
                ArrayList al = new ArrayList();
                int start = 0; //开始位置
                int j = -1; //匹配索引位置
                while (true)
                {
                    j = source.IndexOf(split, start);
                    if (j > -1)
                    {
                        al.Add(source.Substring(start, j - start));
                        int s = j - start;
                        start = j + len;
                    }
                    else
                    {
                        al.Add(source.Substring(start));
                        break;
                    }
                }
                string[] result;
                if (al.Count == 0)
                {
                    string[] r = new string[1];
                    r[0] = source;
                    result = r;
                }
                else
                {
                    string[] r = new string[al.Count];
                    for (int i = 0; i < al.Count; i++)
                    {
                        r[i] = al[i].ToString();
                    }
                    result = r;
                }
                return result;
            }
            else
                return null;
        }



        /// <summary>
        /// 生成分页字符串
        /// </summary>
        /// <param name="PageUrls">所有分页地址</param>
        /// <param name="CurrentPage">当前页数</param>
        /// <param name="PageCount">所有页数</param>
        /// <param name="paginationDIV">分页样式</param>
        /// <param name="disablepageDIV">失效页样式</param>
        /// <param name="currentpageDIV">当前页样式</param>
        /// <param name="nextpageDIV">翻页样式</param>
        /// <returns>分页字符串，如果为空，则分页数不大于1</returns>
        public string CreatePagination(ArrayList PageUrls, int CurrentPage, int PageCount, string paginationDIV, string disablepageDIV, string currentpageDIV, string nextpageDIV)
        {
            if (PageCount > 1)
            {
                StringBuilder sb = new StringBuilder();
                string FirstPageUrl = "";
                string LastPageUrl = "";
                if (CurrentPage == 1)
                {
                    LastPageUrl = PageUrls[CurrentPage].ToString();
                }
                else if (CurrentPage == PageCount)
                {
                }
                else
                {
                    FirstPageUrl = PageUrls[CurrentPage - 1].ToString();
                    LastPageUrl = PageUrls[CurrentPage].ToString();
                }


                sb.Append("<div class='" + paginationDIV + "'><ul>");
                if (CurrentPage == 1)
                {
                    sb.Append("<li class='" + disablepageDIV + "'>上一页</li>");
                }
                else if (CurrentPage == PageCount)
                {
                    FirstPageUrl = PageUrls[PageCount - 2].ToString();
                    sb.Append(@"<li class='" + nextpageDIV + "'> <a href='" + FirstPageUrl + "'>上一页</a></li>");
                }
                else
                {
                    FirstPageUrl = PageUrls[CurrentPage - 2].ToString();
                    sb.Append(@"<li class='" + nextpageDIV + "'><a href='" + FirstPageUrl + "'>上一页</a></li>");
                }

                for (int i = 1; i <= PageCount; i++)
                {
                    if (CurrentPage == i)
                    {
                        sb.Append(@"<li class='" + currentpageDIV + "'>" + i + "</li>");
                    }
                    else
                    {
                        sb.Append(@"<li><a href='" + PageUrls[i - 1].ToString() + "'>" + i + "</a></li>");
                    }
                }

                if (CurrentPage == 1)
                {
                    LastPageUrl = PageUrls[CurrentPage].ToString();
                    sb.Append(@"<li class='" + nextpageDIV + "'><a href='" + LastPageUrl + "'>下一页</a></li>");
                }
                else if (CurrentPage == PageCount)
                {
                    sb.Append("<li class='" + disablepageDIV + "'>下一页</li>");
                }
                else
                {
                    LastPageUrl = PageUrls[CurrentPage].ToString();
                    sb.Append(@"<li class='" + nextpageDIV + "'><a href='" + LastPageUrl + "'>下一页</a></li>");
                }
                sb.Append("</div>");
                return sb.ToString();
            }
            else
                return null;
        }
        #endregion
    }
}

