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

namespace Pbzx.Web.PB_Manage
{
    public partial class LockUserIP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(!string.IsNullOrEmpty(Request["UserIP"]))
                {
                    this.txtIP.Text = Request["UserIP"];
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string userIP = this.txtIP.Text.Trim();
            string tempLockIP = DbHelperSQLBBS.GetSingle("select top 1 Forum_LockIP from Dv_Setup").ToString();
            string[] lockIpSZ = tempLockIP.Split(new char[] { '|' });
            bool isFind = false;
            for (int i = 0; i < lockIpSZ.Length; i++)
            {
                if (!string.IsNullOrEmpty(lockIpSZ[i]))
                {
                    if (lockIpSZ[i].Substring(lockIpSZ[i].Length - 1, 1) == "*")
                    {
                        if (userIP.Substring(0, userIP.LastIndexOf(".")) == lockIpSZ[i].Substring(0, lockIpSZ[i].LastIndexOf(".")))
                        {
                            isFind = true;
                            break;
                        }
                    }
                    else
                    {
                        if (userIP == lockIpSZ[i])
                        {                            
                            isFind = true;
                            break;
                        }
                    }
                }
            }
            if (isFind)
            {
                Response.Write("<script language='javascript'>alert('该IP地址段已经被锁定！');window.returnValue ='yes';window.close()</script>");
            }
            else
            {
                tempLockIP += "|"+userIP;
                DbHelperSQLBBS.ExecuteSql(" update Dv_Setup set Forum_LockIP='" + tempLockIP + "' ");
                Response.Write("<script language='javascript'>alert('锁定成功！');window.returnValue ='yes';window.close()</script>");
            }
        }

        protected void btnJie_Click(object sender, EventArgs e)
        {
            string userIP = this.txtIP.Text.Trim();
            string tempLockIP = DbHelperSQLBBS.GetSingle("select top 1 Forum_LockIP from Dv_Setup").ToString();
            string[] lockIpSZ = tempLockIP.Split(new char[] { '|' });
            bool isFind = false;
            StringBuilder sb =  new StringBuilder("");
            if (userIP.Substring(userIP.Length - 1, 1) == "*")
            {
                for (int i = 0; i < lockIpSZ.Length; i++)
                {
                    if (!string.IsNullOrEmpty(lockIpSZ[i]))
                    {
                        if (lockIpSZ[i].Substring(0, lockIpSZ[i].Length - 1) == userIP.Substring(0, userIP.Length - 1))
                        {
                            isFind = true;
                        }
                        else
                        {
                            sb.Append(lockIpSZ[i] + "|");
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < lockIpSZ.Length; i++)
                {
                    if (!string.IsNullOrEmpty(lockIpSZ[i]))
                    {
                        if (userIP == lockIpSZ[i])
                        {
                            isFind = true;
                        }
                        else
                        {
                            sb.Append(lockIpSZ[i] + "|");
                        }
                    }
                }              
            }

            if(sb.Length > 1 && sb.ToString().Substring(sb.Length-1,1) == "|")
            {
                sb.Remove(sb.Length - 1, 1);
            }
            if (isFind)
            {
                DbHelperSQLBBS.ExecuteSql(" update Dv_Setup set Forum_LockIP='" + sb.ToString() + "' ");
                Response.Write("<script language='javascript'>alert('解锁成功！');window.returnValue ='yes';window.close()</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('没有找到匹配的IP段！');window.returnValue ='yes';window.close()</script>");
            }
        }
    }
}
