using System.Diagnostics;
using System.Runtime.Serialization;

using Infragistics.Shared;

namespace CFW.Test
{
    using System;
    using NUnit.Framework;

    public class T
    {
        static A_Station        _st;
        static CommPortProxy    _c;
        
        // 2006-09-18 12:00:00
        //
        static DateTime         _beginTime = new DateTime(2006,9,18,12,0,0,0);
        // 1 minute
        //
        static TimeSpan         _timespan = new TimeSpan(0,0,1,0,0);

        static public DateTime Begin
        {
            get
            {
                return _beginTime;
            }
        }

        static public TimeSpan timespan
        {
            get
            {
                return _timespan;
            }
        }


        static public CommPortProxy CommPort
        {
            get
            {
                if (_c == null )
                {
                    _c = new CommPortProxy();
                }
                return _c;
            }
        }

        static public CommCmdBase cmd_coll_realdata
        {
            get 
            {
                return new A_Cmd_Coll_Rd();
            }
        }

        static public A_Station station
        {
            get 
            {
                if (_st == null)
                {
                    _st = new A_Station("st",1);
                }
                return _st;
            }
        }

        static public string ConvertBytes2String(byte[] bytes )
        {
            string s=string.Empty;
            for (int i=0;i<bytes.Length;i++)
            {
                s += bytes[i].ToString("X2") + " ";
            }
            return s;
        }
    }

    //[TestFixture]
    [Serializable]
    public class A_Station : Station,ISerializable
    {
        private int c1;
        int c2;
        public int C1
        {
            get 
            {
                return c1;
            }
        }

        public int C2
        {
            get 
            {
                return c2;
            }
        }
        
        public void success()
        {
            c1++;
        }

        public void fail()
        {
            c2++;
        }
        public A_Station(string name, int address)
            : base(name,address)
        {
        }

        public A_Station (SerializationInfo info, StreamingContext context)
            : base (info, context)
        {
        }

        public KeyedSubObjectsCollectionBase primary_collection
        {
            get { return this.PrimaryCollection ; }
        }
        #region ISerializable 成员

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // TODO:  添加 A_Station.GetObjectData 实现
            base.GetObjectData( info, context);
        }

