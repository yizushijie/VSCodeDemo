using COMMPortLib;
using RichTextBoxPlusLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UserControlPlusLib;

namespace ClockWM8510Lib
{
    public enum CLOCKYSELCMD : byte
    {
        CMD_RFASK_CMD2_YSEL1_FREQ_SET	= 0x01,
        CMD_RFASK_CMD2_YSEL2_FREQ_SET	= 0x02,
        CMD_RFASK_CMD2_YSEL3_FREQ_SET	= 0x03,
        CMD_RFASK_CMD2_YSEL4_FREQ_SET	= 0x04,
        CMD_RFASK_CMD2_YSEL1_FREQ_GET	= 0x05,
        CMD_RFASK_CMD2_YSEL2_FREQ_GET	= 0x06,
        CMD_RFASK_CMD2_YSEL3_FREQ_GET	= 0x07,
        CMD_RFASK_CMD2_YSEL4_FREQ_GET	= 0x08,
        CMD_RFASK_CMD2_YSEL_FREQ_SET	= 0x09,
        CMD_RFASK_CMD2_YSEL_FREQ_GET	= 0x0A,
        CMD_RFASK_CMD2_YSEL1_FREQ_OUT   = 0x0B,
        CMD_RFASK_CMD2_YSEL2_FREQ_OUT   = 0x0C,
        CMD_RFASK_CMD2_YSEL3_FREQ_OUT   = 0x0D,
        CMD_RFASK_CMD2_YSEL4_FREQ_OUT   = 0x0E,


    }
    public partial class ClockWM8510
    {
        #region 变量定义
        /// <summary>
        /// 设置命令的主命令
        /// </summary>
        private const byte CMD_RFASK_CMD1_YSEL_FREQ = 0x02;
        #endregion

        #region 属性定义

        #endregion

        #region 构造函数

        #endregion

        #region 析构函数

        #endregion

        #region 重载函数

        #endregion

