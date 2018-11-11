using COMMPortLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RFASKFreqCurrentLib
{
    /// <summary>
    /// 命令枚举
    /// </summary>
    public enum RFASKFreqCurrentPointCMD : byte
    {
       
    }
    public partial class RFASKFreqCurrent
    {
        #region 变量定义

        /// <summary>
        /// 使用的串口
        /// </summary>
        private COMMPort usedPort = null;

        /// <summary>
        /// 第一电压电流点的配置
        /// </summary>
        private const byte CMD_RFASK_CMD1_FREQ_CURRENT_POINT_ONE = 0x04;

        /// <summary>
        /// 第二电压电流点的配置
        /// </summary
        private const byte CMD_RFASK_CMD1_FREQ_CURRENT_POINT_TWO = 0x05;

        #endregion

        #region 属性定义

        /// <summary>
        /// 
        /// </summary>
        public virtual COMMPort m_UsedPort
        {
            get
            {
                return this.usedPort;
            }
        }
         

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public RFASKFreqCurrent()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usePort"></param>
        public RFASKFreqCurrent(COMMPort usePort)
        {
            if (usedPort == null)
            {
                this.usedPort = new COMMPort();
            }
            this.usedPort = usePort;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="useForm"></param>
        /// <param name="usePort"></param>
        public RFASKFreqCurrent(Form useForm,COMMPort usePort)
        {
            if (usedPort==null)
            {
                this.usedPort = new COMMPort();
            }
            this.usedPort = usePort;
        }



        #endregion

        #region 析构函数

        /// <summary>
        /// 析构函数
        /// </summary>
        ~RFASKFreqCurrent()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #region 函数定义

        #endregion

        #region 事件定义

        #endregion

    }
}
