using System;
using CFW;

namespace Communication.GRCtrl
{
    #region GRPressAlarmSetCommand
	/// <summary>
	/// GRPressAlarmSetCommand 的摘要说明。
	/// </summary>
	public abstract class GRPressAlarmSetCommand :CommCmdBase 
	{
        protected float _oneGivePressLoSetV;
        protected float _twoGivePressHiSetV;
        protected float _twoBackPressHiSetV;
        protected float _twoBackPressLoSetV;

        public float OneGivePressLo
        {
            get { return _oneGivePressLoSetV; }
        }

        public float TwoGivePressHiSetV
        {
            get { return _twoGivePressHiSetV; }
        }

        public float TwoBackPressHiSetV
        {
            get { return _twoBackPressHiSetV; }
        }

        public float TwoBackPressLoSetV
        {
            get { return _twoBackPressLoSetV; }
        }

		public GRPressAlarmSetCommand(GRStation st)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            ArgumentChecker.CheckNotNull( st );
            Station  = st;
		}
	}

    #endregion //GRPressAlarmSetCommand

    #region GRReadPressAlarmSetCommand
    public class GRReadPressAlarmSetCommand : GRPressAlarmSetCommand 
    {
        public GRReadPressAlarmSetCommand( GRStation st )
            : base ( st )
        {
        }

        private byte[] GetInnerDatas()
        {
            return new byte[] {GRDef.MC_PRESS_ALARM};
        }

        public override byte[] MakeCommand()
        {
            return GRCommandMaker.MakeCommand( Station.Address,
                GRDef.DEVICE_TYPE,
                GRDef.FC_READ_SETTINGS,
                GetInnerDatas() );
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            CommResultState r = GRCommandMaker.CheckReceivedData( Station.Address,
                GRDef.DEVICE_TYPE,
                GRDef.FC_READ_SETTINGS,
                data );
            if ( r == CommResultState.Correct )
            {
                byte[] innerDatas = GRCommandMaker.GetReceivedInnerData ( data );
                System.Diagnostics.Debug.Assert( innerDatas != null &&
                    innerDatas.Length == 17 );

                if ( innerDatas[0] == GRDef.MC_PRESS_ALARM )
                {
                    _oneGivePressLoSetV = BitConverter.ToSingle( innerDatas, 0 * 4 + 1 );
                    _twoGivePressHiSetV = BitConverter.ToSingle( innerDatas, 1 * 4 + 1 );
                    _twoBackPressHiSetV = BitConverter.ToSingle( innerDatas, 2 * 4 + 1 );
                    _twoBackPressLoSetV = BitConverter.ToSingle( innerDatas, 3 * 4 + 1 );
                }
                else
                {
                    return CommResultState.DataError;
                }
            }
            return r;
        }
        public override int LatencyTime
        {
            get
            {
                return XGConfig.Default.XgCmdLatencyTime;
            }
        }
    }
    #endregion //GRReadPressAlarmSetCommand

    #region GRWritePressAlarmSetCommand
    public class GRWritePressAlarmSetCommand : GRPressAlarmSetCommand 
    {
        public GRWritePressAlarmSetCommand ( GRStation st, 
            float oneGivePressLoSetV,
            float twoGivePressHiSetV,
            float twoBackPressHiSetV,
            float twoBackPressLoSetV ) : base ( st )
        {
            _oneGivePressLoSetV = oneGivePressLoSetV;
            _twoGivePressHiSetV = twoGivePressHiSetV;
            _twoBackPressHiSetV = twoBackPressHiSetV;
            _twoBackPressLoSetV = twoBackPressLoSetV;
        }

        private byte[] GetInnerDatas ()
        {
            byte[] r = new byte[ 17 ];
            r[0] = GRDef.MC_PRESS_ALARM;
            Array.Copy( BitConverter.GetBytes( _oneGivePressLoSetV ), 0, r, 0 * 4 + 1, 4 );
            Array.Copy( BitConverter.GetBytes( _twoGivePressHiSetV ), 0, r, 1 * 4 + 1, 4 );
            Array.Copy( BitConverter.GetBytes( _twoBackPressHiSetV ), 0, r, 2 * 4 + 1, 4 );
            Array.Copy( BitConverter.GetBytes( _twoBackPressLoSetV ), 0, r, 3 * 4 + 1, 4 );

            return r;
        }
        public override byte[] MakeCommand()
        {
            return GRCommandMaker.MakeCommand( Station.Address,
                GRDef.DEVICE_TYPE,
                GRDef.FC_WRITE_SETTINGS,
                GetInnerDatas() );
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            return GRCommandMaker.CheckReceivedData( Station.Address,
                GRDef.DEVICE_TYPE,
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
    #endregion //GRWritePressAlarmSetCommand

}
