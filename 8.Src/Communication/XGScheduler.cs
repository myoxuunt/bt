using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Communication
{
    #region XGScheduler
	/// <summary>
	/// XGScheduler 的摘要说明。
	/// </summary>
	public class XGScheduler
	{
        // 设置检查时间间隔为 1 分钟  
        private const int TIMER_INTERVAL = 1000 * 60 * 1;

        private Timer               _timer = null;
        private XGTasksCollection   _tasks = null;

		public XGScheduler()
		{
            Init();
		}

        private void Init()
        {
            _timer = new Timer();
            _timer.Interval = TIMER_INTERVAL;    
            _timer.Tick +=new EventHandler(OnTimeTick);
            _timer.Enabled = true;
        }

        private void OnTimeTick(object sender, EventArgs e)
        {
            CheckTasks();
        }

        #region CheckTasks
        /// <summary>
        /// 检查巡更任务,检查巡更任务列表中的每一个任务，如果DateTime.Now处于该任务的活动时间段，则激活该任务。
        /// </summary>
        public void CheckTasks()
        {
            for ( int i=0; i<_tasks.Count; i++ )
            {
                XGTask task = _tasks[ i ];
                task.IsActive = !task.IsOutTime( DateTime.Now );
            }
        }
        #endregion //CheckTasks

        #region MatchRecord
        //public int MatchRecord( XGAutoReportData  record )
        public int MatchRecord( XGData  data )
        {
            ArgumentChecker.CheckNotNull( data );
            if ( _tasks == null )
                return 0;

            int matchedCount = 0;
            for ( int i=0; i<_tasks.Count; i++ )
            {
                XGTask task = _tasks[ i ];
                if ( task.IsActive && 
                    !task.IsComplete &&
                    task.MatchXGData( data ) )
                {
                    //task.XgTaskResult  = XGTaskResult.CreateSuccessResult( task, record.DateTime );
                    task.XgTaskResult = data;
                    task.IsComplete = true;
                    matchedCount ++;
                }
            }
            return matchedCount;
        }
        #endregion //MatchRecord

        #region Properties
        public XGTasksCollection Tasks
        {
            get { return _tasks; }
            set 
            { 
                ArgumentChecker.CheckNotNull( value );
                _tasks = value; 
            }
        }

        public bool Enabled
        {
            get { return _timer.Enabled; }
            set
            {
                if ( _timer.Enabled != value )
                    _timer.Enabled = value; 
            }
        }
        #endregion //Properties
    }

    #endregion //XGScheduler
}
