using System;

namespace Communication
{
    /// <summary>
    /// 数据域
    /// </summary>
    public struct DataField
    {
        #region Members
        public const int UNSURENESS = -1;

        private int     _beginPosition;
        private int     _dataLength;
        private byte[]  _values;
        #endregion //Members

        #region Constructor


        /// <summary>
        /// 由beginPosition起始，长度为dataLength，数据为values的域
        /// </summary>
        /// <param name="beginPosition"></param>
        /// <param name="dataLength"></param>
        /// <param name="values"></param>
        public DataField( int beginPosition, int dataLength, byte[] values )
        {
            _beginPosition = UNSURENESS ;
            _dataLength = UNSURENESS ;
            _values = null;

            SetBeginPosition( beginPosition );
            SetDataLength( dataLength );
            SetValues( values );

        }

        /// <summary>
        /// 由beginPosition起始，长度为dataLength的域，数据不确定
        /// </summary>
        /// <param name="beginPosition"></param>
        /// <param name="dataLength"></param>
        public DataField( int beginPosition, int dataLength ) 
            : this ( beginPosition, dataLength, null )
        {
        }

        /// <summary>
        /// 由beginPosition起始，长度为1的域，数据不确定
        /// </summary>
        /// <param name="beginPosition"></param>
        public DataField( int beginPosition ) : this ( beginPosition, 1 )
        {
        }

        #endregion //Constructor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int BeginPostion
        {
            get { return _beginPosition; }
            set { SetBeginPosition( value ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int DataLength
        {
            get { return _dataLength; }
            set { SetDataLength( value ); } 
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Values
        {
            get { return _values; }
            set { SetValues( value ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAssuredValues
        {
            get { return this._values != null && this._values.Length > 0; }
        }
        #endregion //Properties

        #region Method

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public byte[] GetMatch(byte[] datas)
        {
            return GetMatch(datas, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public byte[] GetMatch(byte[] datas, int index)
        {
            if (BeginPostion == DataField.UNSURENESS)
                throw new Exception("BeginPostion == UNSURENESS");

            if (DataLength == DataField.UNSURENESS)
                throw new Exception("DataLength == UNSURENESS");

            int b = this.BeginPostion + index;
            int e = b + this.DataLength;

            int len = e - b;
            byte[] ans = new byte[len];
            Array.Copy(datas, b, ans, 0, len);

            return ans;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool IsMatch( byte[] datas, int index )
        {
            if ( datas == null )
                return false;
            if ( this._beginPosition == UNSURENESS ||
                 this._dataLength    == UNSURENESS ||
                 this._values        == null )
                return false;

            int b = index + _beginPosition;
            int e = b + _dataLength;
            
            if ( b > datas.Length || e > datas.Length )
                return false;

            for ( int i=0; i<_dataLength; i++ )
            {
                if ( datas[ b + i ] != _values[ i ] )
                    return false;
            }
            return true;
        }


        /// <summary>
        /// 搜索Value在bs中出现的位置，如果bs中不包含value则返回-1
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public int SearchBeginPos( byte[] bs )
        {
            if ( this._values == null )
                throw new Exception( "Values == null, at SearchBeginPos()" );
            if ( bs == null )
                return -1;
            if ( bs.Length < Values.Length )
                return -1;

            for( int i=0; i<bs.Length - Values.Length; i++ )
            {
                int offset = 0;
                for( int j=0; j<Values.Length; j++ )
                {
                    if ( bs[i + offset] == Values[j] )
                        offset++;
                    else
                        break;
                }
                if ( offset == Values.Length )
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginPosition"></param>
        private void SetBeginPosition ( int beginPosition )
        {
            if ( beginPosition < 0 && beginPosition != UNSURENESS )
                throw new ArgumentOutOfRangeException( "beginPosition" );
            _beginPosition = beginPosition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataLength"></param>
        private void SetDataLength( int dataLength )
        {
            // 数据长度必须大于等于0, 但是UNSURENESS值除外
            //
            if ( dataLength < 0 && dataLength != UNSURENESS )
                throw new ArgumentOutOfRangeException( "dataLength" );
            _dataLength = dataLength;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        private void SetValues( byte[] values )
        {
            // 当values确定的时候, dataLength和values.Length必须相等
            //
            if ( values != null && values.Length > 0 )
            {
                if ( _dataLength != values.Length )
                    throw new ArgumentException( "dataLength != values.Length", "dataLength" );
            }
            _values = values;            
        }        
        #endregion //Method
    }
}
