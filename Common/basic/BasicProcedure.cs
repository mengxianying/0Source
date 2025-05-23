using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text.RegularExpressions;

using System.Reflection;

namespace Pbzx.Common
{
    /// <summary>
    /// 基本类
    /// </summary>
    public class BasicProcedure
    {
        #region 获取网址
        /// <summary>
        /// 获取网址
        /// </summary>
        public static string WebPath
        {
            get
            {
                return "http://" + HttpContext.Current.Request.Url.Authority;
            }
        }
        #endregion

        #region 获取应用程序物理根路径

        /// <summary>
        /// 获取应用程序物理根路径
        /// </summary>
        public static string PhysicalApplicationPath
        {
            get
            {
              return  HttpContext.Current.Request.PhysicalApplicationPath;
            }
        }
        #endregion

        #region 获取应用程序虚拟根路径
        /// <summary>
        /// 获取应用程序虚拟根路径
        /// </summary>
        public static string AppPath;
        /// <summary>
        /// 获取应用程序虚拟根路径
        /// </summary>
        public static string ApplicationPath
        {
            get
            {
                GetApplicationPath();
                return AppPath;
            }
        }
        private static void GetApplicationPath()
        {
            if (AppPath == null)
            {
                AppPath = HttpContext.Current.Request.ApplicationPath == "/" ? null : HttpContext.Current.Request.ApplicationPath;
            }
        }
        #endregion

        #region 获得逐级缩进的栏目名
        /// <summary>
        /// 获得逐级缩进的栏目名
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="deep">分类的深度</param>
        /// <returns>返回效果</returns>
        public static string getColumnListName(string name, int deep)
        {
            if (deep == 1)
                return name;
            else
            {
                string alt = "├";
                string sStr = "";
                if (deep > 2)
                {
                    for (int i = 2; i < deep; i++)
                        sStr += "___";
                }
                return sStr + alt + name;
            }
        }
        #endregion

        #region 将bool转换成是或否
        /// <summary>
        /// 将bool转换成是或否
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetShow(bool str)
        {
            if (str)
                return "<b>是</b>";
            else
                return "否";
        }
        #endregion


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

        #region 根据枚举值获取详细文本,用"|"隔开
        /// <summary>
        /// 根据枚举值获取详细文本,用"|"隔开
        /// </summary>
        /// <param name="e">枚举类
        /// 例:Enum.GetValues(typeof(rzrs.DBEnum.EArticleAttribute))
        /// </param>
        /// <param name="EnumString">枚举值</param>
        /// <returns>枚举文本</returns>
        public static string GetEnumText(Array arra,string EnumString)
        {
            string es = "";
            if (!string.IsNullOrEmpty(EnumString))
            {
                string[] EnumStrings = EnumString.Split(new char[] { '|' });
                if (EnumStrings.Length > 0)
                {
                    for (int i = 0; i < EnumStrings.Length; i++)
                    {
                        foreach (object e in arra)
                        {
                            
                            int aa = (int)e;
                            int bb = int.Parse(EnumStrings[i].ToString());
                            if (aa == bb)
                            {
                                es += " " + GetEnumDescription(GetEnumDescription(e));
                            }
                        }
                    }
                }
            }
            return es;
        }

        #endregion

        #region 根据枚举值获取详细文本
        /// <summary>
        /// 根据枚举值获取详细文本
        /// </summary>
        /// <param name="e">枚举类
        /// 例:Enum.GetValues(typeof(rzrs.DBEnum.EArticleAttribute))
        /// </param>
        /// <param name="EnumString">枚举值</param>
        /// <returns>枚举文本</returns>
        public static string GetEnumTextString(Array arra, string EnumString)
        {
            string es = "";
            if (!string.IsNullOrEmpty(EnumString))
            {
                foreach (object e in arra)
                {
                    int aa = (int)e;
                    int bb = int.Parse(EnumString);
                    
                    if (aa == bb)
                    {
                        es = GetEnumDescription(GetEnumDescription(e));
                    }
                }

            }
            return es;
        }

