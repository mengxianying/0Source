using System;
using System.Web;
using System.Web.Services;
using System.Data;

namespace Pinble_Help
{
    /// <summary>
    /// webser 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]

    public class webser : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        /// <summary>
        /// 获取下载地址
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        [WebMethod]
        public string DownLoadMian(int cid)
        {
            Pbzx.BLL.Help_Download get_d = new Pbzx.BLL.Help_Download();
           
            DataSet ds = get_d.GetList("d_type=" + cid);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["d_download"].ToString();
            }
            return "";
        }
    }
}
