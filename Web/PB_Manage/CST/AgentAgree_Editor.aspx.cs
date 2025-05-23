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
using System.IO;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class AgentAgree_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string strStr = Request["ID"];
                if (!String.IsNullOrEmpty(strStr))
                {
                    Pbzx.BLL.AgentAgree AgreeBll = new Pbzx.BLL.AgentAgree();
                    Pbzx.Model.AgentAgree AgreeModel = AgreeBll.GetModel(int.Parse(strStr.ToString()));

                    this.txtTitle.Text = AgreeModel.Title;
                    this.rblState.SelectedValue = AgreeModel.State.ToString();
                    this.txtContent.Value = AgreeModel.Content;
                    txtPurpose.Text = AgreeModel.Purpose;
                    //this.txtAddUrl.Text = AgreeModel.AgreeUrl;
                    //this.Label1.Text = AgreeModel.AgreeUrl;
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
           Pbzx.BLL.AgentAgree AgreeBll = new Pbzx.BLL.AgentAgree();
           Pbzx.Model.AgentAgree AgreeModel;
           int intID = Convert.ToInt32(Request["ID"]);

           if (intID > 0)
           {
               AgreeModel = AgreeBll.GetModel(intID);
           }
           else
           {
               AgreeModel = new Pbzx.Model.AgentAgree();
           }
       
           AgreeModel.Title = txtTitle.Text;
           AgreeModel.State =int.Parse(this.rblState.SelectedValue);
           AgreeModel.Content=txtContent.Value.Trim();
           //AgreeModel.AgreeUrl = this.txtAddUrl.Text;
           AgreeModel.AddTime = DateTime.Now;
           AgreeModel.Purpose = txtPurpose.Text;
           
           if (intID > 0)
           {             
               if (AgreeBll.Update(AgreeModel))
               {

                   ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("AgentAgree.aspx"));
                   Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改代理协议[" + AgreeModel.ID + ":" + AgreeModel.Title + "].");
              
               }
               else
               {
                   ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("代理协议修改失败."));
               }
           }
           else
           {               
               if (AgreeBll.Add(AgreeModel))
               {
                   ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("AgentAgree.aspx"));
                   Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "新增代理协议[" + AgreeModel.ID + ":" + AgreeModel.Title + "].");           
               
               }
               else
               {
                   ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("代理协议添加失败."));
               }
           
           }
           }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string fullname = FileUpload1.FileName.ToString();
        //    string no = Request.Params["id"];
        //    if ((no == "") || (no == null))
        //    {
        //        no = "1";
        //    }                   
        //    string size = FileUpload1.PostedFile.ContentLength.ToString();
        //    string typ2 = Path.GetExtension(fullname).ToLower();//获取文件后缀名
        //    string fn = fullname;

        //    if (typ2 == ".gif" || typ2 == ".jpg" || typ2 == ".rar" || typ2 == ".png" || typ2 == ".exe" || typ2 ==".doc")
        //    {
        //        FileUpload1.SaveAs(Server.MapPath("~/Images/AgentAnnex") + "\\" + fn); //将文件保存在Images/AgentAnnex下
        //        Label1.Text = (fn);
        //        //Image1.ImageUrl = (Server.MapPath("up") + "\\" + fn);
        //        if (no == "1")
        //        {
        //            Response.Write("<script>parent.NewImage('~/Images/AgentAnnex/" + fn + "')</script>");
        //        }
        //        else
        //        {
        //            Response.Write("<script>parent.NewImage2('~/Images/AgentAnnex/" + fn + "')</script>");
        //        }
        //    }
        //    else
        //    {
        //        Label1.Text = "文件类型不支持";
        //    }
        //}

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("AgentAgree.aspx"));
        }
    }
}
