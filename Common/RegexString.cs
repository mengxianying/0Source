using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Pbzx.Common
{
    /// <summary>
    /// ��֤�ַ���
    /// </summary>
    public class RegexString
    {
        /// <summary>
        /// ��֤�ַ����Ƿ���ȷ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ValidateString(string input, string Regexs)
        {
            return Regex.IsMatch(input, Regexs);
        }
        /// <summary>
        /// ��֤Email��ַ
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        /// <summary>
        /// dd-mm-yy ��������ʽ���� mm/dd/yy ��������ʽ��
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string MDYToDMY(String input)
        {
            return Regex.Replace(input, "\\b(?\\d{1,2})/(?\\d{1,2})/(?\\d{2,4})\\b", "${day}-${month}-${year}");
        }
        /// <summary>
        /// ��֤�Ƿ�ΪС��
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidDecimal(string strIn)
        {
            return Regex.IsMatch(strIn, @"[0].\d{1,2}|[1]");
        }

        /// <summary>
        /// ��֤�Ƿ�Ϊ����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNum(String str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsNumber(str, i))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// ��֤�Ƿ�Ϊ�绰����
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidTel(string strIn)
        {
            return Regex.IsMatch(strIn, @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?");
        }
        /// <summary>
        /// ��֤������
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidDate(string strIn)
        {
            return Regex.IsMatch(strIn, @"^2\d{3}-(?:0?[1-9]|1[0-2])-(?:0?[1-9]|[1-2]\d|3[0-1])(?:0?[1-9]|1\d|2[0-3]):(?:0?[1-9]|[1-5]\d):(?:0?[1-9]|[1-5]\d)$");
        }
        /// <summary>
        /// ��֤��׺��
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidPostfix(string strIn)
        {
            return Regex.IsMatch(strIn, @"\.(?i:gif|jpg)$");
        }
        /// <summary>
        /// ��֤�ַ��Ƿ���4��12֮��
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidByte(string strIn)
        {
            return Regex.IsMatch(strIn, @"^[a-z]{4,12}$");
        }
        /// <summary>
        /// ��֤IP
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidIp(string strIn)
        {
            return Regex.IsMatch(strIn, @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
        }
    }
}
