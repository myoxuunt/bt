#region 巡更系统通讯协议
/******************************************************************************
  
巡更系统通讯协议

通讯格式： ！＋X＋D＋地址＋设备类型＋功能码＋数据数＋数据＋CRC16
           -   -  -  ----  --------  ------  ------  ----  -----
字节长度： 1   1  1    1      1         1       1      n     2

！（0x21）     X（0x58）     D（0x44）

地址：设备的站号   设备类型： 0xB0

CRC16：16位CRC校验数据，低字节在前，高字节在后。
通讯参数：
1．	修改时间
功能码：0x01
数据数3位：秒，分，时（BCD码）
成功后返回： ！＋X＋D＋地址＋设备类型＋功能码＋数据数（0x00）＋CRC16

2．	修改日期
功能码：0x02
数据数3位：日，月，年（BCD码）
成功后返回： ！＋X＋D＋地址＋设备类型＋功能码＋数据数（0x00）＋CRC16

3．	读取时间
功能码：0x03
数据数0位：
成功后返回： ！＋X＋D＋地址＋设备类型＋功能码＋数据数（0x03）＋秒＋分＋时（BCD码）＋CRC16

4．	读取日期
功能码：0x04
数据数0位：
成功后返回： ！＋X＋D＋地址＋设备类型＋功能码＋数据数（0x03）＋日＋月＋年（BCD码）＋CRC16

5．	修改站号
功能码：0x05
数据数1位：新站号
成功后返回： ！＋X＋D＋新地址＋设备类型＋功能码＋数据数（0x00）＋CRC16

6．	读取记录总条数
功能码：0x06
数据数：0位
成功后返回： ！＋X＋D＋地址＋设备类型＋功能码＋数据数（0x01）＋记录总条数＋CRC16

7．	读取第N条记录：
功能码：0x07
数据数：1位：N
成功后返回： ！＋X＋D＋地址＋设备类型＋功能码＋数据数（0x10）＋第N条记录＋CRC16
如果N取值不正确，则返回：！＋X＋D＋地址＋设备类型＋功能码＋数据数（0x01）＋记录总条数＋CRC16

记录数据格式：00 C S M H DD MM YY SN
#   Name        Len     Conv
--  --------    --      ---
C - RecordCount 1       Hex
S - Second,     1       BCD
M - Minute,     1       BCD
H - Hour,       1       BCD
DD - Day,       1       BCD
MM - Month,     1       BCD
YY - Year,      1       BCD
SN - Card SN,   8       Hex

8．	删除记录
功能码：0x08
数据数：0位
成功后返回： ！＋X＋D＋地址＋设备类型＋功能码＋数据数（0x00）＋CRC16

9．	查询工作站
功能码：0x09
数据数：0位
成功后返回： ！＋X＋D＋地址＋设备类型＋功能码＋数据数（0x00）＋CRC16

10.	实时上传模式下巡更系统下位机发送的数据包
将记录上传。
功能码：0x0a
数据数：16位
如果上位机检测到数据包并确认数据正确，则返回给下位机：
！＋X＋D＋地址＋设备类型＋功能码（0x0a）＋数据数（0x00）＋CRC16
此时下位机将删除此条记录。

数据格式同#7命令.

11.	修改工作状态
功能码：0x0b
数据数1位：（新工作模式） 0x01为实时上传模式。0x02为存储数据模式。
成功后返回： ！＋X＋D＋地址＋设备类型＋功能码＋数据数（0x00）＋CRC16

12. 查询工作状态
功能码：0x0c
数据数 0 位：
成功后返回： ！＋X＋D＋地址＋设备类型＋功能码＋数据数（0x01）＋状态码 + CRC16

若通讯时返回值为：! + X + D + 地址(0x00) + 设备类型(0xb0) + 功能码(0xF3) + CRC16
则上位计下传数据出现错误，可能是!、 X、D、地址、设备类型、功能码出现错误。
若通讯时返回值为：! + X + D + 地址(0x00) + 设备类型(0xb0) + 功能码(0xF2) + CRC16
则上位计下传数据出现错误，可能是CRC16检验出现错误。

******************************************************************************/
#endregion // 巡更系统通讯协议

using System;
using CFW;
using System.Diagnostics;
using Utilities;
using Infragistics.Shared;

namespace Communication 
{
    #region WorkingMode
    /// <summary>
    /// 
    /// </summary>
    public enum WorkingMode
    {
        /// <summary>
        /// 
        /// </summary>
        RealTimeUpload  = 0x01,
        /// <summary>
        /// 
        /// </summary>
        LocalSave       = 0x02,
    }
    #endregion // WorkingMode

    #region Record
    /// <summary>
    /// 
    /// </summary>
    public class Record
    {
        private const int YEAR_POS = 7,
            MONTH_POS   = 6,
            DAY_POS     = 5,
            HOUR_POS    = 4,
            MINUTE_POS  = 3,
            SECOND_POS  = 2,
            CARD_SN_BEGIN_POS   = 8,
            CARD_SN_DATA_LENGTH = 8;

           
        private int _year, 
            _month, 
            _day,
            _hour, 
            _minute, 
            _second;

        string _cardSN;

        //private Record( int year, int month, int day, int hour, int minute, int second, string cardSN, int address)
        private Record( int year, int month, int day, int hour, int minute, int second, string cardSN )
        {
            _year = year;
            _month = month;
            _day = day;
            _hour = hour;
            _minute = minute;
            _second = second;
            _cardSN = cardSN;
        }
        
