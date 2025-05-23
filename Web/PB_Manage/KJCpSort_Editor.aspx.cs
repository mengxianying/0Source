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

namespace Pbzx.Web.PB_Manage
{
    public partial class KJCpSort_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string str = Request.QueryString["ID"];
                Pbzx.Model.PBnet_LotteryMenu MyLottery;
                Pbzx.BLL.PBnet_LotteryMenu cpSortBLL = new Pbzx.BLL.PBnet_LotteryMenu();
                this.ddlNvarClass.DataSource = cpSortBLL.GetLisBySql("select NvarClass from dbo.PBnet_LotteryMenu where 1=1 group by NvarClass");
                this.ddlNvarClass.DataTextField = "NvarClass";
                this.ddlNvarClass.DataValueField = "NvarClass";
                this.ddlNvarClass.DataBind();
                if (OperateText.IsNumber(str))
                {
                    MyLottery = cpSortBLL.GetModel(Convert.ToInt32(str));
                    lblAction.Text = "修改";
                    //btnCancel.Visible = true;
                    //btnCancel.Attributes.Add("onclick", "history.back();return false;");
                    this.txtDayLottCount.Text = MyLottery.DayLottCount.ToString();

                }
                else
                {
                    MyLottery = new Pbzx.Model.PBnet_LotteryMenu();
                    lblAction.Text = "新增";
                    //btnCancel.Visible = false;
                    this.txtDayLottCount.Text = "1";
                }
                hfFriendLinkID.Value = MyLottery.IntId.ToString();
                this.txtNvarName.Text = MyLottery.NvarName;
                this.ddlNvarClass.SelectedValue = MyLottery.NvarClass;
                this.txtIntClass_OrderId.Text = MyLottery.IntClass_OrderId.ToString();
                this.txtNvarOrderId.Text = MyLottery.NvarOrderId.ToString();
                this.rblBitIs_show.Items[0].Selected = MyLottery.BitIs_show;
                this.rblBitIs_show.Items[1].Selected = !MyLottery.BitIs_show;

                this.rblIsRefresh.Items[0].Selected = MyLottery.IsRefresh;
                this.rblIsRefresh.Items[1].Selected = !MyLottery.IsRefresh;

                this.txtIntCase.Text = MyLottery.IntCase.ToString();
                this.txtNvarApp_name.Text = MyLottery.NvarApp_name;
                this.txtNvarLott_date.Text = MyLottery.NvarLott_date;
                this.txtUrl.Text = MyLottery.Url;
                this.txtTimeList.Text = MyLottery.TimeList;
                this.txtIssueLen.Text = MyLottery.IssueLen.ToString();
                this.TextBox1.Text = MyLottery.Mark;


