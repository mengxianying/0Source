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

namespace Pbzx.Web.UserCenter
{
    public partial class Myask : System.Web.UI.Page
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
                Pbzx.Model.PBnet_ask_User UserModel = Pbzx.BLL.PBnet_ask_User.GetCurrentAsker();
                this.lbName.Text = UserModel.UserName;
                this.lbtitle.Text = Method.GetUserTitle(Convert.ToString(UserModel.Score - UserModel.Pointpenalty - UserModel.OtherPointpenalty));
                this.lbScore.Text = Convert.ToString(UserModel.Score - UserModel.Pointpenalty - UserModel.OtherPointpenalty);

                userID = Method.Get_UserName;
                BindJF();
                BindWD();
                BindQuestions();
                BindAnswer();
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


        //#region �����б�
        ///// <summary>
        ///// ѡ��ı�÷���
        ///// </summary>
        ///// <returns></returns>
        //private void ChangeSelect(string myid)
        //{
        //    for (int i = 1; i <= 3; i++)
        //    {
        //        if (i.ToString() == myid)
        //        {
        //            myChange[i - 1] = divHead + GetNameById(i.ToString()) + divfoot;
        //        }
        //        else
        //        {
        //            myChange[i - 1] = divHead1 + "<a href='User.aspx?disp=3&parm=" + i.ToString() + "' style='cursor:pointer;'>" + GetNameById(i.ToString()) + "</a>" + divfoot;
        //        }
        //    }
        //}

        ///// <summary>
        ///// ����ID�õ�����
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //private string GetNameById(string id)
        //{
        //    switch (id)
        //    {
        //        case "1":
        //            return "ȫ��";
        //        case "2":
        //            return "�ѽ������";
        //        case "3":
        //            return "���������";
        //        default:
        //            return "ȫ��";
        //    }
        //}



        /// <summary>
        /// �������б�
        /// </summary>
        private void BindQuestions()
        {
            
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and Asker='" + Method.Get_UserName + "' and Deleted=0 ");
           // bu.Append(this.AddParameter());

            string Searchstr = bu.ToString();
            string order = "AskTime desc";
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
        ///// <summary>
        ///// �������
        ///// </summary>
        ///// <returns></returns>
        //private string AddParameter()
        //{

        //    StringBuilder sbType = new StringBuilder();
        //    switch (Request["parm"])
        //    {
        //        case "2":
        //            sbType.Append(" and state=1 ");
        //            break;
        //        case "3":
        //            sbType.Append(" and State=0 ");
        //            break;
        //        default:
        //            break;
        //    }
        //    return sbType.ToString();
        //}

      //  #endregion

        #region �ش��б�
        /// <summary>
        /// �󶨻ش�
        /// </summary>
        private void BindAnswer() 
        {
  
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and  Deleted=0   and (id in(select QuestionId from [Pinble_Web].dbo.PBnet_ask_Reply where Deleted=0  and Replyer='" + Method.Get_UserName + "' )) ");

           // bu.Append(this.AddParameter1());
            string Searchstr = bu.ToString();
            string order = "AskTime desc";
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

        protected void lbjf_Click(object sender, EventArgs e)
        {
            this.pnl2.Visible = true;
            this.pnl3.Visible = false;
            this.pnl4.Visible = false;
        }

        protected void lbask_Click(object sender, EventArgs e)
        {
            this.pnl3.Visible = true;
            this.pnl2.Visible = false;
            this.pnl4.Visible = false;
        }

        protected void lbanswer_Click(object sender, EventArgs e)
        {
            this.pnl2.Visible = false;
            this.pnl3.Visible = false;
            this.pnl4.Visible = true;
        }
    }
}
