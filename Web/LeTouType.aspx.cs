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
using Maticsoft.DBUtility;
using Pbzx.Common;

namespace Pbzx.Web
{
    public partial class LeTouType : System.Web.UI.Page
    {
        public string qush = "20";
        public string type = "FCSSData";
        private int danHaoWeiShu = 3;
        // private int ltTCodeQJ = 2;
        private int ltCodeMaxCode = 0;
        private int ltCodeMinCode = 0;
        private int ltTcodeMaxCode = 0;
        private int ltTcodeMinCode = 0;
        private string sortName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
//            if (Request.UrlReferrer == null || !(Request.UrlReferrer.Host == "pinble.com" || Request.UrlReferrer.Host == ConfigurationManager.AppSettings["HostName"]))
            if ((Request.UrlReferrer == null && !Page.IsPostBack) || (Request.UrlReferrer != null && (!Request.UrlReferrer.Host.ToLower().Contains(ConfigurationManager.AppSettings["HostName"]))))
            {
                Response.Write("<script>top.location ='/Error.htm';</script>");
                Response.End();
                return;
            }

            if (!Page.IsPostBack)
            {
                try
                {
                    BindData();
                }
                catch (Exception ex)
                {

                    Pbzx.Common.ErrorLog.WriteLogMeng("【异常监控】", ex.Message, true, true);
                }
            }
        }

        private void BindData()
        {
            if (Request["qush"] != null)
            {
                qush = Request["qush"];
                if (int.Parse(qush) > 200 || int.Parse(qush) < 20)
                {
                    qush = "20";
                }
            }
            else
            {
                qush = "20";
            }
            this.ddlQushu.SelectedValue = qush;

            if (Request["type"] != null)
            {
                type = Input.FilterAll(Input.Decrypt(Request["type"]));
            }
            else
            {
                type = "FCSSData";
            }
            Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();

            DataSet ds = lottBLL.GetList(" NvarApp_name='" + type + "'");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

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
                if (mylottType == "乐透型")
                {
                    BindShuangHaoData();
                }
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
            Response.Redirect("LeTouType.aspx?qush=" + qus + mytype);
        }


        /// <summary>
        /// 绑定乐透型图表
        /// </summary>
        private void BindShuangHaoData()
        {
            this.UcShuang1.MaxCode = ltCodeMaxCode;
            this.UcShuang1.MinCode = ltCodeMinCode;
            if (ltTcodeMaxCode != 0)
            {
                this.UcShuang1.MaxTcode = ltTcodeMaxCode;
                this.UcShuang1.MinTcode = ltTcodeMinCode;
            }
            this.UcShuang1.MyDataSource = DbHelperSQL1.Query("select top " + qush + " * from " + type + " order by [date] desc ").Tables[0];
        }


        ///// <summary>
        ///// 乐透型是否显示序号列
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void chbAddXuHao_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.chbAddXuHao.Checked)
        //    {
        //        this.UcShuang1.AddXuHao = true;
        //    }
        //    else
        //    {
        //        this.UcShuang1.AddXuHao = false;
        //    }
        //    string qus = this.ddlQushu.SelectedValue.ToString();
        //    Server.Transfer("LeTouType.aspx?qush=" + qus);
        //}

        ///// <summary>
        ///// 乐透型是否显示开奖号码列
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void chbAddCode_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (this.chbAddCode.Checked)
        //    {
        //        this.UcShuang1.AddCode = true;
        //    }
        //    else
        //    {
        //        this.UcShuang1.AddCode = false;
        //    }
        //    string qus = this.ddlQushu.SelectedValue.ToString();
        //    Server.Transfer("LeTouType.aspx?qush=" + qus);
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
        //        this.UcShuang1.AddYiLou = true;
        //    }
        //    else
        //    {
        //        this.UcShuang1.AddYiLou = false;
        //    }
        //    string qus = this.ddlQushu.SelectedValue.ToString();
        //    Server.Transfer("LeTouType.aspx?qush=" + qus);


        //}


    }
}
