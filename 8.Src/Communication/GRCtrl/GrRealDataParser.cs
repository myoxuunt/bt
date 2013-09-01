using System;
using CFW;
using Utilities;

namespace Communication.GRCtrl
{
	/// <summary>
	/// GrRealDataParser 的摘要说明。
	/// </summary>
	public class GrRealDataParser : BytesParserBase
	{
        private const int GR_REALDATA_LENGTH = 113;

        private CommResultState _commResultState = CommResultState.UnknownError;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
		public GrRealDataParser( byte[] bs ) : base( bs )
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override byte[] ToBytes()
        {
            throw new NotImplementedException("ToBytes()");
        }

        /// <summary>
        /// return a grRealData or null
        /// </summary>
        /// <returns></returns>
        public override object ToValue()
        {
            byte[] data = _bytes;

            if ( data == null || data.Length ==0 )
            {
                _commResultState = CommResultState.NullData;
                return null;
            }
            
            if ( data.Length != 113 )
            {
                _commResultState = CommResultState.LengthError;
                return null;
            }
            
            // dev type and fc
            if ( data[ 4 ] != 0xA0 || data[ 5 ] != 0x1E )
            {
                _commResultState = CommResultState.DataError;
                return null;
            }

            byte cachi,caclo;
            CRC16.CalculateCRC( data, 113 - 2, out cachi, out caclo );
            
            byte hi = data[113-1];
            byte lo = data[113-2];
            
            if ( cachi != hi || caclo != lo )
            {
                _commResultState = CommResultState.CheckError;
                return null;
            }

            int address = -1;
            address = data[ GRDef.ADDRESS_POS ];
            
            byte[] innerData = GRCommandMaker.GetReceivedInnerData( data );
            GRRealData realData = GRRealData.Parse( innerData , address);

            if ( realData != null )
            {
                _commResultState = CommResultState.Correct;
            }
            _value = realData;
            return realData;
        }

        /// <summary>
        /// 
        /// </summary>
        public CommResultState CommResultState
        {
            get { return _commResultState; }
        }
	}
}
