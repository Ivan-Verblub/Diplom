using Gos.Forms.Generic;
using Gos.Server;
using Gos.Server.Atribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gos.Forms
{
    public partial class Buttons<T,F> : Form where T : class where F : class
    {
        private DataForm<T, F> df;
        private EventController ec = EventController.Instance;
        public Buttons(DataForm<T,F> df)
        {
            InitializeComponent();
            this.df = df;
            if (null != typeof(T).GetCustomAttribute<Insertable>())
                button1.Visible = true;
            if (null != typeof(T).GetCustomAttribute<Updateable>())
                button2.Visible = true;
            if (null != typeof(T).GetCustomAttribute<Deleteable>())
                button3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ch = new ChangingForm<T, F>();
            ch.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(df.SelectId() == null)
            {
                MessageBox.Show("Запись не выбрана",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            var filter = typeof(F).GetConstructor(Type.EmptyTypes).Invoke(null);
            var props = filter.GetType().GetProperties();
            foreach (var prop in props)
            {
                var key = prop.GetCustomAttributes(typeof(Key), true);
                if (key.Count() != 0)
                {
                    if (((Key)key[0]).IsKey)
                    {
                        try
                        {
                            prop.SetValue(filter, int.Parse((string)df.SelectId()));
                        }
                        catch
                        {
                            prop.SetValue(filter, df.SelectId());
                        }
                    }
                }
            }
            var ch = new ChangingForm<T, F>((F)filter);
            ch.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (df.SelectId() == null)
            {
                MessageBox.Show("Запись не выбрана",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show(
                "Вы точно хотите удалить запись?",
                "Удаление",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var table = typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
                var props = table.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var key = prop.GetCustomAttributes(typeof(Key), true);
                    if (key.Count() != 0)
                    {
                        if (((Key)key[0]).IsKey)
                        {
                            try
                            {
                                prop.SetValue(table, int.Parse((string)df.SelectId()));
                            }
                            catch
                            {
                                prop.SetValue(table, df.SelectId());
                            }
                        }
                    }
                }
                using (var requester = new Requester<T, F>(Param.Serv.host))
                {
                    string er = "";
                    er = (string)requester.GetType()
                        .GetMethod("Delete", new Type[] { typeof(T) })
                        .Invoke(requester, new object[] { table });
                    if (er == "")
                    {
                        ec.InvokeUpdateTable();
                    }
                    else
                    {
                        MessageBox.Show(
                            er, "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var i = new InfoDictionary();
            var info = new Info(i.InfoForm[typeof(T).Name]);
            info.ShowDialog();
        }

        public void Buttons_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                var i = new InfoDictionary();
                var info = new Info(i.InfoForm[typeof(T).Name]);
                info.ShowDialog();
            }
        }
    }
}
