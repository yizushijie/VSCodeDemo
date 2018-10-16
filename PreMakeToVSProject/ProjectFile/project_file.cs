using System.Collections.Generic;

namespace PreMakeToVSProject
{
	public class ProjectFile
	{
		#region 变量定义

		/// <summary>
		/// 名称
		/// </summary>
		public string _name;

		/// <summary>
		/// 不包含
		/// </summary>
		public List<string> _exclude;

		#endregion 变量定义

		#region 构造函数

		public ProjectFile()
		{
			this._name = string.Empty;
			this._exclude = new List<string>();
		}

		#endregion 构造函数
	}
}