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
    public partial class graph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindClass();
            }
        }


        private void BindClass()
        {
            Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataTable dt = lottBLL.GetList(" BitState=1 and BitIs_show=1 and (NvarClass='全国福彩' or  NvarClass='全国体彩') order by IntClass_OrderId,NvarOrderId ").Tables[0];
            if (dt.Rows.Count < 1)
            {
                return;
            }
            int i = 0;
            int rowid = 0;
            this.menu.InnerHtml += " <div class='G_menu'>";
            foreach (DataRow row in dt.Rows)
            {
                string classType = row["NvarClass"].ToString();
                string appName = row["NvarApp_name"].ToString();
                string lottInfo = row["LottTypeInfo"].ToString();
                string mylottType = lottInfo.Split(new char[] { '|' })[0].Split(new char[] { ',' })[5];

                string result = "";

                if (row["NvarName"].ToString() == "排列五")
                {
                    //这里可以放排列三
                    rowid = dt.Rows.Count + 1;
                    this.menu.InnerHtml += "<a target='FM_Id' id='aa" + rowid + "' class='nav_off' onclick=\"graphQiehuan('aa'," + rowid + "," + rowid + ",'" + "排列三" + "');\"   href='/ShuZiType.aspx?type=" + Input.Encrypt("TCPL35Data") + "&lx=pls'><font color='red'>排列三</font></a>&nbsp;&nbsp;";

                }

                if (classType == "全国福彩")
                {
                    result = "<font color='red'>" + row["NvarName"].ToString() + "</font>";
                }
                else
                {
                    result = "<font color='red'>" + row["NvarName"].ToString() + "</font>";
                }
                switch (mylottType)
                {
                    case "数字型":
                        i++;
                        if (row["NvarName"].ToString() == "福彩3D")
                        {
                            this.menu.InnerHtml += "<a target='FM_Id' id='aa" + i + "' class='nav_on' onclick=\"graphQiehuan('aa'," + i + "," + (dt.Rows.Count + 1) + ",'" + row["NvarName"].ToString() + "');\"   href='/ShuZiType.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "'>" + result + "</a>&nbsp;&nbsp;";
                        }
                        else
                        {
                            this.menu.InnerHtml += "<a target='FM_Id' id='aa" + i + "' class='nav_off' onclick=\"graphQiehuan('aa'," + i + "," + (dt.Rows.Count + 1) + ",'" + row["NvarName"].ToString() + "');\"   href='/ShuZiType.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "'>" + result + "</a>&nbsp;&nbsp;";
                        }
                        break;
                    case "乐透型":
                        i++;
                        this.menu.InnerHtml += "<a target='FM_Id'  id='aa" + i + "' class='nav_off' onclick=\"graphQiehuan('aa'," + i + "," + (dt.Rows.Count + 1) + ",'" + row["NvarName"].ToString() + "');\"  href='/LeTouType.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "'>" + result + "</a>&nbsp;&nbsp;";
                        break;
                }

            }
            this.menu.InnerHtml += "</div>";
        }












    }
}
