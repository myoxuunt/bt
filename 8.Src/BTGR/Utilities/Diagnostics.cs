using System;
using System.Diagnostics;

namespace Utilities
{
	/// <summary>
	/// Diagnostics ��ժҪ˵����
	/// </summary>
	public class Diagnostics
	{
        /// <summary>
        /// 
        /// </summary>
		private Diagnostics()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
