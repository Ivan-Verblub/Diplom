using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms.Сustom
{
    public partial class SetAdress : Form
    {
        public string Adress { get; set; }
        public SetAdress()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adress = textBox1.Text;
            DialogResult = DialogResult.Yes;
        }
    }
}
