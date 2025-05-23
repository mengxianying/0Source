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
                Response.Write(JS.Alert("�Բ�����û�з���Ȩ�ޣ�", "User_Center.aspx"));
                return;
            }

            if (row["UserClass"].ToString() == "����Ա" || row["UserClass"].ToString() == "��������" || row["UserClass"].ToString() == "�Ĺ�" || row["UserClass"].ToString() == "����")
            {
                this.tbEdite.Visible = true;
                this.tbSee.Visible = false;
            }
            else
            {
                Response.Write("<script>alert('�Բ�����û�и�Ȩ�ޣ�');history.go(-1);</script>");
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
                this.lblAction.Text = "�޸�QQ��Ϣ";
                this.ddlQQ_GropID.SelectedValue = qqGroupModel.QQ_GropID.ToString();
                this.lblQQ_GropID.Text = WebFunc.GetGroupByID(qqGroupModel.QQ_GropID).QQ_GroupName;

                txtAddTime.Text = qqGroupModel.AddTime.ToString();
                txtKickOffTime.Text = qqGroupModel.KickOffTime.ToString();
                this.txtaddren.Text = qqGroupModel.KickOffManager;
            }
            else
            {
                this.lblAction.Text = "���QQ��Ϣ";
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
                        msgs += "��" + (i + 1) + "���޸ĵ��û���" + msg[i].ToString() + "\r\n";
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
                strErrMsg += "qq�Ų���Ϊ��.<br/>";
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
            //    strErrMsg += "qqȺ����Ա����������1��4��֮��.<br/>";
            //}

            if (rblOnlineState.SelectedValue == "2")
            {
                if (txtQQ_Detail.Text.Trim() == "")
                {
                    strErrMsg += "����ԭ����Ϊ��.<br/>";
                }
            }


            DateTime addTime = DateTime.Now;
            DateTime tcTime = DateTime.Now;


            if (Request["txtAddTime"].Trim() != "")
            {
                if (!DateTime.TryParse(Request["txtAddTime"].Trim(), out addTime))
                {
                    strErrMsg += "����ʱ���ʽ����ȷ.<br/>";
                }
            }

            if (Request["txtKickOffTime"].Trim() != "")
            {
                if (!DateTime.TryParse(Request["txtKickOffTime"].Trim(), out tcTime))
                {
                    strErrMsg += "�˳�ʱ���ʽ����ȷ.<br/>";
                }
            }
            if (txtUserName.Text.Trim() != "")
            {
                int hasUser = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + Input.FilterAll(this.txtUserName.Text.Trim()) + "' "));
                if (hasUser == 0)
                {
                    strErrMsg += "���û���������.<br/>";
                }
            }

            if (strErrMsg != "")
            {
                strErrMsg = "���ύ��QQ����Ϣ�д������´���:<br/><br/>" + strErrMsg + "<br/>���޸ĺ��������ύ.";

                ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("��ʾ", strErrMsg, 400, "1", "", "", false, false));

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
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("qq��¼��Ϣ�޸�ʧ��."));
                    }
                }
                else
                {
                    int intCount = Convert.ToInt32(DbHelperSQL.GetSingle("select count(*) from PBnet_QQ_Record where QQ_ID='" + Input.FilterHTML(txtQQ_ID.Text.Trim()) + "' and QQ_GropID=" + this.ddlQQ_GropID.SelectedValue + " "));
                    if (intCount > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), WebFunc.GetGuid(), JS.myAlert1("��ʾ", "<br/>��QQ���Ѿ�������" + this.ddlQQ_GropID.SelectedItem.Text + "Ⱥ���޷��ظ���ӡ�<br/>", 420, "1", "", "", false, false));
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
                        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("qq��¼��Ϣ���ʧ��."));
                    }
                }

            }
        }

    }
}