                if (!string.IsNullOrEmpty(MyLottery.IssueInfo))
                {
                    string[] BigClear = MyLottery.IssueInfo.Split(new char[] { '&' });
                    if (BigClear.Length > 1 && !string.IsNullOrEmpty(BigClear[1]))
                    {
                        if (BigClear[1].Contains("年"))
                        {
                            this.chbClear.Items[1].Selected = true;
                        }
                        else
                        {
                            this.chbClear.Items[1].Selected = false;
                        }
                        if (BigClear[1].Contains("日"))
                        {
                            this.chbClear.Items[0].Selected = true;
                        }
                        else
                        {
                            this.chbClear.Items[0].Selected = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(BigClear[0]))
                    {
                        string[] issueBig = BigClear[0].Split(new char[] { '|' });
                        string[] ymd = issueBig[0].Split(new char[] { ',' });
                        if (ymd[0] == "yyyy")
                        {
                            this.rblIssueY.SelectedValue = ymd[0];
                        }
                        else if (ymd[0] == "yy")
                        {
                            this.rblIssueY.Items[1].Selected = true;
                        }
                        else
                        {
                            this.rblIssueY.Items[3].Selected = true;
                        }

                        if (ymd.Length > 1)
                        {
                            if (ymd[1] == "MM")
                            {
                                this.rblIssueM.SelectedValue = ymd[1];
                            }
                            else
                            {
                                this.rblIssueM.Items[1].Selected = true;
                            }
                        }

                        if (ymd.Length > 2)
                        {
                            if (ymd[2] == "dd")
                            {
                                this.rblIssueD.SelectedValue = ymd[2];
                            }
                            else
                            {
                                this.rblIssueD.Items[1].Selected = true;
                            }
                        }

                        if (issueBig.Length > 1)
                        {
                            if (!string.IsNullOrEmpty(issueBig[1]))
                            {
                                this.txtLSH.Text = issueBig[1];
                            }
                            if (issueBig.Length > 2)
                            {
                                if (!string.IsNullOrEmpty(issueBig[2]))
                                {
                                    this.txtLSH2.Text = issueBig[2];
                                }
                            }
                        }
                    }

                }

                if (!string.IsNullOrEmpty(MyLottery.LottTypeInfo))
                {
                    string[] strTempSZ = MyLottery.LottTypeInfo.Split(new char[] { '|' });
                    if (strTempSZ.Length > 0)
                    {
                        string[] strInfo1 = strTempSZ[0].Split(new char[] { ',' });
                        if (strInfo1.Length > 1)
                        {
                            this.ddlCodeTypeName1.SelectedValue = strInfo1[0];
                            this.ddlCodeCount1.SelectedValue = strInfo1[1];
                            this.ddlMinCode1.SelectedValue = strInfo1[2];
                            this.txtMaxCode1.Text = strInfo1[3];
                            this.txtCodeZD1.Text = strInfo1[4];
                            this.ddlCpType1.SelectedValue = strInfo1[5];
                        }
                    }

                    if (MyLottery.LottTypeCount > 1)
                    {
                        string[] strInfo2 = strTempSZ[1].Split(new char[] { ',' });
                        if (strInfo2.Length > 1)
                        {
                            this.ddlCodeTypeName2.Text = strInfo2[0];
                            this.ddlCodeCount2.Text = strInfo2[1];
                            this.ddlMinCode2.Text = strInfo2[2];
                            this.txtMaxCode2.Text = strInfo2[3];
                            this.txtCodeZD2.Text = strInfo2[4];
                            this.ddlCpType2.SelectedValue = strInfo2[5];
                        }
                    }
                }


                if (!string.IsNullOrEmpty(MyLottery.LottWebsites))
                {
                    string[] wzSZ = MyLottery.LottWebsites.Split(new char[] { '|' });
                    string[] webSites1 = null;
                    string[] webSites2 = null;
                    string[] webSites3 = null;
                    string[] webSites4 = null;
                    switch (wzSZ.Length)
                    {
                        case 1:
                            webSites1 = wzSZ[0].Split(new char[] { ',' });
                            this.txtWebSiteName1.Text = webSites1[0];
                            this.txtWebSite1.Text = webSites1[1];
                            break;
                        case 2:
                            webSites1 = wzSZ[0].Split(new char[] { ',' });
                            this.txtWebSiteName1.Text = webSites1[0];
                            this.txtWebSite1.Text = webSites1[1];
                            webSites2 = wzSZ[1].Split(new char[] { ',' });
                            this.txtWebSiteName2.Text = webSites2[0];
                            this.txtWebSite2.Text = webSites2[1];
                            break;
                        case 3:
                            webSites1 = wzSZ[0].Split(new char[] { ',' });
                            this.txtWebSiteName1.Text = webSites1[0];
                            this.txtWebSite1.Text = webSites1[1];
                            webSites2 = wzSZ[1].Split(new char[] { ',' });
                            this.txtWebSiteName2.Text = webSites2[0];
                            this.txtWebSite2.Text = webSites2[1];
                            webSites3 = wzSZ[2].Split(new char[] { ',' });
                            this.txtWebSiteName3.Text = webSites3[0];
                            this.txtWebSite3.Text = webSites3[1];
                            break;
                        case 4:
                            webSites1 = wzSZ[0].Split(new char[] { ',' });
                            webSites2 = wzSZ[1].Split(new char[] { ',' });
                            webSites3 = wzSZ[2].Split(new char[] { ',' });

                            this.txtWebSiteName1.Text = webSites1[0];
                            this.txtWebSite1.Text = webSites1[1];
                            this.txtWebSiteName2.Text = webSites2[0];
                            this.txtWebSite2.Text = webSites2[1];
                            this.txtWebSiteName3.Text = webSites3[0];
                            this.txtWebSite3.Text = webSites3[1];
                            webSites4 = wzSZ[3].Split(new char[] { ',' });
                            this.txtWebSiteName4.Text = webSites4[0];
                            this.txtWebSite4.Text = webSites4[1];
                            break;
                    }
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtNvarName.Text.Trim() == "")
            {
                strErrMsg += "彩种名称不能为空.\\r\\n";
            }

            if (!OperateText.IsNumber(txtIntClass_OrderId.Text.Trim()))
            {
                strErrMsg += "所属类别排序编号未输入或数据格式不正确.\\r\\n";
            }

            if (!OperateText.IsNumber(this.txtNvarOrderId.Text.Trim()))
            {
                strErrMsg += "本类别内排序编号未输入或数据格式不正确.\\r\\n";
            }

            if (!OperateText.IsNumber(txtIntCase.Text.Trim()))
            {
                strErrMsg += "程序调用数字未输入或数据格式不正确.\\r\\n";
            }

            if (this.txtNvarApp_name.Text.Trim() == "")
            {
                strErrMsg += "数据库表名不能为空.\\r\\n";
            }
            if (this.txtNvarLott_date.Text.Trim() == "")
            {
                strErrMsg += "刷新时间间隔不能为空.\\r\\n";
            }
            if (this.txtUrl.Text.Trim() == "")
            {
                strErrMsg += "后台此彩种调用地址不能为空.\\r\\n";
            }

            if (!Input.IsInteger(this.txtIssueLen.Text.Trim()))
            {
                strErrMsg += "期号长度为空或格式不正确.\\r\\n";
            }


            if (!Input.IsInteger(this.txtDayLottCount.Text.Trim()))
            {
                strErrMsg += "每日开奖次数为空或格式不正确.\\r\\n";
            }
            if (this.txtMaxCode1.Text.Trim() == "")
            {
                strErrMsg += "类型一最大号码不能为空.\\r\\n";
            }
            if (this.txtCodeZD1.Text.Trim() == "")
            {
                strErrMsg += "类型一字段名不能为空.\\r\\n";
            }
            if (txtWebSiteName1.Text.Trim() == "")
            {
                strErrMsg += "开奖网址一网站名不能为空.\\r\\n";
            }
            if (this.txtWebSite1.Text.Trim() == "")
            {
                strErrMsg += "开奖网址一网站url地址不能为空.\\r\\n";
            }


            if (!Input.IsInteger(this.txtLSH.Text))
            {
                strErrMsg += "流水号1位数输入格式不正确.\\r\\n";
            }

            if (!string.IsNullOrEmpty(this.txtLSH2.Text))
            {
                if (!Input.IsInteger(this.txtLSH2.Text))
                {
                    strErrMsg += "流水号2位数输入格式不正确.\\r\\n";
                }
            }

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的开奖彩种中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }

