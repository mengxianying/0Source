using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections;

namespace Pbzx.Common
{
    public class Input
    {
        /// <summary>
        /// 检测是否整数型数据
        /// </summary>
        /// <param name="Num">待检查数据</param>
        /// <returns></returns>
        public static bool IsInteger(string Input)
        {
            if (Input == null)
            {
                return false;
            }
            else
            {
                return IsInteger(Input, true);
            }
        }
        /// <summary>
        /// 合并路径字符串
        /// </summary>
        /// <param name="paramesters"></param>
        /// <returns></returns>
        public static string Combine(params  string[] paramesters)
        {
            string result = string.Empty;
            if (paramesters.Length == 0)
                return string.Empty;
            result = paramesters[0];
            for (int i = 0; i < paramesters.Length - 1; i++)
            {
                string temp = paramesters[i + 1];
                if (!string.IsNullOrEmpty(temp) && (temp[0] == '/' || temp[0] == '\\'))
                    temp = temp.Substring(1, temp.Length - 1);
                result += System.IO.Path.Combine(result[i].ToString(), temp);
            }
            return result;
        }
        /// <summary>
        /// 是否全是正整数
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static bool IsInteger(string Input, bool Plus)
        {
            if (Input == null)
            {
                return false;
            }
            else
            {
                string pattern = "^-?[0-9]+$";
                if (Plus)
                    pattern = "^[0-9]+$";
                if (Regex.Match(Input, pattern, RegexOptions.Compiled).Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 是否全是字母
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static bool IsAllLetter(string Input)
        {
            if (Input == null)
            {
                return false;
            }
            else
            {
                string pattern = "^[a-zA-Z]+$";
                if (Regex.Match(Input, pattern, RegexOptions.Compiled).Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// 判断输入是否为日期类型
        /// </summary>
        /// <param name="s">待检查数据</param>
        /// <returns></returns>
        public static bool IsDate(string s)
        {
            try
            {
                DateTime d = DateTime.Parse(s);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 过滤字符串中的html代码
        /// </summary>
        /// <param name="Str"></param>
        /// <returns>返回过滤之后的字符串</returns>
        public static string LostHTML(string Str)
        {
            string Re_Str = "";
            if (Str != null)
            {
                if (Str != string.Empty)
                {
                    string Pattern = "<\\/*[^<>]*>";
                    Re_Str = Regex.Replace(Str, Pattern, "");
                }
            }
            return (Re_Str.Replace("\\r\\n", "")).Replace("\\r", "");
        }

        public static string LostPage(string Str)
        {
            string Re_Str = "";
            if (Str != null)
            {
                if (Str != string.Empty)
                {
                    string Pattern = "\\[FS:PAGE\\/*[^<>]*\\$\\]";
                    Re_Str = Regex.Replace(Str, Pattern, "");
                }
            }
            return Re_Str;
        }

        public static string LostVoteStr(string Str)
        {
            string Re_Str = "";
            if (Str != null)
            {
                if (Str != string.Empty)
                {
                    string Pattern = "\\[FS:unLoop\\/*[^<>]*\\[\\/FS:unLoop\\]";
                    Re_Str = Regex.Replace(Str, Pattern, "");
                }
            }
            return Re_Str;
        }

        /// <summary>
        /// 根据新闻标题的属性设置返回设置后的标题
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="TitleColor">标题颜色</param>
        /// <param name="IsB">是否粗体</param>
        /// <param name="IsI">是否斜体</param>
        /// <param name="TitleNum">返回标题字数</param>
        /// <returns>返回设置后的标题</returns>
        public static string GetColorTitleSubStr(string Title, string TitleColor, int IsB, int IsI, int TitleNum)
        {
            string Return_title = "";
            string FormatTitle = LostHTML(Title);
            if (FormatTitle != null && FormatTitle != string.Empty)
            {
                FormatTitle = GetSubString(FormatTitle, TitleNum);
                if (IsB == 1)
                {
                    FormatTitle = "<b>" + FormatTitle + "</b>";
                }
                if (IsI == 1)
                {
                    FormatTitle = "<i>" + FormatTitle + "</i>";
                }
                if (TitleColor != null && TitleColor != string.Empty)
                {
                    FormatTitle = "<font style=\"color:" + TitleColor + ";\">" + FormatTitle + "</font>";
                }
                Return_title = FormatTitle;
            }
            return Return_title;
        }


        /// <summary>
        /// 截取字符串函数
        /// </summary>
        /// <param name="Str">所要截取的字符串</param>
        /// <param name="Num">截取字符串的长度</param>
        /// <returns></returns>
        public static string GetSubString(string Str, int Num)
        {
            //string titlemore = Foosun.Config.UIConfig.titlemore;
            //string titlenew = Foosun.Config.UIConfig.titlenew;
            if (Str == null || Str == "")
            {
                return "";
            }
            //if (titlenew == "1")
            //{
            //    Num -= 4;
            //}
            string outstr = string.Empty;
            int n = 0;
            foreach (char ch in Str)
            {
                n += System.Text.Encoding.Default.GetByteCount(ch.ToString());

                ////修改bug,中文字符计为一个字符,by 周峻平 2008-5-28
                //if (ch >= 0x4e00 && ch <= 0x9fa5)
                //{
                //    n = n - 1;
                //}

                if (n > Num)
                {
                    break;
                }
                else
                {
                    outstr += ch;
                }
            }
            //if (titlenew == "1")
            //{
            //    outstr += "[New]";
            //}
            return outstr;
        }
        /// <summary>
        /// 截取字符串函数
        /// </summary>
        /// <param name="Str">所要截取的字符串</param>
        /// <param name="Num">截取字符串的长度</param>
        /// <param name="Num">截取字符串后省略部分的字符串</param>
        /// <returns></returns>
        public static string GetSubString(string Str, int Num, string LastStr)
        {
            return (Str.Length > Num) ? Str.Substring(0, Num) + LastStr : Str;
        }

        /// <summary>
        /// 验证字符串是否是图片路径
        /// </summary>
        /// <param name="Input">待检测的字符串</param>
        /// <returns>返回true 或 false</returns>
        public static bool IsImgString(string Input)
        {
            return IsImgString(Input, "/{@dirfile}/");
        }

        public static bool IsImgString(string Input, string checkStr)
        {
            bool re_Val = false;
            if (Input != string.Empty)
            {
                string s_input = Input.ToLower();
                if (s_input.IndexOf(checkStr.ToLower()) != -1 && s_input.IndexOf(".") != -1)
                {
                    string Ex_Name = s_input.Substring(s_input.LastIndexOf(".") + 1).ToString().ToLower();
                    if (Ex_Name == "jpg" || Ex_Name == "gif" || Ex_Name == "bmp" || Ex_Name == "png")
                    {
                        re_Val = true;
                    }
                }
            }
            return re_Val;
        }


        /// <summary>
        ///  将字符转化为HTML编码
        /// </summary>
        /// <param name="str">待处理的字符串</param>
        /// <returns></returns>
        public static string HtmlEncode(string Input)
        {
            return HttpContext.Current.Server.HtmlEncode(Input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string HtmlDecode(string Input)
        {
            return HttpContext.Current.Server.HtmlDecode(Input);
        }

        /// <summary>
        /// URL地址编码
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string URLEncode(string Input)
        {
            return HttpContext.Current.Server.UrlEncode(Input);
        }

        /// <summary>
        /// URL地址解码
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string URLDecode(string Input)
        {
            return HttpContext.Current.Server.UrlDecode(Input);
        }
        /// <summary>
        /// 过滤字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Filter(string sInput)
        {
            if (sInput == null || sInput == "")
                return null;
            string tempInput = sInput.ToLower();
            //sInput = System.Web.HttpContext.Current.Server.UrlDecode(tempInput);
            string pattern = System.Configuration.ConfigurationManager.AppSettings["SQLInject"]; //"*|exec|insert|select|delete|update|count|truncate|declare|char(|mid(|chr(|'|char(|union";            
            if (pattern != null)
            {
                string[] patternSZ = pattern.Split(new char[] { '|' });
                foreach (string ss in patternSZ)
                {
                    if (ss != "" && tempInput.IndexOf(ss) >= 0)
                    {
                        Method.record_user_log("黑客", sInput, "SQL注入", "恶意攻击");
                        throw new Exception("字符串中含有非法字符!");
                    }
                }
            }

            sInput = sInput.Replace("'", "''");
            return sInput;
        }

        /// <summary>
        /// 过滤特殊字符/前台会员
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Htmls(string Input)
        {
            if (Input != string.Empty && Input != null)
            {
                string ihtml = Input.ToLower();
                string pattern = "<img|<|>|iframe|frameset|href|javascript|script";
                string[] patternSZ = pattern.Split(new char[] { '|' });
                foreach (string ss in patternSZ)
                {
                    if (ihtml.IndexOf(ss) >= 0)
                    {
                        Method.record_user_log("黑客", Input, "js脚本注入", "恶意攻击");
                        throw new Exception("字符串中含有非法字符!");
                    }
                }
                return Input;
            }
            else
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// 字符串字符处理
        /// </summary>
        /// <param name="chr">等待处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        /// //把HTML代码转换成TXT格式
        public static String ToTxt(String Input)
        {
            StringBuilder sb = new StringBuilder(Input);
            sb.Replace("&nbsp;", " ");
            sb.Replace("<br>", "\r\n");
            sb.Replace("<br>", "\n");
            sb.Replace("<br/>", "\n");
            sb.Replace("<br/>", "\r\n");
            sb.Replace("<p>", "\r\n");
            sb.Replace("</p>", "");
            sb.Replace("&lt;", "<");
            sb.Replace("&gt;", ">");
            sb.Replace("&amp;", "&");
            return sb.ToString();
        }

        /// <summary>
        /// 字符串字符处理
        /// </summary>
        /// <param name="chr">等待处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        /// //把HTML代码转换成TXT格式
        public static String ToshowTxt(String Input)
        {
            StringBuilder sb = new StringBuilder(Input);
            sb.Replace("&lt;", "<");
            sb.Replace("&gt;", ">");
            return sb.ToString();
        }

        /// <summary>
        /// 把字符转化为文本格式
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string ForTXT(string Input)
        {
            StringBuilder sb = new StringBuilder(Input);
            sb.Replace("<font", " ");
            sb.Replace("<span", " ");
            sb.Replace("<style", " ");
            sb.Replace("<div", " ");
            sb.Replace("<p", "");
            sb.Replace("</p>", "");
            sb.Replace("<label", " ");
            sb.Replace("&nbsp;", " ");
            sb.Replace("<br>", "");
            sb.Replace("<br />", "");
            sb.Replace("<br />", "");
            sb.Replace("&lt;", "");
            sb.Replace("&gt;", "");
            sb.Replace("&amp;", "");
            sb.Replace("<", "");
            sb.Replace(">", "");
            return sb.ToString();
        }
        /// <summary>
        /// 字符串字符处理
        /// </summary>
        /// <param name="chr">等待处理的字符串</param>
        /// <returns>处理后的字符串</returns>
        /// //把TXT代码转换成HTML格式

        public static String ToHtml(string Input)
        {
            StringBuilder sb = new StringBuilder(Input);
            sb.Replace("&", "&amp;");
            sb.Replace("<", "&lt;");
            sb.Replace(">", "&gt;");
            sb.Replace("\r\n", "<br/>");
            sb.Replace("\n", "<br/>");
            //sb.Replace("\t", " ");
            sb.Replace(" ", "&nbsp;");
            //sb.Replace(" ", "&nbsp;");
            return sb.ToString();
        }

        /// <summary>
        /// MD5加密字符串处理
        /// </summary>
        /// <param name="Half">加密是16位还是32位；如果为true为16位</param>
        /// <param name="Input">待加密码字符串</param>
        /// <returns></returns>
        public static string MD5(string Input, bool Half)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(Input);
            byte[] result = md5.ComputeHash(data);
            String strReturn = String.Empty;
            for (int i = 0; i < result.Length; i++)
            {
                strReturn += result[i].ToString("x").PadLeft(2, '0');
            }
            if (Half)
            {
                return strReturn.Substring(8, 16);
            }
            return strReturn;

        }

        public static string MD5(string Input)
        {
            return MD5(Input, true);
        }


        /// <summary>
        /// MD5加密字符串处理
        /// </summary>
        ///  /// <param name="Half">加密是16位还是32位；如果为true为16位(本系统始终采用16位)</param>
        /// <param name="Input">为了保证网站后台安全，管理员MD5采用特殊处理</param>
        /// <param name="Input">待加密码字符串</param>
        /// <returns></returns>
        //public static string MD5(string Input, bool Half,bool IsAdmin)
        //{
        //    string output = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Input, "MD5").ToLower();
        //    if (IsAdmin)
        //    {
        //        output = output.Substring(1, 2) + output.Substring(29, 2) + output.Substring(7, 8) + output.Substring(18, 4);
        //    }
        //    else
        //    {
        //        output = output.Substring(8, 16);
        //    }
        //    return output;
        //}


        /// <summary>
        /// 字符串加密  进行位移操作
        /// </summary>
        /// <param name="str">待加密数据</param>
        /// <returns>加密后的数据</returns>
        public static string EncryptString(string Input)
        {
            string _temp = "";
            int _inttemp;
            char[] _chartemp = Input.ToCharArray();
            for (int i = 0; i < _chartemp.Length; i++)
            {
                _inttemp = _chartemp[i] + 3;
                _chartemp[i] = (char)_inttemp;
                _temp += _chartemp[i];
            }
            return _temp;
        }

        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="str">待解密数据</param>
        /// <returns>解密成功后的数据</returns>
        public static string NcyString(string Input)
        {
            string _temp = "";
            int _inttemp;
            char[] _chartemp = Input.ToCharArray();
            for (int i = 0; i < _chartemp.Length; i++)
            {
                _inttemp = _chartemp[i] - 3;
                _chartemp[i] = (char)_inttemp;
                _temp += _chartemp[i];
            }
            return _temp;
        }





        private static readonly string skey = System.Configuration.ConfigurationManager.AppSettings["JiaMiKey"].ToString();
        public static string Encrypt(string pToEncrypt)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //把字符串放到byte数组中  
            //原来使用的UTF8编码，我改成Unicode编码了，不行  
            if (pToEncrypt == null)
            {
                return "";
                throw new Exception();
            }
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //byte[]  inputByteArray=Encoding.Unicode.GetBytes(pToEncrypt);  

            //建立加密对象的密钥和偏移量  
            //原文使用ASCIIEncoding.ASCII方法的GetBytes方法  
            //使得输入密码必须输入英文文本  
            des.Key = ASCIIEncoding.ASCII.GetBytes(skey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(skey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            //Write  the  byte  array  into  the  crypto  stream  
            //(It  will  end  up  in  the  memory  stream)  
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            //Get  the  data  back  from  the  memory  stream,  and  into  a  string  
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format  as  hex  
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }

        //解密方法  
        public static string Decrypt(string pToDecrypt)
        {
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                //Put  the  input  string  into  the  byte  array  
                byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
                for (int x = 0; x < pToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }

                //建立加密对象的密钥和偏移量，此值重要，不能修改  
                des.Key = ASCIIEncoding.ASCII.GetBytes(skey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(skey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                //Flush  the  data  through  the  crypto  stream  into  the  memory  stream  
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                //Get  the  decrypted  data  back  from  the  memory  stream  
                //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象  
                StringBuilder ret = new StringBuilder();

                return System.Text.Encoding.Default.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                //throw ex;
                System.Web.HttpContext.Current.Response.Redirect("/PageNoFound.htm");
                return "";
            }
        }





        /// <summary>
        /// 检测含中文字符串实际长度
        /// </summary>
        /// <param name="str">待检测的字符串</param>
        /// <returns>返回正整数</returns>
        public static int NumChar(string Input)
        {
            ASCIIEncoding n = new ASCIIEncoding();
            byte[] b = n.GetBytes(Input);
            int l = 0;
            for (int i = 0; i <= b.Length - 1; i++)
            {
                if (b[i] == 63)//判断是否为汉字或全脚符号
                {
                    l++;
                }
                l++;
            }
            return l;
        }

        /// <summary>
        /// 检测是否合法日期
        /// </summary>
        /// <param name="str">待检测的字符串</param>
        /// <returns></returns>
        public static bool ChkDate(string Input)
        {
            try
            {
                DateTime t1 = DateTime.Parse(Input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 转换日期时间函数
        /// </summary>
        /// <returns></returns>        
        public static string ReDateTime()
        {
            return System.DateTime.Now.ToString("yyyyMMdd");
        }



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

        /// <summary>
        /// 去掉首尾P
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string RemovePor(string Input)
        {
            if (Input != string.Empty && Input != null)
            {
                string TMPStr = Input;
                if (Input.ToLower().Substring(0, 3) == "<p>")
                {
                    TMPStr = TMPStr.Substring(3);
                }
                if (TMPStr.Substring(TMPStr.Length - 4) == "</p>")
                {
                    TMPStr = TMPStr.Remove(TMPStr.ToLower().LastIndexOf("</p>"));
                }
                return TMPStr;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 判断参数是否合法
        /// </summary>
        /// <param name="ID">要判断的参数</param>
        /// <returns>返回已处理的字符串</returns>

        public static string checkID(string ID)
        {
            if (ID == null && ID == string.Empty)
                throw new Exception("参数传递错误!<li>参数不能为空</li>");
            else
                ID = Filter(ID);
            return ID;
        }


        /// <summary>
        /// 去除编号字符串中的'-1'
        /// </summary>
        /// <param name="id"></param>
        /// <returns>如果为空则返回'IsNull'</returns>

        public static string Losestr(string id)
        {
            if (id == null || id == "" || id == string.Empty)
                return "IsNull";

            id = id.Replace("'-1',", "");

            if (id == null || id == "" || id == string.Empty)
                return "IsNull";
            else
                return id;
        }

        public static string FilterHTML(string html)
        {
            if (string.IsNullOrEmpty(html))
                return "";
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href*=*[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            html = regex1.Replace(html, ""); //过滤<script></script>标记
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件           
            html = regex4.Replace(html, ""); //过滤iframe
            html = regex5.Replace(html, ""); //过滤frameset
            html = regex6.Replace(html, ""); //过滤frameset
            html = regex9.Replace(html, "");
            return html;
        }


        ///// <summary>
        ///// 判断字符串是否图片地址
        ///// </summary>
        ///// <param name="inputStr"></param>
        ///// <returns></returns>
        //public static string isPicStr(string inputStr)
        //{
        //    string dimm = Foosun.Config.UIConfig.dirDumm;
        //    if (dimm.Trim() != string.Empty)
        //    {
        //        dimm = "/" + dimm;
        //    }
        //    string gStr = string.Empty;
        //    if (inputStr == string.Empty && inputStr == null)
        //    {
        //        gStr = string.Empty;
        //    }
        //    else
        //    {
        //        if (inputStr.IndexOf(".") > -1)
        //        {
        //            int dotPosition = inputStr.IndexOf(".");
        //            string getFile = inputStr.Substring(dotPosition);
        //            int PType = 0;
        //            switch (getFile.ToLower())
        //            {
        //                case ".jpg":
        //                    PType = 1;
        //                    break;
        //                case ".gif":
        //                    PType = 1;
        //                    break;
        //                case ".jpeg":
        //                    PType = 1;
        //                    break;
        //                case ".png":
        //                    PType = 1;
        //                    break;
        //                case ".bmp":
        //                    PType = 1;
        //                    break;
        //                case ".ico":
        //                    PType = 1;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            if (PType == 1)
        //            {
        //                gStr = "<img src=\"" + dimm + inputStr.ToLower().Replace("{@dirfile}", Foosun.Config.UIConfig.dirFile) + "\" border=\"0\" />";
        //            }
        //            else
        //            {
        //                gStr = inputStr;
        //            }
        //        }
        //        else
        //        {
        //            gStr = inputStr;
        //        }
        //    }
        //    return gStr;
        //}

        /// <summary>
        /// 转换日期时间,arjun
        /// </summary>
        /// <param name="datestr">一个预设的时间</param>
        /// <param name="str">要替换的字符串</param>
        /// <returns>替换后的字符串</returns>
        public static string replaceDateTimeStr(string datestr, string str)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(datestr);
            string _Str = str;
            string year02 = dt.ToString().PadRight(2);
            string year04 = dt.ToString();
            string month = dt.Month.ToString();
            string day = dt.Day.ToString();
            string hour = dt.Hour.ToString();
            string minute = dt.Minute.ToString();
            string second = dt.Second.ToString();
            _Str = _Str.Replace("{@year02}", year02);
            _Str = _Str.Replace("{@year04}", year04);
            _Str = _Str.Replace("{@month}", month);
            _Str = _Str.Replace("{@day}", day);
            _Str = _Str.Replace("{@hour}", hour);
            _Str = _Str.Replace("{@minute}", minute);
            _Str = _Str.Replace("{@second}", second);
            return _Str;
        }


        public static string CkIsNullOrEmpty(string input, string item, bool isStop)
        {
            if (string.IsNullOrEmpty(input) && isStop)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('" + item + "不能为空！')</script>");
                System.Web.HttpContext.Current.Response.End();
                return item + "不能为空！";
            }
            else
            {
                return input + "";
            }
        }

        /// <summary>
        /// 用户提交和url传值过滤
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string FilterAll(string Input)
        {
            return Htmls(Filter(Input));
        }

        /// <summary>
        /// 根据绑定的用户ID获取bbs用户名
        /// 创建人: zhouwei
        /// 创建时间:2010-11-15
        /// </summary>
        /// <param name="key">用户的id</param>
        /// <returns></returns>
        public static string BBsUserName(int key)
        {
            System.Data.DataSet dsUserName = new System.Data.DataSet();
            if (key != 0)
            {
                dsUserName = Maticsoft.DBUtility.DbHelperSQLBBS.Query(" select UserName from Dv_User where UserID='" + key + "' ");
            }
            if (dsUserName != null)
                return dsUserName.Tables[0].Rows[0][0].ToString();
            else
                return null;
        }
        /// <summary>
        /// 根据用户名查询网站用户表的ID
        /// 创建人: zhouwei
        /// 创建时间:2010-11-16
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns></returns>
        public static int WebUserNameID(string username)
        {
            System.Data.DataSet userID = new System.Data.DataSet();
            if (username != "")
            {
                userID = Maticsoft.DBUtility.DbHelperSQL.Query("SELECT Id FROM PBnet_UserTable WHERE (UserName = " + username + ")");
            }
            if (userID != null)
                return Convert.ToInt32(userID.Tables[0].Rows[0][0]);
            else
                return 0;
        }
        /// <summary>
        ///格式化内容换号符号
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string TextFramt(string content)
        {
            content = content.Replace("\r\n", "<br/>");
            return content;
        }

        /// <summary>
        /// 得到配置文件中对商户收费的标准
        /// </summary>
        /// <returns></returns>
        public static string GetPrice()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                //判断是添加什么类型限定
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/MarketConfig.xml"));

                //得到根节点
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {
                    XmlNode haha1 = root.SelectNodes("Price")[0];
                    return haha1.SelectSingleNode("@value").Value;
                }
            }
            catch
            {

                return "-1";
            }
            return "-1";
        }

        /// <summary>
        /// 得到前台配置文件中对页面显示条数
        /// </summary>
        /// <returns></returns>
        public static string GetCount()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                //判断是添加什么类型限定
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/MarketConfig.xml"));

                //得到根节点
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("webPage")[0];
                    return haha.SelectSingleNode("@value").Value;
                }
            }
            catch
            {

                return "-1";
            }
            return "-1";
        }
        /// <summary>
        /// 得到后配置文件中对页面显示条数
        /// </summary>
        /// <returns></returns>
        public static string GetManageCount()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                //判断是添加什么类型限定
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/MarketConfig.xml"));

                //得到根节点
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("webPageManage")[0];
                    return haha.SelectSingleNode("@value").Value;
                }
            }
            catch
            {

                return "-1";
            }
            return "-1";
        }

        /// <summary>
        /// 默认项目属性获取
        /// </summary>
        /// <param name="chiroot">节点名称</param>
        /// <returns>value</returns>
        public static string GetValue(string chiroot)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                //判断是添加什么类型限定
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/TypeConfigure.xml"));

                //得到根节点
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes(chiroot)[0];
                    return haha.SelectSingleNode("@value").Value;
                }
            }
            catch
            {

                return "-1";
            }
            return "-1";
        }

        /// <summary>
        /// 根据节点得到他的值
        /// </summary>
        /// <param name="chiroot">节点名称</param>
        /// <returns>value</returns>
        public static string SetValue(string chiroot, string value)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                //判断是添加什么类型限定
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/TypeConfigure.xml"));

                //得到根节点
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes(chiroot)[0];
                    haha.SelectSingleNode("@value").Value = value;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/TypeConfigure.xml"));
                    return "1";
                }
            }
            catch
            {

                return "-1";
            }
            return "-1";
        }


        /// <summary>
        /// 根据节点得到需要的节点下的所有子节点
        /// </summary>
        /// <param name="name"></param>
        public static DataTable GetCP(string name)
        {
            DataTable tab = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/LottoryCondition.xml"));

            //得到根节点
            XmlElement root = doc.DocumentElement;
            XmlNode haha = root.SelectNodes(name)[0];
            if (haha.ChildNodes.Count > 0)
            {
                tab = new DataTable();
                tab.Columns.Add("number");
                tab.Columns.Add("name");

                for (int i = 0; i < haha.ChildNodes.Count; i++)
                {
                    XmlNode haha1 = haha.SelectNodes("chi")[i];
                    tab.Rows.Add(haha1.SelectSingleNode("@number").Value, haha1.SelectSingleNode("@name").Value);
                }
            }

            return tab;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetRoot()
        {

            return "";
        }

        /// <summary>
        /// 根据条件得到相应的配置文件
        /// </summary>
        /// <param name="name"> 如：Market,Chipped,Challenge</param>
        public static DataTable GetWebConfig(string name)
        {
            DataTable tab = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));

            //得到根节点
            XmlElement root = doc.DocumentElement;
            XmlNode haha = root.SelectNodes(name)[0];
            if (haha.ChildNodes.Count > 0)
            {
                tab = new DataTable();
                tab.Columns.Add("WebName");
                tab.Columns.Add("WebTitle");
                tab.Columns.Add("WebUrl");
                tab.Columns.Add("BarLJ");
                tab.Columns.Add("Copyright");
                tab.Columns.Add("WebKey");

                tab.Columns.Add("WebDescription");
                tab.Columns.Add("WebPageNum");

                if (haha.ChildNodes.Count > 0)
                {
                    XmlNode haha1 = haha.SelectNodes("WebName")[0];
                    XmlNode haha2 = haha.SelectNodes("WebTitle")[0];
                    XmlNode haha3 = haha.SelectNodes("WebUrl")[0];
                    XmlNode haha4 = haha.SelectNodes("BarLJ")[0];
                    XmlNode haha5 = haha.SelectNodes("Copyright")[0];
                    XmlNode haha6 = haha.SelectNodes("WebKey")[0];
                    XmlNode haha7 = haha.SelectNodes("WebDescription")[0];
                    XmlNode haha8 = haha.SelectNodes("WebPageNum")[0];

                    tab.Rows.Add(haha1.SelectSingleNode("@value").Value, haha2.SelectSingleNode("@value").Value, haha3.SelectSingleNode("@value").Value, haha4.SelectSingleNode("@value").Value, haha5.SelectSingleNode("@value").Value, haha6.SelectSingleNode("@value").Value, haha7.SelectSingleNode("@value").Value, haha8.SelectSingleNode("@value").Value);
                }

            }

            return tab;
        }
        /// <summary>
        /// 根据节点得到他的值
        /// </summary>
        /// <param name="chiroot">节点名称</param>
        /// <returns>value</returns>
        /// <param name="configName">配置文件名称</param>
        public static string SetConfigValue(string chiroot,string configName)
        {
            string n_value = "";
                XmlDocument doc = new XmlDocument();
                //判断是添加什么类型限定
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/"+configName));

                //得到根节点
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes(chiroot)[0];
                    n_value = haha.SelectSingleNode("@value").Value;
                    //doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/" + configName));
                }


                return n_value;
        }

