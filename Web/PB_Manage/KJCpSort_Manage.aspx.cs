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
using System.Xml;
using System.IO;
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class KJCpSort_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
            }
        }

        private void BindData()
        {
            XmlDocument doc = new XmlDocument();
            //全国刷新情况
            string path = Server.MapPath("~/xml/refresh.xml");
            doc.Load(path);
            XmlNode nodeQG = doc.SelectSingleNode("/CpDate/Refresh_QuanGuo");
            XmlElement xeNodeQG = (XmlElement)nodeQG;
            this.lblRef1.Text = nodeQG.Attributes["text"].Value;

            //各省刷新情况
            //string path2 = Server.MapPath("~/xml/refresh.xml");
            //doc.Load(path2);
            XmlNode nodeGS = doc.SelectSingleNode("/CpDate/Refresh_GeSheng");
            XmlElement xeNodeGS = (XmlElement)nodeGS;
            this.lblRef2.Text = nodeGS.Attributes["text"].Value;

            //高频刷新情况
            //string path3 = Server.MapPath("~/xml/refresh.xml");
            //doc.Load(path3);
            XmlNode nodeGP = doc.SelectSingleNode("/CpDate/Refresh_GaoPinFast");
            XmlElement xeNodeGP = (XmlElement)nodeGP;
            this.lblGaoPinFast.Text = xeNodeGP.Attributes["text"].Value;
            
            //高频超
            XmlNode nodeGPC = doc.SelectSingleNode("/CpDate/Refresh_GaoPinSuper");
             XmlElement xeNodeGPC = (XmlElement)nodeGPC;
             this.lblGaoPinSuper.Text = xeNodeGPC.Attributes["text"].Value;

            XmlNode nodeGPMid = doc.SelectSingleNode("/CpDate/Refresh_GaoPinMid");
            XmlElement xeNodeGPMid = (XmlElement)nodeGPMid;
            this.lblGaoPinMid.Text = xeNodeGPMid.Attributes["text"].Value;


            XmlNode nodeGPSlow = doc.SelectSingleNode("/CpDate/Refresh_GaoPinSlow");
            XmlElement xeNodeGPSlow = (XmlElement)nodeGPSlow;
            this.lblGaoPinSlow.Text = xeNodeGPSlow.Attributes["text"].Value;

            StringBuilder bu = new StringBuilder();
            Pbzx.BLL.PBnet_LotteryMenu  lotteryMenuBLL = new Pbzx.BLL.PBnet_LotteryMenu();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            ///////////////////////////////////////////////////////////////////////////////////
            string Searchstr = bu.ToString();
            string order = " IntClass_OrderId asc,NvarOrderId asc";//,NvarOrderId
            int myCount = 0;

            DataTable lsResult = lotteryMenuBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();

            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>抱歉！<p/><br/>没有找到您搜索的数据记录</b>";
            }
            else
            {
                this.litContent.Text = "";
            }
        }


        /// <summary>
        /// 处理url传值查询
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            if (!string.IsNullOrEmpty(Request["name"]))
            {
                bu.Append(" and NvarName  like '%" + Request["name"] + "%' ");
            }


            if (!string.IsNullOrEmpty(Request["NvarClass"]))
            {
                bu.Append(" and NvarClass ='" + Request["NvarClass"] + "' ");
            }


            if (!string.IsNullOrEmpty(Request["isShow"]))
            {
                bu.Append(" and BitIs_show ='" + Request["isShow"] + "' ");
            }

            if (!string.IsNullOrEmpty(Request["state"]))
            {
                bu.Append(" and BitState='" + Request["state"] + "' ");
            }

            
            return bu.ToString();

        }

        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }


        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "本页<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "分页:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.MyGridView.Rows.Count <= 1)
            {
                e.Cancel = true;
                JS.Alert("必须保证至少有一条记录");
            }
            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string nvarname = MyGridView.Rows[e.RowIndex].Cells[1].Text;
            Pbzx.BLL.PBnet_LotteryMenu bll = new Pbzx.BLL.PBnet_LotteryMenu();
            if (bll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("删除", "删除彩种[" + nvarname + "]");
                //ClientScript.RegisterClientScriptBlock(this.GetType(), "ok", JS.Alert("共删除了" + del + "条记录.", "FriendLink_Manage.aspx"));
                JS.Alert("删除彩种[" + nvarname + "]成功！");
            }
            BindData();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='KJCpSort_Editor.aspx?ID=" + e.Row.Cells[0].Text + "'>";
                e.Row.Cells[0].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

        protected void lbtnShow_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_LotteryMenu.ChangeAudit(id, "BitIs_show");
            BindData();
        }

        protected void lbtnRefresh_Command(object sender, CommandEventArgs e)
        {
            string idAndType = e.CommandArgument.ToString();
            string[] sz = idAndType.Split(new char[] {'&'});
            int id = Convert.ToInt32(sz[0]);
            Pbzx.BLL.PBnet_LotteryMenu.ChangeAudit(id, "IsRefresh");
            BindData();
            Server.Execute("/PB_Manage/RefurbishCpXml.aspx?cpType="+sz[1]+"");            
        }

        protected void lbtnUpdateKJ_Click(object sender, EventArgs e)
        {
            string htmlPath = HttpRuntime.AppDomainAppPath + "\\xml\\QuanGuoCpDate.xml";
            if (File.Exists(htmlPath))
            {
                File.SetAttributes(htmlPath, FileAttributes.Normal);
                File.Delete(htmlPath);
            }
            Server.Execute("RefurbishCpXml.aspx");
            Application.Lock();
            Application["FC3DData"] = "false";
            Application["TCPL35Data"] = "false";
            Application["TC7XCData_New"] = "false";
            Application["FC7LC"] = "false";
            Application["FCSSData"] = "false";
            Application["TCDLTData"] = "false";
            Application["FCKL8Data"] = "false";
//            Application["TC22X5Data"] = "false";
//            Application["TC31X7Data"] = "false";
            Application.UnLock();
        }

        protected void lbtnState_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_LotteryMenu.ChangeAudit(id, "BitState");
            BindData();
        }

        protected void lbtnUpdateQX_Command(object sender, CommandEventArgs e)
        {
            string idAndType = e.CommandArgument.ToString();
            string[] sz = idAndType.Split(new char[] { '&' });
            Object objLottDate = sz[2];
            string strLottDate = "";
            if (objLottDate != null)
            {
                strLottDate = objLottDate.ToString();
                if (strLottDate.Length > 1)
                {
                    strLottDate = strLottDate.Substring(0, strLottDate.Length - 1);
                }
            }           
            string sql = "update PBnet_Module set URL='" + sz[3] + "?city=" + sz[1] + "&lottdate="+strLottDate+"' where Name='"+sz[0]+"' ";
            DbHelperSQL.ExecuteSql(sql);
            Response.Redirect("KJCpSort_Manage.aspx");                                         
        }
    }
}
