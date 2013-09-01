using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Communication
{
	/// <summary>
	/// frmXGTaskResultManager 的摘要说明。
	/// </summary>
	public class frmXGTaskResultManager : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGrid dataGridXGTaskResult;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXGTaskResultManager()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			//
            dataGridXGTaskResult.ReadOnly = true;

		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
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
            this.btnDelete.Text = "删除";
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
            this.Text = "巡更结果管理";
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
            string[] showNames = new string[] {"编号", "时间", "站名",
                "持卡人", "卡号", "期望时间",
                "发生时间", "是否完成"};

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
