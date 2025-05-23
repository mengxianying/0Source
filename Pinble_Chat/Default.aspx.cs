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
using System.Net;
using System.IO;
using Maticsoft.DBUtility;
using Pbzx.Common;
using System.Xml;

namespace Pinble_Chat
{
    public partial class _Default : System.Web.UI.Page
    {
        private string _inUrl = "";
        /// <summary>
        /// 跳转目的Url
        /// </summary>
        public string InUrl
        {
            get { return _inUrl; }
            set { _inUrl = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() != "0")
            {
                Page.RegisterStartupScript("cue", "<script>cue('" + Method.Get_UserName.ToString() + "')</script>");
            }
            if (!IsPostBack)
            {
                
                LoginSort login = new LoginSort();
                ///判断用户是否登陆状态
                if (!login["manager_user"])
                {
                    this.hasLogin.Visible = false;
                    this.Login.Visible = true;
                }
                else
                {
                    this.Login.Visible = false;
                    this.lblUName.Text = Method.Get_UserName;
                    object objMsgCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where flag=0 and issend = 1 and delR = 0 and incept = '" + Method.Get_UserName + "' ");
                    if (Convert.ToInt32(objMsgCount) > 0)
                    {
                        this.lblMessage.Text = "<a href='" + WebInit.webBaseConfig.WebUrl + "UserCenter/User_Center.aspx?myUrl=/UsersMs.aspx' title='阅读短消息' target='_blank'>收信箱 (<font color='red'>" + objMsgCount.ToString() + "</font>)</a>";
                    }
                    else
                    {
                        this.lblMessage.Text = "<a href='" + WebInit.webBaseConfig.WebUrl + "UserCenter/User_Center.aspx?myUrl=/UsersMs.aspx' title='阅读短消息' target='_blank'>收信箱 (0)</a>";
                    }
                    this.hasLogin.Visible = true;

                }
                BindChat();
                CheckIsLogin();
            }

        }
        private void CheckIsLogin()
        {
            LoginSort login = new LoginSort();
            if (login["manager_user"])
            {
                string bbsName = Method.Get_UserName;
                //string chatName = "";
                ///判断用户是否是新聊彩室第一次登录，如果用户是第一次登录则提示同步（对所有用户）
                if (!DbHelperSQLMeChat.Exists("select  count(*) from UserInfo where UserName='" + Method.Get_UserName + "'"))
                {
                    ClientScript.RegisterStartupScript(GetType(), "winOpen", "<script type='text/javascript'> $(document).ready(function(){show('Synchronous',document.getElementById('address'),'聊彩室同步',500,400)});</script>");//document.getElementById('Synchronous'),{width:'650px',height:'487px'} 
                    return;
                    //{alert('您是聊彩室新用户！\\r\\n您的用户名为:" + Session["manager_user"].ToString() + "\\r\\n您的密码为:" + Session["RealPWD"].ToString() + "\\r\\n请牢记!');window.location.reload();}        $.blockUI({message: $('#Synchronous'), css: {width:'480px',height:'360px'} });
                    //
                }

            }
        }
        private void BindChat()
        {
            string chatName = this.lblUName.Text;
            DataSet ds = DbHelperSQLMeChat.Query("select top 1 Alias,Grade,Age,LogoutTime from UserInfo where UserName='" + chatName + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //this.lblAlias.Text = ds.Tables[0].Rows[0]["Alias"].ToString();
                if (ds.Tables[0].Rows[0]["Grade"] != null)
                {
                    this.lblGrade.Text = ds.Tables[0].Rows[0]["Grade"].ToString();
                    this.lblAge.Text = GetGrade(ds.Tables[0].Rows[0]["Grade"].ToString());
                }
            }
            DataSet dsBBS = DbHelperSQLBBS.Query("select top 1 LastLogin from Dv_User where UserName='" + chatName + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (dsBBS.Tables.Count > 0 && dsBBS.Tables[0].Rows.Count > 0)
                {
                    this.lblLogoutTime.Text = dsBBS.Tables[0].Rows[0]["LastLogin"].ToString();
                }

            }

        }
        public static string GetGrade(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 0:
                    type = "无业游民";
                    break;
                case 1:
                    type = "新兵";
                    break;
                case 2:
                    type = "专业军士";
                    break;
                case 3:
                    type = "少尉";
                    break;
                case 4:
                    type = "中尉";
                    break;
                case 5:
                    type = "上尉";
                    break;
                case 6:
                    type = "少校";
                    break;
                case 7:
                    type = "中校";
                    break;
                case 8:
                    type = "上校";
                    break;
                case 9:
                    type = "大校";
                    break;
                case 10:
                    type = "少将";
                    break;
                case 11:
                    type = "中将";
                    break;
                case 12:
                    type = "上将";
                    break;
                case 13:
                    type = "五星上将";
                    break;
                default:
                    type = "未知";
                    break;
            }
            return type;
        }

