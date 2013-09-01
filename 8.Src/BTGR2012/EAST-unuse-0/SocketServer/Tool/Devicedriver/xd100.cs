using System;

namespace Tool
{
    public class xd100
    {
        //加载命令
        #region
        //加载命令
        public static void load_xd100cmd(int listID,xd100x.Set _Set)
        {
            xd100x._XD100xBuffer[listID]._Command = new xd100x.Command[43];
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

            xd100x._XD100xBuffer[listID]._Command[14]._cmd = Set_valvecontrol(addr, _Set._valvecontrol,_Set._valvevalue);
            xd100x._XD100xBuffer[listID]._Command[15]._cmd = Set_valvevalue(addr,_Set._valvecontrol,_Set._valvevalue);
            xd100x._XD100xBuffer[listID]._Command[16]._cmd = Set_valveline(addr,_Set._valveline);
            xd100x._XD100xBuffer[listID]._Command[17]._cmd = Set_valvetime(addr,_Set._valvetime);
            xd100x._XD100xBuffer[listID]._Command[18]._cmd = Set_valvemm(addr,_Set._valvemm);
            xd100x._XD100xBuffer[listID]._Command[19]._cmd = Set_valvelimit(addr,_Set._valvelimit);
            xd100x._XD100xBuffer[listID]._Command[20]._cmd = Set_cycpumpline(addr,_Set._cycpumpline);
            xd100x._XD100xBuffer[listID]._Command[21]._cmd = Set_cycpumpvalue(addr,_Set._cycpumpvalue);
            xd100x._XD100xBuffer[listID]._Command[22]._cmd = Set_addpumpvalue(addr,_Set._addpumpvalue);
            xd100x._XD100xBuffer[listID]._Command[23]._cmd = Set_addpumpmm(addr,_Set._addpumpmm);

            xd100x._XD100xBuffer[listID]._Command[24]._cmd = Set_alarmp(addr,_Set._alarmp);
            xd100x._XD100xBuffer[listID]._Command[25]._cmd = Set_alarmt(addr,_Set._alarmt);
            xd100x._XD100xBuffer[listID]._Command[26]._cmd = Set_outmode(addr,_Set._outmode);
            xd100x._XD100xBuffer[listID]._Command[27]._cmd = Set_outtemp(addr,_Set._outtemp);

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

            xd100x._XD100xBuffer[listID]._Command[42]._cmd = Set_datetime(addr);

            for (int i = 0; i < xd100x._XD100xBuffer[listID]._Command.Length; i++)
            {
                xd100x._XD100xBuffer[listID]._Command[i]._back = false;
                Tool.xd100x._XD100xBuffer[listID]._Command[i]._backdt = DateTime.Now.AddYears(-1);
            }
        }

        #endregion

        //数据处理方法
        #region
        //读取命令生成区域
        #region Get

