using System;
namespace Model
{
	/// <summary>
	/// ImgInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ImgInfo
	{
		public ImgInfo()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _guige;
		private string _changjia;
		private string _pihao;
		private DateTime? _createtime= DateTime.Now;
        private string _url;
		private string _beizhu;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string guige
		{
			set{ _guige=value;}
			get{return _guige;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string changjia
		{
			set{ _changjia=value;}
			get{return _changjia;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pihao
		{
			set{ _pihao=value;}
			get{return _pihao;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string url
        {
            set { _url = value; }
            get { return _url; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string beizhu
		{
			set{ _beizhu=value;}
			get{return _beizhu;}
		}
		#endregion Model

	}
}

