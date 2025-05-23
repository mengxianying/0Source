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
using Maticsoft.DBUtility;
using System.Text;
using Pbzx.Common;
using System.Collections.Generic;

namespace Pinble_Ask
{
    public partial class UserShow : System.Web.UI.Page
    {
        protected string userName = "";
        protected string userRegTime = "";
        protected string userJF = "";
        protected string userTitle = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //1���Ȱ��û�������Ϣ��˳���ܱ䣩
                BindUserInfo();
                // �󶨻ش�ͳ��
                BindWD();
                //���ʴ�
                BindAnswer();

            }
        }


        /// <summary>
        /// ���û���Ϣ
        /// </summary>
        private void BindUserInfo()
        {
            //this.lblEmail.Text = dtDV.Rows[0]["UserEmail"].ToString();
            //this.lblRegTime.Text = dtDV.Rows[0]["JoinDate"].ToString();
            //this.lblLastLogin.Text = dtDV.Rows[0]["LastLogin"].ToString();
            //this.lblLoginCount.Text = dtDV.Rows[0]["UserLogins"].ToString();
            Pbzx.BLL.PBnet_ask_User utBLL = new Pbzx.BLL.PBnet_ask_User();
            List<Pbzx.Model.PBnet_ask_User> lbg = utBLL.GetModelList(" ID='" + Input.Decrypt(Input.FilterAll(Request["name"])) + "' ");
            if (lbg.Count > 0)
            {
                Pbzx.Model.PBnet_ask_User userModel = lbg[0];
                ViewState["id"] = userModel.UserName;
                userName = userModel.UserName;
                this.Title = userName+ "���û���Ϣ���� - ƴ���� - ƴ�����߲���ͨ���";
                
                DataTable dtDV = DbHelperSQLBBS.Query("select UserEmail,JoinDate,LastLogin,UserLogins from Dv_User where UserName='" + userModel.UserName + "' ").Tables[0];
                userRegTime = dtDV.Rows[0]["JoinDate"].ToString();
                userJF = Convert.ToString(userModel.Score - userModel.Pointpenalty - userModel.OtherPointpenalty);
                userTitle = Method.GetUserTitle(Convert.ToString(userModel.Score-userModel.Pointpenalty-userModel.OtherPointpenalty));

                //�󶨻���
                BindJF(userModel);
            }
        }


        /// <summary>
        /// �󶨻���
        /// </summary>
        private void BindJF(Pbzx.Model.PBnet_ask_User askUserModel)
        {
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();


            lblTotalPoint.Text = Convert.ToString(askUserModel.Score - askUserModel.Pointpenalty - askUserModel.OtherPointpenalty);
            //LargessPoint
            //object objAnswerPoint = questionBLL.GetSingleData("select sum(LargessPoint) from PBnet_ask_Question where Answerer='" + ViewState["id"] + "' ");
            //if (objAnswerPoint != null)
            //{
            //    lblAnswerPoint.Text = objAnswerPoint.ToString();
            //}

            lblAnswerPoint.Text = Convert.ToString(askUserModel.Score);

            //object objXSPoint = questionBLL.GetSingleData("select sum(LargessPoint) from PBnet_ask_Question where Asker='" + ViewState["id"] + "' ");
            //if (objXSPoint != null)
            //{
            //    this.lblXSPoint.Text = objXSPoint.ToString();
            //}

            lblXSPoint.Text = Convert.ToString(askUserModel.Pointpenalty);

            //object objPointpenalty = askUserModel.Pointpenalty.ToString();
            //if (objPointpenalty != null)
            //{
            //    this.lblPointpenalty.Text = objPointpenalty.ToString();
            //}
            lblPointpenalty.Text = Convert.ToString(askUserModel.OtherPointpenalty);



            //object objOtherPointpenalty = askUserModel.OtherPointpenalty.ToString();
            //if (objOtherPointpenalty != null)
            //{
            //    this.lblOtherPointpenalty.Text = objOtherPointpenalty.ToString();
            //}

            //lblOtherGet.Text = 

        }

        /// <summary>
        /// �󶨻ش�ͳ��
        /// </summary>
        private void BindWD()
        {
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
            Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
            object objHds = questionBLL.GetSingleData("select count(1) from PBnet_ask_Question where  Deleted=0 and id in(select QuestionId from PBnet_ask_Reply where  Deleted=0 and   Replyer='" + ViewState["id"] + "')  ");
            int cns = 0;
            int hds = 1;
            if (objHds != null)
            {
                cns = (int)objHds;
                this.lblAnswerCount.Text = cns.ToString();
            }
            else
            {
                this.lblAnswerCount.Text = "0"; 
            }

            object objAnswerCount = replyBLL.GetSingleData("select count(1) from PBnet_ask_Question where  Deleted=0  and id in(select QuestionId from PBnet_ask_Reply where  Deleted=0 and   Replyer='" + ViewState["id"] + "' and IsBest=1 )  ");
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

        }



        #region �ش��б�
        /// <summary>
        /// �󶨻ش�
        /// </summary>
        private void BindAnswer()
        {

            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1  and Deleted=0  and (id in(select QuestionId from PBnet_ask_Reply where  Deleted=0 and   Replyer='" + ViewState["id"] + "' ");

            bu.Append(this.AddParameter1());
            bu.Append("  )) ");
            string Searchstr = bu.ToString();
            string order = "AskTime desc ";
            int mycount = 0;
            DataTable IsResult = questionBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.ask.WebPageNum, 3, AspNetPager2.CurrentPageIndex, out mycount);
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
        #endregion

        protected string FormatIsBest(object questionID)
        {
            Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
            DataSet ds = replyBLL.GetList(" QuestionId=" + questionID.ToString() + " and Replyer='" + ViewState["id"] + "' and IsBest=1 ");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return "<img alt='������Ϊ��Ѵ�' src='images/icn_best.gif' />";
            }
            else
            {
                return "";
            }
        }



    }
}