        //获取当前数据
        public static byte[] Get_ai(byte address)
        {
            return DataInfo.xd100GetData(address, 30);
        }
        //获取调节阀控制模式
        public static byte[] Get_valvecontrol(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 71);
        }
        //获取调节阀设定值
        public static byte[] Get_valvevalue(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 71);
        }
        //获取调节阀温度曲线
        public static byte[] Get_valveline(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 72);
        }
        //获取调节阀分时调整
        public static byte[] Get_valvetime(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 72);
        }
        //获取调节阀开度上下限
        public static byte[] Get_valvemm(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 73);
        }
        //获取调节阀流量限定
        public static byte[] Get_valvelimit(byte address)
        {
            return null;
        }
        //获取压差曲线
        public static byte[] Get_cycpumpline(byte address)
        {
            return DataInfo.xd100GetData(address, 0x3e);
        }
        //获取循环泵压差设定
        public static byte[] Get_cycpumpvalue(byte address)
        {
            return DataInfo.xd100GetData(address, 0x40, 0x4b);
        }
        //获取补水泵压力设定
        public static byte[] Get_addpumpvalue(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 77);
        }
        //获取补水压力上下限 水箱水位上下限
        public static byte[] Get_addpumpmm(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 79);
        }
        //获取报警设置压力
        public static byte[] Get_alarmp(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 81);
        }
        //获取报警设置温度液位
        public static byte[] Get_alarmt(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 82);
        }
        //获取室外温度模式
        public static byte[] Get_outmode(byte address)
        {
            return DataInfo.xd100GetData(address, 40);
        }
        //获取室外温度值
        //public static byte[] Get_outtemp(byte address)
        //{
        //    return DataInfo.xd100GetData(address, 41);
        //}
        //获取室外温度修正
        public static byte[] Get_outrevise(byte address)
        {
            return DataInfo.xd100GetData(address, 20,31);
        }
        //获取一次供温温度修正
        public static byte[] Get_GT1revise(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 32);
        }
        //获取一次回温度修正
        public static byte[] Get_BT1revise(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 33);
        }
        //获取二次供温度修正
        public static byte[] Get_GT2revise(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 34);
        }
        //获取二次回温度修正
        public static byte[] Get_BT2revise(byte address)
        {
            return DataInfo.xd100GetData(address, 20, 35);
        }
        #endregion

        //设置命令生成区域
        #region Set
        //设置调节阀模式
        public static byte[] Set_valvecontrol(byte address, xd100x.valvecontrol control, xd100x.valvevalue value)
        {
            byte[] t1 = BitConverter.GetBytes(value._value);
            byte[] t2 = BitConverter.GetBytes(0f);
            byte[] buffer = { 0x47, Convert.ToByte(control._control), t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置调节阀设定值
        public static byte[] Set_valvevalue(byte address, xd100x.valvecontrol control, xd100x.valvevalue value)
        {
            byte[] t1 = BitConverter.GetBytes(value._value);
            byte[] t2 = BitConverter.GetBytes(0f);
            byte[] buffer = { 0x47, Convert.ToByte(control._control), t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置调节阀温度曲线
        public static byte[] Set_valveline(byte address, xd100x.valveline vl)
        {
            byte[] buffer = { (byte)Convert.ToSByte(vl._ov1),(byte)Convert.ToSByte(vl._gv1), 
                                (byte)Convert.ToSByte(vl._ov2), (byte)Convert.ToSByte(vl._gv2), 
                                (byte)Convert.ToSByte(vl._ov3), (byte)Convert.ToSByte(vl._gv3), 
                                (byte)Convert.ToSByte(vl._ov4), (byte)Convert.ToSByte(vl._gv4), 
                                (byte)Convert.ToSByte(vl._ov5), (byte)Convert.ToSByte(vl._gv5), 
                                (byte)Convert.ToSByte(vl._ov6), (byte)Convert.ToSByte(vl._gv6), 
                                (byte)Convert.ToSByte(vl._ov7), (byte)Convert.ToSByte(vl._gv7), 
                                (byte)Convert.ToSByte(vl._ov8), (byte)Convert.ToSByte(vl._gv8) };
            return DataInfo.SetData(address, 0x3c, buffer);
        }
        //设置调节阀分时调整
        public static byte[] Set_valvetime(byte address, xd100x.valvetime vt)
        {
            byte[] buffer = { (byte)Convert.ToSByte(vt._v1), (byte)Convert.ToSByte(vt._v2), 
                                (byte)Convert.ToSByte(vt._v3), (byte)Convert.ToSByte(vt._v4), 
                                (byte)Convert.ToSByte(vt._v5), (byte)Convert.ToSByte(vt._v6), 
                                (byte)Convert.ToSByte(vt._v7), (byte)Convert.ToSByte(vt._v8), 
                                (byte)Convert.ToSByte(vt._v9), (byte)Convert.ToSByte(vt._v10), 
                                (byte)Convert.ToSByte(vt._v11), (byte)Convert.ToSByte(vt._v12) };
            return DataInfo.SetData(address, 0x3d, buffer);
        }
        //设置调节阀开度上下限
        public static byte[] Set_valvemm(byte address, xd100x.valvemm vm)
        {
            byte[] buffer = { 73, Convert.ToByte(vm._min), Convert.ToByte(vm._max), Convert.ToByte(vm._deatharea) };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置调节阀流量限定
        public static byte[] Set_valvelimit(byte address, xd100x.valvelimit vl)
        {
            byte[] buffer = { Convert.ToByte(vl._enable), Convert.ToByte(vl._limit) };
            return buffer;
        }
        //设置压差曲线
        public static byte[] Set_cycpumpline(byte address, xd100x.cycpumpline cl)
        {
            byte[] buffer = {  (byte)Convert.ToSByte(cl._ov1), (byte)Convert.ToSByte(cl._pv1*100), 
                                (byte)Convert.ToSByte(cl._ov2), (byte)Convert.ToSByte(cl._pv2*100), 
                                (byte)Convert.ToSByte(cl._ov3), (byte)Convert.ToSByte(cl._pv3*100), 
                                (byte)Convert.ToSByte(cl._ov4), (byte)Convert.ToSByte(cl._pv4*100), 
                                (byte)Convert.ToSByte(cl._ov5), (byte)Convert.ToSByte(cl._pv5*100), 
                                (byte)Convert.ToSByte(cl._ov6), (byte)Convert.ToSByte(cl._pv6*100), 
                                (byte)Convert.ToSByte(cl._ov7), (byte)Convert.ToSByte(cl._pv7*100), 
                                (byte)Convert.ToSByte(cl._ov8), (byte)Convert.ToSByte(cl._pv8*100)};
            return DataInfo.SetData(address, 0x3f, buffer);
        }
        //设置循环泵压差设定
        public static byte[] Set_cycpumpvalue(byte address, xd100x.cycpumpvalue cv)
        {
            byte[] t1 = BitConverter.GetBytes(cv._pressure);
            byte[] t2 = BitConverter.GetBytes(0f);
            byte[] buffer = { 0, t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3] };
            return DataInfo.SetData(address, 0x41, buffer);
        }
        //设置补水泵压力设定
        public static byte[] Set_addpumpvalue(byte address, xd100x.addpumpvalue av)
        {
            byte[] t1 = BitConverter.GetBytes(av._pressure);
            byte[] t2 = BitConverter.GetBytes(0f);
            byte[] buffer = { 77, Convert.ToByte(av._type), t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置补水压力上下限 水箱水位上下限
        public static byte[] Set_addpumpmm(byte address, xd100x.addpumpmm apmm)
        {
            byte[] t1 = BitConverter.GetBytes(apmm._presshight);
            byte[] t2 = BitConverter.GetBytes(apmm._presslow);
            byte[] t3 = BitConverter.GetBytes(apmm._levelhight);
            byte[] t4 = BitConverter.GetBytes(apmm._levellow);
            byte[] buffer = { 79, t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3], t3[0], t3[1], t3[2], t3[3], t4[0], t4[1], t4[2], t4[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置报警设置压力
        public static byte[] Set_alarmp(byte address, xd100x.alarmp ap)
        {
            byte[] t1 = BitConverter.GetBytes(ap._yicigdiya);
            byte[] t2 = BitConverter.GetBytes(ap._erciggaoya);
            byte[] t3 = BitConverter.GetBytes(ap._ercihgaoya);
            byte[] t4 = BitConverter.GetBytes(ap._ercihdiya);
            byte[] buffer = { 81, t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3], t3[0], t3[1], t3[2], t3[3], t4[0], t4[1], t4[2], t4[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置报警温度液位
        public static byte[] Set_alarmt(byte address, xd100x.alarmt at)
        {
            byte[] t1 = BitConverter.GetBytes(at._yicigdiwen);
            byte[] t2 = BitConverter.GetBytes(at._erciggaowen);
            byte[] t3 = BitConverter.GetBytes(at._waterlow);
            byte[] t4 = BitConverter.GetBytes(at._waterhight);
            byte[] buffer = { 82, t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3], t3[0], t3[1], t3[2], t3[3], t4[0], t4[1], t4[2], t4[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置室外温度设置
        public static byte[] Set_outmode(byte address, xd100x.outmode om)
        {
            byte[] buffer = { Convert.ToByte(om._outmode) };
            return DataInfo.SetData(address, 0x28, buffer);
        }
        //设置室外温度设置
        public static byte[] Set_outtemp(byte address, xd100x.outtemp ot)
        {
            byte[] t1 = BitConverter.GetBytes(ot._outtemp);
            byte[] buffer = { 0x1f, t1[0], t1[1], t1[2], t1[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //循环泵停
        public static byte[] Set_cycpumpstop(byte address)
        {
            return DataInfo.SetData(address, 0x34);
        }
        //补水泵停
        public static byte[] Set_addpumpstop(byte address)
        {
            return DataInfo.SetData(address, 0x32);
        }
        //循环泵启动
        public static byte[] Set_cycpumprun(byte address)
        {
            return DataInfo.SetData(address, 0x35);
        }
        //补水泵启动
        public static byte[] Set_addpumprun(byte address)
        {
            return DataInfo.SetData(address, 0x33);
        }
        //设置室外温度修正
        public static byte[] Set_outrevise(byte address,xd100x.temprevise or)
        {
            byte[] t1 = BitConverter.GetBytes(or._max);
            byte[] t2 = BitConverter.GetBytes(or._min);
            byte[] t3 = BitConverter.GetBytes(or._k);
            byte[] t4 = BitConverter.GetBytes(or._b);
            byte[] buffer = { 31,or._channel,or._type,or._unit, t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3], t3[0], t3[1], t3[2], t3[3], t4[0], t4[1], t4[2], t4[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置一次供温度修正
        public static byte[] Set_GT1revise(byte address, xd100x.temprevise or)
        {
            byte[] t1 = BitConverter.GetBytes(or._max);
            byte[] t2 = BitConverter.GetBytes(or._min);
            byte[] t3 = BitConverter.GetBytes(or._k);
            byte[] t4 = BitConverter.GetBytes(or._b);
            byte[] buffer = { 32, or._channel, or._type, or._unit, t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3], t3[0], t3[1], t3[2], t3[3], t4[0], t4[1], t4[2], t4[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置一次回温度修正
        public static byte[] Set_BT1revise(byte address, xd100x.temprevise or)
        {
            byte[] t1 = BitConverter.GetBytes(or._max);
            byte[] t2 = BitConverter.GetBytes(or._min);
            byte[] t3 = BitConverter.GetBytes(or._k);
            byte[] t4 = BitConverter.GetBytes(or._b);
            byte[] buffer = { 33, or._channel, or._type, or._unit, t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3], t3[0], t3[1], t3[2], t3[3], t4[0], t4[1], t4[2], t4[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置二次供温度修正
        public static byte[] Set_GT2revise(byte address, xd100x.temprevise or)
        {
            byte[] t1 = BitConverter.GetBytes(or._max);
            byte[] t2 = BitConverter.GetBytes(or._min);
            byte[] t3 = BitConverter.GetBytes(or._k);
            byte[] t4 = BitConverter.GetBytes(or._b);
            byte[] buffer = { 34, or._channel, or._type, or._unit, t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3], t3[0], t3[1], t3[2], t3[3], t4[0], t4[1], t4[2], t4[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置二次回温度修正
        public static byte[] Set_BT2revise(byte address, xd100x.temprevise or)
        {
            byte[] t1 = BitConverter.GetBytes(or._max);
            byte[] t2 = BitConverter.GetBytes(or._min);
            byte[] t3 = BitConverter.GetBytes(or._k);
            byte[] t4 = BitConverter.GetBytes(or._b);
            byte[] buffer = { 35, or._channel, or._type, or._unit, t1[0], t1[1], t1[2], t1[3], t2[0], t2[1], t2[2], t2[3], t3[0], t3[1], t3[2], t3[3], t4[0], t4[1], t4[2], t4[3] };
            return DataInfo.SetData(address, 21, buffer);
        }
        //设置事件
        public static byte[] Set_datetime(byte address)
        { 
            byte[] buffer ={};
            return buffer;
        }
        #endregion

        //数据解析区域
        #region Read
        //解析设置类型
        public static xd100x.valvecontrol Read_valvecontrol(byte[] inByte)
        {
            xd100x.valvecontrol vc = new xd100x.valvecontrol();
            vc._control = DataInfo.GetByteValue(inByte, 8);
            return vc;
        }
        //解析设置值
        public static xd100x.valvevalue Read_valvevalue(byte[] inByte)
        {
            xd100x.valvevalue vv = new xd100x.valvevalue();
            vv._value = DataInfo.GetFloatValue(inByte, 9);
            return vv;
        }
        //解析曲线
        public static xd100x.valveline Read_valveline(byte[] inByte)
        {
            xd100x.valveline vl = new xd100x.valveline();
            vl._ov1 = (sbyte)DataInfo.GetByteValue(inByte, 8);
            vl._gv1 = (sbyte)DataInfo.GetByteValue(inByte, 9);
            vl._ov2 = (sbyte)DataInfo.GetByteValue(inByte, 10);
            vl._gv2 = (sbyte)DataInfo.GetByteValue(inByte, 11);
            vl._ov3 = (sbyte)DataInfo.GetByteValue(inByte, 12);
            vl._gv3 = (sbyte)DataInfo.GetByteValue(inByte, 13);
            vl._ov4 = (sbyte)DataInfo.GetByteValue(inByte, 14);
            vl._gv4 = (sbyte)DataInfo.GetByteValue(inByte, 15);
            vl._ov5 = (sbyte)DataInfo.GetByteValue(inByte, 16);
            vl._gv5 = (sbyte)DataInfo.GetByteValue(inByte, 17);
            vl._ov6 = (sbyte)DataInfo.GetByteValue(inByte, 18);
            vl._gv6 = (sbyte)DataInfo.GetByteValue(inByte, 19);
            vl._ov7 = (sbyte)DataInfo.GetByteValue(inByte, 20);
            vl._gv7 = (sbyte)DataInfo.GetByteValue(inByte, 21);
            vl._ov8 = (sbyte)DataInfo.GetByteValue(inByte, 22);
            vl._gv8 = (sbyte)DataInfo.GetByteValue(inByte, 23);
            return vl;
        }
        //解析分时调整
        public static xd100x.valvetime Read_valvetime(byte[] inByte)
        {
            xd100x.valvetime vt = new xd100x.valvetime();
            vt._v1 = (sbyte)DataInfo.GetByteValue(inByte, 24);
            vt._v2 = (sbyte)DataInfo.GetByteValue(inByte, 25);
            vt._v3 = (sbyte)DataInfo.GetByteValue(inByte, 26);
            vt._v4 = (sbyte)DataInfo.GetByteValue(inByte, 27);
            vt._v5 = (sbyte)DataInfo.GetByteValue(inByte, 28);
            vt._v6 = (sbyte)DataInfo.GetByteValue(inByte, 29);
            vt._v7 = (sbyte)DataInfo.GetByteValue(inByte, 30);
            vt._v8 = (sbyte)DataInfo.GetByteValue(inByte, 31);
            vt._v9 = (sbyte)DataInfo.GetByteValue(inByte, 32);
            vt._v10 = (sbyte)DataInfo.GetByteValue(inByte, 33);
            vt._v11 = (sbyte)DataInfo.GetByteValue(inByte, 34);
            vt._v12 = (sbyte)DataInfo.GetByteValue(inByte, 35);
            return vt;
        }
        //解析开度上下限
        public static xd100x.valvemm Read_valvemm(byte[] inByte)
        {
            xd100x.valvemm vm = new xd100x.valvemm();
            vm._min = DataInfo.GetByteValue(inByte, 8);
            vm._max = DataInfo.GetByteValue(inByte, 9);
            vm._deatharea = DataInfo.GetByteValue(inByte, 10);
            return vm;
        }
        //解析压差曲线
        public static xd100x.cycpumpline Read_cycpumpline(byte[] inByte)
        {
            xd100x.cycpumpline cl = new xd100x.cycpumpline();
            cl._ov1 = (sbyte)DataInfo.GetByteValue(inByte, 7);
            cl._pv1 = ((sbyte)DataInfo.GetByteValue(inByte, 8))/100f;
            cl._ov2 = (sbyte)DataInfo.GetByteValue(inByte, 9);
            cl._pv2 = ((sbyte)DataInfo.GetByteValue(inByte, 10))/100f;
            cl._ov3 = (sbyte)DataInfo.GetByteValue(inByte, 11);
            cl._pv3 = ((sbyte)DataInfo.GetByteValue(inByte, 12))/100f;
            cl._ov4 = (sbyte)DataInfo.GetByteValue(inByte, 13);
            cl._pv4 = ((sbyte)DataInfo.GetByteValue(inByte, 14))/100f;
            cl._ov5 = (sbyte)DataInfo.GetByteValue(inByte, 15);
            cl._pv5 = ((sbyte)DataInfo.GetByteValue(inByte, 16))/100f;
            cl._ov6 = (sbyte)DataInfo.GetByteValue(inByte, 17);
            cl._pv6 = ((sbyte)DataInfo.GetByteValue(inByte, 18))/100f;
            cl._ov7 = (sbyte)DataInfo.GetByteValue(inByte, 19);
            cl._pv7 = ((sbyte)DataInfo.GetByteValue(inByte, 20))/100f;
            cl._ov8 = (sbyte)DataInfo.GetByteValue(inByte, 21);
            cl._pv8 = ((sbyte)DataInfo.GetByteValue(inByte, 22))/100f;
            return cl;
        }
        //解析循环泵压差设定
        public static xd100x.cycpumpvalue Read_cycpumpvalue(byte[] inByte)
        {
            xd100x.cycpumpvalue cv = new xd100x.cycpumpvalue();
            cv._pressure = DataInfo.GetFloatValue(inByte,8);
            return cv;
        }
        //解析补水泵压力设定
        public static xd100x.addpumpvalue Read_addpumpvalue(byte[] inByte)
        {
            xd100x.addpumpvalue av = new xd100x.addpumpvalue();
            av._type = DataInfo.GetByteValue(inByte, 8);
            av._pressure = DataInfo.GetFloatValue(inByte,9);
            return av;
        }
        //解析补水压力上下限 水箱水位上下限
        public static xd100x.addpumpmm Read_addpumpmm(byte[] inByte)
        {
            xd100x.addpumpmm sam = new xd100x.addpumpmm();
            sam._presshight = DataInfo.GetFloatValue(inByte, 8);
            sam._presslow = DataInfo.GetFloatValue(inByte, 12);
            sam._levelhight = DataInfo.GetFloatValue(inByte, 16);
            sam._levellow = DataInfo.GetFloatValue(inByte, 20);
            return sam;
        }
        //解析报警设置压力
        public static xd100x.alarmp Read_alarmp(byte[] inByte)
        {
            xd100x.alarmp ap = new xd100x.alarmp();
            ap._yicigdiya = DataInfo.GetFloatValue(inByte, 8);
            ap._erciggaoya = DataInfo.GetFloatValue(inByte, 12);
            ap._ercihgaoya = DataInfo.GetFloatValue(inByte, 16);
            ap._ercihdiya = DataInfo.GetFloatValue(inByte, 20);
            return ap;
        }
        //解析报警设置温度液位
        public static xd100x.alarmt Read_alarmt(byte[] inByte)
        {
            xd100x.alarmt at = new xd100x.alarmt();
            at._yicigdiwen =Convert.ToInt16(DataInfo.GetFloatValue(inByte, 8));
            at._erciggaowen = Convert.ToInt16(DataInfo.GetFloatValue(inByte, 12));
            at._waterhight = DataInfo.GetFloatValue(inByte, 16);
            at._waterlow = DataInfo.GetFloatValue(inByte, 20);
            return at;
        }
        //解析室外温度模式
        public static xd100x.outmode Read_outmode(byte[] inByte)
        {
            xd100x.outmode om = new xd100x.outmode();
            om._outmode = DataInfo.GetByteValue(inByte, 7);
            return om;
        }
        //解析室外温度值
        public static xd100x.outtemp Read_outtemp(byte[] inByte)
        {
            xd100x.outtemp op = new xd100x.outtemp();
            op._outtemp = DataInfo.GetFloatValue(inByte, 8);
            return op;
        }
        //解析实时数据
        public static xd100x.Data Read_ai(byte[] inByte)
        {
            xd100x.Data _rdata = new xd100x.Data();
            _rdata._dt = DateTime.Now;

            _rdata._GTB2 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 15), 1);
            _rdata._PA2 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 19), 2);
            _rdata._BPB2 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 23), 2);

            _rdata._OT = (float)Math.Round(DataInfo.GetFloatValue(inByte, 27), 1);
            _rdata._GT1 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 31), 1);
            _rdata._BT1 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 35), 1);
            _rdata._GT2 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 39), 1);
            _rdata._BT2 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 43), 1);

            _rdata._GP1 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 47), 2);
            _rdata._BP1 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 51), 2);
            _rdata._GP2 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 55), 2);
            _rdata._BP2 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 59), 2);

            _rdata._OD = DataInfo.GetByteValue(inByte, 63);
            _rdata._WL = (float)Math.Round(DataInfo.GetFloatValue(inByte, 64), 2);

            _rdata._WI1 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 68), 1);
            _rdata._WI3 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 72), 1);
            _rdata._HS1 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 76), 1);
            _rdata._HS2 = (float)Math.Round(DataInfo.GetFloatValue(inByte, 80), 1);
            _rdata._WI2 = (float)Math.Round(0f, 1);

            _rdata._WS1 = DataInfo.GetULongValue(inByte, 84);
            _rdata._WS3 = DataInfo.GetULongValue(inByte, 88);
            _rdata._HI1 = DataInfo.GetULongValue(inByte, 92);           
            _rdata._HI2 = DataInfo.GetULongValue(inByte, 96);
            _rdata._WS2 = 0;

            byte[] warnbyte = new byte[2];
            warnbyte[0] = DataInfo.GetByteValue(inByte, 101);
            warnbyte[1] = DataInfo.GetByteValue(inByte, 102);
            xd100x.AlarmState grAlarmData = AlarmParse(warnbyte);
            _rdata._alarm = grAlarmData;

            byte statebyte = DataInfo.GetByteValue(inByte, 103);
            xd100x.PumpState grPumpState = PumpParse(statebyte);
            _rdata._pump = grPumpState;
            
            return _rdata;
        }
        //位寄存器解析泵状态
        public static xd100x.PumpState Get_pumpstate(byte[] inByte)
        {
            byte pumpbyte = inByte[3];
            return PumpParse(pumpbyte);
        }
        //位寄存器解析报警
        public static xd100x.AlarmState Get_alarmstate(byte[] inByte)
        {
            byte[] alarmbyte = { inByte[5], inByte[6] };
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
            gral._yicigongdiwen = DataInfo.GetAlarmData(alarm[0], 0);
            gral._ercigonggaowen = DataInfo.GetAlarmData(alarm[0], 1);
            gral._yicigongdiya = DataInfo.GetAlarmData(alarm[0], 2);
            gral._ercigonggaoya = DataInfo.GetAlarmData(alarm[0], 3);
            gral._ercihuigaoya = DataInfo.GetAlarmData(alarm[0], 4);
            gral._ercihuidiya = DataInfo.GetAlarmData(alarm[0], 5);
            gral._shuiweidi = DataInfo.GetAlarmData(alarm[0], 6);
            gral._shuiweigao = DataInfo.GetAlarmData(alarm[0], 7);

            gral._xunhuanbeng1 = DataInfo.GetAlarmData(alarm[1], 0);
            gral._xunhuanbeng2 = DataInfo.GetAlarmData(alarm[1], 1);
            gral._xunhuanbeng3 = DataInfo.GetAlarmData(alarm[1], 2);
            gral._bushuibeng1 = DataInfo.GetAlarmData(alarm[1], 3);
            gral._bushuibeng2 = DataInfo.GetAlarmData(alarm[1], 4);
            gral._kaiguangao = xd100x.GRAlarm.无;
            gral._kaiguandi = xd100x.GRAlarm.无;
            gral._diaodian = DataInfo.GetAlarmData(alarm[1], 5);
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
        //报警主动上报解析
        public static xd100x.AlarmState Read_alarmstate(byte[] inByte)
        {
            byte[] warnbyte = new byte[2];
            warnbyte[0] = DataInfo.GetByteValue(inByte, 7);
            warnbyte[1] = DataInfo.GetByteValue(inByte, 8);
            xd100x.AlarmState grAlarmData = AlarmParse(warnbyte);
            return grAlarmData;
        }
        //解析温度修正
        public static xd100x.temprevise Read_temprevise(byte[] inByte)
        {
            xd100x.temprevise or = new xd100x.temprevise();
            or._channel = DataInfo.GetByteValue(inByte, 8);
            or._type = DataInfo.GetByteValue(inByte, 9);
            or._unit = DataInfo.GetByteValue(inByte, 10);
            or._max = DataInfo.GetFloatValue(inByte, 11);
            or._min = DataInfo.GetFloatValue(inByte, 15);
            or._k = DataInfo.GetFloatValue(inByte, 19);
            or._b = DataInfo.GetFloatValue(inByte, 23);
            return or;
        }

        #endregion


        #endregion

        //数据处理逻辑
        #region
        //xd100n数据处理
        public static void Deal_XD100Data(byte[] inbyte, string ip)
        {
            //检测是否为xd100n数据
            //判断依据  1、CRC 2、ip 3、器件地址
            if (false == DataInfo.CheckCRC(inbyte))
            {
                return;
            }

            if (inbyte[0] != 0x21 || inbyte[1] != 0x58 || inbyte[2] != 0x44 || inbyte[4] != 0xa0)
            {
                return;
            }

            int busfferlistID = -1;
            for (int i = 0; i < xd100x._XD100xBuffer.Length; i++)
            {
                if (xd100x._XD100xBuffer[i]._Info._ip == ip && xd100x._XD100xBuffer[i]._Info._addr == inbyte[3])
                {
                    busfferlistID = i;
                    break;
                }
            }

            if (busfferlistID == -1)
            {
                return;
            }

            //实时数据 功能码30
            if (inbyte[5] == 30)
            {
                xd100x._XD100xBuffer[busfferlistID]._Data = Read_ai(inbyte);
                xd100x._XD100xBuffer[busfferlistID]._SaveDatas = true;
                TimeSpan ts = DateTime.Now - Convert.ToDateTime(xd100x._XD100xBuffer[busfferlistID]._Data._dt);
                if (ts.TotalMinutes > 3)
                {
                    if (DateTime.Now.Date != Convert.ToDateTime(xd100x._XD100xBuffer[busfferlistID]._Data._dt).Date)
                    {
                        Tool.xd100x._XD100xBuffer[busfferlistID]._Command[42]._cmd = Tool.xd100.Set_datetime(Tool.xd100x._XD100xBuffer[busfferlistID]._Info._addr);
                        Tool.xd100x._XD100xBuffer[busfferlistID]._Command[42]._onoff = true;
                    }
                }
            }
            //获取调节阀控制模式调节阀设定值
            if (inbyte[5] == 20 && inbyte[7]==0x47)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._valvecontrol = Read_valvecontrol(inbyte);
                xd100x._XD100xBuffer[busfferlistID]._Set._valvevalue = Read_valvevalue(inbyte);
            }
            //获取调节阀温度曲线
            if (inbyte[5] == 20 && inbyte[7]==0x48)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._valveline = Read_valveline(inbyte);
                xd100x._XD100xBuffer[busfferlistID]._Set._valvetime = Read_valvetime(inbyte);
            }
            //获取调节阀开度上下限
            if (inbyte[5] == 20 && inbyte[7]==0x49)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._valvemm = Read_valvemm(inbyte);
            }
            //获取压差曲线
            if (inbyte[5] == 0x3E)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._cycpumpline = Read_cycpumpline(inbyte);
            }
            //获取循环泵压差设定
            if (inbyte[5] == 0x40)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._cycpumpvalue = Read_cycpumpvalue(inbyte);
            }
            //获取补水泵压力设定
            if (inbyte[5] == 20 && inbyte[7]==0x4d)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._addpumpvalue = Read_addpumpvalue(inbyte);
            }
            //获取补水压力上下限 水箱水位上下限
            if (inbyte[5] == 20 && inbyte[7]==0x4f)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._addpumpmm = Read_addpumpmm(inbyte);
            }
            //获取报警设置压力
            if (inbyte[5] == 20 && inbyte[7]==0x51)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._alarmp = Read_alarmp(inbyte);
            }
            //获取报警设置温度液位
            if (inbyte[5] == 20 && inbyte[7]==0x52)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._alarmt = Read_alarmt(inbyte);
            }
            //获取室外温度模式
            if (inbyte[5] == 40)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._outmode = Read_outmode(inbyte);
            }
            //获取室外温度值
            //if (inbyte[5] == 20 && inbyte[7] == 0x1f)
            //{
            //    xd100x._XD100xBuffer[busfferlistID]._Set._outtemp = Read_outtemp(inbyte);
            //}          
            //获取室外温度修正
            if (inbyte[5] == 20 && inbyte[7] == 31)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._outrevise = Read_temprevise(inbyte);
                xd100x._XD100xBuffer[busfferlistID]._Set._outrevise._temp = xd100x._XD100xBuffer[busfferlistID]._Data._OT;
            }
            //获取室外温度修正
            if (inbyte[5] == 20 && inbyte[7] == 32)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._GT1revise = Read_temprevise(inbyte);
                xd100x._XD100xBuffer[busfferlistID]._Set._GT1revise._temp = xd100x._XD100xBuffer[busfferlistID]._Data._GT1;
            }
            //获取室外温度修正
            if (inbyte[5] == 20 && inbyte[7] == 33)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._BT1revise = Read_temprevise(inbyte);
                xd100x._XD100xBuffer[busfferlistID]._Set._BT1revise._temp = xd100x._XD100xBuffer[busfferlistID]._Data._BT1;
            }
            //获取室外温度修正
            if (inbyte[5] == 20 && inbyte[7] == 34)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._GT2revise = Read_temprevise(inbyte); 
                xd100x._XD100xBuffer[busfferlistID]._Set._GT2revise._temp = xd100x._XD100xBuffer[busfferlistID]._Data._GT2;
            }
            //获取室外温度修正
            if (inbyte[5] == 20 && inbyte[7] == 35)
            {
                xd100x._XD100xBuffer[busfferlistID]._Set._BT2revise = Read_temprevise(inbyte);
                xd100x._XD100xBuffer[busfferlistID]._Set._BT2revise._temp = xd100x._XD100xBuffer[busfferlistID]._Data._BT2;
            }
            //设定成功返回
            if (inbyte[5] == 10)
            {
                
            }
            //主动上报报警
            if (inbyte[5] == 32)
            {
                xd100x._XD100xBuffer[busfferlistID]._Data._alarm = Read_alarmstate(inbyte);
                return;
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