using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using btGR;
using UICOMM;
using Utilities;

namespace btGRMain
{
    /// <summary>
    /// Form1 ��ժҪ˵����
    /// </summary>
    public class frmMain : System.Windows.Forms.Form
    {
        private DataSet ds=null;
        private DataTable dt=null;
        private int m_UID;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvUser;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        private System.Windows.Forms.StatusBarPanel statusBarPanel4;
		private System.Windows.Forms.StatusBarPanel sbpVersion;
        private System.ComponentModel.IContainer components;

        public event BTGRUIEventHandler UIEventHandler;


        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public frmMain()
        {
            //
            // Windows ���������֧���������
            //
            InitializeComponent();

            //
            // TODO: �� InitializeComponent ���ú�����κι��캯������
            //
        }
        #endregion //Constructor

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.sbpVersion = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel4 = new System.Windows.Forms.StatusBarPanel();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.tvUser = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpVersion)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 583);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1,
																						  this.sbpVersion,
																						  this.statusBarPanel3,
																						  this.statusBarPanel4});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(1028, 22);
			this.statusBar1.TabIndex = 20;
			// 
			// statusBarPanel1
			// 
			this.statusBarPanel1.Text = " ��ɽ�ִ����ؼ������޹�˾  ";
			this.statusBarPanel1.Width = 200;
			// 
			// sbpVersion
			// 
			this.sbpVersion.Text = " �������ϵͳ �汾��R07.2.7";
			this.sbpVersion.Width = 200;
			// 
			// statusBarPanel3
			// 
			this.statusBarPanel3.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel3.Width = 412;
			// 
			// statusBarPanel4
			// 
			this.statusBarPanel4.Text = "��ǰ�û���";
			this.statusBarPanel4.Width = 200;
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
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(112, 583);
			this.panel1.TabIndex = 23;
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
			this.tvUser.Size = new System.Drawing.Size(112, 583);
			this.tvUser.TabIndex = 0;
			this.tvUser.DoubleClick += new System.EventHandler(this.tvUser_DoubleClick);
			this.tvUser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvUser_AfterSelect);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(112, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(4, 583);
			this.splitter1.TabIndex = 25;
			this.splitter1.TabStop = false;
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1028, 605);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusBar1);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.IsMdiContainer = true;
			this.KeyPreview = true;
			this.Name = "frmMain";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpVersion)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel4)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
        #endregion

        /// <summary>
        /// Ӧ�ó��������ڵ㡣
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new frmMain());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            this.Hide();
            this.Text="��ͷ�еڶ��ȵ糧��ɽ�����������ϵͳ";
			this.sbpVersion.Text = string.Format("�汾: {0}", Application.ProductVersion );
            LoginSystem();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoginSystem()
        {
            this.panel1.Visible = false;
            this.splitter1.Visible = false;
            frmLogin f=new frmLogin();
            f.Text=" ��¼";
            f.ShowDialog();
            if(frmLogin.m_Login==true)
            {
                this.Show();
                this.statusBarPanel4.Text = "��ǰ�û���" + frmLogin.m_UserName;
                m_UID = frmLogin.m_UserID;
                InitializeSystem();
            }
            else
                this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeSystem()
        {
            this.panel1.Visible=!panel1.Visible;
            this.splitter1.Visible=!splitter1.Visible;
            InitializeCon(m_UID);
            LoadTree();
            InitializeFrm();
            //MdiGIS();
        }

        /// <summary>
        /// 
        /// </summary>
        private void MdiGIS()
        {
            btGR.frmGisMain f=new frmGisMain();
            f.MdiParent=this;
            f.FormBorderStyle=System.Windows.Forms.FormBorderStyle.None;
            f.Show();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
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
                // 2007.05.30
                //
                //MessageBox.Show("�û�Ȩ�޶�ȡʧ��!","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("�û�Ȩ�޶�ȡʧ��!", ex );
            }
        }

        /// <summary>
        /// 
        /// </summary>
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
                // 2007.05.30
                //
                //MessageBox.Show("�˵�����ʧ��!","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("�˵�����ʧ��!", ex );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="FatherID"></param>
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
                // 2007.05.30
                //
                //MessageBox.Show("�˵�����ʧ��!","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("�˵�����ʧ��!", ex );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void InitializeFrm()
        {
            //			try
            //			{
            //				if(tvUser.Nodes[0].Text=="��ͼ��Ϣ")
            //					tvUser.SelectedNode=tvUser.Nodes[0];
            //			}
            //			catch(Exception ex)
            //			{
            //				MessageBox.Show("���ز˵�û�гɹ���");
            //			}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_MdiChildActivate(object sender, System.EventArgs e)
        {
//            if(this.ActiveMdiChild==null)
//                this.pictureBox2.Visible=true;
//            else
//                this.pictureBox2.Visible=false;
        }

        private bool checkChildFrmExist(string childFrmText)
        {
            try
            {
                foreach(Form childFrm in this.MdiChildren)
                {
                    //���Ӵ����Name�����жϣ�����Ѿ�������������
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
                // 2007.05.30
                //
                //MessageBox.Show("���������,��������������!","����",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("���������,��������������!", ex );

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(frmLogin.m_Login==true)
            {
                DialogResult DR=MessageBox.Show(
                    "��ȷ��Ҫ�˳��������ϵͳ��?",
                    "��ʾ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if(DR == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    //�¼�ȡ��
                    e.Cancel=true;    
                }

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvUser_AfterSelect_1(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
		
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvUser_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if(tvUser.SelectedNode!=null)
                {
                    if(tvUser.SelectedNode.Text=="��ͼ��Ϣ")
                    {
                        if(this.checkChildFrmExist("��ͼ����")==true)
                        {
                            return;
                        }
                        btGR.frmGisMain f=new frmGisMain();
                        f.Text="��ͼ����";
                        f.MdiParent=this;
                        f.WindowState=FormWindowState.Maximized;
                        //f.FormBorderStyle=System.Windows.Forms.FormBorderStyle.None;
                        f.Show();
                    }
                    // Ѳ��ϵͳ�˵�
                    if(tvUser.SelectedNode.Text=="TM������")
                    {
                        //if(this.checkChildFrmExist("TM������")==true)
                        //{
                        //return;
                        //}

                        if ( this.UIEventHandler != null )
                        {
                            UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs( UIFunctionCode.XGTMCardManager, null );
                            UIEventHandler( this, args );
                        }
                    }
                    //if(tvUser.SelectedNode.Text=="�������")
                    //{
                    //if(this.checkChildFrmExist("�������")==true)
                    //{
                    //return;
                    //}
                    //if ( this.UIEventHandler != null )
                    //{
                    //UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs( UIFunctionCode.XGTaskManager , null );
                    //UIEventHandler( this, args );
                    //}
                    //
                    //}
                    if(tvUser.SelectedNode.Text=="���ݹ���")
                    {
                        if(this.checkChildFrmExist("Ѳ�����ݹ���")==true)
                        {
                            return;
                        }
                        if ( this.UIEventHandler != null )
                        {
                            UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs( UIFunctionCode.XGDataManager , null );
                            UIEventHandler( this, args );
                        }
                    }
                    //if(tvUser.SelectedNode.Text=="����ִ�н��")
                    //{
                    //if(this.checkChildFrmExist("Ѳ������ִ�н��")==true)
                    //{
                    //return;
                    //}
                    //
                    //if ( this.UIEventHandler != null )
                    //{
                    //UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs( UIFunctionCode.XGTaskResultManager , null );
                    //UIEventHandler( this, args );
                    //
                    //}
                    //}

                    //����ϵͳ�˵�
                    if(tvUser.SelectedNode.Text=="�ɼ�����")
                    {
                        //						if(this.checkChildFrmExist("����ϵͳ�ɼ�����")==true)
                        //							return;
                        if ( this.UIEventHandler != null )
                        {
                            UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs( UIFunctionCode.GRCollSet, null );
                            UIEventHandler( this, args );
                        }
  
                    }

                    if(tvUser.SelectedNode.Text=="��ˮ����")
                    {
                        if(this.checkChildFrmExist("��ˮ���ݲ�ѯ")==true)
                            return;
                        frmAddPumpDatas f=new frmAddPumpDatas();
                        f.Text="��ˮ���ݲ�ѯ";
                        f.MdiParent=this;
                        f.WindowState=FormWindowState.Maximized;
                        f.Show();
                    }
					
                    if(tvUser.SelectedNode.Text=="��������")
                    {
                        /////////
                        if ( this.UIEventHandler != null )
                        {
                            UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs( UIFunctionCode.GRAlarmDataManager, null );
                            UIEventHandler ( this, args );

                        }
                    }

                    if(tvUser.SelectedNode.Text=="ʵʱ����")
                    {
                        //if(this.checkChildFrmExist("����ϵͳʵʱ�ɼ�����")==true)
                        //{
                        //return;
                        //}
                        if ( this.UIEventHandler != null )
                        {
                            UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs( UIFunctionCode.GRRealDataManager , null );
                            UIEventHandler( this, args );
                        }
                    }

                    if(tvUser.SelectedNode.Text=="һ������ˮ����")
                    {
                        if(this.checkChildFrmExist("һ������ˮ����")==true)
                        {
                            return;
                        }
                        Curve.frmCurveData f=new Curve.frmCurveData();
                        f.Text="һ������ˮ����";
                        f.ShowDialog();
                    }


                    if(tvUser.SelectedNode.Text=="��ʷ����")
                    {
                        if(this.checkChildFrmExist("����ϵͳ���ݲ�ѯ")==true)
                        {
                            return;
                        }

                        //DataCurve.Grid.frmData f=new DataCurve.Grid.frmData();
                        //f.Text="����ϵͳ���ݲ�ѯ";
                        //f.ShowDialog();
                        Grid.frmDataPrint f=new Grid.frmDataPrint();
                        f.Text="����ϵͳ���ݲ�ѯ";
                        f.MdiParent=this;
                        f.WindowState=FormWindowState.Maximized;
                        f.Show();
                    }

                    if(tvUser.SelectedNode.Text=="��ʷ����")
                    {
                        if(this.checkChildFrmExist("����ϵͳ��������")==true)
                        {
                            return;
                        }
                        Curve.frmCurve f=new Curve.frmCurve();
                        f.Text="����ϵͳ��������";
                        f.MdiParent=this;
                        f.WindowState=FormWindowState.Maximized;
                        f.Show();
                    }

                    //����
                    if(tvUser.SelectedNode.Text=="��ý����ͳ���ձ���")
                    {
                        if(this.checkChildFrmExist("��ý����ͳ���ձ���")==true)
                        {
                            return;
                        }
                        frmRMDatas  f=new frmRMDatas();
                        f.Text="��ý����ͳ���ձ���";
                        f.MdiParent=this;
                        f.WindowState=FormWindowState.Maximized;
                        f.Show();
                    }

                    if(tvUser.SelectedNode.Text=="��ˮ����ͳ�Ʒ�������")
                    {
                        if(this.checkChildFrmExist("��ˮ����ͳ�Ʒ�������")==true)
                        {
                            return;
                        }
                        frmAddPumpDatas f=new frmAddPumpDatas();
                        f.Text="��ˮ����ͳ�Ʒ�������";
                        f.MdiParent=this;
                        f.WindowState=FormWindowState.Maximized;
                        f.Show();
                    }

                    if(tvUser.SelectedNode.Text=="��ͳ�������ݷ�������")
                    {
                        if(this.checkChildFrmExist("��ͳ�������ݷ�������")==true)
                        {
                            return;
                        }
                        frmFactoryDatas f=new frmFactoryDatas();
                        f.Text="��ͳ�������ݷ�������";
                        f.MdiParent=this;
                        f.WindowState=FormWindowState.Maximized;
                        f.Show();
                    }
                    if(tvUser.SelectedNode.Text=="����ģ�����߷���")
                    {
                        if(this.checkChildFrmExist("����ģ������")==true)
                        {
                            return;
                        }
                        Curve.frmModelCurve f=new Curve.frmModelCurve();
                        f.Text="����ģ������";
                        f.MdiParent=this;
                        f.WindowState=FormWindowState.Maximized;
                        f.Show();
                    }


                    if(tvUser.SelectedNode.Text=="�û�����")
                    {
                        if(this.checkChildFrmExist("�û�����")==true)
                        {
                            return;
                        }
                        User.frmUser f=new User.frmUser();
                        f.Text="�û�����";
                        f.MdiParent=this;
                        f.WindowState=FormWindowState.Maximized;
                        f.Show();
                    }
                    if(tvUser.SelectedNode.Text=="վ�����")
                    {
                        if(this.checkChildFrmExist("վ�����")==true)
                            return;
                        if ( this.UIEventHandler != null )
                        {
                            UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs( UIFunctionCode.StationManager , null );
                            UIEventHandler( this, args );
                        }
                    }

                    if(tvUser.SelectedNode.Text=="GPRS����")
                    {
                        //						if(this.checkChildFrmExist("GPRS���ӹ���")==true)
                        //							return;
                        if ( this.UIEventHandler != null )
                        {
                            UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs( UIFunctionCode.GprsConnManager , null );
                            UIEventHandler( this, args );
                        }
                    }

                    if ( tvUser.SelectedNode.Text == "Զ�̿���" )
                    {
                        if ( this.UIEventHandler != null )
                        {
                            UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs( UIFunctionCode.GRCtrlSet, null );
                            UIEventHandler ( this, args );
                        }
                    }   

                    if ( tvUser.SelectedNode.Text == "�����¶�����" )
                    {
                        if ( this.UIEventHandler != null )
                        {
                            UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs( UIFunctionCode.GRSetOutSideTemperature, null );
                            UIEventHandler( this, args );
                        }
                    }

                    if ( tvUser.SelectedNode.Text == "Ѳ��ʱ������" )
                    {
                        if ( this.UIEventHandler != null )
                        {
                            UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs(
                                UIFunctionCode.XGDateTimeSetting,
                                null
                                );
                            UIEventHandler( this, args );
                        }
                    }
                }
            }
            catch(Exception ex)
            {
				MessageBox.Show(ex.ToString() ,"����",
					MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void tvUser_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
        }

		private void button1_Click(object sender, System.EventArgs e)
		{
			if ( this.UIEventHandler != null )
			{
				UICOMM.BTGRUIEventArgs args = new BTGRUIEventArgs(
					UIFunctionCode.XGDateTimeSetting,
					null
					);
				UIEventHandler( this, args );
			}
		}

        #region LI
        /// <summary>
        /// ��ȡ��ʾ�ɼ�״̬��StatueBarPanel
        /// </summary>
        public StatusBarPanel GprsCollStateSbr
        {
            get { return this.statusBarPanel3; }
        }
        #endregion //LI

    }
	
}
