using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace Tool
{
    public class UersCheck
    {
        public static string UserName;
        public static string PassWord;

        public static bool check(string username, string password)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("config.xml");
            string name = xDoc.DocumentElement.ChildNodes[0].Attributes.GetNamedItem("name").Value.Trim();
            string word = xDoc.DocumentElement.ChildNodes[0].Attributes.GetNamedItem("word").Value.Trim();

            if (name != username && username != "Guest")
            {
                MessageBox.Show("用户名不存在！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                return false;
            }

            if (username != "Guest")
            {
                if (word != password)
                {
                    MessageBox.Show("密码不正确！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    return false;
                }
            }
            UserName = username;
            PassWord = password;
            return true;
        }

    }
}
