using Gos.Server;
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
using Atribs = Gos.Server.Atribute;

namespace Gos.Forms.Filter
{
    public partial class Filters<T,F> : Form where F : class where T : class
    {
        EventController ec = EventController.Instance;
        public Filters(List<PropertyInfo> props)
        {
            InitializeComponent();
            foreach (var prop in props)
            {

                var ff = new FilterField<T, F>(prop);
                flowLayoutPanel1.Controls.Add(ff);
            }
            ec.EditFilterTable += Deselect;
        }
        private void Deselect(object sender,EventArgs e)
        {
            var filter = typeof(F).GetConstructor(Type.EmptyTypes).Invoke(null);
            var props = filter.GetType().GetProperties();
            foreach(Control item in flowLayoutPanel1.Controls)
            {
                foreach(var prop in props)
                {
                    if(prop.Name == item.Name)
                    {
                        var data = ((FilterField<T, F>)item).Data;
                        if(data.GetType() == typeof(TextBox))
                        {
                            if (prop.PropertyType == typeof(int))
                            {
                                if(String.IsNullOrWhiteSpace(((TextBox)data).Text))
                                {
                                    prop.SetValue(filter, 0);
                                }
                                else
                                {
                                    prop.SetValue(filter, int.
                                        Parse(((TextBox)data).Text));
                                }
                            }
                            else if (prop.PropertyType == typeof(float))
                            {
                                prop.SetValue(filter, float.
                                    Parse(((TextBox)data).Text.Replace(',', '.')));
                            }
                            else
                            {
                                if ((prop.GetCustomAttribute<Atribs.Filter>() != null) &&
                                   (prop.GetCustomAttribute<Atribs.Filter>().Filt
                                   == Filtration.LIKE))
                                {
                                    prop.SetValue(filter,
                                        "%" + ((TextBox)data).Text + "%");
                                }
                                else
                                {
                                    prop.SetValue(filter, ((TextBox)data).Text);
                                }
                            }
                            
                        }
                        else if (data.GetType() == typeof(DateTimePicker))
                        {
                            prop.SetValue(filter, ((DateTimePicker)data).Value);
                        }
                        else if (data.GetType() == typeof(ComboBox))
                        {
                            prop.SetValue(filter, ((ComboBox)data).SelectedValue);
                        }
                            
                    }
                }
            }
            ec.InvokeUpdateFilterTable(filter);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ec.InvokeUpdateTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var filt = new FilterSelector<T,F>()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            Parent.Controls.Add(filt);
            Parent.Controls.Remove(this);
            filt.Show();
            Close();
        }

        private void Filters_FormClosed(object sender, FormClosedEventArgs e)
        {
            ec.EditFilterTable -= Deselect;
        }
    }
}
