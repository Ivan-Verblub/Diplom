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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms.Сustom
{
    public partial class CreateTech : Form
    {
        private CharsList list = null;
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
                Requester<Contextable,ContextableFilter>(Param.Serv.host))
            {
                comboBox1.DisplayMember = "version";
                comboBox1.ValueMember = "id";
                comboBox1.DataSource = DataTableParser.Parse(requster.Select());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var requster = new
                    Requester<SearchContext, SearchContextFilter>(Param.Serv.host))
                {
                    using (var requsterInner = new
                    Requester<Contextable, ContextableFilter>(Param.Serv.host))
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
                    Requester<SearchNames, SearchNamesFilter>(Param.Serv.host))
                {
                    using (var requsterInner = new
                    Requester<Contextable, ContextableFilter>(Param.Serv.host))
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
                flowLayoutPanel1.Controls.Clear();
                var dt = (DataTable)comboBox2.DataSource;
                foreach(DataRow rw in dt.Rows)
                {
                    var el = new Element();
                    el.Name = (string)rw["name"];
                    el.Id = (int)rw["id"];
                    el.Width = flowLayoutPanel1.Width-10;
                    flowLayoutPanel1.Controls.Add(el);
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
            string url = $"{Param.Serv.host}/Tech/Tech/Select/{comboBox1.SelectedValue}";
            Chars[] chars = null;
            while (true)
            {
                var request = WebRequest.Create(url);
                request.Method = "POST";
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                SOptions[] ops = null;
                if (dataGridView1.Rows.Count != 0)
                {
                    ops = new SOptions[dataGridView1.Rows.Count];
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        ops[i] = new SOptions()
                        {
                            Id = (int)dataGridView1.Rows[i].Cells["elementId"].Value,
                            Option = (string)dataGridView1.Rows[i].Cells["name"].Value +";"+
                            (string)dataGridView1.Rows[i].Cells["value"].Value
                        };
                    }
                }
                else
                {
                    ops = new SOptions[]
                    {
                    new SOptions()
                    {
                        Id = (int)comboBox2.SelectedValue,
                        Option = "-100"
                    }
                    };
                }
                string json = JsonSerializer.Serialize<SOptions[]>(ops, options);
                var bytes = UnicodeEncoding.UTF8.GetBytes(json);
                request.ContentLength = bytes.Length;
                request.ContentType = "application/json";
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
                try
                {
                    var jsons = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                    chars = JsonSerializer.Deserialize<Chars[]>(jsons);
                    break;
                }
                catch (WebException ex)
                {
                    if(((HttpWebResponse)ex.Response).StatusCode !=
                            HttpStatusCode.BadGateway)
                    {
                        MessageBox.Show(new 
                            StreamReader(
                            ex.Response.GetResponseStream()).ReadToEnd(),
                            "Ошибка поиска",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    Thread.Sleep(1000);
                }
            }
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
                    foreach(Element el in flowLayoutPanel1.Controls)
                    {
                        if(el.Id == (int)comboBox2.SelectedValue)
                        {
                            el.ItemName = dataGridView2.SelectedRows[0].Cells["nameL"].Value.ToString();
                            el.Link = dataGridView2.SelectedRows[0].Cells["valueL"].Value.ToString();
                        }
                    }
                    
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Create(Chars[] chars)
        {
            try
            {
                list.Show();
            }
            catch
            { 
                list = new CharsList((int)comboBox1.SelectedValue);
                list.Show();
            }
            list.Create(chars, label3.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            foreach (Element el in flowLayoutPanel1.Controls)
            {
                if(String.IsNullOrWhiteSpace(el.Link))
                {
                    MessageBox.Show(
                        "Не все наименования заполнены",
                        "Внимание",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
            }
            List<Chars> charsFull = new List<Chars>();
            string url = $"{Param.Serv.host}/Tech/Tech/Select/Link/{comboBox1.SelectedValue}/";
            var uri = new Uri(dataGridView2.SelectedRows[0].Cells["valueL"].Value.ToString());
            var filter = new ContextFilter()
            {
                DomenL = $"%{uri.Host.Split('.')[1]}%"
            };
            foreach (Element el in flowLayoutPanel1.Controls)
            {
                
                Chars[] chars = null;
                while (true)
                {
                    using (var requester = new Requester<Context, ContextFilter>(Param.Serv.host))
                    {
                        var data = requester.Select(filter);
                        url += $"{data[0].id}?url={el.Link}";
                    }
                    var request = WebRequest.Create(url);
                    request.Method = "POST";
                    try
                    {
                        var jsons = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                        chars = JsonSerializer.Deserialize<Chars[]>(jsons);
                        charsFull.AddRange(chars);
                        break;
                    }
                    catch (WebException ex)
                    {
                        if (((HttpWebResponse)ex.Response).StatusCode !=
                        HttpStatusCode.BadGateway)
                        {
                            MessageBox.Show(new
                                StreamReader(
                                ex.Response.GetResponseStream()).ReadToEnd(),
                                "Ошибка формирования",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        Thread.Sleep(1000);
                    }
                }
            }
            Create(charsFull.ToArray());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dt = (DataTable)dataGridView1.DataSource;
            dt.Rows.Clear();
        }
    }
}
