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
        /// 获取或设置和该策略所关联的Task
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
        /// 获取一个值，该值指示Task是否需要执行。
        /// </summary>
        /// <returns></returns>
        public bool NeedExecute()
        {
            return NeedExecute( DateTime.Now );
        }

        /// <summary>
        /// 获取一个值，该值指示Task是否需要执行。
        /// </summary>
        /// <returns></returns>
        abstract public bool NeedExecute( DateTime dt );

        /// <summary>
        /// 获取一个值，该值指示该Task是否可以被删除。
        /// </summary>
        /// <remarks>
        /// TaskManager会根据该标记自动删除Task。
        /// </remarks>
        abstract public bool CanRemove
        {
            get;
        }

        /// <summary>
        /// 获取一个值，该值指示该Task是否需要首先执行。
        /// </summary>
        abstract public bool FirstExecute
        {
            get;
        }
    }

    #endregion //TaskStrategy
}
