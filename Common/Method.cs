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
        /// 彩票超市主页绑定商家排行信息sql条件
        /// 创建人: zhouwei
        /// 创建时间: 2010-10-21
        /// </summary>
        public static string Mark_UserGueue = "State=1 order by id desc";

        /// <summary>
        /// 彩票超市主页绑定项目列表
        /// 创建人: zhouwei
        /// 创建时间:2010-10-22
        /// </summary>
        public static string Market_Item = " order by Ma.appendID desc";




        /// <summary>
        /// 产品基本筛选条件
        /// </summary>
        //public static string product = " pb_Deleted=0 and pb_Passed=1";
        public static string product = " pb_Deleted=0 and pb_Passed=1";
        /// <summary>
        /// 资源基本筛选条件
        /// </summary>
        public static string soft = " pb_Deleted=0 and pb_Passed=1 ";
        /// <summary>
        /// 广告基本筛选条件
        /// </summary>
        public static string Advs = " pb_ENDTime>getdate() and pb_IsSelected=1  ";

        /// <summary>
        /// 公告类别基本筛选条件
        /// </summary>
        public static string BulletinType = " BitIsAuditing=1 ";


        public static string NewsPage = "order by DatDateAndTime desc";
        public static string IsTopPage = "order by BitIsTop DESC ,DatDateAndTime desc";

        public static string IndexNews = "and ShowIndex=1  order by  BitIsTop DESC ,DatDateAndTime desc";

        public static string DlUser = " ExpireDate > GETDATE() AND Status = 1 ";

        /// <summary>
        /// 有效用户筛选条件
        /// </summary>
        public static string DV_User = " LockUser=0 and UserClass!='COPPA' and UserClass!='等待验证' ";


        /// <returns></returns>
        public static string GetUserIP()
        {
            string result = "IP地址未知";
            if (System.Web.HttpContext.Current.Request.UserHostAddress != null)
            {
                result = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            }
            return result;
        }


        #region//ShowPager:显示分页效果.
        /// <summary>
        /// 显示分页效果.
        /// </summary>
        /// <param name="nPage">当前页.</param>
        /// <param name="maxPage">最大页.</param>
        /// <returns>返回字符串.</returns>
        public static string ShowPager(int nPage, int maxPage)
        {
            int endpage = 1;
            string qdkPager = "";
            if (maxPage <= 11)
            {
                if (nPage > 1)
                {
                    qdkPager = "<a href=\"?page=1\">首页<</a> ";
                }
                else
                {
                    qdkPager = "<a class=\"noLink\">首页<</a> ";
                }
                //qdkPager += "<div>上10页</div> ";
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
                //qdkPager += "<div>下10页</div> ";
                if (nPage < maxPage)
                {
                    qdkPager += "<a href=\"?page=" + maxPage + "\">>尾页</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">>尾页</a> ";
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
                    qdkPager = "<a href=\"?page=1\">首页<</a> ";
                }
                else
                {
                    qdkPager = "<a class=\"noLink\">首页<</a> ";
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
                    qdkPager += "<a href=\"?page=" + ((nowpagecount - 2) * 10 + 1) + "\">上10页</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">上10页</a> ";
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
                    qdkPager += "<a href=\"?page=" + (nowpagecount * 10 + 1) + "\">下10页</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">下10页</a> ";
                }
                if (nPage < maxPage)
                {
                    qdkPager += "<a href=\"?page=" + maxPage + "\">>尾页</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">>尾页</a> ";
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
                    qdkPager = "<a href=\"?page=1&" + strLink + "\">首页<</a> ";
                }
                else
                {
                    qdkPager = "<a class=\"noLink\">首页<</a> ";
                }
                //qdkPager += "<div>上10页</div> ";
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
                //qdkPager += "<div>下10页</div> ";
                if (nPage < maxPage)
                {
                    qdkPager += "<a href=\"?page=" + maxPage + "&" + strLink + "\">>尾页</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">>尾页</a> ";
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
                    qdkPager = "<a href=\"?page=1&" + strLink + "\">首页<</a> ";
                }
                else
                {
                    qdkPager = "<a class=\"noLink\">首页<</a> ";
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
                    qdkPager += "<a href=\"?page=" + ((nowpagecount - 2) * 10 + 1) + "&" + strLink + "\">上10页</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">上10页</a> ";
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
                    qdkPager += "<a href=\"?page=" + (nowpagecount * 10 + 1) + "&" + strLink + "\">下10页</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">下10页</a> ";
                }
                if (nPage < maxPage)
                {
                    qdkPager += "<a href=\"?page=" + maxPage + "&" + strLink + "\">>尾页</a> ";
                }
                else
                {
                    qdkPager += "<a class=\"noLink\">>尾页</a> ";
                }
            }
            return qdkPager;
        }
        #endregion

        #region//sltListBox:将下拉框中等于指定值的选项选中.
        /// <summary>
        /// 将下拉框中等于指定值的选项选中.
        /// </summary>
        /// <param name="MyDD">要设置的下拉框.</param>
        /// <param name="sltValue">要检查的值.</param>
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

        #region GetChecked:用于在绑定数据时选定CheckBox的checked状态.
        /// <summary>
        /// 用于在绑定数据时选定CheckBox的checked状态.
        /// </summary>
        /// <param name="val">绑定的数据.</param>
        /// <returns>返回一个字符串.</returns>
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
        /// 绑定产品编辑里面软件版本下拉框
        /// </summary>
        /// <param name="MyDD"></param>
        public static void BindProductVersionByEnum(ref System.Web.UI.WebControls.DropDownList MyDD)
        {

            string[] MyArray = Enum.GetNames(typeof(EProductVersion));
            MyDD.DataSource = MyArray;   //cboDepartmentType是界面上下拉列表的名称由下拉列表选中的项转换成枚举值方法如下：
            MyDD.DataBind();
        }

        ///<summary>
        /// 绑定DATALIST数据
        /// </summary>
        /// List 数据空间id
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
        /// 绑定新闻编辑里面显示位置下拉框
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
            MyDD.Items.Insert(0, new ListItem("普通", ""));
            MyDD.Items[0].Selected = true;
            //MyDD.DataSource = MyArray;   //cboDepartmentType是界面上下拉列表的名称由下拉列表选中的项转换成枚举值方法如下：
            //MyDD.DataBind();
        }

        /// <summary>
        /// 绑定公告编辑里面显示位置下拉框
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
            MyDD.Items.Insert(0, new ListItem("普通", ""));
            MyDD.Items[0].Selected = true;
            //MyDD.DataSource = MyArray;   //cboDepartmentType是界面上下拉列表的名称由下拉列表选中的项转换成枚举值方法如下：
            //MyDD.DataBind();
        }

        /// <summary>
        /// 广告频道
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
        ///// 广告频道
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
        /// 绑定订单用户提示状态
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
        /// 绑定订单状态
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
        /// 广告类别
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
        /// 绑定用户中心订单搜索下拉框
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
            MyDD.Items.Insert(0, new ListItem("所有", ""));
            MyDD.Items[0].Selected = true;
            //MyDD.DataSource = MyArray;   //cboDepartmentType是界面上下拉列表的名称由下拉列表选中的项转换成枚举值方法如下：
            //MyDD.DataBind();
        }



        ///<summary>
        /// 根据类别ID返回类别名称
        ///</summary>
        public static string GetadClass(object num)
        {
            int intnum = int.Parse(num.ToString());
            return Enum.GetName(typeof(EadClass), intnum);
        }
        ///<summary>
        /// 根据频道ID返回类别名称
        ///</summary>
        public static string GetadChanl(object num)
        {
            int intnum = int.Parse(num.ToString());
            return Enum.GetName(typeof(EadChanl), intnum);
        }

        ///<summary>
        /// 根据广告位类别ID返回类别名称
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
                    type = "经销商";
                    break;
                case 1:
                    type = "3级代理";
                    break;
                case 2:
                    type = "2级代理";
                    break;
                case 3:
                    type = "1级代理";
                    break;
                default:
                    type = "错误类型";
                    break;
            }
            return type;
        }
        /// <summary>
        /// 使用类型
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
                    type = "<font color=#9900FF>购买</font>";
                    break;
                case 2:
                    type = "免费";
                    break;
                default:
                    type = "<font color=red>未知</font>";
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
                    type = "临时";
                    break;
                case 2:
                    type = "3月";
                    break;
                case 3:
                    type = "半年";
                    break;
                case 4:
                    type = "<font color=#ff00ff>1年</font>";
                    break;
                case 5:
                    type = "2年";
                    break;
                case 6:
                    type = "3年";
                    break;
                case 7:
                    type = "<font color=#ff0000>终身</font>";
                    break;
                default:
                    type = "<font color=red>未知</font>";
                    break;
            }
            return type;
        }

        /// <summary>
        /// 网络版使用类型
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
                    result = "包月";
                    break;
                case "2":
                    result = "计天";
                    break;
                case "3":
                    result = "临时";
                    break;
                default:
                    result = "其它";
                    break;
            }
            return result;
        }
        /// <summary>
        /// 网络版使用值
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
                    result = strValue + "个月";
                    break;
                case "2":
                    result = strValue + "天";
                    break;
                default:
                    result = strValue;
                    break;
            }
            return result;
        }

        /// <summary>
        /// 检查单机版，软件狗版，网络版
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
        /// 显示注册方式
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
                    type = "初始值";
                    break;
                case 1:
                    type = "硬盘序列号";
                    break;
                case 2:
                    type = "C盘卷标";
                    break;
                case 8:
                    type = "网络注册";
                    break;
                case 9:
                    type = "软件狗";
                    break;
                default:
                    type = "未知";
                    break;
            }
            return type;
        }
        //用户类型
        public static string GetUserType(object num)
        {
            string User = "";
            int Intnum = int.Parse(num.ToString());
            switch (Intnum)
            {
                case 1:
                    User = "普通";
                    break;
                case 2:
                    User = "VIP";
                    break;
                default:
                    User = "<font color=red>未知</font>";
                    break;
            }
            return User;
        }


        //是否输出单位（天 月）
        public static string Getdanwei(object num)
        {
            string DW = "";
            int Intnum = int.Parse(num.ToString());
            switch (Intnum)
            {
                case 1:
                    DW = "个月";
                    break;
                case 2:
                    DW = "天";
                    break;
                default:
                    DW = "";
                    break;
            }
            return DW;
        }


        //用户类型
        public static string ShowUserType(object num)
        {
            string F_str = "";
            int intNum = int.Parse(num.ToString());
            switch (intNum)
            {
                case 0:
                    F_str = "初始值";
                    break;
                case 1:
                    F_str = "公测";
                    break;
                case 2:
                    F_str = "无限免费";
                    break;
                case 3:
                    F_str = "临时使用";
                    break;
                case 10:
                    F_str = "收费记天";
                    break;
                case 11:
                    F_str = "免费记天";
                    break;
                case 20:
                    F_str = "收费包月";
                    break;
                case 21:
                    F_str = "免费包月";
                    break;
                case 100:
                    F_str = "管理员";
                    break;
                case 101:
                    F_str = "超级版主";
                    break;
                case 102:
                    F_str = "版主";
                    break;
                case 103:
                    F_str = "聊管";
                    break;
                case 104:
                    F_str = "贵宾";
                    break;
                case 105:
                    F_str = "VIP用户";
                    break;
                case 106:
                    F_str = "软件用户";
                    break;
                case 107:
                    F_str = "论坛用户";
                    break;
                case 190:
                    F_str = "免费试用";
                    break;
                case 200:
                    F_str = "禁止使用";
                    break;
                default:
                    F_str = "未知";
                    break;
            }
            return F_str;
        }

        /// <summary>
        /// 显示未知状态
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
                    type = "初始值";
                    break;
                case 1:
                    type = "正常";
                    break;
                case 2:
                    type = "非法";
                    break;
                case 3:
                    type = "错位";
                    break;
                case 4:
                    type = "过期";
                    break;
                default:
                    type = "未知";
                    break;
            }
            return type;
        }

        /// <summary>
        /// 根据等级编号得到下载等级
        /// </summary>
        /// <returns></returns>
        public static string GetDownLoadLeval(object objSoftLevel)
        {
            string type = "";
            int intType = int.Parse(objSoftLevel.ToString());
            switch (intType)
            {
                case 9999:
                    type = "游客";
                    break;
                case 999:
                    type = "注册用户";
                    break;
                case 99:
                    type = "收费用户";
                    break;
                case 9:
                    type = "VIP用户";
                    break;
                case 5:
                    type = "管理员";
                    break;
                default:
                    type = "未知";
                    break;
            }
            return type;
        }

        /// <summary>
        /// 检查过期时间，如果过期返回红色日期
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
        /// 绑定TextBox，就像属性，有赋值和取值功能
        /// </summary>
        /// <param name="aa">控件</param>
        /// <param name="key">本控件通过URL传值的键</param>
        /// <param name="isSet">是否是给控件赋值</param>
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
        /// 绑定ChickBox，就像属性，有赋值和取值功能
        /// </summary>
        /// <param name="aa">控件</param>
        /// <param name="key">本控件通过URL传值的键</param>
        /// <param name="isSet">是否是给控件赋值</param>
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
        /// 绑定DropDownList（或RadioButtonList），就像属性，有赋值和取值功能
        /// </summary>
        /// <param name="aa">控件</param>
        /// <param name="key">本控件通过URL传值的键</param>
        /// <param name="isSet">是否是给控件赋值</param>
        /// <returns></returns>
        public static string BindDdlOrRadio(System.Web.UI.Control aa, string key, bool isSet)
        {
            string strTemp = "";
            if (isSet)
            {
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request[key]))
                {
                    string sname = (System.Web.HttpContext.Current.Request[key]);
                    if (sname == "数字6 1")
                    {
                        sname = "数字6+1";
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
                    if (!string.IsNullOrEmpty(strSelectValue) && strSelectValue != "所有")
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
                    if (!string.IsNullOrEmpty(strSelectValue) && strSelectValue != "所有")
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
        /// US_msg.aspx得到到期日期
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
                    result = "未统计";
                }
                else if (intStatResult == 0)
                {
                    result = "<font color='#ff0000'>发帖不够</font>";
                }
                else
                {
                    result = "<font color='#009900'>本周免费</font>";
                }
            }
            else
            {
                result = "--";
            }
            return result;
        }

        /// <summary>
        /// 将乐透型开奖号码按分隔符每两位分开
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
        /// 检查乐透型是否有重复号码
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
                    result = "号码范围不对,号码范围[01—" + max + "]";
                    break;
                }
                for (int j = i + 1; j < checkCodeSZ.Length; j++)
                {
                    if (checkCodeSZ[i] == checkCodeSZ[j])
                    {
                        result = "不能有重复号码";
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 对号码字符串进行排序返回排序后字符串
        /// </summary>
        /// <param name="code">拼接后的号码字符串</param>
        /// <param name="flag">分隔符</param>
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
        /// 得到开奖日期
        /// </summary>
        /// <param name="lottdate"></param>
        /// <returns></returns>
        /// autor:孟
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
                    s_temp += "、";
                }
                s_temp += "周一";
            }
            if (lottdate.IndexOf('3') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "、";
                }
                s_temp += "周二";
            }
            if (lottdate.IndexOf('4') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "、";
                }
                s_temp += "周三";
            }
            if (lottdate.IndexOf('5') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "、";
                }
                s_temp += "周四";
            }
            if (lottdate.IndexOf('6') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "、";
                }
                s_temp += "周五";
            }
            if (lottdate.IndexOf('7') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "、";
                }
                s_temp += "周六";
            }
            if (lottdate.IndexOf('1') > -1)
            {
                if (s_temp.Length > 0)
                {
                    s_temp += "、";
                }
                s_temp += "周日";
            }
            if (string.IsNullOrEmpty(s_temp))
            {
                s_temp = "天";
            }
            result = "&nbsp;&nbsp;&nbsp;<font color='0000FF'>每" + s_temp + "开奖</font>";
            int index = ((int)DateTime.Now.DayOfWeek) + 1;
            if (lottdate.IndexOf("" + index.ToString() + "") > -1)
            {
                result += "&nbsp;&nbsp;&nbsp;<font color='FF0000'>今日开奖</font>";
            }
            return result;

        }


        /// <summary>
        /// 得到开奖日期1
        /// </summary>
        /// <param name="lottdate"></param>
        /// <returns></returns>
        /// 作者：孟
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
                        s_temp += "、";
                    }
                    s_temp += "周一";
                }
                if (lottdate.IndexOf('3') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "、";
                    }
                    s_temp += "周二";
                }
                if (lottdate.IndexOf('4') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "、";
                    }
                    s_temp += "周三";
                }
                if (lottdate.IndexOf('5') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "、";
                    }
                    s_temp += "周四";
                }
                if (lottdate.IndexOf('6') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "、";
                    }
                    s_temp += "周五";
                }
                if (lottdate.IndexOf('7') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "、";
                    }
                    s_temp += "周六";
                }
                if (lottdate.IndexOf('1') > -1)
                {
                    if (s_temp.Length > 0)
                    {
                        s_temp += "、";
                    }
                    s_temp += "周日";
                }
                if (string.IsNullOrEmpty(s_temp))
                {
                    s_temp = "每日";
                }
            }
            else if (lottdate.Substring(lottdate.Length - 1, 1) == "M")
            {
                s_temp = "每" + lottdate.Substring(0, lottdate.Length - 1) + "分钟一期";
            }
            else if (lottdate.Substring(lottdate.Length - 1, 1) == "H")
            {
                s_temp = "每" + lottdate.Substring(0, lottdate.Length - 1) + "小时一期";
            }

            //int index = ((int)DateTime.Now.DayOfWeek) + 1;
            //if (lottdate.IndexOf("" + index.ToString() + "") > -1)
            //{
            //    result += "&nbsp;&nbsp;&nbsp;<font color='FF0000'>今日开奖</font>";
            //}            
            return s_temp;

        }


        /// <summary>
        /// 将短日期形式的字符串格式为时间形式（如：20080112转换成2008-1-12）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime FormartStrToDate(string str)
        {
            if (str.Length != 8)
            {
                throw new Exception("数据位数不够");
            }
            return DateTime.Parse(str.Substring(0, 4) + "-" + str.Substring(4, 2) + "-" + str.Substring(6));
        }

        /// <summary>
        /// 将时间格式化为短日期形式的字符串形式（如：2008-1-12转换成20080112）
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
        /// 得到新闻冷热属性
        /// </summary>
        /// <param name="hits">点击次数</param>
        /// <returns></returns>
        /// 作者：孟
        public static string GetNewsFlag(object objHits)
        {
            int hits = int.Parse(objHits.ToString());
            string flag = "";
            if (hits < (WebInit.webBaseConfig.HitsOfHot - 1))
            {
                flag = "<font color='blue'>冷</font>";
            }
            else
            {
                flag = "<font color='red'>热</font>";
            }
            return flag;
        }

        /// <summary>
        /// 根据是否是热点新闻，返回热点新闻条件查询字符串
        /// </summary>
        /// <param name="isHot">是否是热点新闻</param>
        /// <returns>热点新闻条件查询字符串</returns>
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
        /// 根据是否是热点问题，返回热点问题条件查询字符串
        /// </summary>
        /// <param name="isHot">是否是热点问题</param>
        /// <returns>热点问题条件查询字符串</returns>
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
        /// 生成随机数字
        /// </summary>
        /// <param name="length">生成长度</param>
        /// <returns></returns>
        public static string Number(int Length)
        {
            return Number(Length, false);
        }

        /// <summary>
        /// 生成随机数字
        /// </summary>
        /// <param name="Length">生成长度</param>
        /// <param name="Sleep">是否要在生成前将当前线程阻止以避免重复</param>
        /// <returns></returns>
        /// 作者：孟
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
        /// 把数字转换成汉字：例如1:一；2：二 ...
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        /// 作者：孟
        public static string NumToHanZi(int i)
        {
            switch (i)
            {
                case 1:
                    return "一";
                case 2:
                    return "二";
                case 3:
                    return "三";
                case 4:
                    return "四";
                case 5:
                    return "五";
                case 6:
                    return "六";
                case 7:
                    return "七";
                case 8:
                    return "八";
                case 9:
                    return "九";
                case 0:
                    return "零";
                default:
                    return i.ToString();
            }

        }

        //
        /// <summary>
        /// 根据最大球号，最小球号，区间个数，确定区间长度
        /// </summary>       
        /// <param name="maxNum">最大球号</param>
        /// <param name="minNum">最新球号</param>
        /// <param name="qjGS">区间个数</param>
        /// <returns>区间长度数组</returns>
        /// 时间：2009-07-16
        ///作者：孟宪迎 

        public static int[] CreateQuJian(int maxNum, int minNum, int qjGS)
        {
            int[] qujianSZ = new int[qjGS];
            int wholeNumCount = maxNum - minNum + 1;
            int yuShu = wholeNumCount % qjGS;
            // 平均分配个数
            int intBase = wholeNumCount / qjGS;
            for (int i = 0; i < qjGS; i++)
            {
                qujianSZ[i] = intBase;
            }
            // 处理剩下的，
            int nTemp = 0;
            while (yuShu > 1)
            {
                // 如果剩下大于2个则从两边开始（先后后前）放
                qujianSZ[nTemp]++;
                qujianSZ[qjGS - 1 - nTemp]++;
                nTemp++;
                yuShu -= 2;
            }
            if (yuShu == 1)
            {
                // 只剩1个，如果是奇数个分区，则放中间，否则放到最后一个分区
                if (qjGS % 2 == 0)
                    qujianSZ[qjGS - 1 - nTemp]++;
                else
                    qujianSZ[qjGS / 2]++;
            }
            return qujianSZ;
        }


        #region 验证用户名是否有效
        /// <summary>
        /// 验证用户名是否有效
        /// </summary>
        public static bool ValidateUserFormat(string userName)
        {
            string Regex = "^[a-zA-Z][a-zA-Z0-9_]{6,18}$";
            return RegexString.ValidateString(userName, Regex);
        }
        #endregion

        #region 验证密码是否有效
        /// <summary>
        /// 验证密码是否有效
        /// </summary>
        public static bool ValidatePassWordFormat(string userName)
        {
            string Regex = "^{6,18}$";
            return RegexString.ValidateString(userName, Regex);
        }
        #endregion


        /// <summary>
        /// 判断字符串中是否含有数字
        /// 时间：2009-07-30
        /// 作者：孟宪迎
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


        #region "获取登陆用户名"
        /// <summary>
        /// 获取登陆用户UserID,如果未登陆为0
        /// </summary>
        public static string Get_UserName
        {
            get
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("登录", "User.Identity.IsAuthenticated：" + HttpContext.Current.User.Identity.Name.ToString() + "；user:" + HttpContext.Current.User.ToString() + "；时间："+DateTime.Now+" \r\n", true, true);
           

                return HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name.Split(new char[] { '&' })[0] : "0";

            }

        }
        #endregion

        #region "获取登陆用户pwd"
        /// <summary>
        /// 获取登陆用户pwd,如果未登陆为0
        /// </summary>
        public static string Get_UserPwd
        {
            get
            {
                return HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name.Split(new char[] { '&' })[1] : "0";

            }

        }
        #endregion

        #region "获取登陆用户论坛ID"
        /// <summary>
        /// 获取登陆用户pwd,如果未登陆为0
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
        /// 按位加和到位数为1
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
        /// 取最后一位
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static int END(int code)
        {
            return int.Parse(code.ToString().Substring(code.ToString().Length - 1, 1));
        }

        /// <summary>
        /// 取和
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
        /// 算跨度
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
        /// 判断提交是否来自外部
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
        /// 当用户积分改变后检测拼搏吧用户等级是否需要更新
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
        /// 验证关注码
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

        ///号码得尾数
        public static int HW(string he)
        {
            return int.Parse(he.Substring(he.Length - 1, 1));
        }


        #region 获取购物车CartGuid
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


        #region 获取购物车CartGuid
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


        #region  将关键字在text中标示,返回标示后的text
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

        #region 转换为人民币货币格式
        public static string FormatMoney(object money)
        {
            decimal deMoney = Convert.ToDecimal(money);
            return string.Format("{0:C2}", deMoney);
        }
        #endregion

        /// <summary>
        /// 计算购物车单行价格
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
        /// 计算校验码
        /// </summary>
        /// <returns></returns>
        public static string GetCheckCode(string temp)
        {
            string num = temp.Substring(2);
            //3位加
            int threeAdd = AddNum(num, 3);
            //两位加
            int twoAdd = AddNum(num, 2);
            //一位加
            int oneAdd = AddNum(num, 1);
            int tempHe = threeAdd + twoAdd + oneAdd;


            return string.Format("{0:D3}", (tempHe % 1000));
        }

        /// <summary>
        /// 按位加
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
        /// 格式管理员权限字符串
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
        /// 根据时间序列计算一天开奖次数
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

        //得到开奖时间间隔
        public static int CetLotteryJG(object objTime)
        {
            if (objTime != null && !string.IsNullOrEmpty(objTime.ToString()))
            {
                string[] tmSZ = objTime.ToString().Split(new char[] { '|' });
                TimeSpan tsStart = new TimeSpan();
                TimeSpan tsEnd = new TimeSpan();
                if (!TimeSpan.TryParse(tmSZ[0], out tsStart) || !TimeSpan.TryParse(tmSZ[1], out tsEnd))
                {
                    System.Web.HttpContext.Current.Response.Write("<script>alert('时间序列有误!')</script>");
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

        //得到字符长度（一个汉字占两个字符）
        public static int GetStrLen(String ss)
        {
            Char[] cc = ss.ToCharArray();
            int intLen = ss.Length;
            int i;
            if ("豆腐".Length == 4)
            {
                //是非 中文 的 平台
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
        /// 购物车检查软件认证码是否合法
        /// </summary>
        /// <param name="F_HDSN"></param>
        /// <returns></returns>
        public static string CheckCartRegType(object F_HDSN, string regType, string ProductID)
        {
            //string result = "";
            string strHdsn = F_HDSN.ToString();
            //验证长度是否是16位start
            if (strHdsn.Length != 16)
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            //验证长度是否是16位end

            string strFlag = strHdsn.Substring(4, 1);
            if (Convert.ToInt32(strFlag) < 5)
            {
                strFlag = "1";
            }
            string rzmType = regType.Split(new char[] { '|' })[0];
            string strF_HDSN = F_HDSN.ToString();
            //根据第五位判断软件类型是否正确start
            if (string.IsNullOrEmpty(rzmType))
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            if (rzmType == "7")
            {
                rzmType = "9";
            }
            if (rzmType != strFlag)
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            //根据第五位判断软件类型是否正确end

            //根据认证码后3位判断软件是否正确start
            object objCstID = DbHelperSQL.GetSingle(" select CstID from PBnet_Product where pb_SoftID='" + ProductID + "'  ");
            int cstID = 0;
            try
            {
                cstID = Convert.ToInt32(objCstID);
            }
            catch (Exception ex)
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            string strCstID = cstID.ToString();
            if (strCstID.Length < 3)
            {
                strCstID = "0" + strCstID;
            }
            if (strF_HDSN.Substring(strF_HDSN.Length - 3, 3) != strCstID)
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            //根据认证码后3位判断软件是否正确start

            //验证认证码校验位start
            string strTempF_HDSN = strF_HDSN.Substring(0, 5) + "000" + strF_HDSN.Substring(8);
            // 三位一起校验和
            int nTemp = 0;
            for (int i = 0; i < 16; i += 3)
            {
                if ((i + 3) > 16)
                {
                    break;
                }
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 3));

            }
            // 两位一起校验和
            for (int i = 0; i < 16; i += 2)
            {
                if ((i + 2) > 16)
                {
                    break;
                }
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 2));

            }
            // 一位校验和
            for (int i = 0; i < 16; i++)
            {
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 1));
            }
            nTemp %= 1000;

            if (int.Parse(strF_HDSN.Substring(5, 3)) != int.Parse(nTemp.ToString()))
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            return "";
        }

        /// <summary>
        /// 购物车检查软件认证码是否合法
        /// </summary>
        /// <param name="F_HDSN"></param>
        /// <returns></returns>
        public static string CheckCartRegTypeCst(object F_HDSN, string regType, string CstID)
        {
            //string result = "";
            string strHdsn = F_HDSN.ToString();
            //验证长度是否是16位start
            if (strHdsn.Length != 16)
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            //验证长度是否是16位end

            string strFlag = strHdsn.Substring(4, 1);
            if (Convert.ToInt32(strFlag) < 5)
            {
                strFlag = "1";
            }
            string rzmType = regType.Split(new char[] { '|' })[0];
            string strF_HDSN = F_HDSN.ToString();


            //根据第五位判断软件类型是否正确start
            if (string.IsNullOrEmpty(rzmType))
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            if (rzmType == "7")
            {
                rzmType = "9";
            }
            if (rzmType != strFlag)
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            //根据第五位判断软件类型是否正确end

            //根据认证码后3位判断软件是否正确start
            int cstID = 0;
            try
            {
                cstID = Convert.ToInt32(CstID);
            }
            catch (Exception ex)
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            string strCstID = cstID.ToString();
            if (strCstID.Length < 3)
            {
                strCstID = "0" + strCstID;
            }
            if (strF_HDSN.Substring(strF_HDSN.Length - 3, 3) != strCstID)
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            //根据认证码后3位判断软件是否正确start

            //验证认证码校验位start
            string strTempF_HDSN = strF_HDSN.Substring(0, 5) + "000" + strF_HDSN.Substring(8);
            // 三位一起校验和
            int nTemp = 0;
            for (int i = 0; i < 16; i += 3)
            {
                if ((i + 3) > 16)
                {
                    break;
                }
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 3));
            }
            // 两位一起校验和
            for (int i = 0; i < 16; i += 2)
            {
                if ((i + 2) > 16)
                {
                    break;
                }
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 2));
            }
            // 一位校验和
            for (int i = 0; i < 16; i++)
            {
                nTemp += int.Parse(strTempF_HDSN.Substring(i, 1));
            }
            nTemp %= 1000;
            if (strF_HDSN.Substring(5, 3) != nTemp.ToString())
            {
                return "此认证码非本软件认证码，请重新核实无误后输入！";
            }
            return "";
        }


        /// <summary>
        /// 注册类别转换成易处理下标
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
        #region 生成随机字符码

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
        /// 检测正整数形输入是否合法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string CheckIsNum(string name, string text, int min, int max)
        {
            int result = 0;
            if (!int.TryParse(text, out result))
            {
                return name + "格式错误！";
            }
            else if (result < min)
            {
                return name + "不能少于" + min + "！";
            }
            else if (result > max)
            {
                return name + "不能大于" + max + "！";
            }
            return "";
        }

        /// <summary>
        /// 生成订单号
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static string CreateOrderID(string prefix, string tableName)
        {
            string orderID = null;
            DateTime now = DateTime.Now;
            //年
            string year = now.Year.ToString();
            year = year.Substring(year.Length - 2, 2);
            //月
            string month = now.Month.ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            //日
            string day = now.Day.ToString();
            if (day.Length < 2)
            {
                day = "0" + day;
            }
            string tempOrder = "";
            //最新订单号
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
            //最小订单号年月日
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
        /// 检查订单是否重复
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="tableName"></param>
        /// <param name="orderID"></param>
        /// <returns></returns>
        private static string checkCFOrderID(string prefix, string tableName, string orderID)
        {
            DateTime now = DateTime.Now;
            //年
            string year = now.Year.ToString();
            year = year.Substring(year.Length - 2, 2);
            //月
            string month = now.Month.ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            //日
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
        /// 创建注册码
        /// </summary>
        /// <param name="type">()</param>
        /// <returns></returns>
        public static string CreateSerial(int type)
        {
            // return CM.MyMethod('1');                 
            return "1234567890";
        }

        /// <summary>
        /// 根据文件路径返回字符串
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetEmailContent(string path)
        {
            string result = "";
            try
            {
                StringWriter strHTML = new StringWriter();
                System.Web.UI.Page myPage = new Page();   //System.Web.UI.Page中有个Server对象，我们要利用一下它
                myPage.Server.Execute(path, strHTML);    //将asp_net.aspx将在客户段显示的html内容读到了strHTML中
                result = strHTML.ToString();

                //StreamWriter sw = new StreamWriter(strSavePath+strSaveFile,true,System.Text.Encoding.GetEncoding("GB2312"));
                //新建一个文件Test.htm，文件格式为GB2312
                //sw.Write(strHTML.ToString());            
                //将strHTML中的字符写到Test.htm中
                strHTML.Close();
                //关闭StringWriter 
                //sw.Close();                                    
                //关闭StreamWriter 
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
        /// 根据Email验证和银行卡验证状态ID得到验证状态名称
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
                    result[0] = "未验证";
                    result[1] = "申请验证";
                    break;
                case "1":
                    result[0] = "验证中";
                    if (type == "1")
                    {
                        result[1] = "Email验证";
                    }
                    else if (type == "2")
                    {
                        result[1] = "";
                    }
                    else
                    {
                        result[1] = "验证";
                    }
                    break;
                case "2":
                    result[0] = "验证失败";
                    result[1] = "重新申请验证";
                    break;
                case "3":
                    result[0] = "验证通过";
                    result[1] = "";
                    break;
                case "4":
                    result[0] = "验证中";
                    result[1] = "银行卡验证";
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
                    return "未开通高级用户";
                case "1":
                    return "未审核";
                case "2":
                    return "正常";
                case "3":
                    return "审核未通过";
                case "10":
                    return "锁定";
            }
            return result;
        }

        /// <summary>
        /// 创建银行验证码，0.01-0.19,格式为小数点后保留两位
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
        /// 根据链接类型代码得到链接类型名
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
                    type = "图片链接";
                    break;
                case 1:
                    type = "文字链接";
                    break;
                default:
                    type = "未知类型";
                    break;
            }
            return type;
        }

        /// <summary>
        /// 拼搏吧-根据问题状态ID返回状态名称
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns></returns>
        public static string GetQuestionStateName(object stateID)
        {
            switch (stateID.ToString())
            {
                case "0":
                    return "待解决";
                case "1":
                    return "已解决";
                case "2":
                    return "已关闭";
                case "3":
                    return "被删除";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 得到当前代理的折扣
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
        /// 得到当前代理的折扣
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
                    System.Web.HttpContext.Current.Response.Write("<script>alert('您的代理信息已经改变，请重新登录！');top.location='/login.aspx';</script>");
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
        /// 计算当前购物车商品总价格()
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
            //判断当前用户是否是代理用户(2010-03-04)start
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

        //根据用户等级返回带颜色用户名
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
        /// 绑定省份
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
                return "常规";
            }
            else if (strRegMode == "1")
            {
                return "手工";
            }
            else if (strRegMode == "10")
            {
                return "自动";
            }
            else
            {
                return "常规";
            }
        }

        /// <summary>
        /// 检测是否是代理身份
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
        /// 用户日志记录
        /// </summary>
        /// <param name="log_username">用户名</param>
        /// <param name="sqlintoWeb">密码/注入符号</param>
        /// <param name="s_state">状态</param>
        public static void record_user_log(string log_username, string sqlintoWeb, string s_state, string Type)
        {
            //<!--用户日志(登录部分记录开关)-->
            string UserLog_Login_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_Login_OnOff"];
            //<!--用户日志(密码相关记录开关)-->
            string UserLog_PWD_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_PWD_OnOff"];
            //<!--用户日志(网站恶意攻击记录开关)-->
            string UserLog_Into_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_Into_OnOff"];
            bool open = false;
            if (Type == "登录" && (UserLog_Login_OnOff == "" || UserLog_Login_OnOff == "on"))
            {
                open = true;
            }
            else if (Type == "恶意攻击" && (UserLog_Into_OnOff == "" || UserLog_Into_OnOff == "on"))
            {
                open = true;
            }
            else if (Type == "密码相关" && (UserLog_PWD_OnOff == "" || UserLog_PWD_OnOff == "on"))
            {
                open = true;
            }
            if (open)
            {
                string s_ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                string s_temp = S_getIPaddress(s_ip);
                string s_sqlinto = System.Web.HttpContext.Current.Server.UrlDecode(sqlintoWeb);
                s_sqlinto = s_sqlinto.Replace("%", "％");
                s_sqlinto = s_sqlinto.Replace("'", "‘");
                s_sqlinto = s_sqlinto.Replace(";", "；");
                s_sqlinto = s_sqlinto.Replace("alert".ToLower(), "ａｌｅｒｔ");
                string urlName = System.Web.HttpContext.Current.Request.FilePath;
                urlName = urlName.Replace("'", "‘");
                urlName = urlName.Replace(";", "；");
                urlName = urlName.Replace("alert".ToLower(), "ａｌｅｒｔ");
                string allhttp = "dns=" + System.Web.HttpContext.Current.Request.UserHostName + "；" + "浏览器代理：" + System.Web.HttpContext.Current.Request.UserAgent + "，" + System.Web.HttpContext.Current.Request.Browser.Browser + System.Web.HttpContext.Current.Request.Browser.Version;
                //'	allhttp=request.servervariables("Remote_Host")&VBCR&VBLF&request.servervariables("Http_Referer")&VBCR&VBLF
                //'	allhttp=allhttp&request.servervariables("All_Http")&VBCR&VBLF&request.servervariables("All_RAW")
                //    allhttp=request.servervariables("All_Http")
                //'	s_sqlinto="注入"
                string sqlinto_aaa = "insert into PBnet_UserLog(log_username,log_password,log_stepinto,log_urlname,log_time,log_Ip,log_state,log_allhttp,log_country,log_city) values('" + log_username + "','" + s_sqlinto + "','Pinble.com','" + urlName + "','" + DateTime.Now + "','" + s_ip + "','" + s_state + "','" + allhttp + "','" + s_temp + "','')";
                DbHelperSQL.ExecuteSql(sqlinto_aaa);
            }
        }


        /// <summary>
        /// 用户日志2记录
        /// </summary>
        /// <param name="log_username">用户名</param>
        /// <param name="sqlintoWeb">密码/注入符号</param>
        /// <param name="s_state">状态</param>
        public static void record_user_log_01(string log_username, string sqlintoWeb, string s_state, string Type)
        {
            //<!--用户日志(登录部分记录开关)-->
            string UserLog_Login_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_Login_OnOff"];
            //<!--用户日志(密码相关记录开关)-->
            string UserLog_PWD_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_PWD_OnOff"];
            //<!--用户日志(网站恶意攻击记录开关)-->
            string UserLog_Into_OnOff = System.Configuration.ConfigurationManager.AppSettings["UserLog_Into_OnOff"];
            bool open = false;
            if (Type == "登录" && (UserLog_Login_OnOff == "" || UserLog_Login_OnOff == "on"))
            {
                open = true;
            }
            else if (Type == "恶意攻击" && (UserLog_Into_OnOff == "" || UserLog_Into_OnOff == "on"))
            {
                open = true;
            }
            else if (Type == "密码相关" && (UserLog_PWD_OnOff == "" || UserLog_PWD_OnOff == "on"))
            {
                open = true;
            }
            if (open)
            {
                string s_ip = System.Web.HttpContext.Current.Request.UserHostAddress;
                string s_temp = S_getIPaddress(s_ip);
                string s_sqlinto = System.Web.HttpContext.Current.Server.UrlDecode(sqlintoWeb);
                s_sqlinto = s_sqlinto.Replace("%", "％");
                s_sqlinto = s_sqlinto.Replace("'", "‘");
                s_sqlinto = s_sqlinto.Replace(";", "；");
                s_sqlinto = s_sqlinto.Replace("alert".ToLower(), "ａｌｅｒｔ");
                string urlName = System.Web.HttpContext.Current.Request.FilePath;
                urlName = urlName.Replace("'", "‘");
                urlName = urlName.Replace(";", "；");
                urlName = urlName.Replace("alert".ToLower(), "ａｌｅｒｔ");
                string allhttp = "dns=" + System.Web.HttpContext.Current.Request.UserHostName + "；" + "浏览器代理：" + System.Web.HttpContext.Current.Request.UserAgent + "，" + System.Web.HttpContext.Current.Request.Browser.Browser + System.Web.HttpContext.Current.Request.Browser.Version;
                //'	allhttp=request.servervariables("Remote_Host")&VBCR&VBLF&request.servervariables("Http_Referer")&VBCR&VBLF
                //'	allhttp=allhttp&request.servervariables("All_Http")&VBCR&VBLF&request.servervariables("All_RAW")
                //    allhttp=request.servervariables("All_Http")
                //'	s_sqlinto="注入"
                string sqlinto_aaa = "insert into PBnet_UserLog(log_username,log_password,log_stepinto,log_urlname,log_time,log_Ip,log_state,log_allhttp,log_country,log_city) values('" + log_username + "','" + s_sqlinto + "','Chat','" + urlName + "','" + DateTime.Now + "','" + s_ip + "','" + s_state + "','" + allhttp + "','" + s_temp + "','')";
                DbHelperSQL.ExecuteSql(sqlinto_aaa);
            }
        }


        /// <summary>
        /// 根据ip地址获取地址名称
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
                return "未知";
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
        /// 双色球项目截止时间
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
                        //查询彩种的开奖时间
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from FCSSData order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();
                        //双色球开奖为：每周二、周四、周日
                        switch (((int)DateTime.Parse(sdate).DayOfWeek) + 1)
                        {
                            case 1: //星期天
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期二
                                break;
                            case 3:   //星期二 
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期四
                                break;
                            case 5: // 星期四
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();// 下个星期天 
                                break;
                        }

                        XmlNode haha = root.SelectNodes("FCSSQEndTime")[0];

                        //对比xml的截止时间，当xml截止时间大于数据库的最后开奖时间，则使用xml的截止时间
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
                #region//保存日期
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

                #region 保存时分秒
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
        /// 福彩3D项目截止时间
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
                        //查询彩种的开奖时间
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 2 date,code from FC3DData order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();

                        string code = dsperiod.Tables[0].Rows[0]["code"].ToString();
                        if (code == "" || code.Trim().Length <= 0)
                        {
                            sdate = dsperiod.Tables[0].Rows[1]["date"].ToString();

                        }

                        XmlNode haha = root.SelectNodes("FC3DEndTime")[0];



                        //对比xml的截止时间，当xml截止时间大于数据库的最后开奖时间，则使用xml的截止时间
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
                #region//保存日期
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

                #region 保存时分秒
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
        /// 体彩排列五项目截止时间
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
                        //查询彩种的开奖时间
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from TCPL35Data order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();



                        //对比xml的截止时间，当xml截止时间大于数据库的最后开奖时间，则使用xml的截止时间
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

                #region//保存日期
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

                #region 保存时分秒
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
        /// 体彩七星彩
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
                        //查询彩种的开奖时间
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from TC7XCData_New  order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();
                        //每周二、周五、周日
                        switch (((int)DateTime.Parse(sdate).DayOfWeek) + 1)
                        {
                            case 1: //星期天
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期二
                                break;
                            case 3:   //星期二 
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();//下个星期五
                                break;
                            case 6: // 星期五
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();// 下个星期天 
                                break;
                        }

                        XmlNode haha = root.SelectNodes("TC7XCEndTime")[0];
                        //对比xml的截止时间，当xml截止时间大于数据库的最后开奖时间，则使用xml的截止时间
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

                #region//保存日期
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

                #region 保存时分秒
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
        /// 福彩七乐彩
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
                        //查询彩种的开奖时间
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from FC7LC  order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();
                        //每周一、周三、周五
                        switch (((int)DateTime.Parse(sdate).DayOfWeek) + 1)
                        {
                            case 6: //星期五
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();//下个星期一
                                break;
                            case 2:   //星期一 
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期三
                                break;
                            case 4: // 星期三
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();// 下个星期五
                                break;
                        }

                        XmlNode haha = root.SelectNodes("FC7LCEndTime")[0];


                        //对比xml的截止时间，当xml截止时间大于数据库的最后开奖时间，则使用xml的截止时间
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
                #region//保存日期
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

                #region 保存时分秒
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
        ///体彩大乐透 
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
                        //查询彩种的开奖时间
                        DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from TCDLTData  order by date desc");

                        string sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();
                        //每周一、周三、周六
                        switch (((int)DateTime.Parse(sdate).DayOfWeek) + 1)
                        {
                            case 7: //星期六
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期一
                                break;
                            case 2:   //星期一 
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期三
                                break;
                            case 4: // 星期三
                                sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();// 下个星期六
                                break;
                        }

                        XmlNode haha = root.SelectNodes("TCDLTEndTime")[0];
                        //对比xml的截止时间，当xml截止时间大于数据库的最后开奖时间，则使用xml的截止时间
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
                #region//保存日期
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

                #region 保存时分秒
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
        /// 体彩22选5
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
        /// 体彩31选7
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
                //查询彩种的开奖时间
                DataSet dsperiod = Maticsoft.DBUtility.DbHelperSQL1.Query("select top 1 date from " + lottoryname + "  order by date desc");
                sdate = dsperiod.Tables[0].Rows[0]["date"].ToString();
            }
            //每周一、周三、周六
            switch (((int)DateTime.Parse(sdate).DayOfWeek) + 1)
            {
                case 7: //星期六
                    sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期一
                    break;
                case 2:   //星期一 
                    sdate = DateTime.Parse(sdate.ToString()).AddDays(2).ToShortDateString();//下个星期三
                    break;
                case 4: // 星期三
                    sdate = DateTime.Parse(sdate.ToString()).AddDays(3).ToShortDateString();// 下个星期六
                    break;
            }
            return Convert.ToDateTime(sdate).ToString("yyyy-MM-dd");
        }


        /// <summary>
        /// 生成方案编号
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <returns></returns>
        public static string CreateQNumber(string prefix,bool Sleep)
        {
            DateTime now = DateTime.Now;
            //年
            string year = now.Year.ToString();
            year = year.Substring(year.Length - 2, 2);
            //月
            string month = now.Month.ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            //日
            string day = now.Day.ToString();
            if (day.Length < 2)
            {
                day = "0" + day;
            }
            //小时
            string hh = now.Hour.ToString();
            if (hh.Length < 2)
            {
                hh = "0" + hh;
            }
            //分钟
            string MM = now.Minute.ToString();
            if (MM.Length < 2)
            {
                MM = "0" + MM;
            }
            //秒
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
        /// 检查方案是否重复
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="tableName"></param>
        /// <param name="orderID"></param>
        /// <returns></returns>
        private static string checkCFQNumber(string prefix, string tableName, string QNumber)
        {
            DateTime now = DateTime.Now;
            //年
            string year = now.Year.ToString();
            year = year.Substring(year.Length - 2, 2);
            //月
            string month = now.Month.ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            //日
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
        /// 投注按钮显示
        /// </summary>
        /// <param name="ltime">截止时间</param>
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
        /// 根据标识ID得到标识信息
        /// </summary>
        /// <param name="number">彩种ID</param>
        /// <param name="type">需要获取的类型，1 彩票编号，2为日志类型</param>
        /// <returns>到数据获取失败时返回null</returns>
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
        /// 根据标识ID得到标识信息
        /// </summary>
        /// <param name="number">彩种ID</param>
        /// <param name="type">需要获取的类型，1 彩票编号，2为日志类型</param>
        /// <returns>到数据获取失败时返回null</returns>
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
        /// 根据标识ID修改标识信息
        /// </summary>
        /// <param name="number">标识ID</param>
        /// <param name="type">需要修改的类型，1为彩种类型，2为日志类型</param>
        /// <param name="value">需要修改的类型，1为彩种类型，2为日志类型</param>
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
        /// 根据条件得到相应的描述
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
        /// 返回开奖号码
        /// </summary>
        /// <param name="lottID">彩种Id</param>
        /// <param name="issue">期号</param>
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
                //七乐彩
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code,tcode from FC7LC where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //处理号码球
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
                //双色球
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select redcode,bluecode from FCSSData where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //处理号码球
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
                //排列5
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code5 from TCPL35Data where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (lottID == 9999)
            {
                //排列3
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code3 from TCPL35Data where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (lottID == 5)
            {
                //七星彩
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code from TC7XCData_New where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
            }
            if (lottID == 6)
            {
                //大乐透
                ds = Maticsoft.DBUtility.DbHelperSQL1.Query("select code,code2 from TCDLTData where issue=" + issue);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //处理号码球
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
