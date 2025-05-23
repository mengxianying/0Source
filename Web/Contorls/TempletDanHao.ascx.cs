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
using Maticsoft.DBUtility;

namespace Pbzx.Web.Contorls
{
    public partial class TempletDanHao : System.Web.UI.UserControl
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



        private DataTable _myDataSource;
        /// <summary>
        /// 数据源
        /// </summary>
        public DataTable MyDataSource
        {
            get { return _myDataSource; }
            set { _myDataSource = value; }
        }


        /// <summary>
        /// 位数
        /// </summary>
        public int WeiShu
        {
            get { return _weiShu; }
            set { _weiShu = value; }
        }

        /// <summary>
        /// 是否添加号码列
        /// </summary>
        public bool AddCode
        {
            get { return _addCode; }
            set { _addCode = value; }
        }
        /// <summary>
        /// 是否是排列三
        /// </summary>
        private bool _ISPls = false;
        public bool ISPls
        {
            get { return _ISPls; }
            set { _ISPls = value; }
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

        private bool _addZhiBiao = true;
        /// <summary>
        /// 是否添加指标区(和值，奇偶比，大小比)
        /// </summary>
        public bool AddZhiBiao
        {
            get { return _addZhiBiao; }
            set { _addZhiBiao = value; }
        }

        private bool _addKuaDuZS = true;
        /// <summary>
        /// 是否添加跨度走势
        /// </summary>
        public bool AddKuaDuZS
        {
            get { return _addKuaDuZS; }
            set { _addKuaDuZS = value; }
        }

        private bool _addHeZhiZS = true;
        /// <summary>
        /// 是否添加和值走势
        /// </summary>
        public bool AddHeZhiZS
        {
            get { return _addHeZhiZS; }
            set { _addHeZhiZS = value; }
        }

        private bool _addCode = true;



        private string _czName;

        /// <summary>
        /// 彩种名称
        /// </summary>
        public string CzName
        {
            get { return _czName; }
            set { _czName = value; }
        }



        //private string CheckJQ(int i)
        //{ 
        //    if(i%2 == 0)
        //    {
        //        return "";
        //    }
        //}
        private void CreateTable()
        {
            #region 创建表头
            //开奖号
            string myCodeName = "";
            //特别号码
            string myTcodeName = "";
            //特码最小号
            string minTcode = "";
            //特码最大号
            string maxTcode = "";
            //特码类型
            string tCodeType = "";
            string tCodtTypeName = "";

            string strAllInfo = DbHelperSQL.GetSingle("select top 1 LottTypeInfo from PBnet_LotteryMenu where NvarApp_name='" + CzName + "'  ").ToString();
            string[] lottTypeInfoSZ = strAllInfo.Split(new char[] { '|' });
            string[] strInfo1 = null;
            if (ISPls)
            {
                strInfo1 = lottTypeInfoSZ[1].Split(new char[] { ',' });
            }
            else
            {
                strInfo1 = lottTypeInfoSZ[0].Split(new char[] { ',' });
            }

            myCodeName = strInfo1[4];


            if (lottTypeInfoSZ.Length > 1 && !string.IsNullOrEmpty(lottTypeInfoSZ[1]))
            {
                string[] strInfo2 = lottTypeInfoSZ[1].Split(new char[] { ',' });
                if ("TCPL35Data".ToLower() == CzName.ToLower())
                {
                }
                else
                {
                    myTcodeName = strInfo2[4];
                    minTcode = strInfo2[2];
                    maxTcode = strInfo2[3];
                    tCodeType = strInfo2[5];
                    tCodtTypeName = strInfo2[0];
                }
            }

            //第一行
            HtmlTableRow rowHead = new HtmlTableRow();
            //第二行
            HtmlTableRow rowHead2 = new HtmlTableRow();
            //序号表头单元格

            HtmlTableCell cellXuHaoH = new HtmlTableCell();
            cellXuHaoH.InnerText = "序";

            //Response.Write("<script>DrawLine(document.getElementById('a1'),document.getElementById('a0'));</script>");
            //Response.Write("<script>DrawLine(document.getElementById('b1'),document.getElementById('b0'));</script>");


            cellXuHaoH.RowSpan = 2;
            cellXuHaoH.Attributes.Add("class", "codebg");
            cellXuHaoH.Width = "40px";
            rowHead.Cells.Add(cellXuHaoH);


            //期数表头单元格
            HtmlTableCell cellQiShuH = new HtmlTableCell();
            cellQiShuH.InnerText = "期数";
            cellQiShuH.RowSpan = 2;
            cellQiShuH.Attributes.Add("class", "codebg");
            cellQiShuH.Width = "75px";
            cellQiShuH.Align = "center";
            rowHead.Cells.Add(cellQiShuH);

            if (CzName == "FC3DData")
            {
                //试机号表头单元格
                HtmlTableCell cellShiJiHaoH = new HtmlTableCell();
                cellShiJiHaoH.InnerText = "试机号";
                cellShiJiHaoH.RowSpan = 2;
                cellShiJiHaoH.Attributes.Add("class", "codebg");
                cellShiJiHaoH.Width = "60px";
                cellShiJiHaoH.Align = "center";
                rowHead.Cells.Add(cellShiJiHaoH);

                //机球-机表头单元格
                HtmlTableCell cellJiH = new HtmlTableCell();
                cellJiH.InnerText = "机";
                cellJiH.RowSpan = 2;
                cellJiH.Attributes.Add("class", "codebg");
                cellJiH.Width = "20px";
                cellJiH.Align = "center";
                cellJiH.Visible = false;
                rowHead.Cells.Add(cellJiH);

                //机球-球表头单元格
                HtmlTableCell cellQiuH = new HtmlTableCell();
                cellQiuH.InnerText = "球";
                cellQiuH.RowSpan = 2;
                cellQiuH.Attributes.Add("class", "codebg");
                cellQiuH.Width = "20px";
                cellQiuH.Align = "center";
                cellQiuH.Visible = false;
                rowHead.Cells.Add(cellQiuH);
            }

            //开奖号表头单元格
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.InnerText = "开奖号";
                cellCodeH.RowSpan = 2;
                cellCodeH.Attributes.Add("class", "codebg");
                //if (CzName.ToLower() == "FCP61Data_HD6S".ToLower())
                //{
                //    cellCodeH.Width = "130";
                //}
                cellCodeH.Width = "65px;";
                cellCodeH.Align = "center";
                rowHead.Cells.Add(cellCodeH);
            }

            //根据位数循环创建位数表头
            for (int i = 1; i <= WeiShu; i++)
            {
                HtmlTableCell cellWeiShuH = new HtmlTableCell();
                cellWeiShuH.ID = "cellWeiShuH" + i.ToString();
                cellWeiShuH.InnerText = "第" + Method.NumToHanZi(i) + "位";
                cellWeiShuH.ColSpan = 10;
                cellWeiShuH.Attributes.Add("class", "codebg");
                rowHead.Cells.Add(cellWeiShuH);
            }

            if (AddZhiBiao)
            {
                //和数值表头单元格
                HtmlTableCell cellHeShuH = new HtmlTableCell();
                cellHeShuH.InnerText = "和数值";
                cellHeShuH.RowSpan = 2;
                cellHeShuH.Attributes.Add("class", "codebg");

                cellHeShuH.Align = "center";
                cellHeShuH.Width = "30";

                rowHead.Cells.Add(cellHeShuH);

                // 奇偶比表头单元格
                HtmlTableCell cellJiOuH = new HtmlTableCell();
                cellJiOuH.InnerText = " 奇偶比";
                cellJiOuH.RowSpan = 2;
                cellJiOuH.Attributes.Add("class", "codebg");

                cellJiOuH.Align = "center";
                cellJiOuH.Width = "30";

                rowHead.Cells.Add(cellJiOuH);

                // 大小比表头单元格
                HtmlTableCell cellDaXiaoH = new HtmlTableCell();

                cellDaXiaoH.InnerText = " 大小比";
                cellDaXiaoH.RowSpan = 2;
                cellDaXiaoH.Attributes.Add("class", "codebg");

                cellDaXiaoH.Align = "center";
                cellDaXiaoH.Width = "30";

                rowHead.Cells.Add(cellDaXiaoH);
            }

            //根据位数循环创建位数表头
            for (int i = 1; i <= WeiShu; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = j.ToString();
                    cellH2.Attributes.Add("class", "codebgweishu");
                    rowHead2.Cells.Add(cellH2);
                }
            }


