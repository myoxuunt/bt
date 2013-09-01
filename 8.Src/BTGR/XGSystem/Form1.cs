using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Communication
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
				if (components != null) 
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cmbCommand = new System.Windows.Forms.ComboBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(512, 288);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmbCommand
            // 
            this.cmbCommand.Location = new System.Drawing.Point(320, 288);
            this.cmbCommand.Name = "cmbCommand";
            this.cmbCommand.Size = new System.Drawing.Size(184, 20);
            this.cmbCommand.TabIndex = 0;
            this.cmbCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCommand_KeyPress);
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("����", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.txtOutput.Location = new System.Drawing.Point(8, 8);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(968, 272);
            this.txtOutput.TabIndex = 2;
            this.txtOutput.Text = "";
            this.txtOutput.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(984, 317);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.cmbCommand);
            this.Controls.Add(this.btnSubmit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cmbCommand;
        private System.Windows.Forms.TextBox txtOutput;

        TestXGSystemCommand _test = null;
        private void Form1_Load(object sender, System.EventArgs e)
        {
            TestXGSystemCommand test = new TestXGSystemCommand();//.test();
            _test = test;
            _test.test();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            string cmd = cmbCommand.Text.Trim().ToLower();
            SubmitCommand( cmd );
        }

        private void SubmitCommand( string cmd )
        {
            switch( cmd )
            {
                case "sl":
                    ShowLogs();
                    cmbCommand.Text = string.Empty ;
                    break;
                case "ee":
                    Close();
                    break;
            }
        }

        private void ShowLogs()
        {
            txtOutput.Text += "Load ShowLogs()" + Environment.NewLine;
            txtOutput.Text += _test.GetOperateLogs() + Environment.NewLine;
        }

        private void cmbCommand_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch( e.KeyChar)
            {
                case (char)0x0D:
                    btnSubmit_Click(null, null);
                    break;
            }
        }
	}
}
