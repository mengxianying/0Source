using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Pbzx.Common;
using System.Xml;
using System.Text;
using Pbzx.BLL;
using Maticsoft.DBUtility;
using System.IO;

namespace Pbzx.Web.PB_Manage
{
    public partial class SoftMessage_Manage_2011 : AdminBasic
    {
        //新建一个BLL对象
        BLL.CM_MainManager ll = new BLL.CM_MainManager();
        public static BLL.CstSoftware softwmanager = new BLL.CstSoftware();

        public static CM_MainBySoftwareTypeManager cmmanager = new CM_MainBySoftwareTypeManager();

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            //判断是不是第一次加载
            if (!IsPostBack)
            {
                //得到所有数据列表
                DataSet ds = ll.GetAllList();
                //得到他的所有行数
                int number = ds.Tables[0].Columns.Count;
                //从配置文件中读取每页显示条数
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                //给排序属性赋初值
                //默认 PostTime 
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "EndTime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }



                //今日访问清0方法（当最后访问日期不是今天！则将他的今日访问清0）

                //得到所有的软件信息
                if (ds.Tables[0].Rows.Count > 0)
                {

                    string ids = "";

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //首先判断，当日访问为0时，没必要更新
                        if (Convert.ToInt32(ds.Tables[0].Rows[i]["TodayCount"].ToString()) > 0)
                        {
                            //当年份不同时，清0
                            if (DateTime.Parse(ds.Tables[0].Rows[i]["LastTime"].ToString()).Year != DateTime.Now.Year)
                            {
                                //保存要清0的ID
                                ids += ds.Tables[0].Rows[i]["ID"].ToString() + ",";
                            }
                            else
                            {
                                //当年份相同时！判断月份，月份不同，清0
                                if (DateTime.Parse(ds.Tables[0].Rows[i]["LastTime"].ToString()).Month != DateTime.Now.Month)
                                {

                                    //保存要清0的ID
                                    ids += ds.Tables[0].Rows[i]["ID"].ToString() + ",";
                                }
                                else
                                {
                                    //当月份相同时，判断他的天，如和最后访问日期不同，清0
                                    if (DateTime.Parse(ds.Tables[0].Rows[i]["LastTime"].ToString()).Day != DateTime.Now.Day)
                                    {
                                        //保存要清0的ID
                                        ids += ds.Tables[0].Rows[i]["ID"].ToString() + ",";
                                    }

                                }

                            }
                        }
                    }
                    //当ids不为空时，则清空他指定ID的当日访问
                    if (ids != "")
                    {
                        ids = ids.Substring(0, ids.Length - 1);
                        //清0
                        DbHelperSQL1.ExecuteSql("UPDATE CM_Main SET TodayCount=0 where id in(" + ids + ")");
                    }
                }
                //------------------------------------------------------------------------------------------

                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }

