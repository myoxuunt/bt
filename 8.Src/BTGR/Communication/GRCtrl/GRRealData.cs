using System;
using CFW;
using System.Diagnostics;
using System.Data;

namespace Communication.GRCtrl
{
    /// <summary>
    /// 供热控制器采集数据
    /// </summary>
    public class GRRealData
    {

        #region s_test
        /// <summary>
        /// 
        /// </summary>
        static public GRRealData s_test
        {
            get 
            { 
                GRRealData grrd = new GRRealData();
                grrd._outsideTemp = -3.8981F;
                grrd._oneGivePress = 0.08F;
                grrd._oneGiveTemp = 79.34F;
                return grrd;
            }
        }
        #endregion //s_test

        /// <summary>
        /// 保留的小数点位数
        /// </summary>
        private static int s_digits = 2;

        #region Digits
        /// <summary>
        /// 
        /// </summary>
        static public int Digits
        {
            get { return s_digits; }
            set { s_digits = value; }
        }
        #endregion //Digits

        #region GRRealData
        /// <summary>
        /// 
        /// </summary>
        private GRRealData ()
        {
            _datetime = DateTime.Now;
            _grPumpState = GRPumpState.s_test;
        }
        #endregion //GRRealData
        
        DateTime _datetime;
        int      _fromAddress;

        #region FromAddress
        /// <summary>
        /// 地址
        /// </summary>
        public int FromAddress
        {
            get { return _fromAddress; }
            //set { _fromAddress = value; }
        }
        #endregion //FromAddress

        #region DT
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime DT
        {
            get { return _datetime; }
        }
        #endregion //DT

        #region TwoGiveBaseTemp
        float _twoGiveBaseTemp;
        /// <summary>
        /// 二次供温基准
        /// </summary>
        public float TwoGiveBaseTemp
        {
            get { return (float)Math.Round( _twoGiveBaseTemp, s_digits ) ; }
        }
        #endregion //TwoGiveBaseTemp

        #region TwoPressCha
        float _twoPressCha;
        /// <summary>
        /// 二次供回压差
        /// </summary>
        public float TwoPressCha
        {
            get { return (float)Math.Round( _twoPressCha, s_digits ) ; }
        }
        #endregion //TwoPressCha

        #region OneBackPress
        float _oneBackPress;
        /// <summary>
        /// 一次回水压力
        /// </summary>
        public float OneBackPress
        {
            get { return (float)Math.Round( _oneBackPress, s_digits ) ; } 
        }
        #endregion //OneBackPress

        #region TwoGivePress
        float _twoGivePress;
        /// <summary>
        /// 二次供水压力
        /// </summary>
        public float TwoGivePress
        {
            get { return (float)Math.Round( _twoGivePress, s_digits ) ; } 
        }
        #endregion //TwoGivePress

        #region TwoBackPress
        float _twoBackPress;
        /// <summary>
        /// 二次回水压力
        /// </summary>
        public float TwoBackPress
        {
            get { return (float)Math.Round( _twoBackPress, s_digits ) ; } 
        }
        #endregion //TwoBackPress

        #region OpenDegree
        byte  _openDegree;
        /// <summary>
        /// 调节阀开度
        /// </summary>
        public byte OpenDegree
        {
            get { return _openDegree; } 
        }
        #endregion //OpenDegree

        #region WatBoxLevel
        float _WatBoxLevel;
        /// <summary>
        /// 水箱水位
        /// </summary>
        public float WatBoxLevel
        {
            get { return (float)Math.Round( _WatBoxLevel, s_digits )  ; }
        }
        #endregion //WatBoxLevel

        #region OneInstant
        float _oneInstant;
        /// <summary>
        /// 一次瞬时流量
        /// </summary>
        public float OneInstant
        {
            get { return (float)Math.Round( _oneInstant, s_digits ) ; }
        }
        #endregion //OneInstant

        #region TwoInstant
        float _twoInstant;
        /// <summary>
        /// 二次瞬时流量
        /// </summary>
        public float TwoInstant
        {
            get { return (float)Math.Round( _twoInstant, s_digits ) ; }
        }
        #endregion //TwoInstant

        #region OneAccum
        uint _oneAccum;
        /// <summary>
        /// 一次累计流量
        /// </summary>
        public int OneAccum
        {
            get { return (int)_oneAccum; }
        }
        #endregion //OneAccum

