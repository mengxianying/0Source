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

namespace Pbzx.Web.PB_Manage
{
    public partial class ChannelManage_Template : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //   this.IsAuthority(0);
                Pbzx.BLL.PBnet_UrlMaping ModuleBLL = new Pbzx.BLL.PBnet_UrlMaping();
                ModuleBLL.BindUrlMaping(this.ddlParent,0,1);
                ListItem item = new ListItem("=��Ϊһ��Ƶ��=", "0");
                ddlParent.Items.Insert(0, item);
                BindData();
                //  ddlParent.Attributes.Add("onchange", "ParentChange(this);");
            }
        }
        private void BindData()
        {
            Pbzx.BLL.PBnet_UrlMaping urlBLL = new Pbzx.BLL.PBnet_UrlMaping();
            this.MyGridView.DataSource = urlBLL.GetListBySort(1);
            this.MyGridView.DataBind();
        }

        protected string showModule(object RootID, object mName, object mDepth)
        {
            int depth = Convert.ToInt32(mDepth);
            string name = mName.ToString();
            if (depth == 0)
            {
                name = "<b>" + name + "</b><a href='#' onclick=\"OpenEdite('PBnet_UrlMaping','MapID','PageName','Html','OrderID','and RootID=" + RootID.ToString() + " and Depth>0 and TypeID=1 ','600','350')\" >[��ģ������]</a>";
            }
            else
            {
                name = "����" + name;
            }
            return name;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int ModuleID = Convert.ToInt32(hfID.Value);
            int ParentID = Convert.ToInt32(ddlParent.SelectedValue);
            if (txtName.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("���Ʋ���Ϊ��."));
                return;
            }


            Pbzx.BLL.PBnet_UrlMaping ModuleBLL = new Pbzx.BLL.PBnet_UrlMaping();

            Pbzx.Model.PBnet_UrlMaping PModule = new Pbzx.Model.PBnet_UrlMaping();
            Pbzx.Model.PBnet_UrlMaping MyModule = new Pbzx.Model.PBnet_UrlMaping();


            if (ModuleID == 0)
            {
                //����
                if (ParentID > 0)
                {
                    //���Ǹ����
                    PModule = ModuleBLL.GetModel(ParentID);
                    MyModule.RootID = PModule.MapID;
                    MyModule.Depth = PModule.Depth + 1;
                    MyModule.FID = PModule.MapID;
                }
                MyModule.PageName = txtName.Text;
                MyModule.Html = txtHtml.Text;
                MyModule.Aspx = txtAspx.Text;
                MyModule.TypeID = 1;
                //   MyModule.OrderID = this.ddlIntOrderID.SelectedValue;

                if (ModuleBLL.Add(MyModule))
                {
                    if (ParentID == 0)
                    {
                        MyModule.MapID = ModuleBLL.GetInsertID();
                        MyModule.FID = 0;
                        MyModule.RootID = MyModule.MapID;
                        MyModule.Depth = 0;
                        ModuleBLL.Update(MyModule);
                    }

                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "����Ƶ����Ϣ[" + MyModule.PageName + "].");
                    // ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("���������ӳɹ�."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("ChannelManage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("Ƶ����Ϣ���ʧ��."));
                }
            }
            else
            {
                MyModule = ModuleBLL.GetModel(ModuleID);
                if (MyModule.Depth == 1 && ParentID == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("����ģ���޷�ת�ɶ���ģ��."));
                    return;
                }

                if (MyModule.Depth > 0)
                {
                    PModule = ModuleBLL.GetModel(ParentID);
                    MyModule.RootID = PModule.MapID;
                    MyModule.FID = PModule.MapID;
                }
                // MyModule.OrderID = this.ddlIntOrderID.SelectedValue;
                //  MyModule.BitIsAuditing = this.cbMenu.Checked;
                MyModule.PageName = txtName.Text;
                MyModule.Html = txtHtml.Text;
                MyModule.Aspx = txtAspx.Text;
                MyModule.TypeID = 1;
                if (ModuleBLL.Update(MyModule))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸�Ƶ����Ϣ[" + MyModule.PageName + "].");
                    //  ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("��������޸ĳɹ�."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("ChannelManage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("Ƶ����Ϣ�޸�ʧ��."));
                }
                return;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //  this.IsAuthority(0);
            hfID.Value = "0";
            divOperator.Visible = false;
            divList.Visible = true;
        }

        //protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowIndex >= 0)
        //    {
        //        TableCell MyCell = e.Row.Cells[5];
        //        MyCell.Attributes.Add("onclick", "return confirm('��ȷ��Ҫɾ����?');");
        //    }
        //}

        //protected void MyGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "EditCate")
        //    {
        //        this.IsAuthority(2);
        //        this.ShowEditor(e.CommandArgument.ToString());
        //    }
        //    else if (e.CommandName == "DelCate")
        //    {
        //        this.IsAuthority(3);
        //        this.DelModule(e.CommandArgument.ToString());
        //    }
        //}

        protected void DelModule(string e)
        {

            int ModuleID = Convert.ToInt32(e);
            Pbzx.BLL.PBnet_UrlMaping ModuleBLL = new Pbzx.BLL.PBnet_UrlMaping();
            if (ModuleBLL.Delete(ModuleID))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ��Ƶ����Ϣ[" + ModuleID + "].");
                //  ClientScript.RegisterClientScriptBlock(this.GetType(), "delok", JS.Alert("�ɹ�ɾ���������."));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redirect", JS.Replace("ChannelManage.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "nodel", JS.Alert("ɾ��Ƶ����Ϣ."));
            }
        }


        protected void ShowEditor(string e)
        {
            int ModuleID = Convert.ToInt32(e);
            Pbzx.Model.PBnet_UrlMaping MyModule = new Pbzx.BLL.PBnet_UrlMaping().GetModel(ModuleID);
            txtName.Text = MyModule.PageName;
            txtHtml.Text = MyModule.Html;
            txtAspx.Text = MyModule.Aspx;
            hfID.Value = MyModule.MapID.ToString();
            if (MyModule.Depth > 0)
            {
                Method.sltListBox(ref ddlParent, MyModule.OrderID.ToString());
                // txtUrl.Attributes.Remove("disabled");
            }
            else
            {
                ddlParent.SelectedIndex = 0;

            }
            ddlParent.Enabled = (MyModule.Depth > 0);
            divOperator.Visible = true;
            divList.Visible = false;
        }


        protected void btn_gl_Click(object sender, EventArgs e)
        {
            divOperator.Visible = false;
            divList.Visible = true;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            //  this.IsAuthority(1);
            hfID.Value = "0";
            txtName.Text = "";
            ddlParent.SelectedIndex = 0;
            ddlParent.Enabled = true;
            divOperator.Visible = true;
            divList.Visible = false;
        }
        //protected void LinkButton2_Command(object sender, CommandEventArgs e)
        //{
        //  //  this.IsAuthority(3);
        //    DelModule(e.CommandArgument.ToString());
        //}

        //protected void LinkButton_Command(object sender, CommandEventArgs e)
        //{
        ////    this.IsAuthority(2);
        //    this.ShowEditor(e.CommandArgument.ToString());
        //}

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = "(" + id.ToString() + ")";
            }
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {

            int id = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();
            bll.CreatHtmlByChannelID(id, false);
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();
            string str = Request.Form["sel"];

            if (str == null)
            {
                return;
            }
            else if (str.IndexOf("25") > -1)
            {
                //Server.Execute("/PB_Manage/Refurbish_Ask.aspx");
                //Server.Execute("/PB_Manage/Refurbish_BBS.aspx");
                Server.Execute("/PB_Manage/RefurbishCpXml.aspx");
                Server.Execute("/PB_Manage/RefurbishGongGao.aspx");
            }
            bll.CreateHtmlByBatch(str);
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "��������ģ�徲̬ҳ��[" + str + "]");
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("��������" + del + "����¼.", "News_Manage.aspx"));            
            BindData();
        }

        protected void btnAllCreate_Click(object sender, EventArgs e)
        {
            //Server.Execute("/PB_Manage/Refurbish_Ask.aspx");
            //Server.Execute("/PB_Manage/Refurbish_BBS.aspx");
            //Server.Execute("/PB_Manage/RefurbishCpXml.aspx");
            //Server.Execute("/PB_Manage/RefurbishGongGao.aspx");

            Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "ȫ������ģ�徲̬ҳ��");
            bll.CreateHtmlByBatch();
            BindData();
        }
    }
}
