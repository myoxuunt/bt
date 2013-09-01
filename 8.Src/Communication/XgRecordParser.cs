using System;
using CFW;
using Utilities;

namespace Communication
{
	/// <summary>
	/// XgRecordParser ��ժҪ˵����
	/// </summary>
	public class XgRecordParser : BytesParserBase 
	{
        private CommResultState _commResultState = CommResultState.UnknownError;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
		public XgRecordParser(byte[] bs ) : base( bs )
		{
		}

        /// <summary>
        /// reutrn xgdata or null
        /// </summary>
        /// <returns></returns>
        public override object ToValue()
        {
            byte[] data = _bytes;
            CommResultState state = XGCommandMaker.CheckReceivedData(// this.Station.Address,
                XGDefinition.DEVICE_TYPE,
                XGDefinition.FC_READ_RECORD,
                data );

            _commResultState = state;

            // ��ȷʱ�����¼���ݣ�����ʱ�����ϴζ�ȡ�����ݲ��䡣
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
                    Record  record = Record.Analyze( innerDatas );
                    if ( record == null )
                        return null;

                    XGData xgdata = new XGData( record.CardSN, address, record.DateTime, false );
                    _value = xgdata;
                    return xgdata;
                }
                else if(innerDataLen == 1) // recode index error
                {
                    //_recordTotalCount = innerDatas[0];
                    return null;
                }
                else
                {
                    //throw new Exception("Read recode inner data error.");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override byte[] ToBytes()
        {
            throw new NotImplementedException( "ToBytes()" );
        }


	}
}
