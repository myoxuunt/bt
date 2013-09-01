using System;
using System.Text;

namespace Communication.LanDi
{
    public class HeartBeat
    {
        private string _simNumber;
        private string _ip;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="simNumber"></param>
        /// <param name="ip"></param>
        public HeartBeat( string simNumber, string ip )
        {
            _simNumber = simNumber;
            _ip = ip;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SimNumber
        {
            get { return _simNumber; } 
            set { _simNumber = value; }
        }

        #region Ip
        /// <summary>
        /// 
        /// </summary>
        public string Ip
        {
        	get { return _ip; }
        	set { _ip = value; }
        }
        #endregion //Ip
    }

	/// <summary>
	/// HeartBeatParser 的摘要说明。
	/// </summary>
	public class HeartBeatParser : BytesParserBase 
	{
		public HeartBeatParser(byte[] bs) : base( bs )
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        /// <summary>
        /// return HeartBeat or null
        /// </summary>
        /// <returns></returns>
        public override object ToValue()
        {
            if( LanDiDef.HEAD.IsMatch( _bytes, 0 ) )
            {
                DataField dfTail = new DataField(
                    _bytes.Length - 2,
                    2,
                    LanDiDef.TAIL.Values
                    );
                if ( dfTail.IsMatch( _bytes, 0 ) )
                {
                    int ipstrPos = LanDiDef.IPSTR.SearchBeginPos( _bytes );
                    if ( ipstrPos != -1 )
                    {
                        DataField dfSimNumber = new DataField(
                            LanDiDef.HEAD_LENGTH,
                            ipstrPos - LanDiDef.HEAD_LENGTH
                            );
                        byte[] simBytes = dfSimNumber.GetMatch( _bytes );

                        DataField dfIP = new DataField(
                            ipstrPos + LanDiDef.IPSTR.DataLength,
                            _bytes.Length - ( ipstrPos + LanDiDef.IPSTR.DataLength + LanDiDef.TAIL_LENGTH )
                            );
                        byte[] ipBytes = dfIP.GetMatch( _bytes );

                        string sim = ASCIIEncoding.ASCII.GetString( simBytes );
                        string ip = ASCIIEncoding.ASCII.GetString( ipBytes );

                        return new HeartBeat( sim, ip );
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override byte[] ToBytes()
        {
            throw new NotImplementedException( "HeartBeatParser.ToBytes" );
        }

	}
}
