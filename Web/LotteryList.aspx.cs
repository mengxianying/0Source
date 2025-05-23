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
using Maticsoft.DBUtility;

namespace Pbzx.Web
{
    public partial class LotteryList : System.Web.UI.Page
    {
        public string ClassName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
//            if (Request.UrlReferrer == null || !(Request.UrlReferrer.Host == "pinble.com" || Request.UrlReferrer.Host == ConfigurationManager.AppSettings["HostName"]))
            if ((Request.UrlReferrer == null && !Page.IsPostBack))
            {
//                Response.Write("<script>top.location ='/Error.htm';</script>");
                Response.End();
                return;
            }
            else if (Request.UrlReferrer != null && !Page.IsPostBack && !Request.UrlReferrer.ToString().ToLower().Contains("pinble.com"))
            {
//                Response.Write("<script>top.location ='/Error.htm';</script>");
                Response.End();
                return;
            }
            Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!Page.IsPostBack)
            {
                if (Request["type"] != null)
                {
                    string type = Input.FilterAll(Input.Decrypt(Request["type"]));
                    ClassName = type;
                    BindData(type);
                }
                else
                {
                    BindData("全国开奖");
                    ClassName = "全国开奖";
                }

            }
            this.Title = ClassName + "开奖信息_拼搏在线彩神通软件";
        }


        private string GetName()
        {
            return (string)DbHelperSQL.GetSingle("select NvarName from PBnet_LotteryMenu where NvarApp_name='" + Input.FilterAll(ViewState["tableName"].ToString()) + "' and BitState=1 and  BitIs_show=1 ");
        }




        private void BindData(string type)
        {

            Pbzx.Common.MyXML xml = new Pbzx.Common.MyXML("\\xml\\QuanGuoCpDate.xml");
            XmlNode root = xml.GetXmlRoot();
            //全国福彩
            XmlNode QGFC = root.SelectSingleNode("/CpDate/QGFC");
            //全国体彩
            XmlNode QGTC = root.SelectSingleNode("/CpDate/QGTC");

            Pbzx.BLL.PBnet_LotteryMenu lotteryMenuBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataSet ds = lotteryMenuBLL.GetList(" BitState=1 and BitIs_show=1  and NvarClass='" + type + "' order by NvarOrderId  ");

            switch (type)
            {
                case "全国开奖":
                    foreach (XmlNode tempNode in QGFC.ChildNodes)
                    {
                        string issue = "";
                        string date = "";
                        string code = "";

                        if (tempNode.Attributes["app"].Value == "WWLHCData_XiangGang" || "LHC" == tempNode.Name)
                        {
                            break;
                        }
                        if (tempNode.Attributes["app"].Value == "FC3DData")
                        {
                            DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + tempNode.Attributes["app"].Value + " where code IS NOT NULL and len(code)>0  order by issue desc").Tables[0];

                            issue = dtWeb.Rows[0]["issue"].ToString();
                            date = dtWeb.Rows[0]["date"].ToString();
                            code = dtWeb.Rows[0]["code"].ToString();
                        }
                        else
                        {
                            issue = tempNode.Attributes["issue"].Value;
                            date = tempNode.Attributes["date"].Value;
                        }

                        //彩种列
                        HtmlTableCell cellName = new HtmlTableCell();
                        if (tempNode.Attributes["app"].Value == "FC3DData")
                        {
                            cellName.InnerHtml = "<a href='/LotteryOneList3D.aspx?name=" + tempNode.Attributes["name"].Value + "' target='_self' class='caibiao1' >" + tempNode.Attributes["name"].Value + "</a>";
                            cellName.Align = "left";
                            cellName.Attributes.Add("class", "left_top left_pd");
                            cellName.Width = "137px";
                            cellName.Height = "26px";
                        }
                        else
                        {
//                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "&class=全国福彩&name=" + tempNode.Attributes["name"].Value + "' target='_self' class='caibiao1' >" + tempNode.Attributes["name"].Value + "</a>";
                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "' target='_self' class='caibiao1' >" + tempNode.Attributes["name"].Value + "</a>";
                            cellName.Align = "left";
                            cellName.Attributes.Add("class", "left_top left_pd");
                            cellName.Width = "137px";
                            cellName.Height = "26px";
                        }


                        //期号列
                        HtmlTableCell cellIssue = new HtmlTableCell();
                        cellIssue.InnerText = issue;
                        cellIssue.BgColor = "#FFFFFF";
                        cellIssue.Align = "center";
                        cellIssue.Width = "81px";
                        cellIssue.Height = "26px";

                        //开奖日期列
                        HtmlTableCell cellDate = new HtmlTableCell();
                        cellDate.InnerText = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(date));

                        cellDate.BgColor = "#FFFFFF";
                        cellDate.Align = "center";
                        cellDate.Width = "116px";
                        cellDate.Height = "26px";

                        //中奖号码列
                        HtmlTableCell cellCode = new HtmlTableCell();
                        //双色球
                        if ("双色球" == tempNode.Name)
                        {
                            cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                            string[] redCodes = Method.FormartCode(tempNode.Attributes["redcode"].Value, " ").Split(new char[] { ' ' });
                            foreach (string tempRedCode in redCodes)
                            {
                                cellCode.InnerHtml += "<td class='Lred'>" + tempRedCode + "</td>";
                            }
                            cellCode.InnerHtml += "<td class='Lblue'>" + tempNode.Attributes["bluecode"].Value + "</td>";
                            cellCode.InnerHtml += "</tr></table>";
                        }
                        else if ("_3D" == tempNode.Name)
                        {
                            cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                            char[] M3Dcode = code.ToCharArray();
                            if (M3Dcode.Length > 1)
                            {
                                foreach (char tempChar in M3Dcode)
                                {
                                    cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                }
                            }
                            cellCode.InnerHtml += "</tr></table>";
                        }
                        else if ("东方6X1" == tempNode.Name)
                        {
                            cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                            char[] M3Dcode = tempNode.Attributes["code"].Value.ToCharArray();
                            foreach (char tempChar in M3Dcode)
                            {
                                cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                            }
                            //string sx = "鼠牛虎兔龙蛇马羊猴鸡狗猪";
                            cellCode.InnerHtml += "<td class='Lblue'>" + tempNode.Attributes["tcode"].Value + "</td>";//sx.Substring(int.Parse(     ) - 1, 1)
                            cellCode.InnerHtml += "</tr></table>";
                        }
                        else
                        {
                            cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                            string[] redCodes = Method.FormartCode(tempNode.Attributes["code"].Value, " ").Split(new char[] { ' ' });
                            foreach (string tempRedCode in redCodes)
                            {
                                cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                            }
                            if (tempNode.Attributes["tcode"] != null)
                            {
                                cellCode.InnerHtml += "<td class='Lblue'>" + tempNode.Attributes["tcode"].Value + "</td>";
                            }

                            cellCode.InnerHtml += "</tr></table>";
                        }
                        cellCode.BgColor = "#FFFFFF";
                        cellCode.VAlign = "bottom";
                        cellCode.Width = "342px";
                        cellCode.Height = "26px";
                        cellCode.Align = "left";

                        //开奖历史列
                        HtmlTableCell cellLS = new HtmlTableCell();
                        if (tempNode.Attributes["app"].Value == "FC3DData")
                        {
                            cellLS.InnerHtml = "<a href='/LotteryOneList3D.aspx?name=3D' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                            cellLS.BgColor = "#FFFFFF";
                            cellLS.Align = "center";
                            cellLS.Width = "73px";
                            cellLS.Height = "26px";
                        }
                        else
                        {
//                            cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "&class=全国福彩&name=" + tempNode.Attributes["name"].Value + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                            cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                            cellLS.BgColor = "#FFFFFF";
                            cellLS.Align = "center";
                            cellLS.Width = "73px";
                            cellLS.Height = "26px";
                        }
//                        cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "&name=" + tempNode.Attributes["name"].Value + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
//                        cellLS.BgColor = "#FFFFFF";
//                        cellLS.Align = "center";
//                        cellLS.Width = "73px";
//                        cellLS.Height = "26px";

                        //开奖日列
                        HtmlTableCell cellLott_date = new HtmlTableCell();
                        cellLott_date.InnerHtml = Method.GetLottDate1(tempNode.Attributes["lott_date"].Value);
                        cellLott_date.BgColor = "#FFFFFF";
                        cellLott_date.Align = "center";
                        cellLott_date.Width = "134px";
                        cellLott_date.Height = "26px";

                        HtmlTableRow tempRow = new HtmlTableRow();
                        tempRow.Cells.Add(cellName);
                        tempRow.Cells.Add(cellDate);
                        tempRow.Cells.Add(cellIssue);
                        tempRow.Cells.Add(cellCode);
                        tempRow.Cells.Add(cellLS);
                        tempRow.Cells.Add(cellLott_date);
                        tb1.Rows.Add(tempRow);
                    }
                    //全国体彩
                    foreach (XmlNode tempNode in QGTC.ChildNodes)
                    {
                        //彩种列
                        HtmlTableCell cellName = new HtmlTableCell();
                        if ("排列五" == tempNode.Name)
                        {
//                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "&class=全国体彩&name=排列五' target='_self' class='caibiao1' >" + "排列五" + "</a>";
                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "' target='_self' class='caibiao1' >" + "排列五" + "</a>";
                        }
                        else
                        {
//                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "&class=全国体彩&name=" + tempNode.Attributes["name"].Value + "' target='_self' class='caibiao1' >" + tempNode.Attributes["name"].Value + "</a>";
                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "' target='_self' class='caibiao1' >" + tempNode.Attributes["name"].Value + "</a>";
                        }

                        cellName.Align = "left";
                        cellName.Attributes.Add("class", "left_top left_pd");
                        cellName.Width = "137px";
                        cellName.Height = "26px";


                        //期号列
                        HtmlTableCell cellIssue = new HtmlTableCell();
                        cellIssue.InnerText = tempNode.Attributes["issue"].Value;
                        cellIssue.BgColor = "#FFFFFF";
                        cellIssue.Align = "center";
                        cellIssue.Width = "81px";
                        cellIssue.Height = "26px";


                        //开奖日期列
                        HtmlTableCell cellDate = new HtmlTableCell();
                        cellDate.InnerText = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(tempNode.Attributes["date"].Value));
                        cellDate.BgColor = "#FFFFFF";
                        cellDate.Align = "center";
                        cellDate.Width = "116px";
                        cellDate.Height = "26px";


                        //中奖号码列
                        HtmlTableCell cellCode = new HtmlTableCell();

                        //双色球
                        if ("排列五" == tempNode.Name)
                        {
                            cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                            char[] redCodes = tempNode.Attributes["code5"].Value.ToCharArray();
                            foreach (char tempChar in redCodes)
                            {
                                cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                            }
                            cellCode.InnerHtml += "</tr></table>";


                        }
                        else
                        {
                            if ("七星彩" == tempNode.Name)
                            {
                                cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                char[] M3Dcode = tempNode.Attributes["code"].Value.ToCharArray();
                                if (M3Dcode.Length > 1)
                                {
                                    foreach (char tempChar in M3Dcode)
                                    {
                                        cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                    }
                                    cellCode.InnerHtml += "<td class='Lblue'>" + tempNode.Attributes["tcode"].Value + "</td>";

                                }
                                //if (!string.IsNullOrEmpty(tempNode.Attributes["tcode"].Value))
                                //{
                                //    cellCode.InnerHtml += "<td class='Lblue'>" + tempNode.Attributes["tcode"].Value + "</td>";
                                //}
                                cellCode.InnerHtml += "</tr></table>";
                            }
                            else
                            {
                                cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                string[] redCodes = Method.FormartCode(tempNode.Attributes["code"].Value, " ").Split(new char[] { ' ' });
                                //Lred
                                if ("大乐透" == tempNode.Name)
                                {
                                    foreach (string tempRedCode in redCodes)
                                    {
                                        cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                    }
                                    if (tempNode.Attributes["code2"].Value.Length == 4)
                                    {
                                        cellCode.InnerHtml += "<td class='Lblue'>" + tempNode.Attributes["code2"].Value.Substring(0, 2) + "</td>";
                                        cellCode.InnerHtml += "<td class='Lblue'>" + tempNode.Attributes["code2"].Value.Substring(2, 2) + "</td>";
                                    }
                                }
                                else
                                {
                                    foreach (string tempRedCode in redCodes)
                                    {
                                        cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                    }
                                    if (tempNode.Attributes["tcode"] != null)
                                    {
                                        cellCode.InnerHtml += "<td class='Lblue'>" + tempNode.Attributes["tcode"].Value + "</td>";
                                    }
                                }
                                cellCode.InnerHtml += "</tr></table>";
                            }
                        }
                        cellCode.BgColor = "#FFFFFF";
                        cellCode.VAlign = "bottom";
                        cellCode.Width = "342px";
                        cellCode.Height = "26px";
                        cellCode.Align = "left";





                        //开奖历史列
                        HtmlTableCell cellLS = new HtmlTableCell();
