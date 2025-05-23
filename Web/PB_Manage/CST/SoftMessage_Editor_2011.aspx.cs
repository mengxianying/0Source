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

                //�õ���ǰʱ��
                txtPostTime1.Text = DateTime.Now.ToString();
                txtPostTime2.Text = DateTime.Now.AddDays(3).ToString();

                Pbzx.Model.CM_Main cmain = null;

                //�������Ϣ������
                BindDropdownList();

                //ע��������Ϣ�б��ֶ���
                RegType();

                //�û��޶����Ͱ�
                UserType();

                //��Ϣ�ȼ���
                MsgType();
                //��Ϣ���
                BindddlMsgCategory1();

                string str = Request.QueryString["ID"];

                //�ж�str�Ƿ����
                if (str != null && OperateText.IsNumber(str))
                {
                    cmain = cmmage.GetMain(int.Parse(str));



                    txtusername.Text = cmain.UserName.Replace("(|", "\r\n");
                    txtRzm.Text = cmain.HDSN.Replace("(|", "\r\n");
                    //    BindInstall();
                    if (cmain != null)
                    {
                        //�������Ϣ��ԭ��ѡ����Ϣ����ҳ���������㣩
                        DataSet dst = cmmanager.GetList("CMID='" + cmain.Id + "'");

                        if (dst != null && dst.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
                            {

                                if (dst.Tables[0].Rows[i][2].ToString() == "0")
                                {
                                    ListItem it = new ListItem();
                                    it.Text = "���޶�";
                                    it.Value = "0,0,0,0|";
                                    Lists.Items.Add(it);
                                }
                                else
                                {
                                    //�½�һ��listItem����
                                    ListItem it = new ListItem();
                                    //��16���Ƶ����ID ת������ȷ�� ID��Ϣ
                                    //�õ����id
                                    int zqid1 = Convert.ToInt32(dst.Tables[0].Rows[i][2]) / 16;
                                    //�õ����ID�������ID
                                    int zqid2 = Convert.ToInt32(dst.Tables[0].Rows[i][2]) % 16;
                                    //�õ��汾�ŵļ����Ϣ
                                    string vis = dst.Tables[0].Rows[i][3] + "," + dst.Tables[0].Rows[i][4];

                                    it.Text = dst.Tables[0].Rows[i][5] + ":" + dst.Tables[0].Rows[i][6] + ":" + vis;
                                    it.Value = zqid1 + "," + zqid2 + "," + vis + "|";
                                    Lists.Items.Add(it);
                                }
                            }
                        }

                        //���ж��Ƿ����޶���Ϣ�������������������û��Ҫ����
                        //if (cmain.SoftInfo.Trim() != "")
                        //{
                        //    string[] rjhy = cmain.SoftInfo.Split('|'); //������ |�ָ��������ʽ

                        //    //�����˷ָ�������б�
                        //    for (int i = 0; i < rjhy.Length - 1; i++)
                        //    {
                        //        //������Ϣ�ٷָ������
                        //        string[] rjmx = rjhy[i].Split(',');

                        //        //�õ�16���Ƶ����ID
                        //        int rjid = Convert.ToInt32(rjmx[0]);

                        //        //��16���Ƶ����ID ת������ȷ�� ID��Ϣ
                        //        //�õ����id
                        //        int zqid1 = rjid / 16;
                        //        //�õ����ID�������ID
                        //        int zqid2 = rjid % 16;
                        //        //�õ��汾�ŵļ����Ϣ
                        //        string vis = rjmx[1] + "," + rjmx[2];

                        //        //�½�һ��listItem����
                        //        ListItem it = new ListItem();



                        //        if (zqid1 != 0)
                        //        {
                        //            //��������ʾֵ�ͼ���ֵ
                        //            //  it.Text = ddlSoftwareType.Items.FindByValue(zqid1.ToString()).Text + ":" + ddlInstallType.Items.FindByValue(zqid2.ToString()).Text + ":" + vis;
                        //            if (rjmx.Length > 4)
                        //            {
                        //                it.Text = rjmx[3] + ":" + rjmx[4] + ":" + vis;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            it.Text = "���޶�";
                        //        }
                        //        it.Value = zqid1 + "," + zqid2 + "," + vis + "|";

                        //        //��������ӵ�lists��
                        //        Lists.Items.Add(it);
                        //    }

                        //}

                        //�õ�ע������
                        string[] regtype = cmain.RegType.Split('|');
                        //��ע������������ʱ�Ÿ���ѡ��
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

                        //�õ��û��޶���Ϣ
                        string[] usety = cmain.UserClass.Split('|');

                        //�ж��û��޶���Ϣ�Ƿ����
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

                        //�õ���Ϣ������
                        int lx = cmain.Mtype;
                        //�жϣ���������
                        if (lx >= 0)
                        {
                            rblMsgLevel.Items.FindByValue(lx.ToString()).Selected = true;
                        }
                        //�Ƿ������û��޶�
                        DisplayCheckBoxUser();
                        //����ʱ��
                        txtMsgTime.Text = cmain.PostTime.ToString();

                        //������
                        string sendername = cmain.Sender;
                        if (sendername != "")
                        {
                            ListItem lst = rblMsgSender.Items.FindByText(sendername);
                            if (lst != null)
                            {

                                lst.Selected = true;
                            }

                        }
                        //�Ƿ񷢲�
                        rblMsgSend.SelectedValue = cmain.State.ToString();

                        //�����⸳ֵ
                        txtMsgTitle.Text = cmain.Title;

                        //��Ϣ����
                        string contentLr = cmain.Content;
                        //������Ϊ��ʱ�����ж�����URL����
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

                        //���������Ӹ�ֵ
                        txttitleUrl.Text = cmain.Linkurl;
                        //��Ϣ���
                        string[] lex = cmain.Category.Split('#');
                        if (lex.Length > 0)
                        {
                            ddlMsgCategory1.SelectedValue = lex[0];
                            ddlMsgCategory2.SelectedValue = lex[1];

                        }
                        //ʱ��
                        //��ʼʱ��
                        txtPostTime1.Text = cmain.BeginTime.ToString();
                        //����ʱ��
                        txtPostTime2.Text = cmain.EndTime.ToString();

                        //����״̬
                        int zt = cmain.State;
                        if (zt == 0)
                        {
                            rblMsgSend.Items[1].Selected = true;
                        }
                        else
                        {
                            rblMsgSend.Items[0].Selected = true;
                        }

                        //�߶ȺͿ��
                        txtwidth.Text = cmain.WebWidth.ToString();
                        txtheight.Text = cmain.WebHeight.ToString();
                        //���ʴ���
                        lblToday.Text = cmain.TodayCount.ToString();
                        lblTotal.Text = cmain.TotalCount.ToString();

                    }

                }
                else
                {
                    rblMsgLevel.Items[0].Selected = true;
                    rblMsgType.Items[0].Selected = true;
                }

                //ģ����ʾ��
                MB();
                if (cmain != null)
                {
                    //ģ��ѡ�а�
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
        /// ��Ϣ�ȼ��󶨷���
        /// </summary>
        private void MsgType()
        {
            XmlDataSource msgdata = new XmlDataSource();
            msgdata.DataFile = "~/xml/Msg_Private.xml";
            rblMsgLevel.DataSource = msgdata;
            rblMsgLevel.DataBind();
        }
        /// <summary>
        /// �û����Ͱ󶨷���
        /// </summary>
        private void UserType()
        {
            XmlDataSource userdata = new XmlDataSource();
            userdata.DataFile = "~/xml/Msg_UserClass.xml";
            CheckBoxUser.DataSource = userdata;
            CheckBoxUser.DataBind();
        }
        /// <summary>
        /// ע�������ֶ��󶨷���
        /// </summary>
        private void RegType()
        {
            XmlDataSource regdata = new XmlDataSource();
            regdata.DataFile = "~/xml/Msg_RegType.xml";
            checkBoxreg.DataSource = regdata;
            checkBoxreg.DataBind();
        }
        //<summary>
        //DropDownList���ݰ�
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
        /// ����Ϣ���(1)
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
        /// ����Ϣ���(2)
        /// </summary>
        private void BindddlMsgCategory2()
        {
            ddlMsgCategory2.Items.Clear();
            XmlDocument dom = new XmlDocument();
            dom.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/Msg_SortTwo.xml"));//װ��XML�ĵ� 
            XmlElement root = dom.DocumentElement;
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                XmlNode haha = root.SelectNodes("reg")[i];
                //�õ�����ID
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
        /// �������(���ɾ�̬ҳ��)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string strErrMsg = "";
            //if (txtMsgPV.Text.Trim() == "")
            //{
            //    strErrMsg += "�汾����Ϊ��.\\r\\n";
            //}
            DateTime dtTemp = new DateTime();
            if (!DateTime.TryParse(this.txtMsgTime.Text, out dtTemp))
            {
                strErrMsg += "����ʱ��δ��������ݸ�ʽ����ȷ.\\r\\n";
            }
            if (txtMsgTitle.Text.Trim() == "")
            {
                strErrMsg += "��Ϣ���ⲻ��Ϊ��.\\r\\n";
            }
            if (rblMsgLevel.SelectedValue == "1" || rblMsgLevel.SelectedValue == "2" || rblMsgLevel.SelectedValue == "4")
            {
                if (rblMsgType.SelectedItem.Value == "0" && txtMsgContent.Value.Trim() == "")
                {
                    strErrMsg += "��Ϣ���ݲ���Ϊ��.\\r\\n";
                }
            }

            else if (rblMsgLevel.SelectedValue == "3")
            {
                if (rblMsgType.SelectedItem.Value == "0" && txtMsgContent1.Text.Trim() == "")
                {
                    strErrMsg += "��Ϣ���ݲ���Ϊ��.\\r\\n";
                }
            }

            if (!DateTime.TryParse(this.txtPostTime1.Text, out dtTemp) || !DateTime.TryParse(this.txtPostTime2.Text, out dtTemp))
            {
                strErrMsg += "ʱ�����ݸ�ʽ����ȷ.\\r\\n";
            }
            if (rblMsgType.SelectedValue != "0")
            {
                if (txturl.Text.Trim() == "")
                {
                    strErrMsg += "url��ַ����Ϊ��.\\r\\n";
                }
                int width = 0, height = 0;
                if (!int.TryParse(txtwidth.Text, out width) || !int.TryParse(txtheight.Text, out height))
                {
                    strErrMsg += "����ȷ��д��Ⱥ͸߶ȣ�����Ϊ����.\\r\\n";
                }
                if (width <= 0 || height <= 0)
                {
                    strErrMsg += "�뽫��Ⱥ͸߶ȸ�Ϊ����0������.\\r\\n";
                }

            }
            if (strErrMsg == "")
            {
                if (Convert.ToDateTime(this.txtPostTime1.Text) >= Convert.ToDateTime(this.txtPostTime2.Text))
                {
                    strErrMsg += "ʱ�޿�ʼʱ�䲻�ܵ��ڻ���ڽ���ʱ��.\\r\\n";
                }
            }
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�������Ϣ��Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {

                //�½�һ��ʵ�����
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
                //--��ҳ����ֶ��е�ֵ��װ�������С�
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

                //------------------------------------------------------------����޶���Ϣ
                //string softwt = null; //����һ���������������Ϣ
                //for (int i = 0; i < Lists.Items.Count; i++)
                //{
                //    ListItem lt = Lists.Items[i];
                //    string[] zu = lt.Value.Split(',');
                //    if (zu.Length >= 4)
                //    {
                //        if (lt.Text != "���޶�")
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
                //    mains.SoftInfo = "0,0,0|"; //�������޶�

                //}











                //-----------------------------------------------------------ע���޶���Ϣ
                string regstring = null;  //����һ�����������ע���޶���Ϣ
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

                //----------------------------------------------------------�û��޶���Ϣ
                string userstring = null;  //����һ������������û��޶���Ϣ

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

                //����������������������������������������������������������������������������
                mains.Sender = rblMsgSender.SelectedItem.Text;

                //-------------------------------------------------------------��Ϣ���ͣ�1��ͨ��Ϣ��2.������Ϣ3.��ҳ��Ϣ.4.������ѯ��
                int mtint = 1; //Ĭ��Ϊ��ͨ��Ϣ
                for (int z = 0; z < rblMsgLevel.Items.Count; z++)
                {
                    if (rblMsgLevel.Items[z].Selected)
                    {
                        mtint = int.Parse(rblMsgLevel.Items[z].Value);
                    }
                }
                mains.Mtype = mtint;
                //-------------------------------------------------------------------------���

                mains.Category = ddlMsgCategory1.SelectedItem.Text + "#" + ddlMsgCategory2.SelectedItem.Text;

                //--------------------------------------------------------------------״̬ 0.δ������1�ѷ���
                mains.State = Convert.ToInt32(rblMsgSend.SelectedValue);

                ////����ʱ��
                mains.PostTime = DateTime.Parse(txtMsgTime.Text);

                //��ʼʱ��
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

                //����ʱ��
                mains.EndTime = DateTime.Parse(txtPostTime2.Text);


                //����
                mains.Title = txtMsgTitle.Text;

                //���ݾ�̬ҳURL��ַ���� http:��ͷ��
                mains.ContentURL = txturl.Text;
                //��������
                mains.Linkurl = txttitleUrl.Text;
                //������ʱ��
                mains.LastTime = DateTime.Now;

                //���շ��ʴ���
                mains.TodayCount = Convert.ToInt32(lblToday.Text);

                //�ܷ��ʴ���
                mains.TotalCount = Convert.ToInt32(lblTotal.Text);

                //��Ϣ����
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
                    //�߶ȺͿ��
                    //����ģ��1�ĸ߶ȺͿ��
                    if (Rdbtn1.SelectedValue == "0")
                    {
                        mains.WebHeight = 118;
                        mains.WebWidth = 266;
                    }
                    else if (Rdbtn1.SelectedValue == "1")
                    {
                        mains.WebHeight = 150;
                        mains.WebWidth = 300;
                        //����ģ��2�ĸ߶ȺͿ��
                    }
                    else if (Rdbtn1.SelectedValue == "2")
                    {
                        mains.WebHeight = 343;
                        //���15�Ĺ�����
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

                        //���������޶����е�����
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
                                if (lt.Text != "���޶�")
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


                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸������Ϣ[" + mains.Id + ":" + mains.Title + "].");
                    }
                    else
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸������Ϣ[" + mains.Id + ":" + mains.Title + "]���޸�ʧ�ܡ�");
                        Response.Write("<script>alert('�޸�ʧ��');</script>");
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
                                if (lt.Text != "���޶�")
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




                        //����ӳɹ�ʱ��������URLȷ��
                        CM_Main cm = cmMain.GetMain(i);
                        if (rblMsgType.SelectedValue == "0")
                        {
                            cm.ContentURL = ConfigurationManager.AppSettings["WebURL"] + "/html/CM_Main/" + rblMsgLevel.SelectedValue + "/" + DateTime.Now.Year.ToString() + "/Msg_" + i + ".html";
                        }
                        //��ID�ŵ�ViewState�У�Ϊ�������ʹ�ã�
                        ViewState["ID"] = i.ToString();
                        //��URL�޸Ľ����ݿ�
                        cmMain.Update(cm);
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "���������Ϣ[" + mains.Title + "].");

                    }
                    else
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "��������Ϣ[" + mains.Title + "]ʧ�ܡ�");
                        Response.Write("<script>alert('���ʧ��');</script>");
                    }
                }
                //����HTML��̬ҳ��
                //���ж��Ƿ�ѡ��HTML
                if (rblMsgType.SelectedValue == "0")
                {
                    //ģ��·��
                    string MB = "";

                    if (rblMsgLevel.SelectedValue == "1" || rblMsgLevel.SelectedValue == "2")
                    {
                        //ȷ��ѡ���ģ��
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
                        //ȷ��ѡ���ģ��
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

                    //���벻Ϊ��ʱ�����о�̬��
                    if (ViewState["ID"] != null)
                    {
                        try
                        {
                            //������ļ���
                            if (!DirectoryFile.IsCreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue)))
                            {
                                //�����ڴ����ļ���
                                DirectoryFile.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue));
                            }
                            //�������ļ��У�(��ͬ���͵���Ϣ�ŵ���ͬ���ļ����£�)
                            if (!DirectoryFile.IsCreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue + "/" + DateTime.Now.Year.ToString())))
                            {
                                //�����ڴ����ļ���
                                DirectoryFile.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue + "/" + DateTime.Now.Year.ToString()));
                            }

                            //��̬��
                            //�½��ļ�
                            DirectoryFile.CreateFile(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue + "/" + DateTime.Now.Year.ToString() + "/Msg_" + ViewState["ID"] + ".html"));

                            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + rblMsgLevel.SelectedValue + "/" + DateTime.Now.Year.ToString() + "/Msg_" + ViewState["ID"] + ".html"), false, System.Text.Encoding.GetEncoding("gb2312")))
                            {
                                //��aspx�ļ���̬���� html
                                System.Web.HttpContext.Current.Server.Execute(MB, sw, true);
                                sw.Close();
                            }

                        }
                        catch
                        {
                            Response.Write("<script>alert('���ݾ�̬������');</script>");
                        }
                    }

                }
            }
            //��Ϣ��ӳɹ����ص��б�ҳ
            Response.Redirect("SoftMessage_Manage_2011.aspx");
        }

        /// <summary>
        /// һ���б�ı��������Զ������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSoftwareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInstall();
        }

        /// <summary>
        /// �󶨶���������
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
            lt.Text = "����";
            lt.Value = "0";
            lt.Selected = true;
            ddlInstallType.Items.Add(lt);
        }
        /// <summary>
        /// ����ص��б�ҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_Manage_2011.aspx");
        }
        /// <summary>
        /// �������޶�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            //��ʽ�ж�
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
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('��ʼ�汾���ܱȽ����汾��');", true);
                        return;
                    }

                    //if (txtMsgPV.Text.Split('.').Length != 3 || txtMsgPV2.Text.Split('.').Length != 3)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('�汾��ʽ���ԣ��磺1.1.1');", true);
                    //    return;
                    //}
                    ////ǰ��汾�ж�
                    //if (Convert.ToInt32(txtMsgPV.Text.Replace('.', '0')) > Convert.ToInt32(txtMsgPV2.Text.Replace('.', '0')))
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('��ʼ�汾���ܱȽ����汾��');", true);
                    //    return;
                    //}
                    //if (txtMsgPV.Text.Split('.')[1].Length > 1 || txtMsgPV.Text.Split('.')[2].Length > 1)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('��ʼ�汾���λ�����ܳ���10');", true);
                    //    return;
                    //}
                    //if (txtMsgPV2.Text.Split('.')[1].Length > 1 || txtMsgPV2.Text.Split('.')[2].Length > 1)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", "alert('�����汾���λ�����ܳ���10');", true);
                    //    return;
                    //}
                }
            }



            //�����ڲ��޶������ʱ���Ƚ��ı���գ�
            if (Lists.Items.Count > 0)
            {
                if (Lists.Items[0].Text.Trim() == "���޶�")
                {
                    Lists.Items.Clear();
                }
            }



            //����һ���汾�ַ���
            string vinso = "";
            //���ı�����Ϊ ���� �Ϳ�ʱ����Ĭ��ֵ

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
            int bs = 0;  //��ʶ
            List<ListItem> list = new List<ListItem>(); ;
            //ѭ���������ѡ�����
            for (int nb = 0; nb < Lists.Items.Count; nb++)
            {
                ListItem itmse = Lists.Items[nb]; //�õ���������
                string[] rj1 = itmse.Value.Split(','); //�ָ��һ��
                string[] rj2 = itmse.Text.Split(':'); //�ָ�ڶ���
                //�ж�ѡ������ID �ͱ��������ID�Ƿ����
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

            //����Ϊ0ʱ�����֪û�н��޸ĵ��ж�
            if (bs == 0)
            {
                if (ddlInstallType.SelectedItem.Text == "����")
                {
                    foreach (ListItem var in ddlInstallType.Items)
                    {
                        if (var.Text != "����")
                        {
                            //��������ʾֵ�ͼ���ֵ
                            var.Text = ddlSoftwareType.SelectedItem.Text + ":" + var.Text + ":" + vinso.Substring(0, vinso.Length - 1);

                            var.Value = (Convert.ToInt32(ddlSoftwareType.SelectedValue.Split('_')[0]) + "," + Convert.ToInt32(var.Value)) + "," + vinso;

                            //��������ӵ�lists��
                            Lists.Items.Add(var);
                        }
                    }
                }
                else
                {
                    ListItem it = new ListItem();
                    //��������ʾֵ�ͼ���ֵ
                    it.Text = ddlSoftwareType.SelectedItem.Text + ":" + ddlInstallType.SelectedItem.Text + ":" + vinso.Substring(0, vinso.Length - 1);

                    it.Value = (Convert.ToInt32(ddlSoftwareType.SelectedValue.Split('_')[0]) + "," + Convert.ToInt32(ddlInstallType.SelectedValue)) + "," + vinso;

                    //��������ӵ�lists��
                    Lists.Items.Add(it);
                }
            }
            bs = 0;
            BindInstall();
        }

        /// <summary>
        /// �ڸ���ѡ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Lists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lists.SelectedItem.Text != "���޶�")
            {
                //�õ�ѡ�����ʾ����
                string rjsoft1 = Lists.SelectedValue;
                string[] bid1 = rjsoft1.Split(',');
                ddlSoftwareType.SelectedValue = bid1[0] + "_" + Lists.SelectedItem.Text.Split(':')[0];
                //���°󶨵ڶ��������������
                BindInstall();
                ddlInstallType.SelectedValue = bid1[1];
                txtMsgPV.Text = bid1[2];
                txtMsgPV2.Text = bid1[3].Substring(0, bid1[3].Length - 1);
            }
        }
        /// <summary>
        /// �Ƴ�ѡ�е�һ��
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
        /// ������޶�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Lists.Items.Clear();
            ListItem it = new ListItem();
            it.Text = "���޶�";
            it.Value = "0,0,0,0|";
            Lists.Items.Add(it);
        }
        /// <summary>
        /// �ڸ���ѡ����ʱ
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
                lblcontent.Text = "url��ַ";
                txttitleUrl.Enabled = false;
            }
            else
            {
                divcontent.Visible = true;
                txturl.Visible = false;
                Divurl.Visible = false;
                lblcontent.Text = "��Ϣ����";

                if (rblMsgLevel.SelectedValue == "3")
                {
                    txttitleUrl.Enabled = true;
                }
            }
        }
        /// <summary>
        /// ���Ԥ��
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
                //ȷ��ѡ���ģ��
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
                Response.Write("<script>alert('������д��������ݺ����Ԥ����');</script>");
            }
        }
        /// <summary>
        /// �������ת��
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string QueryStrings(string str)
        {
            string str2 = str.Replace('\'', '��').Replace("<", "<").Replace(">", ">");
            return str2;
        }

        /// <summary>
        /// ��Ϣ�ȼ�������ѡ���ĸ�ģ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rblMsgLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //��Ϊ���ʱ
            if (Request.QueryString["ID"] == null)
            {
                //����Ϊ��ҳ��Ϣʱ
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
        /// ��ģ����ʾ����
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
                    item.Text = "ģ��һ(650*343)";
                    item.Selected = true;
                    ListItem item1 = new ListItem();
                    item1.Text = "ģ���(550*243)";
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
                    item.Text = "ģ��һ(650*343)";
                    item.Selected = true;
                    ListItem item1 = new ListItem();
                    item1.Text = "ģ���(550*243)";
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
                    item.Text = "ģ��һ(266*118)";
                    item.Selected = true;
                    ListItem item1 = new ListItem();
                    item1.Text = "ģ���(300*150)";
                    item1.Value = "1";

                    ListItem item2 = new ListItem();
                    item2.Text = "ģ����(350*200)";
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
                    item.Text = "ģ��һ(650*343)";
                    item.Selected = true;
                    Rdbtn1.Items.Add(item);
                    txtMsgContent.Visible = true;
                    txtMsgContent1.Visible = false;
                    txttitleUrl.Enabled = false;
                }
            }
        }
        /// <summary>
        /// �ı���Ϣ����ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlMsgCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindddlMsgCategory2();
        }
        /// <summary>
        /// �����û�ע���޶��󼤷�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void checkBoxreg_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayCheckBoxUser();
        }

        /// <summary>
        /// ע���޶���ѡ�������ж�
        /// </summary>
        private void DisplayCheckBoxUser()
        {
            //�������е�ע�Ḵѡ��
            for (int i = 0; i < checkBoxreg.Items.Count; i++)
            {
                //������ѡ�е�ʱ��
                if (checkBoxreg.Items[i].Selected)
                {
                    //�����޶�����ʱ
                    if (checkBoxreg.Items[i].Value == "0")
                    {
                        //�����еĸ�ѡ��ѡ�е�ȥ����������
                        for (int f = 0; f < checkBoxreg.Items.Count; f++)
                        {
                            checkBoxreg.Items[f].Selected = false;
                            checkBoxreg.Items[f].Enabled = false;
                        }
                        //�����е��û���ѡ��ȥ����
                        for (int j = 0; j < CheckBoxUser.Items.Count; j++)
                        {
                            CheckBoxUser.Items[j].Selected = false;
                        }
                        //��ȫ������
                        CheckBoxUser.Enabled = false;
                        //����ǰ��ѡ��
                        checkBoxreg.Items[i].Selected = true;
                        checkBoxreg.Items[i].Enabled = true;
                        //�˳�ѭ��
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
        /// �û��޶���ѡ�������ж�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < CheckBoxUser.Items.Count; i++)
            {
                //����ѡ�е�ʱ���ж�
                if (CheckBoxUser.Items[i].Selected)
                {
                    if (CheckBoxUser.Items[i].Value == "0")
                    {
                        //��ȫ����ѡ�����Ϊfalse
                        for (int j = 0; j < CheckBoxUser.Items.Count; j++)
                        {
                            CheckBoxUser.Items[j].Selected = false;
                            CheckBoxUser.Items[j].Enabled = false;
                        }
                        //��valueΪ0��ѡ��
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
