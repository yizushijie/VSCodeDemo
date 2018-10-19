namespace GenFuncLib
{
	public partial class GenFunc
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="res"></param>
		/// <param name="val"></param>
		public void GenFuncMemset(ref byte[] res,int length, byte val = 0xFF)
		{
			res=new byte[length];
			int i = 0;
			for (i=0;i<length;i++)
			{
				res[i] = val;
			}
		}
	}
}