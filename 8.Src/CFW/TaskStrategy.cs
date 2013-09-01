using CFW;
using System;
using System.Diagnostics;

namespace CFW
{
    #region TaskStrategy
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public abstract class TaskStrategy
    {
        /// <summary>
        /// 
        /// </summary>
        protected Task        m_Owning = null;


        /// <summary>
        /// ��ȡ�����ú͸ò�����������Task
        /// </summary>
        public Task Owning
        {
            get 
            {
                return m_Owning;
            }
            set 
            {
                m_Owning = value;
            }
        }

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾTask�Ƿ���Ҫִ�С�
        /// </summary>
        /// <returns></returns>
        public bool NeedExecute()
        {
            return NeedExecute( DateTime.Now );
        }

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾTask�Ƿ���Ҫִ�С�
        /// </summary>
        /// <returns></returns>
        abstract public bool NeedExecute( DateTime dt );

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ��Task�Ƿ���Ա�ɾ����
        /// </summary>
        /// <remarks>
        /// TaskManager����ݸñ���Զ�ɾ��Task��
        /// </remarks>
        abstract public bool CanRemove
        {
            get;
        }

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ��Task�Ƿ���Ҫ����ִ�С�
        /// </summary>
        abstract public bool FirstExecute
        {
            get;
        }
    }

    #endregion //TaskStrategy
}
