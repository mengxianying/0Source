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

namespace Pbzx.Web
{
    public partial class Synchronous : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LoginSort login = new LoginSort();
                this.txtBbsName.Text = Method.Get_UserName;
                this.txtBbsPWD.Text = Method.Get_UserPwd;
                this.txtLcsName.Text = Method.Get_UserName;
                this.txtLcsPWD.Text = Method.Get_UserPwd;
            }
        }

        protected void btnTB_Click(object sender, EventArgs e)
        {
            //后台基本验证
            string strErrMsg = "";
            if (this.txtBbsName.Text.Trim() == "" || this.txtBbsName.Text.Length>12)
            {
                strErrMsg += "论坛用户名不能为空或超过12个字符。\\r\\n";
            }
            else if (this.txtBbsPWD.Text.Trim() == "" || this.txtBbsPWD.Text.Length > 16)
            {
                strErrMsg += "论坛的密码不能为空或超过16个字符。\\r\\n";
            }
            else if (this.txtLcsName.Text.Trim() == "" || this.txtLcsName.Text.Length > 12)
            {
                strErrMsg += "聊彩室用户名不能为空或超过12个字符。\\r\\n";
            }
            else if (this.txtLcsPWD.Text.Trim() == "" || this.txtLcsPWD.Text.Length > 16)
            {
                strErrMsg += "聊彩室密码不能为空或超过16个字符。\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的聊彩室同步信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
               
                return;
            }
            else
            {
                #region 判断论坛用户名和密码是否正确
                //过滤文本框 防止注入攻击
                string  bbsName = Input.FilterAll(this.txtBbsName.Text);
                string bbsPWD = Input.FilterAll(this.txtBbsPWD.Text);
                DataSet ds = DbHelperSQLBBS.Query("select top 1 * from Dv_User where UserName='" + bbsName + "'");
                if (!(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("论坛用户名或密码不正确!无法同步！"));
                   
                    return;
                }
                DataRow rowData = ds.Tables[0].Rows[0];
                if (rowData["UserPassword"].ToString() != Input.MD5(bbsPWD))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("论坛用户名或密码不正确!无法同步！"));
                   
                    return;
                }
                #endregion

                #region 判断聊彩室 用户名和密码是否正确
                string chatName = Input.FilterAll(this.txtLcsName.Text);
                string chatPWD = Input.FilterAll(this.txtLcsPWD.Text);
                DataSet dsChat = DbHelperSQLMeChat.Query("select top 1 * from UserInfo2 where UserName='" + chatName + "'");
                if (!(dsChat.Tables.Count > 0 && dsChat.Tables[0].Rows.Count > 0))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("聊彩室用户名或密码不正确!无法同步！"));
                   
                    return;
                }
                DataRow rowDataChat = dsChat.Tables[0].Rows[0];
                string tempChatPWD = rowDataChat["Password"].ToString();
                if (tempChatPWD.Length == 16 && !Method.IsContainsNum(tempChatPWD))
                {
                    if (tempChatPWD != Input.MD5(chatPWD))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("聊彩室用户名或密码不正确!无法同步！"));
                       
                        return;
                    }
                }
                else
                {
                    if (tempChatPWD != chatPWD)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "login", JS.Alert("聊彩室用户名或密码不正确!无法同步！"));
                       
                        return;
                    }
                }
                #endregion


                ///将此用户原聊彩室记录记录插入新表
                int copy = DbHelperSQLMeChat.ExecuteSql("insert  into dbo.userInfo select * from userInfo2 where userInfo2.UserName='" + chatName + "'");
                ///将此用户聊彩室用户名更新为论坛用户名实现同步
                int update = DbHelperSQLMeChat.ExecuteSql("update userInfo set userName='" + bbsName + "'");                
                if (copy > 0 && update > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>$(document).ready(function(){ReturnDivValue('success');});</script> ");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>$(document).ready(function(){ReturnDivValue('fail');});</script> ");
                }
                //关闭此窗口并刷新父窗体            
            }            
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "login", "<script type='text/javascript'>$(document).ready(function(){ReturnDivValue('newUser');});</script> ");
        }


        
    }
}
