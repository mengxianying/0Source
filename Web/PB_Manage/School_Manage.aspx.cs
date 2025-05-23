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
using System.Text;

namespace Pbzx.Web.PB_Manage
{
    public partial class School_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["CID"] != null)
                {                    
                    labAction.Text = new Pbzx.BLL.PBnet_SchoolType().GetModel(Convert.ToInt32(Request["CID"])).VarTypeName;
                }
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
            }
        }

        private void BindData()
        {
            Pbzx.BLL.PBnet_School newsBLL = new Pbzx.BLL.PBnet_School();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            //  bu.Append(" and IntSetting=0 ");
            ///////////////////////////////////////////////////////////////////////////////////
            string Searchstr = bu.ToString();
            string order = "BitIsTop desc,datdateandtime desc ";
            int myCount = 0;

            DataTable lsResult = newsBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3 , AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                this.litContent.Text = "";
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
            BindData();
        }

        protected string GetTypeNameByID(object obj)
        {
            string result = "";
            Pbzx.BLL.PBnet_SchoolType newsTypeBLL = new Pbzx.BLL.PBnet_SchoolType();
            if(obj != null && obj.ToString() !="")
            {
                Pbzx.Model.PBnet_SchoolType typeModel = newsTypeBLL.GetModel(int.Parse(obj.ToString()));
                if(typeModel != null)
                {
                    result = typeModel.VarTypeName;
                }
            }
            return result;
        }

        /// <summary>
        /// ����url��ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            if (!string.IsNullOrEmpty(Request["IntChannelID"]))
            {
                bu.Append(" and IntChannelID =" + Request["IntChannelID"] + " ");
            }
            if (!string.IsNullOrEmpty(Request["IntShowType"]))
            {
                bu.Append(" and IntShowType =" + Request["IntShowType"] + " ");
            }
            if (!string.IsNullOrEmpty(Request["regedit"]))
            {
                bu.Append(" and DatDateAndTime between dateAdd(day," + this.Request["regedit"].ToString() + ",getdate()) and getdate()  ");
            }
            if (!string.IsNullOrEmpty(Request["NvarTitle"]))
            {
                bu.Append(" and NvarTitle like '%" + Request["NvarTitle"] + "%' ");
            }
            if (!string.IsNullOrEmpty(Request["ShowIndex"]))
            {
                bu.Append(" and ShowIndex=" + Request["ShowIndex"]);
            }
            if (!string.IsNullOrEmpty(Request["BitIsPass"]))
            {
                bu.Append(" and BitIsPass=" + Request["BitIsPass"]);
            }
            return bu.ToString();

        }

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (this.MyGridView.Rows.Count <= 1)
            {
                e.Cancel = true;
                JS.Alert("���뱣֤������һ����¼");
            }
            int id = int.Parse(MyGridView.DataKeys[e.RowIndex].Value.ToString());
            string nvarname = MyGridView.DataKeys[e.RowIndex].Values["NvarTitle"].ToString();
            Pbzx.BLL.PBnet_School bll = new Pbzx.BLL.PBnet_School();
            if (bll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ�����ѧԺ��Ѷ[" + nvarname + "]");
                //ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("��ɾ����" + del + "����¼.", "FriendLink_Manage.aspx"));
                JS.Alert("ɾ�����ѧԺ��Ѷ[" + nvarname + "]�ɹ���");
            }
            BindData();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("School_Editor.aspx?ID=[*]");
        }


        protected void btnManySH_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_School newstBLL = new Pbzx.BLL.PBnet_School();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdate(str, "BitIsPass", true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�Ƽ�", "�Ƽ����ѧԺ��Ѷ[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("���Ƽ���" + del + "����¼."));
            }
            BindData();
        }

        protected void btnGD_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_School newstBLL = new Pbzx.BLL.PBnet_School();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdate(str, "BitIsTop", true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�ö�", "�ö����ѧԺ��Ѷ[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("���̶���" + del + "����¼."));
            }
            BindData();
        }


        protected void btnSC_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_School newstBLL = new Pbzx.BLL.PBnet_School();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchDel(str);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ�����ѧԺ��Ѷ[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("��ɾ����" + del + "����¼."));
            }
            BindData();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='School_Editor.aspx?ID=" + e.Row.Cells[1].Text + "'>";
                e.Row.Cells[1].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

        protected void btnNoFB_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_School newstBLL = new Pbzx.BLL.PBnet_School();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdate(str, "BitIsPass", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("���ò�����", "���ò��������ѧԺ��Ѷ[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("�����ò�����" + del + "����¼."));
            }
            BindData();
        }

        protected void btnNoGD_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_School newstBLL = new Pbzx.BLL.PBnet_School();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdate(str, "BitIsTop", false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("���̶�", "���ò��̶����ѧԺ��Ѷ[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("�����ò��̶�" + del + "����¼."));
            }
            BindData();
        }

        protected string GetTitle(object title, object isStatic, object savePath)
        {
            string strTitle = StrFormat.CutStringByNum(title, 36);
            string result = "";
            if (bool.Parse(isStatic.ToString()))
            {
                result = "<a title='" + title.ToString() + "' href='" + savePath.ToString() + "' target='_blank'>" + strTitle + "</a>";
            }
            else
            {
                result = "<span title='" + title.ToString() + "'>" + strTitle + "</span>";
            }
            return result;
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            WebFunc.RefPagesByPageName("���ѧԺ��ϸҳģ��");
            int newsID = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_School newsBLL = new Pbzx.BLL.PBnet_School();
            Pbzx.Model.PBnet_School myNews = newsBLL.GetModel(newsID);
            newsBLL.ArticleUpdate(myNews);
            BindData();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            WebFunc.RefPagesByPageName("���ѧԺ��ϸҳģ��");
            Pbzx.BLL.PBnet_School newstBLL = new Pbzx.BLL.PBnet_School();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            newstBLL.CreateContentFileByTemplate(str);
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "�������ѧԺ��Ѷ[" + str + "]");
            //   ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("��������" + del + "����¼.", "News_Manage.aspx"));            
            BindData();
            RefSchoolPage();
            
        }

        protected void btnAllCreate_Click(object sender, EventArgs e)
        {
            WebFunc.RefPagesByPageName("���ѧԺ��ϸҳģ��");
            Pbzx.BLL.PBnet_School newstBLL = new Pbzx.BLL.PBnet_School();
            newstBLL.CreateAllArticleFile();
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "����ȫ�����ѧԺ��Ѷ");
            // ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("��������" + del + "����¼.", "News_Manage.aspx"));
            BindData();
            RefSchoolPage();
        }

        protected void lblCreateIndex_Click(object sender, EventArgs e)
        {
            RefSchoolPage();
            //Pbzx.BLL.PBnet_UrlMaping bll = new Pbzx.BLL.PBnet_UrlMaping();            
            //bll.CreatHtmlByChannelID(bll.GetModelList(" Aspx='/Template/School.aspx' ")[0].MapID, false);
            //btnAllCreate_Click(sender, e);
        }

        protected void lbtnIsTop_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_School.ChangeAudit(id, "BitIsTop");
            BindData();
        }

        protected void lbtnShow_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_School.ChangeAudit(id, "ShowIndex");
            BindData();
        }

        protected void lbtnIsPass_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_School.ChangeAudit(id, "BitIsPass");
            BindData();
        }

        /// <summary>
        /// ˢ����ҳ��������Ѷ��ҳ
        /// </summary>
        private void RefSchoolPage()
        {
            WebFunc.RefPagesByPageName("��ҳ");
            WebFunc.RefPagesByPageName("���ѧԺ");
        }

        protected void btnSChtml_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_School newstBLL = new Pbzx.BLL.PBnet_School();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchDelHtml(str);
            BindData();
            if (del >= 0)
            {
                //Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ������[" + str + "]");
                //Response.Write(JS.Alert("��ɾ����" + del + "�������ļ�."));
                //this.RegisterStartupScript("SCHtml", JS.Alert("��ɾ����" + del + "�������ļ�."));
                ClientScript.RegisterStartupScript(GetType(), "SCHtml", JS.Alert("��ɾ����" + del + "��ѧԺ�ļ�."));
            }
        }
       
    }
}
