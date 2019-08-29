using System;
using System.Data;
using System.Collections.Generic;
using Dal;
using Model;
namespace Bll
{
	/// <summary>
	/// UserInfo
	/// </summary>
	public partial class UserInfoBll
	{
        private readonly UserInfoDal dal = new UserInfoDal();
		public UserInfoBll()
		{}
		#region  BasicMethod

        /// <summary>
        /// 验证用户名和密码是否正确
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <param name="qx"></param>
        /// <returns></returns>
        public bool IsLoginSucces(string username, string userpwd, string qx)
        {
            return dal.IsLoginSucces(username,userpwd,qx);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string name)
        {
            return dal.Exists(name);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(UserInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserInfo GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<UserInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<UserInfo> DataTableToList(DataTable dt)
		{
			List<UserInfo> modelList = new List<UserInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				UserInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

