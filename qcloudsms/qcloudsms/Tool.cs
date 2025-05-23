using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.IO;
using System.Management;
using System.Net;

/// <summary>
/// Tool 的摘要说明
/// </summary>
class Tool
{
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
    [DllImport("kernel32")]
    private static extern void GetWindowsDirectory(StringBuilder WinDir, int count);

    Random Ra = new Random();

    

    public string GetWindowsPath()
    {
        try
        {
            const int nChars = 128;
            StringBuilder Buff = new StringBuilder(nChars);
            GetWindowsDirectory(Buff, nChars);

            string returnstr = Buff.ToString();
            return returnstr;

        }
        catch
        {
            MessageBox.Show("读取 windows 目录错误");
            return "";
        }
    }
    //替换指定的两个字符串之间的字符串为新的字符串,并删除这两个指定的字符串
    public string ReplaceBetweenDelTag(string Sour, string start_oldvalue, string end_oldvalue, string newvalue)
    {
        try
        {
            int startdot = Sour.IndexOf(start_oldvalue);

            int delcount = Sour.IndexOf(end_oldvalue, startdot + start_oldvalue.Length) + end_oldvalue.Length - startdot;
            Sour = Sour.Remove(startdot, delcount);
            Sour = Sour.Insert(startdot, newvalue);


            return Sour;
        }
        catch
        {
            throw new Exception("工具包出现异常");
        }
    }
                


    public string GetNowTimeForFile()
    {
        string ReturnYear = DateTime.Now.Date.Year.ToString().Trim();
        string ReturnMonth = DateTime.Now.Month.ToString().Trim();
        if (ReturnMonth.Length.Equals(1))
        {
            ReturnMonth = "0" + ReturnMonth;
        }
        string ReturnDay = DateTime.Now.Day.ToString().Trim();
        if (ReturnDay.Length.Equals(1))
        {
            ReturnDay = "0" + ReturnDay;
        }
        string ReturnHour = DateTime.Now.Hour.ToString().Trim();
        if (ReturnHour.Length.Equals(1))
        {
            ReturnHour = "0" + ReturnHour;
        }
        string ReturnMinute = DateTime.Now.Minute.ToString().Trim();
        if (ReturnMinute.Length.Equals(1))
        {
            ReturnMinute = "0" + ReturnMinute;
        }
        string ReturnSecond = DateTime.Now.Second.ToString().Trim();
        if (ReturnSecond.Length.Equals(1))
        {
            ReturnSecond = "0" + ReturnSecond;
        }
        string ReturnString = ReturnYear + "" + ReturnMonth + "" + ReturnDay + "" + ReturnHour + "" + ReturnMinute + "" + ReturnSecond;
        return ReturnString;
    }
    public string UnicodeToString(string unicode)
    {
        try
        {
            if (string.IsNullOrEmpty(unicode))
            {
                return "";
            }
            return System.Text.RegularExpressions.Regex.Unescape(unicode);
        }
        catch
        {
            return unicode;
        }
    }

