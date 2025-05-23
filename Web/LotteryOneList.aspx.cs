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
using System.Text;
using Pbzx.Common;
using Maticsoft.DBUtility;
using Pbzx.SQLServerDAL;

namespace Pbzx.Web
{
    public partial class LotteryOneList : System.Web.UI.Page
    {

        protected string riQi = "";
        protected string caizhongName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
// 关闭高频福彩和高频体彩 -- 徐修改 begin
//            string strClass = Request["class"];
//            if (string.IsNullOrEmpty(strClass) || !(strClass == "全国福彩" || strClass == "全国体彩" || strClass == "各省福彩" || strClass == "各省体彩"))
//            {
////                Pbzx.Common.ErrorLog.WriteLogMeng("strClass", strClass, true, true);
//                //                Response.Write("<script>top.location ='/Error.htm';</script>");
//                Response.End();
//                return;
//            }
// 关闭高频福彩和高频体彩 -- 徐修改 end

            if (Request.UrlReferrer == null && !Page.IsPostBack)
            {
//                Pbzx.Common.ErrorLog.WriteLogMeng("IsNullOrEmpty(str_Referrer)", "YES", true, true);
                //                Response.Write("<script>top.location ='/Error.htm';</script>");
                Response.End();
                return;
            }
            else if (Request.UrlReferrer != null && !Page.IsPostBack && !Request.UrlReferrer.ToString().ToLower().Contains("pinble.com"))
            {
//                Pbzx.Common.ErrorLog.WriteLogMeng("str_Referrer.Contains(pinble.com)", "YES", true, true);
                //                Response.Write("<script>top.location ='/Error.htm';</script>");
                Response.End();
                return;
            }

            Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["type"]))
                {
                    string type = Input.FilterAll(Input.Decrypt(Request["type"]));
                    ViewState["tableName"] = type;
//Pbzx.Common.ErrorLog.WriteLogMeng("tableName", type, true, true);
                    caizhongName = GetName();

//                    object objState = DbHelperSQL.GetSingle("select NvarName from PBnet_LotteryMenu where NvarApp_name='" + type + "' and BitState=1 and  BitIs_show=1 ");
//                    if (objState == null || string.IsNullOrEmpty(objState.ToString()))
//                    if (objState == null)
                    if (string.IsNullOrEmpty(caizhongName))
                    {
//                        Response.Write("<script>top.location ='/Error.htm';</script>");
                        Response.End();
                        return;
                    }
                    BindData();
                    this.MyGridView.Attributes.Add("bordercolor", "#B6CBE8");
                }
                else
                {
//                    Response.Write("<script>top.location ='/Error.htm';</script>");
                    Response.End();
                    return;

                }
            }
        }

        private string GetName()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request["lx"]))
                {
                    if (Request.QueryString["lx"].ToLower() == "pls")
                    {
                        return "排列三";
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return (string)DbHelperSQL.GetSingle("select top 1 NvarName from PBnet_LotteryMenu where NvarApp_name='" + ViewState["tableName"].ToString() + "' and BitState=1 and  BitIs_show=1 ");

                }
                    //     return Input.FilterAll(Input.Decrypt(Request["name"]));
//                return Request["name"];
//                Pbzx.Common.ErrorLog.WriteLogMeng("name", HttpUtility.UrlDecode(Request["name"], System.Text.Encoding.GetEncoding("GB2312")), true, true);
//                return HttpUtility.UrlDecode(Request["name"], System.Text.Encoding.GetEncoding("GB2312")); 
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private string GetNvarClass()
        {
            try
            {
                return (string)DbHelperSQL.GetSingle("select top 1 NvarClass from PBnet_LotteryMenu where NvarApp_name='" + Input.FilterAll(ViewState["tableName"].ToString()) + "' and BitState=1 and  BitIs_show=1 ");
//                return Input.FilterAll(Input.Decrypt(Request["class"]));
//                return Request["class"];
//                Pbzx.Common.ErrorLog.WriteLogMeng("class", HttpUtility.UrlDecode(Request["class"], System.Text.Encoding.GetEncoding("GB2312")), true, true);
//                return HttpUtility.UrlDecode(Request["class"], System.Text.Encoding.GetEncoding("GB2312"));
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private string GetLott_date()
        {
            try
            {
                return (string)DbHelperSQL.GetSingle("select NvarLott_date from PBnet_LotteryMenu where NvarApp_name='" + ViewState["tableName"].ToString() + "' and BitState=1 and  BitIs_show=1 ");
            }
            catch (Exception ex)
            {
                return "";
            }
        }



        private void BindData()
        {
            //if (!string.IsNullOrEmpty(Request["lx"]))
            //{
            //    if (Request.QueryString["lx"].ToLower() == "pls")
            //    {
            //        caizhongName = "排列三";
            //    }
            //}
            //else
            //{
            //    caizhongName = GetName();
            //}

            caizhongName = GetName();
            this.Title = caizhongName + "开奖详细信息_拼搏在线彩神通软件";

            if (caizhongName == "" || ViewState["tableName"] == null || ViewState["tableName"].ToString() == "")
            {
                this.litContent.Text = "";
                return;
            }
            object objTime = DbHelperSQL.GetSingle("select TimeList from PBnet_LotteryMenu where NvarApp_name='" + ViewState["tableName"].ToString() + "' ");
            if (objTime != null && !string.IsNullOrEmpty(objTime.ToString()))
            {
                string[] tmSZ = objTime.ToString().Split(new char[] { '|' });
                TimeSpan tsStart = new TimeSpan();
                if (!TimeSpan.TryParse(tmSZ[0], out tsStart))
                {
                    return;
                }

                TimeSpan tsEnd = new TimeSpan();
                if (!TimeSpan.TryParse(tmSZ[1], out tsEnd))
                {
                    return;
                }
                int jg = 0;
                tsEnd.Subtract(tsStart);
                while (tsStart < tsEnd)
                {
                    tsStart = tsStart.Add(TimeSpan.FromMinutes(1));
                    jg++;
                }
                if (caizhongName == "重庆时时彩")
                {
                    riQi = "每10分钟";
                }
                else
                {
                    riQi = "每" + jg.ToString() + "分钟";
                }
            }
            else
            {
                riQi = Method.GetLottDate1(GetLott_date());
            }

            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
//            string order = "Issue desc";
            int myCount = 0;
            //获取分页数据
            //CstGetRecordFromPagesDs
            DataTable lsResult = Basic.CstGetRecordFromPagesDs(ViewState["tableName"].ToString(), "*", "", "issue", 40, AspNetPager1.CurrentPageIndex, true, 2, Searchstr, out myCount);
            //设置datakey
            string[] keys = new string[] { };
            ArrayList listKey = new ArrayList();
            listKey.Add("issue");

            string strAllInfo = "";
            if (ViewState["LottTypeInfo"] != null && ViewState["LottTypeInfo"].ToString() != "")
            {
                strAllInfo = ViewState["LottTypeInfo"].ToString();
            }
            else
            {
                strAllInfo = DbHelperSQL.GetSingle("select top 1 LottTypeInfo from PBnet_LotteryMenu where NvarApp_name='" + ViewState["tableName"].ToString() + "'  ").ToString();
                ViewState["LottTypeInfo"] = strAllInfo;
            }

            string[] lottTypeInfoSZ = strAllInfo.Split(new char[] { '|' });

            string[] strInfo1 = null;
            strInfo1 = lottTypeInfoSZ[0].Split(new char[] { ',' });

            listKey.Add(strInfo1[4]);
            if (lottTypeInfoSZ.Length > 1 && !string.IsNullOrEmpty(lottTypeInfoSZ[1]))
            {
                string[] strInfo2 = lottTypeInfoSZ[1].Split(new char[] { ',' });
                listKey.Add(strInfo2[4]);
            }
            keys = (string[])listKey.ToArray(typeof(string)); // 转换成Type类型数组
            MyGridView.DataKeyNames = keys;

            //绑定
            this.MyGridView.DataSource = lsResult;


            // 下面的绑定数据可以保持 不过也要清零列不然后出现很多重复列




            //if (ViewState["tableName"].ToString() == "FC3DData")
            //{
            //    System.Web.UI.WebControls.BoundField customField = new BoundField();
            //    customField.DataField = lsResult.Columns["testcode"].ColumnName;
            //    customField.HeaderText = "期号";
            //    customField.HeaderStyle.CssClass = "L_zi1";
            //    MyGridView.Columns.Insert(1, customField);


            //    System.Web.UI.WebControls.BoundField customFieldJI = new BoundField();
            //    customFieldJI.DataField = lsResult.Columns["machine"].ColumnName;
            //    customFieldJI.HeaderText = "机";
            //    customFieldJI.HeaderStyle.CssClass = "L_zi1";
            //    MyGridView.Columns.Insert(2, customFieldJI);


            //    System.Web.UI.WebControls.BoundField customFieldQiu = new BoundField();
            //    customFieldQiu.DataField = lsResult.Columns["ball"].ColumnName;
            //    customFieldQiu.HeaderText = "球";
            //    customFieldQiu.HeaderStyle.CssClass = "L_zi1";
            //    MyGridView.Columns.Insert(3, customFieldQiu);           
            //}



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
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 40;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "共<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页共<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["Title"]))
            {

            }
            if (Request["Search"] != null)
            {
            }
            return bu1.ToString();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string name = GetName();

                #region 处理开奖号码显示
                string strAllInfo = DbHelperSQL.GetSingle("select top 1 LottTypeInfo from PBnet_LotteryMenu where NvarApp_name='" + ViewState["tableName"].ToString() + "'  ").ToString();
                string[] lottTypeInfoSZ = strAllInfo.Split(new char[] { '|' });
                string[] strInfo1 = lottTypeInfoSZ[0].Split(new char[] { ',' });

                string qianCode = MyGridView.DataKeys[e.Row.RowIndex].Values[strInfo1[4]].ToString();
                string houCode = "";

                string result = "";
                qianCode = MyGridView.DataKeys[e.Row.RowIndex].Values[strInfo1[4]].ToString();
                //前区
                if ("快乐8" == name)
                {
                    int mycount = 1;
                    string[] redCodes = Method.FormartCode(qianCode, " ").Split(new char[] { ' ' });
                    foreach (string tempRedCode in redCodes)
                    {
                        if (mycount == 11)
                        {
                            result += "<br>" + tempRedCode + " ";
                        }
                        else if (mycount == 10 || mycount == 20)
                        {
                            result += tempRedCode;
                        }
                        else
                        {
                            result += tempRedCode + " ";
                        }
                        mycount++;
                    }
                }
                else if (strInfo1[5] == "乐透型" || strInfo1[5] == "按位乐透型")
                {
                    string[] redCodes = Method.FormartCode(qianCode, " ").Split(new char[] { ' ' });
                    foreach (string tempRedCode in redCodes)
                    {
                        result += tempRedCode + " ";
                    }
                }
                else
                {
                    char[] M3Dcode = qianCode.ToCharArray();
                    foreach (char tempChar in M3Dcode)
                    {
                        result += tempChar.ToString();
                    }
                }

                //后区
                if (lottTypeInfoSZ.Length > 1 && !string.IsNullOrEmpty(lottTypeInfoSZ[1]))
                {
                    string[] strInfo2 = lottTypeInfoSZ[1].Split(new char[] { ',' });
                    houCode = MyGridView.DataKeys[e.Row.RowIndex].Values[strInfo2[4]].ToString();
                    if ("排列五" == name)
                    { }
                    else if ("东方6＋1" == name)
                    {
                        string sx = "鼠牛虎兔龙蛇马羊猴鸡狗猪";
                        result += " + ";
                        if (houCode.Trim().Length < 2)
                        {
                            houCode = "0" + houCode;
                        }
                        result += houCode;

                        result += "(" + sx.Substring(int.Parse(houCode) - 1, 1) + ") ";

                    }
                    else
                    {
                        if (strInfo2[5] == "乐透型" || strInfo2[5] == "按位乐透型")
                        {
                            string[] redCodes = Method.FormartCode(houCode, " ").Split(new char[] { ' ' });
                            result += "+ ";
                            foreach (string tempRedCode in redCodes)
                            {
                                result += tempRedCode + " ";
                            }
                        }
                        else
                        {
                            char[] M3Dcode = houCode.ToCharArray();
                            foreach (char tempChar in M3Dcode)
                            {
                                result += " + ";
                                result += tempChar.ToString() + " ";
                            }
                        }
                    }
                }
                // result += "</tr></table>";
                //if (ViewState["tableName"].ToString() == "FC3DData")
                //{
                //    ((Label)e.Row.Cells[4].FindControl("lblHao")).Text = result;
                //}
                //else
                //{
                if (!string.IsNullOrEmpty(Request["lx"]))
                {
                    if (Request.QueryString["lx"].ToLower() == "pls")
                    {
                        ((Label)e.Row.Cells[2].FindControl("lblHao")).Text = result.Substring(0, 3);
                    }
                }
                else
                {
                    ((Label)e.Row.Cells[2].FindControl("lblHao")).Text = result;
                }
                //}
                #endregion
            }
        }

        /// <summary>
        /// 格式化时间
        /// </summary>
        protected string FormatData(object objDate)
        {
            // string name = GetName();
            string NvarClass = GetNvarClass();
            if (NvarClass == "高频福彩" || NvarClass == "高频体彩")
            {
                return string.Format("{0:yyyy-MM-dd  HH:mm}", (DateTime)objDate);
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd}", (DateTime)objDate);
            }
        }
    }
}
