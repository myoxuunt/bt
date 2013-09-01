using System;

namespace Tool
{
    //数据解析方式
    public class DataInfo
    {
        public DataInfo()
        {
        }

        #region GetGRDataTypes
        static public float GetFloatValue(byte[] datas, int begin)//, int len )
        {
            return BitConverter.ToSingle(datas, begin);
        }
        static public ulong GetULongValue(byte[] datas, int begin)
        {
            return BitConverter.ToUInt32(datas, begin);
        }
        static public int GetLongValue(byte[] datas, int begin)
        {
            return BitConverter.ToInt16(datas, begin);
        }

        static public float GetFloatValue2(byte[] datas, int begin)//, int len )
        {
            byte[] data_c = { datas[begin + 1], datas[begin + 0], datas[begin + 3], datas[begin + 2] };
            return BitConverter.ToSingle(data_c, 0);
        }
        static public ulong GetULongValue2(byte[] datas, int begin)
        {
            byte[] data_c = { datas[begin + 3], datas[begin + 2], datas[begin + 1], datas[begin] };
            return BitConverter.ToUInt32(data_c, 0);
        }
        static public int GetLongValue2(byte[] datas, int begin)
        {
            byte[] data_c = { datas[begin + 1], datas[begin] };
            return BitConverter.ToInt16(data_c, 0);
        }

        static public byte GetByteValue(byte[] datas, int begin)
        {
            return datas[begin];
        }

        static public byte[] GetBitValue(float datas)
        {
            byte[] getBitValue = new byte[4];
            getBitValue = BitConverter.GetBytes(datas);
            return getBitValue;
        }
        static public byte[] GetBitValueInt(int datas)
        {
            byte[] getBitValue = new byte[4];
            getBitValue = BitConverter.GetBytes(datas);
            return getBitValue;
        }
        static public byte bytetoBCD(byte data)
        {
            if (data >= 10)
            {
                byte hexlo = Convert.ToByte(data % 10);
                byte hexhi = Convert.ToByte((data - hexlo) / 10);
                hexhi *= 16;
                byte bcd = Convert.ToByte(hexhi + hexlo);
                return bcd;
            }
            else
            {
                return data;
            }
        }

        static public byte BCDtobyte(byte data)
        {
            byte hexlo = Convert.ToByte(data % 16);
            byte hexhi = Convert.ToByte((data - hexlo) / 16);
            hexhi *= 10;
            byte bcd = Convert.ToByte(hexhi + hexlo);
            return bcd;
        }

        //获取泵状态
        static public xd100x.GRPumpState GetPumpState(byte state, int bitIndex)
        {
            byte mask = (byte)Math.Pow(2, bitIndex);
            int r = mask & state;
            if (r > 0)
                return xd100x.GRPumpState.运行;
            else
                return xd100x.GRPumpState.停止;
        }

        //获取报警状态
        static public xd100x.GRAlarm GetAlarmData(byte state, int bitIndex)
        {
            byte mask = (byte)Math.Pow(2, bitIndex);
            int r = mask & state;
            if (r > 0)
                return xd100x.GRAlarm.有;
            else
                return xd100x.GRAlarm.无;
        }

        #endregion


        static public Tool.xd100x.GRPumpState dttops(string str)
        {
            if (str == Tool.xd100x.GRPumpState.运行.ToString())
            {
                return Tool.xd100x.GRPumpState.运行;
            }
            else
            {
                return Tool.xd100x.GRPumpState.停止;
            }
        }



