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

namespace Pinble_Help.pinbleHelp
{
    public partial class addNoet : System.Web.UI.Page
    {
        Pbzx.BLL.Help_TreeStructure get_ts = new Pbzx.BLL.Help_TreeStructure();
        Pbzx.Model.Help_TreeStructure mod_ts = new Pbzx.Model.Help_TreeStructure();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Pbzx.Help.WebFunc.validation(Request["adress"].ToString());
                ddlBind();
                ddl_pathBind();
            }
        }
        /// <summary>
        /// 绑定下拉列表静态地址
        /// </summary>
        private void ddl_pathBind()
        {
            int id = Convert.ToInt32(Request["id"]);
            ddl_path.Items.Add(new ListItem("--请选择--", "0"));
            ddl_path.Items.Add(new ListItem("说明", "/html/" + id + "/"));
            ddl_path.Items.Add(new ListItem("公用说明", "/publicHtml/"));
        }



        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_addNoet_Click(object sender, EventArgs e)
        {
            int TreeName = Convert.ToInt32(Request["id"]);
            string NoetName = "";
            if (txt_NoetName.Text == "")
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请填写帮助名称！')</script>");
                return;
            }
            else
            {
                if (txt_NoetName.Text.Split('.').Length > 0)
                {
                    NoetName = txt_NoetName.Text.Split('.')[0].ToString();
                }
                else
                {
                    NoetName = txt_NoetName.Text;
                }
            }
            if (get_ts.Exists(txt_NoetName.Text,ddl_fatherNoet.SelectedValue, TreeName))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('您添加的节点名称已存在！')</script>");

                return;
            }
            else
            {
                if (ddl_path.SelectedValue == "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请选择对应的路径！')</script>");
                    return;
                }
                if (ddl_path.SelectedValue == "/publicHtml/")
                {
                    Random ran = new Random();
                    int RandKey = ran.Next(1, 99);
                    int RandHeadKey = ran.Next(1, 10);
                    string id = Request["id"].ToString();
                    //取上页传来的值
                    mod_ts.Tree_name = id;
                    mod_ts.Tree_num = "1" + RandKey.ToString() + DateTime.Now.Second.ToString() + RandHeadKey + id;
                    mod_ts.Tree_superiorNoet = ddl_fatherNoet.SelectedValue;
                    mod_ts.Tree_RootNotd = NoetName;
                    mod_ts.Tree_countent = fck_Noet.Value;
                    mod_ts.Tree_Path = ddl_path.SelectedValue + NoetName + ".htm";
                    if (get_ts.Add(mod_ts) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('添加成功！');</script>");
                        ddlBind();
                        txt_NoetName.Text = "";
                        fck_Noet.Value = "";

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('添加失败，请重新添加！')</script>");

                    }
                }
                else
                {
                    if (fck_Noet.Value == "")
                    {

                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('请添加网页！')</script>");
                        return;
                    }
                    Random ran = new Random();
                    int RandKey = ran.Next(1, 99);
                    int RandHeadKey = ran.Next(1, 10);
                    string id = Request["id"].ToString();
                    //取上页传来的值
                    mod_ts.Tree_name = id;
                    mod_ts.Tree_num = "1" + RandKey.ToString() + DateTime.Now.Second.ToString() + RandHeadKey + id;
                    mod_ts.Tree_superiorNoet = ddl_fatherNoet.SelectedValue;
                    mod_ts.Tree_RootNotd = NoetName;
                    mod_ts.Tree_countent = fck_Noet.Value;
                    mod_ts.Tree_Path = ddl_path.SelectedValue + NoetName + ".htm";
                    if (get_ts.Add(mod_ts) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('添加成功！');</script>");
                        ddlBind();
                        txt_NoetName.Text = "";
                        fck_Noet.Value = "";

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('添加失败，请重新添加！')</script>");

                    }
                }
                

            }
        }

        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        private void ddlBind()
        {
            string id = Request["id"].ToString();
            ddl_fatherNoet.Items.Clear();
            ddl_fatherNoet.Items.Add(new ListItem("--请选择--", "0"));
           
            DataSet ds = get_ts.GetList("Tree_name=" + "'" + id + "'"+" order by Tree_id asc");
            MakeTree(ds.Tables[0], "Tree_superiorNoet", "0", "Tree_num", "Tree_RootNotd", this.ddl_fatherNoet, -1);
        }
        /// <summary> 
        /// 绑定生成一个有树结构的下拉菜单 
        /// </summary> 
        /// <param name="dtNodeSets">菜单记录数据所在的表</param> 
        /// <param name="strParentColumn">表中用于标记父记录的字段</param> 
        /// <param name="strRootValue">第一层记录的父记录值(通常设计为0或者-1或者Null)用来表示没有父记录</param> 
        /// <param name="strIndexColumn">索引字段，也就是放在DropDownList的Value里面的字段</param> 
        /// <param name="strTextColumn">显示文本字段，也就是放在DropDownList的Text里面的字段</param> 
        /// <param name="drpBind">需要绑定的DropDownList</param> 
        /// <param name="i">用来控制缩入量的值，请输入-1</param> 
        private void MakeTree(DataTable dtNodeSets, string strParentColumn, string strRootValue, string strIndexColumn, string strTextColumn, DropDownList drpBind, int i)
        {
            //每向下一层，多一个缩入单位 
            i++;
            DataView dvNodeSets = new DataView(dtNodeSets);
            dvNodeSets.RowFilter = strParentColumn + "=" + strRootValue;

            string strPading = ""; //缩入字符 
            //通过i来控制缩入字符的长度，我这里设定的是一个全角的空格 
            for (int j = 0; j < i; j++)
                strPading += "　";//如果要增加缩入的长度，改成两个全角的空格就可以了 
            foreach (DataRowView drv in dvNodeSets)
            {
                ListItem li = new ListItem(strPading + "├" + drv[strTextColumn].ToString(), drv[strIndexColumn].ToString());
                drpBind.Items.Add(li);
                MakeTree(dtNodeSets, strParentColumn, drv[strIndexColumn].ToString(), strIndexColumn, strTextColumn, drpBind, i);
            }
            //递归结束，要回到上一层，所以缩入量减少一个单位 
            i--;
        }


    }
}

