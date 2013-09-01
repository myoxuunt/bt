using System;
using System.Diagnostics;

namespace Utilities
{
	/// <summary>
	/// Diagnostics 的摘要说明。
	/// </summary>
	public class Diagnostics
	{
        /// <summary>
        /// 
        /// </summary>
		private Diagnostics()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public bool HasPreInstance()
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 1;
        }
	}
}
