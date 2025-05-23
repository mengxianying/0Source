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
using Maticsoft.DBUtility;
using System.Xml;

namespace Pinble_Ask
{
    public partial class Ask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblNM.Text = WebInit.siteconfig.mdf;
                LoginSort login = new LoginSort();
                if (login["manager_user"])
                {
                    DataSet ds = DbHelperSQLBBS.Query("select UserName,UserEmail,JoinDate,LastLogin,UserClass,UserLastIP,LockUser,Mobile from Dv_User where username ='" + Method.Get_UserName + "';");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["LockUser"].ToString() == "1")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "LockUserTS", JS.Alert("您的账户已经被锁定，无法提问"), true);
                            btnOK.Enabled = false;
                        }
                    }
                }
                //if(!(login[ELoginSort.manager_user.ToString()] && login[ELoginSort.ask_User.ToString()]))
                //{
                //    Response.Redirect("http://www.pinble2.com/Login.aspx?ReturnUrl='bar.pinble2.com/Ask.aspx'");
                //    return;
                //}                
                BindData();

            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {

            if (Request["title"] != null)
            {
                this.txtTitle.Text = Input.Decrypt(Input.FilterHTML(Request["Title"]));
            }
            Pbzx.BLL.PBnet_ask_Type typeBLL = new Pbzx.BLL.PBnet_ask_Type();
            DataSet ds = typeBLL.GetList("Depth=0 and BitIsAuditing='1' order by OrderID  ");
            this.libBigType.DataSource = ds;
            this.libBigType.DataTextField = "TypeName";
            this.libBigType.DataValueField = "Id";
            this.libBigType.DataBind();
            this.libBigType.Items[0].Selected = true;

            Pbzx.BLL.PBnet_ask_Type askTypeBLL = new Pbzx.BLL.PBnet_ask_Type();
            DataSet dsChild = askTypeBLL.GetList(" FTypeID=" + libBigType.SelectedValue + " and  BitIsAuditing='1' ");
            this.libType.DataSource = dsChild;
            this.libType.DataTextField = "TypeName";
            this.libType.DataValueField = "Id";
            this.libType.DataBind();
            this.libType.Items.Insert(0, new ListItem("不选", ""));
            this.libType.Items[0].Selected = true;

            //this.libBigType.Attributes.Add("onchange", "bigTypeChange('" + this.libType.ClientID + "',this.value)");
            Pbzx.Model.PBnet_ask_User userModel = Pbzx.BLL.PBnet_ask_User.GetCurrentAsker();
            lblScore.Text = Convert.ToString(userModel.Score - userModel.Pointpenalty - userModel.OtherPointpenalty);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Pbzx.Model.PBnet_ask_User userModel = Pbzx.BLL.PBnet_ask_User.GetCurrentAsker();
            Pbzx.BLL.PBnet_ask_User bllUser = new Pbzx.BLL.PBnet_ask_User();


            Pbzx.BLL.PBnet_ask_Question bllQuestion = new Pbzx.BLL.PBnet_ask_Question();
            Pbzx.Model.PBnet_ask_Question model = new Pbzx.Model.PBnet_ask_Question();

            model.Title = Input.FilterHTML(this.txtTitle.Text);
            model.Content = Input.ToHtml(Input.FilterHTML(this.txtContent.Text));

            model.Asker = userModel.UserName;
            model.AskTime = DateTime.Now;
            model.OverTime = DateTime.Now.AddMonths(2);
            model.UpdateTime = DateTime.Now;
            model.Views = 0;

            if (string.IsNullOrEmpty(Request.Form["libType"]))
            {
                model.TypeID = int.Parse(libBigType.SelectedValue);
                model.TypeName = libBigType.SelectedItem.Text;
            }
            else
            {
                model.TypeID = int.Parse(Request.Form["libType"]);
                model.TypeName = libType.SelectedItem.Text;
            }
            model.FTypeID = int.Parse(libBigType.SelectedValue);
            model.State = 0;

            model.LargessPoint = int.Parse(this.ddlLargessPoint.SelectedValue);
            model.IsCommend = false;
            int tempNM = 0;

            if (this.chkIsAnonymous.Checked)
            {
                tempNM = int.Parse(WebInit.siteconfig.mdf);
                model.IsAnonymous = true;
            }
            else
            {

                model.IsAnonymous = false;
            }
            if (userModel.Score - userModel.Pointpenalty - userModel.OtherPointpenalty < model.LargessPoint)
            {
                ClientScript.RegisterStartupScript(GetType(), "questionAdd", JS.Alert("您得积分不够！提问失败！"), true);
                return;
            }
            model.AttachId = 0;
            model.Replys = 0;
            model.AskerId = userModel.ID;

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





                    string address = chirot.SelectSingleNode("@address").Value;

                    string ips = chirot.SelectSingleNode("@ip").Value;

                    string msg = chirot.SelectSingleNode("@msg").Value;

                    string status = chirot.SelectSingleNode("@status").Value;

                    //标识是否需要审核
                    int number = 0;

                    //判断IP
                    string ip = "";
                    if (Context.Request.ServerVariables["HTTP_VIA"] != null) // 服务器， using proxy 
                    {
                        // 得到真实的客户端地址
                        ip = Context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();  // Return real client IP. 
                    }
                    else//如果没有使用代理服务器或者得不到客户端的ip  not using proxy or can't get the Client IP 
                    {
                        //得到服务端的地址 
                        ip = Context.Request.ServerVariables["REMOTE_ADDR"].ToString(); //While it can't get the Client IP, it will return proxy IP. 
                    }

                    //给它不可能的地址
                    if (ips == "")
                    {
                        ips = "000.000.000";
                    }
                    if (address == "")
                    {
                        address = "0";
                    }

                    if (NewMethod(ip, ips))
                    {
                        if (status != "true")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "questionAdd", JS.Alert(msg, "/"));
                            return;
                        }
                        else
                        {
                            number++;
                        }
                    }
                    //判断省份
                    string s_temp = Method.S_getIPaddress(ip);
                    if (NewMethod(s_temp, address))
                    {
                        if (status != "true")
                        {
                            ClientScript.RegisterStartupScript(GetType(), "questionAdd", JS.Alert(msg, "/"));
                            return;
                        }
                        else
                        {
                            number++;
                        }
                    }




                    if (pbzf != "" && pbzf.Trim() != "")
                    {
                        if (pbzf.Substring(pbzf.Length - 1) == ",")
                        {
                            pbzf = pbzf.Substring(0, pbzf.Length - 1);
                        }

                        pbzf = pbzf.Replace("|\r\n", "|");
                        pbzf = pbzf.Replace("\r\n", "|");

                        string[] upb = pbzf.Split('|');

                        if (upb.Length > 0)
                        {

                            for (int i = 0; i < upb.Length; i++)
                            {
                                if (txtTitle.Text.Contains(upb[i]))
                                {
                                    number++;
                                }
                            }

                            for (int i = 0; i < upb.Length; i++)
                            {
                                if (txtContent.Text.Contains(upb[i]))
                                {
                                    number++;
                                }
                            }
                        }
                    }

                    if (status != "true" && number > 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "questionAdd", JS.Alert(msg, "/"));
                        return;
                    }

                    if (number == 0)
                    {
                        model.Auditing = true;
                    }
                    else
                    {
                        model.Auditing = false;
                    }
                }
            }
            catch
            {
                model.Auditing = false;
            }

            model.AnswererId = null;
            model.BitIsHot = false;
            bool questingFlag = bllQuestion.Add(model) == 1 ? false : true;

            ///当前提问用户，问题数加一，悬赏付出加分，更新当前用户信息
            userModel.AskNum = userModel.AskNum + 1;
            userModel.Pointpenalty += int.Parse(this.ddlLargessPoint.SelectedValue) + tempNM;
            bllUser.Update(userModel);

            //Method.CheckUserGrade(Convert.ToString(userModel.Score-userModel.Pointpenalty -userModel.OtherPointpenalty), userModel.Title, userModel.ID.ToString());
            if (questingFlag)
            {
                ClientScript.RegisterStartupScript(GetType(), "questionAdd", JS.Alert("提问成功！\\r\\n点击查看我的提问", "/User.aspx?disp=3"));
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "questionAdd", JS.Alert("提问成功！", "/"));
            }

        }

        /// <summary>
        /// 循环判断
        /// </summary>
        /// <param name="s_temp"></param>
        /// <param name="sfs"></param>
        /// <returns></returns>
        private bool NewMethod(string s_temp, string sfs)
        {
            sfs = sfs.Replace("|\r\n", "|");
            sfs = sfs.Replace("\r\n", "|");

            sfs = sfs.Replace("*", "");

            if (sfs.Substring(sfs.Length - 1) == "|")
            {
                sfs = sfs.Substring(0, sfs.Length - 1);
            }


            string[] fsfs = sfs.Split('|');

            for (int j = 0; j < fsfs.Length; j++)
            {
                if (s_temp != "")
                {
                    if (s_temp.Contains(fsfs[j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        protected void libBigType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select Id ,TypeName,FTypeID from PBnet_ask_Type where FTypeID='" + this.libBigType.SelectedValue + "' and BitIsAuditing=1 order by OrderID ";
            DataSet ds = DbHelperSQL.Query(sql);
            this.libType.DataSource = ds;
            this.libType.DataTextField = "TypeName";
            this.libType.DataValueField = "Id";
            this.libType.DataBind();
        }
    }
}
