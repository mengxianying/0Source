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

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class Config_Editor : AdminBasic
    {
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Pbzx.BLL.CN_Config configBLL = new Pbzx.BLL.CN_Config();
                Pbzx.Model.CN_Config MyConfig;
                string str = Request.QueryString["ID"];

                MyConfig = configBLL.GetModel(Convert.ToInt32(str));

                lblName.Text = MyConfig.ConfigName;
                txtValue.Text = MyConfig.ConfigValue;
                txtDetails.Text = MyConfig.ConfigDetails;
                lblFlag.Text = (MyConfig.ConfigFlag).ToString();
                lblStatus.Text = GetFlag(MyConfig.Status.ToString());

            }
        }
        /// <summary>
        /// 格式化显示数据
        /// </summary>
        /// <param name="objnum"></param>
        /// <returns></returns>
        protected string GetFlag(object objnum)
        {
            string Flag = "";
            int intnum = int.Parse(objnum.ToString());
            switch (intnum)
            {
                case 0:
                    Flag = "<font color='#009900'>投入使用</font>";
                    break;
                case 1:
                    Flag = "<font color='#666666'>等待使用</font>";
                    break;
                case 10:
                    Flag = "<font color='#660033'>不许修改</font>";
                    break;
                default:
                    Flag = "";
                    break;
            }
            return Flag;
        }
        /// <summary>
        /// 点击修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bt_ok_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.CN_Config configBLL = new Pbzx.BLL.CN_Config();
            string str = Request.QueryString["ID"];
            Pbzx.Model.CN_Config MyConfig = configBLL.GetModel(Convert.ToInt32(str));

            

            //MyConfig.ConfigName = this.lblName.Text;
            MyConfig.ConfigValue = this.txtValue.Text;
            MyConfig.ConfigDetails = this.txtDetails.Text;
            //虚判断他的状态是否能用，当为不许修改的时候不给他启用否则给他等待启用
            if (MyConfig.Status == 1 || MyConfig.Status == 0)
            {
                MyConfig.Status = 1;
            }  
            //MyConfig.ConfigFlag = int.Parse(this.lblFlag.Text);
            //MyConfig.Status = int.Parse(this.lblStatus.Text);

            if (configBLL.Update(MyConfig))
            {
                // ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("修改成功."));               
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改配置信息[" + MyConfig.ConfigName + "].");
                Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            }
            else
            {
                Response.Write("<script>alert('修改失败');</script>");
            }
        }
    }
}
