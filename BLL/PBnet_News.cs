using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Text;
using Pbzx.Common;
using System.Collections;
using System.IO;
using System.Configuration;
namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类PBnet_News 的摘要说明。
    /// </summary>
    public class PBnet_News
    {
        private readonly IPBnet_News dal = DataAccess.CreatePBnet_News();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_News", "IntID");
        public PBnet_News()
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
        public bool Add(Pbzx.Model.PBnet_News model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_News model)
        {
            if (!model.BitIsPass)
            {
                if (!string.IsNullOrEmpty(model.SavePath))
                {
                    string htmlPath = System.Web.HttpContext.Current.Server.MapPath(model.SavePath);
                    if (File.Exists(htmlPath))
                    {
                        File.Delete(htmlPath);
                    }
                }   
            }
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int IntID)
        {
            if (!string.IsNullOrEmpty(GetModel(IntID).SavePath))
            {
                string htmlPath = System.Web.HttpContext.Current.Server.MapPath(GetModel(IntID).SavePath);
                if (File.Exists(htmlPath))
                {
                    File.Delete(htmlPath);
                }
            }
            return dal.Delete(IntID) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_News GetModel(int IntID)
        {

            return dal.GetModel(IntID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_News GetModelByCache(int IntID)
        {

            string CacheKey = "PBnet_NewsModel-" + IntID;
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
            return (Pbzx.Model.PBnet_News)objModel;
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
        public List<Pbzx.Model.PBnet_News> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_News> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_News> modelList = new List<Pbzx.Model.PBnet_News>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_News model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_News();
                    if (dt.Rows[n]["IntID"].ToString() != "")
                    {
                        model.IntID = int.Parse(dt.Rows[n]["IntID"].ToString());
                    }
                    model.NvarTitle = dt.Rows[n]["NvarTitle"].ToString();
                    model.NvarShortTitle = dt.Rows[n]["NvarShortTitle"].ToString();
                    model.NteContent = dt.Rows[n]["NteContent"].ToString();
                    model.NvarAuthor = dt.Rows[n]["NvarAuthor"].ToString();
                    if (dt.Rows[n]["DatDateAndTime"].ToString() != "")
                    {
                        model.DatDateAndTime = DateTime.Parse(dt.Rows[n]["DatDateAndTime"].ToString());
                    }
                    if (dt.Rows[n]["IntChannelID"].ToString() != "")
                    {
                        model.IntChannelID = int.Parse(dt.Rows[n]["IntChannelID"].ToString());
                    }
                    if (dt.Rows[n]["IntShowType"].ToString() != "")
                    {
                        model.IntShowType = int.Parse(dt.Rows[n]["IntShowType"].ToString());
                    }
                    if (dt.Rows[n]["BitIsPass"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsPass"].ToString() == "1") || (dt.Rows[n]["BitIsPass"].ToString().ToLower() == "true"))
                        {
                            model.BitIsPass = true;
                        }
                        else
                        {
                            model.BitIsPass = false;
                        }
                    }
                    if (dt.Rows[n]["BitIsTop"].ToString() != "")
                    {
                        model.BitIsTop = int.Parse(dt.Rows[n]["BitIsTop"].ToString());
                    }
                    if (dt.Rows[n]["BitIsHot"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsHot"].ToString() == "1") || (dt.Rows[n]["BitIsHot"].ToString().ToLower() == "true"))
                        {
                            model.BitIsHot = true;
                        }
                        else
                        {
                            model.BitIsHot = false;
                        }
                    }
                    model.IntDisPosition = dt.Rows[n]["IntDisPosition"].ToString();
                    if (dt.Rows[n]["IntClick"].ToString() != "")
                    {
                        model.IntClick = int.Parse(dt.Rows[n]["IntClick"].ToString());
                    }
                    model.VarPicUrl = dt.Rows[n]["VarPicUrl"].ToString();
                    model.VarOperator = dt.Rows[n]["VarOperator"].ToString();
                    if (dt.Rows[n]["IntOrderID"].ToString() != "")
                    {
                        model.IntOrderID = int.Parse(dt.Rows[n]["IntOrderID"].ToString());
                    }
                    model.NKey = dt.Rows[n]["NKey"].ToString();
                    model.Metadesc = dt.Rows[n]["Metadesc"].ToString();
                    model.Source = dt.Rows[n]["Source"].ToString();
                    model.SourceUrl = dt.Rows[n]["SourceUrl"].ToString();
                    model.Attribute = dt.Rows[n]["Attribute"].ToString();
                    model.RandomFileName = dt.Rows[n]["RandomFileName"].ToString();
                    if (dt.Rows[n]["EffectDate"].ToString() != "")
                    {
                        model.EffectDate = DateTime.Parse(dt.Rows[n]["EffectDate"].ToString());
                    }
                    model.Templet = dt.Rows[n]["Templet"].ToString();
                    model.SavePath = dt.Rows[n]["SavePath"].ToString();
                    model.FileEXName = dt.Rows[n]["FileEXName"].ToString();
                    if (dt.Rows[n]["IsStatic"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsStatic"].ToString() == "1") || (dt.Rows[n]["IsStatic"].ToString().ToLower() == "true"))
                        {
                            model.IsStatic = true;
                        }
                        else
                        {
                            model.IsStatic = false;
                        }
                    }
                    if (dt.Rows[n]["PageNum"].ToString() != "")
                    {
                        model.PageNum = int.Parse(dt.Rows[n]["PageNum"].ToString());
                    }
                    if (dt.Rows[n]["ShowIndex"].ToString() != "")
                    {
                        if ((dt.Rows[n]["ShowIndex"].ToString() == "1") || (dt.Rows[n]["ShowIndex"].ToString().ToLower() == "true"))
                        {
                            model.ShowIndex = true;
                        }
                        else
                        {
                            model.ShowIndex = false;
                        }
                    }
                    if (dt.Rows[n]["ShowInSoft"].ToString() != "")
                    {
                        if ((dt.Rows[n]["ShowInSoft"].ToString() == "1") || (dt.Rows[n]["ShowInSoft"].ToString().ToLower() == "true"))
                        {
                            model.ShowInSoft = true;
                        }
                        else
                        {
                            model.ShowInSoft = false;
                        }
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



        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public static void ChangeAudit(int id, string filed)
        {
            //if (strTableName == "PBnet_News" || strTableName == "PBnet_School" ||strTableName == "PBnet_Bulletin")
            //{
            //    if( filed == "BitIsPass" )
            //    string[] ids = strID.Split(new char[] { ',' });
            //    foreach (string id in ids)
            //    {
            //        int IntID = 0;
            //        if (int.TryParse(id, out IntID))
            //        {
            //            if (!string.IsNullOrEmpty(GetModel(IntID).SavePath))
            //            {
            //                string htmlPath = System.Web.HttpContext.Current.Server.MapPath(GetModel(IntID).SavePath);
            //                if (File.Exists(htmlPath))
            //                {
            //                    File.Delete(htmlPath);
            //                }
            //            }
            //        }
            //    }
            //}

            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_News", "IntID");
            basicDAL1.ChangeAudit(id, filed);
        }

        /// <summary>
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_News", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// <summary>
        /// 根据ＩＤ批量删除删除数据
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchDel(string strID)
        {
            string[] ids= strID.Split(new char[] { ',' });


            foreach (string id in ids)
            {
                int IntID =0;
                if (int.TryParse(id, out IntID))
                {
                    if (!string.IsNullOrEmpty(GetModel(IntID).SavePath))
                    {
                        string htmlPath = System.Web.HttpContext.Current.Server.MapPath(GetModel(IntID).SavePath);
                        if (File.Exists(htmlPath))
                        {
                            File.Delete(htmlPath);
                        }
                    }
                }
            }

            string sql = "DELETE FROM PBnet_News WHERE IntID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }


        /// <summary>
        /// 根据ＩＤ批量删除html文件
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchDelHtml(string strID)
        {
            string[] ids = strID.Split(new char[] { ',' });

            int DelCount = 0;
            foreach (string id in ids)
            {
                int IntID = 0;
                if (int.TryParse(id, out IntID))
                {
                    if (!string.IsNullOrEmpty(GetModel(IntID).SavePath))
                    {
                        string htmlPath = System.Web.HttpContext.Current.Server.MapPath(GetModel(IntID).SavePath);
                        if (File.Exists(htmlPath))
                        {
                            File.Delete(htmlPath);
                            DelCount++;
                        }
                    }
                }
            }
            return DelCount;
        }

        /// <summary>
        /// 根据ＩＤ批量更新数据
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchUpdate(string strID, string column, bool isTrue)
        {
            int i = isTrue ? 1 : 0;

            if (!isTrue && column == "BitIsPass")
            {
                string[] ids = strID.Split(new char[] { ',' });
                foreach (string id in ids)
                {
                    int IntID = 0;
                    if (int.TryParse(id, out IntID))
                    {
                        if (!string.IsNullOrEmpty(GetModel(IntID).SavePath))
                        {
                            string htmlPath = System.Web.HttpContext.Current.Server.MapPath(GetModel(IntID).SavePath);
                            if (File.Exists(htmlPath))
                            {
                                File.Delete(htmlPath);
                            }
                        }
                    }
                }
            }

            string sql = "update PBnet_News set " + column + "=" + i + " WHERE IntID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }


        /// <summary>
        /// 根据ＩＤ批量更新固顶
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchUpdateTop(string strID, string column, int intnum)
        {

            string sql = "update PBnet_News set " + column + "=" + intnum + " WHERE IntID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }
        /// <summary>
        /// 根据查询条件，和需要返回的条数返回结果集
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="count">返回的条数</param>
        /// <returns>结果集</returns>
        public DataTable GetTitleListByCount(string strWhere, int count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + count + " IntID,NvarTitle,NvarShortTitle,NteContent,NvarAuthor,DatDateAndTime,IntChannelID,IntShowType,BitIsPass,BitIsTop,BitIsHot,IntDisPosition,IntClick,VarPicUrl,VarOperator,IntOrderID,NKey,Metadesc,Source,SourceUrl,Attribute,RandomFileName,EffectDate,Templet,SavePath,FileEXName,IsStatic,PageNum ");
            strSql.Append(" FROM PBnet_News ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return dal.Query(strSql.ToString());
        }
        #region 生成静态页

        /// <summary>
        /// 新闻创建
        /// </summary>
        /// <param name="moduleinfo">新闻信息</param>
        /// <returns>返回新闻ID</returns>
        public int ArticleCreate(Pbzx.Model.PBnet_News articleinfo)
        {
            int res = 0;
            try
            {
                //获取分页数组
                Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();
                string[] ContentStr = bpa.PaginationContent(articleinfo.NteContent);
                if (ContentStr != null)
                {
                    articleinfo.PageNum = ContentStr.Length;
                }
                //获取随机文件名
                articleinfo.RandomFileName = BasicProcedure.RandomCreateFileName(0);
                //创建新闻
                articleinfo.IntID = dal.Add(articleinfo);
                //创建分页
                ArticleCreatePaginAtion(articleinfo);
                //创建新闻文件
                if (!articleinfo.IsStatic)
                {
                    CreateContentFileByTemplate(articleinfo.IntID);
                }
                res = articleinfo.IntID;
            }
            catch (Exception ex)
            {
                res = 0;
            }
            return res;
        }

        /// <summary>
        /// 新闻编辑
        /// </summary>
        /// <param name="moduleinfo">频道信息</param>
        /// <returns>返回bool</returns>
        public bool ArticleUpdate(Pbzx.Model.PBnet_News articleinfo)
        {

            bool flag = true;
            //try
            //{
            Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();
            //删除新闻文件
            ArticleDeleteFile(articleinfo.IntID);
            //删除分页数据

            bpa.PaginationDelete(articleinfo.IntID, EModuleType.News);
            //更新新闻
            string[] ContentStr = bpa.PaginationContent(articleinfo.NteContent);
            if (ContentStr != null)
            {
                articleinfo.PageNum = ContentStr.Length;
            }
            dal.Update(articleinfo);
            //创建新闻
            ArticleCreatePaginAtion(articleinfo);
            //创建新闻文件
            //if (articleinfo.IsStatic)
            //{
            CreateContentFileByTemplate(articleinfo.IntID);
            //}
            //}
            //catch (Exception)
            //{
            //    flag = false;
            //}
            return flag;
        }

        /// <summary>
        /// 根据新闻ID删除
        /// </summary>
        /// <param name="moduleinfo">模块信息</param>
        /// <returns>返回bool</returns>
        public bool ArticleDelete(int articleID)
        {
            bool flag = true;
            try
            {
                Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();
                //删除新闻文件
                ArticleDeleteFile(articleID);
                //删除分页数据
                bpa.PaginationDelete(articleID, EModuleType.News);
                //删除数据文件
                dal.Delete(articleID);
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 批量删除新闻
        /// </summary>
        /// <param name="articleID">新闻ID（","为分隔符)</param>
        public void ArticleDelete(string articleID)
        {
            try
            {
                if (!string.IsNullOrEmpty(articleID))
                {
                    string[] articleIDs = articleID.Split(new char[] { ',' });

                    for (int i = 0; i < articleIDs.Length; i++)
                    {
                        ArticleDelete(Convert.ToInt32(articleIDs[i].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据模块ID删除新闻
        /// </summary>
        /// <param name="moduleid">模块ID</param>
        /// <returns>返回bool</returns>
        public bool ArticleDeleteByModuleID(int moduleid)
        {

            bool flag = true;
            try
            {
                IList<Pbzx.Model.PBnet_News> ais = ArticleGetByModuleID(moduleid);
                if (ais.Count > 0)
                {
                    foreach (Pbzx.Model.PBnet_News ai in ais)
                    {
                        ArticleDelete(ai.IntID);
                    }
                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;

        }

        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_News> ArticleGetAll()
        {
            try
            {
                return DataTableToList(dal.GetList("").Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据新闻ID获取数据
        /// </summary>
        /// <param name="ArticleID">新闻ID</param>
        /// <returns></returns>
        public Pbzx.Model.PBnet_News ArticleGetByID(int ArticleID)
        {
            try
            {
                return dal.GetModel(ArticleID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据模块ID获取数据
        /// </summary>
        /// <param name="ModuleID">模块ID</param>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_News> ArticleGetByModuleID(int ModuleID)
        {
            try
            {
                return DataTableToList(dal.GetList(" IntShowType='" + ModuleID + "'").Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 根据关键字获取数据
        /// </summary>
        /// <param name="NKeyStr">关键字符串</param>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_News> ArticleGetByNKey(string NKeyStr)
        {
            try
            {
                return DataTableToList(dal.GetList(" NKey like'%" + NKeyStr + "%'").Tables[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 根据查询字符串获取分页数据
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="SearchStr">查询字符串</param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_News> ArticleGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            try
            {
                if (String.IsNullOrEmpty(SearchStr))
                    SearchStr = "";
                return DataTableToList(basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_News", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts));
            }
            catch (Exception ex)
            {
                Counts = 0;
                return null;
            }
        }




        /// <summary>
        /// 新闻标志(为bit类型)取反
        /// </summary>
        /// <param name="FlagField">标志字段名</param>
        /// <param name="id">新闻ID</param>
        public void ArticleFlagUpdate(string FlagField, int id)
        {
            try
            {
                ChangeAudit(id, FlagField);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="FlagField"></param>
        /// <param name="id"></param>
        public void ArticleAudit(int id)
        {
            try
            {
                ArticleFlagUpdate("BitIsPass", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //创建分页数据
        public void ArticleCreatePaginAtion(Pbzx.Model.PBnet_News articleinfo)
        {
            try
            {
                Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();
                Pbzx.BLL.PBnet_NewsType bc = new PBnet_NewsType();

                string ArticleUrl = articleinfo.DatDateAndTime.Year.ToString() + "/" + articleinfo.DatDateAndTime.Month.ToString() + "/"; //bc.ChannelGetFolder((int)articleinfo.IntShowType);
                for (int i = 1; i <= articleinfo.PageNum; i++)
                {
                    Pbzx.Model.PBnet_PaginAtion pai = new Pbzx.Model.PBnet_PaginAtion();

                    pai.ID = articleinfo.IntID;
                    if (string.IsNullOrEmpty(articleinfo.RandomFileName))
                    {
                        //获取随机文件名
                        articleinfo.RandomFileName = BasicProcedure.RandomCreateFileName(0);
                    }
                    pai.FileName = articleinfo.RandomFileName + i + ".htm";
                    pai.PhysicPath = BasicProcedure.PhysicalApplicationPath + WebInit.webFolderConfig.ArticleUrl + ArticleUrl + pai.FileName;
                    pai.FilePath = WebInit.webBaseConfig.WebUrl + WebInit.webFolderConfig.ArticleUrl + ArticleUrl + pai.FileName;
                    pai.PageNo = i;
                    pai.Suffix = "htm";
                    pai.PageType = (int)EModuleType.News;
                    bpa.PaginationCreate(pai);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //删除分页数据
        public void ArticleDeleteFile(int Articleid)
        {
            try
            {
                BTemplate bt = new BTemplate();
                Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();
                IList<Pbzx.Model.PBnet_PaginAtion> pais = bpa.PaginationGet(Articleid, EModuleType.News);
                if (pais.Count > 0)
                {
                    foreach (Pbzx.Model.PBnet_PaginAtion pai in pais)
                    {
                        bt.DeleteFile(pai.PhysicPath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 批量生成文件
        /// </summary>
        /// <param name="Articleid">文件ID，多个用","隔开</param>
        public void CreateContentFileByTemplate(string Articleid)
        {
            try
            {
                if (!string.IsNullOrEmpty(Articleid))
                {
                    string[] articleIDs = Articleid.Split(new char[] { ',' });

                    for (int i = 0; i < articleIDs.Length; i++)
                    {
                        CreateContentFileByTemplate(Convert.ToInt32(articleIDs[i].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 全部生成文件
        /// </summary>
        public void CreateAllArticleFile()
        {
            try
            {
                List<Pbzx.Model.PBnet_News> ais = ArticleGetAll();
                if (ais.Count > 0)
                {
                    foreach (Pbzx.Model.PBnet_News ai in ais)
                    {
                        CreateContentFileByTemplate(ai.IntID);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 根据模板生成新闻
        /// </summary>
        /// <param name="TemplateFile">模板地址</param>
        /// <param name="CreateFile">生成地址</param>
        /// <param name="articleInfo">新闻信息</param>
        public void CreateContentFileByTemplate(int Articleid)
        {
            try
            {
                Pbzx.Model.PBnet_News articleInfo = ArticleGetByID(Articleid);
                BTemplate bt = new BTemplate();
                Pbzx.BLL.PBnet_PaginAtion bpa = new Pbzx.BLL.PBnet_PaginAtion();
                Pbzx.BLL.PBnet_NewsType bc = new PBnet_NewsType();
                //模板地址
                string TemplateFile = BasicProcedure.PhysicalApplicationPath + "/" + WebInit.webFolderConfig.TemplateUrl + "/" + "Articleshow.htm";
                //文件地址


                string CreateFile = BasicProcedure.PhysicalApplicationPath + "/" + WebInit.webFolderConfig.ArticleUrl + articleInfo.DatDateAndTime.Year.ToString() + "/" + articleInfo.DatDateAndTime.Month + "/"; //bc.ChannelGetFolder((int)articleInfo.IntShowType)

                if (articleInfo.IsStatic)
                {
                    ArticleDeleteFile(Articleid);
                }

                //更新标志位
                if (!articleInfo.IsStatic)
                {
                    //ArticleFlagUpdate("IsStatic", articleInfo.IntID);
                    articleInfo.IsStatic = true;
                }
                if (string.IsNullOrEmpty(articleInfo.RandomFileName))
                {
                    articleInfo.RandomFileName = BasicProcedure.RandomCreateFileName(0);
                }

                //替换内容标签
                string TemplateContent = ReplaceLabel(bt.GetTemplateContent(TemplateFile), articleInfo);
                if (articleInfo.PageNum == null)
                {
                    articleInfo.PageNum = 1;
                }
                //如果信息没有分页
                if (articleInfo.PageNum == 1)
                {
                    TemplateContent = TemplateContent.Replace("{$Content$}", articleInfo.NteContent);
                    TemplateContent = TemplateContent.Replace("{$NextPage$}", "");
                    if (bpa.PaginationGet(articleInfo.IntID, EModuleType.News).Count < 1)
                    {
                        string[] ContentStr = bpa.PaginationContent(articleInfo.NteContent);
                        if (ContentStr != null)
                        {
                            articleInfo.PageNum = ContentStr.Length;
                        }
                        ArticleCreatePaginAtion(articleInfo);
                    }
                    List<Pbzx.Model.PBnet_PaginAtion> pai = bpa.PaginationGet(articleInfo.IntID, EModuleType.News);
                    bt.CreateFile(CreateFile + pai[0].FileName, TemplateContent);
                    articleInfo.Templet = TemplateFile;
                    articleInfo.SavePath = "/" + WebInit.webFolderConfig.ArticleUrl + articleInfo.DatDateAndTime.Year.ToString() + "/" + articleInfo.DatDateAndTime.Month + "/" + pai[0].FileName;
                    Update(articleInfo);
                }
                else//如果信息有分页
                {
                    //获取分页内容
                    string[] Contents = bpa.PaginationContent(articleInfo.NteContent);
                    //获取分页信息
                    if (bpa.PaginationGet(articleInfo.IntID, EModuleType.News).Count < 1)
                    {
                        if (Contents != null)
                        {
                            articleInfo.PageNum = Contents.Length;
                        }
                        ArticleCreatePaginAtion(articleInfo);
                    }
                    List<Pbzx.Model.PBnet_PaginAtion> pai = bpa.PaginationGet(articleInfo.IntID, EModuleType.News);
                    ArrayList stringPages = new ArrayList();
                    for (int i = 0; i < pai.Count; i++)
                    {
                        stringPages.Add(pai[i].FilePath);
                    }
                    //生成分页文件
                    for (int i = 1; i <= articleInfo.PageNum; i++)
                    {
                        string nextpage = bpa.CreatePagination(stringPages, i, (int)articleInfo.PageNum, "pagination", "disablepage", "currentpage", "nextpage");
                        string tc = TemplateContent.Replace("{$NextPage$}", nextpage);
                        tc = tc.Replace("{$Content$}", Contents[i - 1].ToString());
                        //创建分页文件
                        bt.CreateFile(CreateFile + pai[i - 1].FileName.ToString(), tc);
                        articleInfo.Templet = TemplateFile;
                        articleInfo.SavePath = "/" + WebInit.webFolderConfig.ArticleUrl + articleInfo.DatDateAndTime.Year.ToString() + "/" + articleInfo.DatDateAndTime.Month + "/" + pai[i - 1].FileName;
                        Update(articleInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 替换标签
        /// </summary>
        /// <param name="TemplateContent"></param>
        /// <returns></returns>
        public string ReplaceLabel(string TemplateContent, Pbzx.Model.PBnet_News articleInfo)
        {
            if (!string.IsNullOrEmpty(articleInfo.VarPicUrl))
            {
                TemplateContent = TemplateContent.Replace("{$myImg$}", "<img src='" + articleInfo.VarPicUrl + "' alt='" + articleInfo.NvarTitle + "图片' />");
            }
            else
            {
                TemplateContent = TemplateContent.Replace("{$myImg$}", "");
            }

            TemplateContent = TemplateContent.Replace("{$Title$}", articleInfo.NvarTitle);
            TemplateContent = TemplateContent.Replace("{$DateAndTime$}", ((DateTime)articleInfo.DatDateAndTime).ToString("yyyy-MM-dd HH:mm").ToString());
            TemplateContent = TemplateContent.Replace("{$Author$}", articleInfo.NvarAuthor);
            TemplateContent = TemplateContent.Replace("{$SourceUrl$}", articleInfo.SourceUrl);
            TemplateContent = TemplateContent.Replace("{$Source$}", articleInfo.Source);
            TemplateContent = TemplateContent.Replace("{$Summary$}", articleInfo.Metadesc);
            TemplateContent = TemplateContent.Replace("{$Keywords$}", articleInfo.NKey);
            TemplateContent = TemplateContent.Replace("{$click$}", articleInfo.IntClick.ToString());
            TemplateContent = TemplateContent.Replace("{$id$}", articleInfo.IntID.ToString());
            Pbzx.BLL.PBnet_NewsType bc = new PBnet_NewsType();
            string hot = bc.ChannelGetNavigation((int)articleInfo.IntShowType, true, " >> ");
            TemplateContent = TemplateContent.Replace("{$Article_hot$}", hot);
            TemplateContent = TemplateContent.Replace("{$CssUrl$}", WebInit.webBaseConfig.WebUrl + WebInit.webFolderConfig.ArticleUrl + "shownews/shownews.css");
            string tempUrl = WebInit.webBaseConfig.WebUrl;
            //TemplateContent = TemplateContent.Replace("{$SinaWiki}", "<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + tempUrl.Substring(0,tempUrl.Length - 1) + articleInfo.VarPicUrl + "','','','utf-8'));\"><img src='/Images/Web/SinaWiki.jpg' border='0' >分享至新浪微博</a> ");
            //            TemplateContent = TemplateContent.Replace("{$SinaWiki}", "<a href=\"javascript:void((function(s,d,e,r,l,p,t,z,c){var%20f='http://v.t.sina.com.cn/share/share.php?appkey=3374168135',u=z||d.location,p=['&url=',e(u),'&title=',e(t||d.title),'&source=',e(r),'&sourceUrl=',e(l),'&content=',c||'gb2312','&pic=',e(p||'')].join('');function%20a(){if(!window.open([f,p].join(''),'mb',['toolbar=0,status=0,resizable=1,width=440,height=430,left=',(s.width-440)/2,',top=',(s.height-430)/2].join('')))u.href=[f,p].join('');};if(/Firefox/.test(navigator.userAgent))setTimeout(a,0);else%20a();})(screen,document,encodeURIComponent,'','','" + ConfigurationManager.AppSettings["SinaPic_Path"].Trim() + "','','','utf-8'));\"><img src='/Images/Web/SinaWiki.jpg' border='0' >分享至新浪微博</a> ");
            TemplateContent = TemplateContent.Replace("{$SinaWiki}", "");


            return TemplateContent;
        }
        #endregion
    }
}

