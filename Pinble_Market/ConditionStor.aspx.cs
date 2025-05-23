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
using System.Text;

namespace Pinble_Market
{
    public partial class ConditionStor : System.Web.UI.Page
    {
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        Pbzx.BLL.Market_appendItemManager get_app = new Pbzx.BLL.Market_appendItemManager();
        private int rowCount = 0;
        private string str = "";
        DataTable IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindItem();
            }
        }
        private void BindItem()
        {
            string name = Input.Decrypt(Request["name"]);

            StringBuilder strBud = new StringBuilder();
            strBud.Append("On_off=0");
            strBud.Append(" and UserId is not null");
            strBud.Append(" and NvarName=" + "'" + name + "'");
            strBud.Append(" or TypeName=" + "'" + name + "'");

            string Searchstr = strBud.ToString();
            string order = "Time desc";
            int mycount = 0;
            IsResult = get_app.GuestGetBySearch(Searchstr, "*", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            myGridView.DataSource = IsResult;
            myGridView.DataBind();

            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
            rowCount = IsResult.Rows.Count;
        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = Convert.ToInt32(Input.GetCount());
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            //repItemBind();
            BindItem();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void myGridView_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.myGridView.Items)
            {

                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    Label lab_price = RI.FindControl("lab_price") as Label;
                    LinkButton Btn_buy = RI.FindControl("Btn_buy") as LinkButton;

                    DataSet ds = get_page.Market_GetNum("top 1 ExpectNum,Content", "appendID=" + "'" + IsResult.Rows[RI.ItemIndex]["appendID"] + "'" + " order by ExpectNum desc ");
                    Label lab_num = RI.FindControl("lab_num") as Label;
                    Label lab_gut = RI.FindControl("lab_gut") as Label;
                    if (ds != null || ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["ExpectNum"].ToString() == "")
                        {
                            lab_num.Text = "";
                        }
                        else
                        {
                            lab_num.Text = ds.Tables[0].Rows[0]["ExpectNum"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["Content"].ToString() == "")
                        {
                            lab_gut.Text = "";
                        }
                        else
                        {
                            lab_gut.Text = ds.Tables[0].Rows[0]["Content"].ToString();
                        }
                    }
                    if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Charge"]) == 0)
                    {
                        lab_price.Text = "<font color='red'>���</font>";
                        Btn_buy.Visible = false;
                    }
                    else
                    {
                        //�շ���Ŀû����ǰ���ܲ鿴
                        DateTime datatime = new DateTime();
                        if (datatime.Hour > 19 && datatime.Minute > 30)
                        {
                            //lab_viscera.Text = ;
                        }
                        else
                        {
                            lab_gut.Text = "";
                        }
                    }
                }
            }

        }

        protected void Btn_buy_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = get_page.BuyItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            if (str == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('���ѹ��������Ŀ��')", true);
            }
            else
            {
                Page.RegisterStartupScript("upscript", "<script>window.open('" + str + "')</script>");
            }
        }

        protected void Btn_Attention_Command(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = get_page.AttentionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);
        }

        protected void Btn_Collection_Commend(object sender, CommandEventArgs e)
        {
            loginInfo();
            str = get_page.CollectionItem(Method.Get_UserName.ToString(), e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "alert('" + str + "')", true);
        }
        /// <summary>
        /// �ж��û��Ƿ��¼
        /// </summary>
        private void loginInfo()
        {
            //�ж��û��Ƿ��¼
            if (Method.Get_UserName.ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "updatascript", "<script type='text/javascript' language='javascript' > if (confirm('���ȵ�¼��վ��')){ parent.mainFrame.location.href='../login.aspx';}else{ history.go(-1);}</script>", false);
            }
        }
    }
}
