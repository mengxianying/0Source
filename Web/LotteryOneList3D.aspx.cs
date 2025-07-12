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
using System.Text;
using Pbzx.SQLServerDAL;

namespace Pbzx.Web
{
    public partial class LotteryOneList3D : System.Web.UI.Page
    {
        protected string riQi = "";
        protected string caizhongName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
//            if ((Request.UrlReferrer == null && !Page.IsPostBack) || (Request.UrlReferrer != null && (!Request.UrlReferrer.Host.ToLower().Contains("pinble.com") || !ConfigurationManager.AppSettings["HostName"].Contains(Request.UrlReferrer.Host.ToLower()))))
//            {
////                Response.Write("<script>top.location ='/Error.htm';</script>");
//                Response.End();
//                return;
//            }
            if (Request.UrlReferrer == null && !Page.IsPostBack)
            {
                //                Pbzx.Common.ErrorLog.WriteLogMeng("IsNullOrEmpty(str_Referrer)", "YES", true, true);
                //                Response.Write("<script>top.location ='/Error.htm';</script>");
                Response.End();
                return;
            }
            else if (Request.UrlReferrer != null && !Page.IsPostBack && !Request.UrlReferrer.ToString().ToLower().Contains(ConfigurationManager.AppSettings["HostName"]))
            {
                //                Pbzx.Common.ErrorLog.WriteLogMeng("str_Referrer.Contains(pinble.com)", "YES", true, true);
                //                Response.Write("<script>top.location ='/Error.htm';</script>");
                Response.End();
                return;
            }
            Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!Page.IsPostBack)
            {
                ViewState["tableName"] = "FC3DData";
                BindData();
                this.MyGridView.Attributes.Add("bordercolor", "#B6CBE8");
            }
        }

        private string GetName()
        {
            try
            {
//                return Input.FilterAll(Input.Decrypt(Request["name"]));
                return Request["name"];
            }
            catch (Exception ex)
            {
                return "";
            }
            // return Request.QueryString["name"];
            //  return (string)DbHelperSQL.GetSingle("select NvarName from PBnet_LotteryMenu where NvarApp_name='" + ViewState["tableName"].ToString() + "' ");
        }

        private string GetLott_date()
        {
            try
            {
                return (string)DbHelperSQL.GetSingle("select NvarLott_date from PBnet_LotteryMenu where NvarApp_name='" + ViewState["tableName"].ToString() + "' ");
            }
            catch (Exception ex)
            {
                return "";
            }
            //            return (string)DbHelperSQL.GetSingle("select NvarLott_date from PBnet_LotteryMenu where NvarApp_name='" + ViewState["tableName"].ToString() + "' ");
        }


        private void BindData()
        {
            caizhongName = GetName();
            object objTime = DbHelperSQL.GetSingle("select TimeList from PBnet_LotteryMenu where NvarApp_name='" + ViewState["tableName"].ToString() + "' ");
            if (objTime != null && !string.IsNullOrEmpty(objTime.ToString()))
            {
                string[] tmSZ = objTime.ToString().Split(new char[] { '|' });
                TimeSpan tsStart = new TimeSpan();
                if (!TimeSpan.TryParse(tmSZ[0], out tsStart))
                {
                    return;
                }

                TimeSpan tsEnd = new TimeSpan();
                if (!TimeSpan.TryParse(tmSZ[1], out tsEnd))
                {
                    return;
                }
                int jg = 0;
                tsEnd.Subtract(tsStart);
                while (tsStart < tsEnd)
                {
                    tsStart = tsStart.Add(TimeSpan.FromMinutes(1));
                    jg++;
                }
                riQi = "ÿ" + jg.ToString() + "����";
            }
            else
            {
                riQi = Method.GetLottDate1(GetLott_date());
            }

            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 ");
            bu.Append(" and code IS NOT NULL and len(code)>0  ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();
            string order = "Issue";
            int myCount = 0;
            //��ȡ��ҳ����
            DataTable lsResult = Basic.CstGetRecordFromPagesDs(ViewState["tableName"].ToString(), "*", "", "issue", 40, AspNetPager1.CurrentPageIndex, true, 2, Searchstr, out myCount);

            //����datakey
            string[] keys = new string[] { };
            ArrayList listKey = new ArrayList();
            listKey.Add("issue");
            listKey.Add("testcode");
            string strAllInfo = "";
            if (ViewState["LottTypeInfo"] != null && ViewState["LottTypeInfo"].ToString() != "")
            {
                strAllInfo = ViewState["LottTypeInfo"].ToString();
            }
            else
            {
                strAllInfo = DbHelperSQL.GetSingle("select top 1 LottTypeInfo from PBnet_LotteryMenu where NvarApp_name='" + ViewState["tableName"].ToString() + "'  ").ToString();
                ViewState["LottTypeInfo"] = strAllInfo;
            }


            string[] lottTypeInfoSZ = strAllInfo.Split(new char[] { '|' });
            string[] strInfo1 = lottTypeInfoSZ[0].Split(new char[] { ',' });
            listKey.Add(strInfo1[4]);
            if (lottTypeInfoSZ.Length > 1 && !string.IsNullOrEmpty(lottTypeInfoSZ[1]))
            {
                string[] strInfo2 = lottTypeInfoSZ[1].Split(new char[] { ',' });
                listKey.Add(strInfo2[4]);
            }
            keys = (string[])listKey.ToArray(typeof(string)); // ת����Type��������
            MyGridView.DataKeyNames = keys;

            //��
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
            AspNetPager1.PageSize = 40;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ��<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>��&nbsp;&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private string AddParameter()
        {
            StringBuilder bu1 = new StringBuilder();
            if (!string.IsNullOrEmpty(Request["Title"]))
            {

            }
            if (Request["Search"] != null)
            {
            }
            return bu1.ToString();
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string name = GetName();

                #region ������������ʾ

                string strAllInfo = "";
                if (ViewState["LottTypeInfo"] != null && ViewState["LottTypeInfo"].ToString() != "")
                {
                    strAllInfo = ViewState["LottTypeInfo"].ToString();
                }
                else
                {
                    strAllInfo = DbHelperSQL.GetSingle("select top 1 LottTypeInfo from PBnet_LotteryMenu where NvarApp_name='" + ViewState["tableName"].ToString() + "'  ").ToString();
                    ViewState["LottTypeInfo"] = strAllInfo;
                }


                string[] lottTypeInfoSZ = strAllInfo.Split(new char[] { '|' });
                string[] strInfo1 = lottTypeInfoSZ[0].Split(new char[] { ',' });

                string qianCode = MyGridView.DataKeys[e.Row.RowIndex].Values[strInfo1[4]].ToString();
                string houCode = "";

                string result = "";

                string result1 = "";

                qianCode = MyGridView.DataKeys[e.Row.RowIndex].Values[strInfo1[4]].ToString();
                //ǰ��
                if (strInfo1[5] == "��͸��" || strInfo1[5] == "��λ��͸��")
                {
                    string[] redCodes = Method.FormartCode(qianCode, " ").Split(new char[] { ' ' });
                    foreach (string tempRedCode in redCodes)
                    {
                        result += tempRedCode;
                    }
                }
                else
                {
                    char[] M3Dcode = qianCode.ToCharArray();
                    foreach (char tempChar in M3Dcode)
                    {
                        result += tempChar.ToString();
                    }

                    char[] M3DTestCode = MyGridView.DataKeys[e.Row.RowIndex].Values["testcode"].ToString().ToCharArray();
                    foreach (char tempChar in M3DTestCode)
                    {
                        result1 += tempChar.ToString();
                    }

                }

                //����
                if (lottTypeInfoSZ.Length > 1 && !string.IsNullOrEmpty(lottTypeInfoSZ[1]))
                {
                    string[] strInfo2 = lottTypeInfoSZ[1].Split(new char[] { ',' });
                    houCode = MyGridView.DataKeys[e.Row.RowIndex].Values[strInfo2[4]].ToString();



                    if (strInfo2[5] == "��͸��" || strInfo2[5] == "��λ��͸��")
                    {
                        string[] redCodes = Method.FormartCode(houCode, " ").Split(new char[] { ' ' });
                        foreach (string tempRedCode in redCodes)
                        {
                            result += tempRedCode;
                        }
                    }
                    else
                    {
                        char[] M3Dcode = houCode.ToCharArray();
                        foreach (char tempChar in M3Dcode)
                        {
                            result += tempChar.ToString();
                        }
                    }
                }



                ((Label)e.Row.Cells[4].FindControl("lblHao")).Text = result;

                ((Label)e.Row.Cells[1].FindControl("lblHaoTest")).Text = result1;
                #endregion
            }
        }

        /// <summary>
        /// ��ʽ��ʱ��
        /// </summary>
        protected string FormatData(object objDate)
        {
            //string name = GetName();
            //if ("�Ϻ�ʱʱ�� | ����ʱʱ�� | �½�ʱʱ�� | ����ʱʱ�� | ����ʱʱ�� | �㶫����ʮ�� | ��������ʮ�� | ɽ��ȺӢ�� |ɽ��ʮһ�˶�� | �������˶���Ф | �Ϻ����ֲ� | �������ֲ� | �������ֲ� | ���༴�ֲ� | ���Ͽ���123 | �������123 | ����481 | ����481 | ɽ��481 | �����˿� | ɽ���˿� | �������˿� | �Ĵ��˿� | �����˿� | �㽭�˿� | �����˿� | �����˿� | �ӱ��˿� | �����˿� | ɽ���˿� | �����˿� | �����˿�".IndexOf(name) > -1)
            //{
            //    return string.Format("{0:yyyy-MM-dd  HH:mm:ss}", (DateTime)objDate);
            //}
            //else
            //{
            return string.Format("{0:yyyy-MM-dd}", (DateTime)objDate);
            //}
        }
    }
}
