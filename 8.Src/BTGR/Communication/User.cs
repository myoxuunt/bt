using System;

namespace Communication
{
	/// <summary>
	/// User 的摘要说明。
	/// </summary>
	public class User
	{
        private string _name;
        private string _pwd;
        private string _description;

		public User( string name, string pwd, string description )
		{
            _name = name;
            _pwd = pwd;
            _description = description;
		}

        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value ; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

//        public bool IsCanDelete( param )
//        public bool IsCanAdd( param )
//        public bool IsCanEdit( param )
	}
}
