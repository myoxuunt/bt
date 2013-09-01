using System;

namespace Communication
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class BytesParserBase
    {
        #region Members
        /// <summary>
        /// 
        /// </summary>
        protected object _value;
        /// <summary>
        /// 
        /// </summary>
        protected byte[] _bytes;

        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        public BytesParserBase(byte[] bs)
        {
            _bytes = bs;
        }
        #endregion //Constructor

        #region Properties

        #region Bytes
        /// <summary>
        /// 
        /// </summary>
        public byte[] Bytes
        {
        	get { return _bytes; }
        	set { _bytes = value; }
        }
        #endregion //Bytes

        #region Value
        /// <summary>
        /// 
        /// </summary>
        public object Value
        {
        	get { return _value; }
        	set { _value = value; }
        }
        #endregion //Value

        #endregion //Properties

        #region Method
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract public object ToValue();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract public byte[] ToBytes();
        #endregion //Method

    }
	
}
