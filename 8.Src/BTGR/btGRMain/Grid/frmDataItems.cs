using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace btGRMain.Grid
{
	/// <summary>
	/// frmDataItems 的摘要说明。
	/// </summary>
	public class frmDataItems : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.DateTimePicker dtDate;
		private System.Windows.Forms.NumericUpDown dtTime;
		private System.Windows.Forms.ComboBox cmbPoint;
		private System.Windows.Forms.TextBox txtTemp1;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int m_DataID;
		private bool m_bolEdit=false;
		private System.Windows.Forms.TextBox txtTemp2;
		private System.Windows.Forms.TextBox txtFlux;
		private System.Windows.Forms.TextBox txtHeat;
		private System.Windows.Forms.TextBox txtHeatAll;
		private System.Windows.Forms.TextBox txtFluxAll1;
		private System.Windows.Forms.TextBox txtFluxAll2;
		private System.Windows.Forms.TextBox txtFulxInstant;
		private DBcon con=null;
		private string m_DT;
		private Decimal m_Temp1;
		private Decimal m_Temp2;
		private Decimal m_Flux;
		private Decimal m_Heat;
		private Decimal m_HeatAll;
		private Decimal m_FluxAll1;
		private Decimal m_FluxAll2;
		private Decimal m_FluxInstant;

		public frmDataItems()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			m_bolEdit=false;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		public frmDataItems(int id)
		{
			InitializeComponent();
			m_DataID=id;
			m_bolEdit=true;
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.dtDate = new System.Windows.Forms.DateTimePicker();
			this.dtTime = new System.Windows.Forms.NumericUpDown();
			this.cmbPoint = new System.Windows.Forms.ComboBox();
			this.txtTemp1 = new System.Windows.Forms.TextBox();
			this.txtTemp2 = new System.Windows.Forms.TextBox();
			this.txtFlux = new System.Windows.Forms.TextBox();
			this.txtHeat = new System.Windows.Forms.TextBox();
			this.txtHeatAll = new System.Windows.Forms.TextBox();
			this.txtFluxAll1 = new System.Windows.Forms.TextBox();
			this.txtFluxAll2 = new System.Windows.Forms.TextBox();
			this.txtFulxInstant = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.btnYes = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtTime)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "时间：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "站点：";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 82);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "温度1：";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 115);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "温度2：";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 148);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "流量：";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 181);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 17);
			this.label6.TabIndex = 5;
			this.label6.Text = "热能：";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 214);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(66, 17);
			this.label7.TabIndex = 6;
			this.label7.Text = "热能累计：";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 247);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(97, 17);
			this.label8.TabIndex = 7;
			this.label8.Text = "瞬时累计流量1：";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 280);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(97, 17);
			this.label9.TabIndex = 8;
			this.label9.Text = "瞬时累计流量2：";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(16, 313);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(85, 17);
			this.label10.TabIndex = 9;
			this.label10.Text = "瞬时流量/秒：";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(16, 344);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(42, 17);
			this.label11.TabIndex = 10;
			this.label11.Text = "备注：";
			// 
			// dtDate
			// 
			this.dtDate.Location = new System.Drawing.Point(112, 16);
			this.dtDate.Name = "dtDate";
			this.dtDate.Size = new System.Drawing.Size(192, 21);
			this.dtDate.TabIndex = 11;
			// 
			// dtTime
			// 
			this.dtTime.Location = new System.Drawing.Point(304, 16);
			this.dtTime.Maximum = new System.Decimal(new int[] {
																   24,
																   0,
																   0,
																   0});
			this.dtTime.Minimum = new System.Decimal(new int[] {
																   1,
																   0,
																   0,
																   0});
			this.dtTime.Name = "dtTime";
			this.dtTime.Size = new System.Drawing.Size(40, 21);
			this.dtTime.TabIndex = 12;
			this.dtTime.Value = new System.Decimal(new int[] {
																 8,
																 0,
																 0,
																 0});
			// 
			// cmbPoint
			// 
			this.cmbPoint.Location = new System.Drawing.Point(112, 48);
			this.cmbPoint.Name = "cmbPoint";
			this.cmbPoint.Size = new System.Drawing.Size(232, 20);
			this.cmbPoint.TabIndex = 13;
			// 
			// txtTemp1
			// 
			this.txtTemp1.Location = new System.Drawing.Point(112, 80);
			this.txtTemp1.Name = "txtTemp1";
			this.txtTemp1.Size = new System.Drawing.Size(232, 21);
			this.txtTemp1.TabIndex = 14;
			this.txtTemp1.Text = "";
			// 
			// txtTemp2
			// 
			this.txtTemp2.Location = new System.Drawing.Point(112, 112);
			this.txtTemp2.Name = "txtTemp2";
			this.txtTemp2.Size = new System.Drawing.Size(232, 21);
			this.txtTemp2.TabIndex = 15;
			this.txtTemp2.Text = "";
			// 
			// txtFlux
			// 
			this.txtFlux.Location = new System.Drawing.Point(112, 144);
			this.txtFlux.Name = "txtFlux";
			this.txtFlux.Size = new System.Drawing.Size(232, 21);
			this.txtFlux.TabIndex = 16;
			this.txtFlux.Text = "";
			// 
			// txtHeat
			// 
			this.txtHeat.Location = new System.Drawing.Point(112, 176);
			this.txtHeat.Name = "txtHeat";
			this.txtHeat.Size = new System.Drawing.Size(232, 21);
			this.txtHeat.TabIndex = 17;
			this.txtHeat.Text = "";
			// 
			// txtHeatAll
			// 
			this.txtHeatAll.Location = new System.Drawing.Point(112, 208);
			this.txtHeatAll.Name = "txtHeatAll";
			this.txtHeatAll.Size = new System.Drawing.Size(232, 21);
			this.txtHeatAll.TabIndex = 18;
			this.txtHeatAll.Text = "";
			// 
			// txtFluxAll1
			// 
			this.txtFluxAll1.Location = new System.Drawing.Point(112, 240);
			this.txtFluxAll1.Name = "txtFluxAll1";
			this.txtFluxAll1.Size = new System.Drawing.Size(232, 21);
			this.txtFluxAll1.TabIndex = 19;
			this.txtFluxAll1.Text = "";
			// 
			// txtFluxAll2
			// 
			this.txtFluxAll2.Location = new System.Drawing.Point(112, 272);
			this.txtFluxAll2.Name = "txtFluxAll2";
			this.txtFluxAll2.Size = new System.Drawing.Size(232, 21);
			this.txtFluxAll2.TabIndex = 20;
			this.txtFluxAll2.Text = "";
			// 
			// txtFulxInstant
			// 
			this.txtFulxInstant.Location = new System.Drawing.Point(112, 304);
			this.txtFulxInstant.Name = "txtFulxInstant";
			this.txtFulxInstant.Size = new System.Drawing.Size(232, 21);
			this.txtFulxInstant.TabIndex = 21;
			this.txtFulxInstant.Text = "";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(112, 336);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDescription.Size = new System.Drawing.Size(232, 128);
			this.txtDescription.TabIndex = 22;
			this.txtDescription.Text = "";
			// 
			// btnYes
			// 
			this.btnYes.Location = new System.Drawing.Point(200, 480);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(72, 24);
			this.btnYes.TabIndex = 23;
			this.btnYes.Text = "确定";
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(272, 480);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 24);
			this.btnCancel.TabIndex = 24;
			this.btnCancel.Text = "取消";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmDataItems
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(368, 526);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnYes);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.txtFulxInstant);
			this.Controls.Add(this.txtFluxAll2);
			this.Controls.Add(this.txtFluxAll1);
			this.Controls.Add(this.txtHeatAll);
			this.Controls.Add(this.txtHeat);
			this.Controls.Add(this.txtFlux);
			this.Controls.Add(this.txtTemp2);
			this.Controls.Add(this.txtTemp1);
			this.Controls.Add(this.cmbPoint);
			this.Controls.Add(this.dtTime);
			this.Controls.Add(this.dtDate);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDataItems";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmDataItems";
			this.Load += new System.EventHandler(this.frmDataItems_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtTime)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void label3_Click(object sender, System.EventArgs e)
		{
		}

		private void frmDataItems_Load(object sender, System.EventArgs e)
		{
			if(m_bolEdit)
			{
				this.Text="编辑数据";
				LoadStation();
				EditLoad();
			}
			else
			{
				this.Text="添加数据";
				LoadStation();
				cmbPoint.Text=cmbPoint.Items[0].ToString();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void LoadStation()
		{
			string str="select name from PointInfo";
			con=new DBcon();
			SqlCommand cmd=new SqlCommand(str,con.GetConnection());
			SqlDataReader dr=cmd.ExecuteReader();
			while(dr.Read())
			{
				cmbPoint.Items.Add(dr.GetValue(0).ToString().Trim());
			}
			dr.Close();
			
		}
		private void EditLoad()
		{
			DateTime dt;
			try
			{
				con=new DBcon();
				SqlCommand cmd=new SqlCommand("select * from v_PointData where id=@m_id",con.GetConnection());
				cmd.Parameters.Add("@m_id",m_DataID);
				SqlDataReader dr=cmd.ExecuteReader();
				while(dr.Read())
				{
					dt=System.Convert.ToDateTime(dr["DT"]);
					dtDate.Value=dt.Date;
					dtTime.Value=dt.Hour;
//					dtDate.Value=System.Convert.ToDateTime(dr["DT"]);
					cmbPoint.Text=dr["Name"].ToString();
					txtDescription.Text=dr["Description"].ToString();
					txtFlux.Text=dr["Flux"].ToString();
					txtFluxAll1.Text=dr["FluxAll1"].ToString();
					txtFluxAll2.Text=dr["FluxAll2"].ToString();
					txtFulxInstant.Text=dr["FluxInstant"].ToString();
					txtHeat.Text=dr["Heat"].ToString();
					txtHeatAll.Text=dr["HeatAll"].ToString();
					txtTemp1.Text=dr["Temp1"].ToString();
					txtTemp2.Text=dr["Temp2"].ToString();
				}
			
				dr.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void btnYes_Click(object sender, System.EventArgs e)
		{
			if(!CheckDatas())
				return;
			if(m_bolEdit)
				UpdateRecord();
			else
				AddRecord();
			DialogResult =DialogResult.OK ;
			Close();		
		}
		private void UpdateRecord()
		{
			try
			{
				con=new DBcon();
				SqlCommand cmd=new SqlCommand("PointDataUpdate",con.GetConnection());
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.Add("@p_ID",m_DataID);
				cmd.Parameters.Add("@p_PointName",cmbPoint.Text);
				cmd.Parameters.Add("@p_DT",m_DT);
				cmd.Parameters.Add("@p_Temp1",txtTemp1.Text.Trim());
				cmd.Parameters.Add("@p_Temp2",txtTemp2.Text.Trim());
				cmd.Parameters.Add("@p_Flux",txtFlux.Text.Trim());
				cmd.Parameters.Add("@p_Heat",txtHeat.Text.Trim());
				cmd.Parameters.Add("@p_HeatAll",txtHeatAll.Text.Trim());
				cmd.Parameters.Add("@p_FluxAll1",txtFluxAll1.Text.Trim());
				cmd.Parameters.Add("@p_FluxAll2",txtFluxAll2.Text.Trim());
				cmd.Parameters.Add("@p_FluxInstant",txtFulxInstant.Text.Trim());
				cmd.Parameters.Add("@p_Description",txtDescription.Text.Trim());
				cmd.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void AddRecord()
		{
			try
			{
				con=new DBcon();
				SqlCommand cmd=new SqlCommand("PointDataAdd",con.GetConnection());
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Parameters.Add("@p_PointName",cmbPoint.Text.ToString().Trim());
				cmd.Parameters.Add("@p_DT",m_DT);
				cmd.Parameters.Add("@p_Temp1",m_Temp1);
				cmd.Parameters.Add("@p_Temp2",m_Temp2);
				cmd.Parameters.Add("@p_Flux",m_Flux);
				cmd.Parameters.Add("@p_Heat",m_Heat);
				cmd.Parameters.Add("@p_HeatAll",m_HeatAll);
				cmd.Parameters.Add("@p_FluxAll1",m_FluxAll1);
				cmd.Parameters.Add("@p_FluxAll2",m_FluxAll2);
				cmd.Parameters.Add("@p_FluxInstant",m_FluxInstant);
				cmd.Parameters.Add("@p_Description",txtDescription.Text.Trim());
				cmd.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private bool CheckDatas()
		{
			if(cmbPoint.Text=="")
				return false;
			if(dtDate.Value.ToShortDateString()=="")
				return false;
			if(txtTemp1.Text.Trim()=="")
				m_Temp1=0;
			else
				m_Temp1=System.Convert.ToDecimal(txtTemp1.Text.Trim());
			if(txtTemp2.Text.Trim()=="")
				m_Temp2=0;
			else
				m_Temp2=System.Convert.ToDecimal(txtTemp2.Text.Trim());
			if(txtFlux.Text.Trim()=="")
				m_Flux=0;
			else
				m_Flux=System.Convert.ToDecimal(txtFlux.Text.Trim());
			if(txtFluxAll1.Text.Trim()=="")
				m_FluxAll1=0;
			else
				m_FluxAll1=System.Convert.ToDecimal(txtFluxAll1.Text.Trim());
			if(txtFluxAll2.Text.Trim()=="")
				m_FluxAll2=0;
			else
				m_FluxAll2=System.Convert.ToDecimal(txtFluxAll2.Text.Trim());
			if(txtFulxInstant.Text.Trim()=="")
				m_FluxInstant=0;
			else
				m_FluxInstant=System.Convert.ToDecimal(txtFulxInstant.Text.Trim());
			if(txtHeat.Text.Trim()=="")
				m_Heat=0;
			else
				m_Heat=System.Convert.ToDecimal(txtHeat.Text.Trim());
			if(txtHeatAll.Text.Trim()=="")
				m_HeatAll=0;
			else
				m_HeatAll=System.Convert.ToDecimal(txtHeatAll.Text.Trim());
			m_DT=dtDate.Value.ToShortDateString()+" "+dtTime.Value.ToString()+":00:00";
			return true;
			
		}
	}
}
