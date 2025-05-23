using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_Adv。
    /// </summary>
    public class PBnet_Adv : IPBnet_Adv
    {
        public PBnet_Adv()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_Adv");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Adv model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_Adv(");
            strSql.Append("pb_SiteName,pb_SiteUrl,pb_SiteIntro,pb_ImgUrl,pb_ImgWidth,pb_ImgHeight,pb_IsFlash,pb_IsSelected,pb_ADSetting,pb_ADDTime,pb_ENDTime,pb_PeakC1,pb_PeakC2,pb_PeakCount,pb_sPeakNum,pb_ADBSType,pb_Priority,pb_SameIP,pb_Today,pb_TDCount,pb_ALLCount,pbs_TDCount,pbs_ALLCount,CountID,PlaceName)");
            strSql.Append(" values (");
            strSql.Append("@pb_SiteName,@pb_SiteUrl,@pb_SiteIntro,@pb_ImgUrl,@pb_ImgWidth,@pb_ImgHeight,@pb_IsFlash,@pb_IsSelected,@pb_ADSetting,@pb_ADDTime,@pb_ENDTime,@pb_PeakC1,@pb_PeakC2,@pb_PeakCount,@pb_sPeakNum,@pb_ADBSType,@pb_Priority,@pb_SameIP,@pb_Today,@pb_TDCount,@pb_ALLCount,@pbs_TDCount,@pbs_ALLCount,@CountID,@PlaceName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pb_SiteName", SqlDbType.NVarChar,200),
					new SqlParameter("@pb_SiteUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_SiteIntro", SqlDbType.Text),
					new SqlParameter("@pb_ImgUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_ImgWidth", SqlDbType.Int,4),
					new SqlParameter("@pb_ImgHeight", SqlDbType.Int,4),
					new SqlParameter("@pb_IsFlash", SqlDbType.Bit,1),
					new SqlParameter("@pb_IsSelected", SqlDbType.Bit,1),
					new SqlParameter("@pb_ADSetting", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_ADDTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_ENDTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_PeakC1", SqlDbType.Int,4),
					new SqlParameter("@pb_PeakC2", SqlDbType.Int,4),
					new SqlParameter("@pb_PeakCount", SqlDbType.Int,4),
					new SqlParameter("@pb_sPeakNum", SqlDbType.Int,4),
					new SqlParameter("@pb_ADBSType", SqlDbType.Bit,1),
					new SqlParameter("@pb_Priority", SqlDbType.Int,4),
					new SqlParameter("@pb_SameIP", SqlDbType.Int,4),
					new SqlParameter("@pb_Today", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_TDCount", SqlDbType.Int,4),
					new SqlParameter("@pb_ALLCount", SqlDbType.Int,4),
					new SqlParameter("@pbs_TDCount", SqlDbType.Int,4),
					new SqlParameter("@pbs_ALLCount", SqlDbType.Int,4),
					new SqlParameter("@CountID", SqlDbType.Int,4),
					new SqlParameter("@PlaceName", SqlDbType.VarChar,200)};
            parameters[0].Value = model.pb_SiteName;
            parameters[1].Value = model.pb_SiteUrl;
            parameters[2].Value = model.pb_SiteIntro;
            parameters[3].Value = model.pb_ImgUrl;
            parameters[4].Value = model.pb_ImgWidth;
            parameters[5].Value = model.pb_ImgHeight;
            parameters[6].Value = model.pb_IsFlash;
            parameters[7].Value = model.pb_IsSelected;
            parameters[8].Value = model.pb_ADSetting;
            parameters[9].Value = model.pb_ADDTime;
            parameters[10].Value = model.pb_ENDTime;
            parameters[11].Value = model.pb_PeakC1;
            parameters[12].Value = model.pb_PeakC2;
            parameters[13].Value = model.pb_PeakCount;
            parameters[14].Value = model.pb_sPeakNum;
            parameters[15].Value = model.pb_ADBSType;
            parameters[16].Value = model.pb_Priority;
            parameters[17].Value = model.pb_SameIP;
            parameters[18].Value = model.pb_Today;
            parameters[19].Value = model.pb_TDCount;
            parameters[20].Value = model.pb_ALLCount;
            parameters[21].Value = model.pbs_TDCount;
            parameters[22].Value = model.pbs_ALLCount;
            parameters[23].Value = model.CountID;
            parameters[24].Value = model.PlaceName;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.PBnet_Adv model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_Adv set ");
            strSql.Append("pb_SiteName=@pb_SiteName,");
            strSql.Append("pb_SiteUrl=@pb_SiteUrl,");
            strSql.Append("pb_SiteIntro=@pb_SiteIntro,");
            strSql.Append("pb_ImgUrl=@pb_ImgUrl,");
            strSql.Append("pb_ImgWidth=@pb_ImgWidth,");
            strSql.Append("pb_ImgHeight=@pb_ImgHeight,");
            strSql.Append("pb_IsFlash=@pb_IsFlash,");
            strSql.Append("pb_IsSelected=@pb_IsSelected,");
            strSql.Append("pb_ADSetting=@pb_ADSetting,");
            strSql.Append("pb_ADDTime=@pb_ADDTime,");
            strSql.Append("pb_ENDTime=@pb_ENDTime,");
            strSql.Append("pb_PeakC1=@pb_PeakC1,");
            strSql.Append("pb_PeakC2=@pb_PeakC2,");
            strSql.Append("pb_PeakCount=@pb_PeakCount,");
            strSql.Append("pb_sPeakNum=@pb_sPeakNum,");
            strSql.Append("pb_ADBSType=@pb_ADBSType,");
            strSql.Append("pb_Priority=@pb_Priority,");
            strSql.Append("pb_SameIP=@pb_SameIP,");
            strSql.Append("pb_Today=@pb_Today,");
            strSql.Append("pb_TDCount=@pb_TDCount,");
            strSql.Append("pb_ALLCount=@pb_ALLCount,");
            strSql.Append("pbs_TDCount=@pbs_TDCount,");
            strSql.Append("pbs_ALLCount=@pbs_ALLCount,");
            strSql.Append("CountID=@CountID,");
            strSql.Append("PlaceName=@PlaceName");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt,8),
					new SqlParameter("@pb_SiteName", SqlDbType.NVarChar,200),
					new SqlParameter("@pb_SiteUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_SiteIntro", SqlDbType.Text),
					new SqlParameter("@pb_ImgUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_ImgWidth", SqlDbType.Int,4),
					new SqlParameter("@pb_ImgHeight", SqlDbType.Int,4),
					new SqlParameter("@pb_IsFlash", SqlDbType.Bit,1),
					new SqlParameter("@pb_IsSelected", SqlDbType.Bit,1),
					new SqlParameter("@pb_ADSetting", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_ADDTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_ENDTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_PeakC1", SqlDbType.Int,4),
					new SqlParameter("@pb_PeakC2", SqlDbType.Int,4),
					new SqlParameter("@pb_PeakCount", SqlDbType.Int,4),
					new SqlParameter("@pb_sPeakNum", SqlDbType.Int,4),
					new SqlParameter("@pb_ADBSType", SqlDbType.Bit,1),
					new SqlParameter("@pb_Priority", SqlDbType.Int,4),
					new SqlParameter("@pb_SameIP", SqlDbType.Int,4),
					new SqlParameter("@pb_Today", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_TDCount", SqlDbType.Int,4),
					new SqlParameter("@pb_ALLCount", SqlDbType.Int,4),
					new SqlParameter("@pbs_TDCount", SqlDbType.Int,4),
					new SqlParameter("@pbs_ALLCount", SqlDbType.Int,4),
					new SqlParameter("@CountID", SqlDbType.Int,4),
					new SqlParameter("@PlaceName", SqlDbType.VarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.pb_SiteName;
            parameters[2].Value = model.pb_SiteUrl;
            parameters[3].Value = model.pb_SiteIntro;
            parameters[4].Value = model.pb_ImgUrl;
            parameters[5].Value = model.pb_ImgWidth;
            parameters[6].Value = model.pb_ImgHeight;
            parameters[7].Value = model.pb_IsFlash;
            parameters[8].Value = model.pb_IsSelected;
            parameters[9].Value = model.pb_ADSetting;
            parameters[10].Value = model.pb_ADDTime;
            parameters[11].Value = model.pb_ENDTime;
            parameters[12].Value = model.pb_PeakC1;
            parameters[13].Value = model.pb_PeakC2;
            parameters[14].Value = model.pb_PeakCount;
            parameters[15].Value = model.pb_sPeakNum;
            parameters[16].Value = model.pb_ADBSType;
            parameters[17].Value = model.pb_Priority;
            parameters[18].Value = model.pb_SameIP;
            parameters[19].Value = model.pb_Today;
            parameters[20].Value = model.pb_TDCount;
            parameters[21].Value = model.pb_ALLCount;
            parameters[22].Value = model.pbs_TDCount;
            parameters[23].Value = model.pbs_ALLCount;
            parameters[24].Value = model.CountID;
            parameters[25].Value = model.PlaceName;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_Adv ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

          return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Adv GetModel(long ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,pb_SiteName,pb_SiteUrl,pb_SiteIntro,pb_ImgUrl,pb_ImgWidth,pb_ImgHeight,pb_IsFlash,pb_IsSelected,pb_ADSetting,pb_ADDTime,pb_ENDTime,pb_PeakC1,pb_PeakC2,pb_PeakCount,pb_sPeakNum,pb_ADBSType,pb_Priority,pb_SameIP,pb_Today,pb_TDCount,pb_ALLCount,pbs_TDCount,pbs_ALLCount,CountID,PlaceName from PBnet_Adv ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.BigInt)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_Adv model = new Pbzx.Model.PBnet_Adv();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.pb_SiteName = ds.Tables[0].Rows[0]["pb_SiteName"].ToString();
                model.pb_SiteUrl = ds.Tables[0].Rows[0]["pb_SiteUrl"].ToString();
                model.pb_SiteIntro = ds.Tables[0].Rows[0]["pb_SiteIntro"].ToString();
                model.pb_ImgUrl = ds.Tables[0].Rows[0]["pb_ImgUrl"].ToString();
                if (ds.Tables[0].Rows[0]["pb_ImgWidth"].ToString() != "")
                {
                    model.pb_ImgWidth = int.Parse(ds.Tables[0].Rows[0]["pb_ImgWidth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_ImgHeight"].ToString() != "")
                {
                    model.pb_ImgHeight = int.Parse(ds.Tables[0].Rows[0]["pb_ImgHeight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_IsFlash"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["pb_IsFlash"].ToString() == "1") || (ds.Tables[0].Rows[0]["pb_IsFlash"].ToString().ToLower() == "true"))
                    {
                        model.pb_IsFlash = true;
                    }
                    else
                    {
                        model.pb_IsFlash = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["pb_IsSelected"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["pb_IsSelected"].ToString() == "1") || (ds.Tables[0].Rows[0]["pb_IsSelected"].ToString().ToLower() == "true"))
                    {
                        model.pb_IsSelected = true;
                    }
                    else
                    {
                        model.pb_IsSelected = false;
                    }
                }
                model.pb_ADSetting = ds.Tables[0].Rows[0]["pb_ADSetting"].ToString();
                if (ds.Tables[0].Rows[0]["pb_ADDTime"].ToString() != "")
                {
                    model.pb_ADDTime = DateTime.Parse(ds.Tables[0].Rows[0]["pb_ADDTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_ENDTime"].ToString() != "")
                {
                    model.pb_ENDTime = DateTime.Parse(ds.Tables[0].Rows[0]["pb_ENDTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_PeakC1"].ToString() != "")
                {
                    model.pb_PeakC1 = int.Parse(ds.Tables[0].Rows[0]["pb_PeakC1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_PeakC2"].ToString() != "")
                {
                    model.pb_PeakC2 = int.Parse(ds.Tables[0].Rows[0]["pb_PeakC2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_PeakCount"].ToString() != "")
                {
                    model.pb_PeakCount = int.Parse(ds.Tables[0].Rows[0]["pb_PeakCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_sPeakNum"].ToString() != "")
                {
                    model.pb_sPeakNum = int.Parse(ds.Tables[0].Rows[0]["pb_sPeakNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_ADBSType"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["pb_ADBSType"].ToString() == "1") || (ds.Tables[0].Rows[0]["pb_ADBSType"].ToString().ToLower() == "true"))
                    {
                        model.pb_ADBSType = true;
                    }
                    else
                    {
                        model.pb_ADBSType = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["pb_Priority"].ToString() != "")
                {
                    model.pb_Priority = int.Parse(ds.Tables[0].Rows[0]["pb_Priority"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_SameIP"].ToString() != "")
                {
                    model.pb_SameIP = int.Parse(ds.Tables[0].Rows[0]["pb_SameIP"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_Today"].ToString() != "")
                {
                    model.pb_Today = DateTime.Parse(ds.Tables[0].Rows[0]["pb_Today"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_TDCount"].ToString() != "")
                {
                    model.pb_TDCount = int.Parse(ds.Tables[0].Rows[0]["pb_TDCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_ALLCount"].ToString() != "")
                {
                    model.pb_ALLCount = int.Parse(ds.Tables[0].Rows[0]["pb_ALLCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pbs_TDCount"].ToString() != "")
                {
                    model.pbs_TDCount = int.Parse(ds.Tables[0].Rows[0]["pbs_TDCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pbs_ALLCount"].ToString() != "")
                {
                    model.pbs_ALLCount = int.Parse(ds.Tables[0].Rows[0]["pbs_ALLCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CountID"].ToString() != "")
                {
                    model.CountID = int.Parse(ds.Tables[0].Rows[0]["CountID"].ToString());
                }
                model.PlaceName = ds.Tables[0].Rows[0]["PlaceName"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,pb_SiteName,pb_SiteUrl,pb_SiteIntro,pb_ImgUrl,pb_ImgWidth,pb_ImgHeight,pb_IsFlash,pb_IsSelected,pb_ADSetting,pb_ADDTime,pb_ENDTime,pb_PeakC1,pb_PeakC2,pb_PeakCount,pb_sPeakNum,pb_ADBSType,pb_Priority,pb_SameIP,pb_Today,pb_TDCount,pb_ALLCount,pbs_TDCount,pbs_ALLCount,CountID,PlaceName ");
            strSql.Append(" FROM PBnet_Adv ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,pb_SiteName,pb_SiteUrl,pb_SiteIntro,pb_ImgUrl,pb_ImgWidth,pb_ImgHeight,pb_IsFlash,pb_IsSelected,pb_ADSetting,pb_ADDTime,pb_ENDTime,pb_PeakC1,pb_PeakC2,pb_PeakCount,pb_sPeakNum,pb_ADBSType,pb_Priority,pb_SameIP,pb_Today,pb_TDCount,pb_ALLCount,pbs_TDCount,pbs_ALLCount,CountID,PlaceName ");
            strSql.Append(" FROM PBnet_Adv ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "PBnet_Adv";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        public int ExecuteBySql(string sql)
        {
            return DbHelperSQL.ExecuteSql(sql);
           
        }
	}
}

