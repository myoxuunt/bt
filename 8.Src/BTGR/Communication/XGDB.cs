using System;
using System.Data;
using Utilities.Database ;
using System.Diagnostics;
using Communication.GRCtrl;
using CFW;

namespace Communication
{
    #region XGDB
	/// <summary>
	/// XGDB 的摘要说明。
	/// </summary>
    public class XGDB
    {
        #region Members
//        static DbClient s_dbClient = null; 
        static private string s_XGDBConnectionString = string.Empty;
        #endregion //Members

        #region Constructor
        private XGDB()
        {
        }
        #endregion //Constructor

        #region Properties
        static public string XGDBConnectionString
        {
            get { return s_XGDBConnectionString; }
            set 
            { 
                s_XGDBConnectionString = value; 
				if ( Utilities.Database.DbClient.Default != null )
				{
					DbClient dc = Utilities.Database.DbClient.Default;
					if( dc.Connection.State == ConnectionState.Open )
					{
						dc.Close();
					}
				}

                Utilities.Database.DbClient.Default = new DbClient( new SqlFactory(), s_XGDBConnectionString );
            }
        }

		/// <summary>
		/// 
		/// </summary>
        static public DbClient DbClient
        {
			get { return Utilities.Database.DbClient.Default; }
			set { Utilities.Database.DbClient.Default = value;}
        }

        #region //...	

//        static public void SaveXgTaskResult ( XGTask task )
//        {
//            ArgumentChecker.CheckNotNull( task );
//
//            string cardSN = task.Card.SerialNumber;
//            string person = task.Card.Person;
//            
//            string expectionTimeRange = GetXGTimeRange(task.XGTime);
//            int ctrlerId = GetId ( task.XGStation );
//            
//            
//            bool isComplete = task.IsComplete;
//            DateTime dt = DateTime.Now;
//
//            // save xg task result to db
//            //
//            string sql = string.Empty;
//            if ( isComplete )
//            {
//                DateTime occurDt = task.XgTaskResult.XGStationDateTime ;
//                sql = string.Format( 
//                    @"insert into tbl_xgtask_result ( xgstation_id, card_sn, person, occur_time, 
//                expection_time, complete, dt) values ({0}, '{1}', '{2}', '{3}', '{4}', {5}, '{6}')",
//                    ctrlerId, cardSN, person, occurDt.ToString(), expectionTimeRange, 1, dt );
//            }
//            else
//            {
//                sql = string.Format(
//                    @"insert into tbl_xgtask_result ( xgstation_id, card_sn, person,  
//                expection_time, complete, dt) values ({0}, '{1}', '{2}', '{3}', {4}, '{5}')",
//                    ctrlerId, cardSN, person, expectionTimeRange, 0, dt );
//            }
//
//            s_dbClient.ExecuteNonQuery( sql );
//        }

//        static private string GetXGTimeRange( XGTime time )
//        {
//            string str = string.Format( "{0} - {1}", 
//                time.Begin.TimeOfDay.ToString(), 
//                time.End.TimeOfDay.ToString() );
//            return str;
//        }
        #endregion
        static private int GetId( XGStation xgStation )
        {
            // Get xg controller id
            //
            //System.Diagnostics.Debug.Assert(false, "TODO: Get xg controller id");
            int id;
            if (Singles.S.XGStationIds.GetId( xgStation , out id ))
                return id;

            return -1;
        }
        


        static public  bool CheckCardSNExist( string sn )
        {
            string s = string.Format( "select count(*) from tbl_card where sn = '{0}'", sn.Trim() );
            return (int)DbClient.ExecuteScalar( s ) >= 1;
        }

