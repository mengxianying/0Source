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
using Maticsoft.DBUtility;

namespace Pbzx.Web.Template
{

    public partial class CstRemote1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDiv();
            }
        }
        /// <summary>
        /// ���ݰ�
        /// </summary>
        private void BindDiv()
        {
            //����xml������Ϣ
            PageConfig pageConfig = WebInit.pageConfig;

            //-------------------�����б�
            Pbzx.BLL.PBnet_Product ProductBll = new Pbzx.BLL.PBnet_Product();
            //��ѯ�ö���SQL���
            //���жϴ�xml�еõ�����ʾ�����Ƿ��ǿ��Ա�2������
            //Ĭ��Ϊ6
            int number_1 = 6;
            int number_2 = 6;
            if (Convert.ToInt32(pageConfig.SoftCount) % 2 == 0)
            {
                number_1 = Convert.ToInt32(pageConfig.SoftCount) / 2;
                number_2 = number_1;
            }
            else
            {
                number_1 = Convert.ToInt32(pageConfig.SoftCount) / 2;
                number_2 = number_1 + 1;
            }

            string tempSql = "select * from(select * from(SELECT TOP " + number_1 + " pb_SoftID, pb_SoftName, pb_SoftVersion, pb_DownloadUrl1, pb_updatetime, 1 AS myType FROM PBnet_Product where " + Method.product + " and PBnet_Softshow=1 ORDER BY 5 DESC) t1 ";
            tempSql += " union ";
            tempSql += "select * from(SELECT TOP " + number_2 + " PBnet_SoftID,  pbnet_SoftName, pbnet_SoftVersion, pb_DownloadUrl1, pb_updatetime, 2 AS myType FROM PBnet_soft where " + Method.soft + " and PBnet_Softshow=1 ORDER BY 5 DESC) t2) t order by t.pb_updatetime desc";
            DataSet dsProduct = DbHelperSQL.Query(tempSql);
            //---------------------------------------------------
            //-------------------����
            Pbzx.BLL.PBnet_Bulletin ProductBll1 = new Pbzx.BLL.PBnet_Bulletin(); //ҵ����ж��Ƿ�����ĸ����ݿ�

            string tempSql1 = "SELECT TOP " + pageConfig.CstCount + " NvarTitle, NvarShortTitle, SavePath,DatDateAndTime FROM PBnet_Bulletin where BitIsPass = 1 and BitIsTop=1 and ShowInSoft=1 order by 4 desc";  //SQL���

            DataSet dsProduct1 = DbHelperSQL.Query(tempSql1);  //��ѯ����������浽DATaSet�С�
            //-----------------------------------------------------
            //�������ö�������û��11��ʱ����ʱ�佫û���ö��Ĳ���
            DataSet dsProduct2 = null;
            if (dsProduct1.Tables[0].Rows.Count < Convert.ToInt32(pageConfig.CstCount))
            {
                string tempSql2 = "SELECT TOP " + (Convert.ToInt32(pageConfig.CstCount) - dsProduct1.Tables[0].Rows.Count) + " NvarTitle, NvarShortTitle, SavePath,DatDateAndTime FROM PBnet_Bulletin where BitIsPass = 1 and BitIsTop=0 and ShowInSoft=1 order by 4 desc";  //SQL���

                dsProduct2 = DbHelperSQL.Query(tempSql2);  //��ѯ����������浽DATaSet�С�
            }
            StringBuilder but = new StringBuilder();

            but.Append("<table width='594px' border='0'  cellpadding='2' cellspacing='1' bgcolor='#C4E1FF'>");

            //����һ���������ж��ĸ����ݼ���
            int number1 = 0;
            //�������������������
            int bli = 0;
            if (dsProduct2 != null)
            {
                if (dsProduct.Tables[0].Rows.Count > dsProduct1.Tables[0].Rows.Count + dsProduct2.Tables[0].Rows.Count)
                {
                    number1 = dsProduct.Tables[0].Rows.Count;
                }
                else
                {
                    number1 = dsProduct1.Tables[0].Rows.Count + dsProduct2.Tables[0].Rows.Count;
                }
            }
            else
            {
                if (dsProduct.Tables[0].Rows.Count > dsProduct1.Tables[0].Rows.Count)
                {
                    number1 = dsProduct.Tables[0].Rows.Count;
                }
                else
                {
                    number1 = dsProduct1.Tables[0].Rows.Count;
                }
            }

            for (int i = 0; i < number1; i++)
            {




                but.Append("<tr height='14px'>");



                but.Append("<td style='width: 255px;' align='left'valign=\"middle\" bgcolor='#FFFFFF'>");

                if (dsProduct.Tables[0].Rows.Count > i)
                {
                    DataRow tempRow = dsProduct.Tables[0].Rows[i];
                    if (tempRow["myType"].ToString() == "1")
                    {
                        but.Append("<a  class='style2'  href='" + WebInit.webBaseConfig.WebUrl + "Soft_explain.aspx?ID=" + Input.Encrypt(tempRow["pb_SoftID"].ToString()) + "' target='_blank' title='" + tempRow["pb_SoftName"].ToString() + "'  > " + TextFormat(tempRow["pb_SoftName"], Convert.ToInt32(pageConfig.SoftLength) * 2) + "</a>");
                    }
                    else
                    {
                        but.Append("<a  class='style2' href='" + WebInit.webBaseConfig.WebUrl + "Source_explain.aspx?ID=" + Input.Encrypt(tempRow["pb_SoftID"].ToString()) + "' target='_blank' title='" + tempRow["pb_SoftName"].ToString() + "' > " + TextFormat(tempRow["pb_SoftName"], Convert.ToInt32(pageConfig.SoftLength) * 2) + "</a>");
                    }
                }
                else
                {

                    but.Append("<font class='style2' >δ����</font>");
                }


                but.Append("</td>");

                but.Append("<td style='width: 40px;' align='center'valign=\"middle\" bgcolor='#FFFFFF'>");
                if (dsProduct.Tables[0].Rows.Count > i)
                {
                    DataRow tempRow = dsProduct.Tables[0].Rows[i];
                    but.Append("<font class='style2'>" + tempRow["pb_SoftVersion"].ToString() + "</font>");
                }
                else
                {

                    but.Append("<font class='style2'>δ����</font>");
                }
                but.Append("</td>");



                but.Append("<td style='width: 299px;' align='left'valign=\"middle\" bgcolor='#FFFFFF'>");


                if (dsProduct1.Tables[0].Rows.Count > i)
                {
                    but.Append("<img src='Images/Web/soft/icon/" + (i + 1) + ".jpg' width='15' height='9px'/>");
                    DataRow tempRow1 = dsProduct1.Tables[0].Rows[i];
                    if (tempRow1["NvarShortTitle"].ToString() != null && tempRow1["NvarShortTitle"].ToString() != "")
                    {
                        but.Append("<a class='style2' style='color:red;'   href='" + tempRow1["SavePath"].ToString() + "'target='_blank' title='" + tempRow1["NvarShortTitle"].ToString() + "' >" + TextFormat(tempRow1["NvarShortTitle"], Convert.ToInt32(pageConfig.CstLength) * 2) + "</a>");
                    }
                    else
                    {
                        but.Append("<a class='style2'  style='color:red;' href='" + tempRow1["SavePath"].ToString() + "'target='_blank' title='" + tempRow1["NvarTitle"].ToString() + "' > " + TextFormat(tempRow1["NvarTitle"], Convert.ToInt32(pageConfig.CstLength) * 2) + "</a>");

                    }

                }
                else
                {
                    but.Append("<img src='Images/Web/soft/icon/" + (i + 1) + ".gif' width='15' height='9px'/>");
                    if (dsProduct2 != null && dsProduct2.Tables.Count > 0 && dsProduct2.Tables[0].Rows.Count + dsProduct1.Tables[0].Rows.Count > i)
                    {
                        DataRow tempRow2 = dsProduct2.Tables[0].Rows[bli];
                        if (tempRow2["NvarShortTitle"].ToString() != null && tempRow2["NvarShortTitle"].ToString() != "")
                        {
                            but.Append("<a class='style2' href='" + tempRow2["SavePath"].ToString() + "'target='_blank' title='" + tempRow2["NvarShortTitle"].ToString() + "' >" + TextFormat(tempRow2["NvarShortTitle"], Convert.ToInt32(pageConfig.CstLength) * 2) + "</a>");
                        }
                        else
                        {
                            but.Append("<a class='style2' href='" + tempRow2["SavePath"].ToString() + "'target='_blank' title='" + tempRow2["NvarTitle"].ToString() + "' >" + TextFormat(tempRow2["NvarTitle"], Convert.ToInt32(pageConfig.CstLength) * 2) + "</a>");

                        }

                        bli++;
                    }
                    else
                    {
                        but.Append("<font class='style2' >δ����</font>");
                    }
                }
                but.Append("</td>");

                but.Append("</tr>");

            }

            but.Append("</table>");

            NewSoft.InnerHtml = but.ToString();
        }

        /// <summary>
        /// ���ݸ�ʽ��
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string TextFormat(object obj, int length)
        {

            string source = obj.ToString();
            if (length <= 0)
            {
                return source;
            }
            else
            {
                int tempLength = Method.GetStrLen(source);
                int charLength = 0;
                int hzLength = 0;

                //string tempResult = "";
                if (tempLength > length)
                {
                    Char[] cc = source.ToCharArray();
                    //int intLen = 0;
                    for (int i = 0; i < cc.Length; i++)
                    {
                        if (Convert.ToInt32(cc[i]) > 255)
                        {
                            hzLength++;

                        }
                        else
                        {
                            charLength++;
                        }

                        if ((hzLength * 2 + charLength) % 2 == 0 && hzLength * 2 + charLength >= length || (hzLength * 2 + charLength) % 2 == 1 && hzLength * 2 + charLength >= length - 1)
                        {
                            break;
                        }
                    }
                    return source.Substring(0, (hzLength + charLength) - 1) + "..";
                }
                else
                {
                    return source;
                }
            }
        }
    }
}
