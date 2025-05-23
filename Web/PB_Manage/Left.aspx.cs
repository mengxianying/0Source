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
    public partial class Left : System.Web.UI.Page
    {
        protected DataTable Dview;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["currentUser"] == null)
            {
                ViewState["currentUser"] = WebFunc.GetCurrentAdmin();
            }

            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
            DataTable ds = ModuleBLL.GetRootList();
            this.MyGridView.DataSource = ds;
            MyGridView.DataBind();
            BindCustomerPowers();
        }

        private void BindCustomerPowers()
        {
            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
            // (  stuff(ID,1,0, stuff('" + Method.AdminPowerSettingFormart(0) + "',1,len([ID]),''))  in('" + DbHelperSQL.GetSingle("select top 1  Setting  from PBnet_tpman where Master_Name ='" + ViewState["currentUser"] .ToString()+ "'  ") + "')) and 
            string tempIDS = DbHelperSQL.GetSingle("select top 1  Column_Setting  from PBnet_tpman where Master_Name ='" + ViewState["currentUser"].ToString() + "'  ").ToString();
            string[] idsSZ = tempIDS.Split(new char[] { ',' });
            StringBuilder sb = new StringBuilder();
            foreach (string str in idsSZ)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    sb.Append("'" + str + "',");
                }
            }
            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            if (sb.ToString() == "")
            {
                sb.Append("0");
            }
            DataSet dsCustomerPowers = ModuleBLL.GetList(" tempID  in(" + sb.ToString() + ")   and    FlagMenu=1 AND Depth =1   order by AllSort asc ");
            this.rptCustomerPowers.DataSource = dsCustomerPowers;
            this.rptCustomerPowers.DataBind();
            if (dsCustomerPowers.Tables.Count > 0 && dsCustomerPowers.Tables[0].Rows.Count > 0)
            {
                this.dvCustomerPowers.Visible = true;
            }
            else
            {
                this.dvCustomerPowers.Visible = false;
            }
        }

        protected string iniChild(object mRoot)
        {
            int root = Convert.ToInt32(mRoot);
            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
            //(stuff(ID,1,0, stuff('" + Method.AdminPowerSettingFormart(0) + "',1,len([ID]),''))  in('" + DbHelperSQL.GetSingle("select top 1  Setting  from PBnet_tpman where Master_Name ='" + ViewState["currentUser"] .ToString()+ "'  ") + "')) and 
            string tempIDS = DbHelperSQL.GetSingle("select top 1  Setting  from PBnet_tpman where Master_Name ='" + ViewState["currentUser"].ToString() + "'  ").ToString();
            string[] idsSZ = tempIDS.Split(new char[] { ',' });
            StringBuilder sb = new StringBuilder();
            foreach (string str in idsSZ)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    sb.Append("'" + str + "',");
                }
            }
            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            if (sb.ToString() == "")
            {
                sb.Append("0");
            }
            Dview = ModuleBLL.GetList(" tempID  in(" + sb.ToString() + ")   and    FlagMenu=1 AND Depth =1 AND RootID=" + root + "  order by Sort asc ").Tables[0];
            return "";

        }

        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string currentID = MyGridView.DataKeys[e.Row.RowIndex].Values["ID"].ToString();
                if (MyGridView.DataKeys[e.Row.RowIndex].Values["Depth"].ToString() == "0" && MyGridView.DataKeys[e.Row.RowIndex].Values["FlagMenu"].ToString() == "1")
                {
                    iniChild(MyGridView.DataKeys[e.Row.RowIndex].Values["RootID"]);
                    if (Dview.Rows.Count < 1)
                    {
                        (e.Row.Cells[0].FindControl("pnlSub") as Panel).Visible = false;
                    }
                    else
                    {
                        (e.Row.Cells[0].FindControl("pnlSub") as Panel).Visible = true;
                    }
                }
                //document.getElementById('ChildMenu" + currentID + "').style.display=
                //document.getElementById('ChildMenu" + currentID + "').style.display=='none'?'':'none';

                (e.Row.Cells[0].FindControl("pnlSub") as Panel).Attributes.Add("onclick", "if(document.getElementById('ChildMenu" + currentID + "').style.display=='none'){document.getElementById('ChildMenu" + currentID + "').style.display='block';}else{document.getElementById('ChildMenu" + currentID + "').style.display='none';}");
            }
        }
    }
}
