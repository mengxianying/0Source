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

namespace Pinble_Chipped
{
    public partial class ChippedInfo : System.Web.UI.Page
    {
        Pbzx.BLL.PBnet_LotteryMenu get_lm = new Pbzx.BLL.PBnet_LotteryMenu();
        DataSet ds = new DataSet();
        //流水号
        public static string number = "";
        public static int share = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rep_ProjectInfoBind();
                
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void rep_ProjectInfoBind()
        {
            string Qnum = Request["id"].ToString();
            int shareNum =Convert.ToInt32(Request["share"]);
            Pbzx.BLL.Chipped_LaunchInfoManage get_lif = new Pbzx.BLL.Chipped_LaunchInfoManage();
            ds = get_lif.GetList("QNumber=" + "'" + Qnum + "'");
            this.rep_ProjectInfo.DataSource = ds;
            this.rep_ProjectInfo.DataBind();
            buyShare.Text = shareNum.ToString();

            //单份的金额
            decimal nEachMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]) / Convert.ToInt32(ds.Tables[0].Rows[0]["Share"]);
            //花费金额
            decimal nSpend=shareNum*nEachMoney;

            lab_money.Text = nSpend.ToString("0.##");
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Object"]) == 0)
            {
                //显示号码
                string n_num=displayNum(ds.Tables[0].Rows[0]["ChoiceNum"].ToString(), Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]));
                lab_number.Text = n_num;
            }
            if(Convert.ToInt32(ds.Tables[0].Rows[0]["Object"]) == 1)
            {
                lab_number.Text = "";
            }
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["Object"]) == 2)
            {
                lab_number.Text = "";
            }
            //赋值给页面的隐藏变量
            number = Qnum;
            share =Convert.ToInt32(shareNum);
        }

        /// <summary>
        /// 绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rep_ProjectInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_ProjectInfo.Items)
            {
                //玩法标识
                Label lab_lottery = RI.FindControl("lab_lottery") as Label;
                //注数
                Label lab_num = RI.FindControl("lab_num") as Label;
                //单份金额
                Label lab_SingleMoney = RI.FindControl("lab_SingleMoney") as Label;
                //保密类型
                Label lab_secretType = RI.FindControl("lab_secretType") as Label;

                
                
                //查询彩种名称
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]) == 9999)
                {
                    //排列3 特殊处理
                    lab_lottery.Text = "排列3";
                }
                else
                {
                    DataSet ds_lm = get_lm.GetList("IntId=" + Convert.ToInt32(ds.Tables[0].Rows[0]["playName"]));
                    if (ds_lm != null && ds_lm.Tables[0].Rows.Count > 0)
                    {
                        lab_lottery.Text = ds_lm.Tables[0].Rows[0]["NvarName"].ToString();
                    }
                }

                lab_num.Text= ds.Tables[0].Rows[0]["ChoiceNum"].ToString().Split(';').Length.ToString();

                //单份金额
                decimal SingleMoney = Convert.ToDecimal(ds.Tables[0].Rows[0]["AtotalMoney"]) / Convert.ToInt32(ds.Tables[0].Rows[0]["Share"]);

                lab_SingleMoney.Text = SingleMoney.ToString("0.##");

                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["Object"]) == 0)
                {
                    lab_secretType.Text = "开放";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["Object"]) == 1)
                {
                    lab_secretType.Text = "只对跟单人开放";
                }
                if (Convert.ToInt32(ds.Tables[0].Rows[RI.ItemIndex]["Object"]) == 2)
                {
                    lab_secretType.Text = "保密";
                }
            }
        }

        /// <summary>
        /// 显示具体号码
        /// </summary>
        /// <param name="num">号码串</param>
        /// <param name="playName">玩法标识</param>
        private string displayNum(string num,int playName)
        { 
            //3D
            if (playName == 1)
            {
                string num3D="";
                for (int i = 0; i < num.Split(';').Length; i++)
                {
                    if (num.Split(';')[i].Split('|')[0].ToString() == "1")
                    {
                        num3D += "<font color='red'>[3D直选]</font> " + num.Split(';')[i].Split('|')[1].ToString()+"<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S1")
                    {
                        num3D += "<font color='red'>[直选和值]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "6")
                    {
                        num3D += "<font color='red'>[3D组选]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S9")
                    {
                        num3D += "<font color='red'>[组选和值]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "F3")
                    {
                        num3D += "<font color='red'>[组三包号]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S3")
                    {
                        num3D += "<font color='red'>[组三和值]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "F6")
                    {
                        num3D += "<font color='red'>[组六包号]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S6")
                    {
                        num3D += "<font color='red'>[组六和值]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "1D")
                    {
                        num3D += "<font color='red'>[1D选号]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString()=="2D")
                    {
                        num3D += "<font color='red'>[2D选号]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() =="tx")
                    {
                        num3D += "<font color='red'>[通选]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "hsx")
                    {
                        num3D += "<font color='red'>[和数选]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                }
                return num3D;
            }
            //双色球
            if (playName == 3)
            {
                string numssq = "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {

                    numssq += "【红球】 " + num.Split(';')[i].Split('-')[0].ToString()+"<br/>" +"【蓝球】 "+ num.Split(';')[i].Split('-')[1].ToString()+"<br/>";
                }
                return numssq;
            }
            //七乐彩
            if (playName == 2)
            {
                string numqlc= "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {

                    numqlc += "【号码】 " + num.Split(';')[i].ToString() + "<br/>";
                }
                return numqlc;
            }
            //排列5
            if (playName == 4)
            {
                string numpl = "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {

                    numpl += "【号码】 " + num.Split(';')[i].ToString() + "<br/>";
                }
                return numpl;
            }
            //排列3
            if (playName == 9999)
            {
                string numps = "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {
                    if (num.Split(';')[i].Split('|')[0].ToString() == "1")
                    {
                        numps += "<font color='red'>[直选]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S1")
                    {
                        numps += "<font color='red'>[直选和值]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() =="6")
                    {
                        numps += "<font color='red'>[组选]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S6")
                    {
                        numps += "<font color='red'>[组选和值]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() =="F3")
                    {
                        numps += "<font color='red'>[组三包号]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S3")
                    {
                        numps += "<font color='red'>[组三和值]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "F6")
                    {
                        numps += "<font color='red'>[组六包号]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                    if (num.Split(';')[i].Split('|')[0].ToString() == "S6")
                    {
                        numps += "<font color='red'>[组六和值]</font> " + num.Split(';')[i].Split('|')[1].ToString() + "<br/>";
                    }
                }
                return numps;
            }
            //七星彩
            if (playName == 5)
            {
                string numqxc = "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {

                    numqxc += "【号码】 " + num.Split(';')[i].ToString() + "<br/>";
                }
                return numqxc;
            }
            //大乐透
            if (playName == 6)
            {
                string numdlt = "";
                for (int i = 0; i < num.Split(';').Length; i++)
                {

                    numdlt += "【前区号码】 " + num.Split(';')[i].Split('-')[0].ToString() + "<br/>" + "【后区号码】 " + num.Split(';')[i].Split('-')[1].ToString() + "<br/>";
                }
                return numdlt;
            }
            return "";
        }
    }
}
