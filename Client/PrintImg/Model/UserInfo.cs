using System;
namespace Model
{
	/// <summary>
	/// UserInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserInfo
	{
		public UserInfo()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _userpwd;
		private string _qx;
        private DateTime? _createtime = DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userpwd
		{
			set{ _userpwd=value;}
			get{return _userpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qx
		{
			set{ _qx=value;}
			get{return _qx;}
		}

        /// <summary>
        /// 
        /// </summary>
        public DateTime? createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
		#endregion Model

	}
}