//                        cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "&class=全国体彩&name=" + tempNode.Attributes["name"].Value + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                        cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                        cellLS.BgColor = "#FFFFFF";
                        cellLS.Align = "center";
                        cellLS.Width = "73px";
                        cellLS.Height = "26px";


                        //开奖日列
                        HtmlTableCell cellLott_date = new HtmlTableCell();
                        cellLott_date.InnerHtml = Method.GetLottDate1(tempNode.Attributes["lott_date"].Value);
                        cellLott_date.BgColor = "#FFFFFF";
                        cellLott_date.Align = "center";
                        cellLott_date.Width = "134px";
                        cellLott_date.Height = "26px";



                        HtmlTableRow tempRow = new HtmlTableRow();
                        tempRow.Cells.Add(cellName);
                        tempRow.Cells.Add(cellDate);
                        tempRow.Cells.Add(cellIssue);
                        tempRow.Cells.Add(cellCode);
                        tempRow.Cells.Add(cellLS);
                        tempRow.Cells.Add(cellLott_date);



                        if ("排列五" == tempNode.Name)
                        {
                            //排列3用的彩种列
                            HtmlTableCell cellName1 = new HtmlTableCell();
//                            cellName1.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "&class=全国体彩&lx=pls&name=排列三' target='_self' class='caibiao1' >" + "排列三" + "</a>";
                            cellName1.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "' target='_self' class='caibiao1' >" + "排列三" + "</a>";
                            cellName1.Align = "left";
                            cellName1.Attributes.Add("class", "left_top left_pd");
                            cellName1.Width = "137px";
                            cellName1.Height = "26px";

                            //排列3用的期号列
                            HtmlTableCell cellIssue1 = new HtmlTableCell();
                            cellIssue1.InnerText = tempNode.Attributes["issue"].Value;
                            cellIssue1.BgColor = "#FFFFFF";
                            cellIssue1.Align = "center";
                            cellIssue1.Width = "81px";
                            cellIssue1.Height = "26px";

                            //排列3用的开奖日期列
                            HtmlTableCell cellDate1 = new HtmlTableCell();
                            cellDate1.InnerText = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(tempNode.Attributes["date"].Value));
                            cellDate1.BgColor = "#FFFFFF";
                            cellDate1.Align = "center";
                            cellDate1.Width = "116px";
                            cellDate1.Height = "26px";

                            //排列3中奖号码列
                            HtmlTableCell cellCode1 = new HtmlTableCell();
                            //双色球
                            if ("排列五" == tempNode.Name)
                            {
                                cellCode1.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                char[] redCodes = tempNode.Attributes["code5"].Value.Substring(0, 3).ToCharArray();
                                foreach (char tempChar in redCodes)
                                {
                                    cellCode1.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                }
                                cellCode1.InnerHtml += "</tr></table>";


                            }
                            cellCode1.BgColor = "#FFFFFF";
                            cellCode1.VAlign = "bottom";
                            cellCode1.Width = "342px";
                            cellCode1.Height = "26px";
                            cellCode1.Align = "left";

                            //排列3用的开奖历史列
                            HtmlTableCell cellLS1 = new HtmlTableCell();
