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
    public partial class consult : System.Web.UI.Page
    {
        Pbzx.BLL.Market_Page get_page = new Pbzx.BLL.Market_Page();
        Pbzx.BLL.Market_appendItemManager get_app = new Pbzx.BLL.Market_appendItemManager();
        DataTable IsResult = new DataTable();
        private int rowCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindmyRep();
            }
        }
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="name">name</param>
        private void BindmyRep()
        {
            string condition = Input.Decrypt(Request["search"]).ToString();
            StringBuilder sb = new StringBuilder();
            if (condition == "���")
            {
                sb.Append("Charge=0");
            }
            else if (condition == "�շ�")
            {
                sb.Append( "Charge=1");
            }
            else
            {
                sb.Append("UserId like'%" + condition +"%'");
                sb.Append(" or TypeName like '%" +  condition +"%'");
                sb.Append(" or NvarName like '%" +  condition +"%'");
                //sb.Append(" group by NvarName,TypeName,UserId,Charge,[Time],appendid,say");
               
            }
            string Searchstr = sb.ToString();
            string order = "[Time] desc ";
            int mycount = 0;
            IsResult = get_app.GuestGetBySearch(Searchstr, "NvarName,TypeName,UserId,Charge,[Time],appendid,say", order, Convert.ToInt32(Input.GetCount()), 3, AspNetPager1.CurrentPageIndex, out mycount);
            if (IsResult != null && IsResult.Rows.Count > 0)
            {
                myRep.DataSource = IsResult;
                myRep.DataBind();
                litContent.Text = "";
            }
            else
            {
                litContent.Text = "<b>û��������������</b>";
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
            BindmyRep();
        }
        //myRep�¼�
        protected void myRep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.myRep.Items)
            {
                //������ҳü����ҳ��
                if (RI.ItemType != ListItemType.Header && RI.ItemType != ListItemType.Footer)
                {
                    Label lab_charge = RI.FindControl("lab_charge") as Label;
                    Label lab_ExpectNum = RI.FindControl("lab_ExpectNum") as Label;
                    //���ݲ��� ��ѯ���µ�һ��
                    DataSet ds = get_page.Market_GetNum(" top 1 ExpectNum","appendID="+"'"+ IsResult.Rows[RI.ItemIndex]["appendid"].ToString() +"'"+" order by ExpectNum desc");
                    lab_ExpectNum.Text = ds.Tables[0].Rows[0][0].ToString();
                    if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Charge"]) == 0)
                    {
                        lab_charge.Text = "���";
                    }
                    else
                    {
                        lab_charge.Text = "�շ�";
                    }
                }
            }
        }
    }
}
