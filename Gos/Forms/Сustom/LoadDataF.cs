using Gos.Server;
using Gos.Server.Models.Filter;
using Gos.Server.Models.Requesting;
using Gos.Server.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class LoadDataF : Form
    {
        public LoadDataF()
        {
            InitializeComponent();
            using (var requster = new Requester<Server.Models.Table.DataSet,
                DataSetFilter>(Param.Serv.host))
            {
                comboBox1.DataSource = requster.Select();
                comboBox1.ValueMember = "idDataSet";
                comboBox1.DisplayMember = "setName";
            }

            using (var requster = new Requester<Context,
                ContextFilter>(Param.Serv.host))
            {
                comboBox2.DataSource = requster.Select();
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "domen";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label3.Visible = checkBox1.Checked;
            comboBox2.Visible = checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show(
                    "Заполните название страницы",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Заполните название набора данных",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            if ((checkBox1.Checked)&&(comboBox2.SelectedIndex == -1))
            {
                MessageBox.Show(
                    "Заполните название контекста",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                comboBox2.Focus();
                return;
            }

            var dl = new DataLoad()
            {
                Url = textBox1.Text,
                IdDataSet = (int)comboBox1.SelectedValue
            };
            if (checkBox1.Checked)
                dl.IdContext = (int)comboBox2.SelectedValue;

            var request = WebRequest.Create("https://localhost:5001/Tech/DataLoad/SetData");
            request.Method = "POST";
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string filterJson = JsonSerializer.Serialize<DataLoad>(dl, options);
            var bytes = UnicodeEncoding.UTF8.GetBytes(filterJson);
            request.ContentLength = bytes.Length;
            request.ContentType = "application/json";
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }
        }

        private void LoadDataF_Load(object sender, EventArgs e)
        {

        }
    }
}
