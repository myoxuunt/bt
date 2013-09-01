using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient ;
using System.Xml;
namespace btGRMain.Grid
{
	/// <summary>
	/// frmData 的摘要说明。
	/// </summary>
	public class frmData : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private string TYPE_DISPLAY="1";
		private System.Windows.Forms.ComboBox cmbID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.DateTimePicker dtDateDown;
		private System.Windows.Forms.DateTimePicker dtDateUp;
		private System.Windows.Forms.ListBox lsbAll;
		private System.Windows.Forms.ListBox lsbChoice;
		private System.Windows.Forms.Button btnIn;
		private System.Windows.Forms.Button btnOut;
		private System.Windows.Forms.Button btnInAll;
		private System.Windows.Forms.Button btnOutAll;
		private int PAGECOUNT1=8;
		private int PAGECOUNT2=16;
		private int m_PageCount;
//		private bool bHaveTime=false;
		private DateTime dtUp;
		private DateTime dtDown;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmData()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnNo = new System.Windows.Forms.Button();
			this.btnYes = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbID = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dtDateDown = new System.Windows.Forms.DateTimePicker();
			this.dtDateUp = new System.Windows.Forms.DateTimePicker();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btnOutAll = new System.Windows.Forms.Button();
			this.btnInAll = new System.Windows.Forms.Button();
			this.btnOut = new System.Windows.Forms.Button();
			this.btnIn = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.lsbAll = new System.Windows.Forms.ListBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.lsbChoice = new System.Windows.Forms.ListBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnNo);
			this.groupBox1.Controls.Add(this.btnYes);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cmbID);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(388, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btnNo
			// 
			this.btnNo.Location = new System.Drawing.Point(300, 18);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(72, 24);
			this.btnNo.TabIndex = 3;
			this.btnNo.Text = "退出";
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// btnYes
			// 
			this.btnYes.Location = new System.Drawing.Point(228, 18);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(72, 24);
			this.btnYes.TabIndex = 2;
			this.btnYes.Text = "整编";
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "选择站点:";
			// 
			// cmbID
			// 
			this.cmbID.Location = new System.Drawing.Point(78, 18);
			this.cmbID.Name = "cmbID";
			this.cmbID.Size = new System.Drawing.Size(108, 20);
			this.cmbID.TabIndex = 0;
			this.cmbID.SelectedIndexChanged += new System.EventHandler(this.cmbID_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.dtDateDown);
			this.groupBox2.Controls.Add(this.dtDateUp);
			this.groupBox2.Location = new System.Drawing.Point(8, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(388, 56);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "数据时间范围";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(186, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "至";
			// 
			// dtDateDown
			// 
			this.dtDateDown.Location = new System.Drawing.Point(228, 24);
			this.dtDateDown.Name = "dtDateDown";
			this.dtDateDown.Size = new System.Drawing.Size(144, 21);
			this.dtDateDown.TabIndex = 3;
			// 
			// dtDateUp
			// 
			this.dtDateUp.Location = new System.Drawing.Point(18, 24);
			this.dtDateUp.Name = "dtDateUp";
			this.dtDateUp.Size = new System.Drawing.Size(144, 21);
			this.dtDateUp.TabIndex = 2;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnOutAll);
			this.groupBox3.Controls.Add(this.btnInAll);
			this.groupBox3.Controls.Add(this.btnOut);
			this.groupBox3.Controls.Add(this.btnIn);
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Controls.Add(this.groupBox5);
			this.groupBox3.Location = new System.Drawing.Point(8, 128);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(388, 352);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "整编数据列";
			// 
			// btnOutAll
			// 
			this.btnOutAll.Location = new System.Drawing.Point(174, 216);
			this.btnOutAll.Name = "btnOutAll";
			this.btnOutAll.Size = new System.Drawing.Size(36, 36);
			this.btnOutAll.TabIndex = 5;
			this.btnOutAll.Text = "all<<";
			this.btnOutAll.Click += new System.EventHandler(this.btnOutAll_Click);
			// 
			// btnInAll
			// 
			this.btnInAll.Location = new System.Drawing.Point(174, 180);
			this.btnInAll.Name = "btnInAll";
			this.btnInAll.Size = new System.Drawing.Size(36, 37);
			this.btnInAll.TabIndex = 4;
			this.btnInAll.Text = "all>>";
			this.btnInAll.Click += new System.EventHandler(this.btnInAll_Click);
			// 
			// btnOut
			// 
			this.btnOut.Location = new System.Drawing.Point(174, 108);
			this.btnOut.Name = "btnOut";
			this.btnOut.Size = new System.Drawing.Size(36, 30);
			this.btnOut.TabIndex = 3;
			this.btnOut.Text = "<<";
			this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
			// 
			// btnIn
			// 
			this.btnIn.Location = new System.Drawing.Point(174, 78);
			this.btnIn.Name = "btnIn";
			this.btnIn.Size = new System.Drawing.Size(36, 30);
			this.btnIn.TabIndex = 2;
			this.btnIn.Text = ">>";
			this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.lsbAll);
			this.groupBox4.Location = new System.Drawing.Point(18, 18);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(144, 324);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "备选列";
			// 
			// lsbAll
			// 
			this.lsbAll.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lsbAll.ItemHeight = 12;
			this.lsbAll.Location = new System.Drawing.Point(3, 17);
			this.lsbAll.Name = "lsbAll";
			this.lsbAll.Size = new System.Drawing.Size(138, 304);
			this.lsbAll.TabIndex = 0;
			this.lsbAll.DoubleClick += new System.EventHandler(this.lsbAll_DoubleClick);
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.lsbChoice);
			this.groupBox5.Location = new System.Drawing.Point(228, 18);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(144, 324);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "打印列";
			// 
			// lsbChoice
			// 
			this.lsbChoice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lsbChoice.ItemHeight = 12;
			this.lsbChoice.Location = new System.Drawing.Point(3, 17);
			this.lsbChoice.Name = "lsbChoice";
			this.lsbChoice.Size = new System.Drawing.Size(138, 304);
			this.lsbChoice.TabIndex = 0;
			this.lsbChoice.DoubleClick += new System.EventHandler(this.lsbChoice_DoubleClick);
			// 
			// frmData
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(408, 495);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmData";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmData";
			this.Load += new System.EventHandler(this.frmData_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmData_Load(object sender, System.EventArgs e)
		{
			this.Text="数据整编";
			LoadStation();
		}
		private void LoadStation()
		{
			dtDateDown.Value=dtDateUp.Value.AddDays(1);
			string str="select Name from V_heatDatas Group by name";
			DBcon con=new DBcon();
			SqlCommand cmd=new SqlCommand(str,con.GetConnection());
			SqlDataReader dr=cmd.ExecuteReader();
			while(dr.Read())
			{
				cmbID.Items.Add(dr.GetValue(0).ToString().Trim());
			}
			dr.Close();
			m_PageCount=1;
			cmbID.Items.Add("<全部站点>");
		}
		private void LoadInformation()
		{
			lsbAll.Items.Clear();
			XmlDocument xDoc=new XmlDocument();
			xDoc.Load("DataInfo.xml");
			XmlNode xNode=xDoc.DocumentElement.SelectSingleNode("./table[@Name='DataInfo']");
			for(int i=0;i<xNode.ChildNodes.Count;i++)
			{
				XmlNode xNodeC=xNode.ChildNodes[i];
				if(xNodeC.Attributes.GetNamedItem("nu").Value.ToString().Trim()==TYPE_DISPLAY)
					continue;
				lsbAll.Items.Add(xNodeC.InnerText.Trim());
			}
		}
		private bool CheckDatas()
		{
			if(lsbChoice.Items.Count==0)
			{
				MessageBox.Show("请选择整编数据类型!","错误",MessageBoxButtons.OK ,MessageBoxIcon.Error);
				return false;
			}
//			if(!bHaveTime)
//			{
//				MessageBox.Show("必须存在时间列!","错误",MessageBoxButtons.OK ,MessageBoxIcon.Error);
//				return false;
//			}
			dtUp=dtDateUp.Value.Date;
			dtDown=dtDateDown.Value.Date;
			if(dtUp>dtDown)
			{
				MessageBox.Show("时间条件错误!","错误",MessageBoxButtons.OK ,MessageBoxIcon.Error);
				return false;
			}	
			return true;	
		}

		private void cmbID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lsbAll.Items.Clear();
			lsbChoice.Items.Clear();
			LoadInformation();
		}

		private void btnIn_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(lsbAll.SelectedItems.Count==0)
				{
					return;
				}

				int iCount=lsbAll.SelectedItems.Count;
				for(int i=0;i<iCount;i++)
				{
//					if(this.lsbAll.SelectedItems[0].ToString()!="时间")
//					{
						lsbChoice.Items.Add(lsbAll.SelectedItems[0].ToString());
//					}	
//					else
//					{
//						bHaveTime=true;
//					}
					this.lsbAll.Items.Remove(lsbAll.SelectedItems[0]);
				}
