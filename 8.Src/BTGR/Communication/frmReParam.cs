using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Communication.GRCtrl;

namespace Communication
{
	/// <summary>
	/// frmCycleParam ��ժҪ˵����
	/// </summary>
	public class frmReParam : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReParam()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(80, 136);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "ȷ��";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(160, 136);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "ȡ��";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "��ˮ�ù���ģʽ��";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(152, 80);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 21);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "0";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "��ˮѹ���趨��";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(152, 48);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 20);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.Text = "comboBox1";
			// 
			// frmReParam
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 183);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmReParam";
			this.Text = "ѭ���ò���";
			this.Load += new System.EventHandler(this.frmCycleParam_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// 
		/// </summary>
		public RePumpMode Mode
		{
			get { return _mode;}
		} private RePumpMode _mode = RePumpMode.PID����;

		/// <summary>
		/// 
		/// </summary>
		public float Pressset
		{
			get { return _pressset; }
		} private float _pressset;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			try
			{
				this._mode = (RePumpMode) Enum.Parse( typeof( RePumpMode ), this.comboBox1.Text );
				this._pressset = float.Parse( this.textBox1.Text );	
				if( _pressset > 2.5F || _pressset < 0 )
				{
					MessageBox.Show( "����ѹ���趨 ������� 0 �� 2.5 ֮��" );
					return ;
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show ( ex.Message);
				return ;
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void frmCycleParam_Load(object sender, System.EventArgs e)
		{
			this.comboBox1.Items.Add( RePumpMode.PID����);
			this.comboBox1.Items.Add( RePumpMode.��ˮѹ��������� );
			this.comboBox1.Items.Add( RePumpMode.��ŷ����� );

			this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox1.SelectedIndex = 0;
		}
	}
}
