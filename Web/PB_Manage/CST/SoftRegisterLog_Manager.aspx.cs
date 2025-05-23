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
using System.Text;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class SoftRegisterLog_Manager : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "CreateTime";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }


        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }

        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);          
        }

        /// <summary>
        /// ����url��ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();
            Pbzx.BLL.CstSoftware sfBll = new Pbzx.BLL.CstSoftware();


            #region ���¼�(2010-01-05)
            if (!string.IsNullOrEmpty(Request["SoftwareName"]))
            {
                string SoftwareType = sfBll.GetIdByName("SoftwareName", Request["SoftwareName"], "SoftwareType");
                bu.Append(" and SoftwareType='" + SoftwareType + "' ");
            }
            if (!string.IsNullOrEmpty(Request["InstallName"]))
            {
                //string installType = sfBll.GetIdByName("InstallName", Request["InstallName"], "InstallType");
                bu.Append(" and InstallType='" + Request["InstallName"] + "' ");
            }
            else
            {
                if (!string.IsNullOrEmpty(Request["SoftwareName"]))
                {
                    bu.Append(" and InstallType in (select InstallType from  CstSoftware where SoftwareName='" + Request["SoftwareName"] + "' ) ");
                }
            }
            #endregion


            if (!string.IsNullOrEmpty(Request["RegisterMode"]))
            {
                bu.Append(" and RegisterMode='" + Request["RegisterMode"] + "' ");
            }
            if (!string.IsNullOrEmpty(Request["softwareType"]))
            {
                bu.Append(" and SoftwareType='" + Request["softwareType"].Trim() + "' ");
            }
            if (!string.IsNullOrEmpty(Request["installType"]))
            {
                bu.Append(" and InstallType='" + Request["installType"].Trim() + "' ");
            }



            //�����û����Ϳͻ�������ƴ������
            if (!string.IsNullOrEmpty(Request["strUsername"]))
            {

                bu.Append(" and UserName like '%" + Request["strUsername"].Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["strBbsName"]))
            {
                bu.Append(" and BbsName like '%" + Request["strBbsName"].Trim() + "%' ");
            }

            //ʹ������
            if (!string.IsNullOrEmpty(Request["useType"]))
            {
                bu.Append(" and UseType like '%" + Request["useType"].Trim() + "%' ");
            }
            //����״̬
            if (!string.IsNullOrEmpty(Request["payStatus"]))
            {
                bu.Append(" and payStatus='" + Request["payStatus"] + "' ");
            }
            //���ѷ�ʽ
            if (!string.IsNullOrEmpty(Request["PayType"]))
            {
                bu.Append(" and PayType like '%" + Request["PayType"].Trim() + "%' ");
            }
            //ע������
            if (!string.IsNullOrEmpty(Request["registerType"]))
            {
                switch (Request["registerType"])
                {
                    case "��˾ע��":
                        bu.Append(" and RegisterType=1 ");
                        break;
                    case "����ע��":
                        bu.Append(" and RegisterType=2 ");
                        break;
                    //case "��ֵ��ע��":
                    //    bu.Append(" and RegisterType=3 ");
                    //    break;
                    default:
                        bu.Append(" and AgentName='" + Request["registerType"] + "' ");
                        break;
                }
            }


            
   
            if (!string.IsNullOrEmpty(Request["dateType"]))
            {
                if (!string.IsNullOrEmpty(Request["strCreateTime1"]) && !string.IsNullOrEmpty(Request["strCreateTime2"]))
                {
                    if (Request["dateType"] == "1")
                    {
                        bu.Append(" and CreateTime between '" + Request["strCreateTime1"].Trim() + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                    else if (Request["dateType"] == "2")
                    {
                        bu.Append(" and Old_ExpireDate between '" + Request["strCreateTime1"] + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
                    }
                }
            }


            //��ҳ��������
            if (!string.IsNullOrEmpty(Request["bbsName"]))
            {
                bu.Append(" and BbsName like '%" + Request["bbsName"].Trim() + "%' ");
            }
            return bu.ToString();

        }


        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.CN_RegisterLog regInfoBLL = new Pbzx.BLL.CN_RegisterLog();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = column;
            int myCount = 0;
            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }

            DataTable lsResult = regInfoBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.lblTotal.Text = "";
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                string strTotalTemp = regInfoBLL.GetTotalMoney(bu.ToString());
                this.lblTotal.Text = "�ܼƽ�" + Math.Round(Convert.ToDecimal(strTotalTemp.Split(new char[] { '&' })[1]),2) + "Ԫ&nbsp;";
                this.litContent.Text = "";
            }

        }

        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["order"] = e.SortExpression.ToString();
            if ((bool)ViewState["isDesc"])
            {
                ViewState["isDesc"] = false;
            }
            else
            {
                ViewState["isDesc"] = true;
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

       protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a  href='SoftRegisterLog_Editor.aspx?ID=" + e.Row.Cells[0].Text + "' target='_blank'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

        protected string ChkSoftType(object num, object st)
        {
            
            Pbzx.BLL.CstSoftware softBLL = new Pbzx.BLL.CstSoftware();
            string[] result = softBLL.Chksettype(num, st) ;
            return "<a href='SoftRegisterLog_Manager.aspx?softwareType=" + num.ToString() + "&installType=" + st.ToString() + "'>" +result[0]+"("+result[1]+")"+ "</a>";
        }

        protected string ChkHDSN(object tHDSN, object tRN, object tStatus)
        {
            string strStatus = tStatus.ToString();
            string dis = "";
            string strRN = tRN.ToString();
            string strHDSN = tHDSN.ToString();
            switch (strStatus)
            {
                case null:
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
                case "":
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
                case "1":
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
                case "2":
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank' style='color:#ff0000;' >" + strHDSN + "</a>";
                    break;
                case "3":
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank' style='color:#009900;'>" + strHDSN + "</a>";
                    break;
                case "4":
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank' style='color:#999999;'>" + strHDSN + "</a>";
                    break;
                default:
                    dis = "<a href='SoftReg_Manager.aspx?strRN=" + strRN + "&act_searchmod=0' target='_blank'>" + strHDSN + "</a>";
                    break;
            }
            return dis;
        }

        protected string BindHdsn_A(object objOld, object objIsReg)
        {

            string tempObj = objOld.ToString();
            string tempReg = objIsReg.ToString();
            string result = "";
            if (string.IsNullOrEmpty(tempObj))
            {
                result = "color:#0033FF;";
            }
            else if (tempReg == "1")
            {
                result = "color:#FF0000;";
            }
            return result;
        }

        protected string BindGetUseType(object obj)
        {
            return Pbzx.Common.Method.GetUseType(obj);
        }
        protected string BindGetTimeType(object obj)
        {
            return Pbzx.Common.Method.GetTimeType(obj);
        }




        protected string GetPayStatus(object objPayStatus)
        {
            string strPayStatus = objPayStatus.ToString();
            string result = "";
            string strA1 = "<a href='SoftRegisterLog_Manager.aspx?payStatus=" + strPayStatus + "'>";            
            switch (strPayStatus)
            {
                case "1":
                    result = "<font color='ff0000'>δ����</font>";
                    break;
                case "2":
                    result = "�Ѹ���";
                    break;
                case "3":
                    result = "<font color='339900'>���</font>";
                    break;
                default:
                    result = "����";
                    break;
            }
            return strA1+result+"</a>";   
        }

        protected string GetRegisterType(object objRegisterType, object objAgentName, object objCardInfo)
        {
            string strRegisterType = objRegisterType.ToString().Trim();
            string result = "";
          //  string strA1 = "<a href='SoftRegisterLog_Manager.aspx?registerType=" + strRegisterType + "'>";
            switch (strRegisterType)
            {
                case "1":
                    result = "<a href='SoftRegisterLog_Manager.aspx?registerType=��˾ע��'> ��˾ע��</a>";
                    break;
                case "2"://����
                    result = "<a href='SoftRegisterLog_Manager.aspx?registerType=" + objAgentName.ToString().Trim() + "'>" + objAgentName.ToString() + "</a>";
                    break;
                case "3"://������
                    result = "<a href='SoftRegisterLog_Manager.aspx?registerType=" + objAgentName.ToString().Trim() + "'>" + objAgentName.ToString() + "</a>";
                    break;
                default:
                    result = "����";
                    break;
            }
            return result ;
        }

 
    }
}











