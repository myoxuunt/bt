using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Communication
{
	/// <summary>
	/// frmWastingCaloricReportMonth 的摘要说明。
	/// </summary>
	public class frmWastingCaloricReportMonth : System.Windows.Forms.Form
	{
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label lblBeginDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnPrint;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmWastingCaloricReportMonth()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
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
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(96, 16);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(152, 21);
            this.dtpBegin.TabIndex = 0;
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.Location = new System.Drawing.Point(16, 16);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(72, 23);
            this.lblBeginDate.TabIndex = 1;
            this.lblBeginDate.Text = "起始日期：";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(16, 48);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(72, 23);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "截止日期：";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(96, 48);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(152, 21);
            this.dtpEnd.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(168, 88);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmWastingCaloricReportMonth
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(264, 125);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblBeginDate);
            this.Controls.Add(this.dtpBegin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWastingCaloricReportMonth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "热量统计报表";
            this.ResumeLayout(false);

        }
		#endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            Print();
        }

        /// <summary>
        /// 
        /// </summary>
        private DateTime Begin
        {
            get { return this.dtpBegin.Value.Date; }
        }

        /// <summary>
        /// 
        /// </summary>
        private DateTime End
        {
            get { return this.dtpEnd.Value.Date + TimeSpan.FromDays(1); }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Print()
        {
            if ( !CheckDateTime() )
                return ;

            string sql = string.Format(
                "select name, time, onegivetemp, onebacktemp,oneaccum " + 
                "from v_heatdatas where time between '{0}' and '{1}' order by time",
                Begin,
                End 
                );

            DataSet ds = XGDB.DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];
            
            WastingCaloricCalculatorOfDays wccod = new WastingCaloricCalculatorOfDays(
                Begin,
                dtpEnd.Value 
                );

            foreach( DataRow row in tbl.Rows )
            {
                GrDataPoint gdp = CreateGdp( row );
                if ( gdp != null )
                    wccod.AddGrDataPoint( gdp );
            }

            WccResultSet wccrSet = wccod.CalcWccResultSet();
            int count = wccrSet.Count;

            // (row, col)
            //
            // StationName form (4,1)  row ++
            // Date        from (3,2)  col ++
            WcExcelExporter wcee = new WcExcelExporter( 
                this.dtpBegin.Value.Date,
                this.dtpEnd.Value.Date,
                wccrSet 
                );

            wcee.Export();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private GrDataPoint CreateGdp( DataRow row )
        {
            int i = 0;
            string stname = row[ i++ ].ToString();
            DateTime dt = Convert.ToDateTime( row[ i++ ] );
            float onegt = float.Parse( row[ i++ ].ToString() );
            float onebt = float.Parse( row[ i++ ].ToString() );
            int onesum  = int.Parse(   row[ i++ ].ToString() );

            return new GrDataPoint( 
                stname,
                dt,
                onegt,
                onebt,
                onesum 
                );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckDateTime()
        {
            //TODO:
            if ( this.dtpEnd.Value.Date <= this.dtpBegin.Value.Date )
            {
                MsgBox.Show( "截止日期必须大于起始日期!" );
                return false;
            }
            TimeSpan ts = this.dtpEnd.Value.Date - this.dtpBegin.Value.Date;
            int days = (int)ts.TotalDays;
            if( days > 31 )
            {
                MsgBox.Show( "最大时间范围不能超过一个月!" );
                return false;
            }
            return true; 
        }
	}
}
