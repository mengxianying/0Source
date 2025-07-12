using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage
{
    public partial class AdminBasic : System.Web.UI.Page
    {
        public static Hashtable UserAuthority;
        public  Hashtable htUserPower = null;       
        public AdminBasic()
        {                   
            Pbzx.BLL.ChangeDB defaultdb = new Pbzx.BLL.ChangeDB();
            this.Load += new EventHandler(this.Basic_Load);            
        }

        private void Basic_Load(object sender, System.EventArgs e)
        {
            //检查是否已登录.
            Pbzx.BLL.PBnet_tpman.IsLogin(); // .Admin.IsLogin();

            //////////调用dll完成后，管理员重新登录/////////////////////////////////////
            Pbzx.BLL.PBnet_tpman AdminBLL = new Pbzx.BLL.PBnet_tpman();
            Pbzx.Model.PBnet_tpman MyAdmin = AdminBLL.GetEntityByUserName(WebFunc.GetCurrentAdmin());
            Session["htUserPower"] = AdminBasic.GetUserPowers(MyAdmin.Setting);
            AdminBLL.UpdateInfo(MyAdmin);
            if (HttpContext.Current.Request.Cookies["AdminManager"] == null)
            {
                HttpCookie cookie = new HttpCookie("AdminManager");
                //cookie.Expires = DateTime.Now.AddHours(4);
                cookie.Value = Input.Encrypt(MyAdmin.Master_Name);
                //cookie.Domain = ".pinble.com";
                //cookie.Path = "/";
                HttpContext.Current.Response.AppendCookie(cookie);
            }
            //////////调用dll完成后，管理员重新登录/////////////////////////////////////

            if (Session["htUserPower"] != null)
            {
                htUserPower = (Hashtable)Session["htUserPower"];
            }    
            //DeCodeModule(EnCodeModule());
             MyIsAuthority();
            //
        }
        protected void MyIsAuthority()
        {
            string[] arrUrl = Request.Url.PathAndQuery.Split('/');
            string strUrl = arrUrl[arrUrl.Length - 1].ToLower();
            //strUrl = Server.UrlDecode(strUrl);
            if (htUserPower == null)
            {
                Response.Write("<script>alert('网页已过期，请重新登录');top.location='/PB_Manage/AdminLogin.aspx';</script>");
                return;
            }
            else if (htUserPower.Count < 1)
            {
                Response.Write("<script>alert('网页已过期，请重新登录');top.location='/PB_Manage/AdminLogin.aspx';</script>");
                return;
            }

            if (arrUrl.Length == 5 && arrUrl[arrUrl.Length - 2] == "cpdataconfig")
            {
                if (strUrl != "default.aspx")
                {
                    object rights = htUserPower[strUrl];
                    if (rights == null)
                    {
                        rights = htUserPower["cst/" + strUrl];
                    }
                    if (rights != null)//&& rights == 1
                        return;
                    //else
                    //{

                    //}
                    arrUrl = strUrl.Split('?');
                    if (arrUrl.Length > 1)
                    {
                        strUrl = arrUrl[0] + "?" + arrUrl[1].Split('=')[0] + "=[*]";
                        rights = htUserPower[arrUrl[0]];
                        if (rights == null)
                        {
                            rights = htUserPower["cst/" + strUrl];
                        }
                        if (rights != null)//&& rights[aType] == 1
                            return;
                    }
                    //    Pbzx.Model.PBnet_tpman MyAdmin = AdminBLL.GetEntityByUserName(UID);
                    //    Pbzx.BLL.PBnet_Group GroupBLL = new Pbzx.BLL.PBnet_Group();
                    //    //object objAuthority = GroupBLL.GetAuthorityByName(MyAdmin.UserGroup);
                    //    //if (objAuthority != null)
                    //    //{
                    //    //AdminBasic.UserAuthority = AdminBasic.DeCodeModule(objAuthority);
                    //    AdminBasic.htUserPower = AdminBasic.GetUserPowers(MyAdmin.Setting);
                    Response.Redirect("/PB_Manage/NoRight.htm", true);
                }
            }
        }

        protected void IsAuthority(int aType)
        {
            string[] arrUrl = Request.Url.PathAndQuery.Split('/');
            string strUrl = arrUrl[arrUrl.Length - 1].ToLower();

            if (strUrl != "default.aspx")
            {
            //    int[] rights = (int[])UserAuthority[strUrl];
            //    if (rights == null)
            //    {
            //        rights = (int[])UserAuthority["cst/" + strUrl];
            //    }
            //    if (rights != null && rights[aType] == 1)
            //        return;
            //    arrUrl = strUrl.Split('?');
            //    if (arrUrl.Length > 1)
            //    {
            //        strUrl = arrUrl[0] + "?" + arrUrl[1].Split('=')[0] + "=[*]";
            //        rights = (int[])UserAuthority[strUrl];
            //        if (rights == null)
            //        {
            //            rights = (int[])UserAuthority["cst/" + strUrl];
            //        }
            //        if (rights != null && rights[aType] == 1)
            //            return;
            //    }
            //    Response.Redirect("NoRight.html", true);
            }
        }


        protected byte[] EnCodeModule()
        {
            Hashtable result = new Hashtable();
            foreach (string str in Request.Form)
            {
                if(!string.IsNullOrEmpty(str))
                {                                
                    string tmpstr = str.ToLower();
                    if (tmpstr.IndexOf(".aspx") == -1) continue;
                    string[] res = Request.Form.GetValues(str);
                    int[] rights = { 0, 0, 0, 0 };
                    foreach (string val in res)
                    {
                        rights[Convert.ToInt32(val)] = 1;
                    }
                    result.Add(tmpstr, rights);
                }
            }
            return Pbzx.Common.Serialize.getSearialize(result);
        }

        public static Hashtable DeCodeModule(object objModule)
        {
            byte[] myData = (byte[])objModule;
            Hashtable result = (Hashtable)Pbzx.Common.Serialize.getDesearialize(myData);
            return result;
        }

        public static Hashtable GetUserPowers(string pws)
        {
            string[] pwSz = pws.Split(new char[] { ','});
            Hashtable arr = new Hashtable();
            foreach(string str in pwSz)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    Pbzx.BLL.PBnet_Module moduleBll = new Pbzx.BLL.PBnet_Module();
                    string url = moduleBll.GetUrlByID(int.Parse(str));
                    if (!string.IsNullOrEmpty(url))
                    {
                        string[] arrUrl = url.Split('/');
                        string strUrl = arrUrl[arrUrl.Length - 1].ToLower();
                        if (!arr.ContainsKey(strUrl))
                        {
                            arr.Add(strUrl, str);
                        }
                    }
                }
            }
            return arr;
        }
        /*
        private Hashtable getRights()
        {
            Hashtable result = new Hashtable();
            foreach (string str in Request.Form)
            {
                if (str.ToLower().IndexOf(".aspx") == -1) continue;
                string[] res = Request.Form.GetValues(str);
                int[] rights = { 0, 0, 0, 0 };
                foreach (string val in res)
                {
                    rights[Convert.ToInt32(val)] = 1;
                }
                result.Add(str, rights);
            }
            return result;
        }
        */
        public void WriteJs(string strJs)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", strJs);
        }
        #region //分类树形
        public void getTreeList(DropDownList ddList, DataTable tbList)
        {
            foreach (DataRow dr in tbList.Rows)
            {
                int depth = Convert.ToInt32(dr["Depth"]);
                string name = dr["Name"].ToString();
                string space = "";
                if (depth > 1)
                {
                    space = new string('　', depth - 1);
                }
                if (depth > 0)
                {
                    name = space + "├" + name;
                }
                ListItem item = new ListItem(name, dr["ID"].ToString());
                ddList.Items.Add(item);
            }
        }

        public void getTreeList(DropDownList ddList, DataTable tbList, int SelID)
        {
            foreach (DataRow dr in tbList.Rows)
            {
                int depth = Convert.ToInt32(dr["Depth"]);
                string name = dr["Name"].ToString();
                string space = "";
                if (depth > 1)
                {
                    space = new string('　', depth - 1);
                }
                if (depth > 0)
                {
                    name = space + "├" + name;
                }
                ListItem item = new ListItem(name, dr["ID"].ToString());
                if (item.Value == SelID.ToString())
                {
                    item.Selected = true;
                }
                ddList.Items.Add(item);
            }
        }

        public void getTreeList(DropDownList ddList, DataTable tbList, int SelID, string strExclude)
        {
            foreach (DataRow dr in tbList.Rows)
            {
                if (dr["SortStr"].ToString().IndexOf(strExclude) != -1) continue;
                int depth = Convert.ToInt32(dr["Depth"]);
                string name = dr["Name"].ToString();
                string space = "";
                if (depth > 1)
                {
                    space = new string('　', depth - 1);
                }
                if (depth > 0)
                {
                    name = space + "├" + name;
                }
                ListItem item = new ListItem(name, dr["ID"].ToString());
                if (item.Value == SelID.ToString())
                {
                    item.Selected = true;
                }
                ddList.Items.Add(item);
            }
        }
        #endregion
    }
}
