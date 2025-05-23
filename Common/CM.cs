using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Pbzx.Common
{
    public class CM
    {
        public CM()
        {
            try
            {
                Pbzx.Common.ErrorLog.WriteLogMeng("监控程序", "注册动态库初始化监控！！", true, true);
            }
            catch
            {

            }

        }
        /// <summary>
        /// 单机注册注册码
        /// </summary>
        /// <param name="lpszOrderID">订单ID</param>
        /// <param name="nCstID">软件ID</param>
        /// <param name="nTimeType">包月类型(4:一年，7：终身)</param>
        /// <param name="lpszPayType">付款类型(支付宝等)</param>
        /// <param name="nMoney">付款金额(浮点数)</param>
        /// <param name="lpszHDSN">认证码16位</param>
        /// <param name="lpszName">客户姓名(不为空)</param>
        /// <param name="lpszTel">电话</param>
        /// <param name="lpszEMail">Email</param>
        /// <param name="lpszAddr">地址（不能为空）</param>
        /// <param name="lpszBBsName">论坛用户名</param>
        /// <param name="nAgentID">如果是公司注册，则为0，如果经纪人注册，则为1，如果是代理注册，则为代理ID</param>
        /// <param name="lpszAgentName">代理名称，如果是公司注册，则为“公司注册”，如果经纪人注册，则为经纪人姓名，如果是代理注册，则为代理姓名</param>
        /// <param name="nRegisterMode">注册模式（0：常规，1：手工，10：自动）</param>
        /// <param name="lpszOut">返回的注册码，返回值（0:正确lpszout包含注册码，否则错误信息）</param>
        /// <returns>返回值（0:正确lpszout包含注册码，否则错误信息）</returns>
        [DllImport("WebSoftReg.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int DllSoftRegister_HDSN(char[] lpszOrderID, int nCstID, int nTimeType, char[] lpszPayType, float nMoney, char[] lpszHDSN, char[] lpszName, char[] lpszTel, char[] lpszEMail, char[] lpszAddr, char[] lpszBBsName, int nAgentID, char[] lpszAgentName, int nRegisterMode, StringBuilder lpszOut);

        /// <summary>
        /// 软件狗注册码
        /// </summary>
        /// <param name="lpszOrderID">订单ID</param>
        /// <param name="nCstID">软件ID</param>
        /// <param name="nTimeType">包月类型(4:一年，7：终身)</param>
        /// <param name="lpszPayType">付款类型(支付宝等)</param>
        /// <param name="nMoney">付款金额(浮点数)</param>
        /// <param name="lpszHDSN">认证码16位</param>
        /// <param name="lpszName">客户姓名(不为空)</param>
        /// <param name="lpszTel">电话</param>
        /// <param name="lpszEMail">Email</param>
        /// <param name="lpszAddr">地址（不能为空）</param>
        /// <param name="lpszBBsName">论坛用户名</param>
        /// <param name="nAgentID">如果是公司注册，则为0，如果经纪人注册，则为1，如果是代理注册，则为代理ID</param>
        /// <param name="lpszAgentName">代理名称，如果是公司注册，则为“公司注册”，如果经纪人注册，则为经纪人姓名，如果是代理注册，则为代理姓名</param>
        /// <param name="nRegisterMode">注册模式（0：常规，1：手工，10：自动）</param>
        /// <param name="lpszOut">返回的注册码，返回值（0:正确lpszout包含注册码，否则错误信息）</param>
        /// <returns>返回值（0:正确lpszout包含注册码，否则错误信息）</returns>
        [DllImport("WebSoftReg.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int DllSoftRegister_SoftDog(char[] lpszOrderID, int nCstID, int nTimeType, char[] lpszPayType, float nMoney, char[] lpszHDSN, char[] lpszName, char[] lpszTel, char[] lpszEMail, char[] lpszAddr, char[] lpszBBsName, int nAgentID, char[] lpszAgentName, int nRegisterMode, StringBuilder lpszOut);

        /// <summary>
        /// 网络注册
        /// </summary>
        /// <param name="lpszOrderID">订单ID</param>
        /// <param name="nCstID">软件ID</param>
        /// <param name="nUseType">使用类型（1：包月，此时nUseValue为月数，3为3月，6为半年，12为一年； 2：计天，此时nUseValue为天数，50为50天；10：临时使用）</param>
        /// <param name="nUseValue"></param>
        /// <param name="lpszPayType">付款类型(支付宝等)（自动）</param>
        /// <param name="nMoney">付款金额(浮点数)</param>
        /// <param name="lpszName">用户名</param>
        /// <param name="lpszTel">电话</param>
        /// <param name="lpszEMail">Email</param>
        /// <param name="lpszAddr">地址（不能为空）</param>
        /// <param name="lpszBBsName">论坛用户名</param>
        /// <param name="nAgentID">如果是公司注册，则为0，如果经纪人注册，则为1，如果是代理注册，则为代理ID</param>
        /// <param name="lpszAgentName">代理名称，如果是公司注册，则为“公司注册”，如果经纪人注册，则为经纪人姓名，如果是代理注册，则为代理姓名</param>
        /// <param name="nRegisterMode">注册模式（0：常规，1：手工，10：自动）</param>
        /// <param name="lpszOut">返回值（0:正确lpszout包含注册后信息，否则错误信息）</param>
        /// <returns>返回值（0:正确lpszout包含注册后信息，否则错误信息）</returns>
        [DllImport("WebSoftReg.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int DllSoftRegister_Net(char[] lpszOrderID, int nCstID, int nUseType, int nUseValue, char[] lpszPayType, float nMoney, char[] lpszName, char[] lpszTel, char[] lpszEMail, char[] lpszAddr, char[] lpszBBsName, int nAgentID, char[] lpszAgentName, int nRegisterMode, StringBuilder lpszOut);
        //public static void Main()
        //{
        //    Console.WriteLine("MyMethod() returns {0}.", MyMethod(5));
        //}
    }
}
