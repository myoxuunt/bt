using System;
using System.Collections;

namespace Communication
{
    #region WccResultSet
    /// <summary>
    /// 
    /// </summary>
    public class WccResultSet
    {
        #region Members
        private const int CAPACITY = 70 + 10;  // station count

        private ArrayList _list = new ArrayList( CAPACITY );
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public WccResultSet()
        {
        }
        #endregion //Constructor

        #region Properties
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
        public WccResultsCollection this[ int index ]
        {
            get { return (WccResultsCollection) _list[ index ]; }
        }

        #endregion //Properties

        #region Method

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wccrs"></param>
        public void Add( WccResultsCollection wccrs )
        {
           if ( wccrs == null )
               throw new ArgumentNullException( "wccrs" );

            _list.Add( wccrs );
        }
        #endregion //Method
    }
    #endregion //WccResultSet
}
