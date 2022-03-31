using Gos.Server;
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

namespace Gos.Forms.Сustom
{
    public partial class CreateTech : Form
    {
        public CreateTech()
        {
            InitializeComponent();
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("value", typeof(string)));
            dt.Columns.Add(new DataColumn("element", typeof(string)));
            dt.Columns.Add(new DataColumn("elementId", typeof(int)));
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateTech_Load(object sender, EventArgs e)
        {
            using (var requster = new 
                Requester<Contextable,ContextableFilter>("https://localhost:5001"))
            {
                comboBox1.DataSource = DataTableParser.Parse(requster.Select());
                comboBox1.DisplayMember = "version";
                comboBox1.ValueMember = "id";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var requster = new
                Requester<SearchContext, SearchContextFilter>("https://localhost:5001"))
            {
                using (var requsterInner = new
                Requester<Contextable, ContextableFilter>("https://localhost:5001"))
                {
                    label3.Text =  requster.Select(new SearchContextFilter()
                    {
                        Id = requsterInner.Select(new ContextableFilter()
                        {
                            Id = (int)comboBox1.SelectedValue
                        })[0].idSearch
                    })[0].name;
                }
            }

            using (var requster = new
                Requester<SearchNames, SearchNamesFilter>("https://localhost:5001"))
            {
                using (var requsterInner = new
                Requester<Contextable, ContextableFilter>("https://localhost:5001"))
                {
                    comboBox2.DataSource =  DataTableParser.Parse(
                        requster.Select(new SearchNamesFilter()
                    {
                        IdSearch = requsterInner.Select(new ContextableFilter()
                        {
                            Id = (int)comboBox1.SelectedValue
                        })[0].idSearch
                    }));
                    comboBox2.DisplayMember = "id";
                    comboBox2.ValueMember = "name";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
                return;
            var dt = (DataTable)dataGridView1.DataSource;
            var rw = dt.NewRow();
            rw["name"] = textBox1.Text;
            rw["value"] = textBox2.Text;
            rw["element"] = comboBox2.Text;
            rw["elementId"] = comboBox2.SelectedValue;
            dt.Rows.Add(rw);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count != 0)
            {
                if(dataGridView1.SelectedRows[0].Index != -1)
                {
                    var dt = (DataTable)dataGridView1.DataSource;
                    dt.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:5001";
        }
    }
}