//                            cellLS1.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "&class=全国体彩&lx=pls&name=排列三' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                            cellLS1.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(tempNode.Attributes["app"].Value) + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                            cellLS1.BgColor = "#FFFFFF";
                            cellLS1.Align = "center";
                            cellLS1.Width = "73px";
                            cellLS1.Height = "26px";
                            //排列3用的开奖日列
                            HtmlTableCell cellLott_date1 = new HtmlTableCell();
                            cellLott_date1.InnerHtml = Method.GetLottDate1(tempNode.Attributes["lott_date"].Value);
                            cellLott_date1.BgColor = "#FFFFFF";
                            cellLott_date1.Align = "center";
                            cellLott_date1.Width = "134px";
                            cellLott_date1.Height = "26px";

                            //排列3专用
                            HtmlTableRow tempRow1 = new HtmlTableRow();
                            tempRow1.Cells.Add(cellName1);
                            tempRow1.Cells.Add(cellDate1);
                            tempRow1.Cells.Add(cellIssue1);
                            tempRow1.Cells.Add(cellCode1);
                            tempRow1.Cells.Add(cellLS1);
                            tempRow1.Cells.Add(cellLott_date1);

                            tb1.Rows.Add(tempRow1);
                        }


                        tb1.Rows.Add(tempRow);
                    }
                    break;
                case "各省福彩":
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                            string issue = dtWeb.Rows[0]["issue"].ToString();
                            string date = dtWeb.Rows[0]["date"].ToString();
                            string code = dtWeb.Rows[0]["code"].ToString();
                            bool tcode = dtWeb.Columns.Contains("tcode");
                            //彩种列
                            HtmlTableCell cellName = new HtmlTableCell();
