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
using Pbzx.Common;

namespace Pinble_Chipped.admin
{
    public partial class ManageDeal : System.Web.UI.Page
    {
        DataTable IsResult = new DataTable();
        Pbzx.BLL.Chipped_LaunchInfoManage mybll = new Pbzx.BLL.Chipped_LaunchInfoManage();
        Pbzx.BLL.Chipped_InfoManage get_if = new Pbzx.BLL.Chipped_InfoManage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                myGridViewBind();
            }
        }

        //���
        protected void myGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                if (AspNetPager1.PageCount > 1)
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
                }
                else
                {
                    e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
                }
            }
        }
        /// <summary>
        /// ������
        /// </summary>
        private void myGridViewBind()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("1=1");
            sb.Append(BIndSearchstr());

            string Searchstr = sb.ToString();
            //����ʱ�䵹������
            string order = "LaunchTime desc";
            int mycount = 0;
            IsResult = mybll.GuestGetBySearchChipped(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.My_GridView.DataSource = IsResult;
            this.My_GridView.DataBind();
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

        private string BIndSearchstr()
        {
            StringBuilder but = new StringBuilder();
            if (txtQnumber.Text.Trim() != "")
            {
                but.Append(" and  QNumber='" + txtQnumber.Text.Trim() + "'");
            }
            if (txtusername.Text.Trim() != "")
            {
                but.Append(" and UserName='" + txtusername.Text.Trim() + "'");
            }
            if (Request.QueryString["lottery"] != null && Request.QueryString["lottery"] != "")
            {
                but.Append(" and playName='" + Request.QueryString["lottery"].Trim() + "'");
            }

            return but.ToString();
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
            myGridViewBind();
        }

        protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int count = this.My_GridView.Rows.Count;
            //�е�״̬�ǣ�����״̬ ���� ������  
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                for (int i = 0; i < count; i++)
                {
                    //�����ؼ� ��ÿ�ݽ�
                    Label lab_each = this.My_GridView.Rows[i].FindControl("lab_each") as Label;
                    //�����ؼ�������״̬��
                    Label lab_yn = this.My_GridView.Rows[i].FindControl("lab_yn") as Label;

                    decimal nEachMoney = Convert.ToDecimal(IsResult.Rows[i]["AtotalMoney"]) / Convert.ToInt32(IsResult.Rows[i]["Share"]);

                    //������
                    lab_each.Text = nEachMoney.ToString("0.##");

                    //����״̬
                    if (!string.IsNullOrEmpty(IsResult.Rows[i]["State"].ToString()))
                    {
                        if (Convert.ToInt32(IsResult.Rows[i]["State"]) == 0)
                        {
                            lab_yn.Text = "������";
                        }
                        else if (Convert.ToInt32(IsResult.Rows[i]["State"]) == 1)
                        {
                            lab_yn.Text = "�����ɹ����ѳ�Ʊ��";
                        }
                        else if (Convert.ToInt32(IsResult.Rows[i]["State"]) == 2)
                        {
                            lab_yn.Text = "����ʧ�ܣ����˿";
                        }
                        else if (Convert.ToInt32(IsResult.Rows[i]["State"]) ==3)
                        {
                            lab_yn.Text = "�����ɹ���δ��Ʊ��";
                        }
                        else if (Convert.ToInt32(IsResult.Rows[i]["State"]) == 4)
                        {
                            lab_yn.Text = "����ʧ�ܣ�δ�˿";
                        }
                    }
                    else
                    {
                        lab_yn.Text = "״̬����";
                    }
                    //�����ؼ������ݺ��룩
                    Label lab_gut = this.My_GridView.Rows[i].FindControl("lab_gut") as Label;

                    if (IsResult.Rows[i]["ChoiceNum"].ToString().Split('|').Length > 0)
                    {
                        //��ע����
                        //for()
                    }
                    else
                    {
                        //��ע����
                        lab_gut.Text = IsResult.Rows[i]["ChoiceNum"].ToString();
                    }

                }

                LinkButton linkbut = e.Row.Cells[14].FindControl("LinkButton2") as LinkButton;
                if (linkbut != null)
                {
                    linkbut.Attributes.Add("onclick", "if(!confirm('��ȷ��Ҫɾ��������'))return false;");
                }
            }
        }
        /// <summary>
        /// ���ݸ�ʽ��
        /// </summary>
        /// <param name="obj">����</param>
        /// <param name="obj1">Qnumber</param>
        /// <param name="obj1">����</param>
        /// <returns></returns>
        public static string Content(Object obj, Object obj1, Object obj2)
        {
            StringBuilder but = new StringBuilder();
            but.Append("<a id='" + obj1.ToString().Trim() + "' href='#'>�鿴</a>");

            //���JS����
            but.Append(" <script language='javascript' type='text/javascript'>");
            but.Append("$(document).ready(function() {");
            but.Append("$('#" + obj1.ToString().Trim() + "').click(function(){");
            but.Append("$.XYTipsWindow({");
            but.Append("___title:'��ѡע��',");
            StringBuilder buts = new StringBuilder();
            if (obj2.ToString() == "1")
            {
                string[] splits = obj.ToString().Split(';');

                for (int i = 0; i < splits.Length; i++)
                {
                    string[] spli = splits[i].Split('|');
                    if (spli[0] == "1")
                    {
                        buts.Append("[ֱѡ]��");
                    }
                    else if (spli[0] == "2")
                    {
                        buts.Append("[��ѡ]��");
                    }
                    else if (spli[0] == "3")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "6")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "1D")
                    {
                        buts.Append("[1Dѡ��]��");
                    }
                    else if (spli[0] == "2D")
                    {
                        buts.Append("[2Dѡ��]��");
                    }
                    else if (spli[0] == "tx")
                    {
                        buts.Append("[ͨѡ]��");

                    }
                    else
                    {
                        buts.Append("������");
                    }
                    buts.Append(spli[0] + "<br/>");
                }

            }
            else if (obj2.ToString() == "2")
            {
                string[] splits = obj.ToString().Split(';');

                for (int i = 0; i < splits.Length; i++)
                {
                    string[] spli = splits[i].Split('|');
                    if (spli[0] == "1")
                    {
                        buts.Append("[ֱѡ]��");
                    }
                    else if (spli[0] == "2")
                    {
                        buts.Append("[��ѡ]��");
                    }
                    else if (spli[0] == "3")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "6")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "1D")
                    {
                        buts.Append("[1Dѡ��]��");
                    }
                    else if (spli[0] == "2D")
                    {
                        buts.Append("[2Dѡ��]��");
                    }
                    else if (spli[0] == "tx")
                    {
                        buts.Append("[ͨѡ]��");

                    }
                    else
                    {
                        buts.Append("������");
                    }
                    buts.Append(spli[0] + "<br/>");
                }
            }
            else if (obj2.ToString() == "3")
            {
                string[] splits = obj.ToString().Split(';');

                for (int i = 0; i < splits.Length; i++)
                {
                    string[] spli = splits[i].Split('|');
                    if (spli[0] == "1")
                    {
                        buts.Append("[ֱѡ]��");
                    }
                    else if (spli[0] == "2")
                    {
                        buts.Append("[��ѡ]��");
                    }
                    else if (spli[0] == "3")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "6")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "1D")
                    {
                        buts.Append("[1Dѡ��]��");
                    }
                    else if (spli[0] == "2D")
                    {
                        buts.Append("[2Dѡ��]��");
                    }
                    else if (spli[0] == "tx")
                    {
                        buts.Append("[ͨѡ]��");

                    }
                    else
                    {
                        buts.Append("������");
                    }
                    buts.Append(spli[0] + "<br/>");
                }
            }
            else if (obj2.ToString() == "4")
            {
                string[] splits = obj.ToString().Split(';');

                for (int i = 0; i < splits.Length; i++)
                {
                    string[] spli = splits[i].Split('|');
                    if (spli[0] == "1")
                    {
                        buts.Append("[ֱѡ]��");
                    }
                    else if (spli[0] == "2")
                    {
                        buts.Append("[��ѡ]��");
                    }
                    else if (spli[0] == "3")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "6")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "1D")
                    {
                        buts.Append("[1Dѡ��]��");
                    }
                    else if (spli[0] == "2D")
                    {
                        buts.Append("[2Dѡ��]��");
                    }
                    else if (spli[0] == "tx")
                    {
                        buts.Append("[ͨѡ]��");

                    }
                    else
                    {
                        buts.Append("������");
                    }
                    buts.Append(spli[0] + "<br/>");
                }
            }
            else if (obj2.ToString() == "5")
            {
                string[] splits = obj.ToString().Split(';');

                for (int i = 0; i < splits.Length; i++)
                {
                    string[] spli = splits[i].Split('|');
                    if (spli[0] == "1")
                    {
                        buts.Append("[ֱѡ]��");
                    }
                    else if (spli[0] == "2")
                    {
                        buts.Append("[��ѡ]��");
                    }
                    else if (spli[0] == "3")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "6")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "1D")
                    {
                        buts.Append("[1Dѡ��]��");
                    }
                    else if (spli[0] == "2D")
                    {
                        buts.Append("[2Dѡ��]��");
                    }
                    else if (spli[0] == "tx")
                    {
                        buts.Append("[ͨѡ]��");

                    }
                    else
                    {
                        buts.Append("������");
                    }
                    buts.Append(spli[0] + "<br/>");
                }
            }
            else if (obj2.ToString() == "6")
            {
                string[] splits = obj.ToString().Split(';');

                for (int i = 0; i < splits.Length; i++)
                {
                    string[] spli = splits[i].Split('|');
                    if (spli[0] == "1")
                    {
                        buts.Append("[ֱѡ]��");
                    }
                    else if (spli[0] == "2")
                    {
                        buts.Append("[��ѡ]��");
                    }
                    else if (spli[0] == "3")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "6")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "1D")
                    {
                        buts.Append("[1Dѡ��]��");
                    }
                    else if (spli[0] == "2D")
                    {
                        buts.Append("[2Dѡ��]��");
                    }
                    else if (spli[0] == "tx")
                    {
                        buts.Append("[ͨѡ]��");

                    }
                    else
                    {
                        buts.Append("������");
                    }
                    buts.Append(spli[0] + "<br/>");
                }
            }
            else if (obj2.ToString() == "9999")
            {
                string[] splits = obj.ToString().Split(';');

                for (int i = 0; i < splits.Length; i++)
                {
                    string[] spli = splits[i].Split('|');
                    if (spli[0] == "1")
                    {
                        buts.Append("[ֱѡ]��");
                    }
                    else if (spli[0] == "2")
                    {
                        buts.Append("[��ѡ]��");
                    }
                    else if (spli[0] == "3")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "6")
                    {
                        buts.Append("[��ѡ��]��");
                    }
                    else if (spli[0] == "1D")
                    {
                        buts.Append("[1Dѡ��]��");
                    }
                    else if (spli[0] == "2D")
                    {
                        buts.Append("[2Dѡ��]��");
                    }
                    else if (spli[0] == "tx")
                    {
                        buts.Append("[ͨѡ]��");

                    }
                    else
                    {
                        buts.Append("������");
                    }
                    buts.Append(spli[0] + "<br/>");
                }
            }
            else
            {
                buts.Append(obj.ToString());
            }

            but.Append("___content:'text:" + buts.ToString().Replace("|", "<br/>") + "',");

            but.Append("___showbg:true,");
            but.Append("___drag:'___boxTitle'");
            but.Append("});});})</script>");
            return but.ToString();
        }

        /// <summary>
        /// ���ɾ��ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            string Qnumber = e.CommandArgument.ToString();
            if (Qnumber != null && Qnumber != "")
            {
                get_if.Delete(Qnumber);
                int number = mybll.Delete(Qnumber);
                if (number != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('ɾ���ɹ���');location='ManageDeal.aspx';</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('ɾ��ʧ�ܣ�');location='ManageDeal.aspx';</script>");
                }
            }
        }

        /// <summary>
        /// �����ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            myGridViewBind();

        }

        public static string LotteryFmt(Object obj)
        {
            String msg = "";
            if (Convert.ToInt32(obj.ToString()) == 1)
            {
                msg = "<a  href='ManageDeal.aspx?lottery=" + obj.ToString() + "'>3D</a>";
            }
            else if (Convert.ToInt32(obj.ToString()) == 2)
            {
                msg = "<a  href='ManageDeal.aspx?lottery=" + obj.ToString() + "'>���ֲ�</a>";
            }
            else if (Convert.ToInt32(obj.ToString()) == 3)
            {
                msg = "<a  href='ManageDeal.aspx?lottery=" + obj.ToString() + "'>˫ɫ��</a>";
            }
            else if (Convert.ToInt32(obj.ToString()) == 4)
            {
                msg = "<a  href='ManageDeal.aspx?lottery=" + obj.ToString() + "'>����5</a>";
            }
            else if (Convert.ToInt32(obj.ToString()) == 5)
            {
                msg = "<a  href='ManageDeal.aspx?lottery=" + obj.ToString() + "'>���ǲ�</a>";

            }
            else if (Convert.ToInt32(obj.ToString()) == 6)
            {
                msg = "<a  href='ManageDeal.aspx?lottery=" + obj.ToString() + "'>����͸</a>";
            }
            else if (Convert.ToInt32(obj.ToString()) == 9999) {
                msg = "<a  href='ManageDeal.aspx?lottery=" + obj.ToString() + "'>������</a>";
            }
            return msg;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string a = Method.CreateQNumber("11",true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < My_GridView.Rows.Count; i++)
            {

                Label lab_Qnumber = My_GridView.Rows[i].FindControl("lab_Qnumber") as Label;
                CheckBox checkall = My_GridView.Rows[i].FindControl("CheckBox1") as CheckBox;
                if (checkall.Checked)
                {
                    get_if.Delete(lab_Qnumber.Text);
                    mybll.Delete(lab_Qnumber.Text);
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('ɾ���ɹ���');location='ManageDeal.aspx';</script>");

        }

    }
}
