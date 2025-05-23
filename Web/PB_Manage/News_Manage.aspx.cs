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

namespace Pbzx.Web.PB_Manage
{
    public partial class News_Manage : AdminBasic
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request["CID"] != null)
                //{
                //    labAction.Text = new Pbzx.BLL.PBnet_NewsType().GetModel(Convert.ToInt32(Request["CID"])).VarTypeName;
                //}
                this.MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                BindData();
            }
        }

        private void BindData()
        {
            Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();
            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(this.AddParameter());
            //  bu.Append(" and IntSetting=0 ");
            ///////////////////////////////////////////////////////////////////////////////////
            string Searchstr = bu.ToString();
            string order = "BitIsTop desc,datdateandtime desc ";
            int myCount = 0;
            
            DataTable lsResult = newsBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

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
            //AspNetPager1.CurrentPageIndex = page;
           
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
            Pbzx.BLL.PBnet_NewsType newsTypeBLL = new Pbzx.BLL.PBnet_NewsType();
            if (obj != null && obj.ToString() != "")
            {
                Pbzx.Model.PBnet_NewsType typeModel = newsTypeBLL.GetModel(int.Parse(obj.ToString()));
                if (typeModel != null)
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
            Pbzx.BLL.PBnet_News bll = new Pbzx.BLL.PBnet_News();
            if (bll.Delete(id))
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ������[" + nvarname + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("ɾ������[" + nvarname + "]�ɹ���"));
                //JS.Alert("ɾ������[" + nvarname + "]�ɹ���");
            }
            BindData();
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("News_Editor.aspx?ID=[*]");
        }


        protected void btnManySH_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdate(str, "BitIsPass",true);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�Ƽ�", "�Ƽ�����[" + str + "]");
                //ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("���Ƽ���" + del + "����¼."));


            }
            BindData();   
        }

        

 
        protected void btnSC_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchDel(str);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("ɾ��", "ɾ������[" + str + "]");
                 JS.Alert("��ɾ����" + del + "����¼.");
            }
            BindData();
        }





        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                string href = "<a href='News_Editor.aspx?ID=" + e.Row.Cells[1].Text + "' >";
                e.Row.Cells[1].Text = href + "(" + (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString() + ")</a>";
            }
        }

        protected void btnNoFB_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdate(str, "BitIsPass",false);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("���ò�����", "���ò���������[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("�����ò�����" + del + "����¼."));
            }
            BindData();
        }


        protected string GetTitle(object title,object isStatic,object savePath)
        {           
            string strTitle = StrFormat.CutStringByNum(title, 18*2);
            string result = "";
            if (bool.Parse(isStatic.ToString()))
            {
                result = "<a title='" + title.ToString() + "' href='" + savePath.ToString() + "' target='_blank'>" + strTitle + "</a>";
            }
            else
            {
                result = "<span title='"+title.ToString()+"'>"+strTitle+"</span>";
            }
            return result;
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            WebFunc.RefPagesByPageName("������ϸҳģ��");
            int newsID = int.Parse(e.CommandArgument.ToString());
            Pbzx.BLL.PBnet_News newsBLL = new Pbzx.BLL.PBnet_News();
            Pbzx.Model.PBnet_News myNews = newsBLL.GetModel(newsID);
            newsBLL.ArticleUpdate(myNews);            
            BindData();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            WebFunc.RefPagesByPageName("������ϸҳģ��");
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            newstBLL.CreateContentFileByTemplate(str);          
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "��������[" + str + "]");
            ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("��������[" + str + "]"));            
            BindData();
            RefNewsPage();
           
        }

        protected void btnAllCreate_Click(object sender, EventArgs e)
        {
            WebFunc.RefPagesByPageName("������ϸҳģ��");
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            newstBLL.CreateAllArticleFile();
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("����", "ȫ����������");
            // ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("��������" + del + "����¼."));
            BindData();
            RefNewsPage();       
        }

        protected void lblCreateIndex_Click(object sender, EventArgs e)
        {
            RefNewsPage();
            //btnAllCreate_Click(sender, e);
            //Response.Redirect(Request.Url.PathAndQuery);
        }

        protected void lbtnIsTop_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_News.ChangeAudit(id, "ShowInSoft");
            BindData();
        }

        protected void lbtnShow_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_News.ChangeAudit(id, "ShowIndex");
            BindData();
        }

        protected void lbtnIsPass_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            Pbzx.BLL.PBnet_News.ChangeAudit(id, "BitIsPass");
            BindData();
        }

        /// <summary>
        /// ˢ����ҳ��������Ѷ��ҳ
        /// </summary>
        private void RefNewsPage()
        {
            WebFunc.RefPagesByPageName("��ҳ");
            WebFunc.RefPagesByPageName("������Ѷ");
            WebFunc.RefPagesByPageName("�����Ƕҳ��");
        }
        public static string GetIsTop(object objIsTop)
        {
            string strIsTop = "";
            if (objIsTop.ToString() != null && objIsTop.ToString() != "")
            {
                int intIsTop = int.Parse(objIsTop.ToString());
                switch (intIsTop)
                {
                    case 2:
                        strIsTop = "<font color=red>�׹�</font>";
                        break;
                    case 1:
                        strIsTop = "<font color= blue>�ι�</font>";
                        break;
                    case 0:
                        strIsTop = "<font color=#000000>����</font>";
                        break;
                    default:
                        strIsTop = "<font color=red>δ֪</font>";
                        break;
                }
            }
            else {

                return null;
            }
            return strIsTop;
        }

        protected void btnShouG_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdateTop(str, "BitIsTop", 2);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�����׹�", "�����׹�[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("�������׹�" + del + "����¼."));
            }
            BindData();
        }

        protected void btnCiG_Click(object sender, EventArgs e)
        {
   
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdateTop(str, "BitIsTop", 1);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("���ôι�", "���ôι�[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("�����ôι�" + del + "����¼."));
            }
            BindData();
        }

        protected void btnBuG_Click(object sender, EventArgs e)
        {
     
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
            string str = Request.Form["sel"];
            if (str == null)
            {
                return;
            }
            int del = newstBLL.BatchUpdateTop(str, "BitIsTop", 0);
            if (del > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("���ò���", "���ò���[" + str + "]");
                ClientScript.RegisterStartupScript(this.GetType(), "ok", JS.Alert("�����ò���" + del + "����¼."));
            }
            BindData();
        }

        protected void btnSChtml_Click(object sender, EventArgs e)
        {
            Pbzx.BLL.PBnet_News newstBLL = new Pbzx.BLL.PBnet_News();
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
                ClientScript.RegisterStartupScript(GetType(), "SCHtmlXW", JS.Alert("��ɾ����" + del + "�������ļ�."));
            }
        }
    }
}
