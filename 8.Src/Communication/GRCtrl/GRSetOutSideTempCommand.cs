using System;
using CFW;
using System.Diagnostics;

namespace Communication.GRCtrl
{
	/// <summary>
	/// GRSetOutSideTempCommand 的摘要说明。
	/// </summary>
	public class GRSetOutSideTempCommand : CommCmdBase 
    {
        private bool    _isSpecify;
        private float   _outSideTemp;

        public bool IsSpecify
        {
            get { return _isSpecify; }
            set { _isSpecify = value; }
        }

        public float OutSideTemperature
        {
            get { return _outSideTemp; }
            set { _outSideTemp = value; }
        }

        public GRSetOutSideTempCommand ( GRStation st )
        {
            ArgumentChecker.CheckNotNull( st );
            Debug.Assert( st.OSTWorkMode == OutSideTempWorkMode.SetByComputer, 
                "OutSideTempWorkMode != SetByComputer" );
            Station = st;
        }

		public GRSetOutSideTempCommand ( GRStation st, float outSideTemp)
		{
            ArgumentChecker.CheckNotNull( st );

            Station = st;
            _outSideTemp = outSideTemp;
            _isSpecify = true;
		}

        public override int LatencyTime
        {
            //get { return o.s_default.LatencyTime; }
            get  { return XGConfig.Default.GrCmdLatencyTime; }
        }

        public override byte[] MakeCommand()
        {
            if ( ! _isSpecify )
            {
                GRStation grSt = (GRStation) Station;
                if (grSt.OSTWorkMode == OutSideTempWorkMode.SetByComputer)
                    _outSideTemp = Singles.S.OutSideTemperature;
            }

            byte[] datas = BitConverter.GetBytes( _outSideTemp );
            return GRCommandMaker.MakeCommand( Station.Address, 
                GRDef.DEVICE_TYPE, //0xA0, 
                GRDef.FC_SET_OUTSIDE_TEMP, //41, 
                datas );
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            return GRCommandMaker.CheckReceivedData( Station.Address, 
                GRDef.DEVICE_TYPE,//0xA0, 
                GRDef.FC_ANSWER,//41, 
                data );
        }
	}
}