//                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=各省福彩&name=" + row["NvarName"].ToString() + "' target='_self' class='caibiao1' >" + row["NvarName"].ToString() + "</a>";
                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='_self' class='caibiao1' >" + row["NvarName"].ToString() + "</a>";
                            cellName.Align = "left";
                            cellName.Attributes.Add("class", "left_top left_pd");
                            cellName.Width = "137px";
                            cellName.Height = "26px";

                            //期号列
                            HtmlTableCell cellIssue = new HtmlTableCell();
                            cellIssue.InnerText = issue;
                            cellIssue.BgColor = "#FFFFFF";
                            cellIssue.Align = "center";
                            cellIssue.Width = "81px";
                            cellIssue.Height = "26px";

                            //开奖日期列
                            HtmlTableCell cellDate = new HtmlTableCell();
                            cellDate.InnerText = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(date));
                            cellDate.BgColor = "#FFFFFF";
                            cellDate.Align = "center";
                            cellDate.Width = "116px";
                            cellDate.Height = "26px";

                            //中奖号码列
                            HtmlTableCell cellCode = new HtmlTableCell();
                            object objCpInfo = row["LottTypeInfo"];
                            object objLottTypeCount = row["LottTypeCount"];
                            if (objCpInfo != null && !string.IsNullOrEmpty(objCpInfo.ToString()) && objLottTypeCount != null && !string.IsNullOrEmpty(objLottTypeCount.ToString()))
                            {

                                if (Convert.ToInt32(objLottTypeCount) < 2)
                                {
                                    if ("数字型,扑克型".Contains(objCpInfo.ToString().Split(new char[] { ',' })[5]))
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='0'><tr>";
                                        char[] M3Dcode = code.ToCharArray();
                                        if (M3Dcode.Length > 1)
                                        {
                                            foreach (char tempChar in M3Dcode)
                                            {
                                                cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                            }
                                        }
                                        cellCode.InnerHtml += "</tr></table>";
                                    }
                                    else
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='0'><tr>";
                                        string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                        foreach (string tempRedCode in redCodes)
                                        {
                                            cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                        }
                                        cellCode.InnerHtml += "</tr></table>";
                                    }
                                }
                                else
                                {
                                    string[] sz = objCpInfo.ToString().Split(new char[] { '|' });
                                    string qian = sz[0];
                                    string hou = sz[1];
                                    if ("数字型,扑克型".Contains(qian.Split(new char[] { ',' })[5]))
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='0'><tr>";
                                        char[] M3Dcode = code.ToCharArray();
                                        if (M3Dcode.Length > 1)
                                        {
                                            foreach (char tempChar in M3Dcode)
                                            {
                                                cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='0'><tr>";
                                        string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                        foreach (string tempRedCode in redCodes)
                                        {
                                            cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                        }
                                    }
                                    cellCode.InnerHtml += "<td class='Lblue'>" + dtWeb.Rows[0][hou.Split(new char[] { ',' })[4]].ToString() + "</td>";
                                    cellCode.InnerHtml += "</tr></table>";
                                }
                                cellCode.BgColor = "#FFFFFF";
                                cellCode.VAlign = "bottom";
                                cellCode.Width = "342px";
                                cellCode.Height = "26px";
                                cellCode.Align = "left";

                                //开奖历史列
                                HtmlTableCell cellLS = new HtmlTableCell();
//                                cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=各省福彩&name=" + row["NvarName"].ToString() + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                                cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                                cellLS.BgColor = "#FFFFFF";
                                cellLS.Align = "center";
                                cellLS.Width = "73px";
                                cellLS.Height = "26px";

                                //开奖日列
                                HtmlTableCell cellLott_date = new HtmlTableCell();
                                cellLott_date.InnerHtml = Method.GetLottDate1(row["NvarLott_date"].ToString());
                                cellLott_date.BgColor = "#FFFFFF";
                                cellLott_date.Align = "center";
                                cellLott_date.Width = "134px";
                                cellLott_date.Height = "26px";

                                HtmlTableRow tempRow = new HtmlTableRow();
                                tempRow.Cells.Add(cellName);
                                tempRow.Cells.Add(cellDate);
                                tempRow.Cells.Add(cellIssue);
                                tempRow.Cells.Add(cellCode);
                                tempRow.Cells.Add(cellLS);
                                tempRow.Cells.Add(cellLott_date);
                                tb1.Rows.Add(tempRow);
                            }
                        }
                    }
                    break;
                case "各省体彩":

                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                            string issue = dtWeb.Rows[0]["issue"].ToString();
                            string date = dtWeb.Rows[0]["date"].ToString();
                            string code = dtWeb.Rows[0]["code"].ToString();
                            bool tcode = dtWeb.Columns.Contains("tcode");
                            //彩种列
                            HtmlTableCell cellName = new HtmlTableCell();
