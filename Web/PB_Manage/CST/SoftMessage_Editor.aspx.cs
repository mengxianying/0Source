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

namespace Pbzx.Web.PB_Manage
{
    public partial class SoftMessage_Editor : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //����ַ���뵽Session��
                Session["FCKeditor:UserFilesPath"] = "/Images/UploadFiles/CstMessage";

                Session["DefaultSelect"] = "/Images/UploadFiles/CstMessage";
                //�õ���ǰʱ��
                txtPostTime1.Text = DateTime.Now.ToString();
                txtPostTime2.Text = DateTime.Now.AddDays(3).ToString();

               // lsbSoftType.Attributes.Add("onChange", "show('List',document.getElementById('adress'),this.value,400,260)");
             
                Pbzx.Model.CstMessage MyMsg;
                Pbzx.BLL.CstMessage MsgBLL = new Pbzx.BLL.CstMessage();

                //ִ��DropdownList��
                BindDropdownList(); 
                 //�õ���������ID         
                string str = Request.QueryString["ID"];
                //���紫������ID����
                if (str != null && OperateText.IsNumber(str))
                {
                    //����ID�ҵ���Ӧ�����ݶ���
                    MyMsg = MsgBLL.GetModel(int.Parse(str));       
                    //���Ұ󶨵�ҳ��ؼ���
                    ddlSoftwareType.SelectedValue = MyMsg.MsgST.ToString();
                    //�Զ���dropdownlist��
                    BindInstall();
                    //���������ݵİ�
                    ddlInstallType.SelectedValue = MyMsg.MsgIT.ToString();
                    this.rblMsgLevel.SelectedValue = MyMsg.MsgLevel.ToString();
                    this.txtMsgTime.Text = MyMsg.MsgTime.ToString();
                    this.rblMsgSender.SelectedValue = MyMsg.MsgSender;
                    this.txtMsgTitle.Text = MyMsg.MsgTitle;
                    this.rblMsgType.SelectedValue = MyMsg.MsgType.ToString();
                    this.ddlMsgCategory2.SelectedValue = MyMsg.MsgCategory.Split(new char[] {'#'})[1];
                    this.txtMsgContent.Value = MyMsg.MsgContent;
                    this.txtPostTime1.Text = MyMsg.PostTime1.ToString();
                    this.txtPostTime2.Text = MyMsg.PostTime2.ToString();
                    this.rblMsgSend.SelectedIndex = MyMsg.MsgSend ? 0 : 1;                   
                    this.lblToday.Text = MyMsg.LoginCount.ToString();
                    this.lblTotal.Text = MyMsg.TotalCount.ToString();
                    txtMsgPV.Text = MyMsg.MsgPV;
                }
                else
                {
                    //this.IsAuthority(1);
                    //lblAction.Text = "����";
                    MyMsg = new Pbzx.Model.CstMessage();                   
                }                ��
                hfNewsID.Value = MyMsg.ID.ToString();                                      
            }
        }
        //��DropDownList
        private void BindDropdownList()
        {
            //����SQL���
            string sqlSoft = "SELECT   SoftwareType,MAX(SoftwareName) AS SoftwareName FROM CstSoftware GROUP BY SoftwareType";
           //��ѯ�������ݷŵ� DataSet��
            DataSet ds = DbHelperSQL1.Query(sqlSoft);
            //ִ��DropDownList��
            ddlSoftwareType.DataTextField = "SoftwareName";
            ddlSoftwareType.DataValueField = "SoftwareType";
            ddlSoftwareType.DataSource = ds;
            ddlSoftwareType.DataBind();
            //�����ݰ󶨵���һ��
            ddlSoftwareType.Items.Insert(0,new ListItem("����","100"));
            //����Ĭ��ѡ��
            this.ddlSoftwareType.Items[0].Selected = true; 
            //�Զ���dropdownlist��
            BindInstall();
            //�õ���ǰ�û���
            string uname = WebFunc.GetCurrentAdmin();

            this.rblMsgSender.Items.Insert(0, new ListItem("SYSOP", "SYSOP"));
            this.rblMsgSender.Items.Insert(1, new ListItem(uname, uname));
            this.rblMsgSender.Items[0].Selected = true;
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();

            this.txtMsgTime.Text = DateTime.Now.ToString();            
        }
        /// <summary>
        /// �������
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
            if (!DateTime.TryParse(this.txtMsgTime.Text,out dtTemp))
            {
                strErrMsg += "����ʱ��δ��������ݸ�ʽ����ȷ.\\r\\n";
            }
            if(txtMsgTitle.Text.Trim() =="")
            {
                strErrMsg += " .\\r\\n";
            }
            if (txtMsgContent.Value.Trim() == "")
            {
                strErrMsg += "��Ϣ���ݲ���Ϊ��.\\r\\n";
            }
            //if(this.txtPostTime1.Text.Trim() != "" || this.txtPostTime2.Text.Trim() != "")
            //{
                if (!DateTime.TryParse(this.txtPostTime1.Text, out dtTemp) || !DateTime.TryParse(this.txtPostTime2.Text, out dtTemp))
                {
                    strErrMsg += "ʱ�����ݸ�ʽ����ȷ.\\r\\n";
                }
           // }
            //�ж��Ƿ���ڴ���
            if (strErrMsg != "")
            {
                strErrMsg = "���ύ�������Ϣ��Ϣ�д������´���:\\r\\n\\r\\n" + strErrMsg + "\\r\\n���޸ĺ��������ύ.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                int MsgID = Convert.ToInt32(hfNewsID.Value);

                Pbzx.BLL.CstMessage MsgBLL = new Pbzx.BLL.CstMessage();
                Pbzx.Model.CstMessage MyMsg;
                //��ID����0ʱ����ʾ Ҫִ���޸Ĳ���
                if (MsgID > 0)
                {
                    MyMsg = MsgBLL.GetModel(MsgID);
                }
                else
                {
                    MyMsg = new Pbzx.Model.CstMessage();
                }

                MyMsg.MsgST = int.Parse(this.ddlSoftwareType.SelectedValue);
                MyMsg.MsgIT = int.Parse(this.ddlInstallType.SelectedValue);
                MyMsg.MsgPV = this.txtMsgPV.Text;
                MyMsg.MsgLevel = int.Parse(this.rblMsgLevel.SelectedValue);
                MyMsg.MsgTime = DateTime.Parse(this.txtMsgTime.Text);
                MyMsg.MsgSender = this.rblMsgSender.SelectedValue.ToString();
                MyMsg.MsgTitle = this.txtMsgTitle.Text;
                MyMsg.MsgType = int.Parse(this.rblMsgType.SelectedValue);
                MyMsg.MsgCategory = this.ddlMsgCategory1.SelectedValue + "#" + this.ddlMsgCategory2.SelectedValue;
                MyMsg.MsgContent = this.txtMsgContent.Value;
                MyMsg.PostTime1 = DateTime.Parse(this.txtPostTime1.Text);
                MyMsg.PostTime2 = DateTime.Parse(this.txtPostTime2.Text);
                MyMsg.MsgSend = this.rblMsgSend.SelectedValue == "1" ? true : false;               
                MyMsg.LoginCount = int.Parse(this.lblToday.Text);
                MyMsg.TotalCount = int.Parse(this.lblTotal.Text);
                //ִ�в��� ����0 �޸ģ����� ����
                if (MyMsg.ID > 0)
                {
                    if (MsgBLL.Update(MyMsg))
                    {
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�����Ϣ�޸ĳɹ�."));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸������Ϣ[" + MyMsg.ID + ":" + MyMsg.MsgTitle + "].");
                        //Response.Write("<script>alert('�޸ĳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        Response.Redirect("SoftMessage_Manage.aspx");
                    }
                    else
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "�޸������Ϣ[" + MyMsg.ID + ":" + MyMsg.MsgTitle + "]���޸�ʧ�ܡ�");
                        Response.Write("<script>alert('�޸�ʧ��');</script>");
                    }
                }
                else
                {
                    if (MsgBLL.Add(MyMsg))
                    {
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("�����Ϣ��ӳɹ�."));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "���������Ϣ[" + MyMsg.MsgTitle + "].");
                        //Response.Write("<script>alert('��ӳɹ�');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        Response.Redirect("SoftMessage_Manage.aspx");
                    }
                    else
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "��������Ϣ[" + MyMsg.MsgTitle + "]ʧ�ܡ�");
                        Response.Write("<script>alert('���ʧ��');</script>");
                    }
                }
            }
        }

        protected void ddlSoftwareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInstall();
        }
        //ִ�ж���dropdownList��
        private void BindInstall()
        {
            this.ddlInstallType.Items.Clear();
            string sqlInstall = "select  MAX(InstallType) as InstallType,  InstallName  from dbo.CstSoftware where SoftwareName='" + this.ddlSoftwareType.SelectedItem.Text + "' GROUP BY InstallName ";
            DataSet ds = DbHelperSQL1.Query(sqlInstall);
            ddlInstallType.DataTextField = "InstallName";
            ddlInstallType.DataValueField = "InstallType";
            ddlInstallType.DataSource = ds;
            ddlInstallType.DataBind();
            ddlInstallType.Items.Insert(0, new ListItem("����", "100"));        
        }
        /// <summary>
        /// ������أ��ص��б�ҳ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("SoftMessage_Manage.aspx");
        }
 
    }
}

























































































































