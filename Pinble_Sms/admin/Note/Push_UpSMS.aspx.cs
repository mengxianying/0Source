using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.IO;
using System.Text;
/*
 * 本接口由东时方科技公司 www.xhsms.com 提供
 * ***************************************************************************
 *   本代码用于短信回复接口调用(被动调用).需要把URL地址提供给客服人员设置
 * ***************************************************************************
 * 需要设置上行URL地址的。需要联系客服人员设置
 * 功能加入日期 2009-12-14号
 *我们提供PUSH下发回复的短信。需要客户提供URL地址给我们。下面的代码可以用于测试
 被调用的页面。上行短信。服务端下发过来
 * ============================================================================
 * ValidateRequest="false" 这个参数非常重要。请在页面头设置.否则报HTTP 500错误
 * =============================================================================
 * 上行短信PUSH方式发送，接口以POST+XML(utf-8编码)格式发送给客户提供的URL上。下面是XML格式 
<ReadSMS> <!--收到短信开始-->
  <Item>  <!--如果有多条循环此节-->
     <Id>101125</Id> <!-- 上行短信编号。唯一值 -->
     <SenderNo>13405886058</SenderNo> <!--回复者号码-->
     <MsgContent>星信:我时工作顺利用这</MsgContent> <!--回复短信内容-->
     <SendTime>2008-03-14 23:07:39</SendTime>  <!--回复时间-->
     <SP_PID>1065810889988</SP_PID> <!-回复到SP号的号码-->
     <subNo>101</subNo> <!--客户扩展子号码-->
  </Item>
</ReadSMS> 
 */
public partial class demo_Push_UpSMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //跟踪代码。测试执行到哪里
        int n = 0;
        //有数据传送过来
        if (!Page.IsPostBack && Request.ContentLength > 0)
        {
            PassiveReceiveSMS();
        }        
    }

    private void PassiveReceiveSMS()
    {
        int n = 0;
        try
        {
            //测试用的。用于测试收到短信。设置的目录必须有写入权限
            StreamWriter sw = new StreamWriter("e:\\temp\\xx.txt", true, System.Text.Encoding.Default);

            //获取请求xml数据流
            StreamReader reader = new StreamReader(Request.InputStream);
            //把请求流转成字符串
            String xml = reader.ReadToEnd();

            //测试用的把收到的写入文件里。用于测试
            sw.WriteLine(xml);
            DataTable dt = null;
            try
            {
                //把收到的短信转成表方便后面操作
                dt = ConvertXMLToDataSet(xml).Tables[0];
            }
            catch
            {
                n = 99;
            }
            n = 1;
            //接收的短信条数
            if (dt != null && dt.Rows.Count > 0)
            {
                n = 2;
                //循环短信条数
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    /*
                     * <Id>101125</Id> <!-- 上行短信编号。唯一值 -->
     <SenderNo>13405886058</SenderNo> <!--回复者号码-->
     <MsgContent>星信:我时工作顺利用这</MsgContent> <!--回复短信内容-->
     <SendTime>2008-03-14 23:07:39</SendTime>  <!--回复时间-->
     <SP_PID>1065810889988</SP_PID> <!-回复到SP号的号码-->
     <subNo>101</subNo> <!--客户扩展子号码-->*/
                    string id = dt.Rows[i]["Id"].ToString(); //上行短信编号, 唯一
                    string sendno = dt.Rows[i]["SenderNo"].ToString(); //回复者的号码
                    string memo = dt.Rows[i]["MsgContent"].ToString(); //回复内容
                    string stime = dt.Rows[i]["SendTime"].ToString(); //回复时间
                    string spid = dt.Rows[i]["SP_PID"].ToString();//网关号码
                    string subno = dt.Rows[i]["subNo"].ToString(); //客户扩展子号码
                    n = 3;
                    //测出用。写入收到的短信内容
                    sw.WriteLine(id + " " + sendno + "  " + memo + " " + stime);
                }
                //关闭写入流
                sw.Close();
            }
        }
        catch
        {
            n = -4;
        }
        //输出一个数字代表操作状态。
        Response.Write(n.ToString());
    }
    /// <summary>
    /// 把接收到的xml格式短信转成DataTable表。方便客户自己操作
    /// </summary>
    /// <param name="xmlData"></param>
    /// <returns></returns>
    public  DataSet ConvertXMLToDataSet(string xmlData)
    {
        StringReader stream = null;
        XmlTextReader reader = null;
        try
        {
            DataSet xmlDS = new DataSet();
            stream = new StringReader(xmlData);
            reader = new XmlTextReader(stream);
            xmlDS.ReadXml(reader);
            return xmlDS;
        }
        catch (Exception ex)
        {
            string strTest = ex.Message;
            return null;
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }
}