        private void InitLoginIP(string username)
        {
            string tempLJ = HttpRuntime.AppDomainAppPath.Substring(0, HttpRuntime.AppDomainAppPath.Length - 1);
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml");
            doc.Load(path);
            XmlNode node1 = doc.SelectSingleNode("/root/Ask/BarLJ");
            XmlElement xe1 = (XmlElement)node1;
            string barWJJ = xe1.Attributes["value"].Value;

            string currentASK = tempLJ.Substring(0, tempLJ.LastIndexOf("\\")) + "\\" + barWJJ;

            XmlDocument XmlDoc;
            XmlNodeList NodeList;
            XmlDoc = new XmlDocument();
            XmlDoc.Load(currentASK + "\\Xml\\AskConfig.xml");

            //得到根节点
            XmlElement root = XmlDoc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("userlogin")[0];

                string ips = haha.SelectSingleNode("@ip").Value;

                string address = haha.SelectSingleNode("@address").Value;

                //给它不可能的地址
                if (ips == "")
                {
                    ips = "000.000.000";
                }
                if (address == "")
                {
                    address = "0";
                }
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
                if (NewMethod(ips, ip))
                {
                    Method.record_user_log(username, "", "已屏蔽该IP位置登录", "登录相关");
                    Response.Redirect("http://www.pinble.com");
                }
                //判断省份
                string s_temp = Method.S_getIPaddress(ip);
                if (NewMethod(s_temp, address))
                {
                    Method.record_user_log(username, "", "已屏蔽该地址位置登录", "登录相关");
                    Response.Redirect("http://www.pinble.com");
                }
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



        protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            #region 处理基本信息登录
            string UID = this.txtName.Text.Trim();
            string PWD = this.txtPWD.Text.Trim();
            string vCode = this.txtCode.Text.Trim();

            InitLoginIP(UID);

            if (UID == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "uiderr", JS.Alert("用户名不能为空!"));
                return;
            }
            if (PWD == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "pwderr", JS.Alert("用户密码不能为空!"));
                return;
            }
            if (vCode == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("验证码不能为空!"));
                return;
            }
            if (Session["ValidateCode"] == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("验证码已经失效!"));
                return;
            }

            if (vCode.ToUpper() != Session["ValidateCode"].ToString())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("验证码输入错误!"));
                return;
            }
            Pbzx.BLL.PinbleLogin login = new Pbzx.BLL.PinbleLogin();
            string cbState = this.chbState.Checked ? "3" : "0";
            string loginResult = login.CheckLoginChat(UID, PWD, cbState);
            if (string.IsNullOrEmpty(loginResult))
            {

                if (Request["ReturnUrl"] != null)
                {
                    Response.Write("<script>window.top.location.href='" + Server.UrlDecode(Request["ReturnUrl"]) + "';</script>");
                    Response.End();
                }
                //处理跳转
                if (string.IsNullOrEmpty(InUrl))
                {
                    Response.Redirect(Request.Url.PathAndQuery);
                }
                else
                {
                    Response.Write("<script>window.top.location.href='" + this.InUrl + "';</script>");
                    Response.End();
                }
               
            }
            else
            {

                Page.ClientScript.RegisterStartupScript(this.GetType(), "loginResult", JS.Alert("" + loginResult + ""));
                return;
            }
            #endregion
            
        }
        protected void ibtnLoginOut_Click(object sender, ImageClickEventArgs e)
        {
            Pbzx.BLL.PinbleLogin.UserOut();
            Response.Redirect(Request.Url.PathAndQuery);
        }

        //protected void btnTB_Click(object sender, EventArgs e)
        //{
        //    //后台基本验证
        //    string strErrMsg = "";
        //    if (this.txtBbsName.Text.Trim() == "")
        //    {
        //        strErrMsg += "论坛用户名不能为空.\\r\\n";
        //    }
        //    if (this.txtBbsPWD.Text.Trim() == "")
        //    {
        //        strErrMsg += "论坛的密码不能为空.\\r\\n";
        //    }
        //    if (this.txtLcsName.Text.Trim() == "")
        //    {
        //        strErrMsg += "聊彩室用户名不能为空.\\r\\n";
        //    }
        //    if (this.txtLcsPWD.Text.Trim() == "")
        //    {
        //        strErrMsg += "聊彩室密码不能为空.\\r\\n";
        //    }
        //    if (strErrMsg != "")
        //    {
        //        strErrMsg = "您提交的聊彩室同步信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
        //        ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));                
        //        return;
        //    }
        //    else
        //    {
        //        #region 判断论坛用户名和密码是否正确
        //        //过滤文本框 防止注入攻击
        //        string bbsName = Input.FilterAll(this.txtBbsName.Text);
        //        string bbsPWD = Input.FilterAll(this.txtBbsPWD.Text);
        //        DataSet ds = DbHelperSQLBBS.Query("select top 1 * from Dv_User where UserName='" + bbsName + "'");
        //        if (!(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0))
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("论坛用户名或密码不正确!无法同步！"));                    
        //            return;
        //        }
        //        DataRow rowData = ds.Tables[0].Rows[0];
        //        if (rowData["UserPassword"].ToString() != Input.MD5(bbsPWD))
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("论坛用户名或密码不正确!无法同步！"));                    
        //            return;
        //        }
        //        #endregion

        //        #region 判断聊彩室 用户名和密码是否正确
        //        string chatName = Input.FilterAll(this.txtLcsName.Text);
        //        string chatPWD = Input.FilterAll(this.txtLcsPWD.Text);
        //        DataSet dsChat = DbHelperSQLMeChat.Query("select top 1 * from UserInfo where UserName='" + chatName + "'");
        //        if (!(dsChat.Tables.Count > 0 && dsChat.Tables[0].Rows.Count > 0))
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("聊彩室用户名或密码不正确!无法同步！"));
        //            return;
        //        }
        //        DataRow rowDataChat = dsChat.Tables[0].Rows[0];
        //        string tempChatPWD = rowDataChat["Password"].ToString();
        //        if (tempChatPWD.Length == 16 && !Method.IsContainsNum(tempChatPWD))
        //        {
        //            if (tempChatPWD != Input.MD5(chatPWD))
        //            {
        //                Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("聊彩室用户名或密码不正确!无法同步！"));                        
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            if (tempChatPWD != chatPWD)
        //            {
        //                Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("聊彩室用户名或密码不正确!无法同步！"));                        
        //                return;
        //            }
        //        }
        //        #endregion


        //        ///将此用户原聊彩室记录记录插入新表
        //        int copy = DbHelperSQLMeChat.ExecuteSql("select * into userInfo from userInfo2 where userInfo2.userName='" + chatName + "'");
        //        ///将此用户聊彩室用户名更新为论坛用户名实现同步
        //        int update = DbHelperSQLMeChat.ExecuteSql("update userInfo2 set userName='" + bbsName + "'");
        //        if (copy > 0 && update > 0)
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>alert('同步成功！\\r\\n您的用户名为： " + bbsName + "\\r\\n您的密码为： " + bbsPWD + "\\r\\n请您牢记！');$.unblockUI();</script> ");
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>alert('同步失败！\\r\\n请与网站管理员联系！');$.unblockUI();</script> ");
        //        }
        //        //关闭此窗口并刷新父窗体            
        //    }            
        //}

        //protected void btnNew_Click(object sender, EventArgs e)
        //{
        //    string bbsName = Input.FilterAll(this.txtBbsName.Text);
        //    string bbsPWD = Input.FilterAll(this.txtBbsPWD.Text);
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>alert('您是聊彩室新用户！\\r\\n您的用户名为： " + bbsName + "\\r\\n您的密码为： " + bbsPWD + "\\r\\n请您牢记！');$.unblockUI();</script> ");
        //}
    }
}
