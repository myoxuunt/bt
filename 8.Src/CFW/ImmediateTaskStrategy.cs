using System;
using System.Runtime.Serialization;

namespace CFW
{

    #region ImmediateTaskStrategy
    /// <summary>
    /// 立即执行且只执行一次的Task
    /// </summary>
    [Serializable]
    public class ImmediateTaskStrategy: TaskStrategy
    {
        // 2007.02.02 Added
        //
        //public readonly static ImmediateTaskStrategy Value = new ImmediateTaskStrategy();

        public ImmediateTaskStrategy()
        {
        }

        public override bool NeedExecute(System.DateTime dt)
        {
            return true;
        }

        public override bool CanRemove
        {
            get
            {
                return true;
            }
        }

        public override bool FirstExecute
        {
            get
            {
                return true;
            }
        }
    }

    #endregion //ImmediateTaskStrategy
}