        static private void DeleteRow( string tableName, string fieldName, int id)
        {
            string sql = string.Format(@"delete from {0} where {1} = {2}", tableName, fieldName, id );
            DbClient.ExecuteNonQuery( sql );
        }
        
//        static public void InsertXGData( XGData data )
//        {
//            //2007.03.11 replace with InsertXGData ( string remoteIP, XGData data )
//            throw new NotImplementedException ( "insertXGData( XGData data" );
//
//            ArgumentChecker.CheckNotNull( data );
//            string s = string.Format( @"insert into tbl_xgdata(station_address, card_sn, station_time, 
//                computer_time, isAuto) 
//                values({0}, '{1}', '{2}', '{3}', {4})", data.FromAddress, data.CardSN, data.XGStationDateTime, 
//                data.DateTime, data.IsAutoReport ? 1 : 0 );
//
//            DbClient.ExecuteNonQuery( s );
//        }

        /// <summary>
        /// insert a xg data to tbl_xgdata
        /// </summary>
        /// <param name="remoteIP"> form gprs station ip</param>
        /// <param name="data"> xg data </param>
        static public void InsertXGData ( string remoteIP, XGData data )
        {
            ArgumentChecker.CheckNotNull( data );

            // find xgstation_id with remoteIP, id not find xgstation_id then return
            //
            int xgStId = XGDB.GetXGStaionID( remoteIP, data.FromAddress );

            // 2007-10-25 Added not find xgStId
            //
            if ( xgStId == 0 )
                return ;

            // find card_id and person with card sn, if not find 
            // card sn then the sn to tbl_card and return the id
            //
            int cardId;
            string person;

            bool b = XGDB.GetCardIdAndPerson( data.CardSN, true, out cardId, out person );
            if ( b )
            {
                // insert xgdata to tbl_xgdata
                //
                string sql = string.Format( @"insert into tbl_xgdata ( xgstation_id, card_id, xgtime, person ) 
                    values ( {0}, {1}, '{2}', '{3}')",
                    xgStId, cardId, data.XGStationDateTime, person );
 
                DbClient.ExecuteNonQuery( sql );
            }
        }

            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        static public void DeleteXGData( int id )
        {
            DeleteRow( "tbl_xgdata", "xgdata_id", id );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="createNew"></param>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        static private bool GetCardIdAndPerson ( string sn, bool createNew, out int id, out string person )
        {
//            string DEFAILT_PERSON = "(未知)"; 
            // 2007.03.24 
            //
//            string DEFAILT_PERSON = sn;
              string DEFAILT_PERSON = string.Empty;

            id = -1;
            person = string.Empty;

            string sql = string.Format( "select * from tbl_card where sn = '{0}'", sn );
            DataSet ds = DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];

            // not exit the sn
            //
            if ( tbl.Rows.Count == 0 )
            {
                if ( createNew )
                {
                    InsertCard( new Card( sn, DEFAILT_PERSON ) );
                    return GetCardIdAndPerson ( sn, false, out id, out person );
                }
                else
                {
                    return false;
                }
            }
            else
            {
                DataRow r = tbl.Rows[0];
                id = Convert.ToInt32( r["card_id"] );
                person = r["person"].ToString().Trim();
                return true;
            }
        }

        #region CardDB
        
