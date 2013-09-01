using System;
using System.Windows.Forms;

namespace Utilities
{
    public class ExceptionHandler
    {
        static private bool         _showException      = true;

        /// <summary>
        /// 
        /// </summary>
        private ExceptionHandler()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        static public bool Show
        {
            get { return _showException; }
            set { _showException = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        static public string GetExceptionInfo( Exception ex )
        {
            //string strEx = ex.GetType().FullName + Environment.NewLine + Environment.NewLine ;
            string strEx = "Message:\t\t" + ex.Message + Environment.NewLine;
            strEx += "Source:\t\t" + ex.Source  + Environment.NewLine;
            strEx += "TargetSite:\t" + ex.TargetSite  + Environment.NewLine;
            strEx += "StackTrace:\t" + Environment.NewLine + ex.StackTrace  + Environment.NewLine;

            if( ex.HelpLink != null && ex.HelpLink.Length > 0)
                strEx += "HelpLink:\t" + ex.HelpLink  + Environment.NewLine;
            
            
            if (ex.InnerException != null )
                strEx += "InnerException:\t" + GetExceptionInfo ( ex.InnerException );

            return strEx;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        static public void Handle( Exception ex )
        {
            Handle_Helper( null, ex, _showException);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="show"></param>
        static public void Handle( Exception ex, bool show )
        {
            Handle_Helper( null, ex, show );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        static public void Handle(string message,Exception ex)
        {
            Handle_Helper( message, ex, _showException );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <param name="show"></param>
        static public void Handle(string message, Exception ex, bool show)
        {
            //MessageBox.Show(string.Format("{0}\n{1}: {2}",
            //    message, ex.GetType().ToString(), ex.ToString())); 
            Handle_Helper( message, ex, show );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <param name="show"></param>
        static private void Handle_Helper( string message, Exception ex, bool show)
        {
            if (!show)
                return ;
            
            string s = GetExceptionInfo( ex );
            
            if (message != null && message.Trim().Length > 1)
            {
                s = message +  Environment.NewLine + Environment.NewLine + s;
            }

            MessageBox.Show( s, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);    
        }
    }
}