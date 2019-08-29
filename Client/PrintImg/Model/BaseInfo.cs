using System;
namespace Model
{
	/// <summary>
	/// BaseInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BaseInfo
	{
		public BaseInfo()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _pinyin;
		private string _guige;
		private string _changjia;
		private string _beizhu;
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
		/// 名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 简拼
		/// </summary>
		public string pinyin
		{
			set{ _pinyin=value;}
			get{return _pinyin;}
		}
		/// <summary>
		/// 规格
		/// </summary>
		public string guige
		{
			set{ _guige=value;}
			get{return _guige;}
		}
		/// <summary>
		/// 厂家
		/// </summary>
		public string changjia
		{
			set{ _changjia=value;}
			get{return _changjia;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string beizhu
		{
			set{ _beizhu=value;}
			get{return _beizhu;}
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

