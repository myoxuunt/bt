using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace btGRMain.User
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class frmUser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton tbAdd;
		private System.Windows.Forms.ToolBarButton tbEdit;
		private System.Windows.Forms.ToolBarButton tbDelete;
		private System.Windows.Forms.ToolBarButton tbExit;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.DataGrid m_dataGrid;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBarButton tbnFont;
		private bool b_DG=false;
		public frmUser()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUser));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbAdd = new System.Windows.Forms.ToolBarButton();
            this.tbEdit = new System.Windows.Forms.ToolBarButton();
            this.tbDelete = new System.Windows.Forms.ToolBarButton();
            this.tbnFont = new System.Windows.Forms.ToolBarButton();
            this.tbExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_dataGrid = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                        this.tbAdd,
                                                                                        this.tbEdit,
                                                                                        this.tbDelete,
                                                                                        this.tbnFont,
                                                                                        this.tbExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(600, 41);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbAdd
            // 
            this.tbAdd.ImageIndex = 0;
            this.tbAdd.Text = "���";
            // 
            // tbEdit
            // 
            this.tbEdit.ImageIndex = 1;
            this.tbEdit.Text = "�༭";
            // 
            // tbDelete
            // 
            this.tbDelete.ImageIndex = 2;
            this.tbDelete.Text = "ɾ��";
            // 
            // tbnFont
            // 
            this.tbnFont.ImageIndex = 4;
            this.tbnFont.Text = "����";
            this.tbnFont.Visible = false;
            // 
            // tbExit
            // 
            this.tbExit.ImageIndex = 3;
            this.tbExit.Text = "�˳�";
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // m_dataGrid
            // 
            this.m_dataGrid.DataMember = "";
            this.m_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGrid.Location = new System.Drawing.Point(0, 41);
            this.m_dataGrid.Name = "m_dataGrid";
            this.m_dataGrid.ReadOnly = true;
            this.m_dataGrid.Size = new System.Drawing.Size(600, 348);
            this.m_dataGrid.TabIndex = 2;
            // 
            // frmUser
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(600, 389);
            this.Controls.Add(this.m_dataGrid);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmUser";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
//		static void Main() 
//		{
//			Application.Run(new frmUser());
//		}

		private void frmUser_Load(object sender, System.EventArgs e)
		{
			InitializeGridTitle();
			LoadDataGrid();
		}

		private void InitializeGridTitle()
		{
			DataGridTableStyle tbs= new DataGridTableStyle();
			DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
			clm.MappingName="id";
			clm.HeaderText="���";
			clm.Width=60;
			tbs.GridColumnStyles.Add(clm);

			clm=new DataGridTextBoxColumn();
			clm.MappingName="name";
			clm.HeaderText="�û���";
			clm.Width=100;
			tbs.GridColumnStyles.Add(clm);

			clm=new DataGridTextBoxColumn();
			clm.MappingName="password";
			clm.HeaderText="����";
			clm.Width=150;
			tbs.GridColumnStyles.Add(clm);

			clm=new DataGridTextBoxColumn();
			clm.MappingName="description";
			clm.HeaderText="��ע";
			clm.Width=this.Width-360;
			tbs.GridColumnStyles.Add(clm);

			tbs.MappingName ="User";
			this.m_dataGrid.TableStyles.Add(tbs);
		}

		private void LoadDataGrid()
		{
			try
			{
				DBcon con=new DBcon();
				string str="select * from tbWUser";
				SqlCommand cmd=new SqlCommand(str,con.GetConnection());
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
				DataSet ds=new DataSet();
				da.Fill(ds,"User");
				da.Dispose();			
				this.m_dataGrid.DataSource=ds.Tables["User"];
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void ChangeFont()
		{
			FontDialog fd = new FontDialog();
			fd.Font = this.m_dataGrid.Font;
			if ( fd.ShowDialog(this) == DialogResult.OK )
			{
				m_dataGrid.Font = fd.Font;
			}
		}

		private void RefreshTitle(bool bdg)
		{
			if(!b_DG)
			{
				DataGridTableStyle tbs= new DataGridTableStyle();
				DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
				clm.MappingName="id";
				clm.HeaderText="���";
				clm.Width=60;
				tbs.GridColumnStyles.Add(clm);

				clm=new DataGridTextBoxColumn();
				clm.MappingName="name";
				clm.HeaderText="�û���";
				clm.Width=100;
				tbs.GridColumnStyles.Add(clm);

				clm=new DataGridTextBoxColumn();
				clm.MappingName="password";
				clm.HeaderText="����";
				clm.Width=150;
				tbs.GridColumnStyles.Add(clm);

				clm=new DataGridTextBoxColumn();
				clm.MappingName="description";
				clm.HeaderText="��ע";
				clm.Width=this.Width-360;
				tbs.GridColumnStyles.Add(clm);

				tbs.MappingName ="UserNew";
				this.m_dataGrid.TableStyles.Add(tbs);
			}
		}
		private void RefreshDataGrid()
		{
			try
			{
				DBcon con=new DBcon();
				string str="select * from tbWUser";
				SqlCommand cmd=new SqlCommand(str,con.GetConnection());
				cmd.ExecuteNonQuery();
				cmd.Dispose();
				SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
				DataSet ds=new DataSet();
				da.Fill(ds,"UserNew");
				da.Dispose();
				RefreshTitle(b_DG);
				this.m_dataGrid.DataSource=ds.Tables["UserNew"];
				b_DG=true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch(e.Button.Text.Trim())
			{
				case "���":
					Add();
					break; 
				case "�༭":
					Edit ();
					break; 
				case "ɾ��":
					Delete();
					break; 
				case "�˳�":
					this.Close();
					break;
				case "����":
					ChangeFont();
					break;
			}
		}

		private void Add()
		{
			frmUserItem f= new frmUserItem();
			if(f.ShowDialog()==DialogResult.OK)
				RefreshDataGrid();
		}

		private void Edit()
		{
			if(NoRecordDataGrid()) {return;}
			int row=m_dataGrid.CurrentCell.RowNumber;
			int col=1;
			string UserName=m_dataGrid[row,col].ToString().ToString().Trim();
			if(UserName==null)
			{
				MessageBox.Show("����ȷѡ����Ҫ�༭���û���!","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			frmUserItem f = new frmUserItem(UserName);
			if(DialogResult.OK==f.ShowDialog())
				RefreshDataGrid();
		}

		private void Delete()
		{
			if(NoRecordDataGrid()) {return;}
			
			int row=m_dataGrid.CurrentCell.RowNumber;
			int col=1;
			string UserName=m_dataGrid[row,col].ToString().ToString().Trim();
			if(UserName==null)
			{
				MessageBox.Show("����ȷѡ����Ҫɾ����������!","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return ;
			}

			if(MessageBox.Show("ȷ��Ҫɾ����������?","��ʾ",MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes){	return ;}
			row=m_dataGrid.CurrentCell.RowNumber;
			col=0;
			DBcon con=new DBcon();
			int id=Convert.ToInt32(m_dataGrid[row,col].ToString());
			SqlCommand sqlCmd=new SqlCommand("DELETE FROM tbWUser WHERE ID=" + id,con.GetConnection());
			sqlCmd.ExecuteNonQuery();
			sqlCmd.Dispose();
			RefreshDataGrid();
		}
		private bool NoRecordDataGrid()
		{
			return -1==m_dataGrid.CurrentRowIndex;
		}
	}
}
