using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Pbzx.Common;

namespace Pinble_Ask
{
    public class AskUserBasic : System.Web.UI.Page
    {
        public AskUserBasic()
        {
            this.Load += new EventHandler(this.Basic_Load);
        }

        private void Basic_Load(object sender, System.EventArgs e)
        {
            //����Ƿ��ѿ�ͨ
            AskUserBasic.IsOpen();           
        }

        /// <summary>
        /// �ж��Ƿ��¼
        /// </summary>
        public static void IsOpen()
        {
            LoginSort login = new LoginSort();

            if (!login[ELoginSort.ask_User.ToString()])
            {
                HttpContext.Current.Response.Write("<script>if(confirm('����δ��ͨƴ���ɣ��Ƿ�ͨ��')){}else{window.top.location.href='" + WebInit.ask.WebUrl + "';}</script>");
                HttpContext.Current.Response.End();
                return;
            }
        }
    }
}