            //如果含有特码 不显示跨度与和值走势
            if (!string.IsNullOrEmpty(myTcodeName))
            {
                AddKuaDuZS = false;
                AddHeZhiZS = false;

                //跨度走势表头单元格
                HtmlTableCell cellKuaDuH = new HtmlTableCell();
                cellKuaDuH.InnerText = tCodtTypeName;
                cellKuaDuH.ColSpan = int.Parse(maxTcode) - int.Parse(minTcode) + 1;
                cellKuaDuH.Attributes.Add("class", "codebg");
                rowHead.Cells.Add(cellKuaDuH);
                for (int tempI = int.Parse(minTcode); tempI <= int.Parse(maxTcode); tempI++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();

                    if (CzName.ToLower() == "FCP61Data_HD6S".ToLower())
                    {
                        cellKDH2.InnerText = "鼠牛虎兔龙蛇马羊猴鸡狗猪".Substring(tempI - 1, 1);
                    }
                    else
                    {
                        cellKDH2.InnerText = tempI.ToString();
                    }
                    cellKDH2.Attributes.Add("class", "bgKuaDuZS");
                    rowHead2.Cells.Add(cellKDH2);
                }

            }
            else
            {
                AddKuaDuZS = true;
                AddHeZhiZS = true;
            }


            if (AddKuaDuZS)
            {
                //跨度走势表头单元格
                HtmlTableCell cellKuaDuH = new HtmlTableCell();
                cellKuaDuH.InnerText = "跨度走势";
                cellKuaDuH.ColSpan = 10;
                cellKuaDuH.Attributes.Add("class", "codebg");
                rowHead.Cells.Add(cellKuaDuH);
            }
            if (AddHeZhiZS)
            {
                //和值走势表头单元格
                HtmlTableCell cellHeZhiZSH = new HtmlTableCell();
                cellHeZhiZSH.InnerText = "和值尾数走势";
                cellHeZhiZSH.ColSpan = 10;
                cellHeZhiZSH.Attributes.Add("class", "codebg");
                rowHead.Cells.Add(cellHeZhiZSH);
            }
            //将行添加到表格
            tb.Rows.Add(rowHead);


