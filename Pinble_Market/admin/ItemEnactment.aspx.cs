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
using Pbzx.BLL;
using Pbzx.Model;
using Pbzx.Common;
using Pinble_Market.AppCod;
using System.Drawing;

namespace Pinble_Market.admin
{
    /// <summary>
    /// 添加新项目
    /// 2010-10-19
    /// </summary>
    public partial class ItemEnactment : System.Web.UI.Page
    {
        Market_TypeManager lotterymanager = new Market_TypeManager();
        Pbzx.BLL.PBnet_UserTable usertypemanager = new Pbzx.BLL.PBnet_UserTable();
        Market_appendItemManager lotteryitemmanager = new Market_appendItemManager();
        Market_NumManager nummanager = new Market_NumManager();
        Pbzx.BLL.Market_BuyInfo buyinfomanager = new Pbzx.BLL.Market_BuyInfo();

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Method.Get_UserName.ToString() == "0")
            {
                Response.Write("<script type='text/javascript'>parent.mainFrame.location.href='../login.aspx'</script>");
                Response.End();
                return;
            }
            //判断用户是否登录是否是高级用户
            if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            {
                Response.Write("<script type='text/javascript' language='javascript' > if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){location='http://www.pinble.com/UserCenter/UserRealInfo.aspx';}else{history.go(-1);}</script>");
                //ClientScript.RegisterStartupScript(this.GetType(), "upscript", "if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){top.location='../UserCenter/UserRealInfo.aspx';}else{history.go(-1);}",true);
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
                //页面数据绑定
                DataBInds();
                //绑定时间
                BindDate();
                //收费模式
                BindSF(Request.QueryString["itemid"]);

                //判断当他不是新增时就是修改，将数据绑定到控件中
                if (Request.QueryString["itemid"] != null)
                {

                    btnresult.Visible = true;
                    string[] sj = Request.QueryString["itemid"].Split(',');
                    Market_appendItem item = lotteryitemmanager.GetModel(Convert.ToInt32(sj[0]));

                    if (item != null)
                    {
                        ddlSofts.SelectedValue = sj[1];
                        ddlxianmoBind();
                        ddlxianmo.SelectedValue = sj[2];
                        ddlSofts.Enabled = false;
                        ddlxianmo.Enabled = false;
                        txtzk.Text = Convert.ToInt32(item.Agio).ToString();
                        txtprice.Text = Convert.ToInt32(item.Price).ToString();
                        ddlsf.SelectedValue = item.Charge.ToString();
                        radbut.SelectedValue = item.On_off.ToString();
                        txtsay.Text = item.Say;
                    }
                }
            }
        }
        /// <summary>
        /// 判断当用户发布期数没满10期，则不许发收费项目
        /// </summary>
        private void BindSF(string sfms)
        {
            sfmsgs.Text = "";
            this.sfms.Visible = false;
            money.Visible = false;

            ddlsf.Items.Clear();
            if (sfms != null)
            {
                string[] sj = Request.QueryString["itemid"].Split(',');
                if (nummanager.GetList("ItemID='" + sj[0] + "'").Tables[0].Rows.Count >= 10)
                {
                    this.sfms.Visible = true;
                    money.Visible = true;
                    ddlsf.Items.Add(new ListItem("免费", "0"));
                    ddlsf.Items.Add(new ListItem("包月收费", "1"));
                }
                else
                {
                    ddlsf.Items.Add(new ListItem("免费", "0"));
                }

                Market_appendItem item = lotteryitemmanager.GetModel(Convert.ToInt32(sj[0]));

                if (item != null)
                {
                    if (item.Charge == 1)
                    {
                        if (buyinfomanager.GetList("issueInfoId='" + sj[0] + "'  and EndTime>= '" + DateTime.Now.ToString() + "'").Tables[0].Rows.Count > 0)
                        {
                            sfmsgs.Text = "(若想修改收费模式，请先锁定此项目。）";
                            ddlsf.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                ddlsf.Items.Add(new ListItem("免费", "0"));
            }
        }

        /// <summary>
        /// 绑定设置时间
        /// </summary>
        private void BindDate()
        {
            ddlDateH.Items.Clear();
            ddlDateY.Items.Clear();
            ddlDateR.Items.Clear();
            ddlDateS.Items.Clear();
            ddlDateF.Items.Clear();
            //绑定年份
            for (int i = 0; i < 5; i++)
            {
                ListItem list = new ListItem();
                list.Text = (DateTime.Now.Year + i).ToString();
                list.Value = (DateTime.Now.Year + i).ToString();
                ddlDateH.Items.Add(list);
            }
            //绑定月份
            for (int i = 1; i < 13; i++)
            {
                ListItem list = new ListItem();
                list.Text = i.ToString();
                list.Value = i.ToString();
                ddlDateY.Items.Add(list);
            }
            //绑定日
            Bindrq();

            //绑定时
            for (int i = 0; i < 24; i++)
            {
                ListItem list = new ListItem();
                if (i < 10)
                {
                    list.Text = "0" + i.ToString();
                    list.Value = "0" + i.ToString();
                }
                else
                {
                    list.Text = i.ToString();
                    list.Value = i.ToString();
                }
                ddlDateS.Items.Add(list);
            }

            //绑定分
            for (int i = 0; i < 60; i++)
            {
                ListItem list = new ListItem();
                if (i < 10)
                {
                    list.Text = "0" + i.ToString();
                    list.Value = "0" + i.ToString();
                }
                else
                {
                    list.Text = i.ToString();
                    list.Value = i.ToString();
                }
                ddlDateF.Items.Add(list);
            }

        }
        /// <summary>
        /// 数据绑定方法
        /// </summary>
        private void DataBInds()
        {
            ddlSoftsBind();

        }
        /// <summary>
        /// 彩种下拉列表绑定方法
        /// </summary>
        private void ddlSoftsBind()
        {
            DataSet daset = DbHelperSQL.Query("SELECT LotteryID FROM Market_Type GROUP BY LotteryID");
            //当数据大于0时
            string ids = "";
            for (int i = 0; i < daset.Tables[0].Rows.Count; i++)
            {
                if (daset.Tables[0].Rows[i]["LotteryID"].ToString() != "")
                {
                    ids = ids + daset.Tables[0].Rows[i]["LotteryID"].ToString() + ",";
                }
            }
            if (ids != "")
            {

                ids = ids.Substring(0, ids.Length - 1);
                ddlSofts.DataSource = DbHelperSQL.Query("SELECT IntId, NvarName FROM PBnet_LotteryMenu WHERE (IntId IN (" + ids + ")) ");

                ddlSofts.DataTextField = "NvarName";
                ddlSofts.DataValueField = "IntId";
                ddlSofts.DataBind();
            }
        }
        /// <summary>
        /// 更改索引后激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSofts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSofts.SelectedValue != "=请选择彩种=")
            {
                ddlxianmoBind();
            }
            else
            {
                ddlxianmo.Items.Clear();
                ddlxianmo.Items.Add(new ListItem("=请选择条件=", "=请选择="));

            }
        }
        /// <summary>
        /// ddl绑定数据
        /// </summary>
        private void ddlxianmoBind()
        {
            labmsgtype.Text = "";
            Pbzx.Model.PBnet_UserTable user = usertypemanager.GetModelName(Method.Get_UserName);
            if (user != null)
            {
                ddlxianmo.Items.Clear();
                ddlxianmo.Items.Add(new ListItem("=请选择条件=", "=请选择="));
                DataSet dast = lotterymanager.GetList("LotteryID='" + ddlSofts.SelectedValue + "'");
                if (dast.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dast.Tables[0].Rows.Count; i++)
                    {
                        if (Request.QueryString["itemid"] != null)
                        {

                            ListItem lm = new ListItem();
                            //lm.Text = ddlSofts.SelectedItem.Text + dast.Tables[0].Rows[i]["TypeName"];
                            lm.Text = dast.Tables[0].Rows[i]["TypeName"].ToString();
                            lm.Value = dast.Tables[0].Rows[i]["Id"].ToString();
                            ddlxianmo.Items.Add(lm);
                        }
                        else
                        {
                            //判断是否已经添加
                            if (lotteryitemmanager.GetList("TypeID=" + dast.Tables[0].Rows[i]["Id"] + " and UserId='" + Method.Get_UserName + "' and On_off <>3").Tables[0].Rows.Count == 0)
                            {
                                ListItem lm = new ListItem();
                                //lm.Text = ddlSofts.SelectedItem.Text + dast.Tables[0].Rows[i]["TypeName"];
                                lm.Text = dast.Tables[0].Rows[i]["TypeName"].ToString();
                                lm.Value = dast.Tables[0].Rows[i]["Id"].ToString();
                                ddlxianmo.Items.Add(lm);
                            }
                        }
                    }
                }
            }

            if (ddlxianmo.Items.Count <= 1)
            {
                labmsgtype.Text = "(此彩种下的条件您已经全部设定，请选择其它彩种！)";
            }
        }
        /// <summary>
        /// 当控件索引改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlsf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsf.SelectedItem.Text == "免费")
            {
                txtprice.Enabled = false;
                txtzk.Enabled = false;
                txtzk.Text = "0";
                txtprice.Text = "免费";
            }
            else
            {
                txtprice.Enabled = true;
                txtzk.Enabled = true;
                txtprice.Text = "1";
            }

        }

        /// <summary>
        /// 确定提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (ddlSofts.SelectedValue == "=请选择=")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('请选择一个彩种！');", true);
                return;
            }
            if (ddlxianmo.SelectedValue == "=请选择=")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('请选择一个项目！');", true);
                return;
            }
            if (txtsay.Text == "" || txtsay.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('请填写项目说明！');", true);
                return;
            }

            if (ddlxianmo.SelectedValue == "无最新项目" || ddlxianmo.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('“" + ddlSofts.SelectedItem.Text + "”暂时没有最新的项目发布！请随时留意我们的pinble论坛！');", true);
                return;
            }
            if (txtsay.Text.Length > 100)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('“介绍中最多只能填写100个字符！”');", true);
                return;
            }

            if (Input.Htmls(txtsay.Text) == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('“介绍中含有特殊符号或攻击性的脚本！”');", true);
                return;
            }

           
            if (ddlsf.SelectedValue != "0")
            {
                //判断价格输入是否正确
                int price1 = 0;
                if (!int.TryParse(txtprice.Text, out price1))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('价格填写不正确！');", true);
                    return;
                }

                //判断折扣输入是否正确
                int zk = 0;
                if (!int.TryParse(txtzk.Text, out zk))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('折扣填写不正确！');", true);
                    return;
                }
                if (price1 <= 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('价格不能小于或等于￥0！');", true);
                    return;
                }
                if (price1 < 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('价格不能小于或等于￥0！');", true);
                    return;
                }
                if (zk < 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('折扣填写不正确！');", true);
                    return;
                }
            }
            Pbzx.Model.PBnet_UserTable user = usertypemanager.GetModelName(Method.Get_UserName);
            if (user != null)
            {

                Market_appendItem lotteryitem = new Market_appendItem();

                //项目类型ID

                lotteryitem.TypeID = Convert.ToInt32(ddlxianmo.SelectedValue);
                //当前用户名
                //lotteryitem.UserId = user.Id;
                lotteryitem.UserId = Method.Get_UserName.ToString();
                //收费模式
                lotteryitem.Charge = Convert.ToInt32(ddlsf.SelectedValue);
                if (lotteryitem.Charge != 0)
                {
                    //价格
                    lotteryitem.Price = Convert.ToDecimal(txtprice.Text);
                    //折扣
                    lotteryitem.Agio = Convert.ToDecimal(txtzk.Text);
                }
                else
                {
                    //价格
                    lotteryitem.Price = 0;
                    //折扣
                    lotteryitem.Agio = 0;
                }
                //off-on 设置是否开放
                lotteryitem.On_off = Convert.ToInt32(radbut.SelectedValue);
                //介绍
                lotteryitem.Say = txtsay.Text;

                //当前时间
                lotteryitem.Time = DateTime.Now;

                //发布时间
                if (rdbtfabu.SelectedValue == "0")
                    lotteryitem.IssueTime = DateTime.Now.ToString();
                else
                    lotteryitem.IssueTime = ddlDateH.SelectedValue + "-" + ddlDateY.SelectedValue + "-" + ddlDateR.SelectedValue + " " + ddlDateS.SelectedValue + ":" + ddlDateF.SelectedValue + ":00";

                //推荐设置
                lotteryitem.Commend = Convert.ToInt32(rdbttuijian.SelectedValue);

                //默认为正常项目
                lotteryitem.State = 0;


                //是否限制查看人数
                if (rdbtnlenght.SelectedValue == "0")
                    lotteryitem.Confine = 0;
                else
                    lotteryitem.Confine = Convert.ToInt32(txtxz.Text);
                //执行修改操作
                if (Request.QueryString["itemid"] != null)
                {
                    string[] sj = Request.QueryString["itemid"].Split(',');
                    lotteryitem.appendID = Convert.ToInt32(sj[0]);
                    if (lotteryitemmanager.Update(lotteryitem) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('修改成功！');location='Market_ItemManage.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('修改失败！');", true);
                    }
                }
                else
                {
                    if (lotteryitemmanager.Add(lotteryitem) > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('添加成功！');location='Market_ItemManage.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('添加失败！');", true);
                    }
                }
            }
        }

        /// <summary>
        /// 设置发布时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdbtfabu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbtfabu.SelectedValue == "0")
            {
                txtDate.Visible = false;
            }
            else
            {
                ddlDateY.SelectedValue = DateTime.Now.Month.ToString();
                ddlDateR.SelectedValue = (DateTime.Now.Day + 1).ToString();
                txtDate.Visible = true;
            }
        }
        /// <summary>
        /// 根据选择的月份来判断每个月的天数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDateY_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bindrq();
        }
        /// <summary>
        /// 绑定日期的方法
        /// </summary>
        private void Bindrq()
        {
            ddlDateR.Items.Clear();
            //绑定日期
            if (Convert.ToInt32(ddlDateY.SelectedValue) % 2 != 0)
            {
                for (int i = 1; i < 31; i++)
                {
                    ListItem list = new ListItem();
                    list.Text = i.ToString();
                    list.Value = i.ToString();
                    ddlDateR.Items.Add(list);
                }
            }
            else
            {

                if (ddlDateY.SelectedValue == "2")
                {
                    for (int i = 1; i < 29; i++)
                    {
                        ListItem list = new ListItem();
                        list.Text = i.ToString();
                        list.Value = i.ToString();
                        ddlDateR.Items.Add(list);
                    }
                }
                else
                {
                    for (int i = 1; i < 32; i++)
                    {
                        ListItem list = new ListItem();
                        list.Text = i.ToString();
                        list.Value = i.ToString();
                        ddlDateR.Items.Add(list);
                    }
                }
            }
        }
        /// <summary>
        /// 判断是否限制他的访问人数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rdbtnlenght_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbtnlenght.SelectedValue == "0")
            {
                Div2.Visible = false;
            }
            else
            {
                Div2.Visible = true;
            }
        }
        /// <summary>
        /// 点击返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnresult_Click(object sender, EventArgs e)
        {
            Response.Redirect("Market_ItemManage.aspx");
        }
        /// <summary>
        /// 更改索引激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void radbut_SelectedIndexChanged(object sender, EventArgs e)
        {
            string radnumber = radbut.SelectedValue;
            if (radnumber == "0")
            {
                labstatusmsg.Text = "(开放期，发布后其他用户可以订购此项目！)";
                labstatusmsg.ForeColor = Color.Green;
            }
            else if (radnumber == "1")
            {
                labstatusmsg.Text = "(提示：锁定后其他用户将无法订购此的项目！)";
                labstatusmsg.ForeColor = Color.Red;
            }
            else
            {
                labstatusmsg.Text = "(提示：关闭后，将终止对外此项目的服务！)";
                labstatusmsg.ForeColor = Color.Red;
            }

        }

    }
}
