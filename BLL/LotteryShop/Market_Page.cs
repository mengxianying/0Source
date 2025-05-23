using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Text;
using Pbzx.Common;
using System.Web.Security;


namespace Pbzx.BLL
{
    public class Market_Page
    {
        private readonly IMarket_BuyInfo dal = DataAccess.CreateIMarket_BuyInfo();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("v_NumGut", "appendid");

        /// <summary>
        /// 绑定彩票超市商家排行信息
        /// </summary>
        /// <param name="count">显示的个数</param>
        /// <param name="strWhere">sql条件</param>
        /// <returns>周伟10-21</returns>
        public DataTable Mark_GetUserGueue(int count, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Top " + count + " * ");
            strSql.Append(" From PBnet_UserTable ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return dal.Query(strSql.ToString());
        }

        /// <summary>
        /// 绑定彩票超市主页项目列表
        /// 创建人: zhouwei
        /// 创建时间: 2010-10-22
        /// </summary>
        /// <param name="count">显示个数</param>
        /// <param name="steWhere">sql条件</param>
        /// <returns></returns>
        public DataSet Market_GetItme(int count, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Top " + count + " * ");
            strSql.Append(" From v_appendItem");
            if (strWhere.Trim() != "")
            {
                //strSql.Append(" where " + strWhere);
                strSql.Append(strWhere);
            }

            return dal.QuerySet(strSql.ToString());
        }
        /// <summary>
        ///  重载Market_GetItme方法
        /// 创建人: zhouwei
        /// 创建时间: 2010-11-3
        /// </summary>
        /// <param name="strWhere">sql条件</param>
        /// <returns></returns>
        public DataSet Market_GetItme(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" From v_appendItem");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }

