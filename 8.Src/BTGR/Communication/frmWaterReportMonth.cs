using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Communication
{
	/// <summary>
	/// frmWaterReportMonth 的摘要说明。
	/// </summary>
	public class frmWaterReportMonth : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblBeginDate;
        private System.Windows.Forms.DateTimePicker dtpBegin;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmWaterReportMonth()
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(168, 88);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(16, 48);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(72, 23);
            this.lblEndDate.TabIndex = 8;
            this.lblEndDate.Text = "截止日期：";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(96, 48);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(152, 21);
            this.dtpEnd.TabIndex = 7;
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.Location = new System.Drawing.Point(16, 16);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(72, 23);
            this.lblBeginDate.TabIndex = 6;
            this.lblBeginDate.Text = "起始日期：";
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(96, 16);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(152, 21);
            this.dtpBegin.TabIndex = 5;
            // 
            // frmWaterReportMonth
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(266, 127);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblBeginDate);
            this.Controls.Add(this.dtpBegin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWaterReportMonth";
            this.Text = "补水数据统计表";
            this.ResumeLayout(false);

        }
		#endregion

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            Print();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Print()
        {
            if ( !CheckDate() )
                return ;


            DateTime dtbegin = this.dtpBegin.Value.Date;
            DateTime dtend = this.dtpEnd.Value.Date;
            string sql = "select name, time, addpumpvalue from v_addpumpdatas where time between '{0}' and '{1}' order by time";
            sql = string.Format( sql, dtbegin, dtend );
            DataTable tbl = XGDB.DbClient.Execute( sql ).Tables[0];

            DayWaterCalculator dwc = new DayWaterCalculator( dtbegin, dtend );

            foreach( DataRow row in tbl.Rows )
            {
                string name = row["name"].ToString().Trim();
                DateTime dt = Convert.ToDateTime( row["time"] ).Date;
                float waterVal = Convert.ToSingle( row["addpumpvalue"] );

                dwc.Process( name, dt, waterVal );
            }

            ExcelPrint( dtbegin, dtend, dwc.Result );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wdpSet"></param>
        private void ExcelPrint( DateTime dtbegin, DateTime dtend, ArrayList wdpSet )
        {
            new DayWaterExporter( dtbegin, dtend, wdpSet).Export();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckDate()
        {
            DateTime dtbegin = this.dtpBegin.Value.Date;
            DateTime dtend = this.dtpEnd.Value.Date;

            if ( dtend <= dtbegin )
            {
                MsgBox.Show( 
                    "截止日期必须大于起始日期!",
                    GT.TEXT_TIP,
                    MessageBoxIcon.Error 
                    );
                return false;
            }
            return true;
        }
	}
}
