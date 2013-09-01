using System;

namespace Communication
{
    public class XGTime
    {
        /// <summary>
        /// 巡更周期
        /// </summary>
        private enum XgFrequency
        {
            /// <summary> 每天 </summary>
            PerDay
        }
        
        /// <summary>
        /// 最小巡更时间范围10分钟
        /// </summary>
        static public readonly TimeSpan MIN_TIME_RANGE = new TimeSpan( 0, 0, 10, 0, 0 );

        private DateTime _begin;
        private DateTime _end;
        private TimeSpan _offset;
        private XgFrequency _frequency = XgFrequency.PerDay;

        public XGTime( DateTime begin, DateTime end )
        {
            ChangeTimeRange( begin, end );
            _offset = TimeSpan.Zero;
        }

        //private void Check( DateTime b, DateTime e)
        static public void Check( DateTime b, DateTime e)
        {
            TimeSpan tsb = b.TimeOfDay;
            TimeSpan tse = e.TimeOfDay;
            if ( tse - tsb < XGTime.MIN_TIME_RANGE )
                throw new ArgumentException( "XgTime range too small, " + (tse - tsb).ToString());
        }

        public void ChangeTimeRange( DateTime begin, DateTime end )
        {
            // check begin < end 
            //
            Check ( begin, end );
            _begin = begin;
            _end = end;
        }
        
        public bool IsInRange( DateTime dateTime )
        {
            TimeSpan ts = dateTime.TimeOfDay;
            TimeSpan tsb = _begin.TimeOfDay;
            TimeSpan tse = _begin.TimeOfDay;

            return ( ts - tsb >= TimeSpan.Zero ) &&
                ( tse - ts >= TimeSpan.Zero );
        }

        public bool IsInTime ( DateTime dt )
        {
            TimeSpan ts = dt.TimeOfDay;
            TimeSpan tsb = _begin.TimeOfDay;
            TimeSpan tse = _end.TimeOfDay;

            return ( ts - tsb >= TimeSpan.Zero ) &&
                ( tse - ts  >= TimeSpan.Zero ) ;
        }

        public bool IsOutTime ( DateTime dt )
        {
            return !IsInTime( dt );
        }

        public DateTime Begin
        {
            get { return _begin; }
            //set { _begin = value; }
        }

        public DateTime End 
        {
            get { return _end; }
            //set { _end = value; }
        }


    }
}