            return dal.QuerySet(strSql.ToString());
        }
        /// <summary>
        /// 查询v_appendItem视图
        /// </summary>
        /// <param name="strBy">返回的条件值</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet Market_GetItme(string strBy, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select "+strBy);
            strSql.Append(" From v_appendItem");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }

            return dal.QuerySet(strSql.ToString());
        }

        /// <summary>
        /// 返回期号个条件等信息
        /// </summary>
        /// <param name="strBy">返回的条件值</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet Market_GetNum(string strBy, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + strBy);
            strSql.Append(" From v_NumGut");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }

            return dal.QuerySet(strSql.ToString());
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="TableName">查询数据库表的名称</param>
        /// <param name="CheckCondition">查询的列名 全部为*</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet Market_Table(string TableName, string CheckCondition, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select " + CheckCondition);
            strSql.Append(" From " + TableName);
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);

            }

            return dal.QuerySet(strSql.ToString());
        }



        /// <summary>
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
        /// 创建时间: 2010-12-09
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_NumGut", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        /// <summary>
        /// 购买项目的验证
        /// </summary>
        /// <param name="name">购买人的用户名</param>
        /// <param name="item">购买的项目的名称</param>
        /// 
        public string BuyItem(string name, string item)
        {
            Pbzx.BLL.Market_BuyInfo buy = new Pbzx.BLL.Market_BuyInfo();

            //判断是否购买过项目
            if (buy.Exists(name, Convert.ToInt32(item)) == true)
            {
                return "0";

            }
            else
            {
                Pbzx.BLL.Market_appendItemManager app = new Pbzx.BLL.Market_appendItemManager();
                Pbzx.Model.Market_appendItem Modapp = new Pbzx.Model.Market_appendItem();
                Modapp = app.GetModel(Convert.ToInt32(item));

                //Page.RegisterStartupScript("upscript", "<script>window.open('Market_buy.aspx?id='+ '" + Input.Encrypt(Modapp.TypeID.ToString()) + "'+ '&price='+ '" + Input.Encrypt(Modapp.Price.ToString()) + "'+ '&appendId='+'" + Input.Encrypt(item.ToString()) + "')</script>");
                //return "Market_buy.aspx?id="+  Input.Encrypt(Modapp.TypeID.ToString())  + "&price="+ Input.Encrypt(Modapp.Price.ToString()) + "&appendId="+ Input.Encrypt(item.ToString());
                return "buy.aspx?appendId=" + Input.Encrypt(item.ToString());
            }

        }
        /// <summary>
        /// 收藏项目
        /// </summary>
        /// 
        public string CollectionItem(string name, string item)
        {
            Pbzx.BLL.Market_CollASAtten get_collasAtten = new Pbzx.BLL.Market_CollASAtten();
            //判断有没有收藏过此项目
            if (get_collasAtten.Exists(name, item, 1, 1)==true)
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('您已经收藏了此项目')", true);
                return "您已经收藏了此项目条件";
            }
            else
            {
                Pbzx.Model.Market_CollASAtten get_mod = new Pbzx.Model.Market_CollASAtten();
                get_mod.Uname = name;
                get_mod.appName = item;
                get_mod.statc = 1;
                get_mod.mark = 1;
                get_mod.appTime = Convert.ToDateTime(string.Format("{0:T}", DateTime.Today.Date));
                if (get_collasAtten.Add(get_mod) > 0)
                {
                    //Page.RegisterStartupScript("upscripe", "<script>alert('收藏成功')</script>");
                    return "收藏成功";
                }
            }
            return "收藏失败";
        }
        /// <summary>
        /// 关注项目
        /// </summary>
        /// 
        public string AttentionItem(string name, string item)
        {
            Pbzx.BLL.Market_CollASAtten get_collasAtten = new Pbzx.BLL.Market_CollASAtten();
            if (get_collasAtten.Exists(name, item, 1, 2))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('您已经关注的此项目')", true);
                return "您已经关注了此项目条件";
            }
            else
            {
                Pbzx.Model.Market_CollASAtten get_mod = new Pbzx.Model.Market_CollASAtten();
                get_mod.Uname = name;
                get_mod.appName = item;
                get_mod.statc = 1;
                get_mod.mark = 2;
                get_mod.appTime = Convert.ToDateTime(string.Format("{0:T}", DateTime.Today.Date));
                if (get_collasAtten.Add(get_mod) > 0)
                {
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('成功关注了此项目')", true);
                    return "成功关注了项目条件";
                }
            }
            return "关注失败";
        }

        /// <summary>
        /// 统计商户漏发实际期号
        /// </summary>
        /// <param name="itemID">项目ID</param>
        /// <param name="UserName">会员名</param>
        /// <param name="ExpectNum">最新的期号</param>
        /// <returns></returns>
        public string CancelIndentNum(int itemID, string UserName, string ExpectNum)
        {
            string str = "";
            int sign = 0;
            //记录期号间的间隔
            int count = 0;
            Market_Page get_page = new Market_Page();
            DataSet dsNum = get_page.Market_GetNum("NvarName,ExpectNum", "appendId=" + itemID + " and Userid=" + "'" + UserName + "'" + " order by ExpectNum desc");

            if (dsNum.Tables[0].Rows[0]["ExpectNum"].ToString() == ExpectNum)
            {
                for (int i = 0; i < dsNum.Tables[0].Rows.Count - 1; i++)
                {
                    //是不是连续的期号
                    if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - 1 == Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]))
                    {
                        //期号连续不做记录
                    }
                    else
                    {
                        if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]) > 2)
                        {
                            if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]) > 365)
                            {
                                //检测是不是新年的第一期
                                if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) == Convert.ToInt32(DateTime.Now.Year + "001"))
                                {
                                    //查询过去的一年的最后一期 例如：2010-12-31的哪一期的期号
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "3D")
                                    {
                                        //查询上一年的12月31号的那一期
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC3DData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //是新年的第一期 001期
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "双色球")
                                    {
                                        //查询上一年的12月31号的那一期
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FCSSData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //是新年的第一期 001期
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "七星彩")
                                    {
                                        //查询上一年的12月31号的那一期
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC7XCData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //是新年的第一期 001期
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "大乐透")
                                    {
                                        //查询上一年的12月31号的那一期
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCDLTData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //是新年的第一期 001期
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "七乐彩")
                                    {
                                        //查询上一年的12月31号的那一期
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC7LC where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //是新年的第一期 001期
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "排列5")
                                    {
                                        //查询上一年的12月31号的那一期
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCPL35Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //是新年的第一期 001期
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "22选5")
                                    {
                                        //查询上一年的12月31号的那一期
                                        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC22X5Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            //是新年的第一期 001期
                                            count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                        }
                                    }
                                }
                                else
                                {
                                    //不是新年的第一期
                                    count = Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]);
                                }
                            }
                            else
                            {
                                count = Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]);
                            }
                            for (int j = 1; j < count; j++)
                            {
                                if (sign == Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]))
                                {
                                    break;
                                }
                                if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - j == Convert.ToInt32(DateTime.Now.Year + "000"))
                                {
                                    DataSet ds = new DataSet();
                                    //查询过去的一年的最后一期 例如：2010-12-31的哪一期的期号
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "3D")
                                    {
                                        //查询上一年的最后一期。12月31号的哪一期。
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC3DData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "双色球")
                                    {
                                        //查询上一年的12月31号的那一期
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FCSSData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "七星彩")
                                    {
                                        //查询上一年的12月31号的那一期
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC7XCData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "大乐透")
                                    {
                                        //查询上一年的12月31号的那一期
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCDLTData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "七乐彩")
                                    {
                                        //查询上一年的12月31号的那一期
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC3DData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "排列5")
                                    {
                                        //查询上一年的12月31号的那一期
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCPL35Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "22选5")
                                    {
                                        //查询上一年的12月31号的那一期
                                        ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC22X5Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                    }
                                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                                    {
                                        for (int k = 0; k < Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]); k++)
                                        {
                                            if (Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - k == Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]))
                                            {

                                                break;
                                            }
                                            else
                                            {
                                                str += Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - k + "|";
                                            }

                                        }
                                        sign = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - (Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]));
                                    }
                                }
                                else
                                {
                                    str += Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - j + "|";
                                }
                            }
                        }
                        else
                        {
                            str += Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - 1 + "|";
                        }
                    }
                }
                return str;
            }
            else
            {
                if (Convert.ToInt32(ExpectNum) > Convert.ToInt32(dsNum.Tables[0].Rows[0]["ExpectNum"]))
                {
                    for (int l = 0; l < Convert.ToInt32(ExpectNum) - Convert.ToInt32(dsNum.Tables[0].Rows[0]["ExpectNum"]); l++)
                    {
                        str += Convert.ToInt32(ExpectNum) - l + "|";
                    }
                    for (int i = 0; i < dsNum.Tables[0].Rows.Count - 1; i++)
                    {
                        //是不是连续的期号
                        if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - 1 == Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]))
                        {
                            //期号连续不做记录
                        }
                        else
                        {
                            if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]) > 2)
                            {
                                if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i+1]["ExpectNum"]) > 365)
                                {
                                    //检测是不是新年的第一期
                                    if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) == Convert.ToInt32(DateTime.Now.Year + "001"))
                                    {
                                        //查询过去的一年的最后一期 例如：2010-12-31的哪一期的期号
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "3D")
                                        {
                                            //查询上一年的12月31号的那一期
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC3DData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //是新年的第一期 001期
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "双色球")
                                        {
                                            //查询上一年的12月31号的那一期
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FCSSData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //是新年的第一期 001期
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "七星彩")
                                        {
                                            //查询上一年的12月31号的那一期
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC7XCData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //是新年的第一期 001期
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "大乐透")
                                        {
                                            //查询上一年的12月31号的那一期
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCDLTData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //是新年的第一期 001期
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "七乐彩")
                                        {
                                            //查询上一年的12月31号的那一期
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC7LC where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //是新年的第一期 001期
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "排列5")
                                        {
                                            //查询上一年的12月31号的那一期
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCPL35Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //是新年的第一期 001期
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "22选5")
                                        {
                                            //查询上一年的12月31号的那一期
                                            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC22X5Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
                                            if (ds != null && ds.Tables[0].Rows.Count > 0)
                                            {
                                                //是新年的第一期 001期
                                                count = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                            }
                                        }
                                       
                                    }
                                    else
                                    {
                                        //不是新年的第一期
                                        count = Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                    }
                                }
                                else
                                {
                                    count = Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]);
                                }
                                for (int j = 1; j < count; j++)
                                {
                                    if (sign == Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]))
                                    {
                                        break;
                                    }
                                    if (Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - j == Convert.ToInt32(DateTime.Now.Year + "000"))
                                    {
                                        DataSet ds = new DataSet();
                                        //查询过去的一年的最后一期 例如：2010-12-31的哪一期的期号
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "3D")
                                        {
                                            //查询上一年的12月31号的那一期
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC3DData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "双色球")
                                        {
                                            //查询上一年的12月31号的那一期
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FCSSData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "七星彩")
                                        {
                                            //查询上一年的12月31号的那一期
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC7XCData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "大乐透")
                                        {
                                            //查询上一年的12月31号的那一期
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCDLTData where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "七乐彩")
                                        {
                                            //查询上一年的12月31号的那一期
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from FC7LC where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");
 
                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "排列5")
                                        {
                                            //查询上一年的12月31号的那一期
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TCPL35Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (dsNum.Tables[0].Rows[i]["NvarName"].ToString() == "22选5")
                                        {
                                            //查询上一年的12月31号的那一期
                                            ds = Maticsoft.DBUtility.DbHelperSQL.Query("select top 1 issue from TC22X5Data where [date] like '%" + Convert.ToDateTime(DateTime.Now.Year - 1) + "%' order by [date] desc");

                                        }
                                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                                        {
                                            for (int k = 0; k < Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]); k++)
                                            {
                                                if (Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - k == Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]))
                                                {

                                                    break;
                                                }
                                                else
                                                {
                                                    str += Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - k + "|";
                                                }

                                            }
                                            sign = Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - (Convert.ToInt32(ds.Tables[0].Rows[0]["issue"]) - Convert.ToInt32(dsNum.Tables[0].Rows[i + 1]["ExpectNum"]));
                                        }
                                    }
                                    else
                                    {
                                        str += Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - j + "|";
                                    }
                                }
                            }
                            else
                            {
                                str += Convert.ToInt32(dsNum.Tables[0].Rows[i]["ExpectNum"]) - 1 + "|";
                            }
                        }
                    }
                }
                return str;
            }
           
        }

        /// <summary>
        /// 全额退款
        /// </summary>
        /// <param name="UserName"> 退款用户</param>
        /// <param name="item"> 要退的项目</param>
        /// <returns></returns>
        public int cancelState(string username, int item)
        { 
            //查询这个项目的价格
            DataSet dsPrice=Market_GetItme("Price,UserId","appendId="+item);
            //查询商家的帐户金额
            DataSet dsShop = Maticsoft.DBUtility.DbHelperSQLBBS.Query("select UserMoney from Dv_User where UserName=" + "'" + dsPrice.Tables[0].Rows[0]["UserId"].ToString() + "'");
            DataSet ds = Maticsoft.DBUtility.DbHelperSQLBBS.Query("select UserMoney from Dv_User where UserName=" + "'" + username + "'");
            
            //扣除商家的帐户金额
            int moneyShop=Convert.ToInt32(dsShop.Tables[0].Rows[0][0])-Convert.ToInt32(dsPrice.Tables[0].Rows[0]["Price"]);
            int Shopmoney = Maticsoft.DBUtility.DbHelperSQLBBS.ExecuteSql("update Dv_User set UserMoney=" + moneyShop + " where UserName=" + "'" + dsPrice.Tables[0].Rows[0]["UserId"].ToString() + "'");
            if (Shopmoney > 0)
            {
                //修改退款用户的账户金额
                int money = Convert.ToInt32(ds.Tables[0].Rows[0][0]) + Convert.ToInt32(dsPrice.Tables[0].Rows[0]["Price"]);
                int dsmoney = Maticsoft.DBUtility.DbHelperSQLBBS.ExecuteSql("update Dv_User set UserMoney=" + money + " where UserName=" + "'" + username + "'");
                if (dsmoney > 0)
                {
                    //删除购买记录
                    Market_BuyInfo buy = new Market_BuyInfo();
                    Model.Market_BuyInfo modbuy = new Model.Market_BuyInfo();
                    modbuy = buy.GetModel(item);
                    modbuy.market = 1;
                    if (buy.Update(modbuy) > 0)
                    {
                        //退款成功
                        return 1;
                    }
                    else
                    { 
                        //已经给用户退款但是购买记录未删除
                        return 3;
                    }
                    
                }
                else
                {
                    return 0;
                }
                //已扣除商家的金额 但是退款没有成功
//                return 2;
            }
            else
            {
                //退款失败
                return 0;
            }
        }

       /// <summary>
        /// 扣除使用费退款
       /// </summary>
       /// <param name="username">退款用户</param>
       /// <param name="item">要退的项目ID</param>
        public void comtepency(string username, int item)
        {

            //查询用户购买的信息
            DataSet ds = Market_Table("Market_BuyInfo", "*", "BuyUserid=" + "'" + username + "'" + " and issueInfoId=" + item);
            //查询用户退款的时间
            DataSet dstime = Market_Table("Market_CancelIndent", "CTime", "CancelName=" + "'" + username + "'" + " and CancelItem=" + item);
            TimeSpan time=toResult(ds.Tables[0].Rows[0]["BeginTime"].ToString(),dstime.Tables[0].Rows[0]["CTime"].ToString());

            //把购买是的月数转换成天
            TimeSpan shoptime = toResult(ds.Tables[0].Rows[0]["BeginTime"].ToString(), ds.Tables[0].Rows[0]["EndTime"].ToString());

            //判断订制了几个月
            if (time.Days >shoptime.Days)
            {
                //不能退款
                //return 3;
            }
            //润月包括在内。 订购了一个月了。
            else if (time.Days > 27)
            { 
                //订制超过一个月按一个月的价格收取费用


                //按比例扣除费用然后退费

                //退款成功后修改购买期限和时间。
                
            }
            //超过2个月
            if (time.Days > 57)
            { 
                //订制超过二个月了 按2个月的价格收取费用
            }
            if (time.Days > 180)
            { 
                //订制超过半年了 按具体的时间*一个月的价格
            }
            //正常退款后修改这个用户的购买结束时间为退款成功时间。
        }

        /// <summary>
        /// 商户取消收费项目（处理）
        /// </summary>
        /// <param name="ShopUser">商户名称</param>
        /// <param name="item">取消的项目条件ID</param>
        public void ShopCancel(string ShopUser, int item)
        { 
            
            

            //取消的条件。 要把正在订制此项目条件的用户的 金额全部退还。


            //要确保商户有足够的余额扣除。如果余额不够则不能取消收费项目

            //如果取消成功则要把项目的收费标识和金额修改过来。

        }
        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期字符串</param>
        /// <param name="d2">要参与计算的另一个日期字符串</param>
        /// <returns>一个表示日期间隔的TimeSpan类型</returns>

        public static TimeSpan toResult(string d1, string d2)
        {
            try
            {
                DateTime date1 = DateTime.Parse(d1);
                DateTime date2 = DateTime.Parse(d2);
                return toResult(date1, date2);
            }
            catch
            {
                throw new Exception("字符串参数不正确!");
            }
        }
        /// <summary>
        /// 计算日期间隔
        /// </summary>
        /// <param name="d1">要参与计算的其中一个日期</param>
        /// <param name="d2">要参与计算的另一个日期</param>
        /// <returns>一个表示日期间隔的TimeSpan类型</returns>
        public static TimeSpan toResult(DateTime d1, DateTime d2)
        {
            TimeSpan ts;
            if (d1 > d2)
            {
                ts = d1 - d2;
            }
            else
            {
                ts = d2 - d1;
            }
            return ts;
        }
    }
}