            Pbzx.Model.PBnet_LotteryMenu MyLottery;
            Pbzx.BLL.PBnet_LotteryMenu cpSortBLL = new Pbzx.BLL.PBnet_LotteryMenu();

            int intID = Convert.ToInt32(hfFriendLinkID.Value);
            if (intID > 0)
            {
                MyLottery = cpSortBLL.GetModel(intID);
            }
            else
            {
                MyLottery = new Pbzx.Model.PBnet_LotteryMenu();
            }
            MyLottery.NvarName = this.txtNvarName.Text;
            MyLottery.NvarClass = this.ddlNvarClass.SelectedValue;
            MyLottery.IntClass_OrderId = int.Parse(this.txtIntClass_OrderId.Text);
            MyLottery.NvarOrderId = int.Parse(this.txtNvarOrderId.Text);
            MyLottery.BitIs_show = this.rblBitIs_show.Items[0].Selected;
            MyLottery.IsRefresh = this.rblIsRefresh.Items[0].Selected;
            MyLottery.IntCase = int.Parse(this.txtIntCase.Text);
            MyLottery.NvarApp_name = this.txtNvarApp_name.Text;
            MyLottery.NvarLott_date = this.txtNvarLott_date.Text;
            MyLottery.Url = this.txtUrl.Text;

