using System;
using CFW;

namespace Communication.GRCtrl
{
	/// <summary>
	/// GRPumpOP 的摘要说明。
	/// </summary>
	public class GRPumpOP
	{
		public GRPumpOP()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	}

    public enum PumpOP
    {
        Stop,
        Start,
    }

    #region GRRePumpOpCmd
    public class GRRePumpOpCmd : CommCmdBase
    {
        private PumpOP _op;

        public PumpOP OP
        {
            get { return _op ;}
        }
        private byte GetFC()
        {
            if ( _op == PumpOP.Start )
            {
                return GRDef.FC_REPUMP_START;
            }
            else if ( _op == PumpOP.Stop )
            {
                return GRDef.FC_REPUMP_STOP;
            }
            else 
                throw new ArgumentException( "error PumpOP" );
        }

        public  GRRePumpOpCmd ( GRStation st, PumpOP op )
        {
            ArgumentChecker.CheckNotNull( st );
            Station = st;
            _op = op;
            ArgumentChecker.CheckNotNull( Station );
        }
        public override byte[] MakeCommand()
        {
            return GRCommandMaker.MakeCommand( Station.Address ,
                GRDef.DEVICE_TYPE,
                //GRDef.FC_REPUMP_START,
                GetFC(),
                null );
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            return GRCommandMaker.CheckReceivedData( Station.Address ,
                GRDef.DEVICE_TYPE,
//                GRDef.FC_REPUMP_START,
//                GetFC(),
                GRDef.FC_ANSWER,
                data );
        }

        public override int LatencyTime
        {
            get
            {
                return XGConfig.Default.XgCmdLatencyTime;
            }
        }
    }
    #endregion //GRRePumpOpCmd

    #region GRCyclePumpOpCmd
    public class GRCyclePumpOpCmd : CommCmdBase
    {
        private PumpOP _op;

        public PumpOP OP
        {
            get { return _op; }
        }

        private byte GetFC()
        {
            if ( _op == PumpOP.Start )
            {
                return GRDef.FC_CYCPUMP_START;
            }
            else if ( _op == PumpOP.Stop )
            {
                return GRDef.FC_CYCPUMP_STOP;
            }
            else 
                throw new ArgumentException( "error PumpOP" );
        }

        public  GRCyclePumpOpCmd ( GRStation st, PumpOP op )
        {
            ArgumentChecker.CheckNotNull( st );
            Station = st;
            _op = op;
            ArgumentChecker.CheckNotNull( Station );
        }
        public override byte[] MakeCommand()
        {
            return GRCommandMaker.MakeCommand( Station.Address ,
                GRDef.DEVICE_TYPE,
                //GRDef.FC_REPUMP_START,
                GetFC(),
                null );
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            return GRCommandMaker.CheckReceivedData( Station.Address ,
                GRDef.DEVICE_TYPE,
                //                GRDef.FC_REPUMP_START,
//                GetFC(),
                GRDef.FC_ANSWER,
                data );
        }

        public override int LatencyTime
        {
            get
            {
                return XGConfig.Default.XgCmdLatencyTime;
            }
        }
    }
    #endregion //GRCyclePumpOpCmd
}
