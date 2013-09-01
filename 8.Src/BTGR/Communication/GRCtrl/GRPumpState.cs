using System;

namespace Communication.GRCtrl
{

    /// <summary>
    /// 泵状态
    /// </summary>
    public enum PumpState
    {
        Stop    = 0,
        Running = 1,
    }

	/// <summary>
	/// GRPumpState 的摘要说明。
	/// </summary>
	public class GRPumpState
	{
        static public GRPumpState s_test
        {
            get 
            {
                GRPumpState n = new GRPumpState();
                n._cycPump2 = PumpState.Running;
                return n;
//                return new GRPumpState();
            }
        }
        private PumpState   _cycPump1;
        private PumpState   _cycPump2;
        private PumpState   _cycPump3;
        private PumpState   _recruitPump1;
        private PumpState   _recruitPump2;

        public PumpState CyclePump1
        {
            get { return _cycPump1; }
        }
        public PumpState CyclePump2
        {
            get { return _cycPump2; }
        }
        public PumpState CyclePump3
        {
            get { return _cycPump3; }
        }

        public PumpState RecruitPump1
        {
            get { return _recruitPump1; }
        }

        public PumpState RecruitPump2
        {
            get { return _recruitPump2; }
        }

		private GRPumpState()
		{
		}

        /// <summary>
        /// 将 byte 转换成泵状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        static public GRPumpState Parse( byte state )
        {
            GRPumpState grPs = new GRPumpState();
            grPs._cycPump1 = GetPumpState(state, 0);
            grPs._cycPump2 = GetPumpState(state, 1);
            grPs._cycPump3 = GetPumpState(state, 2);
            grPs._recruitPump1 = GetPumpState(state, 3);
            grPs._recruitPump2 = GetPumpState(state, 4);

            return grPs;
        }

        static public GRPumpState Parse ( System.Data.DataRow r )
        {
            ArgumentChecker.CheckNotNull( r );
            GRPumpState state = new GRPumpState ();
            state._cycPump1 = Convert.ToInt32( r["pumpState1"] ) == 0 ? PumpState.Stop: PumpState.Running ;
            state._cycPump2 = Convert.ToInt32( r["pumpState2"] ) == 0 ? PumpState.Stop: PumpState.Running ;
            state._cycPump3 = Convert.ToInt32( r["pumpState3"] ) == 0 ? PumpState.Stop: PumpState.Running ;
            state._recruitPump1 = Convert.ToInt32( r["addPumpState1"] ) == 0 ? PumpState.Stop: PumpState.Running ;
            state._recruitPump2 = Convert.ToInt32( r["addPumpState2"] ) == 0 ? PumpState.Stop: PumpState.Running ;

            return state;
 
        }

        static private PumpState GetPumpState( byte state, int bitIndex )
        {
            byte mask = (byte)Math.Pow( 2, bitIndex );
            int r = mask & state;
            if ( r > 0 )
                return PumpState.Running;
            else
                return PumpState.Stop;
        }
	}
}
