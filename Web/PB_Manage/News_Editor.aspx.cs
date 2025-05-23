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
using System.Text;

namespace Pbzx.Web.PB_Manage
{
    public partial class News_Editor : AdminBasic
    {



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {      
                string basePath =   "/Images/UploadFiles/News/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString();

                if (!DirectoryFile.IsCreateDirectory(Server.MapPath(basePath)))
                {
                    DirectoryFile.CreateDirectory(Server.MapPath(basePath));
                }
                Session["FCKeditor:UserFilesPath"] = basePath;
                Session["DefaultSelect"] = basePath;


               //Pbzx.Common.Method.BindNewsDisPosition(ref this.ddlIntDisPosition);
               // FileUploadThumb.Attributes.Add("onchange", "Upload_OnChange(this,'txtThumb','ThumbImageState');");
                Pbzx.Model.PBnet_News MyNews;
                Pbzx.BLL.PBnet_News ArticleBLL = new Pbzx.BLL.PBnet_News();
                Pbzx.BLL.PBnet_NewsType newsTypeBLL = new Pbzx.BLL.PBnet_NewsType();
                Pbzx.BLL.PBnet_Channel channelBLL = new Pbzx.BLL.PBnet_Channel();       
                string str = Request["ID"];

                channelBLL.BindChannelType(this.ddlChannel, 0);
                ddlChannel.Items.Insert(0, "==请选择==");
                ddlChannel.Items[0].Value = "-1";               
                if (str != null && OperateText.IsNumber(str))
                {
                    this.IsAuthority(2);
                    lblAction.Text = "修改";
                    //btnCancel.Visible = true;
                    //btnCancel.Attributes.Add("onclick", "history.back();return false;");
                    MyNews = ArticleBLL.GetModel(Convert.ToInt32(str));
                    this.chbShowIndex.Checked = MyNews.ShowIndex;
                    this.chbShowInSoft.Checked = MyNews.ShowInSoft;
                    ddlChannel.SelectedValue = MyNews.IntChannelID.ToString();

                    newsTypeBLL.BindNewsType(this.ddlClass, 0);
                    ddlClass.Items.Insert(0, "==请选择==");
                    ddlClass.Items[0].Value = "-1";
                    ddlClass.SelectedValue = MyNews.IntShowType.ToString();
                    txtInWeiXin.Text = MyNews.InWeiXin.ToString();
                }
                else
                {
                    this.IsAuthority(1);
                    lblAction.Text = "新增";
                    //btnCancel.Visible = false;
                    MyNews = new Pbzx.Model.PBnet_News();
                    MyNews.BitIsPass = true;                    
                    MyNews.NvarAuthor = WebFunc.GetCurrentAdmin();
                    MyNews.Source = "拼搏在线彩神通软件";
                    MyNews.SourceUrl = WebInit.webBaseConfig.WebUrl;
                    MyNews.EffectDate = DateTime.Now.AddMonths(3);
                    ddlChannel.SelectedValue = "3";
                    newsTypeBLL.BindNewsType(this.ddlClass, 0);
                    ddlClass.Items.Insert(0, "==请选择==");
                    ddlClass.Items[0].Value = "-1";
                    MyNews.NKey = "";   // GetKeyString();
                    

                    //MyNews.NKey = "彩神通 拼搏在线 彩票软件 3D P3 排列三 排列五 七乐彩 双色球 快乐8 七星彩 超级大乐透 体彩 福彩 福利彩票 体育彩票 图表 走势图 选号 软件下载 玩法技巧 开奖信息 试机号 关注码"; 
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


                this.rbtnIsTop.SelectedValue = MyNews.BitIsTop.ToString();               
               
              //  chkIsHot.Checked = MyNews.BitIsTop;
                chkIsRecommand.Checked = MyNews.BitIsPass;
                //txtThumb.Text = MyNews.VarPicUrl;             
                txtContent.Value = MyNews.NteContent;
                if(string.IsNullOrEmpty(MyNews.IntClick.ToString()))
                {
                    txtHits.Text = "0";
                }
                else
                {
                    txtHits.Text = MyNews.IntClick.ToString();
                }



                if (string.IsNullOrEmpty(MyNews.DatDateAndTime.ToString()))
                {
                    txtCreateTime.Text = DateTime.Now.ToString();
                }
                else
                {
                    txtCreateTime.Text = MyNews.DatDateAndTime.ToString();
                }
                txtVarPicUrl.Text = MyNews.VarPicUrl;

                if (!string.IsNullOrEmpty(MyNews.InWeiXin.ToString()))
                {
                    txtInWeiXin.Text = MyNews.InWeiXin.ToString();
                }

            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (txtTitle.Text.Trim() == "")
            {
                strErrMsg += "新闻标题不能为空.\\r\\n";
            }
            if (ddlChannel.SelectedValue == "-1" )
            {
                strErrMsg += "请选择所属频道.\\r\\n";
            }
            if (ddlClass.SelectedValue == "-1" )
            {
                strErrMsg += "请选择新闻类别.\\r\\n";
            }

            if (txtContent.Value.Trim() == "")
            {
                strErrMsg += "新闻内容不能为空.\\r\\n";
            }
            if (!OperateText.IsNumber(txtHits.Text.Trim()))
            {
                strErrMsg += "点击次数未输入或数据格式不正确.\\r\\n";
            }
           // string ext = "";
            //if (FileUploadThumb.FileName != "" && FileUploadThumb.FileBytes.Length > 100)
            //{
            //    ext = System.IO.Path.GetExtension(FileUploadThumb.FileName).ToLower();
            //    if (ext != ".gif" && ext != ".jpg" && ext != ".jpeg")
            //    {
            //        strErrMsg += "图片格式不对，只允许上传[.gif/.jpg/.jpeg]格式的文件.\\r\\n";
            //    }
            //    else if (FileUploadThumb.FileBytes.Length / 1024 > 1024*2)
            //    {
            //        strErrMsg += "图片大小超过限制，最大允许上传2M(2*1024KB)文件\\r\\n";
            //    }
            //}
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的新闻信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                int NewsID = Convert.ToInt32(hfNewsID.Value);
                Pbzx.BLL.PBnet_News ArticleBLL = new Pbzx.BLL.PBnet_News();
                Pbzx.Model.PBnet_News MyNews;
                if (NewsID > 0)
                {
                    MyNews = ArticleBLL.GetModel(NewsID);
                }
                else
                {
                    MyNews = new Pbzx.Model.PBnet_News();
                }
                MyNews.NvarTitle = txtTitle.Text.Trim();
                MyNews.NvarShortTitle = txtShortTitle.Text.Trim();
                MyNews.NKey = txtKey.Text;

                MyNews.Metadesc = txtMetadesc.Text;
                if(txtMetadesc.Text.Trim() =="")
                {
                    MyNews.Metadesc = this.txtTitle.Text;
                }
                MyNews.Source =this.txtSource.Text;
                MyNews.SourceUrl =  this.txtSourceUrl.Text;
                //MyNews.EffectDate = DateTime.Parse(this.txtEffectDate.Text);

                MyNews.NvarAuthor = txtAuthor.Text.Trim();
                MyNews.IntShowType = Convert.ToInt32(ddlClass.SelectedValue);
                MyNews.IntChannelID = Convert.ToInt32(this.ddlChannel.SelectedValue);

                MyNews.BitIsPass = chkIsRecommand.Checked;
                //MyNews.BitIsHot = chkIsHot.Checked;
                MyNews.BitIsTop = int.Parse(this.rbtnIsTop.SelectedValue);
                
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
                //MyNews.VarPicUrl = this.txtThumb.Text;
                MyNews.ShowIndex = this.chbShowIndex.Checked;
                MyNews.ShowInSoft = this.chbShowInSoft.Checked;
                MyNews.VarPicUrl = this.txtVarPicUrl.Text.Trim();

                if (!string.IsNullOrEmpty(txtInWeiXin.Text.Trim()))
                {
                    MyNews.InWeiXin = int.Parse(txtInWeiXin.Text.Trim());
                }
               

                if (MyNews.IntID > 0)
                {
                    bool  isOK = false;
                    if (this.chkIsRecommand.Checked)
                    {
                       WebFunc.RefPagesByPageName("新闻详细页模板");
                       isOK = ArticleBLL.ArticleUpdate(MyNews);
                    }
                    else
                    { 
                        isOK = ArticleBLL.Update(MyNews);
                    }
                    if (isOK)
                    {                        
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改新闻[" + MyNews.IntID + ":" + MyNews.NvarTitle + "].");
                        //Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        Response.Redirect("News_Manage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败');</script>");
                    }
                }
                else
                {
                    int mynewsID = 0;
                    if (this.chkIsRecommand.Checked)
                    {
                        mynewsID = ArticleBLL.ArticleCreate(MyNews);
                        MyNews.IntID = mynewsID;
                        WebFunc.RefPagesByPageName("新闻详细页模板");
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
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "新增新闻[" + MyNews.NvarTitle + "].");
                        //Response.Write("<script>alert('添加成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        Response.Redirect("News_Manage.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('添加失败');</script>");
                    }
                }
            }
        }

        protected void ddlChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_NewsType newsTypeBLL = new Pbzx.BLL.PBnet_NewsType();
            newsTypeBLL.BindNewsTypeByChannel(this.ddlClass,int.Parse(this.ddlChannel.SelectedValue));
            ddlClass.Items.Insert(0, "==请选择==");
            ddlClass.Items[0].Value = "-1";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("News_Manage.aspx");
        }
        protected string GetKeyString()
        {
            StringBuilder sb = new StringBuilder("");
            DataSet obj = DbHelperSQL.Query("select  metaDesc from PBnet_MetaDesc order by NEWID()");
            if (obj != null)
            {
                foreach (DataRow row in obj.Tables[0].Rows)
                {
                    sb.Append(row[0].ToString()+" ");

                }
            }
            return sb.ToString();
        }

    }
}
