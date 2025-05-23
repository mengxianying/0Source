using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using Pbzx.Common;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类Help_TreeStructure 的摘要说明。
    /// </summary>
    public class Help_TreeStructure
    {
        private static readonly IHelp_TreeStructure dal = DataAccess.CreateHelp_TreeStructure();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Help_TreeStructure", "Tree_id");
        public Help_TreeStructure()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Tree_id)
        {
            return dal.Exists(Tree_id);
        }

        public bool Exists(string name, string lottery, int TreeName)
        {
            return dal.Exists(name, lottery,TreeName);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Help_TreeStructure model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Help_TreeStructure model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Tree_id)
        {
            return dal.Delete(Tree_id);
        }
        public int Delete(string Noet)
        {
            return dal.Delete(Noet);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Help_TreeStructure GetModel(int Tree_id)
        {
            return dal.GetModel(Tree_id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Help_TreeStructure", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        //查询节点
        //public DataTable GetListBySort(int typeID, string Tree_name)
        //{

        //    //DataTable dtResult = basicDAL.GetLisBySql("SELECT * FROM Help_TreeStructure where Tree_superiorNoet=" + typeID + " and 1!=1");
        //    //DataTable dtRoot = basicDAL.GetLisBySql("SELECT * FROM Help_TreeStructure where Tree_superiorNoet=" + typeID + " and Tree_name= " + "'" + Tree_name + "'" + "  ORDER BY Tree_id ASC ");
        //    //for (int i = 0; i < dtRoot.Rows.Count; i++)
        //    //{
        //    //    DataRow myResultRow = dtResult.NewRow();
        //    //    myResultRow.ItemArray = dtRoot.Rows[i].ItemArray;
        //    //    dtResult.Rows.Add(myResultRow);

                
        //    //    //DataTable dtSmall = basicDAL.GetLisBySql("SELECT * FROM Help_TreeStructure where Tree_superiorNoet='" + dtRoot.Rows[i]["Tree_num"] + "' and Tree_name='" + Tree_name + "'  ORDER BY Tree_id ASC ");
        //    //    //for (int j = 0; j < dtSmall.Rows.Count; j++)
        //    //    //{
        //    //    //    DataRow myResultRow1 = dtResult.NewRow();
        //    //    //    myResultRow1.ItemArray = dtSmall.Rows[j].ItemArray;
        //    //    //    dtResult.Rows.Add(myResultRow1);

        //    //    //    DataTable dsTree = basicDAL.GetLisBySql("SELECT * FROM Help_TreeStructure where Tree_superiorNoet='" + dtSmall.Rows[j]["Tree_num"] + "' and Tree_name='" + Tree_name + "'  ORDER BY Tree_id ASC ");
        //    //    //    for (int k = 0; k < dsTree.Rows.Count; k++)
        //    //    //    {
        //    //    //        DataRow myResultRow2 = dtResult.NewRow();
        //    //    //        myResultRow2.ItemArray = dsTree.Rows[k].ItemArray;
        //    //    //        dtResult.Rows.Add(myResultRow2);
        //    //    //    }
        //    //    //}
        //    //}
        //    return dtResult;
        //}
        //查询节点
        public DataTable GetListBySort(string Tree_name)
        {
            DataTable dtResult = basicDAL.GetLisBySql("SELECT * FROM Help_TreeStructure where Tree_name=" + "'" + Tree_name + "'" +" order by Tree_sort asc");
            return dtResult;
        }


        /// <summary>
        /// 根据频道ID生成静态页面（根据参数选择是否生成该频道下面的所有子类别页面）
        /// </summary>
        /// <param name="ID">当前频道编号</param>
        /// <param name="isAllCreate"></param>
        /// <returns></returns>
        public void CreatHtmlByChannelID(int ID, string aspxHtml, bool isAllCreate)
        {
            if (!isAllCreate)
            {
                Pbzx.Model.Help_TreeStructure model = GetModel(ID);
                if (aspxHtml.IndexOf(".aspx") < 0)
                {
                    System.Web.HttpContext.Current.Server.Execute("/" + aspxHtml + ".aspx");
                    System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.Tree_RootNotd.Trim() + "成功！');</script>");
                }
                else if (aspxHtml.IndexOf("RefurbishCpXml.aspx") > 0)
                {
                    System.Web.HttpContext.Current.Server.Execute(aspxHtml);
                }
                else
                {
                    if (Files.Create(model.Tree_Path, aspxHtml))
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.Tree_RootNotd.Trim() + "成功！');</script>");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.Tree_RootNotd.Trim() + "失败！');</script>");
                    }
                }
            }
            else
            {
                Pbzx.Model.Help_TreeStructure model = GetModel(ID);
                if (aspxHtml.IndexOf(".aspx") < 0)
                {
                    System.Web.HttpContext.Current.Server.Execute("/" + aspxHtml + ".aspx");
                    System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.Tree_RootNotd.Trim() + "成功！');</script>");
                }
                else if (aspxHtml.IndexOf("RefurbishCpXml.aspx") > 0)
                {
                    System.Web.HttpContext.Current.Server.Execute(aspxHtml);
                }
                else
                {
                    Files.Create(model.Tree_Path, aspxHtml);
                    System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.Tree_RootNotd.Trim() + "成功！');</script>");
                }
                DataSet ds = GetList(" Tree_superiorNoet=" + "'" + model.Tree_superiorNoet.ToString() + "'");
                if (ds.Tables[0].Rows.Count < 1)
                {
                    return;
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string AspxHtml = "/right.aspx?noet=" + "'" + model.Tree_num.ToString() + "'";
                        Files.Create(row["Tree_Path"].ToString(), AspxHtml);
                        CreatHtmlByChannelID(int.Parse(row["Tree_id"].ToString()), aspxHtml, true);
                    }
                }

            }
        }


        /// <summary>
        /// 批量生成静态页面
        /// </summary>
        /// <param name="ids"></param>
        public void CreateHtmlByBatch(string ids)
        {
            string[] myIds = ids.Split(new char[] { ',' });
            foreach (string str in myIds)
            {
                DataSet ds = GetList("Tree_id=" + Convert.ToInt32(str));
                string aspxHtml = "/right.aspx?noet=" + ds.Tables[0].Rows[0]["Tree_num"].ToString();
                CreatHtmlByChannelID(int.Parse(str), aspxHtml, false);
            }
            System.Web.HttpContext.Current.Response.Write("<script>alert('批量生成静态页面成功！');</script>");
        }

        /// <summary>
        /// 全部生成静态页面
        /// </summary>
        public void CreateHtmlByBatch()
        {
            DataTable dt = GetList("1=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Pbzx.Model.Help_TreeStructure model = GetModel(Convert.ToInt32(row["Tree_id"]));
                    //string AspxHtml = "/right.aspx?noet=" + "'" + model.Tree_num.ToString() + "'";
                    string AspxHtml = "/right.aspx?noet=" + model.Tree_num.ToString();

                    if (AspxHtml.IndexOf(".aspx") < 0)
                    {
                        System.Web.HttpContext.Current.Server.Execute("/" + AspxHtml + ".aspx");
                    }
                    else if (AspxHtml.IndexOf("RefurbishCpXml.aspx") > 0)
                    {
                        System.Web.HttpContext.Current.Server.Execute(AspxHtml);
                    }
                    else
                    {
                        Files.Create(model.Tree_Path, AspxHtml);
                    }
                }
                System.Web.HttpContext.Current.Response.Write("<script>alert('全部生成静态页面成功！');</script>");
            }
        }

        //保存操作信息
        public static bool WriteMasterOperate(string action, string detail)
        {
            
            PBnet_WebLog LogBLL = new PBnet_WebLog();
            Pbzx.Model.PBnet_WebLog MyLog = new Pbzx.Model.PBnet_WebLog();

            MyLog.Operator = "批量生成帮助";
            //System.Web.HttpContext.Current.Request.Cookies["AdminManager"].Value;
            MyLog.UserIP = Pbzx.Common.Method.GetUserIP();
            MyLog.ActionType = action;
            MyLog.Detail = detail;
            return LogBLL.Add(MyLog);
        }

        #endregion  成员方法
    }
}
