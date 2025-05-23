using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage.Platform.num
{
    /// <summary>
    /// DataList 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class DataList : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region 开奖号码
        /// <summary>
        /// 获取彩种的开奖号码
        /// </summary>
        /// <param name="lottID">彩种ID</param>
        /// <param name="issue">期号</param>
        /// <returns></returns>
        [WebMethod]
        public string lottOpenNum(int lottID, int issue)
        {
            string num = "";
            if (lottID == 9999)
            {
                num = Method.RlotteryNum(4, issue).Substring(0, 3);
            }
            else
            {
                num = Method.RlotteryNum(lottID, issue);
            }
            if (num == "")
            {
                return "暂无开奖号码";
            }

            return num;
        }
        #endregion
    }
}
