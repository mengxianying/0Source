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
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class Bacl_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         if (!IsPostBack)
            {
                Pbzx.Model.CN_Black MyBack;
                Pbzx.BLL.CN_Black backBLL = new Pbzx.BLL.CN_Black();

                string str = Request.QueryString["ID"];
                if (str != null && OperateText.IsNumber(str))
                {  
                    MyBack = backBLL.GetModel(Convert.ToInt32(str));
                    this.bt_ok.Text = "修改";
                   
                 
            
                    this.txtValue.Text = MyBack.BlackValue;
                    this.rdlFlag.SelectedValue =(MyBack.BlackFlag).ToString();
                    this.txtTime.Text = (MyBack.CreateTime).ToString();
                    this.txtDetails.Text = MyBack.Details;
                    this.rdlStatus.SelectedValue =(MyBack.Status).ToString();
                }
                else
                {
                    this.bt_ok.Text = "添加";
                    
                    MyBack = new Pbzx.Model.CN_Black();
                    this.txtTime.Text = (DateTime.Now.ToLongTimeString()).ToString();
                }
                this.hfFriendLinkID.Value = MyBack.ID.ToString();
            }
        }

        protected void bt_ok_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtValue.Text.Trim() == "")
            {
                strErrMsg += "黑名单内容不能为空.\\r\\n";
            }

            if (this.txtDetails.Text.Trim() == "")
            {
                strErrMsg += "详细信息不能为空.\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {

                Pbzx.Model.CN_Black  MyBack;
                Pbzx.BLL.CN_Black backBLL = new Pbzx.BLL.CN_Black();
                int intID = Convert.ToInt32(hfFriendLinkID.Value);
                if (intID > 0)
                {
                    MyBack = backBLL.GetModel(intID);
                }
                else
                {
                    MyBack = new Pbzx.Model.CN_Black();
                }
                MyBack.BlackValue = this.txtValue.Text.Trim();
                MyBack.BlackFlag = int.Parse(this.rdlFlag.SelectedValue);
                MyBack.CreateTime = DateTime.Now;
                MyBack.Details = this.txtDetails.Text.Trim();
                MyBack.Status = int.Parse(this.rdlStatus.SelectedValue);

                if (MyBack.ID > 0)
                {
                    if (backBLL.Update(MyBack))
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改信息[" + MyBack.ID + ":" + MyBack.BlackValue + "].");
                        Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");                        
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败');</script>");
                    }
                }
                else
                {
                    if (backBLL.Add(MyBack))
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("添加", "添加信息[" + MyBack.ID + ":" + MyBack.BlackValue + "].");                        
                        Response.Write("<script>alert('添加成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");                        
                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败');</script>");
                    }
                }
            }

       }
    }

}