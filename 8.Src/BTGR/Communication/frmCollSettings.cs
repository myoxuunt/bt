

namespace Communication
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using CFW;

    #region frmCollSettings
	/// <summary>
	/// frmCollSettings ��ժҪ˵����
	/// </summary>
	public class frmCollSettings : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtGRCollCycle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCollSettings()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//

            FormAdjust.SetFormAppearance( this, false, false,false, false, true );
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
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGRCollCycle = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(196, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "ȷ��";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "���ȿ������ɼ�����(����)��";
            // 
            // txtGRCollCycle
            // 
            this.txtGRCollCycle.Location = new System.Drawing.Point(188, 32);
            this.txtGRCollCycle.Name = "txtGRCollCycle";
            this.txtGRCollCycle.Size = new System.Drawing.Size(160, 21);
            this.txtGRCollCycle.TabIndex = 2;
            this.txtGRCollCycle.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(276, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "ȡ��";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(188, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 21);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "������ʾ����";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("����", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.button1.Location = new System.Drawing.Point(352, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = ">>";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "��Ƶ�ļ�|*.wav";
            // 
            // frmCollSettings
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(384, 133);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtGRCollCycle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Name = "frmCollSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "�ɼ��趨";
            this.Load += new System.EventHandler(this.frmCollSettings_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void frmCollSettings_Load(object sender, System.EventArgs e)
        {
            this.LoadCollSettings();
        }

        /// <summary>
        /// 
        /// </summary>
        private const int MIN_COLL_CYCLE = 6;
        private const int MAX_COLL_CYCLE = 30;

        private void LoadCollSettings()
        {
            this.txtGRCollCycle.Text = XGConfig.Default.GrRealDataCollCycle.ToString();
            this.textBox1.Text = XGConfig.Default.AlarmPopupWavFile;
        }

        private TimeSpan GetCycle( int collCycle)
        {
            return new TimeSpan( 0,0,collCycle,0,0 );
        }

        private bool SaveCollSettings()
        {
            int newGrCollCycle;
            try
            {
                newGrCollCycle = int.Parse( this.txtGRCollCycle.Text.Trim() );
            }
            catch
            {
                MsgBox.Show( "�ɼ����ڱ�����������" );
                return false;
            }

            if ( newGrCollCycle < MIN_COLL_CYCLE )
            {
                MsgBox.Show( "�ɼ����ڲ���С��" + MIN_COLL_CYCLE + "����" );
                return false;
            }
            if ( newGrCollCycle > MAX_COLL_CYCLE )
            {
                MsgBox.Show( "�ɼ����ڲ��ܴ���" + MIN_COLL_CYCLE + "����" );
                return false;
            }

            XGConfig.Default.GrRealDataCollCycle = newGrCollCycle;

            // refresh task coll cycle
            //
            TasksCollection tasks = Singles.S.TaskScheduler.Tasks;
            foreach ( Task t in tasks )
            {
                TaskStrategy s = t.TaskStrategy;
                CommCmdBase cmd = t.CommCmd;
                
                
                if ( s is CycleTaskStrategy && cmd is GRCtrl.GRRealDataCommand )
                {
                    CycleTaskStrategy cyc = s as CycleTaskStrategy ;
                    cyc.Cycle = GetCycle( newGrCollCycle );
                }
            }

            // TODO: update app.config file
            //


            return true;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if ( this.SaveCollSettings() )
                Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if ( this.openFileDialog1.ShowDialog( this ) == DialogResult.OK )
            {
                this.textBox1.Text = openFileDialog1.FileName;
                //TODO:
                //
            }
        }
	}
    #endregion //frmCollSettings
}