//                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=各省体彩&name=" + row["NvarName"].ToString() + "' target='_self' class='caibiao1' >" + row["NvarName"].ToString() + "</a>";
                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='_self' class='caibiao1' >" + row["NvarName"].ToString() + "</a>";
                            cellName.Align = "left";
                            cellName.Attributes.Add("class", "left_top left_pd");
                            cellName.Width = "137px";
                            cellName.Height = "26px";

                            //期号列
                            HtmlTableCell cellIssue = new HtmlTableCell();
                            cellIssue.InnerText = issue;
                            cellIssue.BgColor = "#FFFFFF";
                            cellIssue.Align = "center";
                            cellIssue.Width = "81px";
                            cellIssue.Height = "26px";

                            //开奖日期列
                            HtmlTableCell cellDate = new HtmlTableCell();
                            cellDate.InnerText = string.Format("{0:yyyy-MM-dd}", DateTime.Parse(date));
                            cellDate.BgColor = "#FFFFFF";
                            cellDate.Align = "center";
                            cellDate.Width = "116px";
                            cellDate.Height = "26px";

                            //中奖号码列
                            HtmlTableCell cellCode = new HtmlTableCell();
                            object objCpInfo = row["LottTypeInfo"];
                            object objLottTypeCount = row["LottTypeCount"];
                            if (objCpInfo != null && !string.IsNullOrEmpty(objCpInfo.ToString()) && objLottTypeCount != null && !string.IsNullOrEmpty(objLottTypeCount.ToString()))
                            {

                                if (Convert.ToInt32(objLottTypeCount) < 2)
                                {
                                    if ("数字型,扑克型".Contains(objCpInfo.ToString().Split(new char[] { ',' })[5]))
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        char[] M3Dcode = code.ToCharArray();
                                        if (M3Dcode.Length > 1)
                                        {
                                            foreach (char tempChar in M3Dcode)
                                            {
                                                cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                            }
                                        }
                                        cellCode.InnerHtml += "</tr></table>";
                                    }
                                    else
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                        foreach (string tempRedCode in redCodes)
                                        {
                                            cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                        }
                                        cellCode.InnerHtml += "</tr></table>";
                                    }
                                }
                                else
                                {
                                    string[] sz = objCpInfo.ToString().Split(new char[] { '|' });
                                    string qian = sz[0];
                                    string hou = sz[1];
                                    if ("数字型,扑克型".Contains(qian.Split(new char[] { ',' })[5]))
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        char[] M3Dcode = code.ToCharArray();
                                        if (M3Dcode.Length > 1)
                                        {
                                            foreach (char tempChar in M3Dcode)
                                            {
                                                cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                        foreach (string tempRedCode in redCodes)
                                        {
                                            cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                        }
                                    }
                                    cellCode.InnerHtml += "<td class='Lblue'>" + dtWeb.Rows[0][hou.Split(new char[] { ',' })[4]].ToString() + "</td>";
                                    cellCode.InnerHtml += "</tr></table>";
                                }
                                ////双色球
                                //if ("黑龙江6＋1,江苏5＋1,江苏七星彩,天津6＋1,浙江6＋1,海南4＋1".IndexOf(row["NvarName"].ToString()) > -1)
                                //{

                                //    cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                //    char[] M3Dcode = code.ToCharArray();
                                //    if (M3Dcode.Length > 1)
                                //    {
                                //        foreach (char tempChar in M3Dcode)
                                //        {
                                //            cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                //        }
                                //    }
                                //    if (tcode)
                                //    {
                                //        cellCode.InnerHtml += "<td class='Lblue'>" + dtWeb.Rows[0]["tcode"].ToString() + "</td>";
                                //    }
                                //    cellCode.InnerHtml += "</tr></table>";
                                //}
                                //else
                                //{
                                //    cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                //    string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                //    foreach (string tempRedCode in redCodes)
                                //    {
                                //        cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                //    }
                                //    if (tcode)
                                //    {
                                //        cellCode.InnerHtml += "<td class='Lblue'>" + dtWeb.Rows[0]["tcode"].ToString() + "</td>";
                                //    }
                                //    cellCode.InnerHtml += "</tr></table>";
                                //}
                                cellCode.BgColor = "#FFFFFF";
                                cellCode.VAlign = "bottom";
                                cellCode.Width = "342px";
                                cellCode.Height = "26px";
                                cellCode.Align = "left";

                                //开奖历史列
                                HtmlTableCell cellLS = new HtmlTableCell();
//                                cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=各省体彩&name=" + row["NvarName"].ToString() + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                                cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                                cellLS.BgColor = "#FFFFFF";
                                cellLS.Align = "center";
                                cellLS.Width = "73px";
                                cellLS.Height = "26px";

                                //开奖日列
                                HtmlTableCell cellLott_date = new HtmlTableCell();
                                cellLott_date.InnerHtml = Method.GetLottDate1(row["NvarLott_date"].ToString());
                                cellLott_date.BgColor = "#FFFFFF";
                                cellLott_date.Align = "center";
                                cellLott_date.Width = "134px";
                                cellLott_date.Height = "26px";

                                HtmlTableRow tempRow = new HtmlTableRow();
                                tempRow.Cells.Add(cellName);
                                tempRow.Cells.Add(cellDate);
                                tempRow.Cells.Add(cellIssue);
                                tempRow.Cells.Add(cellCode);
                                tempRow.Cells.Add(cellLS);
                                tempRow.Cells.Add(cellLott_date);


                                tb1.Rows.Add(tempRow);
                            }
                        }
                    }
                    break;
                case "高频福彩":
                    break;
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                            string issue = dtWeb.Rows[0]["issue"].ToString();
                            string date = dtWeb.Rows[0]["date"].ToString();
                            string code = dtWeb.Rows[0]["code"].ToString();
                            bool tcode = dtWeb.Columns.Contains("tcode");
                            //彩种列
                            HtmlTableCell cellName = new HtmlTableCell();
