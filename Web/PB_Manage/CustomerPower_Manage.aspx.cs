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
using Maticsoft.DBUtility;
using System.Text;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage
{
    public partial class CustomerPower_Manage : AdminBasic
    {
        protected DataTable Dview;
        protected Hashtable tbRS;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (ViewState["currentUser"] == null)
                {
                    ViewState["currentUser"] = WebFunc.GetCurrentAdmin();
                }
                if (string.IsNullOrEmpty(ViewState["currentUser"].ToString()))
                {
                    Response.Redirect("index.htm");
                    return;
                }
                bindRights();
            }
        }

        protected void bindRights()
        {
            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
            MyGridView.DataSource = ModuleBLL.GetRootList(false);
            MyGridView.DataBind();
        }

        protected string iniChild(object mRoot)
        {
            int root = Convert.ToInt32(mRoot);
            Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
            // (  stuff(ID,1,0, stuff('" + Method.AdminPowerSettingFormart(0) + "',1,len([ID]),''))  in('" + DbHelperSQL.GetSingle("select top 1  Setting  from PBnet_tpman where Master_Name ='" + ViewState["currentUser"] .ToString()+ "'  ") + "')) and 
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
            if (root == 266)
            {
                Dview = ModuleBLL.GetList(" tempID  in(" + sb.ToString() + ") and FlagMenu=1 and Depth =1 AND RootID=" + root + "  order by Sort asc ").Tables[0];
            }
            else
            {
                Dview = ModuleBLL.GetList(" tempID  in(" + sb.ToString() + ") and FlagMenu=1 and Depth =1 AND RootID=" + root + "  order by Sort asc ").Tables[0];
            }
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

        protected string getChild(object mName, object mRoot)
        {
            int root = Convert.ToInt32(mRoot);
            //Pbzx.BLL.PBnet_Module ModuleBLL = new Pbzx.BLL.PBnet_Module();
            //Dview = ModuleBLL.GetList(" Depth =1 AND RootID=" + root).Tables[0];
            string name = mName.ToString();
            name = "<b>" + name + "</b>";
            return name;
        }

        protected string showRights(object name, object mUrl, object id)
        {
            string result = "";
            string url = mUrl.ToString().ToLower();
            bool isHas = DbHelperSQL.Exists("select count(1) from PBnet_tpman where Master_Name='" + ViewState["currentUser"].ToString() + "' and charindex('" + Method.AdminPowerSettingFormart(id) + "',Column_Setting) > 0 ");
            if (!isHas)
            {
                result += name + "<input type=\"checkbox\" name=\"myPower.aspx\" value=\"" + id + "\" /> ";
            }
            else
            {
                result += name + "<input type=\"checkbox\" name=\"myPower.aspx\" value=\"" + id + "\" checked=\"checked\" /> ";
            }
            return result;
        }


        private string EnCodePower()
        {
            StringBuilder sb = new StringBuilder();
            ArrayList arr = new ArrayList();
            foreach (string str in Request.Form)
            {
                string tmpstr = str.ToLower();
                if (tmpstr.IndexOf(".aspx") == -1) continue;
                string[] res = Request.Form.GetValues(str);
                foreach (string strSZ in res)
                {
                    arr.Add(Method.AdminPowerSettingFormart(strSZ));
                }
            }
            arr.Sort();
            foreach (object obj in arr)
            {
                sb.Append(obj.ToString() + ",");
            }
            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (DbHelperSQL.ExecuteSql("update PBnet_tpman set Column_Setting='" + EnCodePower() + "' where Master_Name='" + ViewState["currentUser"].ToString() + "' ") > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改[" + ViewState["currentUser"].ToString() + "]权限");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", "<script>alert('用户常用功能设置成功！');location.href='index.htm';</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "redError", JS.Alert("用户常用功能设置失败！"));
            }
        }
    }
}
