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
using System.Collections.Generic;

namespace Pbzx.Web.Contorls
{
    public partial class TempletShuangHaoCode : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (MyDataSource != null)
                {
                    CreateTable();
                    tb.Width = (tb.Rows[5].Cells.Count * 20).ToString();   
                }   
            }
        }

        private int _weiShu;

        /// <summary>
        /// 分为几个区间
        /// </summary>
        public int WeiShu
        {
            get { return _weiShu; }
            set { _weiShu = value; }
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


        private string _czName;

        /// <summary>
        /// 彩种名称
        /// </summary>
        public string CzName
        {
            get { return _czName; }
            set { _czName = value; }
        }


        private bool _displayYiLou = true;
        /// <summary>
        /// 是否显示遗漏
        /// </summary>
        public bool DisplayYiLou
        {
            get { return _displayYiLou; }
            set { _displayYiLou = value; }
        }

        private int _minCode = 1;
        /// <summary>
        /// 最小号
        /// </summary>
        public int MinCode
        {
            get { return _minCode; }
            set { _minCode = value; }
        }

        private int _maxCode = 38;
        /// <summary>
        /// 最大号
        /// </summary>
        public int MaxCode
        {
            get { return _maxCode; }
            set { _maxCode = value; }
        }


        private void CreateTable()
        {
            #region 创建表头

            HtmlTableRow rowHead = new HtmlTableRow();
            int[] qjLength = Method.CreateQuJian(MaxCode, MinCode, WeiShu);
           
            //根据循环创建位数表头
            for (int i = 1; i <= qjLength.Length; i++)
            {
                HtmlTableCell cellWeiShuH = new HtmlTableCell();
                cellWeiShuH.ID = "cellWeiShuH" + i.ToString();
                cellWeiShuH.InnerText = Method.NumToHanZi(i) + "区";

                cellWeiShuH.ColSpan = qjLength[i-1];
                cellWeiShuH.Attributes.Add("class", "codebg");
                rowHead.Cells.Add(cellWeiShuH);
            }

   
            //将行添加到表格
            tb.Rows.Add(rowHead);

            HtmlTableRow rowHead2 = new HtmlTableRow();

            int tempStartNum = MinCode;
            //根据位数循环创建位数表头
            for (int i = 1; i <= qjLength.Length; i++)
            {
                for (int j = 0; j < qjLength[i - 1]; j++)
                {                  
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = tempStartNum.ToString();
                    cellH2.Attributes.Add("class", "codebg");
                    rowHead2.Cells.Add(cellH2); 
                    tempStartNum++;
                   
                }
                
            }

            tb.Rows.Add(rowHead2);

            #endregion


            
            //int[] currentYL = new int[qjLength.Length];
            List<int> arrCurrentYL = new List<int>();
            List<int> arrFindCount = new List<int>();
            
            #region 循环创建表行
            int xuhao = 0;
            for (int ik = MyDataSource.Rows.Count - 1; ik >= 0; ik--)
            {
                DataRow row = MyDataSource.Rows[ik];
                ++xuhao;
                HtmlTableRow tempRow = new HtmlTableRow();

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

                int myTempStartCode = MinCode;


                int intFindCountTemp = 0;
                for (int i = 1; i <= qjLength.Length; i++)
                {
                        //循环每个区间的所有单元格                        
                        for (int j = 0; j < qjLength[i-1]; j++)
                        {
                                                 
                            //判断是否是第一行
                            if (xuhao == 1)
                            {
                                arrFindCount.Add(0);       
                                //奖号分布和遗漏列
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //如果是中奖号单元格

                                string[] redCodes = Method.FormartCode(myCode, " ").Split(new char[] { ' ' });

                                string tempShortCode = "";
                                if (myTempStartCode < 10)
                                {
                                    tempShortCode = "0" + myTempStartCode.ToString();
                                }
                                else
                                {
                                    tempShortCode = myTempStartCode.ToString();
                                }

                                //奖号单元格
                                if (Array.IndexOf<string>(redCodes, tempShortCode) != -1)
                                {
                                    arrFindCount[intFindCountTemp]+=1;
                                    cellNei.InnerText = tempShortCode;
                                    if (i % 2 != 0)
                                    {
                                        cellNei.Attributes.Add("class", "JiangHaoJ");
                                    }
                                    else
                                    {
                                        cellNei.Attributes.Add("class", "JiangHaoO");
                                    }
                                   
                                }
                                else//非中奖号单元格（遗漏单元格）
                                {
                                    //如果显示遗漏
                                    if (DisplayYiLou)
                                    {
                                        cellNei.InnerText = "1";
                                    }
                                    else//如果不显示遗漏
                                    {
                                        cellNei.InnerText = " ";
                                    }
                                    if (i % 2 != 0)
                                    {
                                        cellNei.Attributes.Add("class", "ZhengChangJ");
                                    }
                                    else
                                    {
                                        cellNei.Attributes.Add("class", "ZhengChangO");
                                    }
                                }
                                tempRow.Cells.Add(cellNei);
                            }
                            else
                            {
                                //是否是最后一行 用来计算当前遗漏
                                if (xuhao == MyDataSource.Rows.Count)
                                {
                                    arrCurrentYL.Add(0);
                                    //奖号分布和遗漏列
                                    HtmlTableCell cellNei = new HtmlTableCell();

                                    //如果是中奖号单元格,就不必计算上一行此位置单元格的值
                                    string[] redCodes = Method.FormartCode(myCode, " ").Split(new char[] { ' ' });

                                    string tempShortCode = "";
                                    if (myTempStartCode < 10)
                                    {
                                        tempShortCode = "0" + myTempStartCode.ToString();
                                    }
                                    else
                                    {
                                        tempShortCode = myTempStartCode.ToString();
                                    }

                                    //奖号单元格
                                    if (Array.IndexOf<string>(redCodes, tempShortCode) != -1)
                                    {
                                        arrFindCount[intFindCountTemp] += 1;
                                        cellNei.InnerText = tempShortCode;
                                        arrCurrentYL[intFindCountTemp]= 0;
                                        if (i % 2 != 0)
                                        {
                                            cellNei.Attributes.Add("class", "JiangHaoJ");
                                        }
                                        else
                                        {
                                            cellNei.Attributes.Add("class", "JiangHaoO");
                                        }
                                    }
                                    else//非中奖号单元格（遗漏单元格）
                                    {
                                        //如果不显示遗漏，,就不必计算上一行此位置单元格的值
                                        if (!DisplayYiLou)
                                        {
                                            cellNei.InnerText = "";
                                        }
                                        else//如果显示遗漏
                                        {
                                            //得到表格当前行的上一行
                                            HtmlTableRow rowShang = tb.Rows[tb.Rows.Count - 1];
                                            //得到当前单元格的上一行此位置单元格的值，并根据这个值计算出此单元格的值                                                                    
                                            int tempIndex = 0;
                                            if (MinCode == 1)
                                            {
                                                tempIndex = myTempStartCode - 1;
                                            }
                                            else if (MinCode == 0)
                                            {
                                                tempIndex = myTempStartCode;
                                            }
                                            HtmlTableCell CellShang = rowShang.Cells[tempIndex];
                                            //判断当前单元格的上一行此位置单元格是否是中奖号单元格

                                            string tempClassName = "";
                                            if (i % 2 != 0)
                                            {
                                                tempClassName = "JiangHaoJ";
                                            }
                                            else
                                            {
                                                tempClassName = "JiangHaoO";
                                            }
                                            if (CellShang.Attributes["class"] == tempClassName)
                                            {
                                                cellNei.InnerText = "1";
                                            }
                                            else
                                            {
                                                int MytempDD = int.Parse(CellShang.InnerText) + 1;
                                                cellNei.InnerText = MytempDD.ToString();
                                            }

                                        }
                                        if (i % 2 != 0)
                                        {
                                            cellNei.Attributes.Add("class", "ZhengChangJ");
                                        }
                                        else
                                        {
                                            cellNei.Attributes.Add("class", "ZhengChangO");
                                        }
                                         arrCurrentYL[intFindCountTemp] = int.Parse(cellNei.InnerText);
                                    }
                                    tempRow.Cells.Add(cellNei);
                                }
                                else
                                {
                                    //奖号分布和遗漏列
                                    HtmlTableCell cellNei = new HtmlTableCell();

                                    //如果是中奖号单元格,就不必计算上一行此位置单元格的值
                                    string[] redCodes = Method.FormartCode(myCode, " ").Split(new char[] { ' ' });

                                    string tempShortCode = "";
                                    if (myTempStartCode < 10)
                                    {
                                        tempShortCode = "0" + myTempStartCode.ToString();
                                    }
                                    else
                                    {
                                        tempShortCode = myTempStartCode.ToString();
                                    }

                                    //奖号单元格
                                    if (Array.IndexOf<string>(redCodes, tempShortCode) != -1)
                                    {
                                        arrFindCount[intFindCountTemp] += 1;
                                        cellNei.InnerText = tempShortCode;
                                        if (i % 2 != 0)
                                        {
                                            cellNei.Attributes.Add("class", "JiangHaoJ");
                                        }
                                        else
                                        {
                                            cellNei.Attributes.Add("class", "JiangHaoO");
                                        }
                                    }
                                    else//非中奖号单元格（遗漏单元格）
                                    {
                                        //如果不显示遗漏，,就不必计算上一行此位置单元格的值
                                        if (!DisplayYiLou)
                                        {
                                            cellNei.InnerText = "";
                                        }
                                        else//如果显示遗漏
                                        {
                                            //得到表格当前行的上一行
                                            HtmlTableRow rowShang = tb.Rows[tb.Rows.Count - 1];
                                            //得到当前单元格的上一行此位置单元格的值，并根据这个值计算出此单元格的值                                                                    
                                            int tempIndex = 0;
                                            if (MinCode == 1)
                                            {
                                                tempIndex = myTempStartCode - 1;
                                            }
                                            else if (MinCode == 0)
                                            {
                                                tempIndex = myTempStartCode;
                                            }
                                            HtmlTableCell CellShang = rowShang.Cells[tempIndex];
                                            //判断当前单元格的上一行此位置单元格是否是中奖号单元格

                                            string tempClassName = "";
                                            if (i % 2 != 0)
                                            {
                                                tempClassName = "JiangHaoJ";
                                            }
                                            else
                                            {
                                                tempClassName = "JiangHaoO";
                                            }
                                            if (CellShang.Attributes["class"] == tempClassName)
                                            {
                                                cellNei.InnerText = "1";
                                            }
                                            else
                                            {
                                                int MytempDD = int.Parse(CellShang.InnerText) + 1;
                                                cellNei.InnerText = MytempDD.ToString();
                                            }

                                        }
                                        if (i % 2 != 0)
                                        {
                                            cellNei.Attributes.Add("class", "ZhengChangJ");
                                        }
                                        else
                                        {
                                            cellNei.Attributes.Add("class", "ZhengChangO");
                                        }
                                    }
                                    tempRow.Cells.Add(cellNei);
                                }
                            }
                            myTempStartCode++;
                            intFindCountTemp++;
                        }                    
                }                        

                tb.Rows.Add(tempRow);
            }
            #endregion

            ///创建预选行
            HtmlTableRow rowYXHCode = new HtmlTableRow();

            int tempStartNum1 = MinCode;
            //根据位数循环创建位数表头
            for (int i = 1; i <= qjLength.Length; i++)
            {
                for (int j = 0; j < qjLength[i - 1]; j++)
                {
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = "　";                      
                    cellH2.Attributes.Add("class", "ZhengChangJ");
                    cellH2.Style.Add("cursor", "pointer");
                    cellH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='ZhengChangJ'?'" + tempStartNum1.ToString() + "':'　';this.className=this.className=='ZhengChangJ'?'JiangHaoJ':'ZhengChangJ';");
                    rowYXHCode.Cells.Add(cellH2);
                    tempStartNum1++;
                }

            }
            tb.Rows.Add(rowYXHCode);


            ///创建预选行参考
            HtmlTableRow rowYXHCodeCK = new HtmlTableRow();
            int tempStartNum2 = MinCode;
            //根据位数循环创建位数表头
            for (int i = 1; i <= qjLength.Length; i++)
            {
                for (int j = 0; j < qjLength[i - 1]; j++)
                {
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = tempStartNum2.ToString();
                    cellH2.Attributes.Add("class", "codebg");
                   // cellH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='codebg'?'':'" + tempStartNum.ToString() + "';this.className=this.className=='codebg'?'JiangHaoJ':'codebg';");
                    rowYXHCodeCK.Cells.Add(cellH2);
                    tempStartNum2++;
                }
            }
            tb.Rows.Add(rowYXHCodeCK);

            ///创建出现次数行
            HtmlTableRow rowFindCount = new HtmlTableRow();
            int tempNumFindCount = 0;
            //根据位数循环创建位数表头
            for (int i = 1; i <= qjLength.Length; i++)
            {
                for (int j = 0; j < qjLength[i - 1]; j++)
                {
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = arrFindCount[tempNumFindCount].ToString();
                    cellH2.Attributes.Add("class", "ZhengChangcishu");
                    // cellH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='codebg'?'':'" + tempStartNum.ToString() + "';this.className=this.className=='codebg'?'JiangHaoJ':'codebg';");
                    rowFindCount.Cells.Add(cellH2);
                    tempNumFindCount++;
                }
            }
            tb.Rows.Add(rowFindCount);


            ///创建当前遗漏行
            HtmlTableRow rowYLCount = new HtmlTableRow();
            int tempNumYLCount = 0;
            //根据位数循环创建位数表头
            for (int i = 1; i <= qjLength.Length; i++)
            {
                for (int j = 0; j < qjLength[i - 1]; j++)
                {
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = arrCurrentYL[tempNumYLCount].ToString();
                    cellH2.Attributes.Add("class", "codebg");
                    // cellH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='codebg'?'':'" + tempStartNum.ToString() + "';this.className=this.className=='codebg'?'JiangHaoJ':'codebg';");
                    rowYLCount.Cells.Add(cellH2);
                    tempNumYLCount++;
                }
            }
            tb.Rows.Add(rowYLCount);


        }
    }
}