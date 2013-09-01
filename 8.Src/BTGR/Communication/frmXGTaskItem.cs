using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Communication
{
	/// <summary>
	/// frmCardItem 的摘要说明。
	/// </summary>
	public class frmXGTaskItem : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCardSN;
        private System.Windows.Forms.Label lblPerson;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        private ADEState    _adeState = ADEState.Add;
        private System.Windows.Forms.Label lblXGStation;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblBeginTime;
        //private System.Windows.Forms.ComboBox cmbXGStation;
        private System.Windows.Forms.ComboBox cmbCardSN;
        private System.Windows.Forms.ComboBox cmbPerson;
        private System.Windows.Forms.ComboBox cmbXGStation;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        //private System.Windows.Forms.ComboBox cmbXGStation;
        private int         _editId = -1;
        private XGTime _xgTime;

        #region Properties
        public ADEState AdeState
        {
            get { return _adeState; }
            set { _adeState = value; }
        }

        public int EditId
        {
            get { return _editId; }
            set { _editId = value; }
        }

        public String XgStationName
        {
            get { return cmbXGStation.Text; }
            set { cmbXGStation.Text = value; }
        }

        public XGTime XGTime
        {
            get 
            { 
                CheckXGTime();
                this._xgTime = new XGTime(  this.dtpBegin.Value, this.dtpEnd.Value );
                return _xgTime; 
            }
            set 
            {
                ArgumentChecker.CheckNotNull( value );
                _xgTime = value; 
                dtpBegin.Value = _xgTime.Begin;
                dtpEnd.Value = _xgTime.End;
            }
        }
        
        public string CardSN
        {
            get { return cmbCardSN.Text; }
            set 
            { 
                cmbCardSN.Text = value; 
            }
        }

        public string Person
        {
            get { return cmbPerson.Text; }
            set { cmbPerson.Text = value; }
        }

        #endregion //Properties

		public frmXGTaskItem()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			//
            FormAdjust.SetFormAppearance( this, false, false, false, false, true );
            cmbCardSN.Sorted = true;
            cmbPerson.Sorted = true;
            cmbXGStation.Sorted = true;

            FillCardSnPersonCombo();
            FillXGStationCombo();

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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCardSN = new System.Windows.Forms.Label();
            this.lblPerson = new System.Windows.Forms.Label();
            this.lblXGStation = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblBeginTime = new System.Windows.Forms.Label();
            this.cmbXGStation = new System.Windows.Forms.ComboBox();
            this.cmbCardSN = new System.Windows.Forms.ComboBox();
            this.cmbPerson = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(240, 160);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(320, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCardSN
            // 
            this.lblCardSN.Location = new System.Drawing.Point(16, 48);
            this.lblCardSN.Name = "lblCardSN";
            this.lblCardSN.Size = new System.Drawing.Size(80, 23);
            this.lblCardSN.TabIndex = 8;
            this.lblCardSN.Text = "卡号：";
            // 
            // lblPerson
            // 
            this.lblPerson.Location = new System.Drawing.Point(16, 80);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(80, 23);
            this.lblPerson.TabIndex = 9;
            this.lblPerson.Text = "持卡人：";
            // 
            // lblXGStation
            // 
            this.lblXGStation.Location = new System.Drawing.Point(16, 16);
            this.lblXGStation.Name = "lblXGStation";
            this.lblXGStation.Size = new System.Drawing.Size(80, 23);
            this.lblXGStation.TabIndex = 7;
            this.lblXGStation.Text = "目标站点：";
            // 
            // dtpBegin
            // 
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBegin.Location = new System.Drawing.Point(104, 112);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.ShowUpDown = true;
            this.dtpBegin.Size = new System.Drawing.Size(96, 21);
            this.dtpBegin.TabIndex = 3;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEnd.Location = new System.Drawing.Point(296, 112);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(96, 21);
            this.dtpEnd.TabIndex = 4;
            // 
            // lblEndTime
            // 
            this.lblEndTime.Location = new System.Drawing.Point(208, 112);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(80, 23);
            this.lblEndTime.TabIndex = 11;
            this.lblEndTime.Text = "结束时间：";
            // 
            // lblBeginTime
            // 
            this.lblBeginTime.Location = new System.Drawing.Point(16, 112);
            this.lblBeginTime.Name = "lblBeginTime";
            this.lblBeginTime.Size = new System.Drawing.Size(80, 23);
            this.lblBeginTime.TabIndex = 10;
            this.lblBeginTime.Text = "起始时间：";
            // 
            // cmbXGStation
            // 
            this.cmbXGStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbXGStation.Location = new System.Drawing.Point(104, 16);
            this.cmbXGStation.Name = "cmbXGStation";
            this.cmbXGStation.Size = new System.Drawing.Size(296, 20);
            this.cmbXGStation.TabIndex = 0;
            // 
            // cmbCardSN
            // 
            this.cmbCardSN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardSN.Location = new System.Drawing.Point(104, 48);
            this.cmbCardSN.Name = "cmbCardSN";
            this.cmbCardSN.Size = new System.Drawing.Size(296, 20);
            this.cmbCardSN.TabIndex = 1;
            this.cmbCardSN.SelectedIndexChanged += new System.EventHandler(this.cmbCardSN_SelectedIndexChanged);
            // 
            // cmbPerson
            // 
            this.cmbPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerson.Location = new System.Drawing.Point(104, 80);
            this.cmbPerson.Name = "cmbPerson";
            this.cmbPerson.Size = new System.Drawing.Size(296, 20);
            this.cmbPerson.TabIndex = 2;
            this.cmbPerson.SelectedIndexChanged += new System.EventHandler(this.cmbPerson_SelectedIndexChanged);
            // 
            // frmXGTaskItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(408, 197);
            this.Controls.Add(this.cmbPerson);
            this.Controls.Add(this.cmbCardSN);
            this.Controls.Add(this.cmbXGStation);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblBeginTime);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpBegin);
            this.Controls.Add(this.lblXGStation);
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.lblCardSN);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmXGTaskItem";
            this.Text = "巡更任务";
            this.Load += new System.EventHandler(this.frmCardItem_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void frmCardItem_Load(object sender, System.EventArgs e)
        {
            
            Text += Misc.GetAdeStateText( _adeState );
        }

        

        private bool CheckXGTime()
        {
            try
            {
                XGTime.Check( this.dtpBegin.Value, this.dtpEnd.Value );
               
                return true;
            }
            catch ( Exception ex )
            {
                //System.Diagnostics.Debug.Fail ( "At check xgtime",ex.ToString() );
                // Add msgbox.
                MsgBox.Show ("结束时间大于开始时间,或时间间隔太短!");
                return false;
            }
        }

        private bool CheckStation()
        {
            if ( cmbXGStation.Text.Trim().Length > 0 )
            {
                return true;
            }
            else
            {
                MsgBox.Show("站点不能为空!");
                return false;
            }
        }

        private bool CheckCardSnPerson()
        {
            if ( cmbCardSN.Text.Trim().Length > 0 )
            {
                if ( cmbPerson.Text.Trim().Length > 0 )
                    return true;
                else
                {
                    MsgBox.Show("持卡人不能为空!");
                    return false;
                }
            }
            else
            {
                MsgBox.Show("卡号不能为空!");
                return false;
            }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if ( ! CheckXGTime () )
                return ;
            if ( ! CheckStation() )
                return ;
            if ( ! CheckCardSnPerson() )
                return ;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FillComboBox( ComboBox cmb, DataTable tbl, int colIndex )
        {
            ArgumentChecker.CheckNotNull( cmb );
            ArgumentChecker.CheckNotNull( tbl );

            foreach( DataRow r in tbl.Rows )
            {
                cmb.Items.Add ( r[colIndex] );
            }
            if ( cmb.Items.Count != 0 )
                cmb.SelectedIndex = 0;
        }

        private void FillXGStationCombo()
        {
            cmbXGStation.Items.Clear(); 
            string s = string.Format( "select name from tbl_xgstation" );
            DataSet ds = XGDB.DbClient.Execute( s );
            FillComboBox( cmbXGStation, ds.Tables[0], 0 );
            
        }
        private SortedList _cardSnPersonAssoc = null;
        
        private void FillCardSnPersonCombo()
        {
            cmbCardSN.Items.Clear();
            cmbPerson.Items.Clear();

            string s = string.Format( "select sn, person from tbl_card" );
            DataSet ds = XGDB.DbClient.Execute( s );
            DataTable tbl = ds.Tables[0];
            _cardSnPersonAssoc = new SortedList( tbl.Rows.Count );
            foreach ( DataRow r in tbl.Rows )
            {
                string person = r[1].ToString();
                string sn = r[0].ToString();
                _cardSnPersonAssoc.Add( person, sn );
            }
           
            FillComboBox ( cmbCardSN, tbl, 0 );
            FillComboBox ( cmbPerson, tbl, 1 );
        }

        private void cmbCardSN_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string sn = this.cmbCardSN.Text;
            int snIdx = _cardSnPersonAssoc.IndexOfValue ( sn );
            string person = _cardSnPersonAssoc.GetKey( snIdx ).ToString();
            cmbPerson.Text = person;
        }

        private void cmbPerson_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string sn = (string) _cardSnPersonAssoc[ cmbPerson.Text ];
            cmbCardSN.Text = sn;
        }
	}
}
