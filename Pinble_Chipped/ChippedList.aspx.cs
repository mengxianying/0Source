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
using System.Text;

namespace Pinble_Chipped
{
    public partial class ChippedList : System.Web.UI.Page
    {
        DataTable IsResult = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rep_list_Bind();
            }
        }

        //�󶨺����б�
        private void rep_list_Bind()
        {
            Pbzx.BLL.Chipped_LaunchInfoManage mybll = new Pbzx.BLL.Chipped_LaunchInfoManage();
            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            string Searchstr = sb.ToString();
            //����ʱ�䵹������
            string order = "LaunchTime desc";

            int mycount = 0;
            IsResult = mybll.GuestGetBySearchChipped(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.rep_list.DataSource = IsResult;
            this.rep_list.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/>��ʱû�к�����Ϣ</b>";
            }
            else
            {
                this.litContent.Text = "";
            }


        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 20;
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
            rep_list_Bind();
        }

        //repeater �İ��¼�
        protected void rep_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_list.Items)
            {
                //�����ؼ���ÿ�ݵĽ�
                Label lab_Each = RI.FindControl("lab_Each") as Label;
                //�����ؼ����������ݣ�
                Label lab_Content = RI.FindControl("lab_Content") as Label;
                //�����ؼ����������ȣ�
                Label lab_progress = RI.FindControl("lab_progress") as Label;
                //�����ؼ���ʣ�������
                Label lab_surplus = RI.FindControl("lab_surplus") as Label;

                //���㵥�ݵĽ��
                lab_Each.Text = Convert.ToString(Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["AtotalMoney"]) / Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Share"]));
                //�������ݵ������ж�
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Object"]) == 0)
                {
                    //�������˹���
                    lab_Content.Text = "<a href='#'>�鿴</a>";
                }
                else if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["Object"]) == 1)
                {
                    lab_Content.Text = "�������˿ɿ�";
                }
                else
                {
                    lab_Content.Text = "�����󹫿�";
                }
                //��ʾ����
                Pbzx.BLL.publicMethod get_pub = new Pbzx.BLL.publicMethod();

                DataSet get_ds = get_pub.Statistics("QNumber=" + "'" + IsResult.Rows[RI.ItemIndex]["QNumber"].ToString() + "'");
                int buyshare = 0;
                if (get_ds == null || get_ds.Tables[0].Rows[0][0].ToString() == "")
                {
                    buyshare = Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["BuyShare"]);
                }
                else
                {
                    //����ķ��� �Լ������+��Ա����
                    buyshare = Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["BuyShare"]) + Convert.ToInt32(get_ds.Tables[0].Rows[0][0]);
                }
                //����ʣ����ٷ�=�ܷ�-����ķ�
                lab_surplus.Text = Convert.ToString(get_pub.percent(IsResult.Rows[RI.ItemIndex]["QNumber"].ToString()));
            }
        }
    }
}
