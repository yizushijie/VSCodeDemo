namespace GenFuncLib
{
	public partial class GenFunc
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="buffer"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public static bool GenFuncEqual(byte[] buf, byte val = 0xFF)
		{
			if ((buf == null))
			{
				return false;
			}
			for (int i = 0; i < buf.Length; i++)
			{
				if (buf[i] != val)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="b1"></param>
		/// <param name="b2"></param>
		/// <returns></returns>
		public static bool GenFuncEqual(byte[] buf1, byte[] buf2)
		{
			if ((buf1 != null) && (buf2 != null))
			{
				if (buf1.Length != buf2.Length)
				{
					return false;
				}
				for (int i = 0; i < buf1.Length; i++)
				{
					if (buf1[i] != buf2[i])
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
	}
}