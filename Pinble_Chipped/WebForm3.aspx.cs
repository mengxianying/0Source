using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;

namespace Pinble_Chipped
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ArrayList nNumBall = lottery("01,02,03,04,05,06,07");
                string num = Random(3, 12);
                Response.Write(num);
            }
        }
        /// <summary>
        /// 拆分复试彩种    01,02,03,04,05,06,07,08
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public ArrayList lottery(string num)
        {

            //string nStrNum = "";
        //    for(int a=0; a<nSelCount; a++)
        //    {
        //        for(int b=0; b<nSelCount; b++)
        //        {
        //            if(a == b) continue;
        //            for(int c=0; c<nSelCount; c++)
        //            {
        //                if(b == c || a == c) continue;
        //                for(int d=0; d<nSelCount; d++)
        //                {
        //                    if(d == a || d == b || d == c) continue;
        //                    for(int e=0; e<nSelCount; e++)
        //                    {
        //                        if(e==a || e==b || e==c || e==d) continue;
        //                        for(int f=0; f<nSelCount; f++)
        //                        {
        //                            if(f==a || f==b || f==c || f==d || f==e) continue;
        //                            btData[0] = m_btSelItemArray[a];
        //                            btData[1] = m_btSelItemArray[b];
        //                            btData[2] = m_btSelItemArray[c];
        //                            btData[3] = m_btSelItemArray[d];
        //                            btData[4] = m_btSelItemArray[e];
        //                            btData[5] = m_btSelItemArray[f];
        //                            m_pINumbers->SetItemData(dwIndex++, btData);
        //                        }}}}}}
        //} break;
            //定义数组
            ArrayList arr = new ArrayList();
            //红球长度
            int nBallLength=num.Split(',').Length;
            

            for (int a = 0; a < nBallLength; a++)
            { 
                for(int b=a+1;b<nBallLength;b++)
                {
                    for (int c = b+1; c < nBallLength; c++)
                    {
                        for (int d = c + 1; d < nBallLength; d++)
                        {
                            for (int e = d + 1; e < nBallLength; e++)
                            {
                                for (int f = e + 1; f < nBallLength; f++)
                                {
                                    arr.Add(num.Split(',')[a] + "," + num.Split(',')[b] + ","+num.Split(',')[c]+","+num.Split(',')[d]+","+num.Split(',')[e]+","+num.Split(',')[f]);
                                }
                            }
                        }
                    }
                }
            }
            return arr;
        }


        #region   生成随机号码
        /// <summary>
        /// 生成随机号码
        /// </summary>
        /// <param name="playName">彩种标识</param>
        /// <param name="note">生成几注</param>
        /// <returns></returns>
        public string Random(int playName, int note)
        {
            Random rad = new Random();
            //声明数组
            ArrayList listArr = new ArrayList();
            string ball = "";

            if (playName == 3)
            {
                 
                //双色球
                int prar1;
                int prar2;
                int prar3;
                int prar4;
                int prar5;
                int prar6;
                string prar7;
                string prar="";
                for (int i = 0; i < note; i++)
                {
                    listArr.Clear();
                    prar1 = rad.Next(1, 33);
                    listArr.Add(number(prar1));
                    //Randomize rm = new Randomize();
                    while (true)
                    {
                        prar2 = rad.Next(1, 33);
                        if (Convert.ToInt32(prar1) != Convert.ToInt32(prar2))
                        {
                            prar = number(prar2);
                            listArr.Add(prar);
                            break;
                        }
                    }
                    while (true)
                    {
                        prar3 = rad.Next(1, 33);
                        if (Convert.ToInt32(prar1) != Convert.ToInt32(prar3) && Convert.ToInt32(prar2) != Convert.ToInt32(prar3))
                        {
                            prar = number(prar3);
                            listArr.Add(prar);
                            
                            break;
                        }
                    }
                    while (true)
                    {
                        prar4 = rad.Next(1, 33);
                        if (Convert.ToInt32(prar4) != Convert.ToInt32(prar1) && Convert.ToInt32(prar4) != Convert.ToInt32(prar2) && Convert.ToInt32(prar4) != Convert.ToInt32(prar3))
                        {
                            prar = number(prar4);
                            listArr.Add(prar);
                            break;
                        }
                    }
                    while (true)
                    {
                        prar5 = rad.Next(1, 33);
                        if (Convert.ToInt32(prar5) != Convert.ToInt32(prar1) && Convert.ToInt32(prar5) != Convert.ToInt32(prar2) && Convert.ToInt32(prar5) != Convert.ToInt32(prar3) && Convert.ToInt32(prar5) != Convert.ToInt32(prar4))
                        {
                            prar = number(prar5);
                            listArr.Add(prar);
                            break;
                        }
                    }
                    while (true)
                    {
                        prar6 = rad.Next(1, 33);
                        if (Convert.ToInt32(prar6) != Convert.ToInt32(prar1) && Convert.ToInt32(prar6) != Convert.ToInt32(prar2) && Convert.ToInt32(prar6) != Convert.ToInt32(prar3) && Convert.ToInt32(prar6) != Convert.ToInt32(prar4) && Convert.ToInt32(prar6) != Convert.ToInt32(prar5))
                        {
                            prar = number(prar6);
                            listArr.Add(prar);
                            break;
                        }
                    }
                    //随机选择蓝球
                    prar7 = number(rad.Next(1, 16));

                    //对红球进行冒泡排序
                    ArrayList arrL = arrlist(listArr);
                    string redBall = "";
                    //组合号码
                    for (int j = 0; j < arrL.Count; j++)
                    {
                        redBall += arrL[j] + ",";
                    }
                    //组合后的一注号码
                    ball += redBall.Substring(0, redBall.Length - 1) + "+" + prar7 + "|";

                }
                return ball.Substring(0,ball.Length - 1);
            }
            return "0";
        }
        /// <summary>
        /// 组合号码
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string number(int num)
        {
            if (num < 10)
            {
                return "0" + num.ToString();
            }
            return num.ToString();
        }
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private ArrayList arrlist(ArrayList arr)
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                int flag = 1;
                for (int j = 0; j < arr.Count - 1 - i; j++)
                {

                    if (Convert.ToInt32(arr[j]) > Convert.ToInt32(arr[j + 1]))
                    {
                        flag = 0;
                        int temp = Convert.ToInt32(arr[j]);
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }

                }
                if (flag == 1)
                {
                    break;
                }
            }

            return arr;
        }
        #endregion
    }
}