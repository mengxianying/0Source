using System;
using Maticsoft.DBUtility;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Web.UI;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.Security;
using System.Data;
using System.Xml;
using Pbzx.Model;
using System.IO;
namespace Pbzx.Common
{
    public class Method
    {

        public static string Where_News = " and (BitIsPass = 1) ";
        public static string Where_Question = "";
        public static string Where_AgentInfo = " and ExpireDate > GETDATE() and (Status=1)";


        /// <summary>
        /// 
        /// </summary>
        public static string IndexProduct = " pb_Deleted=0 and pb_Passed=1 and pb_indexshow=1 order by icountid asc ";
        /// <summary>
        /// 
        /// </summary>
        public static string IndexYYJC = "pb_Deleted=0 and pb_Passed=1 and pb_indexshow=1  order by pb_UpdateTime desc  ";
        /// <summary>
        /// ��Ʊ������ҳ���̼�������Ϣsql����
        /// ������: zhouwei
        /// ����ʱ��: 2010-10-21
        /// </summary>
        public static string Mark_UserGueue = "State=1 order by id desc";

        /// <summary>
        /// ��Ʊ������ҳ����Ŀ�б�
        /// ������: zhouwei
        /// ����ʱ��:2010-10-22
        /// </summary>
        public static string Market_Item = " order by Ma.appendID desc";




        /// <summary>
        /// ��Ʒ����ɸѡ����
        /// </summary>
        //public static string product = " pb_Deleted=0 and pb_Passed=1";
        public static string product = " pb_Deleted=0 and pb_Passed=1";
        /// <summary>
        /// ��Դ����ɸѡ����
        /// </summary>
        public static string soft = " pb_Deleted=0 and pb_Passed=1 ";
        /// <summary>
        /// ������ɸѡ����
        /// </summary>
        public static string Advs = " pb_ENDTime>getdate() and pb_IsSelected=1  ";

        /// <summary>
        /// ����������ɸѡ����
        /// </summary>
        public static string BulletinType = " BitIsAuditing=1 ";


        public static string NewsPage = "order by DatDateAndTime desc";
        public static string IsTopPage = "order by BitIsTop DESC ,DatDateAndTime desc";

        public static string IndexNews = "and ShowIndex=1  order by  BitIsTop DESC ,DatDateAndTime desc";

        public static string DlUser = " ExpireDate > GETDATE() AND Status = 1 ";

        /// <summary>
        /// ��Ч�û�ɸѡ����
        /// </summary>
        public static string DV_User = " LockUser=0 and UserClass!='COPPA' and UserClass!='�ȴ���֤' ";


        /// <returns></returns>
        public static string GetUserIP()
        {
            string result = "IP��ַδ֪";
            if (System.Web.HttpContext.Current.Request.UserHostAddress != null)
            {
                result = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            }
            return result;
        }


        #region//ShowPager:��ʾ��ҳЧ��.
        /// <summary>
        /// ��ʾ��ҳЧ��.
        /// </summary>
        /// <param name="nPage">��ǰҳ.</param>
        /// <param name="maxPage">���ҳ.</param>
        /// <returns>�����ַ���.</returns>
        public static string ShowPager(int nPage, int maxPage)
        {
            int endpage = 1;
            string qdkPager = "";
            if (maxPage <= 11)
            {
                if (nPage > 1)
                {
                    qdkPager = "<a href=\"?page=1\">��ҳ<</a> ";
                }
                else
                {
                    qdkPager = "<a class=\"noLink\">��ҳ<</a> ";
                }
                //qdkPager += "<div>��10ҳ</div> ";
                endpage = maxPage;
                for (int ii = 1; ii <= maxPage; ii++)
                {
                    if (nPage != ii)
                    {
                        qdkPager += "<a href=\"?page=" + ii.ToString() + "\">" + ii.ToString() + "</a> ";
                    }
                    else
                    {
                        qdkPager += "<a class=\"nowPage\">" + ii.ToString() + "</a> ";
                    }
                }
                //qdkPager += "<div>��10ҳ</div> ";
                if (nPage < maxPage)
                {
                    qdkPager += "<a href=\"?page=" + maxPage + "\">>βҳ</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">>βҳ</a> ";
                }
            }
            else
            {
                int maxCount = 0;
                if (maxPage % 10 == 0)
                {
                    maxCount = maxPage / 10;
                }
                else
                {
                    maxCount = maxPage / 10 + 1;
                }
                if (nPage > 1)
                {
                    qdkPager = "<a href=\"?page=1\">��ҳ<</a> ";
                }
                else
                {
                    qdkPager = "<a class=\"noLink\">��ҳ<</a> ";
                }

                int nowpagecount = 0;
                if (nPage % 10 == 0)
                {
                    nowpagecount = nPage / 10;
                }
                else
                {
                    nowpagecount = nPage / 10 + 1;
                }
                if (nowpagecount > 1)
                {
                    qdkPager += "<a href=\"?page=" + ((nowpagecount - 2) * 10 + 1) + "\">��10ҳ</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">��10ҳ</a> ";
                }
                endpage = ((nowpagecount - 1) * 10 + 11) < maxPage ? ((nowpagecount - 1) * 10 + 11) : maxPage;
                for (int ii = ((nowpagecount - 1) * 10) > 0 ? ((nowpagecount - 1) * 10) : 1; ii <= endpage; ii++)
                {
                    if (nPage != ii)
                    {
                        qdkPager += "<a href=\"?page=" + ii.ToString() + "\">" + ii.ToString() + "</a> ";
                    }
                    else
                    {
                        qdkPager += "<a class=\"nowPage\">" + ii.ToString() + "</a> ";
                    }
                }
                if (nowpagecount < maxCount)
                {
                    qdkPager += "<a href=\"?page=" + (nowpagecount * 10 + 1) + "\">��10ҳ</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">��10ҳ</a> ";
                }
                if (nPage < maxPage)
                {
                    qdkPager += "<a href=\"?page=" + maxPage + "\">>βҳ</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">>βҳ</a> ";
                }
            }
            return qdkPager;
        }

        public static string ShowPager(int nPage, int maxPage, string strLink)
        {
            int endpage = 1;
            string qdkPager = "";
            if (maxPage <= 11)
            {
                if (nPage > 1)
                {
                    qdkPager = "<a href=\"?page=1&" + strLink + "\">��ҳ<</a> ";
                }
                else
                {
                    qdkPager = "<a class=\"noLink\">��ҳ<</a> ";
                }
                //qdkPager += "<div>��10ҳ</div> ";
                endpage = maxPage;
                for (int ii = 1; ii <= maxPage; ii++)
                {
                    if (nPage != ii)
                    {
                        qdkPager += "<a href=\"?page=" + ii.ToString() + "&" + strLink + "\">" + ii.ToString() + "</a> ";
                    }
                    else
                    {
                        qdkPager += "<a class=\"nowPage\">" + ii.ToString() + "</a> ";
                    }
                }
                //qdkPager += "<div>��10ҳ</div> ";
                if (nPage < maxPage)
                {
                    qdkPager += "<a href=\"?page=" + maxPage + "&" + strLink + "\">>βҳ</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">>βҳ</a> ";
                }
            }
            else
            {
                int maxCount = 0;
                if (maxPage % 10 == 0)
                {
                    maxCount = maxPage / 10;
                }
                else
                {
                    maxCount = maxPage / 10 + 1;
                }
                if (nPage > 1)
                {
                    qdkPager = "<a href=\"?page=1&" + strLink + "\">��ҳ<</a> ";
                }
                else
                {
                    qdkPager = "<a class=\"noLink\">��ҳ<</a> ";
                }

                int nowpagecount = 0;
                if (nPage % 10 == 0)
                {
                    nowpagecount = nPage / 10;
                }
                else
                {
                    nowpagecount = nPage / 10 + 1;
                }
                if (nowpagecount > 1)
                {
                    qdkPager += "<a href=\"?page=" + ((nowpagecount - 2) * 10 + 1) + "&" + strLink + "\">��10ҳ</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">��10ҳ</a> ";
                }
                endpage = ((nowpagecount - 1) * 10 + 11) < maxPage ? ((nowpagecount - 1) * 10 + 11) : maxPage;
                for (int ii = ((nowpagecount - 1) * 10) > 0 ? ((nowpagecount - 1) * 10) : 1; ii <= endpage; ii++)
                {
                    if (nPage != ii)
                    {
                        qdkPager += "<a href=\"?page=" + ii.ToString() + "&" + strLink + "\">" + ii.ToString() + "</a> ";
                    }
                    else
                    {
                        qdkPager += "<a class=\"nowPage\">" + ii.ToString() + "</a> ";
                    }
                }
                if (nowpagecount < maxCount)
                {
                    qdkPager += "<a href=\"?page=" + (nowpagecount * 10 + 1) + "&" + strLink + "\">��10ҳ</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">��10ҳ</a> ";
                }
                if (nPage < maxPage)
                {
                    qdkPager += "<a href=\"?page=" + maxPage + "&" + strLink + "\">>βҳ</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">>βҳ</a> ";
                }
            }
            return qdkPager;
        }
        #endregion

        #region//sltListBox:���������е���ָ��ֵ��ѡ��ѡ��.
        /// <summary>
        /// ���������е���ָ��ֵ��ѡ��ѡ��.
        /// </summary>
        /// <param name="MyDD">Ҫ���õ�������.</param>
        /// <param name="sltValue">Ҫ����ֵ.</param>
        public static void sltListBox(ref System.Web.UI.WebControls.DropDownList MyDD, string sltValue)
        {
            int ii = 0;
            MyDD.SelectedItem.Selected = false;
            for (ii = 0; ii < MyDD.Items.Count; ii++)
            {
                if (MyDD.Items[ii].Value == sltValue)
                {
                    MyDD.Items[ii].Selected = true;
                }
            }
        }
        #endregion

        #region GetChecked:�����ڰ�����ʱѡ��CheckBox��checked״̬.
        /// <summary>
        /// �����ڰ�����ʱѡ��CheckBox��checked״̬.
        /// </summary>
        /// <param name="val">�󶨵�����.</param>
        /// <returns>����һ���ַ���.</returns>
        public static string GetChecked(object val)
        {
            string result = "";
            if (Convert.ToBoolean(val))
            {
                result = "checked";
            }
            return result;
        }
        #endregion

        /// <summary>
        /// �󶨲�Ʒ�༭��������汾������
        /// </summary>
        /// <param name="MyDD"></param>
        public static void BindProductVersionByEnum(ref System.Web.UI.WebControls.DropDownList MyDD)
        {

            string[] MyArray = Enum.GetNames(typeof(EProductVersion));
            MyDD.DataSource = MyArray;   //cboDepartmentType�ǽ����������б�������������б�ѡ�е���ת����ö��ֵ�������£�
            MyDD.DataBind();
        }

