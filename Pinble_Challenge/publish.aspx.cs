using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pbzx.Common;

namespace Pinble_Challenge
{
    public partial class publish : System.Web.UI.Page
    {
        //定义登录用户
        public static string userName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                userName = Method.Get_UserName.ToString();
            }
        }
    }
}