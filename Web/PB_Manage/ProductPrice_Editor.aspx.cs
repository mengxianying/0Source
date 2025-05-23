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
using System.Text;

namespace Pbzx.Web.PB_Manage
{
    public partial class ProductPrice_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_SoftClass softClassBLL = new Pbzx.BLL.PBnet_SoftClass();
            //绑定软件类别
            softClassBLL.BindSoftClass(this.ddlParent, 0);
            //绑定软件版本类别
            Pbzx.Common.Method.BindProductVersionByEnum(ref this.ddlSoftVersion);
            //软件狗价格赋初始值
            this.txtSoftdog.Text = WebInit.webBaseConfig.SoftdogPrice.ToString();
            this.txtSoftdog.Enabled = false;
            //更新时间赋初始值
            txtDatUpdateTime.Text = DateTime.Now.ToString();
            //绑定
            BindData();
        }
        private void BindData()
        {

            Pbzx.Model.PBnet_ProductPrice MyPrice;
            Pbzx.BLL.PBnet_ProductPrice PriceBLL = new Pbzx.BLL.PBnet_ProductPrice();
            Pbzx.BLL.PBnet_Product productBLL = new Pbzx.BLL.PBnet_Product();
            string str = Request.QueryString["ID"];
            if (str != null && OperateText.IsNumber(str))
            {
                this.IsAuthority(2);
                lblAction.Text = "修改";
                btnCancel.Visible = true;
                btnCancel.Attributes.Add("onclick", "history.back();return false;");
                MyPrice = PriceBLL.GetModel(Convert.ToInt32(str));
                ddlSoftVersion.SelectedValue = MyPrice.VarVersionType;
            }
            else
            {
                this.IsAuthority(1);
                lblAction.Text = "新增";
                btnCancel.Visible = false;
                MyPrice = new Pbzx.Model.PBnet_ProductPrice();
                if (!string.IsNullOrEmpty(Request["productID"]) && OperateText.IsNumber(Request["productID"]))
                {
                    //绑定商品属性
                   BindProduct(productBLL.GetModelByCache(int.Parse(Request["productID"])));
                }
                else
                {
                    Alert();
                }
            }

            hfPriceID.Value = MyPrice.IntPriceID.ToString();
            


        }

        private void BindProduct(Pbzx.Model.PBnet_Product model)
        {
            //软件所属类别
            this.ddlParent.SelectedValue = model.pb_ClassID.ToString();
            this.ddlParent.Enabled = false;
            //软件类别名称
            this.txtPb_SoftName.Text = model.pb_SoftName;
            this.txtPb_SoftName.Enabled = false;
        }

        /// <summary>
        /// 弹出警告方法
        /// </summary>
        private void Alert()
        {
            JS.Alert("没有此商品相关价格！", "ProductPrice_Manage.aspx");
            return; 
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (this.btnReset.Text == "重设")
            {
                this.txtSoftdog.Enabled = true;
                this.btnReset.Text = "保存此价格";
            }
            else
            {
                Decimal price = 0;
                if (!Decimal.TryParse(this.txtSoftdog.Text, out price))
                {
                    JS.Alert("您设定的价格格式不正确！");
                    return;
                }
                WebBaseConfig wb = WebInit.webBaseConfig;
                wb.SoftdogPrice = decimal.Parse(this.txtSoftdog.Text);
                WebInit.webBaseConfig = wb;
                this.txtSoftdog.Enabled = false;
                this.btnReset.Text = "重设";
            }
            
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            //Pbzx.BLL.PBnet_ProductPrice priceBLL = new Pbzx.BLL.PBnet_ProductPrice();
            //StringBuilder strErrMsg = new StringBuilder();
            //if (this.btn_Save.Text == "保存此价格")
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert("您还没有保存软件狗价格，请先保存！"));
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtVarNetPrice.Text))
            //{
            //    strErrMsg.Append("网络注册方式 价格不能为空.\\r\\n");
            //}
            //if(this.ddlSoftVersion.SelectedValue != "专业版" && this.ddlVarUseTime1.SelectedValue == "一年" )
            //{
            //    strErrMsg.Append("单机注册方式 目前只有专业版才有一年期限的价格.\\r\\n");
            //}
            //if(string.IsNullOrEmpty(this.txtVarNetPrice1.Text))
            //{
            //    strErrMsg.Append("单机注册方式 价格不能为空.\\r\\n");
            //}
            //if (!Common.OperateText.IsNumber(this.txtOrderID))
            //{
            //    strErrMsg.Append("您输入的排序编号格式不正确，请输入数字.\\r\\n");
            //}

            //if (strErrMsg != "")
            //{
            //   string  strErrMsg1 = "您提交的新闻信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg.ToString() + "\\r\\n请修改后再重新提交.";
            //    ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg1));
            //    return;
            //}
            //else
            //{ 
               
               
            //}
        }
    }
}
