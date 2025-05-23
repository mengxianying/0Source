using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;

namespace Pbzx.Common
{
    public class OperateText
    {
        #region//MD5:字符串MD5加密.
        /// <summary>
        /// 字符串MD5加密.
        /// </summary>
        /// <param name="InputStr">要加密的字符串.</param>
        /// <returns></returns>
        public static string MD5(string InputStr)
        {
            string EncrStr = FormsAuthentication.HashPasswordForStoringInConfigFile(InputStr, "MD5");
            return EncrStr.ToLower();
        }

        public static string MD5(string InputStr, int len)
        {
            string result = MD5(InputStr);
            if (len == 16)
            {
                result = result.Substring(8, 16);
            }
            return result;
        }
        #endregion
        #region 
        /// <summary>
        /// 如果外部链接为空用内部链接
        /// </summary>
        /// <param name="obj1">外部链接</param>
        /// <param name="obj2">内部链接</param>
        /// <param name="LinkUrl">内部链接地址</param>
        /// <returns>链接地址</returns>
        public static string IsOut(object obj1, object obj2,string LinkUrl)
        {
            string str1 = obj1.ToString();
            string str2 = obj2.ToString();
            if (str1 != "")
            {
                return str1;
            }
            else
            {
                return LinkUrl + str2;
            }
        }
        #endregion
        /*public static string EncryptString(string str)
        {
            string result = string.Empty;
            string tmp = "";
            for (int II = 0; II < str.Length; II++)
            {
                tmp = Convert.ToInt32(Convert.ToChar(str.Substring(II, 1))).ToString("X");
                tmp = tmp.PadLeft(4, '0');
                result += tmp.ToUpper();
            }
            char[] arr = result.ToCharArray();三大
            Array.Reverse(arr);
            result = new string(arr);
            return result;
        }

        public static string DeEncryptString(string str)
        {
            string result = string.Empty;
            string tmp = "";
            for (int II = 0; II < str.Length; II++)
            {
                tmp = Convert.ToInt32(Convert.ToChar(str.Substring(II, 1))).ToString("X");
                tmp = tmp.PadLeft(2, '0');
                result += tmp.ToUpper();
            }
            char[] arr = result.ToCharArray();
            Array.Reverse(arr);
            result = new string(arr);
            return result;
        }*/

        #region//AddZero:在字符串前加0,是字符串达到指定的长度.
        /// <summary>
        /// 在字符串前加0,是字符串达到指定的长度.
        /// </summary>
        /// <param name="str">要修改的字符串.</param>
        /// <param name="len">指定的长度.</param>
        /// <returns></returns>
        public static string AddZero(string str, int len)
        {
            if (str.Length < len)
            {
                for (int ii = str.Length; ii < len; ii++)
                {
                    str = "0" + str;
                }
            }
            return str;
        }
        #endregion

        #region//Chr:将字符编码改成ASCII码
        /// <summary>
        ///将字符编码改成ASCII码
        /// </summary>
        /// <param name＝"CN">将要编码的字符串</param>
        /// <returns>返回ASCII码</returns>
        public static string Chr(int N)
        {
            return Convert.ToChar(N).ToString();
        }
        #endregion

        #region//Asc:将ASCII码改成字符编码
        /// <summary>
        ///将ASCII码改成字符编码
        /// </summary>
        /// <param name＝"S">将要编码的字符串</param>
        /// <returns>返回字符编码</returns>
        public static int Asc(string S)
        {
            return Convert.ToInt32(Convert.ToChar(S));
        }
        #endregion

        #region//breakString:获取指定长度的字符，一个中文算两个字符．
        /// <summary>
        /// 获取指定长度的字符，一个中文算两个字符．
        /// </summary>
        /// <param name="S">要获取字符的原始字符串．</param>
        /// <param name="strLen">指定的长度，中文*２．</param>
        /// <returns></returns>
        public static string breakString(string S, int strLen)
        {
            string qdkRe = "";
            if (S == null || S == "")
            {
                return qdkRe;
            }
            S = S.Replace("&nbsp;", " ").Replace("&quot;", Chr(34)).Replace("&gt;", ">").Replace("&lt;", "<");
            qdkRe = S;
            int sLen, tLen, cLen;
            sLen = S.Length;
            tLen = 0;
            for (int i = 0; i < sLen; i++)
            {
                cLen = Math.Abs(Asc(S.Substring(i, 1)));
                if (cLen > 255)
                {
                    tLen += 2;
                }
                else
                {
                    tLen += 1;
                }
                if (tLen >= strLen)
                {
                    qdkRe = S.Substring(0, i);
                    qdkRe += "...";
                    break;
                }
            }

            qdkRe = qdkRe.Replace(" ", "&nbsp;").Replace(Chr(34), "&quot;").Replace(">", "&gt;").Replace("<", "&lt;");
            return qdkRe;
        }
        public static string breakString(object obj, int strLen)
        {
            string str = breakString(obj.ToString(), strLen);
            return str;
        }
        #endregion

        #region//IsNumber:检查一个字符串是否全部是数字.
        /// <summary>
        /// 检查一个字符串是否全部是数字.
        /// </summary>
        /// <param name="str">要检查的字符串.</param>
        /// <returns>true/false</returns>
        public static bool IsNumber(string str)
        {
            bool qdkRe = true;
            if (str == null || str == "")
            {
                qdkRe = false;
                return qdkRe;
            }
            string strNum = "0123456789-.";
            int sLen;
            for (sLen = 0; sLen < str.Length; sLen++)
            {
                if (strNum.IndexOf(str.Substring(sLen, 1)) < 0)
                {
                    qdkRe = false;
                    break;
                }
            }
            return qdkRe;
        }
        #endregion

        public static bool IsDecimal(string str)
        {
            bool qdkRe = true;
            System.Text.RegularExpressions.Regex MyReg = new System.Text.RegularExpressions.Regex(@"^[\d]+[.]{0,1}[\d]*$");
            qdkRe = MyReg.IsMatch(str);
            return qdkRe;
        }

        #region//filterHTML:删除字符串中的HTML字符.
        /// <summary>
        /// 删除字符串中的HTML字符.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string filterHTML(string str)
        {
            System.Text.RegularExpressions.Regex MyReg = new System.Text.RegularExpressions.Regex(@"<\/*[^<>]*>");
            return MyReg.Replace(str, "");
        }
        #endregion

        /// <summary>
        /// 获取DateTime格式中的日期部分
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public string getdatepart(DateTime d)
        {
            return d.Date.ToString();
        }
    }
}
