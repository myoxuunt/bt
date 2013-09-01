using System;

namespace CFW
{

    /// <summary>
    /// ͨѶ���״̬
    /// </summary>
    public enum CommResultState
    {
        /// <summary> δ֪���� / ��ʼ�� </summary>
        UnknownError = 0,

        /// <summary> ���ȴ��� </summary>
        LengthError,

        /// <summary> У����� </summary>
        CheckError,

        /// <summary> ������ </summary>
        NullData,
  
        /// <summary> ��ȷ�� </summary>
        Correct,

        /// <summary> ���ݴ��� </summary>
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
    /// ����
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
