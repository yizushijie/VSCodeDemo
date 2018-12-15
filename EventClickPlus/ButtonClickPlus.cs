using System;
using System.Reflection;
using System.Windows.Forms;

namespace ControlClickPlusLib
{
	/// <summary>
	/// C# 调用一个按钮的Click事件,利用反射调用
	/// </summary>
	public partial class ButtonClickPlus
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="btn"></param>
		/// <param name="eventName"></param>
		public static void CallButtonClick(Button btn, string eventName)
		{
			//建立一个类型
			Type t = typeof(Button);

			//参数对象
			object[] p = new object[1];

			//产生方法
			MethodInfo m = t.GetMethod(eventName, BindingFlags.NonPublic|BindingFlags.Instance);

			//参数赋值。传入函数
			//获得参数资料
			ParameterInfo[] para = m.GetParameters();

			//根据参数的名字，拿参数的空值。
			p[0]=Type.GetType(para[0].ParameterType.BaseType.FullName).GetProperty("Empty");

			//调用
			m.Invoke(btn, p);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="eventName"></param>
		public static void CallButtonClick(Object obj, string eventName)
		{
			//---建立一个类型，AssemblyQualifiedName拿出有效的名字
			Type t = Type.GetType(obj.GetType().AssemblyQualifiedName);

			//---参数对象
			object[] p = new object[1];

			//---产生方法
			MethodInfo m = t.GetMethod(eventName, BindingFlags.NonPublic|BindingFlags.Instance);

			//--参数赋值。传入函数
			//--获得参数资料
			ParameterInfo[] para = m.GetParameters();

			//--根据参数的名字，拿参数的空值。
			p[0]=Type.GetType(para[0].ParameterType.BaseType.FullName).GetProperty("Empty");

			//调用
			m.Invoke(obj, p);
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="EventName"></param>
		/// <param name="e"></param>
		public static void CallButtonClick(Object obj, string EventName, EventArgs e = null)
		{
			//---建立一个类型
			Type t = Type.GetType(obj.GetType().AssemblyQualifiedName);

			//---产生方法
			MethodInfo m = t.GetMethod(EventName, BindingFlags.NonPublic|BindingFlags.Instance);

			//---参数赋值。传入函数 获得参数资料
			ParameterInfo[] para = m.GetParameters();

			//---根据参数的名字，拿参数的空值 参数对象
			object[] p = new object[1];
			if (e==null)
			{
				p[0]=Type.GetType(para[0].ParameterType.BaseType.FullName).GetProperty("Empty");
			}
			else
			{
				p[0]=e;
			}

			//---调用
			m.Invoke(obj, p);
		}
	}
}