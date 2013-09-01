namespace Communication.GRCtrl
{
    using System;
    using System.Diagnostics;
    using CFW;
    public class GRAlarmData
    {
        #region test
        static public GRAlarmData s_test
        {
            get 
            {
                GRAlarmData ad = new GRAlarmData();
                ad._powerOff = true;
                ad._oneGivePress_lo = true;
                return ad;
            }
        }
        #endregion //test

        #region Members
        private int  _fromAddress;

        private bool _oneGiveTemp_lo;
        private bool _twoGiveTemp_hi;
        private bool _oneGivePress_lo;
        private bool _twoGivePress_hi;
        private bool _twoBackPress_hi;
        private bool _twoBackPress_lo;
        private bool _watLevel_lo;
        private bool _watLevel_hi;

        private bool _cycPump1;
        private bool _cycPump2;
        private bool _cycPump3;
        private bool _recruitPump1;
        private bool _recruitPump2;
        private bool _powerOff;
        #endregion //Members

        #region Properties
        /// <summary>
        /// ���ع��ȿ�����վ���ַ
        /// </summary>
        public int FromAddress
        {
            get { return _fromAddress; }
        }
        /// <summary>
        /// һ�ι��µͱ���
        /// </summary>
        public bool oneGiveTemp_lo
        {
            get { return  _oneGiveTemp_lo; }
        }

        /// <summary>
        /// ���ι��¸߱���
        /// </summary>
        public bool twoGiveTemp_hi
        {
            get { return  _twoGiveTemp_hi ; }
        }

        /// <summary>
        /// һ�ι�ѹ�ͱ���
        /// </summary>
        public bool oneGivePress_lo
        {
            get { return  _oneGivePress_lo ; }
        }

        /// <summary>
        /// ���ι�ѹ�߱���
        /// </summary>
        public bool twoGivePress_hi
        {
            get { return  _twoGivePress_hi ; }
        }

        /// <summary>
        /// ���λ�ѹ�߱���
        /// </summary>
        public bool twoBackPress_hi
        {
            get { return  _twoBackPress_hi ; }
        }

        /// <summary>
        /// ���λ�ѹ�ͱ���
        /// </summary>
        public bool twoBackPress_lo
        {
            get { return  _twoBackPress_lo ; }
        }

        /// <summary>
        /// ˮ��ˮλ�ͱ���
        /// </summary>
        public bool watLevel_lo
        {
            get { return  _watLevel_lo ; }
        }

        /// <summary>
        /// ˮ��ˮλ�߱���
        /// </summary>
        public bool watLevel_hi
        {
            get { return  _watLevel_hi ; }
        }

        /// <summary>
        /// ѭ����1���ϱ���
        /// </summary>
        public bool cycPump1
        {
            get { return  _cycPump1 ; }
        }

        /// <summary>
        /// ѭ����2���ϱ���
        /// </summary>
        public bool cycPump2
        {
            get { return  _cycPump2 ; }
        }

        /// <summary>
        /// ѭ����3���ϱ���
        /// </summary>
        public bool cycPump3
        {
            get { return  _cycPump3 ; }
        }

        /// <summary>
        /// ��ˮ��һ���ϱ���
        /// </summary>
        public bool recruitPump1
        {
            get { return  _recruitPump1 ; }
        }

        /// <summary>
        /// ��ˮ��2���ϱ���
        /// </summary>
        public bool recruitPump2
        {
            get { return  _recruitPump2 ; }
        }

        /// <summary>
        /// ���籨��
        /// </summary>
        public bool powerOff
        {
            get { return  _powerOff ; }
        }
        #endregion //Properties

        #region ProcessAutoReport
        //
        static public CommResultState ProcessAutoReport( byte[] datas, out GRAlarmData alarmData )
        {
            //if ( datas == null )
            //    return CommResultState.NullData;
            //if ( datas.Length != 11 )
            //    return CommResultState.LengthError;
            CommResultState result = GRCommandMaker.CheckReceivedData(0xA0, 0x20, datas );
            if ( result != CommResultState.Correct )
            {
                alarmData = null;
            }
            else
            {
                int addr = datas[ GRDef.ADDRESS_POS ];
                alarmData = Parse( GRCommandMaker.GetReceivedInnerData( datas ) , addr );
            }
            return result;
        }

        #endregion //ProcessAutoReport

        #region Parse
        static public GRAlarmData Parse( byte[] datas , int fromAddress )
        {
            ArgumentChecker.CheckNotNull( datas );
            Debug.Assert( datas.Length == 2, "datas length != 2" );
            //if ( datas.Length != 2 )
            byte b1 = datas[0];
            byte b2 = datas[1];

            GRAlarmData ad = new GRAlarmData();

            ad._oneGiveTemp_lo  = IsAlarm ( b1, 0 );
            ad._twoGiveTemp_hi  = IsAlarm ( b1, 1 );
            ad._oneGivePress_lo = IsAlarm ( b1, 2 );
            ad._twoGivePress_hi = IsAlarm ( b1, 3 );
            ad._twoBackPress_hi = IsAlarm ( b1, 4 );
            ad._twoBackPress_lo = IsAlarm ( b1, 5 );
            ad._watLevel_lo     = IsAlarm ( b1, 6 );
            ad._watLevel_hi     = IsAlarm ( b1, 7 );

            ad._cycPump1        = IsAlarm ( b2, 0 );
            ad._cycPump2        = IsAlarm ( b2, 1 );
            ad._cycPump3        = IsAlarm ( b2, 2 );
            ad._recruitPump1    = IsAlarm ( b2, 3 );
            ad._recruitPump2    = IsAlarm ( b2, 4 );
            ad._powerOff        = IsAlarm ( b2, 5 );
            ad._fromAddress     = fromAddress;
            return ad;
        }
        #endregion //Parse
        
        #region IsAlarm
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="bitIndex"></param>
        /// <returns></returns>
        static private bool IsAlarm( byte b, int bitIndex )
        {
            Debug.Assert( bitIndex >= 0 && bitIndex <= 7 );
            byte mask = (byte)System.Math.Pow(2, bitIndex);
                bool r = (b & mask) > 0 ;
            return r;
        }
        #endregion //IsAlarm
    }
}
