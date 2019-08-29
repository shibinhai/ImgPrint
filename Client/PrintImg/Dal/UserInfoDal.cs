using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Util;
using Model;
namespace Dal
{
    /// <summary>
    /// 数据访问类:UserInfo
    /// </summary>
    public partial class UserInfoDal
    {
        public UserInfoDal()
        { }
        #region  BasicMethod


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserInfo");
            if (!string.IsNullOrEmpty(username))
            {
                strSql.Append(" where username=@username");
            }
           
            SqlParameter[] parameters = {
					new SqlParameter("@username", username)};

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserInfo(");
            strSql.Append("username,userpwd,qx)");
            strSql.Append(" values (");
            strSql.Append("@username,@userpwd,@qx)");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@userpwd", SqlDbType.NVarChar,50),
					new SqlParameter("@qx", SqlDbType.NVarChar,50)};
          
            parameters[0].Value = model.username;
            parameters[1].Value = model.userpwd;
            parameters[2].Value = model.qx;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserInfo set ");
            strSql.Append("username=@username,");
            strSql.Append("userpwd=@userpwd,");
            strSql.Append("qx=@qx");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@userpwd", SqlDbType.NVarChar,50),
					new SqlParameter("@qx", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.username;
            parameters[1].Value = model.userpwd;
            parameters[2].Value = model.qx;
            parameters[3].Value = model.id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserInfo ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserInfo GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,username,userpwd,qx from UserInfo ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
            parameters[0].Value = id;

            UserInfo model = new UserInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserInfo DataRowToModel(DataRow row)
        {
            UserInfo model = new UserInfo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["username"] != null)
                {
                    model.username = row["username"].ToString();
                }
                if (row["userpwd"] != null)
                {
                    model.userpwd = row["userpwd"].ToString();
                }
                if (row["qx"] != null)
                {
                    model.qx = row["qx"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,username,userpwd,qx ");
            strSql.Append(" FROM UserInfo ");
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
            strSql.Append(" id,username,userpwd,qx ");
            strSql.Append(" FROM UserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM UserInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Row,id,username,userpwd,case qx when '0' then '普通用户' else '管理员' end as qx,Convert(varchar(10),createtime,120)createtime FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from UserInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex * endIndex - (endIndex - 1), startIndex * endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 验证用户名和密码是否正确
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <param name="qx"></param>
        /// <returns></returns>
        public bool IsLoginSucces(string username, string userpwd, string qx)
        {
            string sql = "SELECT COUNT(*) FROM dbo.UserInfo WHERE username=@username AND userpwd=@userpwd AND qx=@qx";
            SqlParameter[] sp = new SqlParameter[] { 
            new SqlParameter("@username",username),
            new SqlParameter("@userpwd",userpwd),
            new SqlParameter("@qx",qx)
            };
            if (DbHelperSQL.Exists(sql,sp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  BasicMethod
    }
}

