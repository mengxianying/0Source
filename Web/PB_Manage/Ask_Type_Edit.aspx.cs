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
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class Ask_Type_Edit : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              // this.IsAuthority(0);

                Pbzx.BLL.PBnet_ask_Type MyBLL = new Pbzx.BLL.PBnet_ask_Type();
                MyBLL.BindClass(this.ddlParent, 0);

                ListItem item = new ListItem("=作为顶级类别=", "0");
                ddlParent.Items.Insert(0, item);
              //ddlParent.Attributes.Add("onchange", "ParentChange(this);");
                string str = Request.QueryString["Id"];
                Pbzx.BLL.PBnet_ask_Type MyBll = new Pbzx.BLL.PBnet_ask_Type();
                Pbzx.Model.PBnet_ask_Type MyModel;
                if (OperateText.IsNumber(str))
                {
                    MyModel = MyBll.GetModel(Convert.ToInt32(str));
                    this.txtName.Text = MyModel.TypeName;
                    this.ddlParent.SelectedValue = MyModel.FTypeID.ToString();

                    this.txtIntOrderID.Text = MyModel.OrderID.ToString();
                    this.hfID.Value = MyModel.Id.ToString();
                    cbMenu.Checked = MyModel.BitIsAuditing;
                }


            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int ModuleID = Convert.ToInt32(hfID.Value);
            int ParentID = Convert.ToInt32(ddlParent.SelectedValue);

            if (txtName.Text.Trim() == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "namenull", JS.Alert("名称不能为空."));
                return;
            }

            Pbzx.BLL.PBnet_ask_Type MyBll = new Pbzx.BLL.PBnet_ask_Type();
            Pbzx.Model.PBnet_ask_Type MyModel = new Pbzx.Model.PBnet_ask_Type();
            Pbzx.Model.PBnet_ask_Type PModel = new Pbzx.Model.PBnet_ask_Type();

      
            if (ModuleID == 0)
            {
                //添加
                if (ParentID > 0)
                {
                    //不是跟类别
                    PModel = MyBll.GetModel(ParentID);
                    MyModel.RootID = PModel.Id;
                    MyModel.Depth = PModel.Depth + 1;
                    MyModel.FTypeID = PModel.Id;
                }
                MyModel.BitIsAuditing = this.cbMenu.Checked;
                MyModel.TypeName = this.txtName.Text;
                MyModel.OrderID = int.Parse(this.txtIntOrderID.Text);
              
                if (MyBll.Add(MyModel))
                {
                    if (ParentID == 0)
                    {
                        MyModel.Id = MyBll.GetInsertID();
                        MyModel.FTypeID = 0;
                        MyModel.RootID = MyModel.Id;
                        MyModel.Depth = 0;
                        MyModel.ModuleFIDS = MyModel.Id.ToString();                       
                    }
                    else
                    {
                        MyModel.Id = MyBll.GetInsertID();
                        MyModel.RootID = MyModel.Id;
                        MyModel.Depth = 0;
                        MyModel.ModuleFIDS = MyModel.FTypeID.ToString() + "|" + MyModel.Id.ToString();
                    }
                    MyBll.Update(MyModel);
                     Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "新增拼搏吧类别[" + MyModel.TypeName + "].");
                    // ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("拼搏吧类别添加成功."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("Ask_Type.aspx"));
                

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("拼搏吧类别添加失败."));
                }
            }
            else {
                MyModel = MyBll.GetModel(ModuleID);
                if (MyModel.Depth == 1 && ParentID == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("二级模块无法转成顶级模块."));
                    return;
                }
                if (MyModel.Depth > 0)
                {
                    PModel = MyBll.GetModel(ParentID);
                    MyModel.RootID = PModel.Id;
                    MyModel.FTypeID = int.Parse(this.ddlParent.SelectedValue.ToString());
                    MyModel.ModuleFIDS = MyModel.FTypeID.ToString() + "|" + MyModel.Id.ToString();
                }
                else
                {
                    MyModel.FTypeID = int.Parse(this.ddlParent.SelectedValue.ToString());
                    if(MyModel.FTypeID != 0){
                    MyModel.ModuleFIDS = MyModel.FTypeID.ToString();
                    }
                }
                MyModel.OrderID =int.Parse(this.txtIntOrderID.Text);
                MyModel.BitIsAuditing = this.cbMenu.Checked;
                MyModel.TypeName = this.txtName.Text;
               
            
                if (MyBll.Update(MyModel))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改拼搏吧类别[" + MyModel.TypeName + "].");
                    //  ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("新闻类别修改成功."));
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect", JS.Replace("Ask_Type.aspx"));

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("拼搏吧类别修改失败."));
                
                }

                return;          
            
            }
         }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ask_Type.aspx");
        }

        protected void ddlParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ModuleID = Convert.ToInt32(hfID.Value);
            if (ModuleID == 0)
            {
                this.txtIntOrderID.Text = Convert.ToString(Convert.ToInt32(DbHelperSQL.GetSingle("select max(OrderID) from  PBnet_ask_Type where FTypeID='" + this.ddlParent.SelectedValue + "'  ")) + 1);
            }
        }
    }
}
