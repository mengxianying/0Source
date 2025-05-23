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

namespace Pbzx.Web.Contorls
{
    public partial class TempletShuangHaoIssue : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (MyDataSource != null)
                {
                    CreateTable();
                   
                }   
            }
        }    

        private DataTable _myDataSource;
        /// <summary>
        /// ����Դ
        /// </summary>
        public DataTable MyDataSource
        {
            get { return _myDataSource; }
            set { _myDataSource = value; }
        }

        private bool _addXuHao = true;

        /// <summary>
        /// �Ƿ���������
        /// </summary>
        public bool AddXuHao
        {
            get { return _addXuHao; }
            set { _addXuHao = value; }
        }


        private bool _addCode = true;

        /// <summary>
        /// �Ƿ���Ӻ�����
        /// </summary>
        public bool AddCode
        {
            get { return _addCode; }
            set { _addCode = value; }
        }





        private string _czName;

        /// <summary>
        /// ��������
        /// </summary>
        public string CzName
        {
            get { return _czName; }
            set { _czName = value; }
        }


        private void CreateTable()
        {
            #region ������ͷ
            HtmlTableRow rowHM = new HtmlTableRow();
            HtmlTableCell cellHM = new HtmlTableCell();
            cellHM.InnerText = "�����";
            cellHM.ColSpan = 3;
            cellHM.Attributes.Add("class", "codebg");
            rowHM.Cells.Add(cellHM);
            tb.Rows.Add(rowHM);
            HtmlTableRow rowHead = new HtmlTableRow();
            //��ű�ͷ��Ԫ��
            if(AddXuHao)
            {
                HtmlTableCell cellXuHaoH = new HtmlTableCell();
                cellXuHaoH.InnerText = "��";
               // cellXuHaoH.RowSpan = 2;
                cellXuHaoH.Attributes.Add("class", "codebg");
                //cellXuHaoH.Width = "20%";
                cellXuHaoH.Width = "80px";
                rowHead.Cells.Add(cellXuHaoH);
            }

            //������ͷ��Ԫ��
            HtmlTableCell cellQiShuH = new HtmlTableCell();
            cellQiShuH.InnerText = "����";
           // cellQiShuH.RowSpan = 2;
            cellQiShuH.Width = "35%";
            cellQiShuH.Attributes.Add("class", "codebg");
            //if (Convert.ToInt32(cellQiShuH.Width) < 80)
            //{
            //    cellQiShuH.Width = "80";
            //}
            cellQiShuH.Align = "center";
            rowHead.Cells.Add(cellQiShuH);

            //�����ű�ͷ��Ԫ��
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.InnerText = "������";
                cellCodeH.Width = "45%";
               // cellCodeH.RowSpan = 2;
                cellCodeH.Attributes.Add("class", "codebg");
                rowHead.Cells.Add(cellCodeH);
            }


           
            //������ӵ����
            tb.Rows.Add(rowHead);
      
            #endregion

            #region ѭ����������
            int xuhao = 0;
            for (int ik = MyDataSource.Rows.Count - 1; ik >= 0; ik--)
            {
                DataRow row = MyDataSource.Rows[ik];
                ++xuhao;
                HtmlTableRow tempRow = new HtmlTableRow();
                //�����
                if (AddXuHao)
                {
                    HtmlTableCell cellXuHao = new HtmlTableCell();
                    cellXuHao.InnerText = xuhao.ToString();
                    cellXuHao.Attributes.Add("class", "codebg");
                    tempRow.Cells.Add(cellXuHao);
                }

                //������
                HtmlTableCell cellQiShu = new HtmlTableCell();
                cellQiShu.InnerText = row["issue"].ToString();
                cellQiShu.Attributes.Add("class", "codebg");

                cellQiShu.Align = "center";
                tempRow.Cells.Add(cellQiShu);


                //������
                string myCode = "";
                if (MyDataSource.Columns.Contains("code"))
                {
                    myCode = row["code"].ToString();
                }
                else if (MyDataSource.Columns.Contains("redcode"))
                {
                    myCode = row["redcode"].ToString();
                }
                //�ر����
                string myTcode = "";
                if (MyDataSource.Columns.Contains("tcode"))
                {
                    myTcode = row["tcode"].ToString();
                }
                else if (MyDataSource.Columns.Contains("bluecode"))
                {
                    myTcode = row["bluecode"].ToString();
                }
                else if (MyDataSource.Columns.Contains("code2"))
                {
                    myTcode = row["code2"].ToString();
                }

                //�����ʾ���������� �ʹ�����Ԫ��
                if (AddCode)
                {
                    HtmlTableCell cellCode = new HtmlTableCell();

                    int tempCodeWidth = 0;
                    //�ж��Ƿ����code��
                    if (MyDataSource.Columns.Contains("code"))
                    {
                        string result = "";
                        string[] redCodes = Method.FormartCode(row["code"].ToString(), " ").Split(new char[] { ' ' });
                        foreach (string tempRedCode in redCodes)
                        {
                            result += "" + tempRedCode + "&nbsp;";
                            tempCodeWidth++;
                        }
                        cellCode.InnerHtml = result;
                    }
                    else if (MyDataSource.Columns.Contains("redcode"))//�ж��Ƿ����code5��һ��
                    {
                        string result = "";
                        string[] redCodes = Method.FormartCode(row["redcode"].ToString(), " ").Split(new char[] { ' ' });
                        foreach (string tempRedCode in redCodes)
                        {
                            result += "" + tempRedCode + "&nbsp;";
                            tempCodeWidth++;
                        }
                        cellCode.InnerHtml = result;
                    }

                    ///�ж��Ƿ����ر����
                    if (MyDataSource.Columns.Contains("tcode"))
                    {
                        string result = "";
                        result = row["tcode"].ToString();
                        cellCode.InnerHtml += "+&nbsp;";
                        cellCode.InnerHtml += result;
                        tempCodeWidth++;
                    }
                    else if (MyDataSource.Columns.Contains("bluecode"))
                    {
                        string result = "";
                        result = row["bluecode"].ToString();
                        cellCode.InnerHtml += "+&nbsp;";
                        cellCode.InnerHtml += result;
                        tempCodeWidth++;
                    }
                    else if (MyDataSource.Columns.Contains("code2"))
                    {
                        string[] code2s = Method.FormartCode(row["code2"].ToString(), " ").Split(new char[] { ' ' });
                        string result = "+&nbsp;";
                        foreach (string tempRedCode in code2s)
                        {
                            result += "" + tempRedCode + "&nbsp;";
                            tempCodeWidth++;
                        }
                        cellCode.InnerHtml += result;
                    }
                    
                    cellCode.Attributes.Add("class", "codebgcode");
                    cellCode.Align = "center";
                    tempRow.Cells.Add(cellCode);
                    if(tb.Rows.Count > 3)
                    {
                         tb.Width = ((tb.Rows[3].Cells.Count + tempCodeWidth)  * 24).ToString();   
                    }
                   
                }
                tb.Rows.Add(tempRow);
            }
            #endregion


            #region ������βͳ����
            ///���� Ԥѡ��
            HtmlTableRow rowYXH = new HtmlTableRow();
            HtmlTableCell cellYXH = new HtmlTableCell();
            cellYXH.InnerHtml = "<font  style='font-weight:bold;' >Ԥѡ��>></font>";
            cellYXH.ColSpan = 3;
            cellYXH.Attributes.Add("class", "codebg");
            rowYXH.Cells.Add(cellYXH);
            tb.Rows.Add(rowYXH);        

            //�� �����������ţ�

            HtmlTableRow rowFooter = new HtmlTableRow();
            //��ű�ͷ��Ԫ��
            if (AddXuHao)
            {
                HtmlTableCell cellXuHaoH = new HtmlTableCell();
                cellXuHaoH.InnerText = "��";
                // cellXuHaoH.RowSpan = 2;
                cellXuHaoH.Attributes.Add("class", "codebg");
                cellXuHaoH.Width = "30px";
                rowFooter.Cells.Add(cellXuHaoH);
            }

            //������ͷ��Ԫ��
            HtmlTableCell cellQiShuHFooter = new HtmlTableCell();
            cellQiShuHFooter.InnerText = "�ں�";
            // cellQiShuH.RowSpan = 2;
            cellQiShuHFooter.Attributes.Add("class", "codebg");

            rowFooter.Cells.Add(cellQiShuHFooter);

            //�����ű�ͷ��Ԫ��
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.InnerText = "������";
                // cellCodeH.RowSpan = 2;
                cellCodeH.Attributes.Add("class", "codebg");
                rowFooter.Cells.Add(cellCodeH);
            }



            //������ӵ����
            tb.Rows.Add(rowFooter);

            ///���� ���ִ�����
            HtmlTableRow rowFindCount = new HtmlTableRow();
            HtmlTableCell cellFindCount = new HtmlTableCell();
            cellFindCount.InnerHtml = "<font  style='font-weight:bold;' >���ִ���>></font>";
            cellFindCount.ColSpan = 3;
            cellFindCount.Attributes.Add("class", "codebg");
            rowFindCount.Cells.Add(cellFindCount);
            tb.Rows.Add(rowFindCount);

            ///������ǰ��©��
            HtmlTableRow rowYLCount = new HtmlTableRow();
            HtmlTableCell cellYLCount = new HtmlTableCell();
            cellYLCount.InnerHtml = "<font  style='font-weight:bold;' >��ǰ��©>></font>";
            cellYLCount.ColSpan = 3;
            cellYLCount.Attributes.Add("class", "codebg");
            rowYLCount.Cells.Add(cellYLCount);
            tb.Rows.Add(rowYLCount);
            #endregion


        }
    }
}