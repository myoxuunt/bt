using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CFW;
using Communication.GRCtrl;

namespace Communication
{
	/// <summary>
	/// frmOpenDegree ��ժҪ˵����
	/// </summary>
	public class frmOpenDegree : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnWirte;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label1;

        GRStation _st;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOpenDegree( GRStation st )
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
            if ( st == null )
                throw new ArgumentNullException("st");
            _st = st;
            
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
			this.txtMax = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMin = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtStationName
			// 
			this.txtStationName.Location = new System.Drawing.Point(160, 16);
			this.txtStationName.Name = "txtStationName";
			this.txtStationName.ReadOnly = true;
			this.txtStationName.Size = new System.Drawing.Size(120, 21);
			this.txtStationName.TabIndex = 1;
			this.txtStationName.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 23);
			this.label5.TabIndex = 0;
			this.label5.Text = "վ����";
			// 
			// btnWirte
			// 
			this.btnWirte.Location = new System.Drawing.Point(176, 120);
			this.btnWirte.Name = "btnWirte";
			this.btnWirte.TabIndex = 7;
			this.btnWirte.Text = "����";
			this.btnWirte.Click += new System.EventHandler(this.btnWirte_Click);
			// 
			// btnRead
			// 
			this.btnRead.Location = new System.Drawing.Point(96, 120);
			this.btnRead.Name = "btnRead";
			this.btnRead.TabIndex = 6;
			this.btnRead.Text = "��ȡ";
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// txtMax
			// 
			this.txtMax.Location = new System.Drawing.Point(160, 80);
			this.txtMax.Name = "txtMax";
			this.txtMax.Size = new System.Drawing.Size(120, 21);
			this.txtMax.TabIndex = 5;
			this.txtMax.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "����ſ��ȣ�";
			// 
			// txtMin
			// 
			this.txtMin.Location = new System.Drawing.Point(160, 48);
			this.txtMin.Name = "txtMin";
			this.txtMin.Size = new System.Drawing.Size(120, 21);
			this.txtMin.TabIndex = 3;
			this.txtMin.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "��С���ſ��ȣ�";
			// 
			// frmOpenDegree
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 157);
			this.Controls.Add(this.txtStationName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnWirte);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.txtMax);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtMin);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOpenDegree";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "���ڷ�����";
			this.Load += new System.EventHandler(this.frmOpenDegree_Load);
			this.ResumeLayout(false);

		}
		#endregion

        private void frmOpenDegree_Load(object sender, System.EventArgs e)
        {
			this.txtStationName.Text = this._st.StationName;
        }

        private void btnRead_Click(object sender, System.EventArgs e)
        {
//            GRReadPressAlarmSetCommand cmd = new GRReadPressAlarmSetCommand( _grSt );
            GRReadOpenDegree  cmd = new GRReadOpenDegree( _st );
            Task t = new Task( cmd, new ImmediateTaskStrategy() );
            frmControlProcess f = new frmControlProcess( t );
            Singles.S.TaskScheduler.Tasks.Add( t );

            DialogResult r =  f.ShowDialog( this );
            if ( t.LastCommResultState == CommResultState.Correct )
            {
                this.txtMin.Text = cmd.MinOpenDegree.ToString();
                this.txtMax.Text = cmd.MaxOpenDegree.ToString();
            }
        }

        private void btnWirte_Click(object sender, System.EventArgs e)
        {
            byte min = 0, max = 0;
            try
            {
                min = byte.Parse(this.txtMin.Text);
            }
            catch
            {
                MsgBox.Show("��С���ſ��ȴ���");
                return ;
            }
            try
            {
                max = byte.Parse(this.txtMax.Text);
            }
            catch
            {
                MsgBox.Show("����ſ��ȴ���");
                return ;
            }
            
            if ( min > 100 || max > 100)
            {
                MsgBox.Show("���ſ��Ȳ��ܴ���100");
                return;
            }

            if( min > max )
            {
                MsgBox.Show("��С���ſ��� ���ܴ��� ����ſ���");
                return ;
            }
            GRWriteOpenDegree cmd = new GRWriteOpenDegree( _st, min, max );
            Task t = new Task( cmd, new ImmediateTaskStrategy() );
            frmControlProcess f = new frmControlProcess( t );
            Singles.S.TaskScheduler.Tasks.Add( t );

            DialogResult r =  f.ShowDialog( this );
        }
	}
}
