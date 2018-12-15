using System;

namespace GenFuncLib
{
	public partial class GenFunc
	{
		/// <summary>
		///
		/// </summary>
		/// <param name="dataArray"></param>
		/// <param name="packageByteCount"></param>
		/// <param name="fillByte"></param>
		/// <returns></returns>
		public static byte[][] GenFuncPackageDate(byte[] bufVal, int packageSize, byte defVal = 0xFF)
		{
			byte[][] _return = null;
			int i = 0;
			int packageCount = 0;
			int byteCount = 0;

			//---判断数据包是否为偶数
			if (((packageSize&0x01)!=0))
			{
				packageSize-=1;
			}

			//---数据分包处理
			if ((bufVal!=null)&&(bufVal.Length>0))
			{
				//---计算分包总数
				packageCount=bufVal.Length/packageSize;

				//---不满一包的按满包处理
				if ((bufVal.Length%packageSize)!=0)
				{
					packageCount+=1;
				}

				//---申请缓存区
				_return=new byte[packageCount][];

				//---分包处理
				for (i=0 ; i<packageCount ; i++)
				{
					//---计算当前数据包的字节字数
					byteCount=((bufVal.Length-i*packageSize)>packageSize) ? packageSize : (bufVal.Length-i*packageSize);

					//---保证分包数据量必须是偶数
					if ((byteCount&0x01)!=0)
					{
						byteCount+=1;
					}

					//构建分包数据,并处理奇数字节的数据包
					_return[i]=new byte[byteCount];

					//---填充默认值
					_return[i][byteCount-1]=defVal;

					//---拷贝数据
					Array.Copy(bufVal, i*packageSize, _return[i], 0, byteCount);
				}
			}
			return _return;
		}
	}
}