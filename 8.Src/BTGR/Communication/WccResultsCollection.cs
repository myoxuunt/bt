using System;
using System.Collections;

namespace Communication
{
    #region WccResultsCollection
    /// <summary>
    /// 
    /// </summary>
    public class WccResultsCollection
    {
        #region Members
        private const int CAPACITY = 31;


        private ArrayList   _list = new ArrayList( CAPACITY );
        private string      _stationName;
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        public WccResultsCollection( string stationName )
        {
            _stationName = stationName;
        }
        #endregion //Constructor

        #region Properties

        #region StationName
        /// <summary>
        /// 
        /// </summary>
        public string StationName
        {
        	get { return _stationName; }
        }
        #endregion //StationName

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WccResult this[int index]
        {
            get { return (WccResult) _list[ index ]; }
        }

        #endregion //Properties

        #region Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wccresult"></param>
        public void Add( WccResult wccresult )
        {
            if ( wccresult == null )
                throw new ArgumentNullException( "wccresult" );
            
            _list.Add( wccresult );
        }
        #endregion //Method
    }
    #endregion //WccResultsCollection
}
