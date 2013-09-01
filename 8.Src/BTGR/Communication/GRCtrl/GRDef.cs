using System;

namespace Communication.GRCtrl
{
    public class GRDef
    {
        public const int  ZERO_DATA_CMD_LENGTH      = 9; 
        //public const int  RECODE_DATA_LENGTH        = 0x10; 
        public const int  ADDRESS_POS               = 3;
        public const int  DEVICE_TYPE_POS           = 4;
        public const int  FUNCTION_CODE_POS         = 5;
        public const int  INNER_DATA_LENGTH_POS     = 6;
        public const int  INNER_DATA_BEGIN_POS      = 7;
        public const byte DEVICE_TYPE               = 0xA0;

        public const int REALDATA_LENGTH            = 113;

        #region Function Code
        public const byte FC_CRC_ERROR              = 0x08;     
        public const byte FC_CORRECT                = 0x0A;     // == FC_ANSWER
        public const byte FC_READ_SETTINGS          = 0x14;     //20
        public const byte FC_WRITE_SETTINGS         = 0x15;     //21


        public const byte FC_READ_REALDATA          = 0x1E;
        public const byte FC_AUTO_ALARMDATA         = 0x20;
        public const byte FC_ANSWER                 = 0x0A;
        
        public const byte FC_SET_OUTSIDE_MODE       = 40;  //0x29;     //40
        public const byte FC_SET_OUTSIDE_TEMP       = 41;  //0x28;     //41

        public const byte FC_REPUMP_STOP            = 0x32;
        public const byte FC_REPUMP_START           = 0x33;
        public const byte FC_CYCPUMP_STOP           = 0x34;
        public const byte FC_CYCPUMP_START          = 0x35;

		/// <summary>
		/// 设置温度曲线 - 室外温度 - 二次供温
		/// </summary>
		public const byte FC_WRITE_TEMPERATURE_LINE = 0x3C;

		/// <summary>
		/// 设置分时调整供热曲线
		/// </summary>
		public const byte FC_WRITE_TIME_TEMPERATURE_LINE = 0x3D;
        #endregion //Function Code

        #region ...
//        7、远程停补水泵：
//        上位读取指令：21 58 44 00 A0 32 00 + CRC16（高低两字节）
//        返回内容：    21 58 44 00 A0 0A 00 CRC16（接收正确）
//        8、远程启补水泵：
//        上位读取指令：21 58 44 00 A0 33 00 + CRC16（高低两字节）
//        返回内容：    21 58 44 00 A0 0A 00 CRC16（接收正确）
//        9、远程停循环泵：	
//        上位读取指令：21 58 44 00 A0 34 00 + CRC16（高低两字节）
//        返回内容：    21 58 44 00 A0 0A 00 CRC16（接收正确）
//        10、远程启循环泵：
//        上位读取指令：21 58 44 00 A0 35 00 + CRC16（高低两字节）
//        返回内容：    21 58 44 00 A0 0A 00 CRC16（接收正确）
        #endregion //...

        #region Menu Code
        // MC - Menu Code 
        // for read settings or write setting
        //
        /// <summary>
        /// 室外温度
        /// </summary>
        public const byte MC_OUTSIDE_TEMPERATURE    = 0x1F;     //31

        /// <summary>
        /// 二次供水温度模式，温度曲线或恒温
        /// </summary>
        public const byte MC_GIVETEMP_MODE          = 0x47;

        /// <summary>
        /// 温度曲线、分时调整曲线 - 读取
        /// </summary>
        public const byte MC_TEMPERATURE_LINE       = 0x48;


        /// <summary>
        /// 二次供回压差设定值
        /// </summary>
        public const byte MC_TWOPRESS_CHA           = 0x4B;     //

        /// <summary>
        /// 补水压力设定值
        /// </summary>
        public const byte MC_RE_PRESS               = 0x4D;     //

        /// <summary>
        /// 压力报警上下限设定
        /// </summary>
        public const byte MC_PRESS_ALARM            = 0x51;

        /// <summary>
        /// 温度报警上下限报警
        /// </summary>
        public const byte MC_TEMPERATURE_ALARM      = 0x52;

        /// <summary>
        /// 阀门开度
        /// </summary>
        public const byte MC_OPENDEGREE             = 0x49;
        #endregion //Menu Code

        //public const int 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        static public int GetInnerDataLen( int fc )
        {
            switch ( fc )
            {
                case FC_READ_REALDATA:
                    return 104;

                case FC_AUTO_ALARMDATA:
                    return 2;

                case FC_ANSWER:
                    return 0;

                case FC_SET_OUTSIDE_TEMP:
                    return 4;

                case FC_SET_OUTSIDE_MODE:
                    return 1;
                default:
                    throw new Exception("at Grdef.getinner data len" );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private GRDef()
        {

        }
    }	
}
