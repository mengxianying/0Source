using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_AdvPlace。
    /// </summary>
    public class PBnet_AdvPlace : IPBnet_AdvPlace
    {
        public PBnet_AdvPlace()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_AdvPlace");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_AdvPlace model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_AdvPlace(");
            strSql.Append("PlaceName,TypeID,ChannelID,PlaceHeight,PlaceWidth,PlacePosition,PlaceType)");
            strSql.Append(" values (");
            strSql.Append("@PlaceName,@TypeID,@ChannelID,@PlaceHeight,@PlaceWidth,@PlacePosition,@PlaceType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PlaceName", SqlDbType.NVarChar,200),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@PlaceHeight", SqlDbType.Int,4),
					new SqlParameter("@PlaceWidth", SqlDbType.Int,4),
					new SqlParameter("@PlacePosition", SqlDbType.VarChar,20),
					new SqlParameter("@PlaceType", SqlDbType.VarChar,200)};
            parameters[0].Value = model.PlaceName;
            parameters[1].Value = model.TypeID;
            parameters[2].Value = model.ChannelID;
            parameters[3].Value = model.PlaceHeight;
            parameters[4].Value = model.PlaceWidth;
            parameters[5].Value = model.PlacePosition;
            parameters[6].Value = model.PlaceType;

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
        public int Update(Pbzx.Model.PBnet_AdvPlace model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_AdvPlace set ");
            strSql.Append("PlaceName=@PlaceName,");
            strSql.Append("PlaceHeight=@PlaceHeight,");
            strSql.Append("PlaceWidth=@PlaceWidth,");
            strSql.Append("PlacePosition=@PlacePosition,");
            strSql.Append("PlaceType=@PlaceType");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@PlaceName", SqlDbType.NVarChar,200),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@PlaceHeight", SqlDbType.Int,4),
					new SqlParameter("@PlaceWidth", SqlDbType.Int,4),
					new SqlParameter("@PlacePosition", SqlDbType.VarChar,20),
					new SqlParameter("@PlaceType", SqlDbType.VarChar,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.PlaceName;
            parameters[2].Value = model.TypeID;
            parameters[3].Value = model.ChannelID;
            parameters[4].Value = model.PlaceHeight;
            parameters[5].Value = model.PlaceWidth;
            parameters[6].Value = model.PlacePosition;
            parameters[7].Value = model.PlaceType;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_AdvPlace ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_AdvPlace GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,PlaceName,TypeID,ChannelID,PlaceHeight,PlaceWidth,PlacePosition,PlaceType from PBnet_AdvPlace ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_AdvPlace model = new Pbzx.Model.PBnet_AdvPlace();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.PlaceName = ds.Tables[0].Rows[0]["PlaceName"].ToString();
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ChannelID"].ToString() != "")
                {
                    model.ChannelID = int.Parse(ds.Tables[0].Rows[0]["ChannelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PlaceHeight"].ToString() != "")
                {
                    model.PlaceHeight = int.Parse(ds.Tables[0].Rows[0]["PlaceHeight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PlaceWidth"].ToString() != "")
                {
                    model.PlaceWidth = int.Parse(ds.Tables[0].Rows[0]["PlaceWidth"].ToString());
                }
                model.PlacePosition = ds.Tables[0].Rows[0]["PlacePosition"].ToString();

                    model.PlaceType = ds.Tables[0].Rows[0]["PlaceType"].ToString();
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
            strSql.Append("select ID,PlaceName,TypeID,ChannelID,PlaceHeight,PlaceWidth,PlacePosition,PlaceType ");
            strSql.Append(" FROM PBnet_AdvPlace ");
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
            strSql.Append(" ID,PlaceName,TypeID,ChannelID,PlaceHeight,PlaceWidth,PlacePosition,PlaceType ");
            strSql.Append(" FROM PBnet_AdvPlace ");
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
            parameters[0].Value = "PBnet_AdvPlace";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

