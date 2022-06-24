using Gos.Server.Atribute;
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

namespace Gos.Forms
{
    public partial class FieldSelector<T> : Form where T: class
    {
        EventController ec = EventController.Instance;
        public FieldSelector()
        {
            InitializeComponent();
            var props = typeof(T).GetProperties();
            foreach(var prop in props)
            {
                if (prop.GetCustomAttribute(typeof(Invisible), true) == null)
                {
                    var atribute = prop.GetCustomAttributes(typeof(Localize), true).Cast<Localize>();
                    string name = "";
                    if (atribute.Count() == 0)
                        name = prop.Name;
                    else
                        name = atribute.First().Name;
                    var cm = new CheckBox()
                    {
                        Name = prop.Name,
                        Text = name,
                        Checked = true
                    };
                    cm.CheckedChanged += (o, e) =>
                    {
                        ec.InvokeFieldTable(cm);
                    };
                    flowLayoutPanel1.Controls.Add(cm);
                    flowLayoutPanel1.SizeChanged += (o, e) =>
                    {
                        cm.Width = flowLayoutPanel1.Width-260;
                    };
                }
            }
        }
    }
}