        #endregion
    }


    //[TestFixture]
    public class A_StationsCollection : StationsCollection
    {
        public A_StationsCollection()
        {
        }

        public int Add ( A_Station station )
        {
            return InternalAdd(station);
        }

        public void Clear()
        {
            this.InternalClear();
        }
    }



    //------------------------------------------------------------
    [Serializable]
    public class A_Cmd_Coll_Rd : CommCmdBase,ISerializable 
    {
        public A_Cmd_Coll_Rd()
        {
            this.Station = T.station;
        }

        public A_Cmd_Coll_Rd(SerializationInfo info, StreamingContext context)
        {
        }

        // 2006.12.13
        //
        //public override byte[] MakeCommand(Station station, object[] parameters)
        public override byte[] MakeCommand()
        {
            #region //**
            //string strCmd = string.Format("#{0} : coll real data",station.Address);
            //char[] charsCmd = strCmd.ToCharArray();
            //byte[] bytesCmd = new byte[charsCmd.Length];
            //
            //for (int i=0; i<charsCmd.Length; i++)
            //{
            //    bytesCmd[i] = charsCmd[i] as byte;
            //}
            //return bytesCmd;
            #endregion  
            return Utility.ConvertStringToBytes( string.Format("#{0} : coll real data",this.Station.Address) );
        }

        //public override CommResultState Analyse(Station station, byte[] data)
        // 2006.12.13
        //
        //public override CommResultState ProcessReceived(Station station, object[] parameters, byte[] data)
        public override CommResultState ProcessReceived(byte[] data)
        {
            return CommResultState.Correct;
        }

        public override int LatencyTime
        {
            get
            {
                return 30;
            }
        }

        #region ISerializable 成员

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // TODO:  添加 A_Station.GetObjectData 实现
            //base.GetObjectData( info, context);
        }

        #endregion
    }

    public class A_Cmd_Set_Av : CommCmdBase
    {
        public A_Cmd_Set_Av()
        {

        }

        public override byte[] MakeCommand()
        {
            string str = string.Format ( "#{0} : set alarm value {1}", Station.Address, "command.param");
            return Utility.ConvertStringToBytes (str);
        }

        //public override CommResultState Analyse(Station station, byte[] data)
        public override CommResultState ProcessReceived(byte[] data)
        {
            return CommResultState.Correct ;
        }

        public override int LatencyTime
        {
            get
            {
                return 400;
            }
        }
    }

    public class A_Task_Rd : Task
    {
        public A_Task_Rd(A_Station station,  A_Cmd_Coll_Rd cmd)
            : base ("NoName", cmd,new CycleTaskStrategy (new TimeSpan( 0,0,0,5,0 )))
        {
            if ( this.m_BeforeExecuteTaskDelegate != null )
            {
            }
        }

        //public override void ProcessReceived(byte[] received)
        protected override CommResultState OnProcessReceived(byte[] received)
        {
            //base.OnProcessReceived (station, parameters, received);
            
            if ( this.CommCmd.ProcessReceived( received ) == CommResultState.Correct )
            {
                // 2006.12.13
                //
                //A_Station a = Station  as A_Station ;
                //a.success();
            }
            else
            {
                // 2006.12.13
                //
                //A_Station a = Station  as A_Station ;
                //a.fail();
            
            }

            return CommResultState.Correct ;
        }

        //public override void Execute(CommPortProxy commPortProxy)
        protected override void OnExecute(CommPortProxy commPortProxy, CommCmdBase cmd)
        {
            //base.OnExecute (commPortProxy, station, cmd, parameters);
        //}
                                                                                                                                                                                                                                                               //
        //{
            
            byte[] bytescmd = CommCmd.MakeCommand ( );
            int late = CommCmd.LatencyTime;

            if ( !commPortProxy.IsOpen )
                commPortProxy.Open();

            commPortProxy.Send (bytescmd, late);
        }
    }


    public class A_Task_Collection : TasksCollection
    {
        public A_Task_Collection()
        {
            
        }
    }
    //------------------------------------------------------------




    [TestFixture]
    public class test_Station
    {

        A_StationsCollection        stations ;
        A_Station                   st1;
        A_Station                   st1_too;
        A_Station                   st2;


        [SetUp]
        public void setup()
        {
            stations = new A_StationsCollection();
            st1 = new A_Station("st1", 1);
            st2 = new A_Station("st2", 1);
            st1_too = new A_Station("st1", 1);

        }

        [Test]
        public void add_station()
        {
            stations.Add( st1 );
            stations.Add( st2 );
            Assert.AreEqual (2, stations.Count );
            
            clear_stations();
            stations.Add( st1_too );
            Assert.AreEqual (1, stations.Count );

        }

        [Test,]
        public void change_station_name()
        {
            clear_stations();
            stations.Add( st1 );
            stations.Add( st2 );
            
            

            st2.StationName = "    st2_c   ";
            Assert.AreEqual("st2_c",st2.StationName);
            Assert.AreEqual(st2.Key ,st2.StationName);



            A_Station st =stations.GetItem(0) as A_Station;

            st.StationName = "st1_changed";
            Assert.AreEqual ("st1_changed",st.StationName);
            st.StationName = "st2";

        }

        [Test]
        public void clear_stations()
        {
            stations.Clear();
            Assert.AreEqual(0, stations.Count );
        }

        [Test]
        public void own_coll_of_station()
        {
            clear_stations();
            stations.Add (st1 );
            Assert.AreEqual ( st1.primary_collection , stations );
        }


        [Test]
        [ExpectedException(typeof(System.ArgumentException))]
        public void add_same_station()
        {
            clear_stations();
            stations.Add( st1 );
            stations.Add( st1 );
        }


    }
	

    [TestFixture]
    public class test_comm_cmd
    {
        A_Cmd_Coll_Rd       rdcmd;
        A_Cmd_Set_Av        svcmd;
        A_Station           _st1;

        [SetUp]
        public void setup()
        {
            rdcmd = new A_Cmd_Coll_Rd();
            svcmd = new A_Cmd_Set_Av();
        }

        [Test]
        public void _()
        {
            // 2006.12.13
            //
            //byte[] bytes = rdcmd.MakeCommand( st1, null );
            byte[] bytes = rdcmd.MakeCommand( );

        }

        public A_Station st1
        {
            get
            {
                if (_st1 == null)
                    _st1 = new A_Station("st1", 1);
                return _st1;
            }
        }
    }

    
    [TestFixture]
    public class test_task_collecion
    {
        A_Task_Collection  tasks = null;
        A_Task_Rd rd1               = null;
        A_Task_Rd rd2               = null;


        [SetUp ]
        public void setup()
        {
            tasks = new A_Task_Collection();
            rd1 = new A_Task_Rd(T.station ,new A_Cmd_Coll_Rd() );
            rd2 = rd1;
        }

        [Test]
        public void add_task()
        {
            Assert.AreEqual(0, tasks.Count );
            tasks.Add( rd1 );
            Assert.AreEqual(1, tasks.Count );
        }

        [Test]
        [ExpectedException( typeof(System.ArgumentException) ) ]
        public void add_same_task()
        {
            tasks.Clear();
            Assert.AreEqual(0, tasks.Count);
            tasks.Add (rd1);
            tasks.Add (rd2);
        }

        [Test]
        public void clear()
        {
            tasks.Clear();
            Assert.AreEqual(0, tasks.Count);

            tasks.Add( rd1 );
            tasks.SubObjectPropChanged +=new SubObjectPropChangeEventHandler(tasks_SubObjectPropChanged);
            tasks.Clear();
        }

        private void tasks_SubObjectPropChanged(PropChangeInfo propChange)
        {
            Assert.AreEqual ( propChange.Source , tasks );
            Assert.AreEqual ( PropertyIds.Tasks,propChange.PropId );
            Assert.AreNotEqual (null,propChange.Trigger );
            clear_trigger( propChange.Trigger);
        }

        void clear_trigger(PropChangeInfo t)
        {
            Assert.AreEqual(null, t.Source);
            Assert.AreEqual(PropertyIds.Clear,t.PropId);

        }

        //[Test]
        //public void Clear_event()
        //{
        //  
        //}

    }
    [TestFixture]
    public class test_task_name
    {
        Task t1 = null;
        Task t2 = null;

        TasksCollection ts = null;

        string name = "defTaskName";
        [SetUp]
        public void setup()
        {

            t1 = new Task(name,T.cmd_coll_realdata, new ImmediateTaskStrategy());
            t2 = new Task(
                //name.ToLower(),
                name, T.cmd_coll_realdata, new ImmediateTaskStrategy());
            ts = new TasksCollection();    
        }

        [Test]
        public void NameEqKey()
        {
            Assert.IsTrue (t1.Key == name);
            Assert.IsTrue ( t1.Name == name);
            t1.Name = "newName";
            Assert.IsTrue  (t1.Key == t1.Name);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void dupTaskName()
        {
            ts.Add( t1);
            ts.Add( t2);
        }
    }


    [TestFixture]


    public class test_task_and_collection
    {
        A_Task_Rd rd = null;
        A_Task_Rd rd2 = null;
        A_Task_Collection  tasks = null;

        CommPortProxy cpp = null;

        [SetUp]
        public void setup()
        {
            
            rd = new A_Task_Rd(T.station, new A_Cmd_Coll_Rd());
            rd2 = new A_Task_Rd(T.station, new A_Cmd_Coll_Rd());
            tasks = new A_Task_Collection();
    
            cpp = new CommPortProxy(1,"19200,n,8,1");
            //cpp.Open();
        }

        [Test]
        public void task_exec()
        {
            
            try
            {
                rd.Execute( cpp );
                cpp.Close();
            }
            catch (System.Runtime.InteropServices.COMException comEx)
            {
                Debug.Assert (false, comEx.ErrorCode.ToString("X") );
            }
            catch (Exception ex)
            {
                Debug.Assert (false, ex.Message );
            }
        }
        
    }

    [TestFixture]
    public class test_timepoint 
    {
        private TimePoint DefaultTP
        {
            get
            {
                DateTime dt = T.Begin;

                return new TimePoint(dt.Hour, dt.Minute, dt.Second);//, TimePointFrequency.PerDay);
            }
        }

		[Test]
		public void _overday()
		{
			DateTime dt = new DateTime (2006,09,22,23,59,55,0);
			DateTime dt1 = new DateTime (2006,09,22,23,59,59,0);
			DateTime dt2 = new DateTime (2006,09,22,00,00,00,0);

            //TimePoint tp = new TimePoint(dt, TimePointFrequency.PerDay);
            TimePoint tp = new TimePoint (dt.Hour, dt.Minute, dt.Second);//, TimePointFrequency.PerDay);
			
			Assert.IsTrue( tp.InTimePoint(dt1) );
			Assert.IsTrue( tp.InTimePoint(dt2) );

		}

        [Test]
        public void new_timepoint()
        {
            DateTime dt = T.Begin;
            //TimePoint tp = new TimePoint(T.Begin, TimePointFrequency.PerDay);
            TimePoint tp = new TimePoint(dt.Hour, dt.Minute, dt.Second);//, TimePointFrequency.PerDay);
            
            Assert.AreEqual(new DateTime(2006,9,18,12,0,0) , new DateTime(2006,9,18,tp.Hour,tp.Minute,tp.Second )); //tp.BeginTime);
            Assert.AreEqual(new TimeSpan(0,0,0,10,0) ,tp.Range);
            Assert.AreEqual(TimePointFrequency.PerDay, tp.Frequency );
        }

        [Test]
        public void test_in_timepoint()
        {
            DateTime t_12_0_0 = new DateTime(121,1,1,12,0,0);
            DateTime t_12_0_10 = new DateTime(221,1,1,12,0,10);
            DateTime t_12_0_11 = new DateTime(331,1,1,12,0,11);

            DateTime t_11_59_59 = new DateTime(441,1,1,11,59,59);

    
            DateTime t_12_0_8 = new DateTime(551,1,1,12,0,8);
            DateTime t_11_0_8 = new DateTime(661,1,1,11,0,8);

            Assert.IsTrue( DefaultTP.InTimePoint(t_12_0_0) );
            Assert.IsTrue( DefaultTP.InTimePoint(t_12_0_10) );
            Assert.IsFalse( DefaultTP.InTimePoint(t_12_0_11) );
            Assert.IsFalse( DefaultTP.InTimePoint(t_11_59_59) );
            
            Assert.IsTrue( DefaultTP.InTimePoint(t_12_0_8) );
            Assert.IsFalse( DefaultTP.InTimePoint(t_11_0_8) );
        }


        [Test]
        public void test_in_timepoint_permonth()
        {
            TimePoint tp = new TimePoint (18,12,0,0);

            Assert.IsFalse( tp.InTimePoint( CDT("2006-9-18 11:59:59") ) );
            Assert.IsFalse( tp.InTimePoint( CDT("2006-9-18 12:00:11") ) );

            Assert.IsTrue( tp.InTimePoint( CDT("2006-9-18 12:00:00") ) );
            Assert.IsTrue( tp.InTimePoint( CDT("2006-9-18 12:00:10") ) );

            Assert.IsTrue( tp.InTimePoint( CDT("2001-1-18 12:00:00") ) );
            Assert.IsTrue( tp.InTimePoint( CDT("2006-2-18 12:00:05") ) );
            Assert.IsTrue( tp.InTimePoint( CDT("2006-3-18 12:00:10") ) );

            Assert.IsTrue(!tp.InTimePoint( CDT("2006-10-17 12:00:00") ) );
            Assert.IsTrue(!tp.InTimePoint( CDT("2006-11-19 12:00:10") ) );
        }

        [Test]
        public void test_in_timepoint_once()
        {
            //new DateTime(2006,9,18,12,0,0,0);
            
            TimePoint tp = new TimePoint (2006,9,18,12,0,0);
            //tp.Frequency  = TimePointFrequency.Once;

            Assert.IsTrue( tp.InTimePoint( CDT("2006-9-18 12:0:0") ) );
            Assert.IsTrue( tp.InTimePoint( CDT("2006-9-18 12:0:06") ) );

            Assert.IsTrue(!tp.InTimePoint( CDT("2006-9-18 11:0:0") ) );
            Assert.IsTrue(!tp.InTimePoint( CDT("2006-9-18 13:0:0") ) );
            Assert.IsTrue(!tp.InTimePoint( CDT("2006-9-17 12:0:0") ) );
            Assert.IsTrue(!tp.InTimePoint( CDT("2006-8-18 12:0:0") ) );
            Assert.IsTrue(!tp.InTimePoint( CDT("2005-9-18 12:0:0") ) );
        }

        [Test]
        public void test_in_timepoint_peryear()
        {
            TimePoint tp = DefaultTP;
            //tp.Frequency  = TimePointFrequency.PerYear;

            tp = new TimePoint (9,18,12,0,0);
            Assert.IsTrue( tp.InTimePoint( CDT("2006-9-18 12:0:0") ) );
            Assert.IsTrue( tp.InTimePoint( CDT("2006-9-18 12:0:06") ) );
            Assert.IsTrue( tp.InTimePoint( CDT("2007-9-18 12:0:0") ) );
            Assert.IsTrue( tp.InTimePoint( CDT("2005-9-18 12:0:10") ) );
            Assert.IsTrue(!tp.InTimePoint( CDT("2005-10-18 12:0:0") ) );

            Assert.IsTrue(!tp.InTimePoint( CDT("2006-9-18 11:0:0") ) );
            Assert.IsTrue(!tp.InTimePoint( CDT("2006-9-18 13:0:0") ) );
            Assert.IsTrue(!tp.InTimePoint( CDT("2006-10-18 12:0:0") ) );
            Assert.IsTrue(!tp.InTimePoint( CDT("2006-8-18 12:0:0") ) );
            Assert.IsTrue(!tp.InTimePoint( CDT("2006-11-18 12:0:0") ) );
        }

        [Test]
        public void create_timepoint()
        {
            TimePoint tp = new TimePoint(5,1,1,10,10);
        }


        DateTime CDT(string s)
        {
            return Convert.ToDateTime(s);
        }

    }
    

    [TestFixture]
    public class test_timepoint_taskstrategy
    {
        TimePointTaskStrategy tptask
        {
            get
            {
                return new TimePointTaskStrategy();
            }
        }

        Task task
        {
            get
            {
                return new Task("defaultTaskName", T.cmd_coll_realdata, tptask);
            }
        }

        [Test]
        public void EmptyTimePoints()
        {
            Assert.IsTrue( !task.CanRemove);
            Assert.IsFalse ( tptask.NeedExecute());
        }

        DateTime CDT(string s)
        {
            return Convert.ToDateTime(s);
        }

        [Test]
        public void t1()
        {
            Task t = task;
            TimePointTaskStrategy  tp = tptask;
            tp.Add( new TimePoint( 12,0,0));//, TimePointFrequency.PerDay  );

            t.TaskStrategy = tp;
            Assert.IsTrue( tp.Count == 1);

            
            Assert.IsTrue ( t.NeedExecute( CDT("2006-9-18 12:00:10") ));
            Assert.IsTrue ( t.NeedExecute( CDT("2006-9-18 12:00:00") ));

            Assert.IsFalse ( t.NeedExecute( CDT("2006-9-18 12:00:11") ));
            Assert.IsFalse ( t.NeedExecute( CDT("2006-9-18 11:00:00") ));

            t._set_comm_result (CommResultState.Correct);
            t.LastExecute = CDT("2006-9-18 12:00:00");
            Assert.IsTrue ( !t.NeedExecute( CDT("2006-9-18 12:00:10") ));
            Assert.IsTrue ( !t.NeedExecute( CDT("2006-9-18 12:00:00") ));
            
            //tp.Add ( new TimePoint( CDT("2006-9-19 1:0:30"),TimePointFrequency.Once ));
            tp.Add(new TimePoint (2006,9,19,1,0,30));
            Assert.IsTrue( t.NeedExecute( CDT("2006-9-19 1:0:39") ) );

        }

    }



    [TestFixture]
    public class task_associate_taskstrategy
    {
        [Test]
        public void associate()
        {string def_task_name = "defaule task name";
            CycleTaskStrategy aStrate = new CycleTaskStrategy( new TimeSpan(TimeSpan.TicksPerSecond) );
            CycleTaskStrategy aStrate2 = new CycleTaskStrategy( new TimeSpan(TimeSpan.TicksPerSecond) );
            
            Task task = new Task(def_task_name, T.cmd_coll_realdata, aStrate);
            Assert.AreEqual(task.TaskStrategy, aStrate );

            Task task2 = new Task(def_task_name, T.cmd_coll_realdata, aStrate2);
            Assert.AreEqual(task2.TaskStrategy, aStrate2 );
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void set_strate_is_null()
        {
            Task t = new Task( "defaule task name", T.cmd_coll_realdata, null);
        }

        [Test]
        public void change_stategy_to_other()
        {   
            string def_task_name = "defaule task name";
            CycleTaskStrategy aStrate = new CycleTaskStrategy( new TimeSpan(TimeSpan.TicksPerSecond) );
            CycleTaskStrategy aStrate2 = new CycleTaskStrategy( new TimeSpan(TimeSpan.TicksPerSecond) );
            
            Task task = new Task(def_task_name, T.cmd_coll_realdata, aStrate);
            Assert.AreEqual(task.TaskStrategy, aStrate );

            task.TaskStrategy = aStrate2;

            Assert.AreEqual (null, aStrate.Owning);
            Assert.AreEqual (aStrate2 , task.TaskStrategy );
            Assert.AreEqual (task, aStrate2.Owning );
        }

    }

    //public class 
    #region TasksCollection
    /*
    /// <summary>
    /// test_TasksCollection 的摘要说明。
    /// </summary>
    /// 	
    [TestFixture]
    public class test_TasksCollection
    {
        public test_TasksCollection()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        class a : Task
        {
            public a() : base (null,null,null)
            {
            }
            public override void ProcessReceived(byte[] received)
            {
    
            }
            public override void Execute(CommPortProxy commPortProxy)
            {
    
            }
    
        }
    
    
        [Test]
        public void t1()
        {
            TasksCollection tasks = new TasksCollection();
            tasks.Add ( new a());//CycleTaskStrategy ( new System.TimeSpan(10) ) );
    
        }
    }
    */
    #endregion

    [TestFixture]
    public class Test_tasks_taskscheduler
    {
         TaskScheduler _taskscheduler1 ;//= new TaskScheduler(T.CommPort);
         TaskScheduler _taskscheduler2 ;//= new TaskScheduler(T.CommPort);
         TasksCollection _tasks1 ;//= new TasksCollection();
         TasksCollection _tasks2 ;//= new TasksCollection();


        [SetUp]
        public void setup()
        {
            //object obj = T.CommPort;
            //if (T.CommPort == null)
            //    throw new ArgumentNullException("commprot","cp");
            _taskscheduler1 = new TaskScheduler(T.CommPort);
            _taskscheduler2 = new TaskScheduler(T.CommPort);
            _tasks1 = new TasksCollection();
            _tasks2 = new TasksCollection();

        }

        [Test]        
        public void tasks_owning()
        {             
            _taskscheduler1.Tasks = _tasks1;
            Assert.AreEqual(_taskscheduler1.Tasks, _tasks1);
            Assert.AreEqual(_taskscheduler1, _tasks1.Owning);

            _taskscheduler1 .Tasks = _tasks1;
        }

        [Test]
        public void AddTask()
        {
            Task t1 = new Task("t1",T.cmd_coll_realdata, new CycleTaskStrategy(new TimeSpan(0,0,0,10,0) ) );
            Task t2 = new Task("t2",T.cmd_coll_realdata, new CycleTaskStrategy(new TimeSpan(0,0,0,10,0) ) );
            Task tm = new Task("tm",T.cmd_coll_realdata, new  ImmediateTaskStrategy() );

            _taskscheduler1.Tasks = _tasks1;
            _taskscheduler1.Tasks.Add(t1);
            _taskscheduler1.Tasks.Add(t2);
            _taskscheduler1.Tasks.Add(tm);

            Assert.AreEqual(tm.Name , _tasks1[0].Name);

        }
    }
}