//                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=高频福彩&name=" + row["NvarName"].ToString() + "' target='_self' class='caibiao1' >" + row["NvarName"].ToString() + "</a>";
                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='_self' class='caibiao1' >" + row["NvarName"].ToString() + "</a>";
                            cellName.Align = "left";
                            cellName.Attributes.Add("class", "left_top left_pd");
                            cellName.Width = "137px";
                            cellName.Height = "26px";

                            //期号列
                            HtmlTableCell cellIssue = new HtmlTableCell();
                            cellIssue.InnerText = issue;
                            cellIssue.BgColor = "#FFFFFF";
                            cellIssue.Align = "center";
                            cellIssue.Width = "81px";
                            cellIssue.Height = "26px";

                            //开奖日期列
                            HtmlTableCell cellDate = new HtmlTableCell();
                            cellDate.InnerText = string.Format("{0:yyyy-MM-dd HH:mm}", DateTime.Parse(date));
                            cellDate.BgColor = "#FFFFFF";
                            cellDate.Align = "center";
                            cellDate.Width = "116px";
                            cellDate.Height = "26px";

                            //中奖号码列
                            HtmlTableCell cellCode = new HtmlTableCell();
                            object objCpInfo = row["LottTypeInfo"];
                            object objLottTypeCount = row["LottTypeCount"];
                            if (objCpInfo != null && !string.IsNullOrEmpty(objCpInfo.ToString()) && objLottTypeCount != null && !string.IsNullOrEmpty(objLottTypeCount.ToString()))
                            {

                                if (Convert.ToInt32(objLottTypeCount) < 2)
                                {
                                    if ("数字型,扑克型".Contains(objCpInfo.ToString().Split(new char[] { ',' })[5]))
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        char[] M3Dcode = code.ToCharArray();
                                        if (M3Dcode.Length > 1)
                                        {
                                            foreach (char tempChar in M3Dcode)
                                            {
                                                cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                            }
                                        }
                                        cellCode.InnerHtml += "</tr></table>";
                                    }
                                    else
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                        foreach (string tempRedCode in redCodes)
                                        {
                                            cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                        }
                                        cellCode.InnerHtml += "</tr></table>";
                                    }
                                }
                                else
                                {
                                    string[] sz = objCpInfo.ToString().Split(new char[] { '|' });
                                    string qian = sz[0];
                                    string hou = sz[1];
                                    if ("数字型,扑克型".Contains(qian.Split(new char[] { ',' })[5]))
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        char[] M3Dcode = code.ToCharArray();
                                        if (M3Dcode.Length > 1)
                                        {
                                            foreach (char tempChar in M3Dcode)
                                            {
                                                cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                        foreach (string tempRedCode in redCodes)
                                        {
                                            cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                        }
                                    }
                                    cellCode.InnerHtml += "<td class='Lblue'>" + dtWeb.Rows[0][hou.Split(new char[] { ',' })[4]].ToString() + "</td>";
                                    cellCode.InnerHtml += "</tr></table>";
                                }
                                ////双色球
                                //if ("上海时时乐,重庆时时彩,新疆时时彩,江西时时彩,福建时时彩".IndexOf(row["NvarName"].ToString()) > -1)
                                //{
                                //    cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                //    char[] M3Dcode = code.ToCharArray();
                                //    if (M3Dcode.Length > 1)
                                //    {
                                //        foreach (char tempChar in M3Dcode)
                                //        {
                                //            cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                //        }
                                //    }
                                //    if (tcode)
                                //    {
                                //        cellCode.InnerHtml += "<td class='Lblue'>" + dtWeb.Rows[0]["tcode"].ToString() + "</td>";
                                //    }
                                //    cellCode.InnerHtml += "</tr></table>";
                                //}
                                //else
                                //{
                                //    cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                //    string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                //    foreach (string tempRedCode in redCodes)
                                //    {
                                //        cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                //    }
                                //    if (tcode)
                                //    {
                                //        cellCode.InnerHtml += "<td class='Lblue'>" + dtWeb.Rows[0]["tcode"].ToString() + "</td>";
                                //    }
                                //    cellCode.InnerHtml += "</tr></table>";
                                //}
                                cellCode.BgColor = "#FFFFFF";
                                cellCode.VAlign = "bottom";
                                cellCode.Width = "342px";
                                cellCode.Height = "26px";
                                cellCode.Align = "left";

                                //开奖历史列
                                HtmlTableCell cellLS = new HtmlTableCell();
//                                cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=高频福彩&name=" + row["NvarName"].ToString() + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                                cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                                cellLS.BgColor = "#FFFFFF";
                                cellLS.Align = "center";
                                cellLS.Width = "73px";
                                cellLS.Height = "26px";

                                //开奖日列
                                HtmlTableCell cellLott_date = new HtmlTableCell();
                                //   cellLott_date.InnerHtml = Method.GetLottDate1(tempNode.Attributes["lott_date"].Value);
                                object objTime = row["TimeList"];
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
                                    if (row["NvarName"].ToString() == "重庆时时彩")
                                    {
                                        cellLott_date.InnerHtml = "每10分钟";
                                    }
                                    else
                                    {
                                        cellLott_date.InnerHtml = "每" + jg.ToString() + "分钟";
                                    }
                                }

                                cellLott_date.BgColor = "#FFFFFF";
                                cellLott_date.Align = "center";
                                cellLott_date.Width = "134px";
                                cellLott_date.Height = "26px";
                                HtmlTableRow tempRow = new HtmlTableRow();
                                tempRow.Cells.Add(cellName);
                                tempRow.Cells.Add(cellDate);
                                tempRow.Cells.Add(cellIssue);
                                tempRow.Cells.Add(cellCode);
                                tempRow.Cells.Add(cellLS);
                                tempRow.Cells.Add(cellLott_date);
                                tb1.Rows.Add(tempRow);
                            }
                        }
                    }
                    break;
                case "高频体彩":
                    break;
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            DataTable dtWeb = DbHelperSQL1.Query("select top 1 * from " + row["NvarApp_name"].ToString() + " order by issue desc").Tables[0];
                            if (dtWeb.Rows.Count < 1)
                            {
                                break;
                            }
                            string issue = dtWeb.Rows[0]["issue"].ToString();
                            string date = dtWeb.Rows[0]["date"].ToString();
                            string code = dtWeb.Rows[0]["code"].ToString();
                            bool tcode = dtWeb.Columns.Contains("tcode");
                            //彩种列
                            HtmlTableCell cellName = new HtmlTableCell();
