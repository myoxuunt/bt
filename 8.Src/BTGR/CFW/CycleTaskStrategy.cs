using System;
using System.Diagnostics;
using Infragistics.Shared;
namespace CFW
{
    [Serializable]
    public class CycleTaskStrategy: TaskStrategy 
    {
        static readonly TimeSpan           DEFAULT_MIN_CYCLE = new TimeSpan(0,0,0,0,30);
        static readonly TimeSpan           DEFAULT_MAX_CYCLE = new TimeSpan(1,0,0,0,0);

        static private TimeSpan         s_MinCycle = DEFAULT_MIN_CYCLE;
        static private TimeSpan         s_MaxCycle = DEFAULT_MAX_CYCLE;
        private TimeSpan                m_Cycle ;

        public CycleTaskStrategy ( TimeSpan timeSpan )
        {
            Cycle = timeSpan;
        }

        /// <summary>
        /// 获取或设置执行周期
        /// </summary>
        public TimeSpan Cycle
        {
            get { return m_Cycle; }
            set 
            { 
                //Debug.Assert ( value >= s_MinCycle && value <= s_MaxCycle,
                //    string.Format("TimeSpan {0} too larger or too small, must between {1} to {2}",
                //                    value, s_MinCycle, s_MaxCycle));
                if ( !(value >= s_MinCycle && value <= s_MaxCycle))
                {
                    string s = string.Format(SR.GetString("LE_CycleValueOutOfRange_2"),value,s_MinCycle, s_MaxCycle);
                    throw new ArgumentOutOfRangeException ("Cycle",value,s);
                }
                m_Cycle = value;
            }
        }

        /// <summary>
        /// 获取一个值，该值指示Task是否需要执行。
        /// </summary>
        public override bool NeedExecute ( DateTime dt )
        {
            TimeSpan ts = dt - m_Owning.LastExecute;
            if ( ts >= m_Cycle || ts < TimeSpan.Zero )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool CanRemove
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool FirstExecute
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static public TimeSpan MinCycle 
        {
            get { return s_MinCycle; }
            set
            { 
                //Debug.Assert ( value >= CycleTaskStrategy.DEFAULT_MIN_CYCLE &&
                //    value <= CycleTaskStrategy.DEFAULT_MAX_CYCLE &&
                //    value < s_MaxCycle, 
                //    string.Format(SR.GetString("LE_CycleMin")/*"TimeSpan {0} too larger or too small"*/,value) );

                if ( !(value >= CycleTaskStrategy.DEFAULT_MIN_CYCLE &&
                    value <= CycleTaskStrategy.DEFAULT_MAX_CYCLE &&
                    value < s_MaxCycle) )
                    throw new ArgumentOutOfRangeException("MinCycle",value,string.Format(SR.GetString("LE_CycleMin"),value) );

                CycleTaskStrategy.s_MinCycle = value; 
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        static public TimeSpan MaxCycle
        {
            get { return s_MaxCycle; }
            set 
            {                
                //Debug.Assert ( value >= CycleTaskStrategy.DEFAULT_MIN_CYCLE &&
                //    value <= CycleTaskStrategy.DEFAULT_MAX_CYCLE &&
                //    value > s_MinCycle, 
                //    string.Format(SR.GetString("LE_CycleMax")/*"TimeSpan {0} too larger or too small"*/,value) );

                if (!(value >= CycleTaskStrategy.DEFAULT_MIN_CYCLE &&
                    value <= CycleTaskStrategy.DEFAULT_MAX_CYCLE &&
                    value > s_MinCycle))
                    throw new ArgumentOutOfRangeException("MaxCycle",value,string.Format(SR.GetString("LE_CycleMax"),value) );

                s_MaxCycle = value; 
            }
        }
    }
}
