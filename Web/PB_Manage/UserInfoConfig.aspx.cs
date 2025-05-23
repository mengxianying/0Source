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

namespace Pbzx.Web.PB_Manage
{
    public partial class UserInfoConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                BindUserConfig();
            }
        }
        /// <summary>
        /// 网站用户配置 保存按钮事件 
        /// </summary>
        protected void btmUserConfig_Click(object sender, EventArgs e)
        {
            UserConfig userConfig = WebInit.userConfig;
            userConfig.PassWordQuestion = this.txtPassWordQuestion.Text;
            userConfig.Banks = this.txtBanks.Text;
            userConfig.PersonRegeditAgreement = wePersonRegeditAgreement.Text;
            userConfig.PersonRegeditAgreementGao = wePersonRegeditAgreementGao.Text;
            userConfig.BrokerAgreement = weBrokerAgreement.Text;
            userConfig.AgentAgreement = weAgentAgreement.Text;
            WebInit.userConfig = userConfig;
            BindUserConfig();
        }

        /// <summary>
        /// 网站用户配置绑定数据
        /// </summary>
        private void BindUserConfig()
        {
            UserConfig userConfig = WebInit.userConfig;
            this.txtPassWordQuestion.Text = userConfig.PassWordQuestion;
            this.txtBanks.Text = userConfig.Banks;
            wePersonRegeditAgreement.Text = userConfig.PersonRegeditAgreement;
            wePersonRegeditAgreementGao.Text = userConfig.PersonRegeditAgreementGao;
            weBrokerAgreement.Text = userConfig.BrokerAgreement;
            weAgentAgreement.Text = userConfig.AgentAgreement;
        }

    }
}
