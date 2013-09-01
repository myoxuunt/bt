using System;
using CFW;
using System.Diagnostics;
using Utilities;
using Infragistics.Shared;

namespace Communication.GRCtrl
{
    #region XGCommandMaker
    /// <summary>
    /// GRCommandMaker
    /// </summary>
    public class GRCommandMaker
    {
        public static byte[] MakeCommand(int address, int deviceType, int functionCode, byte[] datas)
        {
            int datasLength = (datas == null ? 0 : datas.Length) ;
            int length = XGDefinition.ZERO_DATA_CMD_LENGTH + datasLength; 

            byte[] r = new byte[length];
            r[0] = 0x21;            //!
            r[1] = 0x58;            //X
            r[2] = 0x44;            //D
            r[3] = (byte)address;
            r[4] = (byte)deviceType;
            r[5] = (byte)functionCode;
            r[6] = (byte)datasLength;

            for (int i=0; i<datasLength; i++)
            {
                r[ XGDefinition.INNER_DATA_BEGIN_POS + i ] = datas[i];
            }
            byte hi, lo;
            CRC16.CalculateCRC(r, length - 2, out hi, out lo );
            
            r[length - 2] = lo;
            r[length - 1] = hi;

            return r;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="deviceType"></param>
        /// <param name="functionCode"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static CommResultState CheckReceivedData(int address, int deviceType, 
            int functionCode, byte[] datas)
        {

            if ( datas == null || datas.Length == 0 )
                return CommResultState.NullData;

            if (datas == null || datas.Length < XGDefinition.ZERO_DATA_CMD_LENGTH)
                return CommResultState.LengthError;

            int innerDataLen = datas[ XGDefinition.INNER_DATA_LENGTH_POS ];
            //if ( innerDataLen != XGDefinition.GetInnerDataLen( functionCode ) )
                //return CommResultState.LengthError;

            if (datas.Length != XGDefinition.ZERO_DATA_CMD_LENGTH + innerDataLen)
                return CommResultState.LengthError;

            byte calcHi, calcLo;
            CRC16.CalculateCRC( datas, datas.Length - 2, out calcHi, out calcLo );
            
            byte lo = datas[ datas.Length - 2];
            byte hi = datas[ datas.Length - 1];
            if (hi != calcHi || lo != calcLo)
                return CommResultState.CheckError;

            int rAddress = datas[ XGDefinition.ADDRESS_POS ];
            int rDeviceType = datas [ XGDefinition.DEVICE_TYPE_POS ];
            int rFC = datas[ XGDefinition.FUNCTION_CODE_POS ];

            if ( rAddress != address ||
                rDeviceType != deviceType ||
                rFC != functionCode )
                return CommResultState.DataError;

            return CommResultState.Correct;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceType"></param>
        /// <param name="functionCode"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static CommResultState CheckReceivedData(int deviceType,
            int functionCode, byte[] datas)
        {
            // 2007.03.09 Added check is nullData
            //
            if ( datas == null || datas.Length == 0 )
                return CommResultState.NullData;

            if (datas == null || datas.Length < XGDefinition.ZERO_DATA_CMD_LENGTH)
                return CommResultState.LengthError;

            int innerDataLen = datas[ XGDefinition.INNER_DATA_LENGTH_POS ];
            if ( innerDataLen != GRDef.GetInnerDataLen( functionCode ) )
                return CommResultState.LengthError;

            if (datas.Length != XGDefinition.ZERO_DATA_CMD_LENGTH + innerDataLen)
                return CommResultState.LengthError;

            byte calcHi, calcLo;
            CRC16.CalculateCRC( datas, datas.Length - 2, out calcHi, out calcLo );
            
            byte lo = datas[ datas.Length - 2];
            byte hi = datas[ datas.Length - 1];
            if (hi != calcHi || lo != calcLo)
                return CommResultState.CheckError;

            //int rAddress = datas[ XGDefinition.ADDRESS_POS ];
            int rDeviceType = datas [ XGDefinition.DEVICE_TYPE_POS ];
            int rFC = datas[ XGDefinition.FUNCTION_CODE_POS ];

            if (// rAddress != address ||
                rDeviceType != deviceType ||
                rFC != functionCode )
                return CommResultState.DataError;

            return CommResultState.Correct;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static byte[] GetReceivedInnerData(byte[] datas )
        {
            int innerDataLen = datas[ XGDefinition.INNER_DATA_LENGTH_POS ];
            if (innerDataLen == 0)
				return new byte[0];
//                return null;

            byte[] innerData = new byte[innerDataLen];

            for (int i=0; i<innerDataLen; i++)
            {
                innerData[i] = datas[XGDefinition.INNER_DATA_BEGIN_POS + i];
            }           

            return innerData;
        }


        /// <summary>
        /// return address of gr ctrl from a receive data
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static int GetCtrlAddress( byte[] bs )
        {
            return bs[GRDef.ADDRESS_POS];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static bool IsGrData( byte[] bs )
        {
            return bs[GRDef.DEVICE_TYPE_POS] == GRDef.DEVICE_TYPE;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static bool IsRealData( byte[] bs )
        {
            return bs[GRDef.FUNCTION_CODE_POS] == GRDef.FC_READ_REALDATA;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static bool IsAlarmData( byte[] bs )
        {
            return bs[GRDef.FUNCTION_CODE_POS] == GRDef.FC_AUTO_ALARMDATA;
        }
    }
    #endregion // GRCommandMaker
}
