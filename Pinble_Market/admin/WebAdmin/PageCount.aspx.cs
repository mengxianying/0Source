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
using System.Xml;
using Pbzx.Common;

namespace Pinble_Market.admin.WebAdmin
{
    public partial class PageCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTxt();
                //商户发布项目默认数据绑定
                BindSH();
                //绑定3D
                grid3d.DataSource = Input.GetCP("CP3D");
                grid3d.DataBind();
                //绑定七彩乐
                GridView2.DataSource = Input.GetCP("CP七乐彩");
                GridView2.DataBind();
                GridView3.DataSource = Input.GetCP("CP七星彩");
                GridView3.DataBind();
                GridView4.DataSource = Input.GetCP("CP双色球");
                GridView4.DataBind();
                GridView5.DataSource = Input.GetCP("CP排列五");
                GridView5.DataBind();
                GridView6.DataSource = Input.GetCP("CP大乐透");
                GridView6.DataBind();
                GridView7.DataSource = Input.GetCP("CP22选5");
                GridView7.DataBind();
                GridView8.DataSource = Input.GetCP("CP31选7");
                GridView8.DataBind();
            }
        }
        /// <summary>
        /// 绑定商户默认配置
        /// </summary>
        private void BindSH()
        {
            txtbegmomery.Text = Input.GetValue("SmallMoney");
            txtendmomery.Text = Input.GetValue("BigMoney");
            txtticheng.Text = Input.GetValue("Ticheng");
            rdoistop.SelectedValue = Input.GetValue("Sign");
            rdoistuijian.SelectedValue = Input.GetValue("Recommend");
            rdoisoff.SelectedValue = Input.GetValue("On_Off");
        }

        private void BindTxt()
        {
            txtprice.Text = Input.GetPrice();
            txtwebcount.Text = Input.GetCount();
            txtmanagecount.Text = Input.GetManageCount();
        }

        /// <summary>
        /// 点击保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                //判断是添加什么类型限定
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/MarketConfig.xml"));

                //得到根节点
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("webPage")[0];
                    XmlNode haha1 = root.SelectNodes("Price")[0];
                    XmlNode txtmanage = root.SelectNodes("webPageManage")[0];
                    //得到他的ID
                    haha.SelectSingleNode("@value").Value = txtwebcount.Text;
                    haha1.SelectSingleNode("@value").Value = txtprice.Text;
                    txtmanage.SelectSingleNode("@value").Value = txtmanagecount.Text;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/MarketConfig.xml"));
                }
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！');</script>");
                return;
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败！');</script>");
                return;
            }
        }

        /// <summary>
        /// 3d生成事件激发时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid3d_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "BJ")
            {
                Response.Redirect("AddLottory.aspx?number=" + e.CommandArgument);
            }
            else if (e.CommandName == "DE")
            {
                string[] sz = e.CommandArgument.ToString().Split(',');
                string lootroy = sz[0];
                string number = sz[1];
                if (lootroy != "" && number != "")
                {
                    DeleteXML(number, lootroy);
                    Response.Redirect("PageCount.aspx");
                }
            }
        }

        /// <summary>
        /// 删除公用方法
        /// </summary>
        /// <param name="e"></param>
        /// <param name="lj"></param>
        private static bool DeleteXML(string number1, string lootroy)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/LottoryCondition.xml"));
                //得到根节点
                XmlElement root = doc.DocumentElement;

                if (root.ChildNodes.Count > 0)
                {
                    XmlNode haha = root.SelectNodes("CP" + lootroy)[0];
                    //为修改

                    for (int i = 0; i < haha.ChildNodes.Count; i++)
                    {
                        XmlNode haha1 = haha.SelectNodes("chi")[i];
                        string number = haha1.SelectSingleNode("@number").Value;
                        if (number == number1)
                        {
                            haha.RemoveChild(haha1);
                        }
                    }
                }
                doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/LottoryCondition.xml"));
                return false;
            }
            catch
            {
                return true;

            }
        }

        /// <summary>
        /// 编辑连接拼接
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bj"></param>
        /// <param name="bj2"></param>
        /// <returns></returns>
        public string BindBJ(object obj, object bj, object bj2)
        {
            return bj.ToString() + "&itemname=" + bj2 + "&lottoryname=" + obj;
        }

        /// <summary>
        /// 删除连接拼接
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bj"></param>
        /// <param name="bj2"></param>
        /// <returns></returns>
        public string BindDE(object ob, object bj2)
        {
            return ob.ToString() + "," + bj2.ToString();
        }

        /// <summary>
        /// 点击添加3D项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbut3D_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=3D");
        }
        /// <summary>
        /// 点击添加七星彩项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbutqxc_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=七星彩");
        }
        /// <summary>
        /// 点击添加排列5项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbutplw_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=排列五");
        }
        /// <summary>
        /// 点击添加22选5项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbut22x5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=22选5");
        }
        /// <summary>
        /// 点击添加七乐彩项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbutqlc_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=七乐彩");
        }
        /// <summary>
        /// 点击添加双色球项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbutssq_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=双色球");
        }
        /// <summary>
        /// 点击添加大乐透项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbutdlt_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=大乐透");
        }
        /// <summary>
        /// 点击添加31选7项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbut31xq7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=31选7");
        }
        /// <summary>
        /// 行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid3d_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.Cells[2].FindControl("LinkButton1") as LinkButton).Attributes.Add("onclick", "javascript: return confirm('真的确定要删除“" + e.Row.Cells[1].Text + "”吗！');");
                e.Row.Attributes.Add("onmouseover", "curr=this.style.backgroundColor; this.style.backgroundColor='#A6FFFF';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=curr");
            }
        }
        /// <summary>
        /// 点击保存商户默认设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnokSH_Click(object sender, EventArgs e)
        {
            Input.SetValue("SmallMoney", txtbegmomery.Text);
            Input.SetValue("BigMoney", txtendmomery.Text);
            Input.SetValue("Ticheng", txtticheng.Text);
            Input.SetValue("On_Off", rdoisoff.SelectedValue);
            Input.SetValue("Sign", rdoistop.SelectedValue);
            Input.SetValue("Recommend", rdoistuijian.SelectedValue);
        }


    }
}
