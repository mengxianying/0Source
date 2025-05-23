using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;

namespace Pbzx.Common
{
    public class OperateText
    {
        #region//MD5:�ַ���MD5����.
        /// <summary>
        /// �ַ���MD5����.
        /// </summary>
        /// <param name="InputStr">Ҫ���ܵ��ַ���.</param>
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
        /// ����ⲿ����Ϊ�����ڲ�����
        /// </summary>
        /// <param name="obj1">�ⲿ����</param>
        /// <param name="obj2">�ڲ�����</param>
        /// <param name="LinkUrl">�ڲ����ӵ�ַ</param>
        /// <returns>���ӵ�ַ</returns>
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
            char[] arr = result.ToCharArray();����
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

        #region//AddZero:���ַ���ǰ��0,���ַ����ﵽָ���ĳ���.
        /// <summary>
        /// ���ַ���ǰ��0,���ַ����ﵽָ���ĳ���.
        /// </summary>
        /// <param name="str">Ҫ�޸ĵ��ַ���.</param>
        /// <param name="len">ָ���ĳ���.</param>
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

        #region//Chr:���ַ�����ĳ�ASCII��
        /// <summary>
        ///���ַ�����ĳ�ASCII��
        /// </summary>
        /// <param name��"CN">��Ҫ������ַ���</param>
        /// <returns>����ASCII��</returns>
        public static string Chr(int N)
        {
            return Convert.ToChar(N).ToString();
        }
        #endregion

        #region//Asc:��ASCII��ĳ��ַ�����
        /// <summary>
        ///��ASCII��ĳ��ַ�����
        /// </summary>
        /// <param name��"S">��Ҫ������ַ���</param>
        /// <returns>�����ַ�����</returns>
        public static int Asc(string S)
        {
            return Convert.ToInt32(Convert.ToChar(S));
        }
        #endregion

        #region//breakString:��ȡָ�����ȵ��ַ���һ�������������ַ���
        /// <summary>
        /// ��ȡָ�����ȵ��ַ���һ�������������ַ���
        /// </summary>
        /// <param name="S">Ҫ��ȡ�ַ���ԭʼ�ַ�����</param>
        /// <param name="strLen">ָ���ĳ��ȣ�����*����</param>
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

        #region//IsNumber:���һ���ַ����Ƿ�ȫ��������.
        /// <summary>
        /// ���һ���ַ����Ƿ�ȫ��������.
        /// </summary>
        /// <param name="str">Ҫ�����ַ���.</param>
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

        #region//filterHTML:ɾ���ַ����е�HTML�ַ�.
        /// <summary>
        /// ɾ���ַ����е�HTML�ַ�.
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
        /// ��ȡDateTime��ʽ�е����ڲ���
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public string getdatepart(DateTime d)
        {
            return d.Date.ToString();
        }
    }
}
