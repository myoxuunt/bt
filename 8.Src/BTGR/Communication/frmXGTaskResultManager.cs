using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Communication
{
	/// <summary>
	/// frmXGTaskResultManager ��ժҪ˵����
	/// </summary>
	public class frmXGTaskResultManager : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGrid dataGridXGTaskResult;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXGTaskResultManager()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			//
            dataGridXGTaskResult.ReadOnly = true;

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
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridXGTaskResult = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXGTaskResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(540, 341);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "ɾ��";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridXGTaskResult
            // 
            this.dataGridXGTaskResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridXGTaskResult.DataMember = "";
            this.dataGridXGTaskResult.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridXGTaskResult.Location = new System.Drawing.Point(0, 5);
            this.dataGridXGTaskResult.Name = "dataGridXGTaskResult";
            this.dataGridXGTaskResult.Size = new System.Drawing.Size(624, 320);
            this.dataGridXGTaskResult.TabIndex = 4;
            // 
            // frmXGTaskResultManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(624, 369);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridXGTaskResult);
            this.Name = "frmXGTaskResultManager";
            this.Text = "Ѳ���������";
            this.Load += new System.EventHandler(this.frmXGTaskResultManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXGTaskResult)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

        private void frmXGTaskResultManager_Load(object sender, System.EventArgs e)
        {
            string[] colNames = new string[] {"result_id", "dt", "station_name", 
                "person", "card_sn", "expection_time",
                "occur_time", "complete"};
            string[] showNames = new string[] {"���", "ʱ��", "վ��",
                "�ֿ���", "����", "����ʱ��",
                "����ʱ��", "�Ƿ����"};

            int[] boolColIndexs = new int[]{7};

            DataGridTableStyle style = Misc.CreateDataGridTableStyle( "Table", colNames, showNames, 
                boolColIndexs);
            this.dataGridXGTaskResult.TableStyles.Add( style );
            LoadXGTaskResultFromDB();
        }

        private void LoadXGTaskResultFromDB()
        {
            string s = string.Format( "select * from v_xgtask_Result" );
            DataSet ds = XGDB.DbClient.Execute( s );
            dataGridXGTaskResult.DataSource = ds.Tables[0];
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
        
        }
	}
}