//				if(bHaveTime)
//				{
//					lsbChoice.Items.Add("时间");
//				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void lsbAll_DoubleClick(object sender, System.EventArgs e)
		{
			btnIn_Click(sender,e);
		}

		private void btnOut_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(lsbChoice.SelectedItems.Count==0)
				{
					return;
				}
				int iCount=lsbChoice.SelectedItems.Count;
				for(int i=0;i<iCount;i++)
				{
					lsbAll.Items.Add(lsbChoice.SelectedItems[0].ToString());
					lsbChoice.Items.Remove(lsbChoice.SelectedItems[0]);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void lsbChoice_DoubleClick(object sender, System.EventArgs e)
		{
			btnOut_Click(sender,e);
		}

		private void btnInAll_Click(object sender, System.EventArgs e)
		{
			if(lsbAll.Items.Count==0)
				return;
			lsbChoice.Items.Clear();
			LoadInformation();
			lsbChoice.Items.AddRange(lsbAll.Items);
//			bHaveTime=true;
			lsbAll.Items.Clear();
		}

		private void btnOutAll_Click(object sender, System.EventArgs e)
		{
			if(lsbChoice.Items.Count==0)
				return;
			lsbChoice.Items.Clear();
//			bHaveTime=false;
			lsbAll.Items.Clear();
			LoadInformation();
		}

		private void btnNo_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnYes_Click(object sender, System.EventArgs e)
		{
			if(!CheckDatas())
				return;
			string[] s_curveInfo=new string[lsbChoice.Items.Count];
			m_PageCount=1;
			if(lsbChoice.Items.Count>PAGECOUNT1)
			{
				if(lsbChoice.Items.Count>PAGECOUNT2)
					m_PageCount=3;
				else
					m_PageCount=2;
			}
			for(int i=0;i<lsbChoice.Items.Count;i++)
			{
				s_curveInfo[i]=lsbChoice.Items[i].ToString();
			}
			string HeatName=cmbID.Text;
			if(HeatName=="<全部站点>")
				HeatName="*";
			frmDataPrint f=new frmDataPrint(dtUp,dtDown,s_curveInfo,m_PageCount,HeatName);		
			f.ShowDialog();
		}
	}
}
