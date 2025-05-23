using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类AgentInfo_Apply。
    /// </summary>
    public class AgentInfo_Apply : IAgentInfo_Apply
    {
        public AgentInfo_Apply()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AgentInfo_Apply");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.AgentInfo_Apply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AgentInfo_Apply(");
            strSql.Append("Password,Name,Company,Telephone,Fax,Mobile,EMail,PostCode,Province,Address,CreateDate,ExpireDate,Type,PricePercent,Status,Remark,delshow,countid,agtmore,postmore,agttype,UserName)");
            strSql.Append(" values (");
            strSql.Append("@Password,@Name,@Company,@Telephone,@Fax,@Mobile,@EMail,@PostCode,@Province,@Address,@CreateDate,@ExpireDate,@Type,@PricePercent,@Status,@Remark,@delshow,@countid,@agtmore,@postmore,@agttype,@UserName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Password", SqlDbType.NVarChar,32),
					new SqlParameter("@Name", SqlDbType.NVarChar,40),
					new SqlParameter("@Company", SqlDbType.NVarChar,128),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,32),
					new SqlParameter("@Fax", SqlDbType.NVarChar,32),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,32),
					new SqlParameter("@EMail", SqlDbType.NVarChar,64),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,8),
					new SqlParameter("@Province", SqlDbType.NVarChar,20),
					new SqlParameter("@Address", SqlDbType.NVarChar,128),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime),
					new SqlParameter("@Type", SqlDbType.TinyInt,1),
					new SqlParameter("@PricePercent", SqlDbType.TinyInt,1),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,1020),
					new SqlParameter("@delshow", SqlDbType.Bit,1),
					new SqlParameter("@countid", SqlDbType.Int,4),
					new SqlParameter("@agtmore", SqlDbType.NVarChar,510),
					new SqlParameter("@postmore", SqlDbType.NVarChar,64),
					new SqlParameter("@agttype", SqlDbType.NVarChar,20),
					new SqlParameter("@UserName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.Password;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Company;
            parameters[3].Value = model.Telephone;
            parameters[4].Value = model.Fax;
            parameters[5].Value = model.Mobile;
            parameters[6].Value = model.EMail;
            parameters[7].Value = model.PostCode;
            parameters[8].Value = model.Province;
            parameters[9].Value = model.Address;
            parameters[10].Value = model.CreateDate;
            parameters[11].Value = model.ExpireDate;
            parameters[12].Value = model.Type;
            parameters[13].Value = model.PricePercent;
            parameters[14].Value = model.Status;
            parameters[15].Value = model.Remark;
            parameters[16].Value = model.delshow;
            parameters[17].Value = model.countid;
            parameters[18].Value = model.agtmore;
            parameters[19].Value = model.postmore;
            parameters[20].Value = model.agttype;
            parameters[21].Value = model.UserName;

            object obj = DbHelperSQL1.GetSingle(strSql.ToString(), parameters);
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
        public int Update(Pbzx.Model.AgentInfo_Apply model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AgentInfo_Apply set ");
            strSql.Append("Password=@Password,");
            strSql.Append("Name=@Name,");
            strSql.Append("Telephone=@Telephone,");
            strSql.Append("Fax=@Fax,");
            strSql.Append("EMail=@EMail,");
            strSql.Append("PostCode=@PostCode,");
            strSql.Append("Province=@Province,");
            strSql.Append("Address=@Address,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("ExpireDate=@ExpireDate,");
            strSql.Append("Type=@Type,");
            strSql.Append("PricePercent=@PricePercent,");
            strSql.Append("Status=@Status,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("delshow=@delshow,");
            strSql.Append("countid=@countid,");
            strSql.Append("agtmore=@agtmore,");
            strSql.Append("postmore=@postmore,");
            strSql.Append("agttype=@agttype,");
            strSql.Append("UserName=@UserName");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Password", SqlDbType.NVarChar,32),
					new SqlParameter("@Name", SqlDbType.NVarChar,40),
					new SqlParameter("@Company", SqlDbType.NVarChar,128),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,32),
					new SqlParameter("@Fax", SqlDbType.NVarChar,32),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,32),
					new SqlParameter("@EMail", SqlDbType.NVarChar,64),
					new SqlParameter("@PostCode", SqlDbType.NVarChar,8),
					new SqlParameter("@Province", SqlDbType.NVarChar,20),
					new SqlParameter("@Address", SqlDbType.NVarChar,128),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@ExpireDate", SqlDbType.SmallDateTime),
					new SqlParameter("@Type", SqlDbType.TinyInt,1),
					new SqlParameter("@PricePercent", SqlDbType.TinyInt,1),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Remark", SqlDbType.NVarChar,1020),
					new SqlParameter("@delshow", SqlDbType.Bit,1),
					new SqlParameter("@countid", SqlDbType.Int,4),
					new SqlParameter("@agtmore", SqlDbType.NVarChar,510),
					new SqlParameter("@postmore", SqlDbType.NVarChar,64),
					new SqlParameter("@agttype", SqlDbType.NVarChar,20),
					new SqlParameter("@UserName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Company;
            parameters[4].Value = model.Telephone;
            parameters[5].Value = model.Fax;
            parameters[6].Value = model.Mobile;
            parameters[7].Value = model.EMail;
            parameters[8].Value = model.PostCode;
            parameters[9].Value = model.Province;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.CreateDate;
            parameters[12].Value = model.ExpireDate;
            parameters[13].Value = model.Type;
            parameters[14].Value = model.PricePercent;
            parameters[15].Value = model.Status;
            parameters[16].Value = model.Remark;
            parameters[17].Value = model.delshow;
            parameters[18].Value = model.countid;
            parameters[19].Value = model.agtmore;
            parameters[20].Value = model.postmore;
            parameters[21].Value = model.agttype;
            parameters[22].Value = model.UserName;

           return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AgentInfo_Apply ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

          return  DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.AgentInfo_Apply GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Password,Name,Company,Telephone,Fax,Mobile,EMail,PostCode,Province,Address,CreateDate,ExpireDate,Type,PricePercent,Status,Remark,delshow,countid,agtmore,postmore,agttype,UserName from AgentInfo_Apply ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.AgentInfo_Apply model = new Pbzx.Model.AgentInfo_Apply();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Company = ds.Tables[0].Rows[0]["Company"].ToString();
                model.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                model.Fax = ds.Tables[0].Rows[0]["Fax"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.EMail = ds.Tables[0].Rows[0]["EMail"].ToString();
                model.PostCode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                model.Province = ds.Tables[0].Rows[0]["Province"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ExpireDate"].ToString() != "")
                {
                    model.ExpireDate = DateTime.Parse(ds.Tables[0].Rows[0]["ExpireDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    model.Type = int.Parse(ds.Tables[0].Rows[0]["Type"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PricePercent"].ToString() != "")
                {
                    model.PricePercent = int.Parse(ds.Tables[0].Rows[0]["PricePercent"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["delshow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["delshow"].ToString() == "1") || (ds.Tables[0].Rows[0]["delshow"].ToString().ToLower() == "true"))
                    {
                        model.delshow = true;
                    }
                    else
                    {
                        model.delshow = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["countid"].ToString() != "")
                {
                    model.countid = int.Parse(ds.Tables[0].Rows[0]["countid"].ToString());
                }
                model.agtmore = ds.Tables[0].Rows[0]["agtmore"].ToString();
                model.postmore = ds.Tables[0].Rows[0]["postmore"].ToString();
                model.agttype = ds.Tables[0].Rows[0]["agttype"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
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
            strSql.Append("select ID,Password,Name,Company,Telephone,Fax,Mobile,EMail,PostCode,Province,Address,CreateDate,ExpireDate,Type,PricePercent,Status,Remark,delshow,countid,agtmore,postmore,agttype,UserName ");
            strSql.Append(" FROM AgentInfo_Apply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL1.Query(strSql.ToString());
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
            strSql.Append(" ID,Password,Name,Company,Telephone,Fax,Mobile,EMail,PostCode,Province,Address,CreateDate,ExpireDate,Type,PricePercent,Status,Remark,delshow,countid,agtmore,postmore,agttype,UserName ");
            strSql.Append(" FROM AgentInfo_Apply ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL1.Query(strSql.ToString());
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
            parameters[0].Value = "AgentInfo_Apply";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL1.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

