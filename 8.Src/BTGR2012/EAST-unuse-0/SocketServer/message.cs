using System;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class message : Form
    {
        public message()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //登录
        private void button1_Click(object sender, EventArgs e)
        {
            if (Tool.UersCheck.check(textBox1.Text.Trim(), textBox2.Text.Trim()))
            {
                this.DialogResult = DialogResult.OK;               
                this.Close();              
            }
        }
        //取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void message_Load(object sender, EventArgs e)
        {

        }
    }
}