        static public bool CheckCardSNExist ( string sn, int ignoreId )
        {
            string s = string.Format( "select count(*) from tbl_card where sn = '{0}' and card_id <> {1}",
                sn, ignoreId );
            return (int)DbClient.ExecuteScalar( s ) >= 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="obj"></param>
        /// <param name="op"></param>
        /// <param name="person"></param>
        static public void InsertCtrlLog( DateTime dt, string obj, string op, string person )
        {
            string s = string.Format("INSERT INTO tbl_ctrllog(dt, obj, op, person) VALUES('{0}', '{1}', '{2}', '{3}')",
                dt, obj, op, person);
            DbClient.ExecuteNonQuery( s );
        }

        static public void InsertCard( Card card )
        {
            ArgumentChecker.CheckNotNull( card );

            // card.Tag save team info
            //
            string team = card.Tag == null ? string.Empty : card.Tag.ToString();

            string s = string.Format( "INSERT INTO tbl_card(sn, person, remark, team) VALUES ('{0}', '{1}', '{2}','{3}')",
                card.SerialNumber, 
                card.Person, 
                card.Remark, 
                //card.Tag.ToString()  );
                team
                );

            DbClient.ExecuteNonQuery( s );
        }

        static public void DeleteCard ( int id )
        {
            DeleteRow( "tbl_card", "card_id", id );
        }

        static public void UpdateCard( int id, Card card )
        {
            ArgumentChecker.CheckNotNull( card );
            //2007.03.30 Added team
            //
            string team = card.Tag.ToString();

            string s = string.Format(@"UPDATE tbl_card SET sn = '{0}', person = '{1}' , remark = '{3}' , team = '{4}'
                WHERE (card_id = {2})", card.SerialNumber, card.Person, id, card.Remark ,team );
            DbClient.ExecuteNonQuery ( s );
        }
        #endregion //CardDB

        static public bool CheckGprsStationNameExist( string name, int ignoreId, int client )
        {
            string s = string.Format( @"select count(*) from tbl_gprs_station where 
                name = '{0}' and gprs_station_id <> {1} and client = {2}",
                name, ignoreId, client );
            return (int)DbClient.ExecuteScalar( s ) >= 1;
        }

        static public bool CheckGprsStationCommPortExist( int commPort, int ignoreId, int client )
        {
            string s = string.Format( @"select count(*) from tbl_gprs_station where 
                commPort = {0} and gprs_station_id <> {1} and client = {2}",
                commPort, ignoreId, client );
            return (int)DbClient.ExecuteScalar( s ) >= 1;
        }

        #region XGStation
        static public bool CheckXGStationNameExist ( string name, int ignoreId )
        {
            string s = string.Format( "select count(*) from tbl_xgstation where name = '{0}' and xgstation_id <> {1}",
                name, ignoreId );
            return (int)DbClient.ExecuteScalar( s ) >= 1;
        }

        static public void InsertXGStation( XGStation st )
        {
            ArgumentChecker.CheckNotNull ( st );

            string s;
            if ( st.Tag != null )
            {
                int gprsStationId = Convert.ToInt32( st.Tag );
                s = string.Format( "insert into tbl_xgstation( name, address, gprs_station_id ) values( '{0}', {1}, {2} )",
                    st.StationName, st.Address,gprsStationId);
            }
            else
            {
                s = string.Format( "insert into tbl_xgstation( name, address ) values( '{0}', {1} )",
                    st.StationName, st.Address );
            }
            DbClient.ExecuteNonQuery( s );
        }

        static public void InsertGRStation( GRStation st )
        {
            ArgumentChecker.CheckNotNull ( st );
            string s;
            if ( st.Tag != null )
            {
                int gprsStationId = Convert.ToInt32( st.Tag );
                s = string.Format( "insert into tbl_grstation( name, address, gprs_station_id ) values( '{0}', {1}, {2} )",
                    st.StationName, st.Address,gprsStationId);
            }
            else
            {
                s = string.Format( "insert into tbl_grstation( name, address ) values( '{0}', {1} )",
                    st.StationName, st.Address );
            }
            DbClient.ExecuteNonQuery( s );
        }

        static public void UpdateGrStation( int id, string name, int address )
        {
            string s = string.Format( "update tbl_grstation set name = '{0}', address = {1} where grstation_id = {2}",
                name, address, id );
            DbClient.ExecuteNonQuery( s );
        }

        static public void UpdateGprsStation ( int id, string name, string ip, string remark, string team, 
            string addDrag, float area , string serverIP , int teamOrder)
        {
            string s = string.Format( @"update tbl_gprs_station set name = '{0}', ip = '{1}', remark = '{2}',
                    team = '{4}', addDrug = '{5}', heatArea = {6}, serverIP = '{7}', teamorder = {8}
                 where gprs_station_id = {3} ",
                name, ip, remark, id, team, addDrag, area, serverIP, teamOrder );
            DbClient.ExecuteNonQuery( s );
        }

        static public void UpdateXGStation( int id , XGStation st )
        {
            ArgumentChecker.CheckNotNull( st );
            string s = string.Format("update tbl_xgstation set name = '{0}', address = {1} where xgstation_id = {2}",
                st.StationName, st.Address, id );
            DbClient.ExecuteNonQuery( s );
        }

        static public void UpdateXGStation( int id , string name, int address )
        {
            //ArgumentChecker.CheckNotNull( st );
            string s = string.Format("update tbl_xgstation set name = '{0}', address = {1} where xgstation_id = {2}",
                name, address, id );
            DbClient.ExecuteNonQuery( s );
        }


        static public void DeleteXGStation ( int id )
        {
            DeleteRow( "tbl_xgstation", "xgstation_id", id );
        }

        static public void DeleteGPRSStation( int id )
        {
            DeleteRow ( "tbl_gprs_station", "gprs_station_id" , id);
        }
        #endregion //XGStation

        #region XGTask
        static public int GetXgStationId( string stationName )
        {
            string s = string.Format("select xgstation_id from tbl_xgstation where name = '{0}'", stationName );
            return (int)DbClient.ExecuteScalar( s );
        }

        static public int GetCardIdFromPerson ( string person )
        {
            string s = string.Format( "select card_id from tbl_card where person = '{0}'", person );
            return (int)DbClient.ExecuteScalar( s );
        }

//        static public void InsertXGTask( XGTask task )
//        {
//            ArgumentChecker.CheckNotNull ( task );
//            InsertXGTask( task.XGStation.StationName, task.Card.Person, task.XGTime );
//        }

//        static public void InsertXGTask ( string stationName, string cardPerson, XGTime time )
//        {
//            ArgumentChecker.CheckNotNull ( time );
//
//            int stationId = GetXgStationId ( stationName );
//            int cardId = GetCardIdFromPerson ( cardPerson );
//            string beginTs = time.Begin.ToString();
//            string endTs = time.End.ToString();
//
//            string s =string.Format( @"insert into tbl_xgtask (card_id, xgstation_id, time_begin, time_end) 
//            values({0}, {1}, '{2}', '{3}')", cardId, stationId, beginTs, endTs );
//
//            DbClient.ExecuteNonQuery( s );
//        }

//        static public void UpdateXGTask ( int id, string stationName, string cardPerson, XGTime time )
//        {
//            ArgumentChecker.CheckNotNull( time );
//            int cardId = GetCardIdFromPerson( cardPerson );
//            int stationId = GetXgStationId( stationName );
//            string beginTs = time.Begin.ToString();
//            string endTs = time.End.ToString();
//
//            string s = string.Format( @"update tbl_xgtask set card_id = {0}, xgstation_id = {1}, 
//                time_begin = '{2}', time_end = '{3}' where xgtask_id = {4}",
//                cardId, stationId, beginTs, endTs, id );
//            DbClient.ExecuteNonQuery( s );
//        }
        static public void DeleteXGTask ( int taskId )
        {
            DeleteRow ( "tbl_xgtask", "xgtask_id", taskId );
        }

        
        #endregion //XGTask

        static public int QueryLastId( string table, string idName )
        {
            string sql = string.Format("select {0} from {1} order by {0} desc", idName, table);
            return Convert.ToInt32( DbClient.ExecuteScalar(sql) );
        }


        #region Resolve
        /// <summary>
        /// 根据数据库数据，生成对象,包括Cards, XGStations, XGTasks，
        /// 并存入Singles.S 的 CardIds, XGStationIds, XGTaskIds中。
        /// </summary>
        static public void Resolve()
        {
            Singles.S.CardIds = ResolveCard();
            Singles.S.XGStationIds = ResolveXGStation();
//            Singles.S.XGTaskIds = ResolveXGTask( Singles.S.XGStationIds, Singles.S.CardIds );
//            XGTasksCollection tasks = GetTasks( Singles.S.XGTaskIds );
//            if ( Singles.S.XGScheduler != null )
//            {
//                if ( Singles.S.XGScheduler.Enabled )
//                    Singles.S.XGScheduler.Enabled = false;
//            }
//            Singles.S.XGScheduler = new XGScheduler();
//            Singles.S.XGScheduler.Tasks = tasks;
//            Singles.S.XGScheduler.CheckTasks();
        }

        //// 2007.02.11 Added
        ////
        //static public void ResolveGprsStation()
        //{
        //    string s = string.Format(@"select gprs_station_id, name, commport, 
        //        gr_address, xg_address, grstation_id, xgstation_id from v_gprs_gr_xg where client = {0}", XGConfig.Default.ClientAorB );
        //    DataSet ds = DbClient.Execute( s );
        //    DataTable dt = ds.Tables[0];
        //    foreach ( DataRow r in dt.Rows )
        //    {
        //        string name = r[1].ToString();
        //        int commport = int.Parse( r[2].ToString() );
        //        CommPortProxy cpp = new CommPortProxy((short) commport, XGConfig.Default.CommPortSettings );
        //        // add try
        //        //
        //        try
        //        {
        //            cpp.Open();
        //        }
        //        catch
        //        {
        //            // Open commport fail.
        //            //
        //            Debug.Fail( "Open commport " + commport + " fail." );
        //        }
        //
        //        cpp.IsEnableAutoReport = true;
        //        cpp.RThreshold = 1;
        //        //cpp.ReceiveAutoReport += new EventHandler( ARDProcessor.Default.Process );
        //
        //        CFW.TaskScheduler commTaskSch = new CFW.TaskScheduler( cpp, XGConfig.Default.TaskSchedulerInterval );
        //        //commTaskSch.Executed +=new EventHandler( CommTaskResultProcessor.Default.Process );
        //        commTaskSch.Enabled = true;
        //
        //        // Add the commTask scheduler to taskSchedulerCollection
        //        //
        //        TaskSchedulersCollection tss = Singles.S.TaskSchCollection;
        //        tss.Add( commTaskSch );
        //        
        //    }
        //    
        //}

        static public ObjectIdAssociateCollection ResolveCard()
        {
            ObjectIdAssociateCollection cardIdAssoc = new ObjectIdAssociateCollection( "tbl_card" );

            string s = "select card_id, sn, person from tbl_card";
            DataSet ds = DbClient.Execute( s );
            DataTable tbl = ds.Tables[0];
            foreach ( DataRow r in tbl.Rows )
            {
                int id = int.Parse( r[0].ToString() );
                string sn = r[1].ToString();
                string person = r[2].ToString();

                Card card = new Card( sn , person );
                cardIdAssoc.Add( card, id );
            }

            return cardIdAssoc;
        }

        /// <summary>
        /// 解析巡更控制器站点
        /// </summary>
        /// <returns></returns>
        static public ObjectIdAssociateCollection ResolveXGStation()
        {
            ObjectIdAssociateCollection stationIdAssoc = new ObjectIdAssociateCollection( "tbl_xgstation" );

//            string s = "select xgstation_id, name, address from tbl_xgstation";
            string s = "select xgstation_id, name, xg_address, ip from v_gprs_gr_xg";
            DataSet ds = DbClient.Execute( s );
            DataTable tbl = ds.Tables[0];
            foreach ( DataRow r in tbl.Rows )
            {
                int id          = int.Parse( r[0].ToString() );
                string name     =            r[1].ToString();
                int address     = int.Parse( r[2].ToString() );
                string ipAddr   =            r[3].ToString().Trim();

                XGStation st = new XGStation( name, ipAddr, address );
                stationIdAssoc.Add( st, id );
            }

            return stationIdAssoc;
        }



//        /// <summary>
//        /// 解析巡更任务
//        /// </summary>
//        /// <param name="stationIds"></param>
//        /// <param name="cardIds"></param>
//        /// <returns></returns>
//        static public ObjectIdAssociateCollection ResolveXGTask( ObjectIdAssociateCollection stationIds,
//            ObjectIdAssociateCollection cardIds )
//        {
//            ArgumentChecker.CheckNotNull( stationIds );
//            ArgumentChecker.CheckNotNull( cardIds );
//
//            ObjectIdAssociateCollection taskIdAssoc = new ObjectIdAssociateCollection("tbl_xgtask");
//            string s = "select xgtask_id, card_id, xgstation_id, time_begin, time_end from tbl_xgtask";
//            DataSet ds =  DbClient.Execute( s );
//            DataTable tbl = ds.Tables[0];
//            foreach ( DataRow r in tbl.Rows )
//            {
//                int id          = int.Parse( r[0].ToString() );
//                int cardId      = int.Parse ( r[1].ToString() );
//                int stationId   = int.Parse ( r[2].ToString() );
//                string begin    = r[3].ToString();
//                string end      = r[4].ToString();
//                
//                XGTime time = new XGTime( DateTime.Parse( begin ), 
//                    DateTime.Parse( end ) );
//
//                Card card = (Card) cardIds.GetObject( cardId );
//                XGStation st = (XGStation) stationIds.GetObject( stationId );
//
//                Debug.Assert( (card != null) && (st != null) );
//                if ( card != null && st != null )
//                {
//                    XGTask task = new XGTask( st, card, time);
//                    taskIdAssoc.Add( task, id );
//                }
//            }
//
//            return taskIdAssoc;
//        }

//        static public XGTasksCollection GetTasks( ObjectIdAssociateCollection oias )
//        {
//            XGTasksCollection tasks = new XGTasksCollection();
//
//            for ( int i=0; i<oias.Count; i++ )
//            {
//                tasks.Add( (XGTask)oias.GetObjectByIndex( i ) );
//            }
//
//            return tasks;
//        }
        #endregion //Resolve

        static private void ExceptionHandler ( Exception ex )
        {
            MsgBox.Show( ex.ToString(), ex.GetType().Name, System.Windows.Forms.MessageBoxIcon.Error );
        }

        /// <summary>
        /// 获取ip, addr 对应的供热站点id
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="addr"></param>
        /// <returns></returns>
        static public int GetGRStationID( string remoteIP, int addr )
        {
            try
            {
                string sql = string.Format( "select grstation_id from v_gprs_gr_xg where ip = '{0}' and gr_address = {1}",
                    remoteIP, addr );
                object obj = DbClient.ExecuteScalar( sql );
                if ( obj == null )
                    return -1 ;
                return Convert.ToInt32( obj );
            }
            catch ( Exception ex )
            {
                ExceptionHandler ( ex );
                return -1;
            }
        }

        static public string GetGRStationName ( string remoteIP )
        {
            try
            {
                string sql = string.Format( "select name from tbl_gprs_station where ip = '{0}'", remoteIP );
                object obj = DbClient.ExecuteScalar( sql );
                if ( obj == null )
                    return string.Empty;
                return obj.ToString().Trim();
            }
            catch( Exception ex )
            {
                //MsgBox.Show( ex.ToString() );
                ExceptionHandler ( ex );
                return string.Empty;
            }
        }


        static public int GetXGStaionID ( string remoteIP, int addr )
        {
            string sql = string.Format( "select xgstation_id from v_gprs_gr_xg where ip = '{0}' and xg_address = {1}",
                remoteIP, addr );
            object obj = DbClient.ExecuteScalar( sql );
            return Convert.ToInt32( obj );
        }
        
        static public void DeleteGrAlarmData ( int id )
        {
            string sql = "delete from tbwalarm where id = " + id ;
            DbClient.ExecuteNonQuery( sql );
        }

        #endregion //Properties
    }

    

    #endregion //XGDB
}