        ///<summary>
        /// ��DATALIST����
        /// </summary>
        /// List ���ݿռ�id
        public static void BindVersion(ref System.Web.UI.WebControls.DataList List)
        {
            string[] MyArray = Enum.GetNames(typeof(EProductVersion));
            List<string> ls = new List<string>();
            foreach (string str in MyArray)
            {
                ls.Add(str);
            }
            List.DataSource = ls;
            List.DataBind();
        }
        /// <summary>
        /// �����ű༭������ʾλ��������
        /// </summary>
        /// <param name="MyDD"></param>
        public static void BindNewsDisPosition(ref System.Web.UI.WebControls.DropDownList MyDD)
        {
            string[] MyArray = Enum.GetNames(typeof(EnewsDisPosition));
            Array MyValue = Enum.GetValues(typeof(EnewsDisPosition));
            for (int i = 0; i < MyArray.Length; i++)
            {
                MyDD.Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));
            }
            MyDD.Items.Insert(0, new ListItem("��ͨ", ""));
            MyDD.Items[0].Selected = true;
            //MyDD.DataSource = MyArray;   //cboDepartmentType�ǽ����������б�������������б�ѡ�е���ת����ö��ֵ�������£�
            //MyDD.DataBind();
        }

        /// <summary>
        /// �󶨹���༭������ʾλ��������
        /// </summary>
        /// <param name="MyDD"></param>
        public static void BindBulletinDisPosition(ref System.Web.UI.WebControls.DropDownList MyDD)
        {
            string[] MyArray = Enum.GetNames(typeof(EBulletinDisPosition));
            Array MyValue = Enum.GetValues(typeof(EBulletinDisPosition));
            for (int i = 0; i < MyArray.Length; i++)
            {
                MyDD.Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));
            }
            MyDD.Items.Insert(0, new ListItem("��ͨ", ""));
            MyDD.Items[0].Selected = true;
            //MyDD.DataSource = MyArray;   //cboDepartmentType�ǽ����������б�������������б�ѡ�е���ת����ö��ֵ�������£�
            //MyDD.DataBind();
        }

        /// <summary>
        /// ���Ƶ��
        /// </summary>
        /// <param name="MyDD"></param>
        public static void BindAdChanl(System.Web.UI.Control MyDD)
        {

            string[] MyArray = Enum.GetNames(typeof(EadChanl));
            Array MyValue = Enum.GetValues(typeof(EadChanl));
            if (MyDD is System.Web.UI.WebControls.DropDownList)
            {
                for (int i = 0; i < MyArray.Length; i++)
                {
                    ((System.Web.UI.WebControls.DropDownList)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));

                }
            }
            else if (MyDD is System.Web.UI.WebControls.ListBox)
            {
                for (int i = 0; i < MyArray.Length; i++)
                {
                    ((System.Web.UI.WebControls.ListBox)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));
                }
            }
        }

        ///// <summary>
        ///// ���Ƶ��
        ///// </summary>
        ///// <param name="MyDD"></param>
        //public static void BindAdPlace(System.Web.UI.Control MyDD)
        //{

        //    string[] MyArray = Enum.GetNames(typeof(EadPlaceType));
        //    //Array MyValue = Enum.GetValues(typeof(EadPlaceType));

        //    if (MyDD is System.Web.UI.WebControls.DropDownList)
        //    {
        //        for (int i = 0; i < ls.Count; i++)
        //        {
        //           // ((System.Web.UI.WebControls.DropDownList)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));
        //            ((System.Web.UI.WebControls.DropDownList)MyDD).Items.Add(new ListItem(MyArray[i], MyArray[i]));

        //        }
        //    }
        //    else if (MyDD is System.Web.UI.WebControls.ListBox)
        //    {
        //        for (int i = 0; i < MyArray.Length; i++)
        //        {
        //           // ((System.Web.UI.WebControls.ListBox)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));
        //            ((System.Web.UI.WebControls.ListBox)MyDD).Items.Add(new ListItem(MyArray[i], MyArray[i]));
        //        }
        //    }
        //}

        /// <summary>
        /// �󶨶����û���ʾ״̬
        /// </summary>
        /// <param name="MyDD"></param>
        public static void BindOrderStaticTip(System.Web.UI.Control MyDD)
        {

            string[] MyArray = Enum.GetNames(typeof(Pbzx.Model.PBnet_OrderStaticTip));
            Array MyValue = Enum.GetValues(typeof(Pbzx.Model.PBnet_OrderStaticTip));
            if (MyDD is System.Web.UI.WebControls.DropDownList)
            {
                for (int i = 0; i < MyArray.Length; i++)
                {
                    ((System.Web.UI.WebControls.DropDownList)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));

                }

            }
            else if (MyDD is System.Web.UI.WebControls.RadioButtonList)
            {
                for (int i = 0; i < MyArray.Length; i++)
                {
                    ((System.Web.UI.WebControls.RadioButtonList)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));

                }

            }
            else if (MyDD is System.Web.UI.WebControls.ListBox)
            {
                for (int i = 0; i < MyArray.Length; i++)
                {
                    ((System.Web.UI.WebControls.ListBox)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));

                }
            }

        }

        /// <summary>
        /// �󶨶���״̬
        /// </summary>
        /// <param name="MyDD"></param>
        public static void BindOrderStatic(System.Web.UI.Control MyDD)
        {

            string[] MyArray = Enum.GetNames(typeof(Pbzx.Model.PBnet_OrderStatic));
            Array MyValue = Enum.GetValues(typeof(Pbzx.Model.PBnet_OrderStatic));
            if (MyDD is System.Web.UI.WebControls.DropDownList)
            {
                for (int i = 0; i < MyArray.Length; i++)
                {
                    ((System.Web.UI.WebControls.DropDownList)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));

                }

            }
            else if (MyDD is System.Web.UI.WebControls.RadioButtonList)
            {
                for (int i = 0; i < MyArray.Length; i++)
                {
                    ((System.Web.UI.WebControls.RadioButtonList)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));

                }


            }
            else if (MyDD is System.Web.UI.WebControls.ListBox)
            {
                for (int i = 0; i < MyArray.Length; i++)
                {
                    ((System.Web.UI.WebControls.ListBox)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));

                }
            }

        }




        /// <summary>
        /// ������
        /// </summary>
        /// <param name="MyDD"></param>
        public static void BindAdClass(System.Web.UI.Control MyDD)
        {
            string[] MyArray = Enum.GetNames(typeof(EadClass));
            Array MyValue = Enum.GetValues(typeof(EadClass));
            if (MyDD is System.Web.UI.WebControls.DropDownList)
            {
                for (int i = 0; i < MyArray.Length; i++)
                {
                    ((System.Web.UI.WebControls.DropDownList)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));

                }

            }

            else if (MyDD is System.Web.UI.WebControls.RadioButtonList)
            {
                for (int i = 0; i < MyArray.Length; i++)
                {
                    ((System.Web.UI.WebControls.RadioButtonList)MyDD).Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));
                }
            }

        }

        /// <summary>
        /// ���û����Ķ�������������
        /// </summary>
        /// <param name="MyDD"></param>
        public static void BindOrderState(ref System.Web.UI.WebControls.DropDownList MyDD)
        {
            string[] MyArray = Enum.GetNames(typeof(PBnet_OrderStaticTip));
            Array MyValue = Enum.GetValues(typeof(PBnet_OrderStaticTip));
            for (int i = 0; i < MyArray.Length; i++)
            {
                MyDD.Items.Add(new ListItem(MyArray[i], Convert.ToString((int)MyValue.GetValue(i))));
            }
            MyDD.Items.Insert(0, new ListItem("����", ""));
            MyDD.Items[0].Selected = true;
            //MyDD.DataSource = MyArray;   //cboDepartmentType�ǽ����������б�������������б�ѡ�е���ת����ö��ֵ�������£�
            //MyDD.DataBind();
        }



        ///<summary>
        /// �������ID�����������
        ///</summary>
        public static string GetadClass(object num)
        {
            int intnum = int.Parse(num.ToString());
            return Enum.GetName(typeof(EadClass), intnum);
        }
        ///<summary>
        /// ����Ƶ��ID�����������
        ///</summary>
        public static string GetadChanl(object num)
        {
            int intnum = int.Parse(num.ToString());
            return Enum.GetName(typeof(EadChanl), intnum);
        }

        ///<summary>
        /// ���ݹ��λ���ID�����������
        ///</summary>
        public static string GetadPlaceType(object num)
        {
            int intnum = int.Parse(num.ToString());
            return Enum.GetName(typeof(EadPlaceType), intnum);
        }


        public static string GetType(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 0:
                    type = "������";
                    break;
                case 1:
                    type = "3������";
                    break;
                case 2:
                    type = "2������";
                    break;
                case 3:
                    type = "1������";
                    break;
                default:
                    type = "��������";
                    break;
            }
            return type;
        }
        /// <summary>
        /// ʹ������
        /// </summary>
        /// <param name="nType"></param>
        /// <returns></returns>
        public static string GetUseType(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 1:
                    type = "<font color=#9900FF>����</font>";
                    break;
                case 2:
                    type = "���";
                    break;
                default:
                    type = "<font color=red>δ֪</font>";
                    break;
            }
            return type;
        }


        public static string GetTimeType(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 1:
                    type = "��ʱ";
                    break;
                case 2:
                    type = "3��";
                    break;
                case 3:
                    type = "����";
                    break;
                case 4:
                    type = "<font color=#ff00ff>1��</font>";
                    break;
                case 5:
                    type = "2��";
                    break;
                case 6:
                    type = "3��";
                    break;
                case 7:
                    type = "<font color=#ff0000>����</font>";
                    break;
                default:
                    type = "<font color=red>δ֪</font>";
                    break;
            }
            return type;
        }

        /// <summary>
        /// �����ʹ������
        /// </summary>
        /// <param name="objUserType"></param>
        /// <returns></returns>
        public static string GetNetUseType(object objUserType)
        {
            string strUserType = objUserType.ToString();
            string result = "";
            switch (strUserType)
            {
                case "1":
                    result = "����";
                    break;
                case "2":
                    result = "����";
                    break;
                case "3":
                    result = "��ʱ";
                    break;
                default:
                    result = "����";
                    break;
            }
            return result;
        }
        /// <summary>
        /// �����ʹ��ֵ
        /// </summary>
        /// <param name="objUserType"></param>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static string GetNetUseValue(object objUserType, object objValue)
        {
            string strUserType = objUserType.ToString();
            string strValue = objValue.ToString();
            string result = "";
            switch (strUserType)
            {
                case "1":
                    result = strValue + "����";
                    break;
                case "2":
                    result = strValue + "��";
                    break;
                default:
                    result = strValue;
                    break;
            }
            return result;
        }

        /// <summary>
        /// ��鵥���棬������棬�����
        /// </summary>
        /// <param name="F_HDSN"></param>
        /// <returns></returns>
        public static string CheckRegType(object F_HDSN)
        {
            string strHdsn = F_HDSN.ToString();

            if (F_HDSN == null)
            {
                return "";
            }
            if (F_HDSN.ToString() == "")
            {
                return "";
            }

            string f_Color = "";
            try
            {
                string strFlag = strHdsn.Substring(4, 1);

                switch (strFlag)
                {
                    case "1":
                        f_Color = "#000000";
                        break;
                    case "8":
                        f_Color = "#009900";
                        break;
                    case "9":
                        f_Color = "#9900FF";
                        break;
                    default:
                        f_Color = "#000000";
                        break;
                }
            }
            catch
            {

                f_Color = "#000000";
            }
            return f_Color;
        }

        /// <summary>
        /// ��ʾע�᷽ʽ
        /// </summary>
        /// <param name="F_HDSNType"></param>
        /// <returns></returns>
        public static string ShowRegType(object F_HDSNType)
        {
            string type = "";
            int intType = int.Parse(F_HDSNType.ToString());
            switch (intType)
            {
                case 0:
                    type = "��ʼֵ";
                    break;
                case 1:
                    type = "Ӳ�����к�";
                    break;
                case 2:
                    type = "C�̾��";
                    break;
                case 8:
                    type = "����ע��";
                    break;
                case 9:
                    type = "�����";
                    break;
                default:
                    type = "δ֪";
                    break;
            }
            return type;
        }
        //�û�����
        public static string GetUserType(object num)
        {
            string User = "";
            int Intnum = int.Parse(num.ToString());
            switch (Intnum)
            {
                case 1:
                    User = "��ͨ";
                    break;
                case 2:
                    User = "VIP";
                    break;
                default:
                    User = "<font color=red>δ֪</font>";
                    break;
            }
            return User;
        }


        //�Ƿ������λ���� �£�
        public static string Getdanwei(object num)
        {
            string DW = "";
            int Intnum = int.Parse(num.ToString());
            switch (Intnum)
            {
                case 1:
                    DW = "����";
                    break;
                case 2:
                    DW = "��";
                    break;
                default:
                    DW = "";
                    break;
            }
            return DW;
        }


        //�û�����
        public static string ShowUserType(object num)
        {
            string F_str = "";
            int intNum = int.Parse(num.ToString());
            switch (intNum)
            {
                case 0:
                    F_str = "��ʼֵ";
                    break;
                case 1:
                    F_str = "����";
                    break;
                case 2:
                    F_str = "�������";
                    break;
                case 3:
                    F_str = "��ʱʹ��";
                    break;
                case 10:
                    F_str = "�շѼ���";
                    break;
                case 11:
                    F_str = "��Ѽ���";
                    break;
                case 20:
                    F_str = "�շѰ���";
                    break;
                case 21:
                    F_str = "��Ѱ���";
                    break;
                case 100:
                    F_str = "����Ա";
                    break;
                case 101:
                    F_str = "��������";
                    break;
                case 102:
                    F_str = "����";
                    break;
                case 103:
                    F_str = "�Ĺ�";
                    break;
                case 104:
                    F_str = "���";
                    break;
                case 105:
                    F_str = "VIP�û�";
                    break;
                case 106:
                    F_str = "����û�";
                    break;
                case 107:
                    F_str = "��̳�û�";
                    break;
                case 190:
                    F_str = "�������";
                    break;
                case 200:
                    F_str = "��ֹʹ��";
                    break;
                default:
                    F_str = "δ֪";
                    break;
            }
            return F_str;
        }

        /// <summary>
        /// ��ʾδ֪״̬
        /// </summary>
        /// <param name="F_HDSNType"></param>
        /// <returns></returns>
        public static string ShowStatus(object F_Status)
        {
            string type = "";
            int intType = int.Parse(F_Status.ToString());
            switch (intType)
            {
                case 0:
                    type = "��ʼֵ";
                    break;
                case 1:
                    type = "����";
                    break;
                case 2:
                    type = "�Ƿ�";
                    break;
                case 3:
                    type = "��λ";
                    break;
                case 4:
                    type = "����";
                    break;
                default:
                    type = "δ֪";
                    break;
            }
            return type;
        }

        /// <summary>
        /// ���ݵȼ���ŵõ����صȼ�
        /// </summary>
        /// <returns></returns>
        public static string GetDownLoadLeval(object objSoftLevel)
        {
            string type = "";
            int intType = int.Parse(objSoftLevel.ToString());
            switch (intType)
            {
                case 9999:
                    type = "�ο�";
                    break;
                case 999:
                    type = "ע���û�";
                    break;
                case 99:
                    type = "�շ��û�";
                    break;
                case 9:
                    type = "VIP�û�";
                    break;
                case 5:
                    type = "����Ա";
                    break;
                default:
                    type = "δ֪";
                    break;
            }
            return type;
        }

        /// <summary>
        /// ������ʱ�䣬������ڷ��غ�ɫ����
        /// </summary>
        /// <param name="nExpireDate"></param>
        /// <returns></returns>
        public static string CheckExpireDate(object nExpireDate)
        {
            string result = "";
            DateTime expDate = DateTime.Now;
            if (!DateTime.TryParse(nExpireDate.ToString(), out expDate))
            {
                return "";
            }
            if (expDate < DateTime.Now)
            {
                result = "<font color=#ff0000>" + expDate.ToShortDateString() + "</font>";
            }
            else
            {
                result = expDate.ToShortDateString();
            }
            return result;
        }

        /// <summary>
        /// ��TextBox���������ԣ��и�ֵ��ȡֵ����
        /// </summary>
        /// <param name="aa">�ؼ�</param>
        /// <param name="key">���ؼ�ͨ��URL��ֵ�ļ�</param>
        /// <param name="isSet">�Ƿ��Ǹ��ؼ���ֵ</param>
        /// <returns></returns>
        public static string BindText(System.Web.UI.WebControls.TextBox txtTemp, string key, bool isSet)
        {
            string strTemp = "";
            if (isSet)
            {
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request[key]))
                {
                    txtTemp.Text = Input.FilterAll(System.Web.HttpContext.Current.Request[key]);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Input.FilterAll(txtTemp.Text.Trim())))
                {
                    strTemp = "&" + key + "=" + txtTemp.Text.Trim();
                }
            }
            return strTemp;
        }

        /// <summary>
        /// ��ChickBox���������ԣ��и�ֵ��ȡֵ����
        /// </summary>
        /// <param name="aa">�ؼ�</param>
        /// <param name="key">���ؼ�ͨ��URL��ֵ�ļ�</param>
        /// <param name="isSet">�Ƿ��Ǹ��ؼ���ֵ</param>
        /// <returns></returns>
        public static string BindChickBox(System.Web.UI.WebControls.CheckBox txtTemp, string key, bool isSet)
        {
            string strTemp = "";
            if (isSet)
            {
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request[key]))
                {
                    if (Input.FilterAll(System.Web.HttpContext.Current.Request[key]) == "1")
                        txtTemp.Checked = true;
                    else
                        txtTemp.Checked = false;
                }
            }
            else
            {
                if (txtTemp.Checked)
                {
                    strTemp = "&" + key + "=1";
                }
                else
                {

                    strTemp = "&" + key + "=0";
                }
            }
            return strTemp;
        }
        /// <summary>
        /// ��DropDownList����RadioButtonList�����������ԣ��и�ֵ��ȡֵ����
        /// </summary>
        /// <param name="aa">�ؼ�</param>
        /// <param name="key">���ؼ�ͨ��URL��ֵ�ļ�</param>
        /// <param name="isSet">�Ƿ��Ǹ��ؼ���ֵ</param>
        /// <returns></returns>
        public static string BindDdlOrRadio(System.Web.UI.Control aa, string key, bool isSet)
        {
            string strTemp = "";
            if (isSet)
            {
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request[key]))
                {
                    string sname = (System.Web.HttpContext.Current.Request[key]);
                    if (sname == "����6 1")
                    {
                        sname = "����6+1";
                    }
                    if (aa is System.Web.UI.WebControls.DropDownList)
                    {
                        ((System.Web.UI.WebControls.DropDownList)aa).SelectedValue = sname;
                    }
                    else if (aa is System.Web.UI.WebControls.RadioButtonList)
                    {
                        ((System.Web.UI.WebControls.RadioButtonList)aa).SelectedValue = sname;
                    }
                }
            }
            else
            {
                if (aa is System.Web.UI.WebControls.DropDownList)
                {
                    string strSelectValue = ((System.Web.UI.WebControls.DropDownList)aa).SelectedValue;
                    if (!string.IsNullOrEmpty(strSelectValue) && strSelectValue != "����")
                    {
                        strTemp = "&" + key + "=" + ((System.Web.UI.WebControls.DropDownList)aa).SelectedValue;
                    }
                    else
                    {
                        strTemp = "";
                    }
                }
                else if (aa is System.Web.UI.WebControls.RadioButtonList)
                {
                    string strSelectValue = ((System.Web.UI.WebControls.RadioButtonList)aa).SelectedValue;
                    if (!string.IsNullOrEmpty(strSelectValue) && strSelectValue != "����")
                    {
                        strTemp = "&" + key + "=" + ((System.Web.UI.WebControls.RadioButtonList)aa).SelectedValue;
                    }
                    else
                    {
                        strTemp = "";
                    }
                }
            }
            return strTemp;
        }

        /// <summary>
        /// US_msg.aspx�õ���������
        /// </summary>
        /// <returns></returns>
        public static string GetExpDate(object objUserType, object objExpireDate, object objStatResult)
        {
            string result = "";
            int intUserType = int.Parse(objUserType.ToString());
            string intExpireDate = objExpireDate.ToString();
            int intStatResult = int.Parse(objStatResult.ToString());
            if (intUserType == 3 || intUserType == 20 || intUserType == 21)
            {
                result = Convert.ToDateTime(objExpireDate.ToString()).ToShortDateString();
            }
            else if (intUserType == 0)
            {
                if (intStatResult == -1)
                {
                    result = "δͳ��";
                }
                else if (intStatResult == 0)
                {
                    result = "<font color='#ff0000'>��������</font>";
                }
                else
                {
                    result = "<font color='#009900'>�������</font>";
                }
            }
            else
            {
                result = "--";
            }
            return result;
        }

        /// <summary>
        /// ����͸�Ϳ������밴�ָ���ÿ��λ�ֿ�
        /// </summary>
        /// <param name="code"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static string FormartCode(string code, string flag)
        {
            if (string.IsNullOrEmpty(flag))
            {
                flag = " ";
            }
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < code.Length; i += 2)
            {
                sb.Append(code.Substring(i, 2) + flag);
            }
            string result = sb.ToString();
            return result.Length > flag.Length ? result.Substring(0, result.Length - flag.Length) : result;
        }
        /// <summary>
        /// �����͸���Ƿ����ظ�����
        /// </summary>
        /// <param name="Checkcode"></param>
        /// <returns></returns>
        public static string showCheckStr(string Checkcode, int max)
        {
            string[] checkCodeSZ = Checkcode.Split(new char[] { ' ' });

            string result = "";

            for (int i = 0; i < checkCodeSZ.Length; i++)
            {
                if (int.Parse(checkCodeSZ[i]) < 1 || int.Parse(checkCodeSZ[i]) > max)
                {
                    result = "���뷶Χ����,���뷶Χ[01��" + max + "]";
                    break;
                }
                for (int j = i + 1; j < checkCodeSZ.Length; j++)
                {
                    if (checkCodeSZ[i] == checkCodeSZ[j])
                    {
                        result = "�������ظ�����";
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// �Ժ����ַ����������򷵻�������ַ���
        /// </summary>
        /// <param name="code">ƴ�Ӻ�ĺ����ַ���</param>
        /// <param name="flag">�ָ���</param>
        /// <returns></returns>
        public static string OrderCode(string code, string flag)
        {
            string result = "";
            if (string.IsNullOrEmpty(flag))
            {
                flag = " ";
            }
            string[] codeSZ = code.Split(new char[] { flag.ToCharArray()[0] });
            Array.Sort(codeSZ);
            foreach (string strTemp in codeSZ)
            {
                result += strTemp;
            }
            return result;
        }

        /// <summary>
        /// �õ���������
        /// </summary>
        /// <param name="lottdate"></param>
        /// <returns></returns>
        /// autor:��
        public static string GetLottDate(string lottdate)
        {
            string result = "";
            string s_temp = "";
            if (lottdate.Length == 0)
            {
                result = "";
                return result;
            }
            if (lottdate.IndexOf('2') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "��";
                }
                s_temp += "��һ";
            }
            if (lottdate.IndexOf('3') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "��";
                }
                s_temp += "�ܶ�";
            }
            if (lottdate.IndexOf('4') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "��";
                }
                s_temp += "����";
            }
            if (lottdate.IndexOf('5') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "��";
                }
                s_temp += "����";
            }
            if (lottdate.IndexOf('6') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "��";
                }
                s_temp += "����";
            }
            if (lottdate.IndexOf('7') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "��";
                }
                s_temp += "����";
            }
            if (lottdate.IndexOf('1') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "��";
                }
                s_temp += "����";
            }
            if (string.IsNullOrEmpty(s_temp))
            {
                s_temp = "��";
            }
            result = "&nbsp;&nbsp;&nbsp;<font color='0000FF'>ÿ" + s_temp + "����</font>";
            int index = ((int)DateTime.Now.DayOfWeek) + 1;
            if (lottdate.IndexOf("" + index.ToString() + "") > -1)
            {
                result += "&nbsp;&nbsp;&nbsp;<font color='FF0000'>���տ���</font>";
            }
            return result;

        }


        /// <summary>
        /// �õ���������1
        /// </summary>
        /// <param name="lottdate"></param>
        /// <returns></returns>
        /// ���ߣ���
        public static string GetLottDate1(string lottdate)
        {
            string s_temp = "";

            if (lottdate.Substring(lottdate.Length - 1, 1) == "D" || lottdate.Substring(lottdate.Length - 1, 1) == "d")
            {
                string result = "";

                if (lottdate.Length == 0)
                {
                    result = "";
                    return result;
                }
                if (lottdate.IndexOf('2') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "��";
                    }
                    s_temp += "��һ";
                }
                if (lottdate.IndexOf('3') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "��";
                    }
                    s_temp += "�ܶ�";
                }
                if (lottdate.IndexOf('4') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "��";
                    }
                    s_temp += "����";
                }
                if (lottdate.IndexOf('5') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "��";
                    }
                    s_temp += "����";
                }
                if (lottdate.IndexOf('6') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "��";
                    }
                    s_temp += "����";
                }
                if (lottdate.IndexOf('7') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "��";
                    }
                    s_temp += "����";
                }
                if (lottdate.IndexOf('1') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "��";
                    }
                    s_temp += "����";
                }
                if (string.IsNullOrEmpty(s_temp))
                {
                    s_temp = "ÿ��";
                }
            }
            else if (lottdate.Substring(lottdate.Length - 1, 1) == "M")
            {
                s_temp = "ÿ" + lottdate.Substring(0, lottdate.Length - 1) + "����һ��";
            }
            else if (lottdate.Substring(lottdate.Length - 1, 1) == "H")
            {
                s_temp = "ÿ" + lottdate.Substring(0, lottdate.Length - 1) + "Сʱһ��";
            }

            //int index = ((int)DateTime.Now.DayOfWeek) + 1;
            //if (lottdate.IndexOf("" + index.ToString() + "") > -1)
            //{
            //    result += "&nbsp;&nbsp;&nbsp;<font color='FF0000'>���տ���</font>";
            //}            
            return s_temp;

        }


        /// <summary>
        /// ����������ʽ���ַ�����ʽΪʱ����ʽ���磺20080112ת����2008-1-12��
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime FormartStrToDate(string str)
        {
            if (str.Length != 8)
            {
                throw new Exception("����λ������");
            }
            return DateTime.Parse(str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-" + str.Substring(6));
        }

        /// <summary>
        /// ��ʱ���ʽ��Ϊ��������ʽ���ַ�����ʽ���磺2008-1-12ת����20080112��
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string FormartDateToStr(DateTime dt)
        {
            string[] dateSZ = dt.ToShortDateString().Split(new char[] { '-' });
            string year = dateSZ[0];
            string month = int.Parse(dateSZ[1]) < 10 ? "0" + dateSZ[1] : dateSZ[1];
            string day = int.Parse(dateSZ[2]) < 10 ? "0" + dateSZ[2] : dateSZ[2];
            return year + month + day;
        }

        /// <summary>
        /// �õ�������������
        /// </summary>
        /// <param name="hits">�������</param>
        /// <returns></returns>
        /// ���ߣ���
        public static string GetNewsFlag(object objHits)
        {
            int hits = int.Parse(objHits.ToString());
            string flag = "";
            if (hits < (WebInit.webBaseConfig.HitsOfHot - 1))
            {
                flag = "<font color='blue'>��</font>";
            }
            else
            {
                flag = "<font color='red'>��</font>";
            }
            return flag;
        }

        /// <summary>
        /// �����Ƿ����ȵ����ţ������ȵ�����������ѯ�ַ���
        /// </summary>
        /// <param name="isHot">�Ƿ����ȵ�����</param>
        /// <returns>�ȵ�����������ѯ�ַ���</returns>
        public static string CheckNewsHot(bool isHot)
        {
            if (isHot)
            {
                return " and IntClick >'" + (WebInit.webBaseConfig.HitsOfHot - 1) + "'";
            }
            else
            {
                return " and IntClick <'" + (WebInit.webBaseConfig.HitsOfHot) + "'";
            }
        }

        /// <summary>
        /// �����Ƿ����ȵ����⣬�����ȵ�����������ѯ�ַ���
        /// </summary>
        /// <param name="isHot">�Ƿ����ȵ�����</param>
        /// <returns>�ȵ�����������ѯ�ַ���</returns>
        public static string CheckQuestionHot(bool isHot)
        {
            if (isHot)
            {
                return " and Views >'" + (WebInit.webBaseConfig.HitsOfHot - 1) + "'";
            }
            else
            {
                return " and Views <'" + (WebInit.webBaseConfig.HitsOfHot) + "'";
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="length">���ɳ���</param>
        /// <returns></returns>
        public static string Number(int Length)
        {
            return Number(Length, false);
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="Length">���ɳ���</param>
        /// <param name="Sleep">�Ƿ�Ҫ������ǰ����ǰ�߳���ֹ�Ա����ظ�</param>
        /// <returns></returns>
        /// ���ߣ���
        public static string Number(int Length, bool Sleep)
        {
            if (Sleep)
                System.Threading.Thread.Sleep(3);
            string result = "";
            System.Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                result += random.Next(10).ToString();
            }
            return result;
        }


        /// <summary>
        /// ������ת���ɺ��֣�����1:һ��2���� ...
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        /// ���ߣ���
        public static string NumToHanZi(int i)
        {
            switch (i)
            {
                case 1:
                    return "һ";
                case 2:
                    return "��";
                case 3:
                    return "��";
                case 4:
                    return "��";
                case 5:
                    return "��";
                case 6:
                    return "��";
                case 7:
                    return "��";
                case 8:
                    return "��";
                case 9:
                    return "��";
                case 0:
                    return "��";
                default:
                    return i.ToString();
            }

        }

        //
        /// <summary>
        /// ���������ţ���С��ţ����������ȷ�����䳤��
        /// </summary>       
        /// <param name="maxNum">������</param>
        /// <param name="minNum">�������</param>
        /// <param name="qjGS">�������</param>
        /// <returns>���䳤������</returns>
        /// ʱ�䣺2009-07-16
        ///���ߣ�����ӭ 

        public static int[] CreateQuJian(int maxNum, int minNum, int qjGS)
        {
            int[] qujianSZ = new int[qjGS];
            int wholeNumCount = maxNum - minNum + 1;
            int yuShu = wholeNumCount % qjGS;
            // ƽ���������
            int intBase = wholeNumCount / qjGS;
            for (int i = 0; i < qjGS; i++)
            {
                qujianSZ[i] = intBase;
            }
            // ����ʣ�µģ�
            int nTemp = 0;
            while (yuShu > 1)
            {
                // ���ʣ�´���2��������߿�ʼ���Ⱥ��ǰ����
                qujianSZ[nTemp]++;
                qujianSZ[qjGS - 1 - nTemp]++;
                nTemp++;
                yuShu -= 2;
            }
            if (yuShu == 1)
            {
                // ֻʣ1�������������������������м䣬����ŵ����һ������
                if (qjGS % 2 == 0)
                    qujianSZ[qjGS - 1 - nTemp]++;
                else
                    qujianSZ[qjGS / 2]++;
            }
            return qujianSZ;
        }


        #region ��֤�û����Ƿ���Ч
        /// <summary>
        /// ��֤�û����Ƿ���Ч
        /// </summary>
        public static bool ValidateUserFormat(string userName)
        {
            string Regex = "^[a-zA-Z][a-zA-Z0-9_]{6,18}$";
            return RegexString.ValidateString(userName, Regex);
        }
        #endregion

        #region ��֤�����Ƿ���Ч
        /// <summary>
        /// ��֤�����Ƿ���Ч
        /// </summary>
        public static bool ValidatePassWordFormat(string userName)
        {
            string Regex = "^{6,18}$";
            return RegexString.ValidateString(userName, Regex);
        }
        #endregion


        /// <summary>
        /// �ж��ַ������Ƿ�������
        /// ʱ�䣺2009-07-30
        /// ���ߣ�����ӭ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsContainsNum(string input)
        {
            bool has = false;
            for (int i = 0; i < input.Length; i++)
            {
                if ("0123456789-".Contains(input.Substring(i, 1)))
                {
                    has = true;
                    break;
                }
            }
            return has;
        }


        #region "��ȡ��½�û���"
        /// <summary>
        /// ��ȡ��½�û�UserID,���δ��½Ϊ0
        /// </summary>
        public static string Get_UserName
        {
            get
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("��¼", "User.Identity.IsAuthenticated��" + HttpContext.Current.User.Identity.Name.ToString() + "��user:" + HttpContext.Current.User.ToString() + "��ʱ�䣺"+DateTime.Now+" \r\n", true, true);
           

                return HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name.Split(new char[] { '&' })[0] : "0";

            }

        }
        #endregion

        #region "��ȡ��½�û�pwd"
        /// <summary>
        /// ��ȡ��½�û�pwd,���δ��½Ϊ0
        /// </summary>
        public static string Get_UserPwd
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name.Split(new char[] { '&' })[1] : "0";

            }

        }
        #endregion

        #region "��ȡ��½�û���̳ID"
        /// <summary>
        /// ��ȡ��½�û�pwd,���δ��½Ϊ0
        /// </summary>
        public static string Get_UserID
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name.Split(new char[] { '&' })[2] : "0";

            }

        }
        #endregion


        /// <summary>
        /// ��λ�Ӻ͵�λ��Ϊ1
        /// </summary>
        /// <returns></returns>
        public static int BSUM(string code)
        {
            string tempCode = code.Replace("-", "");
            do
            {
                int intTemp = 0;
                for (int i = 0; i < tempCode.Length; i++)
                {
                    intTemp = intTemp + int.Parse(tempCode.Substring(i, 1));
                }
                tempCode = intTemp.ToString();

            } while (tempCode.Length > 1);
            return int.Parse(tempCode);
        }


        /// <summary>
        /// ȡ���һλ
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int END(int code)
        {
            return int.Parse(code.ToString().Substring(code.ToString().Length - 1, 1));
        }

        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string Qhe(string code)
        {
            int intTemp = 0;
            for (int i = 0; i < code.Length; i++)
            {
                intTemp = intTemp + int.Parse(code.Substring(i, 1));
            }
            return intTemp.ToString();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int Qkd(string code)
        {
            char[] charSZ = code.ToCharArray();
            char min = charSZ[0];
            char max = charSZ[0];
            for (int i = 0; i < charSZ.Length; i++)
            {
                if (charSZ[i] <= min)
                {
                    min = charSZ[i];
                }
                if (charSZ[i] >= max)
                {
                    max = charSZ[i];
                }
            }
            return Convert.ToInt32(max - min);
        }

        /// <summary>
        /// �ж��ύ�Ƿ������ⲿ
        /// </summary>
        /// <returns></returns>
        public static bool ChkPost()
        {
            bool post = false;
            string server_V1 = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
            string server_V2 = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            if (server_V1.Substring(7, server_V2.Length) != server_V2)
            {
                post = false;
            }
            else
            {
                post = true;
            }
            return post;
        }

        /// <summary>
        /// ���û����ָı����ƴ�����û��ȼ��Ƿ���Ҫ����
        /// </summary>
        /// <param name="point"></param>
        /// <param name="userGrade"></param>
        /// <param name="userID"></param>
        public static void CheckUserGrade(string point, string userGrade, string userID)
        {

            object objUserTitle = DbHelperSQL.GetSingle("SELECT top 1 GradeName FROM PBnet_ask_GradeConfig WHERE (" + point + " BETWEEN MinPoint AND MaxPoint)");
            if (objUserTitle != null)
            {
                string title = objUserTitle.ToString();
                if (userGrade != title)
                {
                    DbHelperSQL.ExecuteSql(" update PBnet_ask_User set Title='" + title + "' where ID=" + userID + " ");
                }
            }

        }

        public static string GetUserTitle(string point)
        {
            DataSet objUserTitle = DbHelperSQL.Query("SELECT top 1 GradeName,MinPoint  FROM PBnet_ask_GradeConfig WHERE (" + point + " BETWEEN MinPoint AND MaxPoint)");
            if (objUserTitle.Tables.Count > 0 && objUserTitle.Tables[0].Rows.Count > 0)
            {
                return objUserTitle.Tables[0].Rows[0]["GradeName"].ToString();
            }
            else
            {
                int minPoint = Convert.ToInt32(objUserTitle.Tables[0].Rows[0]["MinPoint"]);
                if (minPoint > 1000)
                {
                    return DbHelperSQL.GetSingle("select top 1 GradeName from PBnet_ask_GradeConfig order by  MinPoint desc ").ToString();
                }
                else
                {
                    return DbHelperSQL.GetSingle("select top 1 GradeName from PBnet_ask_GradeConfig order by  MinPoint asc ").ToString();
                }
            }
        }

        public static string GetUserGrade(string point)
        {
            DataSet objUserTitle = DbHelperSQL.Query("SELECT top 1 GradeID,GradeName,MinPoint  FROM PBnet_ask_GradeConfig WHERE (" + point + " BETWEEN MinPoint AND MaxPoint)");
            if (objUserTitle.Tables.Count > 0 && objUserTitle.Tables[0].Rows.Count > 0)
            {
                return objUserTitle.Tables[0].Rows[0]["GradeID"].ToString();
            }
            else
            {
                int minPoint = Convert.ToInt32(objUserTitle.Tables[0].Rows[0]["MinPoint"]);
                if (minPoint > 1000)
                {
                    return DbHelperSQL.GetSingle("select top 1 GradeID from PBnet_ask_GradeConfig order by  MinPoint desc ").ToString();
                }
                else
                {
                    return DbHelperSQL.GetSingle("select top 1 GradeID from PBnet_ask_GradeConfig order by  MinPoint asc ").ToString();
                }
            }
        }


        /// <summary>
        /// ��֤��ע��
        /// </summary>
        /// <param name="code"></param>
        /// <param name="gzCode"></param>
        /// <returns></returns>
        public static string[] FormartCSTgzCode(string code, string gzCode)
        {
            string[] strReturn = new string[gzCode.Length + 1];
            int totalcount = 0;
            for (int i = 0; i < gzCode.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < code.Length; j++)
                {
                    if (gzCode[i] == code[j])
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    strReturn[i] = gzCode[i].ToString() + "*";
                    totalcount++;
                }
                else
                {
                    strReturn[i] = gzCode[i].ToString();
                }
            }
            strReturn[gzCode.Length] = totalcount.ToString();
            return strReturn;
        }

        ///�����β��
        public static int HW(string he)
        {
            return int.Parse(he.Substring(he.Length - 1, 1));
        }


        #region ��ȡ���ﳵCartGuid
        public static string GetCartGuid()
        {
            Guid guid = Guid.NewGuid();
//            HttpCookie ck = HttpContext.Current.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName];
            HttpCookie cookie = new HttpCookie("PinbleShopOnline");

            if (HttpContext.Current.Request.Cookies["PinbleShopOnline"] != null && HttpContext.Current.Request.Cookies["PinbleShopOnline"]["CartGuid"] != null)
            {
                if (HttpContext.Current.Request.Cookies["PinbleShopOnline"]["CartGuid"].ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    return HttpContext.Current.Request.Cookies["PinbleShopOnline"]["CartGuid"].ToString();
                }
            }
            if (HttpContext.Current.Request.Cookies["PinbleShopOnline"] != null && HttpContext.Current.Request.Cookies["PinbleShopOnline"]["CartGuid"] != null)
            {
                if (HttpContext.Current.Request.Cookies["PinbleShopOnline"]["CartGuid"].ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    //if (ck != null)
                    //{
                    //    cookie.Expires = ck.Expires;
                    //    cookie.Domain = ck.Domain;
                    //}
                    //else
                    //{ 
                    cookie.Expires = DateTime.Now.AddDays(90);
                    //}
                    cookie.Values.Add("CartGuid", guid.ToString());
                    HttpContext.Current.Response.AppendCookie(cookie);
                    return guid.ToString();
                }
            }
            //if (ck != null)
            //{
            //    cookie.Expires = ck.Expires;
            //    cookie.Domain = ck.Domain;
            //}
            //else
            //{ 
            cookie.Expires = DateTime.Now.AddDays(90);
            //}
            cookie.Values.Add("CartGuid", guid.ToString());
            HttpContext.Current.Response.AppendCookie(cookie);
            return guid.ToString();
        }
        #endregion


        #region ��ȡ���ﳵCartGuid
        public static string GetDelegateCartGuid()
        {
            Guid guid = Guid.NewGuid();
            HttpCookie ck = HttpContext.Current.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName];
            HttpCookie cookie = new HttpCookie("PinbleDelegateOnline");

            if (HttpContext.Current.Request.Cookies["PinbleDelegateOnline"] != null && HttpContext.Current.Request.Cookies["PinbleShopOnline"]["CartGuid"] != null)
            {
                if (HttpContext.Current.Request.Cookies["PinbleDelegateOnline"]["CartGuid"].ToString() != "00000000-0000-0000-0000-000000000000")
                {
                    return HttpContext.Current.Request.Cookies["PinbleDelegateOnline"]["CartGuid"].ToString();
                }
            }
            if (HttpContext.Current.Request.Cookies["PinbleDelegateOnline"] != null && HttpContext.Current.Request.Cookies["PinbleShopOnline"]["CartGuid"] != null)
            {
                if (HttpContext.Current.Request.Cookies["PinbleDelegateOnline"]["CartGuid"].ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    //if (ck != null)
                    //{
                    //    cookie.Expires = ck.Expires;
                    //    cookie.Domain = ck.Domain;
                    //}
                    //else
                    //{ 
                    cookie.Expires = DateTime.Now.AddDays(90);
                    //}
                    cookie.Values.Add("CartGuid", guid.ToString());
                    HttpContext.Current.Response.AppendCookie(cookie);
                    return guid.ToString();
                }
            }
            //if (ck != null)
            //{
            //    cookie.Expires = ck.Expires;
            //    cookie.Domain = ck.Domain;
            //}
            //else
            //{ 
            cookie.Expires = DateTime.Now.AddDays(90);
            //}
            cookie.Values.Add("CartGuid", guid.ToString());
            HttpContext.Current.Response.AppendCookie(cookie);
            return guid.ToString();
        }
        #endregion


        #region  ���ؼ�����text�б�ʾ,���ر�ʾ���text
        public static string SetKeyWordInText(string text, string keyWord)
        {

            if (string.IsNullOrEmpty(keyWord))
                return text;

            string textLower = text.ToLower();
            int indexKeyWord = textLower.IndexOf(keyWord.ToLower());

            if (indexKeyWord >= 0)
            {
                string tempStr = text.Remove(indexKeyWord, keyWord.Length);
                string newKeyWord = string.Format("<span style='color:red;'>{0}</span>", keyWord);
                string newText = tempStr.Insert(indexKeyWord, newKeyWord);

                return newText;
            }
            else
            {

                return text;
            }
        }
        #endregion


        public static DataRow GetCurrentUser()
        {
            DataSet dsUser = DbHelperSQLBBS.Query("select * from Dv_User where UserName='" + Get_UserName + "' ");
            if (!(dsUser.Tables.Count > 0 && dsUser.Tables[0].Rows.Count > 0))
            {
                return null;
            }
            else
            {
                return dsUser.Tables[0].Rows[0];
            }
        }

        #region ת��Ϊ����һ��Ҹ�ʽ
        public static string FormatMoney(object money)
        {
            decimal deMoney = Convert.ToDecimal(money);
            return string.Format("{0:C2}", deMoney);
        }
        #endregion

        /// <summary>
        /// ���㹺�ﳵ���м۸�
        /// </summary>
        /// <returns></returns>
        public static decimal CalRowPrice(object objQuantity, object objRegType)
        {
            decimal result = 0;
            int quantity = Convert.ToInt32(objQuantity);
            string regType = objRegType.ToString();

            if (!string.IsNullOrEmpty(regType))
            {
                string[] regSZ = regType.Split(new char[] { '|' });
                if (regSZ.Length > 1 && !string.IsNullOrEmpty(regSZ[1]))
                {
                    string[] priceSZ = regSZ[1].Split(new char[] { '&' });
                    decimal myprice = 0;
                    if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                    {
                        myprice = decimal.Parse(priceSZ[0]) * decimal.Parse(priceSZ[1]);
                    }
                    else
                    {
                        myprice = Convert.ToDecimal(regSZ[1]);
                    }
                    result = myprice * quantity;
                }
            }
            return result;
        }

        /// <summary>
        /// ����У����
        /// </summary>
        /// <returns></returns>
        public static string GetCheckCode(string temp)
        {
            string num = temp.Substring(2);
            //3λ��
            int threeAdd = AddNum(num, 3);
            //��λ��
            int twoAdd = AddNum(num, 2);
            //һλ��
            int oneAdd = AddNum(num, 1);
            int tempHe = threeAdd + twoAdd + oneAdd;


            return string.Format("{0:D3}", (tempHe % 1000));
        }

        /// <summary>
        /// ��λ��
        /// </summary>
        /// <returns></returns>
        public static int AddNum(string num, int step)
        {
            int result = 0;
            for (int i = 0; i < num.Length; i += step)
            {
                if ((i + step) > num.Length)
                {
                    result += int.Parse(num.Substring(i));
                    break;
                }
                result += int.Parse(num.Substring(i, step));
            }
            return result;
        }

        /// <summary>
        /// ��ʽ����ԱȨ���ַ���
        /// </summary>
        /// <param name="objNum"></param>
        /// <returns></returns>
        public static string AdminPowerSettingFormart(object objNum)
        {
            int length = DbHelperSQL.GetSingle("select max(ID)  from PBnet_Module ").ToString().Length;
            string strFormarter = "{0:D" + length + "}";
            return string.Format(strFormarter, Convert.ToInt32(objNum));
        }

        /// <summary>
        /// ����ʱ�����м���һ�쿪������
        /// </summary>
        /// <param name="timeList"></param>
        /// <returns></returns>
        public static string CalLotteryCout(string timeList)
        {
            string strList = timeList;
            string[] listCount = strList.Split(new char[] { '&' });
            int count1 = 0;
            int count2 = 0;
            if (string.IsNullOrEmpty(strList))
            {
                count1 = 1;
            }
            else if (listCount.Length > 1 && !string.IsNullOrEmpty(listCount[1]))
            {
                count1 = listCount[0].Split(new char[] { '|' }).Length;
                count2 = listCount[1].Split(new char[] { '|' }).Length;
            }
            else
            {
                count1 = listCount[0].Split(new char[] { '|' }).Length;
            }
            return Convert.ToString(count1 + count2);
        }

        //�õ�����ʱ����
        public static int CetLotteryJG(object objTime)
        {
            if (objTime != null && !string.IsNullOrEmpty(objTime.ToString()))
            {
                string[] tmSZ = objTime.ToString().Split(new char[] { '|' });
                TimeSpan tsStart = new TimeSpan();
                TimeSpan tsEnd = new TimeSpan();
                if (!TimeSpan.TryParse(tmSZ[0], out tsStart) || !TimeSpan.TryParse(tmSZ[1], out tsEnd))
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('ʱ����������!')</script>");
                    return -1;
                }
                else
                {
                    int jg = 0;
                    tsEnd.Subtract(tsStart);
                    while (tsStart < tsEnd)
                    {
                        tsStart = tsStart.Add(TimeSpan.FromMinutes(1));
                        jg++;
                    }
                    return jg;
                }
            }
            else
            {
                return -1;
            }
        }

        //�õ��ַ����ȣ�һ������ռ�����ַ���
        public static int GetStrLen(String ss)
        {
            Char[] cc = ss.ToCharArray();
            int intLen = ss.Length;
            int i;
            if ("����".Length == 4)
            {
                //�Ƿ� ���� �� ƽ̨
                return intLen;
            }
            for (i = 0; i < cc.Length; i++)
            {
                if (Convert.ToInt32(cc[i]) > 255)
                {
                    intLen++;
                }
            }
            return intLen;
        }

        /// <summary>
        /// ���ﳵ��������֤���Ƿ�Ϸ�
        /// </summary>
        /// <param name="F_HDSN"></param>
        /// <returns></returns>
        public static string CheckCartRegType(object F_HDSN, string regType, string ProductID)
        {
            //string result = "";
            string strHdsn = F_HDSN.ToString();
            //��֤�����Ƿ���16λstart
            if (strHdsn.Length != 16)
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            //��֤�����Ƿ���16λend

            string strFlag = strHdsn.Substring(4, 1);
            if (Convert.ToInt32(strFlag) < 5)
            {
                strFlag = "1";
            }
            string rzmType = regType.Split(new char[] { '|' })[0];
            string strF_HDSN = F_HDSN.ToString();
            //���ݵ���λ�ж���������Ƿ���ȷstart
            if (string.IsNullOrEmpty(rzmType))
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            if (rzmType == "7")
            {
                rzmType = "9";
            }
            if (rzmType != strFlag)
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            //���ݵ���λ�ж���������Ƿ���ȷend

            //������֤���3λ�ж�����Ƿ���ȷstart
            object objCstID = DbHelperSQL.GetSingle(" select CstID from PBnet_Product where pb_SoftID='" + ProductID + "'  ");
            int cstID = 0;
            try
            {
                cstID = Convert.ToInt32(objCstID);
            }
            catch (Exception ex)
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            string strCstID = cstID.ToString();
            if (strCstID.Length < 3)
            {
                strCstID = "0" + strCstID;
            }
            if (strF_HDSN.Substring(strF_HDSN.Length - 3, 3) != strCstID)
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            //������֤���3λ�ж�����Ƿ���ȷstart

            //��֤��֤��У��λstart
            string strTempF_HDSN = strF_HDSN.Substring(0, 5) + "000" + strF_HDSN.Substring(8);
            // ��λһ��У���
            int nTemp = 0;
            for (int i = 0; i < 16; i += 3)
            {
                if ((i + 3) > 16)
                {
                    break;
                }
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 3));

            }
            // ��λһ��У���
            for (int i = 0; i < 16; i += 2)
            {
                if ((i + 2) > 16)
                {
                    break;
                }
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 2));

            }
            // һλУ���
            for (int i = 0; i < 16; i++)
            {
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 1));
            }
            nTemp %= 1000;

            if (int.Parse(strF_HDSN.Substring(5, 3)) != int.Parse(nTemp.ToString()))
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            return "";
        }

        /// <summary>
        /// ���ﳵ��������֤���Ƿ�Ϸ�
        /// </summary>
        /// <param name="F_HDSN"></param>
        /// <returns></returns>
        public static string CheckCartRegTypeCst(object F_HDSN, string regType, string CstID)
        {
            //string result = "";
            string strHdsn = F_HDSN.ToString();
            //��֤�����Ƿ���16λstart
            if (strHdsn.Length != 16)
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            //��֤�����Ƿ���16λend

            string strFlag = strHdsn.Substring(4, 1);
            if (Convert.ToInt32(strFlag) < 5)
            {
                strFlag = "1";
            }
            string rzmType = regType.Split(new char[] { '|' })[0];
            string strF_HDSN = F_HDSN.ToString();


            //���ݵ���λ�ж���������Ƿ���ȷstart
            if (string.IsNullOrEmpty(rzmType))
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            if (rzmType == "7")
            {
                rzmType = "9";
            }
            if (rzmType != strFlag)
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            //���ݵ���λ�ж���������Ƿ���ȷend

            //������֤���3λ�ж�����Ƿ���ȷstart
            int cstID = 0;
            try
            {
                cstID = Convert.ToInt32(CstID);
            }
            catch (Exception ex)
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            string strCstID = cstID.ToString();
            if (strCstID.Length < 3)
            {
                strCstID = "0" + strCstID;
            }
            if (strF_HDSN.Substring(strF_HDSN.Length - 3, 3) != strCstID)
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            //������֤���3λ�ж�����Ƿ���ȷstart

            //��֤��֤��У��λstart
            string strTempF_HDSN = strF_HDSN.Substring(0, 5) + "000" + strF_HDSN.Substring(8);
            // ��λһ��У���
            int nTemp = 0;
            for (int i = 0; i < 16; i += 3)
            {
                if ((i + 3) > 16)
                {
                    break;
                }
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 3));
            }
            // ��λһ��У���
            for (int i = 0; i < 16; i += 2)
            {
                if ((i + 2) > 16)
                {
                    break;
                }
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 2));
            }
            // һλУ���
            for (int i = 0; i < 16; i++)
            {
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 1));
            }
            nTemp %= 1000;
            if (strF_HDSN.Substring(5, 3) != nTemp.ToString())
            {
                return "����֤��Ǳ������֤�룬�����º�ʵ��������룡";
            }
            return "";
        }


        /// <summary>
        /// ע�����ת�����״����±�
        /// </summary>
        /// <param name="regType"></param>
        /// <returns></returns>
        public static int ChangeRegType2Int(string regType)
        {
            //int result = -1;
            switch (regType)
            {
                case "8":
                    return 0;
                case "1":
                    return 1;
                case "9":
                    return 2;
                case "7":
                    return 3;
                case "6":
                    return 4;
                case "-1":
                    return -1;

                default:
                    return -1;
            }
        }
        #region ��������ַ���

        public static string CreateVerifyCode(int codeLen)
        {
            int length = 4;
            string codeSerial = "2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
            if (codeLen == 0)
            {
                codeLen = length;
            }

            string[] arr = codeSerial.Split(',');

            string code = "";

            int randValue = -1;

            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));

            for (int i = 0; i < codeLen; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);

                code += arr[randValue];
            }

            return code.ToLower();
        }
        public string CreateVerifyCode()
        {
            return CreateVerifyCode(0);
        }
        #endregion

        /// <summary>
        /// ����������������Ƿ�Ϸ�
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CheckIsNum(string name, string text, int min, int max)
        {
            int result = 0;
            if (!int.TryParse(text, out result))
            {
                return name + "��ʽ����";
            }
            else if (result < min)
            {
                return name + "��������" + min + "��";
            }
            else if (result > max)
            {
                return name + "���ܴ���" + max + "��";
            }
            return "";
        }

        /// <summary>
        /// ���ɶ�����
        /// </summary>
        /// <param name="prefix">ǰ׺</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        public static string CreateOrderID(string prefix, string tableName)
        {
            string orderID = null;
            DateTime now = DateTime.Now;
            //��
            string year = now.Year.ToString();
            year = year.Substring(year.Length - 2, 2);
            //��
            string month = now.Month.ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            //��
            string day = now.Day.ToString();
            if (day.Length < 2)
            {
                day = "0" + day;
            }
            string tempOrder = "";
            //���¶�����
            object objLastOrder = DbHelperSQL.GetSingle("select top 1 OrderID from " + tableName + " order by OrderDate desc ");
            string lastOrder = "";

            Random rd = new Random();
            int number = rd.Next(111, 190);
            if (objLastOrder == null)
            {
                string strStart = prefix + year + month + day + "00" + number.ToString() + "0";
                lastOrder = strStart.Substring(0, 8) + Method.GetCheckCode(strStart) + strStart.Substring(strStart.Length - 5, 5);
            }
            else
            {
                lastOrder = objLastOrder.ToString();
            }
            //��С������������
            string nyr = lastOrder.Substring(2, 6);
            if (nyr != year + month + day)
            {
                tempOrder = prefix + year + month + day + "00" + number.ToString();
                string tempOrderID = tempOrder.Substring(0, 8) + Method.GetCheckCode(tempOrder) + tempOrder.Substring(tempOrder.Length - 5, 5);
                orderID = checkCFOrderID(prefix, tableName, tempOrderID);
            }
            else
            {
                orderID = checkCFOrderID(prefix, tableName, lastOrder);
            }
            return orderID;
        }

        /// <summary>
        /// ��鶩���Ƿ��ظ�
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="tableName"></param>
        /// <param name="orderID"></param>
        /// <returns></returns>
        private static string checkCFOrderID(string prefix, string tableName, string orderID)
        {
            DateTime now = DateTime.Now;
            //��
            string year = now.Year.ToString();
            year = year.Substring(year.Length - 2, 2);
            //��
            string month = now.Month.ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            //��
            string day = now.Day.ToString();
            if (day.Length < 2)
            {
                day = "0" + day;
            }
            string serialNum = orderID.Substring(11, 5);
            int intTempNum = int.Parse(serialNum) + 1;
            string serialNumNow = string.Format("{0:D5}", intTempNum);
            string tempOrder = prefix + year + month + day + serialNumNow;
            orderID = tempOrder.Substring(0, 8) + Method.GetCheckCode(tempOrder) + tempOrder.Substring(tempOrder.Length - 5, 5);
            if (DbHelperSQL.Exists("select count(*) from " + tableName + " where OrderID='" + orderID + "'"))
            {
                orderID = checkCFOrderID(prefix, tableName, orderID);
            }
            return orderID;
        }

        /// <summary>
        /// ����ע����
        /// </summary>
        /// <param name="type">()</param>
        /// <returns></returns>
        public static string CreateSerial(int type)
        {
            // return CM.MyMethod('1');                 
            return "1234567890";
        }

        /// <summary>
        /// �����ļ�·�������ַ���
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetEmailContent(string path)
        {
            string result = "";
            try
            {
                StringWriter strHTML = new StringWriter();
                System.Web.UI.Page myPage = new Page();   //System.Web.UI.Page���и�Server��������Ҫ����һ����
                myPage.Server.Execute(path, strHTML);    //��asp_net.aspx���ڿͻ�����ʾ��html���ݶ�����strHTML��
                result = strHTML.ToString();

                //StreamWriter sw = new StreamWriter(strSavePath+strSaveFile,true,System.Text.Encoding.GetEncoding("GB2312"));
                //�½�һ���ļ�Test.htm���ļ���ʽΪGB2312
                //sw.Write(strHTML.ToString());            
                //��strHTML�е��ַ�д��Test.htm��
                strHTML.Close();
                //�ر�StringWriter 
                //sw.Close();                                    
                //�ر�StreamWriter 
            }
            catch
            {
            }


            //try
            //{
            //    System.IO.TextWriter tw = null;
            //    System.Web.HttpContext.Current.Server.Execute(path, tw,true);
            //    tw.Write(result);
            //}catch(Exception ex)
            //{
            //    throw ex;
            //}
            return result;

        }
        /// <summary>
        /// ����Email��֤�����п���֤״̬ID�õ���֤״̬����
        /// </summary>
        /// <param name="objState"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string[] GetYZNameByState(object objState, string type)
        {
            string[] result = new string[2];
            string strState = objState.ToString();
            switch (strState)
            {
                case "0":
                    result[0] = "δ��֤";
                    result[1] = "������֤";
                    break;
                case "1":
                    result[0] = "��֤��";
                    if (type == "1")
                    {
                        result[1] = "Email��֤";
                    }
                    else if (type == "2")
                    {
                        result[1] = "";
                    }
                    else
                    {
                        result[1] = "��֤";
                    }
                    break;
                case "2":
                    result[0] = "��֤ʧ��";
                    result[1] = "����������֤";
                    break;
                case "3":
                    result[0] = "��֤ͨ��";
                    result[1] = "";
                    break;
                case "4":
                    result[0] = "��֤��";
                    result[1] = "���п���֤";
                    break;

            }
            return result;
        }



        public static string GetRealUserSateByState(object objState)
        {
            string result = "";
            switch (objState.ToString())
            {
                case "0":
                    return "δ��ͨ�߼��û�";
                case "1":
                    return "δ���";
                case "2":
                    return "����";
                case "3":
                    return "���δͨ��";
                case "10":
                    return "����";
            }
            return result;
        }

        /// <summary>
        /// ����������֤�룬0.01-0.19,��ʽΪС���������λ
        /// </summary>
        /// <returns></returns>
        public static string CreateBankYZCode()
        {
            System.Random random = new Random();
            int number = random.Next(1, 19);

            Decimal result = Convert.ToDecimal(number) / 100;
            string temp = result.ToString("0.00");
            return temp;
        }

        /// <summary>
        /// �����������ʹ���õ�����������
        /// </summary>
        /// <param name="nType"></param>
        /// <returns></returns>
        public static string GetLinksType(object nType)
        {
            string type = "";
            int intType = int.Parse(nType.ToString());
            switch (intType)
            {
                case 0:
                    type = "ͼƬ����";
                    break;
                case 1:
                    type = "��������";
                    break;
                default:
                    type = "δ֪����";
                    break;
            }
            return type;
        }

        /// <summary>
        /// ƴ����-��������״̬ID����״̬����
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns></returns>
        public static string GetQuestionStateName(object stateID)
        {
            switch (stateID.ToString())
            {
                case "0":
                    return "�����";
                case "1":
                    return "�ѽ��";
                case "2":
                    return "�ѹر�";
                case "3":
                    return "��ɾ��";
                default:
                    return "";
            }
        }

        /// <summary>
        /// �õ���ǰ������ۿ�
        /// </summary>
        /// <returns></returns>
        public static decimal GetCurrentPricePercent(object orderID)
        {
            string uName = DbHelperSQL.GetSingle("select top 1 UserName from PBnet_Orders where OrderID='" + orderID.ToString() + "' ").ToString();
            decimal result = 100;
            object objPP = DbHelperSQL1.GetSingle("select PricePercent from AgentInfo where UserName='" + uName + "' " + Method.Where_AgentInfo);
            if (objPP == null)
            {
                return 1;
            }

            if (decimal.TryParse(objPP.ToString(), out result))
            {
                return result / 100;
            }
            else
            {
                return 1;
            }

        }

        /// <summary>
        /// �õ���ǰ������ۿ�
        /// </summary>
        /// <returns></returns>
        public static decimal GetCurrentPricePercentByUname(object uName)
        {
            decimal result = 100;
            object objPP = DbHelperSQL1.GetSingle("select PricePercent from AgentInfo where UserName='" + uName.ToString() + "' " + Method.Where_AgentInfo);
            if (objPP == null)
            {
                try
                {
                    if (HttpContext.Current.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName] != null)
                    {
                        HttpContext.Current.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddMinutes(-1);
                    }

                    HttpCookie cookieUClass = HttpContext.Current.Request.Cookies["UserClass"];
                    if (cookieUClass != null)
                    {
                        cookieUClass.Expires = DateTime.Today.AddDays(-10);
                        cookieUClass.Domain = System.Web.Security.FormsAuthentication.CookieDomain;
                        HttpContext.Current.Response.Cookies.Add(cookieUClass);
                    }
                    System.Web.Security.FormsAuthentication.SignOut();
                    // System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.UrlReferrer.AbsoluteUri);
                    System.Web.HttpContext.Current.Response.Write("<script>alert('���Ĵ�����Ϣ�Ѿ��ı䣬�����µ�¼��');top.location='/login.aspx';</script>");
                    System.Web.HttpContext.Current.Response.End();
                    return result / 100;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            decimal.TryParse(objPP.ToString(), out result);
            return result / 100;
        }

        /// <summary>
        /// ���㵱ǰ���ﳵ��Ʒ�ܼ۸�()
        /// </summary>
        /// <returns></returns>
        public static decimal CalShoppingCartPrice(DataSet shoppingCartList, bool IsAddPort)
        {
            decimal SumPrice = 0;
            bool hasRJG = false;
            if (shoppingCartList.Tables.Count < 1)
            {
                return SumPrice;
            }
            foreach (DataRow row in shoppingCartList.Tables[0].Rows)
            {
                string regType = row["RegType"].ToString();
                string[] strRegType = regType.Split(new char[] { '|' });
                decimal price = 0;

                if (strRegType.Length > 1 && !string.IsNullOrEmpty(strRegType[1]))
                {
                    string[] priceSZ = strRegType[1].Split(new char[] { '&' });
                    if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                    {
                        price = decimal.Parse(priceSZ[0]) * decimal.Parse(priceSZ[1]);
                    }
                    else
                    {
                        price = decimal.Parse(strRegType[1]);
                    }
                    if (strRegType[0] == "7")
                    {
                        hasRJG = true;
                    }
                }
                SumPrice += price;
            }
            decimal dcJianRJG = SumPrice;

            if (hasRJG)
            {
                dcJianRJG = SumPrice - WebInit.webBaseConfig.SoftdogPrice;
                SumPrice = SumPrice - WebInit.webBaseConfig.SoftdogPrice;
            }
            //�жϵ�ǰ�û��Ƿ��Ǵ����û�(2010-03-04)start
            if (IsDaili())
            {
                decimal tempPercent = GetCurrentPricePercentByUname(Method.Get_UserName);
                SumPrice = dcJianRJG * tempPercent;
            }
            if (hasRJG)
            {
                SumPrice = SumPrice + WebInit.webBaseConfig.SoftdogPrice;
                if (IsAddPort)
                {
                    SumPrice += 20;
                }
            }
            return SumPrice;
        }

        //�����û��ȼ����ش���ɫ�û���
        public static string GetNameSe(object strUser, object strState)
        {
            string newName = strUser.ToString();
            string intType = strState.ToString();
            if (intType == "10" || intType == "20")
            {
                return "<font color='#0000ff'>" + newName + "</font>";
            }
            else if (intType == "106" || intType == "107")
            {
                return "<font color='#009900'>" + newName + "</font>";
            }
            else if (intType == "104")
            {
                return "<font color='#00bfff'>" + newName + "</font>";
            }
            else if (intType == "3" || intType == "21" || intType == "11")
            {
                return "<font color='#9900ff'>" + newName + "</font>";
            }
            else if (intType == "100" || intType == "101" || intType == "102" || intType == "103")
            {
                return "<font color='#ff0000'>" + newName + "</font>";
            }
            else
            {
                return newName;
            }
        }

        /// <summary>
        /// ��ʡ��
        /// </summary>
        /// <param name="list"></param>
        /// <param name="name"></param>
        public static void BindProvince(DropDownList list, string name)
        {
            DataTable dt = DbHelperSQL.Query("select * from PBnet_Province ").Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                list.Items.Add(new ListItem(row["Name"].ToString(), row["Name"].ToString()));
                //list.Items[0].Selected = true;
            }
            if (!string.IsNullOrEmpty(name))
            {
                list.SelectedValue = name;
            }
        }

        public static string GetRegMode(object objRegMode)
        {
            string strRegMode = objRegMode.ToString();
            if (strRegMode == "0")
            {
                return "����";
            }
            else if (strRegMode == "1")
            {
                return "�ֹ�";
            }
            else if (strRegMode == "10")
            {
                return "�Զ�";
            }
            else
            {
                return "����";
            }
        }

        /// <summary>
        /// ����Ƿ��Ǵ������
        /// </summary>
        /// <returns></returns>
        public static bool IsDaili()
        {
            object objPP = DbHelperSQL1.GetSingle("select PricePercent from AgentInfo where UserName='" + Method.Get_UserName + "' " + Method.Where_AgentInfo);
            if (objPP == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string FormartExpireDate(object objExpDate)
        {
            DateTime dtExpDate = Convert.ToDateTime(objExpDate);
            if (dtExpDate < DateTime.Now)
            {
                return "<font color='red' >" + dtExpDate.ToString("yyyy-MM-dd") + "</font>";
            }
            else
            {
                return dtExpDate.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// �û���־��¼
        /// </summary>
        /// <param name="log_username">�û���</param>
        /// <param name="sqlintoWeb">����/ע�����</param>
        /// <param name="s_state">״̬</param>
        public static void record_user_log(string log_username, string sqlintoWeb, string s_state, string Type)
        {
            //<!--�û���־(��¼���ּ�¼����)-->
            string UserLog_Login_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_Login_OnOff"];
            //<!--�û���־(������ؼ�¼����)-->
            string UserLog_PWD_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_PWD_OnOff"];
            //<!--�û���־(��վ���⹥����¼����)-->
            string UserLog_Into_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_Into_OnOff"];
            bool open = false;
            if (Type == "��¼" && (UserLog_Login_OnOff == "" || UserLog_Login_OnOff == "on"))
            {
                open = true;
            }
            else if (Type == "���⹥��" && (UserLog_Into_OnOff == "" || UserLog_Into_OnOff == "on"))
            {
                open = true;
            }
            else if (Type == "�������" && (UserLog_PWD_OnOff == "" || UserLog_PWD_OnOff == "on"))
            {
                open = true;
            }
            if (open)
            {
                string s_ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                string s_temp = S_getIPaddress(s_ip);
                string s_sqlinto = System.Web.HttpContext.Current.Server.UrlDecode(sqlintoWeb);
                s_sqlinto = s_sqlinto.Replace("%", "��");
                s_sqlinto = s_sqlinto.Replace("'", "��");
                s_sqlinto = s_sqlinto.Replace(";", "��");
                s_sqlinto = s_sqlinto.Replace("alert".ToLower(), "������");
                string urlName = System.Web.HttpContext.Current.Request.FilePath;
                urlName = urlName.Replace("'", "��");
                urlName = urlName.Replace(";", "��");
                urlName = urlName.Replace("alert".ToLower(), "������");
                string allhttp = "dns=" + System.Web.HttpContext.Current.Request.UserHostName + "��" + "���������" + System.Web.HttpContext.Current.Request.UserAgent + "��" + System.Web.HttpContext.Current.Request.Browser.Browser + System.Web.HttpContext.Current.Request.Browser.Version;
                //'	allhttp=request.servervariables("Remote_Host")&VBCR&VBLF&request.servervariables("Http_Referer")&VBCR&VBLF
                //'	allhttp=allhttp&request.servervariables("All_Http")&VBCR&VBLF&request.servervariables("All_RAW")
                //    allhttp=request.servervariables("All_Http")
                //'	s_sqlinto="ע��"
                string sqlinto_aaa = "insert into PBnet_UserLog(log_username,log_password,log_stepinto,log_urlname,log_time,log_Ip,log_state,log_allhttp,log_country,log_city) values('" + log_username + "','" + s_sqlinto + "','Pinble.com','" + urlName + "','" + DateTime.Now + "','" + s_ip + "','" + s_state + "','" + allhttp + "','" + s_temp + "','')";
                DbHelperSQL.ExecuteSql(sqlinto_aaa);
            }
        }


        /// <summary>
        /// �û���־2��¼
        /// </summary>
        /// <param name="log_username">�û���</param>
        /// <param name="sqlintoWeb">����/ע�����</param>
        /// <param name="s_state">״̬</param>
        public static void record_user_log_01(string log_username, string sqlintoWeb, string s_state, string Type)
        {
            //<!--�û���־(��¼���ּ�¼����)-->
            string UserLog_Login_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_Login_OnOff"];
            //<!--�û���־(������ؼ�¼����)-->
            string UserLog_PWD_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_PWD_OnOff"];
            //<!--�û���־(��վ���⹥����¼����)-->
            string UserLog_Into_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_Into_OnOff"];
            bool open = false;
            if (Type == "��¼" && (UserLog_Login_OnOff == "" || UserLog_Login_OnOff == "on"))
            {
                open = true;
            }
            else if (Type == "���⹥��" && (UserLog_Into_OnOff == "" || UserLog_Into_OnOff == "on"))
            {
                open = true;
            }
            else if (Type == "�������" && (UserLog_PWD_OnOff == "" || UserLog_PWD_OnOff == "on"))
            {
                open = true;
            }
            if (open)
            {
                string s_ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                string s_temp = S_getIPaddress(s_ip);
                string s_sqlinto = System.Web.HttpContext.Current.Server.UrlDecode(sqlintoWeb);
                s_sqlinto = s_sqlinto.Replace("%", "��");
                s_sqlinto = s_sqlinto.Replace("'", "��");
                s_sqlinto = s_sqlinto.Replace(";", "��");
                s_sqlinto = s_sqlinto.Replace("alert".ToLower(), "������");
                string urlName = System.Web.HttpContext.Current.Request.FilePath;
                urlName = urlName.Replace("'", "��");
                urlName = urlName.Replace(";", "��");
                urlName = urlName.Replace("alert".ToLower(), "������");
                string allhttp = "dns=" + System.Web.HttpContext.Current.Request.UserHostName + "��" + "���������" + System.Web.HttpContext.Current.Request.UserAgent + "��" + System.Web.HttpContext.Current.Request.Browser.Browser + System.Web.HttpContext.Current.Request.Browser.Version;
                //'	allhttp=request.servervariables("Remote_Host")&VBCR&VBLF&request.servervariables("Http_Referer")&VBCR&VBLF
                //'	allhttp=allhttp&request.servervariables("All_Http")&VBCR&VBLF&request.servervariables("All_RAW")
                //    allhttp=request.servervariables("All_Http")
                //'	s_sqlinto="ע��"
                string sqlinto_aaa = "insert into PBnet_UserLog(log_username,log_password,log_stepinto,log_urlname,log_time,log_Ip,log_state,log_allhttp,log_country,log_city) values('" + log_username + "','" + s_sqlinto + "','Chat','" + urlName + "','" + DateTime.Now + "','" + s_ip + "','" + s_state + "','" + allhttp + "','" + s_temp + "','')";
                DbHelperSQL.ExecuteSql(sqlinto_aaa);
            }
        }


        /// <summary>
        /// ����ip��ַ��ȡ��ַ����
        /// </summary>
        /// <param name="userip"></param>
        /// <returns></returns>
        public static string S_getIPaddress(string userip)
        {
            if (string.IsNullOrEmpty(userip))
            {
                return "";
            }
            else if (userip.Length < 2)
            {
                return "δ֪";
            }
            long tnum = 0;
            string result = "";
            int twoTest = 0;
            if (int.TryParse(userip.Substring(0, 1), out twoTest))
            {
                if (userip == "127.0.0.1")
                {
                    result = "192.168.0.1";
                }

                string[] strIPs = userip.Split(new char[] { '.' });
                //if(strIPs[0]=="0" || strIPs[1]=="0" || strIPs[2]=="0" || strIPs[3]=="0")
                //{}
                //else
                //{
                tnum = long.Parse(strIPs[0]) * 16777216 + long.Parse(strIPs[1]) * 65536 + long.Parse(strIPs[2]) * 256 + long.Parse(strIPs[3]) - 1;
                // tSQL="select top 1 country,city from ipdata where ip1 <=" + tnum + "and ip2>="+tnum;
                DataSet ds = DbHelperSQL.Query(" select ip1,ip2,country,city from PBnet_ipdata where ip1 <=" + tnum + "and ip2>=" + tnum);
                if (ds.Tables.Count < 1)
                {

                }
                else
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    result = row[2].ToString() + row[3].ToString();
                }
                //}               
            }
            return result;
        }


        /// <summary>
        /// ˫ɫ����Ŀ��ֹʱ��
        /// </summary>
        private static string getSSQDateTime = null;

        public static string GetSSQDateTime
        {
            get
            {
                getSSQDateTime = null;
                if (getSSQDateTime == null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                    XmlElement root = doc.DocumentElement;
                    if (root.ChildNodes.Count > 0)
                    {
                        //��ѯ���ֵĿ���ʱ��
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from FCSSData order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();
                        //˫ɫ�򿪽�Ϊ��ÿ�ܶ������ġ�����
                        switch (((int)DateTime.Parse(sdate).DayOfWeek) + 1)
                        {
                            case 1: //������
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//�¸����ڶ�
                                break;
                            case 3:   //���ڶ� 
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//�¸�������
                                break;
                            case 5: // ������
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();// �¸������� 
                                break;
                        }

                        XmlNode haha = root.SelectNodes("FCSSQEndTime")[0];

                        //�Ա�xml�Ľ�ֹʱ�䣬��xml��ֹʱ��������ݿ����󿪽�ʱ�䣬��ʹ��xml�Ľ�ֹʱ��
                        XmlDocument docs = new XmlDocument();
                        docs.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                        XmlElement roots = docs.DocumentElement;
                        if (roots.ChildNodes.Count > 0)
                        {
                            XmlNode endtime = roots.SelectNodes("FCSSData")[0];
                            //if (Convert.ToDateTime(sdate) < Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value))
                            if (DateTime.Compare(Convert.ToDateTime(sdate), Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value))<0)
                            {
                                Method.getSSQDateTime = Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                            else
                            {
                                Method.getSSQDateTime = Convert.ToDateTime(sdate).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                        }
                        else
                        {

                            Method.getSSQDateTime = Convert.ToDateTime(sdate).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                        }
                    }
                }
                return Method.getSSQDateTime;

            }
            set
            {
                #region//��������
                XmlDocument doc_1 = new XmlDocument();
                doc_1.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                XmlElement root_1 = doc_1.DocumentElement;
                if (root_1.ChildNodes.Count > 0)
                {

                    XmlNode node = root_1.SelectNodes("FCSSData")[0];
                    node.SelectSingleNode("@EndTime").Value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                    doc_1.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                }

                #endregion

                #region ����ʱ����
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("FCSSQEndTime")[0];
                    haha.SelectSingleNode("@value").Value = Convert.ToDateTime(value).ToString("HH:mm:ss");
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                }
                #endregion

                Method.getSSQDateTime = value;

            }
        }




        /// <summary>
        /// ����3D��Ŀ��ֹʱ��
        /// </summary>
        /// 

        private static string getFCDateTime;

        public static string GetFCDateTime
        {
            get
            {
                getFCDateTime = null;
                if (getFCDateTime == null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                    XmlElement root = doc.DocumentElement;
                    if (root.ChildNodes.Count > 0)
                    {
                        //��ѯ���ֵĿ���ʱ��
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 2 date,code from FC3DData order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();

                        string code = dsperiod.Tables[0].Rows[0]["code"].ToString();
                        if (code == "" || code.Trim().Length <= 0)
                        {
                            sdate = dsperiod.Tables[0].Rows[1]["date"].ToString();

                        }

                        XmlNode haha = root.SelectNodes("FC3DEndTime")[0];



                        //�Ա�xml�Ľ�ֹʱ�䣬��xml��ֹʱ��������ݿ����󿪽�ʱ�䣬��ʹ��xml�Ľ�ֹʱ��
                        XmlDocument docs = new XmlDocument();
                        docs.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                        XmlElement roots = docs.DocumentElement;
                        if (roots.ChildNodes.Count > 0)
                        {
                            XmlNode endtime = roots.SelectNodes("FC3DData")[0];
                            //if (Convert.ToDateTime(sdate).AddDays(1) < Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value))
                            if (DateTime.Compare(Convert.ToDateTime(sdate).AddDays(1), Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value)) < 0)
                            {
                                Method.getFCDateTime = Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                            else
                            {

                                Method.getFCDateTime = Convert.ToDateTime(sdate).AddDays(1).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                        }
                        else
                        {

                            Method.getFCDateTime = Convert.ToDateTime(sdate).AddDays(1).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                        }

                    }
                }
                return Method.getFCDateTime;
            }
            set
            {
                #region//��������
                XmlDocument doc_1 = new XmlDocument();
                doc_1.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                XmlElement root_1 = doc_1.DocumentElement;
                if (root_1.ChildNodes.Count > 0)
                {

                    XmlNode node = root_1.SelectNodes("FC3DData")[0];
                    node.SelectSingleNode("@EndTime").Value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                    doc_1.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                }

                #endregion

                #region ����ʱ����
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("FC3DEndTime")[0];
                    haha.SelectSingleNode("@value").Value = Convert.ToDateTime(value).ToString("HH:mm:ss");
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                }
                #endregion
                Method.getFCDateTime = value;
            }
        }
        /// <summary>
        /// �����������Ŀ��ֹʱ��
        /// </summary>
        private static string getTCPL35DateTime;

        public static string GetTCPL35DateTime
        {
            get
            {
                getTCPL35DateTime = null;
                if (getTCPL35DateTime == null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                    XmlElement root = doc.DocumentElement;
                    if (root.ChildNodes.Count > 0)
                    {

                        XmlNode haha = root.SelectNodes("TCPL35EndTime")[0];
                        //��ѯ���ֵĿ���ʱ��
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from TCPL35Data order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();



                        //�Ա�xml�Ľ�ֹʱ�䣬��xml��ֹʱ��������ݿ����󿪽�ʱ�䣬��ʹ��xml�Ľ�ֹʱ��
                        XmlDocument docs = new XmlDocument();
                        docs.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                        XmlElement roots = docs.DocumentElement;
                        if (roots.ChildNodes.Count > 0)
                        {
                            XmlNode endtime = roots.SelectNodes("TCPL35Data")[0];
                            //if (Convert.ToDateTime(sdate).AddDays(1) < Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value))
                            if (DateTime.Compare(Convert.ToDateTime(sdate).AddDays(1), Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value))<0)
                            {
                                Method.getTCPL35DateTime = Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                            else
                            {
                                Method.getTCPL35DateTime = Convert.ToDateTime(sdate).AddDays(1).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                        }
                        else
                        {

                            Method.getTCPL35DateTime = Convert.ToDateTime(sdate).AddDays(1).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                        }
                    }
                }
                return Method.getTCPL35DateTime;
            }
            set
            {

                #region//��������
                XmlDocument doc_1 = new XmlDocument();
                doc_1.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                XmlElement root_1 = doc_1.DocumentElement;
                if (root_1.ChildNodes.Count > 0)
                {

                    XmlNode node = root_1.SelectNodes("TCPL35Data")[0];
                    node.SelectSingleNode("@EndTime").Value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                    doc_1.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                }

                #endregion

                #region ����ʱ����
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("TCPL35EndTime")[0];
                    haha.SelectSingleNode("@value").Value = Convert.ToDateTime(value).ToString("HH:mm:ss");
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                }
                #endregion


                Method.getTCPL35DateTime = value;
            }
        }

        /// <summary>
        /// ������ǲ�
        /// </summary>
        private static string getTC7XCDateTime;

        public static string GetTC7XCDateTime
        {
            get
            {
                getTC7XCDateTime = null;
                if (getTC7XCDateTime == null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                    XmlElement root = doc.DocumentElement;
                    if (root.ChildNodes.Count > 0)
                    {
                        //��ѯ���ֵĿ���ʱ��
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from TC7XCData_New  order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();
                        //ÿ�ܶ������塢����
                        switch (((int)DateTime.Parse(sdate).DayOfWeek) + 1)
                        {
                            case 1: //������
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//�¸����ڶ�
                                break;
                            case 3:   //���ڶ� 
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();//�¸�������
                                break;
                            case 6: // ������
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();// �¸������� 
                                break;
                        }

                        XmlNode haha = root.SelectNodes("TC7XCEndTime")[0];
                        //�Ա�xml�Ľ�ֹʱ�䣬��xml��ֹʱ��������ݿ����󿪽�ʱ�䣬��ʹ��xml�Ľ�ֹʱ��
                        XmlDocument docs = new XmlDocument();
                        docs.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                        XmlElement roots = docs.DocumentElement;
                        if (roots.ChildNodes.Count > 0)
                        {
                            XmlNode endtime = roots.SelectNodes("TC7XCData_New")[0];
                            if (Convert.ToDateTime(sdate) < Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value))
                            {
                                Method.getTC7XCDateTime = Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                            else
                            {
                                Method.getTC7XCDateTime = Convert.ToDateTime(sdate).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                        }
                        else
                        {

                            Method.getTC7XCDateTime = Convert.ToDateTime(sdate).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                        }
                    }
                }
                return Method.getTC7XCDateTime;
            }
            set
            {

                #region//��������
                XmlDocument doc_1 = new XmlDocument();
                doc_1.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                XmlElement root_1 = doc_1.DocumentElement;
                if (root_1.ChildNodes.Count > 0)
                {

                    XmlNode node = root_1.SelectNodes("TC7XCData_New")[0];
                    node.SelectSingleNode("@EndTime").Value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                    doc_1.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                }

                #endregion

                #region ����ʱ����
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("TC7XCEndTime")[0];
                    haha.SelectSingleNode("@value").Value = Convert.ToDateTime(value).ToString("HH:mm:ss");
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                }
                #endregion
                Method.getTC7XCDateTime = value;
            }
        }
        /// <summary>
        /// �������ֲ�
        /// </summary>
        private static string getFC7LCDateTime;

        public static string GetFC7LCDateTime
        {
            get
            {
                getFC7LCDateTime = null;
                if (getFC7LCDateTime == null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                    XmlElement root = doc.DocumentElement;
                    if (root.ChildNodes.Count > 0)
                    {
                        //��ѯ���ֵĿ���ʱ��
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from FC7LC  order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();
                        //ÿ��һ������������
                        switch (((int)DateTime.Parse(sdate).DayOfWeek) + 1)
                        {
                            case 6: //������
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();//�¸�����һ
                                break;
                            case 2:   //����һ 
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//�¸�������
                                break;
                            case 4: // ������
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();// �¸�������
                                break;
                        }

                        XmlNode haha = root.SelectNodes("FC7LCEndTime")[0];


                        //�Ա�xml�Ľ�ֹʱ�䣬��xml��ֹʱ��������ݿ����󿪽�ʱ�䣬��ʹ��xml�Ľ�ֹʱ��
                        XmlDocument docs = new XmlDocument();
                        docs.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                        XmlElement roots = docs.DocumentElement;
                        if (roots.ChildNodes.Count > 0)
                        {
                            XmlNode endtime = roots.SelectNodes("FC7LC")[0];
                            if (Convert.ToDateTime(sdate) < Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value))
                            {
                                Method.getFC7LCDateTime = Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                            else
                            {
                                Method.getFC7LCDateTime = Convert.ToDateTime(sdate).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                        }
                        else
                        {

                            Method.getFC7LCDateTime = Convert.ToDateTime(sdate).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                        }

                    }
                }
                return Method.getFC7LCDateTime;
            }
            set
            {
                #region//��������
                XmlDocument doc_1 = new XmlDocument();
                doc_1.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                XmlElement root_1 = doc_1.DocumentElement;
                if (root_1.ChildNodes.Count > 0)
                {

                    XmlNode node = root_1.SelectNodes("FC7LC")[0];
                    node.SelectSingleNode("@EndTime").Value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                    doc_1.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                }

                #endregion

                #region ����ʱ����
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("FC7LCEndTime")[0];
                    haha.SelectSingleNode("@value").Value = Convert.ToDateTime(value).ToString("HH:mm:ss");
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                }
                #endregion

                Method.getFC7LCDateTime = value;
            }
        }

        /// <summary>
        ///��ʴ���͸ 
        /// </summary>
        private static string getTCDLTDateTime;

        public static string GetTCDLTDateTime
        {
            get
            {
                getTCDLTDateTime = null;
                if (getTCDLTDateTime == null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                    XmlElement root = doc.DocumentElement;
                    if (root.ChildNodes.Count > 0)
                    {
                        //��ѯ���ֵĿ���ʱ��
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from TCDLTData  order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();
                        //ÿ��һ������������
                        switch (((int)DateTime.Parse(sdate).DayOfWeek) + 1)
                        {
                            case 7: //������
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//�¸�����һ
                                break;
                            case 2:   //����һ 
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//�¸�������
                                break;
                            case 4: // ������
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();// �¸�������
                                break;
                        }

                        XmlNode haha = root.SelectNodes("TCDLTEndTime")[0];
                        //�Ա�xml�Ľ�ֹʱ�䣬��xml��ֹʱ��������ݿ����󿪽�ʱ�䣬��ʹ��xml�Ľ�ֹʱ��
                        XmlDocument docs = new XmlDocument();
                        docs.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                        XmlElement roots = docs.DocumentElement;
                        if (roots.ChildNodes.Count > 0)
                        {
                            XmlNode endtime = roots.SelectNodes("TCDLTData")[0];
                            if (Convert.ToDateTime(sdate) < Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value))
                            {
                                Method.getTCDLTDateTime = Convert.ToDateTime(endtime.SelectSingleNode("@EndTime").Value).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                            else
                            {
                                Method.getTCDLTDateTime = Convert.ToDateTime(sdate).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                            }
                        }
                        else
                        {

                            Method.getTCDLTDateTime = Convert.ToDateTime(sdate).ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                        }
                    }
                }
                return Method.getTCDLTDateTime;
            }
            set
            {
                #region//��������
                XmlDocument doc_1 = new XmlDocument();
                doc_1.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                XmlElement root_1 = doc_1.DocumentElement;
                if (root_1.ChildNodes.Count > 0)
                {

                    XmlNode node = root_1.SelectNodes("TCDLTData")[0];
                    node.SelectSingleNode("@EndTime").Value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                    doc_1.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
                }

                #endregion

                #region ����ʱ����
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("TCDLTEndTime")[0];
                    haha.SelectSingleNode("@value").Value = Convert.ToDateTime(value).ToString("HH:mm:ss");
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                }
                #endregion
                Method.getTCDLTDateTime = value;
            }
        }

        /// <summary>
        /// ���22ѡ5
        /// </summary>
        private static string getTC22X5DateTime;

        public static string GetTC22X5DateTime
        {
            get
            {
                getTC22X5DateTime = null;
                if (getTC22X5DateTime == null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                    XmlElement root = doc.DocumentElement;
                    if (root.ChildNodes.Count > 0)
                    {

                        XmlNode haha = root.SelectNodes("TC22X5EndTime")[0];
                        Method.getTC22X5DateTime = DateTime.Now.ToString("yyyy-MM-dd") + " " + haha.SelectSingleNode("@value").Value;
                    }
                }
                return Method.getTC22X5DateTime;
            }
            set
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("TC22X5EndTime")[0];
                    haha.SelectSingleNode("@value").Value = value;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                }

                Method.getTC22X5DateTime = value;
            }
        }
        /// <summary>
        /// ���31ѡ7
        /// </summary>
        private static string getTC31X7DateTime;

        public static string GetTC31X7DateTime
        {
            get
            {
                getTC31X7DateTime = null;
                if (getTC31X7DateTime == null)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                    XmlElement root = doc.DocumentElement;
                    if (root.ChildNodes.Count > 0)
                    {

                        XmlNode haha = root.SelectNodes("TC31X7EndTime")[0];
                        Method.getTC31X7DateTime = haha.SelectSingleNode("@value").Value;
                    }
                }
                return Method.getTC31X7DateTime;
            }
            set
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {
                    XmlNode haha = root.SelectNodes("TC31X7EndTime")[0];
                    haha.SelectSingleNode("@value").Value = value;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
                }
                Method.getTC31X7DateTime = value;
            }
        }



        public static string GetLotoryTime(string sdate, string lottoryname)
        {
            if (sdate == null)
            {
                //��ѯ���ֵĿ���ʱ��
                DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from " + lottoryname + "  order by date desc");
                sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();
            }
            //ÿ��һ������������
            switch (((int)DateTime.Parse(sdate).DayOfWeek) + 1)
            {
                case 7: //������
                    sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//�¸�����һ
                    break;
                case 2:   //����һ 
                    sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//�¸�������
                    break;
                case 4: // ������
                    sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();// �¸�������
                    break;
            }
            return Convert.ToDateTime(sdate).ToString("yyyy-MM-dd");
        }


        /// <summary>
        /// ���ɷ������
        /// </summary>
        /// <param name="prefix">ǰ׺</param>
        /// <returns></returns>
        public static string CreateQNumber(string prefix,bool Sleep)
        {
            DateTime now = DateTime.Now;
            //��
            string year = now.Year.ToString();
            year = year.Substring(year.Length - 2, 2);
            //��
            string month = now.Month.ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            //��
            string day = now.Day.ToString();
            if (day.Length < 2)
            {
                day = "0" + day;
            }
            //Сʱ
            string hh = now.Hour.ToString();
            if (hh.Length < 2)
            {
                hh = "0" + hh;
            }
            //����
            string MM = now.Minute.ToString();
            if (MM.Length < 2)
            {
                MM = "0" + MM;
            }
            //��
            string SS = now.Second.ToString();
            if (SS.Length < 2)
            {
                SS = "0" + SS;
            }
            if (Sleep)
                System.Threading.Thread.Sleep(1);
            Random rd = new Random(DateTime.Now.Millisecond);
            string strStart = prefix + year + month + day + hh + MM + SS + rd.Next(1000, 99999).ToString();
            return strStart;
        }

        /// <summary>
        /// ��鷽���Ƿ��ظ�
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="tableName"></param>
        /// <param name="orderID"></param>
        /// <returns></returns>
        private static string checkCFQNumber(string prefix, string tableName, string QNumber)
        {
            DateTime now = DateTime.Now;
            //��
            string year = now.Year.ToString();
            year = year.Substring(year.Length - 2, 2);
            //��
            string month = now.Month.ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            //��
            string day = now.Day.ToString();
            if (day.Length < 2)
            {
                day = "0" + day;
            }
            string serialNum = QNumber.Substring(11, 5);
            int intTempNum = int.Parse(serialNum) + 1;
            string serialNumNow = string.Format("{0:D5}", intTempNum);
            string tempOrder = prefix + year + month + day + serialNumNow;
            QNumber = tempOrder.Substring(0, 8) + Method.GetCheckCode(tempOrder) + tempOrder.Substring(tempOrder.Length - 5, 5);
            if (DbHelperSQL.Exists("select count(*) from " + tableName + " where QNumber='" + QNumber + "'"))
            {
                QNumber = checkCFQNumber(prefix, tableName, QNumber);
            }
            return QNumber;
        }



        /// <summary>
        /// Ͷע��ť��ʾ
        /// </summary>
        /// <param name="ltime">��ֹʱ��</param>
        /// <param name="btime"></param>
        /// <returns></returns>
        public static string IsLottory(string ltime)
        {
            if (Convert.ToDateTime(ltime) > DateTime.Now)
            {
                return "$('#J_SubmitPay').attr('style', 'background: url(/images/norepeat_bg.png) no-repeat 0px -470px');";
            }
            else
            {
                return "$('#J_SubmitPay').attr('disabled', 'disabled'); $('#J_SubmitPay').attr('style', 'background: url(/images/norepeat_bg.png) no-repeat 0px -620px');";
            }

        }
        /// <summary>
        /// ���ݱ�ʶID�õ���ʶ��Ϣ
        /// </summary>
        /// <param name="number">����ID</param>
        /// <param name="type">��Ҫ��ȡ�����ͣ�1 ��Ʊ��ţ�2Ϊ��־����</param>
        /// <returns>�����ݻ�ȡʧ��ʱ����null</returns>
        public static string GetXmlLottoryByNumber(int number, int type)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/LotSerialNum.xml"));
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {
                string lottName = "Lottory";
                if (type == 1)
                    lottName = "Lottory";
                else
                    lottName = "Log";
                XmlNode haha = root.SelectNodes(lottName + number)[0];
                return haha.SelectSingleNode("@number").Value;
            }
            return null;
        }
        /// <summary>
        /// ���ݱ�ʶID�õ���ʶ��Ϣ
        /// </summary>
        /// <param name="number">����ID</param>
        /// <param name="type">��Ҫ��ȡ�����ͣ�1 ��Ʊ��ţ�2Ϊ��־����</param>
        /// <returns>�����ݻ�ȡʧ��ʱ����null</returns>
        public static string GetXmlLottoryByValue(int number, int type)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/LotSerialNum.xml"));
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {
                string lottName = "Lottory";
                if (type == 1)
                    lottName = "Lottory";
                else
                    lottName = "Log";
                XmlNode haha = root.SelectNodes(lottName + number)[0];
                return haha.SelectSingleNode("@value").Value;
            }
            return null;
        }
        /// <summary>
        /// ���ݱ�ʶID�޸ı�ʶ��Ϣ
        /// </summary>
        /// <param name="number">��ʶID</param>
        /// <param name="type">��Ҫ�޸ĵ����ͣ�1Ϊ�������ͣ�2Ϊ��־����</param>
        /// <param name="value">��Ҫ�޸ĵ����ͣ�1Ϊ�������ͣ�2Ϊ��־����</param>
        public static void SetXmlLottoryByNumber(string number, int type, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/LotSerialNum.xml"));
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {
                string lottName = "Lottory";
                if (type == 1)
                    lottName = "Lottory";
                else
                    lottName = "Log";

                XmlNode haha = root.SelectNodes(lottName + number)[0];
                haha.SelectSingleNode("@value").Value = value;
                doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebConfig.xml"));
            }
        }

        /// <summary>
        /// ���������õ���Ӧ������
        /// </summary>
        /// <returns></returns>
        public static string GetWebDescribe(string Name, string value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/WebDescribe.xml"));
            XmlElement root = doc.DocumentElement;
            if (root.ChildNodes.Count > 0)
            {
                XmlNode haha = root.SelectNodes(Name)[0];
                return haha.SelectSingleNode("@" + value).Value.Replace("&#xD;", "");
            }
            return null;
        }
        /// <summary>
        /// ���ؿ�������
        /// </summary>
        /// <param name="lottID">����Id</param>
        /// <param name="issue">�ں�</param>
        /// <returns></returns>
        public static string RlotteryNum(int lottID, int issue)
        {
            DataSet ds = new DataSet();
            if (lottID == 1)
            {
                //3D
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code from FC3DData where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (lottID == 2)
            {
                //���ֲ�
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code,tcode from FC7LC where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //���������
                    string Rball = "";
                    for (int i = 0; i < ds.Tables[0].Rows[0]["code"].ToString().Length; i++)
                    {
                        Rball += ds.Tables[0].Rows[0]["code"].ToString().Substring(i, 2) + ",";
                        i++;
                    }
                    return Rball.Substring(0, Rball.Length - 1) + "+" + ds.Tables[0].Rows[0]["tcode"].ToString();
                }
            }
            if (lottID == 3)
            {
                //˫ɫ��
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select redcode,bluecode from FCSSData where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //���������
                    string Rball = "";
                    for (int i = 0; i < ds.Tables[0].Rows[0]["redcode"].ToString().Length; i++)
                    {
                        Rball += ds.Tables[0].Rows[0]["redcode"].ToString().Substring(i, 2) + ",";
                        i++;
                    }
                    return Rball.Substring(0, Rball.Length - 1) + "+" + ds.Tables[0].Rows[0]["bluecode"].ToString();
                }
            }
            if (lottID == 4)
            {
                //����5
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code5 from TCPL35Data where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (lottID == 9999)
            {
                //����3
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code3 from TCPL35Data where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (lottID == 5)
            {
                //���ǲ�
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code from TC7XCData_New where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (lottID == 6)
            {
                //����͸
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code,code2 from TCDLTData where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //���������
                    string Rball = "";
                    for (int i = 0; i < ds.Tables[0].Rows[0]["code"].ToString().Length; i++)
                    {
                        Rball += ds.Tables[0].Rows[0]["code"].ToString().Substring(i, 2) + ",";
                        i++;
                    }
                    return Rball.Substring(0, Rball.Length - 1) + "+" + ds.Tables[0].Rows[0]["code2"].ToString().Substring(0, 2) + "," + ds.Tables[0].Rows[0]["code2"].ToString().Substring(2, 2);

                }
            }
            return "";
        }

    }

}
