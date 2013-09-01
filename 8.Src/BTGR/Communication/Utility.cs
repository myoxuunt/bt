using System;
using System.Windows.Forms;
using System.Data;
using Utilities;

namespace Communication
{

    #region Misc
    /// <summary>
    /// 
    /// </summary>
    public class Misc
    {
        private Misc()
        {
        }
        
        static private bool InArray( int[] array, int n )
        {
            if (array == null )
                return false;

            foreach ( int i in array )
            {
                if ( i == n )
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableMappingName"></param>
        /// <param name="dbColName"></param>
        /// <param name="dgShowName"></param>
        /// <param name="boolColumnIndex"></param>
        /// <returns></returns>
        static public DataGridTableStyle CreateDataGridTableStyle(string tableMappingName, string[] dbColName, string[] dgShowName, int[] boolColumnIndex)
        {
            ArgumentChecker.CheckNotNull(dbColName);
            ArgumentChecker.CheckNotNull(dgShowName);
            if ( dbColName.Length != dgShowName.Length )
                throw new ArgumentException( "dbColName.Length != dgShowName.Length" );

            DataGridTableStyle dgts = new DataGridTableStyle();
            dgts.MappingName = tableMappingName;

            DataGridColumnStyle dgcs = null;
            for ( int i=0; i<dbColName.Length; i++ )
            {
                if ( InArray( boolColumnIndex, i ) )
                    dgcs = new DataGridBoolColumn ();
                else
                    dgcs = new DataGridTextBoxColumn();

				dgcs.MappingName = dbColName[i];
                dgcs.HeaderText = dgShowName[i];

                dgts.GridColumnStyles.Add( dgcs );
            }

            return dgts;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableMappingName"></param>
        /// <param name="dbColName"></param>
        /// <param name="dgShowName"></param>
        /// <param name="boolColumnIndex"></param>
        /// <returns></returns>
        static public DataGridTableStyle CreateDataGridTableStyle(string tableMappingName, string[] dbColName, 
            string[] dgShowName, int[] boolColumnIndex, int [] columnWidth )
        {
            ArgumentChecker.CheckNotNull(dbColName);
            ArgumentChecker.CheckNotNull(dgShowName);
            if ( dbColName.Length != dgShowName.Length )
                throw new ArgumentException( "dbColName.Length != dgShowName.Length" );

            DataGridTableStyle dgts = new DataGridTableStyle();
            dgts.MappingName = tableMappingName;

            DataGridColumnStyle dgcs = null;
            for ( int i=0; i<dbColName.Length; i++ )
            {
                if ( InArray( boolColumnIndex, i ) )
                    dgcs = new DataGridBoolColumn ();
                else
                    dgcs = new DataGridTextBoxColumn();
                if ( columnWidth != null && i < columnWidth.Length )
                {
                    dgcs.Width = columnWidth[ i ];
                }

                dgcs.MappingName = dbColName[i];
                dgcs.HeaderText = dgShowName[i];

                dgts.GridColumnStyles.Add( dgcs );
            }

            return dgts;

        }
        
        static public string GetAdeStateText( ADEState state )
        {
            switch ( state )
            {
                case ADEState.Add:
                    return GT.TEXT_ADD ;

                case ADEState.Delete:
                    return GT.TEXT_DELETE;

                case ADEState.Edit:
                    return GT.TEXT_MODIFY;

                default:
                    throw new ArgumentException(state.ToString());
            }
        }
    }
    #endregion //Misc

    #region ADEState
    public enum ADEState
    {
        Add,
        Edit,
        Delete
    }
    #endregion //ADEState

    #region TagType
    public enum TagType
    {
        OP_ReadAndClearXgData,
    }
    #endregion //TagType

    #region GT
    /// <summary>
    /// 
    /// </summary>
    public class GT
    {
        private GT()
        {
        }


        public const string TIP_DELELE_DATAGRID_ROW = "确定要删除选定项吗?";
        public const string TEXT_ALL                = "<全部>";
        public const string TEXT_ALL_STATION        = "<全部站>";
        public const string TEXT_TIP                = "提示";
        public const string TEXT_ADD                = " - 添加";
        public const string TEXT_MODIFY             = " - 修改";
        public const string TEXT_DELETE             = " - 删除";
        public const string TEXT_UNKNOWN            = "(未知)"; 
        public const string TEXT_START              = "启动";
        public const string TEXT_STOP               = "停止";
        public const string TEXT_CYCLEPUMP          = "循环泵";
        public const string TEXT_RECRUITPUMP        = "补水泵";
        public const string TEXT_PROGRAM_RUNNING    = "程序已经运行";
        public const string TEXT_ERROR              = "错误";
            

    }
    #endregion //GT

    #region MsgBox
    /// <summary>
    /// 
    /// </summary>
    public class MsgBox
    {
        private MsgBox()
        {
        }

        static public DialogResult Show ( string text )
        {
            return MessageBox.Show( text, GT.TEXT_TIP, MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        static public DialogResult Show ( string text, string caption )
        {
            return MessageBox.Show( text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        public static DialogResult Show( string text, string caption,MessageBoxIcon icon )
        {
            return MessageBox.Show( text, caption, MessageBoxButtons.OK, icon );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static public DialogResult  ShowQuestion( string text )
        {
            return MessageBox.Show ( text, GT.TEXT_TIP, MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question,MessageBoxDefaultButton.Button2  );
        }
    }
    #endregion //MsgBox

    #region ArgumentChecker
	/// <summary>
	/// Utility 的摘要说明。
	/// </summary>
	public class ArgumentChecker
	{
		private ArgumentChecker()
		{
		}

        public static void CheckNotNull( object obj )
        {
            if ( obj == null )
                throw new ArgumentNullException ();
        }
	}
    #endregion //ArgumentChecker

    #region FormAdjust
    /// <summary>
    /// FormAdjust 的摘要说明。
    /// </summary>
    public class FormAdjust
    {
        private FormAdjust()
        {
        }

        static public void SetFormAppearance(Form form, bool sizeable, bool showInTaskBar, 
            bool minBox, bool maxBox, bool controlBox)
        {
            form.FormBorderStyle = sizeable ? FormBorderStyle.SizableToolWindow : FormBorderStyle.FixedSingle;
            form.ShowInTaskbar = showInTaskBar;
            form.MinimizeBox = minBox;
            form.MaximizeBox = maxBox;
            form.ControlBox = controlBox; 
        }

        static public void SetComboBoxAppearance( ComboBox box )
        {
            box.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
    #endregion //FormAdjust

}
