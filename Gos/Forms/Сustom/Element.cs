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
    public partial class Element : UserControl
    {
        public int Id { get; set; }
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                label1.Text = $"Элемент:\"{value}\"";
                _name = value;
            }
        }
        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                textBox1.Text = value;
                _itemName = value;
            }
        }
        public string Link { get; set; }
        private string _name;
        private string _itemName;
        public Element()
        {
            InitializeComponent();
        }
    }
}
