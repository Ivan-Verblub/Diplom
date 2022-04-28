using Gos.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace Gos.Forms
{
    public partial class Dump : Form
    {
        public Dump()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                while (true)
                {
                    string url = $"{Param.Serv.host}/Dump/Save/{textBox1.Text}";
                    var request = WebRequest.Create(url);
                    request.Method = "GET";

                    try
                    {
                        var respond = request.GetResponse();
                        var script = new StreamReader(
                            respond.GetResponseStream()).ReadToEnd();
                        File.WriteAllText(saveFileDialog1.FileName+".sql", script);
                        MessageBox.Show("Файл выгружен",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
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
                                "Ошибка выгрузки",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string query = File.ReadAllText(openFileDialog1.FileName);
                while (true)
                {
                    string url = $"{Param.Serv.host}/Dump/Load/{textBox1.Text}";
                    var request = WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    var options = new JsonSerializerOptions
                    {
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize<string[]>(new string[] { query }, options);
                    request.ContentLength = Encoding.UTF8.GetBytes(json).Length;
                    request.GetRequestStream().Write(
                        Encoding.UTF8.GetBytes(json), 0,
                        Encoding.UTF8.GetBytes(json).Length);

                    try
                    {
                        request.GetResponse();
                        MessageBox.Show("БД востановленна",
                            "Успех",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
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
                                "Ошибка выгрузки",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
        }
    }
}
