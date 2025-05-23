using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace Pbzx.Web
{
    /// <summary>
    /// ��ʾһ����ֹ�ظ��ύ�İ�ť�����û�������ť�Ժ󣬸ð�ť��ң������ٴε�����ֱ�����¼���ҳ�������ת��
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ClickOnceButton runat=server></{0}:ClickOnceButton>")]
    public class ClickOnceButton : System.Web.UI.WebControls.Button
    {
        /// <summary>
        /// Ĭ�ϵĹ��캯����
        /// </summary>
        public ClickOnceButton()
        {
            this.ViewState["afterSubmitText"] = "�����ύ�����Ժ�...";
            base.Text = "ClickOnceButton";
            this.ViewState["showMessageBox"] = false;
            this.ViewState["warningText"] = "ȷ��Ҫ�ύ��";
        }

        /// <summary>
        /// ��ȡ�����õ�����ť�󣬰�ť������ʾ���ı���
        /// </summary>
        [Bindable(true),
        Category("Appearance"),
        DefaultValue("�����ύ�����Ժ�..."),
        Description("ָʾ�����ύ�󣬰�ť������ʾ���ı���")]
        public string AfterSubmitText
        {
            get
            {
                string afterSubmitText = (string)this.ViewState["afterSubmitText"];
                if (afterSubmitText != null)
                {
                    return afterSubmitText;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                this.ViewState["afterSubmitText"] = value;
            }
        }

        [Bindable(true),
        Category("Appearance"),
        DefaultValue(false),
        Description("ָʾ�Ƿ�Ҫ��ʾһ����ʾ��")]
        public bool ShowMessageBox
        {
            get
            {
                return (bool)this.ViewState["showMessageBox"];
            }
            set
            {
                this.ViewState["showMessageBox"] = value;
            }
        }


        [Bindable(true),
        Category("Appearance"),
        DefaultValue("ȷ��Ҫ�ύ��"),
        Description("ָʾ��ʾ���������������ݡ�")]
        public string WarningText
        {
            get
            {
                return (string)this.ViewState["warningText"];
            }
            set
            {
                this.ViewState["warningText"] = value;
            }
        }

        /// <summary>
        /// AddAttributesToRender
        /// </summary>
        /// <param name="writer">HtmlTextWriter</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            System.Text.StringBuilder ClientSideEventReference = new System.Text.StringBuilder();

            if (((this.Page != null) && this.CausesValidation) && (this.Page.Validators.Count > 0))
            {
                ClientSideEventReference.Append("if (typeof(Page_ClientValidate) == 'function'){if (Page_ClientValidate() == false){return false;}}");
            }
            //ShowMessageBox?
            if (this.ShowMessageBox)
            {
                ClientSideEventReference.Append("if (!confirm('" + this.WarningText + "')){return false}");
            }
            ClientSideEventReference.AppendFormat("this.value = '{0}';", (string)this.ViewState["afterSubmitText"]);
            ClientSideEventReference.Append("this.disabled = true;");
            ClientSideEventReference.Append(this.Page.ClientScript.GetPostBackEventReference(this, string.Empty));


            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, ClientSideEventReference.ToString(), true);
            base.AddAttributesToRender(writer);
        }
    }
}