        #endregion

        #region 根据枚举绑定单选组
        /// <summary>
        /// 根据枚举绑定单选组
        /// </summary>
        /// <param name="e">枚举类
        /// 例:Enum.GetValues(typeof(rzrs.DBEnum.EArticleAttribute))
        /// </param>
        ///<param name="arra">枚举</param>
        ///<param name="rbl">单选组</param>
        ///<param name="defaultvalue">初始值</param>
        public static void GetRadioListByEnum(Array arra, RadioButtonList rbl, string defaultvalue)
        {
            foreach (object e in arra)
            {
                int aa = (int)e;
                ListItem li = new ListItem(GetEnumDescription(e), aa.ToString());
                if (!string.IsNullOrEmpty(defaultvalue) && GetEnumDescription(e).Equals(defaultvalue))
                {
                    li.Selected = true;
                }
                rbl.Items.Add(li);
            }
        }

        #endregion


        #region 随机生成文件名称
        /// <summary>
        /// 随机生成文件名称
        /// </summary>
        /// <param name="FileType">文件类型(如:2008032300000011)</param>
        /// <returns>文件名称</returns>
        public static string RandomCreateFileName(int FileType)
        {
            string tab = "";
            switch (FileType)
            {
                case 1:
                    tab = "-";
                    break;
                case 2:
                    tab = "/";
                    break;
                case 3:
                    tab = "_";
                    break;
                default:
                    tab = "";
                    break;
            }
            Random objRand = new Random();
            System.DateTime date = DateTime.Now;
            //生成随机文件名
            string Year = date.Year.ToString();
            string Month = date.Month.ToString();
            string Day = date.Day.ToString();
            string Hour = date.Hour.ToString();
            string Minute = date.Minute.ToString();
            string Second = date.Second.ToString();
            string Rand = Convert.ToString(objRand.Next(99) * 97 + 100);
            string saveName = Year + tab + Month + tab + Day + tab + Hour + tab + Minute + tab + Second + tab + Rand;
            return saveName;
        }

        #endregion

        #region 根据是否反回名称

