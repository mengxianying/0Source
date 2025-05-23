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
    public partial class Ad_Edit : AdminBasic
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                //string thisPageName = HttpContext.Current.Request.Url.Segments[HttpContext.Current.Request.Url.Segments.Length - 1];
                //Response.Write(thisPageName);
                //Response.End();
                Session["DefaultSelect"] = "Images/AD";

                string strTime = DateTime.Now.ToShortDateString();
                this.txtStartTime.Text = strTime;
                this.txtEndTime.Text = DateTime.Now.AddYears(1).ToShortDateString();
                Method.BindAdChanl(this.Channel);
                this.Channel.Items[0].Selected = true;
                Method.BindAdClass(this.rbtTypeID);
                this.rbtTypeID.Items[0].Selected = true;
                BindPlaceName();
                this.PlaceName.Items[0].Selected = true;

                Pbzx.BLL.PBnet_Adv MyBll = new Pbzx.BLL.PBnet_Adv();
                Pbzx.Model.PBnet_Adv MyModel;
                string str = Request["ID"];                
                if (str != null && OperateText.IsNumber(str))
                {
                   
                    Pbzx.BLL.PBnet_AdvPlace placeBLL = new Pbzx.BLL.PBnet_AdvPlace();
                                   
                    MyModel = MyBll.GetModel(Convert.ToInt32(str.ToString()));

                    Pbzx.Model.PBnet_AdvPlace placeModel = placeBLL.GetModelName(MyModel.PlaceName);
                    if (placeModel != null)
                    {
                        this.rbtTypeID.SelectedValue = placeModel.TypeID.ToString();
                        this.Channel.SelectedValue = placeModel.ChannelID.ToString();
                        BindPlaceName(placeModel.TypeID.ToString(), placeModel.ChannelID.ToString());
                        this.PlaceName.SelectedValue = placeModel.PlaceName;
                    }  

                  //this.rbtTypeID.Items.FindByValue(MyModel.pb_ADBSType);
                  //this.ddlChannel.SelectedValue = MyModel.pb_ChannelID.ToString();
                  //this.ddlADType.SelectedValue = MyModel.pb_ADType.ToString();

                    if (!string.IsNullOrEmpty(MyModel.pb_ADSetting))
                    {
                       string[] strSettings =  MyModel.pb_ADSetting.Split(new char[] {'|'});
                       this.txtpopleft.Text = strSettings[0];
                        if(strSettings.Length > 1)
                        {
                            this.txtpoptop2.Text = strSettings[1];
                        }
                    }
                    
                    this.IsSelected.Checked = MyModel.pb_IsSelected;
                    this.txtSiteName.Text = MyModel.pb_SiteName;
                    this.txtSiteUrl.Text = MyModel.pb_SiteUrl;
                    this.txtSiteIntro.Text = MyModel.pb_SiteIntro;

                    this.txtThumb.Text = MyModel.pb_ImgUrl;
                    this.txtImgWidth.Text = MyModel.pb_ImgWidth.ToString();
                    this.txtImgHeight.Text = MyModel.pb_ImgHeight.ToString();

                    if (MyModel.pb_IsFlash)
                    {
                        this.IsFlash.Items[0].Selected = true;
                        this.IsFlash.Items[1].Selected = false;
                    }
                    else
                    {
                        this.IsFlash.Items[0].Selected = false;
                        this.IsFlash.Items[1].Selected = true;
                    }
//                    this.IsFlash.SelectedValue = MyModel.pb_IsFlash.ToString();
                    this.txtStartTime.Text = ((DateTime)MyModel.pb_ADDTime).ToShortDateString();
                    this.txtEndTime.Text = ((DateTime)MyModel.pb_ENDTime).ToShortDateString();


                    this.txtpb_PeakC1.Text = MyModel.pb_PeakC1.ToString();
                    this.txtpb_PeakC2.Text = MyModel.pb_PeakC2.ToString();
                    this.txtpb_SameIP.Text = MyModel.pb_SameIP.ToString();


                    this.pb_PeakCount.Text = MyModel.pb_PeakCount.ToString();
                    this.txtpb_sPeakNum.Text = MyModel.pb_sPeakNum.ToString();
                    if (MyModel.pb_ADBSType)
                    {
                        this.pb_ADBSType.Items[0].Selected = true;
                        this.pb_ADBSType.Items[1].Selected = false;
                    }
                    else
                    {
                        this.pb_ADBSType.Items[0].Selected = false;
                        this.pb_ADBSType.Items[1].Selected = true;
                    }

                    this.txtpb_TDCount.Text = MyModel.pb_TDCount.ToString();
                    this.txtpb_ALLCount.Text = MyModel.pb_ALLCount.ToString();
                    this.pbs_TDCount.Text = MyModel.pbs_TDCount.ToString();
                    this.pbs_ALLCount.Text = MyModel.pbs_ALLCount.ToString();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (txtSiteName.Text.Trim() == "")
            {
                strErrMsg += "网站名称不能为空.\\r\\n";
            }

            if (txtSiteUrl.Text.Trim() == "")
            {
                strErrMsg += "网站地址不能为空.\\r\\n";
            }
            if (int.Parse(this.rbtTypeID.SelectedValue.ToString()) != 1)
            {
                if (!OperateText.IsNumber(txtImgWidth.Text.Trim()))
                {
                    strErrMsg += "图片的宽不是数字.\\r\\n";
                }
                if (!OperateText.IsNumber(txtImgHeight.Text.Trim()))
                {
                    strErrMsg += "图片的高不是数字.\\r\\n";
                }
            }
            if (string.IsNullOrEmpty(txtEndTime.Text))
            {
                strErrMsg += "结束时间不能为空.\\r\\n";
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的新闻信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else 
            {
                Pbzx.BLL.PBnet_Adv MyBll = new Pbzx.BLL.PBnet_Adv();
                Pbzx.Model.PBnet_Adv MyModel;
                int intid = Convert.ToInt32(Request.QueryString["ID"]);
                if (intid > 0)
                {
                    MyModel = MyBll.GetModel(Convert.ToInt32(intid));
                }
                else
                {
                    MyModel = new Pbzx.Model.PBnet_Adv();
                }
               
                MyModel.pb_ADSetting=this.txtpopleft.Text+"|"+this.txtpoptop2.Text;
                
                MyModel.pb_IsSelected = this.IsSelected.Checked;
                MyModel.PlaceName = this.PlaceName.SelectedItem.Value.ToString();
                
                MyModel.pb_SiteName =this.txtSiteName.Text;
                MyModel.pb_SiteUrl = this.txtSiteUrl.Text;
                MyModel.pb_SiteIntro=this.txtSiteIntro.Text;

                MyModel.pb_ImgUrl=this.txtThumb.Text;
                if (int.Parse(this.rbtTypeID.SelectedValue.ToString()) != 1)
                {
                    MyModel.pb_ImgWidth = int.Parse(this.txtImgWidth.Text);
                    MyModel.pb_ImgHeight = int.Parse(this.txtImgHeight.Text);
                }


                MyModel.pb_IsFlash = this.IsFlash.Items[0].Selected;
                MyModel.pb_ADDTime= DateTime.Parse(this.txtStartTime.Text);
                MyModel.pb_ENDTime= DateTime.Parse(this.txtEndTime.Text);


                MyModel.pb_PeakC1= int.Parse(this.txtpb_PeakC1.Text);
                MyModel.pb_PeakC2= int.Parse(this.txtpb_PeakC2.Text);
                MyModel.pb_SameIP= int.Parse(this.txtpb_SameIP.Text);


               
                MyModel.pb_sPeakNum = int.Parse(this.txtpb_sPeakNum.Text);
                MyModel.pb_ADBSType = this.pb_ADBSType.Items[0].Selected;

                MyModel.pb_TDCount = int.Parse(this.txtpb_TDCount.Text);
                MyModel.pb_ALLCount = int.Parse(this.txtpb_ALLCount.Text);

                Pbzx.BLL.PBnet_AdvPlace placeBLL = new Pbzx.BLL.PBnet_AdvPlace();

                Pbzx.Model.PBnet_AdvPlace placeModel = placeBLL.GetModelName(MyModel.PlaceName);
                string ADType = "";
                if (placeModel != null)
                {
                    ADType = placeModel.TypeID.ToString();
                }  

                if (intid > 0)
                {
                    if (MyBll.Update(MyModel))
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改广告[" + this.PlaceName.SelectedValue + "]");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Ad_Manage.aspx?ADType="+ADType));//ADType
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("修改失败."));
                    }

                }
                else
                {
                    if (MyBll.Add(MyModel))
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("添加", "添加广告[" + this.PlaceName.SelectedValue + "]");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("Ad_Manage.aspx?ADType="+ADType));
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("添加失败."));
                    }
                }
            }         
        }

        protected void rbtTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPlaceName();
        }

        /// <summary>
        /// 绑定广告位名称
        /// </summary>
        private void BindPlaceName()
        {
            int adType = int.Parse(this.rbtTypeID.SelectedValue);
            int adChannel = int.Parse(this.Channel.SelectedValue);
            Pbzx.BLL.PBnet_AdvPlace placeBLL = new Pbzx.BLL.PBnet_AdvPlace();
            DataSet dsNames = placeBLL.GetList(" TypeID='" + adType + "' and ChannelID ='" + adChannel + "' ");
            this.PlaceName.DataSource = dsNames;
            this.PlaceName.DataTextField = "PlaceName";
            this.PlaceName.DataValueField = "PlaceName";
            this.PlaceName.DataBind();        
        }

        /// <summary>
        /// 绑定广告位名称
        /// </summary>
        private void BindPlaceName(object objadType, object objadChannel)
        {
            int adType = Convert.ToInt32(objadType);
            int adChannel = Convert.ToInt32(objadChannel);
            Pbzx.BLL.PBnet_AdvPlace placeBLL = new Pbzx.BLL.PBnet_AdvPlace();
            DataSet dsNames = placeBLL.GetList(" TypeID='" + adType + "' and ChannelID ='" + adChannel + "' ");
            this.PlaceName.DataSource = dsNames;
            this.PlaceName.DataTextField = "PlaceName";
            this.PlaceName.DataValueField = "PlaceName";
            this.PlaceName.DataBind();
        }
    
        protected void Channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPlaceName();
        }
    }
}
