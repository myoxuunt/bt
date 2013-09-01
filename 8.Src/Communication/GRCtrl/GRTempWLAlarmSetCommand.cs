using System;
using CFW;

namespace Communication.GRCtrl
{
    #region GRTempWLAlarmSetCommand
    /// <summary>
    /// GRTempWLAlarmSetCommand 的摘要说明。
    /// </summary>
    public abstract class GRTempWLAlarmSetCommand :CommCmdBase 
    {
        protected float _oneGiveTempLoSetV;
        protected float _twoGiveTempHiSetV;
        protected float _wlLoSetV;

        public float OneGiveTempLo
        {
            get { return _oneGiveTempLoSetV; }
        }

        public float TwoGiveTempHiSetV
        {
            get { return _twoGiveTempHiSetV; }
        }

        public float wlLoSetV
        {
            get { return _wlLoSetV; }
        }

        public GRTempWLAlarmSetCommand(GRStation st)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            ArgumentChecker.CheckNotNull( st );
            Station  = st;
        }
        public override int LatencyTime
        {
            get
            {
                return XGConfig.Default.XgCmdLatencyTime;
            }
        }

    }

    #endregion //GRTempWLAlarmSetCommand

    #region GRReadTempWLAlarmSetCommand
    public class GRReadTempWLAlarmSetCommand : GRTempWLAlarmSetCommand 
    {
        public GRReadTempWLAlarmSetCommand( GRStation st )
            : base ( st )
        {
        }

        private byte[] GetInnerDatas()
        {
            return new byte[] {GRDef.MC_TEMPERATURE_ALARM };
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
                    innerDatas.Length == 13 );

                if ( innerDatas[0] == GRDef.MC_TEMPERATURE_ALARM )
                {
                    _oneGiveTempLoSetV = BitConverter.ToSingle( innerDatas, 0 * 4 + 1 );
                    _twoGiveTempHiSetV = BitConverter.ToSingle( innerDatas, 1 * 4 + 1 );
                    _wlLoSetV = BitConverter.ToSingle( innerDatas, 2 * 4 + 1 );
                }
                else
                {
                    return CommResultState.DataError;
                }
            }
            return r;
        }
    }
    #endregion //GRReadTempWLAlarmSetCommand


    #region GRWriteTempWLAlarmSetCommand
    public class GRWriteTempWLAlarmSetCommand : GRTempWLAlarmSetCommand 
    {
        public GRWriteTempWLAlarmSetCommand ( GRStation st, 
            float oneGiveTempLoSetV,
            float twoGiveTempHiSetV,
            float wlLoSetV) : base ( st )
        {
            _oneGiveTempLoSetV = oneGiveTempLoSetV;
            _twoGiveTempHiSetV = twoGiveTempHiSetV;
            _wlLoSetV = wlLoSetV;
        }

        private byte[] GetInnerDatas ()
        {
            byte[] r = new byte[ 17 ];
            r[0] = GRDef.MC_TEMPERATURE_ALARM ;
            Array.Copy( BitConverter.GetBytes( _oneGiveTempLoSetV ), 0, r, 0 * 4 + 1, 4 );
            Array.Copy( BitConverter.GetBytes( _twoGiveTempHiSetV ), 0, r, 1 * 4 + 1, 4 );
            Array.Copy( BitConverter.GetBytes( _wlLoSetV ),          0, r, 2 * 4 + 1, 4 );

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
    }
    #endregion //GRWriteTempWLAlarmSetCommand

}