        /// <summary>
        /// 根据是否标志反回名称
        /// </summary>
        /// <param name="flag">是否标志</param>
        /// <param name="TrueName">为真时的名称</param>
        /// <param name="FalseName">为假时的名称</param>
        /// <returns>返回的名称</returns>
        public static string GetNameByFlag(bool flag,string TrueName,string FalseName)
        {
            try
            {

                if (flag)
                {
                    return TrueName;
                }
                else
                {
                    return FalseName;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region 初始化复选框列表数据
        /// <summary>
        /// 初始化复选框列表数据
        /// </summary>
        /// <param name="cbl">复选框列表对象</param>
        /// <param name="cblstr">初始值，用"，"隔开</param>
        /// <returns>复选框列表对象</returns>
        public static CheckBoxList InitCheckBoxList(CheckBoxList cbl, string cblstr)
        {
            if (!String.IsNullOrEmpty(cblstr))
            {
                string[] cblstrs = cblstr.Split(new char[] { '|' });
                for (int i = 0; i < cbl.Items.Count; i++)
                {
                    for (int j = 0; j < cblstrs.Length; j++)
                    {
                        if (cbl.Items[i].Value == cblstrs[j].ToString())
                            cbl.Items[i].Selected = true;
                    }
                }
            }
            return cbl;
        }
        #endregion

        #region 获取复选框列表值
        /// <summary>
        /// 获取复选框列表值
        /// </summary>
        /// <param name="cbl">复选框对象</param>
        /// <returns>返回选定数据，以"|"为分隔符</returns>
        public static string GetCheckBoxListValue(CheckBoxList cbl)
        {
            string aa="";
            if (cbl.Items.Count > 0)
            {
                string flag = "|";
                for (int i = 0; i < cbl.Items.Count; i++)
                {
                    if (cbl.Items[i].Selected)
                    {
                        if (!string.IsNullOrEmpty(aa))
                            flag = "|";
                        else
                            flag = "";
                        aa = aa + flag + cbl.Items[i].Value;
                    }
                }
            }
            return aa;
        }
        #endregion

        #region 格式化日期
        /// <summary>
        /// 格式化日期
        /// 1,2005-11-5
        /// 2,2005年11月5日
        /// 3,2005年11月5日 14:23
        /// 4,2005年11月5日 14:23:23
        /// 5,2005-11-5 14:23
        /// 6,2005-11-5 14:23:23
        /// 7,11月5日
        /// 8,Sat, 05 Nov 2005 14:23:23 GMT
        /// 9,2005-11-05T14:23:23
        /// 10,14:23
        /// 11,14:23:23
        /// 12,2005-11-05 14:23:23
        /// 13,2005年11月5日 6:23:23
        /// 14,2005年11月
        /// 15,2005-11-5 14:23:23 
        /// 16,11-5
        /// 17,200511051423230000
        /// </summary>
        /// <param name="date">日期对象</param>
        /// <returns></returns>
        public static string GetFormateDate(DateTime dt,int type)
        {
            string dtstr="";
            switch (type)
            {
                case 1:
                    dtstr = string.Format("{0:d}", dt);//2005-11-5
                    break;
                case 2:
                    dtstr = string.Format("{0:D}", dt);//2005年11月5日
                    break;
                case 3:
                    dtstr = string.Format("{0:f}", dt);//2005年11月5日 14:23
                    break;
                case 4:
                    dtstr = string.Format("{0:F}", dt);//2005年11月5日 14:23:23
                    break;
                case 5:
                    dtstr = string.Format("{0:g}", dt);//2005-11-5 14:23
                    break;
                case 6:
                    dtstr = string.Format("{0:G}", dt);//2005-11-5 14:23:23
                    break;
                case 7:
                    dtstr = string.Format("{0:M}", dt);//11月5日
                    break;
                case 8:
                    dtstr = string.Format("{0:R}", dt);//Sat, 05 Nov 2005 14:23:23 GMT
                    break;
                case 9:
                    dtstr = string.Format("{0:s}", dt);//2005-11-05T14:23:23
                    break;
                case 10:
                    dtstr = string.Format("{0:t}", dt);//14:23
                    break;
                case 11:
                    dtstr = string.Format("{0:T}", dt);//14:23:23
                    break;
                case 12:
                    dtstr = string.Format("{0:u}", dt);//2005-11-05 14:23:23
                    break;
                case 13:
                    dtstr = string.Format("{0:U}", dt);//2005年11月5日 6:23:23
                    break;
                case 14:
                    dtstr = string.Format("{0:Y}", dt);//2005年11月
                    break;
                case 15:
                    dtstr = string.Format("{0}", dt);//2005-11-5 14:23:23
                    break;
                case 16:
                    dtstr = string.Format("{0:M-d}", dt);
                    break;
                case 17:
                    dtstr = string.Format("{0:yyyyMMddHHmmssffff}", dt);
                    break;
                
            }
            return dtstr;
        }

        #endregion


        #region 根据分隔符拆分数据
        /// <summary>
        /// 根据分隔符拆分数据
        /// </summary>
        /// <param name="source">要分隔的字符</param>
        /// <returns>string[]</returns>
        public static string[] GetStringsByFlag(string source,string flag)
        {
            if (source.IndexOf(WebInit.webBaseConfig.PaginAtion) > -1)
            {
                string split = flag;
                int len = split.Length;
                ArrayList al = new ArrayList();
                int start = 0; //开始位置
                int j = -1; //匹配索引位置
                while (true)
                {
                    j = source.IndexOf(split, start);
                    if (j > -1)
                    {
                        al.Add(source.Substring(start, j - start));
                        int s = j - start;
                        start = j + len;
                    }
                    else
                    {
                        al.Add(source.Substring(start));
                        break;
                    }
                }
                string[] result;
                if (al.Count == 0)
                {
                    string[] r = new string[1];
                    r[0] = source;
                    result = r;
                }
                else
                {
                    string[] r = new string[al.Count];
                    for (int i = 0; i < al.Count; i++)
                    {
                        r[i] = al[i].ToString();
                    }
                    result = r;
                }
                return result;
            }
            else
                return null;
        }
        #endregion


        #region 去除字符串最后一个','号

        /// <summary>
        /// 去除字符串最后一个','号
        /// </summary>
        /// <param name="chr">:要做处理的字符串</param>
        /// <returns>返回已处理的字符串</returns>
        /// /// CreateTime:2007-03-26 Code By DengXi
        public static string CutComma(string Input)
        {
            return CutComma(Input, ",");
        }

        public static string CutComma(string Input, string indexStr)
        {
            if (Input.IndexOf(indexStr) >= 0)
                return Input.Remove(Input.LastIndexOf(indexStr));
            else
                return Input;
        }

        #endregion

        #region 反射方法
        /// <summary>
        /// 反射方法
        /// </summary>
        /// <param name="path">数据集地址</param>
        /// <param name="className">类名</param>
        /// <param name="labelMethod">方法名</param>
        /// <param name="labelParms">参数集str[]</param>
        /// <param name="IsState">是否静态方法</param>
        /// <returns>数据</returns>
        public static string GetMethod(string path, string className, string labelMethod, string[] labelParms, bool IsState)
        {
            if (!string.IsNullOrEmpty(labelMethod) && labelParms.Length > 0)
            {
                Type type;
                object obj;
                Assembly assembly = Assembly.Load(path);
                obj = assembly.CreateInstance(path + "." + className);
                type = assembly.GetType(path + "." + className);
                System.Reflection.MethodInfo method = type.GetMethod(labelMethod.Trim().ToString());//方法的名称
                if (IsState)
                {
                    return (string)method.Invoke(null, labelParms);
                }
                else
                {
                    return (string)method.Invoke(obj, labelParms);
                }
            }
            else
                return null;
        }
        #endregion

        #region 反射属性
        /// <summary>
        /// 反射属性
        /// </summary>
        /// <param name="path">数据集地址</param>
        /// <param name="className">类名</param>
        /// <param name="labelAttribute">属性名</param>
        /// <returns></returns>
        public static string GetAttribute(string path,string className, string labelAttribute)
        {
            Type type;
            object obj;
            Assembly assembly = Assembly.Load(path);
            obj = assembly.CreateInstance(path + "." + className);
            type = assembly.GetType(path + "." + className);
            return (string)type.GetProperty(labelAttribute).GetValue(obj, null);
           
        }

        #endregion


        #region 随机生成字符串

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <param name="strLength">字符串长度</param>
        /// <param name="Seed">随机函数种子值</param>
        /// <returns>指定长度的随机字符串</returns>
        public static string GetRandomString(int strLength, params int[] Seed)
        {
            string strSep = ",";
            char[] chrSep = strSep.ToCharArray();

            //因1与l不容易分清楚，所以去除
            string strChar = "2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z"
             + ",A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,W,X,Y,Z";

            string[] aryChar = strChar.Split(chrSep, strChar.Length);

            string strRandom = string.Empty;
            Random Rnd;
            if (Seed != null && Seed.Length > 0)
            {
                Rnd = new Random(Seed[0]);
            }
            else
            {
                Rnd = new Random();
            }

            //生成随机字符串
            for (int i = 0; i < strLength; i++)
            {
                strRandom += aryChar[Rnd.Next(aryChar.Length)];
            }

            return strRandom;
        }


        #endregion

    }
}
