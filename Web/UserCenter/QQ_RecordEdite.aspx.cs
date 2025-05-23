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

namespace Pbzx.Web.UserCenter
{
    public partial class QQ_RecordEdite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGroupID();
                BindData();
            }
        }


        private void BindGroupID()
        {
            Pbzx.BLL.PBnet_QQ_Group groupBll = new Pbzx.BLL.PBnet_QQ_Group();
            this.ddlQQ_GropID.DataSource = groupBll.GetList(" IsEnable=1  order by SortID");
            ddlQQ_GropID.DataTextField = "QQ_GroupName";
            ddlQQ_GropID.DataValueField = "ID";
            ddlQQ_GropID.DataBind();
        }
        private void BindData()
        {
            DataRow row = WebFunc.GetQQLookUser();
            if (row == null)
            {
                Response.Write(JS.Alert("对不起！您没有访问权限！", "User_Center.aspx"));
                return;
            }

            if (row["UserClass"].ToString() == "管理员" || row["UserClass"].ToString() == "超级版主" || row["UserClass"].ToString() == "聊管" || row["UserClass"].ToString() == "版主")
            {
                this.tbEdite.Visible = true;
                this.tbSee.Visible = false;
            }
            else
            {
                Response.Write("<script>alert('对不起！您没有该权限！');history.go(-1);</script>");
                this.tbSee.Visible = true;
                this.tbEdite.Visible = false;
                return;
            }


            Pbzx.Model.PBnet_QQ_Record qqGroupModel;
            Pbzx.BLL.PBnet_QQ_Record qqGroupBll = new Pbzx.BLL.PBnet_QQ_Record();
            string id = Input.FilterAll(Request["ID"]);


            if (!string.IsNullOrEmpty(id))
            {
                qqGroupModel = qqGroupBll.GetModel(int.Parse(id));
                //if (WebFunc.CheckIsGroupManager(WebFunc.GetGroupByID(qqGroupModel.QQ_GropID).QQ_GroupAdmin))
                //{
                //    this.tbEdite.Visible = true;
                //    this.tbSee.Visible = false;
                //}
                //else
                //{
                //    this.tbSee.Visible = true;
                //    this.tbEdite.Visible = false;                    
                //}
                this.lblAction.Text = "修改QQ信息";
                this.ddlQQ_GropID.SelectedValue = qqGroupModel.QQ_GropID.ToString();
                this.lblQQ_GropID.Text = WebFunc.GetGroupByID(qqGroupModel.QQ_GropID).QQ_GroupName;

                txtAddTime.Text = qqGroupModel.AddTime.ToString();
                txtKickOffTime.Text = qqGroupModel.KickOffTime.ToString();
                this.txtaddren.Text = qqGroupModel.KickOffManager;
            }
            else
            {
                this.lblAction.Text = "添加QQ信息";
                this.tbSee.Visible = false;
                qqGroupModel = new Pbzx.Model.PBnet_QQ_Record();
                txtaddren.Text = Method.Get_UserName;
                txtAddTime.Text = DateTime.Now.ToString();
                // txtKickOffTime.Text = DateTime.Now.ToString();

            }
            hfID.Value = qqGroupModel.ID.ToString();

            this.txtQQ_ID.Text = qqGroupModel.QQ_ID;
            this.lblQQ_ID.Text = qqGroupModel.QQ_ID;

            this.lblAddTime.Text = qqGroupModel.AddTime.ToString();
            this.txtUserName.Text = qqGroupModel.UserName;
            this.lblUserName.Text = qqGroupModel.UserName;


            rblOnlineState.SelectedValue = qqGroupModel.OnlineState.ToString();
            this.lblOnlineState.Text = WebFunc.GetQQOnlieState(qqGroupModel.OnlineState);



            this.lblKickOffTime.Text = qqGroupModel.KickOffTime.ToString();

            txtQQ_Detail.Text = qqGroupModel.QQ_Detail;
            this.lblQQ_Detail.Text = qqGroupModel.QQ_Detail;
            this.chbIsLock.Checked = qqGroupModel.IsLock;


            if (qqGroupModel.UpdateManager != "" && qqGroupModel.UpdateManager != null)
            {
                string msgs = "";
                if (qqGroupModel.UpdateManager.Contains("|"))
                {
                    string[] msg = qqGroupModel.UpdateManager.Split('|');

                    for (int i = 0; i < msg.Length - 1; i++)
                    {
                        msgs += "第" + (i + 1) + "次修改的用户：" + msg[i].ToString() + "\r\n";
                    }
                }
                this.txtupdateren.Text = msgs;
            }
        }

        protected void btnBack1_Click(object sender, EventArgs e)
        {
            Response.Redirect("QQ_RecordManager.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            if (txtQQ_ID.Text.Trim() == "")
            {
                strErrMsg += "qq号不能为空.<br/>";
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

            if (rblOnlineState.SelectedValue == "2")
            {
                if (txtQQ_Detail.Text.Trim() == "")
                {
                    strErrMsg += "被踢原因不能为空.<br/>";
                }
            }


            DateTime addTime = DateTime.Now;
            DateTime tcTime = DateTime.Now;


            if (Request["txtAddTime"].Trim() != "")
            {
                if (!DateTime.TryParse(Request["txtAddTime"].Trim(), out addTime))
                {
                    strErrMsg += "加入时间格式不正确.<br/>";
                }
            }

            if (Request["txtKickOffTime"].Trim() != "")
            {
                if (!DateTime.TryParse(Request["txtKickOffTime"].Trim(), out tcTime))
                {
                    strErrMsg += "退出时间格式不正确.<br/>";
                }
            }
            if (txtUserName.Text.Trim() != "")
            {
                int hasUser = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + Input.FilterAll(this.txtUserName.Text.Trim()) + "' "));
                if (hasUser == 0)
                {
                    strErrMsg += "该用户名不存在.<br/>";
                }
            }

            if (strErrMsg != "")
            {
                strErrMsg = "您提交的QQ号信息中存在以下错误:<br/><br/>" + strErrMsg + "<br/>请修改后再重新提交.";

                ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("提示", strErrMsg, 400, "1", "", "", false, false));

                return;
            }
            else
            {
                int id = Convert.ToInt32(hfID.Value);
                Pbzx.BLL.PBnet_QQ_Record qqGroupBll = new Pbzx.BLL.PBnet_QQ_Record();
                Pbzx.Model.PBnet_QQ_Record MyGroup;
                if (id > 0)
                {
                    MyGroup = qqGroupBll.GetModel(id);

                    MyGroup.UpdateManager = MyGroup.UpdateManager + Method.Get_UserName + "  " + DateTime.Now.ToString() + "|"; ;
                }
                else
                {
                    MyGroup = new Pbzx.Model.PBnet_QQ_Record();
                    MyGroup.KickOffManager = Method.Get_UserName;
                    MyGroup.UpdateManager = Method.Get_UserName + "  " + DateTime.Now.ToString() + "|";
                }

                MyGroup.QQ_GropID = int.Parse(this.ddlQQ_GropID.SelectedValue);
                MyGroup.QQ_ID = Input.FilterHTML(this.txtQQ_ID.Text.Replace(" ", "").Trim());

                MyGroup.UserName = Input.FilterAll(this.txtUserName.Text.Replace(" ","").Trim());

                MyGroup.OnlineState = int.Parse(this.rblOnlineState.SelectedValue);

                if (string.IsNullOrEmpty(Request["txtAddTime"].Trim()))
                {
                    MyGroup.AddTime = null;
                }
                else
                {
                    MyGroup.AddTime = Convert.ToDateTime(Request["txtAddTime"].Trim());
                }

                if (string.IsNullOrEmpty(Request["txtKickOffTime"].Trim()))
                {
                    MyGroup.KickOffTime = null;
                }
                else
                {
                    MyGroup.KickOffTime = Convert.ToDateTime(Request["txtKickOffTime"].Trim());
                }




                MyGroup.QQ_Detail = Input.FilterHTML(this.txtQQ_Detail.Text);
                MyGroup.IsLock = this.chbIsLock.Checked;

                if (MyGroup.ID > 0)
                {
                    bool isOK = qqGroupBll.Update(MyGroup);
                    if (isOK)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("QQ_RecordManager.aspx"));
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("qq记录信息修改失败."));
                    }
                }
                else
                {
                    int intCount = Convert.ToInt32(DbHelperSQL.GetSingle("select count(*) from PBnet_QQ_Record where QQ_ID='" + Input.FilterHTML(txtQQ_ID.Text.Trim()) + "' and QQ_GropID=" + this.ddlQQ_GropID.SelectedValue + " "));
                    if (intCount > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("提示", "<br/>该QQ号已经加入了" + this.ddlQQ_GropID.SelectedItem.Text + "群！无法重复添加。<br/>", 420, "1", "", "", false, false));
                        return;
                    }
                    MyGroup.AddManager = Method.Get_UserName;
                    int mynewsID = qqGroupBll.Add(MyGroup);
                    if (this.chbIsLock.Checked && this.txtUserName.Text.Trim() != "")
                    {
                        DbHelperSQLBBS.ExecuteSql("update Dv_User set LockUser=1 where UserName='" + Input.FilterAll(this.txtUserName.Text.Trim()) + "' ");
                    }

                    if (mynewsID > 0)
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "redir", JS.Replace("QQ_RecordManager.aspx"));
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("qq记录信息添加失败."));
                    }
                }

            }
        }

    }
}
