using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Communication
{
	/// <summary>
	/// frmXGTaskManager 的摘要说明。
	/// </summary>
	public class frmXGTaskManager : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGrid dataGridXGTasK;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmXGTaskManager()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			//
            this.btnAdd.Visible = false;
            this.btnEdit.Visible = false;
            this.btnDelete.Visible = false;
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridXGTasK = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXGTasK)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(540, 341);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(460, 341);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(380, 341);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridXGTasK
            // 
            this.dataGridXGTasK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridXGTasK.DataMember = "";
            this.dataGridXGTasK.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridXGTasK.Location = new System.Drawing.Point(0, 5);
            this.dataGridXGTasK.Name = "dataGridXGTasK";
            this.dataGridXGTasK.Size = new System.Drawing.Size(624, 320);
            this.dataGridXGTasK.TabIndex = 8;
            // 
            // frmXGTaskManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(624, 369);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridXGTasK);
            this.Name = "frmXGTaskManager";
            this.Text = "巡更任务管理";
            this.Load += new System.EventHandler(this.frmXGTaskManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXGTasK)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

        private void frmXGTaskManager_Load(object sender, System.EventArgs e)
        {
            dataGridXGTasK.ReadOnly = true;
            string[] colNames = new string[] {"xgtask_id", "name", "person", "sn", "begin_time", "end_time"};
            string[] showNames = new string[] {"编号", "站名", "持卡人", "卡号", "开始时间", "结束时间"};
            DataGridTableStyle dgts = Misc.CreateDataGridTableStyle( "Table", colNames, showNames, null );
            this.dataGridXGTasK.TableStyles.Add( dgts );

            LoadXGTaskFromDB();
            
        }

        private void LoadXGTaskFromDB()
        {
            string sql = string.Format("select * from v_xgtask");
           
            DataSet ds = XGDB.DbClient.Execute( sql );
            this.dataGridXGTasK.DataSource = ds.Tables[0];


        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            frmXGTaskItem f = new frmXGTaskItem();
            if ( f.ShowDialog(this) == DialogResult.OK )
            {
                string person = f.Person;
                string cardsn = f.CardSN;
                string stName = f.XgStationName;
                XGTime time = f.XGTime ;
                
                XGDB.InsertXGTask( stName, person, time );
                //XGStation xgstation = GetXGStation(  stName );
                //Card card = GetCard( cardsn );
                //
                //XGTask task = new XGTask( xgstation, card, time );
                //XGDB.InsertXGTask( task );

                LoadXGTaskFromDB();
                XGDB.Resolve();
            }
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            int row = dataGridXGTasK.CurrentRowIndex;
            if ( row == -1 )
                return ;
            
            int id = int.Parse( dataGridXGTasK[ row, 0 ].ToString() );
            string stName = dataGridXGTasK[ row, 1 ].ToString();
            string person = dataGridXGTasK[ row, 2 ].ToString();
            string cardsn = dataGridXGTasK[ row, 3 ].ToString();
            string beginTs = dataGridXGTasK[ row, 4 ].ToString();
            string endTs = dataGridXGTasK[ row, 5 ].ToString();
            //XGTime time = new XGTime( DateTime.Parse ( DateTime.Now.Date.ToString() + " " + beginTs ),
            //    DateTime.Parse ( DateTime.Now.Date.ToString() + " " + endTs ) );
            XGTime time = new XGTime( DateTime.Parse( beginTs ), DateTime.Parse( endTs ) );

            frmXGTaskItem f = new frmXGTaskItem();
            f.AdeState = ADEState.Edit;
            f.EditId = id ;
            f.XgStationName = stName;
            f.Person = person;
            f.CardSN = cardsn;
            f.XGTime = time;

            if ( f.ShowDialog( this ) == DialogResult.OK )
            {
                XGDB.UpdateXGTask( id, f.XgStationName, f.Person, f.XGTime );
                LoadXGTaskFromDB();
                
                // 2007.01.30 Added
                //
                XGDB.Resolve();
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            int row = dataGridXGTasK.CurrentRowIndex;
            if ( row == -1 )
                return;

            DialogResult dr = MsgBox.ShowQuestion( GT.TIP_DELELE_DATAGRID_ROW );
            if ( dr == DialogResult.Yes )
            {
                int id = int.Parse( dataGridXGTasK[ row, 0 ].ToString() );
                XGDB.DeleteXGTask( id );
                LoadXGTaskFromDB();
                XGDB.Resolve();
            }
        }
	}
}
