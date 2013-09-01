using System;

namespace Tool
{
    public class xd100n
    {
        //加载命令
        #region
        public static void load_xd100ncmd(int listID, xd100x.Set _Set)
        {
            xd100x._XD100xBuffer[listID]._Command = new xd100x.Command[42];
            byte addr = xd100x._XD100xBuffer[listID]._Info._addr;
            xd100x._XD100xBuffer[listID]._Command[0]._cmd = Get_ai(addr);
            xd100x._XD100xBuffer[listID]._Command[1]._cmd = Get_valvecontrol(addr);
            xd100x._XD100xBuffer[listID]._Command[2]._cmd = Get_valvevalue(addr);
            xd100x._XD100xBuffer[listID]._Command[3]._cmd = Get_valveline(addr);
            xd100x._XD100xBuffer[listID]._Command[4]._cmd = Get_valvetime(addr);
            xd100x._XD100xBuffer[listID]._Command[5]._cmd = Get_valvemm(addr);
            xd100x._XD100xBuffer[listID]._Command[6]._cmd = Get_valvelimit(addr);
            xd100x._XD100xBuffer[listID]._Command[7]._cmd = Get_cycpumpline(addr);
            xd100x._XD100xBuffer[listID]._Command[8]._cmd = Get_cycpumpvalue(addr);
            xd100x._XD100xBuffer[listID]._Command[9]._cmd = Get_addpumpvalue(addr);
            xd100x._XD100xBuffer[listID]._Command[10]._cmd = Get_addpumpmm(addr);
            xd100x._XD100xBuffer[listID]._Command[11]._cmd = Get_alarmp(addr);
            xd100x._XD100xBuffer[listID]._Command[12]._cmd = Get_alarmt(addr);
            xd100x._XD100xBuffer[listID]._Command[13]._cmd = Get_outmode(addr);

            xd100x._XD100xBuffer[listID]._Command[14]._cmd = Set_valvecontrol(addr, _Set._valvecontrol);
            xd100x._XD100xBuffer[listID]._Command[15]._cmd = Set_valvevalue(addr, _Set._valvevalue);
            xd100x._XD100xBuffer[listID]._Command[16]._cmd = Set_valveline(addr, _Set._valveline);
            xd100x._XD100xBuffer[listID]._Command[17]._cmd = Set_valvetime(addr, _Set._valvetime);
            xd100x._XD100xBuffer[listID]._Command[18]._cmd = Set_valvemm(addr, _Set._valvemm);
            xd100x._XD100xBuffer[listID]._Command[19]._cmd = Set_valvelimit(addr, _Set._valvelimit);
            xd100x._XD100xBuffer[listID]._Command[20]._cmd = Set_cycpumpline(addr, _Set._cycpumpline);
            xd100x._XD100xBuffer[listID]._Command[21]._cmd = Set_cycpumpvalue(addr, _Set._cycpumpvalue);
            xd100x._XD100xBuffer[listID]._Command[22]._cmd = Set_addpumpvalue(addr, _Set._addpumpvalue);
            xd100x._XD100xBuffer[listID]._Command[23]._cmd = Set_addpumpmm(addr, _Set._addpumpmm);
            xd100x._XD100xBuffer[listID]._Command[24]._cmd = Set_alarmp(addr, _Set._alarmp);
            xd100x._XD100xBuffer[listID]._Command[25]._cmd = Set_alarmt(addr, _Set._alarmt);
            xd100x._XD100xBuffer[listID]._Command[26]._cmd = Set_outmode(addr, _Set._outmode);
            xd100x._XD100xBuffer[listID]._Command[27]._cmd = Set_outtemp(addr, _Set._outtemp);

            xd100x._XD100xBuffer[listID]._Command[28]._cmd = Set_cycpumpstop(addr);
            xd100x._XD100xBuffer[listID]._Command[29]._cmd = Set_addpumpstop(addr);
            xd100x._XD100xBuffer[listID]._Command[30]._cmd = Set_cycpumprun(addr);
            xd100x._XD100xBuffer[listID]._Command[31]._cmd = Set_addpumprun(addr);

            xd100x._XD100xBuffer[listID]._Command[32]._cmd = Get_outrevise(addr);
            xd100x._XD100xBuffer[listID]._Command[33]._cmd = Get_GT1revise(addr);
            xd100x._XD100xBuffer[listID]._Command[34]._cmd = Get_BT1revise(addr);
            xd100x._XD100xBuffer[listID]._Command[35]._cmd = Get_GT2revise(addr);
            xd100x._XD100xBuffer[listID]._Command[36]._cmd = Get_BT2revise(addr);

            xd100x._XD100xBuffer[listID]._Command[37]._cmd = Set_outrevise(addr, _Set._outrevise);
            xd100x._XD100xBuffer[listID]._Command[38]._cmd = Set_GT1revise(addr, _Set._GT1revise);
            xd100x._XD100xBuffer[listID]._Command[39]._cmd = Set_BT1revise(addr, _Set._BT1revise);
            xd100x._XD100xBuffer[listID]._Command[40]._cmd = Set_GT2revise(addr, _Set._GT2revise);
            xd100x._XD100xBuffer[listID]._Command[41]._cmd = Set_BT2revise(addr, _Set._BT2revise);

            for (int i = 0; i < xd100x._XD100xBuffer[listID]._Command.Length; i++)
            {
                xd100x._XD100xBuffer[listID]._Command[i]._back = false;
                Tool.xd100x._XD100xBuffer[listID]._Command[i]._backdt = DateTime.Now.AddYears(-1);
            }
          //  xd100x._XD100xBuffer[listID]._Command[42]._cmd = Set_datetime(addr);
        }
        #endregion