        #region 函数定义

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="freq"></param>
        /// <returns></returns>
        public virtual int PreFreqYSELSet(int index, int preFreqIndex, PreFreqControl freqControl, COMMPort usedPort, RichTextBox msg = null)
        {
            int _return = 0;
            switch (index)
            {
                case 1:
                    _return = this.PreFreqYSELGetFreq(preFreqIndex, freqControl, usedPort,msg);
                    break;
                case 2:
                    _return = this.PreFreqYSELSetFreq(preFreqIndex, freqControl, usedPort,msg);
                    break;
                default:
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "预设频率点操作不合法!\r\n", Color.Red, false);
                    }
                    _return = 1;
                    break;
            }
            return _return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="freq"></param>
        /// <returns></returns>
        public virtual int PreFreqYSELSetFreq(int preFreqIndex, PreFreqControl freqControl, COMMPort usedPort, RichTextBox msg = null)
        {
            if (usedPort == null)
            {
                if (msg != null)
                {
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
                }
                return 1;
            }
            if (freqControl==null)
            {
                if (msg != null)
                {
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "预设频率点的控件传递错误!\r\n", Color.Red, false);
                }
                return 2;
            }
            int _return = 0;
            byte[] cmd = new byte[] { CMD_RFASK_CMD1_YSEL_FREQ, 0, 0,0, 0,0 };
            int freq1 = 0;
            int freq2 = 0;
            int freq3 = 0;
            int freq4 = 0;
            string str = "";
            switch (preFreqIndex)
            {
                case 1:
                    freq1 = (int)(freqControl.m_PreFreqOne * 100);
                    cmd[1] = (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL1_FREQ_SET;
                    cmd[2] = (byte)(freq1 >> 24);
                    cmd[3] = (byte)(freq1 >> 16);
                    cmd[4] = (byte)(freq1 >> 8);
                    cmd[5] = (byte)(freq1);
                    str = "预设频率点1设置成功，频率是：" + freqControl.m_PreFreqOne.ToString()+"MHz"+ "!\r\n";
                    break;
                case 2:
                    freq2 = (int)(freqControl.m_PreFreqTwo * 100);
                    cmd[1] = (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL2_FREQ_SET;
                    cmd[2] = (byte)(freq2 >> 24);
                    cmd[3] = (byte)(freq2 >> 16);
                    cmd[4] = (byte)(freq2 >> 8);
                    cmd[5] = (byte)(freq2);
                    str = "预设频率点2设置成功，频率是：" + freqControl.m_PreFreqTwo.ToString() + "MHz" + "!\r\n";
                    break;
                case 3:
                    freq3 = (int)(freqControl.m_PreFreqThree * 100);
                    cmd[1] = (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL3_FREQ_SET;
                    cmd[2] = (byte)(freq3 >> 24);
                    cmd[3] = (byte)(freq3 >> 16);
                    cmd[4] = (byte)(freq3 >> 8);
                    cmd[5] = (byte)(freq3);

                    str = "预设频率点3设置成功，频率是：" + freqControl.m_PreFreqThree.ToString() + "MHz" + "!\r\n";
                    break; 
                case 4:
                    freq4 = (int)(freqControl.m_PreFreqFour * 100);
                    cmd[1] = (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL4_FREQ_SET;
                    cmd[2] = (byte)(freq4 >> 24);
                    cmd[3] = (byte)(freq4 >> 16);
                    cmd[4] = (byte)(freq4 >> 8);
                    cmd[5] = (byte)(freq4);

                    str = "预设频率点4设置成功，频率是：" + freqControl.m_PreFreqFour.ToString() + "MHz" + "!\r\n";
                    break;
                case 5:
                    freq1 = (int)(freqControl.m_PreFreqOne * 100);
                    freq2 = (int)(freqControl.m_PreFreqTwo * 100);
                    freq3 = (int)(freqControl.m_PreFreqThree * 100);
                    freq4 = (int)(freqControl.m_PreFreqFour * 100);
                    cmd = new byte[] { CMD_RFASK_CMD1_YSEL_FREQ , (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL_FREQ_SET,0,0,0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                    cmd[2] = (byte)(freq1 >> 24);
                    cmd[3] = (byte)(freq1 >> 16);
                    cmd[4] = (byte)(freq1 >> 8);
                    cmd[5] = (byte)(freq1);

                    cmd[6] = (byte)(freq2 >> 24);
                    cmd[7] = (byte)(freq2 >> 16);
                    cmd[8] = (byte)(freq2 >> 8);
                    cmd[9] = (byte)(freq2);

                    cmd[10] = (byte)(freq3 >> 24);
                    cmd[11] = (byte)(freq3 >> 16);
                    cmd[12] = (byte)(freq3 >> 8);
                    cmd[13] = (byte)(freq3);

                    cmd[14] = (byte)(freq4 >> 24);
                    cmd[15] = (byte)(freq4 >> 16);
                    cmd[16] = (byte)(freq4 >> 8);
                    cmd[17] = (byte)(freq4);

                    str = "预设频率点1设置成功，频率是：" + freqControl.m_PreFreqOne.ToString() + "MHz" + "!\r\n";
                    str += "预设频率点2设置成功，频率是：" + freqControl.m_PreFreqTwo.ToString() + "MHz" + "!\r\n";
                    str += "预设频率点3设置成功，频率是：" + freqControl.m_PreFreqThree.ToString() + "MHz" + "!\r\n";
                    str += "预设频率点4设置成功，频率是：" + freqControl.m_PreFreqFour.ToString() + "MHz" + "!\r\n";
                    break;
                case 6:
                    cmd = new byte[] { CMD_RFASK_CMD1_YSEL_FREQ, (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL1_FREQ_OUT};
                    str = "预设频率点1设置输出，频率是：" + freqControl.m_PreFreqOne.ToString() + "MHz" + "!\r\n";
                    break;
                case 7:
                    cmd = new byte[] { CMD_RFASK_CMD1_YSEL_FREQ, (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL2_FREQ_OUT };
                    str = "预设频率点2设置输出，频率是：" + freqControl.m_PreFreqTwo.ToString() + "MHz" + "!\r\n";
                    break;
                case 8:
                    cmd = new byte[] { CMD_RFASK_CMD1_YSEL_FREQ, (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL3_FREQ_OUT };
                    str = "预设频率点3设置输出，频率是：" + freqControl.m_PreFreqThree.ToString() + "MHz" + "!\r\n";
                    break;
                case 9:
                    cmd = new byte[] { CMD_RFASK_CMD1_YSEL_FREQ, (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL4_FREQ_OUT };
                    str = "预设频率点4设置输出，频率是：" + freqControl.m_PreFreqFour.ToString() + "MHz" + "!\r\n";
                    break;
                default:
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "预设频率点的信息传递错误!\r\n", Color.Red, false);
                    }
                    return 3;
            }
            byte[] res = null;
            //---将命令写入设备
            _return = usedPort.SendCmdAndReadResponse(cmd, ref res, 300);
            //---通信验证
            if ((_return == 0) && (usedPort.m_COMMBytesPassed == true) && (res[usedPort.m_COMMPortDataReadIndex + 1] == 0) && (res[usedPort.m_COMMPortDataReadIndex + 2] == cmd[1]))
            {
                if (msg != null)
                {
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "预设频率设置成功!\r\n" + str, Color.Black, false);
                }
            }
            else
            {
                if (_return != 0)
                {
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信发生错误!\r\n", Color.Red, false);
                    }
                }
                else if (usedPort.m_COMMBytesPassed == false)
                {
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "读取的数据格式不合法!\r\n", Color.Red, false);
                    }
                }
                else if (res[usedPort.m_COMMPortDataReadIndex + 1] != 0)
                {
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "数据返回的结果错误!\r\n", Color.Red, false);
                    }
                }
                else
                {
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信命令验证错误!\r\n", Color.Red, false);
                    }
                }
            }
            return _return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="freq"></param>
        /// <returns></returns>
        public virtual int PreFreqYSELGetFreq(int preFreqIndex, PreFreqControl freqControl, COMMPort usedPort, RichTextBox msg = null)
        {
            if (usedPort == null)
            {
                if (msg != null)
                {
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信端口初始化失败!\r\n", Color.Red, false);
                }
                return 1;
            }
            if (freqControl == null)
            {
                if (msg != null)
                {
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "预设频率点的控件传递错误!\r\n", Color.Red, false);
                }
                return 2;
            }
            int _return = 0;
            byte[] cmd = new byte[] { CMD_RFASK_CMD1_YSEL_FREQ, 0,};
            float freq1 = 0;
            float freq2 = 0;
            float freq3 = 0;
            float freq4 = 0;
            string str = "";
            switch (preFreqIndex)
            {
                case 1:
                    cmd[1] = (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL1_FREQ_GET;
                    break;
                case 2:
                    cmd[1] = (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL2_FREQ_GET;
                    break;
                case 3:
                    cmd[1] = (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL3_FREQ_GET;
                    break;
                case 4:
                    cmd[1] = (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL4_FREQ_GET;
                    break;
                case 5:
                    cmd[1] = (byte)CLOCKYSELCMD.CMD_RFASK_CMD2_YSEL_FREQ_GET;
                    break;
                default:
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "预设频率点的信息传递错误!\r\n", Color.Red, false);
                    }
                    return 3;
            }
            byte[] res = null;
            //---将命令写入设备
            _return = usedPort.SendCmdAndReadResponse(cmd, ref res, 300);
            //---通信验证
            if ((_return == 0) && (usedPort.m_COMMBytesPassed == true) && (res[usedPort.m_COMMPortDataReadIndex + 1] == 0) && (res[usedPort.m_COMMPortDataReadIndex + 2] == cmd[1]))
            {
                switch (preFreqIndex)
                {
                    case 1:
                        freq1 = res[usedPort.m_COMMPortDataReadIndex + 3];
                        freq1 = ((int)freq1<<8)+res[usedPort.m_COMMPortDataReadIndex + 4];
                        freq1 = ((int)freq1 << 8) + res[usedPort.m_COMMPortDataReadIndex + 5];
                        freq1 = ((int)freq1 << 8) + res[usedPort.m_COMMPortDataReadIndex + 6];
                        freqControl.m_PreFreqOne = (float)(freq1 / 100.00);
                        str = "预设频率点1读取成功，频率是：" + freqControl.m_PreFreqOne.ToString("0.00") + "MHz" + "!\r\n";
                        break;
                    case 2:
                        freq2 = res[usedPort.m_COMMPortDataReadIndex + 3];
                        freq2 = ((int)freq2 << 8) + res[usedPort.m_COMMPortDataReadIndex + 4];
                        freq2 = ((int)freq2 << 8) + res[usedPort.m_COMMPortDataReadIndex + 5];
                        freq2 = ((int)freq2 << 8) + res[usedPort.m_COMMPortDataReadIndex + 6];
                        freqControl.m_PreFreqTwo = (float)(freq2 / 100.00);
                        str = "预设频率点2读取成功，频率是：" + freqControl.m_PreFreqTwo.ToString("0.00") + "MHz" + "!\r\n";
                        break;
                    case 3:
                        freq3 = res[usedPort.m_COMMPortDataReadIndex + 3];
                        freq3 = ((int)freq3 << 8) + res[usedPort.m_COMMPortDataReadIndex + 4];
                        freq3 = ((int)freq3 << 8) + res[usedPort.m_COMMPortDataReadIndex + 5];
                        freq3 = ((int)freq3 << 8) + res[usedPort.m_COMMPortDataReadIndex + 6];
                        freqControl.m_PreFreqThree = (float)(freq3 / 100.00);
                        str = "预设频率点3读取成功，频率是：" + freqControl.m_PreFreqThree.ToString("0.00") + "MHz" + "!\r\n";
                        break;
                    case 4:
                        freq4 = res[usedPort.m_COMMPortDataReadIndex + 3];
                        freq4 = ((int)freq4 << 8) + res[usedPort.m_COMMPortDataReadIndex + 4];
                        freq4 = ((int)freq4 << 8) + res[usedPort.m_COMMPortDataReadIndex + 5];
                        freq4 = ((int)freq4 << 8) + res[usedPort.m_COMMPortDataReadIndex + 6];
                        freqControl.m_PreFreqFour = (float)(freq4 / 100.00);
                        str = "预设频率点4读取成功，频率是：" + freqControl.m_PreFreqFour.ToString("0.00") + "MHz" + "!\r\n";
                        break;
                    case 5:
                        freq1 = res[usedPort.m_COMMPortDataReadIndex + 3];
                        freq1 = ((int)freq1 << 8) + res[usedPort.m_COMMPortDataReadIndex + 4];
                        freq1 = ((int)freq1 << 8) + res[usedPort.m_COMMPortDataReadIndex + 5];
                        freq1 = ((int)freq1 << 8) + res[usedPort.m_COMMPortDataReadIndex + 6];
                        freqControl.m_PreFreqOne = (float)(freq1 / 100.00);
                        str = "预设频率点1读取成功，频率是：" + freqControl.m_PreFreqOne.ToString("0.00") + "MHz" + "!\r\n";

                        freq2 = res[usedPort.m_COMMPortDataReadIndex + 7];
                        freq2 = ((int)freq2 << 8) + res[usedPort.m_COMMPortDataReadIndex + 8];
                        freq2 = ((int)freq2 << 8) + res[usedPort.m_COMMPortDataReadIndex + 9];
                        freq2 = ((int)freq2 << 8) + res[usedPort.m_COMMPortDataReadIndex + 10];

                        freqControl.m_PreFreqTwo = (float)(freq2 / 100.00);
                        str += "预设频率点2读取成功，频率是：" + freqControl.m_PreFreqTwo.ToString("0.00") + "MHz" + "!\r\n";

                        freq3 = res[usedPort.m_COMMPortDataReadIndex + 11];
                        freq3 = ((int)freq3 << 8) + res[usedPort.m_COMMPortDataReadIndex + 12];
                        freq3 = ((int)freq3 << 8) + res[usedPort.m_COMMPortDataReadIndex + 13];
                        freq3 = ((int)freq3 << 8) + res[usedPort.m_COMMPortDataReadIndex + 14];
                        freqControl.m_PreFreqThree = (float)(freq3 / 100.00);
                        str += "预设频率点3读取成功，频率是：" + freqControl.m_PreFreqThree.ToString("0.00") + "MHz" + "!\r\n";

                        freq4 = res[usedPort.m_COMMPortDataReadIndex + 15];
                        freq4 = ((int)freq4 << 8) + res[usedPort.m_COMMPortDataReadIndex + 16];
                        freq4 = ((int)freq4 << 8) + res[usedPort.m_COMMPortDataReadIndex + 17];
                        freq4 = ((int)freq4 << 8) + res[usedPort.m_COMMPortDataReadIndex + 18];
                        freqControl.m_PreFreqFour = (float)(freq4 / 100.00);
                        str += "预设频率点4读取成功，频率是：" + freqControl.m_PreFreqFour.ToString("0.00") + "MHz" + "!\r\n";
                        break;
                    default:
                        return 4;
                }
                if (msg != null)
                {
                    RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "预设频率读取成功!\r\n"+str, Color.Black, false);
                }
            }
            else
            {
                if (_return != 0)
                {
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信发生错误!\r\n", Color.Red, false);
                    }
                }
                else if (usedPort.m_COMMBytesPassed == false)
                {
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "读取的数据格式不合法!\r\n", Color.Red, false);
                    }
                }
                else if (res[usedPort.m_COMMPortDataReadIndex + 1] != 0)
                {
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "数据返回的结果错误!\r\n", Color.Red, false);
                    }
                }
                else
                {
                    if (msg != null)
                    {
                        RichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, "通信命令验证错误!\r\n", Color.Red, false);
                    }
                }
            }
            return _return;
        }

        #endregion

        #region 事件定义

        #endregion



    }
}