            MyLottery.Mark = this.TextBox1.Text;

            MyLottery.DayLottCount = int.Parse(this.txtDayLottCount.Text);
            MyLottery.IssueLen = int.Parse(this.txtIssueLen.Text);

            MyLottery.TimeList = this.txtTimeList.Text.Replace("\r\n", "");
            string lottInfo = this.ddlCodeTypeName1.SelectedValue + "," + this.ddlCodeCount1.SelectedValue + "," + this.ddlMinCode1.SelectedValue + "," + this.txtMaxCode1.Text + "," + this.txtCodeZD1.Text + "," + this.ddlCpType1.SelectedValue;
            if (this.txtMaxCode2.Text.Trim() != "" && this.txtCodeZD2.Text.Trim() != "")
            {
                MyLottery.LottTypeCount = 2;
                lottInfo += "|" + this.ddlCodeTypeName2.SelectedValue + "," + this.ddlCodeCount2.SelectedValue + "," + this.ddlMinCode2.SelectedValue + "," + this.txtMaxCode2.Text + "," + this.txtCodeZD2.Text + "," + this.ddlCpType2.SelectedValue;
            }
            else
            {
                MyLottery.LottTypeCount = 1;
            }
            MyLottery.LottTypeInfo = lottInfo;
            string website = this.txtWebSiteName1.Text + "," + this.txtWebSite1.Text;
            if (this.txtWebSite2.Text.Trim() != "")
            {
                website += "|" + this.txtWebSiteName2.Text + "," + this.txtWebSite2.Text;
            }
            if (this.txtWebSite3.Text.Trim() != "")
            {
                website += "|" + this.txtWebSiteName3.Text + "," + this.txtWebSite3.Text;
            }
            if (this.txtWebSite4.Text.Trim() != "")
            {
                website += "|" + this.txtWebSiteName4.Text + "," + this.txtWebSite4.Text;
            }
            MyLottery.LottWebsites = website;

            string strIssueInfo = this.rblIssueY.SelectedValue + "," + this.rblIssueM.SelectedValue + "," + this.rblIssueD.SelectedValue + "|" + this.txtLSH.Text;
            if (int.Parse(txtLSH2.Text) > 0)
            {
                strIssueInfo += "|" + this.txtLSH2.Text;
            }
            strIssueInfo += "&";
            if (this.chbClear.Items[1].Selected)
            {
                strIssueInfo += "年,";
            }
            if (this.chbClear.Items[0].Selected)
            {
                strIssueInfo += "日";
            }

            MyLottery.IssueInfo = strIssueInfo;

            //MyLink.Operator = RM.BLL.Admin.GetNowUser().AdminName;

