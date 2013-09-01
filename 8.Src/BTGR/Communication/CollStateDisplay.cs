namespace Communication
{
    using System;
    using System.Windows.Forms;

    #region CollStateDisplay
    /// <summary>
	/// 封装主界面采集状态栏
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
        /// 获取或设置采集状态文本
        /// </summary>
        public string Text
        {
            get { return _sbp.Text; }
            set { _sbp.Text = value; }
        }
	}
    #endregion //CollStateDisplay
}
