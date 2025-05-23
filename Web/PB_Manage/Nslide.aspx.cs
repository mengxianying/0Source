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

namespace Pbzx.Web.PB_Manage
{
    public partial class Nslide : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["DefaultSelect"] = "Images/UploadFiles/focus";
                BindData();
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_Nslide SlideBll = new Pbzx.BLL.PBnet_Nslide();
            this.MyGridView.DataSource = SlideBll.GetAllList();
            this.MyGridView.DataBind();
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (this.txtLinkUrl.Text.Trim() == "")
            {
                strErrMsg += "����·������Ϊ��.\\r\\n";
            }

            if (txtThumb.Text.Trim() == "")
            {
                strErrMsg += "�õ�ƬͼƬ����Ϊ��.\\r\\n";
            }
            
            if(string.IsNullOrEmpty(this.txtTitle.Text))
            {
                strErrMsg += "�õ�Ƭ˵������Ϊ��.\\r\\n";
            }

            if (!OperateText.IsNumber(txtNOrder.Text.Trim()))
            {
                strErrMsg += "�����Ų�������.\\r\\n";
            }

           
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�Ĺ�����Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                int intID = Convert.ToInt32(hfID.Value);


                Pbzx.BLL.PBnet_Nslide slideBll = new Pbzx.BLL.PBnet_Nslide();
                Pbzx.Model.PBnet_Nslide slideModel;
                if (intID > 0)
                {
                    slideModel = slideBll.GetModel(intID);
                }
                else
                {

                    slideModel = new Pbzx.Model.PBnet_Nslide();
                }
                slideModel.LinkUrl = this.txtLinkUrl.Text;
                slideModel.PicUrl = txtThumb.Text;
                slideModel.NOrder = int.Parse(txtNOrder.Text);
                slideModel.height = 240;
                slideModel.IsEnable = this.chbIsEnable.Checked;
                slideModel.IsInitial = false;
                slideModel.width = 508;
                slideModel.Title = this.txtTitle.Text;

                if (intID > 0)
                {
                    if (slideBll.Update(slideModel))
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Nslide.aspx"));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸Ļõ�Ƭ[" + slideModel.ID + ":" + slideModel.LinkUrl + "].");

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("�޸Ļõ�Ƭʧ��."));
                    }
                }
                else
                {
                    if (slideBll.Add(slideModel))
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Nslide.aspx"));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("���", "��ӻõ�Ƭ[" + slideModel.ID + ":" + slideModel.LinkUrl + "].");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("��ӻõ�Ƭʧ��."));
                    }
                }

            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            hfID.Value = "0";
            divOperator.Visible = false;
            divList.Visible = true;
        }
        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowIndex >= 0)
            //{
            //    TableCell MyCell = e.Row.Cells[4];
            //    MyCell.Attributes.Add("onclick", "return confirm('��ȷ��Ҫɾ����?');");
            //}
        }
        protected void DelModule(string e)
        {

            int ModuleID = Convert.ToInt32(e);
            Pbzx.BLL.PBnet_Nslide ModuleBLL = new Pbzx.BLL.PBnet_Nslide();
            if (ModuleBLL.Delete(ModuleID))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ���õ�Ƭ[" + ModuleID + "].");
                //  ClientScript.RegisterClientScriptBlock(this.GetType(), "delok", JS.Alert("�ɹ�ɾ���������."));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redirect", JS.Replace("Nslide.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "nodel", JS.Alert("ɾ���õ�Ƭʧ��."));
            }
        }
        protected void ShowEditor(string e)
        {

            int intId = Convert.ToInt32(e);
            this.hfID.Value = e;
            Pbzx.BLL.PBnet_Nslide slideBll = new Pbzx.BLL.PBnet_Nslide();
            Pbzx.Model.PBnet_Nslide slideModel = slideBll.GetModel(intId);

            this.txtLinkUrl.Text = slideModel.LinkUrl;
            this.txtThumb.Text = slideModel.PicUrl;
            this.txtTitle.Text = slideModel.Title;
            this.txtNOrder.Text = slideModel.NOrder.ToString();

            divOperator.Visible = true;
            divList.Visible = false;
        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
           
            DelModule(e.CommandArgument.ToString());
        }
        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {            
            this.ShowEditor(e.CommandArgument.ToString());
        }
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "(" + id.ToString() + ")";
            }
        }
        protected void btn_gl_Click(object sender, EventArgs e)
        {
            divOperator.Visible = false;
            divList.Visible = true;
            Response.Redirect("Nslide.aspx");
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {            
            divOperator.Visible = true;
            divList.Visible = false;
        }

        protected void lbtnShow_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_Nslide.ChangeAudit(id, "IsEnable");
            BindData();
        }
    }
}