    public int CompareMax(int numa, int numb)
    {
        if (numa > numb)
        {
            return numa;
        }
        else if (numa == numb)
        {
            return numa;
        }
        else if (numa < numb)
        {
            return numb;
        }
        else
        {
            return numa;
        }


    }
    public string[] Process_StringArray(string SourString)
    {
        int i = 0;
        int j;
        int num = 1;
        SourString = SourString.Replace(" ", "+");
        for (j = 0; j < SourString.Length; j++)
        {
            if (SourString.Substring(j, 1).Equals("+"))
            {
                num = num + 1;
            }
        }
        string[] SourStringArray = new string[num];
        SourString = SourString + "+";
        while (SourString.IndexOf("+") != -1)
        {
            SourStringArray[i] = SourString.Substring(0, SourString.IndexOf("+"));
            SourString = SourString.Substring(SourString.IndexOf("+") + 1);
            i++;
        }
        return SourStringArray;
    }
    public void Clear_MyArray(Array myarray)
    {
        for (int b = 0; b < myarray.Length; b++)
        {
            myarray.SetValue(null, b);
        }
    }
    /// <summary>
    /// 转换html为txt文本
    /// </summary>
    public string htmltotxt(string html_content)
    {
        html_content = html_content.Replace("　", " ");
        html_content = html_content.Replace("&nbsp;", " ");

        while (html_content.IndexOf("<!--") != -1 && html_content.IndexOf("-->") != -1)
        {
            html_content = this.DelBetweenAllStr(html_content, "<!--", "-->");
        }

        while (html_content.IndexOf("<head>") != -1 && html_content.IndexOf("</head>") != -1)
        {
            html_content = this.DelBetweenAllStr(html_content, "<head>", "</head>");
        }

        while (html_content.IndexOf("<HEAD>") != -1 && html_content.IndexOf("</HEAD>") != -1)
        {
            html_content = this.DelBetweenAllStr(html_content, "<HEAD>", "</HEAD>");
        }

        while (html_content.IndexOf("<script") != -1 && html_content.IndexOf("</script>") != -1)
        {
            html_content = this.DelBetweenAllStr(html_content, "<script", "</script>");
        }

        while (html_content.IndexOf("<Script") != -1 && html_content.IndexOf("</Script>") != -1)
        {
            html_content = this.DelBetweenAllStr(html_content, "<Script", "</Script>");
        }

        while (html_content.IndexOf("<SCRIPT") != -1 && html_content.IndexOf("</SCRIPT>") != -1)
        {
            html_content = this.DelBetweenAllStr(html_content, "<SCRIPT", "</SCRIPT>");
        }

        while (html_content.IndexOf("<style>") != -1 && html_content.IndexOf("</style>") != -1)
        {
            html_content = this.DelBetweenAllStr(html_content, "<style>", "</style>");
        }

        while (html_content.IndexOf("<SCRIPT") != -1 && html_content.IndexOf("</script>") != -1)
        {
            html_content = this.DelBetweenAllStr(html_content, "<SCRIPT", "</script>");
        }

        while (html_content.IndexOf("<script") != -1 && html_content.IndexOf("</SCRIPT>") != -1)
        {
            html_content = this.DelBetweenAllStr(html_content, "<script", "</SCRIPT>");
        }

        while (html_content.IndexOf("<") != -1 && html_content.IndexOf(">") != -1)
        {
            html_content = this.DelBetweenAllStr(html_content, "<", ">");
        }
        return html_content;
    }
    /// <summary>
    /// 返回删除两个字符串中间的内容后的内容 (包括这两个字符的内容) start和end是不一样
    /// </summary>
    public string DelBetweenAllStr(string Sour, string Start, string End)
    {
        string returnstr = "";
        int startdot = Sour.IndexOf(Start);
        int enddot = Sour.IndexOf(End, startdot + Start.Length);

        if (startdot > -1 && enddot > -1)
        {
            returnstr = Sour.Remove(startdot, enddot - startdot + End.Length);
        }

        return returnstr;
    }


    //返回一个有换行的字符串的指定行号的内容,从1开始
    public string RowStr(string Sour, int RowID)
    {
        try
        {
            string returnstr = "";
            string enterTag = "\r\n";

            Sour = Sour + enterTag;

            int x = 1;
            while (Sour.IndexOf(enterTag) != -1)
            {
                if (RowID.Equals(x))
                {
                    int enterdot = Sour.IndexOf(enterTag);
                    returnstr = Sour.Substring(0, enterdot);
                    break;
                }
                else
                {
                    int enterdot = Sour.IndexOf(enterTag) + enterTag.Length;
                    Sour = Sour.Remove(0, enterdot);
                }
                x++;

            }
            return returnstr;
        }
        catch
        {
            throw new Exception("工具包出现异常");
        }
    }

    //替换两对新的标志
    public string ReplaceBetweenTag(string Sour, string start_oldvalue, string end_oldvalue, string start_newvalue, string end_newvalue)
    {
        try
        {

            int startdot = Sour.IndexOf(start_oldvalue);
            int enddot = Sour.IndexOf(end_oldvalue, startdot + start_oldvalue.Length);

            Sour = Sour.Remove(enddot, end_oldvalue.Length);
            Sour = Sour.Insert(enddot, end_newvalue);

            Sour = Sour.Remove(startdot, start_oldvalue.Length);
            Sour = Sour.Insert(startdot, start_newvalue);


            return Sour;
        }
        catch
        {
            throw new Exception("工具包出现异常");
        }
    }

   


