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

namespace Pinble_Chipped
{
    public partial class ParticiPation : System.Web.UI.Page
    {
        public static decimal shareMoney = 0;
        public static string Qnum = "";
        public static string Qnumber = "";
        public static string name="";
        //�û����
        public static decimal user_balance;
        //�ں�
        public static int ExpectNum;
        //��ֹʱ��
        public static DateTime endTime;
        DataTable IsResult = new DataTable();
        DataTable IsResultChipped = new DataTable();
        DataTable IsResultMybuy = new DataTable();
        Pbzx.BLL.Chipped_LaunchInfoManage get_mybll = new Pbzx.BLL.Chipped_LaunchInfoManage();
        Pbzx.BLL.publicMethod get_pub = new Pbzx.BLL.publicMethod();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                myRep_infoBind();
                myRep_ChippedBind();
                My_buyrep_IBuyBind();
                Qnumber = Request["num"].ToString();
                //���ݲ���ȡ����ʱ��
                int lState=Convert.ToInt32(Request["lottery"]);
                if (lState == 1)
                {
                    //3D
                    endTime = Convert.ToDateTime(Pbzx.Common.Method.GetFCDateTime.ToString());
                }
                if (lState == 2)
                {
                    //���ֲ�
                    endTime = Convert.ToDateTime(Pbzx.Common.Method.GetFC7LCDateTime.ToString());
                }
                if (lState == 3)
                {
                    //˫ɫ��
                    endTime = Convert.ToDateTime(Pbzx.Common.Method.GetSSQDateTime.ToString());
                }
                if (lState == 4 || lState == 9999)
                {
                    //����5
                    endTime = Convert.ToDateTime(Pbzx.Common.Method.GetTCPL35DateTime.ToString());
                }
                if (lState == 5)
                {
                    //���ǲ�
                    endTime = Convert.ToDateTime(Pbzx.Common.Method.GetTC7XCDateTime.ToString());
                }
                if (lState == 6)
                {
                    //����͸
                    endTime = Convert.ToDateTime(Pbzx.Common.Method.GetTCDLTDateTime.ToString());
                }
                //�û����
                user_balance =Convert.ToDecimal(Pbzx.BLL.publicMethod.GetMoney());
            }
        }

        //��������ϸ�б�
        private void myRep_infoBind()
        {
            Qnum = Request["num"].ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append("QNumber=" + "'"+ Qnum+"'" );
            string Searchstr = sb.ToString();
            string order = "LaunchTime desc";
            int mycount = 0;
            IsResult = get_mybll.GuestGetBySearchChipped(Searchstr, "*", order, 20, 3, 1, out mycount);
            this.myRep_info.DataSource = IsResult;
            this.myRep_info.DataBind();
            //�ں�
            ExpectNum = Convert.ToInt32(IsResult.Rows[0]["ExpectNum"]);

            //������
            lab_name.Text = IsResult.Rows[0]["UserName"].ToString();
            name = IsResult.Rows[0]["UserName"].ToString();

            

            //��������
            lab_title.Text = IsResult.Rows[0]["Title"].ToString();

            //��������
            lab_say.Text = IsResult.Rows[0]["say"].ToString();

            //��ȡ����ķ���
            Pbzx.BLL.publicMethod pubMod=new Pbzx.BLL.publicMethod();
            DataSet ds=pubMod.Statistics("QNumber="+"'"+ Qnum +"'");
            //ʣ�����
            lab_surplusNum.Text=Convert.ToString(Convert.ToInt32(IsResult.Rows[0]["share"])-Convert.ToInt32(ds.Tables[0].Rows[0][0]));

            if (IsResult.Rows[0]["Object"].ToString() == "0")
            {

                if (Convert.ToInt32(IsResult.Rows[0]["playName"]) == 3 || Convert.ToInt32(IsResult.Rows[0]["playName"]) == 2 || Convert.ToInt32(IsResult.Rows[0]["playName"]) == 6)
                {
                    //�������� 
                    string choiceNum = "";
                    string choiceHidden = "";
                    for (int i = 0; i < IsResult.Rows[0]["ChoiceNum"].ToString().Split(';').Length; i++)
                    {
                        if (i <= 4)
                        {
                            displayHidden.Visible = false;
                            choiceNum += IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].ToString() + "<br/>";
                        }
                        else
                        {
                            displayHidden.Visible = true;
                            choiceHidden += IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].ToString() + "<br/>";
                        }
                    }
                    lab_display.Text = choiceNum;
                    lab_hidden.Text = choiceHidden;

                }
                if (Convert.ToInt32(IsResult.Rows[0]["playName"]) == 1 || Convert.ToInt32(IsResult.Rows[0]["playName"]) == 9999)
                {
                    //3D�ķ�������
                    string choiceHidden = "";
                    string choiceNum = "";
                    for (int i = 0; i < IsResult.Rows[0]["ChoiceNum"].ToString().Split(';').Length; i++)
                    {
                        if (i <= 4)
                        {
                            displayHidden.Visible = false;
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "1")
                            {
                                choiceNum += "<font color='red'>[ֱѡ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "S1")
                            {
                                choiceNum += "<font color='red'>[ֱѡ��ֵ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "6")
                            {
                                choiceNum += "<font color='red'>[��ѡ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "S9")
                            {
                                choiceNum += "<font color='red'>[��ѡ��ֵ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "F3")
                            {
                                choiceNum += "<font color='red'>[��������]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "S3")
                            {
                                choiceNum += "<font color='red'>[������ֵ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0] == "F6")
                            {
                                choiceNum += "<font color='red'>[��������]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0] == "S6")
                            {
                                choiceNum += "<font color='red'>[������ֵ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                        }
                        else
                        {
                            displayHidden.Visible = true;
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "1")
                            {
                                choiceHidden += "<font color='red'>[ֱѡ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "S1")
                            {
                                choiceHidden += "<font color='red'>[ֱѡ��ֵ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "6")
                            {
                                choiceHidden += "<font color='red'>[��ѡ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "S9")
                            {
                                choiceHidden += "<font color='red'>[��ѡ��ֵ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "F3")
                            {
                                choiceHidden += "<font color='red'>[��������]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0].ToString() == "S3")
                            {
                                choiceHidden += "<font color='red'>[������ֵ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0] == "F6")
                            {
                                choiceHidden += "<font color='red'>[��������]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                            if (IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[0] == "S6")
                            {
                                choiceHidden += "<font color='red'>[������ֵ]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].Split('|')[1].ToString() + "<br/>";
                            }
                        }

                    }
                    lab_display.Text = choiceNum;
                    lab_hidden.Text = choiceHidden;

                }
                if (Convert.ToInt32(IsResult.Rows[0]["playName"]) == 4 || Convert.ToInt32(IsResult.Rows[0]["playName"]) == 5)
                {
                    //3D�ķ�������
                    string choiceHidden = "";
                    string choiceNum = "";
                    for (int i = 0; i < IsResult.Rows[0]["ChoiceNum"].ToString().Split(';').Length; i++)
                    {
                        if (i <= 4)
                        {
                            displayHidden.Visible = false;
                            choiceNum += "<font color='red'>[Ͷע����]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].ToString() + "<br/>";
                        }
                        else
                        {
                            displayHidden.Visible = true;
                            choiceHidden += "<font color='red'>[��ʽ����]</font> " + IsResult.Rows[0]["ChoiceNum"].ToString().Split(';')[i].ToString() + "<br/>";
                        }

                    }
                    lab_display.Text = choiceNum;
                    lab_hidden.Text = choiceHidden;

                }
            }
            if (IsResult.Rows[0]["Object"].ToString() == "2")
            {
                lab_display.Text = "���뱣��      ";
                lab_hidden.Text = "���뱣��       ";
                displayHidden.Visible = false;
            }
            if (IsResult.Rows[0]["Object"].ToString() == "1")
            {
                lab_display.Text = "�������˿ɼ�";
                lab_hidden.Text = "�������˿ɼ�";
                displayHidden.Visible = false;
            }
        }
        protected void myRep_info_ItemDataBound(object sender, RepeaterItemEventArgs e)
        { 
            Pbzx.BLL.publicMethod get_pub=new Pbzx.BLL.publicMethod();
            foreach(RepeaterItem RI in this.myRep_info.Items)
            {
                Label lab_jindu = RI.FindControl("lab_jindu") as Label;
                lab_jindu.Text = get_pub.percent(IsResult.Rows[RI.ItemIndex]["QNumber"].ToString());
            }
        }



        #region �����б�
        private void myRep_ChippedBind()
        {
            Qnum = Request["num"].ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append("QNumber="+"'"+ Qnum +"'");
            string Searchstr = sb.ToString();
            string order = "ChippedTime desc";
            int mycount = 0;
            IsResultChipped = get_pub.GuestGetBySearch(Searchstr, "*", order, 20, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.myRep_Chipped.DataSource = IsResultChipped;
            this.myRep_Chipped.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResultChipped != null && IsResultChipped.Rows.Count > 0)
            {
               this.litContent.Text = "";
            }
            else
            { 
                this.litContent.Text = "<b>��Ǹ��<p/>��ʱû�к�����Ϣ</b>";
                
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
            myRep_infoBind();
        }
                //repeater �İ��¼�
        protected void myRep_Chipped_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.myRep_Chipped.Items)
            {
                //�����ؼ� (��������еĵ��ݽ��)
                Label lab_money = RI.FindControl("lab_money") as Label;

                //ÿ�ݽ��
                decimal everyMoney = Convert.ToDecimal(IsResult.Rows[0]["AtotalMoney"]) / Convert.ToInt32(IsResult.Rows[0]["Share"]);
                //���ѽ��
                decimal nEachMoney = Convert.ToInt32(IsResultChipped.Rows[RI.ItemIndex]["ChippedShare"]) * everyMoney;
                lab_money.Text = nEachMoney.ToString("0.##");
                shareMoney = everyMoney;
            }
        }
        #endregion

        #region   �ҵ��Ϲ���¼
        public void My_buyrep_IBuyBind()
        {
            Qnum = Request["num"].ToString();
            StringBuilder sb = new StringBuilder();
            sb.Append("QNumber=" + "'" + Qnum + "'");
            sb.Append(" and ChippedName="+"'"+ Method.Get_UserName.ToString() +"'");
            string Searchstr = sb.ToString();
            string order = "ChippedTime desc";
            int mycount = 0;
            IsResultMybuy= get_pub.GuestGetBySearch(Searchstr, "*", order, 20, 3, AspNetPager2.CurrentPageIndex, out mycount);
            this.rep_IBuy.DataSource = IsResultMybuy;
            this.rep_IBuy.DataBind();
            AspNetPagerConfigMy(mycount);
            if (IsResultMybuy != null && IsResultMybuy.Rows.Count > 0)
            {
                this.litContentBuy.Text = "";
            }
            else
            {
                this.litContentBuy.Text = "<b>��Ǹ��<p/>��ʱû�к�����Ϣ</b>";

            }
        }
        protected void AspNetPagerConfigMy(int tempCount)
        {
            AspNetPager2.PageSize = 20;
            AspNetPager2.RecordCount = tempCount;
            AddCustomTextMy();
        }
        protected void AddCustomTextMy()
        {
            AspNetPager2.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager2.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager2.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager2.CurrentPageIndex.ToString() + "</b>/" + AspNetPager2.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            My_buyrep_IBuyBind();
        }
        protected void rep_IBuy_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_IBuy.Items)
            {
                //�����ؼ� (��������еĵ��ݽ��)
                Label lab_BuyMoney = RI.FindControl("lab_BuyMoney") as Label;

                //ÿ�ݽ��
                int everyMoney = Convert.ToInt32(IsResult.Rows[0]["AtotalMoney"]) / Convert.ToInt32(IsResult.Rows[0]["Share"]);
                lab_BuyMoney.Text = Convert.ToString(Convert.ToInt32(IsResultMybuy.Rows[RI.ItemIndex]["ChippedShare"]) * everyMoney);
            }
        }
        #endregion
    }
}
