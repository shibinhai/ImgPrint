using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Util;
using Model;
namespace Dal
{
	/// <summary>
	/// 数据访问类:ImgInfo
	/// </summary>
	public partial class ImgInfoDal
	{
		public ImgInfoDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ImgInfo");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ImgInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ImgInfo(");
			strSql.Append("name,guige,changjia,pihao,createtime,url,beizhu)");
			strSql.Append(" values (");
			strSql.Append("@name,@guige,@changjia,@pihao,@createtime,@url,@beizhu)");
			SqlParameter[] parameters = {
					new SqlParameter("@name", model.name),
					new SqlParameter("@guige", model.guige),
					new SqlParameter("@changjia",model.changjia),
					new SqlParameter("@pihao", model.pihao),
					new SqlParameter("@createtime", model.createtime),
					new SqlParameter("@url", model.url),
					new SqlParameter("@beizhu", model.beizhu)
                                        };
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
		public bool Update(ImgInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ImgInfo set ");
			strSql.Append("name=@name,");
			strSql.Append("guige=@guige,");
			strSql.Append("changjia=@changjia,");
			strSql.Append("pihao=@pihao,");
			strSql.Append("createtime=@createtime,");
			strSql.Append("url=@url,");
			strSql.Append("beizhu=@beizhu");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
						new SqlParameter("@name", model.name),
					new SqlParameter("@guige", model.guige),
					new SqlParameter("@changjia",model.changjia),
					new SqlParameter("@pihao", model.pihao),
					new SqlParameter("@createtime", model.createtime),
					new SqlParameter("@url", model.url),
					new SqlParameter("@beizhu", model.beizhu),
					new SqlParameter("@id",model.id)
                                        };

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
			strSql.Append("delete from ImgInfo ");
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
			strSql.Append("delete from ImgInfo ");
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
		public ImgInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,name,guige,changjia,pihao,createtime,url,beizhu from ImgInfo ");
			strSql.Append(" where id=@id ");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)			};
			parameters[0].Value = id;

			ImgInfo model=new ImgInfo();
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
		public ImgInfo DataRowToModel(DataRow row)
		{
			ImgInfo model=new ImgInfo();
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
				if(row["guige"]!=null)
				{
					model.guige=row["guige"].ToString();
				}
				if(row["changjia"]!=null)
				{
					model.changjia=row["changjia"].ToString();
				}
				if(row["pihao"]!=null)
				{
					model.pihao=row["pihao"].ToString();
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["url"]!=null)
				{
					model.url=row["url"].ToString();
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
			strSql.Append("select id,name,guige,changjia,pihao,createtime,url,beizhu ");
			strSql.Append(" FROM ImgInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			strSql.Append(" id,name,guige,changjia,pihao,createtime,url,beizhu ");
			strSql.Append(" FROM ImgInfo ");
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
			strSql.Append("select count(1) FROM ImgInfo ");
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
            strSql.Append("SELECT Row,id, name, guige, changjia, pihao, Convert(varchar(10),createtime,120)createtime, beizhu, url FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from ImgInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex * endIndex - (endIndex - 1), startIndex * endIndex);
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
			parameters[0].Value = "ImgInfo";
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