        //数据处理方法
        #region
        //读取命令生成区域
        #region Get 

        //获取当前数据模拟量
        public static byte[] Get_ai(byte address)
        {
            return DataInfo.ModbusGetData(address,4,1,50);
        }
        //获取泵状态和报警
        //public static byte[] Get_di(byte address)
        //{
        //    return DataInfo.ModbusGetData(address, 2, 1, 32);
        //}
        //获取调节阀控制模式
        public static byte[] Get_valvecontrol(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 114, 114);
        }
        //获取调节阀设定值
        public static byte[] Get_valvevalue(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 116, 116);
        }
        //获取调节阀温度曲线
        public static byte[] Get_valveline(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 117, 132);
        }
        //获取调节阀分时调整
        public static byte[] Get_valvetime(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 133, 144);
        }
        //获取调节阀开度上下限
        public static byte[] Get_valvemm(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 145, 146);
        }
        //获取调节阀流量限定
        public static byte[] Get_valvelimit(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 153, 154);
        }
        //获取报警设置压力
        public static byte[] Get_alarmp(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 198, 201);
        }
        //获取报警设置温度
        public static byte[] Get_alarmt(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 202, 205);
        }
        //获取室外温度设置
        public static byte[] Get_outmode(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 206, 207);
        }
        //获取压差曲线
        public static byte[] Get_cycpumpline(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 161, 176);
        }
        //获取压差设定
        public static byte[] Get_cycpumpvalue(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 159, 159);
        }
        //获取补水泵模式及压力设定
        public static byte[] Get_addpumpvalue(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 183, 184);
        }
        //获取补水泵压力上下限
        public static byte[] Get_addpumpmm(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 189, 192);
        }
        //室外温度修正
        public static byte[] Get_outrevise(byte address)
        {
            return DataInfo.ModbusGetData(address, 3,4,5);
        }
        //获取一次供温温度修正
        public static byte[] Get_GT1revise(byte address)
        {
            return DataInfo.ModbusGetData(address, 3,11, 12);
        }
        //获取一次回温度修正
        public static byte[] Get_BT1revise(byte address)
        {
            return DataInfo.ModbusGetData(address, 3,18,19);
        }
        //获取二次供温度修正
        public static byte[] Get_GT2revise(byte address)
        {
            return DataInfo.ModbusGetData(address, 3,25, 26);
        }
        //获取二次回温度修正
        public static byte[] Get_BT2revise(byte address)
        {
            return DataInfo.ModbusGetData(address, 3, 32, 33);
        }
        #endregion
        //设置命令生成区域
        #region Set 
       
        //设置类型 
        public static byte[] Set_valvecontrol(byte address, xd100x.valvecontrol vc)
        {
            int[] buffer = { vc._control };
            return DataInfo.ModbusSetData(address, 0x10, 114, buffer);
        }
        //设置二次供温
        public static byte[] Set_valvevalue(byte address, xd100x.valvevalue vv)
        {
            int[] buffer = { Convert.ToInt16(vv._value * 10) };
            return DataInfo.ModbusSetData(address, 0x10, 116, buffer);
        }
        //设置调节阀温度曲线
        public static byte[] Set_valveline(byte address, xd100x.valveline vl)
        {
            int[] buffer = { vl._ov1, vl._gv1, vl._ov2, vl._gv2, vl._ov3, vl._gv3, vl._ov4, vl._gv4, vl._ov5, vl._gv5, vl._ov6, vl._gv6, vl._ov7, vl._gv7, vl._ov8, vl._gv8 };
            return DataInfo.ModbusSetData(address, 0x10, 117, buffer);
        }
        //设置调节阀分时调整
        public static byte[] Set_valvetime(byte address, xd100x.valvetime vt)
        {
            int[] buffer = { Convert.ToInt16(vt._v1 * 10), Convert.ToInt16(vt._v2 * 10), Convert.ToInt16(vt._v3 * 10), Convert.ToInt16(vt._v4 * 10), Convert.ToInt16(vt._v5 * 10), Convert.ToInt16(vt._v6 * 10), Convert.ToInt16(vt._v7 * 10), Convert.ToInt16(vt._v8 * 10), Convert.ToInt16(vt._v9 * 10), Convert.ToInt16(vt._v10 * 10), Convert.ToInt16(vt._v11 * 10), Convert.ToInt16(vt._v12 * 10) };
            return DataInfo.ModbusSetData(address, 0x10, 133, buffer);
        }
        //设置调节阀开度上下限
        public static byte[] Set_valvemm(byte address, xd100x.valvemm vm)
        {
            int[] buffer = { vm._min, vm._max };
            return DataInfo.ModbusSetData(address, 0x10, 145, buffer);
        }
        //设置调节阀流量限定
        public static byte[] Set_valvelimit(byte address, xd100x.valvelimit vl)
        {
            int[] buffer = { vl._enable, vl._limit };
            return DataInfo.ModbusSetData(address, 0x10, 153, buffer);
        }
        //设置报警设置压力
        public static byte[] Set_alarmp(byte address, xd100x.alarmp ap)
        {
            int[] buffer = { Convert.ToInt16(ap._yicigdiya * 100), Convert.ToInt16(ap._erciggaoya * 100),Convert.ToInt16(ap._ercihgaoya * 100), Convert.ToInt16(ap._ercihdiya * 100)};
            return DataInfo.ModbusSetData(address, 0x10, 198, buffer);
        }
        //设置报警设置温度液位
        public static byte[] Set_alarmt(byte address, xd100x.alarmt at)
        {
            int[] buffer = { at._yicigdiwen, at._erciggaowen, Convert.ToInt16(at._waterlow * 100), Convert.ToInt16(at._waterhight * 100) };
            return DataInfo.ModbusSetData(address, 0x10, 202, buffer);
        }
        //设置室外温度设置
        public static byte[] Set_outmode(byte address, xd100x.outmode om)
        {
            int[] buffer = { om._outmode };
            return DataInfo.ModbusSetData(address, 0x10, 206, buffer);
        }
        //设置室外温度值
        public static byte[] Set_outtemp(byte address, xd100x.outtemp ot)
        {
            int[] buffer = { Convert.ToInt16(ot._outtemp * 10) };
            return DataInfo.ModbusSetData(address, 0x10, 207, buffer);
        }
        //循环泵急停
        public static byte[] Set_cycpumpstop(byte address)
        {
            byte[] buffer = { address, 0x0F, 0x00, 0x05, 0x00, 0x01, 0x01, 0x01, 0x00, 0x00 };
            return DataInfo.CRC16(buffer);
        }
        //补水泵急停
        public static byte[] Set_addpumpstop(byte address)
        {
            byte[] buffer = { address, 0x0F, 0x00, 0x07, 0x00, 0x01, 0x01, 0x01, 0x00, 0x00 };
            return DataInfo.CRC16(buffer);
        }
        //循环泵启动
        public static byte[] Set_cycpumprun(byte address)
        {
            byte[] buffer = { address, 0x0F, 0x00, 0x04, 0x00, 0x01, 0x01, 0x01, 0x00, 0x00 };
            return DataInfo.CRC16(buffer);
        }
        //补水泵启动
        public static byte[] Set_addpumprun(byte address)
        {
            byte[] buffer = { address, 0x0F, 0x00, 0x06, 0x00, 0x01, 0x01, 0x01, 0x00, 0x00 };
            return DataInfo.CRC16(buffer);
        }
        //设置压差曲线
        public static byte[] Set_cycpumpline(byte address, xd100x.cycpumpline cl)
        {
            int[] buffer = { cl._ov1, Convert.ToInt16(cl._pv1*100), 
                       cl._ov2, Convert.ToInt16(cl._pv2*100), 
                       cl._ov3, Convert.ToInt16(cl._pv3*100), 
                       cl._ov4, Convert.ToInt16(cl._pv4*100), 
                       cl._ov5, Convert.ToInt16(cl._pv5*100), 
                       cl._ov6, Convert.ToInt16(cl._pv6*100), 
                       cl._ov7, Convert.ToInt16(cl._pv7*100), 
                       cl._ov8, Convert.ToInt16(cl._pv8*100) };
            return DataInfo.ModbusSetData(address, 0x10, 161, buffer);
        }
        //设置压差设定
        public static byte[] Set_cycpumpvalue(byte address, xd100x.cycpumpvalue cv)
        {
            int[] buffer = { Convert.ToInt16(cv._pressure * 100) };
            return DataInfo.ModbusSetData(address, 0x10, 159, buffer);
        }
        //设置补水泵模式及设定
        public static byte[] Set_addpumpvalue(byte address, xd100x.addpumpvalue av)
        {
            int[] buffer = { av._type, Convert.ToInt16(av._pressure * 100) };
            return DataInfo.ModbusSetData(address, 0x10, 183, buffer);
        }
        //设置上下限压力
        public static byte[] Set_addpumpmm(byte address, xd100x.addpumpmm amm)
        {
            int[] buffer = { Convert.ToInt16(amm._presshight * 100), 
                           Convert.ToInt16(amm._presslow*100), 
                           Convert.ToInt16(amm._levelhight*100), 
                           Convert.ToInt16(amm._levellow*100) };
            return DataInfo.ModbusSetData(address, 0x10, 189, buffer);
        }
        //设置室外温度修正
        public static byte[] Set_outrevise(byte address, xd100x.temprevise or)
        {
            int[] buffer = { Convert.ToInt16(or._k * 1000), Convert.ToInt16(or._b * 10) };
            return DataInfo.ModbusSetData(address, 0x10, 4, buffer);
        }
        //设置一次供温度修正
        public static byte[] Set_GT1revise(byte address, xd100x.temprevise or)
        {
            int[] buffer = { Convert.ToInt16(or._k * 1000), Convert.ToInt16(or._b * 10) };
            return DataInfo.ModbusSetData(address, 0x10, 11, buffer);
        }
        //设置一次回温度修正
        public static byte[] Set_BT1revise(byte address, xd100x.temprevise or)
        {
            int[] buffer = { Convert.ToInt16(or._k * 1000), Convert.ToInt16(or._b * 10) };
            return DataInfo.ModbusSetData(address, 0x10, 18, buffer);
        }
        //设置二次供温度修正
        public static byte[] Set_GT2revise(byte address, xd100x.temprevise or)
        {
            int[] buffer = { Convert.ToInt16(or._k * 1000), Convert.ToInt16(or._b * 10) };
            return DataInfo.ModbusSetData(address, 0x10, 25, buffer);
        }
        //设置二次回温度修正
        public static byte[] Set_BT2revise(byte address, xd100x.temprevise or)
        {
            int[] buffer = { Convert.ToInt16(or._k * 1000), Convert.ToInt16(or._b * 10) };
            return DataInfo.ModbusSetData(address, 0x10, 32, buffer);
        }
        #endregion
        #endregion

        //数据解析区域
        #region Read
        //解析实时数据
        public static xd100x.Data Read_ai(byte[] inByte)
        {
            xd100x.Data _rdata = new xd100x.Data();
            _rdata._dt = DateTime.Now;
            _rdata._OT = (float)Math.Round(DataInfo.GetLongValue2(inByte, 15) / 10.0, 1);
            _rdata._GT1 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 17) / 10.0, 1);
            _rdata._BT1 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 19) / 10.0, 1);
            _rdata._GT2 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 21) / 10.0, 1);
            _rdata._BT2 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 23) / 10.0, 1);

            _rdata._GP1 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 25) / 1000.0, 2);
            _rdata._BP1 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 27) / 1000.0, 2);
            _rdata._GP2 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 29) / 1000.0, 2);
            _rdata._BP2 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 31) / 1000.0, 2);

            _rdata._OD = (float)Math.Round(DataInfo.GetLongValue2(inByte, 33) / 10.0, 1);
            _rdata._WL = (float)Math.Round(DataInfo.GetLongValue2(inByte, 35) / 100.0, 1);

            _rdata._WI1 = (float)Math.Round(DataInfo.GetFloatValue2(inByte, 37), 1);
            _rdata._WS1 = DataInfo.GetULongValue2(inByte, 41);

            _rdata._HS1 = (float)Math.Round(DataInfo.GetFloatValue2(inByte, 45), 1);
            _rdata._HI1 = DataInfo.GetULongValue2(inByte, 49) / 10d;

            _rdata._WI2 = (float)Math.Round(DataInfo.GetFloatValue2(inByte, 65), 1);
            _rdata._WS2 = DataInfo.GetULongValue2(inByte, 69);

            _rdata._HS2 = (float)Math.Round(DataInfo.GetFloatValue2(inByte, 73), 1);
            _rdata._HI2 = DataInfo.GetULongValue2(inByte, 77) / 10d;

            _rdata._WI3 = (float)Math.Round(DataInfo.GetFloatValue2(inByte, 53), 1);
            _rdata._WS3 = DataInfo.GetULongValue2(inByte, 57);

            byte statebyte = DataInfo.GetByteValue(inByte, 86);
            xd100x.PumpState grPumpState = PumpParse(statebyte);
            _rdata._pump = grPumpState;
            byte[] warnbyte = new byte[2];
            warnbyte[1] = DataInfo.GetByteValue(inByte, 88);
            warnbyte[0] = DataInfo.GetByteValue(inByte, 87);
            xd100x.AlarmState grAlarmData = AlarmParse(warnbyte);
            _rdata._alarm = grAlarmData;

            _rdata._GTB2 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 97) / 10.0, 1);
            _rdata._PA2 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 99) / 100.0, 2);
            _rdata._BPB2 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 101) / 100.0, 2);
            return _rdata;
        }      
        //解析设置类型
        public static xd100x.valvecontrol Read_valvecontrol(byte[] inByte)
        {
            xd100x.valvecontrol vc = new xd100x.valvecontrol();
            vc._control = DataInfo.GetLongValue2(inByte, 3);
            return vc;
        }
        //解析设定值
        public static xd100x.valvevalue Read_valvevalue(byte[] inByte)
        {
            xd100x.valvevalue vv = new xd100x.valvevalue();
            vv._value = (float)Math.Round(DataInfo.GetLongValue2(inByte, 3) / 10.0, 1);
            return vv;
        }
        //解析曲线
        public static xd100x.valveline Read_valveline(byte[] inByte)
        {
            xd100x.valveline vl = new xd100x.valveline();
            vl._ov1 = DataInfo.GetLongValue2(inByte, 3);
            vl._gv1 = DataInfo.GetLongValue2(inByte, 5);
            vl._ov2 = DataInfo.GetLongValue2(inByte, 7);
            vl._gv2 = DataInfo.GetLongValue2(inByte, 9);
            vl._ov3 = DataInfo.GetLongValue2(inByte, 11);
            vl._gv3 = DataInfo.GetLongValue2(inByte, 13);
            vl._ov4 = DataInfo.GetLongValue2(inByte, 15);
            vl._gv4 = DataInfo.GetLongValue2(inByte, 17);
            vl._ov5 = DataInfo.GetLongValue2(inByte, 19);
            vl._gv5 = DataInfo.GetLongValue2(inByte, 21);
            vl._ov6 = DataInfo.GetLongValue2(inByte, 23);
            vl._gv6 = DataInfo.GetLongValue2(inByte, 25);
            vl._ov7 = DataInfo.GetLongValue2(inByte, 27);
            vl._gv7 = DataInfo.GetLongValue2(inByte, 29);
            vl._ov8 = DataInfo.GetLongValue2(inByte, 31);
            vl._gv8 = DataInfo.GetLongValue2(inByte, 33);
            return vl;
        }
        //解析分时调整
        public static xd100x.valvetime Read_valvetime(byte[] inByte)
        {
            xd100x.valvetime vt = new xd100x.valvetime();
            vt._v1 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 3)/ 10.0, 1);
            vt._v2 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 5)/ 10.0, 1);
            vt._v3 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 7)/ 10.0, 1);
            vt._v4 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 9)/ 10.0, 1);
            vt._v5 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 11)/ 10.0, 1);
            vt._v6 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 13)/ 10.0, 1);
            vt._v7 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 15)/ 10.0, 1);
            vt._v8 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 17)/ 10.0, 1);
            vt._v9 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 19)/ 10.0, 1);
            vt._v10 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 21)/ 10.0, 1);
            vt._v11 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 23)/ 10.0, 1);
            vt._v12 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 25) / 10.0, 1);
            return vt;
        }
        //解析开度上下限
        public static xd100x.valvemm Read_valvemm(byte[] inByte)
        {
            xd100x.valvemm vmm = new xd100x.valvemm();
            vmm._min = DataInfo.GetLongValue2(inByte, 3);
            vmm._max = DataInfo.GetLongValue2(inByte, 5);
            return vmm;
        }
        //解析流量限定
        public static xd100x.valvelimit Read_valvelimit(byte[] inByte)
        {
            xd100x.valvelimit vl = new xd100x.valvelimit();
            vl._enable = DataInfo.GetLongValue2(inByte, 3);
            vl._limit = DataInfo.GetLongValue2(inByte, 5);
            return vl;
        }
        //解析报警设置
        public static xd100x.alarmp Read_alarmp(byte[] inByte)
        {
            xd100x.alarmp ap = new xd100x.alarmp();
            ap._yicigdiya = (float)Math.Round(DataInfo.GetLongValue2(inByte, 3) / 100.0, 2);
            ap._erciggaoya = (float)Math.Round(DataInfo.GetLongValue2(inByte, 5) / 100.0, 2);
            ap._ercihgaoya=(float)Math.Round(DataInfo.GetLongValue2(inByte, 7) / 100.0, 2);
            ap._ercihdiya=(float)Math.Round(DataInfo.GetLongValue2(inByte, 9) / 100.0, 2);
            return ap;
        }
        //解析报警设置
        public static xd100x.alarmt Read_alarmt(byte[] inByte)
        {
            xd100x.alarmt at = new xd100x.alarmt();
            at._yicigdiwen = DataInfo.GetLongValue2(inByte, 3);
            at._erciggaowen = DataInfo.GetLongValue2(inByte, 5);
            at._waterlow = (float)Math.Round(DataInfo.GetLongValue2(inByte, 7) / 100.0, 2);
            at._waterhight = (float)Math.Round(DataInfo.GetLongValue2(inByte, 9) / 100.0, 2);
            return at;
        }
        //解析室外温度设置
        public static xd100x.outmode Read_outmode(byte[] inByte)
        {
            xd100x.outmode om = new xd100x.outmode();
            om._outmode = DataInfo.GetLongValue2(inByte, 3);
            return om;
        }
        //解析室外温度值
        //public static outtemp Read_outtemp(byte[] inByte)
        //{
        //    outtemp ot = new outtemp();
        //    ot._outtemp = (float)Math.Round(DataInfo.GetLongValue2(inByte, 5) / 10.0, 1);
        //    return ot;
        //}
        //位寄存器解析泵状态
        public static xd100x.PumpState Get_pumpstate(byte[] inByte)
        {
            byte pumpbyte = inByte[3];
            return PumpParse(pumpbyte);
        }
        //位寄存器解析报警
        public static xd100x.AlarmState Get_alarmstate(byte[] inByte)
        { 
            byte[] alarmbyte = {inByte[5],inByte[6]};
            return AlarmParse(alarmbyte);
        }
        //报警解析
        public static xd100x.AlarmState AlarmParse(byte[] alarm)
        {
            xd100x.AlarmState gral = new xd100x.AlarmState();
            if (alarm[0] != 0x00 || alarm[1] != 0x00)
            {
                gral._all = xd100x.GRAlarm.有;
            }
            else
            {
                gral._all = xd100x.GRAlarm.无;
            }
            gral._yicigongdiya = DataInfo.GetAlarmData(alarm[1], 0);
            gral._ercigonggaoya = DataInfo.GetAlarmData(alarm[1], 1);
            gral._ercihuigaoya = DataInfo.GetAlarmData(alarm[1], 2);
            gral._ercihuidiya = DataInfo.GetAlarmData(alarm[1], 3);
            gral._yicigongdiwen = DataInfo.GetAlarmData(alarm[1], 4);
            gral._ercigonggaowen = DataInfo.GetAlarmData(alarm[1], 5);
            gral._shuiweigao = DataInfo.GetAlarmData(alarm[1], 6);
            gral._shuiweidi = DataInfo.GetAlarmData(alarm[1], 7);

            gral._xunhuanbeng1 = DataInfo.GetAlarmData(alarm[0], 0);
            gral._xunhuanbeng2 = DataInfo.GetAlarmData(alarm[0], 1);
            gral._xunhuanbeng3 = DataInfo.GetAlarmData(alarm[0], 2);
            gral._bushuibeng1 = DataInfo.GetAlarmData(alarm[0], 3);
            gral._bushuibeng2 = DataInfo.GetAlarmData(alarm[0], 4);
            gral._kaiguangao = DataInfo.GetAlarmData(alarm[0], 5);
            gral._kaiguandi = DataInfo.GetAlarmData(alarm[0], 6);
            gral._diaodian = DataInfo.GetAlarmData(alarm[0], 7);
            gral._word = alarm[0] * 256 + alarm[1];
            return gral;
        }
        //泵状态解析
        public static xd100x.PumpState PumpParse(byte state)
        {
            xd100x.PumpState grPs = new xd100x.PumpState();
            grPs._CM1 = DataInfo.GetPumpState(state, 0);
            grPs._CM2 = DataInfo.GetPumpState(state, 1);
            grPs._CM3 = DataInfo.GetPumpState(state, 2);
            grPs._RM1 = DataInfo.GetPumpState(state, 3);
            grPs._RM2 = DataInfo.GetPumpState(state, 4);
            return grPs;
        }
        //解析压差曲线
        public static xd100x.cycpumpline Read_cycpumpline(byte[] inByte)
        {
            xd100x.cycpumpline cl = new xd100x.cycpumpline();
            cl._ov1 = Convert.ToInt32(DataInfo.GetLongValue2(inByte, 3));
            cl._pv1 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 5) / 100.0, 2);
            cl._ov2 = Convert.ToInt32(DataInfo.GetLongValue2(inByte, 7));
            cl._pv2 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 9) / 100.0, 2);
            cl._ov3 = Convert.ToInt32(DataInfo.GetLongValue2(inByte, 11));
            cl._pv3 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 13) / 100.0, 2);
            cl._ov4 = Convert.ToInt32(DataInfo.GetLongValue2(inByte, 15));
            cl._pv4 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 17) / 100.0, 2);
            cl._ov5 = Convert.ToInt32(DataInfo.GetLongValue2(inByte, 19));
            cl._pv5 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 21) / 100.0, 2);
            cl._ov6 = Convert.ToInt32(DataInfo.GetLongValue2(inByte, 23));
            cl._pv6 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 25) / 100.0, 2);
            cl._ov7 = Convert.ToInt32(DataInfo.GetLongValue2(inByte, 27));
            cl._pv7 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 29) / 100.0, 2);
            cl._ov8 = Convert.ToInt32(DataInfo.GetLongValue2(inByte, 31));
            cl._pv8 = (float)Math.Round(DataInfo.GetLongValue2(inByte, 33) / 100.0, 2);
            return cl;
        }
        //解析压差设定
        public static xd100x.cycpumpvalue Read_cycpumpvalue(byte[] inByte)
        {
            xd100x.cycpumpvalue cv = new xd100x.cycpumpvalue();
            cv._pressure = (float)Math.Round(DataInfo.GetLongValue2(inByte, 3) / 100.0, 2); ;
            return cv;
        }
        //解析补水泵模式及设定压力
        public static xd100x.addpumpvalue Read_addpumpvalue(byte[] inByte)
        {
            xd100x.addpumpvalue av = new xd100x.addpumpvalue();
            av._type = Convert.ToInt16(DataInfo.GetLongValue2(inByte, 3));
            av._pressure = (float)Math.Round(DataInfo.GetLongValue2(inByte, 5) / 100.0, 2); ;
            return av;
        }
        //解析补水泵压力上下限和水箱水位上下限
        public static xd100x.addpumpmm Read_addpumpmm(byte[] inByte)
        {
            xd100x.addpumpmm amm = new xd100x.addpumpmm();
            amm._presshight = (float)Math.Round(DataInfo.GetLongValue2(inByte, 3) / 100.0, 2);
            amm._presslow = (float)Math.Round(DataInfo.GetLongValue2(inByte, 5) / 100.0, 2);
            amm._levelhight = (float)Math.Round(DataInfo.GetLongValue2(inByte, 7) / 100.0, 2);
            amm._levellow = (float)Math.Round(DataInfo.GetLongValue2(inByte, 9) / 100.0, 2);
            return amm;
        }
        //解析室外温度修正
        public static xd100x.temprevise Read_temprevise(byte[] inByte)
        {
            xd100x.temprevise or = new xd100x.temprevise();
            or._k = (float)Math.Round(DataInfo.GetLongValue2(inByte, 3) / 1000.0, 3);
            or._b = (float)Math.Round(DataInfo.GetLongValue2(inByte, 5) / 10.0, 1);
            return or;
        }
        #endregion

        //数据处理逻辑
        #region
        //xd100n数据处理
        public static void Deal_XD100nData(byte[] inbyte, string ip)
        {
            //检测是否为xd100n数据
            //判断依据  1、CRC 2、ip 3、器件地址
            if (false == DataInfo.CheckCRC(inbyte))
            {
                return;
            }
            int busfferlistID = -1;
            for (int i = 0; i < xd100x._XD100xBuffer.Length; i++)
            {
                if (xd100x._XD100xBuffer[i]._Info._ip == ip && xd100x._XD100xBuffer[i]._Info._addr == inbyte[0])
                {
                    busfferlistID = i;
                    break;
                }
            }

            if (busfferlistID == -1)
            {
                return;
            }
            if (xd100x._XD100xBuffer[busfferlistID]._Info._version != "xd100n")
            {
                return;
            }

            //实时数据模拟量 功能码0x04
            if (inbyte[1] == 0x04 && inbyte[2] == 0x64)
            {
                xd100x._XD100xBuffer[busfferlistID]._Data = Read_ai(inbyte);
                xd100x._XD100xBuffer[busfferlistID]._SaveDatas = true;
            }

            //实时数据数字量 功能码0x02
            //if (inbyte[1] == 0x02 && inbyte[2] == 0x04)
            //{
            //    xd100x._XD100xBuffer[busfferlistID]._Data._alarm = Get_alarmstate(inbyte);
            //    xd100x._XD100xBuffer[busfferlistID]._Data._pump = Get_pumpstate(inbyte);
            //    xd100x._XD100xBuffer[busfferlistID]._SaveDatas = true;
            //}

            //03可读返回
            if (inbyte[1] == 0x03)
            {
                //控制方法114
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 1)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._valvecontrol = Read_valvecontrol(inbyte);
                }
                //设定值116
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 2)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._valvevalue = Read_valvevalue(inbyte);
                }
                //曲线117
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 3)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._valveline = Read_valveline(inbyte);
                }
                //分时调整133
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 4)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._valvetime = Read_valvetime(inbyte);
                }
                //开度最大最小值145
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 5)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._valvemm = Read_valvemm(inbyte);
                }
                //流量限定153
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 6)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._valvelimit = Read_valvelimit(inbyte);
                }              
                //压差曲线
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 7)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._cycpumpline = Read_cycpumpline(inbyte);
                }
                //压差设定
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 8)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._cycpumpvalue = Read_cycpumpvalue(inbyte);
                }
                //补水压力模式
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 9)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._addpumpvalue = Read_addpumpvalue(inbyte);
                }
                //补水上下限水位上下限
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 10)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._addpumpmm = Read_addpumpmm(inbyte);
                }
                //报警198
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 11)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._alarmp = Read_alarmp(inbyte);
                }
                //报警202
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 12)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._alarmt = Read_alarmt(inbyte);
                }
                //室外温度206
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 13)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._outmode = Read_outmode(inbyte);
                }
                //室外温度修正4
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 32)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._outrevise = Read_temprevise(inbyte);
                    xd100x._XD100xBuffer[busfferlistID]._Set._outrevise._temp = xd100x._XD100xBuffer[busfferlistID]._Data._OT;
                }
                //一次供温温度修正11
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 33)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._GT1revise = Read_temprevise(inbyte);
                    xd100x._XD100xBuffer[busfferlistID]._Set._GT1revise._temp = xd100x._XD100xBuffer[busfferlistID]._Data._GT1;
                }
                //一次回温温度修正18
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 34)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._BT1revise = Read_temprevise(inbyte);
                    xd100x._XD100xBuffer[busfferlistID]._Set._BT1revise._temp = xd100x._XD100xBuffer[busfferlistID]._Data._BT1;
                }
                //二次供温温度修正25
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 35)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._GT2revise = Read_temprevise(inbyte);
                    xd100x._XD100xBuffer[busfferlistID]._Set._GT2revise._temp = xd100x._XD100xBuffer[busfferlistID]._Data._GT2;
                }
                //二次回温温度修正32
                if (xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex == 36)
                {
                    xd100x._XD100xBuffer[busfferlistID]._Set._BT2revise = Read_temprevise(inbyte);
                    xd100x._XD100xBuffer[busfferlistID]._Set._BT2revise._temp = xd100x._XD100xBuffer[busfferlistID]._Data._BT2;
                }
            }
            //10写返回
            if (inbyte[1] == 0x10)
            {
                
            }
            //急停返回
            if (inbyte[1] == 0x0F)
            {

            }
            xd100x._XD100xBuffer[busfferlistID]._Command[xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex]._onoff = false;
            xd100x._XD100xBuffer[busfferlistID]._Command[xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex]._retrytimesnow = 0;
            xd100x._XD100xBuffer[busfferlistID]._Command[xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex]._backdt = DateTime.Now;
            xd100x._XD100xBuffer[busfferlistID]._Command[xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex]._back = true;
            xd100x._XD100xBuffer[busfferlistID]._Command[xd100x._XD100xBuffer[busfferlistID]._LastCommandIndex]._send = false;
            xd100x._XD100xBuffer[busfferlistID]._Info._state = true;
            //只要有数据返回即解除ISocketRS占用
            Gprs.Gprs_IsOccupy(xd100x._XD100xBuffer[busfferlistID]._Info._ip, false);
        }
        #endregion

    }
}