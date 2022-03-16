using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingForms
{
    public partial class Form1 : Form
    {
        const string urlSelect = @"https://localhost:5001/Tables/Data/Select";
        const string urlUpdate = @"https://localhost:5001/Tables/Data/Update";
        Data save;
        int iter = 0;
        int t = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetData();
        }
        private void SetData()
        {
            try
            {
                WebRequest request = WebRequest.Create(urlSelect);
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "POST";
                request.ContentType = "application/json";

                var filter = new DatasFilter();
                filter.Label = "";
                var fJson = JsonSerializer.Serialize<DatasFilter>(filter);
                request.ContentLength = Encoding.ASCII.GetBytes(fJson).Length;
                var stream = request.GetRequestStream();
                stream.Write(Encoding.ASCII.GetBytes(fJson), 0, Encoding.ASCII.GetBytes(fJson).Length);
                stream.Close();
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var json = reader.ReadToEnd();
                var data = JsonSerializer.Deserialize<Data[]>($"{json}");
                response.Close();
                save = data[0];
                textBox1.Text = save.feature;
                t++;
                label1.Text = t.ToString();
            }
            catch
            {
                var t = new Timer();
                t.Interval = 1000;
                t.Tick += (o,e) => {
                    if (iter != 5)
                    {
                        SetData();
                        iter++;
                        t.Stop();
                    }
                    else
                    {
                        iter = 0;
                        t.Dispose();
                    }
                    
                };
                t.Start();
            }
        }
        private void PostData()
        {
            try
            {
                WebRequest request = WebRequest.Create(urlUpdate);
                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "POST";
                request.ContentType = "application/json";
                var json = JsonSerializer.Serialize<Data>(save);
                request.ContentLength = Encoding.ASCII.GetBytes(json).Length;
                var stream = request.GetRequestStream();
                stream.Write(Encoding.ASCII.GetBytes(json), 0, Encoding.ASCII.GetBytes(json).Length);
                stream.Close();
                
            }
            catch
            {
                var t = new Timer();
                t.Interval = 1000;
                t.Tick += (o, e) => {
                    if (iter != 5)
                    {
                        PostData();
                        iter++;
                        t.Stop();
                    }
                    else
                    {
                        iter = 0;
                        t.Dispose();
                    }

                };
                t.Start();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            save.label = "Trash";
            PostData();
            SetData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save.label = "Usef";
            PostData();
            SetData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            save.label = "Name";
            PostData();
            SetData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            save.label = "CharName";
            PostData();
            SetData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            save.label = "Char";
            PostData();
            SetData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            save.label = "Unknown";
            PostData();
            SetData();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            save.label = "Opor";
            PostData();
            SetData();
        }
    }
    public class Data
    {
        public int idData { get; set; }
        public string feature { get; set; }
        public string label { get; set; }
        public int idDataSet { get; set; }
        public string setName { get; set; }
    }
    public class DatasFilter
    {
        public int IdData { get; set; }

        public string Feature { get; set; }

        public string FeatureL { get; set; }

        public string Label { get; set; }

        public string LabelL { get; set; }

        public int IdDataSet { get; set; }

        public string SetName { get; set; }
        public string SetNameL { get; set; }
    }

}
