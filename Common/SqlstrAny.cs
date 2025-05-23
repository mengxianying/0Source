using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Globalization;

namespace Pbzx.Common
{
    public class SqlstrAny : IHttpModule
    {

        public void Init(HttpApplication application)
        {

            application.BeginRequest += (new

            EventHandler(this.Application_BeginRequest));

        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {

            ProcessRequest pr = new ProcessRequest();

            pr.StartProcessRequest();

        }

        public void Dispose()
        {

        }

    }



    public class ProcessRequest
    {

        private static string SqlStr = System.Configuration.ConfigurationManager.AppSettings["SqlInject"].ToString();

        private static string sqlErrorPage = System.Configuration.ConfigurationSettings.AppSettings["SQLInjectErrPage"].ToString();

        /// 

        /// ����ʶ���Ƿ������ķ�ʽ����

        /// 

        bool IsUploadRequest(HttpRequest request)
        {

            return StringStartsWithAnotherIgnoreCase(request.ContentType, "multipart/form-data");

        }

        /// 

        /// �Ƚ���������

        /// 

        private static bool StringStartsWithAnotherIgnoreCase(string s1, string s2)
        {

            return (string.Compare(s1, 0, s2, 0, s2.Length, true, CultureInfo.InvariantCulture) == 0);

        }

        //SQLע��ʽ�����������

        #region SQLע��ʽ�����������

        /// 

        /// �����û��ύ������

        /// 

        public void StartProcessRequest()
        {

            HttpRequest Request = System.Web.HttpContext.Current.Request;

            HttpResponse Response = System.Web.HttpContext.Current.Response;

            try
            {

                string getkeys = "";

                if (IsUploadRequest(Request)) return;  //����������ݾ��˳�

                //�ַ�������

                if (Request.QueryString != null)
                {

                    for (int i = 0; i < Request.QueryString.Count; i++)
                    {

                        getkeys = Request.QueryString.Keys[i];

                        if (!ProcessSqlStr(Request.QueryString[getkeys]))
                        {

                            Response.Redirect(sqlErrorPage + "?errmsg=QueryString�к��зǷ��ַ���&sqlprocess=true");

                            Response.End();

                        }

                    }

                }

                //form����

                if (Request.Form != null)
                {

                    for (int i = 0; i < Request.Form.Count; i++)
                    {

                        getkeys = Request.Form.Keys[i];

                        if (!ProcessSqlStr(Request.Form[getkeys]))
                        {

                            Response.Redirect(sqlErrorPage + "?errmsg=Form�к��зǷ��ַ���&sqlprocess=true");

                            Response.End();

                        }

                    }

                }

                //cookie����

                //if (Request.Cookies != null)
                //{

                //    for (int i = 0; i < Request.Cookies.Count; i++)
                //    {

                //        getkeys = Request.Cookies.Keys[i];

                //        if (!ProcessSqlStr(Request.Cookies[getkeys].Value))
                //        {

                //            Response.Redirect(sqlErrorPage + "?errmsg=Cookie�к��зǷ��ַ���&sqlprocess=true");

                //            Response.End();

                //        }

                //    }

                //}

            }

            catch
            {

                // ������: �����û��ύ��Ϣ!

                Response.Clear();

                Response.Write("CustomErrorPage���ô���");

                Response.End();

            }

        }



        /// �����û������Ƿ�����

        /// �����û��ύ����

        /// �����Ƿ���SQLע��ʽ��������

        private bool ProcessSqlStr(string Str)
        {

            bool ReturnValue = true;
            //try
            //{

            //    if (Str != "")
            //    {
            //        Str = Str.ToLower();
            //        string[] anySqlStr = SqlStr.Split('|');

            //        foreach (string ss in anySqlStr)
            //        {

            //            if (Str.IndexOf(ss) >= 0)
            //            {

            //                ReturnValue = false;

            //                break;

            //            }

            //        }

            //    }

            //}

            //catch
            //{

            //    ReturnValue = false;

            //}

            return ReturnValue;

        }

        #endregion

    }
}




