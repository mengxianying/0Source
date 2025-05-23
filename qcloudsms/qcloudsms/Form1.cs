using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

using System.Data.SqlClient;
using System.Collections;
using System.IO;

namespace qcloudsms
{
    public partial class Form1 : Form
    {
        public String appkey = "078725ce170a46ec1f9c5e9e32365acf";
        public int appid = 1400530114;

        Business bus = new Business();
        Tool tools = new Tool();

        public IHTTPClient httpclient { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tostart();
        }
        public void tostart()
        {
            this.richTextBox1.AppendText(tools.GetNowTime() + "开始运行" + "\n");
            this.button1.Enabled = false;
            this.button2.Enabled = true;
            this.timer1.Start();
        }

        public bool SendSMS(String tel,int mobanid,String paras)
        {
            try
            {
                string[] parameters = paras.Split('。');
                SmsSingleSender sss = new SmsSingleSender(this.appid, this.appkey);
                SmsSingleSenderResult t = sss.sendWithParam("86", tel, mobanid, parameters, "拼搏在线", "", "");

                String ss = t.ToString();
                if (ss.IndexOf("\"result\":0,\"errmsg\":\"OK\"") > -1)
                {
                    return true;
                }
                else
                {
                    String ss_cn = tools.UnicodeToString(ss);

                    this.richTextBox2.AppendText(tools.GetNowTime() + " 发送短信错误 " + ss + "  " + ss_cn + "，手机号：" + tel + "；模板：" + mobanid.ToString() + "；内容：" + paras + "" + "\n");

                    bus.SaveException("接口发送失败" + ss.ToString() + "  " + ss_cn + "；手机号：" + tel + "；模板：" + mobanid.ToString() + "；内容：" + paras + "");
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.richTextBox1.AppendText(tools.GetNowTime() + " 停止运行" + "\n");
            this.button1.Enabled = true;
            this.button2.Enabled = false;
            this.timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String exesql = "";
            try
            {
                ArrayList SMS_GUID = new ArrayList();
                ArrayList CREATE_TIME = new ArrayList();
                ArrayList SEND_STATE = new ArrayList();
                ArrayList MOBILE = new ArrayList();
                ArrayList TENCENT_TEMPLATEID = new ArrayList();
                ArrayList PARAS = new ArrayList();
                ArrayList SEND_TIME = new ArrayList();
                ArrayList IP = new ArrayList();

                if (bus.ConnectMYSQL(tools.ReturnConf("DB", "IP"), tools.ReturnConf("DB", "USER"), tools.ReturnConf("DB", "PASSWORD"), tools.ReturnConf("DB", "DATABASE")))
                {
                    String sql2 = "select top 10 ";

                    sql2 += "SMS_GUID,";
                    sql2 += "CREATE_TIME,";
                    sql2 += "SEND_STATE,";
                    sql2 += "MOBILE,";
                    sql2 += "TENCENT_TEMPLATEID,";
                    sql2 += "PARAS,";
                    sql2 += "SEND_TIME";
                    sql2 += "IP";

                    sql2 += "  from PBnet_TBL_SMS where SEND_STATE='W' order by CREATE_TIME";

                    exesql = sql2;

                    SqlCommand myCommand2 = new SqlCommand(sql2, bus.MYSQLConn);
                    myCommand2.CommandTimeout = 150;
                    SqlDataReader myReader2 = myCommand2.ExecuteReader();

                    while (myReader2.Read())
                    {
                        SMS_GUID.Add(myReader2.GetValue(0).ToString().Trim());
                        CREATE_TIME.Add(myReader2.GetValue(1).ToString().Trim());
                        SEND_STATE.Add(myReader2.GetValue(2).ToString().Trim());
                        MOBILE.Add(myReader2.GetValue(3).ToString().Trim());
                        TENCENT_TEMPLATEID.Add(myReader2.GetValue(4).ToString().Trim());
                        PARAS.Add(myReader2.GetValue(5).ToString().Trim());
                        SEND_TIME.Add(myReader2.GetValue(6).ToString().Trim());
                        IP.Add(myReader2.GetValue(7).ToString().Trim());
                    }
                    myCommand2.Dispose();
                    myReader2.Close();

                    bus.CloseSql();
                }
                else
                {
                    throw new Exception("连接数据库失败");
                }

                bus.CloseSql();



                ArrayList UpdateOKCD = new ArrayList();
                ArrayList UpdateOKTEL = new ArrayList();

                ArrayList UpdateFAILCD = new ArrayList();
                ArrayList UpdateFAILTEL = new ArrayList();

                for (int h = 0; h < SMS_GUID.Count; h++)
                {
                    if (MOBILE[h].ToString().Trim().Length > 0 && TENCENT_TEMPLATEID[h].ToString().Trim().Length > 0)
                    {
                        String _tel = MOBILE[h].ToString().Trim();
                        int _mbid = int.Parse(TENCENT_TEMPLATEID[h].ToString().Trim());
                        String canshu = PARAS[h].ToString().Trim();

                        bool signleruslt = SendSMS(_tel, _mbid, canshu);

                        if (signleruslt)
                        {
                            UpdateOKCD.Add(SMS_GUID[h].ToString().Trim());
                            UpdateOKTEL.Add(MOBILE[h].ToString().Trim());
                        }
                        else
                        {
                            UpdateFAILCD.Add(SMS_GUID[h].ToString().Trim());
                            UpdateFAILTEL.Add(MOBILE[h].ToString().Trim());
                        }
                    }
                }

                if (UpdateOKCD.Count > 0 || UpdateFAILCD.Count > 0)
                {
                    if (bus.ConnectMYSQL(tools.ReturnConf("DB", "IP"), tools.ReturnConf("DB", "USER"), tools.ReturnConf("DB", "PASSWORD"), tools.ReturnConf("DB", "DATABASE")))
                    {
                        for (int b = 0; b < UpdateOKCD.Count; b++)
                        {
                            String psql = "update PBnet_TBL_SMS set SEND_STATE='Y', SEND_TIME=getdate() where SMS_GUID='" + UpdateOKCD[b].ToString().Trim() + "' ";

                            SqlCommand myCommand = new SqlCommand(psql, bus.MYSQLConn);
                            myCommand.ExecuteNonQuery();

                            exesql = psql;

                            this.richTextBox1.AppendText(tools.GetNowTime() + " 至" + UpdateOKTEL[b].ToString().Trim() + " 发送成功" + "\n");
                        }

                        for (int b = 0; b < UpdateFAILCD.Count; b++)
                        {
                            String psql = "update PBnet_TBL_SMS set SEND_STATE='N', SEND_TIME=null where SMS_GUID='" + UpdateFAILCD[b].ToString().Trim() + "' ";

                            SqlCommand myCommand = new SqlCommand(psql, bus.MYSQLConn);
                            myCommand.ExecuteNonQuery();

                            exesql = psql;

                            this.richTextBox2.AppendText(tools.GetNowTime() + " 至" + UpdateFAILTEL[b].ToString().Trim() + " 发送失败" + "\n");
                        }
                        bus.CloseSql();
                    }
                    else
                    {
                        throw new Exception("连接数据库失败");
                    }

                    bus.CloseSql();
                }
            }
            catch (SqlException sqlex)
            {
                //如果是SQL报错，则不停计时器，接着跑，但记录到日志中
                bus.CloseSql();

                bus.SaveException(sqlex.ToString() + exesql);
                this.richTextBox2.AppendText(tools.GetNowTime() + " 执行SQL出现错误，见日志" + "\n");
                
            }
            catch (Exception ex)
            {
                bus.CloseSql();
                this.timer1.Stop();

                this.button1.Enabled = true;
                this.button2.Enabled = false;
                this.richTextBox2.AppendText(tools.GetNowTime() + "出现异常已停止运行，见日志" + "\n");
                MessageBox.Show(ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bus.SaveException(ex.ToString() + exesql);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.BackColor = ColorTranslator.FromHtml("#eeeeee");

            this.button1.BackColor = ColorTranslator.FromHtml("#cccccc");

            int exceptioncount = 0;
            try
            {
                if (Directory.Exists(Application.StartupPath + "\\Exception"))
                {
                    String[] pfiles = Directory.GetFiles(Application.StartupPath + "\\Exception");
                    exceptioncount = pfiles.Length;
                }
            }
            catch
            { 
            
            }

            if (exceptioncount > 0)
            {
                this.linkLabel1.LinkColor = Color.Red;
                this.linkLabel1.Text = "已发现 " + exceptioncount.ToString() + " 个错误日志";
            }
            else
            {
                this.linkLabel1.LinkColor = Color.Black;
                this.linkLabel1.Text = "未发现错误日志";
                this.linkLabel1.Enabled = false;

            }

            tostart();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(Application.StartupPath + "\\Exception"))
            {
                System.Diagnostics.Process.Start("Explorer.exe", Application.StartupPath + "\\Exception");   
            }
            
        }

        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                notifyIcon1.Visible = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            } 
        }        
    }
}
