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
                if (result == "家庭招聘")
                {
                    temp = "Family recruitment";
                }
                else if (result == "中介招聘")
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
        #region 获取枚举值的详细文本
        /// <summary>
        /// 获取枚举值的详细文本
        /// </summary>
        /// <param name="e">枚举信息</param>
        /// <returns>枚举属性值</returns>
        public static string GetEnumDescription(object e)
        {
            //获取字段信息
            System.Reflection.FieldInfo[] ms = e.GetType().GetFields();

            Type t = e.GetType();
            foreach (System.Reflection.FieldInfo f in ms)
            {

                //判断名称是否相等
                if (f.Name != e.ToString()) continue;

                //反射出自定义属性
                foreach (Attribute attr in f.GetCustomAttributes(true))
                {
                    //类型转换找到一个Description，用Description作为成员名称
                    System.ComponentModel.DescriptionAttribute dscript = attr as System.ComponentModel.DescriptionAttribute;
                    if (dscript != null)
                        return dscript.Description;
                }

            }

            //如果没有检测到合适的注释，则用默认名称
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
