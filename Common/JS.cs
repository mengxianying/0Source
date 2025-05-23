using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    public class JS
    {
        private static string strJsHead = "<script language=\"javascript\">";
        private static string strJsFoot = "</script>";

        #region Alert:������Ϣ��.
        /// <summary>
        /// ������Ϣ��.
        /// </summary>
        /// <param name="msg">��Ϣ����.</param>
        /// <returns>����script��ǩ���ַ�.</returns>
        public static string Alert(string msg)
        {
            string strJs = strJsHead + "alert(\"" + msg + "\");" + strJsFoot;
            return strJs;
        }

        
        /// <summary>
        /// ������Ϣ��.
        /// </summary>
        /// <param name="msg">��Ϣ����.</param>
        /// <param name="url">Ҫ��ת��Url.</param>
        /// <returns>����script��ǩ���ַ�.</returns>
        public static string Alert(string msg, string url)
        {
            string strJs = strJsHead + "alert(\"" + msg + "\");document.location=\"" + url + "\";" + strJsFoot;
            return strJs;
        }


        /// <summary>
        /// ������Ϣ��
        /// </summary>
        /// <param name="title">����</param>
        /// <param name="msg">����</param>
        /// <param name="width">���</param>
        /// <param name="type">����</param>
        /// <param name="callBack">�ص�����һ</param>
        /// <param name="callBack2">�ص�������</param>
        /// <param name="methodType1">�ص�����һ����</param>
        /// <param name="methodType2">�ص�����������</param>
        /// <returns>js��</returns>
        public static string myAlert(string title, string msg, int width, string type, string callBack, string callBack2, bool methodType1, bool methodType2)
        {
            string strJs = "";
            string myTitle = "��ʾ";
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
            string tempResult = FZ + "$('#dialog2').dialog({autoOpen: false,modal: true,width: " + myWidth + ", buttons: { 'ȡ��':function() {" + myCallBack2 + " $(this).dialog('close');$('#dialog2').dialog('destroy'); }, 'ȷ��':function() {" + myCallBack + " $(this).dialog('close');$('#dialog2').dialog('destroy'); } } });$('#dialog2').dialog('open');";

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
        /// ������Ϣ��
        /// </summary>
        /// <param name="title">����</param>
        /// <param name="msg">����</param>
        /// <param name="width">���</param>
        /// <param name="type">����</param>
        /// <param name="callBack">�ص�����һ</param>
        /// <param name="callBack2">�ص�������</param>
        /// <param name="methodType1">�ص�����һ����</param>
        /// <param name="methodType2">�ص�����������</param>
        /// <returns>js��</returns>
        public static string myAlert1(string title, string msg, int width, string type, string callBack, string callBack2, bool methodType1, bool methodType2)
        {
            string strJs = "";
            string myTitle = "��ʾ";
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

            string tempResult = FZ + "$('#dialog1').dialog({autoOpen: false,modal: true,width: " + myWidth + ", buttons: {'ȷ��':function() {" + myCallBack + " $(this).dialog('close');$('#dialog1').dialog('destroy'); } } });$('#dialog1').dialog('open');"; 

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
        /// ������Ϣ��.
        /// </summary>
        /// <param name="msg">��Ϣ����.</param>
        /// <param name="url">Ҫ��ת��Url.</param>
        /// <returns>����script��ǩ���ַ�.</returns>
        public static string Alert(string msg, string url, string type)
        {
            string strJs = strJsHead + "SetDialogValue(\"" + msg + "\");document.location=\"" + url + "\";" + strJsFoot;

            return strJs;
        }

        #endregion

        #region Back:�������ʷ��¼����.
        /// <summary>
        /// �������ʷ��¼����.
        /// </summary>
        /// <returns>����script��ǩ���ַ�.</returns>
        public static string Back()
        {
            string strJs = strJsHead + "history.back(1);" + strJsFoot;
            return strJs;
        }

        /// <summary>
        /// ����.
        /// </summary>
        /// <param name="step">���˵Ĳ���.</param>
        /// <returns>����script��ǩ���ַ�.</returns>
        public static string Back(int step)
        {
            string strJs = strJsHead + "history.back(" + step + ");" + strJsFoot;
            return strJs;
        }
        #endregion

        #region Go:�������ʷ��¼ǰ�������.
        /// <summary>
        /// �������ʷ��¼ǰ�������.
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public static string Go(int step)
        {
            string strJs = strJsHead + "history.go(" + step + ")" + strJsFoot;
            return strJs;
        }
        #endregion

        #region Redirect:��ת��ָ����URL.
        /// <summary>
        /// ��ת��ָ����URL.
        /// </summary>
        /// <param name="sUrl">Ҫ��ת����URL��ַ.</param>
        /// <returns>����script��ǩ���ַ�.</returns>
        public static string Redirect(string sUrl)
        {
            string strJs = "document.location=\"" + sUrl + "\";";
            strJs = strJsHead + strJs + strJsFoot;
            return strJs;
        }
        #endregion

        #region Replace:�ı䵱ǰҳ���URL.
        /// <summary>
        /// �ı䵱ǰҳ���URL.
        /// </summary>
        /// <param name="sUrl">�ı���URL��ַ.</param>
        /// <returns>����script��ǩ���ַ�.</returns>
        public static string Replace(string sUrl)
        {
            string strJs = "document.location.replace(\"" + sUrl + "\");";
            strJs = strJsHead + strJs + strJsFoot;
            return strJs;
        }
        #endregion

        #region CloseWindow:�رյ�ǰ���������.
        /// <summary>
        /// �رյ�ǰ���������.
        /// </summary>
        /// <returns>����script��ǩ���ַ�.</returns>
        public static string CloseWindow()
        {
            string strJs = strJsHead + "window.close();" + strJsFoot;
            return strJs;
        }
        #endregion

        #region RegJs:Ϊ�Զ����JS����script��ǩ.
        /// <summary>
        /// Ϊ�Զ����JS����script��ǩ.
        /// </summary>
        /// <param name="strJs">�Զ����JS.</param>
        /// <returns>����script��ǩ���ַ�.</returns>
        public static string RegJs(string strJs)
        {
            string qdkRe = strJsHead + strJs + strJsFoot;
            return qdkRe;
        }
        #endregion

        #region Reload:�������뵱ǰҳ��.
        /// <summary>
        /// �������뵱ǰҳ��.
        /// </summary>
        /// <returns>����script��ǩ���ַ�.</returns>
        public static string Reload()
        {
            string strJs = "document.location=self.location;";
            strJs = strJsHead + strJs + strJsFoot;
            return strJs;
        }
        #endregion

    }
}
