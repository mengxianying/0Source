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


namespace Pinble_Wap.Manage
{
    public partial class List3DManage : System.Web.UI.Page
    {
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic();

        protected void Page_Load(object sender, EventArgs e)
        {
            basicDAL.IsCst = true;
            if (Session["User"] == null)
            {
                Response.Redirect("../UserLogin.aspx");
                return;
            }
            if (!IsPostBack)
            {
                labname.Text = (Session["User"] as Pbzx.Model.PBnet_tpman).Master_Name;
                BindData();
            }
        }

        /// <summary>
        /// 绑定列表信息
        /// </summary>
        protected void BindData()
        {
            string sql = "select top 5 * from FC3DData order by issue desc";
            DataTable dt = basicDAL.GetLisBySql(sql);
            this.MyGridView.DataSource = dt;
            this.MyGridView.DataBind();
        }

        //格式化IP地址
        protected string GetIp(object ip)
        {
            Pbzx.BLL.PBnet_ipdata ipBLL = new Pbzx.BLL.PBnet_ipdata();
            return ipBLL.S_getIPaddress(ip.ToString());
        }

        /// <summary>
        /// 点击修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            string strIssue = e.CommandArgument.ToString();
            Response.Redirect("AddorUpdate3DManage.aspx?issue=" + strIssue);
        }
        /// <summary>
        /// 点击转到新的开奖信息页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkTJ_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddorUpdate3DManage.aspx");
        }
        /// <summary>
        /// 点击跳转到前台预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkbutQT_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
        /// <summary>
        /// 点击退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkBtnreselt_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Session.Clear();
            Response.Redirect("../UserLogin.aspx");
        }

        /// <summary>
        /// 刷新前台开奖页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkbutsx_Click(object sender, EventArgs e)
        {
            UpdateBind("FC3DData");
            UpdateBind("TCPL35Data");
            UpdateBind("TC7XCData_New");
            UpdateBind("FC7LC");
            UpdateBind("FCSSData");
            UpdateBind("TCDLTData");
            UpdateBind("FCKL8Data");
//            UpdateBind("TC22X5Data");
            return;
        }
        private void UpdateBind(string cpName)
        {
            string tempValue = cpName + "Value";
            Hashtable hatData = new Hashtable();
            DataSet dsAppData = DbHelperSQL1.Query(" select top 1 * from  " + cpName + " order by issue desc ");
            DataRow row = dsAppData.Tables[0].Rows[0];
            hatData.Add("date", row["date"]);
            hatData.Add("issue", row["issue"]);
            hatData.Add("lasttime", row["LastModifyTime"]);
            switch (cpName)
            {
                case "FC3DData":
                    hatData.Add("testcode", row["testcode"]);
                    hatData.Add("code", row["code"]);
                    hatData.Add("machine", row["machine"]);
                    hatData.Add("ball", row["ball"]);
                    hatData.Add("decode", row["decode"]);
                    hatData.Add("AttentionCode", row["AttentionCode"]);

                    break;
                case "TCPL35Data":
                    hatData.Add("code5", row["code5"]);
                    break;
                case "TC7XCData_New":
                    hatData.Add("code", row["code"]);
                    hatData.Add("tcode", row["tcode"]);
                    break;
                case "FC7LC":
                    hatData.Add("code", row["code"]);
                    hatData.Add("tcode", row["tcode"]);
                    break;
                case "FCSSData":
                    hatData.Add("redcode", row["redcode"]);
                    hatData.Add("bluecode", row["bluecode"]);
                    break;
                case "TCDLTData":
                    hatData.Add("code", row["code"]);
                    hatData.Add("code2", row["code2"]);
                    break;
                case "FCKL8Data":
                    hatData.Add("code", row["code"]);
                    break;
                //case "TC22X5Data":
                //    hatData.Add("code", row["code"]);
                //    break;
                //case "TC31X7Data":
                //    hatData.Add("code", row["code"]);
                //    hatData.Add("tcode", row["tcode"]);
                //    break;
            }
            Application.Lock();
            Application[tempValue] = hatData;
            Application[cpName] = "true";
            Application.UnLock();
        }
    }
}
