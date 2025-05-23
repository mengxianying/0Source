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
using System.Xml;
using Maticsoft.DBUtility;

namespace Pinble_Ask
{
    public partial class QuestionUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["question"]))
                {
                    ViewState["id"] = Input.FilterHTML(Input.Decrypt(Request["question"]));
                    Pbzx.BLL.PBnet_ask_Question questionBLL = new Pbzx.BLL.PBnet_ask_Question();
                    Pbzx.Model.PBnet_ask_Question questionModel = questionBLL.GetModel(int.Parse(ViewState["id"].ToString()));
                    if (questionModel.Deleted)
                    {
                        Response.Write("<script>alert('该问题已经被管理员删除');history.go(-1);</script>");
                        Response.End();
                        return;
                    }
                    //questionModel.Views += 1;

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
                                HttpContext.Current.Response.Write("<script>if(confirm('您尚未开通拼搏吧！是否开通？')){}else{window.top.location.href='" + WebInit.ask.WebUrl + "';</script>");
                                return;
                            }
                            if (Method.Get_UserName == questionModel.Asker)
                            {
                                this.tbOther.Visible = false;
                            }
                            else
                            {
                                Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
                                if (Request["replyId"] != null)
                                {
                                    int repID = 0;
                                    if (int.TryParse(Request["replyId"], out repID))
                                    {
                                        Pbzx.Model.PBnet_ask_Reply repModel = replyBLL.GetModel(repID);
                                        if (repModel.Replyer == Method.Get_UserName)
                                        {
                                            this.tbMyAnswerUpdate.Visible = true;
                                        }
                                        this.txtUContent.Text = Input.ToTxt(repModel.Content);
                                        this.txtUReferenceBook.Text = repModel.ReferenceBook;
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    this.tbMyAnswerInsert.Visible = false;
                                }

                                this.tbOther.Visible = true;
                            }
                            this.HasLogin.Visible = true;
                            this.Login.Visible = false;

                            DataSet ds = DbHelperSQLBBS.Query("select UserName,UserEmail,JoinDate,LastLogin,UserClass,UserLastIP,LockUser,Mobile from Dv_User where username ='" + Method.Get_UserName + "';");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables[0].Rows[0]["LockUser"].ToString() == "1")
                                {
                                    ClientScript.RegisterStartupScript(GetType(), "LockUserTS", JS.Alert("您的账户已经被锁定，无法回答"), true);
                                    btnMyAnswer.Enabled = false;
                                    btnUMyAnswer.Enabled = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        this.Login.Visible = false;
                        this.HasLogin.Visible = false;
                    }
                    questionBLL.Update(questionModel);
                }
                else {
                    Response.Redirect("/");
                }
            }
        }


        /// <summary>
        /// 我来回答
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnMyAnswer_Click(object sender, EventArgs e)
        {
            if (this.txtCode.Text.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("验证码输入错误!"));
                return;
                //ClientScript.RegisterStartupScript(GetType(), "vcodeError", "alert('验证码输入错误！')", true);
                //Response.End();
                //return;
            }

            int number = 0;
            //读取XML配置
            try
            {
                XmlDocument doc = new XmlDocument();
                //加载xml
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/AskConfig.xml"));
                //得到根节点
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
                                if (this.txtMyReplay.Text.Contains(upb[i]))
                                {
                                    number++;
                                }
                            }
                        }
                    }

                    if (number > 0 && sh == "false")
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("回复中存在非法字符!"));
                        return;
                    }
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("系统繁忙!"));
                return;
            }
            Pbzx.Model.PBnet_ask_User askUser = Pbzx.BLL.PBnet_ask_User.GetCurrentAsker();
            Pbzx.Model.PBnet_ask_Reply replyMode = new Pbzx.Model.PBnet_ask_Reply();
            Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
            //过滤文本框，防止脚本攻击
            replyMode.QuestionId = int.Parse(ViewState["id"].ToString());
            replyMode.Content = Input.ToHtml(Input.FilterHTML(this.txtMyReplay.Text));
            replyMode.Replyer = askUser.UserName;
            replyMode.ReplyTime = DateTime.Now;
            replyMode.IsBest = false;
            replyMode.ReferenceBook = Input.FilterHTML(this.txtReferenceBook.Text);
            replyMode.Comment = "";
            replyMode.GoodComment = 0;
            replyMode.BadComment = 0;

            if (number == 0)
            {
                replyMode.Auditing = true;
            }
            else
            {
                replyMode.Auditing = false;
            }

            replyMode.AttachId = 0;
            replyMode.ReplyerId = askUser.ID;
            replyBLL.Add(replyMode);

            tbMyAnswerInsert.Visible = false;

            askUser.ReplyNum += 1;
            askUser.Point += 1;
            askUser.Score += 1;
            Pbzx.BLL.PBnet_ask_User userBLL = new Pbzx.BLL.PBnet_ask_User();
            //Method.CheckUserGrade(Convert.ToString(askUser.Score - askUser.Pointpenalty - askUser.OtherPointpenalty), askUser.Title, askUser.ID.ToString());
            userBLL.Update(askUser);

            Pbzx.BLL.PBnet_ask_Question bllQuestion = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.Model.PBnet_ask_Question questionModel = bllQuestion.GetModel(int.Parse(ViewState["id"].ToString()));
            questionModel.Replys += 1;

            //Method.CheckUserGrade(Convert.ToString(askReplyer.Score - askReplyer.Pointpenalty - askReplyer.OtherPointpenalty), askReplyer.Title, askReplyer.ID.ToString());
            bllQuestion.Update(questionModel);
            Response.Redirect("Question.aspx?question=" + Request["question"]);

        }


        protected void btnUMyAnswer_Click(object sender, EventArgs e)
        {
            if (Request["replyId"] != null)
            {
                if (this.txtUCode.Text.ToUpper() != Session["Code"].ToString())
                {

                    // Page.ClientScript.RegisterStartupScript(GetType(), "vcodeError", JS.Alert("验证码输入错误！"), true);
                    //// Response.End();
                    // return;

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("验证码输入错误!"));
                    return;
                }

                int number = 0;
                //读取XML配置
                try
                {
                    XmlDocument doc = new XmlDocument();
                    //加载xml
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/AskConfig.xml"));
                    //得到根节点
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
                                    if (this.txtUContent.Text.Contains(upb[i]))
                                    {
                                        number++;
                                    }
                                }
                            }
                        }

                        if (number > 0 && sh == "false")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("回复中存在非法字符!"));
                            return;
                        }
                    }
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("系统繁忙!"));
                    return;
                }




                Pbzx.BLL.PBnet_ask_Reply replyBLL = new Pbzx.BLL.PBnet_ask_Reply();
                Pbzx.Model.PBnet_ask_Reply repModel = replyBLL.GetModel(int.Parse(Request["replyId"]));
                repModel.Content = Input.ToHtml(Input.FilterHTML(this.txtUContent.Text));
                repModel.ReferenceBook = Input.FilterHTML(this.txtUReferenceBook.Text);


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
            }
            Response.Redirect("Question.aspx?question=" + Request["question"]);
        }


        /// <summary>
        /// 登录事件
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
        /// 注册事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnReg_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Write("<script>window.top.location.href='Login.aspx?ReturnURL=" + HttpContext.Current.Request.Url.PathAndQuery + "';</script>");
            HttpContext.Current.Response.End();
            return;
        }

    }
}
