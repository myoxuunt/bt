using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Communication
{
	/// <summary>
	/// frmTest 的摘要说明。
	/// </summary>
	public class frmTest : System.Windows.Forms.Form
	{
        private System.Data.SqlClient.SqlConnection sqlConnection1;
        private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTest()
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
            this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
            this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            // 
            // sqlConnection1
            // 
            this.sqlConnection1.ConnectionString = "workstation id=A;packet size=4096;user id=sa;data source=a;persist security info=" +
                "False;initial catalog=XGDB";
            // 
            // sqlDataAdapter1
            // 
            this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
            this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
            this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
            this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
                                                                                                      new System.Data.Common.DataTableMapping("Table", "tbl_card", new System.Data.Common.DataColumnMapping[] {
                                                                                                                                                                                                                  new System.Data.Common.DataColumnMapping("card_id", "card_id"),
                                                                                                                                                                                                                  new System.Data.Common.DataColumnMapping("sn", "sn"),
                                                                                                                                                                                                                  new System.Data.Common.DataColumnMapping("person", "person")})});
            this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "DELETE FROM tbl_card WHERE (card_id = @Original_card_id) AND (person = @Original_" +
                "person OR @Original_person IS NULL AND person IS NULL) AND (sn = @Original_sn)";
            this.sqlDeleteCommand1.Connection = this.sqlConnection1;
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_card_id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "card_id", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_person", System.Data.SqlDbType.NVarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "person", System.Data.DataRowVersion.Original, null));
            this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_sn", System.Data.SqlDbType.NVarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "sn", System.Data.DataRowVersion.Original, null));
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = "INSERT INTO tbl_card(sn, person) VALUES (@sn, @person); SELECT card_id, sn, perso" +
                "n FROM tbl_card WHERE (card_id = @@IDENTITY)";
            this.sqlInsertCommand1.Connection = this.sqlConnection1;
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sn", System.Data.SqlDbType.NVarChar, 100, "sn"));
            this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@person", System.Data.SqlDbType.NVarChar, 100, "person"));
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT card_id, sn, person FROM tbl_card";
            this.sqlSelectCommand1.Connection = this.sqlConnection1;
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = "UPDATE tbl_card SET sn = @sn, person = @person WHERE (card_id = @Original_card_id" +
                ") AND (person = @Original_person OR @Original_person IS NULL AND person IS NULL)" +
                " AND (sn = @Original_sn); SELECT card_id, sn, person FROM tbl_card WHERE (card_i" +
                "d = @card_id)";
            this.sqlUpdateCommand1.Connection = this.sqlConnection1;
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sn", System.Data.SqlDbType.NVarChar, 100, "sn"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@person", System.Data.SqlDbType.NVarChar, 100, "person"));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_card_id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "card_id", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_person", System.Data.SqlDbType.NVarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "person", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_sn", System.Data.SqlDbType.NVarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "sn", System.Data.DataRowVersion.Original, null));
            this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@card_id", System.Data.SqlDbType.Int, 4, "card_id"));
            // 
            // frmTest
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(552, 301);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);

        }
		#endregion

        private void frmTest_Load(object sender, System.EventArgs e)
        {
        
        }
	}
}
