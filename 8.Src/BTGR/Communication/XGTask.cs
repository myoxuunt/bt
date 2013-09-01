using System;
using System.Threading;
using Infragistics.Shared;
using CFW;


namespace Communication
{
    #region XGTask
    
    public class XGTask : SubObjectBase 
    {
        private XGStation       _xgStation;
        private XGTime          _xgTime;
        private Card            _card;
        private XGData          _xgTaskResult;

        private bool            _isComplete;
        private bool            _isActive;

        private bool            _isWatingLocalXgData;

        private event System.EventHandler _Active;
        private event System.EventHandler _Inactive;

        #region Constructor
        public XGTask (XGStation xgStation, Card card, XGTime time)
        {
            ArgumentChecker.CheckNotNull (xgStation);
            ArgumentChecker.CheckNotNull (card);
            ArgumentChecker.CheckNotNull (time);

            _xgStation = xgStation;
            _xgTime = time;
            _card = card;
            _isComplete = false;
            _isActive = false;
            this._Active +=new EventHandler(XGTask_Active);
            _Inactive += new EventHandler(XGTask_Inactive);
        }
        #endregion //Constructor

        /// <summary>
        /// 指示正在等待从巡更系统中返回本地数据
        /// </summary>
        public bool IsWatingLocalXgData
        {
            get { return _isWatingLocalXgData; }
        }
        /// <summary>
        /// 获取或设置一个值，指示任务是否激活的
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
            set 
            {
                if ( _isActive == value )
                    return ;

                _isActive = value;
                if ( _isActive )
                {
                    if ( _Active != null )
                        _Active( this, EventArgs.Empty );
                }
                else
                {
                    if ( _Inactive != null )
                        _Inactive ( this, EventArgs.Empty );
                }
            }
        }

        public XGStation XGStation
        {
            get { return _xgStation; }
        }

        public XGTime XGTime
        {
            get { return _xgTime; }
        }

        public Card Card
        {
            get { return _card; }
        }

        public bool IsComplete
        {
            get { return _isComplete; }
            set { _isComplete = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public XGData XgTaskResult
        {
            get { return _xgTaskResult; }
            set 
            { 
                ArgumentChecker.CheckNotNull ( value );
                _xgTaskResult = value; 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool IsOutTime(DateTime dt)
        {
            return _xgTime.IsOutTime( dt );
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            _isComplete = false;
            _isWatingLocalXgData = false;
            _xgTaskResult = null;
        }

        /// <summary>
        /// 任务被激活事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XGTask_Active(object sender, EventArgs e)
        {
            this.Reset();
        }

        /// <summary>
        /// 任务取消激活事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XGTask_Inactive(object sender, EventArgs e)
        {
            if ( _isComplete )
            {
                XGDB.SaveXgTaskResult( this);
                Reset();
            }

            else
            {
                //_xgTaskResult = XGTaskResult.CreateFailResult( this );

                //Record[] records = ReadAndClearXgData();
                //TODO: xgtask inactive!
                //
                XGData[] datas = ReadAndClearXgData();
                _isWatingLocalXgData = true;

            }
            
        }

        /// <summary>
        /// 检查一个时间是否同本次的巡更任务时间相匹配
        /// </summary>
        /// <param name="dt">待检查时间</param>
        /// <returns></returns>
        private bool MatchXgTime( DateTime dt )
        {
            return this._xgTime.IsInTime( dt ) &&
                    ( dt.Date == DateTime.Now.Date ); 
        }

        public bool MatchXGData ( XGData data )
        {
            ArgumentChecker.CheckNotNull( data );
            
            return !IsComplete &&
                ( _card.SerialNumber == data.CardSN ) &&
                ( _xgStation.Address == data.FromAddress ) &&
                ( MatchXgTime( data.XGStationDateTime ));
        }
        /// <summary>
        /// 读取并清空巡更控制器中保存的本地数据
        /// </summary>
        /// <returns>巡更数据数组</returns>
        //private Record[] ReadAndClearXgData()
        private XGData[] ReadAndClearXgData()
        {

            try
            {
                ReadTotalCountCommand countCmd = new ReadTotalCountCommand( _xgStation );
                Task t = new Task(countCmd, new ImmediateTaskStrategy() );

                //传递给通讯调度的附加对象，只是读取全部的本地数据并清空，
                //全部命令完成后，通知xgtask 已完成，ReadLocalXGDataComplete(), xgtask执行相关操作。
                object[] tags = new object[2];
                tags[0] = TagType.OP_ReadAndClearXgData;
                tags[1] = this;

                t.Tag = tags;
            
                Singles.S.TaskScheduler.Tasks.Add ( t );
                return null;
            }
            catch(Exception ex)
            {   
                System.Windows.Forms.MessageBox.Show( ex.ToString() );
                return null;
            }
        }

        public void ReadLocalXgDataComplete()
        {
            XGDB.SaveXgTaskResult( this );
            Reset();
        }

    }
    #endregion //XGTask
}
