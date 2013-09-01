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
		/// �����¶����� - �����¶� - ���ι���
		/// </summary>
		public const byte FC_WRITE_TEMPERATURE_LINE = 0x3C;

		/// <summary>
		/// ���÷�ʱ������������
		/// </summary>
		public const byte FC_WRITE_TIME_TEMPERATURE_LINE = 0x3D;
        #endregion //Function Code

        #region ...
//        7��Զ��ͣ��ˮ�ã�
//        ��λ��ȡָ�21 58 44 00 A0 32 00 + CRC16���ߵ����ֽڣ�
//        �������ݣ�    21 58 44 00 A0 0A 00 CRC16��������ȷ��
//        8��Զ������ˮ�ã�
//        ��λ��ȡָ�21 58 44 00 A0 33 00 + CRC16���ߵ����ֽڣ�
//        �������ݣ�    21 58 44 00 A0 0A 00 CRC16��������ȷ��
//        9��Զ��ͣѭ���ã�	
//        ��λ��ȡָ�21 58 44 00 A0 34 00 + CRC16���ߵ����ֽڣ�
//        �������ݣ�    21 58 44 00 A0 0A 00 CRC16��������ȷ��
//        10��Զ����ѭ���ã�
//        ��λ��ȡָ�21 58 44 00 A0 35 00 + CRC16���ߵ����ֽڣ�
//        �������ݣ�    21 58 44 00 A0 0A 00 CRC16��������ȷ��
        #endregion //...

        #region Menu Code
        // MC - Menu Code 
        // for read settings or write setting
        //
        /// <summary>
        /// �����¶�
        /// </summary>
        public const byte MC_OUTSIDE_TEMPERATURE    = 0x1F;     //31

        /// <summary>
        /// ���ι�ˮ�¶�ģʽ���¶����߻����
        /// </summary>
        public const byte MC_GIVETEMP_MODE          = 0x47;

        /// <summary>
        /// �¶����ߡ���ʱ�������� - ��ȡ
        /// </summary>
        public const byte MC_TEMPERATURE_LINE       = 0x48;


        /// <summary>
        /// ���ι���ѹ���趨ֵ
        /// </summary>
        public const byte MC_TWOPRESS_CHA           = 0x4B;     //

        /// <summary>
        /// ��ˮѹ���趨ֵ
        /// </summary>
        public const byte MC_RE_PRESS               = 0x4D;     //

        /// <summary>
        /// ѹ�������������趨
        /// </summary>
        public const byte MC_PRESS_ALARM            = 0x51;

        /// <summary>
        /// �¶ȱ��������ޱ���
        /// </summary>
        public const byte MC_TEMPERATURE_ALARM      = 0x52;

        /// <summary>
        /// ���ſ���
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
