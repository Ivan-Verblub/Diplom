using Gos.Server;
using Gos.Server.Atribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ch = new ChangingForm<T, F>();
            ch.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var filter = typeof(F).GetConstructor(Type.EmptyTypes).Invoke(null);
            var props = filter.GetType().GetProperties();
            foreach (var prop in props)
            {
                var key = prop.GetCustomAttributes(typeof(Key), true);
                if (key.Count() != 0)
                {
                    if (((Key)key[0]).IsKey)
                    {
                        prop.SetValue(filter, df.SelectId());
                    }
                }
            }
            var ch = new ChangingForm<T, F>((F)filter);
            ch.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
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
                            prop.SetValue(table, df.SelectId());
                        }
                    }
                }
                using (var requester = new Requester<T, F>("https://localhost:5001"))
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
    }
}
