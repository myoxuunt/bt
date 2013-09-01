using System;
using System.Diagnostics;
using System.Collections;
using Infragistics.Shared;

namespace CFW
{
    #region TimePoint
    /// <summary>
    ///
    /// </summary>
    /// 
    [Serializable]
    public class TimePoint
    {
        // Ĭ��ʱ��㳤�� 10 ����
        static public readonly TimeSpan DEFAULT_RANGE = new TimeSpan(0,0,0,10,0);

        // ���ʱ��㳤�� 1 ����
        static public readonly TimeSpan MAX_RANGE     = new TimeSpan(0,0,1,0,0);
        
        private DateTime            m_BeginTime;
        private TimeSpan            m_Range;
        private TimePointFrequency  m_Frequency;

        

        private const int IVV = -1;
        private System.DayOfWeek m_Week;

        /// <summary>
        /// ÿ��
        /// </summary>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        public TimePoint ( int Hour, int Minute, int Second )
            : this(IVV, IVV, IVV, Hour, Minute, Second, 0, TimePointFrequency.PerDay)
        {
        }

        /// <summary>
        /// ÿ��
        /// </summary>
        /// <param name="Day"></param>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        public TimePoint ( int Day, int Hour, int Minute, int Second )
            : this(IVV, IVV, Day, Hour, Minute, Second, 0, TimePointFrequency.PerMonth)
        {
        }

        /// <summary>
        /// ÿ��
        /// </summary>
        /// <param name="Month"></param>
        /// <param name="Day"></param>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        public TimePoint ( int Month, int Day, int Hour, int Minute, int Second )
            : this(IVV, Month, Day, Hour, Minute, Second, 0, TimePointFrequency.PerYear) 
        {
        }

        /// <summary>
        /// ÿ��
        /// </summary>
        /// <param name="Week"></param>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        public TimePoint ( DayOfWeek Week, int Hour, int Minute, int Second )
            : this(IVV, IVV, IVV, Hour, Minute, Second, Week, TimePointFrequency.PerWeek)
        {
        }

        /// <summary>
        /// һ�ε�
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Month"></param>
        /// <param name="Day"></param>
        /// <param name="Hour"></param>
        /// <param name="Minute"></param>
        /// <param name="Second"></param>
        public TimePoint ( int Year, int Month, int Day, int Hour, int Minute, int Second )
            : this(Year, Month, Day, Hour, Minute, Second, 0, TimePointFrequency.Once)
        {
        }
        
        private TimePoint (int Year, int Month, int Day, 
            int Hour, int Minute, int Second, 
            DayOfWeek Week, TimePointFrequency Frequency)
        {
            m_Frequency = Frequency;
            m_Range = DEFAULT_RANGE;
            switch ( Frequency )
            {
                case TimePointFrequency.PerDay:
                    m_BeginTime = new DateTime(4, 1, 1, Hour, Minute, Second);
                    break;

                case TimePointFrequency.PerMonth: 
                    m_BeginTime = new DateTime(4, 1, Day, Hour, Minute, Second);
                    break;

                case TimePointFrequency.PerYear: 
                    // ������������� 2-29
                    m_BeginTime = new DateTime(4, Month, Day, Hour, Minute, Second);
                    break;

                case TimePointFrequency.Once:
                    m_BeginTime = new DateTime(Year, Month, Day, Hour, Minute, Second);
                    break;

                case TimePointFrequency.PerWeek:
                    m_BeginTime = new DateTime(1, 1, 1, Hour, Minute, Second);
                    m_Week = Week;
                    break;
            }
       }


        public int Year
        {
            get{ return m_Frequency == TimePointFrequency.Once ? m_BeginTime.Year : IVV; }
        }

        public int Month
        {
            get { return m_Frequency == TimePointFrequency.PerYear ? m_BeginTime.Month : IVV; }
        }

        public int Day
        {
            get 
            {
                if ( m_Frequency == TimePointFrequency.PerYear ||
                    m_Frequency == TimePointFrequency.PerMonth )
                    return m_BeginTime.Day;
                return IVV;
            }
        }

        public int Hour
        {
            get { return m_BeginTime.Hour ; } 
        }
        public int Minute
        {
            get { return m_BeginTime.Minute; }
        }