            if (MyLottery.IntId > 0)
            {
                if (cpSortBLL.Update(MyLottery))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改彩种[" + MyLottery.IntId + ":" + MyLottery.NvarName + "].");
                    Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=" + MyLottery.NvarApp_name + "");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("彩种修改成功.", "KJCpSort_Manage.aspx"));
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", JS.Alert("彩种修改失败."));
                }
            }
            else
            {
                if (cpSortBLL.Add(MyLottery))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "添加彩种[" + MyLottery.IntId + ":" + MyLottery.NvarName + "].");
                    Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType=" + MyLottery.NvarApp_name + "");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("彩种添加成功..", "KJCpSort_Manage.aspx"));
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "err", JS.Alert("彩种添加失败."));
                }
            }

        }

        protected void btnCalc_Click(object sender, EventArgs e)
        {


            TimeSpan tsStart = new TimeSpan();
            if (!TimeSpan.TryParse(this.txtStart.Text, out tsStart))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error1", JS.Alert("开始时间格式不正确"));
                return;
            }

            TimeSpan tsEnd = new TimeSpan();
            if (!TimeSpan.TryParse(this.txtEnd.Text, out tsEnd))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error1", JS.Alert("结束时间格式不正确"));
                return;
            }
            if (tsEnd < tsStart)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error1", JS.Alert("结束时间不能小于开始时间"));
                return;
            }
            double jg = 10;
            if (!double.TryParse(this.txtJG.Text, out jg))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "error2", JS.Alert("时间间隔必须是数字"));
                return;
            }
            else
            {
                jg = double.Parse(this.txtJG.Text);
            }
            string tempList = this.txtStart.Text + "|";
            while (tsEnd >= tsStart.Subtract(-TimeSpan.FromMinutes(jg)))
            {
                tsStart = tsStart.Subtract(-TimeSpan.FromMinutes(jg));
                tempList += tsStart.ToString().Substring(0, 5) + "|";
            }
            string result = tempList.Length > 5 ? tempList.Substring(0, tempList.Length - 1) : tempList;
            this.txtTempResult.Text = result;
            ClientScript.RegisterStartupScript(this.GetType(), "fff", "<script>document.getElementById('txtTempResult').select();</script>");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.txtStart.Text = "";
            this.txtEnd.Text = "";
            this.txtJG.Text = "";
            this.txtTempResult.Text = "";
        }

        protected void ddlCpType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlCpType1.SelectedValue == "数字型")
            {
                this.ddlMinCode1.SelectedValue = "0";
            }
            else if (this.ddlCpType1.SelectedValue == "乐透型")
            {
                this.ddlMinCode1.SelectedValue = "1";
            }
            else if (this.ddlCpType1.SelectedValue == "扑克型")
            {
                ddlCodeTypeName1.SelectedValue = "开奖号码";
                this.ddlMinCode1.SelectedValue = "1";
                this.txtMaxCode1.Text = "13";
                this.ddlCodeCount1.SelectedValue = "4";
                this.txtCodeZD1.Text = "Code";
            }
            else if (this.ddlCpType1.SelectedValue == "扑克3型")
            {
                ddlCodeTypeName1.SelectedValue = "开奖号码";
                this.ddlMinCode1.SelectedValue = "1";
                this.txtMaxCode1.Text = "13";
                this.ddlCodeCount1.SelectedValue = "6";
                this.txtCodeZD1.Text = "Code";
            }
        }

        protected void ddlCpType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddlCpType2.SelectedValue == "数字型")
            {
                this.ddlMinCode2.SelectedValue = "0";
            }
            else if (this.ddlCpType2.SelectedValue == "乐透型")
            {
                this.ddlMinCode2.SelectedValue = "1";
            }
        }

        protected void btnCal_Click(object sender, EventArgs e)
        {
            string strList = this.txtTimeList.Text.Replace("\r\n", "");
            string[] listCount = strList.Split(new char[] { '&' });
            int count = 0;
            for (int i = 0; i < listCount.Length; i++)
            {
                if (!string.IsNullOrEmpty(listCount[i]) && listCount[i].Length > 1)
                {
                    count += listCount[i].Split(new char[] { '|' }).Length;
                }
            }
            //int count1 = 0;
            //int count2 = 0;
            //if(string.IsNullOrEmpty(strList))
            //{
            //    count1 = 1;
            //}
            //else if (listCount.Length > 1 && !string.IsNullOrEmpty(listCount[1]))
            //{
            //    count1 = listCount[0].Split(new char[] { '|' }).Length;
            //    count2 = listCount[1].Split(new char[] { '|' }).Length;
            //}
            //else
            //{
            //    count1 = listCount[0].Split(new char[] { '|' }).Length;
            //}
            this.txtDayLottCount.Text = Convert.ToString(count);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("KJCpSort_Manage.aspx");
        }

    }
}