        private int Year
        {   
            get { return _year; }
        }

        private int Month
        {
            get { return _month; }
        }
        
        private int Day
        {
            get { return _day; }
        }

        private int Hour
        {
            get { return _hour; }
        }

        private int Minute
        {
            get { return _minute; }
        }

        private int Second
        {
            get { return _second; }
        }

        public DateTime DateTime 
        {
            get 
            { 
                try
                {
                    return new DateTime( _year, _month, _day, _hour, _minute, _second );
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }

        public string CardSN
        {
            get { return _cardSN; }
        }
        
        /// <summary>
        /// 解析接受到的内部记录数据（不包含头、地址、功能码、校验位等），
        /// 该数据只包含一个卡号和日期时间，共16字节。
        /// </summary>
        /// <param name="datas">待解析的内部数据</param>
        /// <returns>成功时返回Record实例，否则返回null</returns>
        public static Record Analyze( byte[] datas )
        {
            //if ( datas == null || datas.Length != XGDefinition
            Debug.Assert( datas.Length == XGDefinition.RECODE_DATA_LENGTH, 
                "datas.Length error, must == " + XGDefinition.RECODE_DATA_LENGTH );
            if ( null == datas || datas.Length != XGDefinition.RECODE_DATA_LENGTH )
                return null;
            try
            {
                int year   = BCDConvert.BCDToDec( datas[ YEAR_POS   ] );
                int month  = BCDConvert.BCDToDec( datas[ MONTH_POS  ] );
                int day    = BCDConvert.BCDToDec( datas[ DAY_POS    ] );
                int hour   = BCDConvert.BCDToDec( datas[ HOUR_POS   ] );
                int minute = BCDConvert.BCDToDec( datas[ MINUTE_POS ] );
                int second = BCDConvert.BCDToDec( datas[ SECOND_POS ] );

                byte[] cardSNDatas = new byte[ CARD_SN_DATA_LENGTH ];
                Array.Copy( datas, CARD_SN_BEGIN_POS, cardSNDatas, 0, CARD_SN_DATA_LENGTH );
                string cardSN = MakeCardSN( cardSNDatas );

                year += 2000;
                //return new Record( year, month, day, hour, minute, second, cardSN, address );
                Record r = new Record( year, month, day, hour, minute, second, cardSN );
                if ( r.DateTime == DateTime.MinValue )
                    return null;
                else
                    return r;
            }
            catch(Exception ex)
            {
				// TODO: log analyze xg record error
				// 
                // Debug.Fail ( ex.ToString(), "at Analyze()");
				Console.WriteLine( "Analyze xg record exception: " + ex.ToString() );
                return null;
            }
        }

        private static string MakeCardSN( byte[] datas )
        {
            Debug.Assert( datas.Length == CARD_SN_DATA_LENGTH );
            string sCardSN = string.Empty;
            for (int i=0; i<datas.Length; i++)
            {
                sCardSN += datas[i].ToString("X2");
            }
            return sCardSN;
        }
    }
    #endregion // Record

    #region XGDefinition
    public class XGDefinition
    {
        public const int  ZERO_DATA_CMD_LENGTH      = 9;
        public const int  RECODE_DATA_LENGTH        = 0x10;
            
        public const int  ADDRESS_POS               = 3;
        public const int  DEVICE_TYPE_POS           = 4;
        public const int  FUNCTION_CODE_POS         = 5;
        public const int  INNER_DATA_LENGTH_POS     = 6;
        public const int  INNER_DATA_BEGIN_POS      = 7;

        public const byte DEVICE_TYPE       = 0xB0;

        // FC - Function Code

        public const byte FC_MODIFY_TIME    = 0x01;
        public const byte FC_MODIFY_DATE    = 0x02;
        public const byte FC_READ_TIME      = 0x03;
        public const byte FC_READ_DATE      = 0x04;
        public const byte FC_MODIFY_ADDRESS = 0x05;
        public const byte FC_READ_TOTALCOUNT= 0x06;
        public const byte FC_READ_RECORD    = 0x07;
        public const byte FC_REMOVE_ALL     = 0x08;
        public const byte FC_QUERY_ADDRESS  = 0x09;
        /// <summary>
        /// 上位机检测到实时上传的数据，并确认数据正确，返回给下位机。
        /// 此时下位机将删除此条记录。
        /// </summary>
        public const byte FC_ANSWER         = 0x0A;
        /// <summary>
        /// 控制器自动上报数据时使用此功能码
        /// </summary>
        public const byte FC_AUTO_REPORT    = 0x0A;

        public const byte FC_MODIFY_MODE    = 0x0B;
        
        private const byte MIN_FC = FC_MODIFY_TIME;
        private const byte MAX_FC = FC_MODIFY_MODE;

        static private int[] _ReceivedInnerDataLen = 
        {
            -1,         // Not use!
            0x00,       // FC_MODIFY_TIME
            0x00,       // FC_MODIFY_DATE
            0x03,       // FC_READ_TIME
            0x03,       // FC_READ_DATE
            0x00,       // FC_MODIFY_ADDRESS
            0x01,       // FC_READ_TOTALCOUNT
            0x10,       // FC_READ_RECORD
            0x00,       // FC_REMOVE_ALL
            0x00,       // FC_QUERY_ADDRESS
            0x10,       // FC_ANSWER
            0x00        // FC_MODIFY_MODE
        };

        /// <summary>
        /// 获取一个命令的返回数据中，包含的内部数据的正确长度
        /// </summary>
        /// <param name="functionCode">功能码，该功能码标识了一个具体的设备命令</param>
        /// <returns>与功能码对应的，内部数据的正确长度</returns>
        static public int GetInnerDataLen( int functionCode )
        {
            if ( functionCode >= MIN_FC && functionCode <= MAX_FC )
                return _ReceivedInnerDataLen[ functionCode ];
            else
                throw new ArgumentOutOfRangeException( "commandType" );
        }
    }
    #endregion // XGDefinition
    
    #region BCDConvert
    public class BCDConvert
    {
        private BCDConvert()
        {
        }

        static public int DecToBCD( int value )
        {
            return Convert.ToInt32( value.ToString(), 16 );
        }

        static public int BCDToDec( int value )
        {
            return Convert.ToInt32( value.ToString("X"), 10 );
        }
    }
    #endregion // BCDConvert

    #region //
    //    #region XGStation
    //    /// <summary>
    //    /// XGStation
    //    /// </summary>
    //    public class XGStation : CFW.Station 
    //    {
    //        public XGStation(string name, int address) : base(name,address)
    //        {
    //        }
    //
    //        public CFW.OperationLogsCollection Logs
    //        {
    //            get { return base.OperationLogs; }
    //        }
    //    }
    //    #endregion // XGStation
    #endregion ////

    #region XGData
    public class XGData : CFW.RealData 
    {
        //private Card _card;

        private string  _cardSN;
        private int     _fromAddress;
        private DateTime _xgStationDateTime;
        private bool    _isAutoReport;

        public XGData ( string sn, int fromAddr, DateTime xgStationDt, bool isAutoReport )
        {
            _cardSN = sn;
            _fromAddress = fromAddr;
            _xgStationDateTime = xgStationDt; 
            _isAutoReport = isAutoReport;
        }

        /// <summary>
        /// 获取巡更时间
        /// </summary>
        public DateTime XGStationDateTime
        {
            get { return _xgStationDateTime; } 
        }

        /// <summary>
        /// 是否为自动上报数据
        /// </summary>
        public bool IsAutoReport
        {
            get { return _isAutoReport; }
        }

        /// <summary>
        /// 获取巡更控制器的地址
        /// </summary>
        public int FromAddress
        {
            get { return _fromAddress; }
        }

        /// <summary>
        /// 获取卡号
        /// </summary>
        public string CardSN
        {
            get { return _cardSN; }
        }
    }
    #endregion // XGData

    #region XGDatasCollection
    public class XGDatasCollection : CFW.RealDatasCollection 
    {
        public XGDatasCollection()
        {
        }

        public int Add( XGData xgData )
        {
            return base.InternalAdd( xgData );
        }

        public XGData this [int index]
        {
            get 
            {
                return base.GetItem( index ) as XGData;
            }
        }
    }
    #endregion //XGDatasCollection

    #region XGCommandMaker
    /// <summary>
    /// XGCommandMaker
    /// </summary>
    public class XGCommandMaker
    {
        public static byte[] MakeCommand(int address, int deviceType, int functionCode, byte[] datas)
        {
            int datasLength = (datas == null ? 0 : datas.Length) ;
            int length = XGDefinition.ZERO_DATA_CMD_LENGTH + datasLength; 

            byte[] r = new byte[length];
            r[0] = 0x21;            //!
            r[1] = 0x58;            //X
            r[2] = 0x44;            //D
            r[3] = (byte)address;
            r[4] = (byte)deviceType;
            r[5] = (byte)functionCode;
            r[6] = (byte)datasLength;

            for (int i=0; i<datasLength; i++)
            {
                r[ XGDefinition.INNER_DATA_BEGIN_POS + i ] = datas[i];
            }
            byte hi, lo;
            CRC16.CalculateCRC(r, length - 2, out hi, out lo );
            
            r[length - 2] = lo;
            r[length - 1] = hi;

            return r;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="deviceType"></param>
        /// <param name="functionCode"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static CommResultState CheckReceivedData(int address, int deviceType, 
            int functionCode, byte[] datas)
        {
            // 2007.03.09 Added check is nullData
            //
            if ( datas == null || datas.Length == 0 )
                return CommResultState.NullData;

            if (datas == null || datas.Length < XGDefinition.ZERO_DATA_CMD_LENGTH)
                return CommResultState.LengthError;

            int innerDataLen = datas[ XGDefinition.INNER_DATA_LENGTH_POS ];
            if ( innerDataLen != XGDefinition.GetInnerDataLen( functionCode ) )
                return CommResultState.LengthError;

            if (datas.Length != XGDefinition.ZERO_DATA_CMD_LENGTH + innerDataLen)
                return CommResultState.LengthError;

            byte calcHi, calcLo;
            CRC16.CalculateCRC( datas, datas.Length - 2, out calcHi, out calcLo );
            
            byte lo = datas[ datas.Length - 2];
            byte hi = datas[ datas.Length - 1];
            if (hi != calcHi || lo != calcLo)
                return CommResultState.CheckError;

            int rAddress = datas[ XGDefinition.ADDRESS_POS ];
            int rDeviceType = datas [ XGDefinition.DEVICE_TYPE_POS ];
            int rFC = datas[ XGDefinition.FUNCTION_CODE_POS ];

            if ( rAddress != address ||
                rDeviceType != deviceType ||
                rFC != functionCode )
                return CommResultState.DataError;

            return CommResultState.Correct;

        }

        public static CommResultState CheckReceivedData(int deviceType,
            int functionCode, byte[] datas)
        {
            // 2007.03.09 Added check is nullData
            //
            if ( datas == null || datas.Length == 0 )
                return CommResultState.NullData;

            if (datas == null || datas.Length < XGDefinition.ZERO_DATA_CMD_LENGTH)
                return CommResultState.LengthError;

            int innerDataLen = datas[ XGDefinition.INNER_DATA_LENGTH_POS ];
            if ( innerDataLen != XGDefinition.GetInnerDataLen( functionCode ) )
                return CommResultState.LengthError;

            if (datas.Length != XGDefinition.ZERO_DATA_CMD_LENGTH + innerDataLen)
                return CommResultState.LengthError;

            byte calcHi, calcLo;
            CRC16.CalculateCRC( datas, datas.Length - 2, out calcHi, out calcLo );
            
            byte lo = datas[ datas.Length - 2];
            byte hi = datas[ datas.Length - 1];
            if (hi != calcHi || lo != calcLo)
                return CommResultState.CheckError;

            //int rAddress = datas[ XGDefinition.ADDRESS_POS ];
            int rDeviceType = datas [ XGDefinition.DEVICE_TYPE_POS ];
            int rFC = datas[ XGDefinition.FUNCTION_CODE_POS ];

            if (// rAddress != address ||
                rDeviceType != deviceType ||
                rFC != functionCode )
                return CommResultState.DataError;

            return CommResultState.Correct;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static byte[] GetReceivedInnerData(byte[] datas )
        {
            int innerDataLen = datas[ XGDefinition.INNER_DATA_LENGTH_POS ];
            if (innerDataLen == 0)
                return null;

            byte[] innerData = new byte[innerDataLen];

            for (int i=0; i<innerDataLen; i++)
            {
                innerData[i] = datas[XGDefinition.INNER_DATA_BEGIN_POS + i];
            }           

            return innerData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static int GetAddress( byte[] bs )
        {
            return bs[XGDefinition.ADDRESS_POS];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static bool IsXgData( byte[] bs )
        {
            return bs[XGDefinition.DEVICE_TYPE_POS] == XGDefinition.DEVICE_TYPE;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static bool IsXgRecord( byte[] bs )
        {
            return bs[XGDefinition.FUNCTION_CODE_POS] == XGDefinition.FC_READ_RECORD;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static bool IsXgRecordCount( byte[] bs )
        {
            return bs[XGDefinition.FUNCTION_CODE_POS] == XGDefinition.FC_READ_TOTALCOUNT;
        }
    }
    #endregion // XGCommandMaker

    #region RangeChecker
    /// <summary>
    /// 
    /// </summary>
    public class RangeChecker
    {
        public static bool Check( int value, int min, int max, bool includeExtremum, bool throwExcetpion)
        {
            bool r = false;

            if (includeExtremum)
            {
                r = value >= min && value <= max;
            }
            else
            {
                r = value > min && value < max;
            }
            if ( !r && throwExcetpion)
                throw new ArgumentOutOfRangeException();
            return r;
        }
    }
    #endregion // RangeChecker

    #region ModifyTimeCommand
    public class ModifyTimeCommand : CFW.CommCmdBase 
    {
        private int _hour = 0;
        private int _minute = 0;
        private int _second =0;
        
        public override int LatencyTime
        {
            get
            {
                return XGConfig.Default.XgCmdLatencyTime;
            }
        }

        public ModifyTimeCommand( XGStation station, int hour, int minute, int second)
        {
            if (station == null)
                throw new ArgumentNullException ("XGStation");
            this.Station = station;
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        #region  Properties
        public int Hour
        {
            get { return _hour; }
            set 
            { 
                RangeChecker.Check(value, 0, 23, true, true); 
                _hour = value; 
            }
        }

        public int Minute
        {
            get { return _minute; }
            set 
            { 
                RangeChecker.Check(value, 0, 59, true, true); 
                _minute = value; 
            }
        }
        
        public int Second
        {
            get { return _second; }
            set 
            {
                RangeChecker.Check(value, 0, 59, true, true); 
                _second = value; 
            }
        }

        #endregion //Properties


        /// <summary>
        /// 生成设置时间命令
        /// </summary>
        /// <returns></returns>
        public override byte[] MakeCommand()
        {

            byte[] datas = new byte[3];
            
            datas[0] = (byte)BCDConvert.DecToBCD(Second);
            datas[1] = (byte)BCDConvert.DecToBCD(Minute);
            datas[2] = (byte)BCDConvert.DecToBCD(Hour) ;
            return XGCommandMaker.MakeCommand( Station.Address, 
                XGDefinition.DEVICE_TYPE, 
                XGDefinition.FC_MODIFY_TIME, 
                datas );
        }


        public override CommResultState ProcessReceived(byte[] data)
        {
            //return new CommResultState ();
            return XGCommandMaker.CheckReceivedData( Station.Address, 
                XGDefinition.DEVICE_TYPE, 
                XGDefinition.FC_MODIFY_TIME,
                data );
        }
    }
    #endregion // ModifyTimeCommand

    #region ModifyDateCommand
    public class ModifyDateCommand : CommCmdBase
    {
        private int _year;
        private int _month;
        private int _day;

        public override int LatencyTime
        {
            get
            {
                return XGConfig.Default.XgCmdLatencyTime;
            }
        }

        public ModifyDateCommand( XGStation station, int year, int month, int day )
        {
            this.Station = station;
            _year = year;
            _month = month;
            _day = day;
        }

        public int Year 
        {
            get { return _year; }
            set { _year = value; }
        }

        public int Month
        {
            get { return _month; }
            set 
            { 
                RangeChecker.Check( value, 1, 12, true, true );
                _month = value; 
            }
        }

        public int Day
        {
            get { return _day; }
            set 
            {
                //RangeChecker
                _day = value; 
            }
        }

        public override byte[] MakeCommand()
        {
            byte[] datas = new byte[3];

            datas[0] = (byte)BCDConvert.DecToBCD(Day);
            datas[1] = (byte)BCDConvert.DecToBCD(Month);
            datas[2] = (byte)BCDConvert.DecToBCD(Year);

            return XGCommandMaker.MakeCommand( Station.Address,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_MODIFY_DATE,
                datas );
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            return XGCommandMaker.CheckReceivedData (Station.Address,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_MODIFY_DATE,
                data );
        }


    }
    #endregion //ModifyDateCommand
    
    #region ReadTimeCommand
    public class ReadTimeCommand : CommCmdBase
    {
        private const  int INVALID_VALUE = -1;
        private int _hour ;
        private int _minute;
        private int _second;


        public override int LatencyTime
        {
            get
            {
                return XGConfig.Default.XgCmdLatencyTime;
            }
        }

        private void SetInvalidValue()
        {
            _hour = INVALID_VALUE;
            _minute = INVALID_VALUE;
            _second = INVALID_VALUE;
        }

        public ReadTimeCommand( XGStation station )
        {
            this.Station = station;
            SetInvalidValue();
        }

        public override byte[] MakeCommand()
        {
            return XGCommandMaker.MakeCommand ( this.Station.Address, 
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_READ_TIME,
                null );

        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            CommResultState state = XGCommandMaker.CheckReceivedData (
                Station.Address, 
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_READ_TIME,
                data );

            if (state == CommResultState.Correct)
            {
                byte[] innerDatas = XGCommandMaker.GetReceivedInnerData( data );
                _second = BCDConvert.BCDToDec ( innerDatas[0] );
                _minute = BCDConvert.BCDToDec ( innerDatas[1] );
                _hour =   BCDConvert.BCDToDec ( innerDatas[2] );
            }
            else
            {
                SetInvalidValue();
            }

            return state;
        }

        public int Hour
        {
            get { return _hour; }
        }

        public int Minute
        {
            get { return _minute; }
        }

        public int Second
        {
            get { return _second; }
        }
    }
    #endregion // ReadTimeCommand

    #region ReadDateCommand
    public class ReadDateCommand : CommCmdBase
    {
        private const  int INVALID_VALUE = -1;
        private int _year ;
        private int _month;
        private int _day;

        public override int LatencyTime
        {
            get
            {
                return XGConfig.Default.XgCmdLatencyTime;
            }
        }

        private void SetInvalidValue()
        {
            _year = INVALID_VALUE;
            _month = INVALID_VALUE;
            _day = INVALID_VALUE;
        }

        public ReadDateCommand( XGStation station )
        {
            this.Station = station;
            SetInvalidValue();
        }

        public override byte[] MakeCommand()
        {
            return XGCommandMaker.MakeCommand ( this.Station.Address, 
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_READ_DATE,
                null );

        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            CommResultState state = XGCommandMaker.CheckReceivedData (
                Station.Address, 
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_READ_DATE,
                data );

            if (state == CommResultState.Correct)
            {
                byte[] innerDatas = XGCommandMaker.GetReceivedInnerData( data );
                _day    = BCDConvert.BCDToDec ( innerDatas[0] );
                _month  = BCDConvert.BCDToDec ( innerDatas[1] );
                _year   = BCDConvert.BCDToDec ( innerDatas[2] );
            }
            else
            {
                SetInvalidValue();
            }

            return state;
        }

        public int Year
        {
            get { return _year; }
        }

        public int Month
        {
            get { return _month; }
        }

        public int Day
        {
            get { return _day; }
        }
    }
    #endregion // ReadDateCommand

    #region ModifyAddressCommand
    public class ModifyAddressCommand : CommCmdBase
    {
        private int _newAddress;


        public override int LatencyTime
        {
            get
            {
                return XGConfig.Default.XgCmdLatencyTime;
            }
        }

        public int NewAddress
        {
            get { return _newAddress; }
            set { _newAddress = value; }
        }

        public ModifyAddressCommand(XGStation station, int newAddress)
        {
            this.Station = station;
            _newAddress = newAddress;
        }

        public override byte[] MakeCommand()
        {
            byte[] datas = new byte[] { (byte)NewAddress };
            return XGCommandMaker.MakeCommand (Station.Address, 
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_MODIFY_ADDRESS,
                datas );
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            return XGCommandMaker.CheckReceivedData ( NewAddress,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_MODIFY_ADDRESS,
                data);
        }
    }
    #endregion // ModifyAddressCommand

    #region ReadTotalCountCommand
    public class ReadTotalCountCommand : CommCmdBase
    {
        private int _totalCount = 0;
        public override int LatencyTime
        {
            get { return XGConfig.Default.XgCmdLatencyTime; }
        }

        public int TotalCount
        {
            get { return _totalCount; }
        }

        public ReadTotalCountCommand (XGStation station )
        {
            this.Station = station;
        }

        public override byte[] MakeCommand()
        {
            return XGCommandMaker.MakeCommand( Station.Address,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_READ_TOTALCOUNT,
                null);
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            CommResultState state = XGCommandMaker.CheckReceivedData( Station.Address,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_READ_TOTALCOUNT,
                data );
            if ( state == CommResultState.Correct )
            {
                byte[] innerDatas = XGCommandMaker.GetReceivedInnerData( data );
                _totalCount = innerDatas[0];
            }
            return state;
        }
    }
    #endregion // ReadTotalCountCommand

    #region ReadRecordCommand
    public class ReadRecordCommand : CommCmdBase
    {
        private int _recordIndex;
        private Record _record; 

        private int _recordTotalCount; 

        private XGData _xgData; 

        public override int LatencyTime
        {
            get { return XGConfig.Default.XgCmdLatencyTime; }
        }

        public XGData XGData
        {
            get { return _xgData; }
        }
        public int RecordIndex
        {
            get { return _recordIndex; }
            set { _recordIndex = value; }
        }
        public Record Record
        {
            get { return _record; }
        }
        public int RecordTotalCount
        {
            get { return _recordTotalCount; }
        }

        public ReadRecordCommand( XGStation station, int recodeIndex)
        {
            _recordIndex = recodeIndex;    
            _record = null;
            _recordTotalCount = -1;
            Station = station;
        }

        public override byte[] MakeCommand()
        {
            byte[] datas = new byte[1];
            datas[0] = (byte)_recordIndex;
            return XGCommandMaker.MakeCommand( this.Station.Address,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_READ_RECORD,
                datas );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override CommResultState ProcessReceived(byte[] data)
        {
            CommResultState state = XGCommandMaker.CheckReceivedData( this.Station.Address,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_READ_RECORD,
                data );

            // 正确时处理记录数据，错误时保留上次读取的数据不变。
            //
            if (state == CommResultState.Correct)
            {
                int address = data[ XGDefinition.ADDRESS_POS ];

                byte[] innerDatas = XGCommandMaker.GetReceivedInnerData( data );
                int innerDataLen = innerDatas.Length;

                // 
                if (innerDataLen == XGDefinition.RECODE_DATA_LENGTH)
                {
                    // analyse recode data
                    //
                    _record = Record.Analyze( innerDatas );

                    // 2007-11-5 Added process data (datetime bytes) error 
                    // 
                    if ( _record == null )
                    {
                        state = CommResultState.DataError;
                        return state;
                    }
                    else
                    {
                        _xgData = new XGData( _record.CardSN, address, _record.DateTime, false );
                        _recordTotalCount = -1;
                    }
                }
                else if(innerDataLen == 1) // recode index error
                {
                    _recordTotalCount = innerDatas[0];
                }
                else
                {
                    throw new Exception("Read recode inner data error.");
                }
            }
            return state;
        }
    }
    #endregion // ReadRecordCommand

    #region RemoveAllCommand
    public class RemoveAllCommand : CommCmdBase
    {
        public override int LatencyTime
        {
            get { return XGConfig.Default.XgCmdLatencyTime; }
        }

        public RemoveAllCommand( XGStation station )
        {
            Station = station;
        }

        public override byte[] MakeCommand()
        {
            return XGCommandMaker.MakeCommand( Station.Address,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_REMOVE_ALL,
                null );
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            return XGCommandMaker.CheckReceivedData( Station.Address,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_REMOVE_ALL,
                data );
        }
    }
    #endregion // RemoveAllCommand

    #region QueryStationCommand
    public class QueryStationCommand : CommCmdBase
    {

        public override int LatencyTime
        {
            get { return XGConfig.Default.XgCmdLatencyTime; }
        }
        public QueryStationCommand( XGStation station )
        {
            if (station == null)
            {
                throw new ArgumentNullException ("XGStation");
            }
            this.Station = station;
        }

        public override byte[] MakeCommand()
        {
            return XGCommandMaker.MakeCommand( Station.Address, 
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_QUERY_ADDRESS,
                null );
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            
            CommResultState r =  XGCommandMaker.CheckReceivedData( Station.Address, 
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_QUERY_ADDRESS,
                data );
            return r;
        }


    }
    #endregion // QueryStationCommand

    #region AutoReportCommand
    // command #10 ??
    /// <summary>
    /// 自动上报数据的应答命令,发送该命令给巡更控制器时,
    /// 控制器将删除该才自动上报的那条记录
    /// </summary>
    /// <remarks>
    /// 自动上报数据的应答命令没有返回结果
    /// </remarks>
    public class AutoReportCommand : CommCmdBase
    {
        public override int LatencyTime
        {
            get { return XGConfig.Default.XgCmdLatencyTime; }
        }

        public AutoReportCommand( XGStation st )
        {
            ArgumentChecker.CheckNotNull ( st );
            Station = st;

        }
        
        public override byte[] MakeCommand()
        {
            return XGCommandMaker.MakeCommand ( Station.Address, XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_ANSWER, null ); 
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            // 2007.03.13 Modify XG AutoReportCommand 不返回数据,所以认为所有的AutpReportCommand都是执行成功的
            //
            //throw new NotImplementedException ("AutoReportCommand.ProcessReceive() not need implement.");
            return CommResultState.Correct;
        } 

        #region AnalyserAutoReportData
        //static public XGAutoReportData AnalyserAutoReportData ( byte[] data )
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static public XGData AnalyserAutoReportData ( byte[] data )
        {
            Record r;
            int from;

            CommResultState state = AnalyserAutoReportData( data, out r, out from );
            if ( state == CommResultState.Correct )
                return new XGData(r.CardSN, from, r.DateTime,  true);
            else
                return null;
        }

        static private CommResultState AnalyserAutoReportData( byte[] data, out Record record, out int fromAddress )
        {
            record = null;
            fromAddress = -1;
            CommResultState state = XGCommandMaker.CheckReceivedData( 
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_AUTO_REPORT,
                data 
                );

            if ( state == CommResultState.Correct )
            {
                fromAddress = data[XGDefinition.ADDRESS_POS];
                byte[] innerDatas = XGCommandMaker.GetReceivedInnerData( data );
                int innerDataLen = innerDatas.Length;
            
                // 
                if (innerDataLen == XGDefinition.RECODE_DATA_LENGTH)
                {
                    // analyse recode data
                    //
                    record = Record.Analyze( innerDatas );
                }
                else
                {
                    //throw new Exception("Read recode inner data error.");
                    return CommResultState.LengthError;
                }
            }
            return state;
          }
        #endregion // AnalyserAutoReportData
    }
    #endregion //AutoReportCommand

    #region ModifyModeCommand
    public class ModifyModeCommand : CommCmdBase
    {
        private WorkingMode _newMode;

        public override int LatencyTime
        {
            get { return XGConfig.Default.XgCmdLatencyTime; }
        }
        
        public WorkingMode WorkingMode
        {
            get { return _newMode; }
            set { _newMode = value; }
        }

        public ModifyModeCommand( XGStation station, WorkingMode newMode )
        {
            ArgumentChecker.CheckNotNull ( station );
            Station = station;
            _newMode = newMode;
        }

        public override byte[] MakeCommand()
        {
            byte[] datas = new byte[]{ (byte)_newMode };
            return XGCommandMaker.MakeCommand( Station.Address,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_MODIFY_MODE,
                datas );
        }
        
        public override CommResultState ProcessReceived(byte[] data)
        {
            return XGCommandMaker.CheckReceivedData( Station.Address,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_MODIFY_MODE,
                data );
        }
    }
    #endregion // ModifyModeCommand

    #region Card
    
    public class Card : KeyedSubObjectBase , IComparable 
    {
        private string _serialNumber;

        private string _person = string.Empty ;

        private string _remark = string.Empty ;

        public Card( string serialNumber )
        {
            //_serialNumber = serialNumber;
            SetSerialNumber( serialNumber );
        }

        public Card ( string serialNumber, string person )
            : this ( serialNumber )
        {
            Person = person;
        }

        public Card ( string serialNumber, string person, string remark )
            : this ( serialNumber, person )
        {
            _remark = remark; 
        }


        public string SerialNumber
        {
            get { return _serialNumber; }
            set { SetSerialNumber( value ); }
        }

        public string Person
        {
            get { return _person; }    
            set 
            { 
                _person = value; 
            }
        }

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private void SetSerialNumber ( string serialNumber )
        {
            if ( this.PrimaryCollection != null )
            {
                CardsCollection cards = PrimaryCollection as CardsCollection;
                cards.ValidateSerialNumber( serialNumber, this );
            }

            _serialNumber = serialNumber;
        }

        #region IComparable 成员
        public int CompareTo(object obj)
        {
            Card c = obj as Card;
            if ( c == null )
                throw new NullReferenceException();

            //return _serialNumber.ToLower().CompareTo( c.SerialNumber.ToLower() );

            if ( obj is Card )
                return CompareTo( (Card) obj );
            else if ( obj is string )
                return CompareTo( (string) obj );
            else
                throw new ArgumentException();
        }

        public int CompareTo( string serialNumber )
        {
            return _serialNumber.Trim().ToLower().CompareTo( serialNumber.Trim().ToLower() );
        }

        public int CompareTo( Card card )
        {
            return CompareTo( card.SerialNumber );
        }
        #endregion
    }

    #endregion // Card

    #region CardsCollection
    public class CardsCollection : KeyedSubObjectsCollectionBase 
    {
        protected override int InitialCapacity
        {
            get { return 10; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public CardsCollection()
        {
        }

        public bool Exists( Card card )
        {
            return Exists( card.SerialNumber, null );
        }

        public bool Exists( string serialNumber, Card ignore )
        {
            for ( int i=0; i<Count; i++)
            {
                Card c = this [ i ];
                if ( c == ignore )
                    continue;

                if ( c.CompareTo( serialNumber ) == 0 )
                    return true;
            }
            return false;

        }
        
        protected internal void ValidateSerialNumber( string serialNumber, Card ignore )
        {
            if ( Exists( serialNumber, ignore ) )
                throw new ArgumentException ( "Serial number" );

        }
        public void Add( Card card )
        {
            if ( Exists( card ) )
                throw new ArgumentException("card");

            base.InternalAdd ( card );
        }

        public void Remove ( Card card )
        {
            base.InternalRemove( card );
        }

        public Card this[ int index ]
        {
            get 
            {
                return base.GetItem( index ) as Card;
            }
        }
    }
    #endregion // CardsCollection

    #region TestXGSystemCommand
    /// <summary>
    /// 
    /// </summary>
    public class TestXGSystemCommand
    {

        private static string GetXGStationIP( string xgStationName )
        {
            //for test
            //
            return "1.1.1.1";
        }
        TaskEventProcessor tep = new TaskEventProcessor();
        CommPortProxy commPort = new CommPortProxy(1, "9600,n,8,1");
        XGStation station0 = new XGStation("XGS_name", GetXGStationIP( "XGS_name" ), 0);
        
        // read tasks
        Task queryTask  = null;
        Task readTimeTask = null;
        Task readDateTask = null;
        Task readCountTask = null;
        Task readRecordTask = null;
        //Task removeTask = null;
        
        TaskScheduler taskSch = null;

        public void test()
        {

            commPort.Open();

            queryTask = new Task("Query station", 
                new QueryStationCommand( station0 ),
                new ImmediateTaskStrategy() 
                );
            
            readTimeTask = new Task( "ReadTime",
                new ReadTimeCommand( station0 ),
                new ImmediateTaskStrategy ()
                );
            readDateTask = new Task( "read date",
                new ReadDateCommand( station0),
                new ImmediateTaskStrategy() );
            readCountTask = new Task( "read count",
                new ReadTotalCountCommand( station0 ),
                new ImmediateTaskStrategy() );
            readRecordTask = new Task("read record",
                new ReadRecordCommand( station0, 1),
                new ImmediateTaskStrategy() );


            //readTimeTask.AfterProcessReceived += new EventHandler(readTimeTask_AfterProcessReceived);
            //readTimeTask.AfterExecuteTask +=new EventHandler(tep.AfterSend);
            //readTimeTask.AfterProcessReceived += new EventHandler(tep.AfterReceived);
            BindTaskEvent ( readTimeTask, tep );
            BindTaskEvent ( queryTask, tep );
            BindTaskEvent ( readDateTask, tep );
            BindTaskEvent ( readCountTask, tep );
            BindTaskEvent ( readRecordTask, tep );
            
            taskSch = new TaskScheduler( commPort );
            //taskSch.Tasks.Add( queryTask );
            taskSch.Tasks.Add( readTimeTask );
            taskSch.Tasks.Add( queryTask );
            taskSch.Tasks.Add( readDateTask );
            taskSch.Tasks.Add( readCountTask );
            taskSch.Tasks.Add( readRecordTask );

            taskSch.Enabled = true;

        }

        //private void readTimeTask_AfterProcessReceived(object sender, EventArgs e)
        //{
        //    Task t = sender as Task;
        //    
        //    //System.Windows.Forms.MessageBox.Show(t.LastCommResultState.ToString() );
        //    //System.Diagnostics.Debug.Assert( t.LastReceived.Length != 0 );
        //    ReadTimeCommand rtc = t.CommCmd  as ReadTimeCommand;
        //    string s = rtc.Hour + ":" + rtc.Minute + ":" + rtc.Second;
        //    System.Windows.Forms.MessageBox.Show(s);
        //}
        public string GetOperateLogs()
        {
            string s = string.Empty;
            OperationLogsCollection logs = station0.OperationLogs ;
            for (int i=0; i<logs.Count; i++)
            {
                string sLog = string.Empty;
                sLog = logs[i].DateTime.ToString() + logs[i].Content;
 
                s += sLog + Environment.NewLine;
            }
            return s;
        }

        private void BindTaskEvent( Task task, TaskEventProcessor tep)
        {
            task.AfterExecuteTask += new EventHandler(tep.AfterSend );
            task.AfterProcessReceived += new EventHandler(tep.AfterReceived);
        }
    }
    #endregion //TestXGSystemCommand

    #region TaskEventProcessor 
    public class TaskEventProcessor
    {
        private Task GetTask (object sender )
        {
            Task t = sender as Task;
            Debug.Assert (t != null);
            return t;
        }

        private XGStation GetXGStation( object sender )
        {
            Task t = GetTask( sender );
            return t.CommCmd.Station as XGStation;
        }

        public void AfterSend( object sender, EventArgs e )
        {
            // get station
            //
            XGStation station = GetXGStation( sender );
            //station.Logs.
            // get send datetime
            // 
            Task t = GetTask(sender);
            string lastSendDt = t.LastSendDateTime.ToString() ;

            // get send byte[] datas
            //
            string lastSendDatas = BytesToString( t.LastSendDatas );

            // command type
            //
            string cmdType = t.CommCmd.GetType().Name;

            // make log string
            //
            string s = "Send: " + lastSendDt + " " + lastSendDatas;

            s = cmdType + Environment.NewLine + s;
            // add log to station.logs
            //
            station.Logs.Add( new OperationLog( s ) );
        }

        public void AfterReceived( object sender, EventArgs e )
        {
            XGStation station = GetXGStation( sender );
            Task t = GetTask(sender);
            string lastReceivedDT = t.LastReceivedDateTime.ToString();
            string lastReceivedData = BytesToString( t.LastReceived ); 
            string cmdType = t.CommCmd.GetType().Name ;

            string s = "Rece: " + lastReceivedDT + " " + lastReceivedData;
            s = cmdType + Environment.NewLine + s;

            station.Logs.Add( new OperationLog( s ) );
        }

        private string BytesToString( byte[] bytes )
        {
            string s = string.Format("[{0}] {1}",
                bytes.Length.ToString("00"), 
                CT.BytesToString(bytes) );
            return s;
        }
    }
    #endregion // TaskEventProcessor
}
