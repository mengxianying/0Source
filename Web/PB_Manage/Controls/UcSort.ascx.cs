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
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage.Controls
{
    public partial class UcSort : System.Web.UI.UserControl
    {
        

        /// <summary>
        /// 表名称
        /// </summary>
        private string _tbName = "";

        public string TbName
        {
            get { return _tbName; }
            set { _tbName = value; }
        }

        /// <summary>
        /// 主键
        /// </summary>
        private string _primaryKey = "";

        public string PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }

        /// <summary>
        /// 显示列名
        /// </summary>
        private string _colName;

        public string ColName
        {
            get { return _colName; }
            set { _colName = value; }
        }

        /// <summary>
        /// 排序编号
        /// </summary>
        private string _sortID;

        public string SortID
        {
            get { return _sortID; }
            set { _sortID = value; }
        }

        /// <summary>
        /// 列名二名称
        /// </summary>
        private string _colName2="";

        public string ColName2
        {
            get { return _colName2; }
            set { _colName2 = value; }
        }


        private string _strWhere;

        public string StrWhere
        {
            get { return _strWhere; }
            set { _strWhere = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["TbName"] != null)
            {
                TbName = Request["TbName"];
            }
            if (Request["PrimaryKey"] != null)
            {
                PrimaryKey = Request["PrimaryKey"];
            }
            if (Request["ColName"] != null)
            {
                ColName = Request["ColName"];
            }
            if (Request["ColName2"] != null)
            {
                ColName2 = Request["ColName2"];
            }
            if (Request["SortID"] != null)
            {
                SortID = Request["SortID"];
            }
            if (Request["StrWhere"] != null)
            {
                StrWhere = Request["StrWhere"];
            }
            if (!Page.IsPostBack)
            {
                if (ViewState["TbName"] == null)
                {
                    ViewState["TbName"] = TbName;
                }
                if (ViewState["PrimaryKey"] == null)
                {
                    ViewState["PrimaryKey"] = PrimaryKey;
                }
                if (ViewState["ColName"] == null)
                {
                    ViewState["ColName"] = ColName;
                }
                if (ViewState["ColName2"] == null)
                {
                    ViewState["ColName2"] = ColName2;
                }
                if (ViewState["SortID"] == null)
                {
                    ViewState["SortID"] = SortID;
                }
                if (ViewState["StrWhere"] == null)
                {
                    ViewState["StrWhere"] = StrWhere;
                }
                BindData();
              
            }

        }

        private void BindData()
        { 
                try
                {                    
                    DataSet dsProducts = DbHelperSQL.Query("select " + ViewState["PrimaryKey"].ToString() + "," + ViewState["ColName"].ToString() + "," + ViewState["ColName2"].ToString() + "," + ViewState["SortID"].ToString() + " from " + ViewState["TbName"].ToString() + " where 1=1 " + ViewState["StrWhere"].ToString() + " order by " + ViewState["SortID"].ToString() + "  ");
                    if (!(dsProducts.Tables.Count > 0 && dsProducts.Tables[0].Rows.Count > 0))
                    {
                        lblMsg.Text = "排序内容当前为空！";
                    }
                    //设置datakey
                    string[] keys = new string[] { };
                    ArrayList listKey = new ArrayList();
                    listKey.Add(ViewState["PrimaryKey"].ToString());
                    listKey.Add(ViewState["ColName"].ToString());
                    listKey.Add(ViewState["ColName2"].ToString());
                    listKey.Add(ViewState["SortID"].ToString());
                    
                    keys = (string[])listKey.ToArray(typeof(string)); // 转换成Type类型数组
                    MyGridView.DataKeyNames = keys;

                    this.MyGridView.DataSource = dsProducts;
                    this.MyGridView.DataBind();
                }
                catch(Exception ex)
                {
                    Response.Write(JS.Alert("请确保表名、列名、和排序编号列名正确无误！"));
                    return;
                }                       
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;             
                e.Row.Cells[0].Text = id.ToString();
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (ViewState["ColName2"].ToString() == "")
                {
                    e.Row.Cells[2].Visible = false;
                }
                else
                {
                    e.Row.Cells[2].Visible = true;
                }
                string curPK = MyGridView.DataKeys[e.Row.RowIndex].Values[ViewState["PrimaryKey"].ToString()].ToString();
                string curColName = MyGridView.DataKeys[e.Row.RowIndex].Values[ViewState["ColName"].ToString()].ToString();
                string curColName2 = MyGridView.DataKeys[e.Row.RowIndex].Values[ViewState["ColName2"].ToString()].ToString();
                string curSortID = MyGridView.DataKeys[e.Row.RowIndex].Values[ViewState["SortID"].ToString()].ToString();
                DropDownList ddlUp = (DropDownList)e.Row.Cells[4].FindControl("ddlUP");

                DropDownList ddlDown = (DropDownList)e.Row.Cells[5].FindControl("ddlDown");

                string sql1 = "select " + ViewState["PrimaryKey"].ToString() + "," + ViewState["ColName"].ToString() + "," + ViewState["ColName2"].ToString() + "," + ViewState["SortID"].ToString() + " from " + ViewState["TbName"].ToString() + "  where 1=1 " + ViewState["StrWhere"].ToString() + "  and " + ViewState["SortID"].ToString() + "<'" + curSortID + "'  order by " + ViewState["SortID"].ToString() + "  ";
                string sql2 = "select " + ViewState["PrimaryKey"].ToString() + "," + ViewState["ColName"].ToString() + "," + ViewState["ColName2"].ToString() + "," + ViewState["SortID"].ToString() + " from " + ViewState["TbName"].ToString() + "  where 1=1 " + ViewState["StrWhere"].ToString() + " and " + ViewState["SortID"].ToString() + ">'" + curSortID + "' order by " + ViewState["SortID"].ToString() + "  ";

                DataSet dsUP = DbHelperSQL.Query(sql1);
                DataSet dsDown = DbHelperSQL.Query(sql2);

                if (dsUP.Tables.Count > 0 && dsUP.Tables[0].Rows.Count > 0)
                {
                    ddlUp.Visible = true;
                    for (int i = 1; i <= dsUP.Tables[0].Rows.Count;i++ )
                    {
                        DataRow tempRow = dsUP.Tables[0].Rows[i-1];
                        ddlUp.Items.Add(new ListItem("上移" + i, curPK + "&" + curSortID + "&" + i));
                    }
                    ddlUp.Items.Insert(0, new ListItem("上移",""));
                }
                else
                {
                    ddlUp.Visible = false;
                }

                if (dsDown.Tables.Count > 0 && dsDown.Tables[0].Rows.Count > 0)
                {
                    ddlDown.Visible = true;
                    for (int i = 1; i <= dsDown.Tables[0].Rows.Count; i++)
                    {
                        DataRow tempRow = dsDown.Tables[0].Rows[i - 1];
                        ddlDown.Items.Add(new ListItem("下移" + i, curPK +"&"+ curSortID + "&" + i));
                    }
                    ddlDown.Items.Insert(0, new ListItem("下移", ""));
                }
                else
                {
                    ddlDown.Visible = false;
                }
            }  
        }

        protected void ddlUP_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlUp = (DropDownList)sender;
            if (ddlUp.SelectedValue != "")
            {
                string[] curSortIDs = ddlUp.SelectedValue.Split(new char[] { '&' });
                int result = Convert.ToInt32(curSortIDs[1]) - Convert.ToInt32(curSortIDs[2]);

                string tempSql = "select " + ViewState["PrimaryKey"].ToString() + "," + ViewState["ColName"].ToString() + "," + ViewState["ColName2"].ToString() + "," + ViewState["SortID"].ToString() + " from " + ViewState["TbName"].ToString() + " where 1=1 " + ViewState["StrWhere"].ToString() + " and  " + ViewState["SortID"].ToString() + " >='" + result + "' and " + ViewState["SortID"].ToString() + "<'" + curSortIDs[1] + "' order by " + ViewState["SortID"].ToString() + "  ";
                DataSet ds = DbHelperSQL.Query(tempSql);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        DbHelperSQL.ExecuteSql("update  " + ViewState["TbName"].ToString() + "  set " + ViewState["SortID"].ToString() + "='" + Convert.ToSingle(1 + Convert.ToInt32(row[ViewState["SortID"].ToString()])) + "' where 1=1 " + ViewState["StrWhere"].ToString() + " and " + ViewState["PrimaryKey"].ToString() + "='" + row[ViewState["PrimaryKey"].ToString()] + "' ");
                    }
                    
                }
                string sql1 = "update  " + ViewState["TbName"].ToString() + "  set " + ViewState["SortID"].ToString() + "='" + result + "' where 1=1 " + ViewState["StrWhere"].ToString() + " and " + ViewState["PrimaryKey"].ToString() + "='" + curSortIDs[0] + "' ";
                
                DbHelperSQL.ExecuteSql(sql1);
                BindData();
            }
        }

        protected void ddlDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlDown = (DropDownList)sender;
            if(ddlDown.SelectedValue != "")
            {
                string[] curSortIDs = ddlDown.SelectedValue.Split(new char[] { '&' });
                int result = Convert.ToInt32(curSortIDs[1]) + Convert.ToInt32(curSortIDs[2]);


                string tempSql = "select " + ViewState["PrimaryKey"].ToString() + "," + ViewState["ColName"].ToString() + "," + ViewState["ColName2"].ToString() + "," + ViewState["SortID"].ToString() + " from " + ViewState["TbName"].ToString() + " where 1=1 " + ViewState["StrWhere"].ToString() + " and  " + ViewState["SortID"].ToString() + " >'" + curSortIDs[1] + "' and " + ViewState["SortID"].ToString() + "<='" + result + "' order by " + ViewState["SortID"].ToString() + "  ";
                DataSet ds = DbHelperSQL.Query(tempSql);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DbHelperSQL.ExecuteSql("update  " + ViewState["TbName"].ToString() + "  set " + ViewState["SortID"].ToString() + "='" + Convert.ToSingle(Convert.ToInt32(row[ViewState["SortID"].ToString()]) - 1) + "' where 1=1 " + ViewState["StrWhere"].ToString() + " and " + ViewState["PrimaryKey"].ToString() + "='" + row[ViewState["PrimaryKey"].ToString()] + "' ");
                    }
                }
                string sql1 = "update  " + ViewState["TbName"].ToString() + "  set " + ViewState["SortID"].ToString() + "='" + result + "' where 1=1 " + ViewState["StrWhere"].ToString() + " and " + ViewState["PrimaryKey"].ToString() + "='" + curSortIDs[0] + "' "; 
                DbHelperSQL.ExecuteSql(sql1);
                BindData();               
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsProducts = DbHelperSQL.Query("select " + ViewState["PrimaryKey"].ToString() + "," + ViewState["ColName"].ToString() + "," + ViewState["ColName2"].ToString() + "," + ViewState["SortID"].ToString() + " from " + ViewState["TbName"].ToString() + " where 1=1 " + ViewState["StrWhere"].ToString() + " order by " + ViewState["SortID"].ToString() + "  ");

                if (!(dsProducts.Tables.Count > 0 && dsProducts.Tables[0].Rows.Count > 0))
                {
                    lblMsg.Text = "排序内容当前为空！";
                    return;
                }
                for (int i = 0; i < dsProducts.Tables[0].Rows.Count;i++ )
                {
                    DbHelperSQL.ExecuteSql(" update  " + ViewState["TbName"].ToString() + "  set " + ViewState["SortID"].ToString() + "='" + Convert.ToString(i + 1) + "' where 1=1 " + ViewState["StrWhere"].ToString() + " and " + ViewState["PrimaryKey"].ToString() + "='" + dsProducts.Tables[0].Rows[i][ViewState["PrimaryKey"].ToString()] + "' ");
                }
                BindData();
            }
            catch (Exception ex)
            {
                Response.Write(JS.Alert("请确保表名、列名、和排序编号列名正确无误！"));
                return;
            }   
        }
    }
}