            //和值走势表头二
            if (AddHeZhiZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellHZH2 = new HtmlTableCell();
                    cellHZH2.InnerText = j.ToString();
                    cellHZH2.Attributes.Add("class", "bgHeZhiZS");
                    rowHead2.Cells.Add(cellHZH2);
                }
            }

            //跨度走势表头二
            if (AddKuaDuZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();
                    cellKDH2.InnerText = j.ToString();
                    cellKDH2.Attributes.Add("class", "bgKuaDuZS");
                    rowHead2.Cells.Add(cellKDH2);
                }
            }
            tb.Rows.Add(rowHead2);

            #endregion


            List<int> arrCurrentYL = new List<int>();
            List<int> arrFindCount = new List<int>();

            List<int> arrCurrentYL_KD = new List<int>();
            List<int> arrFindCount_KD = new List<int>();

            List<int> arrCurrentYL_Tcode = new List<int>();
            List<int> arrFindCount_Tcode = new List<int>();


            List<int> arrCurrentYL_HZ = new List<int>();
            List<int> arrFindCount_HZ = new List<int>();

            #region 循环创建表行
            int xuhao = 0;

            for (int ik = MyDataSource.Rows.Count - 1; ik >= 0; ik--)
            {
                DataRow row = MyDataSource.Rows[ik];
                ++xuhao;
                string myCode = row["" + myCodeName + ""].ToString();
                string myTcode = "";
                if (!string.IsNullOrEmpty(myTcodeName))
                {
                    myTcode = row["" + myTcodeName + ""].ToString();
                }
                HtmlTableRow tempRow = new HtmlTableRow();
                //td class="codebgxu">
                //                        02</td>
                //                    <td class="codebgri">
                //                        09049</td>
                //                    <td class="codebgcode">
                //                        63865</td>
                //序号列
                HtmlTableCell cellXuHao = new HtmlTableCell();
                cellXuHao.InnerText = xuhao.ToString();
                cellXuHao.Attributes.Add("class", "codebg"); //codebgxu
                cellXuHao.Align = "center";
                tempRow.Cells.Add(cellXuHao);
                //期数列
                HtmlTableCell cellQiShu = new HtmlTableCell();
                cellQiShu.InnerText = row["issue"].ToString();
                cellQiShu.Attributes.Add("class", "codebg");//codebgri
                cellQiShu.Align = "center";
                tempRow.Cells.Add(cellQiShu);

                ///如果是福彩3D添加试机号，机球
                if (CzName == "FC3DData")
                {
                    //试机号表头单元格
                    HtmlTableCell cellShiJiHao = new HtmlTableCell();
                    cellShiJiHao.InnerText = row["testcode"].ToString();
                    cellShiJiHao.Attributes.Add("class", "codebgcode");
                    cellShiJiHao.Width = "60px";
                    cellShiJiHao.Align = "center";
                    tempRow.Cells.Add(cellShiJiHao);

                    //机球-机表头单元格
                    HtmlTableCell cellJi = new HtmlTableCell();
                    cellJi.InnerText = row["machine"].ToString();
                    cellJi.Attributes.Add("class", "codebg");
                    cellJi.Width = "20px";
                    cellJi.Visible = false;
                    cellJi.Align = "center";
                    tempRow.Cells.Add(cellJi);

                    //机球-球表头单元格
                    HtmlTableCell cellQiu = new HtmlTableCell();
                    cellQiu.InnerText = row["ball"].ToString();
                    cellQiu.Attributes.Add("class", "codebg");
                    cellQiu.Width = "20px";
                    cellQiu.Align = "center";
                    cellQiu.Visible = false;
                    tempRow.Cells.Add(cellQiu);
                }



                ///开奖号列                

                //如果显示开奖号码列 就创建单元格
                if (AddCode)
                {
                    HtmlTableCell cellCode = new HtmlTableCell();


                    string result = "";
                    //号码1
                    char[] M3Dcode = myCode.ToCharArray();
                    if (M3Dcode.Length > 1)
                    {
                        foreach (char tempChar in M3Dcode)
                        {
                            result += "" + tempChar.ToString() + "";
                        }
                    }

                    //号码2
                    if (!string.IsNullOrEmpty(myTcode))
                    {
                        if (CzName.ToLower() == "FCP61Data_HD6S".ToLower())
                        {
                            string sx = "鼠牛虎兔龙蛇马羊猴鸡狗猪";
                            result += "+" + sx.Substring(int.Parse(myTcode) - 1, 1);
                        }
                        else
                        {
                            result += "+" + myTcode;
                        }
                    }

                    cellCode.InnerHtml = "<div style='overflow:hidden; text-overflow:ellipsis;white-space:nowrap; width:100%'>" + result + "</div> ";

                    cellCode.Attributes.Add("class", "codebgcode");
                    cellCode.Align = "center";
                    tempRow.Cells.Add(cellCode);
                }

                int intFindCountTemp = 0;
                ///奖号分布,循环位数
                #region
                for (int i = 1; i <= WeiShu; i++)
                {
                    string XianCodePrefix = "abcdefghijklmnopqrstuvwxyz".Substring(i, 1);
                    //循环0-9个单元格                        
                    for (int j = 0; j <= 9; j++)
                    {
                        //判断是否是第一行
                        if (xuhao == 1)
                        {
                            arrFindCount.Add(0);
                            //奖号分布和遗漏列
                            HtmlTableCell cellNei = new HtmlTableCell();

                            //如果是中奖号单元格
                            if (myCode.Substring(i - 1, 1) == j.ToString())
                            {
                                arrFindCount[intFindCountTemp] += 1;
                                cellNei.InnerText = j.ToString();
                                if (i % 2 == 0)
                                {
                                    cellNei.Attributes.Add("class", "JiangHaoO");
                                }
                                else
                                {
                                    cellNei.Attributes.Add("class", "JiangHaoJ");
                                }
                                cellNei.ID = XianCodePrefix + xuhao.ToString();
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
                                    cellNei.InnerText = "";
                                }
                                if (i % 2 == 0)
                                {
                                    cellNei.Attributes.Add("class", "ZhengChangO");
                                }
                                else
                                {
                                    cellNei.Attributes.Add("class", "ZhengChangJ");
                                }
                            }
                            tempRow.Cells.Add(cellNei);
                        }
                        else //不是第一行
                        {
                            //最后一行 用来统计遗漏
                            if (xuhao == MyDataSource.Rows.Count)
                            {
                                arrCurrentYL.Add(0);
                                //奖号分布和遗漏列
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //如果是中奖号单元格,就不必计算上一行此位置单元格的值
                                if (myCode.Substring(i - 1, 1) == j.ToString())
                                {
                                    arrFindCount[intFindCountTemp] += 1;
                                    arrCurrentYL[intFindCountTemp] = 0;
                                    //cellNei.InnerText = j.ToString();
                                    if (i % 2 == 0)
                                    {
                                        cellNei.Attributes.Add("class", "JiangHaoO");
                                    }
                                    else
                                    {
                                        cellNei.Attributes.Add("class", "JiangHaoJ");
                                    }
                                    string tempMyXian = "";
                                    if (i % 2 == 0)
                                    {
                                        cellNei.Attributes.Add("class", "JiangHaoO");
                                        tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#1266BB');</script>";
                                    }
                                    else
                                    {
                                        cellNei.Attributes.Add("class", "JiangHaoJ");
                                        tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#C30003');</script>";
                                    }
                                    cellNei.ID = XianCodePrefix + xuhao.ToString();
                                    //string tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'));</script>";
                                    cellNei.InnerHtml = j.ToString() + tempMyXian;
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
                                        if (AddCode)
                                        {
                                            //当前单元格的上一行此位置单元格
                                            int index = 3;

                                            if (CzName == "FC3DData")
                                            {
                                                index += 3;
                                            }



                                            index = (i - 1) * 10 + index;
                                            HtmlTableCell CellShang = rowShang.Cells[index + j];
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
                                        else
                                        {
                                            //当前单元格的上一行此位置单元格
                                            int index = 2;

                                            if (CzName == "FC3DData")
                                            {
                                                index += 3;
                                            }
                                            index = (i - 1) * 10 + index;

                                            HtmlTableCell CellShang = rowShang.Cells[index + j];
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
                                    }

                                    if (i % 2 == 0)
                                    {
                                        cellNei.Attributes.Add("class", "ZhengChangO");
                                    }
                                    else
                                    {
                                        cellNei.Attributes.Add("class", "ZhengChangJ");
                                    }
                                    arrCurrentYL[intFindCountTemp] = int.Parse(cellNei.InnerText);
                                }
                                tempRow.Cells.Add(cellNei);
                            }
                            else //非最后一行
                            {
                                //奖号分布和遗漏列
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //如果是中奖号单元格,就不必计算上一行此位置单元格的值
                                if (myCode.Substring(i - 1, 1) == j.ToString())
                                {
                                    arrFindCount[intFindCountTemp] += 1;
                                    //cellNei.InnerText = j.ToString();

                                    string tempMyXian = "";
                                    if (i % 2 == 0)
                                    {
                                        cellNei.Attributes.Add("class", "JiangHaoO");
                                        tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#1266BB');</script>";

                                    }
                                    else
                                    {
                                        cellNei.Attributes.Add("class", "JiangHaoJ");
                                        tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#C30003');</script>";
                                    }
                                    cellNei.ID = XianCodePrefix + xuhao.ToString();

                                    cellNei.InnerHtml = j.ToString() + tempMyXian;
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
                                        if (AddCode)
                                        {
                                            //当前单元格的上一行此位置单元格
                                            int index = 3;
                                            if (CzName == "FC3DData")
                                            {
                                                index += 3;
                                            }
                                            index = (i - 1) * 10 + index;



                                            HtmlTableCell CellShang = rowShang.Cells[index + j];
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
                                        else
                                        {

                                            //当前单元格的上一行此位置单元格
                                            int index = 2;
                                            if (CzName == "FC3DData")
                                            {
                                                index += 3;
                                            }

                                            index = (i - 1) * 10 + index;
                                            HtmlTableCell CellShang = rowShang.Cells[index + j];
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
                                    }

                                    if (i % 2 == 0)
                                    {
                                        cellNei.Attributes.Add("class", "ZhengChangO");
                                    }
                                    else
                                    {
                                        cellNei.Attributes.Add("class", "ZhengChangJ");
                                    }
                                }
                                tempRow.Cells.Add(cellNei);
                            }

                        }
                        intFindCountTemp++;
                    }

                }
                #endregion

                //添加指标区
                if (AddZhiBiao)
                {
                    int he = 0;
                    int jiGe = 0;
                    int ouGe = 0;
                    int DaGe = 0;
                    int xiaoGe = 0;
                    //计算奇偶比、大小比、和值
                    for (int i = 0; i < myCode.Length; i++)
                    {
                        int tempIntCode = int.Parse(myCode.Substring(i, 1).ToString());
                        if (tempIntCode % 2 == 0)
                        {
                            ouGe += 1;
                        }
                        else
                        {
                            jiGe += 1;
                        }
                        if (tempIntCode >= 5)
                        {
                            DaGe += 1;
                        }
                        else
                        {
                            xiaoGe += 1;
                        }
                        he += tempIntCode;
                    }

                    //创建和值单元格
                    HtmlTableCell cellHeZhi = new HtmlTableCell();

                    cellHeZhi.InnerText = he.ToString();
                    cellHeZhi.Attributes.Add("class", "codebghes");

                    cellHeZhi.Align = "center";


                    tempRow.Cells.Add(cellHeZhi);
                    //创建奇偶比单元格
                    HtmlTableCell cellJiOuBi = new HtmlTableCell();
                    cellJiOuBi.InnerText = jiGe + ":" + ouGe;
                    cellJiOuBi.Attributes.Add("class", "codebgjiou");
                    cellJiOuBi.Align = "center";
                    tempRow.Cells.Add(cellJiOuBi);

                    //创建大小比单元格
                    HtmlTableCell cellDaXiaoBi = new HtmlTableCell();
                    cellDaXiaoBi.InnerText = DaGe + ":" + xiaoGe;
                    cellDaXiaoBi.Attributes.Add("class", "codebgdax");
                    cellDaXiaoBi.Align = "center";
                    tempRow.Cells.Add(cellDaXiaoBi);
                }



                #region 创建特别号码列
                //如果含有特码 不显示跨度与和值走势
                if (!string.IsNullOrEmpty(myTcodeName))
                {
                    AddKuaDuZS = false;
                    AddHeZhiZS = false;


                    int intFindCountTempKD = 0;
                    string XianCodePrefix = "TM";
                    for (int tempI = int.Parse(minTcode); tempI <= int.Parse(maxTcode); tempI++)
                    {

                        //判断是否是第一行
                        if (xuhao == 1)
                        {
                            arrFindCount_Tcode.Add(0);
                            //奖号分布和遗漏列
                            HtmlTableCell cellNei = new HtmlTableCell();

                            //如果是中奖号单元格
                            if (int.Parse(myTcode) == tempI)
                            {
                                arrFindCount_Tcode[intFindCountTempKD] += 1;
                                if (CzName.ToLower() == "FCP61Data_HD6S".ToLower())
                                {
                                    cellNei.InnerText = "鼠牛虎兔龙蛇马羊猴鸡狗猪".Substring(tempI - 1, 1);
                                }
                                else
                                {
                                    cellNei.InnerText = tempI.ToString();
                                }
                                cellNei.Attributes.Add("class", "JiangHaoJ");
                                cellNei.ID = XianCodePrefix + xuhao.ToString();
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
                                    cellNei.InnerText = "";
                                }
                                cellNei.Attributes.Add("class", "ZhengChangJ");
                            }
                            tempRow.Cells.Add(cellNei);
                        }
                        else
                        {
                            //最后一行 用来统计遗漏
                            if (xuhao == MyDataSource.Rows.Count)
                            {
                                arrCurrentYL_Tcode.Add(0);
                                //奖号分布和遗漏列
                                HtmlTableCell cellNei = new HtmlTableCell();
                                //如果是中奖号单元格,就不必计算上一行此位置单元格的值
                                if (int.Parse(myTcode) == tempI)
                                {
                                    arrFindCount_Tcode[intFindCountTempKD] += 1;
                                    arrCurrentYL_Tcode[intFindCountTempKD] = 0;
                                    string strMyTempHQ = "";
                                    if (CzName.ToLower() == "FCP61Data_HD6S".ToLower())
                                    {
                                        strMyTempHQ = "鼠牛虎兔龙蛇马羊猴鸡狗猪".Substring(tempI - 1, 1);
                                        cellNei.InnerText = strMyTempHQ;
                                    }
                                    else
                                    {
                                        strMyTempHQ = tempI.ToString();
                                        cellNei.InnerText = strMyTempHQ;
                                    }

                                    string tempMyXian = "";
                                    //if (tempI % 2 == 0)
                                    //{
                                    //    cellNei.Attributes.Add("class", "JiangHaoO");
                                    //    tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#1266BB');</script>";
                                    //}
                                    //else
                                    //{
                                    cellNei.Attributes.Add("class", "JiangHaoJ");
                                    //tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#C30003');</script>";
                                    //}
                                    cellNei.ID = XianCodePrefix + xuhao.ToString();
                                    //string tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'));</script>";
                                    cellNei.InnerHtml = strMyTempHQ + tempMyXian;



                                    cellNei.Attributes.Add("class", "JiangHaoJ");
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
                                        int intIndex = 0;
                                        if (AddCode && AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 6;
                                        }
                                        else if (AddCode && !AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 3;
                                        }
                                        else if (!AddCode && AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 5;
                                        }
                                        else
                                        {
                                            intIndex = WeiShu * 10 + 2;
                                        }

                                        if (CzName == "FC3DData")
                                        {
                                            intIndex += 3;
                                        }


                                        HtmlTableCell CellShang = null;
                                        if (minTcode == "1")
                                        {
                                            CellShang = rowShang.Cells[intIndex + tempI - 1];
                                        }
                                        else
                                        {
                                            CellShang = rowShang.Cells[intIndex + tempI];
                                        }

                                        //判断当前单元格的上一行此位置单元格是否是中奖号单元格
                                        if (CellShang.Attributes["class"] == "JiangHaoJ")
                                        {
                                            cellNei.InnerText = "1";
                                        }
                                        else
                                        {
                                            int MytempDD = int.Parse(CellShang.InnerText) + 1;
                                            cellNei.InnerText = MytempDD.ToString();
                                        }
                                    }
                                    cellNei.Attributes.Add("class", "ZhengChangJ");
                                    arrCurrentYL_Tcode[intFindCountTempKD] = int.Parse(cellNei.InnerText);
                                }
                                tempRow.Cells.Add(cellNei);
                            }
                            else //不是最后一行
                            {
                                //奖号分布和遗漏列
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //如果是中奖号单元格,就不必计算上一行此位置单元格的值
                                if (int.Parse(myTcode) == tempI)
                                {
                                    arrFindCount_Tcode[intFindCountTempKD] += 1;
                                    string strMyTempHQ = "";
                                    if (CzName.ToLower() == "FCP61Data_HD6S".ToLower())
                                    {
                                        strMyTempHQ = "鼠牛虎兔龙蛇马羊猴鸡狗猪".Substring(tempI - 1, 1);
                                        cellNei.InnerText = strMyTempHQ;
                                    }
                                    else
                                    {
                                        strMyTempHQ = tempI.ToString();
                                        cellNei.InnerText = strMyTempHQ;
                                    }
                                    cellNei.Attributes.Add("class", "JiangHaoJ");
                                    string tempMyXian = "";
                                    //if (tempI % 2 == 0)
                                    //{
                                    //    cellNei.Attributes.Add("class", "JiangHaoO");
                                    //    tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#1266BB');</script>";
                                    //}
                                    //else
                                    //{
                                    cellNei.Attributes.Add("class", "JiangHaoJ");
                                    //tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#C30003');</script>";
                                    //}
                                    cellNei.ID = XianCodePrefix + xuhao.ToString();
                                    //string tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'));</script>";
                                    cellNei.InnerHtml = strMyTempHQ + tempMyXian;
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
                                        int intIndex = 0;
                                        if (AddCode && AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 6;
                                        }
                                        else if (AddCode && !AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 3;
                                        }
                                        else if (!AddCode && AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 5;
                                        }
                                        else
                                        {
                                            intIndex = WeiShu * 10 + 2;
                                        }
                                        if (CzName == "FC3DData")
                                        {
                                            intIndex += 3;
                                        }

                                        HtmlTableCell CellShang = null;
                                        if (minTcode == "1")
                                        {
                                            CellShang = rowShang.Cells[intIndex + tempI - 1];
                                        }
                                        else
                                        {
                                            CellShang = rowShang.Cells[intIndex + tempI];
                                        }

                                        //判断当前单元格的上一行此位置单元格是否是中奖号单元格
                                        if (CellShang.Attributes["class"] == "JiangHaoJ")
                                        {
                                            cellNei.InnerText = "1";
                                        }
                                        else
                                        {
                                            int MytempDD = int.Parse(CellShang.InnerText) + 1;
                                            cellNei.InnerText = MytempDD.ToString();
                                        }
                                    }
                                    cellNei.Attributes.Add("class", "ZhengChangJ");
                                }
                                tempRow.Cells.Add(cellNei);
                            }
                        }
                        intFindCountTempKD++;
                    }

                }
                else
                {
                    AddKuaDuZS = true;
                    AddHeZhiZS = true;
                }
                #endregion

                #region 跨度走势
                if (AddKuaDuZS)
                {
                    int maxInt = int.Parse(myCode.Substring(0, 1));
                    int minInt = int.Parse(myCode.Substring(0, 1));
                    for (int i = 0; i < myCode.Length; i++)
                    {

                        int tempDaXiao = int.Parse(myCode.Substring(i, 1).ToString());
                        if (tempDaXiao > maxInt)
                        {
                            maxInt = tempDaXiao;
                        }
                        if (tempDaXiao < minInt)
                        {
                            minInt = tempDaXiao;
                        }
                    }
                    int kuaDu = maxInt - minInt;
                    //循环0-9个单元格
                    int intFindCountTempKD = 0;
                    string XianCodePrefix = "kd";
                    for (int j = 0; j <= 9; j++)
                    {

                        //判断是否是第一行
                        if (xuhao == 1)
                        {
                            arrFindCount_KD.Add(0);
                            //奖号分布和遗漏列
                            HtmlTableCell cellNei = new HtmlTableCell();

                            //如果是中奖号单元格
                            if (kuaDu == j)
                            {
                                arrFindCount_KD[intFindCountTempKD] += 1;
                                cellNei.InnerText = j.ToString();
                                cellNei.Attributes.Add("class", "JiangHaoJ");
                                cellNei.ID = XianCodePrefix + xuhao.ToString();
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
                                    cellNei.InnerText = "";
                                }
                                cellNei.Attributes.Add("class", "ZhengChangJ");
                            }

                            tempRow.Cells.Add(cellNei);
                        }
                        else
                        {
                            //最后一行 用来统计遗漏
                            if (xuhao == MyDataSource.Rows.Count)
                            {
                                arrCurrentYL_KD.Add(0);
                                //奖号分布和遗漏列
                                HtmlTableCell cellNei = new HtmlTableCell();
                                //如果是中奖号单元格,就不必计算上一行此位置单元格的值
                                if (kuaDu == j)
                                {
                                    arrFindCount_KD[intFindCountTempKD] += 1;
                                    arrCurrentYL_KD[intFindCountTempKD] = 0;
                                    cellNei.InnerText = j.ToString();
                                    cellNei.Attributes.Add("class", "JiangHaoJ");
                                    string tempMyXian = "";



                                    cellNei.Attributes.Add("class", "JiangHaoJ");
                                    tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#C30003');</script>";




                                    cellNei.ID = XianCodePrefix + xuhao.ToString();
                                    //string tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'));</script>";
                                    cellNei.InnerHtml = j.ToString() + tempMyXian;
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
                                        int intIndex = 0;
                                        if (AddCode && AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 6;
                                        }
                                        else if (AddCode && !AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 3;
                                        }
                                        else if (!AddCode && AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 5;
                                        }
                                        else
                                        {
                                            intIndex = WeiShu * 10 + 2;
                                        }

                                        if (CzName == "FC3DData")
                                        {
                                            intIndex += 3;
                                        }


                                        HtmlTableCell CellShang = rowShang.Cells[intIndex + j];
                                        //判断当前单元格的上一行此位置单元格是否是中奖号单元格
                                        if (CellShang.Attributes["class"] == "JiangHaoJ")
                                        {
                                            cellNei.InnerText = "1";
                                        }
                                        else
                                        {
                                            int MytempDD = int.Parse(CellShang.InnerText) + 1;
                                            cellNei.InnerText = MytempDD.ToString();
                                        }
                                    }
                                    cellNei.Attributes.Add("class", "ZhengChangJ");
                                    arrCurrentYL_KD[intFindCountTempKD] = int.Parse(cellNei.InnerText);
                                }
                                tempRow.Cells.Add(cellNei);
                            }
                            else //不是最后一行
                            {
                                //奖号分布和遗漏列
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //如果是中奖号单元格,就不必计算上一行此位置单元格的值
                                if (kuaDu == j)
                                {
                                    arrFindCount_KD[intFindCountTempKD] += 1;
                                    cellNei.InnerText = j.ToString();
                                    cellNei.Attributes.Add("class", "JiangHaoJ");
                                    string tempMyXian = "";
                                    //if (j % 2 == 0)
                                    //{
                                    //    cellNei.Attributes.Add("class", "JiangHaoJ");
                                    //    tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#1266BB');</script>";
                                    //}
                                    //else
                                    //{
                                    cellNei.Attributes.Add("class", "JiangHaoJ");
                                    tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#C30003');</script>";
                                    //}
                                    cellNei.ID = XianCodePrefix + xuhao.ToString();
                                    //string tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'));</script>";
                                    cellNei.InnerHtml = j.ToString() + tempMyXian;
                                    //cellNei.InnerText = j.ToString();
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
                                        int intIndex = 0;
                                        if (AddCode && AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 6;
                                        }
                                        else if (AddCode && !AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 3;
                                        }
                                        else if (!AddCode && AddZhiBiao)
                                        {
                                            intIndex = WeiShu * 10 + 5;
                                        }
                                        else
                                        {
                                            intIndex = WeiShu * 10 + 2;
                                        }

                                        if (CzName == "FC3DData")
                                        {
                                            intIndex += 3;
                                        }

                                        HtmlTableCell CellShang = rowShang.Cells[intIndex + j];
                                        //判断当前单元格的上一行此位置单元格是否是中奖号单元格
                                        if (CellShang.Attributes["class"] == "JiangHaoJ")
                                        {
                                            cellNei.InnerText = "1";
                                        }
                                        else
                                        {
                                            int MytempDD = int.Parse(CellShang.InnerText) + 1;
                                            cellNei.InnerText = MytempDD.ToString();
                                        }
                                    }
                                    cellNei.Attributes.Add("class", "ZhengChangJ");
                                }
                                tempRow.Cells.Add(cellNei);
                            }
                        }

                        intFindCountTempKD++;
                    }
                }
                #endregion



                #region  和值尾数走势
                if (AddHeZhiZS)
                {

                    int he = 0;
                    //计算奇偶比、大小比、和值
                    for (int i = 0; i < myCode.Length; i++)
                    {
                        int tempIntCode = int.Parse(myCode.Substring(i, 1).ToString());
                        he += tempIntCode;
                    }
                    string strHe = he.ToString();
                    int heWei = int.Parse(strHe.Substring(strHe.Length - 1, 1));

                    int intFindCountTempHZ = 0;
                    string XianCodePrefix = "hz";
                    //循环0-9个单元格                        
                    for (int j = 0; j <= 9; j++)
                    {

                        //判断是否是第一行
                        if (xuhao == 1)
                        {
                            arrFindCount_HZ.Add(0);
                            //奖号分布和遗漏列
                            HtmlTableCell cellNei = new HtmlTableCell();
                            //如果是中奖号单元格
                            if (heWei == j)
                            {
                                arrFindCount_HZ[intFindCountTempHZ] += 1;
                                cellNei.InnerText = j.ToString();
                                cellNei.Attributes.Add("class", "JiangHaoO");
                                cellNei.ID = XianCodePrefix + xuhao.ToString();
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
                                    cellNei.InnerText = "";
                                }
                                cellNei.Attributes.Add("class", "ZhengChangO");
                            }

                            tempRow.Cells.Add(cellNei);
                        }
                        else
                        {
                            //最后一行 用来统计遗漏
                            if (xuhao == MyDataSource.Rows.Count)
                            {
                                arrCurrentYL_HZ.Add(0);
                                //奖号分布和遗漏列
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //如果是中奖号单元格,就不必计算上一行此位置单元格的值
                                if (heWei == j)
                                {
                                    arrFindCount_HZ[intFindCountTempHZ] += 1;
                                    arrCurrentYL_HZ[intFindCountTempHZ] = 0;
                                    cellNei.InnerText = j.ToString();
                                    cellNei.Attributes.Add("class", "JiangHaoO");
                                    string tempMyXian = "";
                                    //if (j % 2 == 0)
                                    //{
                                    cellNei.Attributes.Add("class", "JiangHaoO");
                                    tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#1266BB');</script>";
                                    //}
                                    //else
                                    //{
                                    //    cellNei.Attributes.Add("class", "JiangHaoO");
                                    //    tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#C30003');</script>";
                                    //}
                                    cellNei.ID = XianCodePrefix + xuhao.ToString();
                                    //string tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'));</script>";
                                    cellNei.InnerHtml = j.ToString() + tempMyXian;
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
                                        //组合原理 C21*C21*C21 = 8 种情况
                                        int intIndex = 0;
                                        if (AddCode && AddZhiBiao && AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 6 + 10;
                                        }
                                        else if (AddCode && AddZhiBiao && !AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 3 + 3;
                                        }
                                        else if (AddCode && !AddZhiBiao && !AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 3;
                                        }
                                        else if (!AddCode && !AddZhiBiao && !AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 2;
                                        }
                                        else if (!AddCode && !AddZhiBiao && AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 2 + 10;
                                        }
                                        else if (!AddCode && AddZhiBiao && AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 2 + 10 + 3;
                                        }
                                        else if (!AddCode && AddZhiBiao && !AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 2 + 3;
                                        }
                                        else if (AddCode && !AddZhiBiao && AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 10 + 3;
                                        }

                                        if (CzName == "FC3DData")
                                        {
                                            intIndex += 3;
                                        }



                                        HtmlTableCell CellShang = rowShang.Cells[intIndex + j];
                                        //判断当前单元格的上一行此位置单元格是否是中奖号单元格
                                        if (CellShang.Attributes["class"] == "JiangHaoO")
                                        {
                                            cellNei.InnerText = "1";
                                        }
                                        else
                                        {
                                            int MytempDD = int.Parse(CellShang.InnerText) + 1;
                                            cellNei.InnerText = MytempDD.ToString();
                                        }
                                    }
                                    cellNei.Attributes.Add("class", "ZhengChangO");
                                    arrCurrentYL_HZ[intFindCountTempHZ] = int.Parse(cellNei.InnerText);
                                }
                                tempRow.Cells.Add(cellNei);
                            }
                            else
                            {
                                //奖号分布和遗漏列
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //如果是中奖号单元格,就不必计算上一行此位置单元格的值
                                if (heWei == j)
                                {
                                    arrFindCount_HZ[intFindCountTempHZ] += 1;
                                    cellNei.InnerText = j.ToString();
                                    cellNei.Attributes.Add("class", "JiangHaoO");
                                    string tempMyXian = "";
                                    //if (j % 2 == 0)
                                    //{
                                    cellNei.Attributes.Add("class", "JiangHaoO");
                                    tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#1266BB');</script>";
                                    //}
                                    //else
                                    //{
                                    //    cellNei.Attributes.Add("class", "JiangHaoO");
                                    //    tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'),'#C30003');</script>";
                                    //}
                                    cellNei.ID = XianCodePrefix + xuhao.ToString();
                                    //string tempMyXian = "<script>DrawLine(document.getElementById('TempletDanHao1_" + XianCodePrefix + xuhao.ToString() + "'),document.getElementById('TempletDanHao1_" + XianCodePrefix + Convert.ToString(xuhao - 1) + "'));</script>";
                                    cellNei.InnerHtml = j.ToString() + tempMyXian;
                                    //cellNei.InnerText = j.ToString();

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
                                        //组合原理 C21*C21*C21 = 8 种情况
                                        int intIndex = 0;
                                        if (AddCode && AddZhiBiao && AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 6 + 10;
                                        }
                                        else if (AddCode && AddZhiBiao && !AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 3 + 3;
                                        }
                                        else if (AddCode && !AddZhiBiao && !AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 3;
                                        }
                                        else if (!AddCode && !AddZhiBiao && !AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 2;
                                        }
                                        else if (!AddCode && !AddZhiBiao && AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 2 + 10;
                                        }
                                        else if (!AddCode && AddZhiBiao && AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 2 + 10 + 3;
                                        }
                                        else if (!AddCode && AddZhiBiao && !AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 2 + 3;
                                        }
                                        else if (AddCode && !AddZhiBiao && AddKuaDuZS)
                                        {
                                            intIndex = WeiShu * 10 + 10 + 3;
                                        }

                                        if (CzName == "FC3DData")
                                        {
                                            intIndex += 3;
                                        }
                                        HtmlTableCell CellShang = rowShang.Cells[intIndex + j];
                                        //判断当前单元格的上一行此位置单元格是否是中奖号单元格
                                        if (CellShang.Attributes["class"] == "JiangHaoO")
                                        {
                                            cellNei.InnerText = "1";
                                        }
                                        else
                                        {
                                            int MytempDD = int.Parse(CellShang.InnerText) + 1;
                                            cellNei.InnerText = MytempDD.ToString();
                                        }
                                    }
                                    cellNei.Attributes.Add("class", "ZhengChangO");
                                }
                                tempRow.Cells.Add(cellNei);
                            }
                        }
                        intFindCountTempHZ++;
                    }
                }
                #endregion

                tb.Rows.Add(tempRow);
            }
            #endregion






            #region 创建预选行表头

            HtmlTableRow rowYXH = new HtmlTableRow();

            //序号表头单元格

            //HtmlTableCell cellYXH_XH = new HtmlTableCell();
            //cellYXH_XH.InnerText = "";
            //cellYXH_XH.Attributes.Add("class", "codebg");
            //rowYXH.Cells.Add(cellYXH_XH);
            //期数表头单元格
            //HtmlTableCell cellYXH_QH = new HtmlTableCell();
            //cellYXH_QH.InnerText = "";
            //cellYXH_QH.Attributes.Add("class", "codebg");
            //rowYXH.Cells.Add(cellYXH_QH);

            //开奖号表头单元格
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.InnerHtml = "<b>预选行>></b>";
                cellCodeH.ColSpan = 3;

                if (CzName == "FC3DData")
                {
                    cellCodeH.ColSpan = 3 + 1;
                }


                cellCodeH.Attributes.Add("class", "codebg");
                rowYXH.Cells.Add(cellCodeH);
            }

            //根据位数循环创建位数表头
            for (int i = 1; i <= WeiShu; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = "　";
                    cellH2.Attributes.Add("class", "codebgweishu");
                    cellH2.Style.Add("cursor", "pointer");
                    cellH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='codebgweishu'?'" + j.ToString() + "':'　';this.className=this.className=='codebgweishu'?'JiangHaoJ':'codebgweishu';");
                    rowYXH.Cells.Add(cellH2);
                }
            }



            if (AddZhiBiao)
            {
                //和数值表头单元格
                HtmlTableCell cellHeShuH = new HtmlTableCell();
                cellHeShuH.InnerText = "";
                cellHeShuH.Attributes.Add("class", "codebg");
                cellHeShuH.Align = "center";
                cellHeShuH.Width = "30";
                rowYXH.Cells.Add(cellHeShuH);

                // 奇偶比表头单元格
                HtmlTableCell cellJiOuH = new HtmlTableCell();
                cellJiOuH.InnerText = "";
                cellJiOuH.Attributes.Add("class", "codebg");

                cellJiOuH.Align = "center";
                cellJiOuH.Width = "30";

                rowYXH.Cells.Add(cellJiOuH);

                // 大小比表头单元格
                HtmlTableCell cellDaXiaoH = new HtmlTableCell();
                cellDaXiaoH.InnerText = "";
                cellDaXiaoH.Attributes.Add("class", "codebg");

                cellDaXiaoH.Align = "center";
                cellDaXiaoH.Width = "30";

                rowYXH.Cells.Add(cellDaXiaoH);
            }



            //如果含有特码 不显示跨度与和值走势预选
            if (!string.IsNullOrEmpty(myTcodeName))
            {
                AddKuaDuZS = false;
                AddHeZhiZS = false;
                for (int tempI = int.Parse(minTcode); tempI <= int.Parse(maxTcode); tempI++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();
                    cellKDH2.InnerText = "　";
                    cellKDH2.Attributes.Add("class", "bgKuaDuZS");
                    cellKDH2.Style.Add("cursor", "pointer");
                    cellKDH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='bgKuaDuZS'?'" + tempI.ToString() + "':'　';this.className=this.className=='bgKuaDuZS'?'JiangHaoJ':'bgKuaDuZS';");
                    rowYXH.Cells.Add(cellKDH2);
                }
            }
            else
            {
                AddKuaDuZS = true;
                AddHeZhiZS = true;
            }
            //跨度走势预选
            if (AddKuaDuZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();

                    cellKDH2.InnerText = "　";
                    cellKDH2.Attributes.Add("class", "bgKuaDuZS");
                    cellKDH2.Style.Add("cursor", "pointer");
                    cellKDH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='bgKuaDuZS'?'" + j.ToString() + "':'　';this.className=this.className=='bgKuaDuZS'?'JiangHaoJ':'bgKuaDuZS';");
                    rowYXH.Cells.Add(cellKDH2);
                }
            }
            //和值走势预选
            if (AddHeZhiZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellHZH2 = new HtmlTableCell();
                    cellHZH2.InnerText = "　";
                    cellHZH2.Attributes.Add("class", "bgHeZhiZS");
                    cellHZH2.Style.Add("cursor", "pointer");
                    cellHZH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='bgHeZhiZS'?'" + j.ToString() + "':'　';this.className=this.className=='bgHeZhiZS'?'JiangHaoJ':'bgHeZhiZS';");
                    rowYXH.Cells.Add(cellHZH2);
                }
            }
            tb.Rows.Add(rowYXH);

            #endregion


            #region 创建参考行表头

            HtmlTableRow rowYXHCodeCK = new HtmlTableRow();

            //序号表头单元格

            HtmlTableCell cellXuHaoH_CK = new HtmlTableCell();
            cellXuHaoH_CK.InnerText = "序";
            cellXuHaoH_CK.Attributes.Add("class", "codebg");
            rowYXHCodeCK.Cells.Add(cellXuHaoH_CK);
            //期数表头单元格
            HtmlTableCell cellQiShuH_CK = new HtmlTableCell();
            cellQiShuH_CK.InnerText = "期数";
            cellQiShuH_CK.Attributes.Add("class", "codebg");
            rowYXHCodeCK.Cells.Add(cellQiShuH_CK);




            if (CzName == "FC3DData")
            {
                //试机号表头单元格
                HtmlTableCell cellShiJiHaoH_CK = new HtmlTableCell();
                cellShiJiHaoH_CK.InnerText = "试机号";
                cellShiJiHaoH_CK.Attributes.Add("class", "codebg");
                cellShiJiHaoH_CK.Width = "60px";
                cellShiJiHaoH_CK.Align = "center";
                rowYXHCodeCK.Cells.Add(cellShiJiHaoH_CK);

                //机球-机表头单元格
                HtmlTableCell cellJiH_CK = new HtmlTableCell();
                cellJiH_CK.InnerText = "机";
                cellJiH_CK.Attributes.Add("class", "codebg");
                cellJiH_CK.Width = "20px";
                cellJiH_CK.Align = "center";
                cellJiH_CK.Visible = false;
                rowYXHCodeCK.Cells.Add(cellJiH_CK);

                //机球-球表头单元格
                HtmlTableCell cellQiuH_CK = new HtmlTableCell();
                cellQiuH_CK.InnerText = "球";
                cellQiuH_CK.Attributes.Add("class", "codebg");
                cellQiuH_CK.Width = "20px";
                cellQiuH_CK.Align = "center";
                cellQiuH_CK.Visible = false;
                rowYXHCodeCK.Cells.Add(cellQiuH_CK);
            }




            //开奖号表头单元格
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.InnerText = "开奖号";
                cellCodeH.Attributes.Add("class", "codebg");
                rowYXHCodeCK.Cells.Add(cellCodeH);
            }

            //根据位数循环创建位数表头
            for (int i = 1; i <= WeiShu; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = j.ToString();
                    cellH2.Attributes.Add("class", "codebgbtm");
                    rowYXHCodeCK.Cells.Add(cellH2);
                }
            }



            if (AddZhiBiao)
            {
                //和数值表头单元格
                HtmlTableCell cellHeShuH = new HtmlTableCell();
                cellHeShuH.InnerText = "";
                cellHeShuH.Attributes.Add("class", "codebgbtm");
                rowYXHCodeCK.Cells.Add(cellHeShuH);

                // 奇偶比表头单元格
                HtmlTableCell cellJiOuH = new HtmlTableCell();
                cellJiOuH.InnerText = "";
                cellJiOuH.Attributes.Add("class", "codebgbtm");
                rowYXHCodeCK.Cells.Add(cellJiOuH);

                // 大小比表头单元格
                HtmlTableCell cellDaXiaoH = new HtmlTableCell();
                cellDaXiaoH.InnerText = "";
                cellDaXiaoH.Attributes.Add("class", "codebgbtm");
                rowYXHCodeCK.Cells.Add(cellDaXiaoH);
            }


            //如果含有特码 不显示跨度与和值走势参考行
            if (!string.IsNullOrEmpty(myTcodeName))
            {
                AddKuaDuZS = false;
                AddHeZhiZS = false;
                for (int tempI = int.Parse(minTcode); tempI <= int.Parse(maxTcode); tempI++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();
                    cellKDH2.InnerText = tempI.ToString();
                    cellKDH2.Attributes.Add("class", "codebgbtm");
                    rowYXHCodeCK.Cells.Add(cellKDH2);
                }
            }
            else
            {
                AddKuaDuZS = true;
                AddHeZhiZS = true;
            }

            //跨度走势参考行
            if (AddKuaDuZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();
                    cellKDH2.InnerText = j.ToString();
                    cellKDH2.Attributes.Add("class", "codebgbtm");
                    rowYXHCodeCK.Cells.Add(cellKDH2);
                }
            }
            //和值走势参考行
            if (AddHeZhiZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellHZH2 = new HtmlTableCell();
                    cellHZH2.InnerText = j.ToString();
                    cellHZH2.Attributes.Add("class", "codebgbtm");
                    rowYXHCodeCK.Cells.Add(cellHZH2);
                }
            }

            tb.Rows.Add(rowYXHCodeCK);

            #endregion

            #region 创建出现次数行表头

            HtmlTableRow rowFindCount = new HtmlTableRow();

            //序号表头单元格
            //HtmlTableCell cellFindCount_XH = new HtmlTableCell();
            //cellFindCount_XH.InnerText = "";
            //cellFindCount_XH.Attributes.Add("class", "codebg");
            //rowFindCount.Cells.Add(cellFindCount_XH);

            ////HtmlTableCell cellFindCount_XH1 = new HtmlTableCell();
            ////cellFindCount_XH1.InnerText = "";
            ////cellFindCount_XH1.Attributes.Add("class", "codebg");
            ////rowFindCount.Cells.Add(cellFindCount_XH1);


            ////期数表头单元格
            //HtmlTableCell cellFindCount_QH = new HtmlTableCell();
            //cellFindCount_QH.InnerText = "";
            //cellFindCount_QH.Attributes.Add("class", "codebg");
            //rowFindCount.Cells.Add(cellFindCount_QH);

            //开奖号表头单元格
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.ColSpan = 3;
                if (CzName == "FC3DData")
                {
                    cellCodeH.ColSpan = 3 + 1;
                }
                cellCodeH.InnerHtml = "<b>当前出现次数>></b>";
                cellCodeH.Attributes.Add("class", "codebg");
                rowFindCount.Cells.Add(cellCodeH);
            }

            //根据位数循环创建位数表头
            int findCount = 0;
            for (int i = 1; i <= WeiShu; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = arrFindCount[findCount].ToString();
                    cellH2.Attributes.Add("class", "codebgweishu");
                    rowFindCount.Cells.Add(cellH2);
                    findCount++;
                }
            }



            if (AddZhiBiao)
            {
                //和数值表头单元格
                HtmlTableCell cellHeShuH = new HtmlTableCell();
                cellHeShuH.InnerText = "";
                cellHeShuH.Attributes.Add("class", "codebg");
                rowFindCount.Cells.Add(cellHeShuH);

                // 奇偶比表头单元格
                HtmlTableCell cellJiOuH = new HtmlTableCell();
                cellJiOuH.InnerText = "";
                cellJiOuH.Attributes.Add("class", "codebg");
                rowFindCount.Cells.Add(cellJiOuH);

                // 大小比表头单元格
                HtmlTableCell cellDaXiaoH = new HtmlTableCell();
                cellDaXiaoH.InnerText = "";
                cellDaXiaoH.Attributes.Add("class", "codebg");
                rowFindCount.Cells.Add(cellDaXiaoH);
            }

            int findCountTcode = 0;
            //如果含有特码 不显示跨度与和值走势出现次数
            if (!string.IsNullOrEmpty(myTcodeName))
            {
                AddKuaDuZS = false;
                AddHeZhiZS = false;
                for (int tempI = int.Parse(minTcode); tempI <= int.Parse(maxTcode); tempI++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();
                    cellKDH2.InnerText = arrFindCount_Tcode[findCountTcode].ToString();
                    cellKDH2.Attributes.Add("class", "bgKuaDuZS");
                    rowFindCount.Cells.Add(cellKDH2);
                    findCountTcode++;
                }
            }
            else
            {
                AddKuaDuZS = true;
                AddHeZhiZS = true;
            }

            int findCountKD = 0;
            //跨度走势出现次数
            if (AddKuaDuZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();
                    cellKDH2.InnerText = arrFindCount_KD[findCountKD].ToString();
                    cellKDH2.Attributes.Add("class", "bgKuaDuZS");
                    rowFindCount.Cells.Add(cellKDH2);
                    findCountKD++;
                }
            }


            int findCountHZ = 0;
            //和值走势出现次数
            if (AddHeZhiZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellHZH2 = new HtmlTableCell();
                    cellHZH2.InnerText = arrFindCount_HZ[findCountHZ].ToString();
                    cellHZH2.Attributes.Add("class", "bgHeZhiZS");
                    rowFindCount.Cells.Add(cellHZH2);
                    findCountHZ++;
                }
            }

            tb.Rows.Add(rowFindCount);

            #endregion


            #region 创建当前遗漏行表头

            HtmlTableRow rowCurrentYL = new HtmlTableRow();

            //序号表头单元格

            ////HtmlTableCell cellCurrentYL_XH = new HtmlTableCell();
            ////cellCurrentYL_XH.InnerText = "";
            ////cellCurrentYL_XH.Attributes.Add("class", "codebg");
            ////rowCurrentYL.Cells.Add(cellCurrentYL_XH);


            ////期数表头单元格
            //HtmlTableCell cellCurrentYL_QH = new HtmlTableCell();
            //cellCurrentYL_QH.InnerText = "";
            //cellCurrentYL_QH.Attributes.Add("class", "codebg");
            //rowCurrentYL.Cells.Add(cellCurrentYL_QH);

            //开奖号表头单元格
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.ColSpan = 3;
                if (CzName == "FC3DData")
                {
                    cellCodeH.ColSpan = 3 + 1;
                }

                cellCodeH.InnerHtml = "<b>当前遗漏>></b>";
                cellCodeH.Attributes.Add("class", "codebg");
                rowCurrentYL.Cells.Add(cellCodeH);
            }

            int ylCount = 0;
            //根据位数循环创建位数表头
            for (int i = 1; i <= WeiShu; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = arrCurrentYL[ylCount].ToString();
                    cellH2.Attributes.Add("class", "codebgbtm");
                    rowCurrentYL.Cells.Add(cellH2);
                    ylCount++;
                }
            }



            if (AddZhiBiao)
            {
                //和数值表头单元格
                HtmlTableCell cellHeShuH = new HtmlTableCell();
                cellHeShuH.InnerText = "";
                cellHeShuH.Attributes.Add("class", "codebgbtm");
                rowCurrentYL.Cells.Add(cellHeShuH);

                // 奇偶比表头单元格
                HtmlTableCell cellJiOuH = new HtmlTableCell();
                cellJiOuH.InnerText = "";
                cellJiOuH.Attributes.Add("class", "codebgbtm");
                rowCurrentYL.Cells.Add(cellJiOuH);

                // 大小比表头单元格
                HtmlTableCell cellDaXiaoH = new HtmlTableCell();
                cellDaXiaoH.InnerText = "";
                cellDaXiaoH.Attributes.Add("class", "codebgbtm");
                rowCurrentYL.Cells.Add(cellDaXiaoH);
            }


            //如果含有特码 不显示跨度与和值走势遗漏行
            int ylCountTcode = 0;
            if (!string.IsNullOrEmpty(myTcodeName))
            {
                AddKuaDuZS = false;
                AddHeZhiZS = false;
                for (int tempI = int.Parse(minTcode); tempI <= int.Parse(maxTcode); tempI++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();
                    cellKDH2.InnerText = arrCurrentYL_Tcode[ylCountTcode].ToString();
                    cellKDH2.Attributes.Add("class", "codebgbtm");
                    rowCurrentYL.Cells.Add(cellKDH2);
                    ylCountTcode++;
                }
            }
            else
            {
                AddKuaDuZS = true;
                AddHeZhiZS = true;
            }


            //跨度遗漏行
            int ylCountKD = 0;
            if (AddKuaDuZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();
                    cellKDH2.InnerText = arrCurrentYL_KD[ylCountKD].ToString();
                    cellKDH2.Attributes.Add("class", "codebgbtm");
                    rowCurrentYL.Cells.Add(cellKDH2);
                    ylCountKD++;
                }
            }


            int ylCountHZ = 0;
            //和值遗漏行
            if (AddHeZhiZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellHZH2 = new HtmlTableCell();
                    cellHZH2.InnerText = arrCurrentYL_HZ[j].ToString();
                    cellHZH2.Attributes.Add("class", "codebgbtm");
                    rowCurrentYL.Cells.Add(cellHZH2);
                    ylCountHZ++;
                }
            }

            tb.Rows.Add(rowCurrentYL);

            #endregion






        }


    }
}

