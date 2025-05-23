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
        /// ��Ϊ��������
        /// </summary>
        public int WeiShu
        {
            get { return _weiShu; }
            set { _weiShu = value; }
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


        private string _czName;

        /// <summary>
        /// ��������
        /// </summary>
        public string CzName
        {
            get { return _czName; }
            set { _czName = value; }
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

        private int _minCode = 1;
        /// <summary>
        /// ��С��
        /// </summary>
        public int MinCode
        {
            get { return _minCode; }
            set { _minCode = value; }
        }

        private int _maxCode = 38;
        /// <summary>
        /// ����
        /// </summary>
        public int MaxCode
        {
            get { return _maxCode; }
            set { _maxCode = value; }
        }


        private void CreateTable()
        {
            #region ������ͷ

            HtmlTableRow rowHead = new HtmlTableRow();
            int[] qjLength = Method.CreateQuJian(MaxCode, MinCode, WeiShu);
           
            //����ѭ������λ����ͷ
            for (int i = 1; i <= qjLength.Length; i++)
            {
                HtmlTableCell cellWeiShuH = new HtmlTableCell();
                cellWeiShuH.ID = "cellWeiShuH" + i.ToString();
                cellWeiShuH.InnerText = Method.NumToHanZi(i) + "��";

                cellWeiShuH.ColSpan = qjLength[i-1];
                cellWeiShuH.Attributes.Add("class", "codebg");
                rowHead.Cells.Add(cellWeiShuH);
            }

   
            //������ӵ����
            tb.Rows.Add(rowHead);

            HtmlTableRow rowHead2 = new HtmlTableRow();

            int tempStartNum = MinCode;
            //����λ��ѭ������λ����ͷ
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
            
            #region ѭ����������
            int xuhao = 0;
            for (int ik = MyDataSource.Rows.Count - 1; ik >= 0; ik--)
            {
                DataRow row = MyDataSource.Rows[ik];
                ++xuhao;
                HtmlTableRow tempRow = new HtmlTableRow();

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

                int myTempStartCode = MinCode;


                int intFindCountTemp = 0;
                for (int i = 1; i <= qjLength.Length; i++)
                {
                        //ѭ��ÿ����������е�Ԫ��                        
                        for (int j = 0; j < qjLength[i-1]; j++)
                        {
                                                 
                            //�ж��Ƿ��ǵ�һ��
                            if (xuhao == 1)
                            {
                                arrFindCount.Add(0);       
                                //���ŷֲ�����©��
                                HtmlTableCell cellNei = new HtmlTableCell();

                                //������н��ŵ�Ԫ��

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

                                //���ŵ�Ԫ��
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
                                else//���н��ŵ�Ԫ����©��Ԫ��
                                {
                                    //�����ʾ��©
                                    if (DisplayYiLou)
                                    {
                                        cellNei.InnerText = "1";
                                    }
                                    else//�������ʾ��©
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
                                //�Ƿ������һ�� �������㵱ǰ��©
                                if (xuhao == MyDataSource.Rows.Count)
                                {
                                    arrCurrentYL.Add(0);
                                    //���ŷֲ�����©��
                                    HtmlTableCell cellNei = new HtmlTableCell();

                                    //������н��ŵ�Ԫ��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
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

                                    //���ŵ�Ԫ��
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
                                    //���ŷֲ�����©��
                                    HtmlTableCell cellNei = new HtmlTableCell();

                                    //������н��ŵ�Ԫ��,�Ͳ��ؼ�����һ�д�λ�õ�Ԫ���ֵ
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

                                    //���ŵ�Ԫ��
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

            ///����Ԥѡ��
            HtmlTableRow rowYXHCode = new HtmlTableRow();

            int tempStartNum1 = MinCode;
            //����λ��ѭ������λ����ͷ
            for (int i = 1; i <= qjLength.Length; i++)
            {
                for (int j = 0; j < qjLength[i - 1]; j++)
                {
                    HtmlTableCell cellH2 = new HtmlTableCell();
                    cellH2.InnerText = "��";                      
                    cellH2.Attributes.Add("class", "ZhengChangJ");
                    cellH2.Style.Add("cursor", "pointer");
                    cellH2.Attributes.Add("onclick", "javascript:this.innerText=this.className=='ZhengChangJ'?'" + tempStartNum1.ToString() + "':'��';this.className=this.className=='ZhengChangJ'?'JiangHaoJ':'ZhengChangJ';");
                    rowYXHCode.Cells.Add(cellH2);
                    tempStartNum1++;
                }

            }
            tb.Rows.Add(rowYXHCode);


            ///����Ԥѡ�вο�
            HtmlTableRow rowYXHCodeCK = new HtmlTableRow();
            int tempStartNum2 = MinCode;
            //����λ��ѭ������λ����ͷ
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

            ///�������ִ�����
            HtmlTableRow rowFindCount = new HtmlTableRow();
            int tempNumFindCount = 0;
            //����λ��ѭ������λ����ͷ
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


            ///������ǰ��©��
            HtmlTableRow rowYLCount = new HtmlTableRow();
            int tempNumYLCount = 0;
            //����λ��ѭ������λ����ͷ
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