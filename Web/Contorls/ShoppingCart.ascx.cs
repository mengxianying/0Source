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
using System.Collections.Generic;
using System.Text;
using Common;
using Maticsoft.DBUtility;
using Pbzx.Web.PB_Manage.Controls;

namespace Pbzx.Web.Contorls
{
    public partial class ShoppingCart : System.Web.UI.UserControl
    {
        protected DataTable Dview;
        //public string Message = "";      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindShoppingCart();
                this.lblSumPrice.InnerText = WebFunc.CalcTotalPrice().ToString();
                if (Request.UrlReferrer != null && Request.UrlReferrer != Request.Url)
                {
                }
                BindChbTypes();
            }
        }

        protected void BindChbTypes()
        {
            Pbzx.BLL.PBnet_Product productBll = new Pbzx.BLL.PBnet_Product();
            this.rptTypes.DataSource = DbHelperSQL.Query(" SELECT DISTINCT pb_TypeName FROM PBnet_Product WHERE (pb_TypeName <> '免费版' and  pb_TypeName<>'出票系统' and pb_TypeName<>'珍藏版') and  " + Method.product);
            this.rptTypes.DataBind();
        }
        protected string getChild(object typeName)
        {
            Pbzx.BLL.PBnet_Product productBll = new Pbzx.BLL.PBnet_Product();
            Dview = productBll.GetList(" pb_freeshow<>'true' and  pb_TypeName='" + typeName + "' and  " + Method.product).Tables[0];
            string name = typeName.ToString();
            typeName = "<b>" + typeName + "</b>";
            return typeName.ToString();
        }

        protected string showRights(object pb_SoftID, object pb_SoftName)
        {
            string result = "";
            result += "<input type=\"checkbox\" name=\"chbProducts\" value=\"" + pb_SoftID + "\" /> " + pb_SoftName;
            return result;
        }


        #region 获取购物车
        public void BindShoppingCart()
        {

            string cartGuid = Method.GetCartGuid();
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            DataSet dsProducts = shoppingCartBll.SelectShoppingCartByCartGuid(cartGuid);

            if (!(dsProducts.Tables.Count > 0 && dsProducts.Tables[0].Rows.Count > 0))
            {
                lblMsg.Text = "购物车当前为空！";
                btnCheckOut.Enabled = false;
                btnClearShoppingCart.Enabled = false;
                return;
            }
            this.MyGridView.DataSource = dsProducts;
            this.MyGridView.DataBind();


        }
        #endregion

        #region 修改数量
        protected void btnModifyQuatity_Click(object sender, EventArgs e)
        {
            List<Pbzx.Model.PBnet_ShoppingCart> shoppingCartList = new List<Pbzx.Model.PBnet_ShoppingCart>();


            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            shoppingCartBll.UpdateShoppingCart(shoppingCartList);

            BindShoppingCart();
        }
        #endregion

        #region 统计总数量和总价格
        decimal SumBookPrice = (decimal)0.00;
        int SumQuatity = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //TextBox txtQuatity = (TextBox)e.Row.FindControl("txtQuatity");
                int quatity = 1;
                SumQuatity += quatity;

                decimal totalBookPrice = Convert.ToDecimal(e.Row.Cells[4].Text);
                SumBookPrice += totalBookPrice;
                e.Row.Cells[4].Text = string.Format("{0:C2}", totalBookPrice);
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSumQuatity = (Label)e.Row.FindControl("lblSumQuatity");
                lblSumQuatity.Text = SumQuatity.ToString();

                Label lblSumBookPrice = (Label)e.Row.FindControl("lblSumBookPrice");
                lblSumBookPrice.Text = string.Format("{0:C2}", SumBookPrice);
            }
        }
        #endregion

        #region 删除
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }
        #endregion

        #region 清空购物车
        protected void btnClearShoppingCart_Click(object sender, EventArgs e)
        {
            string cartGuid = Method.GetCartGuid();
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            shoppingCartBll.DeleteShoppingCartByCartGuid(cartGuid);
            Response.Redirect("~/ShowShoppingCart.aspx");
        }
        #endregion

        #region 结算
        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
              Response.Redirect("~/AddOrder.aspx");
        }
        #endregion

        /// <summary>
        /// 检测dropdownlist 得选中状态
        /// </summary>
        /// <param name="CartID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected void CheckState(DropDownList ddl, object regType)
        {
            string[] regTypeSZ = regType.ToString().Split(new char[] { '|' });
            foreach (ListItem li in ddl.Items)
            {
                if (li.Value == regTypeSZ[0])
                {
                    li.Selected = true;
                    break;
                }
            }
        }





        /// <summary>
        /// 网络注册方式
        /// </summary>
        /// <param name="CartID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected void GetbtnRadioWL(object CartID, object type, string regType, RadioButtonList rbl, GridViewRow row)
        {
            rbl.Items.Clear();
            int rowIndex = row.RowIndex;
            Pbzx.BLL.PBnet_ProductPrice priceBLL = new Pbzx.BLL.PBnet_ProductPrice();
            DataSet ds = priceBLL.GetList(" VarVersionType='" + type.ToString() + "' ");

            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                // string display = "";
                string useTime = dataRow["VarUseTime"].ToString();
                string price = dataRow["VarPrice"].ToString();
                string typeDay = price.Substring(price.Length - 2, 2);
                string intPrice = price.Remove(price.IndexOf("元"));

                if (decimal.Parse(intPrice) > 0)
                {

                    if (typeDay == "/天")
                    {
                        ListItem liTian = new ListItem(price, intPrice);
                        liTian.Attributes.Add("type", "antian");
                        rbl.Items.Add(liTian);
                        liTian.Selected = CheckStateRadio(intPrice, regType, CartID.ToString());
                    }
                    else
                    {
                        ListItem liTian = new ListItem(useTime + price, intPrice);
                        liTian.Attributes.Add("type", "no");
                        rbl.Items.Add(liTian);
                        liTian.Selected = CheckStateRadio(intPrice, regType, CartID.ToString());
                    }
                }
            }

            ///检测绑定天数
            TextBox txtDays = (TextBox)row.FindControl("txtDays");
            Panel pnlDays = (Panel)row.FindControl("pnlDays");
            pnlDays.Visible = false;
            string[] regTypeSZ = regType.Split(new char[] { '|' });
            if (regTypeSZ.Length > 1)
            {
                if (!string.IsNullOrEmpty(regTypeSZ[1]))
                {
                    string[] myDays = regTypeSZ[1].Split(new char[] { '&' });
                    if (myDays.Length > 1)
                    {
                        if (!string.IsNullOrEmpty(myDays[1]))
                        {
                            txtDays.Text = myDays[1];
                            pnlDays.Visible = true;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 检测radiobutton项的选中状态
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regType"></param>
        /// <param name="CartID"></param>
        /// <returns></returns>
        protected bool CheckStateRadio(string value, string regType, string CartID)
        {

            string[] regTypeSZ = regType.Split(new char[] { '|' });
            if (regTypeSZ.Length > 1)
            {
                if (!string.IsNullOrEmpty(regTypeSZ[1]))
                {
                    string price = "";
                    string[] days = regTypeSZ[1].Split(new char[] { '&' });
                    price = days[0];
                    if (decimal.Parse(value) == decimal.Parse(price))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 单机注册方式
        /// </summary>
        /// <param name="pb_TypeName"></param>
        /// <param name="CartID"></param>
        /// <param name="pb_DemoUrl"></param>
        /// <param name="pb_RegUrl"></param>
        /// <returns></returns>
        protected void GetbtnRadioBD(object pb_TypeName, object CartID, string pb_DemoUrl, string pb_RegUrl, string regType, RadioButtonList rbl)
        {

            rbl.Items.Clear();
            string zhoongS = pb_RegUrl.ToString();
            string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("元"));

            if (pb_TypeName.ToString() == "专业版")
            {
                string danj = pb_DemoUrl.ToString();
                string intPrice = danj.Remove(danj.IndexOf("元"));
                ListItem liZhuan = new ListItem(intPrice + "元/年", intPrice);
                liZhuan.Selected = CheckStateRadio(intPrice, regType, CartID.ToString());
                if (decimal.Parse(intPrice) > 0)
                {
                    rbl.Items.Add(liZhuan);
                }
            }
            if (pb_TypeName.ToString() == "标准版")
            {
                string danj = pb_DemoUrl.ToString();
                string intPrice = danj.Remove(danj.IndexOf("元"));
                ListItem liZhuan = new ListItem(intPrice + "元/年", intPrice);
                liZhuan.Selected = CheckStateRadio(intPrice, regType, CartID.ToString());
                if (decimal.Parse(intPrice) > 0)
                {
                    rbl.Items.Add(liZhuan);
                }
            }
            if (pb_TypeName.ToString() == "胆杀版")
            {
                string danj = pb_DemoUrl.ToString();
                string intPrice = danj.Remove(danj.IndexOf("元"));
                ListItem liZhuan = new ListItem(intPrice + "元/年", intPrice);
                liZhuan.Selected = CheckStateRadio(intPrice, regType, CartID.ToString());
                if (decimal.Parse(intPrice) > 0)
                {
                    rbl.Items.Add(liZhuan);
                }
            }
            if (pb_TypeName.ToString() == "遨游版")
            {
                string danj = pb_DemoUrl.ToString();
                string intPrice = danj.Remove(danj.IndexOf("元"));
                ListItem liZhuan = new ListItem(intPrice + "元/年", intPrice);
                liZhuan.Selected = CheckStateRadio(intPrice, regType, CartID.ToString());
                if (decimal.Parse(intPrice) > 0)
                {
                    rbl.Items.Add(liZhuan);
                }
            }
            ListItem liTao = new ListItem(intPrice2 + "元/套", intPrice2);
            liTao.Selected = CheckStateRadio(intPrice2, regType, CartID.ToString());
            if (decimal.Parse(intPrice2) > 0)
            {
                rbl.Items.Add(liTao);
            }
        }

        /// <summary>
        /// 软件狗注册方式
        /// </summary>
        /// <param name="pb_TypeName"></param>
        /// <param name="CartID"></param>
        /// <param name="pb_DemoUrl"></param>
        /// <param name="pb_RegUrl"></param>
        /// <returns></returns>
        protected void GetbtnRadioRJG(object pb_TypeName, object CartID, string pb_DemoUrl, string pb_RegUrl, string regType, RadioButtonList rbl)
        {

            rbl.Items.Clear();

            string zhoongS = pb_RegUrl.ToString();
            string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("元"));
            decimal p2 = 0;
            if (decimal.TryParse(intPrice2, out p2))
            {
            }
            decimal p4 = p2 + WebInit.webBaseConfig.SoftdogPrice;
            StringBuilder sb = new StringBuilder();
            if (pb_TypeName.ToString() == "专业版" || pb_TypeName.ToString() == "标准版" || pb_TypeName.ToString() == "胆杀版" || pb_TypeName.ToString() == "遨游版" || pb_TypeName.ToString() == "睿智版")
            {
                string danj = pb_DemoUrl.ToString();
                string intPrice = danj.Remove(danj.IndexOf("元"));
                decimal p1 = 0;
                if (decimal.TryParse(intPrice, out p1))
                {
                }
                else
                {
                    intPrice = "";
                }
                decimal p3 = p1 + WebInit.webBaseConfig.SoftdogPrice;
                ListItem liZhuan = new ListItem(intPrice + "元/年 + " + WebInit.webBaseConfig.SoftdogPrice + "元", p3.ToString());
                liZhuan.Selected = CheckStateRadio(p3.ToString(), regType, CartID.ToString());
                if (decimal.Parse(intPrice) > 0 )
                {
                    rbl.Items.Add(liZhuan);
                }
               
            }
//            ListItem liTao = new ListItem(intPrice2 + "元/套 + " + WebInit.webBaseConfig.SoftdogPrice + "元", p4.ToString());
//            liTao.Selected = CheckStateRadio(p4.ToString(), regType, CartID.ToString());
//            if (decimal.Parse(intPrice2) > 0)
//            {
//                rbl.Items.Add(liTao);
//            }
          
        }

        /// <summary>
        /// 得到当前行价格
        /// </summary>
        /// <param name="CartID"></param>
        /// <param name="regType"></param>
        /// <returns></returns>
        protected string GetOneProductPrice(object CartID, string regType)
        {
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            Pbzx.Model.PBnet_ShoppingCart cartModel = shoppingCartBll.GetModel(Convert.ToInt64(CartID));
            string[] sz = cartModel.RegType.Split(new char[] { '|' });
            decimal result = 0;
            if (sz.Length > 1 && !string.IsNullOrEmpty(sz[1]))
            {
                string[] days = sz[1].Split(new char[] { '&' });
                if (days.Length > 1 && !string.IsNullOrEmpty(days[1]))
                {
                    result = ((decimal)cartModel.Quatity) * Convert.ToDecimal(days[0]) * Convert.ToDecimal(days[1]);
                }
                else
                {
                    result = ((decimal)cartModel.Quatity) * Convert.ToDecimal(days[0]);
                }
            }
            return result.ToString();
        }

        ///// <summary>
        ///// 删除事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void lbtnDel_Command1(object sender, CommandEventArgs e)
        //{
        //    Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
        //    string[] strSz = e.CommandArgument.ToString().Split(new char[] { '&' });
        //    Pbzx.Model.PBnet_ShoppingCart cartModel = shoppingCartBll.GetModelByProductID(strSz[0],strSz[1]);
        //    shoppingCartBll.Delete(cartModel.CartID);
        //    BindShoppingCart();
        //    //this.UpShoppingCart.Update();
        //}

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCheckOut_Click(object sender, ImageClickEventArgs e)
        {
            string[] result = CheckALL().Split(new char[] { '|' });
            if (!string.IsNullOrEmpty(result[0]))
            {
                string[] strErrors = result[0].Split(new char[] { '&' });
                if (!string.IsNullOrEmpty(strErrors[0]))
                {
                    //ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), "提示", "alert('您提交的购买软件信息中存在以下错误:<br/><br/>" + result + "<br/>请修改后再重新提交.')", true);
                    ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "您提交的购买软件信息中存在以下错误:<br/><br/>" + strErrors[0] + "<br/><br/>请修改后再重新提交！", 580, "2", "", "", false, false) + "", false);
                    return;
                }
                else if (!string.IsNullOrEmpty(strErrors[1]))
                {
                    ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "一个购物车最多只能选择一个软件狗方式(购买新软件狗)！<br/><br/>请修改后再重新提交！", 370, "2", "", "", false, false) + "", false);
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(result[1]))
                {

                    ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert("提示", "" + result[1] + "", 580, "2", "top.location='/UserCenter/AddOrder.aspx';", "", false, false) + "", false);
                }
            }

        }

        /// <summary>
        /// 检测所有
        /// </summary>
        /// <returns></returns>
        private string CheckALL()
        {
            StringBuilder sbQueRen = new StringBuilder("您将购买以下软件：<br/><br/>");
            StringBuilder sb = new StringBuilder("");
            int foundNewRJG = 0;
            int foundBdRJG = 0;
            if (MyGridView.Rows.Count < 1)
            {
                return "|";
            }
            foreach (GridViewRow row in MyGridView.Rows)
            {
                int rowIndex = row.RowIndex;
                //当前软件名称
                string pb_SoftName = MyGridView.DataKeys[rowIndex].Values["pb_SoftName"].ToString();
                string ProductID = MyGridView.DataKeys[rowIndex].Values["ProductID"].ToString();
                //检测注册方式下拉列表
                DropDownList ddlRegType = (DropDownList)row.Cells[1].FindControl("ddlRegType");
                if (ddlRegType.SelectedValue == "-1")
                {
                    sb.Append("软件：" + pb_SoftName + "；您没有选择任何注册方式！<br/>");
                }
                else
                {
                    RadioButtonList rblPrice = (RadioButtonList)row.Cells[2].FindControl("radio_" + ddlRegType.SelectedValue);
                    if (string.IsNullOrEmpty(rblPrice.SelectedValue))
                    {
                        sb.Append("软件：" + pb_SoftName + "；软件单价栏没有选择使用时间！<br/>");
                    }
                }

                //检测用户名 
                Panel pnlUserName = (Panel)row.FindControl("pnlUserName");
                if (pnlUserName.Visible)
                {
                    TextBox txtUserName = (TextBox)row.FindControl("txtUserName");
                    if (string.IsNullOrEmpty(txtUserName.Text))
                    {
                        sb.Append("软件：" + pb_SoftName + "；未输入用户名！<br/>");
                    }
                    else
                    {
                        int count = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + Input.FilterAll(txtUserName.Text) + "'  and LockUser='0' and UserClass!='COPPA' and UserClass!='等待验证'  "));
                        if (count < 1)
                        {
                            sb.Append("软件：" + pb_SoftName + "；此用户名未注册，或者被锁定！请核实后填写。<br/>");
                        }
                        else
                        {
                            ////获取购物车信息
                            //使用用户名是否存在
                            string cartGuid = Method.GetCartGuid();
                            //获取购物车ID
                            long CartID = Convert.ToInt64(MyGridView.DataKeys[rowIndex].Values["CartID"]);
                            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();

                            DataSet dsShoppingCart = shoppingCartBll.GetList("CartID=" + CartID + " and CartGuid=" + "'" + cartGuid + "'");
                            Pbzx.Model.PBnet_ShoppingCart mod_st = shoppingCartBll.GetModel(Convert.ToInt32(dsShoppingCart.Tables[0].Rows[0]["CartID"]));

                            if (dsShoppingCart != null && dsShoppingCart.Tables[0].Rows.Count > 0)
                            {
                                if (dsShoppingCart.Tables[0].Rows[0]["RegType"].ToString().Split('|')[2].ToString() == "" && Convert.ToInt32(dsShoppingCart.Tables[0].Rows[0]["RegType"].ToString().Split('|')[0]) == 8)
                                {
                                    mod_st.RegType = dsShoppingCart.Tables[0].Rows[0]["RegType"].ToString() + txtUserName.Text;
                                    shoppingCartBll.Update(mod_st);
                                }
                            }
                        }
                    }
                }
                
               


                //检测认证码
                Panel pnlRZM = (Panel)row.FindControl("pnlRZM");
                if (pnlRZM.Visible)
                {
                    TextBox txtRZM = (TextBox)row.FindControl("txtRZM");
                    //string regType = MyGridView.DataKeys[rowIndex].Values["RegType"].ToString();
                    string result = Method.CheckCartRegType(Input.FilterAll(txtRZM.Text), ddlRegType.SelectedValue, ProductID);
                    if (!string.IsNullOrEmpty(result))
                    {
                        sb.Append("软件：" + pb_SoftName + "；" + result + "<br/>");
                    }
                }
                // //检测购买数量
                //// TextBox txtQuatity = (TextBox)row.FindControl("txtQuatity");
                // string tempYZ = Method.CheckIsNum("购买数量", Input.FilterAll(txtQuatity.Text),1,9999);
                // if (!string.IsNullOrEmpty(tempYZ))
                // {
                //    sb.Append("软件：" + pb_SoftName + "；" + tempYZ + "<br/>");                    
                // }
                //检测购买天数
                Panel pnlDays = (Panel)row.FindControl("pnlDays");
                if (pnlDays.Visible)
                {
                    TextBox txtDays = (TextBox)row.FindControl("txtDays");
                    //string tempYZTS = Method.CheckIsNum("天数", Input.FilterAll(txtDays.Text), 50, 999999);
                    string tempYZTS = Method.CheckIsNum("天数", Input.FilterAll(txtDays.Text), 30, 999999);
                    if (!string.IsNullOrEmpty(tempYZTS))
                    {
                        sb.Append("软件：" + pb_SoftName + "；" + tempYZTS + "<br/>");
                    }
                }

                if (ddlRegType.SelectedValue == "7")
                {
                    foundNewRJG++;
                }
                if (ddlRegType.SelectedValue == "6")
                {
                    foundBdRJG++;
                }
                sbQueRen.Append("软件：" + pb_SoftName + "；");
                //
                // Pbzx.Model.PBnet_ShoppingCart my CalCurrentRowPrice(MyGridView.Rows[rowIndex]);
                sbQueRen.Append(WebFunc.CheckRegTye(MyGridView.DataKeys[rowIndex].Values["RegType"], MyGridView.DataKeys[rowIndex].Values["pb_TypeName"], MyGridView.DataKeys[rowIndex].Values["pb_DemoUrl"], MyGridView.DataKeys[rowIndex].Values["pb_RegUrl"]));
                string regType = MyGridView.DataKeys[rowIndex].Values["RegType"].ToString();
                string[] strRegType = regType.Split(new char[] { '|' });
                decimal price = 0;
                if (strRegType.Length > 1 && !string.IsNullOrEmpty(strRegType[1]))
                {
                    string[] priceSZ = strRegType[1].Split(new char[] { '&' });
                    if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                    {
                        price = decimal.Parse(priceSZ[0]) * decimal.Parse(priceSZ[1]);
                    }
                    else
                    {
                        price = decimal.Parse(strRegType[1]);
                    }
                }

                sbQueRen.Append("；价格：" + price + "元。");
                sbQueRen.Append("<br/>");
            }
            decimal totalPrice = 0;
            if (!decimal.TryParse(this.lblSumPrice.InnerText, out totalPrice))
            {
                sb.Append("总价格有误！<br/>");
            }
            if(totalPrice <=0 )
            {
                sb.Append("总价格有误！<br/>"); 
            }
            if (foundBdRJG > 0 && foundNewRJG < 1)
            {
                sb.Append("注册方式选择有误，因为您选择了软件狗方式(绑定新软件狗)，<br/>所以您至少应选择一种\"软件狗方式(购买新软件狗)\"");
            }
            else if (foundBdRJG > 7)
            {
                sb.Append("注册方式选择有误，因为一个新软件狗最多绑定8个软件！<br/>所以您最多应可选择7种\"软件狗方式(绑定新软件狗)\"！");
            }
            else if (foundNewRJG > 1)
            {
                sb.Append("&1");
            }
            sbQueRen.Append("<br/>总价格（不含运费）：" + lblSumPrice.InnerText + "元");
            return sb.ToString() + "|" + sbQueRen.ToString();


        }
        protected void MyGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
        }

        /// <summary>
        /// 根据注册类别和grideview当期行id创建radiobuttonlist
        /// </summary>
        /// <param name="ddlType"></param>
        /// <param name="rowIndex"></param>
        private void CreateRadioList(string ddlType, GridViewRow row)
        {
            int rowIndex = row.RowIndex;
            long CartID = Convert.ToInt64(MyGridView.DataKeys[rowIndex].Values["CartID"]);
            string pb_TypeName = MyGridView.DataKeys[rowIndex].Values["pb_TypeName"].ToString();
            string RegType = MyGridView.DataKeys[rowIndex].Values["RegType"].ToString();
            string pb_DemoUrl = MyGridView.DataKeys[rowIndex].Values["pb_DemoUrl"].ToString();
            string pb_RegUrl = MyGridView.DataKeys[rowIndex].Values["pb_RegUrl"].ToString();
            switch (ddlType)
            {
                case "8":
                    RadioButtonList radio_8 = (RadioButtonList)row.Cells[2].FindControl("radio_8");
                    GetbtnRadioWL(CartID, pb_TypeName, RegType, radio_8, row);
                    break;
                case "1":
                    RadioButtonList radio_1 = (RadioButtonList)row.Cells[2].FindControl("radio_1");
                    GetbtnRadioBD(pb_TypeName, CartID, pb_DemoUrl, pb_RegUrl, RegType, radio_1);
                    break;
                case "9":
                    RadioButtonList radio_9 = (RadioButtonList)row.Cells[2].FindControl("radio_9");
                    GetbtnRadioBD(pb_TypeName, CartID, pb_DemoUrl, pb_RegUrl, RegType, radio_9);
                    break;
                case "7":
                    RadioButtonList radio_7 = (RadioButtonList)row.Cells[2].FindControl("radio_7");
                    GetbtnRadioRJG(pb_TypeName, CartID, pb_DemoUrl, pb_RegUrl, RegType, radio_7);
                    break;
                case "6":
                    RadioButtonList radio_6 = (RadioButtonList)row.Cells[2].FindControl("radio_6");
                    GetbtnRadioBD(pb_TypeName, CartID, pb_DemoUrl, pb_RegUrl, RegType, radio_6);
                    break;

            }
            DisplayRadio(row, Method.ChangeRegType2Int(ddlType));
        }

        /// <summary>
        /// 显示与隐藏软件价格
        /// </summary>
        /// <param name="row"></param>
        /// <param name="index"></param>
        private void DisplayRadio(GridViewRow row, int index)
        {
            for (int i = 0; i <= 4; i++)
            {
                if (index == i)
                {
                    ((Panel)row.Cells[2].FindControl("showprice_" + index)).Visible = true;
                }
                else
                {
                    ((Panel)row.Cells[2].FindControl("showprice_" + i)).Visible = false;
                }
            }
        }

        protected void ddlRegType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddlRegType = (DropDownList)sender;
                int rowIndex = Convert.ToInt32(ddlRegType.Attributes["rowIndex"]);
                CreateRadioList(ddlRegType.SelectedValue, MyGridView.Rows[rowIndex]);
                DisplayUnameRZM(MyGridView.Rows[rowIndex]);
                //判断是否是网络方式中的按天购买，然后计算行价格和总价格
                if (ddlRegType.SelectedValue == "8")
                {
                    RadioButtonList radio_8 = (RadioButtonList)MyGridView.Rows[rowIndex].Cells[2].FindControl("radio_8");
                    ListItem li = radio_8.SelectedItem;
                    TextBox txtDays = (TextBox)MyGridView.Rows[rowIndex].FindControl("txtDays");
                    Panel pnlDays = (Panel)MyGridView.Rows[rowIndex].FindControl("pnlDays");
                    TextBox txtUserName = (TextBox)MyGridView.Rows[rowIndex].FindControl("txtUserName");
                    if (li != null)
                    {
                        if (li.Text.Contains("/天"))
                        {
                            pnlDays.Visible = true;
                            CalCurrentRowPrice(MyGridView.Rows[rowIndex], Input.FilterAll(txtDays.Text));
                        }
                        else
                        {
                            pnlDays.Visible = false;
                            CalCurrentRowPrice(MyGridView.Rows[rowIndex]);
                        }
                    }
                    else
                    {
                        pnlDays.Visible = false;
                        CalCurrentRowPrice(MyGridView.Rows[rowIndex]);
                    }

                    LoginSort login = new LoginSort();
                    if (login["manager_user"])
                    {
                        if (txtUserName.Text.Trim() == "")
                        {
                            txtUserName.Text = Method.Get_UserName;
                        }
                    }
                    else
                    {
                        txtUserName.Text = "";
                    }
                }
                else
                {
                    CalCurrentRowPrice(MyGridView.Rows[rowIndex]);
                }
                BindShoppingCart();
                TextBox txtRZM = (TextBox)MyGridView.Rows[rowIndex].FindControl("txtRZM");
                txtRZM.Text = "";
            }
            catch (Exception ex)
            {
                Response.Redirect("/Default.htm");
            }
        }



        /// <summary>
        /// 验证网络方式注册用户名是否存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            TextBox txtUserName = (TextBox)sender;
            int count = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + Input.FilterAll(txtUserName.Text) + "' and  " + Method.DV_User));
            int rowIndex = Convert.ToInt32(txtUserName.Attributes["rowIndex"]);
            string pb_SoftName = MyGridView.DataKeys[rowIndex].Values["pb_SoftName"].ToString();

            if (count < 1)
            {
                ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "软件：" + pb_SoftName + "，此用户名未注册，或者被锁定！请核实后填写。", 500, "1", "", "", false, false) + "", false);
                return;
            }
            LoginSort myLogin = new LoginSort();
            if (!myLogin["manager_user"])
            {
                ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("提示", "请确认为 " + txtUserName.Text + " 购买" + pb_SoftName + "软件？", 500, "1", "", "", false, false) + "", false);//document.getElementById('" + txtUserName.ClientID + "').value=''
            }
            else if (txtUserName.Text != Method.Get_UserName)
            {
                ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("提示", "您的登录用户名与购买软件的用户名不一致，请确认为他人 " + txtUserName.Text + " 购买" + pb_SoftName + "软件？", 500, "1", "", "", false, false) + "", false);//document.getElementById('" + txtUserName.ClientID + "').value=''
                // ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), "提示", "if Confrim('您将为用户名为：" + txtUserName.Text + "的用户购买软件：" + pb_SoftName + "；是否确定？'){}else{}", true);//;
            }
            else if (txtUserName.Text == Method.Get_UserName)
            {
                ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("提示", "您确认为自己 " + txtUserName.Text + " 购买" + pb_SoftName + "软件？", 500, "1", "", "", false, false) + "", false);//document.getElementById('" + txtUserName.ClientID + "').value=''
            }

            Panel pnlDays = (Panel)MyGridView.Rows[rowIndex].FindControl("pnlDays");

            if (pnlDays.Visible)
            {
                TextBox txtDays = (TextBox)MyGridView.Rows[rowIndex].FindControl("txtDays");
                CalCurrentRowPrice(MyGridView.Rows[rowIndex], Input.FilterAll(txtDays.Text));
            }
            else
            {
                CalCurrentRowPrice(MyGridView.Rows[rowIndex]);
            }
            BindShoppingCart();
            RadioButtonList radio_8 = (RadioButtonList)MyGridView.Rows[rowIndex].Cells[2].FindControl("radio_8");
            radio_8_SelectedIndexChanged(radio_8, new EventArgs());
        }


        /// <summary>
        /// 验证认证码是否正确
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtRZM_TextChanged(object sender, EventArgs e)
        {
            TextBox txtRZM = (TextBox)sender;
            int rowIndex = Convert.ToInt32(txtRZM.Attributes["rowIndex"]);
            DropDownList ddlRegType = (DropDownList)MyGridView.Rows[rowIndex].Cells[1].FindControl("ddlRegType");
            string ProductID = MyGridView.DataKeys[rowIndex].Values["ProductID"].ToString();

            string result = Method.CheckCartRegType(Input.FilterAll(txtRZM.Text), ddlRegType.SelectedValue, ProductID);
            string pb_SoftName = MyGridView.DataKeys[rowIndex].Values["pb_SoftName"].ToString();
            if (!string.IsNullOrEmpty(result))
            {
                ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert("错误！", "软件：" + pb_SoftName + "；" + result + "", 500, "2", "", "", false, false) + "", false);//document.getElementById('" + txtRZM.ClientID + "').value=''                
                return;
            }
            Panel pnlDays = (Panel)MyGridView.Rows[rowIndex].FindControl("pnlDays");
            if (pnlDays.Visible)
            {
                TextBox txtDays = (TextBox)MyGridView.Rows[rowIndex].FindControl("txtDays");
                CalCurrentRowPrice(MyGridView.Rows[rowIndex], Input.FilterAll(txtDays.Text));
            }
            else
            {
                CalCurrentRowPrice(MyGridView.Rows[rowIndex]);
            }
            BindShoppingCart();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //long CartID = Convert.ToInt64(MyGridView.DataKeys[e.Row.RowIndex].Values["CartID"]);
                //int ProductID = Convert.ToInt32(MyGridView.DataKeys[e.Row.RowIndex].Values["ProductID"]);
                //string pb_SoftName = MyGridView.DataKeys[e.Row.RowIndex].Values["pb_SoftName"].ToString();
                string RegType = MyGridView.DataKeys[e.Row.RowIndex].Values["RegType"].ToString();
                //int Quatity = Convert.ToInt32(MyGridView.DataKeys[e.Row.RowIndex].Values["Quatity"]);
                DropDownList ddlRegType = (DropDownList)e.Row.Cells[1].FindControl("ddlRegType");
                TextBox txtUserName = (TextBox)e.Row.Cells[1].FindControl("txtUserName");
                TextBox txtRZM = (TextBox)e.Row.Cells[1].FindControl("txtRZM");
                RadioButtonList radio_8 = (RadioButtonList)e.Row.Cells[2].FindControl("radio_8");
                RadioButtonList radio_1 = (RadioButtonList)e.Row.Cells[2].FindControl("radio_1");
                RadioButtonList radio_9 = (RadioButtonList)e.Row.Cells[2].FindControl("radio_9");
                RadioButtonList radio_7 = (RadioButtonList)e.Row.Cells[2].FindControl("radio_7");
                RadioButtonList radio_6 = (RadioButtonList)e.Row.Cells[2].FindControl("radio_6");
                TextBox txtDays = (TextBox)e.Row.Cells[2].FindControl("txtDays");
                Label lblPrice = (Label)e.Row.Cells[4].FindControl("lblPrice");
                ddlRegType.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                txtUserName.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                txtRZM.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                radio_8.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                radio_1.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                radio_9.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                radio_7.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                radio_6.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                txtDays.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                lblPrice.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                CheckState(ddlRegType, RegType);
                DisplayUnameRZM(e.Row);
                CreateRadioList(ddlRegType.SelectedValue, e.Row);

                string pb_TypeName = MyGridView.DataKeys[e.Row.RowIndex].Values["pb_TypeName"].ToString();
                if (pb_TypeName == "出票系统一" || pb_TypeName == "出票系统二")
                {
                    ddlRegType.SelectedValue = "0";
                    ddlRegType.Items[1].Enabled = false;
                    ddlRegType.Items[3].Enabled = false;
                    ddlRegType.Items[4].Enabled = false;
                    ddlRegType.Items[5].Enabled = false;
                }
                else
                {
                    ddlRegType.Items[1].Enabled = true;
                    ddlRegType.Items[3].Enabled = true;
                    ddlRegType.Items[4].Enabled = true;
                    ddlRegType.Items[5].Enabled = true;
                }
            }
        }

        /// <summary>
        /// 判断是否显示用户名与认证码
        /// </summary>
        private void DisplayUnameRZM(GridViewRow row)
        {
            int rowIndex = row.RowIndex;
            Panel pnlUserName = ((Panel)row.Cells[2].FindControl("pnlUserName"));
            Panel pnlRZM = ((Panel)row.Cells[2].FindControl("pnlRZM"));
            DropDownList ddlRegType = ((DropDownList)row.Cells[2].FindControl("ddlRegType"));
            TextBox txtUserName = (TextBox)row.FindControl("txtUserName");
            TextBox txtRZM = (TextBox)row.FindControl("txtRZM");

            string RegType = MyGridView.DataKeys[rowIndex].Values["RegType"].ToString();
            string result = "";
            string[] types = RegType.Split(new char[] { '|' });
            if (types.Length > 2 && !string.IsNullOrEmpty(types[2]))
            {
                result = types[2];
            }
            if (ddlRegType.SelectedValue != "-1")
            {
                if (ddlRegType.SelectedValue == "8")
                {
                    txtUserName.Text = result;
                    pnlUserName.Visible = true;
                    pnlRZM.Visible = false;
                }
                else if (ddlRegType.SelectedValue == "1" || ddlRegType.SelectedValue == "9")
                {
                    txtRZM.Text = result;
                    pnlUserName.Visible = false;
                    pnlRZM.Visible = true;
                }
                else
                {
                    pnlUserName.Visible = false;
                    pnlRZM.Visible = false;
                }
            }
            else
            {
                pnlUserName.Visible = false;
                pnlRZM.Visible = false;
            }
        }

        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            WebFunc.DelShoppingCartByID(e.CommandArgument.ToString());
            BindShoppingCart();
            this.lblSumPrice.InnerText = WebFunc.CalcTotalPrice().ToString();

            if (MyGridView.Rows.Count <= 1)
            {
                Response.Redirect("~/ShowShoppingCart.aspx");
            }
        }

        /// <summary>
        /// 网络注册方式价格选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void radio_8_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList rbl8 = (RadioButtonList)sender;
            int rowIndex = Convert.ToInt32(rbl8.Attributes["rowIndex"]);
            ListItem li = rbl8.SelectedItem;
            TextBox txtDays = (TextBox)MyGridView.Rows[rowIndex].FindControl("txtDays");
            Panel pnlDays = (Panel)MyGridView.Rows[rowIndex].FindControl("pnlDays");
            if (li == null)
            {
                rbl8.Items[0].Selected = true;
                li = rbl8.SelectedItem;
            }

            if (li.Text.Contains("/天"))
            {
                pnlDays.Visible = true;
                //txtDays.Text = "50";
                txtDays.Text = "30";
                CalCurrentRowPrice(MyGridView.Rows[rowIndex], Input.FilterAll(txtDays.Text));
            }
            else
            {
                pnlDays.Visible = false;
                CalCurrentRowPrice(MyGridView.Rows[rowIndex]);
            }
            BindShoppingCart();
        }
        /// <summary>
        /// 计算当前行价格和总价格
        /// </summary>
        /// <param name="rowIndex"></param>
        private void CalCurrentRowPrice(GridViewRow row)
        {
            try
            {
                int rowIndex = row.RowIndex;
                //用户名或者验证码start
                Panel pnlUserName = ((Panel)row.Cells[2].FindControl("pnlUserName"));
                Panel pnlRZM = ((Panel)row.Cells[2].FindControl("pnlRZM"));
                string temp = "";
                if (pnlUserName.Visible)
                {
                    TextBox txtUserName = (TextBox)row.FindControl("txtUserName");
                    temp = Input.FilterAll(txtUserName.Text);
                }
                else if (pnlRZM.Visible)
                {
                    TextBox txtRZM = (TextBox)row.FindControl("txtRZM");
                    temp = Input.FilterAll(txtRZM.Text);
                }
                //用户名或者验证码end
                DropDownList ddlRegType = (DropDownList)row.Cells[1].FindControl("ddlRegType");
                long CartID = Convert.ToInt64(MyGridView.DataKeys[rowIndex].Values["CartID"]);
                //TextBox txtQuatity = ((TextBox)row.Cells[3].FindControl("txtQuatity"));           
                RadioButtonList rblPrice = (RadioButtonList)row.Cells[2].FindControl("radio_" + ddlRegType.SelectedValue);
                string pb_SoftName = MyGridView.DataKeys[rowIndex].Values["pb_SoftName"].ToString();


                //计算useTime列start
                Panel pnlDays = (Panel)MyGridView.Rows[rowIndex].FindControl("pnlDays");
                string useTime1 = "";
                string useTime2 = "";
                TextBox txtDays = (TextBox)MyGridView.Rows[rowIndex].FindControl("txtDays");
                RadioButtonList radio_8 = (RadioButtonList)MyGridView.Rows[rowIndex].Cells[2].FindControl("radio_8");
                if (rblPrice == null)
                {
                    ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "软件：" + pb_SoftName + "；您没有选择任何注册方式！", 370, "2", "", "", false, false) + "", false);
                    return;
                }
                if (ddlRegType.SelectedValue == "8")
                {
                    if (pnlDays.Visible)
                    {
                        useTime1 = "2";
                        useTime2 = txtDays.Text;
                    }
                    else
                    {
                        useTime1 = "1";
                        if (radio_8.SelectedIndex == 0)
                        {
                            useTime2 = "3";
                        }
                        else if (radio_8.SelectedIndex == 1)
                        {
                            useTime2 = "6";
                        }
                        else if (radio_8.SelectedIndex == 2)
                        {
                            useTime2 = "12";
                        }

                    }
                }
                else
                {
                    if (rblPrice.SelectedItem != null)
                    {
                        if (rblPrice.SelectedItem.Text.Contains("/年"))
                        {
                            useTime1 = "4";
                        }
                        else if (rblPrice.SelectedItem.Text.Contains("/套"))
                        {
                            useTime1 = "7";
                        }
                    }
  
                }
                //计算useTime列end
                Pbzx.Model.PBnet_ShoppingCart CartModel = WebFunc.UpdateShoppingCart(CartID.ToString(), "1", ddlRegType.SelectedValue, rblPrice.SelectedValue, temp, useTime1 + "|" + useTime2);
                string regType = CartModel.RegType;
                ((Label)row.Cells[4].FindControl("lblPrice")).Text = GetOneProductPrice(CartID, regType);
                this.lblSumPrice.InnerText = WebFunc.CalcTotalPrice().ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/ShowShoppingCart.aspx");
            }
        }

        /// <summary>
        /// 计算当前行价格和总价格重载
        /// </summary>
        /// <param name="rowIndex"></param>
        private void CalCurrentRowPrice(GridViewRow row, string days)
        {
            int rowIndex = row.RowIndex;
            //用户名或者验证码start
            Panel pnlUserName = ((Panel)row.Cells[2].FindControl("pnlUserName"));
            Panel pnlRZM = ((Panel)row.Cells[2].FindControl("pnlRZM"));
            string temp = "";
            if (pnlUserName.Visible)
            {
                TextBox txtUserName = (TextBox)row.FindControl("txtUserName");
                temp = Input.FilterAll(txtUserName.Text);
            }
            else if (pnlRZM.Visible)
            {
                TextBox txtRZM = (TextBox)row.FindControl("txtRZM");
                temp = Input.FilterAll(txtRZM.Text);
            }
            //用户名或者验证码end

            DropDownList ddlRegType = (DropDownList)row.Cells[1].FindControl("ddlRegType");
            long CartID = Convert.ToInt64(MyGridView.DataKeys[rowIndex].Values["CartID"]);
            //TextBox txtQuatity = ((TextBox)row.Cells[3].FindControl("txtQuatity"));
            RadioButtonList rblPrice = (RadioButtonList)row.Cells[2].FindControl("radio_" + ddlRegType.SelectedValue);

            string pb_SoftName = MyGridView.DataKeys[rowIndex].Values["pb_SoftName"].ToString();
            if (rblPrice == null)
            {
                ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "软件：" + pb_SoftName + "；您没有选择任何注册方式！", 370, "2", "", "", false, false) + "", false);
                return;
            }

            //计算useTime列start
            Panel pnlDays = (Panel)MyGridView.Rows[rowIndex].FindControl("pnlDays");
            string useTime1 = "";
            string useTime2 = "";
            TextBox txtDays = (TextBox)MyGridView.Rows[rowIndex].FindControl("txtDays");
            RadioButtonList radio_8 = (RadioButtonList)MyGridView.Rows[rowIndex].Cells[2].FindControl("radio_8");
            if (ddlRegType.SelectedValue == "8")
            {
                if (pnlDays.Visible)
                {
                    useTime1 = "2";
                    useTime2 = txtDays.Text;
                }
                else
                {
                    useTime1 = "1";
                    if (radio_8.SelectedIndex == 0)
                    {
                        useTime2 = "3";
                    }
                    else if (radio_8.SelectedIndex == 1)
                    {
                        useTime2 = "6";
                    }
                    else if (radio_8.SelectedIndex == 2)
                    {
                        useTime2 = "12";
                    }
                }
            }
            else
            {
                if (rblPrice.SelectedIndex == 0)
                {
                    useTime1 = "4";
                }
                else if (rblPrice.SelectedIndex == 1)
                {
                    useTime1 = "7";
                }
            }
            //计算useTime列end

            Pbzx.Model.PBnet_ShoppingCart CartModel = WebFunc.UpdateShoppingCart(CartID.ToString(), "1", ddlRegType.SelectedValue + "*" + days, rblPrice.SelectedValue, temp, useTime1 + "|" + useTime2);
            string regType = CartModel.RegType;

            ((Label)row.Cells[4].FindControl("lblPrice")).Text = GetOneProductPrice(CartID, regType);
            this.lblSumPrice.InnerText = WebFunc.CalcTotalPrice().ToString();
        }

        /// <summary>
        ///清空购物车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClearShoppingCart_Click(object sender, ImageClickEventArgs e)
        {
            WebFunc.ClearCart(Method.GetCartGuid());
            BindShoppingCart();
            lblSumPrice.InnerText = "0.00";
            Response.Redirect("~/ShowShoppingCart.aspx");
        }

        #region 以前数量改变
        ///// <summary>
        ///// 数量改变事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void txtQuatity_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtQuatity = (TextBox)sender;
        //    int rowIndex = Convert.ToInt32(txtQuatity.Attributes["rowIndex"]);
        //    string pb_SoftName = MyGridView.DataKeys[rowIndex].Values["pb_SoftName"].ToString();
        //    string tempYZ = Method.CheckIsNum("购买数量", Input.FilterAll(txtQuatity.Text),1,9999);
        //    if (!string.IsNullOrEmpty(tempYZ))
        //    {
        //        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "提示", "alert('软件：" + pb_SoftName + "；" + tempYZ + "')", true);
        //        return;
        //    }   
        //    CalCurrentRowPrice(MyGridView.Rows[rowIndex]);
        //}
        #endregion

        /// <summary>
        ///购买天数改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtDays_TextChanged(object sender, EventArgs e)
        {
            TextBox txtDays = (TextBox)sender;
            int rowIndex = Convert.ToInt32(txtDays.Attributes["rowIndex"]);
            string pb_SoftName = MyGridView.DataKeys[rowIndex].Values["pb_SoftName"].ToString();
            //string tempYZ = Method.CheckIsNum("天数", Input.FilterAll(txtDays.Text), 50, 999999);
            string tempYZ = Method.CheckIsNum("天数", Input.FilterAll(txtDays.Text), 30, 999999);

            if (!string.IsNullOrEmpty(tempYZ))
            {
                ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("错误！", "软件：" + pb_SoftName + "；" + tempYZ + "", 400, "2", "", "", false, false) + "", false);
                return;
            }
            //else if (Convert.ToInt32(Input.FilterAll(txtDays.Text)) < 50)
            else if (Convert.ToInt32(Input.FilterAll(txtDays.Text)) < 30)
            {

            }

            CalCurrentRowPrice(MyGridView.Rows[rowIndex], Input.FilterAll(txtDays.Text));
            BindShoppingCart();
        }



        /// <summary>
        /// 单机注册方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void radio_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList radio_1 = (RadioButtonList)sender;
            int rowIndex = Convert.ToInt32(radio_1.Attributes["rowIndex"]);
            CalCurrentRowPrice(MyGridView.Rows[rowIndex]);
            BindShoppingCart();
        }

    }
}



































