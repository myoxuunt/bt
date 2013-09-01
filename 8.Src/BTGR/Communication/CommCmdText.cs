using System;
using CFW;
using Communication.GRCtrl;
using Communication.LanDi;

namespace Communication
{
	/// <summary>
	/// CommCmdText 的摘要说明。
	/// </summary>
	public class CommCmdText
	{
		private CommCmdText()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		static public string GetCommCmdText( CommCmdBase cmd )
		{
            string r = string.Empty;
            string stName = cmd.Station.StationName;
            string ip = cmd.Station.DestinationIP;

			if( ! Singles.S.CommPortProxyCollection.IsConnected ( ip ) )
            {
                r = string.Format( "同 {0}({1}) 尚未建立连接!", stName, ip );
            }
            else
            {
				if ( cmd is GRRealDataCommand )
				{
					r = string.Format( "正在采集 {0}({1}) 供热实时数据...",stName, ip );                   
				}
				else if ( cmd is ReadTotalCountCommand )
				{
					r = string.Format( "正在读取 {0}({1}) 巡更记录总数...", stName, ip );
				}
				else if ( cmd is ReadRecordCommand )
				{
					ReadRecordCommand c = (ReadRecordCommand)cmd;
					r = string.Format( "正在读取 {0}({1}) 第{2}条巡更记录...", stName, ip , c.RecordIndex );
				}
				else if ( cmd is AutoReportCommand )
				{
					r = string.Format( "正在清除 {0}({1}) 最新巡更数据...", stName, ip );
				}
				else if ( cmd is GRReadPressAlarmSetCommand )
				{
					r = string.Format ( "正在读取 {0}({1}) 压力报警设定...", stName, ip );
				}
				else if ( cmd is GRWritePressAlarmSetCommand )
				{
					r = string.Format( "正在设置 {0}({1}) 压力报警设定...", stName , ip );
				}
				else if ( cmd is GRReadTempWLAlarmSetCommand )
				{
					r = string.Format(  "正在读取 {0}({1}) 温度报警设定...", stName, ip );
				}
				else if ( cmd is GRWriteTempWLAlarmSetCommand )
				{
					r = string.Format( "正在设置 {0}({1}) 温度报警设定...", stName, ip );
				}
				else if ( cmd is GRCyclePumpOpCmd )
				{
					GRCyclePumpOpCmd tc = cmd as GRCyclePumpOpCmd;
					string s;
					if ( tc.OP == PumpOP.Stop )
						s = "正在停止";
					else
						s = "正在启动";
					r = string.Format( s + " {0}({1}) 循环泵...", stName, ip );
				}
				else if ( cmd is GRRePumpOpCmd )
				{
					GRRePumpOpCmd tc = cmd as GRRePumpOpCmd;
					string s;
					if ( tc.OP == PumpOP.Stop )
						s = "正在停止";
					else
						s = "正在启动";

					r = string.Format( s + " {0}({1}) 补水泵...", stName, ip );
				}
				else if ( cmd is GRReadTLCommand )
				{
					r = string.Format( "正在读取 {0}({1}) 温度控制曲线...", stName , ip );
				}
				else if ( cmd is GRSetOutSideTempCommand )
				{
					r = string.Format( "正在设置 {0}({1}) 室外温度...", stName, ip ); 
				}
				else if ( cmd is GRSetOutSideTempModeCommand )
				{
					r =  string.Format( "正在设置 {0}({1}) 室外温度模式...", stName, ip );
				}
				else if ( cmd is ReadDateCommand )
				{
					r = string.Format( "正在读取 {0}({1}) 巡更控制器日期...", stName, ip );
				}
				else if ( cmd is ReadTimeCommand )
				{
					r = string.Format( "正在读取 {0}({1}) 巡更控制器时间...", stName, ip );
				}
				else if ( cmd is ModifyDateCommand )
				{
					r = string.Format( "正在设置 {0}({1}) 巡更控制器日期...", stName, ip );
				}
				else if ( cmd is ModifyTimeCommand )
				{
					r = string.Format( "正在设置 {0}({1}) 巡更控制器时间...", stName, ip );
				}
				else if ( cmd is RemoveAllCommand )
				{
					r = string.Format( "正在删除 {0}({1}) 巡更控制器记录...", stName, ip );
				}
					//		public override string ToString()
				else if ( cmd is GRWriteOTGT2Line )
				{
					r = string.Format("正在设置 {0}({1}) 温度控制曲线...", stName, ip);
				}
				else if ( cmd is GRWriteTimeTempLine )
				{
					r = string.Format("正在设置 {0}({1}) 分时供热曲线...", stName, ip);
				}
				else if( cmd is GRReadTwoPressChaCommand )
				{
					r = string.Format( "正在读取 {0}({1}) 循环泵参数...", stName, ip );
				}
				else if( cmd is GRWriteTwoPressChaCommand )
				{
					r = string.Format( "正在设置 {0}({1}) 循环泵参数...", stName, ip );
				}
				else if( cmd is GRReadRepumpPressSettings )
				{
					r = string.Format( "正在读取 {0}({1}) 补水泵参数...", stName, ip );
				}
				else if( cmd is GRWriteRepumpPressSettings )
				{
					r = string.Format( "正在设置 {0}({1}) 补水泵参数...", stName, ip );
				}
				else
				{
					r = string.Format( "正在执行 {0}({1}) {2}...", stName, ip, cmd.ToString() );
				}
            }

            return r;
		}
	}
}
