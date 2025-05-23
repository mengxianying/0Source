using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    public class JS
    {
        private static string strJsHead = "<script language=\"javascript\">";
        private static string strJsFoot = "</script>";

        #region Alert:弹出消息框.
        /// <summary>
        /// 弹出消息框.
        /// </summary>
        /// <param name="msg">消息内容.</param>
        /// <returns>包含script标签的字符.</returns>
        public static string Alert(string msg)
        {
            string strJs = strJsHead + "alert(\"" + msg + "\");" + strJsFoot;
            return strJs;
        }

        
        /// <summary>
        /// 弹出消息框.
        /// </summary>
        /// <param name="msg">消息内容.</param>
        /// <param name="url">要跳转的Url.</param>
        /// <returns>包含script标签的字符.</returns>
        public static string Alert(string msg, string url)
        {
            string strJs = strJsHead + "alert(\"" + msg + "\");document.location=\"" + url + "\";" + strJsFoot;
            return strJs;
        }


        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="msg">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="type">类型</param>
        /// <param name="callBack">回调方法一</param>
        /// <param name="callBack2">回调方法二</param>
        /// <param name="methodType1">回到方法一类型</param>
        /// <param name="methodType2">回到方法二类型</param>
        /// <returns>js串</returns>
        public static string myAlert(string title, string msg, int width, string type, string callBack, string callBack2, bool methodType1, bool methodType2)
        {
            string strJs = "";
            string myTitle = "提示";
            if(!string.IsNullOrEmpty(title))
            {
                myTitle = title;
            }
            int myWidth = 480;
            if (width <= 580)
            {
                myWidth = width;
            }
            else
            {
                myWidth = 580;
            }

            string myCallBack = "";
            if (!string.IsNullOrEmpty(callBack))
            {
                if (methodType1)
                {
                    myCallBack = callBack + "();";
                }
                else
                {
                    myCallBack = callBack + ";";
                }
               
            }

            string myCallBack2 = "";
            if (!string.IsNullOrEmpty(callBack2))
            {
                if (methodType2)
                {
                    myCallBack2 = callBack2 + "();";
                }
                else
                {
                    myCallBack2 = callBack2+";";
                }
            }


            string FZ = " $('#dialog2').dialog('destroy');$('#dialog2').attr('title','" + myTitle + "'); $('#dialog2').html('<p style=padding:20px >" + msg + "</p>');";
            string tempResult = FZ + "$('#dialog2').dialog({autoOpen: false,modal: true,width: " + myWidth + ", buttons: { '取消':function() {" + myCallBack2 + " $(this).dialog('close');$('#dialog2').dialog('destroy'); }, '确定':function() {" + myCallBack + " $(this).dialog('close');$('#dialog2').dialog('destroy'); } } });$('#dialog2').dialog('open');";

            StringBuilder sb = new StringBuilder();
            sb.Append("if (document.readyState=='complete'){");
            sb.Append(tempResult);
            sb.Append("} else{ document.onreadystatechange = function()  {if (document.readyState=='complete'){");

            sb.Append(tempResult);
            sb.Append("}}}");   

            strJs = strJsHead + sb.ToString()  + strJsFoot; 
            
            return strJs;
        }


        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="msg">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="type">类型</param>
        /// <param name="callBack">回调方法一</param>
        /// <param name="callBack2">回调方法二</param>
        /// <param name="methodType1">回到方法一类型</param>
        /// <param name="methodType2">回到方法二类型</param>
        /// <returns>js串</returns>
        public static string myAlert1(string title, string msg, int width, string type, string callBack, string callBack2, bool methodType1, bool methodType2)
        {
            string strJs = "";
            string myTitle = "提示";
            if (!string.IsNullOrEmpty(title))
            {
                myTitle = title;
            }
            int myWidth = 480;
            if (width <= 580)
            {
                myWidth = width;
            }
            else
            {
                myWidth = 580;
            }
            string myCallBack = "";
            if (!string.IsNullOrEmpty(callBack))
            {
                if (methodType1)
                {
                    myCallBack = callBack + "();";
                }
                else
                {
                    myCallBack = callBack + ";";
                }
            }

            // string FZ1 = "$('#dialog1').html('<p>" + msg + "</p>');";$('#dialog1').dialog('destroy');
            string FZ = " $('#dialog1').attr('title','" + myTitle + "'); $('#dialog1').html('<p style=padding:20px >" + msg + "</p>');";

            string tempResult = FZ + "$('#dialog1').dialog({autoOpen: false,modal: true,width: " + myWidth + ", buttons: {'确定':function() {" + myCallBack + " $(this).dialog('close');$('#dialog1').dialog('destroy'); } } });$('#dialog1').dialog('open');"; 

            StringBuilder sb = new StringBuilder();
            sb.Append("if (document.readyState=='complete'){");                 
            sb.Append(tempResult);
            sb.Append("} else{ document.onreadystatechange = function()  {if (document.readyState=='complete'){");

            sb.Append(tempResult);
            sb.Append("}}}");   
  
         
            strJs = strJsHead + sb.ToString()+ strJsFoot; 
            return strJs;
        }




        /// <summary>
        /// 弹出消息框.
        /// </summary>
        /// <param name="msg">消息内容.</param>
        /// <param name="url">要跳转的Url.</param>
        /// <returns>包含script标签的字符.</returns>
        public static string Alert(string msg, string url, string type)
        {
            string strJs = strJsHead + "SetDialogValue(\"" + msg + "\");document.location=\"" + url + "\";" + strJsFoot;

            return strJs;
        }

        #endregion

        #region Back:浏览器历史记录后退.
        /// <summary>
        /// 浏览器历史记录后退.
        /// </summary>
        /// <returns>包含script标签的字符.</returns>
        public static string Back()
        {
            string strJs = strJsHead + "history.back(1);" + strJsFoot;
            return strJs;
        }

        /// <summary>
        /// 后退.
        /// </summary>
        /// <param name="step">后退的步数.</param>
        /// <returns>包含script标签的字符.</returns>
        public static string Back(int step)
        {
            string strJs = strJsHead + "history.back(" + step + ");" + strJsFoot;
            return strJs;
        }
        #endregion

        #region Go:浏览器历史记录前进或后退.
        /// <summary>
        /// 浏览器历史记录前进或后退.
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public static string Go(int step)
        {
            string strJs = strJsHead + "history.go(" + step + ")" + strJsFoot;
            return strJs;
        }
        #endregion

        #region Redirect:跳转到指定的URL.
        /// <summary>
        /// 跳转到指定的URL.
        /// </summary>
        /// <param name="sUrl">要跳转到的URL地址.</param>
        /// <returns>包含script标签的字符.</returns>
        public static string Redirect(string sUrl)
        {
            string strJs = "document.location=\"" + sUrl + "\";";
            strJs = strJsHead + strJs + strJsFoot;
            return strJs;
        }
        #endregion

        #region Replace:改变当前页面的URL.
        /// <summary>
        /// 改变当前页面的URL.
        /// </summary>
        /// <param name="sUrl">改变后的URL地址.</param>
        /// <returns>包含script标签的字符.</returns>
        public static string Replace(string sUrl)
        {
            string strJs = "document.location.replace(\"" + sUrl + "\");";
            strJs = strJsHead + strJs + strJsFoot;
            return strJs;
        }
        #endregion

        #region CloseWindow:关闭当前浏览器窗口.
        /// <summary>
        /// 关闭当前浏览器窗口.
        /// </summary>
        /// <returns>包含script标签的字符.</returns>
        public static string CloseWindow()
        {
            string strJs = strJsHead + "window.close();" + strJsFoot;
            return strJs;
        }
        #endregion

        #region RegJs:为自定义的JS加上script标签.
        /// <summary>
        /// 为自定义的JS加上script标签.
        /// </summary>
        /// <param name="strJs">自定义的JS.</param>
        /// <returns>包含script标签的字符.</returns>
        public static string RegJs(string strJs)
        {
            string qdkRe = strJsHead + strJs + strJsFoot;
            return qdkRe;
        }
        #endregion

        #region Reload:重新载入当前页面.
        /// <summary>
        /// 重新载入当前页面.
        /// </summary>
        /// <returns>包含script标签的字符.</returns>
        public static string Reload()
        {
            string strJs = "document.location=self.location;";
            strJs = strJsHead + strJs + strJsFoot;
            return strJs;
        }
        #endregion

    }
}
