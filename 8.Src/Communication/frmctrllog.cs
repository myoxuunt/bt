using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace Communication
{
	/// <summary>
	/// frmctrllog ��ժҪ˵����
	/// </summary>
	public class frmctrllog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmctrllog()
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
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(0, 0);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(376, 310);
			this.dataGrid1.TabIndex = 0;
			// 
			// frmctrllog
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(376, 310);
			this.Controls.Add(this.dataGrid1);
			this.Name = "frmctrllog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "������¼";
			this.Load += new System.EventHandler(this.frmctrllog_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmctrllog_Load(object sender, System.EventArgs e)
		{
			//new Test.Test().InsertPumpOPLog();
			string [] colName = new string[] {"ctrllog_id","dt","obj","op","person" };
			string [] colText = new string[] { "���","ʱ��","Ŀ��","����","������" };
			//int [] boolColIndexs = {3,4,5,6,7,8,9,10,11,12,13,14,15,16};
			int [] colWidths = new int[] {50,100, 100, 100, 100};
			DataGridTableStyle dgts = Misc.CreateDataGridTableStyle( "table", colName, colText, null, colWidths );
			this.dataGrid1.TableStyles.Add( dgts );
			RefGD();
		}

		void RefGD()
		{
			string sql = "select * from tbl_ctrllog";
           
			DataSet ds = XGDB.DbClient.Execute( sql );
			DataTable tbl = ds.Tables[0];

			this.dataGrid1 .DataSource = tbl;
			//MsgBox.Show( this.dataGrid1.TableStyles.Count.ToString() );
		}
	}
}