        #region Modbus
        //通用生成读取命令函数
        //byte address 设备地址
        //byte function 功能码
        //int startaddress 起始地址
        //int endaddress 结束地址
        static public byte[] ModbusGetData(byte address, byte function, int startaddress, int endaddress)
        {
            int length = endaddress - startaddress + 1;
            byte[] outByte = new byte[8];
            byte[] temp = new byte[4];
            outByte[0] = address;
            outByte[1] = function;
            temp = BitConverter.GetBytes(startaddress - 1);
            outByte[2] = temp[1];
            outByte[3] = temp[0];
            temp = BitConverter.GetBytes(length);
            outByte[4] = temp[1];
            outByte[5] = temp[0];
            return DataInfo.CRC16(outByte);
        }
        //通用设置命令
        //功能码固定为0x10
        //int startaddress 起始地址
        //int[] data 数据数组
        static public byte[] ModbusSetData(byte address, byte function, int startaddress, int[] data)
        {
            byte[] outByte = new byte[9 + data.Length*2];
            byte[] temp = new byte[4];
            outByte[0] = address;
            outByte[1] = function;
            temp = BitConverter.GetBytes(startaddress - 1);
            outByte[2] = temp[1];
            outByte[3] = temp[0];
            temp = BitConverter.GetBytes(data.Length);
            outByte[4] = temp[1];
            outByte[5] = temp[0];
            outByte[6] = Convert.ToByte(data.Length*2);
            for (int i = 0; i < data.Length * 2; i++)
            {
                temp = BitConverter.GetBytes(data[i / 2]);
                if (i % 2 == 0)
                {
                    outByte[7 + i] = temp[1];
                }
                else
                {
                    int c = data[i / 2];
                    outByte[7 + i] = temp[0];
                }
            }
            return DataInfo.CRC16(outByte);
        }
        #endregion


        //计算CRC
        static public byte[] CRC16(Byte[] data)
        {
            byte CRC16Lo = 0xff, CRC16Hi = 0xff;
            byte CL = 0x1, CH = 0xA0;
            byte SaveHi, SaveLo;
            for (int i = 0; i < data.Length - 2; i++)
            {
                CRC16Lo ^= data[i];
                for (int Flag = 0; Flag < 8; Flag++)
                {
                    SaveHi = CRC16Hi;
                    SaveLo = CRC16Lo;
                    CRC16Hi >>= 1;
                    CRC16Lo >>= 1;
                    if ((SaveHi & 0x01) == 0x01)
                    {
                        CRC16Lo |= 0x80;
                    }
                    if ((SaveLo & 0x1) == 0x1)
                    {
                        CRC16Hi ^= CH;
                        CRC16Lo ^= CL;
                    }
                }
            }
            data[data.Length - 2] = CRC16Lo;
            data[data.Length - 1] = CRC16Hi;
            return data;
        }

        //校验crc
        static public bool CheckCRC(byte[] data)
        {
            if (data.Length < 3)
            {
                return false;
            }
            byte[] temp = new byte[data.Length];
            for (int i = 0; i < data.Length - 2; i++)
            {
                temp[i] = data[i];
            }
            byte[] crc = CRC16(temp);
            if (crc[crc.Length - 2] == data[data.Length - 2] && crc[crc.Length - 1] == data[data.Length - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //xd100的方式
        #region xd100
        static public byte[] xd100GetData(byte address, byte function)
        {
            byte[] outByte = { 0x21, 0x58, 0x44, address,0xA0,function,0x00,0x00,0x00};
            return DataInfo.CRC16(outByte);    
        }
        static public byte[] xd100GetData(byte address, byte function, byte menu)
        {
            byte[] outByte = { 0x21, 0x58, 0x44, address, 0xA0, function, 0x01,menu,0x00, 0x00 };
            return DataInfo.CRC16(outByte); 
        }

        static public byte[] SetData(byte address, byte function)
        {
            byte[] outByte = new byte[9];
            outByte[0] = 0x21;
            outByte[1] = 0x58;
            outByte[2] = 0x44;
            outByte[3] = address;
            outByte[4] = 0xA0;
            outByte[5] = function;
            outByte[6] = 0x00;
            return DataInfo.CRC16(outByte);
        }

        static public byte[] SetData(byte address, byte function, byte[] data)
        {
            byte[] outByte = new byte[9 + data.Length];
            outByte[0] = 0x21;
            outByte[1] = 0x58;
            outByte[2] = 0x44;
            outByte[3] = address;
            outByte[4] = 0xA0;
            outByte[5] = function;
            outByte[6] = Convert.ToByte(data.Length);
            for (int i = 0; i < data.Length; i++)
            {
                outByte[7 + i] = data[i];
            }
            return DataInfo.CRC16(outByte);
        }

        #endregion
    }
}
