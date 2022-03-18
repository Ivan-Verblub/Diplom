using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms.Filter
{
    public partial class Filters<T,F> : Form where F : class where T : class
    {
        public Filters(List<PropertyInfo> props)
        {
            InitializeComponent();
            foreach(var prop in props)
            {
                var ff = new FilterField<T,F>(prop.GetType());
                flowLayoutPanel1.Controls.Add(ff);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
