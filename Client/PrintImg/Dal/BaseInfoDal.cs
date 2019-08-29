using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Util;
using Model;

namespace Dal
{
	/// <summary>
	/// 数据访问类:BaseInfo
	/// </summary>
	public partial class BaseInfoDal
	{
		public BaseInfoDal()
		{}
		#region  BasicMethod

		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BaseInfo");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BaseInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BaseInfo(");
			strSql.Append("name,pinyin,guige,changjia,beizhu)");
			strSql.Append(" values (");
			strSql.Append("@name,@pinyin,@guige,@changjia,@beizhu)");
			SqlParameter[] parameters = {
					new SqlParameter("@name",model.name),
					new SqlParameter("@pinyin", model.pinyin),
					new SqlParameter("@guige", model.guige),
					new SqlParameter("@changjia", model.changjia),
					new SqlParameter("@beizhu", model.beizhu)};

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(BaseInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BaseInfo set ");
			strSql.Append("name=@name,");
			strSql.Append("pinyin=@pinyin,");
			strSql.Append("guige=@guige,");
			strSql.Append("changjia=@changjia,");
			strSql.Append("beizhu=@beizhu");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@pinyin", SqlDbType.NVarChar,50),
					new SqlParameter("@guige", SqlDbType.NVarChar,50),
					new SqlParameter("@changjia", SqlDbType.NVarChar,200),
					new SqlParameter("@beizhu", SqlDbType.NVarChar,200),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.pinyin;
			parameters[2].Value = model.guige;
			parameters[3].Value = model.changjia;
			parameters[4].Value = model.beizhu;
			parameters[5].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BaseInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BaseInfo ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public BaseInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,pinyin,guige,changjia,beizhu from BaseInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			BaseInfoDal model=new BaseInfoDal();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public BaseInfo DataRowToModel(DataRow row)
		{
			BaseInfo model=new BaseInfo();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["pinyin"]!=null)
				{
					model.pinyin=row["pinyin"].ToString();
				}
				if(row["guige"]!=null)
				{
					model.guige=row["guige"].ToString();
				}
				if(row["changjia"]!=null)
				{
					model.changjia=row["changjia"].ToString();
				}
				if(row["beizhu"]!=null)
				{
					model.beizhu=row["beizhu"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,name,pinyin,guige,changjia,beizhu ");
			strSql.Append(" FROM BaseInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,name+'-['+LEFT(changjia,6)+']'+'-['+LEFT(guige,10)+']' as name,pinyin,guige,changjia,beizhu ");
            strSql.Append(" FROM BaseInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,name,pinyin,guige,changjia,beizhu ");
			strSql.Append(" FROM BaseInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BaseInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT Row,id, name, pinyin, guige, changjia, beizhu, Convert(varchar(10),createtime,120)createtime FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from BaseInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", (startIndex * endIndex - (endIndex - 1)), startIndex * endIndex);  10
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", (startIndex * endIndex - (endIndex - 1)), startIndex * endIndex);
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
			parameters[0].Value = "BaseInfo";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

