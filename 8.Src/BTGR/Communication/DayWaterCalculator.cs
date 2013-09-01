using System;
using System.Collections;

namespace Communication
{
        public class WaterDataPoint 
        {
            private string   _name;
            private DateTime _dt;
            private float    _val;
            private float    _usedWater;

            public WaterDataPoint ( string name, DateTime dt, float val )
            {
                _name = name;
                _dt = dt;
                _val = val;
            }

            public string Name
            {
                get { return _name; }
            }

            public DateTime Dt
            {
                get { return _dt; }
            }

            public float Val
            {
                get { return _val; }
            }

            public float UsedWater
            {
                get { return _usedWater; }
                set 
                {
                    if ( value < 0 )
                        throw new ArgumentOutOfRangeException("usedWater", value, "must >= 0" );
                    _usedWater = value; 
                }
            }
        }

	/// <summary>
	/// DayWaterCalculator 的摘要说明。
	/// </summary>
	public class DayWaterCalculator
	{

        DateTime _dtBegin, _dtEnd;
        ArrayList _wdpSet = new ArrayList( 80 );        // 80 station


		public DayWaterCalculator(DateTime dtBegin, DateTime dtEnd)
		{
            _dtBegin = dtBegin;
            _dtEnd = dtEnd;
		}

        public void Process( string name, DateTime dt, float val )
        {
            WaterDataPoint wdp = new WaterDataPoint( name, dt, val );
            WaterDataPoint last;

            if ( FindLast( name, out last ) )
            {
                TimeSpan ts = dt - last.Dt;
                if ( ts.Days == 1 )
                {
                    float usedwater = val - last.Val;
                    last.UsedWater = usedwater;
                }
            }

            // set wdp -> last
            UpdateLast( wdp );
        }

        private bool FindLast( string name, out WaterDataPoint last )
        {
            last = null;
            foreach( object obj in _wdpSet )
            {
                ArrayList array = (ArrayList)obj;
                WaterDataPoint wdp = (WaterDataPoint) array[array.Count-1];
                if ( wdp.Name == name )
                {
                    last = wdp;
                    return true;
                }
            }

            return false;
        }

        private void UpdateLast( WaterDataPoint last )
        {
            foreach( object obj in _wdpSet )
            {
                ArrayList array = (ArrayList) obj;
                WaterDataPoint wdp = (WaterDataPoint) array[0];
                if ( wdp.Name == last.Name )
                {
                    array.Add( last );
                    return ;
                }
            }

            ArrayList newarray = new ArrayList( 31 );   // 31 days
            newarray.Add( last );
            _wdpSet.Add( newarray );
        }

        public ArrayList Result
        {
            get { return _wdpSet; }
        }
	}
}
