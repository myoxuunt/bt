namespace Communication
{
    using System;
    using System.Windows.Forms;

    #region CollStateDisplay
    /// <summary>
	/// ��װ������ɼ�״̬��
	/// </summary>
	public class CollStateDisplay
	{
        private StatusBarPanel _sbp;

		public CollStateDisplay( StatusBarPanel sbp )
		{
            ArgumentChecker.CheckNotNull( sbp );
            _sbp = sbp;
		}

        /// <summary>
        /// ��ȡ�����òɼ�״̬�ı�
        /// </summary>
        public string Text
        {
            get { return _sbp.Text; }
            set { _sbp.Text = value; }
        }
	}
    #endregion //CollStateDisplay
}
