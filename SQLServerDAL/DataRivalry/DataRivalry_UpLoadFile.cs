using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.Model;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类DataRivalry_UpLoadFile。
    /// </summary>
    public class DataRivalry_UpLoadFile : IDataRivalry_UpLoadFile
    {
        public DataRivalry_UpLoadFile()
        { }

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("F_drID", "DataRivalry_UpLoadFile");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int F_drID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DataRivalry_UpLoadFile");
            strSql.Append(" where F_drID= @F_drID");
            SqlParameter[] parameters = {
					new SqlParameter("@F_drID", SqlDbType.Int,4)
				};
            parameters[0].Value = F_drID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserName, string FileName, int FileSize)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DataRivalry_UpLoadFile");
            strSql.Append(" where F_username= @UserName and F_FileName=@FileName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@FileName",SqlDbType.NVarChar,100),
                    new SqlParameter("@FileSize", SqlDbType.Int,4)
				};
            parameters[0].Value = UserName;
            parameters[1].Value = FileName;
            parameters[2].Value = FileSize;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_UpLoadFile model)
        {
            model.F_drID = GetMaxId();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DataRivalry_UpLoadFile(");
            strSql.Append("F_drID,F_Period,F_UserName,F_FileName,F_FileType,F_FileSize,F_FileNum,F_CreateName,F_SingleGroup,F_addTime,F_lottery,F_state)");
            strSql.Append(" values (");
            strSql.Append("@F_drID,@F_Period,@F_UserName,@F_FileName,@F_FileType,@F_FileSize,@F_FileNum,@F_CreateName,@F_SingleGroup,@F_addTime,@F_lottery,@F_state)");
            SqlParameter[] parameters = {
					new SqlParameter("@F_drID", SqlDbType.Int,4),
					new SqlParameter("@F_Period", SqlDbType.Int,4),
					new SqlParameter("@F_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FileName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FileType", SqlDbType.NVarChar,10),
					new SqlParameter("@F_FileSize", SqlDbType.Int,4),
					new SqlParameter("@F_FileNum", SqlDbType.Int,4),
					new SqlParameter("@F_CreateName", SqlDbType.NVarChar,200),
					new SqlParameter("@F_SingleGroup", SqlDbType.Int,4),
					new SqlParameter("@F_addTime", SqlDbType.DateTime),
					new SqlParameter("@F_lottery", SqlDbType.Int,4),
					new SqlParameter("@F_state", SqlDbType.Int,4)};
            parameters[0].Value = model.F_drID;
            parameters[1].Value = model.F_Period;
            parameters[2].Value = model.F_UserName;
            parameters[3].Value = model.F_FileName;
            parameters[4].Value = model.F_FileType;
            parameters[5].Value = model.F_FileSize;
            parameters[6].Value = model.F_FileNum;
            parameters[7].Value = model.F_CreateName;
            parameters[8].Value = model.F_SingleGroup;
            parameters[9].Value = model.F_addTime;
            parameters[10].Value = model.F_lottery;
            parameters[11].Value = model.F_state;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return model.F_drID;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_UpLoadFile model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DataRivalry_UpLoadFile set ");
            strSql.Append("F_Period=@F_Period,");
            strSql.Append("F_UserName=@F_UserName,");
            strSql.Append("F_FileName=@F_FileName,");
            strSql.Append("F_FileType=@F_FileType,");
            strSql.Append("F_FileSize=@F_FileSize,");
            strSql.Append("F_FileNum=@F_FileNum,");
            strSql.Append("F_CreateName=@F_CreateName,");
            strSql.Append("F_SingleGroup=@F_SingleGroup,");
            strSql.Append("F_addTime=@F_addTime,");
            strSql.Append("F_lottery=@F_lottery,");
            strSql.Append("F_state=@F_state");
            strSql.Append(" where F_drID=@F_drID ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_Period", SqlDbType.Int,4),
					new SqlParameter("@F_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FileName", SqlDbType.NVarChar,50),
					new SqlParameter("@F_FileType", SqlDbType.NVarChar,10),
					new SqlParameter("@F_FileSize", SqlDbType.Int,4),
					new SqlParameter("@F_FileNum", SqlDbType.Int,4),
					new SqlParameter("@F_CreateName", SqlDbType.NVarChar,200),
					new SqlParameter("@F_SingleGroup", SqlDbType.Int,4),
					new SqlParameter("@F_addTime", SqlDbType.DateTime),
					new SqlParameter("@F_lottery", SqlDbType.Int,4),
					new SqlParameter("@F_state", SqlDbType.Int,4),
					new SqlParameter("@F_drID", SqlDbType.Int,4)};
            parameters[0].Value = model.F_Period;
            parameters[1].Value = model.F_UserName;
            parameters[2].Value = model.F_FileName;
            parameters[3].Value = model.F_FileType;
            parameters[4].Value = model.F_FileSize;
            parameters[5].Value = model.F_FileNum;
            parameters[6].Value = model.F_CreateName;
            parameters[7].Value = model.F_SingleGroup;
            parameters[8].Value = model.F_addTime;
            parameters[9].Value = model.F_lottery;
            parameters[10].Value = model.F_state;
            parameters[11].Value = model.F_drID;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int F_drID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete DataRivalry_UpLoadFile ");
            strSql.Append(" where F_drID=@F_drID");
            SqlParameter[] parameters = {
					new SqlParameter("@F_drID", SqlDbType.Int,4)
				};
            parameters[0].Value = F_drID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.DataRivalry_UpLoadFile GetModel(int F_drID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_drID,F_Period,F_UserName,F_FileName,F_FileType,F_FileSize,F_FileNum,F_CreateName,F_SingleGroup,F_addTime,F_lottery,F_state from DataRivalry_UpLoadFile ");
            strSql.Append(" where F_drID=@F_drID ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_drID", SqlDbType.Int,4)};
            parameters[0].Value = F_drID;

            Pbzx.Model.DataRivalry_UpLoadFile model = new Pbzx.Model.DataRivalry_UpLoadFile();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["F_drID"].ToString() != "")
                {
                    model.F_drID = int.Parse(ds.Tables[0].Rows[0]["F_drID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["F_Period"].ToString() != "")
                {
                    model.F_Period = int.Parse(ds.Tables[0].Rows[0]["F_Period"].ToString());
                }
                if (ds.Tables[0].Rows[0]["F_UserName"] != null)
                {
                    model.F_UserName = ds.Tables[0].Rows[0]["F_UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["F_FileName"] != null)
                {
                    model.F_FileName = ds.Tables[0].Rows[0]["F_FileName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["F_FileType"] != null)
                {
                    model.F_FileType = ds.Tables[0].Rows[0]["F_FileType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["F_FileSize"].ToString() != "")
                {
                    model.F_FileSize = int.Parse(ds.Tables[0].Rows[0]["F_FileSize"].ToString());
                }
                if (ds.Tables[0].Rows[0]["F_FileNum"] != null)
                {
                    model.F_FileNum = int.Parse(ds.Tables[0].Rows[0]["F_FileNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["F_CreateName"] != null)
                {
                    model.F_CreateName = ds.Tables[0].Rows[0]["F_CreateName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["F_SingleGroup"].ToString() != "")
                {
                    model.F_SingleGroup = int.Parse(ds.Tables[0].Rows[0]["F_SingleGroup"].ToString());
                }
                if (ds.Tables[0].Rows[0]["F_addTime"].ToString() != "")
                {
                    model.F_addTime = DateTime.Parse(ds.Tables[0].Rows[0]["F_addTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["F_lottery"].ToString() != "")
                {
                    model.F_lottery = int.Parse(ds.Tables[0].Rows[0]["F_lottery"].ToString());
                }
                if (ds.Tables[0].Rows[0]["F_state"].ToString() != "")
                {
                    model.F_state = int.Parse(ds.Tables[0].Rows[0]["F_state"].ToString());
                }
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
            strSql.Append("select * from DataRivalry_UpLoadFile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by F_drID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListDesc(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from DataRivalry_UpLoadFile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by F_drID desc");
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListView(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_d_num ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by F_drID ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
