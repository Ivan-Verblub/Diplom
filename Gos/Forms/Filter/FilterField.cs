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

namespace Gos.Forms.Filter
{
    public partial class FilterField<Table,Filt> : UserControl 
        where Table : class where Filt : class
    {
        public Control Data { get; set; }
        public FilterField(Type type)
        {
            InitializeComponent();

            var lab = new Label()
            {
                Text = ""    
            };
            flowLayoutPanel1.Controls.Add(lab);
            if (type == typeof(string))
            {
                Data = new TextBox();
            }
            else if (type == typeof(DateTime))
            {
                Data = new DateTimePicker();
            }
            else if (type == typeof(int))
            {
                Data = new TextBox();
                ((TextBox)Data).KeyPress += (o, e) =>
                {
                    if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != 8))
                        e.Handled = true;
                };
            }
            else if (type == typeof(float))
            {
                Data = new TextBox();
                ((TextBox)Data).KeyPress += (o, e) =>
                {
                    if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != 8) && (e.KeyChar != ','))
                        e.Handled = true;
                };
            }
            else
            {
                using (var requster = new Requester<Table,Filt>("https://localhost:5001"))
                {
                    var result = requster.Select();
                    ((ComboBox)Data).DataSource = DataTableParser.Parse(result);
                    var props = typeof(Table).GetProperties();
                    foreach (var prop in props)
                    {
                        var aribute = prop.GetCustomAttribute<Key>(true);
                        if (aribute != null)
                        {
                            if (aribute.IsKey)
                            {
                                ((ComboBox)Data).ValueMember = prop.Name;
                            }
                            else
                            {
                                ((ComboBox)Data).DisplayMember = prop.Name;
                            }
                        }
                    }
                }
            }
            flowLayoutPanel1.Controls.Add(Data);
        }

        private void FilterField_Load(object sender, EventArgs e)
        {

        }
    }
}
