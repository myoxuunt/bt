using System;
using CFW;
using Communication.GRCtrl;
using Communication.LanDi;

namespace Communication
{
	/// <summary>
	/// CommCmdText ��ժҪ˵����
	/// </summary>
	public class CommCmdText
	{
		private CommCmdText()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		static public string GetCommCmdText( CommCmdBase cmd )
		{
            string r = string.Empty;
            string stName = cmd.Station.StationName;
            string ip = cmd.Station.DestinationIP;

			if( ! Singles.S.CommPortProxyCollection.IsConnected ( ip ) )
            {
                r = string.Format( "ͬ {0}({1}) ��δ��������!", stName, ip );
            }
            else
            {
				if ( cmd is GRRealDataCommand )
				{
					r = string.Format( "���ڲɼ� {0}({1}) ����ʵʱ����...",stName, ip );                   
				}
				else if ( cmd is ReadTotalCountCommand )
				{
					r = string.Format( "���ڶ�ȡ {0}({1}) Ѳ����¼����...", stName, ip );
				}
				else if ( cmd is ReadRecordCommand )
				{
					ReadRecordCommand c = (ReadRecordCommand)cmd;
					r = string.Format( "���ڶ�ȡ {0}({1}) ��{2}��Ѳ����¼...", stName, ip , c.RecordIndex );
				}
				else if ( cmd is AutoReportCommand )
				{
					r = string.Format( "������� {0}({1}) ����Ѳ������...", stName, ip );
				}
				else if ( cmd is GRReadPressAlarmSetCommand )
				{
					r = string.Format ( "���ڶ�ȡ {0}({1}) ѹ�������趨...", stName, ip );
				}
				else if ( cmd is GRWritePressAlarmSetCommand )
				{
					r = string.Format( "�������� {0}({1}) ѹ�������趨...", stName , ip );
				}
				else if ( cmd is GRReadTempWLAlarmSetCommand )
				{
					r = string.Format(  "���ڶ�ȡ {0}({1}) �¶ȱ����趨...", stName, ip );
				}
				else if ( cmd is GRWriteTempWLAlarmSetCommand )
				{
					r = string.Format( "�������� {0}({1}) �¶ȱ����趨...", stName, ip );
				}
				else if ( cmd is GRCyclePumpOpCmd )
				{
					GRCyclePumpOpCmd tc = cmd as GRCyclePumpOpCmd;
					string s;
					if ( tc.OP == PumpOP.Stop )
						s = "����ֹͣ";
					else
						s = "��������";
					r = string.Format( s + " {0}({1}) ѭ����...", stName, ip );
				}
				else if ( cmd is GRRePumpOpCmd )
				{
					GRRePumpOpCmd tc = cmd as GRRePumpOpCmd;
					string s;
					if ( tc.OP == PumpOP.Stop )
						s = "����ֹͣ";
					else
						s = "��������";

					r = string.Format( s + " {0}({1}) ��ˮ��...", stName, ip );
				}
				else if ( cmd is GRReadTLCommand )
				{
					r = string.Format( "���ڶ�ȡ {0}({1}) �¶ȿ�������...", stName , ip );
				}
				else if ( cmd is GRSetOutSideTempCommand )
				{
					r = string.Format( "�������� {0}({1}) �����¶�...", stName, ip ); 
				}
				else if ( cmd is GRSetOutSideTempModeCommand )
				{
					r =  string.Format( "�������� {0}({1}) �����¶�ģʽ...", stName, ip );
				}
				else if ( cmd is ReadDateCommand )
				{
					r = string.Format( "���ڶ�ȡ {0}({1}) Ѳ������������...", stName, ip );
				}
				else if ( cmd is ReadTimeCommand )
				{
					r = string.Format( "���ڶ�ȡ {0}({1}) Ѳ��������ʱ��...", stName, ip );
				}
				else if ( cmd is ModifyDateCommand )
				{
					r = string.Format( "�������� {0}({1}) Ѳ������������...", stName, ip );
				}
				else if ( cmd is ModifyTimeCommand )
				{
					r = string.Format( "�������� {0}({1}) Ѳ��������ʱ��...", stName, ip );
				}
				else if ( cmd is RemoveAllCommand )
				{
					r = string.Format( "����ɾ�� {0}({1}) Ѳ����������¼...", stName, ip );
				}
					//		public override string ToString()
				else if ( cmd is GRWriteOTGT2Line )
				{
					r = string.Format("�������� {0}({1}) �¶ȿ�������...", stName, ip);
				}
				else if ( cmd is GRWriteTimeTempLine )
				{
					r = string.Format("�������� {0}({1}) ��ʱ��������...", stName, ip);
				}
				else if( cmd is GRReadTwoPressChaCommand )
				{
					r = string.Format( "���ڶ�ȡ {0}({1}) ѭ���ò���...", stName, ip );
				}
				else if( cmd is GRWriteTwoPressChaCommand )
				{
					r = string.Format( "�������� {0}({1}) ѭ���ò���...", stName, ip );
				}
				else if( cmd is GRReadRepumpPressSettings )
				{
					r = string.Format( "���ڶ�ȡ {0}({1}) ��ˮ�ò���...", stName, ip );
				}
				else if( cmd is GRWriteRepumpPressSettings )
				{
					r = string.Format( "�������� {0}({1}) ��ˮ�ò���...", stName, ip );
				}
				else
				{
					r = string.Format( "����ִ�� {0}({1}) {2}...", stName, ip, cmd.ToString() );
				}
            }

            return r;
		}
	}
}
