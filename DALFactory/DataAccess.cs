using System;
using System.Reflection;
using System.Configuration;
namespace Pbzx.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL��
    /// ��������ﴴ�����󱨴�����web.config���Ƿ��޸���<add key="DAL" value="Maticsoft.SQLServerDAL" />��
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject

        //��ʹ�û���
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// ��¼������־
                return null;
            }

        }
        //ʹ�û���
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// д�뻺��
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// ��¼������־
                }
            }
            return objType;
        }
        #endregion

        #region CreateSysManage
        public static Pbzx.IDAL.ISysManage CreateSysManage()
        {
            //��ʽ1			
            //return (Pbzx.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

            //��ʽ2 			
            string classNamespace = AssemblyPath + ".SysManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (Pbzx.IDAL.ISysManage)objType;
        }
        #endregion




        /// <summary>
        /// ����PBnet_QQ���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_QQ CreatePBnet_QQ()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_QQ";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_QQ)objType;
        }

        /// <summary>
        /// ����PBnet_ask_Attach���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_Attach CreatePBnet_ask_Attach()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_Attach";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_Attach)objType;
        }


        /// <summary>
        /// ����PBnet_LyBook���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_LyBook CreatePBnet_LyBook()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_LyBook";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_LyBook)objType;
        }
        /// <summary>
        /// ����PBnet_LyResume���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_LyResume CreatePBnet_LyResume()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_LyResume";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_LyResume)objType;
        }
        /// <summary>
        /// ����PBnet_adminloginlog���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_adminloginlog CreatePBnet_adminloginlog()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_adminloginlog";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_adminloginlog)objType;
        }


        /// <summary>
        /// ����PBnet_ADRecord���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ADRecord CreatePBnet_ADRecord()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ADRecord";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ADRecord)objType;
        }
        /// <summary>
        /// ����PBnet_PulbicContent���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_PulbicContent CreatePBnet_PulbicContent()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_PulbicContent";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_PulbicContent)objType;
        }

        /// <summary>
        /// ����PBnet_broker_Config���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_broker_Config CreatePBnet_broker_Config()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_broker_Config";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_broker_Config)objType;
        }


        /// <summary>
        /// ����PBnet_broker_content���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_broker_content CreatePBnet_broker_content()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_broker_content";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_broker_content)objType;
        }
        /// <summary>
        /// ����PBnet_AdvPlace���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Adv CreatePBnet_Adv()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Adv";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Adv)objType;
        }

        /// <summary>
        /// ����PBnet_AdvPlace���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_AdvPlace CreatePBnet_AdvPlace()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_AdvPlace";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_AdvPlace)objType;
        }

        /// <summary>
        /// ����PBnet_arltype���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_arltype CreatePBnet_arltype()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_arltype";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_arltype)objType;
        }



        /// <summary>
        /// ����CN_Black���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_Black CreateCN_Black()
        {

            string ClassNamespace = AssemblyPath + ".CN_Black";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_Black)objType;
        }


        /// <summary>
        /// ����SoftDogInfo���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ISoftDogInfo CreateSoftDogInfo()
        {

            string ClassNamespace = AssemblyPath + ".SoftDogInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ISoftDogInfo)objType;
        }


        /// <summary>
        /// ����CL_PrintLine���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICL_PrintLine CreateCL_PrintLine()
        {

            string ClassNamespace = AssemblyPath + ".CL_PrintLine";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICL_PrintLine)objType;
        }






        /// <summary>
        /// ����PBnet_bocai���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_bocai CreatePBnet_bocai()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_bocai";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_bocai)objType;
        }


        /// <summary>
        /// ����PBnet_boclb���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_boclb CreatePBnet_boclb()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_boclb";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_boclb)objType;
        }


        /// <summary>
        /// ����PBnet_Bulletin���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Bulletin CreatePBnet_Bulletin()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Bulletin";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Bulletin)objType;
        }


        /// <summary>
        /// ����PBnet_FreeReg���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_FreeReg CreatePBnet_FreeReg()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_FreeReg";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_FreeReg)objType;
        }



        /// <summary>
        /// ����PBnet_ipdata���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ipdata CreatePBnet_ipdata()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ipdata";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ipdata)objType;
        }


        /// <summary>
        /// ����PBnet_jjqi���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_jjqi CreatePBnet_jjqi()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_jjqi";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_jjqi)objType;
        }



        /// <summary>
        /// ����PBnet_UserTradeInfo���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_UserTradeInfo CreatePBnet_UserTradeInfo()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_UserTradeInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_UserTradeInfo)objType;
        }

        /// <summary>
        /// ����PBnet_Links���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Links CreatePBnet_Links()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Links";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Links)objType;
        }


        /// <summary>
        /// ����PBnet_LotteryMenu���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_LotteryMenu CreatePBnet_LotteryMenu()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_LotteryMenu";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_LotteryMenu)objType;
        }


        /// <summary>
        /// ����PBnet_News���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_News CreatePBnet_News()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_News";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_News)objType;
        }

        /// <summary>
        /// ����PBnet_Nslide���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Nslide CreatePBnet_Nslide()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Nslide";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Nslide)objType;
        }

        /// <summary>
        /// ����PBnet_pb_3d2005ord���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_pb_3d2005ord CreatePBnet_pb_3d2005ord()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_pb_3d2005ord";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_pb_3d2005ord)objType;
        }


        /// <summary>
        /// ����PBnet_pdttComment���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_pdttComment CreatePBnet_pdttComment()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_pdttComment";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_pdttComment)objType;
        }


        /// <summary>
        /// ����PBnet_Product���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Product CreatePBnet_Product()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Product";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Product)objType;
        }


        /// <summary>
        /// ����PBnet_qjqi���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_qjqi CreatePBnet_qjqi()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_qjqi";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_qjqi)objType;
        }


        /// <summary>
        /// ����PBnet_sms���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_sms CreatePBnet_sms()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_sms";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_sms)objType;
        }


        /// <summary>
        /// ����PBnet_smsback���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_smsback CreatePBnet_smsback()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_smsback";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_smsback)objType;
        }


        /// <summary>
        /// ����PBnet_smsfs���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_smsfs CreatePBnet_smsfs()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_smsfs";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_smsfs)objType;
        }


        /// <summary>
        /// ����PBnet_Soft���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Soft CreatePBnet_Soft()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Soft";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Soft)objType;
        }


        /// <summary>
        /// ����PBnet_SoftClass���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_SoftClass CreatePBnet_SoftClass()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_SoftClass";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_SoftClass)objType;
        }


        /// <summary>
        /// ����PBnet_SoftComment���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_SoftComment CreatePBnet_SoftComment()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_SoftComment";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_SoftComment)objType;
        }


        /// <summary>
        /// ����PBnet_tpman���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_tpman CreatePBnet_tpman()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_tpman";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_tpman)objType;
        }


        /// <summary>
        /// ����PBnet_UserTable���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_UserTable CreatePBnet_UserTable()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_UserTable";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_UserTable)objType;
        }


        /// <summary>
        /// ����PBnet_vipman���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_vipman CreatePBnet_vipman()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_vipman";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_vipman)objType;
        }

        /// <summary>
        /// ����PBnet_Module���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Module CreatePBnet_Module()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Module";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Module)objType;
        }

        /// <summary>
        /// ����PBnet_BulletinType���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_BulletinType CreatePBnet_BulletinType()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_BulletinType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_BulletinType)objType;
        }
        /// <summary>
        /// ����AgentInfo���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IAgentInfo CreateAgentInfo()
        {

            string ClassNamespace = AssemblyPath + ".AgentInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IAgentInfo)objType;
        }
        /// <summary>
        /// ����AgentInfo_Apply���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IAgentInfo_Apply CreateAgentInfo_Apply()
        {

            string ClassNamespace = AssemblyPath + ".AgentInfo_Apply";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IAgentInfo_Apply)objType;
        }
        /// <summary>
        /// ����AgentAgree���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IAgentAgree CreateAgentAgree()
        {

            string ClassNamespace = AssemblyPath + ".AgentAgree";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IAgentAgree)objType;
        }
        /// <summary>
        /// ����CN_UserDetails���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_UserDetails CreateCN_UserDetails()
        {

            string ClassNamespace = AssemblyPath + ".CN_UserDetails";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_UserDetails)objType;
        }


        /// <summary>
        /// ����PBnet_NewsType���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_NewsType CreatePBnet_NewsType()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_NewsType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_NewsType)objType;
        }

        /// <summary>
        /// ����CN_Online���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_Online CreateCN_Online()
        {

            string ClassNamespace = AssemblyPath + ".CN_Online";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_Online)objType;
        }

        /// <summary>
        /// ����CN_MaxOnline���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_MaxOnline CreateCN_MaxOnline()
        {

            string ClassNamespace = AssemblyPath + ".CN_MaxOnline";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_MaxOnline)objType;
        }
        /// <summary>
        /// ����CN_Log���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_Log CreateCN_Log()
        {

            string ClassNamespace = AssemblyPath + ".CN_Log";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_Log)objType;
        }
        /// <summary>
        /// ����CN_Config���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_Config CreateCN_Config()
        {

            string ClassNamespace = AssemblyPath + ".CN_Config";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_Config)objType;
        }
        /// <summary>
        /// ����CN_User���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_User CreateCN_User()
        {

            string ClassNamespace = AssemblyPath + ".CN_User";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_User)objType;
        }
        /// <summary>
        /// ����CN_FreeTestUser���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_FreeTestUser CreateCN_FreeTestUser()
        {

            string ClassNamespace = AssemblyPath + ".CN_FreeTestUser";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_FreeTestUser)objType;
        }


        /// <summary>
        /// ����CN_Software���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_Software CreateCN_Software()
        {

            string ClassNamespace = AssemblyPath + ".CN_Software";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_Software)objType;
        }



        /// <summary>
        /// ����CN_StatLog���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_StatLog CreateCN_StatLog()
        {

            string ClassNamespace = AssemblyPath + ".CN_StatLog";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_StatLog)objType;
        }


        /// <summary>
        /// ����PBnet_ProductPrice���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ProductPrice CreatePBnet_ProductPrice()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ProductPrice";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ProductPrice)objType;
        }

        /// <summary>
        /// ����CstLogin���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICstLogin CreateCstLogin()
        {

            string ClassNamespace = AssemblyPath + ".CstLogin";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICstLogin)objType;
        }

        /// <summary>
        /// ����CstMessage���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICstMessage CreateCstMessage()
        {

            string ClassNamespace = AssemblyPath + ".CstMessage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICstMessage)objType;
        }

        /// <summary>
        /// ����CM_Main���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICM_Main CreateCM_Main()
        {

            string ClassNamespace = AssemblyPath + ".CM_MainService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICM_Main)objType;
        }
        /// <summary>
        /// ����CM_MainBySoftwareType���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICM_MainBySoftwareType CreateCM_MainBySoftwareType()
        {

            string ClassNamespace = AssemblyPath + ".CM_MainBySoftwareTypeService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICM_MainBySoftwareType)objType;
        }

        /// <summary>
        /// ����CstSoftware���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICstSoftware CreateCstSoftware()
        {

            string ClassNamespace = AssemblyPath + ".CstSoftware";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICstSoftware)objType;
        }

        /// <summary>
        /// ����RegisterInfo2���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IRegisterInfo2 CreateRegisterInfo2()
        {

            string ClassNamespace = AssemblyPath + ".RegisterInfo2";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IRegisterInfo2)objType;
        }
        /// <summary>
        /// ����CN_RegisterLog���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_RegisterLog CreateCN_RegisterLog()
        {

            string ClassNamespace = AssemblyPath + ".CN_RegisterLog";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_RegisterLog)objType;
        }
        /// <summary>
        /// ����CL_RegisterInfo���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICL_RegisterInfo CreateCL_RegisterInfo()
        {
            string ClassNamespace = AssemblyPath + ".CL_RegisterInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICL_RegisterInfo)objType;
        }

        /// <summary>
        /// ����TC7XCData���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ITC7XCData CreateTC7XCData()
        {
            string ClassNamespace = AssemblyPath + ".TC7XCData_New";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITC7XCData)objType;
        }
        /// <summary>
        /// ����FCSSData���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IFCSSData CreateFCSSData()
        {
            string ClassNamespace = AssemblyPath + ".FCSSData";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSData)objType;
        }
        /// <summary>
        /// ����FC3DData���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IFC3DData CreateFC3DData()
        {

            string ClassNamespace = AssemblyPath + ".FC3DData";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFC3DData)objType;
        }
        /// <summary>
        /// ����FC7LC���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IFC7LC CreateFC7LC()
        {
            string ClassNamespace = AssemblyPath + ".FC7LC";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFC7LC)objType;
        }
        /// <summary>
        /// ����TCDLTData���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ITCDLTData CreateTCDLTData()
        {

            string ClassNamespace = AssemblyPath + ".TCDLTData";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITCDLTData)objType;
        }
        /// <summary>
        /// ����TCPL35Data���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ITCPL35Data CreateTCPL35Data()
        {

            string ClassNamespace = AssemblyPath + ".TCPL35Data";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITCPL35Data)objType;
        }
        /// <summary>
        /// ����TC22X5Data���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ITC22X5Data CreateTC22X5Data()
        {

            string ClassNamespace = AssemblyPath + ".TC22X5Data";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITC22X5Data)objType;
        }
        /// <summary>
        /// ����TC29X7Data���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ITC29X7Data CreateTC29X7Data()
        {

            string ClassNamespace = AssemblyPath + ".TC29X7Data";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITC29X7Data)objType;
        }
        /// <summary>
        /// ����TC29X7Data���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ITC31X7Data CreateTC31X7Data()
        {

            string ClassNamespace = AssemblyPath + ".TC31X7Data";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITC31X7Data)objType;
        }
        /// <summary>
        /// ����FCSSLData_SH���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IFCSSLData_SH CreateFCSSLData_SH()
        {

            string ClassNamespace = AssemblyPath + ".FCSSLData_SH";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSLData_SH)objType;
        }
        /// <summary>
        /// ����K3Date���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IK3Date CreateK3Date()
        {

            string ClassNamespace = AssemblyPath + ".K3Date";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IK3Date)objType;
        }
        /// <summary>
        /// ����FCSSCData_ChongQ���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IFCSSCData_ChongQ CreateFCSSCData_ChongQ()
        {

            string ClassNamespace = AssemblyPath + ".FCSSCData_ChongQ";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSCData_ChongQ)objType;
        }


        /// <summary>
        /// ����FCSSCData_JiangX���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IFCSSCData_JiangX CreateFCSSCData_JiangX()
        {

            string ClassNamespace = AssemblyPath + ".FCSSCData_JiangX";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSCData_JiangX)objType;
        }


        /// <summary>
        /// ����FCSSCData_XinJ���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IFCSSCData_XinJ CreateFCSSCData_XinJ()
        {

            string ClassNamespace = AssemblyPath + ".FCSSCData_XinJ";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSCData_XinJ)objType;
        }


        /// <summary>
        /// ����FCSSCData_FuJ���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IFCSSCData_FuJ CreateFCSSCData_FuJ()
        {

            string ClassNamespace = AssemblyPath + ".FCSSCData_FuJ";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSCData_FuJ)objType;
        }

        /// <summary>
        /// ����FCSSCData_FuJ���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IFCPL5Data_HeB CreateFCPL5Data_HeB()
        {

            string ClassNamespace = AssemblyPath + ".FCPL5Data_HeB";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCPL5Data_HeB)objType;
        }

        /// <summary>
        /// ����FCSSCData_FuJ���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IFC4DData_ShangH CreateFC4DData_ShangH()
        {

            string ClassNamespace = AssemblyPath + ".FC4DData_ShangH";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFC4DData_ShangH)objType;
        }
        /// <summary>
        /// ����PBnet_Label���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Label CreatePBnet_Label()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Label";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Label)objType;
        }
        /// <summary>
        /// ����PBnet_PaginAtion���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_PaginAtion CreatePBnet_PaginAtion()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_PaginAtion";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_PaginAtion)objType;
        }
        /// <summary>
        /// ����PBnet_UrlMaping���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_UrlMaping CreatePBnet_UrlMaping()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_UrlMaping";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_UrlMaping)objType;
        }
        /// <summary>
        /// ����PBnet_broker_TradeInfo���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_broker_TradeInfo CreatePBnet_broker_TradeInfo()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_broker_TradeInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_broker_TradeInfo)objType;
        }

        /// <summary>
        /// ����PBnet_broker���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_broker CreatePBnet_broker()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_broker";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_broker)objType;
        }

        /// <summary>
        /// ����PBnet_ask_User���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_User CreatePBnet_ask_User()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_User";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_User)objType;
        }

        /// <summary>
        /// ����PBnet_ask_GradeConfig���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_GradeConfig CreatePBnet_ask_GradeConfig()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_GradeConfig";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_GradeConfig)objType;
        }



        /// <summary>
        /// ����PBnet_ask_Question���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_Question CreatePBnet_ask_Question()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_Question";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_Question)objType;
        }


        /// <summary>
        /// ����PBnet_ask_Reply���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_Reply CreatePBnet_ask_Reply()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_Reply";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_Reply)objType;
        }


        /// <summary>
        /// ����PBnet_ask_Type���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_Type CreatePBnet_ask_Type()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_Type";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_Type)objType;
        }



        /// <summary>
        /// ����PBnet_UserProtectPwd���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_UserProtectPwd CreatePBnet_UserProtectPwd()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_UserProtectPwd";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_UserProtectPwd)objType;
        }

        /// <summary>
        /// ����PBnet_OrderTradeInfo���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_OrderTradeInfo CreatePBnet_OrderTradeInfo()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_OrderTradeInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_OrderTradeInfo)objType;
        }


        /// <summary>
        /// ����PBnet_Charge���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Charge CreatePBnet_Charge()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Charge";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Charge)objType;
        }

        /// <summary>
        /// ����PBnet_School���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_School CreatePBnet_School()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_School";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_School)objType;
        }

        /// <summary>
        /// ����PBnet_Channel���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Channel CreatePBnet_Channel()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Channel";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Channel)objType;
        }

        /// <summary>
        /// ����PBnet_SchoolType���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_SchoolType CreatePBnet_SchoolType()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_SchoolType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_SchoolType)objType;
        }

        /// <summary>
        /// ����PBnet_Orders_Delegates���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Orders_Delegates CreatePBnet_Orders_Delegates()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Orders_Delegates";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Orders_Delegates)objType;
        }

        /// <summary>
        /// ����PBnet_OrderDetail_Delegate���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_OrderDetail_Delegate CreatePBnet_OrderDetail_Delegate()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_OrderDetail_Delegate";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_OrderDetail_Delegate)objType;
        }


        /// <summary>
        /// ����PBnet_QQ_Group���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_QQ_Group CreatePBnet_QQ_Group()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_QQ_Group";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_QQ_Group)objType;
        }

        /// <summary>
        /// ����PBnet_QQ_Record���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_QQ_Record CreatePBnet_QQ_Record()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_QQ_Record";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_QQ_Record)objType;
        }
        /// <summary>
        /// ����PBnet_About���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_About CreatePBnet_About()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_About";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_About)objType;
        }

        /// <summary>
        /// ����PBnet_UserLog���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_UserLog CreatePBnet_UserLog()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_UserLog";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_UserLog)objType;
        }

        /// <summary>
        /// ����PBnet_LyType���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_LyType CreatePBnet_LyType()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_LyType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_LyType)objType;
        }
        /// <summary>
        /// ����IMarket_Type���ݲ�ӿ�
        /// ������:����ΰ
        /// ����ʱ�䣺2010-10-22
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_Type CreatePBnet_Lottery_Type()
        {
            string ClassNamespace = AssemblyPath + ".Market_TypeService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_Type)objType;
        }

        /// <summary>
        /// ����IMarket_TypeConfigure���ݲ�ӿ�
        /// ������:����ΰ
        /// ����ʱ�䣺2010-10-22
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_TypeConfigure CreateIPBnet_Lottery_TypeConfigure()
        {
            string ClassNamespace = AssemblyPath + ".Market_TypeConfigureService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_TypeConfigure)objType;
        }
        /// <summary>
        /// ����IMarket_appendItem���ݲ�ӿ�
        /// ������:����ΰ
        /// ����ʱ�䣺2010-10-22
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_appendItem CreateIPBnet_Lottery_appendItem()
        {
            string ClassNamespace = AssemblyPath + ".Market_appendItemService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_appendItem)objType;
        }
        ///// <summary>
        ///// ����IMarket_issueInfo���ݲ�ӿ�
        ///// ������:����ΰ
        ///// ����ʱ�䣺2010-10-22
        ///// </summary>
        ///// <returns></returns>
        //public static Pbzx.IDAL.IMarket_issueInfo CreateIMarket_issueInfo()
        //{
        //    string ClassNamespace = AssemblyPath + ".Market_issueInfoService";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (Pbzx.IDAL.IMarket_issueInfo)objType;
        //}

        /// <summary>
        /// ����Market_Num���ݲ�ӿ�
        /// ������:����ΰ
        /// ����ʱ�䣺2010-10-22
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_Num CreateIMarket_Num()
        {
            string ClassNamespace = AssemblyPath + ".Market_NumService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_Num)objType;
        }
        /// <summary>
        /// ����Market_BuyInfo���ݲ�Ľӿ�
        /// ������: ��ΰ
        /// ������: 2010-10-22
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_BuyInfo CreateIMarket_BuyInfo()
        {
            string ClassNamespace = AssemblyPath + ".Market_BuyInfoService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_BuyInfo)objType;
        }

        /// <summary>
        /// ����Market_BuyInfo���ݲ�Ľӿ�
        /// ������: ��ΰ
        /// ����ʱ��: 2010-10-25
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_ApplicationItem CreateIMarket_ApplicationItem()
        {
            string ClassNamespace = AssemblyPath + ".Market_ApplicationItemService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_ApplicationItem)objType;
        }


        /// <summary>
        /// ����Market_BuyInfo���ݲ�Ľӿ�
        /// ������: ��ΰ
        /// ����ʱ��: 2010-10-28
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_TypeConfigure CreateIMarket_TypeConfigure()
        {
            string ClassNamespace = AssemblyPath + ".Market_TypeConfigureService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_TypeConfigure)objType;
        }


        /// <summary>
        /// ����Market_CollASAtten���ݲ�Ľӿ�
        /// ������: ��ΰ
        /// ����ʱ��: 2010-11-8
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_CollASAtten CreateIMarket_CollASAtten()
        {
            string ClassNamespace = AssemblyPath + ".Market_CollASAttenServer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_CollASAtten)objType;
        }

        /// <summary>
        /// ����Cst_login2010���ݲ�Ľӿ�
        /// ������: xiaowei
        /// ����ʱ��: 2010-11-19
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.ICstLogin2010 CreateICstLogin2010()
        {
            string ClassNamespace = AssemblyPath + ".CstLogin2010Service";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICstLogin2010)objType;
        }

        /// <summary>
        /// ����Market_CancelIndent���ݲ�Ľӿ�
        /// ������: zhouwei
        /// ����ʱ��: 2011-1-10
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_CancelIndent CreateIMarket_CancelIndent()
        {
            string ClassNamespace = AssemblyPath + ".Market_CancelIndentServer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_CancelIndent)objType;
        }

        /// <summary>
        /// ����Chipped_LaunchInfo������ݲ�Ľӿ�
        /// �����ˣ�zhouwei
        /// ����ʱ�䣺2011-2-21
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IChipped_LaunchInfo CreateIChipped_LaunchInfo()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_LaunchInfoServer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_LaunchInfo)objType;
        }
        /// <summary>
        /// ����Chipped_Info������ݲ�Ľӿ�
        /// �����ˣ�zhouwei
        /// ����ʱ�䣺2011-2-21
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IChipped_Info CreateIChipped_Info()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_InfoServer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_Info)objType;
        }
        /// <summary>
        /// ����Chipped_Attention���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_Attention CreateChipped_Attention()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_Attention";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_Attention)objType;
        }

        /// <summary>
        /// ����Chipped_winning���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_winning CreateChipped_winning()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_winning";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_winning)objType;
        }
        /// <summary>
        /// ����Chipped_TrackingOrders���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_TrackingOrders CreateChipped_TrackingOrders()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_TrackingOrders";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_TrackingOrders)objType;
        }
        /// <summary>
        /// ����Chipped_bounsAllost���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_bounsAllost CreateChipped_bounsAllost()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_bounsAllost";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_bounsAllost)objType;
        }
        /// <summary>
        /// ����Chipped_AcctPayCharge���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_AcctPayCharge CreateChipped_AcctPayCharge()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_AcctPayCharge";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_AcctPayCharge)objType;
        }
        /// <summary>
        /// ����DataRivalry_Contrast���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IDataRivalry_Contrast CreateDataRivalry_Contrast()
        {
            string ClassNamespace = AssemblyPath + ".DataRivalry_Contrast";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IDataRivalry_Contrast)objType;
        }
        /// <summary>
        /// ����DataRivalry_UpLoadFile���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IDataRivalry_UpLoadFile CreateDataRivalry_UpLoadFile()
        {
            string ClassNamespace = AssemblyPath + ".DataRivalry_UpLoadFile";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IDataRivalry_UpLoadFile)objType;
        }

        /// <summary>
        /// ����Note_Customize���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.INote_Customize CreateNote_Customize()
        {
            string CacheKey = AssemblyPath + ".Note_Customize";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.INote_Customize)objType;
        }
        /// <summary>
        /// ����Note_WriteBack���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.INote_WriteBack CreateNote_WriteBack()
        {
            string CacheKey = AssemblyPath + ".Note_WriteBack";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.INote_WriteBack)objType;
        }
        /// <summary>
        /// ����Note_Log���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.INote_Log CreateNote_Log()
        {
            string CacheKey = AssemblyPath + ".Note_Log";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.INote_Log)objType;
        }
        /// <summary>
        /// ����Note_LotteryIssue���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.INote_LotteryIssue CreateNote_LotteryIssue()
        {
            string CacheKey = AssemblyPath + ".Note_LotteryIssue";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.INote_LotteryIssue)objType;
        }

        /// <summary>
        /// ����Note_LotteryType���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.INote_LotteryType CreateNote_LotteryType()
        {
            string CacheKey = AssemblyPath + ".Note_LotteryType";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.INote_LotteryType)objType;
        }
        /// <summary>
        /// ����Chipped_Tracking���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_Tracking CreateChipped_Tracking()
        {
            string CacheKey = AssemblyPath + ".Chipped_Tracking";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_Tracking)objType;
        }
        /// <summary>
        /// ����DataRivalry_Result���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IDataRivalry_Rt CreateDataRivalry_Rt()
        {
            string CacheKey = AssemblyPath + ".DataRivalry_Rt";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDataRivalry_Rt)objType;
        }
        /// <summary>
        /// ����PlatformPublic_integralPrize���ݲ�ӿ�
        /// ����ƽ̨���õķ���
        /// </summary>
        public static Pbzx.IDAL.IPlatformPublic_integralPrize CreatePlatformPublic_integralPrize()
        {
            string CacheKey = AssemblyPath + ".PlatformPublic_integralPrize";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IPlatformPublic_integralPrize)objType;
        }
        /// <summary>
        /// ����PlatformPublic_payments���ݲ�ӿ�
        /// ����ƽ̨���õķ���
        /// </summary>
        public static Pbzx.IDAL.IPlatformPublic_payments CreatePlatformPublic_payments()
        {
            string CacheKey = AssemblyPath + ".PlatformPublic_payments";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IPlatformPublic_payments)objType;
        }
        /// <summary>
        /// ����Challenge_integral���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IChallenge_integral CreateChallenge_integral()
        {
            string CacheKey = AssemblyPath + ".Challenge_integral";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChallenge_integral)objType;
        }
        /// <summary>
        /// ����SoftwareHelp_TreeStructure���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IHelp_TreeStructure CreateHelp_TreeStructure()
        {
            string CacheKey = AssemblyPath + ".Help_TreeStructure";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IHelp_TreeStructure)objType;
        }
        /// <summary>
        /// ����SoftwareHelp_HelpName���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IHelp_HelpName CreateHelp_HelpName()
        {
            string CacheKey = AssemblyPath + ".Help_HelpName";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IHelp_HelpName)objType;
        }
        /// <summary>
        /// ����SoftwareHelp_Contrast���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IHelp_Contrast CreateHelp_Contrast()
        {
            string CacheKey = AssemblyPath + ".Help_Contrast";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IHelp_Contrast)objType;
        }
        /// <summary>
        /// ����CN_FreeTestUser_2011���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.ICN_FreeTestUser_2011 CreateCN_FreeTestUser_2011()
        {
            string CacheKey = AssemblyPath + ".CN_FreeTestUser_2011";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.ICN_FreeTestUser_2011)objType;
        }
        /// <summary>
        /// ����Challenge_attention���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IChallenge_attention CreateChallenge_attention()
        {
            string CacheKey = AssemblyPath + ".Challenge_attention";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChallenge_attention)objType;
        }
        /// <summary>
        /// ����DataRivalry_downLoad���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IDataRivalry_downLoad CreateDataRivalry_downLoad()
        {
            string CacheKey = AssemblyPath + ".DataRivalry_downLoad";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDataRivalry_downLoad)objType;
        }
        /// <summary>
        /// ����DataRivalry_Level���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IDataRivalry_Level CreateDataRivalry_Level()
        {
            string CacheKey = AssemblyPath + ".DataRivalry_Level";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDataRivalry_Level)objType;
        }
        /// <summary>
        /// ����PlatformPublic_UserWinning���ݲ�ӿ�
        /// </summary>
        public static Pbzx.IDAL.IPlatformPublic_UserWinning PlatformPublic_UserWinning()
        {
            string CacheKey = AssemblyPath + ".PlatformPublic_UserWinning";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IPlatformPublic_UserWinning)objType;
        }
        /// <summary>
        /// ����Drawer_user���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IDrawer_user CreateDrawer_user()
        {

            string CacheKey = AssemblyPath + ".Drawer_user";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDrawer_user)objType;
        }
        /// <summary>
        /// ����Drawer_Ticket���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IDrawer_Ticket CreateDrawer_Ticket()
        {

            string CacheKey = AssemblyPath + ".Drawer_Ticket";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDrawer_Ticket)objType;
        }
        /// <summary>
        /// ����Drawer_configure���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IDrawer_configure CreateDrawer_configure()
        {

            string CacheKey = AssemblyPath + ".Drawer_configure";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDrawer_configure)objType;
        }

        /// <summary>
        /// ����Chipped_UserTrack���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_UserTrack CreateChipped_UserTrack()
        {

            string CacheKey = AssemblyPath + ".Chipped_UserTrack";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_UserTrack)objType;
        }

        /// <summary>
        /// ����Chipped_RandomNum���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_RandomNum CreateChipped_RandomNum()
        {

            string CacheKey = AssemblyPath + ".Chipped_RandomNum";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_RandomNum)objType;
        }
        /// <summary>
        /// ����Chipped_Num���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_Num CreateChipped_Num()
        {

            string CacheKey = AssemblyPath + ".Chipped_Num";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_Num)objType;
        }
        /// <summary>
        /// ����Chipped_issueN���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_issueN CreateChipped_issueN()
        {

            string CacheKey = AssemblyPath + ".Chipped_issueN";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_issueN)objType;
        }
        /// <summary>
        /// ����Chipped_TrackNum���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_TrackNum CreateChipped_TrackNum()
        {

            string CacheKey = AssemblyPath + ".Chipped_TrackNum";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_TrackNum)objType;
        }
        /// <summary>
        /// ����Chipped_cofig���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IChipped_cofig CreateChipped_cofig()
        {

            string CacheKey = AssemblyPath + ".Chipped_cofig";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_cofig)objType;
        }
        /// <summary>
        /// ����Help_Download���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IHelp_Download CreateHelp_Download()
        {

            string CacheKey = AssemblyPath + ".Help_Download";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IHelp_Download)objType;
        }
        /// <summary>
        /// ����Challenge_Cinfo���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IChallenge_Cinfo CreateChallenge_Cinfo()
        {

            string CacheKey = AssemblyPath + ".Challenge_Cinfo";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChallenge_Cinfo)objType;
        }
        /// <summary>
        /// ����Challenge_type���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IChallenge_type CreateChallenge_type()
        {

            string CacheKey = AssemblyPath + ".Challenge_type";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChallenge_type)objType;
        }

        /// <summary>
        /// ����Challenge_config���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IChallenge_config CreateChallenge_config()
        {

            string CacheKey = AssemblyPath + ".Challenge_config";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChallenge_config)objType;
        }
        /// <summary>
        /// ����PBnet_platfrom_locn���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_platfrom_icon CreatePBnet_platfrom_icon()
        {

            string CacheKey = AssemblyPath + ".PBnet_platfrom_icon";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IPBnet_platfrom_icon)objType;
        }
        /// <summary>
        /// ����PBnet_PayAtt���ݲ�ӿڡ�
        /// </summary>
        public static Pbzx.IDAL.IPBnet_PayAtt CreatePBnet_PayAtt()
        {

            string CacheKey = AssemblyPath + ".PBnet_PayAtt";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IPBnet_PayAtt)objType;
        }
    }
}