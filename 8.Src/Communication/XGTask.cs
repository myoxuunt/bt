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
        /// ָʾ���ڵȴ���Ѳ��ϵͳ�з��ر�������
        /// </summary>
        public bool IsWatingLocalXgData
        {
            get { return _isWatingLocalXgData; }
        }
        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�����Ƿ񼤻��
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
        /// ���񱻼����¼�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XGTask_Active(object sender, EventArgs e)
        {
            this.Reset();
        }

        /// <summary>
        /// ����ȡ�������¼�����
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
        /// ���һ��ʱ���Ƿ�ͬ���ε�Ѳ������ʱ����ƥ��
        /// </summary>
        /// <param name="dt">�����ʱ��</param>
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
        /// ��ȡ�����Ѳ���������б���ı�������
        /// </summary>
        /// <returns>Ѳ����������</returns>
        //private Record[] ReadAndClearXgData()
        private XGData[] ReadAndClearXgData()
        {

            try
            {
                ReadTotalCountCommand countCmd = new ReadTotalCountCommand( _xgStation );
                Task t = new Task(countCmd, new ImmediateTaskStrategy() );

                //���ݸ�ͨѶ���ȵĸ��Ӷ���ֻ�Ƕ�ȡȫ���ı������ݲ���գ�
                //ȫ��������ɺ�֪ͨxgtask ����ɣ�ReadLocalXGDataComplete(), xgtaskִ����ز�����
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
