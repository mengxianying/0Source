using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pbzx.Common;
using System.Data;

namespace Pinble_DataRivalry.admin
{
    public partial class NumTimeConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindPageConfig();
                Pbzx.BLL.PBnet_tpman get_tn = new Pbzx.BLL.PBnet_tpman();
                string name = Pbzx.Common.Input.URLDecode(Input.FilterAll(Request["name"].ToString()));
                if (string.IsNullOrEmpty(name) == true)
                {
                    Pbzx.BLL.PBnet_tpman.IsLoginSoftware();
                }
                else
                {
                    DataSet ds_user = get_tn.GetList("Master_Name=" + "'" + name + "'");
                    if (ds_user == null || ds_user.Tables[0].Rows.Count <= 0)
                    {
                        Pbzx.BLL.PBnet_tpman.IsLoginSoftware();
                    }
                    else
                    {
                        BindPageConfig();
                    }
                }
            }
        }

        private void BindPageConfig()
        {

            PlatformTimeConfig timeConfig = WebInit.timeconfig;
            //时间设置
            txt_FC3DDataTime.Text = timeConfig.FC3DDataTime;
            txt_FC7LCTime.Text = timeConfig.FC7LCTime;
            txt_FCSSDataTime.Text = timeConfig.FCSSDataTime;
            txt_TCPL35DataTime.Text = timeConfig.TCPL35DataTime;
            txt_TC7XCDataTime.Text = timeConfig.TC7XCDataTime;
            txt_TCDLTDataTime.Text = timeConfig.TCDLTDataTime;
            txt_LottCompulsory.Text = timeConfig.LottCompulsory;
            txt_ExecutionTime.Text = timeConfig.ExecutionTime;

            //彩种截止时间设置
            PlatformEndTimeConfig endtimeConfig = WebInit.endtimeconfig;
            txt_3DEndTime.Text = endtimeConfig.FC3DEndTime;
            txt_ssqEndTime.Text = endtimeConfig.FCSSQEndTime;
            txt_plEndTime.Text = endtimeConfig.TCPL35EndTime;

            //大底范围设置-单选
            SwitchConfig scopeConfig = WebInit.switchconfig;
            //最小注数
            txt_LeastRange.Text = scopeConfig.LeastRange;
            //最大注数
            txt_MaximumRange.Text = scopeConfig.MaximumRange;
            //基数
            txt_InTwo.Text = scopeConfig.InTwo;
            txt_InOne.Text = scopeConfig.InOne;
            txt_InZero.Text = scopeConfig.InZero;

            //积分
            txt_IntegralTwo.Text = scopeConfig.IntegralTwo;
            txt_IntegralOne.Text = scopeConfig.IntegralOne;
            txt_IntegralZero.Text = scopeConfig.IntegralZero;
            txt_IntegralGroup.Text = scopeConfig.IntegralGroup;
            //金币
            txt_CoinTwo.Text = scopeConfig.CoinTwo;
            txt_CoinOne.Text = scopeConfig.CoinOne;
            txt_CoinZero.Text = scopeConfig.CoinZero;
            txt_CoinGroup.Text = scopeConfig.CoinGroup;

            //上下限
            txt_InTwoUpperlimit.Text = scopeConfig.InTwoUpperlimit;
            txt_InTwoLowerlimit.Text = scopeConfig.InTwoLowerlimit;

            txt_InOneUpperlimit.Text = scopeConfig.InOneUpperlimit;
            txt_InOneLowerlimit.Text = scopeConfig.InOneLowerlimit;

            txt_InZeroUpperlimit.Text = scopeConfig.InZeroUpperlimit;
            txt_InZeroLowerlimit.Text = scopeConfig.InZeroLowerlimit;


            //大底范围设置-组选
            GroupNumConfig groupConfig = WebInit.groupNumconfig;
            //最小注数
            tLeastRange.Text = groupConfig.LeastRange;
            tMaximumRange.Text = groupConfig.MaximumRange;

            //基数 组6
            tInTwo.Text = groupConfig.InTwo;
            tInOne.Text = groupConfig.InOne;
            tInZero.Text = groupConfig.InZero;

            //基数 组3
            tInTwozt.Text = groupConfig.InTwozt;
            tInOnezt.Text = groupConfig.InOnezt;
            tInZerozt.Text = groupConfig.InZerozt;

            //基数 豹子
            tInTwobz.Text = groupConfig.InTwobz;
            tInOnebz.Text = groupConfig.InOnebz;
            tInZerobz.Text = groupConfig.InZerobz;


            //积分
            tIntegralTwo.Text = groupConfig.IntegralTwo;
            tIntegralOne.Text = groupConfig.IntegralOne;
            tIntegralZero.Text = groupConfig.IntegralZero;
            tIntegralGroup.Text = groupConfig.IntegralGroup;
            //金币
            tCoinTwo.Text = groupConfig.CoinTwo;
            tCoinOne.Text = groupConfig.CoinOne;
            tCoinZero.Text = groupConfig.CoinZero;
            tCoinGroup.Text = groupConfig.CoinGroup;

            //上下限
            tInTwoUpperlimit.Text = groupConfig.InTwoUpperlimit;
            tInTwoLowerlimit.Text = groupConfig.InTwoLowerlimit;

            tInOneUpperlimit.Text = groupConfig.InOneUpperlimit;
            tInOneLowerlimit.Text = groupConfig.InOneLowerlimit;

            tInZeroUpperlimit.Text = groupConfig.InZeroUpperlimit;
            tInZeroLowerlimit.Text = groupConfig.InZeroLowerlimit;

        }


        /// <summary>
        /// 修改时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIndex_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            PlatformTimeConfig time_config = new PlatformTimeConfig();
            if (!IsTime(txt_FC3DDataTime.Text))
            {
                errMsg += "福彩3D时间格式错误！";

            }
            if (!IsTime(txt_FC7LCTime.Text))
            {
                errMsg += "福彩七乐彩时间格式错误！";

            }
            if (!IsTime(txt_FCSSDataTime.Text))
            {
                errMsg += "双色球时间格式错误！";

            }
            if (!IsTime(txt_TCPL35DataTime.Text))
            {
                errMsg += "排列三五时间格式错误！";

            }
            if (!IsTime(txt_TC7XCDataTime.Text))
            {
                errMsg += "七星彩时间格式错误！";

            }
            if (!IsTime(txt_TCDLTDataTime.Text))
            {
                errMsg += "大乐透时间格式错误！";

            }
            if (!IsTime(txt_ExecutionTime.Text))
            {
                errMsg += "页面启动刷新时间格式错误！";

            }
            if (errMsg.Length > 0)
            {
                Page.RegisterStartupScript("错误", JS.Alert("您提交的信息有以下错误，请修改后提交！\\r\\n" + errMsg));
                return;
            }
            time_config.FC3DDataTime = txt_FC3DDataTime.Text;
            time_config.FC7LCTime = txt_FC7LCTime.Text;
            time_config.FCSSDataTime = txt_FCSSDataTime.Text;
            time_config.FCSSDataTime = txt_FCSSDataTime.Text;
            time_config.TCPL35DataTime = txt_TCPL35DataTime.Text;
            time_config.TC7XCDataTime = txt_TC7XCDataTime.Text;
            time_config.TCDLTDataTime = txt_TCDLTDataTime.Text;
            time_config.ExecutionTime = txt_ExecutionTime.Text;

            time_config.LottCompulsory = txt_LottCompulsory.Text;
            WebInit.timeconfig = time_config;
            BindPageConfig();
        }
        /// <summary>
        /// 是否为时间型字符串
        /// </summary>
        /// <param name="source">时间字符串(15:00:00)</param>
        /// <returns></returns>
        public static bool IsTime(string StrSource)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(StrSource, @"^((20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$");
        }

        /// <summary>
        /// 平台截止发布时间设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEndTime_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            PlatformEndTimeConfig endtime_config = new PlatformEndTimeConfig();
            if (!IsTime(txt_3DEndTime.Text))
            {
                errMsg += "福彩3D截止发布时间格式错误！";

            }
            if (!IsTime(txt_ssqEndTime.Text))
            {
                errMsg += "双色球截止发布时间格式错误！";

            }
            if (!IsTime(txt_plEndTime.Text))
            {
                errMsg += "排列3 4截止发布时间时间格式错误！";

            }
            if (errMsg.Length > 0)
            {
                Page.RegisterStartupScript("错误", JS.Alert("您提交的信息有以下错误，请修改后提交！\\r\\n" + errMsg));
                return;
            }

            endtime_config.FC3DEndTime = txt_3DEndTime.Text;
            endtime_config.FCSSQEndTime = txt_ssqEndTime.Text;
            endtime_config.TCPL35EndTime = txt_plEndTime.Text;

            WebInit.endtimeconfig = endtime_config;
            BindPageConfig();
        }

        /// <summary>
        /// 单选大底范围设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_scope_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            SwitchConfig scopeConfig = new SwitchConfig();

            if (!IsNumeric(txt_LeastRange.Text))
            {
                errMsg += "单选大底最小范围请输入数字！";

            }
            if (!IsNumeric(txt_MaximumRange.Text))
            {
                errMsg += "单选大底最大范围请输入数字！";

            }
            if (!IsNumeric(txt_InTwo.Text))
            {
                errMsg += "单选大底2D基数请输入数字！";

            }
            if (!IsNumeric(txt_InOne.Text))
            {
                errMsg += "单选大底1D基数请输入数字！";

            }
            if (!IsNumeric(txt_InZero.Text))
            {
                errMsg += "单选大底0D基数请输入数字！";

            }
            //积分
            if (!IsNumeric(txt_IntegralTwo.Text))
            {
                errMsg += "单选大底2D积分设置请输入数字！";

            }
            if (!IsNumeric(txt_IntegralOne.Text))
            {
                errMsg += "单选大底1D积分请输入数字！";

            }
            if (!IsNumeric(txt_IntegralZero.Text))
            {
                errMsg += "单选大底0D积分请输入数字！";

            }
            if (!IsNumeric(txt_IntegralGroup.Text))
            {
                errMsg += "单选大底全中积分请输入数字！";

            }

            //金币
            if (!IsNumeric(txt_CoinTwo.Text))
            {
                errMsg += "单选大底2D金币设置请输入数字！";

            }
            if (!IsNumeric(txt_CoinOne.Text))
            {
                errMsg += "单选大底1D金币请输入数字！";

            }
            if (!IsNumeric(txt_CoinZero.Text))
            {
                errMsg += "单选大底0D金币请输入数字！";

            }
            if (!IsNumeric(txt_CoinGroup.Text))
            {
                errMsg += "单选大底全中金币请输入数字！";

            }

            //上下限
            if (!IsNumeric(txt_InTwoUpperlimit.Text))
            {
                errMsg += "单选大底2D上限请输入数字！";

            }
            if (!IsNumeric(txt_InTwoLowerlimit.Text))
            {
                errMsg += "单选大底2D下限请输入数字！";

            }
            if (!IsNumeric(txt_InOneUpperlimit.Text))
            {
                errMsg += "单选大底1D上限请输入数字！";

            }
            if (!IsNumeric(txt_InOneLowerlimit.Text))
            {
                errMsg += "单选大底1D下限请输入数字！";

            }
            if (!IsNumeric(txt_InZeroUpperlimit.Text))
            {
                errMsg += "单选大底0D上限请输入数字！";

            }
            if (!IsNumeric(txt_InZeroLowerlimit.Text))
            {
                errMsg += "单选大底0D下限请输入数字！";

            }
            if (errMsg.Length > 0)
            {
                Page.RegisterStartupScript("错误", JS.Alert("您提交的信息有以下错误，请修改后提交！\\r\\n" + errMsg));
                return;
            }
            if (rbl_yn.SelectedValue == "1")
            {
                //金币下载
                scopeConfig.Switch = "1";
            }
            if (rbl_yn.SelectedValue == "2")
            {
                //金币下载
                scopeConfig.Switch = "2";
            }
            scopeConfig.LeastRange = txt_LeastRange.Text;
            scopeConfig.MaximumRange = txt_MaximumRange.Text;

            //基数
            scopeConfig.InTwo = txt_InTwo.Text;
            scopeConfig.InOne = txt_InOne.Text;
            scopeConfig.InZero = txt_InZero.Text;
            //积分
            scopeConfig.IntegralTwo = txt_IntegralTwo.Text;
            scopeConfig.IntegralOne = txt_IntegralOne.Text;
            scopeConfig.IntegralZero = txt_IntegralZero.Text;
            scopeConfig.IntegralGroup = txt_IntegralGroup.Text;

            //金币
            scopeConfig.CoinTwo = txt_CoinTwo.Text;
            scopeConfig.CoinOne = txt_CoinOne.Text;
            scopeConfig.CoinZero = txt_CoinZero.Text;
            scopeConfig.CoinGroup = txt_CoinGroup.Text;
            //上下限
            scopeConfig.InTwoUpperlimit = txt_InTwoUpperlimit.Text;
            scopeConfig.InTwoLowerlimit = txt_InTwoLowerlimit.Text;

            scopeConfig.InOneUpperlimit = txt_InOneUpperlimit.Text;
            scopeConfig.InOneLowerlimit = txt_InOneLowerlimit.Text;

            scopeConfig.InZeroUpperlimit = txt_InZeroUpperlimit.Text;
            scopeConfig.InZeroLowerlimit = txt_InZeroLowerlimit.Text;

            WebInit.switchconfig = scopeConfig;

            BindPageConfig();
        }
        //验证字符串是否是纯数字
        private static bool IsNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg1.IsMatch(str);
        }

        /// <summary>
        /// 组选大底范围修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_group_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            GroupNumConfig groupConfig = new GroupNumConfig();
            if (!IsNumeric(tLeastRange.Text))
            {
                errMsg += "组选大底最小范围请输入数字！";

            }
            if (!IsNumeric(tMaximumRange.Text))
            {
                errMsg += "组选大底最大范围请输入数字！";

            }
            if (!IsNumeric(tInTwo.Text))
            {
                errMsg += "组选大底2D基数请输入数字！";

            }
            if (!IsNumeric(tInOne.Text))
            {
                errMsg += "组选大底1D基数请输入数字！";

            }
            if (!IsNumeric(tInZero.Text))
            {
                errMsg += "组选大底0D基数请输入数字！";

            }

            if (!IsNumeric(tInTwozt.Text))
            {
                errMsg += "组选大底2D基数请输入数字！";

            }
            if (!IsNumeric(tInOnezt.Text))
            {
                errMsg += "组选大底1D基数请输入数字！";

            }
            if (!IsNumeric(tInZerozt.Text))
            {
                errMsg += "组选大底0D基数请输入数字！";

            }

            if (!IsNumeric(tInTwobz.Text))
            {
                errMsg += "组选大底2D基数请输入数字！";

            }
            if (!IsNumeric(tInOnebz.Text))
            {
                errMsg += "组选大底1D基数请输入数字！";

            }
            if (!IsNumeric(tInZerobz.Text))
            {
                errMsg += "组选大底0D基数请输入数字！";

            }
            //积分
            if (!IsNumeric(tIntegralTwo.Text))
            {
                errMsg += "组选大底2D积分设置请输入数字！";

            }
            if (!IsNumeric(tIntegralOne.Text))
            {
                errMsg += "组选大底1D积分请输入数字！";

            }
            if (!IsNumeric(tIntegralZero.Text))
            {
                errMsg += "组选大底0D积分请输入数字！";

            }
            if (!IsNumeric(tIntegralGroup.Text))
            {
                errMsg += "组选大底全中积分请输入数字！";

            }

            //金币
            if (!IsNumeric(tCoinTwo.Text))
            {
                errMsg += "组选大底2D金币设置请输入数字！";

            }
            if (!IsNumeric(tCoinOne.Text))
            {
                errMsg += "组选大底1D金币请输入数字！";

            }
            if (!IsNumeric(tCoinZero.Text))
            {
                errMsg += "组选大底0D金币请输入数字！";

            }
            if (!IsNumeric(tCoinGroup.Text))
            {
                errMsg += "组选大底全中金币请输入数字！";

            }

            //上下限
            if (!IsNumeric(tInTwoUpperlimit.Text))
            {
                errMsg += "组选大底2D上限请输入数字！";

            }
            if (!IsNumeric(tInTwoLowerlimit.Text))
            {
                errMsg += "组选大底2D下限请输入数字！";

            }
            if (!IsNumeric(tInOneUpperlimit.Text))
            {
                errMsg += "组选大底1D上限请输入数字！";

            }
            if (!IsNumeric(tInOneLowerlimit.Text))
            {
                errMsg += "组选大底1D下限请输入数字！";

            }
            if (!IsNumeric(tInZeroUpperlimit.Text))
            {
                errMsg += "组选大底0D上限请输入数字！";

            }
            if (!IsNumeric(tInZeroLowerlimit.Text))
            {
                errMsg += "组选大底0D下限请输入数字！";

            }
            if (errMsg.Length > 0)
            {
                Page.RegisterStartupScript("错误", JS.Alert("您提交的信息有以下错误，请修改后提交！\\r\\n" + errMsg));
                return;
            }
            /************单选大底**************/
            SwitchConfig scopeConfig = new SwitchConfig();
            if (rbl_yn.SelectedValue == "1")
            {
                //金币下载
                scopeConfig.Switch = "1";
            }
            if (rbl_yn.SelectedValue == "2")
            {
                //金币下载
                scopeConfig.Switch = "2";
            }
            scopeConfig.LeastRange = txt_LeastRange.Text;
            scopeConfig.MaximumRange = txt_MaximumRange.Text;

            //基数
            scopeConfig.InTwo = txt_InTwo.Text;
            scopeConfig.InOne = txt_InOne.Text;
            scopeConfig.InZero = txt_InZero.Text;

            //积分
            scopeConfig.IntegralTwo = txt_IntegralTwo.Text;
            scopeConfig.IntegralOne = txt_IntegralOne.Text;
            scopeConfig.IntegralZero = txt_IntegralZero.Text;
            scopeConfig.IntegralGroup = txt_IntegralGroup.Text;

            //金币
            scopeConfig.CoinTwo = txt_CoinTwo.Text;
            scopeConfig.CoinOne = txt_CoinOne.Text;
            scopeConfig.CoinZero = txt_CoinZero.Text;
            scopeConfig.CoinGroup = txt_CoinGroup.Text;
            //上下限
            scopeConfig.InTwoUpperlimit = txt_InTwoUpperlimit.Text;
            scopeConfig.InTwoLowerlimit = txt_InTwoLowerlimit.Text;

            scopeConfig.InOneUpperlimit = txt_InOneUpperlimit.Text;
            scopeConfig.InOneLowerlimit = txt_InOneLowerlimit.Text;

            scopeConfig.InZeroUpperlimit = txt_InZeroUpperlimit.Text;
            scopeConfig.InZeroLowerlimit = txt_InZeroLowerlimit.Text;

            WebInit.switchconfig = scopeConfig;
            /****************************/
            groupConfig.LeastRange = tLeastRange.Text;
            groupConfig.MaximumRange = tMaximumRange.Text;

            //基数
            groupConfig.InTwo = tInTwo.Text;
            groupConfig.InOne = tInOne.Text;
            groupConfig.InZero = tInZero.Text;

            //基数
            groupConfig.InTwozt = tInTwozt.Text;
            groupConfig.InOnezt = tInOnezt.Text;
            groupConfig.InZerozt = tInZerozt.Text;

            //基数
            groupConfig.InTwobz = tInTwobz.Text;
            groupConfig.InOnebz = tInOnebz.Text;
            groupConfig.InZerobz = tInZerobz.Text;

            //积分
            groupConfig.IntegralTwo = tIntegralTwo.Text;
            groupConfig.IntegralOne = tIntegralOne.Text;
            groupConfig.IntegralZero = tIntegralZero.Text;
            groupConfig.IntegralGroup = tIntegralGroup.Text;
            //金币
            groupConfig.CoinTwo = tCoinTwo.Text;
            groupConfig.CoinOne = tCoinOne.Text;
            groupConfig.CoinZero = tCoinZero.Text;
            groupConfig.CoinGroup = tCoinGroup.Text;
            //上下限
            groupConfig.InTwoUpperlimit = tInTwoUpperlimit.Text;
            groupConfig.InTwoLowerlimit = tInTwoLowerlimit.Text;

            groupConfig.InOneUpperlimit = tInOneUpperlimit.Text;
            groupConfig.InOneLowerlimit = tInOneLowerlimit.Text;

            groupConfig.InZeroUpperlimit = tInZeroUpperlimit.Text;
            groupConfig.InZeroLowerlimit = tInZeroLowerlimit.Text;

            WebInit.groupNumconfig = groupConfig;
            BindPageConfig();
        }


    }
}