using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms
{
    public partial class VMenu : Form
    {
        public delegate void Btn1Click();
        public event Btn1Click OnClickBtn1;
        public VMenu()
        {
            InitializeComponent();
        }

        private void VMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnClickBtn1();
        }
    }
}
