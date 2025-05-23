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
using Maticsoft.DBUtility;

namespace Pbzx.Web
{
    public partial class ShuZiType : System.Web.UI.Page
    {
        public string qush = "20";
        public string type = "FC3DData";
        private int danHaoWeiShu = 3;
        private int ltCodeMaxCode = 0;
        private int ltCodeMinCode = 0;
        private int ltTcodeMaxCode = 0;
        private int ltTcodeMinCode = 0;
        private string sortName = "福彩3D";

        protected void Page_Load(object sender, EventArgs e)
        {
//            if (Request.UrlReferrer == null || !(Request.UrlReferrer.Host == "pinble.com" || Request.UrlReferrer.Host == ConfigurationManager.AppSettings["HostName"]))
            if ((Request.UrlReferrer == null && !Page.IsPostBack) || (Request.UrlReferrer != null && (!Request.UrlReferrer.Host.ToLower().Contains("pinble.com") || !ConfigurationManager.AppSettings["HostName"].Contains(Request.UrlReferrer.Host.ToLower()))))
            {
                Response.Write("<script>top.location ='/Error.htm';</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                BindData();

            }
        }

        private void BindData()
        {

            if (Request["qush"] != null && Request["qush"] !="")
            {
                qush = Input.FilterAll(Request["qush"]);
                if (int.Parse(qush) > 200 || int.Parse(qush)< 20 )
                {
                    qush = "20";
                }
            }
            else
            {
                qush = "20";
            }
            this.ddlQushu.SelectedValue = qush;

            if (Request["type"] != null && Request["type"] !="")
            {
                type = Input.FilterAll(Input.Decrypt(Request["type"]));
            }
            else if (Request["lx"] != null && Request["lx"].ToLower() == "pls")
            {
                type = "TCPL35Data";
            }
            else
            {
                type = "FC3DData";
            }
            Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataTable dt = lottBLL.GetList(" NvarApp_name='" + type + "'").Tables[0];
            if (Request["type"] != null)
            {
                sortName = dt.Rows[0]["NvarName"].ToString();
            }
            this.lblName.Text = sortName;
            string lottInfo = dt.Rows[0]["LottTypeInfo"].ToString();
            danHaoWeiShu = int.Parse(lottInfo.Split(new char[] { '|' })[0].Split(new char[] { ',' })[1]);
            ltCodeMaxCode = int.Parse(lottInfo.Split(new char[] { '|' })[0].Split(new char[] { ',' })[3]);
            ltCodeMinCode = int.Parse(lottInfo.Split(new char[] { '|' })[0].Split(new char[] { ',' })[2]);
            if (lottInfo.Split(new char[] { '|' }).Length > 1)
            {
                ltTcodeMaxCode = int.Parse(lottInfo.Split(new char[] { '|' })[1].Split(new char[] { ',' })[3]);
                ltTcodeMinCode = int.Parse(lottInfo.Split(new char[] { '|' })[1].Split(new char[] { ',' })[2]);
            }
            string mylottType = lottInfo.Split(new char[] { '|' })[0].Split(new char[] { ',' })[5];
            if (mylottType == "数字型")
            {
                BindDanHaoData();
            }
        }


        /// <summary>
        /// 绑定数字型图表 
        /// </summary>
        private void BindDanHaoData()
        {
            this.TempletDanHao1.WeiShu = danHaoWeiShu;
            string strAllInfo = DbHelperSQL.GetSingle("select top 1 LottTypeInfo from PBnet_LotteryMenu where NvarApp_name='" + type + "'  ").ToString();
            string[] lottTypeInfoSZ = strAllInfo.Split(new char[] { '|' });
            string[] strInfo1 = lottTypeInfoSZ[0].Split(new char[] { ',' });
            this.TempletDanHao1.MyDataSource = DbHelperSQL1.Query("select top " + qush + " * from " + type + "  where " + strInfo1[4] + " IS NOT NULL and len(" + strInfo1[4] + ")>0  order by [date] desc").Tables[0];
            this.TempletDanHao1.CzName = type;
            if (Request.QueryString["lx"] == "pls")
            {
                this.lblName.Text = "排列三";
                this.TempletDanHao1.WeiShu = 3;
                this.TempletDanHao1.ISPls = true;
            }

        }

        /// <summary>
        /// 期数下拉列表改变的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void qushu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qus = this.ddlQushu.SelectedValue.ToString();
            string mytype = "";
            if (Request["type"] != null)
            {
                mytype = "&type=" + Request["type"];
            }
            if (Request.QueryString["lx"] == "pls")
            {
                Response.Redirect("ShuZiType.aspx?qush=" + qus + mytype + "&lx=pls");   
            }
            else
            {
                Response.Redirect("ShuZiType.aspx?qush=" + qus + mytype);
            }
        }


        ///// <summary>
        ///// 数字型是否显示指标区
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void chbZB_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.chbZB.Checked)
        //    {
        //        this.TempletDanHao1.AddZhiBiao = true;
        //    }
        //    else
        //    {
        //        this.TempletDanHao1.AddZhiBiao = false;
        //    }
        //    string qus = this.ddlQushu.SelectedValue.ToString();
        //    BindData();
        //    //Server.Transfer("ShuZiType.aspx?qush=" + qus);
        //}

        ///// <summary>
        ///// 数字型是否显示跨度走势        
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void chbKD_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.chbKD.Checked)
        //    {
        //        this.TempletDanHao1.AddKuaDuZS = true;
        //    }
        //    else
        //    {
        //        this.TempletDanHao1.AddKuaDuZS = false;
        //    }
        //    string qus = this.ddlQushu.SelectedValue.ToString();
        //    BindData();
        //    //Server.Transfer("ShuZiType.aspx?qush=" + qus);
        //}

        ///// <summary>
        ///// 数字型是否显示尾数和值走势
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void chbHZ_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.chbHZ.Checked)
        //    {
        //        this.TempletDanHao1.AddHeZhiZS = true;
        //    }
        //    else
        //    {
        //        this.TempletDanHao1.AddHeZhiZS = false;
        //    }
        //    string qus = this.ddlQushu.SelectedValue.ToString();
        //    BindData();
        //    //Server.Transfer("ShuZiType.aspx?qush=" + qus);
        //}

        ///// <summary>
        ///// 是否显示遗漏
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void chbYL_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.chbYL.Checked)
        //    {
        //        this.TempletDanHao1.DisplayYiLou = true;
        //    }
        //    else
        //    {
        //        this.TempletDanHao1.DisplayYiLou = false;
        //    }
        //    string qus = this.ddlQushu.SelectedValue.ToString();
        //    BindData();
        //   // Server.Transfer("ShuZiType.aspx?qush=" + qus);


        //}



    }
}
