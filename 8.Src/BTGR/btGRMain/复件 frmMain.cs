using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using btGR;
namespace btGRMain
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private DataSet ds=null;
		private DataTable dt=null;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TreeView tvUser;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label labUser;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private int m_UID;
		private System.Windows.Forms.Label labDQYH;
		private System.ComponentModel.IContainer components;

		public frmMain()
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
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.tvUser = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.labDQYH = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.labUser = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.tvUser);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 56);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(112, 493);
			this.panel1.TabIndex = 16;
			// 
			// tvUser
			// 
			this.tvUser.BackColor = System.Drawing.SystemColors.Control;
			this.tvUser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvUser.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tvUser.ImageList = this.imageList1;
			this.tvUser.Location = new System.Drawing.Point(0, 0);
			this.tvUser.Name = "tvUser";
			this.tvUser.SelectedImageIndex = 1;
			this.tvUser.Size = new System.Drawing.Size(112, 493);
			this.tvUser.TabIndex = 0;
			this.tvUser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvUser_AfterSelect);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(112, 56);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(4, 493);
			this.splitter1.TabIndex = 18;
			this.splitter1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(0, 56);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(1028, 493);
			this.pictureBox2.TabIndex = 13;
			this.pictureBox2.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.Controls.Add(this.labDQYH);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Controls.Add(this.labUser);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1028, 56);
			this.panel2.TabIndex = 6;
			// 
			// labDQYH
			// 
			this.labDQYH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labDQYH.AutoSize = true;
			this.labDQYH.Location = new System.Drawing.Point(948, 32);
			this.labDQYH.Name = "labDQYH";
			this.labDQYH.Size = new System.Drawing.Size(42, 17);
			this.labDQYH.TabIndex = 13;
			this.labDQYH.Text = "NoUser";
			this.labDQYH.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(884, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 17);
			this.label1.TabIndex = 12;
			this.label1.Text = "当前用户:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(1028, 56);
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// labUser
			// 
			this.labUser.AutoSize = true;
			this.labUser.BackColor = System.Drawing.SystemColors.Control;
			this.labUser.Location = new System.Drawing.Point(944, 24);
			this.labUser.Name = "labUser";
			this.labUser.Size = new System.Drawing.Size(0, 17);
			this.labUser.TabIndex = 8;
			this.labUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.Location = new System.Drawing.Point(882, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 17);
			this.label2.TabIndex = 7;
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1028, 549);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.panel2);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IsMdiContainer = true;
			this.KeyPreview = true;
			this.Name = "frmMain";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			this.Text="  包头市第二热电厂青山供热热网监控系统";
			LoginSystem();
		}

		private void LoginSystem()
		{
			this.panel1.Visible =false;
			this.splitter1.Visible=false;
			frmLogin f=new frmLogin();
			f.Text=" 登录";
			f.ShowDialog();
			if(frmLogin.m_Login==true)
			{
				labDQYH.Text=frmLogin.m_UserName+" ";
				m_UID=frmLogin.m_UserID;
				InitializeSystem();
			}
			else
				this.Close();
		}

		private void InitializeSystem()
		{
			this.panel1.Visible=!panel1.Visible;
			this.splitter1.Visible=!splitter1.Visible;
			InitializeCon(m_UID);
			LoadTree();
			InitializeFrm();
//			MdiGIS();
		}

		private void MdiGIS()
		{
			btGR.frmGisMain f=new frmGisMain();
			f.MdiParent=this;
			f.FormBorderStyle=System.Windows.Forms.FormBorderStyle.None;
			f.Show();

		}
		private void InitializeCon(int index)
		{
			try
			{
				DBcon con=new DBcon();
				string str="select * from V_UserFunction where userID="+index+" order by ID";
				SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
				ds=new DataSet();
				da.Fill(ds,"UserFunction");
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void LoadTree()
		{
			tvUser.Nodes.Clear();
			try
			{				
				dt=ds.Tables["UserFunction"];
				if(dt.Rows.Count==0)
					return;
				
				for(int i=0;i<dt.Rows.Count;i++)
				{
					if(System.Convert.ToInt32(dt.Rows[i]["FatherID"])==0)
					{
						TreeNode tn=new TreeNode(dt.Rows[i]["name"].ToString());
						int fatherID=System.Convert.ToInt32(dt.Rows[i]["ID"].ToString());
						tvUser.Nodes.Add(tn);
						CreateTreeNode(tn,fatherID);
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void CreateTreeNode(TreeNode parent,int FatherID)
		{
			try
			{				
				for(int i=0;i<dt.Rows.Count;i++)
				{
					if(System.Convert.ToInt32(dt.Rows[i]["FatherID"])==FatherID)
					{
						TreeNode tn=new TreeNode(dt.Rows[i]["name"].ToString());
						parent.Nodes.Add(tn);
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void InitializeFrm()
		{
//			try
//			{
//				if(tvUser.Nodes[0].Text=="地图信息")
//					tvUser.SelectedNode=tvUser.Nodes[0];
//			}
//			catch(Exception ex)
//			{
//				MessageBox.Show("加载菜单没有成功！");
//			}
		}

		private void frmMain_MdiChildActivate(object sender, System.EventArgs e)
		{
			if(this.ActiveMdiChild==null)
				this.pictureBox2.Visible=true;
			else
				this.pictureBox2.Visible=false;
		}

		private void tvUser_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				if(tvUser.SelectedNode!=null)
				{
					if(tvUser.SelectedNode.Text=="地图信息")
					{
						if(this.checkChildFrmExist("地图监视")==true)
						{
							return;
						}
						btGR.frmGisMain f=new frmGisMain();
						f.Text="地图监视";
						f.MdiParent=this;
						f.WindowState=FormWindowState.Maximized;
						//					f.FormBorderStyle=System.Windows.Forms.FormBorderStyle.None;
						f.Show();
					}
					// 巡更系统菜单
					if(tvUser.SelectedNode.Text=="TM卡管理")
					{
						if(this.checkChildFrmExist("TM卡管理")==true)
						{
							return;
						}
					}
					if(tvUser.SelectedNode.Text=="任务管理")
					{
						if(this.checkChildFrmExist("任务管理")==true)
						{
							return;
						}
					}
					if(tvUser.SelectedNode.Text=="数据管理")
					{
						if(this.checkChildFrmExist("巡更数据管理")==true)
						{
							return;
						}
					}
					if(tvUser.SelectedNode.Text=="任务执行结果")
					{
						if(this.checkChildFrmExist("巡更任务执行结果")==true)
						{
							return;
						}
					}

					//供热系统菜单
					if(tvUser.SelectedNode.Text=="采集设置")
					{
						if(this.checkChildFrmExist("供热系统采集设置")==true)
							return;
					}
					if(tvUser.SelectedNode.Text=="控制参数设置")
					{
						if(this.checkChildFrmExist("供热系统控制参数设置")==true)
							return;
					}
					if(tvUser.SelectedNode.Text=="实时数据")
					{
						if(this.checkChildFrmExist("供热系统实时采集数据")==true)
						{
							return;
						}
					}
					if(tvUser.SelectedNode.Text=="历史数据")
					{
						if(this.checkChildFrmExist("供热系统数据查询")==true)
						{
							return;
						}
						//					DataCurve.Grid.frmData f=new DataCurve.Grid.frmData();
						//					f.Text="供热系统数据查询";
						//					f.ShowDialog();
						DataCurve.Grid.frmDataPrint f=new DataCurve.Grid.frmDataPrint();
						f.Text="供热系统数据查询";
						f.MdiParent=this;
						f.WindowState=FormWindowState.Maximized;
						f.Show();
					}
					if(tvUser.SelectedNode.Text=="历史曲线")
					{
						if(this.checkChildFrmExist("供热系统数据曲线")==true)
						{
							return;
						}
						DataCurve.Curve.frmCurve f=new DataCurve.Curve.frmCurve();
						f.Text="供热系统数据曲线";
						f.MdiParent=this;
						f.WindowState=FormWindowState.Maximized;
						f.Show();
					}
				
					if(tvUser.SelectedNode.Text=="用户管理")
					{
						if(this.checkChildFrmExist("用户管理")==true)
						{
							return;
						}
						UserManage.frmUser f=new UserManage.frmUser();
						f.Text="用户管理";
						f.MdiParent=this;
						f.WindowState=FormWindowState.Maximized;
						f.Show();
					}
					if(tvUser.SelectedNode.Text=="站点管理")
					{
						if(this.checkChildFrmExist("站点管理")==true)
							return;
					}
					if(tvUser.SelectedNode.Text=="GPRS管理")
					{
						if(this.checkChildFrmExist("GPRS连接管理")==true)
							return;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private bool checkChildFrmExist(string childFrmText)
		{
			try
			{
				foreach(Form childFrm in this.MdiChildren)
				{
					//用子窗体的Name进行判断，如果已经存在则将他激活
					if(childFrm.Text == childFrmText)
					{
						if(childFrm.WindowState == FormWindowState.Minimized)
							childFrm.WindowState = FormWindowState.Normal;
						childFrm.Activate();
						return true;
					}
					
				}
				return false;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());

				return false;
			}
		}
	}
}
