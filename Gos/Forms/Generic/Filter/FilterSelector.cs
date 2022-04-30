using Gos.Server.Atribute;
using Gos.Server.Models.Filter;
using Gos.Server.Models.Table;
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
    public partial class FilterSelector<T,F> : Form where F : class where T : class
    {
        private List<PropertyInfo> props = new List<PropertyInfo>();
        public FilterSelector()
        {
            InitializeComponent();
            var props = typeof(F).GetProperties();
            foreach(var prop in props)
            {
                if (prop.GetCustomAttribute(typeof(Invisible), true) == null)
                {
                    string name;
                    var local = prop.GetCustomAttributes(typeof(Localize), true).Cast<Localize>().First();
                    if (local != null)
                        name = local.Name;
                    else
                        name = prop.Name;
                    var cb = new CheckBox()
                    {
                        Text = name,
                        Name = prop.Name,
                        AutoSize = false
                    };

                    flowLayoutPanel1.Controls.Add(cb);
                    flowLayoutPanel1.SizeChanged += (o, e) =>
                    {
                        cb.Width = flowLayoutPanel1.Width-260;
                    };
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            foreach(var cb in flowLayoutPanel1.Controls)
            {
                if(cb.GetType() == typeof(CheckBox))
                {
                    if(((CheckBox)cb).Checked)
                        props.Add(typeof(F).GetProperty(((CheckBox)cb).Name));
                }
            }
            var filt = new Filters<T,F>(props)
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            Parent.Controls.Add(filt);
            Parent.Controls.Remove(this);
            filt.Show();
            Close();
        }
    }
}
