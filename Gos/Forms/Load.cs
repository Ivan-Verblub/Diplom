using Gos.Forms.Сustom;
using Gos.Server;
using Gos.Server.Models.Filter;
using Gos.Server.Models.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms
{
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
        }

        private async void Load_Shown(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                Invoke((Action)(() => { label1.Text = "Инициализация приложения"; }));
                if (!Directory.Exists("Settings"))
                {
                    Invoke((Action)(() => { label1.Text = "Создния директории настроек"; }));
                    Directory.CreateDirectory("Settings");
                }
                while (true)
                {
                    Invoke((Action)(() => { label1.Text = "Попытка считывания настроек"; }));
                    if (File.Exists("Settings\\Server.json"))
                    {
                        try
                        {
                            Param.Serv = JsonSerializer.Deserialize<Server.Models.Requesting.Server>(
                                File.ReadAllText("Settings\\Server.json"));
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        Invoke((Action)(() => 
                        {
                            label1.Text = "Файл настроек не найден"; 
                        }));
                        var set = new SetAdress();
                        if (set.ShowDialog() == DialogResult.Yes)
                        {
                            Param.Serv.host = set.Adress;
                        }
                        else
                        {
                            Invoke((Action)(() =>
                            {
                                Environment.Exit(0);
                            }));
                        }
                    }
                    Invoke((Action)(() =>
                    {
                        label1.Text = "Попытка подключения к серверу";
                    }));
                    try
                    {
                        using (var requester = new Requester<Scat, ScatFilter>(Param.Serv.host))
                        {
                            requester.Select();
                            break;
                        }
                    }
                    catch
                    {
                        var res = MessageBox.Show(
                            "Ошибка при подключении к серверу, если вы " +
                            "не уверены в параметрах, то можете их изменить. " +
                            "Существующие настройки будут удалены.",
                            "Ошибка",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            if (File.Exists("Settings\\Server.json"))
                            {
                                File.Delete("Settings\\Server.json");
                            }
                            continue;
                        }
                        else
                        {
                            Invoke((Action)(() =>
                            {
                                Environment.Exit(0);
                            }));
                        }
                    }
                }
                var json = JsonSerializer.Serialize<Server.Models.Requesting.Server>(Param.Serv);
                File.WriteAllText("Settings\\Server.json", json);
                Invoke((Action)(() =>
                {
                    label1.Text = "Приложение готово к запуску";
                    button1.Enabled = true;
                }));
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
