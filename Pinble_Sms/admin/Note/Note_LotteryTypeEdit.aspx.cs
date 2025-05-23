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
using Pbzx.BLL;

namespace Pinble_Market.admin.Note
{
    public partial class Note_LotteryTypeEdit : System.Web.UI.Page
    {
        Note_LotteryType notebll = new Note_LotteryType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTxt();
            }
        }

        private void BindTxt()
        {
            if (Request.QueryString["sid"] != null)
            {
                Pbzx.Model.Note_LotteryType ntype = notebll.GetModel(Convert.ToInt32(Request.QueryString["sid"]));
                if (ntype != null)
                {
                    txtCName.Text = ntype.SName;
                    txtExt.Text = ntype.Explain;
                    txtPriceContent.Text = ntype.PriceContent;
                    if (ntype.Ispublic)
                    {
                        radIspublic.SelectedValue = "1";
                    }
                    else
                    {
                        radIspublic.SelectedValue = "0";
                    }
                    string[] wrk = ntype.IssueWeek.Split(',');

                    for (int i = 0; i < checkisswrk.Items.Count; i++)
                    {
                        for (int j = 0; j < wrk.Length; j++)
                        {
                            if (checkisswrk.Items[i].Value == wrk[j])
                            {
                                checkisswrk.Items[i].Selected = true;
                            }
                        }
                    }
                    txtisstime.Text = ntype.IssueTime;
                }
                btnOk.Text = "修改";
            }
        }
        /// <summary>
        /// 返回列表页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Note_LotteryTypeList.aspx");
        }

        /// <summary>
        /// 点击修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            //判断类型名称非空
            if (txtCName.Text.Trim() == "")
            {

                return;
            }
            //判断设置价格非空
            if (txtPriceContent.Text.Trim() == "")
            {
                return;
            }

            //判断时间是否为空
            if (txtisstime.Text.Trim() == "")
            {
                return;
            }
            string wrk = "";

            for (int i = 0; i < checkisswrk.Items.Count; i++)
            {
                if (checkisswrk.Items[i].Selected)
                {
                    wrk = wrk + checkisswrk.Items[i].Value + ",";
                }
            }
            //判断选择星期不能为空
            if (wrk == "")
            {
                return;
            }

            wrk = wrk.Substring(0, wrk.Length - 1);

            //添加或修改
            if (Request.QueryString["sid"] != null)
            {
                Pbzx.Model.Note_LotteryType ntype = notebll.GetModel(Convert.ToInt32(Request.QueryString["sid"]));
                if (ntype != null)
                {
                    ntype.SName = txtCName.Text.Trim();
                    ntype.Explain = txtExt.Text.Trim();
                    ntype.PriceContent = txtPriceContent.Text.Trim();
                    ntype.UpTime = DateTime.Now;
                    ntype.IssueTime = txtisstime.Text;
                    ntype.IssueWeek = wrk;
                    if (radIspublic.SelectedValue == "1")
                    {
                        ntype.Ispublic = true;
                    }
                    else
                    {
                        ntype.Ispublic = false;
                    }

                    int result = notebll.Update(ntype);

                    if (result != 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改成功');location='Note_LotteryTypeList.aspx';", true);
                    }

                }
            }
            else
            {
                Pbzx.Model.Note_LotteryType ntype = new Pbzx.Model.Note_LotteryType();
                ntype.SName = txtCName.Text.Trim();
                ntype.Explain = txtExt.Text.Trim();
                ntype.PriceContent = txtPriceContent.Text.Trim();
                ntype.BeginTime = DateTime.Now;
                ntype.UpTime = DateTime.Now;
                ntype.IssueTime = txtisstime.Text;
                ntype.IssueWeek = wrk;

                if (radIspublic.SelectedValue == "1")
                {
                    ntype.Ispublic = true;
                }
                else
                {
                    ntype.Ispublic = false;
                }

                int result = notebll.Add(ntype);

                if (result != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "alert('增加成功');location='Note_LotteryTypeList.aspx';", true);
                }
            }

        }
    }
}
