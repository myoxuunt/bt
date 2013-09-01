using System;
using System.Diagnostics;
using CFW;
using Utilities;

namespace Communication.GRCtrl
{
    public class GRRealDataCommand : CFW.CommCmdBase 
    {
        /// <summary>
        /// 
        /// </summary>
        private GRRealData _realData;

        /// <summary>
        /// 返回接收到的实时数据
        /// </summary>
        public GRRealData GRRealData
        {
            get { return _realData; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        public GRRealDataCommand( GRStation station )
        {
            ArgumentChecker.CheckNotNull ( station );
            this.Station = station;
        }

        /// <summary>
        /// 
        /// </summary>
        public override int LatencyTime
        {
            get
            {
                //return GRConfig.s_default.LatencyTime;
                return XGConfig.Default.GrCmdLatencyTime; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override byte[] MakeCommand()
        {
            byte[] r = new byte[9];
            r[0] = 0x21;            //!
            r[1] = 0x58;            //X
            r[2] = 0x44;            //D
            r[3] = (byte) Station.Address;//dev adr
            r[4] = 0xA0;            //dev type
            r[5] = 0x1E;            // func code
            r[6] = 00;              // inner data len
            byte hi, lo;

            CRC16.CalculateCRC(r, 7, out hi, out lo );
            r[7] = lo;
            r[8] = hi;
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="address"></param>
        /// <param name="realData"></param>
        /// <returns></returns>
        public static CommResultState ProcessReceived( 
            byte[] data,
            out int address,
            out GRRealData realData
            )
        {
            address = -1;
            realData = null;

            if ( data == null || data.Length ==0 )
                return CommResultState.NullData;
            
            if ( data.Length != 113 )
                return CommResultState.LengthError;
            
            if ( data[ 4 ] != 0xA0 || data[ 5 ] != 0x1E )
                return CommResultState.DataError;
            byte cachi,caclo;
            CRC16.CalculateCRC( data, 113 - 2, out cachi, out caclo );
            
            byte hi = data[113-1];
            byte lo = data[113-2];
            
            if ( cachi != hi || caclo != lo )
                return CommResultState.CheckError;

            byte[] innerData = GetReceivedInnerData( data );
            //int 
            address = data[ GRDef.ADDRESS_POS ];
            
            GRRealData rd = GRRealData.Parse( innerData , address);
            //rd.FromAddress = address;

            //_realData = rd;
            realData = rd;
            //Singles.S.OutSideTemperature = _realData.OutSideTemp;

            //Utilities.frmPropertiesGrid f = new frmPropertiesGrid();
            //f.ShowMe( rd,"");
            return CommResultState.Correct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override CommResultState ProcessReceived(byte[] data)
        {
            if ( data == null || data.Length ==0 )
                return CommResultState.NullData;
            
            if ( data.Length != 113 )
                return CommResultState.LengthError;
            
            if ( data[ 4 ] != 0xA0 || data[ 5 ] != 0x1E )
                return CommResultState.DataError;
            byte cachi,caclo;
            CRC16.CalculateCRC( data, 113 - 2, out cachi, out caclo );
            
            byte hi = data[113-1];
            byte lo = data[113-2];
            
            if ( cachi != hi || caclo != lo )
                return CommResultState.CheckError;

            byte[] innerData = GetReceivedInnerData( data );
            int address = data[ GRDef.ADDRESS_POS ];
            
            GRRealData rd = GRRealData.Parse( innerData , address);

            _realData = rd;
            //Singles.S.OutSideTemperature = _realData.OutSideTemp;

            //Utilities.frmPropertiesGrid f = new frmPropertiesGrid();
            //f.ShowMe( rd,"");
            return CommResultState.Correct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        static private byte[] GetReceivedInnerData(byte[] datas )
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
    }
}