//                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=高频体彩&name=" + row["NvarName"].ToString() + "' target='_self' class='caibiao1' >" + row["NvarName"].ToString() + "</a>";
                            cellName.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='_self' class='caibiao1' >" + row["NvarName"].ToString() + "</a>";
                            cellName.Align = "left";
                            cellName.Attributes.Add("class", "left_top left_pd");
                            cellName.Width = "137px";
                            cellName.Height = "26px";

                            //期号列
                            HtmlTableCell cellIssue = new HtmlTableCell();
                            cellIssue.InnerText = issue;
                            cellIssue.BgColor = "#FFFFFF";
                            cellIssue.Align = "center";
                            cellIssue.Width = "81px";
                            cellIssue.Height = "26px";

                            //开奖日期列
                            HtmlTableCell cellDate = new HtmlTableCell();
                            cellDate.InnerText = string.Format("{0:yyyy-MM-dd HH:mm}", DateTime.Parse(date));
                            cellDate.BgColor = "#FFFFFF";
                            cellDate.Align = "center";
                            cellDate.Width = "116px";
                            cellDate.Height = "26px";

                            //中奖号码列
                            HtmlTableCell cellCode = new HtmlTableCell();
                            //双色球
                            object objCpInfo = row["LottTypeInfo"];
                            object objLottTypeCount = row["LottTypeCount"];
                            if (objCpInfo != null && !string.IsNullOrEmpty(objCpInfo.ToString()) && objLottTypeCount != null && !string.IsNullOrEmpty(objLottTypeCount.ToString()))
                            {
                                if (Convert.ToInt32(objLottTypeCount) < 2)
                                {
                                    if ("数字型,扑克型".Contains(objCpInfo.ToString().Split(new char[] { ',' })[5]))
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        char[] M3Dcode = code.ToCharArray();
                                        if (M3Dcode.Length > 1)
                                        {
                                            foreach (char tempChar in M3Dcode)
                                            {
                                                cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                            }
                                        }
                                        cellCode.InnerHtml += "</tr></table>";
                                    }
                                    else
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                        foreach (string tempRedCode in redCodes)
                                        {
                                            cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                        }
                                        cellCode.InnerHtml += "</tr></table>";
                                    }
                                }
                                else
                                {
                                    string[] sz = objCpInfo.ToString().Split(new char[] { '|' });
                                    string qian = sz[0];
                                    string hou = sz[1];
                                    if ("数字型,扑克型".Contains(qian.Split(new char[] { ',' })[5]))
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        char[] M3Dcode = code.ToCharArray();
                                        if (M3Dcode.Length > 1)
                                        {
                                            foreach (char tempChar in M3Dcode)
                                            {
                                                cellCode.InnerHtml += "<td class='Lorange'>" + tempChar.ToString() + "</td>";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        cellCode.InnerHtml = "<table  border='0' cellspacing='0' cellpadding='2'><tr>";
                                        string[] redCodes = Method.FormartCode(code, " ").Split(new char[] { ' ' });
                                        foreach (string tempRedCode in redCodes)
                                        {
                                            cellCode.InnerHtml += "<td class='Lorange'>" + tempRedCode + "</td>";
                                        }
                                    }
                                    cellCode.InnerHtml += "<td class='Lblue'>" + dtWeb.Rows[0][hou.Split(new char[] { ',' })[4]].ToString() + "</td>";
                                    cellCode.InnerHtml += "</tr></table>";
                                }
                                cellCode.BgColor = "#FFFFFF";
                                cellCode.VAlign = "bottom";
                                cellCode.Width = "342px";
                                cellCode.Height = "26px";
                                cellCode.Align = "left";

                                //开奖历史列
                                HtmlTableCell cellLS = new HtmlTableCell();
//                                cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=高频体彩&name=" + row["NvarName"].ToString() + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                                cellLS.InnerHtml = "<a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='_self'><img border='0' src='Images/Web/history.jpg' width='19' height='14' /></a>";
                                cellLS.BgColor = "#FFFFFF";
                                cellLS.Align = "center";
                                cellLS.Width = "73px";
                                cellLS.Height = "26px";

                                //开奖日列
                                HtmlTableCell cellLott_date = new HtmlTableCell();
                                // cellLott_date.InnerHtml = Method.GetLottDate1(tempNode.Attributes["lott_date"].Value);
                                object objTime = row["TimeList"];
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
                                    cellLott_date.InnerHtml = "每" + jg.ToString() + "分钟";
                                }

                                cellLott_date.BgColor = "#FFFFFF";
                                cellLott_date.Align = "center";
                                cellLott_date.Width = "134px";
                                cellLott_date.Height = "26px";
                                HtmlTableRow tempRow = new HtmlTableRow();
                                tempRow.Cells.Add(cellName);
                                tempRow.Cells.Add(cellDate);
                                tempRow.Cells.Add(cellIssue);
                                tempRow.Cells.Add(cellCode);
                                tempRow.Cells.Add(cellLS);
                                tempRow.Cells.Add(cellLott_date);
                                tb1.Rows.Add(tempRow);
                            }
                        }
                    }
                    break;
            }

        }
    }
}
