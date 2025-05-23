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

namespace Pbzx.Web.PB_Manage
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // Session["ValidateCode"] = "";
               //Response.Redirect("AdminLogin.aspx");
            }
        }
       Pbzx.BLL.PBnet_tpman bllTpman = new Pbzx.BLL.PBnet_tpman();

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string UID = this.txtUname.Text.Trim();
            string PWD = this.txtUpwd.Text.Trim();
              string vCode = this.txtCode.Text.Trim();
            if (UID == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "uiderr", JS.Alert("用户名不能为空!"));
                return;
            }
            if (PWD == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "pwderr", JS.Alert("用户密码不能为空!"));
                return;
            }
            if (vCode == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("验证码不能为空!"));
                return;
            }
            Pbzx.BLL.PBnet_tpman AdminBLL = new Pbzx.BLL.PBnet_tpman();

            if (Session["ValidateCode"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "vcodelost", JS.Alert("验证码已经失效!"));
                return;
            }

            if (vCode.ToUpper() != Session["ValidateCode"].ToString().ToUpper())
            {
                AdminBLL.WriteWebLog(UID, Session["ValidateCode"].ToString(), vCode);
                ClientScript.RegisterStartupScript(this.GetType(), "vcodeerr", JS.Alert("验证码输入错误!"));
                return;
            }
            if (InitLoginIP())
            {
                 // 判断用户是否允许登录
                if (!adminLogion(UID))
                {
                    if (AdminBLL.ValidateLogin(UID, PWD))
                    {
                        Pbzx.Model.PBnet_tpman MyAdmin = AdminBLL.GetEntityByUserName(UID);
                        Pbzx.BLL.PBnet_Group GroupBLL = new Pbzx.BLL.PBnet_Group();

                        //object objAuthority = GroupBLL.GetAuthorityByName(MyAdmin.UserGroup);
                        //if (objAuthority != null)
                        //{
                        //AdminBasic.UserAuthority = AdminBasic.DeCodeModule(objAuthority);
                        Session["htUserPower"] = AdminBasic.GetUserPowers(MyAdmin.Setting);
                        AdminBLL.UpdateInfo(MyAdmin);
                        if (HttpContext.Current.Request.Cookies["AdminManager"] == null)
                        {
                            HttpCookie cookie = new HttpCookie("AdminManager");
                            cookie.Value = Input.Encrypt(MyAdmin.Master_Name);
                            //cookie.Domain = ".pinble2.com";
                            //cookie.Path = "/";
                            HttpContext.Current.Response.AppendCookie(cookie);
                        }
                        Response.Redirect("Default.aspx", true);
                        //}
                        //else
                        //{
                        //    ClientScript.RegisterStartupScript(this.GetType(), "grouperr", JS.Alert("该用户不属于任何用户组!"));
                        //    return;
                        //}
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "loginerr", JS.Alert("登录失败！\\r\\n用户名或密码错误或者已经被禁用"));
                        return;
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "loginerr", JS.Alert("登录失败！\\r\\n用户不允许登录"));
                    return;
                }
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "loginerr", JS.Alert("登录失败！\\r\\n用户不允许登录"));
                return;
            }
            


            //if (Request.Cookies["CheckCode"] == null)
            //{
            //    Label1.Text = "";
            //    Label1.Visible = true;
            //    return;
            //}

            //if (String.Compare(Request.Cookies["CheckCode"].Value, txtCode.Text.ToString().Trim(), true) != 0)
            //{
            //    Label1.Text = "<font color=red>对不起，验证码错误！</font>";
            //    Label1.Visible = true;
            //    return;
            //}
            //else
            //{
            //    if (!bllTpman.CheckUser(this.txtUname.Text, this.txtUpwd.Text))
            //    {
            //        Label1.Text = "<font color=red>对不起，您的用户名或密码错误！</font>";
            //        Label1.Visible = true;
            //        return;
            //    }
            //    else
            //    {
            //        Response.Redirect("", true);
            //    }
            //}
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            this.txtUname.Text = "";
            this.txtCode.Text = "";
        }
        private bool InitLoginIP()
        {
            XmlDocument doc = new XmlDocument();
            //判断是添加什么类型限定
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/configurePassword.xml"));

            //得到根节点
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {

                XmlNode haha = root.SelectNodes("adminloginIP")[0];

                string ips = haha.SelectSingleNode("@ip").Value;

                string address = haha.SelectSingleNode("@address").Value;

                ////给它不可能的地址
                //if (ips == "")
                //{
                //    ips = "000.000.000";
                //}
                //if (address == "")
                //{
                //    address = "0";
                //}

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
                if (ips != "")
                {
                    if (NewMethod(ips, ip))
                    {
                        //Method.record_user_log(username, "", "已屏蔽该IP位置登录", "登录相关");
                        //Response.Redirect("/PB_Manage/AdminLogin.aspx");
                        
                        return false;
                    }
                    
                }
                if (address != "")
                {
                    //判断省份
                    string s_temp = Method.S_getIPaddress(ip);
                    if (NewMethod(s_temp, address))
                    {
                        //Method.record_user_log(username, "", "已屏蔽该地址位置登录", "登录相关");
                        //Response.Redirect("/PB_Manage/AdminLogin.aspx");

                        return false;
                    }
                }
                
            }
            return true;
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
        /// <summary>
        /// 用户是否允许登录 （ip限制）
        /// </summary>
        /// <param name="userName">管理员名</param>
        /// <returns></returns>
        private bool adminLogion(string userName)
        {
            Pbzx.BLL.PBnet_tpman get_tpman = new Pbzx.BLL.PBnet_tpman();
            DataSet ds = get_tpman.GetList("Master_Name="+"'"+ userName +"'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string ips = ds.Tables[0].Rows[0]["ipLimit"].ToString().Trim();

                string address = ds.Tables[0].Rows[0]["regionLimit"].ToString().Trim();
                if (ips == "" && address == "")
                {
                    return false;
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
                if (ips != "")
                {
                    if (accord(ips, ip))
                    {
                        return false;
                    }

                }
                if (address != "")
                {
                    //判断省份
                    string s_temp = Method.S_getIPaddress(ip);
                    if (accord(s_temp, address))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 循环判断
        /// </summary>
        /// <param name="s_temp"></param>
        /// <param name="sfs"></param>
        /// <returns></returns>
        private bool accord(string s_temp, string sfs)
        {
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

    }
}
