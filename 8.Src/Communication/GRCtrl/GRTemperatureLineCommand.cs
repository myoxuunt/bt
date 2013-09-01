using System;
using CFW;
using Communication;
namespace Communication.GRCtrl
{
	/// <summary>
	/// ��ȡ�¶����� - �����¶ȿ��� �� ��ʱ����
	/// </summary>
	public class GRTemperatureLineCommand
	{
		#region GRTemperatureLineCommand
		public GRTemperatureLineCommand()
		{
		}
		#endregion //GRTemperatureLineCommand
	}


	#region GRReadTLCommand
	/// <summary>
	/// 
	/// </summary>
	public class GRReadTLCommand : CommCmdBase 
	{
		#region test_receive
		public static byte[]  test_receive = new byte[] {
															0x21, 0x58, 0x44, 0x00, 0xA0, 0x14, 0x1D, 0x48, 0xE2, 0x50, 
															0xE7, 0x4B, 0xEC, 0x46, 0xF1, 0x41, 0xF6, 0x3C, 0xFB, 0x37, 
															0x00, 0x32, 0x05, 0x2D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
															0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xC0, 0xAD
														};
		#endregion //test_receive

		/// <summary>
		/// 
		/// </summary>
		private TemperatureLine _tl;

		#region GRReadTLCommand
		/// <summary>
		/// 
		/// </summary>
		/// <param name="st"></param>
		public GRReadTLCommand ( GRStation st )
		{
			ArgumentChecker.CheckNotNull( st );
			Station = st ;
		}
		#endregion //GRReadTLCommand


		#region LatencyTime
		/// <summary>
		/// 
		/// </summary>
		public override int LatencyTime
		{
			get { return XGConfig.Default.GrCmdLatencyTime; }
		}
		#endregion //LatencyTime

		#region TemperatureLine
		/// <summary>
		/// 
		/// </summary>
		public TemperatureLine TemperatureLine 
		{
			get { return _tl; }
		}
		#endregion //TemperatureLine

		/// <summary>
		///  
		/// </summary>
		public TimeTempLine TimeTempLine
		{
			get { return _timetempline; }
		} private TimeTempLine _timetempline;

		#region MakeCommand
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override byte[] MakeCommand()
		{
			byte[] datas = new byte[] { GRDef.MC_TEMPERATURE_LINE };
			return GRCommandMaker.MakeCommand( Station.Address,
				GRDef.DEVICE_TYPE, GRDef.FC_READ_SETTINGS, datas );
		}
		#endregion //MakeCommand


		#region ProcessReceived
		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override CommResultState ProcessReceived(byte[] data)
		{
			CommResultState r = GRCommandMaker.CheckReceivedData( Station.Address,
				GRDef.DEVICE_TYPE, GRDef.FC_READ_SETTINGS, data );

			if ( r == CommResultState.Correct )
			{
				byte[] innerDatas = GRCommandMaker.GetReceivedInnerData( data );

				byte mc = innerDatas[0];
				if ( mc == GRDef.MC_TEMPERATURE_LINE )
				{
					_tl = TemperatureLine.Parse( innerDatas, 1 );
					this._timetempline = TimeTempLine.Parse( innerDatas, 1 + 16 );
				}
				else
				{
					return CommResultState.DataError;
				}
			}
			return r;
		}
		#endregion //ProcessReceived
	}
	#endregion //GRReadTLCommand

	
	//    #region GRWriteTLCommand
	//	/// <summary>
	//	/// 
	//	/// </summary>
	//    public class GRWriteTLCommand : CommCmdBase 
	//    {
	//        private TemperatureLine _line;
	//		private TimeTempLine _timetempline;
	//
	//
	//        #region GRWriteTLCommand
	//		/// <summary>
	//		/// 
	//		/// </summary>
	//		/// <param name="st"></param>
	//		/// <param name="line"></param>
	//		/// <param name="timetempline"></param>
	//        public GRWriteTLCommand( GRStation st , TemperatureLine line, TimeTempLine timetempline )
	//        {
	//            ArgumentChecker.CheckNotNull( st );
	//            ArgumentChecker.CheckNotNull( line );
	//			if( timetempline == null )
	//				throw new ArgumentNullException("timetempline");
	//
	//            Station = st;
	//            _line = line;
	//			_timetempline = timetempline;
	//        }
	//        #endregion //GRWriteTLCommand
	//
	//
	//        #region MakeCommand
	//		/// <summary>
	//		/// 
	//		/// </summary>
	//		/// <returns></returns>
	//        public override byte[] MakeCommand()
	//        {
	//            byte[] tlBs = TemperatureLine.Parse( _line );
	//
	//            byte[] bs = new byte[29];
	//            bs[0] = GRDef.MC_TEMPERATURE_LINE;
	//            Array.Copy( tlBs, 0, bs, 1, tlBs.Length );
	//
	//			// ttlbs - timetempline
	//			//
	//			byte[] ttlbs = this._timetempline.GetBytes();
	//			Array.Copy( ttlbs, 0, bs, 1 + tlBs.Length, ttlbs.Length );
	//
	//            return GRCommandMaker.MakeCommand( Station.Address, 
	//                                    GRDef.DEVICE_TYPE,
	//                                    GRDef.FC_WRITE_SETTINGS,
	////                                    _line.CreateInnerDatas() );
	//                                     bs);
	//        }
	//        #endregion //MakeCommand
	//
	//
	//        #region ProcessReceived
	//        public override CommResultState ProcessReceived(byte[] data)
	//        {
	//            return GRCommandMaker.CheckReceivedData( Station.Address, 
	//                                                GRDef.DEVICE_TYPE, 
	//                                                GRDef.FC_ANSWER, 
	//                                                data );
	//        }
	//        #endregion //ProcessReceived
	//
	//
	//        #region LatencyTime
	//        public override int LatencyTime
	//        {
	//            get
	//            {
	//                return XGConfig.Default.XgCmdLatencyTime;
	//            }
	//        }
	//        #endregion //LatencyTime
	//    }
	//    #endregion //GRWriteTLCommand

