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
                //将地址存入到Session中
                Session["FCKeditor:UserFilesPath"] = "/Images/UploadFiles/CstMessage";

                Session["DefaultSelect"] = "/Images/UploadFiles/CstMessage";
                //得到当前时间
                txtPostTime1.Text = DateTime.Now.ToString();
                txtPostTime2.Text = DateTime.Now.AddDays(3).ToString();

               // lsbSoftType.Attributes.Add("onChange", "show('List',document.getElementById('adress'),this.value,400,260)");
             
                Pbzx.Model.CstMessage MyMsg;
                Pbzx.BLL.CstMessage MsgBLL = new Pbzx.BLL.CstMessage();

                //执行DropdownList绑定
                BindDropdownList(); 
                 //得到传过来的ID         
                string str = Request.QueryString["ID"];
                //如如传过来的ID存在
                if (str != null && OperateText.IsNumber(str))
                {
                    //根据ID找到对应的数据对象
                    MyMsg = MsgBLL.GetModel(int.Parse(str));       
                    //并且绑定到页面控件上
                    ddlSoftwareType.SelectedValue = MyMsg.MsgST.ToString();
                    //对二级dropdownlist绑定
                    BindInstall();
                    //对其他数据的绑定
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
                    //lblAction.Text = "新增";
                    MyMsg = new Pbzx.Model.CstMessage();                   
                }                　
                hfNewsID.Value = MyMsg.ID.ToString();                                      
            }
        }
        //绑定DropDownList
        private void BindDropdownList()
        {
            //定义SQL语句
            string sqlSoft = "SELECT   SoftwareType,MAX(SoftwareName) AS SoftwareName FROM CstSoftware GROUP BY SoftwareType";
           //查询，将数据放到 DataSet中
            DataSet ds = DbHelperSQL1.Query(sqlSoft);
            //执行DropDownList绑定
            ddlSoftwareType.DataTextField = "SoftwareName";
            ddlSoftwareType.DataValueField = "SoftwareType";
            ddlSoftwareType.DataSource = ds;
            ddlSoftwareType.DataBind();
            //将数据绑定到第一个
            ddlSoftwareType.Items.Insert(0,new ListItem("所有","100"));
            //并且默认选中
            this.ddlSoftwareType.Items[0].Selected = true; 
            //对二级dropdownlist绑定
            BindInstall();
            //得到当前用户名
            string uname = WebFunc.GetCurrentAdmin();

            this.rblMsgSender.Items.Insert(0, new ListItem("SYSOP", "SYSOP"));
            this.rblMsgSender.Items.Insert(1, new ListItem(uname, uname));
            this.rblMsgSender.Items[0].Selected = true;
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();

            this.txtMsgTime.Text = DateTime.Now.ToString();            
        }
        /// <summary>
        /// 点击保存
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
            if (!DateTime.TryParse(this.txtMsgTime.Text,out dtTemp))
            {
                strErrMsg += "发布时间未输入或数据格式不正确.\\r\\n";
            }
            if(txtMsgTitle.Text.Trim() =="")
            {
                strErrMsg += " .\\r\\n";
            }
            if (txtMsgContent.Value.Trim() == "")
            {
                strErrMsg += "消息内容不能为空.\\r\\n";
            }
            //if(this.txtPostTime1.Text.Trim() != "" || this.txtPostTime2.Text.Trim() != "")
            //{
                if (!DateTime.TryParse(this.txtPostTime1.Text, out dtTemp) || !DateTime.TryParse(this.txtPostTime2.Text, out dtTemp))
                {
                    strErrMsg += "时限数据格式不正确.\\r\\n";
                }
           // }
            //判断是否存在错误！
            if (strErrMsg != "")
            {
                strErrMsg = "您提交的软件消息信息中存在以下错误:\\r\\n\\r\\n" + strErrMsg + "\\r\\n请修改后再重新提交.";
                ClientScript.RegisterStartupScript(this.GetType(), "no", JS.Alert(strErrMsg));
                return;
            }
            else
            {
                int MsgID = Convert.ToInt32(hfNewsID.Value);

                Pbzx.BLL.CstMessage MsgBLL = new Pbzx.BLL.CstMessage();
                Pbzx.Model.CstMessage MyMsg;
                //当ID大于0时，表示 要执行修改操作
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
                //执行操作 大于0 修改，否则 新增
                if (MyMsg.ID > 0)
                {
                    if (MsgBLL.Update(MyMsg))
                    {
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("软件消息修改成功."));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改软件消息[" + MyMsg.ID + ":" + MyMsg.MsgTitle + "].");
                        //Response.Write("<script>alert('修改成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        Response.Redirect("SoftMessage_Manage.aspx");
                    }
                    else
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("修改", "修改软件消息[" + MyMsg.ID + ":" + MyMsg.MsgTitle + "]，修改失败。");
                        Response.Write("<script>alert('修改失败');</script>");
                    }
                }
                else
                {
                    if (MsgBLL.Add(MyMsg))
                    {
                        //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("软件消息添加成功."));
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "新增软件消息[" + MyMsg.MsgTitle + "].");
                        //Response.Write("<script>alert('添加成功');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
                        Response.Redirect("SoftMessage_Manage.aspx");
                    }
                    else
                    {
                        Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("新增", "添加软件消息[" + MyMsg.MsgTitle + "]失败。");
                        Response.Write("<script>alert('添加失败');</script>");
                    }
                }
            }
        }

        protected void ddlSoftwareType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInstall();
        }
        //执行二级dropdownList绑定
        private void BindInstall()
        {
            this.ddlInstallType.Items.Clear();
            string sqlInstall = "select  MAX(InstallType) as InstallType,  InstallName  from dbo.CstSoftware where SoftwareName='" + this.ddlSoftwareType.SelectedItem.Text + "' GROUP BY InstallName ";
            DataSet ds = DbHelperSQL1.Query(sqlInstall);
            ddlInstallType.DataTextField = "InstallName";
            ddlInstallType.DataValueField = "InstallType";
            ddlInstallType.DataSource = ds;
            ddlInstallType.DataBind();
            ddlInstallType.Items.Insert(0, new ListItem("所有", "100"));        
        }
        /// <summary>
        /// 点击返回，回到列表页面
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
////        oEditor.innerHTML='全部';
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
////                 sb+= currentSoft + "<input checked='checked'   type='checkbox'  id='chk_"+classSZ[i]+"' />"+classSZ[i]+" &nbsp;&nbsp;请输入请输入版本号：<input type='text' maxlength='20'  />";            
////                 sb+="</div>";
////            }
////            return sb;    
////     }



//</script>