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
namespace Pbzx.Web
{
    public partial class ChannelAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pbzx.BLL.PBnet_UrlMaping MyBLL = new Pbzx.BLL.PBnet_UrlMaping();
                Pbzx.Model.PBnet_UrlMaping MyModel = new Pbzx.Model.PBnet_UrlMaping();
                MyBLL.BindUrlMaping(this.ddlParent,0);

                ListItem item = new ListItem("=��Ϊһ��Ƶ��=", "0");
                ddlParent.Items.Insert(0, item);

                string str = Request.QueryString["ID"];
                if (str != null && OperateText.IsNumber(str))
                {
                    MyModel = MyBLL.GetModel(Convert.ToInt32(str));
                }
                this.txtPageName.Text = MyModel.PageName;
                this.txtHtml.Text = MyModel.Html;
                this.txtAspx.Text = MyModel.Aspx;

                if (MyModel.Depth > 0)
                {
                    Method.sltListBox(ref ddlParent, MyModel.FID.ToString());
                    // txtUrl.Attributes.Remove("disabled");
                }
                else
                {
                    ddlParent.SelectedIndex = 0;

                }
          //      ddlParent.Enabled = (MyModel.Depth > 0);
                hfID.Value = MyModel.MapID.ToString();
            }
           

        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {  
            int map = Convert.ToInt32(hfID.Value);
            int FID = Convert.ToInt32(ddlParent.SelectedValue);



            if (txtPageName.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("���Ʋ���Ϊ��."));
                return;
            }
            Pbzx.BLL.PBnet_UrlMaping MyBLL = new Pbzx.BLL.PBnet_UrlMaping();
            Pbzx.Model.PBnet_UrlMaping MyModel = new Pbzx.Model.PBnet_UrlMaping();
            Pbzx.Model.PBnet_UrlMaping FModel = new Pbzx.Model.PBnet_UrlMaping();        
            
            if (map == 0)
            {
                if (FID > 0) 
                {
                    //���Ǹ�Ŀ¼
                    FModel = MyBLL.GetModel(FID);
                    MyModel.Depth = FModel.Depth + 1;
                    MyModel.FID = FModel.MapID;
                }
                MyModel.PageName = this.txtPageName.Text;
                MyModel.FID = int.Parse(this.ddlParent.SelectedValue);
                MyModel.Html = this.txtHtml.Text;
                MyModel.Aspx = this.txtAspx.Text;

               if (MyBLL.Add(MyModel))
                {
                    if (FID == 0) 
                    {
                        MyModel.MapID = MyBLL.GetInsertID();
                        MyModel.FID = MyModel.MapID;
                        MyModel.Depth = 0;
                        MyBLL.Update(MyModel);
                    }

                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "����Ƶ����Ϣ[" + MyModel.PageName + "].");
                    // ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("���������ӳɹ�."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("ChannelManage.aspx"));
                  
                }
                else 
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("����Ƶ����Ϣʧ��."));
                }
            }
            else
            {
                MyModel = MyBLL.GetModel(map);
                if (MyModel.Depth == 1 && FID == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("����ģ���޷�ת�ɶ���ģ��."));
                    return;
                }

                if (MyModel.Depth > 0)
                {
                    FModel = MyBLL.GetModel(FID);
                    MyModel.MapID = FModel.MapID;
                    MyModel.FID = FModel.FID;
                
                }
                MyModel.PageName = this.txtPageName.Text;
                MyModel.FID = int.Parse(this.ddlParent.SelectedValue);
                MyModel.Html = this.txtHtml.Text;
                MyModel.Aspx = this.txtAspx.Text;

                if (MyBLL.Update(MyModel))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸�Ƶ����Ϣ[" + MyModel.PageName + "].");
                    // ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("���������ӳɹ�."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("ChannelManage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("�޸�Ƶ����Ϣʧ��."));
                }            
            }
            
        }
    }
}