    //返回两个字符串中间的内容 (不包括这两个字符串的内容)
    public string BetweenStr(string Sour, string Start, string End)
    {
        try
        {

            string returnstr = "";
            int startdot = Sour.IndexOf(Start) + Start.Length;

            if (Sour.IndexOf(Start) > -1)
            {
                if (!End.Equals(""))
                {
                    int enddot = Sour.IndexOf(End, startdot);
                    returnstr = Sour.Substring(startdot, enddot - startdot);
                }
                else
                {
                    returnstr = Sour.Substring(startdot);
                }
            }

            return returnstr;
        }
        catch
        {
            throw new Exception("工具包出现异常");
        }
    }

    //返回删除两个字符串中间的内容后的内容 (包括这两个字符的内容)
    public string DelBetweenStr(string Sour, string Start, string End)
    {
        try
        {
            string returnstr = "";
            int startdot = Sour.IndexOf(Start);
            int enddot = Sour.IndexOf(End, startdot + Start.Length);//这里加Start.Length是因为start和end是一样的

            returnstr = Sour.Remove(startdot, enddot - startdot);

            return returnstr;
        }
        catch
        {
            throw new Exception("工具包出现异常");
        }
    }

    public double ReturnDOUBLE(double yuan, int weishu)
    {
        string yuanstr = yuan.ToString().Trim();
        if (yuanstr.IndexOf(".") != -1)
        {
            string yuanstr_head = yuanstr.Substring(0, yuanstr.IndexOf("."));
            string yuanstr_back = yuanstr.Substring(yuanstr.IndexOf(".") + 1);

            if (yuanstr_back.Length >= weishu)
            {
                yuanstr_back = yuanstr_back.Substring(0, weishu);
            }

            yuanstr = yuanstr_head + "." + yuanstr_back;
            return double.Parse(yuanstr);
        }
        else
        {
            return yuan;
        }
    }
    public String ReturnStringFromDOUBLE(decimal yuan, int weishu)
    {
        string yuanstr = yuan.ToString().Trim();
        if (yuanstr.IndexOf(".") != -1)
        {
            string yuanstr_head = yuanstr.Substring(0, yuanstr.IndexOf("."));
            string yuanstr_back = yuanstr.Substring(yuanstr.IndexOf(".") + 1);

            if (yuanstr_back.Length >= weishu)
            {
                yuanstr_back = yuanstr_back.Substring(0, weishu);
            }

            yuanstr = yuanstr_head + "." + yuanstr_back;
            return yuanstr;
        }
        else
        {
            return yuan.ToString();
        }
    }
    public string encoding(string STRSOU)
    {
        if (STRSOU == null)
        {
            return null;
        }
        StringBuilder sb = new StringBuilder();
        for (int i = (STRSOU.Length - 1); i >= 0; i--)
        {
            char chr = Char.Parse(STRSOU.Substring(i, 1));
            if (chr == '0')
            {
                sb.Append((chr));
            }
            else if (chr == '5')
            {
                sb.Append((chr));
            }
            else if (chr == '6')
            {
                sb.Append((chr));
            }
            else if (chr == '7')
            {
                sb.Append((chr));
            }
            else if (chr == '3')
            {
                sb.Append((chr));
            }
            else if (chr == '&')
            {
                sb.Append((chr));
            }
            else if (chr == 'I')
            {
                sb.Append((chr));
            }
            else if (chr == 'j')
            {
                sb.Append((chr));
            }
            else if (chr == '%')
            {
                sb.Append((chr));
            }
            else
            {
                sb.Append((char)(chr & 0xffe0 | ((chr & 0x001f) ^ 0x0015)));
            }
        }

        return sb.ToString().Trim();
    }
    public string decoding(string STRSOU)
    {
        return encoding(STRSOU);
    }
    public string ReturnConf(string Section, string Key)
    {
        try
        {
            StringBuilder Temp = new StringBuilder(255);
            string FilePath = Application.StartupPath + "\\config.ini";
            int i = GetPrivateProfileString(Section, Key, "", Temp, 255, FilePath);

            return Temp.ToString();
        }
        catch
        {
            return "";
        }

    }
    public void WriteConf(string Section, string Key, string KeyValue)
    {
        try
        {
            string FilePath = Application.StartupPath + "\\config.ini";
            WritePrivateProfileString(Section, Key, KeyValue, FilePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show("对不起，写入失败。" + ex.ToString());
        }

    }
    public string ReturnConfForCustomINI(string Section, string Key, string filepath)
    {
        try
        {
            StringBuilder Temp = new StringBuilder(255);
            string FilePath = filepath;
            int i = GetPrivateProfileString(Section, Key, "", Temp, 255, FilePath);

            return Temp.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return "";
        }
    }
    /// <summary>
    /// 返回一个文本文件的内容
    /// </summary>
    public string ReadtxtFile(string thisFileName)
    {
        try
        {
            string MESSAGE_richTextBox = "";
            if (File.Exists(thisFileName))
            {

                FileStream fs = new FileStream(thisFileName, FileMode.Open, FileAccess.ReadWrite);
                StreamReader m_streamReader = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));

                //使用StreamReader类来读取文件
                m_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

                // 从数据流中读取每一行，直到文件的最后一行，并在richTextBox1中显示出内容
                string strLine = m_streamReader.ReadLine();
                while (strLine != null)
                {
                    MESSAGE_richTextBox += strLine + "\n";
                    strLine = m_streamReader.ReadLine();
                }
                //关闭此StreamReader对象
                m_streamReader.Close();
            }
            return MESSAGE_richTextBox;
        }
        catch
        {
            return "";
        }

    }
    public void WriteConfForCustomINI(string Section, string Key, string KeyValue, string filepath)
    {
        try
        {
            string FilePath = filepath;
            WritePrivateProfileString(Section, Key, KeyValue, FilePath);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    /// <summary>
    /// 检查字符串两端的 Tag 符,为SQL in 操作准备,或者为 Split 方法准备
    /// </summary>
    public string ForSqlInStr(string Sour, string Tag)
    {
        if (Sour.Length > 0)
        {
            if (Sour.Substring(0, 1).Equals(Tag))
            {
                Sour = Sour.Substring(1);
            }
        }
        if (Sour.Length > 0)
        {
            if (Sour.Substring(Sour.Length - 1).Equals(Tag))
            {
                Sour = Sour.Substring(0, Sour.Length - 1);
            }
        }
        return Sour;
    }
    public string ToPercent(int number, int totla)
    {
        double numberx = double.Parse(number.ToString());
        double totlax = double.Parse(totla.ToString());

        double tempdoublet = numberx / totlax * 100;

        string justmyvaluest = tempdoublet.ToString();

        if (justmyvaluest.IndexOf('.') != -1)
        {
            justmyvaluest = justmyvaluest.Substring(0, justmyvaluest.IndexOf('.'));
        }

        return justmyvaluest + "%";
    }
    /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
       public  string GetTimeStamp()  
       {  
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);  
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();  
       } 
    public string GetNowTime()
    {
        string ReturnYear = DateTime.Now.Date.Year.ToString().Trim();
        string ReturnMonth = DateTime.Now.Month.ToString().Trim();
        if (ReturnMonth.Length.Equals(1))
        {
            ReturnMonth = "0" + ReturnMonth;
        }
        string ReturnDay = DateTime.Now.Day.ToString().Trim();
        if (ReturnDay.Length.Equals(1))
        {
            ReturnDay = "0" + ReturnDay;
        }
        string ReturnHour = DateTime.Now.Hour.ToString().Trim();
        if (ReturnHour.Length.Equals(1))
        {
            ReturnHour = "0" + ReturnHour;
        }
        string ReturnMinute = DateTime.Now.Minute.ToString().Trim();
        if (ReturnMinute.Length.Equals(1))
        {
            ReturnMinute = "0" + ReturnMinute;
        }
        string ReturnSecond = DateTime.Now.Second.ToString().Trim();
        if (ReturnSecond.Length.Equals(1))
        {
            ReturnSecond = "0" + ReturnSecond;
        }
        string ReturnString = ReturnYear + "-" + ReturnMonth + "-" + ReturnDay + " " + ReturnHour + ":" + ReturnMinute + ":" + ReturnSecond;
        return ReturnString;
    }
    public string GetNowDate()
    {
        string ReturnYear = DateTime.Now.Date.Year.ToString().Trim();
        string ReturnMonth = DateTime.Now.Month.ToString().Trim();
        if (ReturnMonth.Length.Equals(1))
        {
            ReturnMonth = "0" + ReturnMonth;
        }
        string ReturnDay = DateTime.Now.Day.ToString().Trim();
        if (ReturnDay.Length.Equals(1))
        {
            ReturnDay = "0" + ReturnDay;
        }
        string ReturnHour = DateTime.Now.Hour.ToString().Trim();

        string ReturnString = ReturnYear + "-" + ReturnMonth + "-" + ReturnDay;
        return ReturnString;
    }
    public string GetNowTime_Month()
    {
        string ReturnMonth_Month = DateTime.Now.Month.ToString().Trim();
        if (ReturnMonth_Month.Length.Equals(1))
        {
            ReturnMonth_Month = "0" + ReturnMonth_Month;
        }
        return ReturnMonth_Month;
    }
    public string GetNowTime_Year()
    {
        string ReturnYear_Year = DateTime.Now.Year.ToString().Trim();
        return ReturnYear_Year;
    }
    public string GetNowTime_Day()
    {
        string ReturnDay_Day = DateTime.Now.Day.ToString().Trim();
        if (ReturnDay_Day.Length.Equals(1))
        {
            ReturnDay_Day = "0" + ReturnDay_Day;
        }
        return ReturnDay_Day;
    }
    public string REQUEST_string(string SourSTR)
    {
        SourSTR = SourSTR.Replace("'", "'");
        SourSTR = SourSTR.Replace("<", "&lt;");
        SourSTR = SourSTR.Replace(">", "&gt;");
        SourSTR = SourSTR.ToString().Trim();
        return SourSTR;
    }
    /// <summary>
    /// 返回参数SourStr的double格式的字符串，如果转换无效则返回"pass"
    /// </summary>
    public string ConvertDoubleTest(string SourStr)
    {
        if (SourStr.Length > 0)
        {
            if (SourStr.IndexOf("折") != -1)
            {
                return "pass";
            }
            else
            {
                string tempint = "";
                for (int x = 0; x < SourStr.Length; x++)
                {
                    string tempstr = SourStr.Substring(x, 1);
                    if (tempstr.Equals("."))
                    {
                        tempint = tempint + ".";
                    }
                    else
                    {
                        try
                        {
                            tempint = tempint + (int.Parse(tempstr)).ToString();
                        }
                        catch
                        {

                        }
                    }
                }
                SourStr = tempint;
                try
                {
                    double tempdouble = double.Parse(SourStr);
                    if (SourStr.Length > 0)
                    {
                        return SourStr;
                    }
                    else
                    {
                        return "pass";
                    }
                }
                catch
                {
                    return "pass";
                }
            }
        }
        else
        {
            return "pass";
        }
    }
    public string REQUEST_PROstring(string SourSTR, string NullSTR)
    {
        if (SourSTR == "" || SourSTR == null)
        {
            return NullSTR;
        }
        else
        {
            SourSTR = SourSTR.Replace("'", "''");
            SourSTR = SourSTR.Replace("<", "&lt;");
            SourSTR = SourSTR.Replace(">", "&gt;");
            SourSTR = SourSTR.ToString().Trim();
            return SourSTR;
        }

    }
    public string KEY_pro(string yuan)
    {
        yuan = yuan.Replace("~", "");
        yuan = yuan.Replace("!", "");
        yuan = yuan.Replace("@", "");
        yuan = yuan.Replace("#", "");
        yuan = yuan.Replace("$", "");
        yuan = yuan.Replace("%", "");
        yuan = yuan.Replace("^", "");
        yuan = yuan.Replace("&", "");
        yuan = yuan.Replace("*", "");
        yuan = yuan.Replace("(", "");
        yuan = yuan.Replace(")", "");
        yuan = yuan.Replace("|", "");
        yuan = yuan.Replace("/", "");
        yuan = yuan.Replace("\\", "");
        yuan = yuan.Replace("<", "");
        yuan = yuan.Replace(">", "");

        return yuan;
    }
    public string REQUEST_PRO_ONLYDANYINHAOstring(string SourSTR, string NullSTR)
    {
        if (SourSTR == "" || SourSTR == null)
        {
            return NullSTR;
        }
        else
        {
            SourSTR = SourSTR.Replace("'", "''");
            /*
            SourSTR = SourSTR.Replace("script","");
            SourSTR = SourSTR.Replace("Script","");
            SourSTR = SourSTR.Replace("SCRIPT","");
            SourSTR = SourSTR.Replace("ScripT","");
            SourSTR = SourSTR.Replace("/script","");
            SourSTR = SourSTR.Replace("/Script","");
            SourSTR = SourSTR.Replace("<br>","");
            SourSTR = SourSTR.Replace("<p>","");
            SourSTR = SourSTR.Replace("</p>","");
            SourSTR = SourSTR.Replace("<td>","");
            SourSTR = SourSTR.Replace("</td>","");
            SourSTR = SourSTR.Replace("<tr>","");
            SourSTR = SourSTR.Replace("</tr>","");
            SourSTR = SourSTR.Replace("</table>","");
            SourSTR = SourSTR.Replace("</font>","");
            SourSTR = SourSTR.Replace("  ","");
            SourSTR = SourSTR.Replace("&nbsp;","");
            SourSTR = SourSTR.Replace("<hr>","");
            SourSTR = SourSTR.Replace("<i>","");
            SourSTR = SourSTR.Replace("</i>","");
            SourSTR = SourSTR.Replace("<b>","");
            SourSTR = SourSTR.Replace("</b>","");
            SourSTR = SourSTR.Replace("<u>","");
            SourSTR = SourSTR.Replace("</u>","");
            SourSTR = SourSTR.Replace("<","");
            SourSTR = SourSTR.Replace(">","");
            */

            SourSTR = SourSTR.ToString().Trim();
            return SourSTR;
        }

    }
    public string REQUEST_NOPROstring(string SourSTR, string NullSTR)
    {
        if (SourSTR == "" || SourSTR == null)
        {
            return NullSTR;
        }
        else
        {
            SourSTR = SourSTR.ToString().Trim();
            return SourSTR;
        }
    }
    public string RandomApp_ID()
    {
        string RandomID = "";
        for (int i = 1; i < 9; i++)
        {
            RandomID = (Math.Round(Ra.NextDouble() * 9)).ToString() + RandomID;
        }
        return RandomID;
    }
    public String sixzero(Object inputobj)
    {
        try
        {
            if (inputobj == null)
            {
                return "0.00";
            }
            else
            {
                String x = inputobj.ToString();
                if (x.Length > 0)
                {
                    x = x.Replace(".000000", "");

                    if (x.IndexOf(".") > -1)
                    {
                        String qianmian = x.Substring(0, x.IndexOf("."));

                        String houmian = x.Substring(x.IndexOf(".") + 1);

                        houmian = houmian + "ZZZ";
                        houmian = houmian.Replace("00000ZZZ", "");
                        houmian = houmian.Replace("0000ZZZ", "");
                        houmian = houmian.Replace("000ZZZ", "");
                        houmian = houmian.Replace("00ZZZ", "");
                        houmian = houmian.Replace("0ZZZ", "");
                        houmian = houmian.Replace("ZZZ", "");

                        return qianmian + "." + houmian;


                    }
                    else
                    {
                        return x;
                    }
                }
                else
                {
                    return "0.00";
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public String GetDateFromTime(String TimeStr)
    {
        try
        {
            if (TimeStr.IndexOf(" ") > -1)
            {
                return TimeStr.Substring(0, TimeStr.IndexOf(" "));
            }
            else
            {
                return TimeStr;
            }
        }
        catch
        {
            return TimeStr;
        }
    }
    public string RandomFilename()
    {
        string RandomFilenameStr = "";
        for (int i = 1; i < 9; i++)
        {
            RandomFilenameStr = (Math.Round(Ra.NextDouble() * 9)).ToString() + RandomFilenameStr;
        }
        RandomFilenameStr = RandomFilenameStr + System.DateTime.Now.Ticks;
        for (int i = 1; i < 9; i++)
        {
            RandomFilenameStr = (Math.Round(Ra.NextDouble() * 9)).ToString() + RandomFilenameStr;
        }
        return RandomFilenameStr;
    }

   
}