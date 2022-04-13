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
    public partial class CharList : UserControl
    {
        public string Title
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
        public string Value
        {
            get
            {
                return textBox2.Text;
            }
            set
            {
                textBox2.Text = value;
            }
        }
        public int Index
        {
            get
            {
                return comboBox1.SelectedIndex;
            }
            set
            {
                comboBox1.SelectedIndex = value;
            }
        }
        public string Start
        {
            get
            {
                return textBox3.Text;
            }
            set
            {
                textBox3.Text = value;
            }
        }
        public string End
        {
            get
            {
                return textBox4.Text;
            }
            set
            {
                textBox4.Text = value;
            }
        }
        public CharList()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 5)
            {
                textBox3.Visible = true;
                textBox4.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
            }
            else
            {
                textBox3.Visible = false;
                textBox4.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
            }
            
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(this, DragDropEffects.Copy);
        }
    }
}
