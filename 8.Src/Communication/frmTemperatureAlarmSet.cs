using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Communication.GRCtrl;
using CFW;

namespace Communication
{
	/// <summary>
	/// frmTemperatureAlarmSet ��ժҪ˵����
	/// </summary>
	public class frmTemperatureAlarmSet : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnWirte;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox txtTwoGiveTempHi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOneGiveTempLo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWLLo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStationName;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTemperatureAlarmSet( GRStation grSt )
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
            ArgumentChecker.CheckNotNull( grSt );
            _grSt = grSt;
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnWirte = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.txtTwoGiveTempHi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOneGiveTempLo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWLLo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(160, 16);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.ReadOnly = true;
            this.txtStationName.Size = new System.Drawing.Size(120, 21);
            this.txtStationName.TabIndex = 23;
            this.txtStationName.Text = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "վ����";
            // 
            // btnWirte
            // 
            this.btnWirte.Location = new System.Drawing.Point(184, 160);
            this.btnWirte.Name = "btnWirte";
            this.btnWirte.TabIndex = 21;
            this.btnWirte.Text = "����";
            this.btnWirte.Click += new System.EventHandler(this.btnWirte_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(104, 160);
            this.btnRead.Name = "btnRead";
            this.btnRead.TabIndex = 20;
            this.btnRead.Text = "��ȡ";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // txtTwoGiveTempHi
            // 
            this.txtTwoGiveTempHi.Location = new System.Drawing.Point(160, 80);
            this.txtTwoGiveTempHi.Name = "txtTwoGiveTempHi";
            this.txtTwoGiveTempHi.Size = new System.Drawing.Size(120, 21);
            this.txtTwoGiveTempHi.TabIndex = 15;
            this.txtTwoGiveTempHi.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "���ι����±���ֵ��";
            // 
            // txtOneGiveTempLo
            // 
            this.txtOneGiveTempLo.Location = new System.Drawing.Point(160, 48);
            this.txtOneGiveTempLo.Name = "txtOneGiveTempLo";
            this.txtOneGiveTempLo.Size = new System.Drawing.Size(120, 21);
            this.txtOneGiveTempLo.TabIndex = 13;
            this.txtOneGiveTempLo.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "һ�ι����±���ֵ��";
            // 
            // txtWLLo
            // 
            this.txtWLLo.Location = new System.Drawing.Point(160, 115);
            this.txtWLLo.Name = "txtWLLo";
            this.txtWLLo.Size = new System.Drawing.Size(120, 21);
            this.txtWLLo.TabIndex = 25;
            this.txtWLLo.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 24;
            this.label3.Text = "ˮ��ˮλ�ͱ���ֵ��";
            // 
            // frmTemperatureAlarmSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(304, 197);
            this.Controls.Add(this.txtWLLo);
            this.Controls.Add(this.txtStationName);
            this.Controls.Add(this.txtTwoGiveTempHi);
            this.Controls.Add(this.txtOneGiveTempLo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnWirte);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTemperatureAlarmSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "�¶ȱ�������";
            this.Load += new System.EventHandler(this.frmTemperatureAlarmSet_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private GRStation _grSt ;
        private void btnRead_Click(object sender, System.EventArgs e)
        {
            Read();
        }

        private void Read()
        {
            GRReadTempWLAlarmSetCommand cmd = new GRReadTempWLAlarmSetCommand( _grSt );
            Task t = new Task( cmd, new ImmediateTaskStrategy() );
            frmControlProcess f = new frmControlProcess( t );
            Singles.S.TaskScheduler.Tasks.Add( t );
            DialogResult r = f.ShowDialog( this );
            if ( t.LastCommResultState == CommResultState.Correct )
            {
                txtOneGiveTempLo.Text = cmd.OneGiveTempLo.ToString();
                txtTwoGiveTempHi.Text = cmd.TwoGiveTempHiSetV.ToString();
                txtWLLo.Text = cmd.wlLoSetV.ToString();
            }
        }

        private void Write()
        {
            float onegtl; 
            float twogth;  
            float wllo;
            try
            {
                onegtl = Convert.ToSingle( txtOneGiveTempLo.Text );
            }
            catch
            {
                MsgBox.Show ("һ�ι����±���ֵ����");
                return;
            }
            
            try
            {
                twogth = Convert.ToSingle( txtTwoGiveTempHi.Text );
            }
            catch
            {
                MsgBox.Show( "���ι����±���ֵ����" );
                return;
            }

            try
            {
                wllo   = Convert.ToSingle( txtWLLo.Text );
            }
            catch
            {
                MsgBox.Show ("ˮ��ˮλ�ͱ���ֵ����");
                return;
            }

            GRWriteTempWLAlarmSetCommand cmd = new GRWriteTempWLAlarmSetCommand( _grSt,
                onegtl, twogth, wllo );
            Task t = new Task( cmd, new ImmediateTaskStrategy() );
            Singles.S.TaskScheduler.Tasks.Add( t );
            frmControlProcess f = new frmControlProcess( t );
            DialogResult r = f.ShowDialog( this );
        }

        private void frmTemperatureAlarmSet_Load(object sender, System.EventArgs e)
        {
            txtStationName.Text = _grSt.StationName; 
        }

        private void btnWirte_Click(object sender, System.EventArgs e)
        {
            Write();
        }
	}
}
