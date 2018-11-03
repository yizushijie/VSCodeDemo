using COMMPortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClockWM8510Lib
{
    public class ClockWM8510
    {

        #region 变量定义

        /// <summary>
        /// 设置最小输出频率，20KHz
        /// </summary>
        private int minFreq = 20000;

        /// <summary>
        /// 最大输出频率，38MHz
        /// </summary>
        private int maxFreq = 38000000;

        #endregion

        #region 属性定义

        /// <summary>
        /// 
        /// </summary>
        public int m_MinFreq
        {
            get
            {
                return this.minFreq;
            }
            set
            {
                this.minFreq = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int m_MaxFreq
        {
            get
            {
                return this.maxFreq;
            }
            set
            {
                this.maxFreq = value;
            }
        }



        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public ClockWM8510()
        {

        }

        #endregion

        #region 析构函数

        /// <summary>
        /// 
        /// </summary>
        ~ClockWM8510()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #region 函数定义

        /// <summary>
        /// 设置WM8510输出频率
        /// </summary>
        /// <param name="freq"></param>
        /// <param name="usedPort"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int ClockWM8510SetFreq(int freq,COMMPort usedPort,RichTextBox msg=null)
        {
            int _return = 0;
            return _return;
        }

        /// <summary>
        /// 读取WM8510输出频率
        /// </summary>
        /// <param name="freq"></param>
        /// <param name="usedPort"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int ClockWM8510GetFreq(int freq, COMMPort usedPort, RichTextBox msg = null)
        {
            int _return = 0;
            return _return;
        }

        /// <summary>
        /// 复位WM8510
        /// </summary>
        /// <param name="usedPort"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int ClockWM8510Reset(COMMPort usedPort, RichTextBox msg = null)
        {
            int _return = 0;
            return _return;
        }

        /// <summary>
        /// 时钟输出通道
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="isOpen"></param>
        /// <param name="usedPort"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int ClockWM8510SetChannel(int channel,bool isOpen, COMMPort usedPort, RichTextBox msg = null)
        {
            int _return = 0;
            return _return;
        }

        #endregion

        #region 事件定义

        #endregion

    }
}
