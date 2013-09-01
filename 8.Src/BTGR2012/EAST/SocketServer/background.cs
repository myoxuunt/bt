using System;
using System.Drawing;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class background : Form
    {
        public background()
        {
            InitializeComponent();
        }

        private void background_Load(object sender, EventArgs e)
        {   
           this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\beijing.jpg");
        }
    }
}
