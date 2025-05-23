using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Pbzx.Common;

namespace Pinble_Challenge
{
    public partial class Person : System.Web.UI.Page
    {
        Pbzx.BLL.Challenge_Cinfo get_c = new Pbzx.BLL.Challenge_Cinfo();
        DataTable IsResult = new DataTable();
        public static string name="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ChallSer _challSer = new ChallSer();
                int lottID = 0;
                if (Request["name"] != null && Server.UrlDecode(Request["name"].ToString()) != "0")
                {

                    name = Input.FilterAll(Server.UrlDecode(Request["name"].ToString()));
                }
                
                
                if (Request["lottN"] != null)
                {
                    lottID = Convert.ToInt32(Request["lottN"]);
                    rep_DataBind(lottID);
                    if (lottID == 1)
                    {
                        //perTableD
                        div_Stati1.InnerHtml = Server.HtmlDecode(_challSer.perTableD(Convert.ToInt32(ddl_issN.SelectedValue), name, lottID));
                     }
                    if (lottID == 3)
                    {
                        div_Stati1.InnerHtml = Server.HtmlDecode(_challSer.perTableS(Convert.ToInt32(ddl_issN.SelectedValue), name, lottID));
                    }
                    if (lottID == 9999)
                    {
                        //perTableP
                        div_Stati1.InnerHtml = Server.HtmlDecode(_challSer.perTableP(Convert.ToInt32(ddl_issN.SelectedValue), name, lottID));
                    }
                    
                    Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "gg", "<script>tran("+ lottID +"); </script>");
                }
                else
                {
                    rep_DataBind(3);
                    div_Stati1.InnerHtml = Server.HtmlDecode(_challSer.perTableS(Convert.ToInt32(ddl_issN.SelectedValue), name, 3));

                }
                if (Request["name"] != null && Server.UrlDecode(Request["name"].ToString()) != "0")
                {
                    rep_payattBind(Input.FilterAll(Server.UrlDecode(Request["name"]).ToString()));
                }
            }

        }

        //绑定合买列表
        private void rep_DataBind(int lottID)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("C_name=" + "'" + name + "'");
            sb.Append(" and C_lottID=" + lottID);
            if (Request["ts"] != null)
            {
                int n_tid = Convert.ToInt32(Request["ts"]);
                sb.Append(" and C_Tid="+n_tid);
            }
            //string issue = "";
            //if (lottID == 9999)
            //{
            //    issue = Pbzx.BLL.publicMethod.Period(4);
            //}
            //else
            //{
            //    issue = Pbzx.BLL.publicMethod.Period(lottID);
            //}
            //sb.Append(" and C_issue="+"'"+ issue +"'");
            sb.Append(" and C_name is not null");
            string Searchstr = sb.ToString();
            //发布时间倒序排列
            string order = "C_time desc";
            int mycount = 0;
            IsResult = get_c.GuestGetBySearchCinfo(Searchstr, "*", order, 10, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.rep_data.DataSource = IsResult;
            this.rep_data.DataBind();
            AspNetPagerConfig(mycount);

        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 10;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (Request["lottN"] != null)
            {
                int lottID = Convert.ToInt32(Request["lottN"]);
                rep_DataBind(lottID);
                Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "gg", "<script>tran(" + lottID + "); </script>");
            }
            else
            {
                rep_DataBind(3);
            }
        }

        //数据绑定触发
        protected void rep_data_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_data.Items)
            {
                //获取开奖号码
                string w_num = Method.RlotteryNum(Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["C_lottID"]), Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["C_issue"]));
                Label lab_num = RI.FindControl("lab_num") as Label;
                Label lab_win = RI.FindControl("lab_win") as Label;
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["C_win"]) == 1)
                {
                    lab_win.Text = "<font color=\"red\" style=\"font-size: 16px; font-weight: bold;\">√</font>";
                    //获取中出的号码
                    string n_wNum = WinNum(w_num, IsResult.Rows[RI.ItemIndex]["C_num"].ToString(), IsResult.Rows[RI.ItemIndex]["T_state"].ToString());
                    if (!string.IsNullOrEmpty(n_wNum) && n_wNum != "")
                    {
                        lab_num.Text = "<font color='red'>" + n_wNum + "</font>";
                    }

                }
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["C_win"]) == 2)
                {
                    lab_win.Text = "<b>×</b>";
                    lab_num.Text = "无";
                }
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["C_win"]) == 0)
                {
                    lab_win.Text = "未对奖";
                }

                //显示开奖号码
                Label labONum = RI.FindControl("labONum") as Label;
                labONum.Text = w_num;

                //号码
                Label lab_cNum = RI.FindControl("lab_cNum") as Label;
                if (IsResult.Rows[RI.ItemIndex]["T_state"].ToString() == "h3l")
                {
                    string num = "";
                    for (int i = 0; i < IsResult.Rows[RI.ItemIndex]["C_num"].ToString().Split(',').Length; i++)
                    {
                        if (i % 7 == 0 && i > 0)
                        {
                            num += IsResult.Rows[RI.ItemIndex]["C_num"].ToString().Split(',')[i] + "</br>";
                        }
                        else
                        {
                            num += IsResult.Rows[RI.ItemIndex]["C_num"].ToString().Split(',')[i] + ",";
                        }
                    }
                    lab_cNum.Text = num.Substring(0, num.Length - 1);
                }
                else if (IsResult.Rows[RI.ItemIndex]["T_state"].ToString() == "h2l")
                {
                    string num = "";
                    for (int i = 0; i < IsResult.Rows[RI.ItemIndex]["C_num"].ToString().Split(',').Length; i++)
                    {
                        if (i % 5 == 0 && i > 0)
                        {
                            num += IsResult.Rows[RI.ItemIndex]["C_num"].ToString().Split(',')[i] + "</br>";
                        }
                        else
                        {
                            num += IsResult.Rows[RI.ItemIndex]["C_num"].ToString().Split(',')[i] + ",";
                        }
                    }
                    lab_cNum.Text = num.Substring(0, num.Length - 1);
                }
                else
                {
                    lab_cNum.Text = IsResult.Rows[RI.ItemIndex]["C_num"].ToString();
                }

            }
        }


        /// <summary>
        /// //显示中奖号码
        /// </summary>
        /// <param name="oNum">开奖号码</param>
        /// <param name="zNum">自选号码</param>
        /// <param name="lottCond">彩种条件</param>
        /// <returns></returns>
        private string WinNum(string oNum, string xNum, string lottCond)
        {
            string Num = "";
            if (oNum != "" && xNum != "")
            {
                if (lottCond == "h3l" || lottCond == "h2l")
                {
                    //红球
                    string redBall = "";
                    //蓝球
                    string buleBall = "";
                    for (int i = 0; i < oNum.Split('+')[0].Split(',').Length; i++)
                    {
                        for (int j = 0; j < xNum.Split('+')[0].Split(',').Length; j++)
                        {
                            if (Convert.ToInt32(oNum.Split('+')[0].Split(',')[i]) == Convert.ToInt32(xNum.Split('+')[0].Split(',')[j]))
                            {
                                redBall += oNum.Split('+')[0].Split(',')[i] + ",";
                            }
                        }
                    }
                    for (int i = 0; i < oNum.Split('+')[1].Split(',').Length; i++)
                    {
                        for (int j = 0; j < xNum.Split('+')[1].Split(',').Length; j++)
                        {
                            if (Convert.ToInt32(oNum.Split('+')[1].Split(',')[i]) == Convert.ToInt32(xNum.Split('+')[1].Split(',')[j]))
                            {
                                buleBall = oNum.Split('+')[1].Split(',')[i];
                            }
                        }
                    }

                    if (buleBall == "")
                    {
                        Num = redBall.Substring(0, redBall.Length - 1);
                    }
                    else
                    {
                        Num = redBall.Substring(0, redBall.Length - 1) + "+" + buleBall;
                    }
                }
                if (lottCond == "3dw" || lottCond == "5dw" || lottCond == "p5dw" || lottCond == "p3dw")
                {

                    Num = oNum.Replace(",", "/");
                }
                if (lottCond == "hq3d" || lottCond == "hq6d")
                {
                    string wball = "";

                    for (int j = 0; j < xNum.Split(',').Length; j++)
                    {
                        for (int i = 0; i < oNum.Split('+')[0].Split(',').Length; i++)
                        {
                            if (Convert.ToInt32(xNum.Split(',')[j]) == Convert.ToInt32(oNum.Split('+')[0].Split(',')[i]))
                            {
                                wball += oNum.Split('+')[0].Split(',')[i] + ",";
                            }
                        }
                    }

                    Num = wball.Substring(0, wball.Length - 1);
                }
                if (lottCond == "s3hq" || lottCond == "s6hq")
                {

                    Num = xNum;
                }
                if (lottCond == "lq1d" || lottCond == "lq3d")
                {
                    string wball = "";

                    for (int j = 0; j < xNum.Split(',').Length; j++)
                    {
                        for (int i = 0; i < oNum.Split('+')[1].Split(',').Length; i++)
                        {
                            if (Convert.ToInt32(xNum.Split(',')[j]) == Convert.ToInt32(oNum.Split('+')[1].Split(',')[i]))
                            {
                                wball = oNum.Split('+')[1].ToString();
                            }
                        }
                    }

                    Num = wball;
                }
                if (lottCond == "s3lq" || lottCond == "s6lq")
                {

                    Num = xNum;
                }
                if (lottCond == "dd" || lottCond == "pdd")
                {
                    Num = xNum;
                }
                if (lottCond == "sd" || lottCond == "psd")
                {
                    string wball = "";
                    string numball = ResNum_d(oNum);
                    
                    for (int i = 0; i < numball.Split(',').Length; i++)
                    {
                        if (xNum.Contains(numball.Split(',')[i]))
                        {
                            wball += numball.Split(',')[i] + ",";
                            numball.Remove(numball.IndexOf(numball.Split(',')[i].ToString()), 1);
                        }
                    }
                    Num = wball.Substring(0, wball.Length - 1);
                }
                if (lottCond == "s1m" || lottCond == "ps1m" || lottCond == "s2m" || lottCond == "ps2m")
                {

                    Num = xNum;
                }
                if (lottCond == "zx1z" || lottCond == "pzx1z")
                {
                    int _count = 0;
                    string wball = "";
                    string numD = ResNum_d(oNum);
                    for (int i = 0; i < 3; i++)
                    {
                        if (numD.Contains(xNum.Split(',')[i]))
                        {
                            _count = _count + 1;
                            if (_count == 3)
                            {
                                wball += xNum.Split(',')[i].ToString() + ",";
                            }
                            int v = xNum.IndexOf(xNum.Split(',')[i]);
                            xNum = xNum.Remove(v, 1); // 结果在返回值中
                        }
                    }
                    if (wball != "")
                    {
                        Num = wball.Substring(0, wball.Length - 1);
                    }
                    else
                    {
                        Num = wball;
                    }
                }
                if (lottCond == "zx" || lottCond == "pzx")
                {

                    Num = xNum;
                }
                if (lottCond == "dh" || lottCond == "pdh" || lottCond == "s1h" || lottCond == "ps1h")
                {
                    Num = xNum;
                }
                if (lottCond == "m" || lottCond == "p5m")
                {

                    Num = oNum;
                }
            }
            return Num;
        }
        /// <summary>
        /// 拆分3D 排列3 开奖号码
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string ResNum_d(string num)
        {
            string newNum = "";
            for (int i = 0; i < 3; i++)
            {
                newNum += num.Substring(i, 1).ToString() + ",";
            }
            return newNum.Substring(0, newNum.Length - 1);
        }

        /// <summary>
        /// 绑定关注 (我关注的人 默认值)
        /// </summary>
        /// <param name="name">会员名</param>
        public void rep_payattBind(string name)
        {
            Pbzx.BLL.PBnet_PayAtt get_pt = new Pbzx.BLL.PBnet_PayAtt();
            DataSet ds = get_pt.GetList("Pa_fans=" + "'" + name + "'" + " and Pa_PSign='pblt'");
            rep_payatt.DataSource = ds;
            rep_payatt.DataBind();

            DataSet ds_Idol = get_pt.GetList("Pa_Idol=" + "'" + name + "'" + " and Pa_PSign='pblt'");
            lab_payAtt.Text = ds_Idol.Tables[0].Rows.Count.ToString();
        }

    }
}