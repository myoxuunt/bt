using System;
using System.Collections;

namespace Communication
{
    #region GrDataPointsCollection
    /// <summary>
    /// 
    /// </summary>
    public class GrDataPointsCollection
    {
        #region Members
        private ArrayList _list;
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public GrDataPointsCollection (int capacity)
        {
            _list = new ArrayList( capacity );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 50 = 48 = 24 hour / 0.5
        /// </remarks>
        public GrDataPointsCollection ()
            : this( 50 )
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
        public GrDataPoint this[ int index ]
        {
            get { return (GrDataPoint)_list[index];}
            set 
            {
                if ( value == null )
                    throw new ArgumentNullException( "this[] setter value" );
                
                _list[index] = value;
            }
        }
        #endregion //Properties

        #region Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grDataPoint"></param>
        /// <returns></returns>
        public int Add( GrDataPoint grDataPoint )
        {
            if ( grDataPoint  == null )
                throw new ArgumentNullException("add()");
            return _list.Add( grDataPoint );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grDataPoint"></param>
        public void Remove( GrDataPoint grDataPoint )
        {
            _list.Remove( grDataPoint );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void removeAt( int index )
        {
            _list.RemoveAt( index );
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        #endregion //Method
    }
    #endregion //GrDataPointsCollection
}