        /// <summary>
        /// 绑定分页控件
        /// </summary>
        /// <param name="tempCount"></param>
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        /// <summary>
        /// 分页控件的其他显示
        /// </summary>
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }


        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            //当标题不为空时
            if (!string.IsNullOrEmpty(Request["strTitleSerch"]))
            {
                bu.Append(" and Title like '%" + Request["strTitleSerch"] + "%' ");
            }
            //当软件查询条件不是所有时
            if (!string.IsNullOrEmpty(Request["DropList1"]))
            {
                if (Request["DropList1"] != "0")
                {
                    //当查询软件版本不为所有时
                    if (Request["DropList1"] != "0")
                    {
                        //得到他的16进制的ID
                        //int id16 = ((Convert.ToInt32(Request["DropList1"]) * 16) + Convert.ToInt32(Request["DropList2"]));
                        //bu.Append(" and SoftInfo like '%" + id16 + ",%'");

                        //if (Request["DropList2"] != "0")
                        //{
                        //    bu.Append(" and SoftInfo like '%" + Request["DropList1"] + "," + Request["DropList2"] + "|%'");
                        //}
                        //else
                        //{
                        //    bu.Append(" and SoftInfo like '%" + Request["DropList1"] + ",%'");
                        //}

                        if (Request["DropList2"] != "0")
                        {
                            bu.Append(" and  Id in( select CMID from CM_MainBySoftwareType where (SoftwareName = '" + Request["DropList1"] + "') AND (InstallName = '" + Request["DropList2"] + "'))");
                        }
                        else
                        {
                            bu.Append(" and  Id in( select CMID from CM_MainBySoftwareType where (SoftwareName = '" + Request["DropList1"] + "'))");
                        }


                    }
                }
            }
            //当注册限定不是所有时
            if (!string.IsNullOrEmpty(Request["DropList3"]))
            {
                if (Request["DropList3"] != "00")
                {
                    bu.Append(" and RegType like '%" + Request["DropList3"] + "|%'");

                }
            }
            //当用户限定不是所有时
            if (!string.IsNullOrEmpty(Request["DropList4"]))
            {
                if (Request["DropList4"] != "00")
                {
                    bu.Append(" and UserClass  like '%" + Request["DropList4"] + "|%'");
                }
                else if (Request["DropList4"] == "0")
                {
                    bu.Append(" and UserClass = '" + Request["DropList4"] + "|'");
                }
            }
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and PostTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and BeginTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                    else if (Request["dateType"] == "3")
                    {
                        bu.Append(" and EndTime between '" + Request["strCreateTime1"] + "' and '" + Request["strCreateTime2"] + " 23:59:59'  ");
                    }
                }
            }
            return bu.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.CM_MainManager cmmain = new Pbzx.BLL.CM_MainManager();
            Pbzx.Model.CM_Main msgModel = cmmain.GetMain(id);
            string nvarname = msgModel.Title.ToString();
            //判断对应生成HTML页面是否存在，如存在，将他删除
            try
            {
                //当网站改动时，这里也需改动，不然无法使用删除
                if (DirectoryFile.IsCreateFile(Server.MapPath("~" + msgModel.ContentURL.Substring(22))))
                {
                    DirectoryFile.FileDel(Server.MapPath("~" + msgModel.ContentURL.Substring(22)));
                }
            }
            catch
            {

            }


            if (cmmain.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除软件消息[" + nvarname + "]");
                JS.Alert("删除成功！");
            }
            else
            {
                JS.Alert("删除失败！");
            }

            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <param name="it"></param>
        /// <returns></returns>
        protected string ChkSoftType(object st, object it)
        {
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(st, it);
            return result[0] + "(" + result[1] + ")";
        }



        /// <summary>
        /// 数据绑定方法
        /// </summary>
        /// <param name="column"></param>
        /// <param name="isDesc"></param>
        private void BindData(string column, bool isDesc)
        {
            //新建一个BLL对象
            BLL.CM_MainManager ll = new BLL.CM_MainManager();
            //定义一个类型属性
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 "); //条件
            //URL传来的值

            //判断如果有xx则只需要给他这个查询条件
            if (Request["xx"] != null)
            {
                bu.Append(" and [Type]=" + Request["xx"]);
            }
            else
            {
                bu.Append(this.AddParameter());
            }
            string Searchstr = bu.ToString();
            //排序条件
            string order = column;
            int myCount = 0;
            //判断是升序排列还是降序
            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }
            //调用BLL方法得到 数据表
            DataTable lsResult = ll.GuestGetBySearch(Searchstr, "ID,SoftInfo,RegType,UserClass,Sender,Type,Category,State,PostTime,BeginTime,EndTime,Title,ContentURL,LastTime,TodayCount,TotalCount,Content", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);
            //绑定到GriView中
            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();

            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>应该没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }


        }


        protected void lbtnAduting_Command(object sender, CommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.CstMessage cstMSGBLL = new Pbzx.BLL.CstMessage();
            cstMSGBLL.ChangeAudit(id, "MsgSend");
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_Editor_2011.aspx");
        }
        /// <summary>
        /// 行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='SoftMessage_Editor_2011.aspx?ID=" + e.Row.Cells[0].Text + "'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

        //状态格式化
        public static string StatusGSF(object obj)
        {
            if (Convert.ToInt32(obj) == 0)
            {
                return "未发布";
            }
            else
            {
                return "<font color='green'>已发布</font>";
            }

        }
        //消息格式化
        public static string MsgGSH(object obj)
        {
            string s = "";
            string zong = "";
            XmlDocument dom = new XmlDocument();
            dom.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_Private.xml"));//装载XML文档 
            XmlElement root = dom.DocumentElement;
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {

                XmlNode haha = root.SelectNodes("reg")[i];
                //得到他的ID
                string ss = haha.SelectSingleNode("@number").Value;

                if (ss == obj.ToString())
                {
                    zong = haha.SelectSingleNode("@name").Value;
                }
            }
            switch (Convert.ToInt32(obj))
            {
                case 1:
                    s = "<a style='color:#000000' href='SoftMessage_Manage_2011.aspx?xx=1'>" + zong + "</a>";
                    break;
                case 2:
                    s = "<a style='color:#FF0000' href='SoftMessage_Manage_2011.aspx?xx=2'>" + zong + "</a>";
                    break;
                case 3:
                    s = "<a style='color:#0000FF' href='SoftMessage_Manage_2011.aspx?xx=3'>" + zong + "</a>";
                    break;
                case 4:
                    s = "<a style='color:#008000' href='SoftMessage_Manage_2011.aspx?xx=4'>" + zong + "</a>";
                    break;
            }
            return s;
        }
        //今日访问格式化
        public static string JrfwGSH(object obj)
        {
            if (Convert.ToInt32(obj) > 0)
            {
                return "<font color='#000000'>" + obj + "</font>";
            }
            else
            {
                return "<font color='#808080'>" + obj + "</font>";
            }

        }
        /// <summary>
        /// 类别
        /// </summary>
        /// <returns></returns>
        public static string LeibieGSH(object obj)
        {
            if (obj.ToString() == "")
            {
                return "URL";
            }
            else
            {

                return "HTML";
            }

        }
        /// <summary>
        /// 软件限定
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string RJGSH(object obj)
        {

            if (obj.ToString() == "0,0,0|")
            {
                return "<font color='#0000FF' title='没有任何软件限定'>所有</font>";
            }
            else
            {
                //得到所有的软件组
                string[] rj = obj.ToString().Split('|');
                //所有集合
                string buts = "";
                for (int i = 0; i < rj.Length - 1; i++)
                {
                    string rjstring = "";
                    //将此信息再分割成数组
                    string[] rjmx = rj[i].Split(',');

                    //得到16进制的软件ID
                    //int rjid = Convert.ToInt32(rjmx[0]);

                    //将16进制的软件ID 转换成正确的 ID信息
                    ////得到软件id
                    //int zqid1 = rjid / 16;
                    ////得到软件ID下面项的ID
                    //int zqid2 = rjid % 16;
                    //得到版本号的间隔信息
                    string vis = rjmx[1] + "," + rjmx[2];
                    ////一级绑定
                    //string sqlSoft = "SELECT SoftwareType,MAX(SoftwareName) AS SoftwareName FROM CstSoftware where SoftwareType=" + zqid1.ToString() + " GROUP BY SoftwareType";
                    //DataTable ds1 = softwmanager.GetLisBySql(sqlSoft);

                    //if (ds1.Rows.Count > 0)
                    //{
                    //rjstring = ds1.Rows[0]["SoftwareName"].ToString();
                    //if (zqid2 != 0)
                    //{
                    //二级绑定
                    //string sqlInstall = "select  MAX(InstallType) as InstallType,  InstallName  from dbo.CstSoftware where InstallType='" + zqid2.ToString() + "' GROUP BY InstallName ";
                    //DataTable ds2 = softwmanager.GetLisBySql(sqlInstall);

                    //if (ds2.Rows.Count > 0)
                    //{
                    //    rjstring += ":" + ds2.Rows[0]["InstallName"].ToString();
                    //}


                    //}
                    //else
                    //{
                    //    rjstring += ":所有";
                    //}

                    //}

                    if (rjmx.Length > 3)
                    {
                        rjstring += rjmx[3] + ":" + rjmx[4] + ":" + vis + "&#13;";

                    }
                    else
                    {
                        rjstring += "所有";
                    }

                    buts += rjstring;

                }

                if (buts.Length >= 7)
                {
                    return "<font title='" + buts + "'>" + buts.Substring(0, 6) + "...</font>";
                }
                else
                {
                    return "<font title='" + buts + "'>" + buts + "</font>";
                }
            }
        }

        /// <summary>
        /// 软件限定修改版本
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string RJGSH_01(object obj)
        {
            if (obj != null)
            {
                DataSet ds = cmmanager.GetList("CMID='" + obj.ToString() + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string buts = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        if (ds.Tables[0].Rows[i][5].ToString() == "0")
                        {
                            return "<font title='所有'>所有</font>";
                        }
                        buts += ds.Tables[0].Rows[i][5] + ":" + ds.Tables[0].Rows[i][6] + ":" + ds.Tables[0].Rows[i][3] + "," + ds.Tables[0].Rows[i][4] + "&#13;";

                    }

                    if (buts.Length >= 7)
                    {
                        return "<font title='" + buts + "'>" + buts.Substring(0, 6) + "...</font>";
                    }
                    else
                    {
                        return "<font title='" + buts + "'>" + buts + "</font>";
                    }
                }


            }
            return "";

            //if (obj.ToString() == "0,0,0|")
            //{
            //    return "<font color='#0000FF' title='没有任何软件限定'>所有</font>";
            //}
            //else
            //{
            //    //得到所有的软件组
            //    string[] rj = obj.ToString().Split('|');
            //    //所有集合
            //    string buts = "";
            //    for (int i = 0; i < rj.Length - 1; i++)
            //    {
            //        string rjstring = "";
            //        //将此信息再分割成数组
            //        string[] rjmx = rj[i].Split(',');
            //        string vis = rjmx[1] + "," + rjmx[2];


            //        if (rjmx.Length > 3)
            //        {
            //            rjstring += rjmx[3] + ":" + rjmx[4] + ":" + vis + "&#13;";

            //        }
            //        else
            //        {
            //            rjstring += "所有";
            //        }

            //        buts += rjstring;

            //    }

            //    if (buts.Length >= 7)
            //    {
            //        return "<font title='" + buts + "'>" + buts.Substring(0, 6) + "...</font>";
            //    }
            //    else
            //    {
            //        return "<font title='" + buts + "'>" + buts + "</font>";
            //    }
            //}
        }


        /// <summary>
        /// 注册限定信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ZCGSH(object obj)
        {
            string zong = "";
            string[] zc = obj.ToString().Split('|');
            XmlDocument dom = new XmlDocument();
            dom.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_RegType.xml"));//装载XML文档 
            XmlElement root = dom.DocumentElement;
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {

                XmlNode haha = root.SelectNodes("reg")[i];
                //得到他的ID
                string ss = haha.SelectSingleNode("@number").Value;
                for (int j = 0; j < zc.Length - 1; j++)
                {
                    if (ss == zc[j])
                    {
                        zong += haha.SelectSingleNode("@name").Value + "|";
                    }
                }



            }

            if (zong.Length >= 7)
            {
                return "<font title='" + zong + "'>" + zong.Substring(0, 6) + "...</font>";
            }
            else if (zong.Length > 0)
            {
                return "<font title='" + zong + "'>" + zong.Substring(0, zong.Length - 1) + "</font>";
            }
            return "";

        }
        /// <summary>
        /// 用户限定信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string YHGSH(object obj)
        {

            string zong = "";
            string[] zc = obj.ToString().Split('|');
            XmlDocument dom = new XmlDocument();
            dom.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_UserClass.xml"));//装载XML文档 
            XmlElement root = dom.DocumentElement;
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {

                XmlNode haha = root.SelectNodes("reg")[i];
                //得到他的ID
                string ss = haha.SelectSingleNode("@number").Value;
                for (int j = 0; j < zc.Length - 1; j++)
                {
                    if (ss == zc[j])
                    {
                        zong += haha.SelectSingleNode("@name").Value + "|";
                    }
                }



            }

            if (zong.Length >= 7)
            {
                return "<font title='" + zong + "'>" + zong.Substring(0, 6) + "...</font>";
            }
            else if (zong.Length > 0)
            {
                return "<font title='" + zong + "'>" + zong.Substring(0, zong.Length - 1) + "</font>";
            }
            return "";
        }

        /// <summary>
        /// 标题显示颜色调用方法
        /// </summary>
        /// <param name="objtile">标题</param>
        /// <param name="objbegintime">开始时间</param>
        /// <param name="objendtime">结束时间</param>
        /// <param name="isfb">是否发布了</param>
        /// <returns>标题</returns>
        public static string TitleFmt(object objtile, object objbegintime, object objendtime, object isfb)
        {
            //为0未发布
            if (Convert.ToInt32(isfb) != 0)
            {
                //已发布已开始 绿色
                if (Convert.ToDateTime(objbegintime) <= DateTime.Now && Convert.ToDateTime(objendtime) >= DateTime.Now)
                {
                    return "<font style='color:blue;'>" + objtile + "</font>";
                }
                //已发布未开始 蓝色
                if (Convert.ToDateTime(objbegintime) > DateTime.Now)
                {
                    return "<font style='color:green;'>" + objtile + "</font>";
                }
                //已发布已过期 灰色
                if (Convert.ToDateTime(objendtime) < DateTime.Now)
                {
                    return "<font style='color:gray;'>" + objtile + "</font>";
                }

            }
            //未发布已过期 灰色
            if (Convert.ToDateTime(objendtime) < DateTime.Now)
            {
                return "<font style='color:gray;'>" + objtile + "</font>";
            }
            //未发布黑色 black
            return "<font style='color:black;'>" + objtile + "</font>";
        }
        /// <summary>
        /// 当存在事件激发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //当为修改时
            if (e.CommandName == "Upda")
            {
                Pbzx.Model.CM_Main cmian = ll.GetMain(Convert.ToInt32(e.CommandArgument));
                //执行修改
                if (cmian.BeginTime < DateTime.Now)
                    cmian.BeginTime = DateTime.Now;

                if (cmian.State == 0)
                {
                    //不发布代码
                    DbHelperSQL1.ExecuteSql("UPDATE CM_Main SET State = 1,BeginTime='" + cmian.BeginTime + "' WHERE (ID = " + e.CommandArgument + ") ");
                }
                else
                {
                    DbHelperSQL1.ExecuteSql("UPDATE CM_Main SET State = 0,BeginTime='" + cmian.BeginTime + "' WHERE (ID = " + e.CommandArgument + ") ");
                }

                Response.Redirect("SoftMessage_Manage_2011.aspx");
            }

        }

        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["order"] = e.SortExpression.ToString();
            if ((bool)ViewState["isDesc"])
            {
                ViewState["isDesc"] = false;
            }
            else
            {
                ViewState["isDesc"] = true;
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }
    }
}
