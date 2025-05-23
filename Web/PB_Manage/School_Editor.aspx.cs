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
    public partial class School_Editor : AdminBasic
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string basePath = "/Images/UploadFiles/School/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString();
                if (!DirectoryFile.IsCreateDirectory(Server.MapPath(basePath)))
                {
                    DirectoryFile.CreateDirectory(Server.MapPath(basePath));
                }
                Session["FCKeditor:UserFilesPath"] = basePath;
                Session["DefaultSelect"] = basePath;


                //Pbzx.Common.Method.BindNewsDisPosition(ref this.ddlIntDisPosition);
                // FileUploadThumb.Attributes.Add("onchange", "Upload_OnChange(this,'txtThumb','ThumbImageState');");
                Pbzx.Model.PBnet_School MyNews;
                Pbzx.BLL.PBnet_School ArticleBLL = new Pbzx.BLL.PBnet_School();
                Pbzx.BLL.PBnet_SchoolType newsTypeBLL = new Pbzx.BLL.PBnet_SchoolType();
                Pbzx.BLL.PBnet_Channel channelBLL = new Pbzx.BLL.PBnet_Channel();
                string str = Request.QueryString["ID"];
                channelBLL.BindChannelType(this.ddlChannel, 0);
                ddlChannel.Items.Insert(0, "==��ѡ��==");
                ddlChannel.Items[0].Value = "-1";    
                if (str != null && OperateText.IsNumber(str))
                {                   
                    lblAction.Text = "�޸�";
                    btnCancel.Visible = true;
                    btnCancel.Attributes.Add("onclick", "history.back();return false;");
                    MyNews = ArticleBLL.GetModel(Convert.ToInt32(str));
                    this.chbShowIndex.Checked = MyNews.ShowIndex;
                    //this.chbShowInSoft.Checked = MyNews.ShowInSoft;
                    newsTypeBLL.BindNewsType(this.ddlClass, 0);
                    ddlClass.Items.Insert(0, "==��ѡ��==");
                    ddlClass.Items[0].Value = "-1";
                    ddlClass.SelectedValue = MyNews.IntShowType.ToString();
                    ddlChannel.SelectedValue = MyNews.IntChannelID.ToString();
                    txtCreateTime.Text = MyNews.DatDateAndTime.ToString();
                }
                else
                {
                    //this.IsAuthority(1);
                    lblAction.Text = "����";
                    btnCancel.Visible = false;
                    MyNews = new Pbzx.Model.PBnet_School();
                    MyNews.BitIsPass = true;
                    MyNews.NvarAuthor = WebFunc.GetCurrentAdmin();
                    MyNews.Source = "ƴ�����߲���ͨ���";
                    MyNews.SourceUrl = WebInit.webBaseConfig.WebUrl;
                    MyNews.EffectDate = DateTime.Now.AddMonths(3);
                    ddlChannel.SelectedValue = "9";
                    newsTypeBLL.BindNewsType(this.ddlClass, 0);

                    ddlClass.Items.Insert(0, "==��ѡ��==");
                    ddlClass.Items[0].Value = "-1";
                    txtCreateTime.Text = DateTime.Now.ToString();
                    MyNews.NKey = "";

                }
                hfNewsID.Value = MyNews.IntID.ToString();
                //ddlIntDisPosition.SelectedValue = MyNews.IntDisPosition.ToString();
                txtTitle.Text = MyNews.NvarTitle;
                txtShortTitle.Text = MyNews.NvarShortTitle;

                txtKey.Text = MyNews.NKey;
                txtMetadesc.Text = MyNews.Metadesc;
                this.txtSource.Text = MyNews.Source;
                this.txtSourceUrl.Text = MyNews.SourceUrl;
                //this.txtEffectDate.Text = ((DateTime)MyNews.EffectDate).ToShortDateString();

                txtAuthor.Text = MyNews.NvarAuthor;


                chkIsTop.Checked = MyNews.BitIsTop;

                //  chkIsHot.Checked = MyNews.BitIsTop;
                chkIsRecommand.Checked = MyNews.BitIsPass;
                //txtThumb.Text = MyNews.VarPicUrl;
                txtContent.Value = MyNews.NteContent;
                if (string.IsNullOrEmpty(MyNews.IntClick.ToString()))
                {
                    txtHits.Text = "0";
                }
                else
                {
                    txtHits.Text = MyNews.IntClick.ToString();
                }

                txtVarPicUrl.Text = MyNews.VarPicUrl;
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (txtTitle.Text.Trim() == "")
            {
                strErrMsg += "ѧԺ��Ѷ����Ϊ��.\\r\\n";
            }
            if (ddlChannel.SelectedValue == "-1")
            {
                strErrMsg += "��ѡ������Ƶ��.\\r\\n";
            }
            if (ddlClass.SelectedValue == "-1")
            {
                strErrMsg += "��ѡ�����ѧԺ��Ѷ���.\\r\\n";
            }

            if (txtContent.Value.Trim() == "")
            {
                strErrMsg += "ѧԺ��Ѷ����Ϊ��.\\r\\n";
            }
            if (!OperateText.IsNumber(txtHits.Text.Trim()))
            {
                strErrMsg += "�������δ��������ݸ�ʽ����ȷ.\\r\\n";
            }
            // string ext = "";
            //if (FileUploadThumb.FileName != "" && FileUploadThumb.FileBytes.Length > 100)
            //{
            //    ext = System.IO.Path.GetExtension(FileUploadThumb.FileName).ToLower();
            //    if (ext != ".gif" && ext != ".jpg" && ext != ".jpeg")
            //    {
            //        strErrMsg += "ͼƬ��ʽ���ԣ�ֻ�����ϴ�[.gif/.jpg/.jpeg]��ʽ���ļ�.\\r\\n";
            //    }
            //    else if (FileUploadThumb.FileBytes.Length / 1024 > 1024*2)
            //    {
            //        strErrMsg += "ͼƬ��С�������ƣ���������ϴ�2M(2*1024KB)�ļ�\\r\\n";
            //    }
            //}
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�����ѧԺ��Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                int NewsID = Convert.ToInt32(hfNewsID.Value);
                Pbzx.BLL.PBnet_School ArticleBLL = new Pbzx.BLL.PBnet_School();
                Pbzx.Model.PBnet_School MyNews;
                if (NewsID > 0)
                {
                    MyNews = ArticleBLL.GetModel(NewsID);
                }
                else
                {
                    MyNews = new Pbzx.Model.PBnet_School();
                }
                MyNews.NvarTitle = txtTitle.Text.Trim();
                MyNews.NvarShortTitle = txtShortTitle.Text.Trim();
                MyNews.NKey = txtKey.Text;
                MyNews.Metadesc = txtMetadesc.Text;
                if (txtMetadesc.Text.Trim() == "")
                {
                    MyNews.Metadesc = this.txtTitle.Text;
                }

                MyNews.Source = this.txtSource.Text;
                MyNews.SourceUrl = this.txtSourceUrl.Text;
                //MyNews.EffectDate = DateTime.Parse(this.txtEffectDate.Text);

                MyNews.NvarAuthor = txtAuthor.Text.Trim();
                MyNews.IntShowType = Convert.ToInt32(ddlClass.SelectedValue);
                MyNews.IntChannelID = Convert.ToInt32(this.ddlChannel.SelectedValue);

                MyNews.BitIsPass = chkIsRecommand.Checked;
                //MyNews.BitIsHot = chkIsHot.Checked;
                MyNews.BitIsTop = chkIsTop.Checked;
                //MyNews.IntDisPosition = int.Parse(this.ddlIntDisPosition.SelectedValue);
                //MyNews.IsRecommand = chkIsRecommand.Checked;
                MyNews.NteContent = txtContent.Value.Trim();
                MyNews.IntOrderID = 0;
                MyNews.IntClick = Convert.ToInt32(txtHits.Text.Trim());
                MyNews.VarOperator = Pbzx.BLL.PBnet_tpman.GetNowUser().Master_Name;
                MyNews.DatDateAndTime = DateTime.Parse(Request["txtCreateTime"]);
                //string filename = "/Images/UploadFiles/News/N_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                //if (FileUploadThumb.FileName != "" && FileUploadThumb.FileBytes.Length > 100)
                //{
                //    if (MyNews.VarPicUrl != "")
                //    {
                //        Files.deleteFile(Server.MapPath(MyNews.VarPicUrl));
                //    }
                //    //FileUploadThumb.SaveAs(Server.MapPath("../" + filename));
                //    Thumbnail.getThumbnail(FileUploadThumb.FileContent, Server.MapPath(filename), 257, 163);
                //    MyNews.VarPicUrl = filename;
                //}
               // MyNews.VarPicUrl = this.txtThumb.Text;
                MyNews.ShowIndex = this.chbShowIndex.Checked;
                //MyNews.ShowInSoft = this.chbShowInSoft.Checked;
                MyNews.VarPicUrl = this.txtVarPicUrl.Text.Trim();

                if (MyNews.IntID > 0)
                {
                    bool isOK = false;
                    if (this.chkIsRecommand.Checked)
                    {
                        WebFunc.RefPagesByPageName("���ѧԺ��ϸҳģ��");
                        isOK = ArticleBLL.ArticleUpdate(MyNews);
                    }
                    else
                    {
                        isOK = ArticleBLL.Update(MyNews);
                    }
                    if (isOK)
                    {                        
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸����ѧԺ��Ѷ[" + MyNews.IntID + ":" + MyNews.NvarTitle + "].");
                        //Response.Write("<script>alert('�޸ĳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        //Server.Execute("Refurbish_School.aspx");
                        Response.Redirect("School_Manage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('�޸�ʧ��');</script>");
                    }
                }
                else
                {
                    int mynewsID = 0;
                    if (this.chkIsRecommand.Checked)
                    {
                        mynewsID = ArticleBLL.ArticleCreate(MyNews);
                        MyNews.IntID = mynewsID;
                        WebFunc.RefPagesByPageName("���ѧԺ��ϸҳģ��");
                        ArticleBLL.ArticleUpdate(MyNews);
                    }
                    else
                    {
                        if (ArticleBLL.Add(MyNews))
                        {
                            mynewsID = 1;
                        }
                        else
                        {
                            mynewsID = 0;
                        }
                    }

                    if (mynewsID > 0)
                    {                        
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "�������ѧԺ��Ѷ[" + MyNews.NvarTitle + "].");
                        //Response.Write("<script>alert('��ӳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        //Server.Execute("Refurbish_School.aspx");
                        Response.Redirect("School_Manage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('���ʧ��');</script>");
                    }
                }
            }
        }

        protected void ddlChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_SchoolType newsTypeBLL = new Pbzx.BLL.PBnet_SchoolType();
            newsTypeBLL.BindNewsTypeByChannel(this.ddlClass, int.Parse(this.ddlChannel.SelectedValue));
            ddlClass.Items.Insert(0, "==��ѡ��==");
            ddlClass.Items[0].Value = "-1";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("School_Manage.aspx");
        }
    }
}
