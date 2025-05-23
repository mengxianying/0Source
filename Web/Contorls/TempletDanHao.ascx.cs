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
        /// ����Դ
        /// </summary>
        public DataTable MyDataSource
        {
            get { return _myDataSource; }
            set { _myDataSource = value; }
        }


        /// <summary>
        /// λ��
        /// </summary>
        public int WeiShu
        {
            get { return _weiShu; }
            set { _weiShu = value; }
        }

        /// <summary>
        /// �Ƿ���Ӻ�����
        /// </summary>
        public bool AddCode
        {
            get { return _addCode; }
            set { _addCode = value; }
        }
        /// <summary>
        /// �Ƿ���������
        /// </summary>
        private bool _ISPls = false;
        public bool ISPls
        {
            get { return _ISPls; }
            set { _ISPls = value; }
        }


        private bool _displayYiLou = true;
        /// <summary>
        /// �Ƿ���ʾ��©
        /// </summary>
        public bool DisplayYiLou
        {
            get { return _displayYiLou; }
            set { _displayYiLou = value; }
        }

        private bool _addZhiBiao = true;
        /// <summary>
        /// �Ƿ����ָ����(��ֵ����ż�ȣ���С��)
        /// </summary>
        public bool AddZhiBiao
        {
            get { return _addZhiBiao; }
            set { _addZhiBiao = value; }
        }

        private bool _addKuaDuZS = true;
        /// <summary>
        /// �Ƿ���ӿ������
        /// </summary>
        public bool AddKuaDuZS
        {
            get { return _addKuaDuZS; }
            set { _addKuaDuZS = value; }
        }

        private bool _addHeZhiZS = true;
        /// <summary>
        /// �Ƿ���Ӻ�ֵ����
        /// </summary>
        public bool AddHeZhiZS
        {
            get { return _addHeZhiZS; }
            set { _addHeZhiZS = value; }
        }

        private bool _addCode = true;



        private string _czName;

        /// <summary>
        /// ��������
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
            #region ������ͷ
            //������
            string myCodeName = "";
            //�ر����
            string myTcodeName = "";
            //������С��
            string minTcode = "";
            //��������
            string maxTcode = "";
            //��������
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

            //��һ��
            HtmlTableRow rowHead = new HtmlTableRow();
            //�ڶ���
            HtmlTableRow rowHead2 = new HtmlTableRow();
            //��ű�ͷ��Ԫ��

            HtmlTableCell cellXuHaoH = new HtmlTableCell();
            cellXuHaoH.InnerText = "��";

            //Response.Write("<script>DrawLine(document.getElementById('a1'),document.getElementById('a0'));</script>");
            //Response.Write("<script>DrawLine(document.getElementById('b1'),document.getElementById('b0'));</script>");


            cellXuHaoH.RowSpan = 2;
            cellXuHaoH.Attributes.Add("class", "codebg");
            cellXuHaoH.Width = "40px";
            rowHead.Cells.Add(cellXuHaoH);


            //������ͷ��Ԫ��
            HtmlTableCell cellQiShuH = new HtmlTableCell();
            cellQiShuH.InnerText = "����";
            cellQiShuH.RowSpan = 2;
            cellQiShuH.Attributes.Add("class", "codebg");
            cellQiShuH.Width = "75px";
            cellQiShuH.Align = "center";
            rowHead.Cells.Add(cellQiShuH);

            if (CzName == "FC3DData")
            {
                //�Ի��ű�ͷ��Ԫ��
                HtmlTableCell cellShiJiHaoH = new HtmlTableCell();
                cellShiJiHaoH.InnerText = "�Ի���";
                cellShiJiHaoH.RowSpan = 2;
                cellShiJiHaoH.Attributes.Add("class", "codebg");
                cellShiJiHaoH.Width = "60px";
                cellShiJiHaoH.Align = "center";
                rowHead.Cells.Add(cellShiJiHaoH);

                //����-����ͷ��Ԫ��
                HtmlTableCell cellJiH = new HtmlTableCell();
                cellJiH.InnerText = "��";
                cellJiH.RowSpan = 2;
                cellJiH.Attributes.Add("class", "codebg");
                cellJiH.Width = "20px";
                cellJiH.Align = "center";
                cellJiH.Visible = false;
                rowHead.Cells.Add(cellJiH);

                //����-���ͷ��Ԫ��
                HtmlTableCell cellQiuH = new HtmlTableCell();
                cellQiuH.InnerText = "��";
                cellQiuH.RowSpan = 2;
                cellQiuH.Attributes.Add("class", "codebg");
                cellQiuH.Width = "20px";
                cellQiuH.Align = "center";
                cellQiuH.Visible = false;
                rowHead.Cells.Add(cellQiuH);
            }

            //�����ű�ͷ��Ԫ��
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.InnerText = "������";
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

            //����λ��ѭ������λ����ͷ
            for (int i = 1; i <= WeiShu; i++)
            {
                HtmlTableCell cellWeiShuH = new HtmlTableCell();
                cellWeiShuH.ID = "cellWeiShuH" + i.ToString();
                cellWeiShuH.InnerText = "��" + Method.NumToHanZi(i) + "λ";
                cellWeiShuH.ColSpan = 10;
                cellWeiShuH.Attributes.Add("class", "codebg");
                rowHead.Cells.Add(cellWeiShuH);
            }

            if (AddZhiBiao)
            {
                //����ֵ��ͷ��Ԫ��
                HtmlTableCell cellHeShuH = new HtmlTableCell();
                cellHeShuH.InnerText = "����ֵ";
                cellHeShuH.RowSpan = 2;
                cellHeShuH.Attributes.Add("class", "codebg");

                cellHeShuH.Align = "center";
                cellHeShuH.Width = "30";

                rowHead.Cells.Add(cellHeShuH);

                // ��ż�ȱ�ͷ��Ԫ��
                HtmlTableCell cellJiOuH = new HtmlTableCell();
                cellJiOuH.InnerText = " ��ż��";
                cellJiOuH.RowSpan = 2;
                cellJiOuH.Attributes.Add("class", "codebg");

                cellJiOuH.Align = "center";
                cellJiOuH.Width = "30";

                rowHead.Cells.Add(cellJiOuH);

                // ��С�ȱ�ͷ��Ԫ��
                HtmlTableCell cellDaXiaoH = new HtmlTableCell();

                cellDaXiaoH.InnerText = " ��С��";
                cellDaXiaoH.RowSpan = 2;
                cellDaXiaoH.Attributes.Add("class", "codebg");

                cellDaXiaoH.Align = "center";
                cellDaXiaoH.Width = "30";

                rowHead.Cells.Add(cellDaXiaoH);
            }

            //����λ��ѭ������λ����ͷ
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


            //����������� ����ʾ������ֵ����
            if (!string.IsNullOrEmpty(myTcodeName))
            {
                AddKuaDuZS = false;
                AddHeZhiZS = false;

                //������Ʊ�ͷ��Ԫ��
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
                        cellKDH2.InnerText = "��ţ������������Ｆ����".Substring(tempI - 1, 1);
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
                //������Ʊ�ͷ��Ԫ��
                HtmlTableCell cellKuaDuH = new HtmlTableCell();
                cellKuaDuH.InnerText = "�������";
                cellKuaDuH.ColSpan = 10;
                cellKuaDuH.Attributes.Add("class", "codebg");
                rowHead.Cells.Add(cellKuaDuH);
            }
            if (AddHeZhiZS)
            {
                //��ֵ���Ʊ�ͷ��Ԫ��
                HtmlTableCell cellHeZhiZSH = new HtmlTableCell();
                cellHeZhiZSH.InnerText = "��ֵβ������";
                cellHeZhiZSH.ColSpan = 10;
                cellHeZhiZSH.Attributes.Add("class", "codebg");
                rowHead.Cells.Add(cellHeZhiZSH);
            }
            //������ӵ����
            tb.Rows.Add(rowHead);


            //��ֵ���Ʊ�ͷ��
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

            //������Ʊ�ͷ��
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

            #region ѭ����������
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
                //�����
                HtmlTableCell cellXuHao = new HtmlTableCell();
                cellXuHao.InnerText = xuhao.ToString();
                cellXuHao.Attributes.Add("class", "codebg"); //codebgxu
                cellXuHao.Align = "center";
                tempRow.Cells.Add(cellXuHao);
                //������
                HtmlTableCell cellQiShu = new HtmlTableCell();
                cellQiShu.InnerText = row["issue"].ToString();
                cellQiShu.Attributes.Add("class", "codebg");//codebgri
                cellQiShu.Align = "center";
                tempRow.Cells.Add(cellQiShu);

                ///����Ǹ���3D����Ի��ţ�����
                if (CzName == "FC3DData")
                {
                    //�Ի��ű�ͷ��Ԫ��
                    HtmlTableCell cellShiJiHao = new HtmlTableCell();
                    cellShiJiHao.InnerText = row["testcode"].ToString();
                    cellShiJiHao.Attributes.Add("class", "codebgcode");
                    cellShiJiHao.Width = "60px";
                    cellShiJiHao.Align = "center";
                    tempRow.Cells.Add(cellShiJiHao);

                    //����-����ͷ��Ԫ��
                    HtmlTableCell cellJi = new HtmlTableCell();
                    cellJi.InnerText = row["machine"].ToString();
                    cellJi.Attributes.Add("class", "codebg");
                    cellJi.Width = "20px";
                    cellJi.Visible = false;
                    cellJi.Align = "center";
                    tempRow.Cells.Add(cellJi);

                    //����-���ͷ��Ԫ��
                    HtmlTableCell cellQiu = new HtmlTableCell();
                    cellQiu.InnerText = row["ball"].ToString();
                    cellQiu.Attributes.Add("class", "codebg");
                    cellQiu.Width = "20px";
                    cellQiu.Align = "center";
                    cellQiu.Visible = false;
                    tempRow.Cells.Add(cellQiu);
                }



                ///��������                

                //�����ʾ���������� �ʹ�����Ԫ��
                if (AddCode)
                {
                    HtmlTableCell cellCode = new HtmlTableCell();


                    string result = "";
                    //����1
                    char[] M3Dcode = myCode.ToCharArray();
                    if (M3Dcode.Length > 1)
                    {
                        foreach (char tempChar in M3Dcode)
                        {
                            result += "" + tempChar.ToString() + "";
                        }
                    }

                    //����2
                    if (!string.IsNullOrEmpty(myTcode))
                    {
                        if (CzName.ToLower() == "FCP61Data_HD6S".ToLower())
                        {
                            string sx = "��ţ������������Ｆ����";
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
                ///���ŷֲ�,ѭ��λ��
                #region
                for (int i = 1; i <= WeiShu; i++)
                {
                    string XianCodePrefix = "abcdefghijklmnopqrstuvwxyz".Substring(i, 1);
                    //ѭ��0-9����Ԫ��                        
                    for (int j = 0; j <= 9; j++)
                    {
                        //�ж��Ƿ��ǵ�һ��
                        if (xuhao == 1)
                        {
                            arrFindCount.Add(0);
                            //���ŷֲ�����©��
                            HtmlTableCell cellNei = new HtmlTableCell();

                            //������н��ŵ�Ԫ��
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
                            else//���н��ŵ�Ԫ����©��Ԫ��
                            {
                                //�����ʾ��©
                                if (DisplayYiLou)
                                {
                                    cellNei.InnerText = "1";
                                }
                                else//�������ʾ��©
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
                        else //���ǵ�һ��
                        {
                            //���һ�� ����ͳ����©
                            if (xuhao == MyDataSource.Rows.Count)
                            {
                                arrCurrentYL.Add(0);
                                //���ŷֲ�����©��
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //������н��ŵ�Ԫ��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
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
                                else//���н��ŵ�Ԫ����©��Ԫ��
                                {
                                    //�������ʾ��©��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
                                    if (!DisplayYiLou)
                                    {
                                        cellNei.InnerText = "";
                                    }
                                    else//�����ʾ��©
                                    {
                                        //�õ����ǰ�е���һ��
                                        HtmlTableRow rowShang = tb.Rows[tb.Rows.Count - 1];
                                        //�õ���ǰ��Ԫ�����һ�д�λ�õ�Ԫ���ֵ�����������ֵ������˵�Ԫ���ֵ                             
                                        if (AddCode)
                                        {
                                            //��ǰ��Ԫ�����һ�д�λ�õ�Ԫ��
                                            int index = 3;

                                            if (CzName == "FC3DData")
                                            {
                                                index += 3;
                                            }



                                            index = (i - 1) * 10 + index;
                                            HtmlTableCell CellShang = rowShang.Cells[index + j];
                                            //�жϵ�ǰ��Ԫ�����һ�д�λ�õ�Ԫ���Ƿ����н��ŵ�Ԫ��
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
                                            //��ǰ��Ԫ�����һ�д�λ�õ�Ԫ��
                                            int index = 2;

                                            if (CzName == "FC3DData")
                                            {
                                                index += 3;
                                            }
                                            index = (i - 1) * 10 + index;

                                            HtmlTableCell CellShang = rowShang.Cells[index + j];
                                            //�жϵ�ǰ��Ԫ�����һ�д�λ�õ�Ԫ���Ƿ����н��ŵ�Ԫ��
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
                            else //�����һ��
                            {
                                //���ŷֲ�����©��
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //������н��ŵ�Ԫ��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
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
                                else//���н��ŵ�Ԫ����©��Ԫ��
                                {
                                    //�������ʾ��©��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
                                    if (!DisplayYiLou)
                                    {
                                        cellNei.InnerText = "";
                                    }
                                    else//�����ʾ��©
                                    {
                                        //�õ����ǰ�е���һ��
                                        HtmlTableRow rowShang = tb.Rows[tb.Rows.Count - 1];
                                        //�õ���ǰ��Ԫ�����һ�д�λ�õ�Ԫ���ֵ�����������ֵ������˵�Ԫ���ֵ                             
                                        if (AddCode)
                                        {
                                            //��ǰ��Ԫ�����һ�д�λ�õ�Ԫ��
                                            int index = 3;
                                            if (CzName == "FC3DData")
                                            {
                                                index += 3;
                                            }
                                            index = (i - 1) * 10 + index;



                                            HtmlTableCell CellShang = rowShang.Cells[index + j];
                                            //�жϵ�ǰ��Ԫ�����һ�д�λ�õ�Ԫ���Ƿ����н��ŵ�Ԫ��
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

                                            //��ǰ��Ԫ�����һ�д�λ�õ�Ԫ��
                                            int index = 2;
                                            if (CzName == "FC3DData")
                                            {
                                                index += 3;
                                            }

                                            index = (i - 1) * 10 + index;
                                            HtmlTableCell CellShang = rowShang.Cells[index + j];
                                            //�жϵ�ǰ��Ԫ�����һ�д�λ�õ�Ԫ���Ƿ����н��ŵ�Ԫ��
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

                //���ָ����
                if (AddZhiBiao)
                {
                    int he = 0;
                    int jiGe = 0;
                    int ouGe = 0;
                    int DaGe = 0;
                    int xiaoGe = 0;
                    //������ż�ȡ���С�ȡ���ֵ
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

                    //������ֵ��Ԫ��
                    HtmlTableCell cellHeZhi = new HtmlTableCell();

                    cellHeZhi.InnerText = he.ToString();
                    cellHeZhi.Attributes.Add("class", "codebghes");

                    cellHeZhi.Align = "center";


                    tempRow.Cells.Add(cellHeZhi);
                    //������ż�ȵ�Ԫ��
                    HtmlTableCell cellJiOuBi = new HtmlTableCell();
                    cellJiOuBi.InnerText = jiGe + ":" + ouGe;
                    cellJiOuBi.Attributes.Add("class", "codebgjiou");
                    cellJiOuBi.Align = "center";
                    tempRow.Cells.Add(cellJiOuBi);

                    //������С�ȵ�Ԫ��
                    HtmlTableCell cellDaXiaoBi = new HtmlTableCell();
                    cellDaXiaoBi.InnerText = DaGe + ":" + xiaoGe;
                    cellDaXiaoBi.Attributes.Add("class", "codebgdax");
                    cellDaXiaoBi.Align = "center";
                    tempRow.Cells.Add(cellDaXiaoBi);
                }



                #region �����ر������
                //����������� ����ʾ������ֵ����
                if (!string.IsNullOrEmpty(myTcodeName))
                {
                    AddKuaDuZS = false;
                    AddHeZhiZS = false;


                    int intFindCountTempKD = 0;
                    string XianCodePrefix = "TM";
                    for (int tempI = int.Parse(minTcode); tempI <= int.Parse(maxTcode); tempI++)
                    {

                        //�ж��Ƿ��ǵ�һ��
                        if (xuhao == 1)
                        {
                            arrFindCount_Tcode.Add(0);
                            //���ŷֲ�����©��
                            HtmlTableCell cellNei = new HtmlTableCell();

                            //������н��ŵ�Ԫ��
                            if (int.Parse(myTcode) == tempI)
                            {
                                arrFindCount_Tcode[intFindCountTempKD] += 1;
                                if (CzName.ToLower() == "FCP61Data_HD6S".ToLower())
                                {
                                    cellNei.InnerText = "��ţ������������Ｆ����".Substring(tempI - 1, 1);
                                }
                                else
                                {
                                    cellNei.InnerText = tempI.ToString();
                                }
                                cellNei.Attributes.Add("class", "JiangHaoJ");
                                cellNei.ID = XianCodePrefix + xuhao.ToString();
                            }
                            else//���н��ŵ�Ԫ����©��Ԫ��
                            {
                                //�����ʾ��©
                                if (DisplayYiLou)
                                {
                                    cellNei.InnerText = "1";
                                }
                                else//�������ʾ��©
                                {
                                    cellNei.InnerText = "";
                                }
                                cellNei.Attributes.Add("class", "ZhengChangJ");
                            }
                            tempRow.Cells.Add(cellNei);
                        }
                        else
                        {
                            //���һ�� ����ͳ����©
                            if (xuhao == MyDataSource.Rows.Count)
                            {
                                arrCurrentYL_Tcode.Add(0);
                                //���ŷֲ�����©��
                                HtmlTableCell cellNei = new HtmlTableCell();
                                //������н��ŵ�Ԫ��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
                                if (int.Parse(myTcode) == tempI)
                                {
                                    arrFindCount_Tcode[intFindCountTempKD] += 1;
                                    arrCurrentYL_Tcode[intFindCountTempKD] = 0;
                                    string strMyTempHQ = "";
                                    if (CzName.ToLower() == "FCP61Data_HD6S".ToLower())
                                    {
                                        strMyTempHQ = "��ţ������������Ｆ����".Substring(tempI - 1, 1);
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
                                else//���н��ŵ�Ԫ����©��Ԫ��
                                {
                                    //�������ʾ��©��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
                                    if (!DisplayYiLou)
                                    {
                                        cellNei.InnerText = "";
                                    }
                                    else//�����ʾ��©
                                    {
                                        //�õ����ǰ�е���һ��
                                        HtmlTableRow rowShang = tb.Rows[tb.Rows.Count - 1];
                                        //�õ���ǰ��Ԫ�����һ�д�λ�õ�Ԫ���ֵ�����������ֵ������˵�Ԫ���ֵ                             
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

                                        //�жϵ�ǰ��Ԫ�����һ�д�λ�õ�Ԫ���Ƿ����н��ŵ�Ԫ��
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
                            else //�������һ��
                            {
                                //���ŷֲ�����©��
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //������н��ŵ�Ԫ��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
                                if (int.Parse(myTcode) == tempI)
                                {
                                    arrFindCount_Tcode[intFindCountTempKD] += 1;
                                    string strMyTempHQ = "";
                                    if (CzName.ToLower() == "FCP61Data_HD6S".ToLower())
                                    {
                                        strMyTempHQ = "��ţ������������Ｆ����".Substring(tempI - 1, 1);
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
                                else//���н��ŵ�Ԫ����©��Ԫ��
                                {
                                    //�������ʾ��©��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
                                    if (!DisplayYiLou)
                                    {
                                        cellNei.InnerText = "";
                                    }
                                    else//�����ʾ��©
                                    {
                                        //�õ����ǰ�е���һ��
                                        HtmlTableRow rowShang = tb.Rows[tb.Rows.Count - 1];
                                        //�õ���ǰ��Ԫ�����һ�д�λ�õ�Ԫ���ֵ�����������ֵ������˵�Ԫ���ֵ                             
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

                                        //�жϵ�ǰ��Ԫ�����һ�д�λ�õ�Ԫ���Ƿ����н��ŵ�Ԫ��
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

                #region �������
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
                    //ѭ��0-9����Ԫ��
                    int intFindCountTempKD = 0;
                    string XianCodePrefix = "kd";
                    for (int j = 0; j <= 9; j++)
                    {

                        //�ж��Ƿ��ǵ�һ��
                        if (xuhao == 1)
                        {
                            arrFindCount_KD.Add(0);
                            //���ŷֲ�����©��
                            HtmlTableCell cellNei = new HtmlTableCell();

                            //������н��ŵ�Ԫ��
                            if (kuaDu == j)
                            {
                                arrFindCount_KD[intFindCountTempKD] += 1;
                                cellNei.InnerText = j.ToString();
                                cellNei.Attributes.Add("class", "JiangHaoJ");
                                cellNei.ID = XianCodePrefix + xuhao.ToString();
                            }
                            else//���н��ŵ�Ԫ����©��Ԫ��
                            {
                                //�����ʾ��©
                                if (DisplayYiLou)
                                {
                                    cellNei.InnerText = "1";
                                }
                                else//�������ʾ��©
                                {
                                    cellNei.InnerText = "";
                                }
                                cellNei.Attributes.Add("class", "ZhengChangJ");
                            }

                            tempRow.Cells.Add(cellNei);
                        }
                        else
                        {
                            //���һ�� ����ͳ����©
                            if (xuhao == MyDataSource.Rows.Count)
                            {
                                arrCurrentYL_KD.Add(0);
                                //���ŷֲ�����©��
                                HtmlTableCell cellNei = new HtmlTableCell();
                                //������н��ŵ�Ԫ��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
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
                                else//���н��ŵ�Ԫ����©��Ԫ��
                                {
                                    //�������ʾ��©��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
                                    if (!DisplayYiLou)
                                    {
                                        cellNei.InnerText = "";
                                    }
                                    else//�����ʾ��©
                                    {
                                        //�õ����ǰ�е���һ��
                                        HtmlTableRow rowShang = tb.Rows[tb.Rows.Count - 1];
                                        //�õ���ǰ��Ԫ�����һ�д�λ�õ�Ԫ���ֵ�����������ֵ������˵�Ԫ���ֵ                             
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
                                        //�жϵ�ǰ��Ԫ�����һ�д�λ�õ�Ԫ���Ƿ����н��ŵ�Ԫ��
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
                            else //�������һ��
                            {
                                //���ŷֲ�����©��
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //������н��ŵ�Ԫ��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
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
                                else//���н��ŵ�Ԫ����©��Ԫ��
                                {
                                    //�������ʾ��©��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
                                    if (!DisplayYiLou)
                                    {
                                        cellNei.InnerText = "";
                                    }
                                    else//�����ʾ��©
                                    {
                                        //�õ����ǰ�е���һ��
                                        HtmlTableRow rowShang = tb.Rows[tb.Rows.Count - 1];
                                        //�õ���ǰ��Ԫ�����һ�д�λ�õ�Ԫ���ֵ�����������ֵ������˵�Ԫ���ֵ                             
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
                                        //�жϵ�ǰ��Ԫ�����һ�д�λ�õ�Ԫ���Ƿ����н��ŵ�Ԫ��
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



                #region  ��ֵβ������
                if (AddHeZhiZS)
                {

                    int he = 0;
                    //������ż�ȡ���С�ȡ���ֵ
                    for (int i = 0; i < myCode.Length; i++)
                    {
                        int tempIntCode = int.Parse(myCode.Substring(i, 1).ToString());
                        he += tempIntCode;
                    }
                    string strHe = he.ToString();
                    int heWei = int.Parse(strHe.Substring(strHe.Length - 1, 1));

                    int intFindCountTempHZ = 0;
                    string XianCodePrefix = "hz";
                    //ѭ��0-9����Ԫ��                        
                    for (int j = 0; j <= 9; j++)
                    {

                        //�ж��Ƿ��ǵ�һ��
                        if (xuhao == 1)
                        {
                            arrFindCount_HZ.Add(0);
                            //���ŷֲ�����©��
                            HtmlTableCell cellNei = new HtmlTableCell();
                            //������н��ŵ�Ԫ��
                            if (heWei == j)
                            {
                                arrFindCount_HZ[intFindCountTempHZ] += 1;
                                cellNei.InnerText = j.ToString();
                                cellNei.Attributes.Add("class", "JiangHaoO");
                                cellNei.ID = XianCodePrefix + xuhao.ToString();
                            }
                            else//���н��ŵ�Ԫ����©��Ԫ��
                            {
                                //�����ʾ��©
                                if (DisplayYiLou)
                                {
                                    cellNei.InnerText = "1";
                                }
                                else//�������ʾ��©
                                {
                                    cellNei.InnerText = "";
                                }
                                cellNei.Attributes.Add("class", "ZhengChangO");
                            }

                            tempRow.Cells.Add(cellNei);
                        }
                        else
                        {
                            //���һ�� ����ͳ����©
                            if (xuhao == MyDataSource.Rows.Count)
                            {
                                arrCurrentYL_HZ.Add(0);
                                //���ŷֲ�����©��
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //������н��ŵ�Ԫ��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
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
                                else//���н��ŵ�Ԫ����©��Ԫ��
                                {
                                    //�������ʾ��©��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
                                    if (!DisplayYiLou)
                                    {
                                        cellNei.InnerText = "";
                                    }
                                    else//�����ʾ��©
                                    {
                                        //�õ����ǰ�е���һ��
                                        HtmlTableRow rowShang = tb.Rows[tb.Rows.Count - 1];
                                        //�õ���ǰ��Ԫ�����һ�д�λ�õ�Ԫ���ֵ�����������ֵ������˵�Ԫ���ֵ     
                                        //���ԭ�� C21*C21*C21 = 8 �����
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
                                        //�жϵ�ǰ��Ԫ�����һ�д�λ�õ�Ԫ���Ƿ����н��ŵ�Ԫ��
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
                                //���ŷֲ�����©��
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //������н��ŵ�Ԫ��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
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
                                else//���н��ŵ�Ԫ����©��Ԫ��
                                {
                                    //�������ʾ��©��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
                                    if (!DisplayYiLou)
                                    {
                                        cellNei.InnerText = "";
                                    }
                                    else//�����ʾ��©
                                    {
                                        //�õ����ǰ�е���һ��
                                        HtmlTableRow rowShang = tb.Rows[tb.Rows.Count - 1];
                                        //�õ���ǰ��Ԫ�����һ�д�λ�õ�Ԫ���ֵ�����������ֵ������˵�Ԫ���ֵ     
                                        //���ԭ�� C21*C21*C21 = 8 �����
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
                                        //�жϵ�ǰ��Ԫ�����һ�д�λ�õ�Ԫ���Ƿ����н��ŵ�Ԫ��
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






            #region ����Ԥѡ�б�ͷ

            HtmlTableRow rowYXH = new HtmlTableRow();

            //��ű�ͷ��Ԫ��

            //HtmlTableCell cellYXH_XH = new HtmlTableCell();
            //cellYXH_XH.InnerText = "";
            //cellYXH_XH.Attributes.Add("class", "codebg");
            //rowYXH.Cells.Add(cellYXH_XH);
            //������ͷ��Ԫ��
            //HtmlTableCell cellYXH_QH = new HtmlTableCell();
            //cellYXH_QH.InnerText = "";
            //cellYXH_QH.Attributes.Add("class", "codebg");
            //rowYXH.Cells.Add(cellYXH_QH);

            //�����ű�ͷ��Ԫ��
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.InnerHtml = "<b>Ԥѡ��>></b>";
                cellCodeH.ColSpan = 3;

                if (CzName == "FC3DData")
                {
                    cellCodeH.ColSpan = 3 + 1;
                }


                cellCodeH.Attributes.Add("class", "codebg");
                rowYXH.Cells.Add(cellCodeH);
            }

            //����λ��ѭ������λ����ͷ
            for (int i = 1; i <= WeiShu; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = "��";
                    cellH2.Attributes.Add("class", "codebgweishu");
                    cellH2.Style.Add("cursor", "pointer");
                    cellH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='codebgweishu'?'" + j.ToString() + "':'��';this.className=this.className=='codebgweishu'?'JiangHaoJ':'codebgweishu';");
                    rowYXH.Cells.Add(cellH2);
                }
            }



            if (AddZhiBiao)
            {
                //����ֵ��ͷ��Ԫ��
                HtmlTableCell cellHeShuH = new HtmlTableCell();
                cellHeShuH.InnerText = "";
                cellHeShuH.Attributes.Add("class", "codebg");
                cellHeShuH.Align = "center";
                cellHeShuH.Width = "30";
                rowYXH.Cells.Add(cellHeShuH);

                // ��ż�ȱ�ͷ��Ԫ��
                HtmlTableCell cellJiOuH = new HtmlTableCell();
                cellJiOuH.InnerText = "";
                cellJiOuH.Attributes.Add("class", "codebg");

                cellJiOuH.Align = "center";
                cellJiOuH.Width = "30";

                rowYXH.Cells.Add(cellJiOuH);

                // ��С�ȱ�ͷ��Ԫ��
                HtmlTableCell cellDaXiaoH = new HtmlTableCell();
                cellDaXiaoH.InnerText = "";
                cellDaXiaoH.Attributes.Add("class", "codebg");

                cellDaXiaoH.Align = "center";
                cellDaXiaoH.Width = "30";

                rowYXH.Cells.Add(cellDaXiaoH);
            }



            //����������� ����ʾ������ֵ����Ԥѡ
            if (!string.IsNullOrEmpty(myTcodeName))
            {
                AddKuaDuZS = false;
                AddHeZhiZS = false;
                for (int tempI = int.Parse(minTcode); tempI <= int.Parse(maxTcode); tempI++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();
                    cellKDH2.InnerText = "��";
                    cellKDH2.Attributes.Add("class", "bgKuaDuZS");
                    cellKDH2.Style.Add("cursor", "pointer");
                    cellKDH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='bgKuaDuZS'?'" + tempI.ToString() + "':'��';this.className=this.className=='bgKuaDuZS'?'JiangHaoJ':'bgKuaDuZS';");
                    rowYXH.Cells.Add(cellKDH2);
                }
            }
            else
            {
                AddKuaDuZS = true;
                AddHeZhiZS = true;
            }
            //�������Ԥѡ
            if (AddKuaDuZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellKDH2 = new HtmlTableCell();

                    cellKDH2.InnerText = "��";
                    cellKDH2.Attributes.Add("class", "bgKuaDuZS");
                    cellKDH2.Style.Add("cursor", "pointer");
                    cellKDH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='bgKuaDuZS'?'" + j.ToString() + "':'��';this.className=this.className=='bgKuaDuZS'?'JiangHaoJ':'bgKuaDuZS';");
                    rowYXH.Cells.Add(cellKDH2);
                }
            }
            //��ֵ����Ԥѡ
            if (AddHeZhiZS)
            {
                for (int j = 0; j <= 9; j++)
                {
                    HtmlTableCell cellHZH2 = new HtmlTableCell();
                    cellHZH2.InnerText = "��";
                    cellHZH2.Attributes.Add("class", "bgHeZhiZS");
                    cellHZH2.Style.Add("cursor", "pointer");
                    cellHZH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='bgHeZhiZS'?'" + j.ToString() + "':'��';this.className=this.className=='bgHeZhiZS'?'JiangHaoJ':'bgHeZhiZS';");
                    rowYXH.Cells.Add(cellHZH2);
                }
            }
            tb.Rows.Add(rowYXH);

            #endregion


            #region �����ο��б�ͷ

            HtmlTableRow rowYXHCodeCK = new HtmlTableRow();

            //��ű�ͷ��Ԫ��

            HtmlTableCell cellXuHaoH_CK = new HtmlTableCell();
            cellXuHaoH_CK.InnerText = "��";
            cellXuHaoH_CK.Attributes.Add("class", "codebg");
            rowYXHCodeCK.Cells.Add(cellXuHaoH_CK);
            //������ͷ��Ԫ��
            HtmlTableCell cellQiShuH_CK = new HtmlTableCell();
            cellQiShuH_CK.InnerText = "����";
            cellQiShuH_CK.Attributes.Add("class", "codebg");
            rowYXHCodeCK.Cells.Add(cellQiShuH_CK);




            if (CzName == "FC3DData")
            {
                //�Ի��ű�ͷ��Ԫ��
                HtmlTableCell cellShiJiHaoH_CK = new HtmlTableCell();
                cellShiJiHaoH_CK.InnerText = "�Ի���";
                cellShiJiHaoH_CK.Attributes.Add("class", "codebg");
                cellShiJiHaoH_CK.Width = "60px";
                cellShiJiHaoH_CK.Align = "center";
                rowYXHCodeCK.Cells.Add(cellShiJiHaoH_CK);

                //����-����ͷ��Ԫ��
                HtmlTableCell cellJiH_CK = new HtmlTableCell();
                cellJiH_CK.InnerText = "��";
                cellJiH_CK.Attributes.Add("class", "codebg");
                cellJiH_CK.Width = "20px";
                cellJiH_CK.Align = "center";
                cellJiH_CK.Visible = false;
                rowYXHCodeCK.Cells.Add(cellJiH_CK);

                //����-���ͷ��Ԫ��
                HtmlTableCell cellQiuH_CK = new HtmlTableCell();
                cellQiuH_CK.InnerText = "��";
                cellQiuH_CK.Attributes.Add("class", "codebg");
                cellQiuH_CK.Width = "20px";
                cellQiuH_CK.Align = "center";
                cellQiuH_CK.Visible = false;
                rowYXHCodeCK.Cells.Add(cellQiuH_CK);
            }




            //�����ű�ͷ��Ԫ��
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.InnerText = "������";
                cellCodeH.Attributes.Add("class", "codebg");
                rowYXHCodeCK.Cells.Add(cellCodeH);
            }

            //����λ��ѭ������λ����ͷ
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
                //����ֵ��ͷ��Ԫ��
                HtmlTableCell cellHeShuH = new HtmlTableCell();
                cellHeShuH.InnerText = "";
                cellHeShuH.Attributes.Add("class", "codebgbtm");
                rowYXHCodeCK.Cells.Add(cellHeShuH);

                // ��ż�ȱ�ͷ��Ԫ��
                HtmlTableCell cellJiOuH = new HtmlTableCell();
                cellJiOuH.InnerText = "";
                cellJiOuH.Attributes.Add("class", "codebgbtm");
                rowYXHCodeCK.Cells.Add(cellJiOuH);

                // ��С�ȱ�ͷ��Ԫ��
                HtmlTableCell cellDaXiaoH = new HtmlTableCell();
                cellDaXiaoH.InnerText = "";
                cellDaXiaoH.Attributes.Add("class", "codebgbtm");
                rowYXHCodeCK.Cells.Add(cellDaXiaoH);
            }


            //����������� ����ʾ������ֵ���Ʋο���
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

            //������Ʋο���
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
            //��ֵ���Ʋο���
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

            #region �������ִ����б�ͷ

            HtmlTableRow rowFindCount = new HtmlTableRow();

            //��ű�ͷ��Ԫ��
            //HtmlTableCell cellFindCount_XH = new HtmlTableCell();
            //cellFindCount_XH.InnerText = "";
            //cellFindCount_XH.Attributes.Add("class", "codebg");
            //rowFindCount.Cells.Add(cellFindCount_XH);

            ////HtmlTableCell cellFindCount_XH1 = new HtmlTableCell();
            ////cellFindCount_XH1.InnerText = "";
            ////cellFindCount_XH1.Attributes.Add("class", "codebg");
            ////rowFindCount.Cells.Add(cellFindCount_XH1);


            ////������ͷ��Ԫ��
            //HtmlTableCell cellFindCount_QH = new HtmlTableCell();
            //cellFindCount_QH.InnerText = "";
            //cellFindCount_QH.Attributes.Add("class", "codebg");
            //rowFindCount.Cells.Add(cellFindCount_QH);

            //�����ű�ͷ��Ԫ��
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.ColSpan = 3;
                if (CzName == "FC3DData")
                {
                    cellCodeH.ColSpan = 3 + 1;
                }
                cellCodeH.InnerHtml = "<b>��ǰ���ִ���>></b>";
                cellCodeH.Attributes.Add("class", "codebg");
                rowFindCount.Cells.Add(cellCodeH);
            }

            //����λ��ѭ������λ����ͷ
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
                //����ֵ��ͷ��Ԫ��
                HtmlTableCell cellHeShuH = new HtmlTableCell();
                cellHeShuH.InnerText = "";
                cellHeShuH.Attributes.Add("class", "codebg");
                rowFindCount.Cells.Add(cellHeShuH);

                // ��ż�ȱ�ͷ��Ԫ��
                HtmlTableCell cellJiOuH = new HtmlTableCell();
                cellJiOuH.InnerText = "";
                cellJiOuH.Attributes.Add("class", "codebg");
                rowFindCount.Cells.Add(cellJiOuH);

                // ��С�ȱ�ͷ��Ԫ��
                HtmlTableCell cellDaXiaoH = new HtmlTableCell();
                cellDaXiaoH.InnerText = "";
                cellDaXiaoH.Attributes.Add("class", "codebg");
                rowFindCount.Cells.Add(cellDaXiaoH);
            }

            int findCountTcode = 0;
            //����������� ����ʾ������ֵ���Ƴ��ִ���
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
            //������Ƴ��ִ���
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
            //��ֵ���Ƴ��ִ���
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


            #region ������ǰ��©�б�ͷ

            HtmlTableRow rowCurrentYL = new HtmlTableRow();

            //��ű�ͷ��Ԫ��

            ////HtmlTableCell cellCurrentYL_XH = new HtmlTableCell();
            ////cellCurrentYL_XH.InnerText = "";
            ////cellCurrentYL_XH.Attributes.Add("class", "codebg");
            ////rowCurrentYL.Cells.Add(cellCurrentYL_XH);


            ////������ͷ��Ԫ��
            //HtmlTableCell cellCurrentYL_QH = new HtmlTableCell();
            //cellCurrentYL_QH.InnerText = "";
            //cellCurrentYL_QH.Attributes.Add("class", "codebg");
            //rowCurrentYL.Cells.Add(cellCurrentYL_QH);

            //�����ű�ͷ��Ԫ��
            if (AddCode)
            {
                HtmlTableCell cellCodeH = new HtmlTableCell();
                cellCodeH.ColSpan = 3;
                if (CzName == "FC3DData")
                {
                    cellCodeH.ColSpan = 3 + 1;
                }

                cellCodeH.InnerHtml = "<b>��ǰ��©>></b>";
                cellCodeH.Attributes.Add("class", "codebg");
                rowCurrentYL.Cells.Add(cellCodeH);
            }

            int ylCount = 0;
            //����λ��ѭ������λ����ͷ
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
                //����ֵ��ͷ��Ԫ��
                HtmlTableCell cellHeShuH = new HtmlTableCell();
                cellHeShuH.InnerText = "";
                cellHeShuH.Attributes.Add("class", "codebgbtm");
                rowCurrentYL.Cells.Add(cellHeShuH);

                // ��ż�ȱ�ͷ��Ԫ��
                HtmlTableCell cellJiOuH = new HtmlTableCell();
                cellJiOuH.InnerText = "";
                cellJiOuH.Attributes.Add("class", "codebgbtm");
                rowCurrentYL.Cells.Add(cellJiOuH);

                // ��С�ȱ�ͷ��Ԫ��
                HtmlTableCell cellDaXiaoH = new HtmlTableCell();
                cellDaXiaoH.InnerText = "";
                cellDaXiaoH.Attributes.Add("class", "codebgbtm");
                rowCurrentYL.Cells.Add(cellDaXiaoH);
            }


            //����������� ����ʾ������ֵ������©��
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


            //�����©��
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
            //��ֵ��©��
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