	/// <summary>
	/// 
	/// </summary>
	public class GRWriteOTGT2Line : CommCmdBase 
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="st"></param>
		public GRWriteOTGT2Line( GRStation st, TemperatureLine tl )
		{
			Station = st;
			_tl = tl;
		}

		private TemperatureLine _tl;
		#region LatencyTime
		/// <summary>
		/// 
		/// </summary>
		public override int LatencyTime
		{
			get { return XGConfig.Default.GrCmdLatencyTime; }
		}
		#endregion //LatencyTime


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override byte[] MakeCommand()
		{
			//1.��λ�´��¶�����
			//��λ�´���21 58 44 00 A0 3C 10 + ���� +  CRC�����ֽ�+���ֽڣ�
			//�������ݣ�21 58 44 00 A0 0A 00 CRC16��������ȷ��
			byte[] bs = this._tl.GetBytes();
			return GRCommandMaker.MakeCommand( Station.Address,
				GRDef.DEVICE_TYPE,
				GRDef.FC_WRITE_TEMPERATURE_LINE,
				bs );
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override CommResultState ProcessReceived(byte[] data)
		{ 
			return GRCommandMaker.CheckReceivedData( Station.Address, 
				GRDef.DEVICE_TYPE, 
				GRDef.FC_ANSWER, 
				data );
		}


	}



	/// <summary>
	/// 
	/// </summary>
	public class GRWriteTimeTempLine: CommCmdBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="st"></param>
		public GRWriteTimeTempLine( GRStation st, TimeTempLine  ttl )
		{
			Station = st;
			if( ttl == null )
			{
				throw new ArgumentNullException("ttl");
			}
			_ttl = ttl;
		}

		/// <summary>
		/// 
		/// </summary>
		public TimeTempLine TimeTempLine
		{
			get { return _ttl; }
		}
		private TimeTempLine _ttl;

		#region LatencyTime
		/// <summary>
		/// 
		/// </summary>
		public override int LatencyTime
		{
			get { return XGConfig.Default.GrCmdLatencyTime; }
		}
		#endregion //LatencyTime


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override byte[] MakeCommand()
		{
			//1.��λ�´��¶�����
			//��λ�´���21 58 44 00 A0 3C 10 + ���� +  CRC�����ֽ�+���ֽڣ�
			//�������ݣ�21 58 44 00 A0 0A 00 CRC16��������ȷ��
			byte[] bs = this._ttl.GetBytes();
			return GRCommandMaker.MakeCommand( Station.Address,
				GRDef.DEVICE_TYPE,
				GRDef.FC_WRITE_TIME_TEMPERATURE_LINE,
				bs );
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override CommResultState ProcessReceived(byte[] data)
		{ 
			return GRCommandMaker.CheckReceivedData( Station.Address, 
				GRDef.DEVICE_TYPE, 
				GRDef.FC_ANSWER, 
				data );
		}

		//		/// <summary>
		//		/// 
		//		/// </summary>
		//		/// <returns></returns>
		//		public override string ToString()
		//		{
		//			string s = string.Format("���� {0} ��ʱ��������...", this.Station.StationName);
		//			return s;
		//		}

	}


}
