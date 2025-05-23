using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System;

/// <summary>
/// New Interface for AliPay
/// </summary>
namespace Gateway
{
    public class AliPay
    {
        /// <summary>
        /// ��ASP���ݵ�MD5�����㷨
        /// </summary>
        public static string GetMD5(string s, string _input_charset)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        /// ð������
        /// ������ĸ���д�a��z��˳������
        /// </summary>
        public static string[] BubbleSort(string[] r)
        {
            int i, j; //������־ 
            string temp;

            bool exchange;

            for (i = 0; i < r.Length; i++) //�����R.Length-1������ 
            {
                exchange = false; //��������ʼǰ��������־ӦΪ��

                for (j = r.Length - 2; j >= i; j--)
                {//��������
                    if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)
                    {
                        temp = r[j + 1];
                        r[j + 1] = r[j];
                        r[j] = temp;

                        exchange = true; //�����˽������ʽ�������־��Ϊ�� 
                    }
                }

                if (!exchange) //��������δ������������ǰ��ֹ�㷨 
                {
                    break;
                }
            }
            return r;
        }

        /// <summary>
        /// ����URL���ӻ���ܽ��
        /// </summary>
        /// <param name="para">������������</param>
        /// <param name="_input_charset">�����ʽ</param>
        /// <param name="sign_type">��������</param>
        /// <param name="key">��ȫУ����</param>
        /// <returns>�ַ���URL����ܽ��</returns>
        public static string CreatUrl(
            string gateway,//GET��ʽ���ݲ���ʱ��ȥ��ע��
            string[] para,
            string _input_charset,
            string sign_type,
            string key
            )
        {
            int i;
            
            //��������
            string[] Sortedstr = BubbleSort(para);


            //�����md5ժҪ�ַ��� ��

            StringBuilder prestr = new StringBuilder();

            for (i = 0; i < Sortedstr.Length; i++)
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr.Append(Sortedstr[i]);

                }
                else
                {
                    prestr.Append(Sortedstr[i] + "&");
                }

            }

            prestr.Append(key);

            //����Md5ժҪ��
			string sign = GetMD5(prestr.ToString(), _input_charset);

			//������POST��ʽ���ݲ���
			//return sign;

			//������GET��ʽ���ݲ���
            //����֧��Url��
            char[] delimiterChars = { '=' };
            StringBuilder parameter = new StringBuilder();
            parameter.Append(gateway);
            for (i = 0; i < Sortedstr.Length; i++)
            {//UTF-8��ʽ�ı���ת��
                parameter.Append(Sortedstr[i].Split(delimiterChars)[0] + "=" + HttpUtility.UrlEncode(Sortedstr[i].Split(delimiterChars)[1]) + "&");
            }

            parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

            //����֧��Url��
            return parameter.ToString();
        }

        //��ȡԶ�̷�����ATN�������֤�Ƿ���֧��������������������
        public static string Get_Http(string a_strUrl, int timeout)
        {
            string strResult;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(a_strUrl);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.Default);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }

                strResult = strBuilder.ToString();
            }
            catch (Exception exp)
            {

                strResult = "����" + exp.Message;
            }

            return strResult;
        }

    }
}