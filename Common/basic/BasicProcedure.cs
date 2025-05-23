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
    /// ������
    /// </summary>
    public class BasicProcedure
    {
        #region ��ȡ��ַ
        /// <summary>
        /// ��ȡ��ַ
        /// </summary>
        public static string WebPath
        {
            get
            {
                return "http://" + HttpContext.Current.Request.Url.Authority;
            }
        }
        #endregion

        #region ��ȡӦ�ó��������·��

        /// <summary>
        /// ��ȡӦ�ó��������·��
        /// </summary>
        public static string PhysicalApplicationPath
        {
            get
            {
              return  HttpContext.Current.Request.PhysicalApplicationPath;
            }
        }
        #endregion

        #region ��ȡӦ�ó��������·��
        /// <summary>
        /// ��ȡӦ�ó��������·��
        /// </summary>
        public static string AppPath;
        /// <summary>
        /// ��ȡӦ�ó��������·��
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

        #region �������������Ŀ��
        /// <summary>
        /// �������������Ŀ��
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="deep">��������</param>
        /// <returns>����Ч��</returns>
        public static string getColumnListName(string name, int deep)
        {
            if (deep == 1)
                return name;
            else
            {
                string alt = "��";
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

        #region ��boolת�����ǻ��
        /// <summary>
        /// ��boolת�����ǻ��
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetShow(bool str)
        {
            if (str)
                return "<b>��</b>";
            else
                return "��";
        }
        #endregion


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

        #region ����ö��ֵ��ȡ��ϸ�ı�,��"|"����
        /// <summary>
        /// ����ö��ֵ��ȡ��ϸ�ı�,��"|"����
        /// </summary>
        /// <param name="e">ö����
        /// ��:Enum.GetValues(typeof(rzrs.DBEnum.EArticleAttribute))
        /// </param>
        /// <param name="EnumString">ö��ֵ</param>
        /// <returns>ö���ı�</returns>
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

        #region ����ö��ֵ��ȡ��ϸ�ı�
        /// <summary>
        /// ����ö��ֵ��ȡ��ϸ�ı�
        /// </summary>
        /// <param name="e">ö����
        /// ��:Enum.GetValues(typeof(rzrs.DBEnum.EArticleAttribute))
        /// </param>
        /// <param name="EnumString">ö��ֵ</param>
        /// <returns>ö���ı�</returns>
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

        #region ����ö�ٰ󶨵�ѡ��
        /// <summary>
        /// ����ö�ٰ󶨵�ѡ��
        /// </summary>
        /// <param name="e">ö����
        /// ��:Enum.GetValues(typeof(rzrs.DBEnum.EArticleAttribute))
        /// </param>
        ///<param name="arra">ö��</param>
        ///<param name="rbl">��ѡ��</param>
        ///<param name="defaultvalue">��ʼֵ</param>
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


        #region ��������ļ�����
        /// <summary>
        /// ��������ļ�����
        /// </summary>
        /// <param name="FileType">�ļ�����(��:2008032300000011)</param>
        /// <returns>�ļ�����</returns>
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
            //��������ļ���
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

        #region �����Ƿ񷴻�����

        /// <summary>
        /// �����Ƿ��־��������
        /// </summary>
        /// <param name="flag">�Ƿ��־</param>
        /// <param name="TrueName">Ϊ��ʱ������</param>
        /// <param name="FalseName">Ϊ��ʱ������</param>
        /// <returns>���ص�����</returns>
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

        #region ��ʼ����ѡ���б�����
        /// <summary>
        /// ��ʼ����ѡ���б�����
        /// </summary>
        /// <param name="cbl">��ѡ���б����</param>
        /// <param name="cblstr">��ʼֵ����"��"����</param>
        /// <returns>��ѡ���б����</returns>
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

        #region ��ȡ��ѡ���б�ֵ
        /// <summary>
        /// ��ȡ��ѡ���б�ֵ
        /// </summary>
        /// <param name="cbl">��ѡ�����</param>
        /// <returns>����ѡ�����ݣ���"|"Ϊ�ָ���</returns>
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

        #region ��ʽ������
        /// <summary>
        /// ��ʽ������
        /// 1,2005-11-5
        /// 2,2005��11��5��
        /// 3,2005��11��5�� 14:23
        /// 4,2005��11��5�� 14:23:23
        /// 5,2005-11-5 14:23
        /// 6,2005-11-5 14:23:23
        /// 7,11��5��
        /// 8,Sat, 05 Nov 2005 14:23:23 GMT
        /// 9,2005-11-05T14:23:23
        /// 10,14:23
        /// 11,14:23:23
        /// 12,2005-11-05 14:23:23
        /// 13,2005��11��5�� 6:23:23
        /// 14,2005��11��
        /// 15,2005-11-5 14:23:23 
        /// 16,11-5
        /// 17,200511051423230000
        /// </summary>
        /// <param name="date">���ڶ���</param>
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
                    dtstr = string.Format("{0:D}", dt);//2005��11��5��
                    break;
                case 3:
                    dtstr = string.Format("{0:f}", dt);//2005��11��5�� 14:23
                    break;
                case 4:
                    dtstr = string.Format("{0:F}", dt);//2005��11��5�� 14:23:23
                    break;
                case 5:
                    dtstr = string.Format("{0:g}", dt);//2005-11-5 14:23
                    break;
                case 6:
                    dtstr = string.Format("{0:G}", dt);//2005-11-5 14:23:23
                    break;
                case 7:
                    dtstr = string.Format("{0:M}", dt);//11��5��
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
                    dtstr = string.Format("{0:U}", dt);//2005��11��5�� 6:23:23
                    break;
                case 14:
                    dtstr = string.Format("{0:Y}", dt);//2005��11��
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


        #region ���ݷָ����������
        /// <summary>
        /// ���ݷָ����������
        /// </summary>
        /// <param name="source">Ҫ�ָ����ַ�</param>
        /// <returns>string[]</returns>
        public static string[] GetStringsByFlag(string source,string flag)
        {
            if (source.IndexOf(WebInit.webBaseConfig.PaginAtion) > -1)
            {
                string split = flag;
                int len = split.Length;
                ArrayList al = new ArrayList();
                int start = 0; //��ʼλ��
                int j = -1; //ƥ������λ��
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


        #region ȥ���ַ������һ��','��

        /// <summary>
        /// ȥ���ַ������һ��','��
        /// </summary>
        /// <param name="chr">:Ҫ��������ַ���</param>
        /// <returns>�����Ѵ�����ַ���</returns>
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

        #region ���䷽��
        /// <summary>
        /// ���䷽��
        /// </summary>
        /// <param name="path">���ݼ���ַ</param>
        /// <param name="className">����</param>
        /// <param name="labelMethod">������</param>
        /// <param name="labelParms">������str[]</param>
        /// <param name="IsState">�Ƿ�̬����</param>
        /// <returns>����</returns>
        public static string GetMethod(string path, string className, string labelMethod, string[] labelParms, bool IsState)
        {
            if (!string.IsNullOrEmpty(labelMethod) && labelParms.Length > 0)
            {
                Type type;
                object obj;
                Assembly assembly = Assembly.Load(path);
                obj = assembly.CreateInstance(path + "." + className);
                type = assembly.GetType(path + "." + className);
                System.Reflection.MethodInfo method = type.GetMethod(labelMethod.Trim().ToString());//����������
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

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="path">���ݼ���ַ</param>
        /// <param name="className">����</param>
        /// <param name="labelAttribute">������</param>
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


        #region ��������ַ���

        /// <summary>
        /// ��ȡ����ַ���
        /// </summary>
        /// <param name="strLength">�ַ�������</param>
        /// <param name="Seed">�����������ֵ</param>
        /// <returns>ָ�����ȵ�����ַ���</returns>
        public static string GetRandomString(int strLength, params int[] Seed)
        {
            string strSep = ",";
            char[] chrSep = strSep.ToCharArray();

            //��1��l�����׷����������ȥ��
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

            //��������ַ���
            for (int i = 0; i < strLength; i++)
            {
                strRandom += aryChar[Rnd.Next(aryChar.Length)];
            }

            return strRandom;
        }


        #endregion

    }
}
