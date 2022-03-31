using Gos.Server;
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

namespace Gos.Forms
{
    public partial class DataForm<T,F> : Form where T : class where F : class
    {
        EventController ec = EventController.Instance;
        public DataForm()
        {
            InitializeComponent();
            dataGridView1.Columns.Clear();
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {

                var atribute = prop.GetCustomAttributes(typeof(Localize), true)
                .Cast<Localize>().First();
                string name = prop.Name;
                if (atribute != null)
                    name = atribute.Name;
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
                {
                    Name = prop.Name,
                    HeaderText = name,
                    DataPropertyName = prop.Name
                };
                if (prop.GetCustomAttribute(typeof(Invisible), true) != null)
                {
                    col.Visible = false;
                }
                dataGridView1.Columns.Add(col);

            }
        }
        public object SelectId()
        {
            if(dataGridView1.SelectedRows.Count != 0)
            {
                if (dataGridView1.SelectedRows[0].Index != -1)
                {
                    var props = typeof(T).GetProperties();
                    foreach (var prop in props)
                    {
                        var key = prop.GetCustomAttributes(typeof(Key), true);
                        if(key.Count() != 0)
                        {
                            if(((Key)key[0]).IsKey)
                            {
                                return dataGridView1.SelectedRows[0].Cells[prop.Name].Value;
                            }
                        }
                    }
                }
            }
            return null;
        }
        private void DataForm_Load(object sender, EventArgs e)
        {
            ec.UpdateTable += UpdateTable;
            ec.UpdateFilterTable += UpdateFilterTable;
            ec.FieldTable += FieldTable;
            UpdateTable(null,EventArgs.Empty);
        }

        private void UpdateTable(object sender, EventArgs e)
        {
            using (var requester = new Requester<T, F>("https://localhost:5001"))
            {
                dataGridView1.DataSource = DataTableParser.Parse(requester.Select());
            }
        }
        private void UpdateFilterTable(object sender, EventArgs e)
        {
            using (var requester = new Requester<T, F>("https://localhost:5001"))
            {
                dataGridView1.DataSource = DataTableParser.Parse(requester.Select((F)sender));
            }
        }
        private void FieldTable(object sender, EventArgs e)
        {
            dataGridView1.Columns[((CheckBox)sender).Name].Visible = ((CheckBox)sender).Checked;
        }

        private void DataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ec.UpdateTable -= UpdateTable;
            ec.UpdateFilterTable -= UpdateFilterTable;
            ec.FieldTable -= FieldTable;
        }
    }
}
