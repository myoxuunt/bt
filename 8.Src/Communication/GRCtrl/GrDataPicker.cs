using System;
using Communication;
using System.Collections;

namespace Communication.GRCtrl
{
    /// <summary>
    /// GrDataPicker 的摘要说明。
    /// </summary>
    public class GrDataPicker
    {

        #region Members
        private DataField _head = new DataField( 
            0, 
            3, 
            new byte[] {0x21, 0x58, 0x44} 
            );

        private DataField _devType = new DataField(
            GRDef.DEVICE_TYPE_POS,
            1,
            new byte[] { GRDef.DEVICE_TYPE }
            );

        private DataField _innerDataLen = new DataField(
            GRDef.INNER_DATA_LENGTH_POS,
            1,
            null 
            );

        private int _minLen = GRDef.ZERO_DATA_CMD_LENGTH;

        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public GrDataPicker()
        {
        }
        #endregion //Constructor

        #region Properties
        #endregion //Properties

        #region Method

        /// <summary>
        /// 
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        private byte[][] ArraylistToByteDim2( ArrayList al )
        {
            if ( al != null &&
                 al.Count > 0 )
            {
                byte[][] r = new byte[al.Count][];
                for( int i =0; i<al.Count; i++ )
                {
                    r[i] = al[i] as byte[];
                }
                return r;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public byte[][] Picker( byte[] datas )
        {
            if ( datas == null || datas.Length < _minLen )
                return null;

            ArrayList al = new ArrayList();
            for ( int i=0; i<datas.Length - _minLen; i++ )
            {
                if ( _head.IsMatch( datas, i ) &&
                    _devType.IsMatch( datas, i ) )
                {
                    byte[] bs = _innerDataLen.GetMatch( datas, i );

                    // idl - inner data length
                    int idl = bs[0];
                    if ( idl + _minLen + i <= datas.Length )
                    {
                        DataField df = new DataField( 0, idl + _minLen );
                        byte[] aGrData = df.GetMatch( datas, i );

                        al.Add( aGrData );
                    }
                }
            }
            return ArraylistToByteDim2( al );

        }
        #endregion //Method
    }
}
