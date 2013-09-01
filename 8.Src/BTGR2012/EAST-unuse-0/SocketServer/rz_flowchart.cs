using System;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class rz_flowchart : Form
    {
        public rz_flowchart()
        {
            InitializeComponent();
        }
        public static int ID;

        private int busfferlistID = -1;

        private int Get_busfferlistID(int id)
        {
            int _id = -1;
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                if (id == Tool.xd100x._XD100xBuffer[i]._Info._id)
                {
                    _id = i;
                    break;
                }
            }
            return _id;
        }

        private void rz_flowchart_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            busfferlistID = Get_busfferlistID(ID);
            Refalsh_data(busfferlistID);
        }

        private void Refalsh_data(int busfferlistID)
        {         
            if (busfferlistID == -1)
            {
                return;
            }
            labname.Text = Tool.xd100x._XD100xBuffer[busfferlistID]._Info._name.ToString();
            labdt.Text = Tool.xd100x._XD100xBuffer[busfferlistID]._Data._dt.ToString();

            labot.Text = "室外温度：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._OT.ToString() + " ℃";
            labdegree.Text = "阀位反馈：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._OD.ToString()+" %";
            labogt.Text = "一次供水温度：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._GT1.ToString() + " ℃";
            labogp.Text = "一次供水压力：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._GP1.ToString()+" MPa";
            labobt.Text = "一次回水温度：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._BT1.ToString() + " ℃";
            labobp.Text = "一次回水压力：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._BP1.ToString() + " MPa";

            labof.Text = "一次瞬时流量：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._WI1.ToString() + " m3/h";
            laboaf.Text = "一次累积流量：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._WS1.ToString() + " m3";

            laboh.Text = "一次瞬时热量：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._HS1.ToString()+" GJ/h";
            laboah.Text = "一次累积热量：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._HI1.ToString()+" GJ";

            labtgt.Text = "二次供水温度：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._GT2.ToString() + " ℃";
            labtgp.Text = "二次供水压力：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._GP2.ToString() + " MPa";
            labtbt.Text = "二次回水温度：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._BT2.ToString() + " ℃";
            labtbp.Text = "二次回水压力：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._BP2.ToString() + " MPa";
            labtgpb.Text = "二次回压设定：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._BPB2.ToString() + " MPa";
            labtgtb.Text = "二次供温基准：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._GTB2.ToString() + " ℃";
            labcb.Text = "二次压差设定：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._PA2.ToString() + " MPa";

            labtf.Text = "二次瞬时流量：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._WI2.ToString() + " m3/h";
            labtaf.Text = "二次累积流量：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._WS2.ToString() + " m3";

            labth.Text = "二次瞬时热量：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._HS2.ToString() + " GJ/h";
            labtah.Text = "二次累积热量：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._HI2.ToString() + " GJ";

            labsf.Text = "补水瞬时流量：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._WI3.ToString() + " m3/h";
            labsaf.Text = "补水累积流量：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._WS3.ToString() + " m3";

            labwl.Text = "水箱水位：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._WL.ToString()+" m";
            labx1.Text = "循环泵1状态：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._pump._CM1.ToString();
            labx2.Text = "循环泵2状态：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._pump._CM2.ToString();
            labx3.Text = "循环泵3状态：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._pump._CM3.ToString();
            labb1.Text = "补水泵1状态：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._pump._RM1.ToString();
            labb2.Text = "补水泵2状态：" + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._pump._RM2.ToString();

            if (Tool.xd100x._XD100xBuffer[busfferlistID]._Info._state == false)
            {
                labdevs.Text = "设备状态：故障";
            }
            else
            {
                labdevs.Text = "设备状态：正常";
            }

            for (int i=0; i < Tool.Gprs._GprsList.Length; i++)
            {
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Info._ip == Tool.Gprs._GprsList[i]._ip)
                {
                    if (Tool.Gprs._GprsList[i]._Iscon == false)
                    {
                        labcoms.Text = "通讯状态：未连接";
                        labdevs.Text = "设备状态：未知";
                    }
                    else
                    {
                        labcoms.Text = "通讯状态：已连接";
                    }
                    if (Tool.Gprs._GprsList[i]._Isbusy == true)
                    {
                        labcoms.Text = "通讯状态：正在通讯";
                    }               
                }
            }
        }


    }
}
