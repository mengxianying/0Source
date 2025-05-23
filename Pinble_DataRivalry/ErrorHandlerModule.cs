using System;
using System.Collections.Generic;
using System.Web;

namespace Pbzx.Web
{
    public class ErrorHandlerModule : IHttpModule
    {
        public void Dispose()
        {
        }
        public void Init(HttpApplication context)
        {
            context.Error += new EventHandler(context_Error);
        }
        public void context_Error(object sender, EventArgs e)
        {

            //此处处理异常
            HttpContext ctx = HttpContext.Current;
            HttpResponse response = ctx.Response;
            HttpRequest request = ctx.Request;
            //获取到HttpUnhandledException异常，这个异常包含一个实际出现的异常
            Exception ex = ctx.Server.GetLastError();
            //实际发生的异常
            Exception iex = ex.InnerException;            
            string path = request.RawUrl;         
            string message = "路径：" + path+"\r\n";
            string title = iex == null ? ex.Message : iex.Message;
            string content = iex == null ? ex.StackTrace : iex.StackTrace;
            message += "标题：" + title + "\r\n";
            message += "堆栈：" + content + "\r\n";
            if (!title.Contains("不存在"))
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("大底全局异常", message, true, true);      
            }     
            ctx.Server.ClearError();
            ctx.Server.Transfer("~/Error.htm"); 
        }
    }
}