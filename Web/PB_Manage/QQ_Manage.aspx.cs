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
    public partial class QQ_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pbzx.BLL.PBnet_Channel channelBLL = new Pbzx.BLL.PBnet_Channel();
                channelBLL.BindChannelType(this.ddlDisplay, 0);
                ddlDisplay.Items.Insert(0, "��ҳ��Ŀ");
                ddlDisplay.Items[0].Value = "0";    

                Pbzx.BLL.PBnet_QQ MyBll = new Pbzx.BLL.PBnet_QQ();
                Pbzx.Model.PBnet_QQ MyModel;
                if (Request["id"] != null)
                {
                    MyModel = MyBll.GetModel(Convert.ToInt32(Request["id"]));
                    this.txtTeam.Text = MyModel.Team;
                    this.txtTel.Text = MyModel.Tel;
                    this.txtQQ.Text = MyModel.VarQQNumber;
                    this.txtVarName.Text = MyModel.VarName;
                    this.ddlIntOrderID.SelectedValue = MyModel.IntOrderID.ToString();
                    this.ddlDisplay.SelectedValue = MyModel.IntDisplayPosition.ToString();
                    this.chAuditing.SelectedValue = MyModel.BitIsAuditing.ToString();
                    this.divList.Visible = false;
                    this.divOperator.Visible = true;
                
                }
                BindData();
            }
        }

        private void BindData() 
        {
            Pbzx.BLL.PBnet_QQ qqBll = new Pbzx.BLL.PBnet_QQ();
            MyGridView.DataSource = qqBll.GetList(" 1=1 ORDER BY IntDisplayPosition asc ");
            MyGridView.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_QQ MyBll = new Pbzx.BLL.PBnet_QQ();
            Pbzx.Model.PBnet_QQ MyModel;
            int intid = Convert.ToInt32(Request["id"]);
            if (intid > 0)
            {
                MyModel = MyBll.GetModel(intid);
            }
            else
            {
                MyModel = new Pbzx.Model.PBnet_QQ();
            }
            MyModel.Team = this.txtTeam.Text;
            MyModel.Tel = this.txtTel.Text;
            MyModel.VarQQNumber = this.txtQQ.Text;
            MyModel.VarName = this.txtVarName.Text;
            MyModel.IntOrderID = int.Parse(this.ddlIntOrderID.SelectedValue);
            MyModel.BitIsAuditing = this.chAuditing.Items[0].Selected;
            MyModel.IntDisplayPosition = int.Parse(this.ddlDisplay.SelectedValue);
            if (intid > 0)
            {
                if (MyBll.Update(MyModel))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸Ŀͷ�QQ��Ϣ[" + this.txtQQ.Text + "].");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("QQ_Manage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("�޸�ʧ��."));
                }
            }
            else {

                if (MyBll.Add(MyModel))
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("���", "��ӿͷ�QQ��Ϣ[" + this.txtQQ.Text + "].");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("QQ_Manage.aspx"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("���ʧ��."));
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
            divOperator.Visible = false;
            divList.Visible = true;
        }

        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex >= 0)
            {
                TableCell MyCell = e.Row.Cells[8];
                MyCell.Attributes.Add("onclick", "return confirm('��ȷ��Ҫɾ����?');");
            }
        }


        protected void DelModule(string e)
        {
            int ModuleID = Convert.ToInt32(e);
            Pbzx.BLL.PBnet_QQ ModuleBLL = new Pbzx.BLL.PBnet_QQ();
            Pbzx.Model.PBnet_QQ ModuleMedol = ModuleBLL.GetModel(ModuleID);
            string strNvname = ModuleMedol.VarQQNumber.ToString();
            if (ModuleBLL.Delete(ModuleID))
            {

                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ���ͷ�QQ��Ϣ[" + strNvname + "].");
                //   ClientScript.RegisterClientScriptBlock(this.GetType(), "delok", JS.Alert("�ɹ�ɾ���������."));
                ClientScript.RegisterClientScriptBlock(this.GetType(), "redirect", JS.Replace("QQ_Manage.aspx"));
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "nodel", JS.Alert("ɾ��QQ��Ϣʧ��."));
            }
        }
        

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
           
            divOperator.Visible = true;
            divList.Visible = false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            divOperator.Visible = false;
            divList.Visible = true;
        }
        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
           
            DelModule(e.CommandArgument.ToString());
        }

 
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = "(" + id.ToString() + ")";
            }
        }
        public static string GetChannlType(object strChannl)
        {
            int channlId = int.Parse(strChannl.ToString());

            if (channlId > 0)
            {
                return WebFunc.GetChannlName(channlId);
            }
            else {
                return "��ҳ��Ŀ";
            
            }
        }
    }
}
