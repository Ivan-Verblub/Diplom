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

namespace Gos.Forms.Changing
{
    public partial class DataField<T,F> : UserControl 
        where T: class where F: class
    {
        public Control Data => _data;
        private Control _data;
        private EventController ec = EventController.Instance;
        public DataField(PropertyInfo type)
        {
            InitializeComponent();
            var local = type.GetCustomAttribute<Localize>();
            Name = type.Name;
            string name;
            if (local == null)
                name = type.Name;
            else
                name = local.Name;
            var lab = new Label()
            {
                Text = name
            };
            flowLayoutPanel1.Controls.Add(lab);

            var able = type.GetCustomAttribute<Typeable>();
            var en = type.GetCustomAttribute<EnumList>();
            if (en != null)
            {
                _data = new ComboBox();
                var dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("name", typeof(string));
                foreach (var ar in en.EnumType.GetEnumValues())
                {
                    var rw = dt.NewRow();
                    rw["id"] = (int)ar;
                    rw["name"] = ar.ToString();
                    dt.Rows.Add(rw);
                }
                ((ComboBox)Data).DataSource = dt;
                ((ComboBox)Data).ValueMember = "id";
                ((ComboBox)Data).DisplayMember = "name";
                ((ComboBox)Data).SelectedValueChanged += (o, e) =>
                {
                    ec.InvokeEditFilterTable();
                };
            }
            else if (able == null)
            {
                if (type.PropertyType == typeof(string))
                {
                    _data = new TextBox();
                }
                else if (type.PropertyType == typeof(DateTime))
                {
                    _data = new DateTimePicker();
                }
                else if (type.PropertyType == typeof(int))
                {
                    _data = new TextBox();
                    ((TextBox)Data).KeyPress += (o, e) =>
                    {
                        if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != 8))
                            e.Handled = true;
                    };
                }
                else if (type.PropertyType == typeof(float))
                {
                    _data = new TextBox();
                    ((TextBox)Data).KeyPress += (o, e) =>
                    {
                        if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != 8) && (e.KeyChar != ','))
                            e.Handled = true;
                    };
                }
            }
            else
            {
                var f = able.FType;
                var t = able.TType;
                var requester = typeof(Requester<,>).MakeGenericType(t, f).
                    GetConstructor(new Type[] { typeof(string) }).
                    Invoke(new object[] { "https://localhost:5001" });
                var result = requester.GetType().
                    GetMethod("Select", Type.EmptyTypes).Invoke(requester, null);
                _data = new ComboBox();
                ((ComboBox)Data).DataSource =
                    (DataTable)typeof(DataTableParser).GetMethod("Parse").
                    MakeGenericMethod(result.GetType().GetElementType())
                    .Invoke(null, new object[] { result });
                var props = t.GetProperties();
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
            flowLayoutPanel1.Controls.Add(Data);
        }
    }
}
