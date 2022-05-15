using Gos.Forms.Generic;
using Gos.Server;
using Gos.Server.Models.Filter;
using Gos.Server.Models.Requesting;
using Gos.Server.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Learn : Form
    {
        public Learn()
        {
            InitializeComponent();
            using (var requester = new Requester<DataSet, DataSetFilter>(Param.Serv.host))
            {
                comboBox1.DataSource = DataTableParser.Parse(requester.Select());
                comboBox1.ValueMember = "idDataSet";
                comboBox1.DisplayMember = "setName";
            }
        }

        private void Learn_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1)
            {
                string url = $"{Param.Serv.host}/Tech/ML/" +
                    $"LoadData/{comboBox1.SelectedValue}/" +
                    $"{(trackBar1.Value/10f).ToString().Replace(',','.')}";
                var requeset = WebRequest.Create(url);
                requeset.Method = "POST";
                try
                {
                    requeset.GetResponse();
                    MessageBox.Show(
                    "Данные загружены",
                    "Внимаение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (WebException ex)
                {
                    MessageBox.Show(
                    new StreamReader(ex.Response.GetResponseStream()).ReadToEnd(),
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                    ex.Message,
                    "Внимаение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(
                    "Заполните поле набор данных",
                    "Внимаение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label6.Text = (trackBar1.Value/10f).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Task.Run(() => {
                string url = $"{Param.Serv.host}/Tech/ML/Train";
                var requeset = WebRequest.Create(url);
                requeset.Method = "GET";
                Invoke((Action)(() => { progressBar1.Value = progressBar1.Maximum; }));
                try
                {
                    string json = new StreamReader(requeset.GetResponse().GetResponseStream()).ReadToEnd();
                    MessageBox.Show(
                "Обучение прошло успешно",
                "Внимаение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show(
                "Обучение прошло не успешно",
                "Внимаение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                }
                
            });

            Task.Run(() =>
            {
                bool wh = true;
                while (wh)
                {
                    Task.Delay(1000);
                    Invoke((Action)(() => {
                        if (progressBar1.Value != progressBar1.Maximum) 
                            progressBar1.Value++;
                        else
                            wh = false;
                    }));
                }
            });
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string url = $"{Param.Serv.host}/Tech/ML/Predict";
                var request = WebRequest.Create(url);
                request.Method = "POST";
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                var data = new Data()
                {
                    Feature = textBox1.Text,
                    Label = ""
                };
                string json = JsonSerializer.Serialize<Data>(data, options);
                var bytes = UnicodeEncoding.UTF8.GetBytes(json);
                request.ContentLength = bytes.Length;
                request.ContentType = "application/json";
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }

                var jsons = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
                var pData = JsonSerializer.Deserialize<PData>(jsons);
                MessageBox.Show(
                    "Результат:"+pData.predictedLabel,
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(
                    "Ошибка при тестировании",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show(
                    "Заполните поле версия",
                    "Внимаение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show(
                    "Заполните поле Название",
                    "Внимаение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string url = $"{Param.Serv.host}/Tech/ML/Save/last.zip";
            var request = WebRequest.Create(url);
            request.Method = "POST";
            string bytes = new StreamReader(request.GetResponse().GetResponseStream()).ReadToEnd();
            object buff;
            try
            {
                buff = int.Parse((string)comboBox1.SelectedValue);
            }
            catch
            {
                buff = comboBox1.SelectedValue;
            }
            var learning = new LearningHistory()
            {
                date = DateTime.Now,
                idDataSet = (int)buff,
                version = textBox2.Text,
                comment = textBox3.Text,
                iter = 1000
            };
            var learningF = new LearningHistoryFilter()
            {
                Date = learning.date,
                IdDataSet = learning.idDataSet,
                Version = learning.version,
                Comment = learning.comment,
                
            };
            using (var requster = new Requester<LearningHistory, LearningHistoryFilter>(Param.Serv.host))
            {
                string er = requster.Insert(learning);
                try
                {
                    var t = requster.Select(learningF);
                    var f = new Actual()
                    {
                        conf = bytes,
                        name = textBox4.Text,
                        idLearningHistory = t[0].id
                    };
                    using (var req = new Requester<Actual, ActualFilter>(Param.Serv.host))
                    {
                        var ers = req.Insert(f);
                        if (ers == "")
                            Close();
                        else
                        {
                            MessageBox.Show(
                                ers,
                                "Внимаение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                    ex.Message,
                    "Внимаение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    return;
                }
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                var str = "Для обучения необходимо:\n" +
                    "1.Выбрать набор данных\n" +
                    "2.Выбрать разделение данных, " +
                    "используется для разделения набора " +
                    "данных на данные для теста и обучения, если не знаете " +
                    "зачем это, то оставьте на стандартном значении\n" +
                    "3.Загрузите данные\n" +
                    "4.Нажмите кнопку \"Обучить\", ожидайте пока не появится сообщение\n" +
                    "5.Опционально, можете провести свой собственный тест, " +
                    "результатом будет признак, который вы установили ранее\n" +
                    "6.Заполните версию, название, коментарий и нажмите сохранить";
                var info = new Info(str);
                info.ShowDialog();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var str = "Для обучения необходимо:\n" +
                    "1.Выбрать набор данных\n" +
                    "2.Выбрать разделение данных, " +
                    "используется для разделения набора " +
                    "данных на данные для теста и обучения, если не знаете " +
                    "зачем это, то оставьте на стандартном значении\n" +
                    "3.Загрузите данные\n" +
                    "4.Нажмите кнопку \"Обучить\", ожидайте пока не появится сообщение\n" +
                    "5.Опционально, можете провести свой собственный тест, " +
                    "результатом будет признак, который вы установили ранее\n" +
                    "6.Заполните версию, название, коментарий и нажмите сохранить";
            var info = new Info(str);
            info.ShowDialog();
        }
    }
}
