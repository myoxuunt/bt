using System;
namespace CFW
{
    #region TimeSubObjectBase
    /// <summary>
    /// ����ʱ�����
    /// </summary>
    public abstract class TimeSubObjectBase
		: Infragistics.Shared.SubObjectBase 
    {
        private DateTime m_DateTime ;//= null;


        protected TimeSubObjectBase()
            : this ( DateTime.Now )
        {
        }

        protected TimeSubObjectBase(DateTime dateTime)
        {
            m_DateTime = dateTime;
        }

        public DateTime DateTime
        {
            get { return m_DateTime ; }
            set { m_DateTime = value; }
        }
    }
    #endregion //TimeSubObjectBase
}
