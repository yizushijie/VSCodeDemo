using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileFuncLib
{
	/// <summary>
	/// TXT文件操作
	/// </summary>
	public class FileFuncTXT
    {
		#region 构造函数

		/// <summary>
		/// Initializes a new instance of the <see cref="FileFuncTXT"/> class.
		/// </summary>
		public FileFuncTXT()
		{

		}

		#endregion

		#region 函数定义


		/// <summary>
		/// Writes to text file.
		/// </summary>
		/// <param name="fileName">The path.</param>
		/// <param name="text">The text.</param>
		public void WriteToTxtFile(string fileName,string text,bool isNewLine=false)
		{
			string filePath = System.IO.Directory.GetCurrentDirectory() + fileName;
			FileStream fs = null;
			// 判断文件是否存在，不存在则创建
			if (!File.Exists(filePath))
			{
				///---创建文件
				fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			}
			else
			{
				//---打开文件
				fs = new FileStream(filePath, FileMode.Open, FileAccess.Write);
			}
			StreamWriter sr = new StreamWriter(fs);
			//---写入数据
			if (isNewLine)
			{
				sr.WriteLine(text);
			}
			else
			{
				sr.Write(text);
			}
			//---关闭文本
			sr.Close();
			//---关闭文件流
			fs.Close();
		}

		/// <summary>
		/// 从TXT文档的结尾写入
		/// </summary>
		/// <param name="fileName">The path.</param>
		/// <param name="text">The text.</param>
		public void WriteToTxtFileEnd(string fileName, string text,bool isNewLine=false)
		{
			string filePath = System.IO.Directory.GetCurrentDirectory() + fileName;
			FileStream fs = null;
			// 判断文件是否存在，不存在则创建
			if (!File.Exists(filePath))
			{
				///---创建文件
				fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
				//---关闭文件流
				fs.Close();
			}
			StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.Default);
			//---写入数据
			if (isNewLine)
			{
				sw.WriteLine(text);
			}
			else
			{
				sw.Write(text);
			}
			//---清空缓存区
			sw.Flush();
			//---关闭文本
			sw.Close();
			
		}

		#endregion
	}
}