//<script language="javascript" type="text/javascript">
////function getValue(value)
////{  
////    var oEditor =document.getElementById("DivContentText");
////    if(value.length > 0)
////    {        
////        oEditor.innerHTML += f_creatediv(value);
////    }
////    else
////    {
////        oEditor.innerHTML='ȫ��';
////    }    
////  
////    document.getElementById("LabelDivid").style.display="none";
////}

////    function f_creatediv(listValue){ 
////         var sb="";       
////         var classSZ = listValue.split('&');                      
////            var currentSelect = document.getElementById('<%=lsbSoftType.ClientID%>'); 
////            var currentSoft = currentSelect.options[currentSelect.selectedIndex].text;
////            for (i = 0; i < classSZ.length-1; i++)
////            {            
////                 sb += "<div style='width:400px; height:28px;'id='Div_"+classSZ[i]+"'onmouseover=\"javascript:this.style.backgroundColor=\'#FF9988\'\" onmouseout=\"javascript:this.style.backgroundColor=\'#FFffff\'\" ondblclick=\"this.innerHTML=\'\';style.display = \'none\'\"  > ";
////                 sb+= currentSoft + "<input checked='checked'   type='checkbox'  id='chk_"+classSZ[i]+"' />"+classSZ[i]+" &nbsp;&nbsp;������������汾�ţ�<input type='text' maxlength='20'  />";            
////                 sb+="</div>";
////            }
////            return sb;    
////     }



//</script>