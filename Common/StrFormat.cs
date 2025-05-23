using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
    public class StrFormat
    {
        StrFormat()
        { }

        public static string CutStringByNum(object obj, int length)
        {
            string source = obj.ToString();
            if (length <= 0)
            {
                return source;
            }
            else
            {
                int tempLength = Method.GetStrLen(source);
                int charLength = 0;
                int hzLength = 0;

                //string tempResult = "";
                if (tempLength > length)
                {
                    Char[] cc = source.ToCharArray();
                    //int intLen = 0;
                    for (int i = 0; i < cc.Length; i++)
                    {
                        if (Convert.ToInt32(cc[i]) > 255)
                        {
                            hzLength++;

                        }
                        else
                        {
                            charLength++;
                        }

                        if ((hzLength * 2 + charLength) % 2 == 0 && hzLength * 2 + charLength >= length || (hzLength * 2 + charLength) % 2 == 1 && hzLength * 2 + charLength >= length - 1)
                        {
                            break;
                        }
                    }
                    return source.Substring(0, hzLength + charLength);
                }
                else
                {
                    return source;
                }
            }
        }
        public static string CutStringByNum(object obj, int length, string strEnd)
        {
            string source = obj.ToString();
            if (length <= 0)
            {
                return source;
            }
            else
            {
                int endLength = strEnd.Length;
                int tempLength = Method.GetStrLen(source);
                int charLength = 0;
                int hzLength = 0;

                //string tempResult = "";
                if ( tempLength > length)
                {
                    Char[] cc = source.ToCharArray();
                    //int intLen = 0;                    
                    for (int  i = 0; i < cc.Length; i++)
                    {
                        if (Convert.ToInt32(cc[i]) > 255)
                        {
                            hzLength++;

                        }
                        else
                        {
                            charLength++;
                        }

                        if ((hzLength * 2 + charLength) % 2 == 0 && hzLength * 2 + charLength >= length || (hzLength * 2 + charLength) % 2 == 1 && hzLength * 2 + charLength >= length-1)
                        {
                            break;
                        }
                    }
                    return  source.Substring(0, hzLength+charLength) ;
                }
                else
                {
                    return source;
                }
            }
        }

        public static string ConvertZpType(string result, string lan)
        {
            string temp = "";
            if (lan == "cn")
            {
                temp = result;
            }
            else if (lan == "en")
            {
                if (result == "��ͥ��Ƹ")
                {
                    temp = "Family recruitment";
                }
                else if (result == "�н���Ƹ")
                {
                    temp = "Intermediary recruitment";
                }
                else
                {
                    temp = result;
                }
            }
            return temp;
        }
        #region ��ȡö��ֵ����ϸ�ı�
        /// <summary>
        /// ��ȡö��ֵ����ϸ�ı�
        /// </summary>
        /// <param name="e">ö����Ϣ</param>
        /// <returns>ö������ֵ</returns>
        public static string GetEnumDescription(object e)
        {
            //��ȡ�ֶ���Ϣ
            System.Reflection.FieldInfo[] ms = e.GetType().GetFields();

            Type t = e.GetType();
            foreach (System.Reflection.FieldInfo f in ms)
            {

                //�ж������Ƿ����
                if (f.Name != e.ToString()) continue;

                //������Զ�������
                foreach (Attribute attr in f.GetCustomAttributes(true))
                {
                    //����ת���ҵ�һ��Description����Description��Ϊ��Ա����
                    System.ComponentModel.DescriptionAttribute dscript = attr as System.ComponentModel.DescriptionAttribute;
                    if (dscript != null)
                        return dscript.Description;
                }

            }

            //���û�м�⵽���ʵ�ע�ͣ�����Ĭ������
            return e.ToString();
        }
        #endregion

        public static string FormartMoneyToString(object objMoney)
        {
            decimal deMoney = Convert.ToDecimal(objMoney);
            return deMoney.ToString("0.00");
        }
    }
}
