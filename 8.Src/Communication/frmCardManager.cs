namespace Communication
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;

    #region frmCardManager
    /// <summary>
    /// frmCardManager 的摘要说明。
    /// </summary>
    public class frmCardManager : System.Windows.Forms.Form
    {
        #region Members
        private System.Windows.Forms.DataGrid dataGridCards;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbbAdd;
        private System.Windows.Forms.ToolBarButton tbbEdit;
        private System.Windows.Forms.ToolBarButton tbbDelete;
        private System.Windows.Forms.ToolBarButton tbbExit;
        private System.ComponentModel.IContainer components;
        #endregion //Members

        #region Constructor
        public frmCardManager()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            this.dataGridCards.Dock = DockStyle.Fill;
        }
        #endregion //Constructor

        #region Dispose
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
        #endregion //Dispose

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCardManager));
            this.dataGridCards = new System.Windows.Forms.DataGrid();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbbAdd = new System.Windows.Forms.ToolBarButton();
            this.tbbEdit = new System.Windows.Forms.ToolBarButton();
            this.tbbDelete = new System.Windows.Forms.ToolBarButton();
            this.tbbExit = new System.Windows.Forms.ToolBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCards)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCards
            // 
            this.dataGridCards.DataMember = "";
            this.dataGridCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridCards.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridCards.Location = new System.Drawing.Point(0, 41);
            this.dataGridCards.Name = "dataGridCards";
            this.dataGridCards.Size = new System.Drawing.Size(736, 408);
            this.dataGridCards.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                        this.tbbAdd,
                                                                                        this.tbbEdit,
                                                                                        this.tbbDelete,
                                                                                        this.tbbExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(736, 41);
            this.toolBar1.TabIndex = 4;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbbAdd
            // 
            this.tbbAdd.ImageIndex = 0;
            this.tbbAdd.Text = "添加";
            // 
            // tbbEdit
            // 
            this.tbbEdit.ImageIndex = 1;
            this.tbbEdit.Text = "修改";
            // 
            // tbbDelete
            // 
            this.tbbDelete.ImageIndex = 2;
            this.tbbDelete.Text = "删除";
            // 
            // tbbExit
            // 
            this.tbbExit.ImageIndex = 3;
            this.tbbExit.Text = "退出";
            // 
            // frmCardManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(736, 449);
            this.Controls.Add(this.dataGridCards);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmCardManager";
            this.Text = "TM卡管理";
            this.Load += new System.EventHandler(this.frmCardManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCards)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region FormEvent
        private void frmCardManager_Load(object sender, System.EventArgs e)
        {
            dataGridCards.ReadOnly = true;
            //MessageBox.Show(dataGridCards.Top + " " + dataGridCards.Left);
            
           
            //            InitXGDB();
            LoadCardFromDB();
            
        }
        
        private void AddTableStyles()
        {
            string [] colNames = new string[] {"card_id", "sn", "person", "team", "remark"};
            string [] showNames = new string[] {"编号", "卡号", "持卡人", "所属班组", "备注"};
            int []columnWidth = new int[] {50, 150, 100,100, 200 };

            DataGridTableStyle dgts = Misc.CreateDataGridTableStyle( "Table", colNames, showNames, null , columnWidth);
            this.dataGridCards.TableStyles.Add( dgts );
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            AddCard();
        }
        #endregion //FormEvent

        #region InitXGDB
        private void InitXGDB()
        {

        }
        #endregion //InitXGDB

        #region LoadCardFromDB
        private void LoadCardFromDB()
        {
            //            string sql = string.Format("select card_id, sn, person, remark from tbl_card");
            this.dataGridCards.TableStyles.Clear();
            AddTableStyles();
            this.dataGridCards.DataSource = null;


            string sql = "select card_id, sn, person, team, remark from tbl_card";
           
            DataSet ds = XGDB.DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];

            this.dataGridCards.DataSource = tbl;//ds.Tables[0];
            //            this.dataGridCards.Refresh();
        }
        #endregion //LoadCardFromDB

        #region AddCard
        /// <summary>
        /// 
        /// </summary>
        private void AddCard()
        {
            try
            {
                frmCardItem f = new frmCardItem();
                if ( f.ShowDialog(this) == DialogResult.OK )
                {
                    Card c = new Card( f.CardSN, f.Person, f.Remark  );
                    //2007.03.30 Added Team
                    //
                    c.Tag = f.Team;

                    XGDB.InsertCard( c );
                    LoadCardFromDB();
                    XGDB.Resolve();
                }
            }
            catch ( Exception ex )
            {
                MsgBox.Show( ex.ToString() );
            }
        }
        #endregion //AddCard

        #region EditCard
        private void EditCard()
        {
            int row = dataGridCards.CurrentRowIndex;
            if ( row == -1 )
                return ;

            int id = Convert.ToInt32( dataGridCards[ row, 0 ] );
            string sn     = dataGridCards[ row, 1 ].ToString();
            string person = dataGridCards[ row, 2 ].ToString();
            string team   = dataGridCards[ row, 3 ].ToString();
            string remark = dataGridCards[ row, 4 ].ToString();

            frmCardItem f = new frmCardItem();
            f.AdeState = ADEState.Edit;
            f.EditId = id;
            f.CardSN = sn;
            f.Person = person;
            f.Remark = remark;
            f.Team   = team;

            if ( f.ShowDialog() == DialogResult.OK )
            {
                Card c = new Card( f.CardSN, f.Person, f.Remark );
                c.Tag = f.Team;
                XGDB.UpdateCard(id, c );
                LoadCardFromDB();
                XGDB.Resolve();
            }
        }
        #endregion //EditCard

        #region GetSelectedId
        private int GetSelectedId ()
        {
            int row = dataGridCards.CurrentRowIndex;
            int col=0;

            if ( row == -1 )
            {
                return -1;
            }
            else
            {
                object obj = dataGridCards[ row, col ];
                return Convert.ToInt32( obj );
            }
        }
        #endregion //GetSelectedId

        #region btnDelete_Click
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            int id = GetSelectedId();
            if ( id == -1 )
                return ;
            DialogResult dr = MsgBox.ShowQuestion( GT.TIP_DELELE_DATAGRID_ROW );
            if ( dr == DialogResult.Yes )
            {
                XGDB.DeleteCard( id );
                LoadCardFromDB();
                XGDB.Resolve();
            }
        }
        #endregion //btnDelete_Click

        #region btnEdit_Click
        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            EditCard();
        }
        #endregion //btnEdit_Click

        #region toolBar1_ButtonClick

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if ( e.Button == tbbAdd )
                this.btnAdd_Click( this, EventArgs.Empty );

            else if ( e.Button == tbbEdit )
                this.btnEdit_Click( this, EventArgs.Empty );

            else if ( e.Button == tbbDelete )
                this.btnDelete_Click ( this, EventArgs.Empty );

            else if ( e.Button == tbbExit )
                this.Close();
        }
        #endregion //toolBar1_ButtonClick        
    }

    #endregion //frmCardManager
}
