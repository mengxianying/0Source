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
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
using System.Xml;


namespace Pinble_Ask
{
    public partial class Question : Pbzx.Common.SubmitOncePage
    {

        //��������
        protected string content = "";

        //��Ѵ�
        protected StringBuilder bestAnswer = new StringBuilder();

        /// <summary>
        /// ��������Ϣ
        /// </summary>
        protected string askUser;

        /// <summary>
        /// ��ǰ�û���
        /// </summary>
        protected string currentUserName;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Cache.SetNoStore();
            if (!Page.IsPostBack)
            {
                Bulletin_r1.Count = int.Parse(WebInit.siteconfig.BarBulletin);
                if (!string.IsNullOrEmpty(Request["question"]))
                {
                    ViewState["id"] = Input.FilterHTML(Input.Decrypt(Request["question"]));
                    Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
                    Pbzx.Model.PBnet_ask_Question questionModel = questionBLL.GetModel(int.Parse(ViewState["id"].ToString()));

                    if (questionModel == null)
                    {
                        Response.Write("<script>alert('�����ⲻ���ڣ�');history.go(-1);</script>");
                        Response.End();
                        return;
                    }

                    if (questionModel.Deleted)
                    {
                        Response.Write("<script>alert('�������Ѿ�������Աɾ��');history.go(-1);</script>");
                        Response.End();
                        return;
                    }

                    DateTime dtAsk = questionModel.AskTime;
                    if (questionModel.State == 0)
                    {
                        if (questionModel.AskTime.AddDays(int.Parse(WebInit.siteconfig.OverTime)) < DateTime.Now)
                        {
                            string askerName = questionModel.Asker;
                            Pbzx.BLL.PBnet_ask_User userBll = new Pbzx.BLL.PBnet_ask_User();
                            Pbzx.Model.PBnet_ask_User userModel = userBll.GetModelName(askerName);
                            userModel.OtherPointpenalty = int.Parse(WebInit.siteconfig.gqkf);
                            userBll.Update(userModel);
                            //Method.CheckUserGrade(Convert.ToString(userModel.Score - userModel.Pointpenalty - userModel.OtherPointpenalty), userModel.Title, userModel.ID.ToString());
                            questionModel.State = 2;
                            questionModel.OverTime = DateTime.Now;
                            questionBLL.Update(questionModel);
                        }
                    }

                    this.Title = questionModel.Title + " - ƴ����_ƴ�����߲���ͨ���";
                    questionModel.Views += 1;
                    //�󶨻ش����
                    BindData(questionModel);

                    if (questionModel.State == 0)
                    {
                        LoginSort login = new LoginSort();
                        if (!login["manager_user"])
                        {
                            this.Login.Visible = true;
                            this.HasLogin.Visible = false;
                        }
                        else
                        {

                            if (!login[ELoginSort.ask_User.ToString()])
                            {
                                HttpContext.Current.Response.Write("<script>if(confirm('����δ��ͨƴ���ɣ��Ƿ�ͨ��')){}else{window.top.location.href='" + WebInit.ask.WebUrl + "';</script>");
                                return;
                            }
                            if (Method.Get_UserName == questionModel.Asker)
                            {
                                this.trSet.Visible = true;
                                this.tbOther.Visible = false;
                            }
                            else
                            {
                                this.trSet.Visible = false;
                                this.tbOther.Visible = true;
                            }
                            this.HasLogin.Visible = true;
                            this.Login.Visible = false;

                            DataSet ds = DbHelperSQLBBS.Query("select UserName,UserEmail,JoinDate,LastLogin,UserClass,UserLastIP,LockUser,Mobile from Dv_User where username ='" + Method.Get_UserName + "';");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables[0].Rows[0]["LockUser"].ToString() == "1")
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "LockUserTS", JS.Alert("�����˻��Ѿ����������޷��ش�"), true);
                                    btnMyAnswer.Enabled = false;
                                    btnUMyAnswer.Enabled = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        trSet.Visible = false;
                        this.Login.Visible = false;
                        this.HasLogin.Visible = false;
                    }
                    questionBLL.Update(questionModel);
                }
            }
            else
            {
                if (ViewState["id"] != null)
                {
                    if (!string.IsNullOrEmpty(Request["question"]))
                    {
                        ViewState["id"] = Input.FilterHTML(Input.Decrypt(Request["question"]));
                        Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
                        Pbzx.Model.PBnet_ask_Question questionModel = questionBLL.GetModel(int.Parse(ViewState["id"].ToString()));
                        if (questionModel == null)
                        {
                            Response.Write("<script>alert('�����ⲻ���ڣ�');history.go(-1);</script>");
                            Response.End();
                            return;
                        }

                        DateTime dtAsk = questionModel.AskTime;
                        if (questionModel.State == 0)
                        {
                            if (questionModel.AskTime.AddDays(int.Parse(WebInit.siteconfig.OverTime)) < DateTime.Now)
                            {
                                string askerName = questionModel.Asker;
                                Pbzx.BLL.PBnet_ask_User userBll = new Pbzx.BLL.PBnet_ask_User();
                                Pbzx.Model.PBnet_ask_User userModel = userBll.GetModelName(askerName);
                                userModel.OtherPointpenalty = int.Parse(WebInit.siteconfig.gqkf);
                                userBll.Update(userModel);
                                //Method.CheckUserGrade(Convert.ToString(userModel.Score - userModel.Pointpenalty - userModel.OtherPointpenalty), userModel.Title, userModel.ID.ToString());
                                questionModel.State = 2;
                                questionModel.OverTime = DateTime.Now;
                                questionBLL.Update(questionModel);
                            }
                        }
                        //questionModel.Views += 1;

                        //�󶨻ش����
                        BindData(questionModel);

                        if (questionModel.State == 0)
                        {
                            LoginSort login = new LoginSort();
                            if (!login["manager_user"])
                            {
                                this.Login.Visible = true;
                                this.HasLogin.Visible = false;
                            }
                            else
                            {
                                if (!login[ELoginSort.ask_User.ToString()])
                                {
                                    HttpContext.Current.Response.Write("<script>if(confirm('����δ��ͨƴ���ɣ��Ƿ�ͨ��')){}else{window.top.location.href='" + WebInit.ask.WebUrl + "';</script>");
                                    return;
                                }
                                if (Method.Get_UserName == questionModel.Asker)
                                {
                                    this.trSet.Visible = true;
                                    this.tbOther.Visible = false;
                                }
                                else
                                {
                                    this.trSet.Visible = false;
                                    this.tbOther.Visible = true;
                                }
                                this.HasLogin.Visible = true;
                                this.Login.Visible = false;
                            }
                        }
                        else
                        {
                            trSet.Visible = false;
                            this.Login.Visible = false;
                            this.HasLogin.Visible = false;
                        }
                        questionBLL.Update(questionModel);
                    }
                }

            }
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="id"></param>
        private void BindData(Pbzx.Model.PBnet_ask_Question questionModel)
        {
            //��ԭ��� 
            Clear();

            //������ϸ��Ϣ
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();

            //�������
            int count = (int)questionModel.Views;
            this.lblviewCount.Text = count.ToString();
            questionModel.Views = count;

            txtRelay.Text = questionModel.Relay;
            questionBLL.Update(questionModel);

            //�󶨵���
            Pbzx.BLL.PBnet_ask_Type typeBLL = new Pbzx.BLL.PBnet_ask_Type();
            lblLink.Text = typeBLL.ChannelGetNavigation((int)questionModel.TypeID, true, "&nbsp>>&nbsp");


            //��������ϸ��Ϣ
            Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
            Pbzx.Model.PBnet_ask_User askUserModel = userBLL.GetModel((int)questionModel.AskerId);

            //�ظ�ҵ������
            Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
            //����״̬
            string questionState = "";
            //����ʱ��
            string questionTime = "";

            Pbzx.Model.PBnet_ask_Question myQuestionModel = questionBLL.GetModel(questionModel.Id);
            if (questionModel.State == 1 || questionModel.State == 2)
            {
                trSet.Visible = false;
            }

            if (questionModel != null)
            {
                switch (questionModel.State)
                {
                    case 0:
                        questionState = "<img src='images/A_ask.jpg' width='16' height='16' hspace='0' vspace='0' align='texttop' />&nbsp;�����";
                        questionTime = "����ʱ�䣺" + questionModel.AskTime.ToString();
                        break;
                    case 1:
                        questionState = "<img src='images/A_ok.jpg' width='16' height='16' hspace='0' vspace='0' align='texttop' />&nbsp;�ѽ��";
                        questionTime = "���ʱ�䣺" + questionModel.AskTime;
                        trSet.Visible = false;
                        break;
                    case 2:
                        questionState = "<img src='/images/A_ask.jpg' width='16' height='16' hspace='0' vspace='0' align='texttop' />&nbsp;�ѹر�";
                        questionTime = "�ر�ʱ�䣺" + questionModel.OverTime;
                        break;
                }
            }
            lblTime.Text = questionTime;
            this.litState.Text = questionState;

            //�������
            if (questionModel.IsCommend)
            {
                this.lbltitle.Text = "<font color='red'>[��]</font>" + questionModel.Title;
            }
            else
            {
                this.lbltitle.Text = questionModel.Title;
            }
            //��������
            content = questionModel.Content;
            //�ͷ�
            this.lbllargessPoint.Text = questionModel.LargessPoint.ToString();

            if (!string.IsNullOrEmpty(questionModel.Relay.Trim()))
            {
                content += "<br/><font style='font-weight:bolder;'>���ⲹ�䣺</font><br/>" + questionModel.Relay;
            }

            this.lblcontent.Text = content;

            //������
            if (questionModel.IsAnonymous)
            {
                this.lblaskUser.Text = "����&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
            }
            else
            {
                this.lblaskUser.Text = "<a target='_blank' href='UserShow.aspx?name=" + Input.Encrypt(questionModel.AskerId.ToString()) + "'>" + askUserModel.UserName + "</a>- <a href='Help.aspx#n5' target='_blank'>" + Method.GetUserTitle(Convert.ToString(askUserModel.Score - askUserModel.Pointpenalty - askUserModel.OtherPointpenalty)) + "</a>";
            }
            if (questionModel.State > 2 || questionModel.State < 0)
            {
                this.divClose.Visible = true;
            }
            else
            {
                ///��Ѵ�
                List<Pbzx.Model.PBnet_ask_Reply> lsBest = replyBLL.GetModelList("QuestionId='" + ViewState["id"] + "' and IsBest=1 ");
                if (lsBest.Count > 0)
                {
                    bestAnswer.Append(" <table width='96%' border='0' cellpadding='1' cellspacing='0'>");
                    bestAnswer.Append("<tr> <td class='f14black' align='left' >" + lsBest[0].Content + "</td></tr>");
                    bestAnswer.Append("<tr><td align='right'>�ش��ߣ�<a target='_blank' href='UserShow.aspx?name=" + Input.Encrypt(lsBest[0].ReplyerId.ToString()) + "'>" + lsBest[0].Replyer + " </a>- <a href='Help.aspx#n5' target='_blank'>" + userBLL.GetTitleByID((int)lsBest[0].ReplyerId) + "</a>&nbsp;&nbsp;&nbsp;" + lsBest[0].ReplyTime + "</td> </tr>");
                    bestAnswer.Append("</table>");
                    litBestAnswer.Text = bestAnswer.ToString();
                    this.divBestAnswer.Visible = true;
                }
                else
                {
                    litBestAnswer.Text = "";
                    this.divBestAnswer.Visible = false;
                }
                this.divClose.Visible = false;
            }

            //�������ظ���
            BindOtherReplays();
            LoginSort login = new LoginSort();
            if (login["manager_user"])
            {
                if (!login[ELoginSort.ask_User.ToString()])
                {
                    HttpContext.Current.Response.Write("<script>if(confirm('����δ��ͨƴ���ɣ��Ƿ�ͨ��')){}else{window.top.location.href='" + WebInit.ask.WebUrl + "';</script>");
                    HttpContext.Current.Response.End();
                    return;
                }
                if (questionModel.State == 0)
                {
                    //��ǰ�û���
                    List<Pbzx.Model.PBnet_ask_Reply> lsCurrent = replyBLL.GetModelList("Replyer='" + Method.Get_UserName + "' and QuestionId=" + ViewState["id"].ToString() + " ");
                    if (lsCurrent.Count < 1)
                    {
                        tbMyAnswerInsert.Visible = true;
                    }
                }
            }

        }



