using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Globalization;
using System.IO;
using System.Configuration;
using Pbzx.Common;

namespace Pbzx.Web.AppCode
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CheckImgLinks : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest req = context.Request;
            string IMG_path = req.PhysicalPath;
            string contentType;
            if (req.UrlReferrer != null && req.UrlReferrer.Host.Length > 0)
            {
                //context.Request.UrlReferrer.Host == ConfigurationManager.AppSettings["HostName"];
                //CultureInfo.InvariantCulture.CompareInfo.Compare(req.Url.Host, req.UrlReferrer.Host, CompareOptions.IgnoreCase) != 0
                if (context.Request.UrlReferrer.Host != ConfigurationManager.AppSettings["HostName"])
                {
                   // IMG_path = context.Server.MapPath("~/Images/Web/errorLinkImg.jpg");
                }
                contentType = GetContentType(IMG_path);
                if (File.Exists(IMG_path))
                {
                    context.Response.StatusCode = 200;
                    context.Response.ContentType = contentType;
                    context.Response.WriteFile(IMG_path);
                }
                //else
                //{
                //  //  context.Response.StatusCode = 404;
                //   // context.Response.Status = "无法找到你请求的文件";
                //}
            }
            #region
            ////判断是否是本地网站引用图片，如果是则返回正确的图片
            //if (context.Request.UrlReferrer.Host == "www.pinble2.com")
            //{
            //    //设置客户端缓冲时间过期时间为0，即立即过期
            //    context.Response.Expires = 0;
            //    //清空服务器端为此会话开启的输出缓存
            //    context.Response.Clear();
            //    //设置输出文件类型
                
            //    //context.Response.ContentType = "image/jpg";
            //    context.Response.ContentType = context.Request.ContentType;
            //    //将请求文件写入到输出缓存中
            //    context.Response.WriteFile(context.Request.PhysicalPath);
            //    //将输出缓存中的信息传送到客户端
            //    context.Response.End();
            //}
            ////如果不是本地引用，则是盗链本站图片
            //else
            //{
            //    //设置客户端缓冲时间过期时间为0，即立即过期
            //    context.Response.Expires = 0;
            //    //清空服务器端为此会话开启的输出缓存
            //    context.Response.Clear();
            //    //设置输出文件类型
            //    context.Response.ContentType = "image/jpg";
            //    //将请求文件写入到输出缓存中
            //    context.Response.WriteFile(context.Request.PhysicalApplicationPath + "Images/Web/errorLinkImg.jpg");
            //    //将输出缓存中的信息传送到客户端
            //    context.Response.End();
            //}
            #endregion
        }

        private string GetContentType(string path)
        {
            string extension = Path.GetExtension(path);
            string type;
            switch (extension)
            {
                case ".gif":
                    type = "image/gif";
                    break;
                case ".jpg":
                    type = "image/Jpeg";
                    break;
                case ".png":
                    type = "image/png";
                    break;
                case ".swf":
                    type = "application/x-shockwave-flash";
                    break;
                default:
                    type = "";
                    break;
            }
            return type;
        }



        //该属性表示HTTP请求是否可以使用当前处理
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
