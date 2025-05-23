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

namespace Pbzx.Web
{
    public partial class Lottery : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["lx"] == "pls1")
                {
                    Response.Redirect("");
                }
                BindZiMenu();

            }
        }


        private void BindZiMenu()
        {
            Pbzx.BLL.PBnet_LotteryMenu lottBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            DataTable dt = lottBLL.GetList(" BitState=1 and BitIs_show=1 order by  IntClass_OrderId asc,NvarOrderId asc ").Tables[0];
            if (dt.Rows.Count < 1)
            {
                return;
            }
            foreach (DataRow row in dt.Rows)
            {
                string type = row["NvarClass"].ToString();
                string plw = row["NvarName"].ToString();
                switch (type)
                {
                    case "ȫ������":
                        if (row["NvarApp_name"].ToString() == "FC3DData")
                        {
                            this.LM1.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList3D.aspx?name=" + row["NvarName"] + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                            this.LM1.Visible = true;
                        }
                        else
                        {
//                            this.LM1.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=" + type + "&name=" + row["NvarName"] + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                            this.LM1.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                            this.LM1.Visible = true;
                        }
                        break;
                    case "ȫ�����":
                        if (plw == "������") //��Ϊ������ʱ�����������������
                        {
//                            this.LM1.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=" + type + "&lx=pls&name=������' target='FM_Id' class='caibiao'>" + "������" + "</a><br />";
                            this.LM1.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&lx=pls' target='FM_Id' class='caibiao'>" + "������" + "</a><br />";
                            this.LM1.Visible = true;
                        }
//                        this.LM1.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=" + type + "&name=" + row["NvarName"] + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                        this.LM1.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                        this.LM1.Visible = true;


                        break;
                    case "��ʡ����":
//                        this.LM2.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=" + type + "&name=" + row["NvarName"] + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                        this.LM2.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                        this.LM2.Visible = true;
                        break;
                    case "��ʡ���":
//                        this.LM3.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=" + type + "&name=" + row["NvarName"] + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                        this.LM3.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                        this.LM3.Visible = true;
                        break;
                    case "��Ƶ����":
//                        this.LM4.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=" + type + "&name=" + row["NvarName"] + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                        this.LM4.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                        this.LM4.Visible = true;
                        break;
                    case "��Ƶ���":
//                        this.LM5.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "&class=" + type + "&name=" + row["NvarName"] + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                        this.LM5.InnerHtml += "<img src='/Images/Web/kai_menu_li.jpg' width='9' height='11' hspace='3' border='0' /><a href='/LotteryOneList.aspx?type=" + Input.Encrypt(row["NvarApp_name"].ToString()) + "' target='FM_Id' class='caibiao'>" + row["NvarName"] + "</a><br />";
                        this.LM5.Visible = true;
                        break;
                }
            }
        }

        protected string GetParamUrl()
        {
            if (!string.IsNullOrEmpty(Input.FilterAll(Request["redirectUrl"])))
            {

                return "/LotteryOneList.aspx?type=" + Input.Encrypt(Input.FilterAll(Request["redirectUrl"])) + "";
            }
            else
            {
                return "/LotteryList.aspx";
            }
        }
    }
}
