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

namespace Pbzx.Web.UserCenter
{
    public partial class QQ_GroupEdite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            DataRow row = WebFunc.GetQQLookUser();
            if(row== null)
            {
                Response.Write(JS.Alert("对不起！您没有访问权限！", "User_Center.aspx"));
                return;
            }

            if (row["UserClass"].ToString() == "管理员" || row["UserClass"].ToString() == "超级版主")
            {
            }
            else
            {
                Response.Write(JS.Alert("对不起！您没有访问权限！", "User_Center.aspx"));
                return;
            }

            Pbzx.Model.PBnet_QQ_Group qqGroupModel ;
            Pbzx.BLL.PBnet_QQ_Group qqGroupBll = new Pbzx.BLL.PBnet_QQ_Group();
            string id = Input.FilterAll(Request["GropID"]);
            
            
            if (!string.IsNullOrEmpty(id))
            {
                qqGroupModel = qqGroupBll.GetModel(int.Parse(id));

                //if (WebFunc.CheckIsGroupManager(qqGroupModel.QQ_GroupAdmin))
                //{
                    this.tbEdite.Visible = true;
                    this.tbSee.Visible = false;                    
                //}
                //else
                //{
                //    this.tbSee.Visible = true;
                //    this.tbEdite.Visible = false;
                //}
                this.lblAction.Text = "修改QQ群信息";

                this.lblAdmin.Text = WebFunc.FormartQQGroupAdmin(qqGroupModel.QQ_GroupAdmin);
                if (qqGroupModel.IsEnable) { this.rblIsEnable.Items[0].Selected = true; } else { this.rblIsEnable.Items[1].Selected = true; }
            }
            else
            {
                this.lblAction.Text = "添加QQ群信息";
                this.tbSee.Visible = false;
                qqGroupModel = new Pbzx.Model.PBnet_QQ_Group();
                rblIsEnable.Items[0].Selected = true;
                int intSortID = Convert.ToInt32(DbHelperSQL.GetSingle("select max(SortID) from PBnet_QQ_Group ")) + 1;
                qqGroupModel.SortID = intSortID;
            }
            hfID.Value = qqGroupModel.ID.ToString();
            this.txtQQ_GroupID.Text = qqGroupModel.QQ_GroupID;
            this.lblQQ_GroupID.Text = qqGroupModel.QQ_GroupID;

            this.txtQQ_GroupName.Text = qqGroupModel.QQ_GroupName;
            lblQQ_GroupName.Text = qqGroupModel.QQ_GroupName;

            rblQQ_GroupType.SelectedValue = qqGroupModel.QQ_GroupType.ToString();
            lblQQ_GroupType.Text =WebFunc.GetQQGroupTypeName(qqGroupModel.QQ_GroupType);

            if(qqGroupModel.IsSoftGroup) 
            {this.rblIsSoftGroup.Items[0].Selected = true;}else{ this.rblIsSoftGroup.Items[1].Selected = true;}
            this.lblIsSoftGroup.Text = qqGroupModel.IsSoftGroup ? "是" : "否";

            //string[] allAdmin = qqGroupModel.QQ_GroupAdmin.Split(new char[] { '|' });
            //for (int i = 0; i < allLanguage.Length; i++)
            //{
            //    foreach (ListItem li in lsbAdmin.Items)
            //    {
            //        if (li.Value == allAdmin[i])
            //        {
            //            li.Selected = true;
            //        }
            //    }
            //}

            txtAdmin.Text = qqGroupModel.QQ_GroupAdmin;


            this.txtDetails.Text = qqGroupModel.QQ_GroupDetails;
            this.lblDetails.Text = qqGroupModel.QQ_GroupDetails;

           
            this.lblIsEnable.Text = qqGroupModel.IsEnable ? "是" : "否";

            this.txtSortID.Text = qqGroupModel.SortID.ToString();
            this.lblSortID.Text = qqGroupModel.SortID.ToString();

        }

        protected void btnBack1_Click(object sender, EventArgs e)
        {
            Response.Redirect("QQ_GroupManager.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (txtQQ_GroupID.Text.Trim() == "")
            {
                strErrMsg += "qq群号不能为空.<br/>";
            }
            if (txtQQ_GroupName.Text.Trim() == "")
            {
                strErrMsg += "qq群名称不能为空.<br/>";
            }

            //StringBuilder sb = new StringBuilder();
            //int count = 0;
            //foreach (ListItem li in lsbAdmin.Items)
            //{
            //    if (li.Selected)
            //    {
            //        sb.Append(li.Value + "|");
            //        count++;
            //    }
            //}
            //if(count == 0 || count > 4)
            //{
            //    strErrMsg += "qq群管理员个数必须在1到4个之间.<br/>";
            //}



            string[] adminSZ = this.txtAdmin.Text.Split(new char[] {'|'});
            if(this.txtAdmin.Text.Trim() == "" || adminSZ.Length > 4)
            {
                strErrMsg += "qq群管理员个数必须在1到4个之间.<br/>";
            }


            if (txtSortID.Text.Trim() == "")
            {
                strErrMsg += "排序编号不能为空.<br/>";
            }
            int sortId = 0;
            if (!int.TryParse(this.txtSortID.Text, out sortId))
            {
                strErrMsg += "排序编号格式不正确.<br/>";
            }

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的QQ群信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.";

                ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("提示", strErrMsg, 400, "1", "", "", false, false));
                return;
            }
            else
            {
                int id = Convert.ToInt32(hfID.Value);
                Pbzx.BLL.PBnet_QQ_Group qqGroupBll = new Pbzx.BLL.PBnet_QQ_Group();
                Pbzx.Model.PBnet_QQ_Group MyGroup;
                if (id > 0)
                {
                    MyGroup = qqGroupBll.GetModel(id);
                }
                else
                {
                    MyGroup = new Pbzx.Model.PBnet_QQ_Group();
                }

                
                MyGroup.QQ_GroupID = Input.FilterHTML(this.txtQQ_GroupID.Text.Trim());
                MyGroup.QQ_GroupName = Input.FilterHTML(txtQQ_GroupName.Text.Trim());
                MyGroup.QQ_GroupType = int.Parse(this.rblQQ_GroupType.SelectedValue);
                if (this.rblIsSoftGroup.Items[0].Selected)
                {
                    MyGroup.IsSoftGroup = true;
                }
                else
                {
                    MyGroup.IsSoftGroup = false;
                }
               
                MyGroup.QQ_GroupAdmin =Input.FilterHTML(this.txtAdmin.Text.Trim());
                MyGroup.QQ_GroupDetails = Input.FilterHTML(this.txtDetails.Text.Trim());
                if (this.rblIsEnable.Items[0].Selected)
                {
                    MyGroup.IsEnable = true;
                }
                else
                {
                    MyGroup.IsEnable = false;
                }
               
                MyGroup.SortID = int.Parse(this.txtSortID.Text.Trim());

                if (MyGroup.ID > 0)
                {
                    bool isOK = qqGroupBll.Update(MyGroup);
                    if (isOK)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("QQ_GroupManager.aspx"));
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("qq群信息修改失败."));
                    }
                }
                else
                {
                    int mynewsID = qqGroupBll.Add(MyGroup);
                    if (mynewsID > 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("QQ_GroupManager.aspx"));
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("qq群信息添加失败."));
                    }
                }

            }
        }
    }
}
