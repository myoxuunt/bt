using System;
using CFW;

namespace Communication.GRCtrl
{  
    /// <summary>
    /// �����¶ȹ���ģʽ
    /// </summary>
    public enum OutSideTempWorkMode
    {
        /// <summary>
        /// ͨ���������ɼ�
        /// </summary>
        CollByControllor = 0,

        /// <summary> 
        /// ͨ����������� 
        /// </summary> 
        SetByComputer = 1,
    }

	/// <summary>
	/// GRSetOutSideTempMode ��ժҪ˵����
	/// </summary>
	public class GRSetOutSideTempModeCommand : CommCmdBase 
	{


        //private bool _collBySelf;
        private OutSideTempWorkMode _workMode;

		public GRSetOutSideTempModeCommand( GRStation st , OutSideTempWorkMode mode)
    	{
			//
			//
            //_collBySelf = collBySelf;
            _workMode = mode;
            Station = st;
		}

        public override int LatencyTime
        {
            get
            {
                //return GRConfig.s_default.LatencyTime;
                return XGConfig.Default.GrCmdLatencyTime;
            }
        }

        public override byte[] MakeCommand()
        {
            byte[] bs = new byte[1];
            bs[0] = (byte)_workMode;
            return GRCommandMaker.MakeCommand( Station.Address, 
                GRDef.DEVICE_TYPE,
                GRDef.FC_SET_OUTSIDE_MODE, 
                bs );
        }
        public override CommResultState ProcessReceived(byte[] data)
        {
            return GRCommandMaker.CheckReceivedData( Station.Address, 
                GRDef.DEVICE_TYPE,//0xA0, 
                GRDef.FC_ANSWER, //40, 
                data );
        }
	}
}
