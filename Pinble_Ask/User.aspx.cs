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
using System.Collections.Generic;
using Maticsoft.DBUtility;

namespace Pinble_Ask
{
    public partial class User : AskUserBasic
    {
        protected string[] myChange = new string[3];
        private string divHead = "<div class='As_list_qie1bg'>";//style='width:100%; height:100% 
        private string divHead1 = "<div class='As_list_qie2bg'>";
        private string divfoot = "</div>";
        protected string userID = "";
        protected string[] myChange1 = new string[2];


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                userID = Method.Get_UserName;
                ViewState["disp"] = Request["disp"] == null ? "1" : Request["disp"];
                ViewState["disp"] = ViewState["disp"] == null ? "1" : ViewState["disp"];
                CallMethod();
                Pbzx.Model.PBnet_ask_User askUser = Pbzx.BLL.PBnet_ask_User.GetCurrentAsker();
                // Method.CheckUserGrade(Convert.ToString(askUser.Score - askUser.Pointpenalty - askUser.OtherPointpenalty), askUser.Title, askUser.ID.ToString());
            }
        }

        /// <summary>
        /// ���÷���ѡ��
        /// </summary>
        private void CallMethod()
        {
            string disp = ViewState["disp"].ToString();
            switch (disp)
            {
                case "1":
                    this.lblTitle.Text = "�ҵ�����";
                    BindUserInfo();
                    break;
                case "2":
                    this.lblTitle.Text = "�ҵĻ���";
                    BindJF();
                    BindWD();
                    break;
                case "3":
                    this.lblTitle.Text = "�ҵ�����";
                    BindQuestions();
                    break;
                case "4":
                    this.lblTitle.Text = "�ҵĻش�";
                    BindAnswer();
                    break;
            }
            DisplayDiv(disp);
        }

        /// <summary>
        /// ����ʾ��
        /// </summary>
        /// <param name="id"></param>
        private void DisplayDiv(string id)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (i.ToString() == id)
                {
                    (tdMain.FindControl("pnl" + i) as Panel).Visible = true;
                }
                else
                {
                    (tdMain.FindControl("pnl" + i) as Panel).Visible = false; ;
                }
            }

        }

        /// <summary>
        /// ���û���Ϣ
        /// </summary>
        private void BindUserInfo()
        {
            this.lblUName.Text = Method.Get_UserName;
            DataTable dtDV = DbHelperSQLBBS.Query("select UserEmail,JoinDate,LastLogin,UserLogins from Dv_User where UserName='" + Method.Get_UserName + "' ").Tables[0];
            this.lblEmail.Text = dtDV.Rows[0]["UserEmail"].ToString();
            this.lblRegTime.Text = Convert.ToDateTime(dtDV.Rows[0]["JoinDate"]).ToString("yyyy-MM-dd HH:mm:ss");
            this.lblLastLogin.Text = Convert.ToDateTime(dtDV.Rows[0]["LastLogin"]).ToString("yyyy-MM-dd HH:mm:ss");
            this.lblLoginCount.Text = dtDV.Rows[0]["UserLogins"].ToString();

            Pbzx.BLL.PBnet_UserTable utBLL = new Pbzx.BLL.PBnet_UserTable();
            List<Pbzx.Model.PBnet_UserTable> lbg = utBLL.GetModelList(" UserName='" + Method.Get_UserName + "' ");
            if (lbg.Count > 0)
            {
                Pbzx.Model.PBnet_UserTable userModel = lbg[0];
                this.lblSex.Text = userModel.Sex ? "��" : "Ů";
                this.lblRealName.Text = userModel.RealName;
                this.lblBirthDay.Text = userModel.Birthday.ToString();
                this.lblQq.Text = userModel.QQ;
                this.lblMSN.Text = userModel.MSN;
                this.lblAddress.Text = userModel.Province;
                Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
                Pbzx.Model.PBnet_ask_User askUserModel = Pbzx.BLL.PBnet_ask_User.GetCurrentAsker();
                this.lblGrade.Text = Method.GetUserTitle(Convert.ToString(askUserModel.Score - askUserModel.Pointpenalty - askUserModel.OtherPointpenalty));

                if (userModel.City != null)
                {
                    this.lblAddress.Text = userModel.Province + "-" + userModel.City;
                }
            }
        }


        /// <summary>
        /// �󶨻���
        /// </summary>
        private void BindJF()
        {
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
            Pbzx.Model.PBnet_ask_User askUserModel = Pbzx.BLL.PBnet_ask_User.GetCurrentAsker();
            lblTotalPoint.Text = Convert.ToString(askUserModel.Score - askUserModel.Pointpenalty - askUserModel.OtherPointpenalty);
            //LargessPoint
            //object objAnswerPoint = questionBLL.GetSingleData("select sum(LargessPoint) from PBnet_ask_Question where Answerer='" + userID + "' ");           
            //if (objAnswerPoint != null)
            //{
            //    lblAnswerPoint.Text = askUserModel.Score.ToString();
            //}
            lblAnswerPoint.Text = Convert.ToString(askUserModel.Score);

            //object objXSPoint = questionBLL.GetSingleData("select sum(LargessPoint) from PBnet_ask_Question where Asker='" + userID + "' ");
            //if (objXSPoint != null)
            //{
            //    this.lblXSPoint.Text = askUserModel.Pointpenalty.ToString();
            //        //objXSPoint.ToString();
            //}
            lblXSPoint.Text = Convert.ToString(askUserModel.Pointpenalty);

            //object objPointpenalty = userBLL.GetSingleData("select top 1 OtherPointpenalty from PBnet_ask_User where userName='" + userID + "' ");
            //if (objPointpenalty != null)
            //{
            //    this.lblPointpenalty.Text = objPointpenalty.ToString();
            //}

            //object objOtherPointpenalty = userBLL.GetSingleData("select top 1 OtherPointpenalty from PBnet_ask_User where userName='" + userID + "' ");
            //if (objOtherPointpenalty != null)
            //{
            //    this.lblOtherPointpenalty.Text = objOtherPointpenalty.ToString();
            //}
            lblOtherPointpenalty.Text = askUserModel.OtherPointpenalty.ToString();
        }

        /// <summary>
        /// ������
        /// </summary>
        private void BindWD()
        {
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
            Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
            object objHds = questionBLL.GetSingleData("select count(1) from PBnet_ask_Question where  Deleted=0 and id in(select QuestionId from PBnet_ask_Reply where  Deleted=0 and   Replyer='" + Method.Get_UserName + "')  ");

            int cns = 0;
            int hds = 1;
            if (objHds != null)
            {
                cns = (int)objHds;
                this.lblAnswerCount.Text = objHds.ToString();
            }
            else
            {
                this.lblAnswerCount.Text = "0";
            }

            object objAnswerCount = replyBLL.GetSingleData("select count(1) from PBnet_ask_Question where  Deleted=0  and id in(select QuestionId from PBnet_ask_Reply where  Deleted=0 and   Replyer='" + Method.Get_UserName + "' and IsBest=1 )  ");

            if (objAnswerCount != null)
            {
                hds = (int)objAnswerCount;
                this.lblBestAnswer.Text = hds.ToString();
            }
            else
            {
                this.lblBestAnswer.Text = "0";
            }
            if (cns == 0)
            {
                this.lblRat.Text = "0%";
            }
            else
            {
                this.lblRat.Text = Convert.ToDecimal(Convert.ToDecimal(hds) / Convert.ToDecimal(cns) * 100).ToString("0.00") + "%";
            }

            object objAskCount = questionBLL.GetSingleData("select count(1) from PBnet_ask_Question where  Deleted=0 and Asker ='" + Method.Get_UserName + "' ");
            if (objAskCount != null)
            {
                this.lblAskCount.Text = objAskCount.ToString();
            }

            object objHasAnwer = questionBLL.GetSingleData("select count(1) from PBnet_ask_Question where  Deleted=0 and Asker ='" + Method.Get_UserName + "' and State=1 ");
            if (objHasAnwer != null)
            {
                this.lblHasAnwer.Text = objHasAnwer.ToString();
            }

            this.lblInAnswer.Text = questionBLL.GetSingleData("select count(1) from PBnet_ask_Question where  Deleted=0 and  Asker ='" + Method.Get_UserName + "' and State=0 ").ToString();

            this.lblClose.Text = questionBLL.GetSingleData("select count(1) from PBnet_ask_Question where  Deleted=0  and Asker ='" + Method.Get_UserName + "' and State=2 ").ToString();



        }


        #region �����б�
        /// <summary>
        /// ѡ��ı�÷���
        /// </summary>
        /// <returns></returns>
        private void ChangeSelect(string myid)
        {
            for (int i = 1; i <= 3; i++)
            {
                if (i.ToString() == myid)
                {
                    myChange[i - 1] = divHead + GetNameById(i.ToString()) + divfoot;
                }
                else
                {
                    myChange[i - 1] = divHead1 + "<a href='User.aspx?disp=3&parm=" + i.ToString() + "' style='cursor:pointer;'>" + GetNameById(i.ToString()) + "</a>" + divfoot;
                }
            }
        }

        /// <summary>
        /// ����ID�õ�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetNameById(string id)
        {
            switch (id)
            {
                case "1":
                    return "ȫ��";
                case "2":
                    return "�ѽ������";
                case "3":
                    return "���������";
                default:
                    return "ȫ��";
            }
        }



        /// <summary>
        /// �������б�
        /// </summary>
        private void BindQuestions()
        {
            switch (Request["parm"])
            {
                case "1":
                    ChangeSelect("1");
                    break;
                case "2":
                    ChangeSelect("2");
                    break;
                case "3":
                    ChangeSelect("3");
                    break;
                default:
                    ChangeSelect("1");
                    break;
            }
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1  and Deleted=0 and Asker='" + Method.Get_UserName + "' ");
            bu.Append(this.AddParameter());

            string Searchstr = bu.ToString();
            string order = "AskTime desc ";
            int mycount = 0;
            DataTable IsResult = questionBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.ask.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.MyGridView.DataSource = IsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }

        /// <summary>
        /// ���÷�ҳ����
        /// </summary>
        /// <param name="tempCount"></param>
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.ask.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        /// <summary>
        /// ��ʾ��ҳ��Ϣ
        /// </summary>
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>����¼&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ����<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>����¼&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        /// <summary>
        /// ҳ��ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindQuestions();
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {

            StringBuilder sbType = new StringBuilder();
            switch (Request["parm"])
            {
                case "2":
                    sbType.Append(" and state=1 ");
                    break;
                case "3":
                    sbType.Append(" and State=0 ");
                    break;
                default:
                    break;
            }
            return sbType.ToString();
        }

        #endregion








        #region �ش��б�
        /// <summary>
        /// �󶨻ش�
        /// </summary>
        private void BindAnswer()
        {
            switch (Request["parm1"])
            {
                case "1":
                    ChangeSelect1("1");
                    break;
                case "2":
                    ChangeSelect1("2");
                    break;
                default:
                    ChangeSelect1("1");
                    break;
            }
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and  Deleted=0  and (id in(select QuestionId from PBnet_ask_Reply where  Deleted=0 and  Replyer='" + Method.Get_UserName + "' ");

            bu.Append(this.AddParameter1());
            bu.Append("  )) ");
            string Searchstr = bu.ToString();
            string order = "AskTime desc ";
            int mycount = 0;
            DataTable IsResult = questionBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.ask.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.MyGridView1.DataSource = IsResult;
            this.MyGridView1.DataBind();
            AspNetPagerConfig1(mycount);
            if (IsResult == null)
            {
                this.litContent1.Text = "<b>��Ǹ��<p/><br/>û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent1.Text = "";
            }
        }

        /// <summary>
        /// ���÷�ҳ����
        /// </summary>
        /// <param name="tempCount"></param>
        protected void AspNetPagerConfig1(int tempCount)
        {
            AspNetPager2.PageSize = WebInit.ask.WebPageNum;
            AspNetPager2.RecordCount = tempCount;
            AddCustomText1();
        }
        /// <summary>
        /// ��ʾ��ҳ��Ϣ
        /// </summary>
        protected void AddCustomText1()
        {
            AspNetPager2.CustomInfoHTML = "�ܼ�<font color=\"blue\"><b>" + AspNetPager2.RecordCount.ToString() + "</b></font>����¼&nbsp;";
            AspNetPager2.CustomInfoHTML += "��ҳ����<font color=\"red\"><b>" + MyGridView1.Rows.Count + "</b></font>����¼&nbsp;&nbsp;";
            AspNetPager2.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager2.CurrentPageIndex.ToString() + "</b>/" + AspNetPager2.PageCount.ToString() + "ҳ</font>";
        }
        /// <summary>
        /// ҳ��ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {
            BindAnswer();
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        private string AddParameter1()
        {

            StringBuilder sbType = new StringBuilder();

            switch (Request["parm1"])
            {
                case "1":
                    break;
                case "2":
                    sbType.Append("  and IsBest=1 ");
                    break;
                default:
                    break;
            }
            return sbType.ToString();
        }


        /// <summary>
        /// ѡ��ı�÷���
        /// </summary>
        /// <returns></returns>
        private void ChangeSelect1(string myid)
        {
            for (int i = 1; i <= 2; i++)
            {
                if (i.ToString() == myid)
                {
                    myChange1[i - 1] = divHead + GetNameById1(i.ToString()) + divfoot;
                }
                else
                {
                    myChange1[i - 1] = divHead1 + "<a href='User.aspx?disp=4&parm1=" + i.ToString() + "' style='cursor:pointer;'>" + GetNameById1(i.ToString()) + "</a>" + divfoot;
                }
            }
        }

        /// <summary>
        /// ����ID�õ�����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GetNameById1(string id)
        {
            switch (id)
            {
                case "1":
                    return "ȫ��";
                case "2":
                    return "�����ɻش�";
                default:
                    return "ȫ��";
            }
        }

        #endregion


        public static string shzt(object obj)
        {

            if ((bool)obj)
            {
                return "<font color='green'>��ͨ��</font>";
            }
            return "δͨ��";
        }
    }
}
