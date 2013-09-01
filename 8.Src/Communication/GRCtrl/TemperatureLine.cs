using System;
using CFW;

namespace Communication.GRCtrl
{
	
    #region TemperatureLine
	/// <summary>
	/// 温度曲线
	/// </summary>
    public class TemperatureLine
    {
        #region GetDefaultTemperatureLine
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public static TemperatureLine GetDefaultTemperatureLine()
        {
            GRReadTLCommand c = new GRReadTLCommand( new GRStation("aa",0,"1.1.1.1") );
            if ( c.ProcessReceived( GRReadTLCommand.test_receive ) == CommResultState.Correct )
                return c.TemperatureLine;
            else
                return null;
        }
        #endregion //GetDefaultTemperatureLine

		/// <summary>
		/// 数据点个数
		/// </summary>
		private const int _size = 8;

		/// <summary>
		/// 
		/// </summary>
		static public int TemperaturePointNumber
		{
			get {return _size; }
		}
		/// <summary>
		/// 
		/// </summary>
        private TemperatureLinePoint [] _points = new TemperatureLinePoint [ _size ];


        #region TemperatureLine
        public TemperatureLine ()
        {

        }   
        #endregion //TemperatureLine


        #region Check
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public bool Check()
        {
            if ( _points[0] == null )
                return false;

            for ( int i=1; i<_size ; i++ )
            {
                if ( _points[i] == null )
                    return false ;

                if (( _points[i].OutSideTemperature > _points[i-1].OutSideTemperature ) &&
                    ( _points[i].TwoGiveTemperature < _points[i-1].TwoGiveTemperature ))
                {

                }
                else
                {
                    return false;
                }

            }
            return true;
        }
        #endregion //Check


        #region this
        public TemperatureLinePoint this [ int index ]
        {
            get { return _points[ index ];}
            set { _points [ index ] = value; }
        }
        #endregion //this

		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public byte[] GetBytes()
		{
			return TemperatureLine.Parse( this );
		}

        #region Parse
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="beginPos"></param>
        /// <returns></returns>
        static public TemperatureLine Parse ( byte[] datas, int beginPos )
        {
            ArgumentChecker.CheckNotNull( datas );
            if ( datas.Length < ( _size * 2 ) + beginPos )
                throw new ArgumentException ( "datas.length" );
            
            TemperatureLine tl = new TemperatureLine();

            for ( int i=0; i<_size; i++ )
            {
                int idx = i * 2 + beginPos ;
                byte[] pointDatas = new byte[] { datas[idx], datas[idx+1] };
                TemperatureLinePoint p = TemperatureLinePoint.Parse ( pointDatas );
                tl[ i ] = p;
            }

            return tl;
        }
        #endregion //Parse


        #region Parse
		/// <summary>
		/// 
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
        static public byte[] Parse ( TemperatureLine line )
        {
            ArgumentChecker.CheckNotNull( line );
            byte[] bs = new byte[ _size * 2 ];
            for ( int i=0; i<_size; i++ )
            {
                byte[] linePointDatas = TemperatureLinePoint.Parse( line[i] );
                int idx = i * 2;

                bs[ idx ] = linePointDatas[0];
                bs[ idx + 1 ] = linePointDatas[1];
            }
            return bs;
        }
        #endregion //Parse
    }
    #endregion //TemperatureLine
}