        #region TwoAccum
        public uint _twoAccum;
        /// <summary>
        /// 二次累计流量
        /// </summary>
        public int TwoAccum
        {
            get { return (int)_twoAccum;}
        }
        #endregion //TwoAccum

        #region Warn1
        byte _warn1;
        /// <summary>
        /// 报警1
        /// </summary>
        public byte Warn1
        {
            get { return _warn1; }
        }
        #endregion //Warn1

        #region DrangeSubSet
        float _DrangeSubSet;
        /// <summary>
        /// 压差设定
        /// </summary>
        public float DrangeSubSet
        {
            get { return (float)Math.Round( _DrangeSubSet, s_digits ) ; }
        }
        #endregion //DrangeSubSet

        #region Warn2
        byte _warn2;
        /// <summary>
        /// 报警2
        /// </summary>
        public byte Warn2
        {
            get { return _warn2; } 
        }
        #endregion //Warn2

        #region State
        byte _state;
        /// <summary>
        /// 状态
        /// </summary>
        public byte State
        {
            get { return _state; }
        }
        #endregion //State
        
        #region DrangeSet
        float _DrangeSet;
        /// <summary>
        /// 补水压力设定
        /// </summary>
        public float DrangeSet
        {
            get { return (float)Math.Round( _DrangeSet, s_digits ) ;}
        }
        #endregion //DrangeSet

        #region OutSideTemp
        float _outsideTemp;
        /// <summary>
        /// 室外温度
        /// </summary>
        public float OutSideTemp
        {
            get { return (float)Math.Round( _outsideTemp, s_digits ) ; }
        }
        #endregion //OutSideTemp

        #region OneGiveTemp
        float _oneGiveTemp;
        /// <summary>
        /// 一次供水温度
        /// </summary>
        public float OneGiveTemp
        {
            get { return (float)Math.Round( _oneGiveTemp, s_digits ) ; }
        }
        #endregion //OneGiveTemp

        #region OneBackTemp
        float _oneBackTemp;
        /// <summary>
        /// 一次回水温度
        /// </summary>
        public float OneBackTemp
        {
            get { return (float)Math.Round( _oneBackTemp, s_digits ) ; }
        }
        #endregion //OneBackTemp

        #region TwoGiveTemp
        float _twoGiveTemp;
        /// <summary>
        /// 二次供水温度
        /// </summary>
        public float TwoGiveTemp
        {
            get { return (float)Math.Round( _twoGiveTemp, s_digits ) ; }
        }
        #endregion //TwoGiveTemp

        #region TwoBackTemp
        float _twoBackTemp;
        /// <summary>
        /// 二次回水温度
        /// </summary>
        public float TwoBackTemp
        {
            get { return (float)Math.Round( _twoBackTemp, s_digits ) ;}
        }
        #endregion //TwoBackTemp

        #region OneGivePress
        float _oneGivePress;
        /// <summary>
        /// 一次供水压力
        /// </summary>
        public float OneGivePress
        {
            get { return (float)Math.Round( _oneGivePress, s_digits ) ; }
        }
        #endregion //OneGivePress

        #region GrPumpState
        GRPumpState _grPumpState;
        /// <summary>
        /// 获取实时数据中的泵状态,包含3个循环泵,2个补水泵
        /// </summary>
        public GRPumpState GrPumpState
        {
            get { return _grPumpState; }
        }
        #endregion //GrPumpState

        #region GrAlarmData
        GRAlarmData _grAlarmData;
        /// <summary>
        /// 获取实时数据中的报警数据
        /// </summary>
        public GRAlarmData GrAlarmData
        {
            get { return _grAlarmData; }
        }
        #endregion //GrAlarmData

