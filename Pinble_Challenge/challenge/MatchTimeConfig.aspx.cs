using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pbzx.Common;
using System.Data;

namespace Pinble_Challenge.challenge
{
    public partial class MatchTimeConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Pbzx.BLL.PBnet_tpman get_tn = new Pbzx.BLL.PBnet_tpman();
//                string name = Request.QueryString["name"];
                string UserName = Pbzx.Common.Input.URLDecode(Request["name"].ToString());
                UserName = Pbzx.Common.Input.FilterAll(UserName);
                if (string.IsNullOrEmpty(UserName) == true)
                {
                    Pbzx.BLL.PBnet_tpman.IsLoginSoftware();
                }
                else
                {
                    DataSet ds_user = get_tn.GetList("Master_Name=" + "'" + UserName.ToString() + "'");
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

            //擂台积分
            lottIntegral lottInt = WebInit.lottintconfig;
            txt_h3HitOne.Text = lottInt.h3HitOne;
            txt_h3HitTwo.Text = lottInt.h3HitTwo;
            txt_h3HitThree.Text = lottInt.h3HitThree;

            txt_h6HitOne.Text = lottInt.h6HitOne;
            txt_h6HitTwo.Text = lottInt.h6HitTwo;
            txt_h6HitThree.Text = lottInt.h6HitThree;
            txt_h6HitFour.Text = lottInt.h6HitFour;
            txt_h6HitFive.Text = lottInt.h6HitFive;
            txt_h6HitSix.Text = lottInt.h6HitSix;

            txt_s3hHit.Text = lottInt.s3hHit;
            txt_s6hHit.Text = lottInt.s6hHit;

            txt_lHit.Text = lottInt.lHit;
            txt_l3Hit.Text = lottInt.l3Hit;

            txt_s3lHit.Text = lottInt.s3lHit;
            txt_s6lHit.Text = lottInt.s6lHit;

            txt_h3l61Hit.Text = lottInt.h3l61Hit;
            txt_h3l60Hit.Text = lottInt.h3l60Hit;
            txt_h3l51Hit.Text = lottInt.h3l51Hit;
            txt_h3l50Hit.Text = lottInt.h3l50Hit;
            txt_h3l41Hit.Text = lottInt.h3l41Hit;
            txt_h3l40Hit.Text = lottInt.h3l40Hit;
            txt_h3l31Hit.Text = lottInt.h3l31Hit;
            txt_h3l30Hit.Text = lottInt.h3l30Hit;
            txt_h3l21Hit.Text = lottInt.h3l21Hit;
            txt_h3l20Hit.Text = lottInt.h3l20Hit;
            txt_h3l11Hit.Text = lottInt.h3l11Hit;
            txt_h3l01Hit.Text = lottInt.h3l01Hit;

            txt_h2l61Hit.Text = lottInt.h2l61Hit;
            txt_h2l60Hit.Text = lottInt.h2l60Hit;
            txt_h2l51Hit.Text = lottInt.h2l51Hit;
            txt_h2l50Hit.Text = lottInt.h2l50Hit;
            txt_h2l41Hit.Text = lottInt.h2l41Hit;
            txt_h2l40Hit.Text = lottInt.h2l40Hit;
            txt_h2l31Hit.Text = lottInt.h2l31Hit;
            txt_h2l30Hit.Text = lottInt.h2l30Hit;
            txt_h2l21Hit.Text = lottInt.h2l21Hit;
            txt_h2l20Hit.Text = lottInt.h2l20Hit;
            txt_h2l11Hit.Text = lottInt.h2l11Hit;
            txt_h2l01Hit.Text = lottInt.h2l01Hit;

            txt_ddHit.Text = lottInt.ddHit;

            txt_sdHitOne.Text = lottInt.sdHitOne;
            txt_sdHitTwo.Text = lottInt.sdHitTwo;

            txt_GroupHit.Text = lottInt.GroupHit;
            txt_dirHit.Text = lottInt.dirHit;

            txt_sMHitOne.Text = lottInt.sMHitOne;
            txt_sMHitTwo.Text = lottInt.sMHitTwo;

            txt_dKHit.Text = lottInt.dKHit;

            txt_dhHit.Text = lottInt.dhHit;

            txt_shHit.Text = lottInt.shHit;

            txt_m5Hit.Text = lottInt.m5Hit;

            txt_dw5Hit.Text = lottInt.dw5Hit;
            txt_dw3Hit.Text = lottInt.dw3Hit;
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
        /// 开奖截止时间
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
        /// 擂台积分设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string errMsg = "";
            lottIntegral lottin = new lottIntegral();
            if (!IsNumeric(txt_h3HitOne.Text))
            {
                errMsg += "红球3胆中1请输入数字！";

            }
            if (!IsNumeric(txt_h3HitTwo.Text))
            {
                errMsg += "红球3胆中2请输入数字！";

            }
            if (!IsNumeric(txt_h3HitThree.Text))
            {
                errMsg += "红球3胆中3请输入数字！";

            }
            if (!IsNumeric(txt_h6HitOne.Text))
            {
                errMsg += "红球6胆中1请输入数字！";

            }
            if (!IsNumeric(txt_h6HitTwo.Text))
            {
                errMsg += "红球6胆中2请输入数字！";

            }
            if (!IsNumeric(txt_h6HitThree.Text))
            {
                errMsg += "红球6胆中3请输入数字！";

            }
            if (!IsNumeric(txt_h6HitFour.Text))
            {
                errMsg += "红球6胆中4请输入数字！";

            }
            if (!IsNumeric(txt_h6HitFive.Text))
            {
                errMsg += "红球6胆中5请输入数字！";

            }
            if (!IsNumeric(txt_h6HitSix.Text))
            {
                errMsg += "红球6胆中6请输入数字！";

            }

            if (!IsNumeric(txt_s3hHit.Text))
            {
                errMsg += "杀3红球请输入数字！";

            }
            if (!IsNumeric(txt_s6hHit.Text))
            {
                errMsg += "杀6红球请输入数字！";

            }
            if (!IsNumeric(txt_lHit.Text))
            {
                errMsg += "蓝球1胆请输入数字！";

            }
            if (!IsNumeric(txt_l3Hit.Text))
            {
                errMsg += "蓝球3胆请输入数字！";

            }
            if (!IsNumeric(txt_s3lHit.Text))
            {
                errMsg += "杀3蓝球请输入数字！";

            }
            if (!IsNumeric(txt_s6lHit.Text))
            {
                errMsg += "杀6蓝球请输入数字！";

            }
            if (!IsNumeric(txt_h3l61Hit.Text))
            {
                errMsg += "12红+3蓝中6红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h3l60Hit.Text))
            {
                errMsg += "12红+3蓝中6红请输入数字！";

            }
            if (!IsNumeric(txt_h3l51Hit.Text))
            {
                errMsg += "12红+3蓝中5红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h3l50Hit.Text))
            {
                errMsg += "12红+3蓝中5红请输入数字！";

            }
            if (!IsNumeric(txt_h3l41Hit.Text))
            {
                errMsg += "12红+3蓝中4红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h3l40Hit.Text))
            {
                errMsg += "12红+3蓝中4红请输入数字！";

            }
            if (!IsNumeric(txt_h3l31Hit.Text))
            {
                errMsg += "12红+3蓝中3红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h3l30Hit.Text))
            {
                errMsg += "12红+3蓝中3红请输入数字！";

            }
            if (!IsNumeric(txt_h3l21Hit.Text))
            {
                errMsg += "12红+3蓝中2红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h3l20Hit.Text))
            {
                errMsg += "12红+3蓝中2红请输入数字！";

            }
            if (!IsNumeric(txt_h3l11Hit.Text))
            {
                errMsg += "12红+3蓝中1红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h3l01Hit.Text))
            {
                errMsg += "12红+3蓝1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h2l61Hit.Text))
            {
                errMsg += "9红+2蓝中6红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h2l60Hit.Text))
            {
                errMsg += "9红+2蓝中6红请输入数字！";

            }
            if (!IsNumeric(txt_h2l51Hit.Text))
            {
                errMsg += "9红+2蓝中5红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h2l50Hit.Text))
            {
                errMsg += "9红+2蓝中5红请输入数字！";

            }
            if (!IsNumeric(txt_h2l41Hit.Text))
            {
                errMsg += "9红+2蓝中4红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h2l40Hit.Text))
            {
                errMsg += "9红+2蓝中4红请输入数字！";

            }
            if (!IsNumeric(txt_h2l31Hit.Text))
            {
                errMsg += "9红+2蓝中3红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h2l30Hit.Text))
            {
                errMsg += "9红+2蓝中3红请输入数字！";

            }
            if (!IsNumeric(txt_h2l21Hit.Text))
            {
                errMsg += "9红+2蓝中2红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h2l20Hit.Text))
            {
                errMsg += "9红+2蓝中2红请输入数字！";

            }
            if (!IsNumeric(txt_h2l11Hit.Text))
            {
                errMsg += "9红+2蓝中1红1蓝请输入数字！";

            }
            if (!IsNumeric(txt_h2l01Hit.Text))
            {
                errMsg += "9红+2蓝中1蓝请输入数字！";

            }

            if (!IsNumeric(txt_ddHit.Text))
            {
                errMsg += "独胆请输入数字！";

            }
            if (!IsNumeric(txt_sdHitOne.Text))
            {
                errMsg += "双胆中1请输入数字！";

            }
            if (!IsNumeric(txt_sdHitTwo.Text))
            {
                errMsg += "双胆中2请输入数字！";

            }
            if (!IsNumeric(txt_GroupHit.Text))
            {
                errMsg += "组选1注请输入数字！";

            }
            if (!IsNumeric(txt_dirHit.Text))
            {
                errMsg += "单选1注请输入数字！";

            }

            if (!IsNumeric(txt_sMHitOne.Text))
            {
                errMsg += "杀1码请输入数字！";

            }
            if (!IsNumeric(txt_sMHitTwo.Text))
            {
                errMsg += "杀2码请输入数字！";

            }
            if (!IsNumeric(txt_dKHit.Text))
            {
                errMsg += "独跨请输入数字！";

            }
            if (!IsNumeric(txt_dhHit.Text))
            {
                errMsg += "独合请输入数字！";

            }
            if (!IsNumeric(txt_shHit.Text))
            {
                errMsg += "杀1合请输入数字！";

            }
            if (!IsNumeric(txt_m5Hit.Text))
            {
                errMsg += "5码请输入数字！";

            }
            if (!IsNumeric(txt_dw5Hit.Text))
            {
                errMsg += "5*5*5定位请输入数字！";

            }
            if (!IsNumeric(txt_dw3Hit.Text))
            {
                errMsg += "3*3*3定位请输入数字！";

            }
            if (errMsg.Length > 0)
            {
                Page.RegisterStartupScript("错误", JS.Alert("您提交的信息有以下错误，请修改后提交！\\r\\n" + errMsg));
                return;
            }
            //擂台积分
            lottin.h3HitOne = txt_h3HitOne.Text;
            lottin.h3HitTwo = txt_h3HitTwo.Text;
            lottin.h3HitThree = txt_h3HitThree.Text;

            lottin.h6HitOne = txt_h6HitOne.Text;
            lottin.h6HitTwo = txt_h6HitTwo.Text;
            lottin.h6HitThree = txt_h6HitThree.Text;
            lottin.h6HitFour = txt_h6HitFour.Text;
            lottin.h6HitFive= txt_h6HitFive.Text;
            lottin.h6HitSix=txt_h6HitSix.Text ;

            lottin.s3hHit = txt_s3hHit.Text;
            lottin.s6hHit = txt_s6hHit.Text;

            lottin.lHit = txt_lHit.Text;
            lottin.l3Hit = txt_l3Hit.Text;

            lottin.s3lHit = txt_s3lHit.Text;
            lottin.s6lHit = txt_s6lHit.Text;

            lottin.h3l61Hit = txt_h3l61Hit.Text;
            lottin.h3l60Hit = txt_h3l60Hit.Text;
            lottin.h3l51Hit = txt_h3l51Hit.Text;
            lottin.h3l50Hit = txt_h3l50Hit.Text;
            lottin.h3l41Hit = txt_h3l41Hit.Text;
            lottin.h3l40Hit = txt_h3l40Hit.Text;
            lottin.h3l31Hit = txt_h3l31Hit.Text;
            lottin.h3l30Hit = txt_h3l30Hit.Text;
            lottin.h3l21Hit = txt_h3l21Hit.Text;
            lottin.h3l20Hit = txt_h3l20Hit.Text;
            lottin.h3l11Hit = txt_h3l11Hit.Text;
            lottin.h3l01Hit = txt_h3l01Hit.Text;

            lottin.h2l61Hit = txt_h2l61Hit.Text;
            lottin.h2l60Hit = txt_h2l60Hit.Text;
            lottin.h2l51Hit = txt_h2l51Hit.Text;
            lottin.h2l50Hit = txt_h2l50Hit.Text;
            lottin.h2l41Hit = txt_h2l41Hit.Text;
            lottin.h2l40Hit = txt_h2l40Hit.Text;
            lottin.h2l31Hit = txt_h2l31Hit.Text;
            lottin.h2l30Hit = txt_h2l30Hit.Text;
            lottin.h2l21Hit = txt_h2l21Hit.Text;
            lottin.h2l20Hit = txt_h2l20Hit.Text;
            lottin.h2l11Hit = txt_h2l11Hit.Text;
            lottin.h2l01Hit = txt_h2l01Hit.Text;

            lottin.ddHit= txt_ddHit.Text ;

             lottin.sdHitOne=txt_sdHitOne.Text;
            lottin.sdHitTwo = txt_sdHitTwo.Text;

            lottin.GroupHit = txt_GroupHit.Text;
            lottin.dirHit = txt_dirHit.Text;

            lottin.sMHitOne = txt_sMHitOne.Text;
            lottin.sMHitTwo = txt_sMHitTwo.Text;

            lottin.dKHit = txt_dKHit.Text;

            lottin.dhHit = txt_dhHit.Text;

            lottin.shHit = txt_shHit.Text;

            lottin.m5Hit = txt_m5Hit.Text;

            lottin.dw5Hit = txt_dw5Hit.Text;
            lottin.dw3Hit = txt_dw3Hit.Text;
            WebInit.lottintconfig = lottin;
            BindPageConfig();
        }

        //验证字符串是否是纯数字
        private static bool IsNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg1 = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg1.IsMatch(str);
        }
    }
}