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
                var atribute = prop.GetCustomAttributes(typeof(Localize),true)
                    .Cast<Localize>().First();
                string name = prop.Name;
                if(atribute != null)
                    name = atribute.Name;
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn()
                {
                    Name = prop.Name,
                    HeaderText = name,
                    DataPropertyName = prop.Name
                };
                dataGridView1.Columns.Add(col);
            }
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            ec.UpdateTable += UpdateTable;
            ec.UpdateFilterTable += UpdateFilterTable;
            using(var requester = new Requester<T,F>("https://localhost:5001"))
            {
                dataGridView1.DataSource = DataTableParser.Parse(requester.Select());               
            }
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
    }
}
