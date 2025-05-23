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
                Pbzx.Common.ErrorLog.WriteLogMeng("��س���", "ע�ᶯ̬���ʼ����أ���", true, true);
            }
            catch
            {

            }

        }
        /// <summary>
        /// ����ע��ע����
        /// </summary>
        /// <param name="lpszOrderID">����ID</param>
        /// <param name="nCstID">���ID</param>
        /// <param name="nTimeType">��������(4:һ�꣬7������)</param>
        /// <param name="lpszPayType">��������(֧������)</param>
        /// <param name="nMoney">������(������)</param>
        /// <param name="lpszHDSN">��֤��16λ</param>
        /// <param name="lpszName">�ͻ�����(��Ϊ��)</param>
        /// <param name="lpszTel">�绰</param>
        /// <param name="lpszEMail">Email</param>
        /// <param name="lpszAddr">��ַ������Ϊ�գ�</param>
        /// <param name="lpszBBsName">��̳�û���</param>
        /// <param name="nAgentID">����ǹ�˾ע�ᣬ��Ϊ0�����������ע�ᣬ��Ϊ1������Ǵ���ע�ᣬ��Ϊ����ID</param>
        /// <param name="lpszAgentName">�������ƣ�����ǹ�˾ע�ᣬ��Ϊ����˾ע�ᡱ�����������ע�ᣬ��Ϊ����������������Ǵ���ע�ᣬ��Ϊ��������</param>
        /// <param name="nRegisterMode">ע��ģʽ��0�����棬1���ֹ���10���Զ���</param>
        /// <param name="lpszOut">���ص�ע���룬����ֵ��0:��ȷlpszout����ע���룬���������Ϣ��</param>
        /// <returns>����ֵ��0:��ȷlpszout����ע���룬���������Ϣ��</returns>
        [DllImport("WebSoftReg.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int DllSoftRegister_HDSN(char[] lpszOrderID, int nCstID, int nTimeType, char[] lpszPayType, float nMoney, char[] lpszHDSN, char[] lpszName, char[] lpszTel, char[] lpszEMail, char[] lpszAddr, char[] lpszBBsName, int nAgentID, char[] lpszAgentName, int nRegisterMode, StringBuilder lpszOut);

        /// <summary>
        /// �����ע����
        /// </summary>
        /// <param name="lpszOrderID">����ID</param>
        /// <param name="nCstID">���ID</param>
        /// <param name="nTimeType">��������(4:һ�꣬7������)</param>
        /// <param name="lpszPayType">��������(֧������)</param>
        /// <param name="nMoney">������(������)</param>
        /// <param name="lpszHDSN">��֤��16λ</param>
        /// <param name="lpszName">�ͻ�����(��Ϊ��)</param>
        /// <param name="lpszTel">�绰</param>
        /// <param name="lpszEMail">Email</param>
        /// <param name="lpszAddr">��ַ������Ϊ�գ�</param>
        /// <param name="lpszBBsName">��̳�û���</param>
        /// <param name="nAgentID">����ǹ�˾ע�ᣬ��Ϊ0�����������ע�ᣬ��Ϊ1������Ǵ���ע�ᣬ��Ϊ����ID</param>
        /// <param name="lpszAgentName">�������ƣ�����ǹ�˾ע�ᣬ��Ϊ����˾ע�ᡱ�����������ע�ᣬ��Ϊ����������������Ǵ���ע�ᣬ��Ϊ��������</param>
        /// <param name="nRegisterMode">ע��ģʽ��0�����棬1���ֹ���10���Զ���</param>
        /// <param name="lpszOut">���ص�ע���룬����ֵ��0:��ȷlpszout����ע���룬���������Ϣ��</param>
        /// <returns>����ֵ��0:��ȷlpszout����ע���룬���������Ϣ��</returns>
        [DllImport("WebSoftReg.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int DllSoftRegister_SoftDog(char[] lpszOrderID, int nCstID, int nTimeType, char[] lpszPayType, float nMoney, char[] lpszHDSN, char[] lpszName, char[] lpszTel, char[] lpszEMail, char[] lpszAddr, char[] lpszBBsName, int nAgentID, char[] lpszAgentName, int nRegisterMode, StringBuilder lpszOut);

        /// <summary>
        /// ����ע��
        /// </summary>
        /// <param name="lpszOrderID">����ID</param>
        /// <param name="nCstID">���ID</param>
        /// <param name="nUseType">ʹ�����ͣ�1�����£���ʱnUseValueΪ������3Ϊ3�£�6Ϊ���꣬12Ϊһ�ꣻ 2�����죬��ʱnUseValueΪ������50Ϊ50�죻10����ʱʹ�ã�</param>
        /// <param name="nUseValue"></param>
        /// <param name="lpszPayType">��������(֧������)���Զ���</param>
        /// <param name="nMoney">������(������)</param>
        /// <param name="lpszName">�û���</param>
        /// <param name="lpszTel">�绰</param>
        /// <param name="lpszEMail">Email</param>
        /// <param name="lpszAddr">��ַ������Ϊ�գ�</param>
        /// <param name="lpszBBsName">��̳�û���</param>
        /// <param name="nAgentID">����ǹ�˾ע�ᣬ��Ϊ0�����������ע�ᣬ��Ϊ1������Ǵ���ע�ᣬ��Ϊ����ID</param>
        /// <param name="lpszAgentName">�������ƣ�����ǹ�˾ע�ᣬ��Ϊ����˾ע�ᡱ�����������ע�ᣬ��Ϊ����������������Ǵ���ע�ᣬ��Ϊ��������</param>
        /// <param name="nRegisterMode">ע��ģʽ��0�����棬1���ֹ���10���Զ���</param>
        /// <param name="lpszOut">����ֵ��0:��ȷlpszout����ע�����Ϣ�����������Ϣ��</param>
        /// <returns>����ֵ��0:��ȷlpszout����ע�����Ϣ�����������Ϣ��</returns>
        [DllImport("WebSoftReg.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern int DllSoftRegister_Net(char[] lpszOrderID, int nCstID, int nUseType, int nUseValue, char[] lpszPayType, float nMoney, char[] lpszName, char[] lpszTel, char[] lpszEMail, char[] lpszAddr, char[] lpszBBsName, int nAgentID, char[] lpszAgentName, int nRegisterMode, StringBuilder lpszOut);
        //public static void Main()
        //{
        //    Console.WriteLine("MyMethod() returns {0}.", MyMethod(5));
        //}
    }
}
