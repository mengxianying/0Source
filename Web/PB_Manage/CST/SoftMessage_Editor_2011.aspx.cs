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
using Pbzx.Common;
using Maticsoft.DBUtility;
using Pbzx.Model;
using Pbzx.BLL;
using System.Collections.Generic;
using System.Xml;
using System.Globalization;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class SoftMessage_Editor_2011 : System.Web.UI.Page
    {
        CM_MainManager cmmage = new CM_MainManager();
        Pbzx.BLL.CstSoftware softwar = new Pbzx.BLL.CstSoftware();
        CM_MainBySoftwareTypeManager cmmanager = new CM_MainBySoftwareTypeManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["FCKeditor:UserFilesPath"] = "/Images/UploadFiles/CstMessage";
                Session["DefaultSelect"] = "/Images/UploadFiles/CstMessage";

                //得到当前时间
                txtPostTime1.Text = DateTime.Now.ToString();
                txtPostTime2.Text = DateTime.Now.AddDays(3).ToString();

                Pbzx.Model.CM_Main cmain = null;

                //绑定软件信息下拉框
                BindDropdownList();

                //注册类型信息列表手动绑定
                RegType();

                //用户限定类型绑定
                UserType();

                //消息等级绑定
                MsgType();
                //消息类别
                BindddlMsgCategory1();

                string str = Request.QueryString["ID"];

                //判断str是否存在
                if (str != null && OperateText.IsNumber(str))
                {
                    cmain = cmmage.GetMain(int.Parse(str));



                    txtusername.Text = cmain.UserName.Replace("(|", "\r\n");
                    txtRzm.Text = cmain.HDSN.Replace("(|", "\r\n");
                    //    BindInstall();
                    if (cmain != null)
                    {
                        //将软件信息还原成选择信息（本页面最大的亮点）
                        DataSet dst = cmmanager.GetList("CMID='" + cmain.Id + "'");

                        if (dst != null && dst.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
                            {

                                if (dst.Tables[0].Rows[i][2].ToString() == "0")
                                {
                                    ListItem it = new ListItem();
                                    it.Text = "不限定";
                                    it.Value = "0,0,0,0|";
                                    Lists.Items.Add(it);
                                }
                                else
                                {
                                    //新建一个listItem对象
                                    ListItem it = new ListItem();
                                    //将16进制的软件ID 转换成正确的 ID信息
                                    //得到软件id
                                    int zqid1 = Convert.ToInt32(dst.Tables[0].Rows[i][2]) / 16;
                                    //得到软件ID下面项的ID
                                    int zqid2 = Convert.ToInt32(dst.Tables[0].Rows[i][2]) % 16;
                                    //得到版本号的间隔信息
                                    string vis = dst.Tables[0].Rows[i][3] + "," + dst.Tables[0].Rows[i][4];

                                    it.Text = dst.Tables[0].Rows[i][5] + ":" + dst.Tables[0].Rows[i][6] + ":" + vis;
                                    it.Value = zqid1 + "," + zqid2 + "," + vis + "|";
                                    Lists.Items.Add(it);
                                }
                            }
                        }

                        //先判断是否有限定信息存在则给他遍历，否则没必要遍历
                        //if (cmain.SoftInfo.Trim() != "")
                        //{
                        //    string[] rjhy = cmain.SoftInfo.Split('|'); //数据以 |分割成数组形式

                        //    //遍历此分割的数组列表
                        //    for (int i = 0; i < rjhy.Length - 1; i++)
                        //    {
                        //        //将此信息再分割成数组
                        //        string[] rjmx = rjhy[i].Split(',');

                        //        //得到16进制的软件ID
                        //        int rjid = Convert.ToInt32(rjmx[0]);

                        //        //将16进制的软件ID 转换成正确的 ID信息
                        //        //得到软件id
                        //        int zqid1 = rjid / 16;
                        //        //得到软件ID下面项的ID
                        //        int zqid2 = rjid % 16;
                        //        //得到版本号的间隔信息
                        //        string vis = rjmx[1] + "," + rjmx[2];

                        //        //新建一个listItem对象
                        //        ListItem it = new ListItem();



                        //        if (zqid1 != 0)
                        //        {
                        //            //给他的显示值和键赋值
                        //            //  it.Text = ddlSoftwareType.Items.FindByValue(zqid1.ToString()).Text + ":" + ddlInstallType.Items.FindByValue(zqid2.ToString()).Text + ":" + vis;
                        //            if (rjmx.Length > 4)
                        //            {
                        //                it.Text = rjmx[3] + ":" + rjmx[4] + ":" + vis;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            it.Text = "不限定";
                        //        }
                        //        it.Value = zqid1 + "," + zqid2 + "," + vis + "|";

                        //        //将此项添加到lists中
                        //        Lists.Items.Add(it);
                        //    }

                        //}

                        //得到注册类型
                        string[] regtype = cmain.RegType.Split('|');
                        //当注册类型有数据时才给他选中
                        if (regtype.Length > 0)
                        {
                            for (int i = 0; i < regtype.Length - 1; i++)
                            {
                                if (regtype[i] != "")
                                {
                                    checkBoxreg.Items.FindByValue(regtype[i]).Selected = true;
                                }
                            }
                        }

                        //得到用户限定信息
                        string[] usety = cmain.UserClass.Split('|');

                        //判断用户限定信息是否存在
                        if (usety.Length > 0)
                        {
                            for (int i = 0; i < usety.Length - 1; i++)
                            {
                                if (usety[i] != "")
                                {
                                    CheckBoxUser.Items.FindByValue(usety[i]).Selected = true;
                                }
                            }
                        }

                        //得到消息的类型
                        int lx = cmain.Mtype;
                        //判断，并给他绑定
                        if (lx >= 0)
                        {
                            rblMsgLevel.Items.FindByValue(lx.ToString()).Selected = true;
                        }
                        //是否启用用户限定
                        DisplayCheckBoxUser();
                        //发布时间
                        txtMsgTime.Text = cmain.PostTime.ToString();

                        //发布人
                        string sendername = cmain.Sender;
                        if (sendername != "")
                        {
                            ListItem lst = rblMsgSender.Items.FindByText(sendername);
                            if (lst != null)
                            {

                                lst.Selected = true;
                            }

                        }
                        //是否发布
                        rblMsgSend.SelectedValue = cmain.State.ToString();

                        //给标题赋值
                        txtMsgTitle.Text = cmain.Title;

                        //消息内容
                        string contentLr = cmain.Content;
                        //当内容为空时，则判断他是URL类型
                        if (contentLr.Trim() == "")
                        {
                            rblMsgType.Items.FindByValue("1").Selected = true;

                            txturl.Text = cmain.ContentURL;
                            txturl.Visible = true;
                            Divurl.Visible = true;
                            divcontent.Visible = false;
                        }
                        else
                        {
                            rblMsgType.Items.FindByValue("0").Selected = true;
                            if (rblMsgLevel.SelectedValue == "1" || rblMsgLevel.SelectedValue == "2" || rblMsgLevel.SelectedValue == "4")
                            {
                                txtMsgContent.Value = cmain.Content;
                            }
                            else if (rblMsgLevel.SelectedValue == "3")
                            {
                                txtMsgContent1.Text = cmain.Content;
                            }

                            txturl.Visible = false;
                            Divurl.Visible = false;
                            divcontent.Visible = true;
                        }

                        //给标题链接赋值
                        txttitleUrl.Text = cmain.Linkurl;
                        //消息类别
                        string[] lex = cmain.Category.Split('#');
                        if (lex.Length > 0)
                        {
                            ddlMsgCategory1.SelectedValue = lex[0];
                            ddlMsgCategory2.SelectedValue = lex[1];

                        }
                        //时限
                        //开始时间
                        txtPostTime1.Text = cmain.BeginTime.ToString();
                        //结束时间
                        txtPostTime2.Text = cmain.EndTime.ToString();

                        //发布状态
                        int zt = cmain.State;
                        if (zt == 0)
                        {
                            rblMsgSend.Items[1].Selected = true;
                        }
                        else
                        {
                            rblMsgSend.Items[0].Selected = true;
                        }

                        //高度和宽度
                        txtwidth.Text = cmain.WebWidth.ToString();
                        txtheight.Text = cmain.WebHeight.ToString();
                        //访问次数
                        lblToday.Text = cmain.TodayCount.ToString();
                        lblTotal.Text = cmain.TotalCount.ToString();

                    }

                }
                else
                {
                    rblMsgLevel.Items[0].Selected = true;
                    rblMsgType.Items[0].Selected = true;
                }

                //模版显示绑定
                MB();
                if (cmain != null)
                {
                    //模版选中绑定
                    if (cmain.WebWidth > 0)
                    {
                        if (Rdbtn1.Items.Count > 1)
                        {
                            string number = "0";
                            if (cmain.WebWidth == 665)
                            {
                                number = "2";
                            }
                            else if (cmain.WebWidth == 565)
                            {
                                number = "6";
                            }
                            else if (cmain.WebWidth == 266)
                            {
                                number = "0";
                            }
                            else if (cmain.WebWidth == 300)
                            {
                                number = "1";
                            }
                            else if (cmain.WebWidth == 350)
                            {
                                number = "5";
                            }
                            Rdbtn1.SelectedValue = number;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 消息等级绑定方法
        /// </summary>
        private void MsgType()
        {
            XmlDataSource msgdata = new XmlDataSource();
            msgdata.DataFile = "~/xml/Msg_Private.xml";
            rblMsgLevel.DataSource = msgdata;
            rblMsgLevel.DataBind();
        }
        /// <summary>
        /// 用户类型绑定方法
        /// </summary>
        private void UserType()
        {
            XmlDataSource userdata = new XmlDataSource();
            userdata.DataFile = "~/xml/Msg_UserClass.xml";
            CheckBoxUser.DataSource = userdata;
            CheckBoxUser.DataBind();
        }
        /// <summary>
        /// 注册类型手动绑定方法
        /// </summary>
        private void RegType()
        {
            XmlDataSource regdata = new XmlDataSource();
            regdata.DataFile = "~/xml/Msg_RegType.xml";
            checkBoxreg.DataSource = regdata;
            checkBoxreg.DataBind();
        }
        //<summary>
        //DropDownList数据绑定
        //</summary>
        private void BindDropdownList()
        {
            string sqlSoft = "Select SoftwareName,SoftwareType from [CstSoftware] Group By SoftwareName,SoftwareType order by min(CstID)";
            DataSet ds = DbHelperSQL1.Query(sqlSoft);


            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = ds.Tables[0].Rows[i]["SoftwareName"].ToString();
                    item.Value = ds.Tables[0].Rows[i]["SoftwareType"] + "_" + ds.Tables[0].Rows[i]["SoftwareName"];

                    ddlSoftwareType.Items.Add(item);
                }
            }

            //ddlSoftwareType.DataTextField = "SoftwareName";
            //ddlSoftwareType.DataValueField = "SoftwareType";
            //ddlSoftwareType.DataSource = ds;
            //ddlSoftwareType.DataBind();

            BindInstall();

            string uname = WebFunc.GetCurrentAdmin();
            this.rblMsgSender.Items.Insert(0, new ListItem("SYSOP", "SYSOP"));
            this.rblMsgSender.Items.Insert(1, new ListItem(uname, uname));
            this.rblMsgSender.Items[0].Selected = true;
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();

            this.txtMsgTime.Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// 绑定消息类别(1)
        /// </summary>
        private void BindddlMsgCategory1()
        {
            XmlDataSource regdata = new XmlDataSource();
            regdata.DataFile = "~/xml/Msg_SortOne.xml";
            ddlMsgCategory1.DataSource = regdata;
            ddlMsgCategory1.DataBind();
            BindddlMsgCategory2();
        }
        /// <summary>
        /// 绑定消息类别(2)
        /// </summary>
        private void BindddlMsgCategory2()
        {
            ddlMsgCategory2.Items.Clear();
            XmlDocument dom = new XmlDocument();
            dom.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortTwo.xml"));//装载XML文档 
            XmlElement root = dom.DocumentElement;
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                XmlNode haha = root.SelectNodes("reg")[i];
                //得到他的ID
                string ss = haha.SelectSingleNode("@number").Value;

                if (ss == ddlMsgCategory1.SelectedValue)
                {
                    ListItem item = new ListItem();
                    item.Text = haha.SelectSingleNode("@name").Value;
                    item.Value = haha.SelectSingleNode("@name").Value;
                    ddlMsgCategory2.Items.Add(item);
                }
            }
            ddlMsgCategory2.DataBind();

        }
        /// <summary>
        /// 点击保存(生成静态页面)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            //if (txtMsgPV.Text.Trim() == "")
            //{
            //    strErrMsg += "版本不能为空.\\r\\n";
            //}
            DateTime dtTemp = new DateTime();
            if (!DateTime.TryParse(this.txtMsgTime.Text, out dtTemp))
            {
                strErrMsg += "发布时间未输入或数据格式不正确.\\r\\n";
            }
            if (txtMsgTitle.Text.Trim() == "")
            {
                strErrMsg += "消息标题不能为空.\\r\\n";
            }
            if (rblMsgLevel.SelectedValue == "1" || rblMsgLevel.SelectedValue == "2" || rblMsgLevel.SelectedValue == "4")
            {
                if (rblMsgType.SelectedItem.Value == "0" && txtMsgContent.Value.Trim() == "")
                {
                    strErrMsg += "消息内容不能为空.\\r\\n";
                }
            }

            else if (rblMsgLevel.SelectedValue == "3")
            {
                if (rblMsgType.SelectedItem.Value == "0" && txtMsgContent1.Text.Trim() == "")
                {
                    strErrMsg += "消息内容不能为空.\\r\\n";
                }
            }

            if (!DateTime.TryParse(this.txtPostTime1.Text, out dtTemp) || !DateTime.TryParse(this.txtPostTime2.Text, out dtTemp))
            {
                strErrMsg += "时限数据格式不正确.\\r\\n";
            }
            if (rblMsgType.SelectedValue != "0")
            {
                if (txturl.Text.Trim() == "")
                {
                    strErrMsg += "url地址不能为空.\\r\\n";
                }
                int width = 0, height = 0;
                if (!int.TryParse(txtwidth.Text, out width) || !int.TryParse(txtheight.Text, out height))
                {
                    strErrMsg += "请正确填写宽度和高度，限制为整数.\\r\\n";
                }
                if (width <= 0 || height <= 0)
                {
                    strErrMsg += "请将宽度和高度改为大于0的整数.\\r\\n";
                }

            }
            if (strErrMsg == "")
            {
                if (Convert.ToDateTime(this.txtPostTime1.Text) >= Convert.ToDateTime(this.txtPostTime2.Text))
                {
                    strErrMsg += "时限开始时间不能等于或大于结束时间.\\r\\n";
                }
            }
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的软件消息信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {

                //新建一个实体对象
                CM_Main mains = null;
                if (Request.QueryString["ID"] != null)
                {
                    mains = cmmage.GetMain(Convert.ToInt32(Request.QueryString["ID"]));
                }
                else
                {
                    mains = new CM_Main();
                }

                string usernames = txtusername.Text.Trim();
                //--将页面的字段中的值封装到对象中。
                string strings = "";

                string[] usernameset = usernames.Replace("\r\n", "|").Split('|');

                if (usernameset.Length > 0)
                {
                    for (int i = 0; i < usernameset.Length; i++)
                    {
                        if (usernameset[i] != "")
                        {
                            strings = strings + "|" + usernameset[i];
                        }
                    }

                }

                if (strings != "")
                {
                    string un = strings + "|";
                    if (un.Substring(0, 1) == "|")
                    {
                        mains.UserName = un;
                    }
                    else
                    {
                        mains.UserName = "|" + un;
                    }


                }
                else
                {
                    mains.UserName = "";
                }


                string[] rzmstrings = txtRzm.Text.Trim().Replace("\r\n", "|").Split('|');

                string rzmstring = "";
                if (rzmstrings.Length > 0)
                {
                    for (int i = 0; i < rzmstrings.Length; i++)
                    {
                        if (rzmstrings[i] != "")
                        {
                            rzmstring = rzmstring + "|" + rzmstrings[i];
                        }

                    }
                }

                if (rzmstring != "")
                {
                    mains.HDSN = rzmstring + "|";

                }
                else
                {
                    mains.HDSN = "";
                }

                //------------------------------------------------------------软件限定信息
                //string softwt = null; //定义一个变量来放软件信息
                //for (int i = 0; i < Lists.Items.Count; i++)
                //{
                //    ListItem lt = Lists.Items[i];
                //    string[] zu = lt.Value.Split(',');
                //    if (zu.Length >= 4)
                //    {
                //        if (lt.Text != "不限定")
                //        {
                //            softwt += ((int.Parse(zu[0]) * 16) + int.Parse(zu[1])) + "," + zu[2] + "," + zu[3].Split('|')[0] + "," + lt.Text.Split(':')[0] + "," + lt.Text.Split(':')[1] + "|";
                //        }
                //    }

                //}



                //if (softwt != null)
                //{
                //    mains.SoftInfo = softwt;
                //}
                //else
                //{
                //    mains.SoftInfo = "0,0,0|"; //给他不限定

                //}











                //-----------------------------------------------------------注册限定信息
                string regstring = null;  //定义一个变量来存放注册限定信息
                if (checkBoxreg.Items[0].Selected)
                {
                    regstring = "|0|";
                }
                else
                {
                    for (int j = 0; j < checkBoxreg.Items.Count; j++)
                    {
                        if (checkBoxreg.Items[j].Selected)
                        {

                            regstring += checkBoxreg.Items[j].Value + "|";
                        }
                    }
                }
                if (regstring != null)
                {

                    if (regstring.Substring(0, 1) == "|")
                    {
                        mains.RegType = regstring;
                    }
                    else
                    {
                        mains.RegType = "|" + regstring;
                    }

                }
                else
                {
                    mains.RegType = "|0|";
                }

                //----------------------------------------------------------用户限定信息
                string userstring = null;  //定义一个变量来存放用户限定信息

                if (CheckBoxUser.Items[0].Selected)
                {
                    userstring = "|0|";
                }
                else
                {
                    for (int q = 0; q < CheckBoxUser.Items.Count; q++)
                    {
                        if (CheckBoxUser.Items[q].Selected)
                        {

                            userstring += CheckBoxUser.Items[q].Value + "|";
                        }
                    }
                }
                if (userstring != null)
                {
                    if (userstring.Substring(0, 1) == "|")
                    {
                        mains.UserClass = userstring;
                    }
                    else
                    {
                        mains.UserClass = "|" + userstring;
                    }

                }
                else
                {
                    mains.UserClass = "|0|";
                }

                //－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－发布人
                mains.Sender = rblMsgSender.SelectedItem.Text;

                //-------------------------------------------------------------消息类型（1普通消息，2.紧急消息3.网页消息.4.最新咨询）
                int mtint = 1; //默认为普通消息
                for (int z = 0; z < rblMsgLevel.Items.Count; z++)
                {
                    if (rblMsgLevel.Items[z].Selected)
                    {
                        mtint = int.Parse(rblMsgLevel.Items[z].Value);
                    }
                }
                mains.Mtype = mtint;
                //-------------------------------------------------------------------------类别

                mains.Category = ddlMsgCategory1.SelectedItem.Text + "#" + ddlMsgCategory2.SelectedItem.Text;

                //--------------------------------------------------------------------状态 0.未发布，1已发布
                mains.State = Convert.ToInt32(rblMsgSend.SelectedValue);

                ////发布时间
                mains.PostTime = DateTime.Parse(txtMsgTime.Text);

                //开始时间
                //if (rblMsgSend.SelectedValue == "1")
                //{
                //    if (Convert.ToDateTime(txtPostTime1.Text) < DateTime.Now)
                //        mains.BeginTime = DateTime.Now;
                //    else
                //        mains.BeginTime = DateTime.Parse(txtPostTime1.Text);

                //}
                //else
                //{
                //    mains.BeginTime = DateTime.Parse(txtPostTime1.Text);
                //}
                mains.BeginTime = DateTime.Parse(txtPostTime1.Text);

                //结束时间
                mains.EndTime = DateTime.Parse(txtPostTime2.Text);


                //标题
                mains.Title = txtMsgTitle.Text;

                //内容静态页URL地址（以 http:开头）
                mains.ContentURL = txturl.Text;
                //标题链接
                mains.Linkurl = txttitleUrl.Text;
                //最后访问时间
                mains.LastTime = DateTime.Now;

                //今日访问次数
                mains.TodayCount = Convert.ToInt32(lblToday.Text);

                //总访问次数
                mains.TotalCount = Convert.ToInt32(lblTotal.Text);

                //消息内容
                if (rblMsgType.SelectedValue == "0")
                {
                    if (rblMsgLevel.SelectedValue == "1" || rblMsgLevel.SelectedValue == "2" || rblMsgLevel.SelectedValue == "4")
                    {
                        mains.Content = txtMsgContent.Value;
                    }
                    else if (rblMsgLevel.SelectedValue == "3")
                    {
                        mains.Content = txtMsgContent1.Text;
                    }
                }
                else
                {
                    mains.Content = "";

                }
                if (rblMsgType.SelectedItem.Value != "1")
                {
                    //高度和宽度
                    //启用模版1的高度和宽度
                    if (Rdbtn1.SelectedValue == "0")
                    {
                        mains.WebHeight = 118;
                        mains.WebWidth = 266;
                    }
                    else if (Rdbtn1.SelectedValue == "1")
                    {
                        mains.WebHeight = 150;
                        mains.WebWidth = 300;
                        //启用模版2的高度和宽度
                    }
                    else if (Rdbtn1.SelectedValue == "2")
                    {
                        mains.WebHeight = 343;
                        //添加15的滚动条
                        mains.WebWidth = 665;
                    }
                    else if (Rdbtn1.SelectedValue == "3")
                    {
                        mains.WebHeight = 343;
                        mains.WebWidth = 650;
                    }
                    else if (Rdbtn1.SelectedValue == "4")
                    {
                        mains.WebHeight = 343;
                        mains.WebWidth = 650;
                    }
                    else if (Rdbtn1.SelectedValue == "5")
                    {
                        mains.WebHeight = 200;
                        mains.WebWidth = 350;
                    }
                    else if (Rdbtn1.SelectedValue == "6")
                    {
                        mains.WebHeight = 243;
                        mains.WebWidth = 565;
                    }
                }
                else
                {
                    mains.WebHeight = Convert.ToInt32(txtheight.Text);
                    mains.WebWidth = Convert.ToInt32(txtwidth.Text);
                }
                CM_MainManager cmMain = new CM_MainManager();
                if (Request.QueryString["ID"] != null)
                {
                    ViewState["ID"] = Request.QueryString["ID"];
                    mains.Id = Convert.ToInt32(Request.QueryString["ID"]);
                    if (rblMsgType.SelectedValue == "0")
                    {
                        mains.ContentURL = ConfigurationManager.AppSettings["WebURL"] + "/html/CM_Main/" + rblMsgLevel.SelectedValue + "/" + DateTime.Now.Year.ToString() + "/Msg_" + Request.QueryString["ID"] + ".html";
                    }
                    if (cmMain.Update(mains))
                    {

                        //先清除软件限定表中的数据
                        if (mains.Id > 0)
                        {
                            cmmanager.DeleteByCM_ID(mains.Id);
                        }


                        if (Lists.Items.Count == 0)
                        {
                            CM_MainBySoftwareType cmtype = new CM_MainBySoftwareType();
                            cmtype.CMID = mains.Id;
                            cmtype.SoftInfo = 0;
                            cmtype.BeginVersion = 0;
                            cmtype.EndVersion = 0;
                            cmtype.SoftwareName = "0";
                            cmtype.InstallName = "0";
                            cmmanager.Add(cmtype);
                        }


                        for (int i = 0; i < Lists.Items.Count; i++)
                        {
                            ListItem lt = Lists.Items[i];
                            string[] zu = lt.Value.Split(',');
                            if (zu.Length >= 4)
                            {
                                CM_MainBySoftwareType cmtype = new CM_MainBySoftwareType();
                                if (lt.Text != "不限定")
                                {
                                    cmtype.CMID = mains.Id;
                                    cmtype.SoftInfo = ((int.Parse(zu[0]) * 16) + int.Parse(zu[1]));
                                    cmtype.BeginVersion = Convert.ToInt32(zu[2].ToString());
                                    cmtype.EndVersion = Convert.ToInt32(zu[3].Split('|')[0]);
                                    cmtype.SoftwareName = lt.Text.Split(':')[0];
                                    cmtype.InstallName = lt.Text.Split(':')[1];

                                    cmmanager.Add(cmtype);
                                }
                                else
                                {
                                    cmtype.CMID = mains.Id;
                                    cmtype.SoftInfo = 0;
                                    cmtype.BeginVersion = 0;
                                    cmtype.EndVersion = 0;
                                    cmtype.SoftwareName = "0";
                                    cmtype.InstallName = "0";
                                    cmmanager.Add(cmtype);
                                }
                            }
                        }


                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改软件消息[" + mains.Id + ":" + mains.Title + "].");
                    }
                    else
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改软件消息[" + mains.Id + ":" + mains.Title + "]，修改失败。");
                        Response.Write("<script>alert('修改失败');</script>");
                    }
                }
                else
                {
                    int i = cmMain.Add(mains);
                    if (i > 0)
                    {
                        if (Lists.Items.Count == 0)
                        {
                            CM_MainBySoftwareType cmtype = new CM_MainBySoftwareType();
                            cmtype.CMID = i;
                            cmtype.SoftInfo = 0;
                            cmtype.BeginVersion = 0;
                            cmtype.EndVersion = 0;
                            cmtype.SoftwareName = "0";
                            cmtype.InstallName = "0";
                            cmmanager.Add(cmtype);
                        }


                        for (int its = 0; its < Lists.Items.Count; its++)
                        {
                            ListItem lt = Lists.Items[its];
                            string[] zu = lt.Value.Split(',');
                            if (zu.Length >= 4)
                            {
                                CM_MainBySoftwareType cmtype = new CM_MainBySoftwareType();
                                if (lt.Text != "不限定")
                                {
                                    cmtype.CMID = i;
                                    cmtype.SoftInfo = ((int.Parse(zu[0]) * 16) + int.Parse(zu[1]));
                                    cmtype.BeginVersion = Convert.ToInt32(zu[2].ToString());
                                    cmtype.EndVersion = Convert.ToInt32(zu[3].Split('|')[0]);
                                    cmtype.SoftwareName = lt.Text.Split(':')[0];
                                    cmtype.InstallName = lt.Text.Split(':')[1];

                                    cmmanager.Add(cmtype);
                                }
                                else
                                {
                                    cmtype.CMID = i;
                                    cmtype.SoftInfo = 0;
                                    cmtype.BeginVersion = 0;
                                    cmtype.EndVersion = 0;
                                    cmtype.SoftwareName = "0";
                                    cmtype.InstallName = "0";
                                    cmmanager.Add(cmtype);
                                }
                            }
                        }




                        //当添加成功时，给他的URL确定
                        CM_Main cm = cmMain.GetMain(i);
                        if (rblMsgType.SelectedValue == "0")
                        {
                            cm.ContentURL = ConfigurationManager.AppSettings["WebURL"] + "/html/CM_Main/" + rblMsgLevel.SelectedValue + "/" + DateTime.Now.Year.ToString() + "/Msg_" + i + ".html";
                        }
                        //将ID放到ViewState中（为了下面的使用）
                        ViewState["ID"] = i.ToString();
                        //将URL修改进数据库
                        cmMain.Update(cm);
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "新增软件消息[" + mains.Title + "].");

                    }
                    else
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "添加软件消息[" + mains.Title + "]失败。");
                        Response.Write("<script>alert('添加失败');</script>");
                    }
                }
                //生成HTML静态页面
                //先判断是否选择HTML
                if (rblMsgType.SelectedValue == "0")
                {
                    //模版路径
                    string MB = "";

                    if (rblMsgLevel.SelectedValue == "1" || rblMsgLevel.SelectedValue == "2")
                    {
                        //确定选择的模版
                        if (Rdbtn1.SelectedValue == "2" || Rdbtn1.SelectedValue == "3")
                        {
                            MB = "~/Template/CM_mainTemplate/CM_mainTemplate2011_3.aspx?id=" + ViewState["ID"];
                        }
                        else
                        {
                            MB = "~/Template/CM_mainTemplate/CM_mainTemplate2011_6.aspx?id=" + ViewState["ID"];
                        }
                    }
                    else if (rblMsgLevel.SelectedValue == "3")
                    {
                        //确定选择的模版
                        if (Rdbtn1.SelectedValue == "0")
                        {
                            MB = "~/Template/CM_mainTemplate/CM_mainTemplate2011_1.aspx?id=" + ViewState["ID"];
                        }
                        else if (Rdbtn1.SelectedValue == "1")
                        {
                            MB = "~/Template/CM_mainTemplate/CM_mainTemplate2011_2.aspx?id=" + ViewState["ID"];
                        }
                        else
                        {
                            MB = "~/Template/CM_mainTemplate/CM_mainTemplate2011_5.aspx?id=" + ViewState["ID"];
                        }
                    }
                    else if (rblMsgLevel.SelectedValue == "4")
                    {
                        MB = "~/Template/CM_mainTemplate/CM_mainTemplate2011_4.aspx?id=" + ViewState["ID"];
                    }

                    //必须不为空时，进行静态化
                    if (ViewState["ID"] != null)
                    {
                        try
                        {
                            //找年份文件夹
                            if (!DirectoryFile.IsCreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue)))
                            {
                                //不存在创建文件夹
                                DirectoryFile.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue));
                            }
                            //找类型文件夹！(不同类型的消息放到不同的文件夹下！)
                            if (!DirectoryFile.IsCreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue + "/" + DateTime.Now.Year.ToString())))
                            {
                                //不存在创建文件夹
                                DirectoryFile.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue + "/" + DateTime.Now.Year.ToString()));
                            }

                            //静态化
                            //新建文件
                            DirectoryFile.CreateFile(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue + "/" + DateTime.Now.Year.ToString() + "/Msg_" + ViewState["ID"] + ".html"));

                            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue + "/" + DateTime.Now.Year.ToString() + "/Msg_" + ViewState["ID"] + ".html"), false, System.Text.Encoding.GetEncoding("gb2312")))
                            {
                                //将aspx文件静态化到 html
                                System.Web.HttpContext.Current.Server.Execute(MB, sw, true);
                                sw.Close();
                            }

                        }
                        catch
                        {
                            Response.Write("<script>alert('数据静态化错误！');</script>");
                        }
                    }

                }
            }
            //消息添加成功返回到列表页
            Response.Redirect("SoftMessage_Manage_2011.aspx");
        }

        /// <summary>
        /// 一级列表改变索引，自动引发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSoftwareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInstall();
        }

        /// <summary>
        /// 绑定二级下拉框
        /// </summary>
        private void BindInstall()
        {
            this.ddlInstallType.Items.Clear();
            string sqlInstall = "select InstallType, InstallName  from dbo.CstSoftware where SoftwareName='" + this.ddlSoftwareType.SelectedItem.Text + "' order by CstID ";
            DataTable ds = softwar.GetLisBySql(sqlInstall);

            ddlInstallType.DataTextField = "InstallName";
            ddlInstallType.DataValueField = "InstallType";


            ddlInstallType.DataSource = ds;
            ddlInstallType.DataBind();
            ListItem lt = new ListItem();
            lt.Text = "所有";
            lt.Value = "0";
            lt.Selected = true;
            ddlInstallType.Items.Add(lt);
        }
        /// <summary>
        /// 点击回到列表页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_Manage_2011.aspx");
        }
        /// <summary>
        /// 添加软件限定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            //格式判断
            if (txtMsgPV.Text == "")
            {
                txtMsgPV.Text = "0";

            }
            if (txtMsgPV2.Text == "")
            {
                txtMsgPV2.Text = "0";
            }
            if (txtMsgPV.Text != "" && txtMsgPV2.Text != "")
            {
                if (txtMsgPV.Text != "0" || txtMsgPV2.Text != "0")
                {

                    if (Convert.ToInt32(txtMsgPV.Text) > Convert.ToInt32(txtMsgPV2.Text))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('开始版本不能比结束版本低');", true);
                        return;
                    }

                    //if (txtMsgPV.Text.Split('.').Length != 3 || txtMsgPV2.Text.Split('.').Length != 3)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('版本格式不对，如：1.1.1');", true);
                    //    return;
                    //}
                    ////前后版本判断
                    //if (Convert.ToInt32(txtMsgPV.Text.Replace('.', '0')) > Convert.ToInt32(txtMsgPV2.Text.Replace('.', '0')))
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('开始版本不能比结束版本大，');", true);
                    //    return;
                    //}
                    //if (txtMsgPV.Text.Split('.')[1].Length > 1 || txtMsgPV.Text.Split('.')[2].Length > 1)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('开始版本后二位数不能超过10');", true);
                    //    return;
                    //}
                    //if (txtMsgPV2.Text.Split('.')[1].Length > 1 || txtMsgPV2.Text.Split('.')[2].Length > 1)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('结束版本后二位数不能超过10');", true);
                    //    return;
                    //}
                }
            }



            //当存在不限定的软件时，先将文本清空！
            if (Lists.Items.Count > 0)
            {
                if (Lists.Items[0].Text.Trim() == "不限定")
                {
                    Lists.Items.Clear();
                }
            }



            //定义一个版本字符串
            string vinso = "";
            //当文本里面为 所有 和空时给他默认值

            if ((txtMsgPV.Text.Trim() == "0" || txtMsgPV.Text.Trim() == "") && (txtMsgPV2.Text.Trim() == "0" || txtMsgPV2.Text.Trim() == "") || ddlSoftwareType.SelectedValue == "0")
            {
                vinso = "0,0|";
            }
            else
            {

                if (txtMsgPV.Text.Trim() != "" && txtMsgPV2.Text.Trim() != "")
                {
                    if (txtMsgPV.Text.Trim() == "0.0.0" || txtMsgPV2.Text.Trim() == "0.0.0")
                    {
                        vinso = "0,0|";
                    }
                    else
                    {
                        vinso = txtMsgPV.Text.Trim() + "," + txtMsgPV2.Text.Trim() + "|";
                    }
                }
                else
                {
                    if (txtMsgPV.Text.Trim() == "" && txtMsgPV2.Text.Trim() != "")
                    {
                        vinso = "0," + txtMsgPV2.Text.Trim() + "|";
                    }
                    else if (txtMsgPV.Text.Trim() != "" && txtMsgPV2.Text.Trim() == "")
                    {
                        vinso = txtMsgPV.Text.Trim() + ",0|";
                    }
                    else
                    {
                        vinso = "0,0|";
                    }
                }

            }

            //---------------------------------------------------------------------------------------------------
            int bs = 0;  //标识
            List<ListItem> list = new List<ListItem>(); ;
            //循环遍历软件选择的项
            for (int nb = 0; nb < Lists.Items.Count; nb++)
            {
                ListItem itmse = Lists.Items[nb]; //得到单个对象
                string[] rj1 = itmse.Value.Split(','); //分割第一个
                string[] rj2 = itmse.Text.Split(':'); //分割第二个
                //判断选择的软件ID 和遍历的软件ID是否相等
                if (rj1[0] == ddlSoftwareType.SelectedValue.Split('_')[0])
                {
                    if (ddlInstallType.SelectedValue == "0")
                    {
                        list.Add(itmse);
                    }
                    else if (rj1[1] == ddlInstallType.SelectedValue)
                    {
                        bs = 1;
                        Lists.Items[nb].Text = rj2[0] + ":" + rj2[1] + ":" + vinso.Substring(0, vinso.Length - 1);
                        Lists.Items[nb].Value = rj1[0] + "," + rj1[1] + "," + vinso;
                    }
                    else if (rj1[1] == "0")
                    {
                        bs = 1;
                    }
                }
            }
            if (list.Count > 0)
            {

                foreach (ListItem var in list)
                {
                    Lists.Items.Remove(var);
                }
            }

            //当他为0时，则可知没有进修改的判断
            if (bs == 0)
            {
                if (ddlInstallType.SelectedItem.Text == "所有")
                {
                    foreach (ListItem var in ddlInstallType.Items)
                    {
                        if (var.Text != "所有")
                        {
                            //给他的显示值和键赋值
                            var.Text = ddlSoftwareType.SelectedItem.Text + ":" + var.Text + ":" + vinso.Substring(0, vinso.Length - 1);

                            var.Value = (Convert.ToInt32(ddlSoftwareType.SelectedValue.Split('_')[0]) + "," + Convert.ToInt32(var.Value)) + "," + vinso;

                            //将此项添加到lists中
                            Lists.Items.Add(var);
                        }
                    }
                }
                else
                {
                    ListItem it = new ListItem();
                    //给他的显示值和键赋值
                    it.Text = ddlSoftwareType.SelectedItem.Text + ":" + ddlInstallType.SelectedItem.Text + ":" + vinso.Substring(0, vinso.Length - 1);

                    it.Value = (Convert.ToInt32(ddlSoftwareType.SelectedValue.Split('_')[0]) + "," + Convert.ToInt32(ddlInstallType.SelectedValue)) + "," + vinso;

                    //将此项添加到lists中
                    Lists.Items.Add(it);
                }
            }
            bs = 0;
            BindInstall();
        }

        /// <summary>
        /// 在更改选定项激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Lists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lists.SelectedItem.Text != "不限定")
            {
                //得到选择的显示数据
                string rjsoft1 = Lists.SelectedValue;
                string[] bid1 = rjsoft1.Split(',');
                ddlSoftwareType.SelectedValue = bid1[0] + "_" + Lists.SelectedItem.Text.Split(':')[0];
                //重新绑定第二个下拉框的数据
                BindInstall();
                ddlInstallType.SelectedValue = bid1[1];
                txtMsgPV.Text = bid1[2];
                txtMsgPV2.Text = bid1[3].Substring(0, bid1[3].Length - 1);
            }
        }
        /// <summary>
        /// 移除选中的一项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkBtnrem_Click(object sender, EventArgs e)
        {
            if (Lists.SelectedValue != "")
            {
                ListItem it = new ListItem();
                it.Text = Lists.SelectedItem.Text;
                it.Value = Lists.SelectedValue;
                Lists.Items.Remove(it);
            }
        }
        /// <summary>
        /// 点击不限定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Lists.Items.Clear();
            ListItem it = new ListItem();
            it.Text = "不限定";
            it.Value = "0,0,0,0|";
            Lists.Items.Add(it);
        }
        /// <summary>
        /// 在更改选得项时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rblMsgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblMsgType.SelectedItem.Value == "1")
            {
                divcontent.Visible = false;
                txturl.Visible = true;
                Divurl.Visible = true;
                lblcontent.Text = "url地址";
                txttitleUrl.Enabled = false;
            }
            else
            {
                divcontent.Visible = true;
                txturl.Visible = false;
                Divurl.Visible = false;
                lblcontent.Text = "消息内容";

                if (rblMsgLevel.SelectedValue == "3")
                {
                    txttitleUrl.Enabled = true;
                }
            }
        }
        /// <summary>
        /// 点击预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string content = "";
            if (rblMsgLevel.SelectedValue == "1" || rblMsgLevel.SelectedValue == "2" || rblMsgLevel.SelectedValue == "4")
            {
                content = txtMsgContent.Value;
            }
            else if (rblMsgLevel.SelectedValue == "3")
            {
                content = txtMsgContent1.Text;
            }

            if (txtMsgTitle.Text != "" && content != "")
            {
                string MB = "1";
                string height = "600";
                string width = "600";
                //确定选择的模版
                if (Rdbtn1.SelectedValue == "0")
                {
                    MB = "1";
                    height = "150";
                    width = "300";
                }
                else if (Rdbtn1.SelectedValue == "1")
                {
                    MB = "2";
                    height = "150";
                    width = "300";
                }
                else if (Rdbtn1.SelectedValue == "2")
                {
                    MB = "3";
                    height = "400";
                    width = "650";
                }
                else if (Rdbtn1.SelectedValue == "3")
                {
                    MB = "3";
                    height = "400";
                    width = "650";
                }
                else if (Rdbtn1.SelectedValue == "4")
                {
                    MB = "4";
                    height = "400";
                    width = "650";
                }
                else if (Rdbtn1.SelectedValue == "5")
                {
                    MB = "5";
                    height = "200";
                    width = "350";
                }
                else if (Rdbtn1.SelectedValue == "6")
                {
                    MB = "6";
                    height = "234";
                    width = "550";
                }

                Response.Write("<script>window.open('../../Template/CM_mainTemplate/CM_mainTemplate2011_" + MB + ".aspx?title=" + Server.UrlEncode(QueryStrings(txtMsgTitle.Text)) + "&content=" + Server.UrlEncode(QueryStrings(content)) + "&titleurl=" + txttitleUrl.Text + "','newwindow', 'height=" + height + ", width=" + width + ", top=100, left=150, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no');</script>");
            }
            else
            {
                Response.Write("<script>alert('必须填写标题和内容后才能预览！');</script>");
            }
        }
        /// <summary>
        /// 特殊符号转换
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string QueryStrings(string str)
        {
            string str2 = str.Replace('\'', '’').Replace("<", "<").Replace(">", ">");
            return str2;
        }

        /// <summary>
        /// 消息等级控制他选择哪个模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rblMsgLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当为添加时
            if (Request.QueryString["ID"] == null)
            {
                //并且为网页消息时
                if (rblMsgLevel.SelectedValue == "3")
                {
                    txtPostTime1.Text = DateTime.Now.ToString();
                    txtPostTime2.Text = DateTime.Now.AddHours(3).ToString();
                }
                else
                {
                    txtPostTime1.Text = DateTime.Now.ToString();
                    txtPostTime2.Text = DateTime.Now.AddDays(3).ToString();
                }
            }
            MB();
        }
        /// <summary>
        /// 绑定模板显示方法
        /// </summary>
        private void MB()
        {
            Rdbtn1.Items.Clear();
            if (rblMsgLevel.Items.Count >= 1)
            {

                ListItem item = new ListItem();
                if (rblMsgLevel.SelectedValue == "1")
                {
                    item.Value = "2";
                    item.Text = "模版一(650*343)";
                    item.Selected = true;
                    ListItem item1 = new ListItem();
                    item1.Text = "模版二(550*243)";
                    item1.Value = "6";


                    Rdbtn1.Items.Add(item);
                    Rdbtn1.Items.Add(item1);
                    txtMsgContent.Visible = true;
                    txtMsgContent1.Visible = false;
                    txttitleUrl.Enabled = false;
                }
                else if (rblMsgLevel.SelectedValue == "2")
                {
                    item.Value = "2";
                    item.Text = "模版一(650*343)";
                    item.Selected = true;
                    ListItem item1 = new ListItem();
                    item1.Text = "模版二(550*243)";
                    item1.Value = "6";

                    Rdbtn1.Items.Add(item);
                    Rdbtn1.Items.Add(item1);
                    txtMsgContent.Visible = true;
                    txtMsgContent1.Visible = false;
                    txttitleUrl.Enabled = false;
                }
                else if (rblMsgLevel.SelectedValue == "3")
                {
                    item.Value = "0";
                    item.Text = "模版一(266*118)";
                    item.Selected = true;
                    ListItem item1 = new ListItem();
                    item1.Text = "模版二(300*150)";
                    item1.Value = "1";

                    ListItem item2 = new ListItem();
                    item2.Text = "模版三(350*200)";
                    item2.Value = "5";
                    Rdbtn1.Items.Add(item);
                    Rdbtn1.Items.Add(item1);
                    Rdbtn1.Items.Add(item2);
                    txtMsgContent.Visible = false;
                    txtMsgContent1.Visible = true;
                    if (rblMsgType.SelectedValue == "0")
                    {
                        txttitleUrl.Enabled = true;
                    }
                }
                else if (rblMsgLevel.SelectedValue == "4")
                {
                    item.Value = "4";
                    item.Text = "模版一(650*343)";
                    item.Selected = true;
                    Rdbtn1.Items.Add(item);
                    txtMsgContent.Visible = true;
                    txtMsgContent1.Visible = false;
                    txttitleUrl.Enabled = false;
                }
            }
        }
        /// <summary>
        /// 改变消息类型时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlMsgCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindddlMsgCategory2();
        }
        /// <summary>
        /// 更改用户注册限定后激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void checkBoxreg_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayCheckBoxUser();
        }

        /// <summary>
        /// 注册限定复选框条件判断
        /// </summary>
        private void DisplayCheckBoxUser()
        {
            //遍历所有的注册复选框
            for (int i = 0; i < checkBoxreg.Items.Count; i++)
            {
                //当存在选中的时候
                if (checkBoxreg.Items[i].Selected)
                {
                    //当不限定存在时
                    if (checkBoxreg.Items[i].Value == "0")
                    {
                        //将所有的复选框选中的去掉，并禁用
                        for (int f = 0; f < checkBoxreg.Items.Count; f++)
                        {
                            checkBoxreg.Items[f].Selected = false;
                            checkBoxreg.Items[f].Enabled = false;
                        }
                        //将所有的用户复选框去掉，
                        for (int j = 0; j < CheckBoxUser.Items.Count; j++)
                        {
                            CheckBoxUser.Items[j].Selected = false;
                        }
                        //并全部禁用
                        CheckBoxUser.Enabled = false;
                        //将当前的选中
                        checkBoxreg.Items[i].Selected = true;
                        checkBoxreg.Items[i].Enabled = true;
                        //退出循环
                        return;
                    }


                    if (checkBoxreg.Items[i].Value == "8")
                    {
                        CheckBoxUser.Enabled = true;
                        for (int v = 0; v < CheckBoxUser.Items.Count; v++)
                        {
                            CheckBoxUser.Items[v].Enabled = true;
                        }
                        return;
                    }
                }

                checkBoxreg.Items[i].Enabled = true;

            }
            checkBoxreg.Items[0].Selected = false;
            CheckBoxUser.Enabled = false;

            for (int i = 0; i < CheckBoxUser.Items.Count; i++)
            {
                CheckBoxUser.Items[i].Selected = false;
            }
        }
        /// <summary>
        /// 用户限定复选框条件判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < CheckBoxUser.Items.Count; i++)
            {
                //当有选中的时才判断
                if (CheckBoxUser.Items[i].Selected)
                {
                    if (CheckBoxUser.Items[i].Value == "0")
                    {
                        //将全部的选择框设为false
                        for (int j = 0; j < CheckBoxUser.Items.Count; j++)
                        {
                            CheckBoxUser.Items[j].Selected = false;
                            CheckBoxUser.Items[j].Enabled = false;
                        }
                        //将value为0的选中
                        CheckBoxUser.Items[i].Selected = true;
                        CheckBoxUser.Items[i].Enabled = true;

                        return;
                    }
                }
                CheckBoxUser.Items[i].Enabled = true;
            }
        }

    }
}
