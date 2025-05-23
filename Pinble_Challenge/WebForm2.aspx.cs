using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace Pinble_Challenge
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_PRAGMA"] != null)
                {
                    Response.Write("ip地址：" + HttpContext.Current.Request.UserHostAddress);
                }
                else
                {
                    Response.Write("没有代理IP");
                }
                
                string dailiIP = "";    //获取代理IP
                string zhenshiIP = "";  //获取真实IP
                try
                {
                    if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)  //如果有代理IP
                    {
                        dailiIP = HttpContext.Current.Request.UserHostAddress;   //dailiIP直接取值
                        zhenshiIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();  //真实IP需要穿过代理取值
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "aa", "alert('你使用了代理IP上网')", true);
                    }
                    else  //如果没有代理IP
                    {
                        zhenshiIP = HttpContext.Current.Request.UserHostAddress;  //真实IP直接取值
                    }
                }
                catch //如果有异常，则不作任何处理
                {

                }

                if (dailiIP == "" && zhenshiIP == "")
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "aa", "alert('发生了异常，原因是服务器无法回路访问，这主要是您的浏览器设置出错造成。原因之一，你屏蔽了IP；原因之二，你设置了代理服务器。')", true);
                }

                lbl_daili.Text = dailiIP;
                lbl_zhenshi.Text = zhenshiIP;
                lbl_pcname.Text = System.Net.Dns.GetHostEntry(Request.ServerVariables["remote_addr"]).HostName.ToString();
            }
        }



        //真实IP
        public static string GetRealIP()
        {
            string ip;
            try
            {
                HttpRequest request = HttpContext.Current.Request;

                if (request.ServerVariables["HTTP_VIA"] != null)
                {
                    ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
                }
                else
                {
                    ip = request.UserHostAddress;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ip;
        }


        //获取代理IPview plaincopy to clipboardprint?
        public static string GetViaIP()
        {
            string viaIp = null;

            try
            {
                HttpRequest request = HttpContext.Current.Request;

                if (request.ServerVariables["HTTP_VIA"] != null)
                {
                    viaIp = request.UserHostAddress;
                }

            }
            catch (Exception e)
            {

                throw e;
            }

            return viaIp;
        }



        public static Int64 toDenaryIp(string ip)
        {
            Int64 _Int64 = 0;
            string _ip = ip;
            if (_ip.LastIndexOf(".") > -1)
            {
                string[] _iparray = _ip.Split('.');

                _Int64 = Int64.Parse(_iparray.GetValue(0).ToString()) * 256 * 256 * 256 + Int64.Parse(_iparray.GetValue(1).ToString()) * 256 * 256 + Int64.Parse(_iparray.GetValue(2).ToString()) * 256 + Int64.Parse(_iparray.GetValue(3).ToString()) - 1;
            }
            return _Int64;
        }

        /// <summary>
        /// /ip十进制
        /// </summary>
        public static Int64 DenaryIp
        {
            get
            {
                Int64 _Int64 = 0;

                string _ip = IP;
                if (_ip.LastIndexOf(".") > -1)
                {
                    string[] _iparray = _ip.Split('.');

                    _Int64 = Int64.Parse(_iparray.GetValue(0).ToString()) * 256 * 256 * 256 + Int64.Parse(_iparray.GetValue(1).ToString()) * 256 * 256 + Int64.Parse(_iparray.GetValue(2).ToString()) * 256 + Int64.Parse(_iparray.GetValue(3).ToString()) - 1;
                }
                return _Int64;
            }
        }

        public static string IP
        {
            get
            {
                string result = String.Empty;  //先定义为空
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (result != null && result != String.Empty)
                {
                    //可能有代理
                    if (result.IndexOf(".") == -1) //没有"."肯定是非IPv4格式
                    {
                        result = null;
                    }
                    else
                    {
                        if (result.IndexOf(",") != -1)
                        {
                            //有","，估计多个代理。取第一个不是内网的IP。
                            result = result.Replace(" ", "").Replace("", "");
                            string[] temparyip = result.Split(",;".ToCharArray());
                            for (int i = 0; i < temparyip.Length; i++)
                            {
                                if (IsIPAddress(temparyip[i]) && temparyip[i].Substring(0, 3) != "10." && temparyip[i].Substring(0, 7) != "192.168" && temparyip[i].Substring(0, 7) != "172.16.")
                                {
                                    return temparyip[i]; //找到不是内网的地址
                                }
                            }
                        }
                        else if (IsIPAddress(result)) //代理即是IP格式
                        {
                            return result;
                        }
                        else
                        {
                            result = null; //代理中的内容 非IP，取IP
                        }
                    }

                }
                string IpAddress = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null && HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != String.Empty) ? HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] : HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                if (null == result || result == String.Empty)
                {
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                if (result == null || result == String.Empty)
                {
                    result = HttpContext.Current.Request.UserHostAddress;
                }

                return result;
            }
        }

        //是否ip格式
        public static bool IsIPAddress(string str1)
        {
            if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15)
            {
                return false;
            }
            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }

        //点击“操作看看”时
        protected void btn_caozuo_Click(object sender, EventArgs e)
        {
            Response.Write(IP);
        }
    }
}