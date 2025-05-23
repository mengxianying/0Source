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
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class US_softpost_Editor : System.Web.UI.Page
    {
        protected string boardValue = "";
        protected string[] MinTopics = new string[8];
        protected string[] MinAnncounts = new string[8];
        protected string[] MinDays = new string[8];
        protected string[] MinBests = new string[8];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindList();
                DataSet dsBoard = DbHelperSQLBBS.Query("select boardid,BoardType from Dv_Board ");
                this.dlBMXX.DataSource = dsBoard;
                this.dlBMXX.DataBind();

                if (!string.IsNullOrEmpty(Request["ID"]))
                {
                    Pbzx.BLL.CN_Software softwareBll = new Pbzx.BLL.CN_Software();
                    List<Pbzx.Model.CN_Software> ls = softwareBll.GetModelList(" ID='" + Input.FilterAll(Request["ID"]) + "' ");
                    ViewState["boardValue"] = ls[0].Boards;
                    MinTopics = ls[0].MinTopics.Split(new char[] { '|' });
                    MinAnncounts = ls[0].MinAnncounts.Split(new char[] { '|' });
                    MinDays = ls[0].MinDays.Split(new char[] { '|' });
                    MinBests = ls[0].MinBests.Split(new char[] { '|' });
                    Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
                    string[] result = softBLL.Chksettype(ls[0].SoftwareType, ls[0].InstallType);
                    lblName.Text = result[0] + "(" + result[1] + ")";

                    this.upSoftType.Visible = false;
                    boardValue = ls[0].Boards;
                    this.txtLottery.Text = ls[0].Lottery;
                    this.txtLotteryID.Text = ls[0].LotteryID.ToString();
                    if (ls[0].Flag == 0)
                    {
                        rblFlag.Items[0].Selected = true;
                    }
                    else
                    {
                        rblFlag.Items[1].Selected = true;
                    }
                    if (ls[0].Status == 0)
                    {
                        rblStatus.Items[0].Selected = true;
                    }
                    else
                    {
                        rblStatus.Items[1].Selected = true;
                    }
                }
                else
                {
                    this.lblName.Visible = false;
                    ViewState["boardValue"] = "--";
                    boardValue = "--";
                }
            }
        }


        private void BindList()
        {
            Pbzx.BLL.CstSoftware softwareBLL = new Pbzx.BLL.CstSoftware();
            softwareBLL.BindSoftwareType(this.ddlSoftwareType);
            //ddlSoftwareType.Attributes.Add("onChange", "SoftwareTypeChange('" + ddlSoftwareType.ClientID + "','" + ddlInstallType.ClientID + "',this.value);");

        }
        protected void ddlSoftwareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pbzx.BLL.CstSoftware softwareBll = new Pbzx.BLL.CstSoftware();
            softwareBll.GetInstallTypes(this.ddlSoftwareType.SelectedItem.Text, this.ddlInstallType);
        }



        protected string showBoards(object boardid, object BoardType)
        {
            string result = "";

            if (ViewState["boardValue"] == null)
            {
                if (!string.IsNullOrEmpty(Request["ID"]))
                {
                    Pbzx.BLL.CN_Software softwareBll = new Pbzx.BLL.CN_Software();
                    List<Pbzx.Model.CN_Software> ls = softwareBll.GetModelList(" ID='" + Input.FilterAll(Request["ID"]) + "' ");
                    this.upSoftType.Visible = false;
                    boardValue = ls[0].Boards;
                    ViewState["boardValue"] = ls[0].Boards;
                }
                else
                {
                    this.lblName.Visible = false;
                    boardValue = "--";
                    ViewState["boardValue"] = "--";
                }
            }

            string temp = WebFunc.CheckBBsBoardValue(ViewState["boardValue"].ToString(), boardid.ToString());
            //bool isHas = DbHelperSQL.Exists("select count(1) from PBnet_tpman where Master_Name='" + ViewState["currentUser"].ToString() + "' and charindex('" + Method.AdminPowerSettingFormart(id) + "',Setting) > 0 ");
            if (temp == "checked")
            {
                result += "<input type=\"checkbox\" name=\"US_softpost_Editor.aspx\" value=\"" + boardid + "\" checked=\"checked\" /> " + BoardType.ToString();
            }
            else
            {
                result += "<input type=\"checkbox\" name=\"US_softpost_Editor.aspx\" value=\"" + boardid + "\" /> " + BoardType.ToString();
            }
            return result;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.CN_Software softwareBll = new Pbzx.BLL.CN_Software();
            string[] result = EnCodePower();
            if (!string.IsNullOrEmpty(Request["ID"]))
            {

                List<Pbzx.Model.CN_Software> ls = softwareBll.GetModelList(" ID='" + Input.FilterAll(Request["ID"]) + "' ");
                ls[0].Boards = result[0];
                if (rblFlag.Items[0].Selected)
                {
                    ls[0].Flag = 0;
                }
                else
                {
                    ls[0].Flag = 1;
                }
                ls[0].Lottery = this.txtLottery.Text;
                ls[0].LotteryID = Convert.ToInt32(this.txtLotteryID.Text);
                ls[0].MinTopics = result[1];
                ls[0].MinAnncounts = result[2];
                ls[0].MinDays = result[3];
                ls[0].MinBests = result[4];
                ls[0].Status = rblStatus.Items[0].Selected ? 0 : 2;
                softwareBll.Update(ls[0]);
                Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                Pbzx.Model.CN_Software model = new Pbzx.Model.CN_Software();
                model.Boards = result[0];
                if (rblFlag.Items[0].Selected)
                {
                    model.Flag = 0;
                }
                else
                {
                    model.Flag = 1;
                }
                model.Lottery = this.txtLottery.Text;
                model.LotteryID = Convert.ToInt32(this.txtLotteryID.Text);
                model.MinTopics = result[1];
                model.MinAnncounts = result[2];
                model.MinDays = result[3];
                model.MinBests = result[4];
                model.Status = rblStatus.Items[0].Selected ? 0 : 2;
                model.InstallType = int.Parse(this.ddlInstallType.SelectedValue);
                //
                object objST = DbHelperSQL1.GetSingle("Select top 1 SoftwareType from [CstSoftware] where SoftwareName='" + this.ddlSoftwareType.SelectedValue + "' ");
                model.SoftwareType = int.Parse(objST.ToString());
                softwareBll.Add(model);
                Response.Write("<script>alert('添加成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
        }

        /// <summary>
        /// 得到input值
        /// </summary>
        /// <returns></returns>
        private string[] EnCodePower()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbMinTopics = new StringBuilder();
            StringBuilder sbMinAnncounts = new StringBuilder();
            StringBuilder sbMinDays = new StringBuilder();
            StringBuilder sbMinBests = new StringBuilder();

            foreach (string str in Request.Form)
            {
                string tmpstr = str.ToLower();
                if (tmpstr.IndexOf(".aspx") != -1)
                {
                    string[] res = Request.Form.GetValues(str);
                    string strtemp1 = "";

                    foreach (string strTemp in res)
                    {
                        strtemp1 += strTemp + "|";
                    }

                    if (strtemp1 != "")
                    {
                        // sb.Append(strtemp1.Substring(0, strtemp1.Length - 1));
                        sb.Append(strtemp1);
                    }

                }
            }
            string dsUserType = Maticsoft.DBUtility.DbHelperSQL1.GetSingle("Select ConfigValue From CN_Config Where ConfigName = 'AllPostUserType' ").ToString();

            string[] dsUserTypeSZ = dsUserType.Split(new char[] { '|' });

            string mintopics1 = "";
            string minanncounts1 = "";
            string mindays1 = "";
            string minbests1 = "";
            for (int i = 0; i < dsUserTypeSZ.Length - 1; i++)
            {
                if (dsUserTypeSZ.Length > 0)
                {
                    mintopics1 += Request.Form["MinTopics" + i.ToString()] + "|";
                    minanncounts1 += Request.Form["MinAnncounts" + i.ToString()] + "|";
                    mindays1 += Request.Form["MinDays" + i.ToString()] + "|";
                    minbests1 += Request.Form["MinBests" + i.ToString()] + "|";

                }
            }
            if (mintopics1 != "")
            {
                //   sbMinTopics.Append(mintopics1.Substring(0, mintopics1.Length - 1));
                sbMinTopics.Append(mintopics1);
            }
            if (minanncounts1 != "")
            {
                //   sbMinAnncounts.Append(minanncounts1.Substring(0, minanncounts1.Length - 1));
                sbMinAnncounts.Append(minanncounts1);
            }
            if (mindays1 != "")
            {
                //    sbMinDays.Append(mindays1.Substring(0, mindays1.Length - 1));
                sbMinDays.Append(mindays1);
            }
            if (minbests1 != "")
            {
                //    sbMinBests.Append(minbests1.Substring(0, minbests1.Length - 1));
                sbMinBests.Append(minbests1);
            }
            string[] result = new string[] { sb.ToString(), sbMinTopics.ToString(), sbMinAnncounts.ToString(), sbMinDays.ToString(), sbMinBests.ToString() };

            return result;
        }


    }
}