        /// <summary>
        /// ���������б�
        /// </summary>
        private void BindOtherReplays()
        {
            //�ظ�ҵ������
            Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
            StringBuilder bu = new StringBuilder();
            bu.Append(" Auditing=1 and Deleted=0 ");
            bu.Append(this.AddParameter());

            string Searchstr = bu.ToString();
            string order = "ReplyTime desc ";
            int mycount = 0;
            DataTable IsResult = replyBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.ask.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out mycount);
            this.MyGridView.DataSource = IsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(mycount);
            if (IsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
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
            BindOtherReplays();
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();
            bu1.Append(" and QuestionId=" + ViewState["id"].ToString() + " and IsBest='0' ");
            return bu1.ToString();
        }



        /// <summary>
        /// �����û�ID�õ��û�ͷ��
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        protected string GetUserTitle(object userID)
        {
            try
            {
                Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
                if (string.IsNullOrEmpty(userID.ToString()))
                {
                    return "";
                }
                return userBLL.GetTitleByID((int)userID);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRelayAdd_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.Model.PBnet_ask_Question questionModel = questionBLL.GetModel(int.Parse(ViewState["id"].ToString()));
            if (!IsRefreshed)
            {
                //������ϸ��Ϣ

                if (questionModel != null)
                {
                    questionModel.Relay = Input.ToHtml(Input.FilterHTML(Request.Form["txtRelay"]));
                    questionModel.UpdateTime = DateTime.Now;
                    questionBLL.Update(questionModel);
                }
            }
            else
            {
                Response.Redirect("Question.aspx?question=" + Request["question"], true);
            }
            BindData(questionModel);
        }

        /// <summary>
        /// ����ͷ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddScore_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
            Pbzx.Model.PBnet_ask_User askUserModel = Pbzx.BLL.PBnet_ask_User.GetCurrentAsker();
            int jifen = int.Parse(this.ddlAdd.SelectedValue);
            if (jifen > (askUserModel.Score - askUserModel.Pointpenalty - askUserModel.OtherPointpenalty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("���û��ֲ�����"));
                return;
            }
            else
            {
                Pbzx.Model.PBnet_ask_Question questionModel = questionBLL.GetModel(int.Parse(ViewState["id"].ToString()));
                if (!IsRefreshed)
                {
                    if (questionModel != null)
                    {
                        questionModel.LargessPoint += int.Parse(this.ddlAdd.SelectedValue);
                        questionBLL.Update(questionModel);
                    }
                }
                else
                {
                    Response.Redirect("Question.aspx?question=" + Request["question"]);
                }
                askUserModel.Pointpenalty += int.Parse(this.ddlAdd.SelectedValue);
                // Method.CheckUserGrade(Convert.ToString(askUserModel.Score - askUserModel.Pointpenalty - askUserModel.OtherPointpenalty), askUserModel.Title, askUserModel.ID.ToString());
                userBLL.Update(askUserModel);
                BindData(questionModel);
            }
        }
        //�ر������¼�
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            if (!IsRefreshed)
            {
                Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
                Pbzx.Model.PBnet_ask_Question questionModel = questionBLL.GetModel(int.Parse(ViewState["id"].ToString()));
                if (questionModel != null)
                {
                    questionModel.State = 2;
                    questionModel.OverTime = DateTime.Now;
                    questionBLL.Update(questionModel);
                }
                BindOtherReplays();
                Response.Redirect("Question.aspx?question=" + Request["question"]);
            }
            else
            {
                Response.Redirect("Question.aspx?question=" + Request["question"]);
            }

        }

        /// <summary>
        /// ��¼�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write("<script>window.top.location.href='Login.aspx?ReturnURL=" + HttpContext.Current.Request.Url.PathAndQuery + "';</script>");
            HttpContext.Current.Response.End();
            return;
        }
        /// <summary>
        /// ע���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnReg_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write("<script>window.top.location.href='Login.aspx?ReturnURL=" + HttpContext.Current.Request.Url.PathAndQuery + "';</script>");
            HttpContext.Current.Response.End();
            return;
        }

        /// <summary>
        /// �����ش�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMyAnswer_Click(object sender, EventArgs e)
        {
            if (!IsRefreshed)
            {
                ViewState["txtMyReplay"] = Input.ToHtml(Input.FilterHTML(Request.Form["txtMyReplay"]));

                if (this.txtCode.Text.ToUpper() != Session["ValidateCode"].ToString())
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("��֤���������!"));
                    this.txtMyReplay.Text = Request.Form["txtMyReplay"];
                    txtReferenceBook.Text = Request.Form["txtReferenceBook"];
                    return;
                    //ClientScript.RegisterStartupScript(GetType(), "vcodeError", "alert('��֤���������')", true);
                    //Response.End();
                    //return;
                }


                //��ȡXML����
                int number = 0;
                try
                {
                    XmlDocument doc = new XmlDocument();
                    //����xml
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/AskConfig.xml"));
                    //�õ����ڵ�
                    XmlElement root = doc.DocumentElement;
                    if (root.ChildNodes.Count > 0)
                    {
                        XmlNode chirot = root.SelectNodes("Ask_astrict")[0];

                        string pbzf = chirot.SelectSingleNode("@value").Value;

                        string sh = chirot.SelectSingleNode("@status").Value;

                        if (pbzf != "" && pbzf.Trim() != "")
                        {
                            if (pbzf.Substring(pbzf.Length - 1) == ",")
                            {
                                pbzf = pbzf.Substring(0, pbzf.Length - 1);
                            }

                            string[] upb = pbzf.Split('|');



                            for (int i = 0; i < upb.Length; i++)
                            {
                                if (Request.Form["txtMyReplay"].Contains(upb[i]))
                                {
                                    number++;
                                }
                            }
                        }

                        if (number > 0 && sh == "false")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("�ظ��д��ڷǷ��ַ�!"));
                            return;
                        }
                    }
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("ϵͳ��æ!"));
                    return;
                }

                Pbzx.Model.PBnet_ask_User askUser = Pbzx.BLL.PBnet_ask_User.GetCurrentAsker();
                Pbzx.Model.PBnet_ask_Reply replyMode = new Pbzx.Model.PBnet_ask_Reply();
                Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
                //�����ı��򣬷�ֹ�ű�����
                replyMode.QuestionId = int.Parse(ViewState["id"].ToString());
                replyMode.Content = Input.ToHtml(Input.FilterHTML(Request.Form["txtMyReplay"]));
                replyMode.Replyer = askUser.UserName;
                replyMode.ReplyTime = DateTime.Now;
                replyMode.IsBest = false;
                replyMode.ReferenceBook = Input.FilterHTML(Request.Form["txtReferenceBook"]);

                if (number == 0)
                {
                    replyMode.Auditing = true;
                }
                else
                {
                    replyMode.Auditing = false;
                }

                replyMode.Comment = "";
                replyMode.GoodComment = 0;
                replyMode.BadComment = 0;
                replyMode.AttachId = 0;
                replyMode.ReplyerId = askUser.ID;
                replyBLL.Add(replyMode);

                BindOtherReplays();
                tbMyAnswerInsert.Visible = false;

                askUser.ReplyNum += 1;
                askUser.Point += Convert.ToInt32(WebInit.siteconfig.dadf);
                askUser.Score += Convert.ToInt32(WebInit.siteconfig.dadf);
                Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
                // Method.CheckUserGrade(Convert.ToString(askUser.Score - askUser.Pointpenalty - askUser.OtherPointpenalty), askUser.Title, askUser.ID.ToString());
                userBLL.Update(askUser);

                Pbzx.BLL.PBnet_ask_Question bllQuestion = new Pbzx.BLL.PBnet_ask_Question();
                Pbzx.Model.PBnet_ask_Question questionModel = bllQuestion.GetModel(int.Parse(ViewState["id"].ToString()));
                questionModel.Replys += 1;

                //Method.CheckUserGrade(Convert.ToString(askReplyer.Score - askReplyer.Pointpenalty - askReplyer.OtherPointpenalty), askReplyer.Title, askReplyer.ID.ToString());

                bllQuestion.Update(questionModel);
            }
            else
            {
                Response.Redirect("Question.aspx?question=" + Request["question"]);
            }
        }


        /// <summary>
        /// �޸Ļش�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            if (!IsRefreshed)
            {
                Response.Redirect("/QuestionUpdate.aspx?question=" + Request["question"] + "&replyId=" + e.CommandArgument.ToString());
                // (sender as Button).Visible = false;
                //int replyId = int.Parse(e.CommandArgument.ToString());
                //Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
                //Pbzx.Model.PBnet_ask_Reply repModel = replyBLL.GetModel(replyId);
                //this.tbMyAnswerInsert.Visible = false;
                //this.tbMyAnswerUpdate.Visible = true;
                //this.txtUContent.Text = Input.ToTxt(repModel.Content);
                //this.txtUReferenceBook.Text = repModel.ReferenceBook;
                //ViewState["updateID"] = replyId.ToString();
            }
        }

        /// <summary>
        /// ��Ϊ��Ѵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBest_Command(object sender, CommandEventArgs e)
        {
            if (!IsRefreshed)
            {
                int replyId = int.Parse(e.CommandArgument.ToString());
                Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
                Pbzx.Model.PBnet_ask_Reply repModel = replyBLL.GetModel(replyId);



                Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
                Pbzx.Model.PBnet_ask_User askReplyer = userBLL.GetModel((int)repModel.ReplyerId);
                askReplyer.Best_ReplyNum += 1;

                Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
                Pbzx.Model.PBnet_ask_Question qModel = questionBLL.GetModel(int.Parse(ViewState["id"].ToString()));


                askReplyer.Point += (int)qModel.LargessPoint + int.Parse(WebInit.siteconfig.dajiadf);
                askReplyer.Score += int.Parse(lbllargessPoint.Text.Trim()) + int.Parse(WebInit.siteconfig.dajiadf);
                //Method.CheckUserGrade(Convert.ToString(askReplyer.Score - askReplyer.Pointpenalty - askReplyer.OtherPointpenalty), askReplyer.Title, askReplyer.ID.ToString());
                userBLL.Update(askReplyer);

                repModel.IsBest = true;
                replyBLL.Update(repModel);



                qModel.State = 1;
                qModel.Answerer = repModel.Replyer;
                qModel.AnswererId = repModel.ReplyerId;
                qModel.OverTime = DateTime.Now;

                //Method.CheckUserGrade(Convert.ToString(askReplyer.Score - askReplyer.Pointpenalty - askReplyer.OtherPointpenalty), askReplyer.Title, askReplyer.ID.ToString());

                questionBLL.Update(qModel);
                BindData(qModel);

            }
        }


        /// <summary>
        /// ��ԭ���
        /// </summary>
        private void Clear()
        {
            this.lblInsert.Visible = true;
            this.txtMyReplay.Text = "�ش𼴵ý���" + WebInit.siteconfig.dadf + "�֣��ش𱻲��ɵ����ͷ֡�";
            this.txtMyReplay.Attributes.Add("onfocus", "if(this.value=='�ش𼴵ý���" + WebInit.siteconfig.dadf + "�֣��ش𱻲��ɵ����ͷ֡�'){this.value=''}");
            this.txtReferenceBook.Text = "";
            this.btnMyAnswer.Text = "�ύ�ش�";
        }

        /// <summary>
        /// ����󶨲ο�����
        /// </summary>
        protected string AddReferenceBook(object objBook)
        {
            if (objBook == null)
            {
                return "";
            }
            else
            {
                if (objBook.ToString().Trim() == "")
                {
                    return "";
                }
                else
                {
                    return "<font color='#666666'>�ο����ϣ�" + objBook.ToString() + "</font>";
                }
            }
        }

        /// <summary>
        /// �д�����ʱ���жϴ���ǰ��¼�û��Ƿ�ش��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            LoginSort login = new LoginSort();
            if (login["manager_user"])
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string currentReplyer = MyGridView.DataKeys[e.Row.RowIndex].Values["Replyer"].ToString();
                    string currentID = MyGridView.DataKeys[e.Row.RowIndex].Values["QuestionId"].ToString();
                    Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
                    Pbzx.Model.PBnet_ask_Question quModel = questionBLL.GetModel(int.Parse(currentID));
                    string currentState = quModel.State.ToString();

                    if (currentState == "0")
                    {
                        if (currentReplyer == Method.Get_UserName)
                        {

                            if (!login[ELoginSort.ask_User.ToString()])
                            {
                                HttpContext.Current.Response.Write("<script>if(confirm('����δ��ͨƴ���ɣ��Ƿ�ͨ��')){}else{window.top.location.href='" + WebInit.ask.WebUrl + "';</script>");
                                HttpContext.Current.Response.End();
                                return;
                            }

                            Button btnUpdate = new Button();
                            btnUpdate.Text = "�޸Ĵ�";
                            btnUpdate.CommandArgument = MyGridView.DataKeys[e.Row.RowIndex].Values["ID"].ToString();
                            btnUpdate.Command += new CommandEventHandler(btnUpdate_Command);
                            e.Row.Cells[0].Controls.Add(btnUpdate);
                        }
                        else if (quModel.Asker == Method.Get_UserName)
                        {
                            Button btnBest = new Button();
                            btnBest.Text = "����Ϊ��";
                            btnBest.Attributes.Add("onclick", "return Confirm('��ȷ��Ҫ����Ϊ����')");
                            btnBest.CommandArgument = MyGridView.DataKeys[e.Row.RowIndex].Values["ID"].ToString();
                            btnBest.Command += new CommandEventHandler(btnBest_Command);
                            //MyGridView.Rows[e.Row.RowIndex -1]
                            e.Row.Cells[0].Controls.Add(btnBest);
                            // MyGridView.FooterRow.Cells[0].Controls.Add(btnBest);
                        }
                    }
                    Label lbHr = new Label();
                    lbHr.Text = "<hr width='100%'>";
                    e.Row.Cells[0].Controls.Add(lbHr);
                }
            }

        }

        protected void btnUMyAnswer_Click(object sender, EventArgs e)
        {
            if (!IsRefreshed)
            {
                if (ViewState["updateID"] != null)
                {
                    if (this.txtUCode.Text.ToUpper() != Session["Code"].ToString())
                    {

                        // Page.ClientScript.RegisterStartupScript(GetType(), "vcodeError", JS.Alert("��֤���������"), true);
                        //// Response.End();
                        // return;

                        Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("��֤���������!"));
                        return;
                    }


                    //��ȡXML����
                    int number = 0;
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        //����xml
                        doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/AskConfig.xml"));
                        //�õ����ڵ�
                        XmlElement root = doc.DocumentElement;
                        if (root.ChildNodes.Count > 0)
                        {
                            XmlNode chirot = root.SelectNodes("Ask_astrict")[0];

                            string pbzf = chirot.SelectSingleNode("@value").Value;

                            string sh = chirot.SelectSingleNode("@status").Value;



                            if (pbzf != "" && pbzf.Trim() != "")
                            {
                                if (pbzf.Substring(pbzf.Length - 1) == ",")
                                {
                                    pbzf = pbzf.Substring(0, pbzf.Length - 1);
                                }

                                string[] upb = pbzf.Split('|');

                                if (upb.Length > 0)
                                {

                                    for (int i = 0; i < upb.Length; i++)
                                    {
                                        if (Request.Form["txtUContent"].Contains(upb[i]))
                                        {
                                            number++;
                                        }
                                    }
                                }
                            }

                            if (number > 0 && sh == "false")
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("�ظ��д��ڷǷ��ַ�!"));
                                return;
                            }
                        }
                    }
                    catch
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("ϵͳ��æ!"));
                        return;
                    }


                    Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
                    Pbzx.Model.PBnet_ask_Reply repModel = replyBLL.GetModel(int.Parse(ViewState["updateID"].ToString()));
                    repModel.Content = Input.ToHtml(Input.FilterHTML(Request.Form["txtUContent"]));
                    repModel.ReferenceBook = Input.FilterHTML(Request.Form["txtUReferenceBook"]);

                    if (number == 0)
                    {
                        repModel.Auditing = true;
                    }
                    else
                    {
                        repModel.Auditing = false;
                    }

                    repModel.ReplyTime = DateTime.Now;
                    replyBLL.Update(repModel);
                    tbMyAnswerUpdate.Visible = false;
                    BindOtherReplays();
                }
            }
            else
            {
                Response.Redirect("Question.aspx?question=" + Request["question"]);
            }
        }


    }
}
