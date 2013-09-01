using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Communication
{
    #region XGScheduler
	/// <summary>
	/// XGScheduler ��ժҪ˵����
	/// </summary>
	public class XGScheduler
	{
        // ���ü��ʱ����Ϊ 1 ����  
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
        /// ���Ѳ������,���Ѳ�������б��е�ÿһ���������DateTime.Now���ڸ�����Ļʱ��Σ��򼤻������
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
