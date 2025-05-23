using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Pinble_Market.AppCod
{
    public enum SessionName
    {
        HasNotPayedPrice,
        UserLogined,
        AdminLogined,
        CartGuid,
    }
}
