using System;
using CFW;

namespace Communication.GRCtrl
{

    #region GRReadTwoPressChaCommand
	/// <summary>
	/// cycle pump param
	/// </summary>
    public class GRReadTwoPressChaCommand : CommCmdBase 
    {
        private CyclePumpMode    _cycPumpCtrlMode ;
        private float   _pressChaSetValue;
        private float   _backPressSetValue;

        /// <summary>
        /// 循环泵控制方式
        /// </summary>
        public CyclePumpMode CyclePumpCtrlMode
        {
            get { return _cycPumpCtrlMode; }
        }

        /// <summary>
        /// 压差设定
        /// </summary>
        public float PressChaSet
        {
            get { return _pressChaSetValue; }
        }

        /// <summary>
        /// 回压设定
        /// </summary>
        public float BackPressSet
        {
            get { return _backPressSetValue; }
        }


        public GRReadTwoPressChaCommand ( GRStation st )
        {
            ArgumentChecker.CheckNotNull( st );
            this.Station = st;
        }

        public override byte[] MakeCommand()
        {
            byte [] datas = new byte[] { GRDef.MC_TWOPRESS_CHA };
            return GRCommandMaker.MakeCommand ( Station.Address, 
                GRDef.DEVICE_TYPE,
                GRDef.FC_READ_SETTINGS,
                datas );
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            CommResultState r = GRCommandMaker.CheckReceivedData ( Station.Address,
                GRDef.DEVICE_TYPE,
                GRDef.FC_READ_SETTINGS,
                data );
            if ( r == CommResultState.Correct )
            {
                byte[] innerDatas = GRCommandMaker.GetReceivedInnerData( data );
                
//                System.Diagnostics.Debug.Assert ( innerDatas != null &&
//                    innerDatas.Length == 10 );
				if( innerDatas.Length < 10 )
					return CommResultState.LengthError;

                if ( innerDatas [0] == GRDef.MC_TWOPRESS_CHA )
                {
                    _cycPumpCtrlMode = (CyclePumpMode)innerDatas[ 1 ];
                    //                    byte[] pressChaSetValue = new byte[ 4 ];
                    //                    byte[] backPressSetValue = new byte[ 4 ];
                    //                    Array.Copy( innerDatas,2, pressChaSetValue, 0, 4 );
                    //                    Array.Copy( innerDatas,6, backPressSetValue, 0, 4 );

                    _pressChaSetValue = BitConverter.ToSingle(innerDatas, 2 );
                    _backPressSetValue = BitConverter.ToSingle(innerDatas, 6 );

                }
                else
                {
                    return CommResultState.DataError ;
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
    #endregion //GRReadTwoPressChaCommand

	public enum CyclePumpMode 
	{
		//为0000表示PID控制、为0001表示二次供回水压差输出；
		PID控制 = 0,
		二次供回水压差输出 = 1,
	}

	#region GRWriteTwoPressChaCommand
    public class GRWriteTwoPressChaCommand : CommCmdBase 
    {
//        private byte    _cycPumpCtrlMode;
        private CyclePumpMode _cycPumpCtrlMode;
        private float   _pressChaSetValue;
        private float   _backPressSetValue;
        /// <summary>
        /// 循环泵控制方式
        /// </summary>
        public CyclePumpMode  CyclePumpCtrlMode
        {
            get { return _cycPumpCtrlMode; }
        }

        /// <summary>
        /// 压差设定
        /// </summary>
        public float PressChaSet
        {
            get { return _pressChaSetValue; }
        }

        /// <summary>
        /// 回压设定
        /// </summary>
        public float BackPressSet
        {
            get { return _backPressSetValue; }
        }

        public GRWriteTwoPressChaCommand( GRStation st, 
//            byte cyclePumpCtrlMode,
			CyclePumpMode cyclePumpCtrlMode,
            float pressChaSet,
            float backPressSet )
        {
            ArgumentChecker.CheckNotNull( st );
            this.Station = st;

            _cycPumpCtrlMode = cyclePumpCtrlMode;
            _pressChaSetValue = pressChaSet;
            _backPressSetValue = backPressSet;
        }

        private byte[] GetInnerData()
        {
            byte[] r = new byte[ 1 + 1 + 4 + 4 ];       // MC + cycPumpMode + pressSet + backPressSet
            r[0] = GRDef.MC_TWOPRESS_CHA ;
            r[1] = (byte)_cycPumpCtrlMode;
            Array.Copy ( BitConverter.GetBytes( _pressChaSetValue), 0,  r, 2, 4 );
            Array.Copy ( BitConverter.GetBytes( _backPressSetValue ), 0, r, 6, 4 );
            return r;
        }

        public override byte[] MakeCommand()
        {
            return GRCommandMaker.MakeCommand( Station.Address,
                GRDef.DEVICE_TYPE,
                GRDef.FC_WRITE_SETTINGS,
                GetInnerData() );
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
    #endregion //GRWriteTwoPressChaCommand

	public class GRReadRepumpPressSettings : CommCmdBase 
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="st"></param>
		public GRReadRepumpPressSettings ( GRStation st )
		{
			this.Station = st;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override byte[] MakeCommand()
		{
			return GRCommandMaker.MakeCommand( this.Station.Address,
				GRDef.DEVICE_TYPE,
				GRDef.FC_READ_SETTINGS,
				new byte[] { GRDef.MC_RE_PRESS} );
		}

		/// <summary>
		/// 
		/// </summary>
		public float RePressSet
		{
			get { return _rePressSet; }
		} float _rePressSet;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override CommResultState ProcessReceived(byte[] data)
		{
			CommResultState r = GRCommandMaker.CheckReceivedData( Station.Address,
				GRDef.DEVICE_TYPE, GRDef.FC_READ_SETTINGS,
				data );

			if( r == CommResultState.Correct )
			{
				byte[] inner = GRCommandMaker.GetReceivedInnerData( data );
				if( inner.Length < 10 )
					return CommResultState.LengthError;

				if( inner[0] == GRDef.MC_RE_PRESS )
				{
//					byte mode = inner[1];
					_mode = (RePumpMode)inner[1];
					_rePressSet = BitConverter.ToSingle( inner, 2 );
				}
				else
				{
					return CommResultState.DataError;
				}
			}
			return r;
		}

		/// <summary>
		/// 
		/// </summary>
		public RePumpMode Mode 
		{
			get { return _mode; }
		} private RePumpMode _mode;
	}

	/// <summary>
	/// 
	/// </summary>
	public enum RePumpMode
	{
		// 000 - PID控制、为0001表示二次回水压力输出、为0002表示电磁阀；
		PID控制 = 0,
		回水压力输出控制 = 1,
		电磁阀控制 = 2,
	}

	/// <summary>
	/// 
	/// </summary>
	public class GRWriteRepumpPressSettings : CommCmdBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="st"></param>
		/// <param name="mode"></param>
		/// <param name="pressset"></param>
	public 	GRWriteRepumpPressSettings( GRStation st, RePumpMode mode, float pressset )
		{
			Station  = st;
			_repumpMode = mode;
			_perssset = pressset;
		}

		/// <summary>
		/// 
		/// </summary>
		public float PressSet
		{
			get { return _perssset;}
		} private float _perssset;

		/// <summary>
		/// 
		/// </summary>
		public RePumpMode RepumpMode 
		{
			get { return _repumpMode; }
		} private RePumpMode _repumpMode; 

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override byte[] MakeCommand()
		{
			byte[] bs = new byte[10];
			bs[0] = GRDef.MC_RE_PRESS;
			bs[1] = (byte)this.RepumpMode;
			byte[] temp = BitConverter.GetBytes( this._perssset );
			Array.Copy (temp, 0, bs, 2, 4  );

			return GRCommandMaker.MakeCommand( Station.Address,
				GRDef.DEVICE_TYPE, 
				GRDef.FC_WRITE_SETTINGS,
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
	

	public class GRReadTEMPOP : CommCmdBase 
	{
		private float _k,_b;
		private byte[] _ids;

		public byte[] Ids
		{
			get { return _ids; }
		}
		public float K
		{
			get { return _k; }
		}

		public float B
		{
			get { return _b; }
		}
		public GRReadTEMPOP(GRStation st)
		{
			if( st == null )
				throw new ArgumentNullException( "station" );
           
			this.Station = st;
		}

		public override int LatencyTime
		{
			get
			{
				return XGConfig.Default.XgCmdLatencyTime;
			}
		}

		public override byte[] MakeCommand()
		{
			byte[] bs = new byte[] {GRDef.MC_OUTSIDE_TEMPERATURE };
			return GRCommandMaker.MakeCommand( this.Station.Address,
				GRDef.DEVICE_TYPE,
				GRDef.FC_READ_SETTINGS,
				bs );
		}

		public override CommResultState ProcessReceived(byte[] data)
		{
			CommResultState r = GRCommandMaker.CheckReceivedData( this.Station.Address,
				GRDef.DEVICE_TYPE,
				GRDef.FC_READ_SETTINGS,
				data );

			if ( r == CommResultState.Correct )
			{
				byte[] ids = GRCommandMaker.GetReceivedInnerData( data );
				if( ids != null && ids.Length == 19 )
				{
					_b = BitConverter.ToSingle( ids, 15 );
					_k = BitConverter.ToSingle( ids, 11 );
					_ids = ids;
				}
				else
					return CommResultState.LengthError;
			}
			return r;
		}

		public override string ToString()
		{
			return string.Format(" {0} {1}", this.Station.StationName, "读取室外温度修正参数");
		}

	}

	public class GRWriteTEMPOP : CommCmdBase 
	{
		private float _k, _b;
		byte[] _readids;

		public GRWriteTEMPOP( GRStation st , byte[] readids, float k, float b)
		{
			if ( st == null )
				throw new ArgumentNullException("st");
			this.Station = st;
			_k = k;
			_b = b;
			_readids = readids;
		}

		public override int LatencyTime
		{
			get
			{
				return XGConfig.Default.XgCmdLatencyTime ;
			}
		}

		public override byte[] MakeCommand()
		{
			//byte[] bs = new byte[]{};
			byte[] kbs = BitConverter.GetBytes(_k);
			byte[] bbs = BitConverter.GetBytes(_b );

			Array.Copy(kbs,0, _readids, 11, 4 );
			Array.Copy(bbs,0, _readids, 15, 4 );

			return GRCommandMaker.MakeCommand( this.Station.Address,
				GRDef.DEVICE_TYPE,
				GRDef.FC_WRITE_SETTINGS,
				this._readids );
		}

		public override CommResultState ProcessReceived(byte[] data)
		{
			CommResultState r = GRCommandMaker.CheckReceivedData( this.Station.Address,
				GRDef.DEVICE_TYPE,
				GRDef.FC_ANSWER,
				data);
			return r;
		}

		public override string ToString()
		{
			return string.Format(" {0} {1}", this.Station.StationName, "设置室外温度修正参数");
		
		}


	}
    public class GRReadOpenDegree : CommCmdBase 
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="station"></param>
        public GRReadOpenDegree( GRStation station )
        {
            if( station == null )
                throw new ArgumentNullException( "station" );
            this.Station = station;
        }

        /// <summary>
        /// 
        /// </summary>
        public override int LatencyTime
        {
            get
            {
                return XGConfig.Default.XgCmdLatencyTime;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override byte[] MakeCommand()
        {
            byte[] datas = new byte[] { GRDef.MC_OPENDEGREE };
            return GRCommandMaker.MakeCommand( this.Station.Address, 
                GRDef.DEVICE_TYPE,
                GRDef.FC_READ_SETTINGS,
                datas );
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override CommResultState ProcessReceived(byte[] data)
        {
            CommResultState r = GRCommandMaker.CheckReceivedData( this.Station.Address,
                GRDef.DEVICE_TYPE,
                GRDef.FC_READ_SETTINGS,
                data );

            if ( r == CommResultState.Correct )
            {
                byte[] ids = GRCommandMaker.GetReceivedInnerData( data );
                if( ids != null && ids.Length == 4 )
                {
                    if( ids[0] == GRDef.MC_OPENDEGREE )
                    {
                        this._minod = ids[1];
                        this._maxod = ids[2];
                    }
                    else
                    {
                        return CommResultState.DataError;
                    }
                }
            }
            return r;
        }


        public byte MinOpenDegree
        {
            get { return _minod; }
        } private byte _minod;

        public byte MaxOpenDegree
        {
            get { return _maxod; }
        } private byte _maxod;
    }

    /// <summary>
    /// 
    /// </summary>
    public class GRWriteOpenDegree : CommCmdBase 
    {
        private byte _min, _max;
        public GRWriteOpenDegree ( GRStation st, byte min, byte max )
        {
            if ( st == null )
                throw new ArgumentNullException( "st" );
            if ( min > 100 )
                throw new ArgumentOutOfRangeException("min",min,"");
            if ( max > 100 )
                throw new ArgumentOutOfRangeException("max",max,"");

            if( min > max )
                throw new ArgumentException("min > max");

            _min = min; 
            _max = max;
			this.Station = st;
        }

        /// <summary>
        /// 
        /// </summary>
        public override int LatencyTime
        {
            get { return XGConfig.Default.XgCmdLatencyTime; }
        }

        public override byte[] MakeCommand()
        {
            byte[] ids = new byte[] {GRDef.MC_OPENDEGREE, _min, _max, 0};  
            return GRCommandMaker.MakeCommand( this.Station.Address,
                GRDef.DEVICE_TYPE,
                GRDef.FC_WRITE_SETTINGS,
                ids );
        }

        public override CommResultState ProcessReceived(byte[] data)
        {
            CommResultState r = GRCommandMaker.CheckReceivedData( this.Station.Address,
                GRDef.DEVICE_TYPE,
                GRDef.FC_ANSWER,
                data);
            return r;
        }
    }
}
