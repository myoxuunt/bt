using System;
using CFW;
using Utilities;

namespace Communication.GRCtrl
{
    /// <summary>
    /// 供温模式
    /// </summary>
    public enum GiveTempMode
    {
        /// <summary>
        /// 通过二次供温曲线调整
        /// </summary>
        TempLine,
        /// <summary>
        /// 二次供水温度恒定
        /// </summary>
        TempValue,
    };

    /// <summary>
    /// 
    /// </summary>
    public class GRReadGiveModeCommand : CFW.CommCmdBase 
    {
        private GiveTempMode _giveTempMode;
        private float _giveTempValue;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        public GRReadGiveModeCommand( GRStation st ) 
        {
            if ( st == null )
                throw new ArgumentNullException( "grstation" );
            this.Station = st;
        }

		public override string ToString()
		{
			return string.Format(" {0} {1}", this.Station.StationName, "读取供温模式");
		}


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override byte[] MakeCommand()
        {
            byte[] r = new byte[10];
            r[0] = 0x21;            //!
            r[1] = 0x58;            //X
            r[2] = 0x44;            //D
            r[3] = (byte) Station.Address;
            r[4] = 0xA0;            //dev type
            r[5] = GRDef.FC_READ_SETTINGS;            // func code
            r[6] = 01;              // inner data len
            r[7] = GRDef.MC_GIVETEMP_MODE;
            byte hi, lo;

            CRC16.CalculateCRC(r, 7, out hi, out lo );
            r[8] = lo;
            r[9] = hi;
            return r;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override CommResultState ProcessReceived(byte[] data)
        {
            if ( data == null || data.Length == 0 )
                return CommResultState.NullData;
            if ( data.Length != 9 + 0x0A )
                return CommResultState.LengthError;

            if ( data[4] != 0xA0 || data[ 5 ] != 0x14 )
                return CommResultState.DataError;

            if ( data[6] != 0x0A )
                return CommResultState.DataError;

            byte cachi,caclo;
            CRC16.CalculateCRC( data, data.Length - 2, out cachi, out caclo );
            
            byte hi = data[data.Length-1];
            byte lo = data[data.Length-2];
            
            if ( cachi != hi || caclo != lo )
                return CommResultState.CheckError;

            byte[] innerData = GRCommandMaker.GetReceivedInnerData( data );

            if( innerData[0] != GRDef.MC_GIVETEMP_MODE )
                return CommResultState.DataError;
            
            _giveTempMode = GetGiveTempMode( innerData[1] );
            _giveTempValue = BitConverter.ToSingle( innerData, 2 );
            
            return CommResultState.Correct;
        }
    

        #region GiveTempMode
        /// <summary>
        /// 
        /// </summary>
        public GiveTempMode GiveTempMode
        {
            get { return _giveTempMode; }
        }
        #endregion //GiveTempMode

        #region GiveTempValue
        /// <summary>
        /// 
        /// </summary>
        public float GiveTempValue
        {
            get { return _giveTempValue; }
        }
        #endregion //GiveTempValue

        private GiveTempMode GetGiveTempMode( byte b )
        {
            byte r = (byte)(0x10 & b);
            if ( r != 0 )
                return GiveTempMode.TempValue;
            else
                return GiveTempMode.TempLine;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GRWriteGiveModeCommand : CFW.CommCmdBase
    {
        private GiveTempMode _giveTempMode;
        private float        _giveTempValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        /// <param name="gvm"></param>
        /// <param name="giveTempValue"></param>
        public GRWriteGiveModeCommand(GRStation st, GiveTempMode gvm, float giveTempValue)
        {
            if ( st == null )
                throw new ArgumentNullException( "grstation" );

            this.Station = st;
            _giveTempMode = gvm;
            _giveTempValue = giveTempValue;
        }
		public override string ToString()
		{
			return string.Format(" {0} {1}", this.Station.StationName, "设置供温模式");
		}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override byte[] MakeCommand()
        {
            byte[] r = new byte[19];
            r[0] = 0x21;            //!
            r[1] = 0x58;            //X
            r[2] = 0x44;            //D
            r[3] = (byte) Station.Address;
            r[4] = 0xA0;            //dev type
            r[5] = GRDef.FC_WRITE_SETTINGS;            // func code
            r[6] = 0x0A;              // inner data len
            r[7] = GRDef.MC_GIVETEMP_MODE;
            r[8] = GetGiveTempModeByte();
            byte[] gvbs = GetTempValueBytes();
            r[9] = gvbs[0];
            r[10] =gvbs[1];
            r[11] =gvbs[2];
            r[12] =gvbs[3];
            r[13] =0;
            r[14] =0;
            r[15] =0;
            r[16] =0;

            byte hi, lo;
            CRC16.CalculateCRC(r, 17, out hi, out lo );
            r[17] = lo;
            r[18] = hi;
            return r;
            
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            return GRCommandMaker.CheckReceivedData( Station.Address, 
                GRDef.DEVICE_TYPE,
                GRDef.FC_ANSWER,
                data );
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private byte[] GetTempValueBytes()
        {
            return BitConverter.GetBytes( _giveTempValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private byte GetGiveTempModeByte()
        {
            if ( _giveTempMode == GiveTempMode.TempLine )
                return 0x00;
            else if (_giveTempMode == GiveTempMode.TempValue )
                return 0x10;
            else
                throw new Exception("unknown giveTempMode " + _giveTempMode);
        }
    }
}
