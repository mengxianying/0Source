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
using Pbzx.Common;

namespace Pbzx.Web.UserCenter.Contorls
{
    public partial class UcMsgCount : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //Dim Sms_max
                //Sms_max=Cint(Dvbbs.GroupSetting(35))'用户组短信限制，条数
                //If Sms_max = 0 Then Sms_Max = 9999
                try
                {
                    string GroupSetting = DbHelperSQLBBS.GetSingle("select top 1 GroupSetting from Dv_UserGroups where usertitle in(select top 1 UserClass from dv_user where username='" + Method.Get_UserName + "')").ToString();
                    string[] GroupSettingSZ = GroupSetting.Split(new char[] { ',' });
                    int Sms_max = 0;
                    Sms_max = Convert.ToInt32(GroupSettingSZ[35]);
                    if (Sms_max == 0)
                    {
                        Sms_max = 9999;
                    }
                    string useCount = DbHelperSQLBBS.GetSingle("select count(*) from Dv_Message where incept='" + Method.Get_UserName + "' ").ToString();
                    this.lblTotalCount.Text = Sms_max.ToString();
                    this.lblUseCount.Text = useCount.ToString();
                    int intUseCount = int.Parse(useCount);
                    if (intUseCount > Sms_max)
                    {
                        int delI = intUseCount - Sms_max;
                        DbHelperSQLBBS.ExecuteSql("Delete From DV_Message Where id in(Select top " + delI + " id From DV_Message Where incept='" + Method.Get_UserName + "' Order by id,delR Desc)");
                    }
                }
                catch(Exception ex)
                {
                    Response.Write("<script>alert('此用户信息异常，请与管理员联系');top.location='Default.htm';</script>");
                }
            }
        }
    }
}