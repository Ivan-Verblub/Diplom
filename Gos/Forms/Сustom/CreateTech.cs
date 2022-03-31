using Gos.Server;
using Gos.Server.Models.Filter;
using Gos.Server.Models.Table;
using Server.Controllers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
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
            try
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
                        comboBox2.DisplayMember = "name";
                        comboBox2.ValueMember = "id";
                    }
                }
            }
            catch { }
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
            string url = $"https://localhost:5001/Tech/Tech/Select/{comboBox1.SelectedValue}";
            var request = WebRequest.Create(url);
            request.Method = "POST";
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            var ops = new SOptions[dataGridView1.Rows.Count];
            for(int i = 0; i < dataGridView1.Rows.Count;i++)
            {
                ops[i] = new SOptions()
                {
                    Id = (int)dataGridView1.Rows[i].Cells["elementId"].Value,
                    Option = (string)dataGridView1.Rows[i].Cells["name"].Value +" "+
                    (string)dataGridView1.Rows[i].Cells["value"].Value
                };
            }
            string json = JsonSerializer.Serialize<SOptions[]>(ops, options);
            var bytes = UnicodeEncoding.UTF8.GetBytes(json);
            request.ContentLength = bytes.Length;
            request.ContentType = "application/json";
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }

            var jsons = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
            var chars = JsonSerializer.Deserialize<Chars[]>(jsons);

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("nameL", typeof(string)));
            dt.Columns.Add(new DataColumn("valueL", typeof(string)));
            
            foreach(var c in chars)
            {
                var rw = dt.NewRow();
                rw["nameL"] = c.name;
                rw["valueL"] = c.value;
                dt.Rows.Add(rw);
            }

            dataGridView2.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView2.SelectedRows.Count != 0)
            {
                if(dataGridView2.SelectedRows[0].Index != -1)
                {
                    Process.Start(dataGridView2.SelectedRows[0].Cells["valueL"].Value.ToString());
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {
                if (dataGridView2.SelectedRows[0].Index != -1)
                {
                    string url = $"https://localhost:5001/Tech/Tech/Select/Link/{comboBox1.SelectedValue}/";
                    var uri = new Uri(dataGridView2.SelectedRows[0].Cells["valueL"].Value.ToString());
                    var filter = new ContextFilter()
                    {
                        DomenL = uri.Host.Split('.')[1]
                    };
                    using (var requester = new Requester<Context,ContextFilter>("https://localhost:5001"))
                    {
                        var data = requester.Select(filter);
                        url += $"{data[0].id}?url={dataGridView2.SelectedRows[0].Cells["valueL"].Value}";
                    }

                    var request = WebRequest.Create(url);
                    request.Method = "POST";
                    var jsons = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                    var chars = JsonSerializer.Deserialize<Chars[]>(jsons);
                }
            }
        }
    }
}
