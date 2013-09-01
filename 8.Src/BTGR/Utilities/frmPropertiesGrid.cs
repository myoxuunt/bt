using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Utilities
{
	/// <summary>
	/// frmPropertiesGrid 的摘要说明。
	/// </summary>
	public class frmPropertiesGrid : System.Windows.Forms.Form
	{
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkTopMost;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPropertiesGrid()
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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btnProperties = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.CommandsVisibleIfAvailable = true;
            this.propertyGrid1.LargeButtons = false;
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid1.Location = new System.Drawing.Point(8, 8);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(272, 512);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.Text = "propertyGrid1";
            this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
            this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
            this.propertyGrid1.Click += new System.EventHandler(this.propertyGrid1_Click);
            // 
            // btnProperties
            // 
            this.btnProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProperties.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnProperties.Location = new System.Drawing.Point(8, 544);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(88, 24);
            this.btnProperties.TabIndex = 1;
            this.btnProperties.Text = "&Properties";
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(192, 544);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 24);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkTopMost
            // 
            this.chkTopMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTopMost.Location = new System.Drawing.Point(112, 544);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(72, 24);
            this.chkTopMost.TabIndex = 3;
            this.chkTopMost.Text = "&TopMost";
            this.chkTopMost.CheckedChanged += new System.EventHandler(this.chkTopMost_CheckedChanged);
            // 
            // frmPropertiesGrid
            // 
            this.AcceptButton = this.btnProperties;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(288, 581);
            this.Controls.Add(this.chkTopMost);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnProperties);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "frmPropertiesGrid";
            this.Text = "frmPropertiesGrid";
            this.Load += new System.EventHandler(this.frmPropertiesGrid_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void frmPropertiesGrid_Load(object sender, System.EventArgs e)
        {
        
        }

        public void ShowMe( object objAppearance, string strCaption )
        {
            this.propertyGrid1.SelectedObject = objAppearance;
            //this.Text = "Appearance properties - " + strCaption;
            this.Text = strCaption;
            this.Show();
        }

        public void ShowMe ( object objAppearance )
        {
            if ( objAppearance == null )
                return ;
            ShowMe( objAppearance, objAppearance.GetType().Name );

        }

        private void propertyGrid1_Click(object sender, System.EventArgs e)
        {
            //this.Text = this.propertyGrid1.SelectedObject.ToString();
        }

        private void btnProperties_Click(object sender, System.EventArgs e)
        {
            GridItem gi = this.propertyGrid1.SelectedGridItem;
            if (gi.Value != null)
            {
                new frmPropertiesGrid().ShowMe( gi.Value, gi.Label + ": " + gi.Value.ToString());
            }
            else
            {
                MessageBox.Show(this, "Cannot show <null> object", "Null reference", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void chkTopMost_CheckedChanged(object sender, System.EventArgs e)
        {
            this.TopMost = this.chkTopMost.Checked;
        }
	}
}
