using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pbzx.Common;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Pinble_DataRivalry
{
    public partial class RelUpload : System.Web.UI.Page
    {
        Pbzx.BLL.DataRivalry_UpLoadFile get_ue = new Pbzx.BLL.DataRivalry_UpLoadFile();
        public static string n_issue = "";
        public static int g_lotType = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            string n_request = "";
            if (Request["ln"] != null)
            {
                n_request = Request["ln"].ToString();
                if (n_request == "dzx")
                {
                    lab_lottName.Text = "3D单选";
                    DateTime n_time = Convert.ToDateTime(get_ue.AllowTime("1"));
                    lab_endTime.Text = n_time.ToString();
                    n_issue = get_ue.Period(1);
                    lab_issue.Text = n_issue;
                    g_lotType = 1;

                }
                if (n_request == "dzux")
                {
                    lab_lottName.Text = "3D组选";
                    DateTime n_time = Convert.ToDateTime(get_ue.AllowTime("1"));
                    lab_endTime.Text = n_time.ToString();
                    n_issue = get_ue.Period(1);
                    lab_issue.Text = n_issue;
                    g_lotType = 1;
                }
                if (n_request == "pd")
                {
                    lab_lottName.Text = "排三单选";
                    DateTime n_time = Convert.ToDateTime(get_ue.AllowTime("4"));
                    lab_endTime.Text = n_time.ToString();
                    n_issue = get_ue.Period(4);
                    //lab_issue.Text = n_issue.Substring(0, 3).ToString();
                    lab_issue.Text = n_issue;
                    g_lotType = 2;
                }
                if (n_request == "pzd")
                {
                    lab_lottName.Text = "排三组选";
                    DateTime n_time = Convert.ToDateTime(get_ue.AllowTime("4"));
                    lab_endTime.Text = n_time.ToString();
                    n_issue = get_ue.Period(4);
                    //lab_issue.Text = n_issue.Substring(0, 3).ToString();
                    lab_issue.Text = n_issue;
                    g_lotType = 2;
                }
            }
            else
            {
                lab_lottName.Text = "3D单选";
                DateTime n_time = Convert.ToDateTime(get_ue.AllowTime("1"));
                lab_endTime.Text = n_time.ToString();
                n_issue = get_ue.Period(1);
                lab_issue.Text = n_issue;
                g_lotType = 1;
            }
            
        }

        /// <summary>
        /// 上传大底
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnUpfile_Click(object sender, EventArgs e)
        {
            string n_title="福彩3D单选";
            if (Method.Get_UserName.ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "<script>alert('您还没有登录，请先登录');</script>", false);
                //ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('您还没有登录，请先登录');</script>");
            }
            else
            {
                
                //大底类型 1：单选 2：组选
                int type = 1;
                string lottName = "";
                if (Request["ln"] != null)
                {
                    lottName = Request["ln"].ToString();
                }

                DateTime n_time = Convert.ToDateTime(get_ue.AllowTime("1"));
                if (lottName == "dzux")
                {
                    n_title="福彩3D组选";
                    type = 2;
                }
                if (lottName == "pd")
                {
                    //排3截止时间
                    n_time = Convert.ToDateTime(get_ue.AllowTime("4"));
                    n_title="排三单选";
                }
                if (lottName == "pzd")
                {
                    //排3截止时间
                    n_time = Convert.ToDateTime(get_ue.AllowTime("4"));
                    type = 2;
                    n_title="排三组选";
                }
                //获取截至时间
                if (DateTime.Compare(DateTime.Now, n_time) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('本期已经截止发布大底。开奖后可以发布下期大底')</script>");
                }
                else
                {
                    BtnUpfile.Visible = false;
                    if (this.HtmlInputFiles1.CheckAllPostedFile(true))
                    {
                        int n_succ = 0;
                        for (int i = 0; i <= this.HtmlInputFiles1.RecordCount; i++)
                        {

                            if (this.HtmlInputFiles1[i].PostedFile.FileName.ToString() != "" && this.HtmlInputFiles1[i].PostedFile.FileName != null)
                            {
                                //获取上传文件的全部路径
                                System.IO.FileInfo info = new FileInfo(this.HtmlInputFiles1[i].PostedFile.FileName);
                                //获取上传文件的文件名
                                string fileName = info.Name;
                                int size = this.HtmlInputFiles1[i].PostedFile.ContentLength;
                                //重新定义文件名
                                string filePath = System.Guid.NewGuid().ToString() + fileName;

                                //获取当年
                                int str_year = DateTime.Now.Year;
                                string path = Server.MapPath("UpLoads/" + str_year.ToString()+"/");

                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                    
                                }
                               
                                //保存文件
                                this.HtmlInputFiles1[i].PostedFile.SaveAs(path + filePath);

                                //编辑文件地址
                                string F_CreateName=str_year.ToString()+"/"+ filePath;

                                
                                //上传文件检查文件数据书否正确
                                string uploadMessage = uploadFiles(path + filePath, fileName, size, F_CreateName, type);
                               
                                
                                if (uploadMessage == "true")
                                {
                                    
                                    n_succ++;
                                }
                                else
                                {
                                    File.Delete(path + fileName);
                                    if (uploadMessage == "range")
                                    {

                                        ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('您上传的大底个数不在规定范围中');window.location.href = 'RelUpload.aspx';</script>");
                                        BtnUpfile.Visible = true;
                                        break;
                                    }
                                    else if (uploadMessage == "FileNameSame")
                                    {
                                        ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('您已上传过相同文件');window.location.href = 'RelUpload.aspx';</script>");
                                        BtnUpfile.Visible = true;
                                        break;
                                    }
                                    else
                                    {
                                        ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('上传的数据格式错误,请您检查');window.location.href = 'RelUpload.aspx';</script>");
                                        BtnUpfile.Visible = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (n_succ > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>if(confirm('您要上传 " + n_title + " 大底文件？')){alert('上传成功" + n_succ + "个文本！');}else{window.location.href = 'RelUpload.aspx';}</script>");
                            BtnUpfile.Enabled = true;
                            BtnUpfile.Visible = true;
                        }
                    }
                }
            }

           
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="path">完整路径</param>
        /// <param name="FileName">原始文件名</param>
        /// <param name="FileSize">上传文件的大小</param>
        /// <param name="FilePath">重新定义的路径</param>
        /// <param name="type">类型：组选大底：2  直选大底：1</param>
        public string uploadFiles(string path, string FileName, int FileSize, string FilePath, int type)
        {
            //读取文件
            StreamReader rd = new StreamReader(path, Encoding.UTF8);
            //验证字符是否是0-9的数字
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^[1-9]d*$");
            //保存大底的号码字符串
            StringBuilder group_str = new StringBuilder();
            //大底注数
            string txt_DataRange = "";

            string lintext="";
            //读取到流末尾
            while (!rd.EndOfStream)
            {
                //过滤掉所有非数字0-9的字符 （只留数字）
                lintext += Regex.Replace(rd.ReadLine().ToString(), "[^0-9]", "");

                
            }
            if (lintext != "" || lintext == null)
            {
                //处理字符串
                lintext = Hstr(lintext);
                group_str.Append(lintext + " ");
            }
            txt_DataRange = group_str.ToString().Substring(0, group_str.Length - 1).Split(' ').Length.ToString();
            //去除重复
            string outStr = Input.RemoveRepeat(group_str.ToString().Substring(0, group_str.Length - 1).Replace(" ",","));


            if (type == 1)
            {
                //获取xml中单选大底限制范围
                //int n_LeastRange = Convert.ToInt32(Input.SetConfigValue("LeastRange", "Switchxml.xml"));  //最小值
                //int n_MaximumRange = Convert.ToInt32(Input.SetConfigValue("MaximumRange", "Switchxml.xml"));  //最大值
                int n_LeastRange = 0;  //最小值
                if (Input.SetConfigValue("LeastRange", "Switchxml.xml") != "")
                {
                    n_LeastRange = Convert.ToInt32(Input.SetConfigValue("LeastRange", "Switchxml.xml"));
                }
                int n_MaximumRange = 0;  //最大值
                if (Input.SetConfigValue("MaximumRange", "Switchxml.xml") != "")
                {
                    n_MaximumRange = Convert.ToInt32(Input.SetConfigValue("MaximumRange", "Switchxml.xml"));
                }
                //单选大底
                if (outStr.Split(',').Length < n_LeastRange || outStr.Split(',').Length > n_MaximumRange)
                {
                    rd.Close();
                    rd.Dispose();
                    return "range";
                }
            }
            if (type == 2)
            {
                //获取xml中 组选大底限制范围
                //int n_LeastRange = Convert.ToInt32(Input.SetConfigValue("LeastRange", "GroupNum.xml"));  //最小值
                //int n_MaximumRange = Convert.ToInt32(Input.SetConfigValue("MaximumRange", "GroupNum.xml"));  //最大值
                int n_LeastRange = 0;  //最小值
                if (Input.SetConfigValue("LeastRange", "GroupNum.xml") != "")
                {
                    n_LeastRange = Convert.ToInt32(Input.SetConfigValue("LeastRange", "GroupNum.xml"));
                }
                int n_MaximumRange = 0;  //最大值
                if (Input.SetConfigValue("MaximumRange", "GroupNum.xml") != "")
                {
                    n_MaximumRange = Convert.ToInt32(Input.SetConfigValue("MaximumRange", "GroupNum.xml"));
                }
                //组选大底
                if (outStr.Split(',').Length < n_LeastRange || outStr.Split(',').Length > n_MaximumRange)
                {
                    rd.Close();
                    rd.Dispose();
                    return "range";
                }
            }
            //这一期的大底信息传入数据库
            Pbzx.BLL.DataRivalry_UpLoadFile get_upfile = new Pbzx.BLL.DataRivalry_UpLoadFile();
            Pbzx.Model.DataRivalry_UpLoadFile mod_upfile = new Pbzx.Model.DataRivalry_UpLoadFile();
            Pbzx.BLL.DataRivalry_Contrast get_con = new Pbzx.BLL.DataRivalry_Contrast();
            Pbzx.Model.DataRivalry_Contrast mod_con = new Pbzx.Model.DataRivalry_Contrast();
            //同一个用户不能上传相同文件名的文件
            if (get_upfile.Exists(Method.Get_UserName.ToString(), FileName.Split('.')[0].ToString(), FileSize))
            {
                rd.Close();
                rd.Dispose();
                return "FileNameSame";
            }
            //添加数据
            mod_upfile.F_Period = Convert.ToInt32(n_issue);
            mod_upfile.F_UserName = Method.Get_UserName.ToString();
            mod_upfile.F_FileName = FileName.Split('.')[0].ToString();
            mod_upfile.F_FileType = FileName.Split('.')[1].ToString();
            mod_upfile.F_FileSize = FileSize;
            mod_upfile.F_SingleGroup = type;
            mod_upfile.F_addTime = DateTime.Now;
            mod_upfile.F_CreateName = FilePath;
            //mod_upfile.F_FileNum = Request.Form["txt_DataRange"].ToString();

            mod_upfile.F_FileNum =Convert.ToInt32(txt_DataRange);
            mod_upfile.F_lottery = g_lotType;
            mod_upfile.F_state = 0;
            if (get_upfile.Add(mod_upfile) > 0)
            {
                //查询出当前用户最新添加的一期
                DataSet ds = get_upfile.GetListDesc("F_UserName=" + "'" + Method.Get_UserName.ToString() + "'");
                mod_con.ct_drID = Convert.ToInt32(ds.Tables[0].Rows[0]["F_drID"]);
                mod_con.ct_Num = outStr.ToString();
                try
                {
                    if (get_con.Add(mod_con) > 0)
                    {
                        rd.Close();
                        rd.Dispose();
                        return "true";
                    }
                }
                catch (Exception ex)
                {
                    Pbzx.Common.ErrorLog.WriteLog(ex);
                }
            }
            return "error";
        }

        /// <summary>
        /// 处理字符串（）
        /// </summary>
        /// <param name="lintext"></param>
        /// <returns></returns>
        private string Hstr(string lintext)
        {
            List<string> list = new List<string>();
            while (lintext.Length >= 3)
            {
                list.Add(lintext.Substring(0, 3));
                lintext = lintext.Substring(3);
                if (lintext.Length < 3)
                {
                    lintext = "";
                }
            }
            foreach (string item in list)
            {
                lintext += item + " ";

            }
            lintext = lintext.Substring(0, lintext.Length - 1);
            return lintext.ToString();
        }

        /// <summary>
        /// 手动输入 上传大底
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_handup_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('暂不开放手动输入功能')</script>");
            #region  手动输入
            //判断输入区是否为空
            if (!string.IsNullOrEmpty(txt_n.Text.ToString()))
            {
                string n_title = "福彩3D单选";
                if (Method.Get_UserName.ToString() == "0")
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "<script>alert('您还没有登录，请先登录');</script>", false);
                }
                else
                {
                    //大底类型 1：单选 2：组选
                    int type = 1;
                    string lottName = "";

                    if (Request["ln"] != null)
                    {
                        lottName = Request["ln"].ToString();
                    }
                    DateTime n_time = Convert.ToDateTime(get_ue.AllowTime("1"));
                    if (lottName == "dzux")
                    {
                        n_title = "福彩3D组选";
                        type = 2;
                    }
                    if (lottName == "pd")
                    {
                        //排3截止时间
                        n_time = Convert.ToDateTime(get_ue.AllowTime("4"));
                        n_title = "体彩排列三单选";
                    }
                    if (lottName == "pzd")
                    {
                        //排3截止时间
                        n_time = Convert.ToDateTime(get_ue.AllowTime("4"));
                        type = 2;
                        n_title = "体彩排列三组选";
                    }
                    //获取截至时间
                    if (DateTime.Compare(DateTime.Now, n_time) > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('本期已经截止发布大底。开奖后可以发布下期大底')</script>");
                        txt_n.Text = "";
                        return;
                    }
                    else
                    {
                        btn_handup.Visible = false;
                        //格式化时间
                        string timeStr = string.Format("{0:yyyyMMddHHmmssffff}", DateTime.Now);
                        //组合文件名称 （用户名+当前期号+大底类型+发布时间）
                        string fileName = Method.Get_UserName.ToString() + n_issue + n_title + timeStr + ".txt";

                        //获取当年
                        int str_year = DateTime.Now.Year;
                        string path = Server.MapPath("UpLoads/" + str_year.ToString() + "/");

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);

                        }
                        //过滤非数字字符 处理字符串
                        string txt = Regex.Replace(txt_n.Text.ToString(), "[^0-9]", "");
                        //string txt = Regex.Replace(txt_n.Text.ToString(), @"\D", "");

                        string s = Hstr(txt);

                        string txt_DataRange = s.Split(' ').Length.ToString();
                        //去除重复数据
                        string newS = Input.RemoveRepeat(s.Replace(" ", ","));
                        if (type == 1)
                        {
                            //获取xml中单选大底限制范围
                            int n_LeastRange = 0;  //最小值
                            if (Input.SetConfigValue("LeastRange", "Switchxml.xml") != "")
                            {
                                n_LeastRange = Convert.ToInt32(Input.SetConfigValue("LeastRange", "Switchxml.xml"));
                            }
                            int n_MaximumRange =0;  //最大值
                            if (Input.SetConfigValue("MaximumRange", "Switchxml.xml") != "")
                            {
                                n_MaximumRange = Convert.ToInt32(Input.SetConfigValue("MaximumRange", "Switchxml.xml"));
                            }
                            //单选大底
                            if (newS.Split(',').Length < n_LeastRange || newS.Split(',').Length > n_MaximumRange)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('您输入的大底个数不在规定范围中');window.location.href = 'RelUpload.aspx';</script>");
                                btn_handup.Visible = true;
                                txt_n.Text = "";
                                return;
                            }
                        }
                        if (type == 2)
                        {
                            //获取xml中 组选大底限制范围
                            int n_LeastRange = 0;  //最小值
                            if (Input.SetConfigValue("LeastRange", "GroupNum.xml") != "")
                            {
                                n_LeastRange = Convert.ToInt32(Input.SetConfigValue("LeastRange", "GroupNum.xml"));
                            }
                            int n_MaximumRange = 0;  //最大值
                            if (Input.SetConfigValue("MaximumRange", "GroupNum.xml") != "")
                            {
                                n_MaximumRange = Convert.ToInt32(Input.SetConfigValue("MaximumRange", "GroupNum.xml"));
                            }
                            //组选大底
                            if (newS.Split(',').Length < n_LeastRange || newS.Split(',').Length > n_MaximumRange)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('您输入的大底个数不在规定范围中');window.location.href = 'RelUpload.aspx';</script>");
                                btn_handup.Visible = true;
                                txt_n.Text = "";
                                return;
                            }
                        }
                        //这一期的大底信息传入数据库
                        Pbzx.BLL.DataRivalry_UpLoadFile get_upfile = new Pbzx.BLL.DataRivalry_UpLoadFile();
                        Pbzx.Model.DataRivalry_UpLoadFile mod_upfile = new Pbzx.Model.DataRivalry_UpLoadFile();
                        Pbzx.BLL.DataRivalry_Contrast get_con = new Pbzx.BLL.DataRivalry_Contrast();
                        Pbzx.Model.DataRivalry_Contrast mod_con = new Pbzx.Model.DataRivalry_Contrast();
                        //同一个用户不能上传相同文件名的文件
                        if (get_upfile.Exists(Method.Get_UserName.ToString(), fileName.Split('.')[0].ToString(), 0))
                        {
                            File.Delete(path + fileName);
                            ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('您已上传过相同文件');window.location.href = 'RelUpload.aspx';</script>");
                            btn_handup.Visible = true;
                            txt_n.Text = "";
                            return;
                        }

                        //显示用名称
                        string showName = Method.Get_UserName.ToString() + "-" + n_title + "-" + n_issue + "期-" + txt_DataRange + "注";

                        // 判断文件是否存在，不存在则创建，否则读取值显示到窗体            
                        if (!File.Exists(path + fileName))
                        {
                            //创建写入文件
                            FileStream fs1 = new FileStream(path + fileName, FileMode.Create, FileAccess.Write);

                            //开始写入值   
                            StreamWriter sw = new StreamWriter(fs1);
                            //去掉所有，号
                            string sNum = newS.Replace(",", "");
                            string removeNum = "";
                            for (int i = 0; i < sNum.Length / 30; i++)
                            {
                                sw.WriteLine(Hstr(sNum.Substring(i * 30, 30)));
                                //删除截取的数字
                                int j = i + 1;
                                removeNum = sNum.Remove(0, 30 * j);

                            }
                            if (removeNum != "")
                            {
                                sw.WriteLine(Hstr(removeNum));
                            }


                            sw.Close();
                            fs1.Close();

                            //添加数据
                            mod_upfile.F_Period = Convert.ToInt32(n_issue);
                            mod_upfile.F_UserName = Method.Get_UserName.ToString();
                            mod_upfile.F_FileName = showName;
                            mod_upfile.F_FileType = fileName.Split('.')[1].ToString();
                            mod_upfile.F_FileSize = 0;
                            mod_upfile.F_SingleGroup = type;
                            mod_upfile.F_addTime = DateTime.Now;
                            mod_upfile.F_CreateName = str_year.ToString() + "/" + fileName;
                            //mod_upfile.F_FileNum = Request.Form["txt_DataRange"].ToString();

                            mod_upfile.F_FileNum = Convert.ToInt32(txt_DataRange);
                            mod_upfile.F_lottery = g_lotType;
                            mod_upfile.F_state = 0;
                            if (get_upfile.Add(mod_upfile) > 0)
                            {
                                //查询出当前用户最新添加的一期
                                DataSet ds = get_upfile.GetListDesc("F_UserName=" + "'" + Method.Get_UserName.ToString() + "'");
                                mod_con.ct_drID = Convert.ToInt32(ds.Tables[0].Rows[0]["F_drID"]);
                                mod_con.ct_Num = newS.ToString();
                                try
                                {
                                    if (get_con.Add(mod_con) > 0)
                                    {
                                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>if(confirm('您要发布" + n_title + "大底数据？')){alert('发布成功！');}else{window.location.href = 'RelUpload.aspx';}</script>");
                                        btn_handup.Enabled = true;
                                        btn_handup.Visible = true;
                                        txt_n.Text = "";
                                    }
                                    else
                                    {
                                        ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('上传的数据错误,请您检查数据重新上传');window.location.href = 'RelUpload.aspx';</script>");
                                        btn_handup.Visible = true;
                                        txt_n.Text = "";
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Pbzx.Common.ErrorLog.WriteLog(ex);
                                }
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('已有相同的文件名，请稍后在发布');window.location.href = 'RelUpload.aspx';</script>");
                            btn_handup.Visible = true;
                            txt_n.Text = "";
                        }

                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('请在输入区写入大底号码');window.location.href = 'RelUpload.aspx';</script>");
                btn_handup.Enabled = true;
            }
            #endregion
        }


    }
}