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
using Pbzx.Model;
using Pbzx.Common;
using Pinble_Market.AppCod;
using System.Xml;

namespace Pinble_Market.admin
{
    public partial class AddItemsort : System.Web.UI.Page
    {
        Pbzx.BLL.PBnet_LotteryMenu mey = new Pbzx.BLL.PBnet_LotteryMenu();
        Market_Type lotterytype = new Market_Type();
        Market_TypeConfigure lotterytypeconfigure = new Market_TypeConfigure();
        Market_TypeManager serverType = new Market_TypeManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            ////判断用户是否登录是否是高级用户
            //if (!WebFunc.CheckIsAdvanceUser(Method.Get_UserName))
            //{
            //    Response.Write("<script type='text/javascript' language='javascript' > if (confirm('只有高级用户才能使用此项功能，现在申请吗？')){top.location='../UserCenter/UserRealInfo.aspx';}</script>");
            //    Response.End();
            //    return;

            //}
            if (!IsPostBack)
            {
                BindLoad();
            }
        }
        /// <summary>
        /// 给定他默认绑定
        /// </summary>
        private void BindLoad()
        {
            DdtList.Items.Add(new ListItem("--请选择--", "--请选择--"));

            DdtList.DataSource = mey.GetList("NvarClass='全国福彩' or NvarClass='全国体彩'");
            DdtList.DataTextField = "NvarName";
            DdtList.DataValueField = "IntId";
            DdtList.DataBind();
        }