        #region Parse
        /// <summary>
        /// 将 byte[] 转换成供热控制器的实时数据对象,
        /// </summary>
        /// <param name="datas">is innerDatas</param>
        /// <param name="fromAddress"></param>
        /// <returns></returns>
        static public GRRealData Parse( byte[] datas , int fromAddress)
        {
            ArgumentChecker.CheckNotNull( datas );
            Debug.Assert( datas.Length == 0x68 ,"Parse GRRealData");//Decimal  104

            GRRealData rd = new GRRealData();


            rd._twoGiveBaseTemp = GetFloatValue( datas, 0 + 8);
            rd._DrangeSubSet    = GetFloatValue( datas, 4 + 8);
            rd._DrangeSet       = GetFloatValue( datas, 8 + 8);
            rd._outsideTemp     = GetFloatValue( datas, 12 + 8);
            rd._oneGiveTemp     = GetFloatValue( datas, 16 + 8);
            rd._oneBackTemp     = GetFloatValue( datas, 20 + 8);
            rd._twoGiveTemp     = GetFloatValue( datas, 24 + 8);
            rd._twoBackTemp     = GetFloatValue( datas, 28 + 8);
            rd._oneGivePress    = GetFloatValue( datas, 32 + 8);
            rd._oneBackPress    = GetFloatValue( datas, 36 + 8);
            rd._twoGivePress    = GetFloatValue( datas, 40 + 8);
            rd._twoBackPress    = GetFloatValue( datas, 44 + 8);
            
            rd._openDegree      = GetByteValue ( datas, 48 + 8);
            
            rd._WatBoxLevel     = GetFloatValue( datas, 49 + 8);
            rd._oneInstant      = GetFloatValue( datas, 53 + 8);
            rd._twoInstant      = GetFloatValue( datas, 57 + 8);
            
            rd._oneAccum        = GetULongValue( datas, 69 + 8);
            rd._twoAccum        = GetULongValue( datas, 73 + 8);
            
            rd._warn1           = GetByteValue ( datas, 86 + 8 );
            rd._warn2           = GetByteValue ( datas, 87 + 8);
            rd._state           = GetByteValue ( datas, 88 + 8);
            rd._datetime        = DateTime.Now;

            rd._twoPressCha     = rd._twoGivePress - rd._twoBackPress;  
            rd._grPumpState     = GRPumpState.Parse( rd._state );
            rd._fromAddress     = fromAddress;

            //int fromAddr=99;
            rd._grAlarmData     = GRAlarmData.Parse( 
                new byte[]{ rd._warn1, rd._warn2 }, 
                fromAddress );
            
            return rd;

        }

        static public GRRealData Parse ( DataRow r )
        {
            if ( r == null )
                return null;
            try
            {
                GRRealData rd = new GRRealData();
                rd._datetime        = Convert.ToDateTime( r["time"] );
                rd._oneGiveTemp     = Convert.ToSingle( r["oneGiveTemp"] );
                rd._oneBackTemp     = Convert.ToSingle( r["oneBackTemp"] );
                rd._twoGiveTemp     = Convert.ToSingle( r["twoGiveTemp"] );
                rd._twoBackTemp     = Convert.ToSingle( r["twoBackTemp"] );
                rd._outsideTemp     = Convert.ToSingle( r["outsideTemp"] );
                rd._twoGiveBaseTemp = Convert.ToSingle( r["twoGiveBaseTemp"] );
                rd._oneGivePress    = Convert.ToSingle( r["oneGivePress"] );
                rd._oneBackPress    = Convert.ToSingle( r["oneBackPress"] );
                rd._WatBoxLevel     = Convert.ToSingle( r["WatBoxLevel"] );
                rd._twoGivePress    = Convert.ToSingle( r["twoGivePress"] );
                rd._twoBackPress    = Convert.ToSingle( r["twoBackPress"] );
                rd._oneInstant      = Convert.ToSingle( r["oneInstant"] );
                rd._twoInstant      = Convert.ToSingle( r["twoInstant"] );
                rd._oneAccum        = (uint)Convert.ToInt32( r["oneAccum"] );
                rd._twoAccum        = (uint)Convert.ToInt32( r["twoAccum"] );
                rd._openDegree      = Convert.ToByte( r["openDegree"] );
                rd._twoPressCha     = Convert.ToSingle( r["twoPressCha"] );

                GRPumpState pumpState = GRPumpState.Parse( r );

                rd._grPumpState = pumpState;
                rd._grAlarmData = null;

                return rd;
            }
            catch ( Exception ex )
            {
                MsgBox.Show( ex.ToString() );
                return null;
            }
//            return null;
        }
        #endregion //Parse

        #region GetFloatValue
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="begin"></param>
        /// <returns></returns>
        static private float GetFloatValue( byte[] datas, int begin)//, int len )
        {
            return BitConverter.ToSingle(datas, begin);
        }
        #endregion //GetFloatValue

        #region GetULongValue
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="begin"></param>
        /// <returns></returns>
        static private uint GetULongValue ( byte[] datas, int begin )
        {
            return BitConverter.ToUInt32( datas, begin );
        }
        #endregion //GetULongValue

        #region GetByteValue
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="begin"></param>
        /// <returns></returns>
        static private byte GetByteValue( byte[] datas, int begin )
        {
            return datas[begin];
        }
    }
        #endregion //GetByteValue

}
