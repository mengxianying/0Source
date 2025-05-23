using System;
using System.Reflection;
using System.Configuration;
namespace Pbzx.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            object objType = DataCache.GetCache(classNamespace);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                    DataCache.SetCache(classNamespace, objType);// 写入缓存
                }
                catch//(System.Exception ex)
                {
                    //string str=ex.Message;// 记录错误日志
                }
            }
            return objType;
        }
        #endregion

        #region CreateSysManage
        public static Pbzx.IDAL.ISysManage CreateSysManage()
        {
            //方式1			
            //return (Pbzx.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

            //方式2 			
            string classNamespace = AssemblyPath + ".SysManage";
            object objType = CreateObject(AssemblyPath, classNamespace);
            return (Pbzx.IDAL.ISysManage)objType;
        }
        #endregion




        /// <summary>
        /// 创建PBnet_QQ数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_QQ CreatePBnet_QQ()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_QQ";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_QQ)objType;
        }

        /// <summary>
        /// 创建PBnet_ask_Attach数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_Attach CreatePBnet_ask_Attach()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_Attach";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_Attach)objType;
        }


        /// <summary>
        /// 创建PBnet_LyBook数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_LyBook CreatePBnet_LyBook()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_LyBook";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_LyBook)objType;
        }
        /// <summary>
        /// 创建PBnet_LyResume数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_LyResume CreatePBnet_LyResume()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_LyResume";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_LyResume)objType;
        }
        /// <summary>
        /// 创建PBnet_adminloginlog数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_adminloginlog CreatePBnet_adminloginlog()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_adminloginlog";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_adminloginlog)objType;
        }


        /// <summary>
        /// 创建PBnet_ADRecord数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ADRecord CreatePBnet_ADRecord()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ADRecord";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ADRecord)objType;
        }
        /// <summary>
        /// 创建PBnet_PulbicContent数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_PulbicContent CreatePBnet_PulbicContent()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_PulbicContent";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_PulbicContent)objType;
        }

        /// <summary>
        /// 创建PBnet_broker_Config数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_broker_Config CreatePBnet_broker_Config()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_broker_Config";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_broker_Config)objType;
        }


        /// <summary>
        /// 创建PBnet_broker_content数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_broker_content CreatePBnet_broker_content()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_broker_content";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_broker_content)objType;
        }
        /// <summary>
        /// 创建PBnet_AdvPlace数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Adv CreatePBnet_Adv()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Adv";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Adv)objType;
        }

        /// <summary>
        /// 创建PBnet_AdvPlace数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_AdvPlace CreatePBnet_AdvPlace()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_AdvPlace";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_AdvPlace)objType;
        }

        /// <summary>
        /// 创建PBnet_arltype数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_arltype CreatePBnet_arltype()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_arltype";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_arltype)objType;
        }



        /// <summary>
        /// 创建CN_Black数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_Black CreateCN_Black()
        {

            string ClassNamespace = AssemblyPath + ".CN_Black";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_Black)objType;
        }


        /// <summary>
        /// 创建SoftDogInfo数据层接口
        /// </summary>
        public static Pbzx.IDAL.ISoftDogInfo CreateSoftDogInfo()
        {

            string ClassNamespace = AssemblyPath + ".SoftDogInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ISoftDogInfo)objType;
        }


        /// <summary>
        /// 创建CL_PrintLine数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICL_PrintLine CreateCL_PrintLine()
        {

            string ClassNamespace = AssemblyPath + ".CL_PrintLine";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICL_PrintLine)objType;
        }






        /// <summary>
        /// 创建PBnet_bocai数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_bocai CreatePBnet_bocai()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_bocai";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_bocai)objType;
        }


        /// <summary>
        /// 创建PBnet_boclb数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_boclb CreatePBnet_boclb()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_boclb";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_boclb)objType;
        }


        /// <summary>
        /// 创建PBnet_Bulletin数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Bulletin CreatePBnet_Bulletin()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Bulletin";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Bulletin)objType;
        }


        /// <summary>
        /// 创建PBnet_FreeReg数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_FreeReg CreatePBnet_FreeReg()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_FreeReg";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_FreeReg)objType;
        }



        /// <summary>
        /// 创建PBnet_ipdata数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ipdata CreatePBnet_ipdata()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ipdata";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ipdata)objType;
        }


        /// <summary>
        /// 创建PBnet_jjqi数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_jjqi CreatePBnet_jjqi()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_jjqi";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_jjqi)objType;
        }



        /// <summary>
        /// 创建PBnet_UserTradeInfo数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_UserTradeInfo CreatePBnet_UserTradeInfo()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_UserTradeInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_UserTradeInfo)objType;
        }

        /// <summary>
        /// 创建PBnet_Links数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Links CreatePBnet_Links()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Links";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Links)objType;
        }


        /// <summary>
        /// 创建PBnet_LotteryMenu数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_LotteryMenu CreatePBnet_LotteryMenu()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_LotteryMenu";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_LotteryMenu)objType;
        }


        /// <summary>
        /// 创建PBnet_News数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_News CreatePBnet_News()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_News";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_News)objType;
        }

        /// <summary>
        /// 创建PBnet_Nslide数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Nslide CreatePBnet_Nslide()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Nslide";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Nslide)objType;
        }

        /// <summary>
        /// 创建PBnet_pb_3d2005ord数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_pb_3d2005ord CreatePBnet_pb_3d2005ord()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_pb_3d2005ord";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_pb_3d2005ord)objType;
        }


        /// <summary>
        /// 创建PBnet_pdttComment数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_pdttComment CreatePBnet_pdttComment()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_pdttComment";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_pdttComment)objType;
        }


        /// <summary>
        /// 创建PBnet_Product数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Product CreatePBnet_Product()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Product";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Product)objType;
        }


        /// <summary>
        /// 创建PBnet_qjqi数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_qjqi CreatePBnet_qjqi()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_qjqi";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_qjqi)objType;
        }


        /// <summary>
        /// 创建PBnet_sms数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_sms CreatePBnet_sms()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_sms";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_sms)objType;
        }


        /// <summary>
        /// 创建PBnet_smsback数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_smsback CreatePBnet_smsback()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_smsback";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_smsback)objType;
        }


        /// <summary>
        /// 创建PBnet_smsfs数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_smsfs CreatePBnet_smsfs()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_smsfs";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_smsfs)objType;
        }


        /// <summary>
        /// 创建PBnet_Soft数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Soft CreatePBnet_Soft()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Soft";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Soft)objType;
        }


        /// <summary>
        /// 创建PBnet_SoftClass数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_SoftClass CreatePBnet_SoftClass()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_SoftClass";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_SoftClass)objType;
        }


        /// <summary>
        /// 创建PBnet_SoftComment数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_SoftComment CreatePBnet_SoftComment()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_SoftComment";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_SoftComment)objType;
        }


        /// <summary>
        /// 创建PBnet_tpman数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_tpman CreatePBnet_tpman()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_tpman";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_tpman)objType;
        }


        /// <summary>
        /// 创建PBnet_UserTable数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_UserTable CreatePBnet_UserTable()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_UserTable";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_UserTable)objType;
        }


        /// <summary>
        /// 创建PBnet_vipman数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_vipman CreatePBnet_vipman()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_vipman";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_vipman)objType;
        }

        /// <summary>
        /// 创建PBnet_Module数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Module CreatePBnet_Module()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Module";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Module)objType;
        }

        /// <summary>
        /// 创建PBnet_BulletinType数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_BulletinType CreatePBnet_BulletinType()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_BulletinType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_BulletinType)objType;
        }
        /// <summary>
        /// 创建AgentInfo数据层接口
        /// </summary>
        public static Pbzx.IDAL.IAgentInfo CreateAgentInfo()
        {

            string ClassNamespace = AssemblyPath + ".AgentInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IAgentInfo)objType;
        }
        /// <summary>
        /// 创建AgentInfo_Apply数据层接口
        /// </summary>
        public static Pbzx.IDAL.IAgentInfo_Apply CreateAgentInfo_Apply()
        {

            string ClassNamespace = AssemblyPath + ".AgentInfo_Apply";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IAgentInfo_Apply)objType;
        }
        /// <summary>
        /// 创建AgentAgree数据层接口
        /// </summary>
        public static Pbzx.IDAL.IAgentAgree CreateAgentAgree()
        {

            string ClassNamespace = AssemblyPath + ".AgentAgree";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IAgentAgree)objType;
        }
        /// <summary>
        /// 创建CN_UserDetails数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_UserDetails CreateCN_UserDetails()
        {

            string ClassNamespace = AssemblyPath + ".CN_UserDetails";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_UserDetails)objType;
        }


        /// <summary>
        /// 创建PBnet_NewsType数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_NewsType CreatePBnet_NewsType()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_NewsType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_NewsType)objType;
        }

        /// <summary>
        /// 创建CN_Online数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_Online CreateCN_Online()
        {

            string ClassNamespace = AssemblyPath + ".CN_Online";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_Online)objType;
        }

        /// <summary>
        /// 创建CN_MaxOnline数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_MaxOnline CreateCN_MaxOnline()
        {

            string ClassNamespace = AssemblyPath + ".CN_MaxOnline";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_MaxOnline)objType;
        }
        /// <summary>
        /// 创建CN_Log数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_Log CreateCN_Log()
        {

            string ClassNamespace = AssemblyPath + ".CN_Log";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_Log)objType;
        }
        /// <summary>
        /// 创建CN_Config数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_Config CreateCN_Config()
        {

            string ClassNamespace = AssemblyPath + ".CN_Config";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_Config)objType;
        }
        /// <summary>
        /// 创建CN_User数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_User CreateCN_User()
        {

            string ClassNamespace = AssemblyPath + ".CN_User";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_User)objType;
        }
        /// <summary>
        /// 创建CN_FreeTestUser数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_FreeTestUser CreateCN_FreeTestUser()
        {

            string ClassNamespace = AssemblyPath + ".CN_FreeTestUser";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_FreeTestUser)objType;
        }


        /// <summary>
        /// 创建CN_Software数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_Software CreateCN_Software()
        {

            string ClassNamespace = AssemblyPath + ".CN_Software";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_Software)objType;
        }



        /// <summary>
        /// 创建CN_StatLog数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_StatLog CreateCN_StatLog()
        {

            string ClassNamespace = AssemblyPath + ".CN_StatLog";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_StatLog)objType;
        }


        /// <summary>
        /// 创建PBnet_ProductPrice数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ProductPrice CreatePBnet_ProductPrice()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ProductPrice";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ProductPrice)objType;
        }

        /// <summary>
        /// 创建CstLogin数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICstLogin CreateCstLogin()
        {

            string ClassNamespace = AssemblyPath + ".CstLogin";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICstLogin)objType;
        }

        /// <summary>
        /// 创建CstMessage数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICstMessage CreateCstMessage()
        {

            string ClassNamespace = AssemblyPath + ".CstMessage";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICstMessage)objType;
        }

        /// <summary>
        /// 创建CM_Main数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICM_Main CreateCM_Main()
        {

            string ClassNamespace = AssemblyPath + ".CM_MainService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICM_Main)objType;
        }
        /// <summary>
        /// 创建CM_MainBySoftwareType数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICM_MainBySoftwareType CreateCM_MainBySoftwareType()
        {

            string ClassNamespace = AssemblyPath + ".CM_MainBySoftwareTypeService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICM_MainBySoftwareType)objType;
        }

        /// <summary>
        /// 创建CstSoftware数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICstSoftware CreateCstSoftware()
        {

            string ClassNamespace = AssemblyPath + ".CstSoftware";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICstSoftware)objType;
        }

        /// <summary>
        /// 创建RegisterInfo2数据层接口
        /// </summary>
        public static Pbzx.IDAL.IRegisterInfo2 CreateRegisterInfo2()
        {

            string ClassNamespace = AssemblyPath + ".RegisterInfo2";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IRegisterInfo2)objType;
        }
        /// <summary>
        /// 创建CN_RegisterLog数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_RegisterLog CreateCN_RegisterLog()
        {

            string ClassNamespace = AssemblyPath + ".CN_RegisterLog";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICN_RegisterLog)objType;
        }
        /// <summary>
        /// 创建CL_RegisterInfo数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICL_RegisterInfo CreateCL_RegisterInfo()
        {
            string ClassNamespace = AssemblyPath + ".CL_RegisterInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICL_RegisterInfo)objType;
        }

        /// <summary>
        /// 创建TC7XCData数据层接口
        /// </summary>
        public static Pbzx.IDAL.ITC7XCData CreateTC7XCData()
        {
            string ClassNamespace = AssemblyPath + ".TC7XCData_New";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITC7XCData)objType;
        }
        /// <summary>
        /// 创建FCSSData数据层接口
        /// </summary>
        public static Pbzx.IDAL.IFCSSData CreateFCSSData()
        {
            string ClassNamespace = AssemblyPath + ".FCSSData";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSData)objType;
        }
        /// <summary>
        /// 创建FC3DData数据层接口
        /// </summary>
        public static Pbzx.IDAL.IFC3DData CreateFC3DData()
        {

            string ClassNamespace = AssemblyPath + ".FC3DData";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFC3DData)objType;
        }
        /// <summary>
        /// 创建FC7LC数据层接口
        /// </summary>
        public static Pbzx.IDAL.IFC7LC CreateFC7LC()
        {
            string ClassNamespace = AssemblyPath + ".FC7LC";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFC7LC)objType;
        }
        /// <summary>
        /// 创建TCDLTData数据层接口
        /// </summary>
        public static Pbzx.IDAL.ITCDLTData CreateTCDLTData()
        {

            string ClassNamespace = AssemblyPath + ".TCDLTData";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITCDLTData)objType;
        }
        /// <summary>
        /// 创建TCPL35Data数据层接口
        /// </summary>
        public static Pbzx.IDAL.ITCPL35Data CreateTCPL35Data()
        {

            string ClassNamespace = AssemblyPath + ".TCPL35Data";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITCPL35Data)objType;
        }
        /// <summary>
        /// 创建TC22X5Data数据层接口
        /// </summary>
        public static Pbzx.IDAL.ITC22X5Data CreateTC22X5Data()
        {

            string ClassNamespace = AssemblyPath + ".TC22X5Data";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITC22X5Data)objType;
        }
        /// <summary>
        /// 创建TC29X7Data数据层接口
        /// </summary>
        public static Pbzx.IDAL.ITC29X7Data CreateTC29X7Data()
        {

            string ClassNamespace = AssemblyPath + ".TC29X7Data";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITC29X7Data)objType;
        }
        /// <summary>
        /// 创建TC29X7Data数据层接口
        /// </summary>
        public static Pbzx.IDAL.ITC31X7Data CreateTC31X7Data()
        {

            string ClassNamespace = AssemblyPath + ".TC31X7Data";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ITC31X7Data)objType;
        }
        /// <summary>
        /// 创建FCSSLData_SH数据层接口
        /// </summary>
        public static Pbzx.IDAL.IFCSSLData_SH CreateFCSSLData_SH()
        {

            string ClassNamespace = AssemblyPath + ".FCSSLData_SH";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSLData_SH)objType;
        }
        /// <summary>
        /// 创建K3Date数据层接口
        /// </summary>
        public static Pbzx.IDAL.IK3Date CreateK3Date()
        {

            string ClassNamespace = AssemblyPath + ".K3Date";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IK3Date)objType;
        }
        /// <summary>
        /// 创建FCSSCData_ChongQ数据层接口
        /// </summary>
        public static Pbzx.IDAL.IFCSSCData_ChongQ CreateFCSSCData_ChongQ()
        {

            string ClassNamespace = AssemblyPath + ".FCSSCData_ChongQ";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSCData_ChongQ)objType;
        }


        /// <summary>
        /// 创建FCSSCData_JiangX数据层接口
        /// </summary>
        public static Pbzx.IDAL.IFCSSCData_JiangX CreateFCSSCData_JiangX()
        {

            string ClassNamespace = AssemblyPath + ".FCSSCData_JiangX";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSCData_JiangX)objType;
        }


        /// <summary>
        /// 创建FCSSCData_XinJ数据层接口
        /// </summary>
        public static Pbzx.IDAL.IFCSSCData_XinJ CreateFCSSCData_XinJ()
        {

            string ClassNamespace = AssemblyPath + ".FCSSCData_XinJ";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSCData_XinJ)objType;
        }


        /// <summary>
        /// 创建FCSSCData_FuJ数据层接口
        /// </summary>
        public static Pbzx.IDAL.IFCSSCData_FuJ CreateFCSSCData_FuJ()
        {

            string ClassNamespace = AssemblyPath + ".FCSSCData_FuJ";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCSSCData_FuJ)objType;
        }

        /// <summary>
        /// 创建FCSSCData_FuJ数据层接口
        /// </summary>
        public static Pbzx.IDAL.IFCPL5Data_HeB CreateFCPL5Data_HeB()
        {

            string ClassNamespace = AssemblyPath + ".FCPL5Data_HeB";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFCPL5Data_HeB)objType;
        }

        /// <summary>
        /// 创建FCSSCData_FuJ数据层接口
        /// </summary>
        public static Pbzx.IDAL.IFC4DData_ShangH CreateFC4DData_ShangH()
        {

            string ClassNamespace = AssemblyPath + ".FC4DData_ShangH";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IFC4DData_ShangH)objType;
        }
        /// <summary>
        /// 创建PBnet_Label数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Label CreatePBnet_Label()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Label";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Label)objType;
        }
        /// <summary>
        /// 创建PBnet_PaginAtion数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_PaginAtion CreatePBnet_PaginAtion()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_PaginAtion";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_PaginAtion)objType;
        }
        /// <summary>
        /// 创建PBnet_UrlMaping数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_UrlMaping CreatePBnet_UrlMaping()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_UrlMaping";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_UrlMaping)objType;
        }
        /// <summary>
        /// 创建PBnet_broker_TradeInfo数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_broker_TradeInfo CreatePBnet_broker_TradeInfo()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_broker_TradeInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_broker_TradeInfo)objType;
        }

        /// <summary>
        /// 创建PBnet_broker数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_broker CreatePBnet_broker()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_broker";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_broker)objType;
        }

        /// <summary>
        /// 创建PBnet_ask_User数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_User CreatePBnet_ask_User()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_User";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_User)objType;
        }

        /// <summary>
        /// 创建PBnet_ask_GradeConfig数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_GradeConfig CreatePBnet_ask_GradeConfig()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_GradeConfig";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_GradeConfig)objType;
        }



        /// <summary>
        /// 创建PBnet_ask_Question数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_Question CreatePBnet_ask_Question()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_Question";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_Question)objType;
        }


        /// <summary>
        /// 创建PBnet_ask_Reply数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_Reply CreatePBnet_ask_Reply()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_Reply";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_Reply)objType;
        }


        /// <summary>
        /// 创建PBnet_ask_Type数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_ask_Type CreatePBnet_ask_Type()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_ask_Type";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_ask_Type)objType;
        }



        /// <summary>
        /// 创建PBnet_UserProtectPwd数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_UserProtectPwd CreatePBnet_UserProtectPwd()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_UserProtectPwd";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_UserProtectPwd)objType;
        }

        /// <summary>
        /// 创建PBnet_OrderTradeInfo数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_OrderTradeInfo CreatePBnet_OrderTradeInfo()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_OrderTradeInfo";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_OrderTradeInfo)objType;
        }


        /// <summary>
        /// 创建PBnet_Charge数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Charge CreatePBnet_Charge()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Charge";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Charge)objType;
        }

        /// <summary>
        /// 创建PBnet_School数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_School CreatePBnet_School()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_School";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_School)objType;
        }

        /// <summary>
        /// 创建PBnet_Channel数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Channel CreatePBnet_Channel()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Channel";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Channel)objType;
        }

        /// <summary>
        /// 创建PBnet_SchoolType数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_SchoolType CreatePBnet_SchoolType()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_SchoolType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_SchoolType)objType;
        }

        /// <summary>
        /// 创建PBnet_Orders_Delegates数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_Orders_Delegates CreatePBnet_Orders_Delegates()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_Orders_Delegates";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_Orders_Delegates)objType;
        }

        /// <summary>
        /// 创建PBnet_OrderDetail_Delegate数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_OrderDetail_Delegate CreatePBnet_OrderDetail_Delegate()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_OrderDetail_Delegate";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_OrderDetail_Delegate)objType;
        }


        /// <summary>
        /// 创建PBnet_QQ_Group数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_QQ_Group CreatePBnet_QQ_Group()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_QQ_Group";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_QQ_Group)objType;
        }

        /// <summary>
        /// 创建PBnet_QQ_Record数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_QQ_Record CreatePBnet_QQ_Record()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_QQ_Record";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_QQ_Record)objType;
        }
        /// <summary>
        /// 创建PBnet_About数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_About CreatePBnet_About()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_About";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_About)objType;
        }

        /// <summary>
        /// 创建PBnet_UserLog数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_UserLog CreatePBnet_UserLog()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_UserLog";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_UserLog)objType;
        }

        /// <summary>
        /// 创建PBnet_LyType数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPBnet_LyType CreatePBnet_LyType()
        {

            string ClassNamespace = AssemblyPath + ".PBnet_LyType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IPBnet_LyType)objType;
        }
        /// <summary>
        /// 创建IMarket_Type数据层接口
        /// 创建人:杨良伟
        /// 创建时间：2010-10-22
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_Type CreatePBnet_Lottery_Type()
        {
            string ClassNamespace = AssemblyPath + ".Market_TypeService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_Type)objType;
        }

        /// <summary>
        /// 创建IMarket_TypeConfigure数据层接口
        /// 创建人:杨良伟
        /// 创建时间：2010-10-22
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_TypeConfigure CreateIPBnet_Lottery_TypeConfigure()
        {
            string ClassNamespace = AssemblyPath + ".Market_TypeConfigureService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_TypeConfigure)objType;
        }
        /// <summary>
        /// 创建IMarket_appendItem数据层接口
        /// 创建人:杨良伟
        /// 创建时间：2010-10-22
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_appendItem CreateIPBnet_Lottery_appendItem()
        {
            string ClassNamespace = AssemblyPath + ".Market_appendItemService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_appendItem)objType;
        }
        ///// <summary>
        ///// 创建IMarket_issueInfo数据层接口
        ///// 创建人:杨良伟
        ///// 创建时间：2010-10-22
        ///// </summary>
        ///// <returns></returns>
        //public static Pbzx.IDAL.IMarket_issueInfo CreateIMarket_issueInfo()
        //{
        //    string ClassNamespace = AssemblyPath + ".Market_issueInfoService";
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (Pbzx.IDAL.IMarket_issueInfo)objType;
        //}

        /// <summary>
        /// 创建Market_Num数据层接口
        /// 创建人:杨良伟
        /// 创建时间：2010-10-22
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_Num CreateIMarket_Num()
        {
            string ClassNamespace = AssemblyPath + ".Market_NumService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_Num)objType;
        }
        /// <summary>
        /// 创建Market_BuyInfo数据层的接口
        /// 创建人: 周伟
        /// 创建人: 2010-10-22
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_BuyInfo CreateIMarket_BuyInfo()
        {
            string ClassNamespace = AssemblyPath + ".Market_BuyInfoService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_BuyInfo)objType;
        }

        /// <summary>
        /// 创建Market_BuyInfo数据层的接口
        /// 创建人: 周伟
        /// 创建时间: 2010-10-25
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_ApplicationItem CreateIMarket_ApplicationItem()
        {
            string ClassNamespace = AssemblyPath + ".Market_ApplicationItemService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_ApplicationItem)objType;
        }


        /// <summary>
        /// 创建Market_BuyInfo数据层的接口
        /// 创建人: 周伟
        /// 创建时间: 2010-10-28
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_TypeConfigure CreateIMarket_TypeConfigure()
        {
            string ClassNamespace = AssemblyPath + ".Market_TypeConfigureService";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_TypeConfigure)objType;
        }


        /// <summary>
        /// 创建Market_CollASAtten数据层的接口
        /// 创建人: 周伟
        /// 创建时间: 2010-11-8
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_CollASAtten CreateIMarket_CollASAtten()
        {
            string ClassNamespace = AssemblyPath + ".Market_CollASAttenServer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_CollASAtten)objType;
        }

        /// <summary>
        /// 创建Cst_login2010数据层的接口
        /// 创建人: xiaowei
        /// 创建时间: 2010-11-19
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.ICstLogin2010 CreateICstLogin2010()
        {
            string ClassNamespace = AssemblyPath + ".CstLogin2010Service";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.ICstLogin2010)objType;
        }

        /// <summary>
        /// 创建Market_CancelIndent数据层的接口
        /// 创建人: zhouwei
        /// 创建时间: 2011-1-10
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IMarket_CancelIndent CreateIMarket_CancelIndent()
        {
            string ClassNamespace = AssemblyPath + ".Market_CancelIndentServer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IMarket_CancelIndent)objType;
        }

        /// <summary>
        /// 创建Chipped_LaunchInfo表的数据层的接口
        /// 创建人：zhouwei
        /// 创建时间：2011-2-21
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IChipped_LaunchInfo CreateIChipped_LaunchInfo()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_LaunchInfoServer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_LaunchInfo)objType;
        }
        /// <summary>
        /// 创建Chipped_Info表的数据层的接口
        /// 创建人：zhouwei
        /// 创建时间：2011-2-21
        /// </summary>
        /// <returns></returns>
        public static Pbzx.IDAL.IChipped_Info CreateIChipped_Info()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_InfoServer";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_Info)objType;
        }
        /// <summary>
        /// 创建Chipped_Attention数据层接口
        /// </summary>
        public static Pbzx.IDAL.IChipped_Attention CreateChipped_Attention()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_Attention";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_Attention)objType;
        }

        /// <summary>
        /// 创建Chipped_winning数据层接口
        /// </summary>
        public static Pbzx.IDAL.IChipped_winning CreateChipped_winning()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_winning";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_winning)objType;
        }
        /// <summary>
        /// 创建Chipped_TrackingOrders数据层接口
        /// </summary>
        public static Pbzx.IDAL.IChipped_TrackingOrders CreateChipped_TrackingOrders()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_TrackingOrders";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_TrackingOrders)objType;
        }
        /// <summary>
        /// 创建Chipped_bounsAllost数据层接口
        /// </summary>
        public static Pbzx.IDAL.IChipped_bounsAllost CreateChipped_bounsAllost()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_bounsAllost";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_bounsAllost)objType;
        }
        /// <summary>
        /// 创建Chipped_AcctPayCharge数据层接口
        /// </summary>
        public static Pbzx.IDAL.IChipped_AcctPayCharge CreateChipped_AcctPayCharge()
        {
            string ClassNamespace = AssemblyPath + ".Chipped_AcctPayCharge";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IChipped_AcctPayCharge)objType;
        }
        /// <summary>
        /// 创建DataRivalry_Contrast数据层接口
        /// </summary>
        public static Pbzx.IDAL.IDataRivalry_Contrast CreateDataRivalry_Contrast()
        {
            string ClassNamespace = AssemblyPath + ".DataRivalry_Contrast";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IDataRivalry_Contrast)objType;
        }
        /// <summary>
        /// 创建DataRivalry_UpLoadFile数据层接口
        /// </summary>
        public static Pbzx.IDAL.IDataRivalry_UpLoadFile CreateDataRivalry_UpLoadFile()
        {
            string ClassNamespace = AssemblyPath + ".DataRivalry_UpLoadFile";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (Pbzx.IDAL.IDataRivalry_UpLoadFile)objType;
        }

        /// <summary>
        /// 创建Note_Customize数据层接口
        /// </summary>
        public static Pbzx.IDAL.INote_Customize CreateNote_Customize()
        {
            string CacheKey = AssemblyPath + ".Note_Customize";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.INote_Customize)objType;
        }
        /// <summary>
        /// 创建Note_WriteBack数据层接口
        /// </summary>
        public static Pbzx.IDAL.INote_WriteBack CreateNote_WriteBack()
        {
            string CacheKey = AssemblyPath + ".Note_WriteBack";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.INote_WriteBack)objType;
        }
        /// <summary>
        /// 创建Note_Log数据层接口
        /// </summary>
        public static Pbzx.IDAL.INote_Log CreateNote_Log()
        {
            string CacheKey = AssemblyPath + ".Note_Log";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.INote_Log)objType;
        }
        /// <summary>
        /// 创建Note_LotteryIssue数据层接口
        /// </summary>
        public static Pbzx.IDAL.INote_LotteryIssue CreateNote_LotteryIssue()
        {
            string CacheKey = AssemblyPath + ".Note_LotteryIssue";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.INote_LotteryIssue)objType;
        }

        /// <summary>
        /// 创建Note_LotteryType数据层接口
        /// </summary>
        public static Pbzx.IDAL.INote_LotteryType CreateNote_LotteryType()
        {
            string CacheKey = AssemblyPath + ".Note_LotteryType";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.INote_LotteryType)objType;
        }
        /// <summary>
        /// 创建Chipped_Tracking数据层接口
        /// </summary>
        public static Pbzx.IDAL.IChipped_Tracking CreateChipped_Tracking()
        {
            string CacheKey = AssemblyPath + ".Chipped_Tracking";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_Tracking)objType;
        }
        /// <summary>
        /// 创建DataRivalry_Result数据层接口
        /// </summary>
        public static Pbzx.IDAL.IDataRivalry_Rt CreateDataRivalry_Rt()
        {
            string CacheKey = AssemblyPath + ".DataRivalry_Rt";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDataRivalry_Rt)objType;
        }
        /// <summary>
        /// 创建PlatformPublic_integralPrize数据层接口
        /// 所有平台公用的方法
        /// </summary>
        public static Pbzx.IDAL.IPlatformPublic_integralPrize CreatePlatformPublic_integralPrize()
        {
            string CacheKey = AssemblyPath + ".PlatformPublic_integralPrize";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IPlatformPublic_integralPrize)objType;
        }
        /// <summary>
        /// 创建PlatformPublic_payments数据层接口
        /// 所有平台公用的方法
        /// </summary>
        public static Pbzx.IDAL.IPlatformPublic_payments CreatePlatformPublic_payments()
        {
            string CacheKey = AssemblyPath + ".PlatformPublic_payments";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IPlatformPublic_payments)objType;
        }
        /// <summary>
        /// 创建Challenge_integral数据层接口
        /// </summary>
        public static Pbzx.IDAL.IChallenge_integral CreateChallenge_integral()
        {
            string CacheKey = AssemblyPath + ".Challenge_integral";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChallenge_integral)objType;
        }
        /// <summary>
        /// 创建SoftwareHelp_TreeStructure数据层接口
        /// </summary>
        public static Pbzx.IDAL.IHelp_TreeStructure CreateHelp_TreeStructure()
        {
            string CacheKey = AssemblyPath + ".Help_TreeStructure";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IHelp_TreeStructure)objType;
        }
        /// <summary>
        /// 创建SoftwareHelp_HelpName数据层接口
        /// </summary>
        public static Pbzx.IDAL.IHelp_HelpName CreateHelp_HelpName()
        {
            string CacheKey = AssemblyPath + ".Help_HelpName";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IHelp_HelpName)objType;
        }
        /// <summary>
        /// 创建SoftwareHelp_Contrast数据层接口
        /// </summary>
        public static Pbzx.IDAL.IHelp_Contrast CreateHelp_Contrast()
        {
            string CacheKey = AssemblyPath + ".Help_Contrast";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IHelp_Contrast)objType;
        }
        /// <summary>
        /// 创建CN_FreeTestUser_2011数据层接口
        /// </summary>
        public static Pbzx.IDAL.ICN_FreeTestUser_2011 CreateCN_FreeTestUser_2011()
        {
            string CacheKey = AssemblyPath + ".CN_FreeTestUser_2011";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.ICN_FreeTestUser_2011)objType;
        }
        /// <summary>
        /// 创建Challenge_attention数据层接口
        /// </summary>
        public static Pbzx.IDAL.IChallenge_attention CreateChallenge_attention()
        {
            string CacheKey = AssemblyPath + ".Challenge_attention";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChallenge_attention)objType;
        }
        /// <summary>
        /// 创建DataRivalry_downLoad数据层接口
        /// </summary>
        public static Pbzx.IDAL.IDataRivalry_downLoad CreateDataRivalry_downLoad()
        {
            string CacheKey = AssemblyPath + ".DataRivalry_downLoad";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDataRivalry_downLoad)objType;
        }
        /// <summary>
        /// 创建DataRivalry_Level数据层接口
        /// </summary>
        public static Pbzx.IDAL.IDataRivalry_Level CreateDataRivalry_Level()
        {
            string CacheKey = AssemblyPath + ".DataRivalry_Level";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDataRivalry_Level)objType;
        }
        /// <summary>
        /// 创建PlatformPublic_UserWinning数据层接口
        /// </summary>
        public static Pbzx.IDAL.IPlatformPublic_UserWinning PlatformPublic_UserWinning()
        {
            string CacheKey = AssemblyPath + ".PlatformPublic_UserWinning";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IPlatformPublic_UserWinning)objType;
        }
        /// <summary>
        /// 创建Drawer_user数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IDrawer_user CreateDrawer_user()
        {

            string CacheKey = AssemblyPath + ".Drawer_user";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDrawer_user)objType;
        }
        /// <summary>
        /// 创建Drawer_Ticket数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IDrawer_Ticket CreateDrawer_Ticket()
        {

            string CacheKey = AssemblyPath + ".Drawer_Ticket";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDrawer_Ticket)objType;
        }
        /// <summary>
        /// 创建Drawer_configure数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IDrawer_configure CreateDrawer_configure()
        {

            string CacheKey = AssemblyPath + ".Drawer_configure";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IDrawer_configure)objType;
        }

        /// <summary>
        /// 创建Chipped_UserTrack数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IChipped_UserTrack CreateChipped_UserTrack()
        {

            string CacheKey = AssemblyPath + ".Chipped_UserTrack";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_UserTrack)objType;
        }

        /// <summary>
        /// 创建Chipped_RandomNum数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IChipped_RandomNum CreateChipped_RandomNum()
        {

            string CacheKey = AssemblyPath + ".Chipped_RandomNum";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_RandomNum)objType;
        }
        /// <summary>
        /// 创建Chipped_Num数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IChipped_Num CreateChipped_Num()
        {

            string CacheKey = AssemblyPath + ".Chipped_Num";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_Num)objType;
        }
        /// <summary>
        /// 创建Chipped_issueN数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IChipped_issueN CreateChipped_issueN()
        {

            string CacheKey = AssemblyPath + ".Chipped_issueN";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_issueN)objType;
        }
        /// <summary>
        /// 创建Chipped_TrackNum数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IChipped_TrackNum CreateChipped_TrackNum()
        {

            string CacheKey = AssemblyPath + ".Chipped_TrackNum";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_TrackNum)objType;
        }
        /// <summary>
        /// 创建Chipped_cofig数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IChipped_cofig CreateChipped_cofig()
        {

            string CacheKey = AssemblyPath + ".Chipped_cofig";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChipped_cofig)objType;
        }
        /// <summary>
        /// 创建Help_Download数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IHelp_Download CreateHelp_Download()
        {

            string CacheKey = AssemblyPath + ".Help_Download";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IHelp_Download)objType;
        }
        /// <summary>
        /// 创建Challenge_Cinfo数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IChallenge_Cinfo CreateChallenge_Cinfo()
        {

            string CacheKey = AssemblyPath + ".Challenge_Cinfo";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChallenge_Cinfo)objType;
        }
        /// <summary>
        /// 创建Challenge_type数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IChallenge_type CreateChallenge_type()
        {

            string CacheKey = AssemblyPath + ".Challenge_type";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChallenge_type)objType;
        }

        /// <summary>
        /// 创建Challenge_config数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IChallenge_config CreateChallenge_config()
        {

            string CacheKey = AssemblyPath + ".Challenge_config";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IChallenge_config)objType;
        }
        /// <summary>
        /// 创建PBnet_platfrom_locn数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IPBnet_platfrom_icon CreatePBnet_platfrom_icon()
        {

            string CacheKey = AssemblyPath + ".PBnet_platfrom_icon";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IPBnet_platfrom_icon)objType;
        }
        /// <summary>
        /// 创建PBnet_PayAtt数据层接口。
        /// </summary>
        public static Pbzx.IDAL.IPBnet_PayAtt CreatePBnet_PayAtt()
        {

            string CacheKey = AssemblyPath + ".PBnet_PayAtt";
            object objType = CreateObject(AssemblyPath, CacheKey);
            return (Pbzx.IDAL.IPBnet_PayAtt)objType;
        }
    }
}