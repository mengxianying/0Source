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
        /// 数据源
        /// </summary>
        public DataTable MyDataSource
        {
            get { return _myDataSource; }
            set { _myDataSource = value; }
        }

        private bool _addXuHao = true;

        /// <summary>
        /// 是否添加序号列
        /// </summary>
        public bool AddXuHao
        {
            get { return _addXuHao; }
            set { _addXuHao = value; }
        }


        private bool _addCode = true;

        /// <summary>
        /// 是否添加号码列
        /// </summary>
        public bool AddCode
        {
            get { return _addCode; }
            set { _addCode = value; }
        }





        private string _czName;

        /// <summary>
        /// 彩种名称
        /// </summary>
        public string CzName
        {
            get { return _czName; }
            set { _czName = value; }
        }


        private void CreateTable()
        {
            #region 创建表头
            HtmlTableRow rowHM = new HtmlTableRow();
            HtmlTableCell cellHM = new HtmlTableCell();
            cellHM.InnerText = "号码表";
            cellHM.ColSpan = 3;
            cellHM.Attributes.Add("class", "codebg");
            rowHM.Cells.Add(cellHM);
            tb.Rows.Add(rowHM);
            HtmlTableRow rowHead = new HtmlTableRow();
            //序号表头单元格
            if(AddXuHao)
            {
                HtmlTableCell cellXuHaoH = new HtmlTableCell();
                cellXuHaoH.InnerText = "序";
               // cellXuHaoH.RowSpan = 2;
                cellXuHaoH.Attributes.Add("class", "codebg");
                //cellXuHaoH.Width = "20%";
                cellXuHaoH.Width = "80px";
                rowHead.Cells.Add(cellXuHaoH);
            }

            //期数表头单元格
            HtmlTableCell cellQiShuH = new HtmlTableCell();
            cellQiShuH.InnerText = "期数";
           // cellQiShuH.RowSpan = 2;
            cellQiShuH.Width = "35%";
            cellQiShuH.Attributes.Add("class", "codebg");
            //if (Convert.ToInt32(cellQiShuH.Width) < 80)
            //{
            //    cellQiShuH.Width = "80";
            //}
            cellQiShuH.Align = "center";
            rowHead.Cells.Add(cellQiShuH);

            //开奖号表头单元格
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.InnerText = "开奖号";
                cellCodeH.Width = "45%";
               // cellCodeH.RowSpan = 2;
                cellCodeH.Attributes.Add("class", "codebg");
                rowHead.Cells.Add(cellCodeH);
            }


           
            //将行添加到表格
            tb.Rows.Add(rowHead);
      
            #endregion

            #region 循环创建表行
            int xuhao = 0;
            for (int ik = MyDataSource.Rows.Count - 1; ik >= 0; ik--)
            {
                DataRow row = MyDataSource.Rows[ik];
                ++xuhao;
                HtmlTableRow tempRow = new HtmlTableRow();
                //序号列
                if (AddXuHao)
                {
                    HtmlTableCell cellXuHao = new HtmlTableCell();
                    cellXuHao.InnerText = xuhao.ToString();
                    cellXuHao.Attributes.Add("class", "codebg");
                    tempRow.Cells.Add(cellXuHao);
                }

                //期数列
                HtmlTableCell cellQiShu = new HtmlTableCell();
                cellQiShu.InnerText = row["issue"].ToString();
                cellQiShu.Attributes.Add("class", "codebg");

                cellQiShu.Align = "center";
                tempRow.Cells.Add(cellQiShu);


                //开奖号
                string myCode = "";
                if (MyDataSource.Columns.Contains("code"))
                {
                    myCode = row["code"].ToString();
                }
                else if (MyDataSource.Columns.Contains("redcode"))
                {
                    myCode = row["redcode"].ToString();
                }
                //特别号码
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

                //如果显示开奖号码列 就创建单元格
                if (AddCode)
                {
                    HtmlTableCell cellCode = new HtmlTableCell();

                    int tempCodeWidth = 0;
                    //判断是否包含code列
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
                    else if (MyDataSource.Columns.Contains("redcode"))//判断是否包含code5这一列
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

                    ///判断是否有特别号码
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


            #region 创建表尾统计行
            ///创建 预选行
            HtmlTableRow rowYXH = new HtmlTableRow();
            HtmlTableCell cellYXH = new HtmlTableCell();
            cellYXH.InnerHtml = "<font  style='font-weight:bold;' >预选行>></font>";
            cellYXH.ColSpan = 3;
            cellYXH.Attributes.Add("class", "codebg");
            rowYXH.Cells.Add(cellYXH);
            tb.Rows.Add(rowYXH);        

            //序 期数，开奖号：

            HtmlTableRow rowFooter = new HtmlTableRow();
            //序号表头单元格
            if (AddXuHao)
            {
                HtmlTableCell cellXuHaoH = new HtmlTableCell();
                cellXuHaoH.InnerText = "序";
                // cellXuHaoH.RowSpan = 2;
                cellXuHaoH.Attributes.Add("class", "codebg");
                cellXuHaoH.Width = "30px";
                rowFooter.Cells.Add(cellXuHaoH);
            }

            //期数表头单元格
            HtmlTableCell cellQiShuHFooter = new HtmlTableCell();
            cellQiShuHFooter.InnerText = "期号";
            // cellQiShuH.RowSpan = 2;
            cellQiShuHFooter.Attributes.Add("class", "codebg");

            rowFooter.Cells.Add(cellQiShuHFooter);

            //开奖号表头单元格
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.InnerText = "开奖号";
                // cellCodeH.RowSpan = 2;
                cellCodeH.Attributes.Add("class", "codebg");
                rowFooter.Cells.Add(cellCodeH);
            }



            //将行添加到表格
            tb.Rows.Add(rowFooter);

            ///创建 发现次数行
            HtmlTableRow rowFindCount = new HtmlTableRow();
            HtmlTableCell cellFindCount = new HtmlTableCell();
            cellFindCount.InnerHtml = "<font  style='font-weight:bold;' >出现次数>></font>";
            cellFindCount.ColSpan = 3;
            cellFindCount.Attributes.Add("class", "codebg");
            rowFindCount.Cells.Add(cellFindCount);
            tb.Rows.Add(rowFindCount);

            ///创建当前遗漏行
            HtmlTableRow rowYLCount = new HtmlTableRow();
            HtmlTableCell cellYLCount = new HtmlTableCell();
            cellYLCount.InnerHtml = "<font  style='font-weight:bold;' >当前遗漏>></font>";
            cellYLCount.ColSpan = 3;
            cellYLCount.Attributes.Add("class", "codebg");
            rowYLCount.Cells.Add(cellYLCount);
            tb.Rows.Add(rowYLCount);
            #endregion


        }
    }
}