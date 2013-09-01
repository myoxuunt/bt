using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Tool.UersCheck.check(textBox1.Text.Trim(), textBox2.Text.Trim()))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void login_Load(object sender, EventArgs e)
        {
           // this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\denglu.jpg");
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

    }
}