        public int Second 
        {
            get { return m_BeginTime.Second; }
        }
        public DayOfWeek Week
        {
            get { return m_Frequency == TimePointFrequency.PerWeek ? m_Week : 0; }
        }

        public TimeSpan Range
        {
            get { return m_Range; }
            set 
            { 
                if (value > MAX_RANGE)
                    throw new ArgumentOutOfRangeException(SR.GetString("LE_TimePointRange"));
                m_Range = value; 
            }
        }

        public TimePointFrequency Frequency
        {
            get { return m_Frequency; }
        }

        /// <summary>
        /// �ж�һ��ʱ���Ƿ��ڸ�ʱ��㷶Χ��
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public bool InTimePoint ( DateTime datetime )
        {
            bool result = false;

            switch (m_Frequency)
            {
                case TimePointFrequency.PerDay:
                    result = InTime( datetime );
                    break;

                case TimePointFrequency.PerWeek:
                    if (datetime.DayOfWeek == m_Week)
                        result = InTime( datetime );
                    break;

                case TimePointFrequency.PerMonth:
                    if (datetime.Day == m_BeginTime.Day)
                        result = InTime( datetime );
                    break;

                case TimePointFrequency.PerYear:
                    if (datetime.Day == m_BeginTime.Day && 
                        datetime.Month == m_BeginTime.Month)
                        result = InTime( datetime );
                    break;

                case TimePointFrequency.Once:
                    TimeSpan ts = datetime - m_BeginTime;
                    result =  (ts >= TimeSpan.Zero && ts <= m_Range);
                    break;

            }
            return result;
        }

        /// <summary>
        /// �ж�һ��ʱ���Ƿ���ʱ��㷶Χ��,����ʱ����бȽϣ����������ڡ�
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool InTime(DateTime dt)
        {

            TimeSpan ts = dt.TimeOfDay - m_BeginTime.TimeOfDay;

            // ����������
            //
            if ( ts < TimeSpan.Zero )
                ts += new TimeSpan(1,0,0,0,0);

            return (ts >= TimeSpan.Zero) && (ts <= m_Range);
        }
    }

    #endregion // TimePoint

    #region TimePointTaskStrategy
    /// <summary>
    /// ��ָ����Time pointִ��Task
    /// </summary>
    /// 
    [Serializable]
    public class TimePointTaskStrategy : TaskStrategy 
    {

        private ArrayList   m_TimePoints    = null;
        
        // 2006.12.28
        //
        //protected ArrayList TimePoints
        public ArrayList TimePoints
        {
            get 
            {
                if ( m_TimePoints == null )
                    m_TimePoints = new ArrayList();
                return m_TimePoints;
            }
        }

        public int Add(TimePoint timePoint)
        {
            //Debug.Assert (timePoint != null, "Can not add <null> TimePoint.");
            if (timePoint == null)
                throw new ArgumentNullException ("timePoint",SR.GetString("LE_TimePointNull"));
            return TimePoints.Add ( timePoint );
        }

        public void Remove( TimePoint  timePoint)
        {
            TimePoints.Remove( timePoint);
        }

        public void RemoveAt( int index )
        {
            TimePoints.RemoveAt( index );
        }

        public int IndexOf( TimePoint timePoint )
        {
            return TimePoints.IndexOf( timePoint );
        }

        public TimePoint GetTimePoint( int index )
        {
            return m_TimePoints[index] as TimePoint;
        }

        public int Count
        {
            get { return TimePoints.Count; }
        }

        public override bool NeedExecute(DateTime dt)
        {
            foreach ( TimePoint tp in TimePoints )
            {
                if ( tp.InTimePoint( dt ) )
                {
                    TimeSpan ts = dt - Owning.LastExecute;

                    if ( Owning.LastCommResultState == CommResultState.Correct &&
                        ts >= TimeSpan.Zero &&
                        ts <= tp.Range )
                        return false;
                    else
                        return true;
                }
            }
            return false;
        }

        public override bool CanRemove
        {
            get
            {
                return false;
            }
        }

        public override bool FirstExecute
        {
            get
            {
                return false;
            }
        }
    }
    #endregion //TimePointTaskStrategy
}