        /// <summary>
        /// 更改索引后激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Rbtlist1.SelectedValue == "0")
            {
                BtnOk.Text = "完 成";
            }
            else
            {
                BtnOk.Text = "下一步>>";
            }
        }

        /// <summary>
        /// 点击完成或者下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnOk_Click(object sender, EventArgs e)
        {


            if (DdtList.SelectedValue == "--请选择--")
            {
                //JS.Alert("请选择彩种");
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('请选择彩种！')", true);
                return;
            }


            if (Ddtservice.SelectedItem.Text == "--请选择--")
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('请填写类别！')", true);
                return;
            }
            else
            {
                //判断是否存在该项目类型
                if (serverType.GetList("LotteryID=" + DdtList.SelectedValue.ToString() + " and TypeName='" + Ddtservice.SelectedItem.Text + "'").Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('该项目类型已存在！无需重复发布！')", true);
                    return;
                }



                if (BtnOk.Text == "下一步>>")
                {
                    labmc.Text = txtxiangm.Text;
                    MutViwe.ActiveViewIndex++;

                }
                else
                {

                    lotterytype.LotteryID = Convert.ToInt32(DdtList.SelectedValue.ToString());
                    lotterytype.TypeName = Ddtservice.SelectedItem.Text;
                    lotterytype.Intercalate = Convert.ToInt32(Rbtlist1.SelectedValue);
                    //默认配置，默认配置配置在XML里
                    lotterytype.State = 0;
                    lotterytype.UserID = Convert.ToInt32(Method.Get_UserID);
                    int typeid = serverType.Add(lotterytype);
                    if (typeid > 0)
                    {

                        lotterytypeconfigure.TypeId = typeid;
                        lotterytypeconfigure.On_off = Convert.ToInt32(Input.GetValue("On_Off"));

                        lotterytypeconfigure.Sign = Convert.ToInt32(Input.GetValue("Sign"));

                        lotterytypeconfigure.BeginTime = DateTime.Now;

                        lotterytypeconfigure.Endtime = DateTime.Now;

                        lotterytypeconfigure.Upload = Convert.ToInt32(Input.GetValue("Upload")); ;

                        lotterytypeconfigure.SmallMoney = Convert.ToDecimal(Input.GetValue("SmallMoney"));

                        lotterytypeconfigure.BigMoney = Convert.ToDecimal(Input.GetValue("BigMoney"));

                        lotterytypeconfigure.Ticheng = Input.GetValue("Ticheng");

                        lotterytypeconfigure.ManyIssue = Convert.ToInt32(Input.GetValue("ManyIssue"));

                        lotterytypeconfigure.Recommend = Convert.ToInt32(Input.GetValue("Recommend"));

                        //执行 数据增加操作
                        Market_TypeConfigureManager config = new Market_TypeConfigureManager();
                        if (config.Add(lotterytypeconfigure) > 0)
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('添加成功！')", true);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('添加失败！')", true);
                            return;
                        }


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('添加失败！');", true);
                        return;
                    }
                }

            }

        }

        /// <summary>
        /// 上一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void butResult_Click(object sender, EventArgs e)
        {
            MutViwe.ActiveViewIndex--;
        }

        /// <summary>
        /// 点击保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {

            //判断是否存在该项目类型
            if (serverType.GetList("LotteryID=" + DdtList.SelectedValue.ToString() + " and TypeName='" + Ddtservice.SelectedItem.Text + "'").Tables[0].Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('该项目类型已存在！无需重复发布！')", true);
                return;
            }

            //彩种ID
            int typeid = 0;
            //服务类别
            string leibie = Ddtservice.SelectedItem.Text;

            //是否默认
            int mrid = Convert.ToInt32(Rbtlist1.SelectedValue);

            //开关
            int kaiguan = 0;
            //是否置顶

            int zd = 0;
            //最小金额
            decimal minmoney = 0;
            //最大金额
            decimal maxmoney = 0;
            //提成参数
            double ticheng = 0;
            //是否允许多期

            int douqi = 0;
            if (mrid != 0)
            {

                //开关
                kaiguan = Convert.ToInt32(RBtkaiguan.SelectedValue);

                //是否置顶
                zd = Convert.ToInt32(Rbtzhiding.SelectedValue);

                //判断最小金额是否输入正确
                if (!Decimal.TryParse(txtbeginMoney.Text, out minmoney))
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('最小金额填写不正确！')", true);
                    return;
                }

                //判断最大金额是否输入正确
                if (!Decimal.TryParse(txtendMoney.Text, out maxmoney))
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('最大金额填写不正确！')", true);
                    return;
                }
                //判断最小金额不能大于最大金额
                if (minmoney > maxmoney)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('最小金额不能大于最大金额！')", true);
                    return;
                }
                //提成非空判断
                if (txtticheng.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('提成参数不能为空！');", true);
                    return;
                }
                //判断提成输入
                if (!Double.TryParse(txtticheng.Text, out ticheng))
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('提成参数输入不对！');", true);
                    return;
                }


                //是否允许多期

                douqi = Convert.ToInt32(Rbtduoqi.SelectedValue);

            }



            lotterytype.LotteryID = Convert.ToInt32(DdtList.SelectedValue.ToString());
            lotterytype.TypeName = Ddtservice.SelectedItem.Text;
            lotterytype.Intercalate = Convert.ToInt32(Rbtlist1.SelectedValue);
            //默认配置,默认添加
            lotterytype.State = 0;
            lotterytype.UserID = Convert.ToInt32(Method.Get_UserName);
            typeid = serverType.Add(lotterytype);
            if (typeid > 0)
            {


                // lotterytype.Userid = null;
                //end-------------结束

                //执行数据增加操作 返回执行后的ID


                //类型详细信息添加

                // lotterytypeconfigure.Typeid = 1;

                lotterytypeconfigure.TypeId = typeid;
                lotterytypeconfigure.On_off = kaiguan;

                lotterytypeconfigure.Sign = zd;

                lotterytypeconfigure.BeginTime = DateTime.Now;

                lotterytypeconfigure.Endtime = DateTime.Now;

                lotterytypeconfigure.Upload = 0;

                lotterytypeconfigure.SmallMoney = minmoney;

                lotterytypeconfigure.BigMoney = maxmoney;

                lotterytypeconfigure.Ticheng = ticheng.ToString();

                lotterytypeconfigure.ManyIssue = douqi;

                lotterytypeconfigure.Recommend = 0;

                //执行 数据增加操作
                Market_TypeConfigureManager config = new Market_TypeConfigureManager();
                if (config.Add(lotterytypeconfigure) > 0)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('添加成功！')", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('添加失败！')", true);
                    return;
                }


            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('添加失败！');", true);
                return;
            }
        }

        /// <summary>
        /// 在更改文本属性激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtleibie_TextChanged(object sender, EventArgs e)
        {
            if (Ddtservice.SelectedItem.Text != "--请选择--")
                txtxiangm.Text = DdtList.SelectedItem.Text + Ddtservice.SelectedItem.Text;
            else
                txtxiangm.Text = "";
        }


        /// <summary>
        /// 更改索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DdtList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ddtservice.Items.Clear();
            Ddtservice.Items.Add(new ListItem("--请选择--", "--请选择--"));
            if (DdtList.SelectedItem.Text == "--请选择--")
            {
                return;
            }

            try
            {
                XmlDocument dom = new XmlDocument();
                dom.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/LottoryCondition.xml"));//装载XML文档 
                XmlElement root = dom.DocumentElement;
                XmlNode xmlchiroot = root.SelectNodes("CP" + DdtList.SelectedItem.Text)[0];
                if (xmlchiroot != null)
                {
                    for (int i = 0; i < xmlchiroot.ChildNodes.Count; i++)
                    {
                        if (xmlchiroot.ChildNodes[i] != null)
                        {
                            ListItem item = new ListItem();
                            item.Text = xmlchiroot.ChildNodes[i].SelectSingleNode("@name").Value;
                            item.Value = xmlchiroot.ChildNodes[i].SelectSingleNode("@name").Value;
                            Ddtservice.Items.Add(item);
                        }
                    }
                    Ddtservice.DataBind();
                }

            }
            catch
            {

            }
            if (Ddtservice.SelectedItem.Text != "--请选择--")
                txtxiangm.Text = DdtList.SelectedItem.Text + Ddtservice.SelectedItem.Text;
            else
                txtxiangm.Text = "";
        }
        /// <summary>
        /// 项目索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Ddtservice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ddtservice.SelectedItem.Text != "--请选择--")
                txtxiangm.Text = DdtList.SelectedItem.Text + Ddtservice.SelectedItem.Text;
            else
                txtxiangm.Text = "";
        }

    }
}
