using Gos.Forms.Generic;
using Gos.Server;
using Gos.Server.Models.Filter;
using Gos.Server.Models.Table;
using Server.Controllers.Models;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms.Сustom
{
    public partial class PathTester : Form
    {
        public PathTester()
        {
            InitializeComponent();
            using (var requster = new Requester<Context,
                ContextFilter>(Param.Serv.host))
            {
                comboBox2.DataSource = requster.Select();
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "domen";
            }
            using (var requster = new Requester<Context,
                ContextFilter>(Param.Serv.host))
            {
                comboBox1.DataSource = requster.Select();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "domen";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show(
                    "Заполните ссылку на страницу характеристик",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show(
                    "Заполните путь до таблицы",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show(
                    "Заполните путь до строки",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show(
                    "Заполните путь до названия",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show(
                    "Заполните путь до значения",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                textBox5.Focus();
                return;
            }

            var p = new PathP();
            p.Table = textBox2.Text;
            p.Row = textBox3.Text;
            p.Title = textBox4.Text;
            p.Value = textBox5.Text;
            string json = JsonSerializer.Serialize<PathP>(p);
            var request = WebRequest.Create(Param.Serv.host+$"/Tester/Product?link={textBox1.Text}");
            request.Method = "POST";
            request.ContentType = "application/json";
            var bytes = Encoding.UTF8.GetBytes(json);
            request.ContentLength = bytes.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0,bytes.Length);
                stream.Close();
            }
            try
            {
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        if(bool.Parse(reader.ReadToEnd()))
                        {
                            button4.Enabled = true;
                            MessageBox.Show(
                                "Есть возможность сохранить",
                                "Успех",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            button4.Enabled = false;
                            MessageBox.Show(
                                "Пути не достаточно точные. " +
                                "В таблице невозможно найти строки или " +
                                "в строке невозможно найти данные.",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                button4.Enabled = false;
                MessageBox.Show(
                    "Ошибка на стороне сервера",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox9.Text))
            {
                MessageBox.Show(
                    "Заполните ссылку на страницу каталога",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                textBox9.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show(
                    "Заполните путь до активной кнопки далее",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                textBox8.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show(
                    "Заполните путь до ссылки",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                textBox7.Focus();
                return;
            }

            if (String.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show(
                    "Заполните путь до названия",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                textBox6.Focus();
                return;
            }

            var p = new PathC();
            p.Next = textBox8.Text;
            p.Cell = textBox7.Text;
            p.CellName = textBox6.Text;     
            string json = JsonSerializer.Serialize<PathC>(p);
            var request = WebRequest.Create(Param.Serv.host+$"/Tester/Catalog?link={textBox9.Text}");
            request.Method = "POST";
            request.ContentType = "application/json";
            var bytes = Encoding.UTF8.GetBytes(json);
            request.ContentLength = bytes.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }
            try
            {
                using (var stream = request.GetResponse().GetResponseStream())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        if (bool.Parse(reader.ReadToEnd()))
                        {
                            button3.Enabled = true;
                            MessageBox.Show(
                                "Есть возможность сохранить",
                                "Успех",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            button3.Enabled = false;
                            MessageBox.Show(
                                "Пути не достаточно точные.",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                button3.Enabled = false;
                MessageBox.Show(
                    "Ошибка на стороне сервера",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var path = new Paths()
            {
                idContext = (int)comboBox1.SelectedValue,
                path = textBox2.Text.Replace("\'", "\\\'").Replace("\"", "\\\""),
                cclass = (int)PathClass.XPATH,
                type = (int)PathType.TABLE
            };
            using (var requster = new Requester<Paths,
                PathsFilter>(Param.Serv.host))
            {
                requster.Insert(path);
            }

            path = new Paths()
            {
                idContext = (int)comboBox1.SelectedValue,
                path = textBox3.Text.Replace("\'", "\\\'").Replace("\"", "\\\""),
                cclass = (int)PathClass.XPATH,
                type = (int)PathType.ROW
            };
            using (var requster = new Requester<Paths,
                PathsFilter>(Param.Serv.host))
            {
                requster.Insert(path);
            }

            path = new Paths()
            {
                idContext = (int)comboBox1.SelectedValue,
                path = textBox4.Text.Replace("\'", "\\\'").Replace("\"", "\\\""),
                cclass = (int)PathClass.XPATH,
                type = (int)PathType.COLUMNTITLE
            };
            using (var requster = new Requester<Paths,
                PathsFilter>(Param.Serv.host))
            {
                requster.Insert(path);
            }

            path = new Paths()
            {
                idContext = (int)comboBox1.SelectedValue,
                path = textBox5.Text.Replace("\'", "\\\'").Replace("\"", "\\\""),
                cclass = (int)PathClass.XPATH,
                type = (int)PathType.COLUMNVALUE
            };
            using (var requster = new Requester<Paths,
                PathsFilter>(Param.Serv.host))
            {
                requster.Insert(path);
            }
            MessageBox.Show(
                "Пути сохранены",
                "Успех",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var path = new Paths()
            {
                idContext = (int)comboBox2.SelectedValue,
                path = textBox8.Text.Replace("\'", "\\\'").Replace("\"", "\\\""),
                cclass = (int)PathClass.XPATH,
                type = (int)PathType.NEXT
            };
            using (var requster = new Requester<Paths,
                PathsFilter>(Param.Serv.host))
            {
                requster.Insert(path);
            }

            path = new Paths()
            {
                idContext = (int)comboBox2.SelectedValue,
                path = textBox7.Text.Replace("\'", "\\\'").Replace("\"", "\\\""),
                cclass = (int)PathClass.XPATH,
                type = (int)PathType.CELL
            };
            using (var requster = new Requester<Paths,
                PathsFilter>(Param.Serv.host))
            {
                requster.Insert(path);
            }

            path = new Paths()
            {
                idContext = (int)comboBox2.SelectedValue,
                path = textBox6.Text.Replace("\'", "\\\'").Replace("\"", "\\\""),
                cclass = (int)PathClass.XPATH,
                type = (int)PathType.CELLNAME
            };
            using (var requster = new Requester<Paths,
                PathsFilter>(Param.Serv.host))
            {
                requster.Insert(path);
            }
            MessageBox.Show(
                "Пути сохранены",
                "Успех",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            var str = "Для заполнения путей страницы с характеристиками следует заполнить:\n" +
                "1.Ссылку на страницу характеристик\n" +
                "2.Путь до таблицы\n" +
                "3.Путь до строки в таблице указаной выше\n" +
                "4.Путь до ячейки с названием в строке указаной выше\n" +
                "5.Путь до ячейки со значением в строке указаной выше\n" +
                "6.Нажать кнопку \"Тест\", при неудачном результате перепроверьте структуру путей\n" +
                "7.При удачном результате выберите необходимый контекст и сохраните результат" +
                "Для заполнения путей страницы с каталогом необходимо заполнить:\n" +
                "1.Ссылка на страницу каталога обязательно с активной кнопкой далее\n" +
                "2.Путь до активной кнопки далее\n" +
                "3.Путь до ссылки на страницу с товаром\n" +
                "4.Путь до названия товара на странице каталога\n" +
                "5.Повторить 6-7 пункты предыдущего списка\n" +
                "Пути до элементов страницы записываются по стандарту XPath.\n" +
                "XPath являются относительными путями или шаблонами для элементов.\n" +
                "Для заполнения путей будет достаточно использователь следующею структуру.\n" +
                "//тэг[Условие][//тег[Условие]]\n" +
                "Условия записываются в [] и являются логическими.\n" +
                "@параментр = 'значение' - точное значение\n" +
                "(условие and условие) - лоческое И\n" +
                "(условие or условие) - логическое ИЛИ\n" +
                "not(условие) - логическое НЕ\n" +
                "contains(@параметр,'значение') - проверка на содержание первой строки вторую\n" +
                "Пример:\n//a[contains(@class,'catalog-product__name') and contains(@class,'ui-link')]//span";
            var info = new Info(str);
            info.Show();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                var str = "Для заполнения путей страницы с характеристиками следует заполнить:\n" +
                    "1.Ссылку на страницу характеристик\n" +
                    "2.Путь до таблицы\n" +
                    "3.Путь до строки в таблице указаной выше\n" +
                    "4.Путь до ячейки с названием в строке указаной выше\n" +
                    "5.Путь до ячейки со значением в строке указаной выше\n" +
                    "6.Нажать кнопку \"Тест\", при неудачном результате перепроверьте структуру путей\n" +
                    "7.При удачном результате выберите необходимый контекст и сохраните результат" +
                    "Для заполнения путей страницы с каталогом необходимо заполнить:\n" +
                    "1.Ссылка на страницу каталога обязательно с активной кнопкой далее\n" +
                    "2.Путь до активной кнопки далее\n" +
                    "3.Путь до ссылки на страницу с товаром\n" +
                    "4.Путь до названия товара на странице каталога\n" +
                    "5.Повторить 6-7 пункты предыдущего списка\n" +
                    "Пути до элементов страницы записываются по стандарту XPath.\n" +
                    "XPath являются относительными путями или шаблонами для элементов.\n" +
                    "Для заполнения путей будет достаточно использователь следующею структуру.\n" +
                    "//тэг[Условие][//тег[Условие]]\n" +
                    "Условия записываются в [] и являются логическими.\n" +
                    "@параментр = 'значение' - точное значение\n" +
                    "(условие and условие) - лоческое И\n" +
                    "(условие or условие) - логическое ИЛИ\n" +
                    "not(условие) - логическое НЕ\n" +
                    "contains(@параметр,'значение') - проверка на содержание первой строки вторую\n" +
                    "Пример:\n//a[contains(@class,'catalog-product__name') and contains(@class,'ui-link')]//span";
                var info = new Info(str);
                info.Show();
                
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