        /// <summary>
        /// 去除字符串中的重复字符。 字符格式 a,b,c 字符间要用,号隔开
        /// </summary>
        /// <param name="strinput">处理字符串</param>
        /// <returns></returns>
        public static string RemoveRepeat(string strinput)
        {
            string strouput = "";
            Array stringArray = strinput.Split(',');
            System.Collections.Generic.List<string> listString = new System.Collections.Generic.List<string>();
            //遍历删除重复项 
            foreach (string eachString in stringArray)
            {
                if (!listString.Contains(eachString))
                    listString.Add(eachString);
            }

            //遍历输出 
            foreach (string string1 in listString)   //测试值 
            {
                strouput = strouput + string1 + ',';
            }
            strouput = strouput.Substring(0, strouput.Length - 1);

            return strouput.ToString();
        }
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static ArrayList arrlist(ArrayList arr)
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                int flag = 1;
                for (int j = 0; j < arr.Count - 1 - i; j++)
                {

                    if (Convert.ToInt32(arr[j]) > Convert.ToInt32(arr[j + 1]))
                    {
                        flag = 0;
                        int temp = Convert.ToInt32(arr[j]);
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }

                }
                if (flag == 1)
                {
                    break;
                }
            }

            return arr;
        }
        //获取真实IPview plaincopy to clipboardprint?
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
            string viaIp = "";

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

    }
}
