using System;

namespace CFW
{

    /// <summary>
    /// 通讯结果状态
    /// </summary>
    public enum CommResultState
    {
        /// <summary> 未知错误 / 初始化 </summary>
        UnknownError = 0,

        /// <summary> 长度错误 </summary>
        LengthError,

        /// <summary> 校验错误 </summary>
        CheckError,

        /// <summary> 无数据 </summary>
        NullData,
  
        /// <summary> 正确的 </summary>
        Correct,

        /// <summary> 数据错误 </summary>
        DataError,
    }

    /// <summary>
    /// 
    /// </summary>
	public enum PropertyIds
	{
		Add,
		Remove,
		Insert,
		Clear,

		Task,
		Tasks,
	}

    /// <summary>
    /// 周期
    /// </summary>
    public enum TimePointFrequency
    {
        PerDay,
        PerWeek,
        PerMonth,
        PerYear,
        Once,
    }
}
